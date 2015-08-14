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
    public partial class PlanDesktop : ApplicationForm
    {
        public PlanDesktop()
        {
            InitializeComponent();
            cargarEspecialidades();
        }
        
        private void cargarEspecialidades()
        {
            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            List<Especialidad> _especialidades = especialidadLogic.GetAll();

            cbEspecialidad.DataSource = _especialidades;
            cbEspecialidad.ValueMember = "ID";
            cbEspecialidad.DisplayMember = "Descripcion";
        }

        public PlanDesktop (ModoForm modo):this()
        {
            Modo = modo;
        }
        private Plan planActual{ get; set;}
        public PlanDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;

            PlanLogic plan = new PlanLogic();
            try
            {
                planActual = plan.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception e)
            {
                Notificar("Error inesperado", e.Message + "\nIntente realizar la operación nuevamente",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

        protected override void MapearDeDatos()
        {
            cbEspecialidad.SelectedValue = planActual.IdEspecialidad;
            txtIdPlan.Text = planActual.ID.ToString();
            txtDescPlan.Text = planActual.Descripcion;
            
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
                txtIdPlan.Enabled = false;
            }
            else if (Modo == ModoForm.Baja)
            {
                txtIdPlan.Enabled = false;
                txtDescPlan.Enabled = false;
                cbEspecialidad.Enabled = false;
                btnAceptar.Text = "Eliminar";
            }
        }
        protected override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Plan plan = new Plan();
                planActual = plan;
                planActual.State = BusinessEntity.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                planActual.ID = int.Parse(txtIdPlan.Text);
                planActual.State = BusinessEntity.States.Modified;
            }
            if (Modo == ModoForm.Baja)
            {
                planActual.ID = int.Parse(txtIdPlan.Text);
                planActual.State = BusinessEntity.States.Deleted;
            }

            planActual.Descripcion = txtDescPlan.Text;
            planActual.IdEspecialidad = Convert.ToInt32(cbEspecialidad.SelectedValue);
        }

        protected override void GuardarCambios()
        {
            MapearADatos();

            PlanLogic plan = new PlanLogic();

            try
            {
                plan.Save(planActual);
            }
            catch (Exception e)
            {
                Notificar("Error inesperado", e.Message + "\nIntente realizar la operacion nuevamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool Validar()
        {
            string msgError = "";
            bool retorno = true;
               
            if (string.IsNullOrWhiteSpace(txtDescPlan.Text))
            {
                msgError += "El campo \"Descripcion\" no puede estar vacio\n";
                retorno = false;
            }
           
            if(cbEspecialidad.SelectedValue == null)
            {
                msgError += "Debe seleccionar una Especialidad para el plan\n";
                retorno = false;
            }
                  
            if (retorno == false)
            {
                Notificar(msgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // TODO: Agregar una columna a las tablas en base de datos para dar de baja los registros
                // UNDONE: Modificar codigo para que elimine los registros de manera logica
                DialogResult resultado = Notificar("Al eliminar un plan se eliminaran todas las personas "
                    + "que pertenezcan al plan! \nDesea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    GuardarCambios();
                }
                
                Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
                                 
    }
}
