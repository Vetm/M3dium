using CUE.NET;
using CUE.NET.Brushes;
using CUE.NET.Devices.Generic;
using CUE.NET.Devices.Generic.Enums;
using CUE.NET.Devices.Keyboard;
using CUE.NET.Devices.Keyboard.Enums;
using CUE.NET.Devices.Keyboard.Keys;
using CUE.NET.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CUEAmbietent
{

    public partial class Form1 : Form
    {
        private int lightningMode = 0;
        private bool active;
        private Timer timer;
        CorsairKeyboard keyboard;
        RectangleKeyGroup[,] ambientRect = new RectangleKeyGroup[22, 7];

        IBrush brush = null;

        public Form1()
        {
            InitializeComponent();
            Initialize();
            keyboard = CueSDK.KeyboardSDK;

            //ambientRect = GenerateAmbientKeyGroup(ambientRect);
        }

        void Initialize()
        {
            try
            {
                CueSDK.Initialize();
                //Debug.WriteLine("Initialized with " + CueSDK.LoadedArchitecture + "-SDK");

                CorsairKeyboard keyboard = CueSDK.KeyboardSDK;
                if (keyboard == null)
                    throw new WrapperException("No keyboard found");
            }
            catch (CUEException ex)
            {
                Debug.WriteLine("CUE Exception! ErrorCode: " + Enum.GetName(typeof(CorsairError), ex.Error));
            }
            catch (WrapperException ex)
            {
                Debug.WriteLine("Wrapper Exception! Message:" + ex.Message);
            }
            timer = new Timer();
            timer.Tick += new EventHandler(Refresh);
            timer.Interval = 100; // in miliseconds
            timer.Start();
        }

        private void Refresh(object sender, EventArgs e)
        {
            /*switch (lightningMode)
            {
                case 0:
                    AverageColor();
                    break;
                case 1:
                    AmbientColor();
                    break;
                case 2:
                    BottomColor();
                    break;
            }*/
            if (active)
            {
                AverageColor();
            }
            else
            {
                keyboard.Brush = null;
                keyboard.Update();
            }
        }

        void AverageColor()
        {
            ScreenTools capture = new ScreenTools();
            Rectangle bounds = new Rectangle();
            Bitmap img = capture.Screen(ref bounds);
            img = new Bitmap(img, new Size(img.Width / 100, img.Height / 100));
            Color background = getDominantColor(img);
            Debug.Print(background.ToString());
            brush = new SolidColorBrush(background);
            brush.Brightness = 1f;
            keyboard.Brush = brush;
            keyboard.Update();
        }

        /*void AmbientColor()
        {
            ScreenTools capture = new ScreenTools();
            Rectangle bounds = new Rectangle();
            Bitmap img = capture.Screen(ref bounds);
            img = new Bitmap(img, new Size(img.Width / 90, img.Height / 90));
            Color background = getDominantColor(img);
            Debug.Print(background.ToString());
            IBrush brush = new SolidColorBrush(background);
            brush.Brightness = 1f;
            keyboard.Brush = brush;
            keyboard.Update();
        }*/

        void BottomColor()
        {

        }

        public Color getDominantColor(Bitmap bmp)
        {
            int r = 0;
            int g = 0;
            int b = 0;

            int total = 0;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color clr = bmp.GetPixel(x, y);
                    r += clr.R;
                    g += clr.G;
                    b += clr.B;
                    total++;
                }
            }

            r /= total;
            g /= total;
            b /= total;

            return Color.FromArgb(r, g, b);
        }

        /*private RectangleKeyGroup[,] GenerateAmbientKeyGroup(RectangleKeyGroup[,] rectGroup)
        {
            RectangleF rect = new RectangleF();
            int xOffset = 20;
            int yOffset = 20;
            //423 maxWidth
            //137 maxHeight
            //20 horizontal Step
            //20 vertical Step
            rect.Width = 25;
            rect.Height = 25;
            for (int y = 0; y < rectGroup.GetLength(1); y++)
            {
                for (int x = 0; x < rectGroup.GetLength(0); x++)
                {
                    rect.X += xOffset;
                    rectGroup[x, y] = new RectangleKeyGroup(keyboard, rect, 0.5f, true);
                    //rectGroup[x, y].Brush = new RandomColorBrush();
                }
                rect.X = 0;
                rect.Y += yOffset;
            }

            return rectGroup;
        }*/

        private void average_On(object sender, EventArgs e)
        {
            lightningMode = 0;
            active = true;
        }

        private void average_Off(object sender, EventArgs e)
        {
            active = false;
            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            this.Close();
        }

        private void ambient_Click(object sender, EventArgs e)
        {
            lightningMode = 1;
        }

        private void bottom_Click(object sender, EventArgs e)
        {
            lightningMode = 2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
