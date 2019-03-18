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
    /// Logique d'interaction pour FenetreAjoutPatient.xaml
    /// </summary>
    public partial class FenetreAjoutPatient : Window
    {
        public FenetreAjoutPatient()
        {
            InitializeComponent();
        }
        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(nss.Text) && !String.IsNullOrEmpty(telephoneParent.Text))
            {
                Patient newPatient = new Patient();
                newPatient.nss = nss.Text;
                newPatient.dateNaissance = dateNaiss.DisplayDate;
                newPatient.nom = nom.Text;
                newPatient.prenom = prenom.Text;
                newPatient.adresse = adresse.Text;
                newPatient.ville = ville.Text;
                newPatient.province = province.Text;
                newPatient.codePostal = codePoste.Text;
                newPatient.telephone = telephone.Text;
                //newPatient.idMedecin = cboMedecin.Text;
                newPatient.idMedecin = ((Medecin)cboMedecin.SelectedItem).idMedecin;

                Parent par = new Parent();
                par.refParent = (telephoneParent.Text);
                par.nom = nomParent.Text;
                par.prenom = prenomParent.Text;
                par.adresse = addParent.Text;
                par.ville = villeParent.Text;
                par.province = provinceParent.Text;
                par.codepostal = codePosteParent.Text;

                par.telephone = telephoneParent.Text;

                MainWindow.myBDD.Parents.Add(par);
                if (!String.IsNullOrEmpty(nomCompanie.Text))
                {
                    Assurance newAssurance = new Assurance();
                    newAssurance.idCompanie = ("A" + nomCompanie.Text);
                    newAssurance.nom = nomCompanie.Text;
                    newPatient.idCompanie = newAssurance.idCompanie;
                    MainWindow.myBDD.Assurances.Add(newAssurance);
                }
                else
                {
                    newPatient.idCompanie = ((Assurance)cb_idCompAssurence.SelectedItem).idCompanie;
                }
                newPatient.refParent = par.refParent;
                ((Medecin)cboMedecin.SelectedItem).aPatient = true;
                MainWindow.myBDD.Patients.Add(newPatient);
                MainWindow.myBDD.SaveChanges();
                MessageBox.Show("Patient ajoute dans la liste");
            }
            else
            {
                MessageBox.Show("Attention Ajouter le nss et/ou le telephone parent!");
            }

        }
        private void BQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnAdmission_Click(object sender, RoutedEventArgs e)
        {

          
            fenetreAdmission admis = new fenetreAdmission();
            admis.ShowDialog();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboMedecin.DataContext = MainWindow.myBDD.Medecins.ToList();
            cb_idCompAssurence.DataContext = MainWindow.myBDD.Assurances.ToList();
        }

        private void CopyPat_Click(object sender, RoutedEventArgs e)
        {
            nomParent.Text = nom.Text;
            addParent.Text = adresse.Text;
            villeParent.Text = ville.Text;
            provinceParent.Text = province.Text;
            codePosteParent.Text = codePoste.Text;
        }
    }
}