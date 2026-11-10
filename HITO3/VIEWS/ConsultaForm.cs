using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SistemaLegadoApp.Views
{
    public class ConsultaForm : Form
    {
        private ListBox lstRegistros;
        private Button btnCargar;

        public ConsultaForm()
        {
            Text = "Pantalla 3: Consulta de Registros";
            Size = new Size(460, 360);
            StartPosition = FormStartPosition.CenterParent;

            lstRegistros = new ListBox { Location = new Point(20, 20), Size = new Size(405, 210) };
            
            btnCargar = new Button { Text = "Cargar Datos del Archivo", Location = new Point(140, 245), Size = new Size(180, 40) };
            btnCargar.Click += (s, e) => CargarArchivo();

            Controls.Add(lstRegistros);
            Controls.Add(btnCargar);
        }

        private void CargarArchivo()
        {
            lstRegistros.Items.Clear();
            string ruta = "datos_legados.txt";

            if (File.Exists(ruta))
            {
                string[] lineas = File.ReadAllLines(ruta);
                foreach (string linea in lineas)
                {
                    lstRegistros.Items.Add(linea);
                }
            }
            else
            {
                MessageBox.Show("Aún no existen datos guardados en el archivo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}