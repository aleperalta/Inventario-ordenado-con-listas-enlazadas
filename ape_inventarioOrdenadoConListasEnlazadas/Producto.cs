using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ape_inventarioOrdenadoConListasEnlazadas
{
    class Producto
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }
        public Producto siguiente { get; set; }

        public Producto(int codigo, string nombre, double precio, int cantidad)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
            siguiente = null;
        }

        public override string ToString()
        {
            string prod = "Código: " + codigo.ToString() +
                          Environment.NewLine + "Nombre: " + nombre +
                          Environment.NewLine + "Precio: $ " + precio.ToString() +
                          Environment.NewLine + "Cantidad: " + cantidad.ToString() + Environment.NewLine;

            return prod;
        }
    }
}
