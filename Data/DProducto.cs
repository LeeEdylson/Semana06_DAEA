using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DProducto
    {
        public List<Producto> Listar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<Producto> productos = null;

            try
            {
                comandText = "USP_GetProducto";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                productos = new List<Producto>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, comandText,
                    CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            IdProducto = reader["idproducto"] != null ? Convert.ToInt32(reader["idproducto"]) : 0,
                            NombreProducto = reader["nombreProducto"] != null ? Convert.ToString(reader["nombreProducto"]) : string.Empty,
                            CantidadPorUnidad = reader["cantidadPorUnidad"] != null ? Convert.ToString(reader["cantidadPorUnidad"]) : string.Empty,
                            PrecioUnidad = reader["precioUnidad"] != null ? Convert.ToInt32(reader["precioUnidad"]) : 0,
                            UnidadesEnExistencia = reader["unidadesEnExistencia"] != null ? Convert.ToInt32(reader["unidadesEnExistencia"]) : 0,
                            UnidadesEnPedido = reader["unidadesEnPedido"] != null ? Convert.ToInt32(reader["unidadesEnPedido"]) : 0,
                            NivelNuevoPedido = reader["nivelNuevoPedido"] != null ? Convert.ToInt32(reader["nivelNuevoPedido"]) : 0
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            return productos;
        }

        public void Insertar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;

            try
            {
                comandText = "USP_InsProducto";
                parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@nombreProducto", SqlDbType.VarChar);
                parameters[0].Value = producto.NombreProducto;
                parameters[1] = new SqlParameter("@cantidadPorUnidad", SqlDbType.Text);
                parameters[1].Value = producto.CantidadPorUnidad;
                parameters[2] = new SqlParameter("@precioUnidad", SqlDbType.Int);
                parameters[2].Value = producto.PrecioUnidad;
                parameters[3] = new SqlParameter("@unidadesEnExistencia", SqlDbType.Int);
                parameters[3].Value = producto.UnidadesEnExistencia;
                parameters[4] = new SqlParameter("@unidadesEnPedido", SqlDbType.Int);
                parameters[4].Value = producto.UnidadesEnPedido;
                parameters[5] = new SqlParameter("@nivelNuevoPedido", SqlDbType.Int);
                parameters[5].Value = producto.NivelNuevoPedido;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Actualizar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;

            try
            {
                comandText = "USP_UpdProducto";
                parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                parameters[1] = new SqlParameter("@nombrecategoria", SqlDbType.VarChar);
                parameters[1].Value = producto.NombreProducto;
                parameters[2] = new SqlParameter("@cantidadPorUnidad", SqlDbType.Text);
                parameters[2].Value = producto.CantidadPorUnidad;
                parameters[3] = new SqlParameter("@precioUnidad", SqlDbType.Int);
                parameters[3].Value = producto.PrecioUnidad;
                parameters[4] = new SqlParameter("@unidadesEnExistencia", SqlDbType.Int);
                parameters[4].Value = producto.UnidadesEnExistencia;
                parameters[5] = new SqlParameter("@unidadesEnPedido", SqlDbType.Int);
                parameters[5].Value = producto.UnidadesEnPedido;
                parameters[6] = new SqlParameter("@nivelNuevoPedido", SqlDbType.Int);
                parameters[6].Value = producto.NivelNuevoPedido;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void Eliminar(int IdProducto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;

            try
            {
                comandText = "USP_DelProducto";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = IdProducto;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
