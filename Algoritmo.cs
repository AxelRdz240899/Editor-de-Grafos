using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Net.Http.Headers;

namespace Editor_de_Grafos
{
    class Algoritmo
    {
        //private Matriz m_form;
        private List<Nodo> k, m;
        String RutaResultado = "";
        int NumPermutacionTranspuesta = 0;
        int INF = 100000;
        public Algoritmo()
        {
            //m_form = new Matriz();
            k = new List<Nodo>();
            m = new List<Nodo>();
        }

        public int[] EsBiparitoKM(List<Nodo> nodos, int[,] MR)
        {
            int[] km = { 0, 0 };
            if (!EsBipartito(nodos, MR))
                return km;
            for (int i = 0; i < k.Count; i++)
                for (int j = 0; j < m.Count; j++)
                    if (!SeRelacionan(nodos, k[i], m[j]))
                        return km;
            km[0] = k.Count;
            km[1] = m.Count;
            return km;
        }

        public bool EsCompleto(List<Nodo> nodos, int[,] MR)
        {
            for (int i = 0; i < nodos.Count; i++)
                for (int j = 0; j < nodos.Count; j++)
                {
                    if (i == j && MR[i, j] == 1)
                        return false;
                    else if (i != j && MR[i, j] == 0)
                        return false;
                }
            return true;
        }

        public int[] MuestraGrados(List<Nodo> nodos, int[,] MR)
        {
            int[] grados = new int[25];

            for (int i = 0; i < nodos.Count; i++)
            {
                grados[i] = 0;
                for (int j = 0; j < nodos.Count; j++)
                    if (i != j)
                        grados[i] += MR[i, j] + MR[j, i];
            }
            return grados;
        }

        public bool EsBipartito(List<Nodo> nodos, int[,] MR)
        {
            if (nodos.Count < 2)
                return false;
            List<Nodo> l1 = new List<Nodo>();
            List<Nodo> l2 = new List<Nodo>();
            int index;
            bool b1, b2;
            l1.Add(nodos[0]);
            while (l1.Count + l2.Count < nodos.Count)
            {
                b1 = b2 = false;
                for (int i = 0; i < l1.Count; i++)//agregando relaciones de nodos de lista1 a lista2
                    for (int j = 0; j < l1[i].Relaciones.Count; j++)
                    {
                        index = IndiceNodo(nodos, BuscaNodoInt(nodos, l1[i].Relaciones[j].Destino));
                        if (!l2.Contains(nodos[index]))
                        {
                            //MessageBox.Show("metiendo a "+nodos[index].ID+" a l2");
                            l2.Add(nodos[index]);
                            b1 = true;
                        }
                    }
                for (int k = 0; k < l2.Count; k++)//agregando relaciones de nodos de lista2 a lista1
                    for (int l = 0; l < l2[k].Relaciones.Count; l++)
                    {
                        index = IndiceNodo(nodos, BuscaNodoInt(nodos, l2[k].Relaciones[l].Destino));
                        if (!l1.Contains(nodos[index]))
                        {
                            //MessageBox.Show("metiendo a " + nodos[index].ID + " a l1");
                            l1.Add(nodos[index]);
                            b2 = true;
                        }
                    }
                if (b1 == false && b2 == false)//si no se agregaron nodos, agrega uno "valido" a la lista1
                    for (int i = 1; i < nodos.Count; i++)
                        if (!l1.Contains(nodos[i]) && !l2.Contains(nodos[i]))
                        {
                            if (!SeRelacionan(nodos, nodos[i], nodos[0]))
                            {
                                l1.Add(nodos[i]);
                                //MessageBox.Show("metiendo extra a " + nodos[i].ID + " a l1");
                                i = 1000;
                            }
                        }
            }
            for (int i = 0; i < l1.Count; i++)
                for (int j = 0; j < l1.Count; j++)
                    if (SeRelacionan(nodos, l1[i], l1[j]))
                        return false;
            for (int i = 0; i < l2.Count; i++)
                for (int j = 0; j < l2.Count; j++)
                    if (SeRelacionan(nodos, l2[i], l2[j]))
                        return false;
            k = l1;
            m = l2;
            return true;
        }

        private Nodo BuscaNodoInt(List<Nodo> Nodos, int identificador)
        {
            foreach (Nodo nodo in Nodos)
            {
                if (nodo.Identificador == identificador)
                {
                    return nodo;
                }
            }
            return null;
        }
        public bool SeRelacionan(List<Nodo> nodos, Nodo n1, Nodo n2)
        {
            List<Nodo> NodosRelaciones1 = new List<Nodo>();
            List<Nodo> NodsRelaciones2 = new List<Nodo>();

            foreach (Arco r in n1.Relaciones)
            {
                NodosRelaciones1.Add(BuscaNodoInt(nodos, r.Destino));
            }
            foreach (Arco r in n2.Relaciones)
            {
                NodsRelaciones2.Add(BuscaNodoInt(nodos, r.Destino));
            }
            if (IndiceNodo(NodosRelaciones1, n2) >= 0 || IndiceNodo(NodsRelaciones2, n1) >= 0)
                return true;
            return false;
        }
        //retorna la posicion del "nodo n" en "la lista nodos"
        public int IndiceNodo(List<Nodo> nodos, Nodo n)
        {
            return nodos.FindIndex(nodo => nodo.Identificador == n.Identificador);
        }

        public int[,] MultiplicaMatrices(int[,] Matriz1, int[,] Matriz2)
        {
            int[,] Mr = new int[Matriz1.GetLength(0), Matriz2.GetLength(0)];
            for (int i = 0; i < Matriz1.GetLength(0); i++)
            {
                for (int j = 0; j < Matriz2.GetLength(0); j++)
                {
                    Mr[i, j] = 0;
                    for (int aux = 0; aux < Matriz2.GetLength(0); aux++)
                    {
                        Mr[i, j] += Matriz1[i, aux] * Matriz2[aux, j];
                    }
                }
            }
            return Mr;
        }

        public void intercambiaRenglon(int RenglonOrigen, int RenglonDestino, int[,] Matriz, int Tamaño)
        {
            int[,] Copia = new int[Tamaño, Tamaño];
            for (int i = 0; i < Tamaño; i++)
            {
                for (int j = 0; j < Tamaño; j++)
                {
                    Copia[i, j] = Matriz[i, j];
                }
            }
            // En este punto ya tenemos una copia de la matriz original
            for (int i = 0; i < Tamaño; i++)
            {
                Matriz[RenglonDestino, i] = Copia[RenglonOrigen, i];
                Matriz[RenglonOrigen, i] = Copia[RenglonDestino, i];
            }
            //MessageBox.Show("Intercambiando el renglón: \n" + FormateaMatrizaCadena(Matriz));
        }

        public void intercambiaColumnna(int ColumnaOrigen, int ColumnaDestino, int[,] Matriz, int Tamaño)
        {
            int[,] Copia = new int[Tamaño, Tamaño];
            for (int i = 0; i < Tamaño; i++)
            {
                for (int j = 0; j < Tamaño; j++)
                {
                    Copia[i, j] = Matriz[i, j];
                }
            }
            // En este punto ya tenemos una copia de la matriz original
            for (int i = 0; i < Tamaño; i++)
            {
                Matriz[i, ColumnaDestino] = Copia[i, ColumnaOrigen];
                Matriz[i, ColumnaOrigen] = Copia[i, ColumnaDestino];
            }
        }

        public string FormateaMatrizaCadena(int[,] Matriz)
        {
            string F = "";
            for (int i = 0; i < Matriz.GetLength(0); i++)
            {
                for (int j = 0; j < Matriz.GetLength(1); j++)
                {
                    F += Matriz[i, j].ToString();
                    F += "   ";
                }
                F += "\n";
            }
            return F;
        }

        public int BuscaColumnaSimilar(int GradoColumna, int PosicionColumna, int[,] Matriz, Grafo grafo, List<int> GradosSalida)
        {
            bool Bandera;
            //En los renglones tenemos que obtener el grado de salida del nodo en la posición del renglón seleccionado
            //En la columna tenemos que obtener el grado de entrada del nodo
            int TamañoMatriz = grafo.Nodos.Count;
            List<int> ListaAuxiliar = new List<int>();
            for (int i = PosicionColumna; i < TamañoMatriz; i++)
            {
                if (grafo.ObtenGradoEntradaNodo(grafo.Nodos[i]) == GradoColumna)
                {
                    Bandera = true;
                    for (int j = 0; j < grafo.Nodos.Count; j++)
                    {
                        if (Matriz[j, i] == 1)
                        {
                            int NumAuxgrados = 0;
                            for (int z = 0; z < grafo.Nodos.Count; z++)
                            {
                                NumAuxgrados += Matriz[z, j];
                            }
                            ListaAuxiliar.Add(NumAuxgrados);
                        }
                    }
                    ListaAuxiliar.Sort();
                    GradosSalida.Sort();
                    for (int z = 0; z < ListaAuxiliar.Count; z++)
                    {
                        if (ListaAuxiliar[z] != GradosSalida[z])
                        {
                            Bandera = false;
                        }
                    }
                    ListaAuxiliar.Clear();
                    if (Bandera)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }
        public bool AlgoritmoManualBotello(Grafo grafo1, Grafo grafo2)
        {
            SaveFileDialog VentanaGuardar = new SaveFileDialog();
            string CadenaAEscribir = "";
            string Ruta = "";
            int SumaColumna = 0;
            int[,] MatrizU = grafo1.GeneraMatrizAdyacencia();
            int[,] MatrizV = grafo2.GeneraMatrizAdyacencia();
            List<int> ArregloGradosSalidaColumna;
            VentanaGuardar.Filter = "Texto (*.txt)|*.txt";
            MessageBox.Show("Por favor selecciona donde guardar el resultado");
            if (VentanaGuardar.ShowDialog() == DialogResult.OK)
            {
                Ruta = VentanaGuardar.FileName;
            }

            if ((grafo1.Nodos.Count == grafo2.Nodos.Count) && (grafo1.ObtenNumeroRelaciones() == grafo2.ObtenNumeroRelaciones())) // Si tenemos el mismo número de relaciones y nodos 
            {
                for (int i = 0; i < grafo1.Nodos.Count - 1; i++)
                {
                    ArregloGradosSalidaColumna = new List<int>();
                    SumaColumna = grafo1.ObtenGradoEntradaNodo(grafo1.Nodos[i]);
                    for (int j = 0; j < grafo1.Nodos.Count; j++)
                    {
                        if (MatrizU[j, i] == 1)
                        {
                            int NumAuxGrados = 0;
                            for (int z = 0; z < grafo1.Nodos.Count; z++)
                            {
                                NumAuxGrados += MatrizU[z, j];
                            }
                            ArregloGradosSalidaColumna.Add(NumAuxGrados);
                        }
                    }
                    int ColSim = BuscaColumnaSimilar(SumaColumna, i + 1, MatrizV, grafo2, ArregloGradosSalidaColumna);
                    if (ColSim != 0)
                    {
                        CadenaAEscribir += "Comparando con la columna: " + (i + 1) + " de la matriz 1 \n" + "Columna Similar encontrada: " + (ColSim + 1) + " en la matriz 2 " + "\n";
                        intercambiaColumnna(i, ColSim, MatrizV, grafo1.Nodos.Count);
                        intercambiaRenglon(i, ColSim, MatrizV, grafo1.Nodos.Count);
                        CadenaAEscribir += "\nNueva Matriz: \n" + FormateaMatrizaCadena(MatrizV) + "\n";
                        if (ComparaMatrices(MatrizU, MatrizV, grafo1.Nodos.Count))
                        {
                            CadenaAEscribir += "\n\nLos grafos son isomorfos";
                            using (StreamWriter Escritor = new StreamWriter(Ruta))
                            {
                                Escritor.WriteLine(CadenaAEscribir);
                            }
                            return true;
                        }
                    }
                    else
                    {
                        CadenaAEscribir += "No se encontaron coincidencias con la columna: " + (i + 1) + " de la matriz 1\n";
                    }

                }
            }
            else
            {
                MessageBox.Show("Los grafos no tienen el mismo número de nodos o el mismo número de relaciones!!!!");
            }
            CadenaAEscribir += "\n Los grafos no son isomorfos";
            using (StreamWriter Escritor = new StreamWriter(Ruta))
            {
                Escritor.WriteLine(CadenaAEscribir);
            }
            return false;
        }

        //Algoritmo Matriz Permutada
        public bool IsomorfismoMatrizPermutada(Grafo g1, Grafo g2)
        {
            NumPermutacionTranspuesta = 0;
            SaveFileDialog VentanaGuardar = new SaveFileDialog();
            MessageBox.Show("Por favor selecciona donde guardar el resultado");
            if (VentanaGuardar.ShowDialog() == DialogResult.OK)
            {
                RutaResultado = VentanaGuardar.FileName + ".txt";
            }
            int[,] A = g1.GeneraMatrizAdyacencia();
            int[,] B = g2.GeneraMatrizAdyacencia();
            int[,] MatrizPermutacion = new int[g1.Nodos.Count, g2.Nodos.Count];
            int[,] MatrizTranspuesta = new int[g1.Nodos.Count, g2.Nodos.Count];
            int count = g1.Nodos.Count;

            StreamWriter Escritor = new StreamWriter(RutaResultado);
            List<int[]> pesos = CalculaPesosMatriz(A, count);
            List<int[]> pesos2 = CalculaPesosMatriz(B, count);
            List<int> f = pesos[0].ToList();
            List<int> g = pesos2[0].ToList();
            List<int> mper = new List<int>();
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    MatrizPermutacion[i, j] = 0;
                    MatrizTranspuesta[i, j] = 0;
                }
            }

            for (int i = 0; i < f.Count; i++)
            {
                for (int j = 0; j < g.Count; j++)
                {
                    if (f[i] == g[j])
                        if (!mper.Contains(j))
                        {
                            MatrizPermutacion[i, j] = 1;
                            MatrizTranspuesta[j, i] = 1;
                            mper.Add(j);
                            break;
                        }

                }
            }

            Escritor.WriteLine("\t\t\t\t Matriz Permutación ");
            Escritor.Write(FormateaMatrizaCadena(MatrizPermutacion));
            Escritor.WriteLine("\t\t\t\t Matriz Transpuesta");
            Escritor.Write(FormateaMatrizaCadena(MatrizTranspuesta));
            return (CreaPermutaciones(MatrizPermutacion, MatrizTranspuesta, A, B, count, f, Escritor));
        }

        /* 
        Knuths 
        1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation. 
        2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l. 
        3. Swap a[j] with a[l]. 
        4. Reverse the sequence from a[j + 1] up to and including the final element a[n]. 
        */
        private static bool SiguientePermutacion(int[] numList)
        {

            var largestIndex = -1;
            for (var i = numList.Length - 2; i >= 0; i--)
            {
                if (numList[i] < numList[i + 1])
                {
                    largestIndex = i;
                    break;
                }
            }
            if (largestIndex < 0) return false;
            var largestIndex2 = -1;
            for (var i = numList.Length - 1; i >= 0; i--)
            {
                if (numList[largestIndex] < numList[i])
                {
                    largestIndex2 = i;
                    break;
                }
            }
            var tmp = numList[largestIndex];
            numList[largestIndex] = numList[largestIndex2];
            numList[largestIndex2] = tmp;
            for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i++, j--)
            {
                tmp = numList[i];
                numList[i] = numList[j];
                numList[j] = tmp;
            }
            return true;
        }


        public bool FuerzaBruta(int[,] MatrizGrafo1, int[,] MatrizGrafo2, int count)
        {
            SaveFileDialog VentanaGuardar = new SaveFileDialog();
            if (VentanaGuardar.ShowDialog() == DialogResult.OK)
            {
                RutaResultado = VentanaGuardar.FileName + ".txt";
            }
            else
            {
                MessageBox.Show("Intenta de nuevo");
            }
            StreamWriter Escritor = new StreamWriter(RutaResultado);

            long[] fact = { 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800,
                           39916800};
            int[] indexp = new int[count];
            for (int i = 0; i < count; i++)
            {
                indexp[i] = i;
            }
            if (ComparaMatrices(MatrizGrafo1, MatrizGrafo2, count))
            {
                Escritor.WriteLine("Las matrices son iguales desde un inicio!!!");
                Escritor.Close();
                return true;
            }
            for (int i = 0; i < fact[count - 1]; i++)
            {
                SiguientePermutacion(indexp);
                string Aux = "";
                Escritor.WriteLine("PERMUTACIÓN: ");
                for (int z = 0; z < indexp.GetLength(0); z++)
                {
                    Aux += "{" + (z + 1) + " , " + (indexp[z] + 1) + "}   ";
                }
                Escritor.WriteLine(Aux);
                Escritor.WriteLine("Probando Permutación en B");
                if (PruebaPermutacion(MatrizGrafo1, MatrizGrafo2, indexp))
                {
                    Escritor.WriteLine("Permutacion correcta encontrada, donde  A es igual a B, por lo tanto son Isomorfos!!!!");
                    Escritor.Close();
                    return true;
                }
            }
            Escritor.WriteLine("Lamentablemente no son Isomorfos :(");
            Escritor.Close();

            return false;
        }
        public bool PruebaPermutacion(int[,] M1, int[,] M2, int[] permutacion)
        {
            for (int i = 0; i < permutacion.Length; i++)
                for (int j = 0; j < permutacion.Length; j++)
                    if (M1[i, j] != M2[permutacion[i], permutacion[j]]) return false;
            return true;
        }

        public int[,] FormulaPAPT(int[,] p, int[,] a, int[,] t, int count, int[] indices, StreamWriter Escritor)
        {

            int[,] P = new int[count, count];
            int[,] T = new int[count, count];
            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
                    P[i, j] = p[indices[i], indices[j]];
            Escritor.WriteLine("Se realizó la permutación de las matrices");

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    T[i, j] = P[j, i];
                }
            }
            Escritor.WriteLine("Matriz P: \n");
            Escritor.Write(FormateaMatrizaCadena(P));
            Escritor.WriteLine("Matriz T: \n");
            Escritor.Write(FormateaMatrizaCadena(T));
            int[,] PA = MultiplicaMatrices(P, a);
            int[,] PAT = MultiplicaMatrices(PA, T);
            return PAT;
        }

        public bool CreaPermutaciones(int[,] P, int[,] T, int[,] A, int[,] B, int count, List<int> f, StreamWriter Escritor)
        {
            long[] fact = { 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800,
                           39916800, 479001600, 6227020800, 87178291200};
            int[] indices = new int[count];
            for (int i = 0; i < count; indices[i] = i, i++) ;
            int[,] res = new int[count, count];
            //MessageBox.Show(count.ToString());
            for (int i = 0; i < fact[count - 1]; i++)
            {
                NumPermutacionTranspuesta++;
                Escritor.WriteLine("Numero de Permutación: " + NumPermutacionTranspuesta);
                SiguientePermutacion(indices);
                //MessageBox.Show(indices.GetLength(0).ToString());
                //MessageBox.Show(res.GetLength(0).ToString());
                res = FormulaPAPT(P, A, T, count, indices, Escritor);
                //MessageBox.Show(res.GetLength(0).ToString()); // Aquí regresa mal el tamaño
                Escritor.WriteLine("Formula = Permutación * A * Permutación Transpuesta");
                Escritor.Write(FormateaMatrizaCadena(res));
                if (ComparaMatrices(B, res, count))
                {
                    Escritor.WriteLine("Funcionó la permutación!!!!!!!!!!!! :)");
                    Escritor.WriteLine("Matriz A:");
                    Escritor.Write(FormateaMatrizaCadena(A));
                    Escritor.WriteLine("Matriz B: ");
                    Escritor.Write(FormateaMatrizaCadena(B));
                    Escritor.Close();
                    return true;
                }
            }
            MessageBox.Show("Numero de Permutación" + NumPermutacionTranspuesta);
            Escritor.WriteLine("No se encontró una permutación adecuada");
            Escritor.Close();
            return false;
        }

        public List<int[]> CalculaPesosMatriz(int[,] MR, int count)
        {
            int[] pesoC = new int[count], pesoR = new int[count];
            List<int[]> pesos = new List<int[]>();

            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
                {
                    pesoR[i] += MR[i, j];
                    pesoC[j] += MR[j, i];
                }
            pesos.Add(pesoR);
            pesos.Add(pesoC);
            return pesos;
        }


        public bool ComparaMatrices(int[,] Matriz1, int[,] Matriz2, int tamaño)
        {
            bool r = true;
            try
            {
                for (int i = 0; i < tamaño; i++)
                {
                    for (int j = 0; j < tamaño; j++)
                    {
                        if (Matriz1[i, j] != Matriz2[i, j]) { return false; }
                    }
                }
            }
            catch (Exception e)
            {
            }

            return r;
        }

        public List<List<int>> CaminosSimples(int n1, int n2, int[,] MR, int count)
        {
            List<List<int>> caminos = new List<List<int>>();
            for (int i = 0; i < count; i++)
                if (MR[n1, i] == 1)
                    GeneraCamino(caminos, new List<int> { n1 }, i, n2, MR, count);

            if (n1 == n2)//para circuitos
            {
                int limpiando = caminos.Count;
                while (limpiando != 0)
                {
                    for (int i = 0; i < caminos.Count; i++)
                        if (caminos[i].Count < 4)
                        {
                            caminos.RemoveAt(i);
                            break;
                        }
                    limpiando--;
                }
            }
            return caminos;
        }

        public void GeneraCamino(List<List<int>> caminos, List<int> camino, int n1, int n2, int[,] MR, int count)
        {
            if (camino.Contains(n1))
            {
                if (n1 == n2)
                {
                    camino.Add(n1);
                    caminos.Add(camino);
                    return;
                }
                camino.Add(n1);
                return;
            }
            camino.Add(n1);
            if (n1 == n2)
            {
                caminos.Add(camino);
                return;
            }
            for (int i = 0; i < count; i++)
            {
                if (MR[n1, i] == 1)
                {
                    List<int> c = new List<int>();
                    for (int j = 0; j < camino.Count; j++)
                    {
                        c.Add(camino[j]);
                    }
                    GeneraCamino(caminos, c, i, n2, MR, count);
                }
            }
        }

        public void CaminoEuler(Grafo g, int idOrigen, int idDestino, List<List<int>> Camino)
        {
            List<int> ListaAuxInt = new List<int>();
            Nodo origen = g.Nodos[idOrigen - 1];
            Nodo destino = g.Nodos[idDestino - 1];
            foreach (Nodo n in g.Nodos)
            {
                ListaAuxInt.Add(n.ObtenGradoNodo());
            }

            int Pares = 0, Impares = 0;

            for (int i = 0; i < ListaAuxInt.Count; i++)
            {
                if (ListaAuxInt[i] % 2 == 0)
                    Pares++;
                else
                    Impares++;
            }

            if (Pares == ListaAuxInt.Count - 2 && Impares == 2)
            {
                if (origen.ObtenGradoNodo() % 2 != 0 && destino.ObtenGradoNodo() % 2 != 0)
                {
                    List<Nodo> ListaAux1, ListaAux2;
                    ListaAux1 = new List<Nodo>();
                    ListaAux2 = new List<Nodo>();
                    ListaAux1.Add(origen);

                    for (int i = 0; i < origen.ObtenGradoNodo(); i++)
                    {

                        ListaAux2.Add(BuscaNodoInt(g.Nodos, origen.ObtenRelacion(i).Destino));
                        ListaAux1.Add(BuscaNodoInt(g.Nodos, origen.ObtenRelacion(i).Destino));
                        EulerAlgoritmoRec(ListaAux1, ListaAux2, g, Camino);
                        ListaAux1.RemoveAt(ListaAux1.Count - 1);
                        ListaAux2.RemoveAt(ListaAux2.Count - 1);
                    }
                }
                else
                    MessageBox.Show("Seleccione los nodos de grado impar");

            }
            else
                MessageBox.Show("No cumple los requisitos");

            origen = null;
            destino = null;
        }

        public void EulerAlgoritmoRec(List<Nodo> ListaAux1, List<Nodo> ListaAux2, Grafo grafo, List<List<int>> camino)
        {
            Nodo n = ListaAux1[ListaAux1.Count - 1];
            Boolean Utilizado = false;

            if (ListaAux2.Count < grafo.ObtenNumeroRelaciones() / 2)
            {
                for (int i = 0; i < n.ObtenGradoNodo(); i++)
                {
                    Nodo aux = BuscaNodoInt(grafo.Nodos, n.ObtenRelacion(i).Destino);

                    for (int j = 0; j < ListaAux2.Count; j++)
                    {
                        if ((ListaAux1[j].Equals(aux) && ListaAux2[j].Equals(n)) || (ListaAux1[j].Equals(n) && ListaAux2[j].Equals(aux)))
                        {
                            Utilizado = true;
                            break;
                        }
                    }

                    if (!Utilizado)
                    {
                        ListaAux2.Add(aux);
                        ListaAux1.Add(aux);
                        EulerAlgoritmoRec(ListaAux1, ListaAux2, grafo, camino);
                        ListaAux1.RemoveAt(ListaAux1.Count - 1);
                        ListaAux2.RemoveAt(ListaAux2.Count - 1);
                    }
                    else
                        Utilizado = false;
                }
            }
            else
            {
                List<Nodo> serie = new List<Nodo>();
                for (int i = 0; i < ListaAux1.Count; i++)
                {
                    serie.Add(ListaAux1[i]);
                }
                List<int> Aux = new List<int>();
                for (int i = 0; i < ListaAux1.Count; i++)
                {
                    Aux.Add(ListaAux1[i].Identificador);
                }
                camino.Add(Aux);
            }
        }

        public void CircuitoEuler(Grafo g, int idNodo, List<List<int>> circuito)
        {

            Boolean requisitos = true;
            List<int> arr = new List<int>();
            Nodo origen = BuscaNodoInt(g.Nodos, idNodo);
            foreach (Nodo n in g.Nodos)
            {
                arr.Add(n.ObtenGradoNodo());
            }
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] % 2 != 0)
                    requisitos = false;
            }
            if (requisitos)
            {
                List<Nodo> ListaAux1, ListaAux2;
                ListaAux1 = new List<Nodo>();
                ListaAux2 = new List<Nodo>();
                ListaAux1.Add(origen);

                for (int i = 0; i < origen.ObtenGradoNodo(); i++)
                {
                    ListaAux2.Add(BuscaNodoInt(g.Nodos, origen.ObtenRelacion(i).Destino));
                    ListaAux1.Add(BuscaNodoInt(g.Nodos, origen.ObtenRelacion(i).Destino));
                    FleuryAlgoritmoRec(ListaAux1, ListaAux2, g, circuito);
                    ListaAux1.RemoveAt(ListaAux1.Count - 1);
                    ListaAux2.RemoveAt(ListaAux2.Count - 1);
                }
            }
            else
                MessageBox.Show("Desafortunadamente no  todos los nodos tienen grado par");

            origen = null;
        }
        public void FleuryAlgoritmoRec(List<Nodo> ListaAux1, List<Nodo> ListaAux2, Grafo g, List<List<int>> circuito)
        {
            Nodo nd = ListaAux1[ListaAux1.Count - 1];
            Boolean usado = false;

            if (ListaAux2.Count < g.ObtenNumeroRelaciones() / 2)
            {
                for (int i = 0; i < nd.ObtenGradoNodo(); i++)
                {
                    Nodo aux = BuscaNodoInt(g.Nodos, nd.ObtenRelacion(i).Destino);

                    for (int j = 0; j < ListaAux2.Count; j++)
                    {
                        if ((ListaAux1[j].Equals(aux) && ListaAux2[j].Equals(nd)) || (ListaAux1[j].Equals(nd) && ListaAux2[j].Equals(aux)))
                        {
                            usado = true;
                            break;
                        }
                    }

                    if (!usado)
                    {
                        ListaAux2.Add(aux);
                        ListaAux1.Add(aux);
                        FleuryAlgoritmoRec(ListaAux1, ListaAux2, g, circuito);
                        ListaAux1.RemoveAt(ListaAux1.Count - 1);
                        ListaAux2.RemoveAt(ListaAux2.Count - 1);
                    }
                    else
                        usado = false;
                }
            }
            else
            {
                List<Nodo> serie = new List<Nodo>();
                for (int i = 0; i < ListaAux1.Count; i++)
                {
                    serie.Add(ListaAux1[i]);
                }
                List<int> Aux = new List<int>();
                for (int i = 0; i < ListaAux1.Count; i++)
                {
                    Aux.Add(ListaAux1[i].Identificador);
                }
                circuito.Add(Aux);
            }
        }

        #region Floyd
        public void disp(int[,] distance, int verticesCount)
        {
            string CadAux = "";
            CadAux += "Distance Matrix for Shortest Distance between the nodes\n";
            for (int i = 0; i < verticesCount; ++i)
            {
                for (int j = 0; j < verticesCount; ++j)
                {
                    // IF THE DISTANCE TO THE NODE IS NOT DIRECTED THAN THE COST IN iNIFINITY  

                    if (distance[i, j] == INF)
                        CadAux += "INF";
                    else
                        CadAux += distance[i, j].ToString();
                }
                CadAux += "\n";
            }
            MessageBox.Show(CadAux);
        }

        public void FloydWarshall(int[,] graph, int verticesCount)
        {
            int[,] distance = new int[verticesCount, verticesCount];

            for (int i = 0; i < verticesCount; ++i)
                for (int j = 0; j < verticesCount; ++j)
                    distance[i, j] = graph[i, j];

            for (int k = 0; k < verticesCount; k++)
            {
                for (int i = 0; i < verticesCount; i++)
                {
                    for (int j = 0; j < verticesCount; j++)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                            distance[i, j] = distance[i, k] + distance[k, j];
                    }
                }
            }

            disp(distance, verticesCount);
            Console.ReadKey();

        }
        #endregion
    }
}


