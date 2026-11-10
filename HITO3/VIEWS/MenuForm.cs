using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaLegadoApp.Views
{
    public class MenuForm : Form
    {
        private Button btnRegistrar;
        private Button btnConsultar;
        private Button btnSalir;
        private Label lblTitulo;

        public MenuForm()
        {
            Text = "Sistema Legado - Menú Principal";
            Size = new Size(420, 320);
            StartPosition = FormStartPosition.CenterScreen;

            lblTitulo = new Label { 
                Text = "SISTEMA DE GESTIÓN - HITO 3", 
                Font = new Font("Arial", 11, FontStyle.Bold), 
                Location = new Point(80, 25), 
                AutoSize = true 
            };
            
            btnRegistrar = new Button { 
                Text = "1. Ir a Registro de Datos", 
                Location = new Point(90, 80), 
                Size = new Size(220, 45) 
            };
            btnRegistrar.Click += (s, e) => { new RegistroForm().ShowDialog(); };

            btnConsultar = new Button { 
                Text = "2. Consultar Registros Guardados", 
                Location = new Point(90, 140), 
                Size = new Size(220, 45) 
            };
            btnConsultar.Click += (s, e) => { new ConsultaForm().ShowDialog(); };

            btnSalir = new Button { 
                Text = "Salir del Sistema", 
                Location = new Point(140, 210), 
                Size = new Size(120, 35) 
            };
            btnSalir.Click += (s, e) => Application.Exit();

            Controls.Add(lblTitulo);
            Controls.Add(btnRegistrar);
            Controls.Add(btnConsultar);
            Controls.Add(btnSalir);
        }
    }
}