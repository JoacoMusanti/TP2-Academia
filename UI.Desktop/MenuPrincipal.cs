using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;

namespace UI.Desktop
{
    public partial class MenuPrincipal : Form
    {
        private Persona.TipoPersonas _rol;

        public Persona.TipoPersonas Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }
        public MenuPrincipal()
        {
            InitializeComponent();

            
        }

        private void MenuPrincipal_OnLoad(object sender, EventArgs e)
        {
            
         FormLogin appLogin = new FormLogin();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
               
                Close();
            }
            Rol = appLogin.Rol;
        }


        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Rol != Persona.TipoPersonas.Administrativo)
            {
                MessageBox.Show("No tiene permisos para acceder a este recurso");
            }
            else
            {
                Usuarios usr = new Usuarios();
                usr.ShowDialog();
            }
            
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Rol != Persona.TipoPersonas.Administrativo)
            {
                MessageBox.Show("No tiene permisos para acceder a este recurso");
            }
            else
            {
                Especialidades esp = new Especialidades();
                esp.ShowDialog();
            }
            
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Rol != Persona.TipoPersonas.Administrativo)
            {
                MessageBox.Show("No tiene permisos para acceder a este recurso");
            }
            else
            {
                Materias mat = new Materias();
                mat.ShowDialog();
            }
            
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Rol != Persona.TipoPersonas.Administrativo)
            {
                MessageBox.Show("No tiene permisos para acceder a este recurso");
            }
            else
            {
                Comisiones com = new Comisiones();
                com.ShowDialog();
            }
            
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Rol != Persona.TipoPersonas.Administrativo)
            {
                MessageBox.Show("No tiene permisos para acceder a este recurso");
            }
            else
            {
                Planes pl = new Planes();
                pl.ShowDialog();
            } 
            
        }
    }
}
