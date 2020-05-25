using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic;
using System.IO;
using System.Threading;

/* TipoOperacion
 * -1 = Mover Nodo
 * 0 = Agregar Nodo
 * 1 = Eliminar Nodo
 * 2 = Agregar Relacion
 * 3 = Mover Nodo
 * 4 = Eliminar Relacion
 * 5 = Cambiar Peso Relacion
 */
namespace Editor_de_Grafos
{
    public partial class Form1 : Form
    {
        Grafo grafo;
        Graphics Graficos;
        int TipoOperacion;
        int Identificador;
        bool M = false;
        bool R = false;
        int XRel = 0;
        int YRel = 0;
        int contador;
        Nodo NodoMovimiento;
        Nodo NodoDestino, NodoInicio;
        Pen LineaNodo = new Pen(Color.Black, 2);
        Pen LineaRelaciones = new Pen(Color.Black, 3);
        Bitmap ImagenP;
        bool BanderaIsomorfismo = false;
        int ContEliminados = 0;
        Grafo grafo2;
        Algoritmo Algoritmos = new Algoritmo();
        Form2 VentanaIsomorfismo = new Form2();
        int NodoCamino1 = -1;
        int NodoCamino2 = -1;
        bool banderaCamino = false;
        List<List<int>> Caminos = new List<List<int>>();
        int IdentificadorCamino = -1;
        int IndiceVerticeMostrar = -1;
        bool CaminoCompleto = false;
        List<Arco> ArcoADibujar = null;
        bool BanderaPrim = false;
        bool BanderaDijkstra = false;
        bool BanderaKruskal = false;
        bool BanderaFloyd = false;
        bool BanderaWarshall = false;
        PrimAxel Prim;
        Kruskal k;
        Floyd F;
        DijkstraAxel Dijkstra;
        public Form1()
        {
            InitializeComponent();
            NodoInicio = new Nodo();
            ImagenP = new Bitmap(this.Width, this.Height);
            Graficos = CreateGraphics();
            Graficos.SmoothingMode = SmoothingMode.AntiAlias;
            Reinicio();
        }

        private void AuxMatriz()
        {
            int[,] M1 = new int[4, 4] { { 1, 0, 1, 1 }, { 1, 1, 0, 0 }, { 1, 1, 0, 1 }, { 1, 1, 1, 1 } };
            int[,] M2 = new int[4, 4] { { 1, 1, 0, 0 }, { 1, 0, 0, 1 }, { 0, 0, 0, 1 }, { 1, 1, 0, 0 } };
            int[,] MR = Algoritmos.MultiplicaMatrices(M1, M2);
            string CadAux = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    CadAux += MR[i, j] + " ";
                }
                CadAux += "\n";
            }
            MessageBox.Show(CadAux);
        }
        private void GrafoDirigidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BT_AgregarNodo.Enabled = true;
            BT_EliminarNodo.Enabled = true;
            BT_AñadirRelacion.Enabled = true;
            BT_EliminarRelacion.Enabled = true;
            grafo.Dirigido = true;
            nuevoToolStripMenuItem.Enabled = false;
        }

        private void GrafoNoDirigidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BT_AgregarNodo.Enabled = true;
            BT_EliminarNodo.Enabled = true;
            BT_AñadirRelacion.Enabled = true;
            BT_EliminarRelacion.Enabled = true;
            grafo.Dirigido = false;
            nuevoToolStripMenuItem.Enabled = false;
        }

        public void DibujaNodos()
        {
            double tg, atg;
            int a, b, x, y;
            Point p, p2;
            Pen PlumaFlecha = new Pen(Color.Black, 4);
            PlumaFlecha.StartCap = LineCap.RoundAnchor;
            PlumaFlecha.EndCap = LineCap.ArrowAnchor;
            List<Arco> AuxCaminos = new List<Arco>();
            if (banderaCamino && Caminos.Count != 0 && IdentificadorCamino != -1)
            {
                for (int j = 0; j < Caminos[IdentificadorCamino].Count - 1; j++)
                {
                    Arco arc = new Arco();
                    arc.Origen = Caminos[IdentificadorCamino][j];
                    arc.Destino = Caminos[IdentificadorCamino][j + 1];
                    AuxCaminos.Add(arc);
                }
            }
            foreach (Nodo nodo in grafo.Nodos)
            {
                Point PuntoMedioRecta = new Point();
                String numero = Convert.ToString(nodo.Identificador);
                Font Fuente = new Font("Comic Sans", 16);
                Font FuentePesos = new Font("Arial", 12);
                SolidBrush ColorNumero = new SolidBrush(Color.Red);
                SolidBrush ColorPeso = new SolidBrush(Color.Blue);
                SolidBrush ColorNodo = new SolidBrush(Color.DarkGray);
                Rectangle RectanguloAuxiliar = new Rectangle(nodo.Coordenadas.X, nodo.Coordenadas.Y, 50, 50);
                Graficos.DrawEllipse(LineaNodo, RectanguloAuxiliar);
                Graficos.FillEllipse(ColorNodo, RectanguloAuxiliar);
                if (nodo.Identificador < 10)
                {
                    Graficos.DrawString(numero, Fuente, ColorNumero, nodo.Coordenadas.X + 14, nodo.Coordenadas.Y + 14);
                }
                else
                {
                    Graficos.DrawString(numero, Fuente, ColorNumero, nodo.Coordenadas.X + 9, nodo.Coordenadas.Y + 14);
                }

                foreach (Arco r in nodo.Relaciones)
                {
                    Nodo aux = BuscaNodoInt(r.Destino);
                    if (aux != null)
                    {
                        tg = (double)(BuscaNodoInt(r.Origen).Centro.Y - BuscaNodoInt(r.Destino).Centro.Y) / (BuscaNodoInt(r.Destino).Centro.X - BuscaNodoInt(r.Origen).Centro.X);
                        atg = Math.Atan(tg);
                        a = (int)((50 * .53) * Math.Cos(atg));
                        b = (int)((50 * .53) * Math.Sin(atg));
                        if (BuscaNodoInt(r.Origen).Centro.X < BuscaNodoInt(r.Destino).Centro.X)
                        {
                            a *= -1;
                            b *= -1;
                        }
                        p = new Point(BuscaNodoInt(r.Destino).Centro.X + a, BuscaNodoInt(r.Destino).Centro.Y - b);
                        p2 = new Point(BuscaNodoInt(r.Origen).Centro.X - a, BuscaNodoInt(r.Origen).Centro.Y + b);

                        if (grafo.Dirigido == false)
                        {
                            if (aux.Identificador != r.Origen)
                            {
                                Graficos.DrawLine(LineaRelaciones, p2, p);
                                PuntoMedioRecta.X = (nodo.Centro.X + aux.Centro.X) / 2;
                                PuntoMedioRecta.Y = (nodo.Centro.Y + aux.Centro.Y) / 2;
                                Graficos.DrawString(r.Peso.ToString(), FuentePesos, ColorPeso, PuntoMedioRecta);
                            }
                            else
                            {
                                Graficos.DrawArc(LineaRelaciones, aux.Coordenadas.X - 50 / 6, aux.Coordenadas.Y - 50 / 6,
                                    50 / 2, 50 / 2, 100, 250);
                                Graficos.DrawString(r.Peso.ToString(), FuentePesos, ColorPeso, aux.Centro.X - 30, aux.Centro.Y - 32);
                            }
                        }
                        else
                        {
                            if (aux.Identificador != r.Origen)
                            {
                                Graficos.DrawLine(PlumaFlecha, p2, p);
                                PuntoMedioRecta.X = (nodo.Centro.X + aux.Centro.X) / 2;
                                PuntoMedioRecta.Y = (nodo.Centro.Y + aux.Centro.Y) / 2;
                                Graficos.DrawString(r.Peso.ToString(), FuentePesos, ColorPeso, PuntoMedioRecta);
                            }
                            else
                            {
                                Graficos.DrawArc(PlumaFlecha, aux.Coordenadas.X - 50 / 6, aux.Coordenadas.Y - 50 / 6,
                                    65 / 2, 65 / 2, 100, 250);
                                Graficos.DrawString(r.Peso.ToString(), FuentePesos, ColorPeso, aux.Centro.X - 30, aux.Centro.Y - 32);
                            }
                        }
                    }
                }
            }
            if (banderaCamino)
            {
                //MessageBox.Show("DIBUJANDO ARCO");
                DibujaArco(ArcoADibujar);
                //DibujaCamino(GeneraListaRelacionesCamino(Caminos));
            }
            /*if (CaminoCompleto)
            {
                DibujaCamino(GeneraListaRelacionesCamino(Caminos));
            }*/

        }
        public void DibujaCamino(List<Arco> AuxCaminos)
        {
            Pen Pluma = new Pen(Color.Red, 3);
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 0);
            
            
            for (int i = 0; i < AuxCaminos.Count; i++)
            {

                List<Nodo> Nodos = BuscaNodosRelaciones(AuxCaminos[i].Origen, AuxCaminos[i].Destino);
                if (Nodos.Count == 2)
                {
                    Graficos.DrawLine(Pluma, Nodos[0].Centro, Nodos[1].Centro);
                }
            }
        }

        public void DibujaArco(List<Arco> a)
        {
            if (a != null)
            {
                foreach (Arco ar in a)
                {
                    List<Nodo> Nodos = BuscaNodosRelaciones(ar.Origen, ar.Destino);
                    if (Nodos.Count == 2)
                    {
                        Graficos.DrawLine(new Pen(Color.Red, 3), Nodos[0].Centro, Nodos[1].Centro);
                    }
                }
            }
        }
        public List<Arco> GeneraListaRelacionesCamino(List<List<int>> Caminos)
        {
            List<Arco> AuxCaminos = new List<Arco>();
            for (int j = 0; j < Caminos[IdentificadorCamino].Count - 1; j++)
            {
                Arco arc = new Arco();
                arc.Origen = Caminos[IdentificadorCamino][j];
                arc.Destino = Caminos[IdentificadorCamino][j + 1];
                AuxCaminos.Add(arc);
            }
            return AuxCaminos;
        }

        public List<Arco> GeneraRelacionesUnCamino(List<int> Camino, Grafo G)
        {
            List<Arco> AuxCaminos = new List<Arco>();
            for (int j = 0; j < Camino.Count - 1; j++)
            {
                /*Arco arc = new Arco();
                arc.Origen = Camino[j];
                arc.Destino = Camino[j + 1];*/
                Arco Relacion = G.BuscaRelacion(Camino[j], Camino[j + 1]);
                if (Relacion != null)
                {
                    AuxCaminos.Add(Relacion);
                }
            }
            return AuxCaminos;
        }
        public int ObtenPesoCamino(List<Arco> Camino)
        {
            int Peso = 0;
            foreach (Arco a in Camino)
            {
                Peso += a.Peso;
            }
            return Peso;
        }

        public List<Arco> GeneraListaRelacionesPrim(List<List<int>> Caminos)
        {
            List<Arco> AuxPrim = new List<Arco>();
            for (int i = 0; i < Caminos[IdentificadorCamino].Count - 1; i += 2)
            {
                Arco Arc = new Arco();
                Arc.Origen = Caminos[IdentificadorCamino][i];
                Arc.Destino = Caminos[IdentificadorCamino][i + 1];
                AuxPrim.Add(Arc);
            }
            return AuxPrim;
        }

        public List<Nodo> BuscaNodosRelaciones(int Origen, int Destino)
        {
            List<Nodo> Nodos = new List<Nodo>();

            foreach (Nodo n in grafo.Nodos)
            {
                if (n.Identificador == Origen)
                {
                    Nodos.Add(n);
                    Origen = -1;
                }
                else if (n.Identificador == Destino)
                {
                    Nodos.Add(n);
                    Destino = -1;
                }
            }
            return Nodos;
        }
        private void BT_AgregarNodo_Click(object sender, EventArgs e)
        {
            TipoOperacion = 0;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (TipoOperacion)
            {
                case -1:

                    NodoMovimiento = BuscaNodo(e);
                    if (NodoMovimiento != null)
                    {
                        M = true;
                    }
                    break;
                case 0:
                    Identificador++;
                    Nodo Aux = new Nodo();
                    Aux.AsignarCoordenadas(e.X, e.Y);
                    Aux.Identificador = Identificador;
                    grafo.AgregarNodo(Aux);
                    Form1_Paint(this, null);
                    break;
                case 1:
                    Nodo aux = BuscaNodo(e);
                    if (aux != null)
                    {
                        if (MessageBox.Show("Estas seguro de eliminar el nodo : " + aux.Identificador + " ?", "Eliminar nodo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            grafo.EliminarNodo(aux);
                            Form1_Paint(this, null);
                            Identificador--;
                        }
                    }
                    break;
                case 2: // Agregar Relación
                    NodoInicio = BuscaNodo(e);
                    if (NodoInicio != null)
                    {
                        R = true;
                    }
                    break;
                case 3: // Mover Nodo
                    NodoMovimiento = BuscaNodo(e);
                    M = true;
                    break;
                case 4:
                    Arco Relacion = BuscaRelacion(e);
                    if (Relacion != null)
                    {
                        if (grafo.Dirigido == true)
                        {
                            grafo.EliminaRelacion(BuscaNodoInt(Relacion.Origen), BuscaNodoInt(Relacion.Destino));
                        }
                        else
                        {
                            if (Relacion.Origen != Relacion.Destino)
                            {
                                grafo.EliminaRelacion(BuscaNodoInt(Relacion.Origen), BuscaNodoInt(Relacion.Destino));
                                Arco RelAux = BuscaRelacionNodo(BuscaNodoInt(Relacion.Destino), Relacion.Origen);
                                grafo.EliminaRelacion(BuscaNodoInt(RelAux.Origen), BuscaNodoInt(RelAux.Destino));
                            }
                            else
                            {
                                grafo.EliminaRelacion(BuscaNodoInt(Relacion.Origen), BuscaNodoInt(Relacion.Destino));
                            }

                        }
                        Form1_Paint(this, null);
                    }
                    break;
                case 5:
                    Arco RelacionPeso = BuscaRelacion(e);
                    if (RelacionPeso != null)
                    {
                        int Peso = Convert.ToInt32(Interaction.InputBox("Ingresa el nuevo peso de la relación: " + RelacionPeso.Origen + " - " + RelacionPeso.Destino));
                        if (grafo.Dirigido == true)
                        {
                            RelacionPeso.Peso = Peso;
                        }
                        else
                        {
                            Arco RelacionAuxiliarPeso = BuscaRelacionNodo(BuscaNodoInt(RelacionPeso.Destino), RelacionPeso.Origen);
                            RelacionPeso.Peso = Peso;
                            RelacionAuxiliarPeso.Peso = Peso;
                        }
                    }
                    break;
                case 6:
                    Nodo NodoAux = BuscaNodo(e);
                    if (NodoAux != null)
                    {
                        MessageBox.Show("El grado de salida del nodo es: " + NodoAux.ObtenGradoNodo().ToString() + "\n" + "El grado de entrada del nodo es: " + grafo.ObtenGradoEntradaNodo(NodoAux));
                    }
                    break;
                case 7:
                    if (!banderaCamino)
                    {
                        if (BuscaNodo(e) != null)
                        {
                            NodoCamino1 = BuscaNodo(e).Identificador;
                            LB_NodosSeleccionados.Text = "Nodo Seleccionado:\n" + NodoCamino1;
                            banderaCamino = true;
                            break;
                        }
                    }
                    if (banderaCamino)
                    {
                        if (BuscaNodo(e) != null)
                        {
                            NodoCamino2 = BuscaNodo(e).Identificador;
                            banderaCamino = false;
                            LB_NodosSeleccionados.Text = "Nodos Seleccionados:\n\t\t" + "{" + NodoCamino1 + " , " + NodoCamino2 + "}";
                            TipoOperacion = -1;
                            break;
                        }
                    }
                    break;
            }
        }
        private Arco BuscaRelacionNodo(Nodo n, int Destino)
        {
            Arco RelacionAux = null;
            foreach (Arco a in n.Relaciones)
            {
                if (a.Destino == Destino)
                {
                    RelacionAux = a;
                }
            }
            return RelacionAux;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics Page = this.CreateGraphics(); //  Creamos un graphics para que podamos dibujar sobre ello el bitmap
            Page.SmoothingMode = SmoothingMode.AntiAlias;
            Graficos = Graphics.FromImage(ImagenP);
            Graficos.Clear(BackColor);
            DibujaNodos();
            if (R == true)
            {
                Graficos.DrawLine(LineaRelaciones, NodoInicio.Centro.X, NodoInicio.Centro.Y, XRel, YRel);
            }
            Page.DrawImage(ImagenP, 0, 0);
        }
        private Nodo BuscaNodo(MouseEventArgs e)
        {
            foreach (Nodo nodo in grafo.Nodos)
            {
                if (e.X < nodo.Coordenadas.X + 50 && e.Y < nodo.Coordenadas.Y + 50 && e.X > nodo.Coordenadas.X && e.Y > nodo.Coordenadas.Y)
                {
                    return nodo;
                }
            }
            return null;
        }
        private Nodo BuscaNodoInt(int identificador)
        {
            foreach (Nodo nodo in grafo.Nodos)
            {
                if (nodo.Identificador == identificador)
                {
                    return nodo;
                }
            }
            return null;
        }

        private void BT_EliminarNodo_Click(object sender, EventArgs e)
        {
            TipoOperacion = 1;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            M = false;
            R = false;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (M == true && NodoMovimiento != null)
            {
                NodoMovimiento.AsignarCoordenadas(e.X, e.Y);
                Form1_Paint(this, null);
            }
            else if (R == true && NodoInicio != null)
            {
                NodoDestino = BuscaNodo(e);
                if (NodoDestino != null && NodoDestino.Identificador != NodoInicio.Identificador)
                {
                    if (grafo.Dirigido == false)
                    {
                        NodoInicio.AñadirRelacion(NodoDestino.Identificador, 0);
                        NodoDestino.AñadirRelacion(NodoInicio.Identificador, 0);
                    }
                    else
                    {
                        NodoInicio.AñadirRelacion(NodoDestino.Identificador, 0);
                    }
                    Form1_Paint(this, null);
                    R = false;
                }
                XRel = e.X;
                YRel = e.Y;
                Form1_Paint(this, null);
            }
        }

        private void CerrarGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro que quieres cerrar el grafo?", "Cerrar Grafo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Reinicio();
            }
        }
        private Arco BuscaRelacion(MouseEventArgs e)
        {
            Arco auxAri = null;
            GraphicsPath path = new GraphicsPath();
            foreach (Nodo n in grafo.Nodos)
            {
                foreach (Arco ari in n.Relaciones)
                {
                    path = new GraphicsPath();
                    if (ari.Origen != ari.Destino)
                    {
                        path.AddLine(BuscaNodoInt(ari.Origen).Centro, BuscaNodoInt(ari.Destino).Centro);
                    }
                    else
                    {
                        path.AddArc(BuscaNodoInt(ari.Origen).Coordenadas.X - 50 / 6, BuscaNodoInt(ari.Origen).Coordenadas.Y - 50 / 6,
                                50 / 2, 50 / 2, 100, 250);
                    }
                    if (path.IsOutlineVisible(new Point(e.X, e.Y), LineaRelaciones))
                    {
                        auxAri = ari;
                        break;
                    }
                }
            }
            return auxAri;
        }
        public void Reinicio()
        {
            LB_NodosSeleccionados.Text = "";
            BT_AgregarNodo.Enabled = false;
            BT_EliminarNodo.Enabled = false;
            BT_AñadirRelacion.Enabled = false;
            BT_EliminarRelacion.Enabled = false;
            Identificador = 0;
            TipoOperacion = -1;
            grafo = new Grafo();
            nuevoToolStripMenuItem.Enabled = true;
            Form1_Paint(this, null);
        }

        private void AdyacenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Formato = "Matriz Adyacencia \n";
            int[,] MatrizAd = grafo.GeneraMatrizAdyacencia();
            for (int i = 0; i < MatrizAd.GetLength(0); i++)
            {
                for (int j = 0; j < MatrizAd.GetLength(1); j++)
                {
                    Formato += MatrizAd[i, j].ToString();
                    Formato += "   ";
                }
                Formato += "\n";
            }
            MessageBox.Show(Formato);
        }

        private void PesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Formato = "Matriz Pesos \n";
            int[,] MatrizP = grafo.GeneraMatrizPesos();
            for (int i = 0; i < MatrizP.GetLength(0); i++)
            {
                for (int j = 0; j < MatrizP.GetLength(1); j++)
                {
                    Formato += MatrizP[i, j].ToString();
                    Formato += "   ";
                }
                Formato += "\n";
            }
            MessageBox.Show(Formato);
        }

        private void BT_EliminarRelacion_Click(object sender, EventArgs e)
        {
            TipoOperacion = 4;
        }

        private void BT_MoverNodo_Click(object sender, EventArgs e)
        {
            TipoOperacion = 3;
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (R == true)
            {
                Nodo Nodo = BuscaNodo(e);
                if (Nodo != null)
                {
                    Nodo.AñadirRelacion(Nodo.Identificador, 0);
                    Form1_Paint(this, null);
                }
            }
        }
        private void BT_CambiarPesoRel_Click(object sender, EventArgs e)
        {
            TipoOperacion = 5;
        }

        private void guardarGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> CadenaInformacion = new List<string>();
                if (grafo.Dirigido == true)
                {
                    CadenaInformacion.Add("D");
                }
                else
                {
                    CadenaInformacion.Add("SD");
                }
                foreach (Nodo n in grafo.Nodos)
                {
                    string Aux = "N/" + n.Identificador + "/" + n.Coordenadas.X + "/" + n.Coordenadas.Y;
                    CadenaInformacion.Add(Aux);
                    foreach (Arco r in n.Relaciones)
                    {
                        string AuxRel = "R/" + r.Origen + "/" + r.Destino + "/" + r.Peso;
                        CadenaInformacion.Add(AuxRel);
                    }
                }
                SaveFileDialog VentanaGuardar = new SaveFileDialog();
                VentanaGuardar.Filter = "Grafo (*.gfo)|*.gfo";
                if (VentanaGuardar.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter Escritor = new StreamWriter(VentanaGuardar.FileName))
                    {
                        foreach (string C in CadenaInformacion)
                        {
                            Escritor.WriteLine(C);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void abrirGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Reinicio();
                BT_AgregarNodo.Enabled = true;
                BT_EliminarNodo.Enabled = true;
                BT_AñadirRelacion.Enabled = true;
                BT_EliminarRelacion.Enabled = true;
                cargaGrafo();
            }
            catch
            {

            }
        }

        private void cargaGrafo()
        {
            string[] CadenaInformacion;
            OpenFileDialog VentanaAbrir = new OpenFileDialog();
            VentanaAbrir.Filter = "Grafo (*.gfo)|*.gfo";
            if (VentanaAbrir.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader Lector = new StreamReader(VentanaAbrir.FileName))
                {
                    while (!Lector.EndOfStream)
                    {
                        string Aux = Lector.ReadLine();
                        if (Aux == "D")
                        {
                            grafo.Dirigido = true;
                        }
                        else if (Aux == "ND")
                        {
                            grafo.Dirigido = false;
                        }
                        CadenaInformacion = Aux.Split('/');
                        if (Aux[0] == 'N')
                        {
                            Nodo NuevoNodo = new Nodo();
                            NuevoNodo.Identificador = Convert.ToInt32(CadenaInformacion[1]);
                            NuevoNodo.AsignarCoordenadas(Convert.ToInt32(CadenaInformacion[2]), Convert.ToInt32(CadenaInformacion[3]));
                            grafo.Nodos.Add(NuevoNodo);
                        }
                        else if (Aux[0] == 'R')
                        {
                            Nodo AuxNodo = BuscaNodoInt(Convert.ToInt32(CadenaInformacion[1]));
                            Arco Relacion = new Arco();
                            AuxNodo.AñadirRelacion(Convert.ToInt32(CadenaInformacion[2]), Convert.ToInt32(CadenaInformacion[3]));
                        }
                    }
                    Identificador = grafo.Nodos.Count;
                    Form1_Paint(this, null);
                }
            }
        }
        private void esBipartitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] Km = Algoritmos.EsBiparitoKM(grafo.Nodos, grafo.GeneraMatrizAdyacencia());
            if (Km[0] != 0 && Km[1] != 0)
            {
                MessageBox.Show("El grafo es bipartito" + "\nK: " + Km[0] + "\nm: " + Km[1]);
            }
            else
            {
                MessageBox.Show("El grafo no es bipartito");
            }
        }

        private void esCompletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grafo.EsCompleto())
            {
                MessageBox.Show("El grafo es completo");
            }
            else
            {
                MessageBox.Show("El grafo no es completo");
            }
        }

        private void esCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Count = 0;
            if (grafo.Dirigido == true)
            {
                if (grafo.EsCiclo())
                {
                    MessageBox.Show("El grafo es ciclico");
                }
                else
                {
                    MessageBox.Show("El grafo no es ciclico");
                }
            }
            else if (grafo.Dirigido == false)
            {
                bool[] Res = new bool[grafo.Nodos.Count];
                for (int i = 0; i < grafo.Nodos.Count; i++)
                {
                    Res[i] = Algoritmos.GrafoContieneCiclo(i, i, grafo.GeneraMatrizAdyacencia(), grafo.Nodos.Count);
                }
                bool Ciclico = true;
                foreach (bool b in Res)
                {
                    if (b == false)
                    {
                        Ciclico = false;
                        break;
                    }
                }
                if (Ciclico)
                {
                    MessageBox.Show("El grafo es ciclico ");
                }
                else
                {
                    MessageBox.Show("El grafo no es ciclico");
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TipoOperacion = 6;
        }

        private void gradoDelGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Suma = 0;
            foreach (Nodo n in grafo.Nodos)
            {
                Suma += n.ObtenGradoNodo();
            }
            MessageBox.Show("El grado del grafo es: " + Suma);
        }

        private void BT_Isomorfismo_Click(object sender, EventArgs e)
        {
            VentanaIsomorfismo.Show();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafo2 = VentanaIsomorfismo.grafo;
            if (grafo2.Nodos.Count > 0)
            {
                if (Algoritmos.AlgoritmoManualBotello(grafo, grafo2))
                {
                    MessageBox.Show("Los grafos son Isomorfos entre si");
                }
                else
                {
                    MessageBox.Show("Los grafos no son isomorfos entre si");
                }
            }
            else
            {
                MessageBox.Show("El grafo no está cargado");
            }
        }

        private void matrizTranspuestaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafo2 = VentanaIsomorfismo.grafo;
            if (grafo2.Nodos.Count > 0)
            {
                if (Algoritmos.IsomorfismoMatrizPermutada(grafo, grafo2))
                {
                    MessageBox.Show("Los grafos son isomorficos entre si según el algoritmo de la matriz transpuesta");
                }
                else
                {
                    MessageBox.Show("Los grafos no son isomorficos entre si según el algoritmo de la matriz transpuesta");
                }
            }
            else
            {
                MessageBox.Show("El grafo no está cargado");
            }
        }

        private void algoritmoFuerzaBrutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafo2 = VentanaIsomorfismo.grafo;
            if (grafo2.Nodos.Count > 0)
            {
                if ((grafo.ObtenNumeroRelaciones() == grafo2.ObtenNumeroRelaciones()) && (grafo.Nodos.Count == grafo2.Nodos.Count))
                {
                    bool Respuesta = Algoritmos.FuerzaBruta(grafo.GeneraMatrizAdyacencia(), grafo2.GeneraMatrizAdyacencia(), grafo.Nodos.Count);
                    if (Respuesta)
                    {
                        MessageBox.Show("Los grafos son isomorficos entre si según el algoritmo de fuerza bruta");
                    }
                    else
                    {
                        MessageBox.Show("Los grafos no son isomorficos entre si según el algoritmo de fuerza bruta");
                    }
                }
                else
                {
                    MessageBox.Show("El número de relaciones o el número de nodos de los 2 grafos no son iguales");
                }

            }
            else
            {
                MessageBox.Show("El grafo no ha sido cargado");
            }
        }

        private void caminosSimplesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (NodoCamino1 != -1 || NodoCamino2 != -1)
                {
                    Caminos = Algoritmos.CaminosSimples(NodoCamino1 - 1, NodoCamino2 - 1, grafo.GeneraMatrizAdyacencia(), grafo.Nodos.Count);
                    if (Caminos.Count != 0)
                    {
                        for (int i = 0; i < Caminos.Count; i++)
                        {
                            for (int j = 0; j < Caminos[i].Count; j++)
                            {
                                Caminos[i][j] = Caminos[i][j] + 1;
                            }
                        }
                        PintaCamino();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron caminos :(");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor selecciona los nodos");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }


        public void PintaCamino()
        {
            int Delay = 0;
            string CadAux = "";
            banderaCamino = true;
            List<Arco> Relaciones = new List<Arco>();
            foreach (List<int> l in Caminos)
            {
                ArcoADibujar = new List<Arco>();
                IdentificadorCamino++;
                if (BanderaKruskal || BanderaWarshall)
                {
                    Relaciones = GeneraListaRelacionesPrim(Caminos);
                }
                else
                {
                    Relaciones = GeneraListaRelacionesCamino(Caminos);
                }
                foreach (Arco a in Relaciones)
                {

                    //MessageBox.Show("Relación de: " + a.Origen + " a : " + a.Destino);
                    ArcoADibujar.Add(a);
                    Form1_Paint(this, null);
                    while (Delay < 140000000)
                    {
                        Delay++;
                    }
                    Delay = 0;
                }
                if (BanderaDijkstra)
                {
                    CadAux += "RUTA MÁS CORTA CON DIJKSTRA\n\n\t";
                }
                if (BanderaKruskal)
                {
                    CadAux += "***********ARBOL DE COSTO MÍNIMO CON KRUSKAL**************\n\n\t";
                }
                if (BanderaFloyd)
                {
                    CadAux += "********RUTA MÁS CORTA CON FLOYD*******\n\n\t";
                }
                if (BanderaWarshall)
                {
                    CadAux += "\t*******NODOS CONECTADOS POR LA CERRADURA TRANSITIVA OBTENIDA EN WARSHALL************\n\n\t\t";
                    BanderaWarshall = false;
                }

                for (int i = 0; i < l.Count - 1; i++)
                {
                    CadAux += l[i] + "-";
                }
                CadAux += l[l.Count - 1];
                if (BanderaDijkstra)
                {
                    int Costo = 0;
                    int[,] matrizPesos = grafo.GeneraMatrizPesos();
                    foreach (Arco a in Relaciones)
                    {
                        Costo += matrizPesos[a.Origen - 1, a.Destino - 1];
                    }
                    CadAux += "\n\nCon un costo de: " + Costo;

                }
                if (BanderaKruskal)
                {
                    CadAux += "\n\t Costo total del árbol: " + k.CostoMinimo;
                    BanderaKruskal = false;
                }
                if (BanderaFloyd)
                {
                    CadAux += "\n\t Costo total del camino: " + ObtenPesoCamino(GeneraRelacionesUnCamino(Caminos[0], grafo));
                    BanderaFloyd = false;
                }
                MessageBox.Show(CadAux);
                if (BanderaPrim)
                {
                    string CadPrim = "*********************PRIM*******************\n" +
                        "\tCosto total del árbol: " + Prim.CostoTotal;

                    MessageBox.Show(CadPrim);
                    BanderaPrim = false;
                }
                CadAux = "";
            }
            BanderaDijkstra = false;
            ArcoADibujar = new List<Arco>();
            banderaCamino = false;
            IdentificadorCamino = -1;
        }

        private void circuitoEulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (NodoCamino1 != -1 && NodoCamino2 != -1)
                {
                    List<List<int>> CaminosEuler = new List<List<int>>();
                    Algoritmos.CaminoEuler(grafo, NodoCamino1, NodoCamino2, CaminosEuler);
                    if (CaminosEuler.Count != 0)
                    {
                        Caminos = CaminosEuler;
                        banderaCamino = true;
                        string CadAux = "";
                        PintaCamino();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron Caminos de Euler");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccciona los nodos(Deben de ser los nodos con grado impar)");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }

        private void BT_SeleccionarNodos_Click(object sender, EventArgs e)
        {
            TipoOperacion = 7;
        }

        private void circuitoEulerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (NodoCamino1 != -1)
                {
                    List<List<int>> CircuitosEuler = new List<List<int>>();
                    Algoritmos.CircuitoEuler(grafo, NodoCamino1, CircuitosEuler);
                    if (CircuitosEuler.Count != 0)
                    {
                        Caminos = CircuitosEuler;
                        banderaCamino = true;
                        string CadAux = "";
                        PintaCamino();
                        banderaCamino = false;
                        Form1_Paint(this, null);
                        IdentificadorCamino = -1;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron Circuitos de Euler");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor selecciona un nodo");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void dijkstraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] Pesos = grafo.GeneraMatrizPesos();
            if (NodoCamino1 != -1)
            {
                Dijkstra = new DijkstraAxel(grafo.Nodos.Count, Pesos, NodoCamino1 - 1);
                Caminos = Dijkstra.ALgoritmoDIjkstra();
                GeneraCaminoDijkstra();
                BanderaDijkstra = true;
                if (Caminos.Count != 0)
                {
                    PintaCamino();
                }
            }
            else
            {
                MessageBox.Show("Tienes que escoger un nodo primero");
            }
        }

        private void primToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NodoCamino1 != -1)
            {
                Prim = new PrimAxel(grafo.Nodos.Count, grafo.GeneraMatrizPesos(), NodoCamino1 - 1);
                Caminos.Clear();
                Caminos.Add(new List<int>());
                Caminos[0] = new List<int>();
                Caminos[0] = Prim.Prim();
                if (Caminos[0].Count != 0)
                {
                    BanderaPrim = true;
                    PintaCamino();
                }
            }
            else
            {
                MessageBox.Show("Tienes que escoger un nodo primero");
            }

        }

        private void kruskalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BanderaKruskal = true;
            k = new Kruskal(grafo.Nodos.Count, grafo.GeneraMatrizPesos());
            Caminos.Clear();
            Caminos.Add(new List<int>());
            Caminos[0] = k.kruskalMST();
            if (Caminos[0].Count > 0)
            {
                PintaCamino();
            }
            //kruskal.kruskalMST(grafo.GeneraMatrizPesos(), grafo.Nodos.Count);
        }

        private void floydToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BanderaFloyd = true;
            if (NodoCamino1 != -1 || NodoCamino2 != -1)
            {
                Caminos.Clear();
                F = new Floyd(grafo.Nodos.Count, grafo.GeneraMatrizPesos());
                Caminos = Algoritmos.CaminosSimples(NodoCamino1 - 1, NodoCamino2 - 1, grafo.GeneraMatrizAdyacencia(), grafo.Nodos.Count);
                if (Caminos.Count > 0)
                {
                    GeneraCaminoFloyd();
                    if (Caminos[0].Count > 0)
                    {
                        PintaCamino();
                    }
                }
                else
                {
                    MessageBox.Show("No hay camino");
                }
            }
            else
            {
                MessageBox.Show("Primero tienes que escoger los nodos");
            }
        }
        public void GeneraCaminoFloyd()
        {
            List<int> CaminoAmostrar = new List<int>();
            int Costo = F.BuscaPesoCaminoMasCorto(NodoCamino1 - 1, NodoCamino2 - 1);
            FormateaCaminos(Caminos);
            foreach (List<int> c in Caminos)
            {
                List<Arco> Camino = GeneraRelacionesUnCamino(c, grafo);
                int Peso = ObtenPesoCamino(Camino);
                if (Peso == Costo)
                {
                    CaminoAmostrar = c;
                    break;
                }
            }
            if (CaminoAmostrar.Count != 0)
            {
                Caminos.Clear();
                Caminos.Add(CaminoAmostrar);
            }
        }
        public void GeneraCaminoDijkstra()
        {
            Caminos.Clear();
            int[] AuxDist = Dijkstra.Distancias;
            /*foreach(int i in AuxDist)
            {
                MessageBox.Show("Distancia: " + i);
            }*/
            List<List<int>> ListaAuxiliar = new List<List<int>>();
            for(int i = 0; i < grafo.Nodos.Count; i++)
            {
                //MessageBox.Show("Caminos del nodo: " + (i + 1));
                ListaAuxiliar = Algoritmos.CaminosSimples(NodoCamino1 - 1, i, grafo.GeneraMatrizAdyacencia(), grafo.Nodos.Count);
                FormateaCaminos(ListaAuxiliar);
                //MessageBox.Show(ListaAuxiliar.Count.ToString());
                if (ListaAuxiliar.Count > 0)
                {
                    foreach (List<int> c in ListaAuxiliar)
                    {
                        List<Arco> Camino = GeneraRelacionesUnCamino(c, grafo);

                        int peso = ObtenPesoCamino(Camino);
                        //MessageBox.Show("PESO: " + peso + " AuxDist: " + AuxDist[i] + "en I:" + i);
                        
                        //MessageBox.Show("PESO: " + peso);
                        if (peso == AuxDist[i])
                        {
                            //MessageBox.Show("Agregando camino de nodo: " + (i + 1) + " con peso de: " + peso);
                            //MessageBox.Show("Estos pesos concuerdan: " + peso);
                            Caminos.Add(c);
                            break;
                        }
                        
                    }
                }
            }
        }
        public void FormateaCaminos(List<List<int>> Caminos)
        {
            if (Caminos.Count != 0)
            {
                for (int i = 0; i < Caminos.Count; i++)
                {
                    for (int j = 0; j < Caminos[i].Count; j++)
                    {
                        Caminos[i][j] = Caminos[i][j] + 1;
                    }
                }
            }
        }

        private void warshallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BanderaWarshall = true;
            Caminos.Clear();
            Caminos.Add(new List<int>());
            Warshall W = new Warshall(grafo.GeneraMatrizAdyacencia());
            W.CreaCerraduraTransitivaWarshall();
            for(int i = 0; i < grafo.Nodos.Count; i++)
            {
                for(int j = 0; j < grafo.Nodos.Count; j++)
                {
                    if(W.MR[i,j] == 1)
                    {
                        if(grafo.BuscaRelacion(i + 1 , j + 1) != null)
                        {
                            Caminos[0].Add(i + 1);
                            Caminos[0].Add(j + 1);
                        }
                    }
                }
            }
            W.ImprimeCerraduraTransitiva();
            if (Caminos[0].Count > 0) 
            {
                PintaCamino();
            }

        }

        private void BT_AñadirRelacion_Click(object sender, EventArgs e)
        {
            TipoOperacion = 2;
        }
    }
}
