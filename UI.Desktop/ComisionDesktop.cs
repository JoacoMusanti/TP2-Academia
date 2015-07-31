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
using Business.Entities;

namespace UI.Desktop
{
    public partial class ComisionDesktop : ApplicationForm
    {
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        public ComisionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        private Comision comisionActual { get; set; }

        public ComisionDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;

            ComisionLogic com = new ComisionLogic();

            try
            {
                comisionActual = com.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception e)
            {
                Notificar("Error inesperado", e.Message + "\nIntente realizar la operacion nuevamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void MapearDeDatos()
        {
            txtDescripcion.Text = comisionActual.Descripcion;
            txtID.Text = comisionActual.ID.ToString();

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                txtID.Enabled = false;
                txtDescripcion.Enabled = false;
                btnAceptar.Text = "Eliminar";
            }
        }


        protected override bool Validar()
        {
            string error = "";
            bool retorno = true;

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                error += "El campo \"Descripcion\" no puede estar vacio\n";
                retorno = false;
            }

            if (string.IsNullOrWhiteSpace(txtAnioDeEspecialidad.Text))
            {
                error += "El campo de \"Año de especialidad\" no puede estar vacio";
                retorno = false;
            }

            if (cbPlan.SelectedItem == null)
            {
                error += "Debe seleccionar un plan, el campo no puede estar vacío";
                retorno = false;
            }

            if (retorno == false)
            {
                Notificar(error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retorno;
        }

        protected override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Comision com = new Comision();
                comisionActual = com;
                comisionActual.State = BusinessEntity.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                comisionActual.ID = int.Parse(txtID.Text);
                comisionActual.State = BusinessEntity.States.Modified;
            }
            if (Modo == ModoForm.Baja)
            {
                comisionActual.ID = int.Parse(txtID.Text);
                comisionActual.State = BusinessEntity.States.Deleted;
            }

            comisionActual.AnioEspecialidad = int.Parse(txtAnioDeEspecialidad.Text);
            comisionActual.Descripcion = txtDescripcion.Text;
            comisionActual.IdPlan = Convert.ToInt32(cbPlan.SelectedValue);
        }

        protected override void GuardarCambios()
        {
            MapearADatos();

            ComisionLogic com = new ComisionLogic();

            try
            {
                com.Save(comisionActual);
            }
            catch (Exception e)
            {
                Notificar("Error inesperado", e.Message + "\nIntente realizar la operacion nuevamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Validar() == true)
                {
                    GuardarCambios();
                    Close();
                }
            }
            else if (Modo == ModoForm.Baja)
            {
                GuardarCambios();
                Close();
            }
        }

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'academiaDataSet.planes' Puede moverla o quitarla según sea necesario.
            this.planesTableAdapter.Fill(this.academiaDataSet.planes);

        }
    }
}
