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
using System.Net.Mail;
using System.Net;

namespace UI.Desktop
{
    public partial class OlvidoContrasenia : ApplicationForm
    {
        public OlvidoContrasenia()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Persona per = new PersonaLogic().GetOne(txtUsuario.Text);

                if (per.NombreUsuario == txtUsuario.Text)
                {
                    EnviarMail(per.Email, "1234");
                    Close();
                }
            }
            catch (Exception ex)
            {
                Notificar(ex);
            }
        }

        private void EnviarMail(string mail, string cuerpo)
        {
            // CODIGO DE PRUEBA
            string de = "aplicaciontp2@gmail.com";
            string asunto = "Mensaje de prueba recuperacion de contraseña";
            MailMessage mensaje = new MailMessage(de, mail, asunto, cuerpo);
            SmtpClient cliente = new SmtpClient("smtp.gmail.com", 25);
            cliente.Credentials = new NetworkCredential(de, "zaq12wsxCDE3");
            cliente.EnableSsl = true;
            cliente.Send(mensaje);

            mensaje.Dispose();
            cliente.Dispose();
        }
    }
}
