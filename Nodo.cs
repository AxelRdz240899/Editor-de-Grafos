using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Editor_de_Grafos
{
    public class Nodo
    {
        public List<Arco> Relaciones;
        public Point Coordenadas;
        public int Identificador;
        public int radio = 25;
        public Point Centro;
        public Nodo()
        {
            Relaciones = new List<Arco>();
            Coordenadas = new Point(0, 0);
            Centro = new Point(0, 0);
            Identificador = 0;
        }

        public void AsignarCoordenadas(int X, int Y)
        {
            Coordenadas.X = X - radio;
            Coordenadas.Y = Y - radio;
            Centro.X = X;
            Centro.Y = Y;
        }

        public void AñadirRelacion(int NumeroNodo, int Peso)
        {
            Arco Aux = new Arco();
            Aux.Origen = Identificador;
            Aux.Destino = NumeroNodo;
            Aux.Peso = Peso;
            Relaciones.Add(Aux);
        }
        
        public int ObtenGradoNodo()
        {
            int Grado = 0;
            foreach(Arco r in Relaciones)
            {
                Grado++;
            }
            return Grado;
        }

        public Arco ObtenRelacion(int indice)
        {
            return Relaciones[indice];
        }

        public void AñadirPeso(int PesoRelacion, int destino)
        {
            foreach(Arco relacion in Relaciones)
            {
                if(relacion.Destino == destino)
                {
                    relacion.Peso = PesoRelacion;
                }
            }
        }

        public bool TieneRelacion(int Identificador)
        {
            bool Respuesta = false;
            foreach(Arco a in Relaciones)
            {
                if(a.Destino == Identificador)
                {
                    Respuesta = true;
                    break;
                }
            }
            return Respuesta;
        }

    }
}
