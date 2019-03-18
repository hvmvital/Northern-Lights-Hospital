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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NLH
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static NLHEntities2 myBDD;
        //public Password Psw { get; set; }

        //public static bool canvasPreposeVisibility = false;
        

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
 
        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myBDD = new NLHEntities2();

            

        }


        private void BQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnRecherchePat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RecherchePatient affiche = new RecherchePatient();
            affiche.ShowDialog();
        }

        private void BtnRecherchePat_MouseEnter(object sender, MouseEventArgs e)
        {
            btnRecherche.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 0, 255));
        }

        private void BtnRecherchePat_MouseLeave(object sender, MouseEventArgs e)
        {
            btnRecherche.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 197, 255));
        }

        private void BtnAddPat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FenetreAjoutPatient ajout = new FenetreAjoutPatient();
            ajout.ShowDialog();
        }

        private void BtnAddPat_MouseEnter(object sender, MouseEventArgs e)
        {
            btnAdd.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 0, 255));
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            string userLogin = txtUser.Text;                        // login entre par l'utilisateur
            string userPassword = txtMotPasse.Password.ToString();  // password entre par l'utilisateur


            if (userPassword == "admin" && userLogin == "admin")
            {
     
                var queryAdmin =
                from p in MainWindow.myBDD.Patients
                join m in MainWindow.myBDD.Medecins on p.idMedecin equals m.idMedecin
                select new { p.nss, Patient = p.nom, p.prenom, m.idMedecin, Medecin = "Dr. " + m.prenom };
                lstMedecin.DataContext = MainWindow.myBDD.Medecins.ToList();

                dataGridMed.ItemsSource = queryAdmin.ToList();


                canvasPrepose.Visibility = Visibility.Hidden;
                canvasMedecin.Visibility = Visibility.Hidden;
                canvasAdmin.Visibility = Visibility.Visible;
            }
            else if (userPassword == "medecin" && userLogin == "medecin")
            {
                cb_idAdmission.DataContext = MainWindow.myBDD.dossierAdmissions.Where(d => d.dateConge == null).ToList();
                cb_Lit_Patient.DataContext = MainWindow.myBDD.Lits.Where(l => l.occupe == true).ToList();


                canvasPrepose.Visibility = Visibility.Hidden;
                canvasAdmin.Visibility = Visibility.Hidden;
                canvasMedecin.Visibility = Visibility.Visible;
            }
            else if (userPassword == "prepose" && userLogin == "prepose")
            {

                var queryPrepose =
                from d in MainWindow.myBDD.dossierAdmissions
                join p in MainWindow.myBDD.Patients on d.nss equals p.nss
                where d.dateConge == null
                select new { d.idAdmission, p.nss, p.nom, p.prenom, d.numLit, p.idMedecin };
                dataGridAdmissions.ItemsSource = queryPrepose.ToList();

                canvasMedecin.Visibility = Visibility.Hidden;
                canvasAdmin.Visibility = Visibility.Hidden;
                canvasPrepose.Visibility = Visibility.Visible;
            }
            else
            {
                canvasPrepose.Visibility = Visibility.Hidden;
                MessageBox.Show("Mot de pass ou/et username est incorrect");

            }
        }
        private void BtnAddPat_MouseLeave(object sender, MouseEventArgs e)
        {
            btnAdd.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 197, 255));
        }

        private void BtnAdmissionPat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            fenetreAdmission admis = new fenetreAdmission();
            admis.ShowDialog();
        }

        private void BtnAdmissionPat_MouseEnter(object sender, MouseEventArgs e)
        {
            btnAdmission.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 0, 255));
        }

        private void BtnAdmissionPat_MouseLeave(object sender, MouseEventArgs e)
        {
            btnAdmission.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 197, 255));
        }

        private void BtnListeAdmissionsPat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dataGridAdmissions.ItemsSource = null;

            var query =
                from d in MainWindow.myBDD.dossierAdmissions
                join p in MainWindow.myBDD.Patients on d.nss equals p.nss
                where d.dateConge == null
                select new { d.idAdmission, p.nss, p.nom, p.prenom, d.numLit, p.idMedecin };
            dataGridAdmissions.ItemsSource = query.ToList();
        }

        private void BtnListeAdmissionsPat_MouseEnter(object sender, MouseEventArgs e)
        {

            btnListeAdmissions.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 0, 255));
        }

        private void BtnListeAdmissionsPat_MouseLeave(object sender, MouseEventArgs e)
        {
            btnListeAdmissions.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 197, 255));
        }

        

        private void BtnAddMedAdmin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FenetreAjoutMed newMed = new FenetreAjoutMed();
            newMed.ShowDialog();
        }

        private void BtnAddMedAdmin_MouseEnter(object sender, MouseEventArgs e)
        {
            btnAddMed.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 0, 255));
        }

        private void BtnAddMedAdmin_MouseLeave(object sender, MouseEventArgs e)
        {
            btnAddMed.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 197, 255));
        }

        private void BtnEditMedAdmin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FenetreModifier newMed = new FenetreModifier();
            newMed.ShowDialog();
        }

        private void BtnEditMedAdmin_MouseEnter(object sender, MouseEventArgs e)
        {
            btnEditMed.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 0, 255));
        }

        private void BtnEditMedAdmin_MouseLeave(object sender, MouseEventArgs e)
        {
            btnEditMed.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 197, 255));
        }

        private void BtnRemoveMedAdmin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Medecin med = (Medecin)lstMedecin.SelectedItem;
            MainWindow.myBDD.Medecins.Remove(med);



            MainWindow.myBDD.SaveChanges();

            var query =
               from p in MainWindow.myBDD.Patients
               join m in MainWindow.myBDD.Medecins on p.idMedecin equals m.idMedecin
               select new { p.nss, Patient = p.nom, p.prenom, m.idMedecin, Medecin = "Dr. " + m.prenom };
            lstMedecin.DataContext = MainWindow.myBDD.Medecins.ToList();

        

            MessageBox.Show("Medecin supprime de la liste");

            


        }

        private void BtnRemoveMedAdmin_MouseEnter(object sender, MouseEventArgs e)
        {
            btnRemoveMed.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 0, 255));
        }

        private void BtnRemoveMedAdmin_MouseLeave(object sender, MouseEventArgs e)
        {
            btnRemoveMed.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 197, 255));
        }

        private void LstMedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((Medecin)lstMedecin.SelectedItem).aPatient == false)
            {
                btnRemoveMed.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 197, 255));
                btnRemoveMedAdmin.IsEnabled = true;
                msgErrorSupp.Visibility = Visibility.Hidden;

            }
            else
            {
                btnRemoveMed.Fill = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                btnRemoveMedAdmin.IsEnabled = false;
                msgErrorSupp.Visibility = Visibility.Visible;
            }

        }

        private void cb_nss_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dossierAdmission conge = cb_idAdmission.SelectedItem as dossierAdmission;
            nss.Text = Convert.ToString(conge.nss);
            dateAdmiss.SelectedDate = conge.dateAdmission;
            numLit.Text = Convert.ToString(conge.numLit);

        }
        
       
    }
    
}
