using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ape_inventarioOrdenadoConListasEnlazadas
{
    class Inventario
    {
        Producto ultimo, primero, anterior, encontrado, temp;

        public Inventario()
        {
            primero = null;
        }

        public void agregar(Producto nuevoP)
        {
            if (primero == null)
            {
                primero = nuevoP;
                ultimo = nuevoP;
            }
            else
            {
                if (primero.siguiente == null)
                    if (primero.codigo > nuevoP.codigo)
                    {
                        nuevoP.siguiente = primero;
                        ultimo = primero;
                        primero = nuevoP;
                    }
                    else
                    {
                        primero.siguiente = nuevoP;
                        ultimo = nuevoP;
                    }
                else {
                    if (primero.codigo > nuevoP.codigo)
                    {
                        nuevoP.siguiente = primero;
                        primero = nuevoP;
                    }
                    else if (ultimo.codigo < nuevoP.codigo)
                    {
                        ultimo.siguiente = nuevoP;
                        ultimo = nuevoP;
                    }
                    else
                    {
                        temp = primero;

                        while (temp.siguiente.codigo < nuevoP.codigo && temp.siguiente != ultimo)
                        {
                            temp = temp.siguiente;
                        }

                        nuevoP.siguiente = temp.siguiente;
                        temp.siguiente = nuevoP;
                    }
                }
            }
        }

        public Producto buscar(int codigoP)
        {
            temp = primero;
            encontrado = null;

            while (encontrado == null && temp != null)
                if (temp.codigo == codigoP)
                    encontrado = temp;
                else
                {
                    anterior = temp;
                    temp = temp.siguiente;
                }

            return encontrado;
        }

        public void eliminar()
        {
            anterior.siguiente = encontrado.siguiente;
            //encontrado = null;
        }

        public string mostrar()
        {
            string vProducto = "";
            temp = primero;

            while (temp != null)
            {
                vProducto += temp.ToString() + Environment.NewLine;
                temp = temp.siguiente;
            }

            return vProducto;
        }
    }
}
