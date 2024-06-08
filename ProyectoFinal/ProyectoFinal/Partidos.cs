using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    /// <summary>
    /// Representa un partido de fútbol, almacenando información detallada sobre los equipos, el marcador, y otros detalles relevantes del evento.
    /// </summary>
    public class Partidos
    {
        public String FechaPartido { get; set; }
        public String EstadoPartido { get; set; }
        public String EquipoCasaPartido { get; set; }
        public String EquipoVisitantePartido { get; set; }
        public String ArbitroPartido { get; set; }
        public int NumeroSemanaPartido { get; set; }
        public int GolesCasaPartido { get; set; }
        public int GolesVisitantePartido { get; set; }
        public int TotalGolesPartido { get; set; }
        public String EstadioPartido { get; set; }

        /// <summary>
        /// Constructor para crear un objeto Partidos con toda la información necesaria.
        /// </summary>
        /// <param name="fechaPartido">Fecha en la que se juega el partido.</param>
        /// <param name="estadoPartido">Estado del partido (e.g., programado, en curso, finalizado).</param>
        /// <param name="equipoCasaPartido">Nombre del equipo que juega en casa.</param>
        /// <param name="equipoVisitantePartido">Nombre del equipo visitante.</param>
        /// <param name="arbitroPartido">Nombre del árbitro del partido.</param>
        /// <param name="numeroSemanaPartido">Número de la semana del campeonato en la que se juega el partido.</param>
        /// <param name="golesCasaPartido">Goles marcados por el equipo de casa.</param>
        /// <param name="golesVisitantePartido">Goles marcados por el equipo visitante.</param>
        /// <param name="totalGolesPartido">Total de goles marcados en el partido.</param>
        /// <param name="estadioPartido">Nombre del estadio donde se juega el partido.</param>
        public Partidos(String fechaPartido, String estadoPartido, string equipoCasaPartido, String equipoVisitantePartido, 
            String arbitroPartido, int numeroSemanaPartido, int golesCasaPartido, int golesVisitantePartido,
            int totalGolesPartido, String estadioPartido)
        {
            FechaPartido = fechaPartido;
            EstadoPartido = estadoPartido;
            EquipoCasaPartido = equipoCasaPartido;
            EquipoVisitantePartido = equipoVisitantePartido;
            ArbitroPartido = arbitroPartido;
            NumeroSemanaPartido = numeroSemanaPartido;
            GolesCasaPartido = golesCasaPartido;
            GolesVisitantePartido = golesVisitantePartido;
            TotalGolesPartido = totalGolesPartido;
            EstadioPartido = estadioPartido;
        }
    }
}
