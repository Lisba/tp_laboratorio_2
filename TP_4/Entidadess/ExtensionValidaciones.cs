using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades
{
    public static class ExtensionValidaciones
    {
        /// <summary>
        /// Convierte el primer caracter a mayusucula de la instancia recibida por parámetro.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string ConvertirPrimeraLetraAMayusucula(this string texto)
        {
            string retorno;

            if (!string.IsNullOrEmpty(texto))
            {
                retorno = char.ToUpper(texto[0]) + texto.Substring(1);
            }
            else
            {
                retorno = string.Empty;
            }


            return retorno;
        }
    }
}
