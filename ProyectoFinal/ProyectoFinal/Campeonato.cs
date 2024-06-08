using EstructurasDeDatos.Arbol;
using EstructurasDeDatos.ListaSimple;
using System.Text;

namespace ProyectoFinal
{
    /// <summary>
    /// Formulario principal del Campeonato que gestiona equipos, jugadores y partidos.
    /// </summary>
    public partial class Campeonato : Form
    {
        private ArbolAVL arbolEquipos;
        private ListaS listaJugadores;
        private TablaHash tablaPartidos;

        /// <summary>
        /// Constructor principal que inicializa las estructuras de datos y componentes del formulario.
        /// </summary>
        public Campeonato()
        {
            InitializeComponent();
            arbolEquipos = new ArbolAVL();
            listaJugadores = new ListaS();
            tablaPartidos = new TablaHash();
        }

        /// <summary>
        /// Muestra el formulario de gestión de jugadores.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Form formularioJugador = new Jugador(listaJugadores);
            formularioJugador.Show();
        }

        /// <summary>
        /// Muestra el formulario de gestión de equipos.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            Form formularioEquipo = new Equipo(arbolEquipos);
            formularioEquipo.Show();
        }

        private void Campeonato_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Muestra el formulario de gestión de partidos.
        /// </summary>
        private void btnAdministrarPartidos_Click(object sender, EventArgs e)
        {
            Form formularioPartido = new Partido(tablaPartidos);
            formularioPartido.Show();
        }

        /// <summary>
        /// Muestra la clasificación de equipos ordenada según los criterios establecidos.
        /// </summary>
        private void btnRankEquipos_Click(object sender, EventArgs e)
        {
            ListaS equiposOrdenados = ObtenerEquiposOrdenados();
            txbMostrar.Clear();
            StringBuilder sb = new StringBuilder();
            NodoLista current = equiposOrdenados.header;
            while (current != null)
            {
                Equipos equipo = (Equipos)current.Dato;
                sb.AppendLine($"{equipo.AliasEquipo} - Puntos: {equipo.PuntosPartidoEquipo} - Goles: {equipo.TotalGolesEquipo} - Posición: {equipo.PosicionLigaEquipo}");
                current = current.Link;
            }
            txbMostrar.Text = sb.ToString();
        }

        /// <summary>
        /// Ordena los equipos de forma ascendente por sus puntos en el campeonato.
        /// </summary>
        private ListaS ObtenerEquiposOrdenados()
        {
            ListaS listaOrdenada = new ListaS();
            InordenRecursivo(arbolEquipos.raizArbol(), listaOrdenada);
            return listaOrdenada;
        }

        /// <summary>
        /// Recorrido inorden del árbol AVL para recuperar y ordenar los equipos.
        /// </summary>
        private void InordenRecursivo(NodoAvl nodo, ListaS lista)
        {
            if (nodo != null)
            {
                InordenRecursivo((NodoAvl)nodo.subarbolIzdo(), lista);
                InsertSorted(lista, (Equipos)nodo.valorNodo());
                InordenRecursivo((NodoAvl)nodo.subarbolDcho(), lista);
            }
        }

        /// <summary>
        /// Inserta los equipos en la lista de forma ordenada según su puntuación.
        /// </summary>
        private void InsertSorted(ListaS lista, Equipos equipo)
        {
            NodoLista nuevoNodo = new NodoLista(equipo);
            if (lista.header == null || ((Equipos)lista.header.Dato).PuntosPartidoEquipo <= equipo.PuntosPartidoEquipo)
            {
                nuevoNodo.Link = lista.header;
                lista.header = nuevoNodo;
            }
            else
            {
                NodoLista current = lista.header;
                while (current.Link != null && ((Equipos)current.Link.Dato).PuntosPartidoEquipo > equipo.PuntosPartidoEquipo)
                {
                    current = current.Link;
                }
                nuevoNodo.Link = current.Link;
                current.Link = nuevoNodo;
            }
        }

        /// <summary>
        /// Muestra el ranking de partidos agrupados por fecha.
        /// </summary>
        private void btnRankPartidos_Click(object sender, EventArgs e)
        {
            var partidosPorFecha = tablaPartidos.ObtenerPartidosAgrupadosPorFecha();
            StringBuilder sb = new StringBuilder();
            foreach (var fecha in partidosPorFecha.Keys)
            {
                sb.AppendLine($"Fecha: {fecha}");
                foreach (var partido in partidosPorFecha[fecha])
                {
                    sb.AppendLine($"{partido.EquipoCasaPartido} vs {partido.EquipoVisitantePartido} - Goles: {partido.GolesCasaPartido}-{partido.GolesVisitantePartido}");
                }
                sb.AppendLine();
            }

            txbMostrar.Text = sb.ToString();
        }

        /// <summary>
        /// Muestra el ranking de jugadores según goles, asistencias y tarjetas.
        /// </summary>
        private void btnRankJugadores_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Top 10 Jugadores con más Goles:");
            var topGoles = GetTopJugadoresByGoles(10);
            foreach (var jugador in topGoles)
            {
                sb.AppendLine($"{jugador.NombreJugador} - Goles: {jugador.GolesJugador}");
            }

            sb.Append(Environment.NewLine);
            sb.AppendLine("Top 5 Jugadores con más Asistencias:");
            var topAsistencias = GetTopJugadoresByAsistencias(5);
            foreach (var jugador in topAsistencias)
            {
                sb.AppendLine($"{jugador.NombreJugador} - Asistencias: {jugador.AsistenciasJugador}");
            }

            sb.Append(Environment.NewLine);
            sb.AppendLine("Jugadores con Tarjetas Amarillas o Rojas:");
            var jugadoresConTarjetas = GetJugadoresConTarjetas();
            foreach (var jugador in jugadoresConTarjetas)
            {
                sb.AppendLine($"{jugador.NombreJugador} - Amarillas: {jugador.TarjetasAmarillasJugador}, Rojas: {jugador.TarjetasRojasJugador}");
            }

            txbMostrar.Text = sb.ToString();
        }

        /// <summary>
        /// Obtiene la lista de los jugadores con más goles.
        /// </summary>
        private List<Jugadores> GetTopJugadoresByGoles(int count)
        {
            List<Jugadores> sortedList = new List<Jugadores>();
            NodoLista current = listaJugadores.header;
            while (current != null)
            {
                sortedList.Add((Jugadores)current.Dato);
                current = current.Link;
            }
            return sortedList.OrderByDescending(j => j.GolesJugador).Take(count).ToList();
        }

        /// <summary>
        /// Obtiene la lista de los jugadores con más asistencias.
        /// </summary>
        private List<Jugadores> GetTopJugadoresByAsistencias(int count)
        {
            List<Jugadores> sortedList = new List<Jugadores>();
            NodoLista current = listaJugadores.header;
            while (current != null)
            {
                sortedList.Add((Jugadores)current.Dato);
                current = current.Link;
            }
            return sortedList.OrderByDescending(j => j.AsistenciasJugador).Take(count).ToList();
        }

        /// <summary>
        /// Obtiene la lista de jugadores que tienen al menos una tarjeta amarilla o roja.
        /// </summary>
        private List<Jugadores> GetJugadoresConTarjetas()
        {
            List<Jugadores> filteredList = new List<Jugadores>();
            NodoLista current = listaJugadores.header;
            while (current != null)
            {
                Jugadores jugador = (Jugadores)current.Dato;
                if (jugador.TarjetasAmarillasJugador > 0 || jugador.TarjetasRojasJugador > 0)
                {
                    filteredList.Add(jugador);
                }
                current = current.Link;
            }
            return filteredList;
        }

        /// <summary>
        /// Método para habilitar el desplazamiento vertical en el control de texto donde se muestra el ranking.
        /// </summary>
        private void txbMostrar_TextChanged(object sender, EventArgs e)
        {
            txbMostrar.Multiline = true;

            txbMostrar.ScrollBars = ScrollBars.Vertical;

            txbMostrar.WordWrap = false;

        }
    }
}