using GestionBibliotheque.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using static System.Reflection.Metadata.BlobBuilder;

namespace GestionBibliotheque
{
    /// <summary>
    /// Interaction logic for Livres.xaml
    /// </summary>
    public partial class Livres : Window
    {
        private ObservableCollection<Livre> booksList = new ObservableCollection<Livre>();
        User user;

        public Livres()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dataGrid.ItemsSource = booksList;
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

        private void EmpruntHandle(object sender, RoutedEventArgs e)
        {
            Empruntes empruntes = new Empruntes();
            empruntes.setUser(user);
            empruntes.Show();
            Close();
        }

        private void AdherantHandle(object sender, RoutedEventArgs e)
        {
            Adherents ad = new Adherents();
            ad.setUser(user);
            ad.Show();
            Close();
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

        private void CategorieHandle(object sender, RoutedEventArgs e)
        {
            Categories categories = new Categories();
            categories.setUser(user);
            categories.Show();
            Close();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            livreForm livreForm = new livreForm();
            livreForm.Show();
            if(livreForm == null || !livreForm.IsLoaded)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            booksList.Clear();
            using (var dbContext = new Database())
            {
                var books = dbContext.Livres.Include(l => l.Auteur).Include(l => l.Categorie).OrderBy(l=> l.LivreId).ToList();

                foreach (var book in books)
                {
                    Livre livre = new Livre();
                    livre.Titre = book.Titre;
                    livre.Auteur = book.Auteur;
                    livre.Prix = book.Prix;
                    livre.LivreId = book.LivreId;
                    livre.Categorie = book.Categorie;
                    livre.Edition = book.Edition;
                    livre.DateDistrubution = ((DateTime)book.DateDistrubution).Date;
                    livre.Image = book.Image;
                    booksList.Add(livre);
                }
            }
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Livre selectedBook = (Livre)dataGrid.SelectedItem;
                livreForm livreForm = new livreForm(selectedBook);
                livreForm.Show();
                livreForm.Closed += UpdateData;
            }
        }

        private void Search(object sender, EventArgs e)
        {
            string searchTerm = searchInput.Text;
            if (searchTerm.Equals(""))
            {
                dataGrid.ItemsSource = booksList;
            }
            else
            {
                ObservableCollection<Livre> filteredBooks = new(
                booksList.Where(b => b.Titre.ToLower().Contains(searchTerm.ToLower()) ||
                                    b.Auteur.Nom.ToLower().Contains(searchTerm.ToLower()) || b.Auteur.Prenom.ToLower().Contains(searchTerm.ToLower()) ||
                                    b.Categorie.Nom.ToLower().Contains(searchTerm.ToLower())));
                dataGrid.ItemsSource = filteredBooks;
            }
        }

        private void UpdateData(object sender, EventArgs e)
        {
            LoadData();
        }

        private void empHandle(object sender, RoutedEventArgs e)
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
