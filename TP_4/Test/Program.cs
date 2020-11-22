﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prueba de Funcionalidades
            void PruebaTraerProductoPorNombre()
            {
                Producto producto = BaseDatos.TraerProductoPorNombre("Linterna");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Prueba Traer un Producto:\n");
                sb.AppendLine($"{producto.Id}");
                sb.AppendLine($"{producto.Nombre}");
                sb.AppendLine($"{producto.Cantidad}");
                sb.AppendLine($"{producto.PrecioUnidad}");

                Console.WriteLine(sb.ToString());

                Console.ReadKey();
            }

            void PruebaTraerTodosLosProducto()
            {
                List<Producto> listaProductos = BaseDatos.TraerProductos();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Prueba Traer Todos los Productos:\n");
                sb.AppendLine($"----------------------------");
                
                foreach(Producto item in listaProductos)
                {
                    sb.AppendLine($"ID: {item.Id}");
                    sb.AppendLine($"NOMBRE: {item.Nombre}");
                    sb.AppendLine($"CANTIDAD: {item.Cantidad}");
                    sb.AppendLine($"PRECIO UNIDAD: {item.PrecioUnidad}");
                    sb.AppendLine($"----------------------------");
                }

                Console.WriteLine(sb.ToString());
                Console.ReadKey();
            }

            PruebaTraerProductoPorNombre();
            Console.Clear();
            PruebaTraerTodosLosProducto();
        }
    }
}
