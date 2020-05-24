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
            CostoCamino = 0;
            List<int> Camino = new List<int>();
            int Identificador = -1;
            if (MatrizPesos[IdentificadorNodo, IdentificadorDestino] != INF)
            {
                CostoCamino = MatrizPesos[IdentificadorNodo, IdentificadorDestino];
                Identificador++;
                int Valor = MatrizRecorrido[IdentificadorNodo, IdentificadorDestino];
                MessageBox.Show("Valor Inicial: " + Valor);
                Camino.Add(IdentificadorNodo);
                //MessageBox.Show("Valor de la relación: " + MatrizPesos[IdentificadorNodo, IdentificadorDestino]);
                while (Valor != IdentificadorDestino)
                {
                    Valor = MatrizRecorrido[Valor, IdentificadorDestino];
                    MessageBox.Show("Todavía no llego al final, y tenemos un valor de: " + (Valor + 1));
                    Camino.Add(Valor);
                }
            }
            else
            {
                MessageBox.Show("No hay camino");
            }
            //MessageBox.Show("Cantidad de Caminos: " + Caminos.Count);
            string Cadena = "CAMINOS EN FLOYD: " + "\n";

            MessageBox.Show("Cantidad de nodos en el camino: " + Camino.Count);
            foreach (int entero in Camino)
            {
                Cadena += (entero + 1) + " ";
            }
            Cadena += "\nCon un costo de: " + CostoCamino;
            MessageBox.Show(Cadena);
            return Camino;
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
