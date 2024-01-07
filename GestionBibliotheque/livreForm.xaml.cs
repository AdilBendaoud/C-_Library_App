using CustomMessageBox;
using GestionBibliotheque.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using static System.Net.Mime.MediaTypeNames;

namespace GestionBibliotheque
{
    /// <summary>
    /// Interaction logic for livreForm.xaml
    /// </summary>
    public partial class livreForm : Window
    {
        private Livre mylivre;

        private void Init()
        {
            using(var dbContext = new Database())
            {
                List<Auteur> auteurs = dbContext.Auteurs.ToList();
                List<Categorie> categories = dbContext.Categories.ToList();

                auteurInput.ItemsSource = auteurs;
                categorieInput.ItemsSource = categories;
            }
        }

        public livreForm()
        {
            InitializeComponent();
            Init();
            updateBtn.Visibility = Visibility.Collapsed;
            deleteBtn.Visibility = Visibility.Collapsed;
        }

        public livreForm(object livre)
        {
            InitializeComponent();
            Init();
            mylivre = (Livre)livre;
            addBtn.Visibility = Visibility.Collapsed;
            titreInput.Text = mylivre.Titre;
            prixInput.Text = mylivre.Prix.ToString();
            categorieInput.Text = mylivre.Categorie.Nom;
            editionInput.Text = mylivre.Edition;
            auteurInput.Text = mylivre.Auteur.Prenom+" "+mylivre.Auteur.Nom;
            livreImage.Source = new BitmapImage(new Uri(mylivre.Image));
            datePublication.SelectedDate = mylivre.DateDistrubution;
            idInput.Text = mylivre.LivreId.ToString();
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

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            if (titreInput.Text == "" || auteurInput.Text == "" || editionInput.Text == "" ||
                double.Parse(prixInput.Text) <= 0 || categorieInput.Text == "" || tempImage == null || !datePublication.SelectedDate.HasValue)
            {
                bool? Result = new MessageBoxCustom("Tous les champs sont obligatoirs", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
            else
            {
                string newFileName = $"book_{Guid.NewGuid()}{System.IO.Path.GetExtension(tempImage)}";
                string newFilePath = System.IO.Path.Combine("C:\\Users\\pc\\source\\repos\\GestionBibliotheque\\GestionBibliotheque\\Images", newFileName);
                File.Copy(tempImage, newFilePath);

                using (var dbContext = new Database())
                {
                    DateTime utcDateTime = DateTime.SpecifyKind(datePublication.SelectedDate.Value, DateTimeKind.Utc);
                    var newBook = new Livre
                    {
                        Titre = titreInput.Text,
                        AuteurId = ((Auteur)auteurInput.SelectedItem).AuteurId,
                        Edition = editionInput.Text,
                        Prix = double.Parse(prixInput.Text),
                        CategorieId = ((Categorie)categorieInput.SelectedItem).CategorieId,
                        DateDistrubution = utcDateTime,
                        Image = newFilePath,
                    };

                    dbContext.Livres.Add(newBook);
                    dbContext.SaveChanges();
                    Close();
                }
            }
        }

        private void UpdateBook_Click(object sender, RoutedEventArgs e)
        {
            String currentImagePath = "";
            ImageSource imageSource = livreImage.Source;
            if (imageSource is BitmapImage bitmapImage)
            {
                Uri imageUri = bitmapImage.UriSource;
                currentImagePath = imageUri.LocalPath.ToString().Replace("/", "\\");
            }
            using (var dbContext = new Database())
            {
                var existingBook = dbContext.Livres.FirstOrDefault(b => b.LivreId.ToString() == idInput.Text);
                DateTime utcDateTime = DateTime.SpecifyKind(datePublication.SelectedDate.Value, DateTimeKind.Utc);
                if (existingBook != null)
                {
                    if (currentImagePath != existingBook.Image)
                    {
                        string newFileName = $"book_{Guid.NewGuid()}{System.IO.Path.GetExtension(tempImage)}";
                        string newFilePath = System.IO.Path.Combine("C:\\Users\\pc\\source\\repos\\GestionBibliotheque\\GestionBibliotheque\\Images", newFileName);
                        File.Copy(tempImage, newFilePath);
                        existingBook.Image = newFilePath;
                    }
                    existingBook.Titre = titreInput.Text;
                    existingBook.AuteurId = (int)auteurInput.SelectedValue;
                    existingBook.Edition = editionInput.Text;
                    existingBook.Prix = double.Parse(prixInput.Text);
                    existingBook.CategorieId = (int)categorieInput.SelectedValue;
                    existingBook.DateDistrubution = utcDateTime;
                    dbContext.SaveChanges();
                    Close();
                }
            }
        }
 
        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            bool? result = new MessageBoxCustom("Voulez-vous vraiment supprimer ce livre ?", MessageType.Confirmation, MessageButtons.OkCancel).ShowDialog();
            if (result != null && (bool)result)
            {
                using (var dbContext = new Database())
                {
                    var existingBook = dbContext.Livres.First(b => b.LivreId.ToString() == idInput.Text);
                    if (existingBook != null)
                    {
                        dbContext.Livres.Remove(existingBook);
                        dbContext.SaveChanges();
                        Close();
                    }
                }
            }
        }

        private string tempImage;
        private void BrowseImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                tempImage = imagePath;
                livreImage.Source = new BitmapImage(new Uri(imagePath));
            }
        }
    }
}
