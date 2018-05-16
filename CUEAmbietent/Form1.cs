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
using M3dium.Properties;


namespace CUEAmbient
{

    public partial class Form1 : Form
    {
        private int lightningMode = 0;
        private bool active;
        private Timer timer;
        private Timer settings_timer;
        M3dium.Form2 settings_form;
        CorsairKeyboard keyboard;
        RectangleKeyGroup[,] ambientRect = new RectangleKeyGroup[22, 7];
        ContextMenu context = new ContextMenu();

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
            if (Settings.Default.Start_minimized)
            {
                notifyIcon.Visible = true;
            }
            if (Settings.Default.Enable_with_application_start)
            {
                lightningMode = 0;
                active = true;
            }
            if (Settings.Default.Display_color)
            {
                currentcolor.Visible = true;
            }
            context.MenuItems.Add(0, new MenuItem("Exit", new System.EventHandler(Close)));
            notifyIcon.ContextMenu = context;
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
            if (Settings.Default.Display_color) update_color_display(background);
            brush = new SolidColorBrush(background);
            brush.Brightness = 1f;
            keyboard.Brush = brush;
            keyboard.Update();
        }

        void update_color_display(Color background)
        {
            currentcolor.Text = "Color: " + "R " + background.R + ",G " + background.G + ",B " + background.B;
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
        
        public void show_color()
        {
            currentcolor.Visible = true;
        }

        public void hide_color()
        {
            currentcolor.Visible = false;
        }

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

        private void settings_button_Click(object sender, EventArgs e)
        {
            settings_form = new M3dium.Form2();
            settings_form.Show();
            settings_timer = new Timer();
            settings_timer.Tick += new EventHandler(Check_Form);
            settings_timer.Interval = 100; // in miliseconds
            settings_timer.Start();
        }

        private void Check_Form(object sender, EventArgs e)
        {
            if (Settings.Default.Display_color)
            {
                currentcolor.Visible = true;
            }
            else
            {
                currentcolor.Visible = false;
            }
            if (settings_form.IsDisposed)
            {
                settings_timer.Stop();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
                notifyIcon.Visible = false;
            }
        }

        private void Close(Object sender, System.EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.notifyIcon.Dispose();
            base.Dispose();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (Settings.Default.Start_minimized)
            {
                this.Hide();
            }
        }
    }
}
