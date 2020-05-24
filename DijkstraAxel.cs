using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor_de_Grafos
{
    class DijkstraAxel
    {
        const int INF = 100000;
        int NumNodos;
        int[,] MatrizRelacion;
        int NodoOrigen = -1;

        public DijkstraAxel(int N, int[,] MR, int Origen)
        {
            NumNodos = N;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (MR[i, j] == 0)
                    {
                        MR[i, j] = INF;
                    }
                }
            }
            MatrizRelacion = MR;
            NodoOrigen = Origen;
            //ALgoritmoDIjkstra();
        }

        public List<List<int>> ALgoritmoDIjkstra()
        {
            bool[] NodoVisitado = new bool[NumNodos];
            int[] Distancias = new int[NumNodos];
            List<List<int>> Caminos = new List<List<int>>();
            for (int i = 0; i < NumNodos; i++)
            {
                Distancias[i] = MatrizRelacion[NodoOrigen, i];
                NodoVisitado[i] = false;
                Caminos.Add(new List<int>());
                Caminos[i].Add(NodoOrigen);
            }
            //MessageBox.Show("Distancias Iniciales: ");
            Distancias[NodoOrigen] = 0;
            for (int n = 0; n < NumNodos - 1; n++)
            {
                int Indice = ObtenIndiceValorMinimo(Distancias, NodoVisitado);
                //MessageBox.Show("Indice que estoy visitando: " + Indice);
                NodoVisitado[Indice] = true;
                for (int v = 0; v < NumNodos; v++)
                {
                    if (!NodoVisitado[v] && MatrizRelacion[Indice, v] != INF && Distancias[Indice]
                        + MatrizRelacion[Indice, v] < Distancias[v])
                    {
                        
                        //Console.WriteLine("He encontrado un camino menor hacia {0} desde {1}", v + 1, Indice + 1);
                        for (int i = 1; i < Caminos[Indice].Count; i++)
                        {
                            if(Caminos[Indice][i] != NodoOrigen)
                            {
                                Caminos[v].Add(Caminos[Indice][i]);
                            }
                            
                        }
                        Caminos[v].Add(Indice);
                        Distancias[v] = Distancias[Indice] + MatrizRelacion[Indice, v];
                    }
                }
            }
            int IndiceLista = 0;
            for (int i = 0; i < Caminos.Count; i++)
            {
                for (int j = 0; j < Caminos[i].Count; j++)
                {
                    Caminos[i][j] += 1;
                }
            }
            foreach (List<int> ListI in Caminos)
            {
                ListI.Add(IndiceLista + 1);
                string CadAux = "Camino del origen a: " + (IndiceLista + 1) + "\n";
                foreach (int i in ListI)
                {
                    CadAux += (i) + " - ";
                }
                IndiceLista++;
                //MessageBox.Show(CadAux);
            }
            Caminos.RemoveAt(NodoOrigen);
            for (int i = 0; i < NumNodos; i++)
            {
                if (Distancias[i] == INF)
                {
                    Caminos.RemoveAt(i);
                }
            }
            ImprimeDistancias(Distancias);
            return Caminos;
        }
        public int ObtenIndiceValorMinimo(int[] ArregloDistancias, bool[] NodosVisitados)
        {
            int min = INF, min_index = -1;

            for (int v = 0; v < NumNodos; v++)
                if (NodosVisitados[v] == false && ArregloDistancias[v] <= min)
                {
                    min = ArregloDistancias[v];
                    min_index = v;
                }

            return min_index;
        }

        public void ImprimeDistancias(int[] Distancias)
        {
            string CADAUX = "\t**************ALGORITMO DE DIJKSTRA**************\n";
            for (int i = 0; i < Distancias.Length; i++)
            {
                if(Distancias[i] != INF)
                {
                    CADAUX += "\t     Distancia mínima desde " + (NodoOrigen + 1) + "  hacía: " + (i + 1) + "   es de: " + Distancias[i] + "\n";
                }
                else
                {
                    CADAUX += "\t     Distancia mínima desde " + (NodoOrigen + 1)  + "  hacía: " + (i + 1) + "   no existe" + "\n";
                }
                
            }
            MessageBox.Show(CADAUX);
        }
    }
}
