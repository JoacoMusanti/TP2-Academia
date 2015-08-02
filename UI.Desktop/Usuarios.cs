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
using Business.Logic;

namespace UI.Desktop
{
    public partial class Usuarios : ApplicationForm
    {
        public Usuarios()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            
        }

        public void Listar()
        {
            PersonaLogic ul = new PersonaLogic();

            try
            {
                dgvUsuarios.DataSource = ul.GetAll();
            }
            catch (Exception e)
            {
                Notificar("Error inesperado", e.Message + "\nIntente la operacion nuevamente", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Abre un form donde se solicita el ingreso de los datos de un nuevo usuario y permite agregarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUsuario.Text = "Agregar Usuario";
            formUsuario.ShowDialog();
            Listar();
        }

        /// <summary>
        /// Abre un form en donde se muestran los datos del usuario seleccionado y permite modificarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Persona)dgvUsuarios.SelectedRows[0].DataBoundItem).ID;

                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formUsuario.Text = "Modificar Usuario";
                formUsuario.ShowDialog();
            }

            Listar();
        }

        /// <summary>
        /// Abre un form en donde se muestran los datos del usuario seleccionado y permite eliminarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Persona)dgvUsuarios.SelectedRows[0].DataBoundItem).ID;

                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                formUsuario.Text = "Eliminar Usuario";
                formUsuario.ShowDialog();
            }

            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
