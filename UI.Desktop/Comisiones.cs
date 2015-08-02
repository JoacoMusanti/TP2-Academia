using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Comisiones : ApplicationForm
    {
        public Comisiones()
        {
            InitializeComponent();
            dgvComisiones.AutoGenerateColumns = false;
            dgvComisiones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            try
            {
                dgvComisiones.DataSource = cl.GetAll();
            }
            catch(Exception e)
            {
                Notificar("Error inesperado", e.Message + "\nIntente la operacion nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void Comisiones_Load(object sender, EventArgs e)
        {
            Listar();
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop formComisionesDesktop = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formComisionesDesktop.Text = "Agregar Comision";
            formComisionesDesktop.ShowDialog();
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.SelectedRows.Count == 1)
            {
                int id = ((Business.Entities.Comision)dgvComisiones.SelectedRows[0].DataBoundItem).ID;

                ComisionDesktop formComisionDesktop = new ComisionDesktop(id, ApplicationForm.ModoForm.Modificacion);
                formComisionDesktop.Text = "Editar Comision";
                formComisionDesktop.ShowDialog();
                Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.SelectedRows.Count == 1)
            {
                int id = ((Business.Entities.Comision)dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop formComisionDesktop = new ComisionDesktop(id, ApplicationForm.ModoForm.Baja);
                formComisionDesktop.Text = "Eliminar Comision";
                formComisionDesktop.ShowDialog();
                Listar();
            }
        }

       
    }
}
