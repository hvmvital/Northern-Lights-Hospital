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
    /// Logique d'interaction pour ListeMedecin.xaml
    /// </summary>
    public partial class ListeMedecin : Window
    {
        public ListeMedecin()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cb_IdMed.DataContext = MainWindow.myBDD.Medecins.ToList();
        }
        private void cb_IdMed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medecin unMedecin = cb_IdMed.SelectedItem as Medecin;
            nom.Text = Convert.ToString(unMedecin.nom);
            prenom.Text = Convert.ToString(unMedecin.prenom);
            specialite.Text = Convert.ToString(unMedecin.specialite);

        }
        private void BQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
