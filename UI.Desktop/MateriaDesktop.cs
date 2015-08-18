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
        private List<Especialidad> _especialidades;

        public MateriaDesktop()
        {
            InitializeComponent();
            PlanLogic planLogic = new PlanLogic();
            _planes = planLogic.GetAll();
            CargarEspecialidades();
            CargarPlanes();
            
        }

        private Materia materiaActual { get; set; }

        public MateriaDesktop(ModoForm modo):this()
        {
            Modo = modo;
        }

        private void CargarEspecialidades()
        {
            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            _especialidades = especialidadLogic.GetAll();

            cbEspecialidad.ValueMember = "ID";
            cbEspecialidad.DisplayMember = "Descripcion";
            cbEspecialidad.DataSource = _especialidades;

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

        protected override void MapearDeDatos()
        {
            txtIDMat.Text = materiaActual.ID.ToString();
            txtDescMat.Text = materiaActual.Descripcion;
            txtHsSemMat.Text = materiaActual.HorasSemanales.ToString();
            txtHsTotMat.Text = materiaActual.HorasTotales.ToString();
            Plan p = _planes.Find(x => x.ID == materiaActual.IdPlan);
            cbEspecialidad.SelectedValue = _especialidades.Find(y => y.ID == p.IdEspecialidad).ID;
            cbPlan.SelectedValue = materiaActual.IdPlan;

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                
                txtIDMat.Enabled = false;
                txtHsSemMat.Enabled = false;
                txtDescMat.Enabled = false;
                txtHsTotMat.Enabled = false;
                cbPlan.Enabled = false;
                cbEspecialidad.Enabled = false;
                btnAceptar.Text = "Eliminar";
            }
        }

        protected override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Materia mat = new Materia();              
                materiaActual = mat;
                materiaActual.State = BusinessEntity.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                materiaActual.ID = int.Parse(txtIDMat.Text);
                materiaActual.State = BusinessEntity.States.Modified;
            }
            if (Modo == ModoForm.Baja)
            {
                materiaActual.ID = int.Parse(txtIDMat.Text);
                materiaActual.State = BusinessEntity.States.Modified;
                materiaActual.Baja = true;
            }

            materiaActual.HorasSemanales = int.Parse(txtHsSemMat.Text);
            materiaActual.HorasTotales = int.Parse(txtHsTotMat.Text);
            materiaActual.Descripcion = txtDescMat.Text;
            materiaActual.IdPlan = Convert.ToInt32(cbPlan.SelectedValue);
        }

        protected override bool Validar()
        {
            string error = "";
            bool retorno = true;

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
            MapearADatos();


            MateriaLogic mat = new MateriaLogic();
            try
            {
                mat.Save(materiaActual);
            }
            catch (Exception e)
            {
                Notificar("Error inesperado", e.Message + "\nIntente realizar la operacion nuevamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
