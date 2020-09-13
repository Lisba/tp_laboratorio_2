using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Entidades
{
    public class Numero
    {
        private double number;

        public string Number
        {
            set 
            {
                number = ValidarNumero(value);
            }
        }

        public Numero()
        {
            number = 0;
        }
        
        public Numero(double numero)
        {
            number = numero;
        }
        
        public Numero(string strNumero)
        {
            Double.TryParse(strNumero, out number);
        }

        public static string BinarioDecimal(string binario)
        {
            string returnValue = "Valor Inválido";
            char[] charArr;
            int sum = 0;

            if (EsBinario(binario))
            {
                charArr = binario.ToCharArray();
                Array.Reverse(charArr);

                for (int i = 0; i < charArr.Length; i++)
                {
                    if (charArr[i] == '1')
                    {
                        if(i == 0)
                        {
                            sum += 1;
                        }
                        else
                        {
                            sum += (int)Math.Pow(2, i);
                        }
                    }
                }
                
                returnValue = sum.ToString();
            }
            
            return returnValue;
        }

        public static string DecimalBinario(double numero)
        {
            int resto;
            string resultado = string.Empty;
            int numeroEntero = (int)numero;

            while (numeroEntero > 0)
            {
                resto = numeroEntero % 2;
                numeroEntero /= 2;
                resultado = resto.ToString() + resultado;
            }

            return resultado;
        }

        public static string DecimalBinario(string numero)
        {
            double doubleNumber;
            double.TryParse(numero, out doubleNumber);
            return DecimalBinario(doubleNumber);
        }

        private static bool EsBinario(string binario)
        {
            bool isBinary = true;

            foreach (char character in binario)
            {
                if (character < '0' || character > '1')
                {
                    isBinary = false;
                    break;
                }
            }

            return isBinary;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.number + n2.number;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.number - n2.number;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.number * n2.number;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double returnValue = double.MinValue;

            if (n2.number != 0)
            {
                returnValue = n1.number / n2.number;
            }

            return returnValue;
        }

        private double ValidarNumero(string strNumero)
        {
            bool isDouble = true;
            double doubleReturned = 0;
            int comaCounter = 0;

            foreach(char character in strNumero)
            {
                if((character < '0' || character > '9') && (character != ','))
                {
                    isDouble = false;
                }

                if (character == ',')
                {
                    comaCounter++;
                }
            }

            if(comaCounter > 1)
            {
                isDouble = false;
            }

            if (isDouble)
            {
                Double.TryParse(strNumero, out doubleReturned);
            }

            return doubleReturned;
        }
    }
}
