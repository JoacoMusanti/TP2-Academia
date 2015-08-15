using Business.Entities;
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

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {

        private List<Plan> _planes;
        public MateriaDesktop()
        {
            InitializeComponent();
            PlanLogic planLogic = new PlanLogic();
            _planes = planLogic.GetAll();
            CargarPlanes();
        }

        private Materia materiaActual { get; set; }

        public MateriaDesktop(ModoForm modo):this()
        {
            Modo = modo;
        }

        private void CargarPlanes()
        {
            List<Plan> planesCombo = _planes.FindAll(x => x.IdEspecialidad == (int)cbEspecialidad.SelectedValue);

            cbPlan.DataSource = planesCombo;
            cbPlan.ValueMember = "ID";
            cbPlan.DisplayMember = "Descripcion";
        }

        public MateriaDesktop(int ID,ModoForm modo):this()
        {
            Modo = modo;
            MateriaLogic mat = new MateriaLogic();
            try
            {
                materiaActual = mat.GetOne(ID);
                MapearDeDatos();
            }
            catch(Exception e)
            {
                Notificar("Error inesperado", e.Message + "\nIntente realizar la operacion nuevamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MapearDeDatos()
        {
            
        }

        protected override bool Validar()
        {
            string error = "";
            bool retorno = true;
            int temp;

            if(string.IsNullOrWhiteSpace(txtDescMat.Text))
            {
                error += "El campo \"Descripcion\" no puede estar vacio\n";
                retorno = false;
            }

            if(string.IsNullOrWhiteSpace(txtHsSemMat.Text))
            {
                error += "El campo \"Horas semanales\" no puede estar vacio\n";
                retorno = false;
            }

            if(string.IsNullOrWhiteSpace(txtHsTotMat.Text))
            {
                error += "El campo \"Horas totales\" no puede estar vacio\n";
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

        protected override void GuardarCambios()
        {
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if(Validar()==true)
                {
                    GuardarCambios();
                    Close();
                }
            }
            else
                if(Modo == ModoForm.Baja)
                {
                    GuardarCambios();
                    Close();
                }
        }
        
    }
}
