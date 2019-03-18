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
namespace NLH
{
    /// <summary>
    /// Logique d'interaction pour FenetreMed.xaml
    /// </summary>
    public partial class FenetreMed : Window
    {

        public FenetreMed()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            cb_idAdmission.DataContext = MainWindow.myBDD.dossierAdmissions.Where(d => d.dateConge == null).ToList();
            cb_Lit_Patient.DataContext = MainWindow.myBDD.Lits.Where(l => l.occupe == true).ToList();
        }
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var query =
        //        from d in MainWindow.myBDD.dossierAdmissions
        //        join p in MainWindow.myBDD.Patients on d.nss equals p.nss
        //        select new { p.nss, p.nom, p.prenom, d.idAdmission };
        //         dataGridPatients.ItemsSource = query.ToList();
        //}
        //private void BSuppr_Click(object sender, RoutedEventArgs e)
        //{
        //    Patient pat = (Patient)dataGridPatients.SelectedItem;
        //    //MainWindow.myBDD.Patients.Remove(pat);
        //    MainWindow.myBDD.SaveChanges();
        //    MessageBox.Show("Le patient a recu son conge");
        //}
        private void BQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
        private void cb_nss_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dossierAdmission conge = cb_idAdmission.SelectedItem as dossierAdmission;
            nss.Text = Convert.ToString(conge.nss);
            dateAdmiss.SelectedDate = conge.dateAdmission;
            numLit.Text = Convert.ToString(conge.numLit);

        }
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (cb_Lit_Patient.SelectedItem != null)
            {
                if (!String.IsNullOrEmpty(dateConge.Text) && (((Lit)cb_Lit_Patient.SelectedItem).numLit) == numLit.Text)
                {
                    dossierAdmission enConge = (dossierAdmission)cb_idAdmission.SelectedItem;
                    enConge.dateConge = dateConge.SelectedDate;
                    ((Lit)cb_Lit_Patient.SelectedItem).occupe = false;
                    MainWindow.myBDD.SaveChanges();
                    MessageBox.Show("Le patient a recu sa date de sortie");
                }
                else
                {
                    MessageBox.Show("Entrer une date et/ou un numero de lit valide");
                }
            }
            else
            {
                MessageBox.Show("Pas de lit libre");
            }





        }
    }
}