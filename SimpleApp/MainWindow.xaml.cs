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

namespace proj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Popup popup;
        System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();
        int licznik=0;
        public MainWindow()
        {
            InitializeComponent();
            notifyIcon.Text = Name;
            
            //notifyIcon.BalloonTipTitle = "title";          
            notifyIcon.Icon = new System.Drawing.Icon("Game.ico");
            notifyIcon.Visible = true;
            ///popup create
            this.popup = new Popup();
            this.popup.CustomPopupPlacementCallback = new CustomPopupPlacementCallback(placePopup);
            this.popup.Placement = PlacementMode.Custom;

            
        }

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
                     mainTextBlock.Text += a.addTextBox.Text + "\n";
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


  
    }
}
