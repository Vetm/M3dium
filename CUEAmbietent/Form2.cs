using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;


namespace M3dium
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            CheckBox_startwwindows.Checked = Properties.Settings.Default.Start_with_windows;
            CheckBox_startminimized.Checked = Properties.Settings.Default.Start_minimized;
            CheckBox_displaycolor.Checked = Properties.Settings.Default.Display_color;
            CheckBox_enablewstart.Checked = Properties.Settings.Default.Enable_with_application_start;
        }

        private void CheckBox_startwwindows_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_startwwindows.Checked)
            {
                Properties.Settings.Default.Start_with_windows = true;
                RunOnStartup();
                if (!Properties.Settings.Default.Enable_with_application_start)
                {
                    ToolTip tooltip2 = new ToolTip();
                    tooltip2.AutoPopDelay = 7;
                    tooltip2.Show("Recommended in case of run on startup", CheckBox_enablewstart);
                }
            }
            else
            {
                Properties.Settings.Default.Start_with_windows = false;
                RunNotOnStartup();
            }
            Properties.Settings.Default.Save();
        }

        private void CheckBox_displaycolor_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_displaycolor.Checked)
            {
                Properties.Settings.Default.Display_color = true;
                //CUEAmbient.Program.main.show_color();
            }
            else
            {
                Properties.Settings.Default.Display_color = false;
                //CUEAmbient.Program.main.hide_color();
            }
            Properties.Settings.Default.Save();
        }

        private void CheckBox_enablewstart_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_enablewstart.Checked)
            {
                Properties.Settings.Default.Enable_with_application_start = true;
            }
            else
            {
                Properties.Settings.Default.Enable_with_application_start = false;
            }
            Properties.Settings.Default.Save();
        }

        private void CheckBox_startminimized_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_startminimized.Checked)
            {
                Properties.Settings.Default.Start_minimized = true;
            }
            else
            {
                Properties.Settings.Default.Start_minimized = false;
            }
            Properties.Settings.Default.Save();
        }

        byte[] active = new byte[]
        {
            0x02,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
        };
        byte[] inactive = new byte[]
        {
            0x03,0x00,0x00,0x00,0x22,0xaa,0xf9,0x83,0x15,0xe5,0xd3,0x01
        };

        private void RunOnStartup()
        {
            //string startup_dir = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MICROSOFT\\WINDOWS\\CurrentVersion\\Run", true);
            add.SetValue("M3dium", "\"" + Application.ExecutablePath.ToString() + "\"");
            RegistryKey myKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MICROSOFT\\WINDOWS\\CurrentVersion\\Explorer\\StartupApproved\\Run", true);
            myKey.SetValue("M3dium", active, RegistryValueKind.Binary);
            add.Close();
            myKey.Close();
            registry_delete_button.Enabled = true;
        }

        private void RunNotOnStartup()
        {
            RegistryKey myKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MICROSOFT\\WINDOWS\\CurrentVersion\\Explorer\\StartupApproved\\Run", true);
            myKey.SetValue("M3dium", inactive, RegistryValueKind.Binary);
            myKey.Close();
        }

        private void RemoveKey()
        {
            RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MICROSOFT\\WINDOWS\\CurrentVersion\\Run", true);
            RegistryKey myKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MICROSOFT\\WINDOWS\\CurrentVersion\\Explorer\\StartupApproved\\Run", true);
            try
            {
                add.DeleteValue("M3dium");
                myKey.DeleteValue("M3dium");
            }
            catch
            {
            }
            finally
            {
                Properties.Settings.Default.Start_with_windows = false;
                Properties.Settings.Default.Save();
                CheckBox_startwwindows.Checked = false;
                registry_delete_button.Enabled = false;
                add.Close();
                myKey.Close();
            }
        }

        private void registry_delete_button_Click(object sender, EventArgs e)
        {
            RemoveKey();
        }
    }
}
