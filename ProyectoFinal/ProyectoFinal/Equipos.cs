using EstructurasDeDatos.Arbol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstructurasDeDatos.Arbol;

namespace ProyectoFinal
{
    /// <summary>
    /// Representa un equipo en el contexto de un campeonato, manejando información relevante
    /// como nombre, país, estadísticas de juegos y goles.
    /// </summary>
    public class Equipos : Comparador
    {
        public String NombreEquipo { get; set; }
        public String AliasEquipo { get; set; }
        public String PaisEquipo { get; set; }
        public int PartidosJugadosEquipo { get; set; }
        public int PartidosGanadosEquipo { get; set; }
        public double PuntosPartidoEquipo { get; set; }
        public int PosicionLigaEquipo { get; set; }
        public int TotalGolesEquipo { get; set; }

        /// <summary>
        /// Constructor de la clase Equipos.
        /// </summary>
        /// <param name="nombreequipo">Nombre del equipo.</param>
        /// <param name="aliasequipo">Alias del equipo.</param>
        /// <param name="paisequipo">País de origen del equipo.</param>
        /// <param name="partidosjugadosequipo">Cantidad de partidos jugados.</param>
        /// <param name="partidosganadosequipo">Cantidad de partidos ganados.</param>
        /// <param name="puntospartidoequipo">Puntos acumulados en el campeonato.</param>
        /// <param name="posicionligaequipo">Posición en la liga.</param>
        /// <param name="totalgolesequipo">Total de goles marcados en el campeonato.</param>
        public Equipos(String nombreequipo, String aliasequipo, String paisequipo, int partidosjugadosequipo, int partidosganadosequipo, double puntospartidoequipo, int posicionligaequipo, int totalgolesequipo)
        {
            NombreEquipo = nombreequipo;
            AliasEquipo = aliasequipo;
            PaisEquipo = paisequipo;
            PartidosJugadosEquipo = partidosjugadosequipo;
            PartidosGanadosEquipo = partidosganadosequipo;
            PuntosPartidoEquipo = puntospartidoequipo;
            PosicionLigaEquipo = posicionligaequipo;
            TotalGolesEquipo = totalgolesequipo;
        }

        bool Comparador.igualQue(Object op2)
        {
            Equipos p2 = (Equipos)op2;
            return NombreEquipo == p2.NombreEquipo;
        }

        bool Comparador.menorQue(Object op2)
        {
            Equipos p2 = (Equipos)op2;
            if (NombreEquipo.CompareTo(p2.NombreEquipo) < 0)
                return true;
            else
                return false;
            ///Para int usar este:
            ///return NombreProyecto < p2.NombreProyecto;
        }

        bool Comparador.menorIgualQue(Object op2)
        {
            Equipos p2 = (Equipos)op2;
            if (NombreEquipo.CompareTo(p2.NombreEquipo) <= 0)
                return true;
            else
                return false;
        }

        bool Comparador.mayorQue(Object op2)
        {
            Equipos p2 = (Equipos)op2;
            if (NombreEquipo.CompareTo(p2.NombreEquipo) > 0)
                return true;
            else
                return false;
        }

        bool Comparador.mayorIgualQue(Object op2)
        {
            Equipos p2 = (Equipos)op2;
            if (NombreEquipo.CompareTo(p2.NombreEquipo) >= 0)
                return true;
            else
                return false;
        }

        /*public override string ToString()
        {
            return $"Nombre: {NombreProyecto}, Descripción: {DescripcionProyecto}, Cliente: {ClienteProyecto}, Fecha de Inicio: {FechaProyecto}";
        }*/

        /*
        public override string ToString()
        {
            return "(" + NombreProyecto + " - " + DescripcionProyecto + " - " + ClienteProyecto + " - " + FechaProyecto + ")";
        } */
    }
}