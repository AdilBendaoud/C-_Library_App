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
    /// Interaction logic for auteurForm.xaml
    /// </summary>
    public partial class auteurForm : Window
    {
        public auteurForm()
        {
            InitializeComponent();
            updateBtn.Visibility = Visibility.Collapsed;
            deleteBtn.Visibility = Visibility.Collapsed;
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
                var existingAuteur = dbContext.Auteurs.FirstOrDefault(e => e.AuteurId.ToString() == idInput.Text);
                DateTime dateNaissance = DateTime.SpecifyKind(dateInput.SelectedDate.Value, DateTimeKind.Utc);
                if (existingAuteur != null)
                {
                    existingAuteur.DateNaissance = dateNaissance;
                    existingAuteur.Prenom = prenomInput.Text;
                    existingAuteur.Nom = nomInput.Text;
                }
                dbContext.SaveChanges(); 
                Close();
            }
        }

        private void deleteClick(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Voulez-vous vraiment supprimer l'auteur ?", MessageType.Confirmation, MessageButtons.OkCancel).ShowDialog();
            if (result != null && (bool)result)
            {
                using (var dbContext = new Database())
                {
                    var existing = dbContext.Auteurs.First(a => a.AuteurId.ToString() == idInput.Text);
                    if (existing != null)
                    {
                        dbContext.Auteurs.Remove(existing);
                        dbContext.SaveChanges();
                        Close();
                    }
                }
            }
        }

        private void addClick(object sender, RoutedEventArgs e)
        {
            DateTime dateNaissance = DateTime.SpecifyKind(dateInput.SelectedDate.Value, DateTimeKind.Utc);
            using (var dbContext = new Database())
            {
                Auteur aut = new Auteur();
                aut.Nom = nomInput.Text;
                aut.Prenom = prenomInput.Text;
                aut.DateNaissance = dateNaissance;
                dbContext.Auteurs.Add(aut);
                dbContext.SaveChanges();
                Close();
            }
        }

        public auteurForm(object  aut)
        {
            InitializeComponent();
            Auteur auteur1 = (Auteur)aut;
            prenomInput.Text = auteur1.Prenom;
            nomInput.Text = auteur1.Nom;
            dateInput.SelectedDate = auteur1.DateNaissance;
            idInput.Text = auteur1.AuteurId.ToString();
            addBtn.Visibility = Visibility.Collapsed;
        }
    }
}
