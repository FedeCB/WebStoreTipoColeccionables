using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;


namespace Dominio
{
    public class Cliente : Usuario
    {

        public override string GetRol()
        {
            return "Cliente";
        }

    }
}
