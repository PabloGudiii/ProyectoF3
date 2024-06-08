using EstructurasDeDatos.ListaSimple;
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
    /// Gestiona la interfaz y la lógica de los jugadores en el campeonato.
    /// </summary>
    public partial class Jugador : Form
    {
        /// <summary>
        /// Lista enlazada que almacena los jugadores.
        /// </summary>
        private ListaS listaJugadores;
        /// <summary>
        /// Inicializa una nueva instancia de la clase Jugador con una lista existente de jugadores.
        /// </summary>
        /// <param name="listaExistente">Lista enlazada de jugadores existente.</param>
        public Jugador(ListaS listaExistente)
        {
            InitializeComponent();
            this.listaJugadores = listaExistente;
        }
        /// <summary>
        /// Limpia los campos de entrada del formulario.
        /// </summary>
        private void Limpiar()
        {
            tbxNombreJugador.Text = "";
            tbxEdadJugador.Text = "";
            tbxFechaJugador.Text = "";
            tbxLigaJugador.Text = "";
            tbxPosicionJugador.Text = "";
            tbxClubJugador.Text = "";
            tbxNacionalidadJugador.Text = "";
            txbGoles.Text = "";
            txbAsistencias.Text = "";
            txbPenales.Text = "";
            txbTarjetasRojas.Text = "";
            txbTarjetasAmarillas.Text = "";
        }
        /// <summary>
        /// Guarda un nuevo jugador en la lista enlazada a partir de la información proporcionada en el formulario.
        /// </summary>
        private void btnGuardarJugador_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = tbxNombreJugador.Text;
                int edad = int.Parse(tbxEdadJugador.Text);
                string fecha = tbxFechaJugador.Text;
                string liga = tbxLigaJugador.Text;
                string posicion = tbxPosicionJugador.Text;
                string club = tbxClubJugador.Text;
                string nacionalidad = tbxNacionalidadJugador.Text;
                int goles = int.Parse(txbGoles.Text);
                int asistencias = int.Parse(txbAsistencias.Text);
                int penales = int.Parse(txbPenales.Text);
                int tarjetasRojas = int.Parse(txbTarjetasRojas.Text);
                int tarjetasAmarillas = int.Parse(txbTarjetasAmarillas.Text);

                // Crear el objeto jugador
                Jugadores nuevoJugador = new Jugadores(nombre, edad, fecha, liga, posicion, club, nacionalidad, goles, asistencias, penales, tarjetasRojas, tarjetasAmarillas);

                // Insertar en la lista
                listaJugadores.insertLast(nuevoJugador);

                MessageBox.Show("Jugador guardado con éxito.");
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el jugador: " + ex.Message);
            }
        }

        /// <summary>
        /// Busca un jugador por nombre y muestra sus detalles en el formulario si es encontrado.
        /// </summary>
        private void btnBuscarJugador_Click(object sender, EventArgs e)
        {
            string nombre = tbxNombreJugador.Text;
            NodoLista current = listaJugadores.header;
            Jugadores jugadorEncontrado = null;

            while (current != null)
            {
                Jugadores jugador = current.Dato as Jugadores;
                if (jugador != null && jugador.NombreJugador.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    jugadorEncontrado = jugador;
                    break;
                }
                current = current.Link;
            }

            if (jugadorEncontrado != null)
            {
                tbxNombreJugador.Text = jugadorEncontrado.NombreJugador;
                tbxEdadJugador.Text = jugadorEncontrado.EdadJugador.ToString();
                tbxFechaJugador.Text = jugadorEncontrado.FechaJugador;
                tbxLigaJugador.Text = jugadorEncontrado.LigaJugador;
                tbxPosicionJugador.Text = jugadorEncontrado.PosicionJugador;
                tbxClubJugador.Text = jugadorEncontrado.ClubJugador;
                tbxNacionalidadJugador.Text = jugadorEncontrado.NacionalidadJugador;
                txbGoles.Text = jugadorEncontrado.GolesJugador.ToString();
                txbAsistencias.Text = jugadorEncontrado.AsistenciasJugador.ToString();
                txbPenales.Text = jugadorEncontrado.PenalesJugador.ToString();
                txbTarjetasRojas.Text = jugadorEncontrado.TarjetasRojasJugador.ToString();
                txbTarjetasAmarillas.Text = jugadorEncontrado.TarjetasAmarillasJugador.ToString();

                MessageBox.Show("Jugador encontrado.");
            }
            else
            {
                MessageBox.Show("Jugador no encontrado.");
            }
        }

        /// <summary>
        /// Modifica la información de un jugador existente en la lista enlazada.
        /// </summary>
        private void btnModificarJugador_Click(object sender, EventArgs e)
        {
            string nombreOriginal = tbxNombreJugador.Text;
            NodoLista current = listaJugadores.header;
            Jugadores jugadorEncontrado = null;

            while (current != null)
            {
                Jugadores jugador = current.Dato as Jugadores;
                if (jugador != null && jugador.NombreJugador.Equals(nombreOriginal, StringComparison.OrdinalIgnoreCase))
                {
                    jugadorEncontrado = jugador;
                    break;
                }
                current = current.Link;
            }

            if (jugadorEncontrado != null)
            {
                jugadorEncontrado.EdadJugador = int.Parse(tbxEdadJugador.Text);
                jugadorEncontrado.FechaJugador = tbxFechaJugador.Text;
                jugadorEncontrado.LigaJugador = tbxLigaJugador.Text;
                jugadorEncontrado.PosicionJugador = tbxPosicionJugador.Text;
                jugadorEncontrado.ClubJugador = tbxClubJugador.Text;
                jugadorEncontrado.NacionalidadJugador = tbxNacionalidadJugador.Text;
                jugadorEncontrado.GolesJugador = int.Parse(txbGoles.Text);
                jugadorEncontrado.AsistenciasJugador = int.Parse(txbAsistencias.Text);
                jugadorEncontrado.PenalesJugador = int.Parse(txbPenales.Text);
                jugadorEncontrado.TarjetasRojasJugador = int.Parse(txbTarjetasRojas.Text);
                jugadorEncontrado.TarjetasAmarillasJugador = int.Parse(txbTarjetasAmarillas.Text);
                MessageBox.Show("Jugador modificado correctamente.");
            }
            else
            {
                MessageBox.Show("Jugador no encontrado.");
            }
        }

        /// <summary>
        /// Elimina un jugador de la lista enlazada.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string nombre = tbxNombreJugador.Text;
            NodoLista current = listaJugadores.header;
            NodoLista previous = null;

            while (current != null)
            {
                Jugadores jugador = current.Dato as Jugadores;
                if (jugador != null && jugador.NombreJugador.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    if (previous == null)
                    {  // Primer elemento en la lista
                        listaJugadores.header = current.Link;
                    }
                    else
                    {
                        previous.Link = current.Link;
                    }
                    MessageBox.Show("Jugador eliminado con éxito.");
                    Limpiar();
                    return;
                }
                previous = current;
                current = current.Link;
            }

            MessageBox.Show("Jugador no encontrado.");
        }

        /// <summary>
        /// Limpia los campos del formulario.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Carga jugadores desde un archivo CSV y los añade a la lista enlazada.
        /// </summary>
        private void btnSubirArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\"; // Ruta inicial para el diálogo.
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
                            string nombre = data[0].Trim();
                            int edad = int.Parse(data[1].Trim());
                            string fecha = data[2].Trim();
                            string liga = data[3].Trim();
                            string posicion = data[4].Trim();
                            string club = data[5].Trim();
                            string nacionalidad = data[6].Trim();
                            int goles = int.Parse(data[7].Trim());
                            int asistencias = int.Parse(data[8].Trim());
                            int penales = int.Parse(data[9].Trim());
                            int tarjetasRojas = int.Parse(data[10].Trim());
                            int tarjetasAmarillas = int.Parse(data[11].Trim());

                            Jugadores nuevoJugador = new Jugadores(nombre, edad, fecha, liga, posicion, club, nacionalidad, goles, asistencias, penales, tarjetasRojas, tarjetasAmarillas);
                            listaJugadores.insertLast(nuevoJugador);
                            countAdded++;
                        }
                        else
                        {
                            MessageBox.Show($"Error en la línea {i + 1}: Formato incorrecto.");
                        }
                    }

                    MessageBox.Show($"Se han cargado {countAdded} jugadores correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el archivo: " + ex.Message);
                }
            }
        }
    }
}
