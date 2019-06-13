namespace Example
{
    partial class DatasetForm
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
            this.tabDataset = new System.Windows.Forms.TabControl();
            this.tabTraining = new System.Windows.Forms.TabPage();
            this.gridTraining = new System.Windows.Forms.DataGridView();
            this.tabValidation = new System.Windows.Forms.TabPage();
            this.gridValidation = new System.Windows.Forms.DataGridView();
            this.tabTest = new System.Windows.Forms.TabPage();
            this.gridTest = new System.Windows.Forms.DataGridView();
            this.tabDataset.SuspendLayout();
            this.tabTraining.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTraining)).BeginInit();
            this.tabValidation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridValidation)).BeginInit();
            this.tabTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTest)).BeginInit();
            this.SuspendLayout();
            // 
            // tabDataset
            // 
            this.tabDataset.Controls.Add(this.tabTraining);
            this.tabDataset.Controls.Add(this.tabValidation);
            this.tabDataset.Controls.Add(this.tabTest);
            this.tabDataset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDataset.Location = new System.Drawing.Point(0, 0);
            this.tabDataset.Name = "tabDataset";
            this.tabDataset.SelectedIndex = 0;
            this.tabDataset.Size = new System.Drawing.Size(800, 450);
            this.tabDataset.TabIndex = 0;
            // 
            // tabTraining
            // 
            this.tabTraining.Controls.Add(this.gridTraining);
            this.tabTraining.Location = new System.Drawing.Point(4, 22);
            this.tabTraining.Name = "tabTraining";
            this.tabTraining.Padding = new System.Windows.Forms.Padding(3);
            this.tabTraining.Size = new System.Drawing.Size(792, 424);
            this.tabTraining.TabIndex = 0;
            this.tabTraining.Text = "Training";
            this.tabTraining.UseVisualStyleBackColor = true;
            // 
            // gridTraining
            // 
            this.gridTraining.AllowUserToAddRows = false;
            this.gridTraining.AllowUserToDeleteRows = false;
            this.gridTraining.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTraining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTraining.Location = new System.Drawing.Point(3, 3);
            this.gridTraining.Name = "gridTraining";
            this.gridTraining.ReadOnly = true;
            this.gridTraining.Size = new System.Drawing.Size(786, 418);
            this.gridTraining.TabIndex = 0;
            // 
            // tabValidation
            // 
            this.tabValidation.Controls.Add(this.gridValidation);
            this.tabValidation.Location = new System.Drawing.Point(4, 22);
            this.tabValidation.Name = "tabValidation";
            this.tabValidation.Padding = new System.Windows.Forms.Padding(3);
            this.tabValidation.Size = new System.Drawing.Size(792, 424);
            this.tabValidation.TabIndex = 1;
            this.tabValidation.Text = "Validation";
            this.tabValidation.UseVisualStyleBackColor = true;
            // 
            // gridValidation
            // 
            this.gridValidation.AllowUserToAddRows = false;
            this.gridValidation.AllowUserToDeleteRows = false;
            this.gridValidation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridValidation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridValidation.Location = new System.Drawing.Point(3, 3);
            this.gridValidation.Name = "gridValidation";
            this.gridValidation.ReadOnly = true;
            this.gridValidation.Size = new System.Drawing.Size(786, 418);
            this.gridValidation.TabIndex = 1;
            // 
            // tabTest
            // 
            this.tabTest.Controls.Add(this.gridTest);
            this.tabTest.Location = new System.Drawing.Point(4, 22);
            this.tabTest.Name = "tabTest";
            this.tabTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabTest.Size = new System.Drawing.Size(792, 424);
            this.tabTest.TabIndex = 2;
            this.tabTest.Text = "Test";
            this.tabTest.UseVisualStyleBackColor = true;
            // 
            // gridTest
            // 
            this.gridTest.AllowUserToAddRows = false;
            this.gridTest.AllowUserToDeleteRows = false;
            this.gridTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTest.Location = new System.Drawing.Point(3, 3);
            this.gridTest.Name = "gridTest";
            this.gridTest.ReadOnly = true;
            this.gridTest.Size = new System.Drawing.Size(786, 418);
            this.gridTest.TabIndex = 2;
            // 
            // DatasetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabDataset);
            this.Name = "DatasetForm";
            this.Text = "Dataset Viewer";
            this.Load += new System.EventHandler(this.DatasetForm_Load);
            this.tabDataset.ResumeLayout(false);
            this.tabTraining.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTraining)).EndInit();
            this.tabValidation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridValidation)).EndInit();
            this.tabTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDataset;
        private System.Windows.Forms.TabPage tabTraining;
        private System.Windows.Forms.DataGridView gridTraining;
        private System.Windows.Forms.TabPage tabValidation;
        private System.Windows.Forms.DataGridView gridValidation;
        private System.Windows.Forms.TabPage tabTest;
        private System.Windows.Forms.DataGridView gridTest;
    }
}