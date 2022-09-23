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
    public static class FachadaStore
    {
        public static bool AltaCliente(string nombre, string apellido, string telefono, string direccion, string password)
        {
            bool ret = false;
            Cliente cli = new Cliente()
            {
                Nombre = nombre,
                Apellido = apellido,
                Telefono = telefono,
                Direccion = direccion,
                Password = password

        };

            RepoClientes repoCli = new RepoClientes();
            ret = repoCli.Alta(cli);
            return ret;

        }

        public static bool AltaProducto(string nombre, string descripcion, decimal precio, Categoria categoria, string marca) 
        {
            bool ret = false;


            //RepoCategorias repoCateg = new RepoCategorias();  ************* FALTA IMPLEMENTAR RepoCategorias *************
            Categoria c = new Categoria(); //= repoCateg.BuscarPorId(idCat);

            if (c != null) 
            {
               
                Producto p = new Producto()
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    Precio = precio,
                    Categoria = c, 
                    Marca = marca
                };


                RepoProductos repoProd = new RepoProductos();
                ret = repoProd.Alta(p);
            }

            return ret;
        }
    }
}
