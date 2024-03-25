using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Datos.BaseDatos.Models;
using Negocio;

namespace RAD_SII_Actividad_V
{
    public partial class ClientesV : Form
    {
        private NClientes nclientes;
        public ClientesV()
        {
            InitializeComponent();
            nclientes = new NClientes();
        }

        private void ClientesV_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            DGVDatos.DataSource = nclientes.TodaslosClientes();
        }

        private void LimpiarDatos()
        {
            TxtClienteId.Text = "";
            TxtNombre.Text = "";
            TxtApellido.Text = "";
            CHKActivo.Checked = false;
            errorProvider1.Clear();
        }

        private bool ValidarDatos()
        {
            var FormularioValido = true;
            if (string.IsNullOrEmpty(TxtNombre.Text.ToString()) || string.IsNullOrWhiteSpace(TxtNombre.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(TxtNombre, "Debe ingresar el Nombre de cliente");
                return FormularioValido;
            }
            if (string.IsNullOrEmpty(TxtApellido.Text.ToString()) || string.IsNullOrWhiteSpace(TxtApellido.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(TxtApellido, "Debe ingresar el Apellido del cliente");
                return FormularioValido;
            }
            return FormularioValido;
        }

        private void CHKActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKActivos.Checked == true)
            {
                DGVDatos.DataSource = nclientes.ClientesActivos();
            }
            else
            {
                cargarDatos();
            }
        }

        private void DGVDatos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtClienteId.Text = DGVDatos.CurrentRow.Cells["clienteId"].Value.ToString();
            TxtNombre.Text = DGVDatos.CurrentRow.Cells["Nombres"].Value.ToString();
            TxtApellido.Text = DGVDatos.CurrentRow.Cells["Apellidos"].Value.ToString();
            CHKActivo.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Estado"].Value.ToString());
            btnEliminar.Enabled = false;
        }

        private void DGVDatos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtClienteId.Text = DGVDatos.CurrentRow.Cells["clienteId"].Value.ToString();
            TxtNombre.Text = DGVDatos.CurrentRow.Cells["Nombres"].Value.ToString();
            TxtApellido.Text = DGVDatos.CurrentRow.Cells["Apellidos"].Value.ToString();
            CHKActivo.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Estado"].Value.ToString());
            btnEliminar.Enabled = true;
            btnEliminar.BackColor = Color.Red;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Clientes Cliente = new Clientes()
                {
                    Nombres = TxtNombre.Text.ToString(),
                    Apellidos = TxtApellido.Text.ToString(),
                    FechaIngreso = DateTime.Now,
                    Estado = CHKActivo.Checked
                };
                if (!string.IsNullOrEmpty(TxtClienteId.Text) || !string.IsNullOrWhiteSpace(TxtClienteId.Text))
                {
                    if (int.Parse(TxtClienteId.Text.ToString()) != 0)
                    {
                        Cliente.clienteId = int.Parse(TxtClienteId.Text.ToString());
                    }
                }
                nclientes.AgregarClienets(Cliente);
                LimpiarDatos();
                cargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtClienteId.Text.ToString()) ||
           !string.IsNullOrWhiteSpace(TxtClienteId.Text.ToString()))
            {
                if (int.Parse(TxtClienteId.Text.ToString()) != 0)
                {
                    var clienteId = int.Parse(TxtClienteId.Text.ToString());
                    nclientes.EliminarClientes(clienteId);
                    cargarDatos();
                }
            }
        }
    }
}
