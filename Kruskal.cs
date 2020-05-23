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
        public int V, INT_MAX = 99999;
        public int[] parent;

        // Find set of vertex i 
        int find(int i)
        {
            while (parent[i] != i)
                i = parent[i];
            return i;
        }

        // Does union of i and j. It returns 
        // false if i and j are already in same 
        // set. 
        void union1(int i, int j)
        {
            int a = find(i);
            int b = find(j);
            parent[a] = b;
        }

        // Finds MST using Kruskal's algorithm 
        public void kruskalMST(int[,] cost, int count)
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (cost[i, j] == 0)
                    {
                        cost[i, j] = INT_MAX;
                    }
                }
            }
            int mincost = 0; // Cost of min MST. 
            V = count;
            parent = new int[count];
            // Initialize sets of disjoint sets. 
            for (int i = 0; i < V; i++)
                parent[i] = i;

            // Include minimum weight edges one by one 
            int edge_count = 0;
            while (edge_count < V)
            {
                int min = INT_MAX, a = -1, b = -1;
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (find(i) != find(j) && cost[i, j] < min)
                        {
                            min = cost[i, j];
                            a = i;
                            b = j;
                        }
                    }
                }

                union1(a, b);
                MessageBox.Show("Relacion" + (edge_count + 1) + ": (" + a + ", " + b + ") costo:" + min);
                mincost += min;
            }
            MessageBox.Show("Costo minimo: " + mincost);
        }
    }
}
