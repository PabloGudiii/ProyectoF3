using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class NodoTablaHash
    {
        public Object Dato;
        public NodoTablaHash Enlace;
        public NodoTablaHash(Object vDato)
        {
            Dato = vDato;
            Enlace = null;
        }
    }
}
