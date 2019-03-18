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
    /// Logique d'interaction pour FenetreAjoutMed.xaml
    /// </summary>
    public partial class FenetreAjoutMed : Window
    {
        public FenetreAjoutMed()
        {
            InitializeComponent();
        }

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            Medecin newMed = new Medecin();
            newMed.idMedecin = idMedecin.Text;
            newMed.nom = nom.Text;
            newMed.prenom = prenom.Text;
            newMed.specialite = specialite.Text;
            newMed.aPatient = false;



            MainWindow.myBDD.Medecins.Add(newMed);
            MainWindow.myBDD.SaveChanges();
            MessageBox.Show("Medecin ajoute avec succes");
        }
    }
}
