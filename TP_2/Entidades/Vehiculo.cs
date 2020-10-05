﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        string chasis;
        EMarca marca;
        ConsoleColor color;
        ETamanio tamanio;

        public enum ETamanio
        {
            Chico,
            Mediano,
            Grande
        }

        public enum EMarca
        {
            BMW,
            HarleyDavidson,
            Toyota,
            Chevrolet,
            Ford,
            Renault,
            Honda
        }

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        public virtual ETamanio Tamanio { get; }
        public virtual ConsoleColor Color { get; }
        public virtual string Chasis { get; }
        public virtual EMarca Marca { get; }

        public Vehiculo(EMarca marca, string chasis, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public abstract string Mostrar();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: {p.chasis}");
            sb.AppendLine($"MARCA : {p.marca}");
            sb.AppendLine($"COLOR : {p.color}");
            sb.AppendLine("");
            sb.AppendLine($"TAMANIO : {p.Tamanio}");
            sb.AppendLine("---------------------");
            sb.AppendLine("");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }

        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        
        public override bool Equals(object o)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
