﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.BaseDatos.Models;

namespace RAD_SII_Actividad_V
{
    public partial class MenuPrin : Form
    {
        public MenuPrin()
        {
            InitializeComponent();
        }

        private void gruposDeDescuentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PeliculasV peliculas = new PeliculasV();
            peliculas.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientesV peliculas = new ClientesV();
            peliculas.Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RentaId renta = new RentaId();
            renta.Show();
        }
    }
}
