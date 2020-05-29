using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor_de_Grafos
{
    class Kruskal
    {
        public int NumNodos;
        public int[] NodosPadre;
        public int INF = 100000;
        public int[,] cost;
        public int CostoMinimo = 0;
        public Kruskal(int NumNodos, int[,] MatrizPesos) // Constructor del Objeto
        {
            this.NumNodos = NumNodos;
            cost = MatrizPesos;
            NodosPadre = new int[NumNodos];
            for(int i = 0; i < NumNodos; i++)
            {
                for(int j = 0; j < NumNodos; j++)
                {
                    if(cost[i,j] == 0)
                    {
                        cost[i, j] = INF;
                    }
                }
            }
            //kruskalMST();
        }

        // Encuentra el Vertex i en el arreglo de vertices
        private int EncuentraNodo(int i)
        {
            while (NodosPadre[i] != i)
                i = NodosPadre[i];
            return i;
        }

        // Este método checa si ya existe la relación entre 2 nodos. 
        private void union1(int i, int j)
        {
            int a = EncuentraNodo(i);
            int b = EncuentraNodo(j);
            NodosPadre[a] = b;
        }

        // Método para encontrar el árbol de menor costo usando el algoritmo de Kruskal
        public  List<int> kruskalMST()
        {
            int mincost = 0; // NumNodosarialb 
            List<int> ArbolKruskal = new List<int>();
            // Initialize sets of disjoint sets. 
            for (int i = 0; i < NumNodos; i++)
                NodosPadre[i] = i;
            string CadAux = "ARBOL DE MENOR COSTO (KRUSKAL)\n";
            // Include minimum weight edges one by one 
            int edge_count = 0;
            while (edge_count < NumNodos - 1)
            {
                int min = INF, a = -1, b = -1;
                for (int i = 0; i < NumNodos; i++)
                {
                    for (int j = 0; j < NumNodos; j++)
                    {
                        if (EncuentraNodo(i) != EncuentraNodo(j) && cost[i, j] < min)
                        {
                            min = cost[i, j];
                            a = i;
                            b = j;
                        }
                    }
                }
                union1(a, b);
                ArbolKruskal.Add(a + 1);
                ArbolKruskal.Add(b + 1);
                CadAux += "Relacion : " + edge_count++ + " :(" + (a + 1) + " , " + (b + 1) + ")" + " costo: " + min + "\n";
                mincost += min;
            }
            CadAux += "Costo minimo: " + mincost + "\n";
            MessageBox.Show(CadAux);
            CostoMinimo = mincost;
            return ArbolKruskal;
        }
    }
}
