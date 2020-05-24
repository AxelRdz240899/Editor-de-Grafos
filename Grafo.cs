using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor_de_Grafos
{
    public class Grafo
    {
        public List<Nodo> Nodos;
        public bool Dirigido { get; set; }
        int[,] MatrizAdyacencia;
        int[,] MatrizPesos;

        public Grafo()
        {
            Nodos = new List<Nodo>();
            Dirigido = false;
        }


        public void AgregarNodo(Nodo NodoNuevo)
        {
            Nodos.Add(NodoNuevo);
        }

        public void EliminarNodo(Nodo NodoEliminar)
        {
            Nodos.Remove(NodoEliminar);
            foreach (Nodo n in Nodos)
            {
                if (n.Identificador > NodoEliminar.Identificador)
                {
                    n.Identificador--;
                }
                for (int i = 0; i < n.Relaciones.Count; i++)
                {
                    n.Relaciones[i].Origen = n.Identificador;
                    if (n.Relaciones[i].Destino == NodoEliminar.Identificador)
                    {
                        n.Relaciones.Remove(n.Relaciones[i]);
                        i--;
                    }
                    else if (n.Relaciones[i].Destino > NodoEliminar.Identificador)
                    {
                        n.Relaciones[i].Destino--;
                    }
                }
            }
        }

        public bool EsCompleto()
        {
            bool Completo = true;
            int[,] MatrizR = GeneraMatrizAdyacencia();
            for (int i = 0; i < Nodos.Count; i++)
            {
                for (int j = 0; j < Nodos.Count; j++)
                {
                    if (j != i)
                    {
                        if (MatrizR[i, j] != 1)
                        {
                            Completo = false;
                        }
                    }
                }
            }
            return Completo;
        }

        public bool EsCiclo()
        {
            int[,] MatrizAdyacencia = GeneraMatrizAdyacencia();
            int suma;
            for (int i = 0; i < Nodos.Count; i++)
            {
                suma = 0;
                for (int j = 0; j < Nodos.Count; j++)
                    suma += MatrizAdyacencia[i, j];
                if (suma > 2)
                    return false;
            }
            for (int i = 0; i < Nodos.Count;)
            {
                if (Nodos[i].Relaciones.Count == 0)
                {
                    return false;
                }

                for (int j = 0; j < Nodos[i].Relaciones.Count; j++)
                {
                    i = IndiceNodo(Nodos, Nodos[i].Relaciones[j].Destino);
                    if (Nodos[i] == Nodos[0])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public int IndiceNodo(List<Nodo> nodos, int Identificador)
        {
            {
                return nodos.FindIndex(nodo => nodo.Identificador == Identificador);
            }
        }
        public bool EsBipartito()
        {
            bool Bipartito = true;
            List<Nodo> Grupo1 = new List<Nodo>();
            List<Nodo> Grupo2 = new List<Nodo>();

            if (Nodos.Count > 1)
            {
                Grupo1.Add(Nodos[0]);

                for (int i = 1; i < Nodos.Count; i++)
                {
                    foreach (Arco r in Grupo1[0].Relaciones)
                    {
                        if (r.Destino != Nodos[i].Identificador)
                        {
                            Grupo1.Add(Nodos[i]);
                        }
                        else
                        {
                            Grupo2.Add(Nodos[i]);
                        }
                    }
                }
                string Aux1 = "Grupo 1 -----> NODOS";
                string Aux2 = "Grupo 2 -----> NODOS";
                foreach (Nodo n in Grupo1)
                {
                    Aux1 += "\n" + n.Identificador;
                }
                foreach (Nodo n in Grupo2)
                {
                    Aux2 += "\n" + n.Identificador;
                }
                MessageBox.Show(Aux1);
                MessageBox.Show(Aux2);
            }
            return Bipartito;
        }
        public int[,] GeneraMatrizAdyacencia()
        {
            MatrizAdyacencia = new int[Nodos.Count, Nodos.Count];
            for (int i = 0; i < Nodos.Count; i++)
            {
                for (int j = 0; j < Nodos[i].Relaciones.Count; j++)
                {
                    if (Nodos[i].Relaciones[j].Destino != 0)
                    {
                        MatrizAdyacencia[i, Nodos[i].Relaciones[j].Destino - 1] = 1;
                    }
                }
            }
            return MatrizAdyacencia;
        }

        public int[,] GeneraMatrizPesos()
        {
            MatrizPesos = new int[Nodos.Count, Nodos.Count];
            for (int i = 0; i < Nodos.Count; i++)
            {
                for (int j = 0; j < Nodos[i].Relaciones.Count; j++)
                {
                    if (Nodos[i].Relaciones[j].Destino != 0)
                    {
                        MatrizPesos[i, Nodos[i].Relaciones[j].Destino - 1] = Nodos[i].Relaciones[j].Peso;
                    }
                }
            }
            return MatrizPesos;
        }

        public int EliminaRelacion(Nodo Inicio, Nodo Final)
        {
            int Resultado = 0;

            foreach (Nodo n in Nodos)
            {
                if (n.Identificador == Inicio.Identificador)
                {
                    for (int i = 0; i < n.Relaciones.Count; i++)
                    {
                        if (n.Relaciones[i].Destino == Final.Identificador)
                        {
                            n.Relaciones.Remove(n.Relaciones[i]);
                        }
                    }
                }
            }
            return Resultado;
        }

        public int ObtenGradoEntradaNodo(Nodo n1)
        {
            int GradoSalida = 0;
            foreach (Nodo n in Nodos)
            {
                foreach (Arco a in n.Relaciones)
                {
                    if (a.Destino == n1.Identificador)
                    {
                        GradoSalida++;
                    }
                }
            }
            return GradoSalida;
        }

        public bool TieneRelacion(Nodo n1, Nodo n2)
        {
            bool Tiene = false;

            foreach (Arco a in n2.Relaciones)
            {
                if (a.Destino == n1.Identificador)
                {
                    Tiene = true;
                }
            }
            return Tiene;
        }

        public int ObtenNumeroRelaciones()
        {
            int NumRelaciones = 0;
            foreach (Nodo n in Nodos)
            {
                foreach (Arco r in n.Relaciones)
                {
                    NumRelaciones++;
                }
            }
            return NumRelaciones;
        }

        public void ReseteaVisitas()
        {
            foreach (Nodo n in Nodos)
            {
                foreach (Arco a in n.Relaciones)
                {
                    a.Visitado = false;
                }
            }
        }

        public Arco BuscaRelacion(int Origen, int Destino)
        {
            Arco Relacion = null;
            foreach(Nodo n in Nodos)
            {
                if(n.Identificador == Origen)
                {
                    foreach(Arco r in n.Relaciones)
                    {
                        if(r.Destino == Destino)
                        {
                            Relacion = r;
                            break;
                        }
                    }
                }
            }
            return Relacion;
        }
        public int ObtenNumeroVisitasRestantes()
        {
            int Sum = 0;
            foreach (Nodo n in Nodos)
            {
                foreach (Arco a in n.Relaciones)
                {
                    if (a.Visitado == false)
                    {
                        Sum++;
                    }
                }
            }
            return Sum;
        }

        public int ObtenNumeroVisitasRestantesNodo(int IdNodo)
        {
            Nodo n = Nodos[IdNodo];
            int Sum = 0;

            foreach (Arco a in n.Relaciones)
            {
                if (a.Visitado == false)
                {
                    Sum++;
                }
            }
            return Sum;
        }
    }
}
