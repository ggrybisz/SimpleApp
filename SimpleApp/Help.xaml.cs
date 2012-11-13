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
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();

            helpTextImage1.Text = "Główne okno programu\n Kliknij przycisk \"Add\" aby wpisać tereść nowej wiadomości";

            helpTextImage2.Text = "Okno wprowadzania wiadomości\n Wpisz wiadomość i naciśnij przycisk \"Send\" aby wysłać wiadomość";
        }
    }
}
