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
    public partial class Planes : ApplicationForm
    {
        public Planes()
        {
            InitializeComponent();
            dgvPlanes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlanes.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();

            try
            {
                dgvPlanes.DataSource = pl.GetAll().FindAll(x => x.Baja == false);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                Notificar(e);
            }
        }

        private void Planes_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop formPlanesDesktop = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlanesDesktop.Text = "Agregar Plan";
            formPlanesDesktop.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvPlanes.SelectedRows.Count == 1)
            {
                int id = ((Business.Entities.Plan)dgvPlanes.SelectedRows[0].DataBoundItem).ID;

                PlanDesktop formPlanDesktop = new PlanDesktop(id, ApplicationForm.ModoForm.Modificacion);
                formPlanDesktop.Text = "Editar Plan";
                formPlanDesktop.ShowDialog();
                Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPlanes.SelectedRows.Count == 1)
            {
                int id = ((Business.Entities.Plan)dgvPlanes.SelectedRows[0].DataBoundItem).ID;

                PlanDesktop formplanDesktop = new PlanDesktop(id, ApplicationForm.ModoForm.Baja);
                formplanDesktop.Text = "Eliminar Plan";
                formplanDesktop.ShowDialog();
                Listar();
            }
        }
    }
}
