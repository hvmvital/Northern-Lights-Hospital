using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class FenetreAdmin : Form
    {
        public static NLHEntities myBDD;
        
        public FenetreAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AjoutMed ajout = new AjoutMed();
            ajout.ShowDialog();
        }

        private void bAffiche_Click(object sender, EventArgs e)
        {

        }
    }
}
