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
    public partial class FormLogin : ApplicationForm
    {
        private Persona UsuarioActual { get; set; }
        public Persona.TipoPersonas Rol 
        {
            get { return UsuarioActual.TipoPersona; } 
        }
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            PersonaLogic usr = new PersonaLogic();

            try
            {
                UsuarioActual = usr.GetOne(txtUsuario.Text);
                // UNDONE: Restringir el acceso a ciertos forms segun el tipo de persona
                if (UsuarioActual.Clave != null &&
                    Util.Hash.VerificarHash(UsuarioActual.Clave, txtPass.Text))
                {
                    DialogResult = DialogResult.OK;
                }
                else if (UsuarioActual.Clave != null && UsuarioActual.Habilitado == false)
                {
                    Notificar("Login", "Este usuario no esta habilitado para usar el sistema", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                else
                {
                    Notificar("Login", "Usuario y/o contraseña incorrectos",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception a)
            {
                Notificar(a);
            }
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OlvidoContrasenia formContrasenia = new OlvidoContrasenia();
            formContrasenia.ShowDialog();
        }
               
    }
}
