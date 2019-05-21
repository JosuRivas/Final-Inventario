using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_inventarios
{
    class Lista
    {
        public NodoLista cabeza;
        public Lista()
        {
            cabeza = null;
        }
        public void InsertarF(object item)
        {
            NodoLista auxiliar = new NodoLista();
            auxiliar.dato = item;
            auxiliar.siguiente = null;

            if (cabeza == null)
            {
                cabeza = auxiliar;
            }
            else
            {
                NodoLista puntero;
                puntero = cabeza;
                while (puntero.siguiente !=null)
                {
                    puntero = puntero.siguiente;
                }
                puntero.siguiente = auxiliar;
            }
        }
        public void InsertarI(object item)
        {
            NodoLista auxiliar = new NodoLista();
            auxiliar.dato = item;
            auxiliar.siguiente = null;
            if (cabeza == null)
            {
                cabeza = auxiliar;
            }
            else
            {
                NodoLista puntero;
                puntero = cabeza;
                cabeza = auxiliar;
                auxiliar.siguiente = puntero;
            }
        }
        public void EliminarObj(object info)
        {
            if (cabeza == null)
            {
                MessageBox.Show("El registro se encuentra vacío", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            NodoLista punteroant, punteropost;
            punteroant = cabeza;
            punteropost = cabeza;
            while (punteropost.siguiente !=null)
            {
                if (punteropost.dato == info)
                {
                    break;
                }
                punteroant = punteropost;
                punteropost = punteropost.siguiente;
            }
            punteroant.siguiente = punteropost.siguiente;

        }
    }
}
