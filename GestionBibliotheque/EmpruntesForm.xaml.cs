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
    /// Interaction logic for EmpruntesForm.xaml
    /// </summary>
    public partial class EmpruntesForm : Window
    {
        private Emprunte emprunte;

        public EmpruntesForm()
        {
            InitializeComponent();
        }
        public EmpruntesForm(object emp)
        {
            InitializeComponent();
            emprunte = (Emprunte)emp;
            titreInput.Text = emprunte.Livre.Titre;
            CINInput.Text = emprunte.User.CIN.ToString();
            NomInput.Text = emprunte.User.Prenom + " " + emprunte.User.Prenom;
            dateEmpruntInput.SelectedDate = emprunte.DateEmprunte;
            dateEmprunPrevuetInput.SelectedDate = emprunte.DateRetourPrevue;
            idInput.Text = emprunte.EmprunteId.ToString();
            if (emprunte.DateRetourReelle != emprunte.DateEmprunte)
            {
                retourCheckBox.IsChecked = true;
                prixInput.Text = emprunte.PrixPaye.ToString();
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            DateTime today = DateTime.Now;
            int joursDeRetard = (int)( today - emprunte.DateRetourPrevue).TotalDays;
            decimal coutRetard = (decimal)(joursDeRetard > 0 ? joursDeRetard * emprunte.Livre.Prix * 0.25 : 0);

            int joursTotal = (int)(today - emprunte.DateEmprunte).TotalDays;
            decimal coutLocationBase = (decimal)(joursTotal * emprunte.Livre.Prix);

            decimal coutTotal = coutLocationBase + coutRetard;
            prixInput.Text += coutTotal;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            prixInput.Text = "";
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

        private void UpdateBook_Click(object sender, EventArgs e)
        {
            using(var dbContext = new Database()){
                var existingEmprunt = dbContext.Empruntes.FirstOrDefault(e => e.EmprunteId.ToString() == idInput.Text);
                DateTime empruntDate = DateTime.SpecifyKind(dateEmpruntInput.SelectedDate.Value, DateTimeKind.Utc);
                DateTime empruntDatePrevue = DateTime.SpecifyKind(dateEmprunPrevuetInput.SelectedDate.Value, DateTimeKind.Utc);
                DateTime today = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                if (existingEmprunt != null)
                {
                    existingEmprunt.DateEmprunte = empruntDate;
                    existingEmprunt.DateRetourPrevue = empruntDatePrevue;
                    if ((bool)retourCheckBox.IsChecked)
                    {
                        existingEmprunt.DateRetourReelle = today;
                        existingEmprunt.PrixPaye = Decimal.Parse(prixInput.Text);
                    }
                    else
                    {
                        existingEmprunt.PrixPaye = 0;
                        existingEmprunt.DateRetourReelle = empruntDate;
                    }
                }
                dbContext.SaveChanges();
                Close();
            }
        }
    }
}
