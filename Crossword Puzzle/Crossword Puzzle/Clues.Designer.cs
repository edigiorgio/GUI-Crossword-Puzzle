namespace Crossword_Puzzle
{
    partial class Clues
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clueTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.clueTable)).BeginInit();
            this.SuspendLayout();
            // 
            // clueTable
            // 
            this.clueTable.AllowUserToAddRows = false;
            this.clueTable.AllowUserToDeleteRows = false;
            this.clueTable.AllowUserToResizeColumns = false;
            this.clueTable.AllowUserToResizeRows = false;
            this.clueTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clueTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.clueTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clueTable.Location = new System.Drawing.Point(0, 0);
            this.clueTable.Name = "clueTable";
            this.clueTable.RowHeadersVisible = false;
            this.clueTable.RowHeadersWidth = 51;
            this.clueTable.RowTemplate.Height = 24;
            this.clueTable.Size = new System.Drawing.Size(407, 532);
            this.clueTable.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "#";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 35;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Direction";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Clue";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Clues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 532);
            this.Controls.Add(this.clueTable);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Clues";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Clues";
            ((System.ComponentModel.ISupportInitialize)(this.clueTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        public System.Windows.Forms.DataGridView clueTable;
    }
}