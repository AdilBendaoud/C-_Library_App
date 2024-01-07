using CustomMessageBox;
using GestionBibliotheque.Model;
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
using System.Windows.Shapes;

namespace GestionBibliotheque
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void ButtonClickHandler(object sender, RoutedEventArgs e)
        {
            using (var context = new Database())
            {
                var user = context.Users.SingleOrDefault(u => u.CIN == CINInput.Text && u.Password == passwordInput.Password.ToString());
                if (user != null)
                {
                    Empruntes empruntes = new Empruntes();
                    empruntes.setUser(user);
                    empruntes.Show();
                    Close();
                }
                else
                {
                    bool? Result = new MessageBoxCustom("Mot de passe ou CIN incorrecte !!", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
            }
        }
        
    }
}
