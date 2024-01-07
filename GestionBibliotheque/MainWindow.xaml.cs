using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionBibliotheque
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void EmpruntHandle(object sender, RoutedEventArgs e)
        {

        }

        private void AdherantHandle(object sender, RoutedEventArgs e)
        {

        }
        
        private void LivreHandle(object sender, RoutedEventArgs e)
        {
            Livres livres = new Livres();
            livres.Show();
            this.Close();
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
