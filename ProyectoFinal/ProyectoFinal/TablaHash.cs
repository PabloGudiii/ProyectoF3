using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class TablaHash
    {
        public static readonly int M = 400;
        private static readonly int MaxPartidos = 250;
        private int totalPartidos = 0;
        public Lista[] TablaHashGenerica;
        int Posicion;

        public TablaHash()
        {
            TablaHashGenerica = new Lista[M];
        }

        public IEnumerable<Lista> ObtenerTodasListas()
        {
            foreach (var lista in TablaHashGenerica)
            {
                if (lista != null)
                {
                    yield return lista;
                }
            }
        }

        public int DispersionMod(int Clave)
        {
            return Clave % M;
        }

        public static int HashApellido(string fechaPartido)
        {
            int hash = 0;
            foreach (char c in fechaPartido)
            {
                hash = (hash * 31 + c) % M;
            }
            return hash;
        }

        public bool Insertar(Partidos dato)
        {
            if (totalPartidos >= MaxPartidos)
            {
                return false;
            }

            int clave = HashApellido(dato.FechaPartido);
            int posicion = DispersionMod(clave);

            if (TablaHashGenerica[posicion] == null)
            {
                TablaHashGenerica[posicion] = new Lista();
            }

            NodoTablaHash actual = TablaHashGenerica[posicion].primero;
            while (actual != null)
            {
                Partidos participante = actual.Dato as Partidos;
                if (participante != null && participante.FechaPartido.Equals(dato.FechaPartido, StringComparison.OrdinalIgnoreCase)
                    && participante.EquipoCasaPartido.Equals(dato.EquipoCasaPartido, StringComparison.OrdinalIgnoreCase)
                    && participante.EquipoVisitantePartido.Equals(dato.EquipoVisitantePartido, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                actual = actual.Enlace;
            }

            TablaHashGenerica[posicion].insertarCabezaLista(dato);
            totalPartidos++;
            return true;
        }

        public bool Eliminar(string fechaPartido)
        {
            int clave = HashApellido(fechaPartido);
            int posicion = DispersionMod(clave);
            if (TablaHashGenerica[posicion] == null)
                return false;

            NodoTablaHash actual = TablaHashGenerica[posicion].primero;
            NodoTablaHash previo = null;
            while (actual != null)
            {
                Partidos participante = actual.Dato as Partidos;
                if (participante != null && participante.FechaPartido.Equals(fechaPartido, StringComparison.OrdinalIgnoreCase))
                {
                    if (previo == null)
                        TablaHashGenerica[posicion].primero = actual.Enlace;
                    else
                        previo.Enlace = actual.Enlace;
                    totalPartidos--;
                    return true;
                }
                previo = actual;
                actual = actual.Enlace;
            }
            return false;
        }


        public bool Actualizar(Partidos nuevoDato)
        {
            Partidos partido = Consultar(nuevoDato.FechaPartido);
            if (partido != null)
            {
                partido.EstadoPartido = nuevoDato.EstadoPartido;
                partido.EquipoCasaPartido = nuevoDato.EquipoCasaPartido;
                partido.EquipoVisitantePartido = nuevoDato.EquipoVisitantePartido;
                partido.ArbitroPartido = nuevoDato.ArbitroPartido;
                partido.NumeroSemanaPartido = nuevoDato.NumeroSemanaPartido;
                partido.GolesCasaPartido = nuevoDato.GolesCasaPartido;
                partido.GolesVisitantePartido = nuevoDato.GolesVisitantePartido;
                partido.TotalGolesPartido = nuevoDato.TotalGolesPartido;
                partido.EstadioPartido = nuevoDato.EstadioPartido;
                return true;
            }
            return false;
        }

        public Partidos Consultar(string fechaPartido)
        {
            int hashClave = HashApellido(fechaPartido);
            int posicion = DispersionMod(hashClave);
            if (TablaHashGenerica[posicion] != null)
            {
                NodoTablaHash nodo = TablaHashGenerica[posicion].primero;
                while (nodo != null)
                {
                    Partidos participante = nodo.Dato as Partidos;
                    if (participante != null && participante.FechaPartido.Equals(fechaPartido, StringComparison.OrdinalIgnoreCase))
                        return participante;
                    nodo = nodo.Enlace;
                }
            }
            return null;
        }

        public Dictionary<string, List<Partidos>> ObtenerPartidosAgrupadosPorFecha()
        {
            var partidosPorFecha = new Dictionary<string, List<Partidos>>();
            foreach (var lista in ObtenerTodasListas())
            {
                if (lista != null)
                {
                    NodoTablaHash nodo = lista.primero;
                    while (nodo != null)
                    {
                        Partidos partido = nodo.Dato as Partidos;
                        if (partido != null)
                        {
                            if (!partidosPorFecha.ContainsKey(partido.FechaPartido))
                            {
                                partidosPorFecha[partido.FechaPartido] = new List<Partidos>();
                            }
                            partidosPorFecha[partido.FechaPartido].Add(partido);
                        }
                        nodo = nodo.Enlace;
                    }
                }
            }
            return partidosPorFecha;
        }

    }
}
