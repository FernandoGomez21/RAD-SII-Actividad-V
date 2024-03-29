using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.BaseDatos.Models;
using Negocio;

namespace RAD_SII_Actividad_V
{
    public partial class RentaId : Form
    {
        private NRenta nRenta;
        private NClientes nClientes;
        private NPeliculas nPeliculas;
        public RentaId()
        {
            InitializeComponent();
            nRenta = new NRenta();
            nClientes = new NClientes();
            nPeliculas = new NPeliculas();
        }

        private void RentaId_Load(object sender, EventArgs e)
        {
            cargarDatos();
            CargarCombos();
        }
        private void cargarDatos()
        {
            DGVDatos.DataSource = nRenta.TodasRentas();
        }

        private void LimpiarDatos()
        {
            TxtRentaId.Text = "";
            CBXClientesId.DataSource = "";
            CBXPeliculasId.DataSource = "";
            DTPFechaRetorno.Value = DateTime.Now;
            TxtCantidad.Text = "";
            CBXPrecio.Text = "";
            CHKActivo.Checked = false;
            errorProvider1.Clear();
        }

        private void CHKActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKActivos.Checked == true)
            {
                DGVDatos.DataSource = nRenta.RentasActivas();
            }
            else
            {
                cargarDatos();
            }
        }
        private bool ValidarDatos()
        {
            var FormularioValido = true;
            if (string.IsNullOrEmpty(TxtCantidad.Text.ToString()) || string.IsNullOrWhiteSpace(TxtCantidad.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(TxtCantidad, "Debe ingresar la cantidad de la renta");
                return FormularioValido;
            }
            if (string.IsNullOrEmpty(CBXPrecio.Text.ToString()) || string.IsNullOrWhiteSpace(CBXPrecio.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(CBXPrecio, "Debe ingresar el Precio de la renta");
                return FormularioValido;
            }
            return FormularioValido;
        }

        private void DGVDatos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtRentaId.Text = DGVDatos.CurrentRow.Cells["RentaId"].Value.ToString();
            CBXClientesId.Text = DGVDatos.CurrentRow.Cells["clienteId"].Value.ToString();
            CBXPeliculasId.Text = DGVDatos.CurrentRow.Cells["PeliculasId"].Value.ToString();
            DTPFechaRetorno.Text = DGVDatos.CurrentRow.Cells["FechaRetorno"].Value.ToString();
            TxtCantidad.Text = DGVDatos.CurrentRow.Cells["Cantidad"].Value.ToString();
            CBXPrecio.Text = DGVDatos.CurrentRow.Cells["PrecioRenta"].Value.ToString();
            CHKActivo.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Activo"].Value.ToString());

            btnEliminar.Enabled = false;
        }

        private void DGVDatos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtRentaId.Text = DGVDatos.CurrentRow.Cells["RentaId"].Value.ToString();
            CBXClientesId.Text = DGVDatos.CurrentRow.Cells["clienteId"].Value.ToString();
            CBXPeliculasId.Text = DGVDatos.CurrentRow.Cells["PeliculasId"].Value.ToString();
            DTPFechaRetorno.Text = DGVDatos.CurrentRow.Cells["FechaRetorno"].Value.ToString();
            TxtCantidad.Text = DGVDatos.CurrentRow.Cells["Cantidad"].Value.ToString();
            CBXPrecio.Text = DGVDatos.CurrentRow.Cells["PrecioRenta"].Value.ToString();
            CHKActivo.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Activo"].Value.ToString());

            btnEliminar.Enabled = true;
            btnEliminar.BackColor = Color.Red;
        }
        private void CargarCombos()
        {

            CBXPeliculasId.DataSource = nPeliculas.CargaCombo();
            CBXPeliculasId.DropDownStyle = ComboBoxStyle.DropDownList; //Evitamos que se cambien los que ya estan
            CBXPeliculasId.ValueMember = "Valor";
            CBXPeliculasId.DisplayMember = "Nombres";

            

            CBXClientesId.DataSource = nClientes.CargaCombo();
            CBXClientesId.ValueMember = "Valor";
            CBXClientesId.DisplayMember = "Nombre";

        }
        private void BtnAgregar_Click(object sender, EventArgs e)
        {

            if (ValidarDatos())
            {
                Renta Cliente = new Renta()
                {
                    RentaId = int.Parse(TxtRentaId.Text.ToString()),
                    clienteId = int.Parse(CBXClientesId.Text.ToString()),
                    PeliculasId = int.Parse(CBXPeliculasId.Text.ToString()),
                    FechaRenta = DateTime.Now,
                    FechaRetorno =DTPFechaRetorno.Value,
                    Cantidad = int.Parse(TxtCantidad.Text.ToString()),
                    PrecioRenta = decimal.Parse(CBXPrecio.Text.ToString()),
                    Activo = CHKActivo.Checked
                };
                if (!string.IsNullOrEmpty(TxtRentaId.Text) || !string.IsNullOrWhiteSpace(TxtRentaId.Text))
                {
                    if (int.Parse(TxtRentaId.Text.ToString()) != 0)
                    {

                        if (DTPFechaRetorno.Value >DateTime.Now)
                        {
                            CHKActivo.Checked = false;
                            Cliente.RentaId = int.Parse(TxtRentaId.Text.ToString());
                        }
                        Cliente.RentaId = int.Parse(TxtRentaId.Text.ToString());


                    }
                }
                nRenta.AgregarRenta(Cliente);
                LimpiarDatos();
                cargarDatos();
            }
        }
    }
 }
    