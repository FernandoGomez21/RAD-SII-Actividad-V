using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.BaseDatos.Models;
using Negocio;

namespace RAD_SII_Actividad_V
{
    public partial class PeliculasV : Form
    {
        private NPeliculas nPeliculas;
        public PeliculasV()
        {
            InitializeComponent();
            nPeliculas = new NPeliculas();
        }
        private void PeliculasV_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            DGVDatos.DataSource = nPeliculas.TodasLasPeliculas();
        }

        private void LimpiarDatos()
        {
            TxtPeliculaId.Text = "";
            TxtNombre.Text = "";
            TxtGenero.Text = "";
            TxtAutores.Text = "";
            TxtExistencia.Text = "";
            TxtPrecio.Text = "";
            CHKActivo.Checked = false;
            errorProvider1.Clear();
        }

        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKActivos.Checked == true)
            {
                DGVDatos.DataSource = nPeliculas.CategoriasActivas();
            }
            else
            {
                cargarDatos();
            }
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
            if (string.IsNullOrEmpty(TxtGenero.Text.ToString()) || string.IsNullOrWhiteSpace(TxtGenero.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(TxtGenero, "Debe ingresar el Genero del cliente");
                return FormularioValido;
            }
            if (string.IsNullOrEmpty(TxtAutores.Text.ToString()) || string.IsNullOrWhiteSpace(TxtAutores.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(TxtAutores, "Debe ingresar el Autor del cliente");
                return FormularioValido;
            }
            if (string.IsNullOrEmpty(TxtExistencia.Text.ToString()) || string.IsNullOrWhiteSpace(TxtExistencia.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(TxtExistencia, "Debe ingresar la Existencia del cliente");
                return FormularioValido;
            }
            if (string.IsNullOrEmpty(TxtPrecio.Text.ToString()) || string.IsNullOrWhiteSpace(TxtPrecio.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(TxtPrecio, "Debe ingresar el Precio del cliente");
                return FormularioValido;
            }
            return FormularioValido;
        }
        private void dgCategorias_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtPeliculaId.Text = DGVDatos.CurrentRow.Cells["PeliculasId"].Value.ToString();
            TxtNombre.Text = DGVDatos.CurrentRow.Cells["Nombre"].Value.ToString();
            TxtGenero.Text = DGVDatos.CurrentRow.Cells["Genero"].Value.ToString();
            TxtAutores.Text = DGVDatos.CurrentRow.Cells["Autores"].Value.ToString();
            TxtExistencia.Text = DGVDatos.CurrentRow.Cells["Existencia"].Value.ToString();
            TxtPrecio.Text = DGVDatos.CurrentRow.Cells["PrecioRenta"].Value.ToString();
            CHKActivo.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Estado"].Value.ToString());
            btnEliminar.Enabled = false;
        }

        private void dgCategorias_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtPeliculaId.Text = DGVDatos.CurrentRow.Cells["PeliculasId"].Value.ToString();
            TxtNombre.Text = DGVDatos.CurrentRow.Cells["Nombre"].Value.ToString();
            TxtGenero.Text = DGVDatos.CurrentRow.Cells["Genero"].Value.ToString();
            TxtAutores.Text = DGVDatos.CurrentRow.Cells["Autores"].Value.ToString();
            TxtExistencia.Text = DGVDatos.CurrentRow.Cells["Existencia"].Value.ToString();
            TxtPrecio.Text = DGVDatos.CurrentRow.Cells["PrecioRenta"].Value.ToString();
            CHKActivo.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Estado"].Value.ToString());

            btnEliminar.Enabled = true;
            btnEliminar.BackColor = Color.Red;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Peliculas Cliente = new Peliculas()
                {
                    Nombre = TxtNombre.Text.ToString(),
                    Genero = TxtGenero.Text.ToString(),
                    Autores = TxtAutores.Text.ToString(),
                    Existencia = int.Parse(TxtExistencia.Text.ToString()),
                    PrecioRenta = decimal.Parse(TxtPrecio.Text.ToString()),
                    Estado = CHKActivo.Checked
                };
                if (!string.IsNullOrEmpty(TxtPeliculaId.Text) || !string.IsNullOrWhiteSpace(TxtPeliculaId.Text))
                {
                    if (int.Parse(TxtPeliculaId.Text.ToString()) != 0)
                    {
                        Cliente.PeliculasId = int.Parse(TxtPeliculaId.Text.ToString());
                    }
                }
                nPeliculas.Agregarpelicula(Cliente);
                LimpiarDatos();
                cargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtPeliculaId.Text.ToString()) ||
              !string.IsNullOrWhiteSpace(TxtPeliculaId.Text.ToString()))
            {
                if (int.Parse(TxtPeliculaId.Text.ToString()) != 0)
                {
                    var clienteId = int.Parse(TxtPeliculaId.Text.ToString());
                    nPeliculas.EliminarPeliculas(clienteId);
                    cargarDatos();
                }
            }
        }
    }
}
