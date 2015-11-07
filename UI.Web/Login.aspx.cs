using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {

        private Persona UsuarioActual { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            PersonaLogic usr = new PersonaLogic();

            try
            {
                UsuarioActual = usr.GetOne(loginAcademia.UserName);
                // UNDONE: Restringir el acceso a ciertos forms segun el tipo de persona
                if (UsuarioActual.Clave != null &&
                    Util.Hash.VerificarHash(UsuarioActual.Clave, loginAcademia.Password) &&
                    UsuarioActual.Habilitado == true)
                {
                    Session["RolSesion"] = UsuarioActual.TipoPersona;
                    Session["IdAlumno"] = UsuarioActual.ID;
                    Session["IdPlan"] = UsuarioActual.IdPlan;
                    FormsAuthentication.RedirectFromLoginPage(loginAcademia.UserName, loginAcademia.RememberMeSet);
                }
                else
                {
                    if (UsuarioActual.Habilitado == false)
                    {
                        Response.Write("El usuario " + User.Identity.Name + " no esta habilitado a usar el sistema.");
                    }
                    else
                    {
                        Response.Write("Usuario y/o contraseña incorrectos");
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "mensajeError", "mensajeError();", true);
            }
        }
    }
}