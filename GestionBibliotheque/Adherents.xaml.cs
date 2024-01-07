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
using GemBox.Spreadsheet;
using CustomMessageBox;
using System.Windows.Forms;
using System.Data;

namespace GestionBibliotheque
{
    /// <summary>
    /// Interaction logic for Adherents.xaml
    /// </summary>
    public partial class Adherents : Window
    {
        private readonly ObservableCollection<User> AdherentsList = new();
        User user;
        public Adherents()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dataGrid.ItemsSource = AdherentsList;
            LoadData();
        }

        private void ExporteBtn(object sender, RoutedEventArgs e)
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            using (var dbContext = new Database())
            {
                var data = dbContext.Users.Where(u => u.IsAdmin == false && u.IsSuperAdmin == false).Select(u => new { u.CIN, u.Nom, u.Prenom, u.Email, u.Adresse, u.Tel }).ToList();

                var workbook = new ExcelFile();
                var worksheet = workbook.Worksheets.Add("Sheet1");

                var headers = new string[] { "CIN", "Nom", "Prenom", "Email", "Adresse", "Tel" };
                for (var colIndex = 0; colIndex < headers.Length; colIndex++)
                {
                    worksheet.Cells[0, colIndex].Value = headers[colIndex];
                }

                for (var rowIndex = 0; rowIndex < data.Count; rowIndex++)
                {
                    var userData = data[rowIndex];
                    worksheet.Cells[rowIndex + 1, 0].Value = userData.CIN;
                    worksheet.Cells[rowIndex + 1, 1].Value = userData.Nom;
                    worksheet.Cells[rowIndex + 1, 2].Value = userData.Prenom;
                    worksheet.Cells[rowIndex + 1, 3].Value = userData.Email;
                    worksheet.Cells[rowIndex + 1, 4].Value = userData.Adresse;
                    worksheet.Cells[rowIndex + 1, 5].Value = userData.Tel;
                }
                for(int column = 0; column < 6; column++)
                {
                    worksheet.Columns[column].AutoFit();
                }

                var tableRange = worksheet.Cells.GetSubrangeAbsolute(0, 0, data.Count, 5);
                tableRange.SetBorders(MultipleBorders.All, SpreadsheetColor.FromName(ColorName.Black), LineStyle.Medium);

                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.FileName = "ExportationAdherent.xlsx";

                    if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        workbook.Save(saveFileDialog.FileName);
                        bool? Result = new MessageBoxCustom("Exportation Successfully Done.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    }
                }
            }
        }

        private void ImportBtn(object sender, RoutedEventArgs e)
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Select Excel File";

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var workbook = ExcelFile.Load(openFileDialog.FileName);
                    var worksheet = workbook.Worksheets.FirstOrDefault();

                    if (worksheet != null)
                    {
                        var dataTable = worksheet.CreateDataTable(new CreateDataTableOptions()
                        {
                            ColumnHeaders = true,
                            StartRow = 0,
                            NumberOfColumns = 6,
                            NumberOfRows = worksheet.Rows.Count,
                            Resolution = ColumnTypeResolution.AutoPreferStringCurrentCulture
                        });

                        using (var dbContext = new Database())
                        {

                            foreach (DataRow row in dataTable.Rows)
                            {
                                var user = new User
                                {
                                    CIN = (string)row[0],
                                    Nom = (string)row[1],
                                    Prenom = (string)row[2],
                                    Email = (string)row[3],
                                    Password = (string)row[2] + "." + (string)row[1],
                                    Adresse = (string)row[4],
                                    Tel = (int)row[5],
                                    IsAdmin = false
                                };
                                dbContext.Users.Add(user);
                            }
                            dbContext.SaveChanges();
                            bool? Result = new MessageBoxCustom("Importation Successfully Done.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                            LoadData();
                        }
                    }
                    else
                    {
                        bool? Result = new MessageBoxCustom("No worksheet found in the Excel file.", MessageType.Error, MessageButtons.Ok).ShowDialog();
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
                dataGrid.ItemsSource = AdherentsList;
            }
            else
            {
                ObservableCollection<User> filteredAdherents = new(AdherentsList.Where(b => b.Nom.ToLower().Contains(searchTerm.ToLower()) ||
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
                AdherentsForm empruntForm = new AdherentsForm(selected);
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
            AdherentsList.Clear();
            using (var dbContext = new Database())
            {
                var Adherents = dbContext.Users.Where(u=>u.IsAdmin == false).ToList();

                foreach (var temp in Adherents)
                {
                    User adherent = new();
                    adherent.CIN = temp.CIN;
                    adherent.Prenom = temp.Prenom;
                    adherent.Nom = temp.Nom;
                    adherent.Adresse = temp.Adresse;
                    adherent.Email = temp.Email;
                    adherent.Tel = temp.Tel;
                    AdherentsList.Add(adherent);
                }
            }
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            Close();
        }

        private void goToEmployees(object sender, RoutedEventArgs e)
        {
            Employes employes = new Employes();
            employes.setUser(user);
            employes.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
