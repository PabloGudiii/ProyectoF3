using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    /// <summary>
    /// Representa un jugador dentro de un contexto de campeonato deportivo,
    /// almacenando toda la información relevante sobre su desempeño y detalles personales.
    /// </summary>
    public class Jugadores
    {
        public String NombreJugador { get; set; }
        public int EdadJugador { get; set; }
        public String FechaJugador { get; set; }
        public String LigaJugador { get; set; }
        public String PosicionJugador { get; set; }
        public String ClubJugador { get; set; }
        public String NacionalidadJugador { get; set; }
        public int GolesJugador { get; set; }
        public int AsistenciasJugador { get; set; }
        public int PenalesJugador { get; set; }
        public int TarjetasRojasJugador { get; set; }
        public int TarjetasAmarillasJugador { get; set; }

        /// <summary>
        /// Constructor para crear un objeto Jugadores con toda la información necesaria.
        /// </summary>
        /// <param name="nombrejugador">Nombre completo del jugador.</param>
        /// <param name="edadjugador">Edad del jugador.</param>
        /// <param name="fechajugador">Fecha de nacimiento del jugador.</param>
        /// <param name="ligajugador">Liga en la que juega actualmente.</param>
        /// <param name="posicionjugador">Posición deportiva en el campo.</param>
        /// <param name="clubjugador">Club actual del jugador.</param>
        /// <param name="nacionalidadjugador">Nacionalidad del jugador.</param>
        /// <param name="golesjugador">Total de goles marcados en la temporada actual.</param>
        /// <param name="asistenciasjugador">Total de asistencias realizadas en la temporada actual.</param>
        /// <param name="penalesjugador">Total de penales ejecutados por el jugador.</param>
        /// <param name="tarjetasrojasjugador">Total de tarjetas rojas recibidas.</param>
        /// <param name="tarjetasamarillasjugador">Total de tarjetas amarillas recibidas.</param>
        public Jugadores(String nombrejugador, int edadjugador, String fechajugador, String ligajugador, String posicionjugador, String clubjugador, String nacionalidadjugador, int golesjugador, int asistenciasjugador, int penalesjugador, int tarjetasrojasjugador, int tarjetasamarillasjugador)
        {
            NombreJugador = nombrejugador;
            EdadJugador = edadjugador;
            FechaJugador = fechajugador;
            LigaJugador = ligajugador;
            PosicionJugador = posicionjugador;
            ClubJugador = clubjugador;
            NacionalidadJugador = nacionalidadjugador;
            GolesJugador = golesjugador;
            AsistenciasJugador = asistenciasjugador;
            PenalesJugador = penalesjugador;
            TarjetasRojasJugador = tarjetasrojasjugador;
            TarjetasAmarillasJugador = tarjetasamarillasjugador;
        }
    }
}
