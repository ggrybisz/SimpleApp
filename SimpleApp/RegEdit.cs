using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace proj
{
    class RegEdit
    {
        RegistryKey rejestr;
        int loc;
        public RegEdit()
        {
            rejestr = Registry.CurrentUser.OpenSubKey("Software\\14k3_b_g\\SimpleApp",true);
            if (rejestr == null) // Jeżeli nie istnieje to utworzenie nowego
            {                
                rejestr = Registry.CurrentUser.CreateSubKey("Software\\14k3_b_g\\SimpleApp");   
            }
            var wartosc = rejestr.GetValue("wartosc");
            if (wartosc == null)
            {
                wartosc = 1;
                rejestr.SetValue("Name", "SimpleApp");
                rejestr.SetValue("Comp", "14k3_b_g");
                rejestr.SetValue("Date", DateTime.Now.Date);
                rejestr.SetValue("wartosc", wartosc);
            }
            else
            {
                wartosc = (int)wartosc + 1;
                rejestr.SetValue("wartosc", wartosc);
            }
            loc = (int)wartosc;
            rejestr.Close();
            //rejestr = Registry.CurrentUser.OpenSubKey("Software\\14k3_b_g\\SimpleApp");
            //RegistryKey rejestr = Registry.CurrentUser.OpenSubKey("Software\\14k3_b_g\\SimpleApp",true);
            //rejestr.SetValue("wersja", "1.0");
            //wartosc = rejestr.GetValue("wartosc");
            //rejestr.DeleteValue("wartosc");
            //rejestr.Close();
            //Registry.CurrentUser.DeleteSubKey("Software\\14k3_b_g\\SimpleApp");
            //Registry.CurrentUser.DeleteSubKeyTree("Software\\14k3_b_g\\SimpleApp");
        }
        public int TimeCheck()
        {
            return loc;
        }

    }
}
