using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Editor_de_Grafos
{
    class Warshall
    {
        public int[,] MR;
        public Warshall(int [,] MatrizRelacion)
        {
            MR = MatrizRelacion;
        }
        public void CreaCerraduraTransitivaWarshall()
        {
            
            int N = MR.GetLength(0);
            for(int z = 0; z < N; z++)
            {
                for(int i = 0; i < N; i++)
                {
                    for(int j = 0; j < N; j++)
                    {
                        if(MR[i,j] != 1)
                        {
                            MR[i, j] = MR[i, z] & MR[z, j];
                        }
                    }
                }
            }
        }

        public void ImprimeCerraduraTransitiva()
        {
            int N = MR.GetLength(0);
            string Formato = "Matriz de Cerradura Transitiva WARSHALL!\n";
            for (int i = 0; i < N; i++)
            {
                Formato += "\t     ";
                for (int j = 0; j < N; j++)
                {

                        Formato += MR[i, j].ToString();
                    
                    Formato += "   ";
                }
                Formato += "\n";
            }
            System.Windows.Forms.MessageBox.Show(Formato);
        }
    }
}
