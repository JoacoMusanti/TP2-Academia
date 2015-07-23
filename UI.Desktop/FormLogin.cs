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
        private Usuario UsuarioActual { get; set; }
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic usr = new UsuarioLogic();

            try
            {
                UsuarioActual = usr.GetOne(this.txtUsuario.Text);
                if (UsuarioActual.Clave != null && Util.Hash.VerificarHash(UsuarioActual.Clave, txtPass.Text))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    Notificar("Login", "Usuario y/o contraseña incorrectos",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception a)
            {
                Notificar("Error inesperado", a.Message + "\nIntente realizar la operacion nuevamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OlvidoContrasenia formContrasenia = new OlvidoContrasenia();
            formContrasenia.ShowDialog();
        }
               
    }
}
