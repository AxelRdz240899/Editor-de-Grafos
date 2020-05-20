using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Editor_de_Grafos
{
    public class Arco
    {
        public int Peso;
        public int Origen;
        public int Destino;
        public bool Visitado = false;
        public Color ColorArco = Color.Black;
        public Arco()
        {
            Peso = 0;
            Destino = 0;
            Origen = 0;
        }
    }
}
