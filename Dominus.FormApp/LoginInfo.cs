﻿using Dominus.DataModel;

namespace Dominus.FormApp
{
    public static class LoginInfo
    {
        public static Usuario Usuario;

        public static void Login(Usuario usuario)
        {
            Usuario = usuario;
        }

        public static void Logoff()
        {
            Usuario = null;
        }
    }
}
