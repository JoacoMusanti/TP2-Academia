using Business.Logic;
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
    public partial class Materias : ApplicationForm
    {
        public Materias()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
            dgvMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Listar()
        {
            MateriaLogic matLogic = new MateriaLogic();
            try
            {
                dgvMaterias.DataSource = matLogic.GetAll();
            }
            catch(Exception e)
            {
                Notificar(e) ;
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop formMateriaDesktop = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateriaDesktop.Text = "Agregar Materia";
            formMateriaDesktop.ShowDialog();
            Listar();
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            if(dgvMaterias.SelectedRows.Count == 1)
            {
                int id = ((Materia)(dgvMaterias.SelectedRows[0].DataBoundItem)).ID;
                MateriaDesktop formMateriaDesktop = new MateriaDesktop(id, ApplicationForm.ModoForm.Modificacion);
                formMateriaDesktop.Text = "Editar Materia";
                formMateriaDesktop.ShowDialog();
                Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if(dgvMaterias.SelectedRows.Count == 1)
            {
                int id = ((Materia)(dgvMaterias.SelectedRows[0].DataBoundItem)).ID;
                MateriaDesktop formMateriaDesktop = new MateriaDesktop(id,ApplicationForm.ModoForm.Baja);
                formMateriaDesktop.Text = "Eliminar Materia";
                formMateriaDesktop.ShowDialog();
                Listar();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
