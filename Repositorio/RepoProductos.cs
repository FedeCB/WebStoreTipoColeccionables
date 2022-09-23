using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;

namespace Repositorio
{
    public class RepoProductos : IRepositorio<Producto>
    {
        public bool Alta(Producto obj)
        {
            bool ret = false;

            if (obj != null)
            {
                string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=BaseFreakLand; Integrated Security=SSPI;";
                SqlConnection sqlCon = new SqlConnection(strCon);

                string strSql = "insert into Productos(Nombre, Descripcion, Precio, IdCategoria, marca) values(@nombre, @descripcion, @precio, @Categoria, @marca);";
                strSql += "select cast(scope_identity() as int);"; //ASÍ OBTENDREMOS EL ID AUTOGENERADO EN LA BASE
                SqlCommand sqlComm = new SqlCommand(strSql, sqlCon);

                sqlComm.Parameters.AddWithValue("@nombre", obj.Nombre);
                sqlComm.Parameters.AddWithValue("@descripcion", obj.Descripcion);
                sqlComm.Parameters.AddWithValue("@precio", obj.Precio);
                sqlComm.Parameters.AddWithValue("@Categoria", obj.Categoria.Id);
                sqlComm.Parameters.AddWithValue("@marca", obj.Marca);



                try
                {
                    sqlCon.Open();
                    int afectadas = sqlComm.ExecuteNonQuery();
                    sqlCon.Close();

                    ret = afectadas == 1;
                }
                catch 
                {

                    throw;
                }
                finally
                {
                    if (sqlCon.State == ConnectionState.Open)
                    {
                        sqlCon.Close();
                    }
                }

            }
            return ret;
        }

        public bool Baja(int id)
        {
            bool ret = false;

            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=BaseFreakLand; Integrated Security=SSPI;";
            SqlConnection sqlCon = new SqlConnection(strCon);

            string strSql = "delete from Productos where id = @id;";
            SqlCommand sqlComm = new SqlCommand(strSql, sqlCon);

            sqlComm.Parameters.AddWithValue("@id", id);

            try
            {
                sqlCon.Open();
                int afectadas = sqlComm.ExecuteNonQuery();
                sqlCon.Close();

                ret = afectadas == 1;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return ret;
        }

        public bool Modificacion(Producto obj)
        {
            bool ret = false;

            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=BaseFreakLand; Integrated Security=SSPI;";
            SqlConnection sqlCon = new SqlConnection(strCon);

            string strSql = "update from Productos set Nombre = @nombre, Descripcion = @descripcion, Precio = @precio, Categoria = @Categoria, Marca = @marca where id = @id;";
            SqlCommand sqlComm = new SqlCommand(strSql, sqlCon);

            sqlComm.Parameters.AddWithValue("@nombre", obj.Nombre);
            sqlComm.Parameters.AddWithValue("@descripcion", obj.Descripcion);
            sqlComm.Parameters.AddWithValue("@precio", obj.Precio);
            sqlComm.Parameters.AddWithValue("@Categoria", obj.Categoria.Id);
            sqlComm.Parameters.AddWithValue("@marca", obj.Marca);
            sqlComm.Parameters.AddWithValue("@id", obj.Id);

            try
            {
                sqlCon.Open();
                int afectadas = sqlComm.ExecuteNonQuery();
                sqlCon.Close();

                ret = afectadas == 1;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return ret;
        }

        public List<Producto> TraerTodo()
        {
            List<Producto> productos = new List<Producto>();

            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=BaseFreakLand; Integrated Security=SSPI;";
            SqlConnection sqlCon = new SqlConnection(strCon);

            string strSql = "select * from Productos;";
            SqlCommand sqlComm = new SqlCommand(strSql, sqlCon);

            try
            {
                sqlCon.Open();
                SqlDataReader reader = sqlComm.ExecuteReader();

                while (reader.Read())
                {
                    Producto producto = new Producto
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2),
                        Precio = reader.GetInt32(3),
                        //Categoria = reader.GetInt32(4),  ¿Còmo leer la categorìa en esta parte?
                        Marca = reader.GetString(5)

                    };

                    productos.Add(producto);
                }

                sqlCon.Close();
            }

            catch
            {
                throw;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return productos;
        }

        public Producto BuscarPorId(int id)
        {
            Producto producto = null;

            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=BaseFreakLand; Integrated Security=SSPI;";
            SqlConnection sqlCon = new SqlConnection(strCon);

            string strSql = "select * from Productos where Id = @id;";
            SqlCommand sqlComm = new SqlCommand(strSql, sqlCon);

            sqlComm.Parameters.AddWithValue("@id", id);

            try
            {
                sqlCon.Open();
                SqlDataReader reader = sqlComm.ExecuteReader();

                if (reader.Read())
                {
                    producto = new Producto
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2),
                        Precio = reader.GetInt32(3),
                        //Categoria = reader.GetInt32(4),  ¿Còmo leer la categorìa en esta parte?
                        Marca = reader.GetString(5)
                    };
                }

                sqlCon.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return producto;
        }

    }
}
