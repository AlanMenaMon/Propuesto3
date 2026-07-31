using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuColmado
{
    public partial class Form1 : Form
    {
        // Lista de productos con su precio
        private readonly (string Nombre, decimal Precio)[] productos = new (string, decimal)[]
        {
            ("Arroz (lb)", 35.00m),
            ("Habichuelas (lb)", 60.00m),
            ("Pollo (lb)", 120.00m),
            ("Huevos (cartón)", 180.00m),
            ("Leche (galón)", 220.00m),
            ("Pan (unidad)", 25.00m),
            ("Aceite (litro)", 150.00m),
            ("Refresco (2L)", 90.00m)
        };

        public Form1()
        {
            InitializeComponent();

            // Aquí conectamos los eventos, sin tocar el diseñador
            this.Load += Form1_Load;
            cboProducto.SelectedIndexChanged += Controles_CambioValor;
            txtCantidad.TextChanged += Controles_CambioValor;
            rbEfectivo.CheckedChanged += Controles_CambioValor;
            rbTarjeta.CheckedChanged += Controles_CambioValor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Textos de las etiquetas (label1 y label2 ya existían vacíos/con texto por defecto)
            label1.Text = "Producto:";
            label2.Text = "Cantidad:";

            // Llenar el ComboBox con los productos y precios
            cboProducto.Items.Clear();
            foreach (var p in productos)
            {
                cboProducto.Items.Add($"{p.Nombre} - RD${p.Precio:0.00}");
            }
            cboProducto.SelectedIndex = 0;

            txtCantidad.Text = "1";
            rbEfectivo.Checked = true;

            CalcularTotal();
        }

        // Un solo método que reacciona a cualquier cambio (producto, cantidad o forma de pago)
        private void Controles_CambioValor(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            if (cboProducto.SelectedIndex == -1) return;

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                lblTotal.Text = "Total: RD$0.00";
                return;
            }

            decimal precio = productos[cboProducto.SelectedIndex].Precio;
            decimal total = precio * cantidad;
            string metodoPago = rbEfectivo.Checked ? "Efectivo" : "Tarjeta";

            lblTotal.Text = $"Total: RD${total:0.00}  ({metodoPago})";
        }

        // Este método ya lo tenía el diseñador conectado a label1, lo dejamos vacío para que no dé error
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}