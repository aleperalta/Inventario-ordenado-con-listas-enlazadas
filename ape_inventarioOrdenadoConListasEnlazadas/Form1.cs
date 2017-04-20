using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ape_inventarioOrdenadoConListasEnlazadas
{
    public partial class frmPrincipal : Form
    {
        Inventario inventario = new Inventario();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (vacio())
                MessageBox.Show("Favor de llenar los campos incompletos. Gracias.");
            else
            {
                int vCodigo = Convert.ToInt16(txtCodigo.Text);
                string vNombre = txtNombre.Text;
                double vPrecio = Convert.ToDouble(txtPrecio.Text);
                int vCantidad = Convert.ToInt16(txtCantidad.Text);

                if (inventario.buscar(vCodigo) != null)
                    MessageBox.Show("Producto ya existente.");
                else
                    inventario.agregar(new Producto(vCodigo, vNombre, vPrecio, vCantidad));

                limpiarTXT();
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
                MessageBox.Show("Favor de escribir el código del producto a eliminar.");
            else
                if (inventario.buscar(Convert.ToInt16(txtCodigo.Text)) == null)
                MessageBox.Show("El producto no existe.");
            else
            {
                inventario.eliminar();
                MessageBox.Show("Producto eliminado.");
                txtReporte.Text = inventario.mostrar();
            }

            limpiarTXT();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
                MessageBox.Show("Favor de escribir el código del producto a buscar.");
            else
                if (inventario.buscar(Convert.ToInt16(txtCodigo.Text)) == null)
                    MessageBox.Show("El producto no existe.");
                else
                    txtReporte.Text = inventario.buscar(Convert.ToInt16(txtCodigo.Text)).ToString();

            limpiarTXT();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Text = inventario.mostrar();
        }

        public bool vacio()
        {
            if (txtCodigo.Text == "" || txtNombre.Text == "" || txtPrecio.Text == "" || txtCantidad.Text == "")
                return true;
            else
                return false;
        }

        public void limpiarTXT()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
        }
    }
}
