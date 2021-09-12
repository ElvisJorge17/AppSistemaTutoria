﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_CambiarContraseña : Form
    {
        public string Usuario = "";
        public string Correo = "";
        public P_CambiarContraseña()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrar_MouseHover(object sender, EventArgs e)
        {
            btnCerrar.Size = new Size(25, 25);
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.Size = new Size(24, 24);
        }

        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            string correo = lblCorreoUnsaac.Text;
            if(correo != "")
            {
                panelVerificacion.Visible = true;
                panelCorreo.Visible = false;
                panelVerificacion.BringToFront();
            }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            panelVerificacion.Visible = false;
            panelCambiarContraseña.Visible = true;
            panelCambiarContraseña.BringToFront();
        }
    }
}
