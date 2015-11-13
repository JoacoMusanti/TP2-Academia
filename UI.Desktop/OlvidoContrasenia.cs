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
                PersonaLogic perLogic = new PersonaLogic();

                Persona per = perLogic.GetOne(txtUsuario.Text);
                per.State = BusinessEntity.States.Modified;
                if (per.NombreUsuario == txtUsuario.Text)
                {
                    Random randomPass = new Random();
                    string posibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                    int longitud = posibles.Length;
                    char letra;
                    string nuevacadena = "";
                    for (int i = 0; i < 9; i++)
                    {
                        letra = posibles[randomPass.Next(longitud)];
                        nuevacadena += letra.ToString();
                    }
                    EnviarMail(per.Email, nuevacadena);
                    MessageBox.Show("Correo enviado correctamente");
                    per.Clave = Util.Hash.SHA256ConSal(nuevacadena, null);
                    perLogic.Save(per);
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
            string de = "aplicaciontp2@gmail.com";
            string asunto = "Mensaje de recuperacion de contraseña";
            MailMessage mensaje = new MailMessage(de, mail, asunto, "Su nueva contraseña es: \n\n" + cuerpo);
            SmtpClient cliente = new SmtpClient("smtp.gmail.com");
            cliente.Port = Convert.ToInt32("587");
            cliente.EnableSsl = true;
            cliente.UseDefaultCredentials = false;
            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
            cliente.Credentials = new NetworkCredential(de, "zaq12wsxCDE3");
            cliente.Send(mensaje);
            mensaje.Dispose();
            cliente.Dispose();
        }
    }
}
