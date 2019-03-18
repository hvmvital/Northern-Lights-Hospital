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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "admin" && textBox4.Text == "admin")
            {
                FenetreAdmin admin = new FenetreAdmin();
                admin.Show();
            }
            else if (textBox3.Text == "medecin" && textBox4.Text == "medecin")
            {
                FenetreMed med = new FenetreMed();
                med.Show();
            }
            else if (textBox3.Text == "prepose" && textBox4.Text == "prepose")
            {
                FenetrePrepo prepo = new FenetrePrepo();
                prepo.Show();
            }
            else
            {
                MessageBox.Show("mot de passe ou nom incorrect!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
