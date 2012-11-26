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
            InitializeComponent();
            notifyIcon.Text = Name;

            helpProvider.HelpNamespace = "\\help.chm";
            

            //notifyIcon.BalloonTipTitle = "title";          
            notifyIcon.Icon = new System.Drawing.Icon("Game.ico");
            notifyIcon.Visible = true;
            ///popup create
            this.popup = new Popup();
            this.popup.CustomPopupPlacementCallback = new CustomPopupPlacementCallback(placePopup);
            this.popup.Placement = PlacementMode.Custom;

            
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
                     this.popup.Child = box;///add window to popup as child
                     mainTextBlock.Text += box.labelTime.Content + ":  " +a.addTextBox.Text + "\n";
                    // notifyIcon.BalloonTipText = a.addTextBox.Text;
                    // notifyIcon.ShowBalloonTip(3);
                     
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
               new CustomPopupPlacement(new Point(-1000, 100), PopupPrimaryAxis.Vertical);

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
            

            if (File.Exists(helpFile))
            {
                System.Windows.Forms.Help.ShowHelp(null, helpFile);
            }
            else
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
    }
}
