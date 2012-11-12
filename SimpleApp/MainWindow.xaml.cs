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
    }
}
