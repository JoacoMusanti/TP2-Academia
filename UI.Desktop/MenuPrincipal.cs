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
            // mostramos el form de login, si los datos de login son correctos continua la ejecucion
            // si no, se vuelve a mostrar el form de login
            FormLogin appLogin = new FormLogin();
            /*if (appLogin.ShowDialog() != DialogResult.OK)
            {
                Close();
            }*/
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

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            Comisiones com = new Comisiones();
            com.ShowDialog();
        }

        private void btnAdministrarPlanes_Click(object sender, EventArgs e)
        {
            Planes pl = new Planes();
            pl.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias mat = new Materias();
            mat.ShowDialog();
        }
    }
}
