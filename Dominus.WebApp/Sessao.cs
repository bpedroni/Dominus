using Dominus.DataModel;
using System;
using System.Globalization;
using System.Web;
using System.Web.Security;

namespace Dominus.WebApp
{
    public static class Sessao
    {
        public static void IniciarSessao(Usuario usuario)
        {
            HttpContext.Current.Session["Usuario"] = usuario;
            HttpContext.Current.Session["Periodo"] = DateTime.Now.ToString(@"MMMM / yyyy", new CultureInfo("PT-br"));

            FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, usuario.Login, DateTime.Now, DateTime.Now.AddMinutes(30), true, usuario.Nome);
            string cookiestr = FormsAuthentication.Encrypt(tkt);
            HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            ck.Expires = tkt.Expiration;
            ck.Path = FormsAuthentication.FormsCookiePath;
            HttpContext.Current.Response.Cookies.Add(ck);
        }
    }
}