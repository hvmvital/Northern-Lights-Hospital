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
    /// Logique d'interaction pour RecherchePatient.xaml
    /// </summary>
    public partial class RecherchePatient : Window
    {
        public RecherchePatient()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cb_nssPatient.DataContext = MainWindow.myBDD.Patients.ToList();
        }

        private void cb_nssPatient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Patient unPatient = cb_nssPatient.SelectedItem as Patient;
            d_naissance.SelectedDate = unPatient.dateNaissance;
            nom.Text = Convert.ToString(unPatient.nom);
            prenom.Text = Convert.ToString(unPatient.prenom);
            adresse.Text = Convert.ToString(unPatient.adresse);
            ville.Text = Convert.ToString(unPatient.ville);
            province.Text = Convert.ToString(unPatient.province);
            codePoste.Text = Convert.ToString(unPatient.codePostal);
            telephone.Text = Convert.ToString(unPatient.telephone);
            idMedecin.Text = Convert.ToString(unPatient.idMedecin);
            idCompanie.Text = Convert.ToString(unPatient.idCompanie);
            refParent.Text = Convert.ToString(unPatient.refParent);
        }

        private void BQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
