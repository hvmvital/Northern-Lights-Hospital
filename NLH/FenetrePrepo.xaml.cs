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
    /// Logique d'interaction pour FenetrePrepo.xaml
    /// </summary>
    public partial class FenetrePrepo : Window
    {

        public FenetrePrepo()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
                from d in MainWindow.myBDD.dossierAdmissions
                join p in MainWindow.myBDD.Patients on d.nss equals p.nss
                where d.dateConge == null
                select new { d.idAdmission, p.nss, p.nom, p.prenom, d.numLit, p.idMedecin };
            dataGridAdmissions.ItemsSource = query.ToList();
        }
        private void BRefresh_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            FenetrePrepo admin = new FenetrePrepo();
            admin.ShowDialog();
        }
        private void BQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BAjout_Click(object sender, RoutedEventArgs e)
        {
            FenetreAjoutPatient ajout = new FenetreAjoutPatient();
            ajout.ShowDialog();
        }
        private void BRecherche_Click(object sender, RoutedEventArgs e)
        {
            RecherchePatient affiche = new RecherchePatient();
            affiche.ShowDialog();
        }
    }
}