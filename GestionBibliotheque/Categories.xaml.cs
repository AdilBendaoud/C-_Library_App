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
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : Window
    {
        private readonly ObservableCollection<Categorie> categorieList = new();
        User user;
        public Categories()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dataGrid.ItemsSource = categorieList;
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

        private void LivreHandle(object sender, RoutedEventArgs e)
        {
            Livres livres = new();
            livres.setUser(user);
            livres.Show();
            Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            CategorieForm af = new CategorieForm();
            af.Show();
            af.Closed += UpdateData;
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            Close();
        }

        private void AuteursHandle(object sender, RoutedEventArgs e)
        {
            Auteurs auteur = new();
            auteur.setUser(user);
            auteur.Show();
            Close();
        }

        private void Search(object sender, EventArgs e)
        {
            string searchTerm = searchInput.Text;
            if (searchTerm.Equals(""))
            {
                dataGrid.ItemsSource = categorieList;
            }
            else
            {
                ObservableCollection<Categorie> filteredBooks = new(categorieList.Where(b => b.Nom.ToLower().Contains(searchTerm.ToLower())));
                dataGrid.ItemsSource = filteredBooks;
            }
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Categorie selectedBook = (Categorie)dataGrid.SelectedItem;
                CategorieForm empruntForm = new CategorieForm(selectedBook);
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
            categorieList.Clear();
            using (var dbContext = new Database())
            {
                var categoies = dbContext.Categories.ToList();

                foreach (var temp in categoies)
                {
                    Categorie categorie = new();
                    categorie.CategorieId = temp.CategorieId;
                    categorie.Nom = temp.Nom;
                    categorieList.Add(categorie);
                }
            }
        }

        private void AdherentHandle(object sender, RoutedEventArgs e)
        {
            Adherents adherents = new Adherents();
            adherents.setUser(user);
            adherents.Show();
            Close();
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
