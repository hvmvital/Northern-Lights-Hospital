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
using Microsoft.VisualBasic;
using System.ComponentModel;

namespace NLH
{
    /// <summary>
    /// Logique d'interaction pour FenetreAdmin.xaml
    /// </summary>
    public partial class FenetreAdmin : Window
    {

        public FenetreAdmin()
        {
            InitializeComponent();

   
        }







        private void BAjout_Click(object sender, RoutedEventArgs e)
        {
            FenetreAjoutMed ajout = new FenetreAjoutMed();
            ajout.ShowDialog();
        }

        private void BSuppr_Click(object sender, RoutedEventArgs e)
        {
            Medecin med = (Medecin)lstMedecin.SelectedItem;
            MainWindow.myBDD.Medecins.Remove(med);

            MainWindow.myBDD.SaveChanges();
            MessageBox.Show("Medecin supprime de la liste");
        }

        private void BRefresh_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            FenetreAdmin admin = new FenetreAdmin();
            admin.ShowDialog();
        }

        private void BQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BModif_Click(object sender, RoutedEventArgs e)
        {
            FenetreModifier modif = new FenetreModifier();
            modif.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
               from p in MainWindow.myBDD.Patients
               join m in MainWindow.myBDD.Medecins on p.idMedecin equals m.idMedecin

             

            select new { p.nss, Patient = p.nom, m.idMedecin, Medecin = "Dr. " + m.prenom  };
            dataGridMed.ItemsSource = query.ToList();


            lstMedecin.DataContext = MainWindow.myBDD.Medecins.ToList();
        }

        private void LstMedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((Medecin)lstMedecin.SelectedItem).aPatient == false)
            {

                btnSupprimer.IsEnabled = true;
                msgErrorSupp.Visibility = Visibility.Hidden;

            }
            else {
                btnSupprimer.IsEnabled = false;
                msgErrorSupp.Visibility = Visibility.Visible;
            }
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ListeMedecin med = new ListeMedecin();
            med.ShowDialog();

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            
                RecherchePatient pat = new RecherchePatient();
                pat.ShowDialog();
            
        }

        
    }
}

