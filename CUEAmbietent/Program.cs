using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using CUE.NET;
using CUE.NET.Devices.Keyboard;
using CUE.NET.Exceptions;
using CUE.NET.Devices.Generic.Enums;
using System.Drawing;
using CUE.NET.Devices.Keyboard.Enums;

namespace CUEAmbient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 main = new Form1();
            Application.Run(main);
        }

        //public static 
    }
}
