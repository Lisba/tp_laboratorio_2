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
        double numero;

        public string SetNumero
        {
            set 
            {
                numero = ValidarNumero(value);
            }
        }

        public Numero()
        {
            this.numero = 0;
        }
        
        public Numero(double numero)
        {
            this.numero = numero;
        }
        
        public Numero(string strNumero)
        {
            Double.TryParse(strNumero, out this.numero);
        }

        public string BinarioDecimal(string binario)
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

        public string DecimalBinario(double numero)
        {
            int remainder;
            string result = string.Empty;
            int numeroEntero = (int)numero;

            while (numeroEntero > 0)
            {
                remainder = numeroEntero % 2;
                numeroEntero /= 2;
                result = remainder.ToString() + result;
            }

            return result;
        }

        public string DecimalBinario(string numero)
        {
            double doubleNumber;
            double.TryParse(numero, out doubleNumber);
            return DecimalBinario(doubleNumber);
        }

        bool EsBinario(string binario)
        {
            bool isBinary = true;

            foreach (char character in binario)
            {
                if (character < '0' || character > '1')
                {
                    isBinary = false;
                }
            }

            return isBinary;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double returnValue;

            if (n2.numero == 0)
            {
                returnValue = Double.MinValue;
            }
            else
            {
                returnValue = n1.numero / n2.numero;
            }

            return returnValue;
        }

        double ValidarNumero(string strNumero)
        {
            bool isDouble = true;
            double doubleReturned = 0;
            int dotCounter = 0;

            foreach(char character in strNumero)
            {
                if((character < '0' || character > '9') && (character != '.'))
                {
                    isDouble = false;
                }

                if (character == '.')
                {
                    dotCounter++;
                }
            }

            if(dotCounter > 1)
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
