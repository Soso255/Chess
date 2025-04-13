namespace Chess
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fichierToolStripMenuItem = new ToolStripMenuItem();
            nouvellePartieToolStripMenuItem = new ToolStripMenuItem();
            enregistrerSousToolStripMenuItem = new ToolStripMenuItem();
            ouvrirToolStripMenuItem = new ToolStripMenuItem();
            outilsToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            calculeDeSolutionToolStripMenuItem = new ToolStripMenuItem();
            joueur1ToolStripMenuItem = new ToolStripMenuItem();
            calculateSolutionForPlayer1Deep4ToolStripMenuItem = new ToolStripMenuItem();
            jouerToolStripMenuItem = new ToolStripMenuItem();
            calculDeSolutionAvec8ThreadsToolStripMenuItem = new ToolStripMenuItem();
            joueur1Niveau5ToolStripMenuItem = new ToolStripMenuItem();
            joueur2Niveau5ToolStripMenuItem = new ToolStripMenuItem();
            jouerAutomatiquementNIveau5ToolStripMenuItem = new ToolStripMenuItem();
            calculDeSolutionAvec16ThreadsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            jouerPourJoueur1Pr5ToolStripMenuItem = new ToolStripMenuItem();
            jouerAutomatiquementProfondeur5ToolStripMenuItem = new ToolStripMenuItem();
            retourToolStripMenuItem = new ToolStripMenuItem();
            redoaToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            tm = new System.Windows.Forms.Timer(components);
            tm2 = new System.Windows.Forms.Timer(components);
            tm3 = new System.Windows.Forms.Timer(components);
            sv = new SaveFileDialog();
            opf = new OpenFileDialog();
            joueur2ToolStripMenuItem = new ToolStripDropDownMenu();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.BlueViolet;
            menuStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fichierToolStripMenuItem, outilsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(734, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            fichierToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nouvellePartieToolStripMenuItem, enregistrerSousToolStripMenuItem, ouvrirToolStripMenuItem });
            fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            fichierToolStripMenuItem.Size = new Size(46, 25);
            fichierToolStripMenuItem.Text = "File";
            // 
            // nouvellePartieToolStripMenuItem
            // 
            nouvellePartieToolStripMenuItem.Name = "nouvellePartieToolStripMenuItem";
            nouvellePartieToolStripMenuItem.Size = new Size(158, 26);
            nouvellePartieToolStripMenuItem.Text = "New round";
            nouvellePartieToolStripMenuItem.Click += nouvellePartieToolStripMenuItem_Click;
            // 
            // enregistrerSousToolStripMenuItem
            // 
            enregistrerSousToolStripMenuItem.Name = "enregistrerSousToolStripMenuItem";
            enregistrerSousToolStripMenuItem.Size = new Size(158, 26);
            enregistrerSousToolStripMenuItem.Text = "Save as";
            enregistrerSousToolStripMenuItem.Click += enregistrerSousToolStripMenuItem_Click;
            // 
            // ouvrirToolStripMenuItem
            // 
            ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            ouvrirToolStripMenuItem.Size = new Size(158, 26);
            ouvrirToolStripMenuItem.Text = "Open";
            ouvrirToolStripMenuItem.Click += ouvrirToolStripMenuItem_Click;
            // 
            // outilsToolStripMenuItem
            // 
            outilsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { refreshToolStripMenuItem, calculeDeSolutionToolStripMenuItem, calculDeSolutionAvec8ThreadsToolStripMenuItem, calculDeSolutionAvec16ThreadsToolStripMenuItem, retourToolStripMenuItem, redoaToolStripMenuItem });
            outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
            outilsToolStripMenuItem.Size = new Size(57, 25);
            outilsToolStripMenuItem.Text = "Tools";
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(434, 26);
            refreshToolStripMenuItem.Text = "Refresh";
            refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
            // 
            // calculeDeSolutionToolStripMenuItem
            // 
            calculeDeSolutionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { joueur1ToolStripMenuItem, calculateSolutionForPlayer1Deep4ToolStripMenuItem, jouerToolStripMenuItem });
            calculeDeSolutionToolStripMenuItem.Name = "calculeDeSolutionToolStripMenuItem";
            calculeDeSolutionToolStripMenuItem.Size = new Size(434, 26);
            calculeDeSolutionToolStripMenuItem.Text = "Solution calculation with depth of 4 and one thread";
            calculeDeSolutionToolStripMenuItem.Click += calculeDeSolutionToolStripMenuItem_Click;
            // 
            // joueur1ToolStripMenuItem
            // 
            joueur1ToolStripMenuItem.Name = "joueur1ToolStripMenuItem";
            joueur1ToolStripMenuItem.Size = new Size(367, 26);
            joueur1ToolStripMenuItem.Text = "Solution calculation for player 1, depth=4";
            joueur1ToolStripMenuItem.Click += joueur1ToolStripMenuItem_Click;
            // 
            // calculateSolutionForPlayer1Deep4ToolStripMenuItem
            // 
            calculateSolutionForPlayer1Deep4ToolStripMenuItem.Name = "calculateSolutionForPlayer1Deep4ToolStripMenuItem";
            calculateSolutionForPlayer1Deep4ToolStripMenuItem.Size = new Size(367, 26);
            calculateSolutionForPlayer1Deep4ToolStripMenuItem.Text = "Solution calculation for player 2, depth=4";
            calculateSolutionForPlayer1Deep4ToolStripMenuItem.Click += joueur2ToolStripMenuItem_Click;
            // 
            // jouerToolStripMenuItem
            // 
            jouerToolStripMenuItem.Name = "jouerToolStripMenuItem";
            jouerToolStripMenuItem.Size = new Size(367, 26);
            jouerToolStripMenuItem.Text = "Self play with depth=4";
            jouerToolStripMenuItem.Click += jouerToolStripMenuItem_Click;
            // 
            // calculDeSolutionAvec8ThreadsToolStripMenuItem
            // 
            calculDeSolutionAvec8ThreadsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { joueur1Niveau5ToolStripMenuItem, joueur2Niveau5ToolStripMenuItem, jouerAutomatiquementNIveau5ToolStripMenuItem });
            calculDeSolutionAvec8ThreadsToolStripMenuItem.Name = "calculDeSolutionAvec8ThreadsToolStripMenuItem";
            calculDeSolutionAvec8ThreadsToolStripMenuItem.Size = new Size(434, 26);
            calculDeSolutionAvec8ThreadsToolStripMenuItem.Text = "Solution calculation with 8 Threads";
            calculDeSolutionAvec8ThreadsToolStripMenuItem.Click += calculDeSolutionAvec8ThreadsToolStripMenuItem_Click;
            // 
            // joueur1Niveau5ToolStripMenuItem
            // 
            joueur1Niveau5ToolStripMenuItem.Name = "joueur1Niveau5ToolStripMenuItem";
            joueur1Niveau5ToolStripMenuItem.Size = new Size(398, 26);
            joueur1Niveau5ToolStripMenuItem.Text = "Solution calculation for player 1 and  depth=5";
            joueur1Niveau5ToolStripMenuItem.Click += joueur1Niveau5ToolStripMenuItem_Click;
            // 
            // joueur2Niveau5ToolStripMenuItem
            // 
            joueur2Niveau5ToolStripMenuItem.Name = "joueur2Niveau5ToolStripMenuItem";
            joueur2Niveau5ToolStripMenuItem.Size = new Size(398, 26);
            joueur2Niveau5ToolStripMenuItem.Text = "Solution calculation for player 2 and  depth=5";
            joueur2Niveau5ToolStripMenuItem.Click += joueur2Niveau5ToolStripMenuItem_Click;
            // 
            // jouerAutomatiquementNIveau5ToolStripMenuItem
            // 
            jouerAutomatiquementNIveau5ToolStripMenuItem.Name = "jouerAutomatiquementNIveau5ToolStripMenuItem";
            jouerAutomatiquementNIveau5ToolStripMenuItem.Size = new Size(398, 26);
            jouerAutomatiquementNIveau5ToolStripMenuItem.Text = "Self playing with depth=5";
            jouerAutomatiquementNIveau5ToolStripMenuItem.Click += jouerAutomatiquementNIveau5ToolStripMenuItem_Click;
            // 
            // calculDeSolutionAvec16ThreadsToolStripMenuItem
            // 
            calculDeSolutionAvec16ThreadsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, jouerPourJoueur1Pr5ToolStripMenuItem, jouerAutomatiquementProfondeur5ToolStripMenuItem });
            calculDeSolutionAvec16ThreadsToolStripMenuItem.Name = "calculDeSolutionAvec16ThreadsToolStripMenuItem";
            calculDeSolutionAvec16ThreadsToolStripMenuItem.Size = new Size(434, 26);
            calculDeSolutionAvec16ThreadsToolStripMenuItem.Text = "Solution calculation with 16 Threads";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(358, 26);
            toolStripMenuItem1.Text = "Solution calculation for player 1 deep=5";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // jouerPourJoueur1Pr5ToolStripMenuItem
            // 
            jouerPourJoueur1Pr5ToolStripMenuItem.Name = "jouerPourJoueur1Pr5ToolStripMenuItem";
            jouerPourJoueur1Pr5ToolStripMenuItem.Size = new Size(358, 26);
            jouerPourJoueur1Pr5ToolStripMenuItem.Text = "Solution calculation for player 2 deep=5";
            jouerPourJoueur1Pr5ToolStripMenuItem.Click += jouerPourJoueur1Pr5ToolStripMenuItem_Click;
            // 
            // jouerAutomatiquementProfondeur5ToolStripMenuItem
            // 
            jouerAutomatiquementProfondeur5ToolStripMenuItem.Name = "jouerAutomatiquementProfondeur5ToolStripMenuItem";
            jouerAutomatiquementProfondeur5ToolStripMenuItem.Size = new Size(358, 26);
            jouerAutomatiquementProfondeur5ToolStripMenuItem.Text = "Self playing with tree deep=5";
            jouerAutomatiquementProfondeur5ToolStripMenuItem.Click += jouerAutomatiquementProfondeur5ToolStripMenuItem_Click;
            // 
            // retourToolStripMenuItem
            // 
            retourToolStripMenuItem.Name = "retourToolStripMenuItem";
            retourToolStripMenuItem.Size = new Size(434, 26);
            retourToolStripMenuItem.Text = "Back---------------------------------------Return Bar";
            retourToolStripMenuItem.Click += retourToolStripMenuItem_Click;
            // 
            // redoaToolStripMenuItem
            // 
            redoaToolStripMenuItem.Name = "redoaToolStripMenuItem";
            redoaToolStripMenuItem.Size = new Size(434, 26);
            redoaToolStripMenuItem.Text = "Redo--------------------------------------------   a";
            redoaToolStripMenuItem.Click += redoaToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(45, 699);
            label1.Name = "label1";
            label1.Size = new Size(78, 21);
            label1.TabIndex = 1;
            label1.Text = "Echo here";
            // 
            // tm
            // 
            tm.Tick += timer1_Tick;
            // 
            // tm2
            // 
            tm2.Tick += tm2_Tick;
            // 
            // tm3
            // 
            tm3.Tick += tm3_Tick;
            // 
            // sv
            // 
            sv.DefaultExt = "Sof";
            sv.Filter = "Fichiers Sof|*.sof";
            sv.InitialDirectory = "/";
            sv.Tag = "";
            sv.Title = "Sauvegarder";
            sv.FileOk += sv_FileOk;
            // 
            // opf
            // 
            opf.FileName = "openFileDialog1";
            // 
            // joueur2ToolStripMenuItem
            // 
            joueur2ToolStripMenuItem.AutoClose = false;
            joueur2ToolStripMenuItem.Name = "joueur2ToolStripMenuItem";
            joueur2ToolStripMenuItem.Size = new Size(61, 4);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Purple;
            ClientSize = new Size(734, 747);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chess";
            Deactivate += Form1_Deactivate;
            Load += Form1_Load;
            LocationChanged += Form1_LocationChanged;
            SizeChanged += Form1_SizeChanged;
            DragDrop += Form1_DragDrop;
            Paint += Form1_Paint;
            KeyPress += Form1_KeyPress;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fichierToolStripMenuItem;
        private ToolStripMenuItem nouvellePartieToolStripMenuItem;
        public Label label1;
        private ToolStripMenuItem outilsToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Timer tm;
        private ToolStripMenuItem calculDeSolutionAvec8ThreadsToolStripMenuItem;
        private ToolStripMenuItem joueur1Niveau5ToolStripMenuItem;
        private ToolStripMenuItem joueur2Niveau5ToolStripMenuItem;
        private ToolStripMenuItem jouerAutomatiquementNIveau5ToolStripMenuItem;
        private System.Windows.Forms.Timer tm2;
        private ToolStripMenuItem calculDeSolutionAvec16ThreadsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem jouerPourJoueur1Pr5ToolStripMenuItem;
        private ToolStripMenuItem jouerAutomatiquementProfondeur5ToolStripMenuItem;
        private System.Windows.Forms.Timer tm3;
        private ToolStripMenuItem retourToolStripMenuItem;
        private ToolStripMenuItem enregistrerSousToolStripMenuItem;
        private ToolStripMenuItem ouvrirToolStripMenuItem;
        private SaveFileDialog sv;
        private OpenFileDialog opf;
        private ToolStripMenuItem redoaToolStripMenuItem;
        private ToolStripMenuItem calculeDeSolutionToolStripMenuItem;
        private ToolStripMenuItem calculateSolutionForPlayer1Deep4ToolStripMenuItem;
        private ToolStripMenuItem joueur1ToolStripMenuItem;
        private ToolStripMenuItem jouerToolStripMenuItem;
        private ToolStripDropDownMenu joueur2ToolStripMenuItem;
    }
}
