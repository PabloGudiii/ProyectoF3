using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class ComparadorEquipos : IComparer<Equipos>
    {
        public int Compare(Equipos x, Equipos y)
        {
            return x.AliasEquipo.CompareTo(y.AliasEquipo);
        }
    }
}
