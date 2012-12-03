using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.IO;

namespace proj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// This class serves as main application window 
    /// and point of origin for whole workflow
    /// </summary>
    public partial class MainWindow : Window
    {
        private Popup popup;
        System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();
        int licznik=0;

        System.Windows.Forms.HelpProvider helpProvider = new System.Windows.Forms.HelpProvider();

        static string helpFile = ".\\help.chm";

        public MainWindow()
        {
            if (!Initial())
            {
                System.Windows.MessageBox.Show("Błąd incjalizacji");
                Close();
            }
        }

        private bool Initial()
        {
            try
            {
                InitializeComponent();
                RegEdit rejestr = new RegEdit();
               
                notifyIcon.Text = Name;
                helpProvider.HelpNamespace = "\\help.chm";
                       
                notifyIcon.Icon = new System.Drawing.Icon("Game.ico");
                notifyIcon.Visible = true;
                ///popup create
                this.popup = new Popup();
                this.popup.CustomPopupPlacementCallback = new CustomPopupPlacementCallback(placePopup);
                this.popup.Placement = PlacementMode.Custom;
                TimeLess(rejestr.TimeCheck());
                return true;
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return false;
            }
        }

        private void TimeLess(int t)
        {
            if (t < 30)
            {
                System.Windows.MessageBox.Show("Wersja o ograniczonej ilości wejść.\nZarejestruj się aby móc korzystać w pełni.", "Pozostało: "+(30 - t).ToString());
            }
            else
            {
                throw(new Exception("trial expired"));
            }
        }

        /// <summary>
        /// Method executed when user clicks on the button of this Window.
        /// It adds text fom pop-up window to text box in main window area.
        /// It also contains logic for showing tray area pop-up message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void openButton_Click(object sender, RoutedEventArgs e)
        {    
            try
             {                               
                 wpiszBox a = new wpiszBox();
                 a.ShowDialog();
                 popup.IsOpen = false;
                 
                 if (a.addTextBox.Text != "" && a.addTextBox.Text != null)
                 {
                     licznik = 0;
                     textBox box = new textBox();
                     Timer timer = new Timer();
                     timer.Interval = 1000;
                     timer.Tick += (s, ev) =>
                     {
                         licznik++;
                         if (licznik > 3)
                         {
                             popup.IsOpen = false;
                             timer.Stop();
                         }
                     };

                     box.labelTekst.Content = a.addTextBox.Text;
                     box.labelTime.Content = DateTime.Now.ToLocalTime().ToShortTimeString();
                     this.popup.Child = box;
                     mainTextBlock.Text += box.labelTime.Content + ":  " +a.addTextBox.Text + "\n";
               
                     
                     this.popup.IsOpen = true;
                     timer.Start();
                 }
                 else
                 {
                     throw (new Exception("Brak tekstu, weź coś wpisz!"));
                 }
             }
             catch(Exception exp)
             {
                 System.Windows.MessageBox.Show(exp.Message);
             }
             finally
             {
              //wrazie gdyby cos trzeba bylo dodac
             }
        }
        public CustomPopupPlacement[] placePopup(Size popupSize, Size targetSize, Point offset)
        {
            
            CustomPopupPlacement placement1 =
               new CustomPopupPlacement(new Point((System.Windows.SystemParameters.WorkArea.Width - 300), (System.Windows.SystemParameters.WorkArea.Height - 300)), PopupPrimaryAxis.Vertical);

            CustomPopupPlacement placement2 =
                new CustomPopupPlacement(new Point((System.Windows.SystemParameters.WorkArea.Width - 300),(System.Windows.SystemParameters.WorkArea.Height - 300)), PopupPrimaryAxis.Horizontal);
          
            CustomPopupPlacement[] ttplaces =
                    new CustomPopupPlacement[] { placement1, placement2 };
            return ttplaces;
        }
        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.showHelp();
        }

        public static void showHelp()
        {
            try
            {
                if (File.Exists(helpFile))
                {
                    System.Windows.Forms.Help.ShowHelp(null, helpFile);
                }
                else
                {
                    throw new Exception("No help available");
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("No help available");
            }

        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                MainWindow.showHelp();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
        }
    }
}
