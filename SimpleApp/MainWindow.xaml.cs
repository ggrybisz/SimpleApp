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

namespace proj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// This class serves as main application window 
    /// and point of origin for whole workflow
    /// </summary>
    public partial class MainWindow : Window
    {
        
        System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();
        public MainWindow()
        {
            InitializeComponent();
            notifyIcon.Text = Name;
            
            //notifyIcon.BalloonTipTitle = "title";          
            notifyIcon.Icon = new System.Drawing.Icon("Game.ico");
            notifyIcon.Visible = true;
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
             wpiszBox a = new wpiszBox();
             a.ShowDialog();
             
             try
             {
                 if (a.addTextBox.Text != "" && a.addTextBox.Text != null)
                 {
                     mainTextBlock.Text += a.addTextBox.Text + "\n";
                     notifyIcon.BalloonTipText = a.addTextBox.Text;
                     notifyIcon.ShowBalloonTip(3);
                 }
                 else
                 {
                     throw (new Exception("Brak tekstu, weź coś wpisz!"));
                 }
             }
             catch(Exception exp)
             {
                 MessageBox.Show(exp.Message);
             }
             finally
             {
                 //wrazie gdyby cos trzeba bylo dodac
             }
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            Help helpWindow = new Help();
            helpWindow.ShowDialog();
        }
    }
}
