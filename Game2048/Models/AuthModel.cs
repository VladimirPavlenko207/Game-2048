using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048.Models
{
    internal class AuthModel
    {
        private readonly string correctLogin = "Admin"; 
        private readonly string correctPass = "Admin";
         
        public string Login { get; set; }
        public string Pass { get; set; }

        public bool Aythentication()
        {
            // Упрощенная проверка (без пароля)
            if (Login == correctLogin ) return true;
            return false;
        }
    }
}
