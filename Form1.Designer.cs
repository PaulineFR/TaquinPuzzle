namespace TaquinPuzzle
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
            panelControls = new Panel();
            solveButton = new Button();
            label2 = new Label();
            label1 = new Label();
            numericNbAgents = new NumericUpDown();
            numericGridSize = new NumericUpDown();
            btnRun = new Button();
            panelGrid = new Panel();
            panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericNbAgents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericGridSize).BeginInit();
            SuspendLayout();
            // 
            // panelControls
            // 
            panelControls.Controls.Add(solveButton);
            panelControls.Controls.Add(label2);
            panelControls.Controls.Add(label1);
            panelControls.Controls.Add(numericNbAgents);
            panelControls.Controls.Add(numericGridSize);
            panelControls.Controls.Add(btnRun);
            panelControls.Location = new Point(22, 22);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(192, 527);
            panelControls.TabIndex = 0;
            // 
            // solveButton
            // 
            solveButton.Location = new Point(45, 254);
            solveButton.Name = "solveButton";
            solveButton.Size = new Size(94, 29);
            solveButton.TabIndex = 5;
            solveButton.Text = "Résoudre";
            solveButton.UseVisualStyleBackColor = true;
            solveButton.Click += solveButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 120);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 4;
            label2.Text = "Nombre d'agents";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 53);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 3;
            label1.Text = "Taille de la grille";
            // 
            // numericNbAgents
            // 
            numericNbAgents.Location = new Point(26, 143);
            numericNbAgents.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            numericNbAgents.Name = "numericNbAgents";
            numericNbAgents.Size = new Size(150, 27);
            numericNbAgents.TabIndex = 2;
            // 
            // numericGridSize
            // 
            numericGridSize.Location = new Point(26, 76);
            numericGridSize.Name = "numericGridSize";
            numericGridSize.Size = new Size(150, 27);
            numericGridSize.TabIndex = 1;
            numericGridSize.ValueChanged += numericGridSize_ValueChanged;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(45, 204);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(94, 29);
            btnRun.TabIndex = 0;
            btnRun.Text = "Lancer";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // panelGrid
            // 
            panelGrid.Location = new Point(259, 31);
            panelGrid.Name = "panelGrid";
            panelGrid.Size = new Size(520, 520);
            panelGrid.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 586);
            Controls.Add(panelGrid);
            Controls.Add(panelControls);
            Name = "Form1";
            Text = "Taquin Puzzle - LUSSON Robin - ROBIN Julien - FRANQUELIN Pauline";
            panelControls.ResumeLayout(false);
            panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericNbAgents).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericGridSize).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelControls;
        private NumericUpDown numericNbAgents;
        private NumericUpDown numericGridSize;
        private Button btnRun;
        private Panel panelGrid;
        private Label label1;
        private Label label2;
        private Button solveButton;
    }
}