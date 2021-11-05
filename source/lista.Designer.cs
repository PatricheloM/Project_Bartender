
namespace Bartender_M9D47D
{
    partial class lista
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
            this.currentTableText = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // currentTableText
            // 
            this.currentTableText.AutoSize = true;
            this.currentTableText.Location = new System.Drawing.Point(13, 13);
            this.currentTableText.Name = "currentTableText";
            this.currentTableText.Size = new System.Drawing.Size(123, 13);
            this.currentTableText.TabIndex = 0;
            this.currentTableText.Text = "currentTablePlaceholder";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.priceColumn,
            this.invoiceColumn});
            this.dataGridView.Location = new System.Drawing.Point(13, 30);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView.Size = new System.Drawing.Size(385, 568);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_EditingControlShowing);
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Tétel";
            this.nameColumn.Name = "nameColumn";
            // 
            // priceColumn
            // 
            this.priceColumn.HeaderText = "Ár";
            this.priceColumn.Name = "priceColumn";
            this.priceColumn.ReadOnly = true;
            // 
            // invoiceColumn
            // 
            this.invoiceColumn.HeaderText = "Számla";
            this.invoiceColumn.Name = "invoiceColumn";
            this.invoiceColumn.ReadOnly = true;
            // 
            // lista
            // 
            this.ClientSize = new System.Drawing.Size(410, 610);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.currentTableText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "lista";
            this.Text = "Lista";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.lista_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentTableText;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceColumn;
    }
}