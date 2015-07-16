using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();       
        }

        private void MenuPrincipal_OnLoad(object sender, EventArgs e)
        {
            FormLogin appLogin = new FormLogin();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Close();
            }
        }
      
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios usr = new Usuarios();
            usr.ShowDialog();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades esp = new Especialidades();
            esp.ShowDialog();
        }

       
    }
}
