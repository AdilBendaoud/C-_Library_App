using GestionBibliotheque.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Auteurs.xaml
    /// </summary>
    public partial class Auteurs : Window
    {
        private readonly ObservableCollection<Auteur> auteurList = new();
        User user;
        public Auteurs()
        {
            InitializeComponent();
            dataGrid.ItemsSource = auteurList;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LoadData();
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

        private void AdherantHandle(object sender, RoutedEventArgs e)
        {
            Adherents adherents = new Adherents();
            adherents.setUser(user);
            adherents.Show();
            Close();
        }

        private void LivreHandle(object sender, RoutedEventArgs e)
        {
            Livres livres = new();
            livres.setUser(user);
            livres.Show();
            Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            auteurForm af = new auteurForm();
            af.Show();
            if (af == null || !af.IsLoaded)
            {
                LoadData();
            }
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            Close();
        }

        private void CategorieHandle(object sender, RoutedEventArgs e)
        {
            Categories categories = new Categories();
            categories.setUser(user);
            categories.Show();
            Close();
        }
        private void Search(object sender, EventArgs e)
        {
            string searchTerm = searchInput.Text;
            if (searchTerm.Equals(""))
            {
                dataGrid.ItemsSource = auteurList;
            }
            else
            {
                ObservableCollection<Auteur> filteredBooks = new(auteurList.Where(b => b.Prenom.ToLower().Contains(searchTerm.ToLower()) ||
                                    b.Nom.ToLower().Contains(searchTerm.ToLower())));
                dataGrid.ItemsSource = filteredBooks;
            }
        }
        private void DataGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Auteur selectedBook = (Auteur)dataGrid.SelectedItem;
                auteurForm empruntForm = new auteurForm(selectedBook);
                empruntForm.Show();
                empruntForm.Closed += UpdateData;
            }
        }
        private void UpdateData(object sender, EventArgs e)
        {
            LoadData();
        }

        private void EmprruntHandle(object sender, RoutedEventArgs e)
        {
            Empruntes empruntes = new Empruntes();
            empruntes.setUser(user);
            empruntes.Show();
            Close();
        }

        private void LoadData()
        {
            auteurList.Clear();
            using (var dbContext = new Database())
            {
                var emprunts = dbContext.Auteurs.ToList();

                foreach (var temp in emprunts)
                {
                    Auteur auteur = new();
                    auteur.AuteurId = temp.AuteurId;
                    auteur.Nom = temp.Nom;
                    auteur.Prenom = temp.Prenom;
                    auteur.DateNaissance = temp.DateNaissance;
                    auteurList.Add(auteur);
                }
            }
        }

        private void goToEmployees(object sender, RoutedEventArgs e)
        {
            Employes employes = new Employes();
            employes.setUser(user);
            employes.Show();
            Close();
        }

        internal void setUser(User user)
        {
            this.user = user;
            if (user != null && user.IsAdmin) { empBtn.Visibility = Visibility.Collapsed; }
        }
    }
}
