using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
namespace Editor_de_Grafos
{
    public partial class Form2 : Form
    {
        public Grafo grafo; 
        Graphics Graficos;
        Pen LineaNodo = new Pen(Color.Black, 2);
        Pen LineaRelaciones = new Pen(Color.Black, 3);
        Bitmap ImagenP;
        public Form2()
        {
            InitializeComponent();
            ImagenP = new Bitmap(this.Width, this.Height);
            Graficos = CreateGraphics();
            Graficos.SmoothingMode = SmoothingMode.AntiAlias;
            grafo = new Grafo();
        }

        public void Reinicio()
        {
            grafo = new Grafo();
            Form2_Paint(this, null);
        }
        private void abrirGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargaGrafo();

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
                    Form2_Paint(this, null);
                }
            }
        }
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics Page = this.CreateGraphics(); //  Creamos un graphics para que podamos dibujar sobre ello el bitmap
                Page.SmoothingMode = SmoothingMode.AntiAlias;
                Graficos = Graphics.FromImage(ImagenP);
                Graficos.Clear(BackColor);
                DibujaNodos();
                Page.DrawImage(ImagenP, 0, 0);
            }

            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }



        public void DibujaNodos()
        {
            double tg, atg;
            int a, b, x, y;
            Point p, p2;
            Pen PlumaFlecha = new Pen(Color.Black, 4);
            PlumaFlecha.StartCap = LineCap.RoundAnchor;
            PlumaFlecha.EndCap = LineCap.ArrowAnchor;
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

        private void cerrarGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reinicio();
        }
    }
}
