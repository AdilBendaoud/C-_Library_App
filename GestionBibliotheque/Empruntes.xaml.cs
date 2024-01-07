using GestionBibliotheque.Model;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for Empruntes.xaml
    /// </summary>
    public partial class Empruntes : Window
    {
        User user;
        private readonly ObservableCollection<Emprunte> empruntsList = new();
        public Empruntes()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dataGrid.ItemsSource = empruntsList;
            LoadData();
        }

        private void LoadData()
        {
            empruntsList.Clear();
            using (var dbContext = new Database())
            {
                var emprunts = dbContext.Empruntes.Include(l => l.User).Include(l => l.Livre).OrderBy(l => l.EmprunteId).ToList();

                foreach (var temp in emprunts)
                {
                    Emprunte emprunte = new();
                    emprunte.EmprunteId = temp.EmprunteId;
                    emprunte.DateEmprunte = temp.DateEmprunte.AddHours(12);
                    emprunte.DateRetourPrevue = temp.DateRetourPrevue.AddHours(12);
                    emprunte.DateRetourReelle = temp.DateRetourReelle.AddHours(12);
                    emprunte.DateEmprunteString = ((DateTime)temp.DateEmprunte.AddHours(12)).Date.ToString("yyyy MMMM dd");
                    emprunte.DateRetourPrevueString = ((DateTime)temp.DateRetourPrevue.AddHours(12)).Date.ToString("yyyy MMMM dd");
                    if (temp.DateEmprunte != temp.DateRetourReelle)
                    {
                        emprunte.DateRetourReelleString = ((DateTime)temp.DateRetourReelle.AddHours(12)).Date.ToString("yyyy MMMM dd");
                    }
                    else
                    {
                        emprunte.DateRetourReelleString = "";
                    }
                    emprunte.PrixPaye = temp.PrixPaye;
                    emprunte.LivreId = temp.LivreId;
                    emprunte.UserId = temp.UserId;
                    emprunte.User = temp.User;
                    emprunte.Livre = temp.Livre;
                    empruntsList.Add(emprunte);
                }
            }
        }

        private void Search(object sender, EventArgs e)
        {
            string searchTerm = searchInput.Text;
            if (searchTerm.Equals(""))
            {
                dataGrid.ItemsSource = empruntsList;
            }
            else
            {
                ObservableCollection<Emprunte> filteredBooks = new(empruntsList.Where(b => b.User.CIN.ToLower().Contains(searchTerm.ToLower()) ||
                                    b.User.Nom.ToLower().Contains(searchTerm.ToLower()) || b.User.Prenom.ToLower().Contains(searchTerm.ToLower()) ||
                                    b.Livre.Titre.ToLower().Contains(searchTerm.ToLower())));
                dataGrid.ItemsSource = filteredBooks;
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

        private void AdherantHandle(object sender, RoutedEventArgs e)
        {
            Adherents ad = new Adherents();
            ad.setUser(user);
            ad.Show();
            Close();
        }

        private void LivreHandle(object sender, RoutedEventArgs e)
        {
            Livres livres = new();
            livres.setUser(user);
            livres.Show();
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
            Categories categorie = new Categories();
            categorie.setUser(user);
            categorie.Show();
            Close();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Emprunte selectedBook = (Emprunte)dataGrid.SelectedItem;
                EmpruntesForm empruntForm = new EmpruntesForm(selectedBook);
                empruntForm.Show();
                empruntForm.Closed += UpdateData;
            }
        }
        private void UpdateData(object sender, EventArgs e)
        {
            LoadData();
        }

        internal void setUser(User user){
            this.user = user;
            if (user != null && user.IsAdmin) { empBtn.Visibility = Visibility.Collapsed; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Employes emp = new Employes();
            emp.setUser(user);
            emp.Show();
            Close();
        }
    }
}
