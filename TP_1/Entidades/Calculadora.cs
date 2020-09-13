using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double returnValue = 0;
            char charOperator;

            if (String.IsNullOrEmpty(operador))
            {
                operador = "+";
            }

            if (char.TryParse(operador, out charOperator))
            {
                switch (ValidarOperador(charOperator))
                {
                    case "+":
                        returnValue = num1 + num2;
                        break;
                    case "-":
                        returnValue = num1 - num2;
                        break;
                    case "*":
                        returnValue = num1 * num2;
                        break;
                    case "/":
                        returnValue = num1 / num2;
                        break;
                    default:
                        returnValue = num1 + num2;
                        break;
                }
            }

            return returnValue;
        }

        private static string ValidarOperador(char operador)
        {
            string returnValue = String.Empty;

            switch (operador)
            {
                case '+':
                    returnValue = "+";
                    break;
                case '-':
                    returnValue = "-";
                    break;
                case '*':
                    returnValue = "*";
                    break;
                case '/':
                    returnValue = "/";
                    break;
                default:
                    returnValue = "+";
                    break;
            }

            return returnValue;
        }
    }
}
