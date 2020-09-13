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
        #region Fields
        /// <summary>
        /// El campo para almacenar el numero en formato double de cada instancia.
        /// </summary>
        private double numero;
        #endregion

        #region Properties
        /// <summary>
        /// Propiedad write-only para el campo numero (Valida el valor recibido).
        /// </summary>
        public string SetNumero
        {
            set 
            {
                numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor por defecto (llama a otro constructor con un cero de tipo double).
        /// </summary>
        public Numero(): this(default(Double))
        {
            
        }
        
        /// <summary>
        /// Convierte a string el double recibido y llama a otro constructor.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero): this(numero.ToString())
        {
            
        }
        
        /// <summary>
        /// Llama a la propiedad set pasando el string recibido.
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Convierte un numero Binario en formato string a Decimal en formato string.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>El numero Decimal en formato string.</returns>
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

        /// <summary>
        /// Convierte un numero Decimal a Binario en formato string.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>El numero binario en formato string.</returns>
        public static string DecimalBinario(double numero)
        {
            int resto;
            string resultado = "0"; // En caso de que llegue un 0 por parametro.
            int numeroEntero = (int)numero;

            while (numeroEntero > 0)
            {
                resto = numeroEntero % 2;
                numeroEntero /= 2;
                resultado = resto.ToString() + resultado;
            }

            return resultado;
        }

        /// <summary>
        /// Convierte a double el decimal en string recibido y se lo pasa al metodo correspondiente (Sobrecarga de métodos).
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>El numero Binario en formato string.</returns>
        public static string DecimalBinario(string numero)
        {
            string returnValue = String.Empty;
            double doubleNumber;

            if (double.TryParse(numero, out doubleNumber))
            {
                returnValue = DecimalBinario(doubleNumber);
            }
            return returnValue;
        }

        /// <summary>
        /// Valida que el numero string recibido sea un binario válido (solo unos y ceros).
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>True o False si es o no un binario válido.</returns>
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

        /// <summary>
        /// Sobrecarga del operador + para los objetos de tipo "Numero".
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>La suma de los campos "numero" de ambos objetos.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador - para los objetos de tipo "Numero".
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>La resta de los campos "numero" de ambos objetos.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador * para los objetos de tipo "Numero".
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>La multiplicación de los campos "numero" de ambos objetos.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador / para los objetos de tipo "Numero".
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>La division de los campos "numero" de ambos objetos.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double returnValue = double.MinValue;

            if (n2.numero != 0)
            {
                returnValue = n1.numero / n2.numero;
            }

            return returnValue;
        }

        /// <summary>
        /// Valida que el string recibido sea un double válido (Solo se considera la coma para la parte flotante, el punto se permite pero no representa importancia para el cálculo).
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>El numero en formato double ó cero si no es un double válido.</returns>
        private double ValidarNumero(string strNumero)
        {
            bool isDouble = true;
            double doubleReturned = 0;
            int comaCounter = 0;

            foreach(char character in strNumero)
            {
                if((character < '0' || character > '9') && (character != ',' && character != '.'))
                {
                    isDouble = false;
                    break;
                }

                if (character == ',' || character == '.')
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
        #endregion
    }
}
