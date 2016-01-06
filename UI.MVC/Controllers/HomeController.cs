using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using Business.Logic;
using UI.MVC.ViewModels;
using Util;

namespace UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private PersonaLogic _logicPer;

        public PersonaLogic LogicPersona
        {
            get
            {
                if (_logicPer == null)
                {
                    _logicPer = new PersonaLogic();
                }

                return _logicPer;
            }
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            var user = LogicPersona.GetOne(lvm.User);

            if (user != null)
            {
                if (Hash.VerificarHash(user.Clave, lvm.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.NombreUsuario, false);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();   
            }
            
        }
    }
}
