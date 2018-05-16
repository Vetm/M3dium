﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUEAmbient
{
    public class ScreenTools
    {
        private Bitmap _newBitmap;
        private Bitmap _prevBitmap;

        public Bitmap Screen(ref Rectangle bounds)
        {
            // Capture a new screenshot.
            //
            _newBitmap = CaptureScreen.CaptureDesktop();

            // If we have a previous screenshot, only send back
            //    a subset that is the minimum rectangular area
            //    that encompasses all the changed pixels.
            //
            if (_prevBitmap != null)
            {
                // Get the bounding box.
                //
                bounds = GetBoundingBoxForChanges();
                if (bounds == Rectangle.Empty)
                {
                    // Nothing has changed.
                    //
                    return null;
                }

                // Get the minimum rectangular area
                //
                Bitmap diff = new Bitmap(bounds.Width, bounds.Height);
                Graphics g = Graphics.FromImage(diff);
                g.DrawImage(_newBitmap, 0, 0, bounds, GraphicsUnit.Pixel);
                g.Dispose();

                // Set the current bitmap as the previous to prepare
                //    for the next screen capture.
                //
                _prevBitmap = _newBitmap;

                return diff;
            }
            // We don't have a previous screen capture. Therefore
            //    we need to send back the whole screen this time.
            //
            else
            {
                // Set the previous bitmap to the current to prepare
                //    for the next screen capture.
                //
                _prevBitmap = _newBitmap;

                // Create a bounding rectangle.
                //
                bounds = new Rectangle(0, 0, _newBitmap.Width, _newBitmap.Height);

                return _newBitmap;
            }
        }

        private Rectangle GetBoundingBoxForChanges()
        {
            // The search algorithm starts by looking
            //    for the top and left bounds. The search
            //    starts in the upper-left corner and scans
            //    left to right and then top to bottom. It uses
            //    an adaptive approach on the pixels it
            //    searches. Another pass is looks for the
            //    lower and right bounds. The search starts
            //    in the lower-right corner and scans right
            //    to left and then bottom to top. Again, an
            //    adaptive approach on the search area is used.
            //

            // Note: The GetPixel member of the Bitmap class
            //    is too slow for this purpose. This is a good
            //    case of using unsafe code to access pointers
            //    to increase the speed.
            //

            // Validate the images are the same shape and type.
            //
            if (_prevBitmap.Width != _newBitmap.Width ||
                _prevBitmap.Height != _newBitmap.Height ||
                _prevBitmap.PixelFormat != _newBitmap.PixelFormat)
            {
                // Not the same shape...can't do the search.
                //
                return Rectangle.Empty;
            }

            // Init the search parameters.
            //
            int width = _newBitmap.Width;
            int height = _newBitmap.Height;
            int left = width;
            int right = 0;
            int top = height;
            int bottom = 0;

            BitmapData bmNewData = null;
            BitmapData bmPrevData = null;
            try
            {
                // Lock the bits into memory.
                //
                bmNewData = _newBitmap.LockBits(
                    new Rectangle(0, 0, _newBitmap.Width, _newBitmap.Height),
                    ImageLockMode.ReadOnly, _newBitmap.PixelFormat);
                bmPrevData = _prevBitmap.LockBits(
                    new Rectangle(0, 0, _prevBitmap.Width, _prevBitmap.Height),
                    ImageLockMode.ReadOnly, _prevBitmap.PixelFormat);

                // The images are ARGB (4 bytes)
                //
                int numBytesPerPixel = 4;

                // Get the number of integers (4 bytes) in each row
                //    of the image.
                //
                int strideNew = bmNewData.Stride / numBytesPerPixel;
                int stridePrev = bmPrevData.Stride / numBytesPerPixel;

                // Get a pointer to the first pixel.
                //
                // Note: Another speed up implemented is that I don't
                //    need the ARGB elements. I am only trying to detect
                //    change. So this algorithm reads the 4 bytes as an
                //    integer and compares the two numbers.
                //
                System.IntPtr scanNew0 = bmNewData.Scan0;
                System.IntPtr scanPrev0 = bmPrevData.Scan0;

                // Enter the unsafe code.
                //
                unsafe
                {
                    // Cast the safe pointers into unsafe pointers.
                    //
                    int* pNew = (int*)(void*)scanNew0;
                    int* pPrev = (int*)(void*)scanPrev0;

                    // First Pass - Find the left and top bounds
                    //    of the minimum bounding rectangle. Adapt the
                    //    number of pixels scanned from left to right so
                    //    we only scan up to the current bound. We also
                    //    initialize the bottom & right. This helps optimize
                    //    the second pass.
                    //
                    // For all rows of pixels (top to bottom)
                    //
                    for (int y = 0; y < _newBitmap.Height; ++y)
                    {
                        // For pixels up to the current bound (left to right)
                        //
                        for (int x = 0; x < left; ++x)
                        {
                            // Use pointer arithmetic to index the
                            //    next pixel in this row.
                            //
                            if ((pNew + x)[0] != (pPrev + x)[0])
                            {
                                // Found a change.
                                //
                                if (x < left)
                                {
                                    left = x;
                                }
                                if (x > right)
                                {
                                    right = x;
                                }
                                if (y < top)
                                {
                                    top = y;
                                }
                                if (y > bottom)
                                {
                                    bottom = y;
                                }
                            }
                        }

                        // Move the pointers to the next row.
                        //
                        pNew += strideNew;
                        pPrev += stridePrev;
                    }

                    // If we did not find any changed pixels
                    //    then no need to do a second pass.
                    //
                    if (left != width)
                    {
                        // Second Pass - The first pass found at
                        //    least one different pixel and has set
                        //    the left & top bounds. In addition, the
                        //    right & bottom bounds have been initialized.
                        //    Adapt the number of pixels scanned from right
                        //    to left so we only scan up to the current bound.
                        //    In addition, there is no need to scan past
                        //    the top bound.
                        //

                        // Set the pointers to the first element of the
                        //    bottom row.
                        //
                        pNew = (int*)(void*)scanNew0;
                        pPrev = (int*)(void*)scanPrev0;
                        pNew += (_newBitmap.Height - 1) * strideNew;
                        pPrev += (_prevBitmap.Height - 1) * stridePrev;

                        // For each row (bottom to top)
                        //
                        for (int y = _newBitmap.Height - 1; y > top; y--)
                        {
                            // For each column (right to left)
                            //
                            for (int x = _newBitmap.Width - 1; x > right; x--)
                            {
                                // Use pointer arithmetic to index the
                                //    next pixel in this row.
                                //
                                if ((pNew + x)[0] != (pPrev + x)[0])
                                {
                                    // Found a change.
                                    //
                                    if (x > right)
                                    {
                                        right = x;
                                    }
                                    if (y > bottom)
                                    {
                                        bottom = y;
                                    }
                                }
                            }

                            // Move up one row.
                            //
                            pNew -= strideNew;
                            pPrev -= stridePrev;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                int xxx = 0;
            }
            finally
            {
                // Unlock the bits of the image.
                //
                if (bmNewData != null)
                {
                    _newBitmap.UnlockBits(bmNewData);
                }
                if (bmPrevData != null)
                {
                    _prevBitmap.UnlockBits(bmPrevData);
                }
            }

            // Validate we found a bounding box. If not
            //    return an empty rectangle.
            //
            int diffImgWidth = right - left + 1;
            int diffImgHeight = bottom - top + 1;
            if (diffImgHeight < 0 || diffImgWidth < 0)
            {
                // Nothing changed
                return Rectangle.Empty;
            }

            // Return the bounding box.
            //
            return new Rectangle(left, top, diffImgWidth, diffImgHeight);
        }

    }
}
