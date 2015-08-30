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
    public partial class ApplicationForm : Form
    {
        public enum ModoForm
        {
            Alta,
            Baja,
            Modificacion,
            Consulta
        }

        public ModoForm Modo {get;set;}


        public ApplicationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Utilizado en cada formulario para copiar la
        /// información de las entidades a los controles del formulario(TextBox,
        /// ComboBox, etc) para mostrar la infromación de cada entidad
        /// </summary>
        protected virtual void MapearDeDatos() { }

        /// <summary>
        /// Utilizado para pasar la información de los
        /// controles a una entidad para luego enviarla a las capas inferiores
        /// </summary>
        protected virtual void MapearADatos(){}

        /// <summary>
        /// Utilizado para invocar al método
        /// correspondiente de la capa de negocio según sea el ModoForm en que se
        /// encuentre el formulario
        /// </summary>
        protected virtual void GuardarCambios() { }


        /// <summary>
        /// Devuelve si los datos son válidos para poder
        /// registrar los cambios realizados.
        /// </summary>
        /// <returns></returns>
        protected virtual bool Validar() { return false; }

        /// <summary>
        /// Utilizado para unificar el mecanismo de
        /// avisos al usuario y en caso de tener que modificar la forma en que se
        /// realizan los avisos al usuario sólo se debe modificar este método, en
        /// lugar de tener que reemplazarlo en toda la aplicación.
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="mensaje"></param>
        /// <param name="botones"></param>
        /// <param name="icono"></param>
        public DialogResult Notificar (string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            return MessageBox.Show(mensaje, titulo, botones, icono);
        }

        public DialogResult Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            return Notificar(Text, mensaje, botones, icono);
        }

        public DialogResult Notificar(Exception e)
        {
            return Notificar("Error inesperado", e.Message + "\nIntente realizar la operacion nuevamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
