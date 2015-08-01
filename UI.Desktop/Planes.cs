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
                dgvPlanes.DataSource = pl.GetAll();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                Notificar("Error inesperado", e.Message + "\nIntente la operacion nuevamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            throw new NotImplementedException();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
