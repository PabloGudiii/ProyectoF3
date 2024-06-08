namespace ProyectoFinal
{
    partial class Campeonato
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            btnAdministrarPartidos = new Button();
            panel1 = new Panel();
            txbMostrar = new TextBox();
            Ranking = new Label();
            btnRankEquipos = new Button();
            btnRankPartidos = new Button();
            btnRankJugadores = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(230, 37);
            label1.Name = "label1";
            label1.Size = new Size(119, 23);
            label1.TabIndex = 0;
            label1.Text = "Campeonatos";
            // 
            // button1
            // 
            button1.Location = new Point(9, 79);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(175, 40);
            button1.TabIndex = 1;
            button1.Text = "Administrar Jugadores";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(209, 79);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(175, 40);
            button2.TabIndex = 2;
            button2.Text = "Administrar Equipos";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnAdministrarPartidos
            // 
            btnAdministrarPartidos.Location = new Point(405, 79);
            btnAdministrarPartidos.Margin = new Padding(3, 4, 3, 4);
            btnAdministrarPartidos.Name = "btnAdministrarPartidos";
            btnAdministrarPartidos.Size = new Size(175, 40);
            btnAdministrarPartidos.TabIndex = 3;
            btnAdministrarPartidos.Text = "Administrar Partidos";
            btnAdministrarPartidos.UseVisualStyleBackColor = true;
            btnAdministrarPartidos.Click += btnAdministrarPartidos_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txbMostrar);
            panel1.Location = new Point(10, 196);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(570, 411);
            panel1.TabIndex = 4;
            // 
            // txbMostrar
            // 
            txbMostrar.Location = new Point(3, 4);
            txbMostrar.Margin = new Padding(3, 4, 3, 4);
            txbMostrar.Multiline = true;
            txbMostrar.Name = "txbMostrar";
            txbMostrar.Size = new Size(563, 401);
            txbMostrar.TabIndex = 0;
            txbMostrar.TextChanged += txbMostrar_TextChanged;
            // 
            // Ranking
            // 
            Ranking.AutoSize = true;
            Ranking.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            Ranking.Location = new Point(257, 157);
            Ranking.Name = "Ranking";
            Ranking.Size = new Size(76, 23);
            Ranking.TabIndex = 5;
            Ranking.Text = "Ranking";
            // 
            // btnRankEquipos
            // 
            btnRankEquipos.Location = new Point(36, 624);
            btnRankEquipos.Name = "btnRankEquipos";
            btnRankEquipos.Size = new Size(149, 29);
            btnRankEquipos.TabIndex = 6;
            btnRankEquipos.Text = "Ranking Equipos";
            btnRankEquipos.UseVisualStyleBackColor = true;
            btnRankEquipos.Click += btnRankEquipos_Click;
            // 
            // btnRankPartidos
            // 
            btnRankPartidos.Location = new Point(221, 624);
            btnRankPartidos.Name = "btnRankPartidos";
            btnRankPartidos.Size = new Size(144, 29);
            btnRankPartidos.TabIndex = 7;
            btnRankPartidos.Text = "Resumen Partidos";
            btnRankPartidos.UseVisualStyleBackColor = true;
            btnRankPartidos.Click += btnRankPartidos_Click;
            // 
            // btnRankJugadores
            // 
            btnRankJugadores.Location = new Point(397, 624);
            btnRankJugadores.Name = "btnRankJugadores";
            btnRankJugadores.Size = new Size(158, 29);
            btnRankJugadores.TabIndex = 8;
            btnRankJugadores.Text = "Ranking Jugadores";
            btnRankJugadores.UseVisualStyleBackColor = true;
            btnRankJugadores.Click += btnRankJugadores_Click;
            // 
            // Campeonato
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Turquoise;
            ClientSize = new Size(594, 675);
            Controls.Add(btnRankJugadores);
            Controls.Add(btnRankPartidos);
            Controls.Add(btnRankEquipos);
            Controls.Add(Ranking);
            Controls.Add(panel1);
            Controls.Add(btnAdministrarPartidos);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Campeonato";
            Text = "Campeonato";
            Load += Campeonato_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button btnAdministrarPartidos;
        private Panel panel1;
        private TextBox txbMostrar;
        private Label Ranking;
        private Button btnRankEquipos;
        private Button btnRankPartidos;
        private Button btnRankJugadores;
    }
}
