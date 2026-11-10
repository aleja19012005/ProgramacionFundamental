using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaLegadoApp.Models;
using SistemaLegadoApp.Services;
using SistemaLegadoApp.Exceptions;

namespace SistemaLegadoApp.Views
{
    public class RegistroForm : Form
    {
        private TextBox txtCodigo;
        private TextBox txtDescripcion;
        private TextBox txtValor;
        private Button btnGuardar;
        private FileHandler _fileHandler = new FileHandler();

        public RegistroForm()
        {
            Text = "Pantalla 2: Registro Seguro";
            Size = new Size(360, 310);
            StartPosition = FormStartPosition.CenterParent;

            Label lblCod = new Label { Text = "Código Legado:", Location = new Point(25, 25), AutoSize = true };
            txtCodigo = new TextBox { Location = new Point(135, 22), Width = 175 };

            Label lblDesc = new Label { Text = "Descripción:", Location = new Point(25, 70), AutoSize = true };
            txtDescripcion = new TextBox { Location = new Point(135, 67), Width = 175 };

            Label lblVal = new Label { Text = "Monto / Valor:", Location = new Point(25, 115), AutoSize = true };
            txtValor = new TextBox { Location = new Point(135, 112), Width = 175 };

            btnGuardar = new Button { Text = "Validar y Guardar", Location = new Point(100, 175), Size = new Size(150, 40) };
            btnGuardar.Click += BtnGuardar_Click; // Validación integrada en evento de la UI[cite: 4]

            Controls.Add(lblCod); Controls.Add(txtCodigo);
            Controls.Add(lblDesc); Controls.Add(txtDescripcion);
            Controls.Add(lblVal); Controls.Add(txtValor);
            Controls.Add(btnGuardar);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación estricta usando tu clase SecurityValidator
                if (!SecurityValidator.ValidarCodigo(txtCodigo.Text))
                {
                    MessageBox.Show("El código debe ser alfanumérico (3 a 20 caracteres).", "Validación Fallida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal valor = SecurityValidator.ValidarMonto(txtValor.Text);

                LegacyRecord record = new LegacyRecord
                {
                    Id = new Random().Next(1, 1000),
                    CodigoLegacy = txtCodigo.Text,
                    Descripcion = txtDescripcion.Text,
                    Valor = valor
                };

                // Persistencia de datos mediante manejo de archivos desde la UI[cite: 4]
                _fileHandler.GuardarDato($"{record.CodigoLegacy} | {record.Descripcion} | ${record.Valor} | {record.FechaCreacion}");

                MessageBox.Show("¡Registro validado y guardado correctamente en el archivo!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (LegacyException ex)
            {
                MessageBox.Show(ex.Message, "Error en Persistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}