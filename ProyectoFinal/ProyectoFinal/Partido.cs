using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    /// <summary>
    /// Clase que maneja la lógica de la interfaz para los partidos.
    /// </summary>
    public partial class Partido : Form
    {
        /// <summary>
        /// Tabla hash que almacena los partidos.
        /// </summary>
        private TablaHash tablaHash;
        /// <summary>
        /// Constructor que inicializa el formulario y la tabla de hash con partidos.
        /// </summary>
        /// <param name="tablaHash">Instancia de la tabla hash de partidos.</param>
        public Partido(TablaHash tablaHash)
        {
            InitializeComponent();
            this.tablaHash = tablaHash;
        }
        /// <summary>
        /// Limpia todos los campos del formulario.
        /// </summary>
        private void Limpiar()
        {
            tbxFechaPartido.Text = "";
            txbEstadoPartido.Text = "";
            txbEquipoCasa.Text = "";
            txbEquipoVisita.Text = "";
            txbArbitro.Text = "";
            txbSemana.Text = "";
            txbGolesCasa.Text = "";
            txbGolesVisita.Text = "";
            txbGolesPartido.Text = "";
            txbEstadioPartido.Text = "";
        }
        /// <summary>
        /// Guarda un nuevo partido en la tabla hash y limpia el formulario si es exitoso.
        /// </summary>
        private void btnGuardarPartido_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha = tbxFechaPartido.Text;
                string estado = txbEstadoPartido.Text;
                string equipoCasa = txbEquipoCasa.Text;
                string equipoVisita = txbEquipoVisita.Text;
                string arbitro = txbArbitro.Text;
                int semana = int.Parse(txbSemana.Text);
                int golesCasa = int.Parse(txbGolesCasa.Text);
                int golesVisita = int.Parse(txbGolesVisita.Text);
                int totalGoles = int.Parse(txbGolesPartido.Text);
                string estadio = txbEstadioPartido.Text;

                Partidos nuevoPartido = new Partidos(fecha, estado, equipoCasa, equipoVisita, arbitro, semana, golesCasa, golesVisita, totalGoles, estadio);

                if (tablaHash.Insertar(nuevoPartido))
                {
                    MessageBox.Show("Partido guardado con éxito.");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Error al guardar el partido. Puede que ya exista un partido con esa fecha.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Busca un partido en la tabla hash por fecha y muestra los detalles en el formulario si lo encuentra.
        /// </summary>
        private void btnBuscarPartido_Click(object sender, EventArgs e)
        {
            string fecha = tbxFechaPartido.Text;
            Partidos partidoEncontrado = tablaHash.Consultar(fecha);
            if (partidoEncontrado != null)
            {
                tbxFechaPartido.Text = partidoEncontrado.FechaPartido;
                txbEstadoPartido.Text = partidoEncontrado.EstadoPartido;
                txbEquipoCasa.Text = partidoEncontrado.EquipoCasaPartido;
                txbEquipoVisita.Text = partidoEncontrado.EquipoVisitantePartido;
                txbArbitro.Text = partidoEncontrado.ArbitroPartido;
                txbSemana.Text = partidoEncontrado.NumeroSemanaPartido.ToString();
                txbGolesCasa.Text = partidoEncontrado.GolesCasaPartido.ToString();
                txbGolesVisita.Text = partidoEncontrado.GolesVisitantePartido.ToString();
                txbGolesPartido.Text = partidoEncontrado.TotalGolesPartido.ToString();
                txbEstadioPartido.Text = partidoEncontrado.EstadioPartido;
            }
            else
            {
                MessageBox.Show("Partido no encontrado.");
            }
        }

        /// <summary>
        /// Actualiza la información de un partido en la tabla hash.
        /// </summary>
        private void btnModificarPartido_Click(object sender, EventArgs e)
        {
            string fecha = tbxFechaPartido.Text;
            Partidos partidoActualizado = new Partidos(fecha, txbEstadoPartido.Text, txbEquipoCasa.Text, txbEquipoVisita.Text, txbArbitro.Text, int.Parse(txbSemana.Text), int.Parse(txbGolesCasa.Text), int.Parse(txbGolesVisita.Text), int.Parse(txbGolesPartido.Text), txbEstadioPartido.Text);

            if (tablaHash.Actualizar(partidoActualizado))
            {
                MessageBox.Show("Partido actualizado correctamente.");
            }
            else
            {
                MessageBox.Show("Error al actualizar el partido. Partido no encontrado.");
            }
        }

        /// <summary>
        /// Elimina un partido de la tabla hash por fecha.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string fecha = tbxFechaPartido.Text;
            if (tablaHash.Eliminar(fecha))
            {
                MessageBox.Show("Partido eliminado correctamente.");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al eliminar el partido. Partido no encontrado.");
            }
        }

        /// <summary>
        /// Limpia todos los campos del formulario.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Abre un diálogo para seleccionar un archivo CSV y carga los partidos en la tabla hash.
        /// </summary>
        private void btnSubirArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    int countAdded = 0;

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] data = lines[i].Split(',');

                        if (data.Length >= 9)
                        {
                            string fecha = data[0].Trim();
                            string estado = data[1].Trim();
                            string equipoCasa = data[2].Trim();
                            string equipoVisita = data[3].Trim();
                            string arbitro = data[4].Trim();
                            int semana = int.Parse(data[5].Trim());
                            int golesCasa = int.Parse(data[6].Trim());
                            int golesVisita = int.Parse(data[7].Trim());
                            int totalGoles = int.Parse(data[8].Trim());
                            string estadio = data[9].Trim();

                            Partidos nuevoPartido = new Partidos(fecha, estado, equipoCasa, equipoVisita, arbitro, semana, golesCasa, golesVisita, totalGoles, estadio);

                            if (tablaHash.Insertar(nuevoPartido))
                            {
                                countAdded++;
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Error en la línea {i + 1}: Formato incorrecto.");
                        }
                    }

                    MessageBox.Show($"Se han cargado {countAdded} partidos correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el archivo: " + ex.Message);
                }
            }
        }

    }
}
