
namespace Bartender_M9D47D
{
    partial class ablak
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ablak));
            this.pluszK = new System.Windows.Forms.Button();
            this.pluszB = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.groupBoxK = new System.Windows.Forms.GroupBox();
            this.groupBoxB = new System.Windows.Forms.GroupBox();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pluszK
            // 
            this.pluszK.Location = new System.Drawing.Point(1095, 60);
            this.pluszK.Name = "pluszK";
            this.pluszK.Size = new System.Drawing.Size(50, 50);
            this.pluszK.TabIndex = 1;
            this.pluszK.Text = "+K";
            this.pluszK.UseVisualStyleBackColor = true;
            this.pluszK.Click += new System.EventHandler(this.pluszK_Click);
            // 
            // pluszB
            // 
            this.pluszB.Location = new System.Drawing.Point(5, 60);
            this.pluszB.Name = "pluszB";
            this.pluszB.Size = new System.Drawing.Size(50, 50);
            this.pluszB.TabIndex = 1;
            this.pluszB.Text = "+B";
            this.pluszB.UseVisualStyleBackColor = true;
            this.pluszB.Click += new System.EventHandler(this.pluszB_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(1095, 5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(50, 50);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // groupBoxK
            // 
            this.groupBoxK.Location = new System.Drawing.Point(750, 60);
            this.groupBoxK.Name = "groupBoxK";
            this.groupBoxK.Size = new System.Drawing.Size(388, 568);
            this.groupBoxK.TabIndex = 0;
            this.groupBoxK.TabStop = false;
            // 
            // groupBoxB
            // 
            this.groupBoxB.Location = new System.Drawing.Point(10, 60);
            this.groupBoxB.Name = "groupBoxB";
            this.groupBoxB.Size = new System.Drawing.Size(734, 568);
            this.groupBoxB.TabIndex = 0;
            this.groupBoxB.TabStop = false;
            // 
            // minimizeButton
            // 
            this.minimizeButton.Location = new System.Drawing.Point(1040, 5);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(50, 50);
            this.minimizeButton.TabIndex = 1;
            this.minimizeButton.Text = "_";
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // ablak
            // 
            this.ClientSize = new System.Drawing.Size(1150, 640);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.pluszB);
            this.Controls.Add(this.pluszK);
            this.Controls.Add(this.groupBoxB);
            this.Controls.Add(this.groupBoxK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon"))); // <----------- comment this line to compile with mono
            this.Name = "ablak";
            this.Text = "Bartender";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pluszK;
        private System.Windows.Forms.Button pluszB;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.GroupBox groupBoxB;
        private System.Windows.Forms.GroupBox groupBoxK;
    }
}

