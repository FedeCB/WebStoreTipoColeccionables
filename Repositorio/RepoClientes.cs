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
    public class RepoClientes : IRepositorio<Cliente>
    {

        public bool Alta(Cliente obj)
        {
            bool ret = false;

            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=BaseFreakLand; Integrated Security=SSPI;";
            SqlConnection sqlCon = new SqlConnection(strCon);

            string strSql = "insert into Clientes(Nombre, Apellido, Telefono, Direccion, Password) values(@nombre, @apellido, @telefono, @direccion, @password);";
            SqlCommand sqlComm = new SqlCommand(strSql, sqlCon);

            sqlComm.Parameters.AddWithValue("@nombre", obj.Nombre);
            sqlComm.Parameters.AddWithValue("@apellido", obj.Apellido);
            sqlComm.Parameters.AddWithValue("@telefono", obj.Telefono);
            sqlComm.Parameters.AddWithValue("@direccion", obj.Direccion);
            sqlComm.Parameters.AddWithValue("@password", obj.Password);

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

        public bool Baja(int id)
        {
            bool ret = false;

            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=BaseFreakLand; Integrated Security=SSPI;";
            SqlConnection sqlCon = new SqlConnection(strCon);

            string strSql = "delete from Clientes where id = @id;";
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

        public bool Modificacion(Cliente obj)
        {
            bool ret = false;

            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=BaseFreakLand; Integrated Security=SSPI;";
            SqlConnection sqlCon = new SqlConnection(strCon);

            string strSql = "update from Clientes set Nombre = @nombre, Apellido = @apellido, Telefono = @telefono, Direccion = @direccion, Password = @password where id = @id;";
            SqlCommand sqlComm = new SqlCommand(strSql, sqlCon);

            sqlComm.Parameters.AddWithValue("@nombre", obj.Nombre);
            sqlComm.Parameters.AddWithValue("@apellido", obj.Apellido);
            sqlComm.Parameters.AddWithValue("@telefono", obj.Telefono);
            sqlComm.Parameters.AddWithValue("@direccion", obj.Direccion);
            sqlComm.Parameters.AddWithValue("@password", obj.Password);
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

        public List<Cliente> TraerTodo()
        {
            List<Cliente> clientes = new List<Cliente>();

            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=BaseFreakLand; Integrated Security=SSPI;";
            SqlConnection sqlCon = new SqlConnection(strCon);

            string strSql = "select * from Clientes;";
            SqlCommand sqlComm = new SqlCommand(strSql, sqlCon);

            try
            {
                sqlCon.Open();
                SqlDataReader reader = sqlComm.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        Telefono = reader.GetString(3),
                        Direccion = reader.GetString(4),
                        Password = reader.GetString(5)
                        
                    };

                    clientes.Add(cliente);
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

            return clientes;
        }

        public Cliente BuscarPorId(int id)
        {
            Cliente cliente = null;

            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=BaseFreakLand; Integrated Security=SSPI;";
            SqlConnection sqlCon = new SqlConnection(strCon);

            string strSql = "select * from Clientes where Id = @id;";
            SqlCommand sqlComm = new SqlCommand(strSql, sqlCon);

            sqlComm.Parameters.AddWithValue("@id", id);

            try
            {
                sqlCon.Open();
                SqlDataReader reader = sqlComm.ExecuteReader();

                if (reader.Read())
                {
                    cliente = new Cliente
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        Telefono = reader.GetString(3),
                        Direccion = reader.GetString(4),
                        Password = reader.GetString(5)
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

            return cliente;
        }

    }
}
