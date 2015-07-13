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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        private Especialidad EspecialidadActual { get; set; }

        protected override void MapearDeDatos()
        {
            txtDescripcion.Text = EspecialidadActual.Descripcion;
            txtID.Text = EspecialidadActual.ID.ToString();

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

        protected override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Especialidad esp = new Especialidad();
                EspecialidadActual = esp;
                EspecialidadActual.State = BusinessEntity.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                EspecialidadActual.ID = int.Parse(txtID.Text);
                EspecialidadActual.State = BusinessEntity.States.Modified;
            }

            EspecialidadActual.Descripcion = txtDescripcion.Text;
        }

        protected override void GuardarCambios()
        {
            MapearADatos();

            EspecialidadLogic esp = new EspecialidadLogic();

            try
            {
                esp.Save(EspecialidadActual);
            }
            catch (Exception e)
            {
                Notificar("Error inesperado", e.Message + "\nIntente realizar la operacion nuevamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (retorno == false)
            {
                Notificar(error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retorno;
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
    }
}
