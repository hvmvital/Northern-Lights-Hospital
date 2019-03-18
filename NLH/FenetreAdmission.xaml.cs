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
    /// Logique d'interaction pour FenetreAdmission.xaml
    /// </summary>
    public partial class fenetreAdmission : Window
    {
        public fenetreAdmission()
        {
            InitializeComponent();
        }
        private void BQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cb_numLit.DataContext = MainWindow.myBDD.Lits.Where(l => l.occupe == false).ToList();
            cb_nss.DataContext = MainWindow.myBDD.Patients.ToList();
            cboMedecin.DataContext = MainWindow.myBDD.Medecins.ToList();
        }
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            dossierAdmission newAdmis = new dossierAdmission();
            newAdmis.idAdmission = ("AD_" + /*((Patient)cb_nss.SelectedItem).nss.Trim() +*/ DateTime.Now.ToString("yyyyMMddhhmm")).Trim();
            newAdmis.nss = ((Patient)cb_nss.SelectedItem).nss;

            if (rbOui.IsChecked == true)
            {
                newAdmis.chirurgie = true;
            }
            else
            {
                newAdmis.chirurgie = false;
            }
            newAdmis.dateAdmission = dateAdmiss.SelectedDate;
            newAdmis.dateChirurgie = dateChirur.SelectedDate;
            newAdmis.numLit = ((Lit)cb_numLit.SelectedItem).numLit;
            ((Lit)cb_numLit.SelectedItem).occupe = true;
            ((Patient)cb_nss.SelectedItem).idMedecin = ((Medecin)cboMedecin.SelectedItem).idMedecin;
            //newAdmis.dateConge = dateConge.SelectedDate;
            MainWindow.myBDD.dossierAdmissions.Add(newAdmis);
            MainWindow.myBDD.SaveChanges();
            MessageBox.Show("Admission est faite");
        }
        private void rbOui_Click(object sender, RoutedEventArgs e)
        {
            cb_numLit.DataContext = MainWindow.myBDD.Lits.Where(l => l.occupe == false && l.idDepartement == "D01").ToList();
            cboMedecin.DataContext = MainWindow.myBDD.Medecins.Where(m => m.specialite == "chirurgien").ToList();

        }
        private void rbNon_Click(object sender, RoutedEventArgs e)
        {
            int age = ((DateTime.Today.Year) - (((Patient)cb_nss.SelectedItem).dateNaissance.Value.Year));
            if (age > 16)
            {
                cb_numLit.DataContext = MainWindow.myBDD.Lits.Where(l => l.occupe == false && l.idDepartement == "D03").ToList();
                cboMedecin.DataContext = MainWindow.myBDD.Medecins.Where(m => m.specialite != "chirurgien" && m.specialite != "pediatre").ToList();
            }
            else
            {
                cb_numLit.DataContext = MainWindow.myBDD.Lits.Where(l => l.occupe == false && l.idDepartement == "D02").ToList();
                cboMedecin.DataContext = MainWindow.myBDD.Medecins.Where(m => m.specialite == "pediatre").ToList();
            }



        }
    }
}