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
    /// Interaction logic for CategorieForm.xaml
    /// </summary>
    public partial class CategorieForm : Window
    {
        public CategorieForm()
        {
            InitializeComponent();
            updateBtn.Visibility = Visibility.Collapsed;
            deleteBtn.Visibility = Visibility.Collapsed;
        }
        public CategorieForm(object aut)
        {
            InitializeComponent();
            Categorie cat = (Categorie)aut;
            nomInput.Text = cat.Nom;
            idInput.Text = cat.CategorieId.ToString();
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
                var existingCategorie = dbContext.Categories.FirstOrDefault(e => e.CategorieId.ToString() == idInput.Text);
                if (existingCategorie != null)
                {
                    existingCategorie.Nom = nomInput.Text;
                }
                dbContext.SaveChanges();
                Close();
            }
        }

        private void deleteClick(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Voulez-vous vraiment supprimer ce categorie ?", MessageType.Confirmation, MessageButtons.OkCancel).ShowDialog();
            if (result != null && (bool)result)
            {
                using (var dbContext = new Database())
                {
                    var existingCategorie = dbContext.Categories.First(b => b.CategorieId.ToString() == idInput.Text);
                    if (existingCategorie != null)
                    {
                        dbContext.Categories.Remove(existingCategorie);
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
                Categorie categorie = new Categorie();
                categorie.Nom = nomInput.Text;
                dbContext.Categories.Add(categorie);
                dbContext.SaveChanges();
                Close();
            }
        }
    }
}
