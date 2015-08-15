using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Especialidades : ApplicationForm
    {
        public Especialidades()
        {
            InitializeComponent();
            dgvEspecialidades.AutoGenerateColumns = false;
            dgvEspecialidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();

            try
            {
                dgvEspecialidades.DataSource = el.GetAll().FindAll(x => x.Baja == false);
            }
            catch (Exception e)
            {
                Notificar("Error inesperado", e.Message + "\nIntente la operacion nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop formEspecialidadDesktop = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidadDesktop.Text = "Agregar Especialidad";
            formEspecialidadDesktop.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count == 1)
            {
                int id = ((Business.Entities.Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;

                EspecialidadDesktop formEspecialidadDesktop = new EspecialidadDesktop(id, ApplicationForm.ModoForm.Modificacion);
                formEspecialidadDesktop.Text = "Editar especialidad";
                formEspecialidadDesktop.ShowDialog();
                Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count == 1)
            {
                int id = ((Business.Entities.Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;

                EspecialidadDesktop formEspecialidadDesktop = new EspecialidadDesktop(id, ApplicationForm.ModoForm.Baja);
                formEspecialidadDesktop.Text = "Eliminar especialidad";
                formEspecialidadDesktop.ShowDialog();
                Listar(); 
            }
        }
    }
}
