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
    /// Interaction logic for EmployeForm.xaml
    /// </summary>
    public partial class EmployeForm : Window
    {
        public EmployeForm()
        {
            InitializeComponent();
            updateBtn.Visibility = Visibility.Collapsed;
            deleteBtn.Visibility = Visibility.Collapsed;
        }
        public EmployeForm(object aut)
        {
            InitializeComponent();
            User user = (User)aut;
            cinInput.Text = user.CIN;
            nomInput.Text = user.Nom;
            prenomInput.Text = user.Prenom;
            emailInput.Text = user.Email;
            adresseInput.Text = user.Adresse;
            telInput.Text = user.Tel.ToString();
            if (user.IsAdmin){empRadio.IsChecked= true;}
            if (user.IsSuperAdmin) { adminRadio.IsChecked = true; }

            addBtn.Visibility = Visibility.Collapsed;
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

        private void updateClick(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new Database())
            {
                var existingUser = dbContext.Users.FirstOrDefault(e => e.CIN== cinInput.Text);
                if (existingUser != null)
                {
                    existingUser.Nom = nomInput.Text;
                    existingUser.Prenom = prenomInput.Text;
                    existingUser.Email = emailInput.Text;
                    existingUser.Adresse = adresseInput.Text;
                    if(telInput.Text != ""){existingUser.Tel = Int32.Parse(telInput.Text);}
                    existingUser.IsAdmin = (empRadio.IsChecked == true);
                    existingUser.IsSuperAdmin = (adminRadio.IsChecked == true);
                }
                dbContext.SaveChanges();
                Close();
            }
        }

        private void deleteClick(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Voulez-vous vraiment supprimer ce employe ?", MessageType.Confirmation, MessageButtons.OkCancel).ShowDialog();
            if (result != null && (bool)result)
            {
                using (var dbContext = new Database())
                {
                    var existingUser = dbContext.Users.First(b => b.CIN == cinInput.Text);
                    if (existingUser != null)
                    {
                        dbContext.Users.Remove(existingUser);
                        dbContext.SaveChanges();
                        Close();
                    }
                }
            }
        }

        private void addClick(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new Database())
            {
                User user = new User();
                user.CIN = cinInput.Text;
                user.Nom = nomInput.Text;
                user.Prenom = prenomInput.Text;
                user.Email = emailInput.Text;
                user.Adresse = adresseInput.Text;
                user.Tel = Int32.Parse(telInput.Text);
                user.IsAdmin = (empRadio.IsChecked == true);
                user.Password = prenomInput.Text + "."+ nomInput.Text;
                user.IsSuperAdmin = (adminRadio.IsChecked == true);
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                Close();
            }
        }
    }
}
