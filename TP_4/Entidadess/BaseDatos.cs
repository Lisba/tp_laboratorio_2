using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class BaseDatos
    {
        #region Fields
        static SqlConnection conexion;
        static SqlCommand comando;
        static SqlDataReader lector;
        static string stringConnection;
        static Producto producto;
        static List<Producto> listaProductos;
        #endregion

        #region Constructors
        static BaseDatos()
        {
            stringConnection = @"Server=localhost\SQLEXPRESS; Database=TP4; Trusted_Connection=True";
            conexion = new SqlConnection(stringConnection);
            comando = new SqlCommand();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Inserta un producto en la Base de Datos
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="cantidadDisponible"></param>
        /// <param name="precioUnitario"></param>
        public static int InsertarProducto(string nombre, int cantidadDisponible, double precioUnitario)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = @"INSERT INTO Productos (nombre, cantidadDisponible, precioUnitario)
                                        VALUES (@NOMBRE, @CANTIDAD_DISPONIBLE, @PRECIO_UNITARIO)";

                comando.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                comando.Parameters.Add(new SqlParameter("@CANTIDAD_DISPONIBLE", cantidadDisponible));
                comando.Parameters.Add(new SqlParameter("@PRECIO_UNITARIO", precioUnitario));

                return comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new FailSqlOpException("¡Operación con la base de datos fallida!");
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Trae un producto desde la base de datos por su nombre.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public static Producto TraerProductoPorNombre(string nombre)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM Productos WHERE Nombre = @NOMBRE";

                comando.Parameters.Add(new SqlParameter("@NOMBRE", nombre));

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    producto = new Producto(
                        int.Parse(lector["Id"].ToString()),
                        lector["Nombre"].ToString(),
                        int.Parse(lector["CantidadDisponible"].ToString()),
                        double.Parse(lector["PrecioUnitario"].ToString())
                        );
                }

                return producto;
            }
            catch (Exception)
            {
                throw new FailSqlOpException("¡Operación con la base de datos fallida!");
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Trae todos los productos de la base de datos.
        /// </summary>
        /// <returns></returns>
        public static List<Producto> TraerProductos()
        {
            try
            {
                listaProductos = new List<Producto>();

                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM Productos";

                lector = comando.ExecuteReader();


                while (lector.Read())
                {
                    listaProductos.Add(new Producto(
                        int.Parse(lector["Id"].ToString()),
                        lector["Nombre"].ToString(),
                        int.Parse(lector["CantidadDisponible"].ToString()),
                        double.Parse(lector["PrecioUnitario"].ToString())
                        ));
                }

                return listaProductos;
            }
            catch (Exception ex)
            {
                throw new FailSqlOpException("¡Operación con la base de datos fallida!", ex);
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Elimina un producto de la base de datos.
        /// </summary>
        /// <param name="nombre"></param>
        public static int EliminarProductoPorNombre(string nombre)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "DELETE * FROM Productos WHERE Nombre = @NOMBRE";

                comando.Parameters.Add(new SqlParameter("@NOMBRE", nombre));

                return comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new FailSqlOpException("¡Operación con la base de datos fallida!");
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Disminuye uno a la cantidad de un producto en la Base de Datos.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="cantidadDisponible"></param>
        /// <param name="precioUnitario"></param>
        public static int DisminuirCantidadProducto(Producto producto)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = @"UPDATE Productos
                                        SET CantidadDisponible = CantidadDisponible - 1
                                        WHERE Id = @ID";

                comando.Parameters.Add(new SqlParameter("@ID", producto.Id));

                return comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new FailSqlOpException("¡Operación con la base de datos fallida!");
            }
            finally
            {
                conexion.Close();
            }
        }
        #endregion
    }
}
