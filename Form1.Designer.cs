namespace Editor_de_Grafos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grafoDirigidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grafoNoDirigidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adyacenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esBipartitoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esCompletoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esCicloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propiedadesDelGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradoDelGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmosIsomorfismoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrizTranspuestaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmoFuerzaBrutaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caminosCircuitosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caminosSimplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circuitoEulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circuitoEulerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmos4o5toParcialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dijkstraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floydToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warshallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kruskalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BT_AgregarNodo = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BT_EliminarNodo = new System.Windows.Forms.Button();
            this.BT_AñadirRelacion = new System.Windows.Forms.Button();
            this.BT_EliminarRelacion = new System.Windows.Forms.Button();
            this.BT_MoverNodo = new System.Windows.Forms.Button();
            this.BT_CambiarPesoRel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BT_Isomorfismo = new System.Windows.Forms.Button();
            this.BT_SeleccionarNodos = new System.Windows.Forms.Button();
            this.LB_NodosSeleccionados = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirGrafoToolStripMenuItem,
            this.guardarGrafoToolStripMenuItem,
            this.cerrarGrafoToolStripMenuItem,
            this.matrizToolStripMenuItem,
            this.esBipartitoToolStripMenuItem,
            this.esCompletoToolStripMenuItem,
            this.esCicloToolStripMenuItem,
            this.propiedadesDelGrafoToolStripMenuItem,
            this.algoritmosIsomorfismoToolStripMenuItem,
            this.caminosCircuitosToolStripMenuItem,
            this.algoritmos4o5toParcialToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1230, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grafoDirigidoToolStripMenuItem,
            this.grafoNoDirigidoToolStripMenuItem});
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // grafoDirigidoToolStripMenuItem
            // 
            this.grafoDirigidoToolStripMenuItem.Name = "grafoDirigidoToolStripMenuItem";
            this.grafoDirigidoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.grafoDirigidoToolStripMenuItem.Text = "Grafo dirigido";
            this.grafoDirigidoToolStripMenuItem.Click += new System.EventHandler(this.GrafoDirigidoToolStripMenuItem_Click);
            // 
            // grafoNoDirigidoToolStripMenuItem
            // 
            this.grafoNoDirigidoToolStripMenuItem.Name = "grafoNoDirigidoToolStripMenuItem";
            this.grafoNoDirigidoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.grafoNoDirigidoToolStripMenuItem.Text = "Grafo no dirigido";
            this.grafoNoDirigidoToolStripMenuItem.Click += new System.EventHandler(this.GrafoNoDirigidoToolStripMenuItem_Click);
            // 
            // abrirGrafoToolStripMenuItem
            // 
            this.abrirGrafoToolStripMenuItem.Name = "abrirGrafoToolStripMenuItem";
            this.abrirGrafoToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.abrirGrafoToolStripMenuItem.Text = "Abrir Grafo";
            this.abrirGrafoToolStripMenuItem.Click += new System.EventHandler(this.abrirGrafoToolStripMenuItem_Click);
            // 
            // guardarGrafoToolStripMenuItem
            // 
            this.guardarGrafoToolStripMenuItem.Name = "guardarGrafoToolStripMenuItem";
            this.guardarGrafoToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.guardarGrafoToolStripMenuItem.Text = "Guardar Grafo";
            this.guardarGrafoToolStripMenuItem.Click += new System.EventHandler(this.guardarGrafoToolStripMenuItem_Click);
            // 
            // cerrarGrafoToolStripMenuItem
            // 
            this.cerrarGrafoToolStripMenuItem.Name = "cerrarGrafoToolStripMenuItem";
            this.cerrarGrafoToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.cerrarGrafoToolStripMenuItem.Text = "Cerrar Grafo";
            this.cerrarGrafoToolStripMenuItem.Click += new System.EventHandler(this.CerrarGrafoToolStripMenuItem_Click);
            // 
            // matrizToolStripMenuItem
            // 
            this.matrizToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adyacenciaToolStripMenuItem,
            this.pesosToolStripMenuItem});
            this.matrizToolStripMenuItem.Name = "matrizToolStripMenuItem";
            this.matrizToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.matrizToolStripMenuItem.Text = "Matriz";
            // 
            // adyacenciaToolStripMenuItem
            // 
            this.adyacenciaToolStripMenuItem.Name = "adyacenciaToolStripMenuItem";
            this.adyacenciaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.adyacenciaToolStripMenuItem.Text = "Adyacencia";
            this.adyacenciaToolStripMenuItem.Click += new System.EventHandler(this.AdyacenciaToolStripMenuItem_Click);
            // 
            // pesosToolStripMenuItem
            // 
            this.pesosToolStripMenuItem.Name = "pesosToolStripMenuItem";
            this.pesosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pesosToolStripMenuItem.Text = "Pesos";
            this.pesosToolStripMenuItem.Click += new System.EventHandler(this.PesosToolStripMenuItem_Click);
            // 
            // esBipartitoToolStripMenuItem
            // 
            this.esBipartitoToolStripMenuItem.Name = "esBipartitoToolStripMenuItem";
            this.esBipartitoToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.esBipartitoToolStripMenuItem.Text = "EsBipartito";
            this.esBipartitoToolStripMenuItem.Click += new System.EventHandler(this.esBipartitoToolStripMenuItem_Click);
            // 
            // esCompletoToolStripMenuItem
            // 
            this.esCompletoToolStripMenuItem.Name = "esCompletoToolStripMenuItem";
            this.esCompletoToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.esCompletoToolStripMenuItem.Text = "EsCompleto";
            this.esCompletoToolStripMenuItem.Click += new System.EventHandler(this.esCompletoToolStripMenuItem_Click);
            // 
            // esCicloToolStripMenuItem
            // 
            this.esCicloToolStripMenuItem.Name = "esCicloToolStripMenuItem";
            this.esCicloToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.esCicloToolStripMenuItem.Text = "EsCiclo";
            this.esCicloToolStripMenuItem.Click += new System.EventHandler(this.esCicloToolStripMenuItem_Click);
            // 
            // propiedadesDelGrafoToolStripMenuItem
            // 
            this.propiedadesDelGrafoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gradoDelGrafoToolStripMenuItem});
            this.propiedadesDelGrafoToolStripMenuItem.Name = "propiedadesDelGrafoToolStripMenuItem";
            this.propiedadesDelGrafoToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.propiedadesDelGrafoToolStripMenuItem.Text = "Propiedades del Grafo";
            // 
            // gradoDelGrafoToolStripMenuItem
            // 
            this.gradoDelGrafoToolStripMenuItem.Name = "gradoDelGrafoToolStripMenuItem";
            this.gradoDelGrafoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.gradoDelGrafoToolStripMenuItem.Text = "Grado del grafo";
            this.gradoDelGrafoToolStripMenuItem.Click += new System.EventHandler(this.gradoDelGrafoToolStripMenuItem_Click);
            // 
            // algoritmosIsomorfismoToolStripMenuItem
            // 
            this.algoritmosIsomorfismoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.matrizTranspuestaToolStripMenuItem,
            this.algoritmoFuerzaBrutaToolStripMenuItem});
            this.algoritmosIsomorfismoToolStripMenuItem.Name = "algoritmosIsomorfismoToolStripMenuItem";
            this.algoritmosIsomorfismoToolStripMenuItem.Size = new System.Drawing.Size(148, 20);
            this.algoritmosIsomorfismoToolStripMenuItem.Text = "Algoritmos Isomorfismo";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.manualToolStripMenuItem.Text = "Manual Grafos";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // matrizTranspuestaToolStripMenuItem
            // 
            this.matrizTranspuestaToolStripMenuItem.Name = "matrizTranspuestaToolStripMenuItem";
            this.matrizTranspuestaToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.matrizTranspuestaToolStripMenuItem.Text = "Matriz Transpuesta";
            this.matrizTranspuestaToolStripMenuItem.Click += new System.EventHandler(this.matrizTranspuestaToolStripMenuItem_Click);
            // 
            // algoritmoFuerzaBrutaToolStripMenuItem
            // 
            this.algoritmoFuerzaBrutaToolStripMenuItem.Name = "algoritmoFuerzaBrutaToolStripMenuItem";
            this.algoritmoFuerzaBrutaToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.algoritmoFuerzaBrutaToolStripMenuItem.Text = "Algoritmo Fuerza Bruta";
            this.algoritmoFuerzaBrutaToolStripMenuItem.Click += new System.EventHandler(this.algoritmoFuerzaBrutaToolStripMenuItem_Click);
            // 
            // caminosCircuitosToolStripMenuItem
            // 
            this.caminosCircuitosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caminosSimplesToolStripMenuItem,
            this.circuitoEulerToolStripMenuItem,
            this.circuitoEulerToolStripMenuItem1});
            this.caminosCircuitosToolStripMenuItem.Name = "caminosCircuitosToolStripMenuItem";
            this.caminosCircuitosToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.caminosCircuitosToolStripMenuItem.Text = "Caminos/Circuitos";
            // 
            // caminosSimplesToolStripMenuItem
            // 
            this.caminosSimplesToolStripMenuItem.Name = "caminosSimplesToolStripMenuItem";
            this.caminosSimplesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.caminosSimplesToolStripMenuItem.Text = "Caminos Simples";
            this.caminosSimplesToolStripMenuItem.Click += new System.EventHandler(this.caminosSimplesToolStripMenuItem_Click);
            // 
            // circuitoEulerToolStripMenuItem
            // 
            this.circuitoEulerToolStripMenuItem.Name = "circuitoEulerToolStripMenuItem";
            this.circuitoEulerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.circuitoEulerToolStripMenuItem.Text = "Camino Euler";
            this.circuitoEulerToolStripMenuItem.Click += new System.EventHandler(this.circuitoEulerToolStripMenuItem_Click);
            // 
            // circuitoEulerToolStripMenuItem1
            // 
            this.circuitoEulerToolStripMenuItem1.Name = "circuitoEulerToolStripMenuItem1";
            this.circuitoEulerToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.circuitoEulerToolStripMenuItem1.Text = "Circuito_Euler";
            this.circuitoEulerToolStripMenuItem1.Click += new System.EventHandler(this.circuitoEulerToolStripMenuItem1_Click);
            // 
            // algoritmos4o5toParcialToolStripMenuItem
            // 
            this.algoritmos4o5toParcialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dijkstraToolStripMenuItem,
            this.floydToolStripMenuItem,
            this.warshallToolStripMenuItem,
            this.primToolStripMenuItem,
            this.kruskalToolStripMenuItem});
            this.algoritmos4o5toParcialToolStripMenuItem.Name = "algoritmos4o5toParcialToolStripMenuItem";
            this.algoritmos4o5toParcialToolStripMenuItem.Size = new System.Drawing.Size(154, 20);
            this.algoritmos4o5toParcialToolStripMenuItem.Text = "Algoritmos 4o/5to Parcial";
            // 
            // dijkstraToolStripMenuItem
            // 
            this.dijkstraToolStripMenuItem.Name = "dijkstraToolStripMenuItem";
            this.dijkstraToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dijkstraToolStripMenuItem.Text = "Dijkstra";
            this.dijkstraToolStripMenuItem.Click += new System.EventHandler(this.dijkstraToolStripMenuItem_Click);
            // 
            // floydToolStripMenuItem
            // 
            this.floydToolStripMenuItem.Name = "floydToolStripMenuItem";
            this.floydToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.floydToolStripMenuItem.Text = "Floyd";
            this.floydToolStripMenuItem.Click += new System.EventHandler(this.floydToolStripMenuItem_Click);
            // 
            // warshallToolStripMenuItem
            // 
            this.warshallToolStripMenuItem.Name = "warshallToolStripMenuItem";
            this.warshallToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.warshallToolStripMenuItem.Text = "Warshall";
            // 
            // primToolStripMenuItem
            // 
            this.primToolStripMenuItem.Name = "primToolStripMenuItem";
            this.primToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.primToolStripMenuItem.Text = "Prim";
            this.primToolStripMenuItem.Click += new System.EventHandler(this.primToolStripMenuItem_Click);
            // 
            // kruskalToolStripMenuItem
            // 
            this.kruskalToolStripMenuItem.Name = "kruskalToolStripMenuItem";
            this.kruskalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kruskalToolStripMenuItem.Text = "Kruskal";
            this.kruskalToolStripMenuItem.Click += new System.EventHandler(this.kruskalToolStripMenuItem_Click);
            // 
            // BT_AgregarNodo
            // 
            this.BT_AgregarNodo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BT_AgregarNodo.BackColor = System.Drawing.Color.Transparent;
            this.BT_AgregarNodo.Image = ((System.Drawing.Image)(resources.GetObject("BT_AgregarNodo.Image")));
            this.BT_AgregarNodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_AgregarNodo.Location = new System.Drawing.Point(12, 27);
            this.BT_AgregarNodo.Name = "BT_AgregarNodo";
            this.BT_AgregarNodo.Size = new System.Drawing.Size(24, 27);
            this.BT_AgregarNodo.TabIndex = 1;
            this.toolTip1.SetToolTip(this.BT_AgregarNodo, "Agregar Nodo");
            this.BT_AgregarNodo.UseVisualStyleBackColor = false;
            this.BT_AgregarNodo.Click += new System.EventHandler(this.BT_AgregarNodo_Click);
            // 
            // BT_EliminarNodo
            // 
            this.BT_EliminarNodo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BT_EliminarNodo.BackColor = System.Drawing.Color.Transparent;
            this.BT_EliminarNodo.Image = ((System.Drawing.Image)(resources.GetObject("BT_EliminarNodo.Image")));
            this.BT_EliminarNodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_EliminarNodo.Location = new System.Drawing.Point(42, 27);
            this.BT_EliminarNodo.Name = "BT_EliminarNodo";
            this.BT_EliminarNodo.Size = new System.Drawing.Size(24, 27);
            this.BT_EliminarNodo.TabIndex = 2;
            this.toolTip1.SetToolTip(this.BT_EliminarNodo, "Eliminar Nodo");
            this.BT_EliminarNodo.UseVisualStyleBackColor = false;
            this.BT_EliminarNodo.Click += new System.EventHandler(this.BT_EliminarNodo_Click);
            // 
            // BT_AñadirRelacion
            // 
            this.BT_AñadirRelacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BT_AñadirRelacion.BackColor = System.Drawing.Color.Transparent;
            this.BT_AñadirRelacion.Image = ((System.Drawing.Image)(resources.GetObject("BT_AñadirRelacion.Image")));
            this.BT_AñadirRelacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_AñadirRelacion.Location = new System.Drawing.Point(72, 27);
            this.BT_AñadirRelacion.Name = "BT_AñadirRelacion";
            this.BT_AñadirRelacion.Size = new System.Drawing.Size(24, 27);
            this.BT_AñadirRelacion.TabIndex = 3;
            this.toolTip1.SetToolTip(this.BT_AñadirRelacion, "Añadir Relacion");
            this.BT_AñadirRelacion.UseVisualStyleBackColor = false;
            this.BT_AñadirRelacion.Click += new System.EventHandler(this.BT_AñadirRelacion_Click);
            // 
            // BT_EliminarRelacion
            // 
            this.BT_EliminarRelacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BT_EliminarRelacion.BackColor = System.Drawing.Color.Transparent;
            this.BT_EliminarRelacion.Image = ((System.Drawing.Image)(resources.GetObject("BT_EliminarRelacion.Image")));
            this.BT_EliminarRelacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_EliminarRelacion.Location = new System.Drawing.Point(102, 27);
            this.BT_EliminarRelacion.Name = "BT_EliminarRelacion";
            this.BT_EliminarRelacion.Size = new System.Drawing.Size(24, 27);
            this.BT_EliminarRelacion.TabIndex = 4;
            this.toolTip1.SetToolTip(this.BT_EliminarRelacion, "Eliminar Relacion");
            this.BT_EliminarRelacion.UseVisualStyleBackColor = false;
            this.BT_EliminarRelacion.Click += new System.EventHandler(this.BT_EliminarRelacion_Click);
            // 
            // BT_MoverNodo
            // 
            this.BT_MoverNodo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BT_MoverNodo.BackColor = System.Drawing.Color.Transparent;
            this.BT_MoverNodo.Image = ((System.Drawing.Image)(resources.GetObject("BT_MoverNodo.Image")));
            this.BT_MoverNodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_MoverNodo.Location = new System.Drawing.Point(132, 27);
            this.BT_MoverNodo.Name = "BT_MoverNodo";
            this.BT_MoverNodo.Size = new System.Drawing.Size(24, 27);
            this.BT_MoverNodo.TabIndex = 5;
            this.toolTip1.SetToolTip(this.BT_MoverNodo, "Mover Nodo");
            this.BT_MoverNodo.UseVisualStyleBackColor = false;
            this.BT_MoverNodo.Click += new System.EventHandler(this.BT_MoverNodo_Click);
            // 
            // BT_CambiarPesoRel
            // 
            this.BT_CambiarPesoRel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BT_CambiarPesoRel.BackColor = System.Drawing.Color.Transparent;
            this.BT_CambiarPesoRel.Image = ((System.Drawing.Image)(resources.GetObject("BT_CambiarPesoRel.Image")));
            this.BT_CambiarPesoRel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_CambiarPesoRel.Location = new System.Drawing.Point(162, 27);
            this.BT_CambiarPesoRel.Name = "BT_CambiarPesoRel";
            this.BT_CambiarPesoRel.Size = new System.Drawing.Size(24, 27);
            this.BT_CambiarPesoRel.TabIndex = 6;
            this.toolTip1.SetToolTip(this.BT_CambiarPesoRel, "Cambiar Peso Relacion");
            this.BT_CambiarPesoRel.UseVisualStyleBackColor = false;
            this.BT_CambiarPesoRel.Click += new System.EventHandler(this.BT_CambiarPesoRel_Click);
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(192, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 27);
            this.button1.TabIndex = 7;
            this.toolTip1.SetToolTip(this.button1, "Informacion Nodo");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BT_Isomorfismo
            // 
            this.BT_Isomorfismo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BT_Isomorfismo.BackColor = System.Drawing.Color.Transparent;
            this.BT_Isomorfismo.Image = ((System.Drawing.Image)(resources.GetObject("BT_Isomorfismo.Image")));
            this.BT_Isomorfismo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_Isomorfismo.Location = new System.Drawing.Point(222, 27);
            this.BT_Isomorfismo.Name = "BT_Isomorfismo";
            this.BT_Isomorfismo.Size = new System.Drawing.Size(24, 27);
            this.BT_Isomorfismo.TabIndex = 8;
            this.toolTip1.SetToolTip(this.BT_Isomorfismo, "Isomorfismo");
            this.BT_Isomorfismo.UseVisualStyleBackColor = false;
            this.BT_Isomorfismo.Click += new System.EventHandler(this.BT_Isomorfismo_Click);
            // 
            // BT_SeleccionarNodos
            // 
            this.BT_SeleccionarNodos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BT_SeleccionarNodos.BackColor = System.Drawing.Color.Transparent;
            this.BT_SeleccionarNodos.Image = ((System.Drawing.Image)(resources.GetObject("BT_SeleccionarNodos.Image")));
            this.BT_SeleccionarNodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_SeleccionarNodos.Location = new System.Drawing.Point(252, 27);
            this.BT_SeleccionarNodos.Name = "BT_SeleccionarNodos";
            this.BT_SeleccionarNodos.Size = new System.Drawing.Size(24, 27);
            this.BT_SeleccionarNodos.TabIndex = 10;
            this.toolTip1.SetToolTip(this.BT_SeleccionarNodos, "Seleccionar Nodos(Circuitos, Caminos)");
            this.BT_SeleccionarNodos.UseVisualStyleBackColor = false;
            this.BT_SeleccionarNodos.Click += new System.EventHandler(this.BT_SeleccionarNodos_Click);
            // 
            // LB_NodosSeleccionados
            // 
            this.LB_NodosSeleccionados.AutoSize = true;
            this.LB_NodosSeleccionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_NodosSeleccionados.Location = new System.Drawing.Point(1031, 557);
            this.LB_NodosSeleccionados.Name = "LB_NodosSeleccionados";
            this.LB_NodosSeleccionados.Size = new System.Drawing.Size(60, 24);
            this.LB_NodosSeleccionados.TabIndex = 9;
            this.LB_NodosSeleccionados.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 650);
            this.Controls.Add(this.BT_SeleccionarNodos);
            this.Controls.Add(this.LB_NodosSeleccionados);
            this.Controls.Add(this.BT_Isomorfismo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BT_CambiarPesoRel);
            this.Controls.Add(this.BT_MoverNodo);
            this.Controls.Add(this.BT_EliminarRelacion);
            this.Controls.Add(this.BT_AñadirRelacion);
            this.Controls.Add(this.BT_EliminarNodo);
            this.Controls.Add(this.BT_AgregarNodo);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grafoDirigidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grafoNoDirigidoToolStripMenuItem;
        public System.Windows.Forms.Button BT_AgregarNodo;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button BT_EliminarNodo;
        public System.Windows.Forms.Button BT_AñadirRelacion;
        private System.Windows.Forms.ToolStripMenuItem abrirGrafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarGrafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarGrafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adyacenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesosToolStripMenuItem;
        public System.Windows.Forms.Button BT_EliminarRelacion;
        public System.Windows.Forms.Button BT_MoverNodo;
        public System.Windows.Forms.Button BT_CambiarPesoRel;
        private System.Windows.Forms.ToolStripMenuItem esBipartitoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esCompletoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esCicloToolStripMenuItem;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem propiedadesDelGrafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradoDelGrafoToolStripMenuItem;
        public System.Windows.Forms.Button BT_Isomorfismo;
        private System.Windows.Forms.ToolStripMenuItem algoritmosIsomorfismoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrizTranspuestaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmoFuerzaBrutaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caminosCircuitosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caminosSimplesToolStripMenuItem;
        private System.Windows.Forms.Label LB_NodosSeleccionados;
        public System.Windows.Forms.Button BT_SeleccionarNodos;
        private System.Windows.Forms.ToolStripMenuItem circuitoEulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circuitoEulerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem algoritmos4o5toParcialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dijkstraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floydToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warshallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem primToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kruskalToolStripMenuItem;
    }
}

