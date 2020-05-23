using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor_de_Grafos
{
    class PrimAxel
    {
        const int INF = 100000;
        bool[] NodoCheck;
        int[] DistanciaNodo;
        int NumNodos;
        int[,] MatrizPesos;
        int Origen;
        public int CostoTotal{get;set;}
        public PrimAxel(int NNodos, int[,] Pesos, int NodoOrigen)
        {
            NumNodos = NNodos;
            DistanciaNodo = new int[NumNodos];
            NodoCheck = new bool[NumNodos];
            for(int i = 0; i < NumNodos; i++)
            {
                for(int j = 0; j < NumNodos; j++)
                {
                    if(Pesos[i,j] == 0)
                    {
                        Pesos[i, j] = INF;
                    }
                }
            }
            MatrizPesos = Pesos;
            Origen = NodoOrigen;
            CostoTotal = 0;
        }



        public List<int> Prim()
        {
            List<int> Camino = new List<int>();
            for (int i = 0; i < NumNodos; i++)
            {
                NodoCheck[i] = false;
            }
            NodoCheck[Origen] = true;
            Camino.Add(Origen);
            for (int i = 0; i < NumNodos - 1; i++)
            {
                int[] IndiceArreglo = BuscaRelacionMenorNodoSinVisitar(NodoCheck);
                
                NodoCheck[IndiceArreglo[1]] = true;
                int Indice = Camino.IndexOf(IndiceArreglo[0]);
                if(Indice != -1)
                {
                    //MessageBox.Show("Indice del padre, en la lista del camino" + Indice);
                    List<int> Auxiliar = new List<int>();

                    for(int z = 0; z < Indice + 1; z++)
                    {
                        Auxiliar.Add(Camino[z]);
                    }
                    Auxiliar.Add(IndiceArreglo[1]);
                    for (int z = Indice; z < Camino.Count; z++)
                    {
                        Auxiliar.Add(Camino[z]);
                    }
                    Camino = Auxiliar;
                    CostoTotal += BuscaCostoRelacion(IndiceArreglo[0], IndiceArreglo[1]);
                }
                //Camino.Insert(Indice,)
                //MessageBox.Show("Encontrando Relación con costo menor, va de: " + (IndiceArreglo[0] + 1) + " a el nodo: " + (IndiceArreglo[1] + 1));
            }
            for(int i = 0; i < Camino.Count; i++)
            {
                Camino[i] = Camino[i] + 1;
            }
            return Camino;
        }
        public int BuscaCostoRelacion(int i, int j)
        {
            return (MatrizPesos[i, j]);
        }
        public int[] BuscaRelacionMenorNodoSinVisitar(bool[] NodoCheck)
        {
            int[] Arreglo = new int[2]; // En la primera posición se encuentra el nodo padre, en la 2a posición se encuentra el nodo hijo;
            int ValorMinimo = INF;
            string Aux = "Nodos en la lista de visitados: \n";
            for(int i = 0; i  < NumNodos; i++)
            {
                if (NodoCheck[i])
                {
                    Aux += i;
                }
            }
            //MessageBox.Show(Aux);
            for(int i = 0; i < NumNodos; i++)
            {
                if (NodoCheck[i] == true)
                {

                    for(int j = 0; j < NumNodos; j++)
                    {
                        if(MatrizPesos[i,j] != INF && MatrizPesos[i,j] < ValorMinimo && !NodoCheck[j])
                        {
                            ValorMinimo = MatrizPesos[i, j];
                            Arreglo[0] = i;
                            Arreglo[1] = j;
                        }
                    }
                }
            }
            return Arreglo;
        }
    }
}
