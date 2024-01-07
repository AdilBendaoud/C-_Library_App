using CustomMessageBox;
using GestionBibliotheque.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for AdherentsForm.xaml
    /// </summary>
    public partial class AdherentsForm : Window
    {
        public AdherentsForm(object obj)
        {
            InitializeComponent();
            User user = (User)obj;
            prenomInput.Text = user.Prenom;
            nomInput.Text = user.Nom;
            emailInput.Text = user.Email;
            adresseInput.Text = user.Adresse;
            telInput.Text = user.Tel.ToString();
            idInput.Text = user.CIN;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Voulez-vous vraiment supprimer l'adherent ?", MessageType.Confirmation, MessageButtons.OkCancel).ShowDialog();
            if (result != null && (bool)result)
            {
                using (var dbContext = new Database())
                {
                    var existingUsers = dbContext.Users.First(u => u.CIN == idInput.Text);
                    if (existingUsers != null)
                    {
                        dbContext.Users.Remove(existingUsers);
                        dbContext.SaveChanges();
                        Close();
                    }
                }
            }
        }

        private void HandleDragWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MinimizeBtn(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        
        private void MaximizeBtn(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new Database())
            {
                var existingUsere = dbContext.Users.FirstOrDefault(e => e.CIN == idInput.Text);
                if (existingUsere != null)
                {
                    existingUsere.Nom = nomInput.Text;
                    existingUsere.Prenom = prenomInput.Text;
                    existingUsere.Tel = Int32.Parse(telInput.Text);
                    existingUsere.Email = emailInput.Text;
                    existingUsere.Adresse = adresseInput.Text;
                }
                dbContext.SaveChanges();
                Close();
            }
        }
    }
}
