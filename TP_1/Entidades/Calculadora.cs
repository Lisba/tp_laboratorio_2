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
            double returnValue;

            switch (operador)
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

            return returnValue;
        }

        static string ValidarOperador(char operador)
        {
            char returnValue;

            switch (operador)
            {
                case '+':
                    returnValue = operador;
                    break;
                case '-':
                    returnValue = operador;
                    break;
                case '*':
                    returnValue = operador;
                    break;
                case '/':
                    returnValue = operador;
                    break;
                default:
                    returnValue = '+';
                    break;
            }

            return Char.ToString(returnValue);
        }
    }
}
