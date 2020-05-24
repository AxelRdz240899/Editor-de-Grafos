using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor_de_Grafos
{
    class Floyd
    {
        int[,] MatrizPesos;
        int INF = 100000;
        int N;
        int[,] MatrizRecorrido;
        int CostoCamino = 0;
        int O = 0;
        public List<int> Camino; 
        public Floyd(int NumNodos, int[,] MP)
        {
            N = NumNodos;
            MatrizPesos = MP;
            MatrizRecorrido = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (MatrizPesos[i, j] == 0)
                    {
                        MatrizPesos[i, j] = INF;
                    }
                    MatrizRecorrido[j, i] = i;
                }
            }
            AlgoritmoFloyd();
        }

        public void AlgoritmoFloyd()
        {
            for (int i = 0; i < N; i++)
            {
                ChecaRenglonColumna(i);
            }

            ImprimeMatrizFloyd(MatrizPesos, "****** FLOYD *******\n Matriz de Pesos\n");
            //DaFormatoMatrizRecorridos();
            ImprimeMatrizFloyd(MatrizRecorrido, "****** FLOYD *******\n Matriz de Recorridos");
        }


        public void DaFormatoMatrizRecorridos()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    MatrizRecorrido[i, j] += 1;
                }
            }
        }
        public void ChecaRenglonColumna(int RenglonColumna)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    int Distancia = MatrizPesos[i, RenglonColumna] + MatrizPesos[RenglonColumna, j];
                    if(i != j)
                    {
                        if (MatrizPesos[i, j] > Distancia)
                        {
                            //MessageBox.Show("Cambiando como pivote en el nodo: " + (RenglonColumna + 1));
                            MatrizPesos[i, j] = Distancia;
                            MatrizRecorrido[i, j] = RenglonColumna;
                        }
                    }
                }
            }
        }

        public List<int> ObtenCaminosNodo(int IdentificadorNodo, int IdentificadorDestino)
        {
            O = IdentificadorNodo;
            CostoCamino = 0;
            Camino = new List<int>();
            if (MatrizPesos[IdentificadorNodo, IdentificadorDestino] != INF)
            {
                CostoCamino = MatrizPesos[IdentificadorNodo, IdentificadorDestino];
                if (MatrizRecorrido[IdentificadorNodo,IdentificadorDestino] != IdentificadorDestino)
                {
                    int V = MatrizRecorrido[IdentificadorNodo, IdentificadorDestino];
                    MessageBox.Show("Primero tengo que encontrar el camino menor al nodo: " + (V + 1));
                    Camino.Add(IdentificadorNodo);
                    BuscaCaminoMásCorto(IdentificadorNodo, V);
                    MessageBox.Show("Valor de V al finalizar la búsqueda" + (V + 1));
                    /*if(MatrizRecorrido[V, IdentificadorDestino] == IdentificadorDestino)
                    {
                        Camino.Add(IdentificadorDestino);
                    }*/
                }
                else
                { 
                    Camino.Add(IdentificadorNodo);
                    Camino.Add(IdentificadorDestino);
                }
                string Cadena = "CAMINOS EN FLOYD: " + "\n";
                for (int i = 0; i < Camino.Count; i++)
                {
                    Camino[i] = Camino[i] + 1;
                }
                MessageBox.Show("Cantidad de nodos en el camino: " + Camino.Count);
                foreach (int entero in Camino)
                {
                    Cadena += entero + " ";
                }
                Cadena += "\nCon un costo de: " + CostoCamino;
                MessageBox.Show(Cadena);
                return Camino;
            }
            else
            {
                MessageBox.Show("No hay camino");
            }
            return Camino;
        }

        public int BuscaPesoCaminoMasCorto(int Origen, int Destino)
        {
            return(MatrizPesos[Origen, Destino]);
        }

        public void BuscaCaminoMásCorto(int Origen, int Destino)
        {
            //MessageBox.Show("Encontrando el camino menor del nodo: " + (Origen + 1));
            int Valor = MatrizRecorrido[Origen, Destino];
            if (Valor != Destino)
            {
                //MessageBox.Show("Agregando el valor de: " + (Valor + 1) + " al camino");
                Camino.Add(Valor);
                //MessageBox.Show("El valor todavía no es el del destino, entonces tengo que ir al nodo: " + (Valor + 1));
                BuscaCaminoMásCorto(Valor, Destino);
            }
            else
            {
                //MessageBox.Show("Agregando el valor de: " + (Valor + 1) + " al camino");
                Camino.Add(Valor);
            }

        }
        public void ImprimeMatrizFloyd(int[,] Matriz, string Texto)
        {
            string Formato = Texto + "\n";
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (Matriz[i, j] == INF)
                    {
                        Formato += "- ";
                    }
                    else
                    {
                        Formato += Matriz[i, j].ToString();
                    }
                    Formato += "   ";
                }
                Formato += "\n";
            }
            MessageBox.Show(Formato);
        }
    }
}
