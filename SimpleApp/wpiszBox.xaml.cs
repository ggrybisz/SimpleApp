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
using System.Windows.Shapes;

namespace proj
{
    /// <summary>
    /// Interaction logic for wpiszBox.xaml
    /// </summary>
    public partial class wpiszBox : Window
    {
        public wpiszBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method executed when user clicks on the button of this Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, RoutedEventArgs e)
        {            
            Close();
        }
    }
}
