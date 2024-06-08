using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class Lista
    {

        public NodoTablaHash primero;

        public Lista()
        {
            primero = null;
        }

        public Lista insertarCabezaLista(Object vDato)
        {
            NodoTablaHash nuevo;
            nuevo = new NodoTablaHash(vDato);
            nuevo.Enlace = primero;
            primero = nuevo;
            return this;
        }

        public String MuestraLista()
        {
            NodoTablaHash temp = primero;
            String resultado = "";
            while (temp != null)
            {
                resultado = resultado + temp.Dato + " - ";
                temp = temp.Enlace;
            }
            return resultado;
        }

        public Object BuscarNodo(Object pValor)
        {
            NodoTablaHash temp = primero;
            int posicion = 1;

            while (temp != null && !temp.Dato.Equals(pValor))
            {
                temp = temp.Enlace;
                posicion++;
            }
            return (temp == null) ? null : temp.Dato;
        }

        public void displayList()
        {
            NodoTablaHash current = primero;
            while (current != null)
            {
                Console.WriteLine(current.Dato);
                current = current.Enlace;
            }
        }

        public int readNodos()
        {
            int suma = 0;
            NodoTablaHash nodoActual = primero;
            while (nodoActual != null)
            {
                suma += int.Parse(nodoActual.Dato.ToString());
                nodoActual = nodoActual.Enlace;
            }
            return suma;
        }

        public void insertLast(object objNodo)
        {
            NodoTablaHash nuevoNodo = new NodoTablaHash(objNodo);
            if (primero == null)
            {
                primero = nuevoNodo;
            }
            else
            {
                NodoTablaHash lastNode = getLastNode();
                lastNode.Enlace = nuevoNodo;
            }
        }

        private NodoTablaHash getLastNode()
        {
            NodoTablaHash temp = primero;
            while (temp.Enlace != null)
            {
                temp = temp.Enlace;
            }
            return temp;
        }

        public bool deleteNode(object objNodo)
        {
            if (primero == null)
                return false;

            if (primero.Dato.Equals(objNodo))
            {
                primero = primero.Enlace;
                return true;
            }

            NodoTablaHash current = primero;
            while (current.Enlace != null)
            {
                if (current.Enlace.Dato.Equals(objNodo))
                {
                    current.Enlace = current.Enlace.Enlace;
                    return true;
                }
                current = current.Enlace;
            }
            return false;
        }
    }
}
