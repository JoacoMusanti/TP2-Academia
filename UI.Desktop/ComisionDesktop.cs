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
        private List<Plan> _planes;
        private List<Especialidad> _especialidades;

        public ComisionDesktop()
        {
            InitializeComponent();
            PlanLogic planLogic = new PlanLogic();
            _planes = planLogic.GetAll();
            CargarEspecialidades();
            CargarPlanes();
        }

        private void CargarEspecialidades()
        {
            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            _especialidades = especialidadLogic.GetAll();

            cbEspecialidad.ValueMember = "ID";
            cbEspecialidad.DisplayMember = "Descripcion";
            cbEspecialidad.DataSource = _especialidades;
            
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
                Notificar(e);
            }
        }

        protected override void MapearDeDatos()
        {
            txtDescripcion.Text = comisionActual.Descripcion;
            txtAnioDeEspecialidad.Text = comisionActual.AnioEspecialidad.ToString();
            txtID.Text = comisionActual.ID.ToString();
            // buscamos el plan de esta comision y luego buscamos la especialidad que tenga ese plan
            Plan p = _planes.Find(x => x.ID == comisionActual.IdPlan);
            cbEspecialidad.SelectedValue = _especialidades.Find(y => y.ID == p.IdEspecialidad).ID;
            cbPlan.SelectedValue = comisionActual.IdPlan;
            
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                txtID.Enabled = false;
                txtAnioDeEspecialidad.Enabled = false;
                txtDescripcion.Enabled = false;
                cbPlan.Enabled = false;
                cbEspecialidad.Enabled = false;
                btnAceptar.Text = "Eliminar";
            }
        }


        protected override bool Validar()
        {
            string error = "";
            bool retorno = true;
            int temp;

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                error += "El campo \"Descripcion\" no puede estar vacio\n";
                retorno = false;
            }

            if (string.IsNullOrWhiteSpace(txtAnioDeEspecialidad.Text))
            {
                error += "El campo de \"Año de especialidad\" no puede estar vacio\n";
                retorno = false;
            }
            if (int.TryParse(txtAnioDeEspecialidad.Text, out temp) == false || (temp > 5 || temp < 1))
            {
                error += "El campo \"Año especialidad\" debe contener un numero entero entre 1 y 5";
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
                comisionActual.State = BusinessEntity.States.Modified;
                comisionActual.Baja = true;
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
                Notificar(e);
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

        private void CargarPlanes()
        {
            List<Plan> planesCombo = _planes.FindAll(x => x.IdEspecialidad == (int)cbEspecialidad.SelectedValue);

            cbPlan.DataSource = planesCombo;
            cbPlan.ValueMember = "ID";
            cbPlan.DisplayMember = "Descripcion";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPlanes();
        }
    }
}
