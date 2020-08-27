using Dominus.DataModel;

namespace Dominus.FormApp
{
    public static class LoginInfo
    {
        private static Usuario Usuario;

        public static void Login(Usuario usuario)
        {
            Usuario = usuario;
        }

        public static void Logout()
        {
            Usuario = null;
        }
    }
}
