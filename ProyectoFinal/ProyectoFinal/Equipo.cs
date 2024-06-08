using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EstructurasDeDatos.Arbol;

namespace ProyectoFinal
{
    // <summary>
    /// Formulario para la gestión de equipos deportivos usando un árbol AVL para almacenar los datos.
    /// </summary>
    public partial class Equipo : Form
    {
        private ArbolAVL arbolEquipos;
        /// <summary>
        /// Constructor del formulario que inicializa el árbol AVL con el arbol proporcionado.
        /// </summary>
        /// <param name="arbol">Instancia de un árbol AVL para gestionar equipos.</param>
        public Equipo(ArbolAVL arbol)
        {
            InitializeComponent();
            this.arbolEquipos = arbol;
        }
        /// <summary>
        /// Limpia los campos del formulario para la entrada de nuevos datos.
        /// </summary>
        private void Limpiar()
        {
            tbxNombreEquipo.Text = "";
            tbxAliasEquipo.Text = "";
            tbxPaisEquipo.Text = "";
            tbxPartidosEquipo.Text = "";
            tbxPartidosGanados.Text = "";
            tbxPuntosPartido.Text = "";
            tbxPosicionLiga.Text = "";
            txbTotalGoles.Text = "";
        }

        /// <summary>
        /// Guarda un nuevo equipo en el árbol AVL.
        /// </summary>
        private void btnGuardarEquipo_Click(object sender, EventArgs e)
        {
            string nombre = tbxNombreEquipo.Text;
            string alias = tbxAliasEquipo.Text;
            string pais = tbxPaisEquipo.Text;
            int partidosJugados = int.Parse(tbxPartidosEquipo.Text);
            int partidosGanados = int.Parse(tbxPartidosGanados.Text);
            double puntos = double.Parse(tbxPuntosPartido.Text);
            int posicion = int.Parse(tbxPosicionLiga.Text);
            int goles = int.Parse(txbTotalGoles.Text);

            Equipos equipo = new Equipos(nombre, alias, pais, partidosJugados, partidosGanados, puntos, posicion, goles);
            try
            {
                arbolEquipos.insertar(equipo);
                MessageBox.Show("Equipo guardado con éxito.");
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Limpiar();
            }
        }
        /// <summary>
        /// Busca un equipo en el árbol AVL y muestra sus datos en el formulario.
        /// </summary>
        private void btnBuscarEquipo_Click(object sender, EventArgs e)
        {
            string nombre = tbxNombreEquipo.Text;
            Equipos equipoBuscado = new Equipos(nombre, "", "", 0, 0, 0, 0, 0);

            NodoAvl nodoEncontradoAvl = arbolEquipos.buscarIterativo(equipoBuscado);
            if (nodoEncontradoAvl != null)
            {
                Equipos equipoEncontrado = (Equipos)nodoEncontradoAvl.valorNodo();
                tbxNombreEquipo.Text = equipoEncontrado.NombreEquipo;
                tbxAliasEquipo.Text = equipoEncontrado.AliasEquipo;
                tbxPaisEquipo.Text = equipoEncontrado.PaisEquipo;
                tbxPartidosEquipo.Text = equipoEncontrado.PartidosJugadosEquipo.ToString();
                tbxPartidosGanados.Text = equipoEncontrado.PartidosGanadosEquipo.ToString();
                tbxPuntosPartido.Text = equipoEncontrado.PuntosPartidoEquipo.ToString();
                tbxPosicionLiga.Text = equipoEncontrado.PosicionLigaEquipo.ToString();
                txbTotalGoles.Text = equipoEncontrado.TotalGolesEquipo.ToString();
                MessageBox.Show("Equipo encontrado: " + equipoEncontrado.NombreEquipo);
            }
            else
            {
                MessageBox.Show("Equipo no encontrado.");
            }
        }
        /// <summary>
        /// Modifica los datos de un equipo existente en el árbol AVL.
        /// </summary>
        private void btnModificarEquipo_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreOriginal = tbxNombreEquipo.Text;
                Equipos equipoOriginal = new Equipos(nombreOriginal, "", "", 0, 0, 0.0, 0, 0);

                NodoAvl nodoOriginal = arbolEquipos.buscarIterativo(equipoOriginal);
                if (nodoOriginal != null && nodoOriginal.valorNodo() is Equipos)
                {
                    Equipos equipoEncontrado = (Equipos)nodoOriginal.valorNodo();

                    string nuevoNombre = tbxNombreEquipo.Text;
                    string nuevoAlias = tbxAliasEquipo.Text;
                    string nuevoPais = tbxPaisEquipo.Text;
                    int nuevosPartidosJugados = int.Parse(tbxPartidosEquipo.Text);
                    int nuevosPartidosGanados = int.Parse(tbxPartidosGanados.Text);
                    double nuevosPuntos = double.Parse(tbxPuntosPartido.Text);
                    int nuevaPosicion = int.Parse(tbxPosicionLiga.Text);
                    int nuevosGoles = int.Parse(txbTotalGoles.Text);

                    Equipos equipoModificado = new Equipos(nuevoNombre, nuevoAlias, nuevoPais, nuevosPartidosJugados, nuevosPartidosGanados, nuevosPuntos, nuevaPosicion, nuevosGoles);

                    arbolEquipos.eliminar(equipoEncontrado);
                    arbolEquipos.insertar(equipoModificado);

                    MessageBox.Show("Equipo modificado correctamente");
                }
                else
                {
                    MessageBox.Show("Equipo no encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Elimina un equipo del árbol AVL.
        /// </summary>
        private void btnEliminarEquipo_Click(object sender, EventArgs e)
        {
            string nombreEquipo = tbxNombreEquipo.Text;

            if (string.IsNullOrWhiteSpace(nombreEquipo))
            {
                MessageBox.Show("Por favor, ingrese el nombre del equipo a eliminar.");
                return;
            }

            Equipos equipoAEliminar = new Equipos(nombreEquipo, "", "", 0, 0, 0, 0, 0);

            try
            {
                arbolEquipos.eliminar(equipoAEliminar);
                MessageBox.Show("Equipo eliminado con éxito.");

                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el equipo: " + ex.Message);
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
        /// Carga datos de equipos desde un archivo CSV y los inserta en el árbol AVL.
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
                    StringBuilder fileContent = new StringBuilder();

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string line = lines[i];
                        string[] data = line.Split(',');

                        if (data.Length >= 8)
                        {
                            string nombre = data[0].Trim();
                            string alias = data[1].Trim();
                            string pais = data[2].Trim();
                            int partidosJugados = int.Parse(data[3].Trim());
                            int partidosGanados = int.Parse(data[4].Trim());
                            double puntos = double.Parse(data[5].Trim());
                            int posicion = int.Parse(data[6].Trim());
                            int goles = int.Parse(data[7].Trim());

                            Equipos equipo = new Equipos(nombre, alias, pais, partidosJugados, partidosGanados, puntos, posicion, goles);
                            arbolEquipos.insertar(equipo);

                            fileContent.AppendLine($"Nombre: {nombre}, Alias: {alias}, País: {pais}, Partidos Jugados: {partidosJugados}, Partidos Ganados: {partidosGanados}, Puntos: {puntos}, Posición: {posicion}, Goles: {goles}");
                        }
                        else
                        {
                            MessageBox.Show("El formato del archivo no es válido. Asegúrate de que cada línea tenga al menos 8 campos separados por comas.");
                        }
                    }

                    MessageBox.Show("Archivo subido correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al cargar los datos: " + ex.Message);
                }
            }
        }
    }
}
