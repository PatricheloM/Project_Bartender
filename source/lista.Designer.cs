
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
            this.currentTable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // currentTable
            // 
            this.currentTable.AutoSize = true;
            this.currentTable.Location = new System.Drawing.Point(13, 13);
            this.currentTable.Name = "currentTable";
            this.currentTable.Size = new System.Drawing.Size(35, 13);
            this.currentTable.TabIndex = 0;
            this.currentTable.Text = "currentTable";
            // 
            // lista
            // 
            this.ClientSize = new System.Drawing.Size(410, 610);
            this.Controls.Add(this.currentTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "lista";
            this.Text = "Lista";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentTable;
    }
}