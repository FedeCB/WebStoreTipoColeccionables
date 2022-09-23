using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace Dominio
{
    public class Producto
    {

        #region Atributos

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public Categoria Categoria { get; set; }
        public string Marca { get; set; }
        
        public enum Condicion { Nuevo_en_caja, Perfecto_estado, Excelente_estado, Buen_estado, Usado, Pobre_estado }


        #endregion

    }
}
