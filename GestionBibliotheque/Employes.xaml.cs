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
    /// Interaction logic for employes.xaml
    /// </summary>
    public partial class Employes : Window
    {
        private readonly ObservableCollection<User> EmployesList = new();
        User user;
        public Employes()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dataGrid.ItemsSource = EmployesList;
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
                dataGrid.ItemsSource = EmployesList;
            }
            else
            {
                ObservableCollection<User> filteredAdherents = new(EmployesList.Where(b => b.Nom.ToLower().Contains(searchTerm.ToLower()) ||
                                                                                        b.Prenom.ToLower().Contains(searchTerm.ToLower()) ||
                                                                                        b.Email.ToLower().Contains(searchTerm.ToLower())));
                dataGrid.ItemsSource = filteredAdherents;
            }
        }

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                User selected = (User)dataGrid.SelectedItem;
                EmployeForm employeForm = new EmployeForm(selected);
                employeForm.Show();
                employeForm.Closed += UpdateData;
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
            EmployesList.Clear();
            using (var dbContext = new Database())
            {
                var Adherents = dbContext.Users.Where(u => u.IsAdmin == true || u.IsSuperAdmin == true).ToList();

                foreach (var temp in Adherents)
                {
                    User adherent = new();
                    adherent.CIN = temp.CIN;
                    adherent.Prenom = temp.Prenom;
                    adherent.Nom = temp.Nom;
                    adherent.Adresse = temp.Adresse;
                    adherent.Email = temp.Email;
                    adherent.Tel = temp.Tel;
                    adherent.IsAdmin = temp.IsAdmin;
                    adherent.IsSuperAdmin = temp.IsSuperAdmin;
                    EmployesList.Add(adherent);
                }
            }
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            Close();
        }

        private void AddBtn(object sender, RoutedEventArgs e)
        {
            EmployeForm employeForm = new EmployeForm();
            employeForm.Show();
            employeForm.Closed += UpdateData;
        }

        private void goToAdherents(object sender, RoutedEventArgs e)
        {
            Adherents ad = new Adherents();
            ad.setUser(user);
            ad.Show();
            Close();
        }

        private void goToCategories(object sender, RoutedEventArgs e)
        {
            Categories cat = new Categories();
            cat.setUser(user);
            cat.Show();
            Close();
        }

        internal void setUser(User user)
        {
            this.user = user;
            if (user != null && user.IsAdmin) { empBtn.Visibility = Visibility.Collapsed; }
        }
    }
}
