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
    /// Logique d'interaction pour FenetreModifier.xaml
    /// </summary>
    public partial class FenetreModifier : Window
    {
        public FenetreModifier()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cb_idMedecin.DataContext = MainWindow.myBDD.Medecins.ToList();
        }

        private void cb_idMedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medecin unMedecin = cb_idMedecin.SelectedItem as Medecin;
            nom.Text = Convert.ToString(unMedecin.nom);
            prenom.Text = Convert.ToString(unMedecin.prenom);
            specialite.Text = Convert.ToString(unMedecin.specialite);
        }

        private void BModif_Click(object sender, RoutedEventArgs e)
        {
            Medecin unMedecin = (Medecin)cb_idMedecin.SelectedItem;
            unMedecin.nom = nom.Text;
            unMedecin.prenom = prenom.Text;
            unMedecin.specialite = specialite.Text;

            MainWindow.myBDD.SaveChanges();
            MessageBox.Show("Modifie avec succes");
        }

        private void BQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BRefresh_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            FenetreModifier mod = new FenetreModifier();
            mod.ShowDialog();
        }
    }
}