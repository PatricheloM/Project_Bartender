
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
            this.kulsoLabel = new System.Windows.Forms.Label();
            this.groupBoxB = new System.Windows.Forms.GroupBox();
            this.belsoLabel = new System.Windows.Forms.Label();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.itallapButton = new System.Windows.Forms.Button();
            this.kifizetesButton = new System.Windows.Forms.Button();
            this.groupBoxK.SuspendLayout();
            this.groupBoxB.SuspendLayout();
            this.SuspendLayout();
            // 
            // pluszK
            // 
            this.pluszK.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F);
            this.pluszK.Location = new System.Drawing.Point(1095, 60);
            this.pluszK.Name = "pluszK";
            this.pluszK.Size = new System.Drawing.Size(50, 50);
            this.pluszK.TabIndex = 1;
            this.pluszK.Text = "+";
            this.pluszK.UseVisualStyleBackColor = true;
            this.pluszK.Click += new System.EventHandler(this.pluszK_Click);
            // 
            // pluszB
            // 
            this.pluszB.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F);
            this.pluszB.Location = new System.Drawing.Point(5, 60);
            this.pluszB.Name = "pluszB";
            this.pluszB.Size = new System.Drawing.Size(50, 50);
            this.pluszB.TabIndex = 1;
            this.pluszB.Text = "+";
            this.pluszB.UseVisualStyleBackColor = true;
            this.pluszB.Click += new System.EventHandler(this.pluszB_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold);
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
            this.groupBoxK.Controls.Add(this.kulsoLabel);
            this.groupBoxK.Location = new System.Drawing.Point(750, 60);
            this.groupBoxK.Name = "groupBoxK";
            this.groupBoxK.Size = new System.Drawing.Size(388, 568);
            this.groupBoxK.TabIndex = 0;
            this.groupBoxK.TabStop = false;
            // 
            // kulsoLabel
            // 
            this.kulsoLabel.AutoSize = true;
            this.kulsoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.kulsoLabel.Location = new System.Drawing.Point(284, 0);
            this.kulsoLabel.Name = "kulsoLabel";
            this.kulsoLabel.Size = new System.Drawing.Size(135, 29);
            this.kulsoLabel.TabIndex = 0;
            this.kulsoLabel.Text = "Külső rész";
            // 
            // groupBoxB
            // 
            this.groupBoxB.Controls.Add(this.belsoLabel);
            this.groupBoxB.Location = new System.Drawing.Point(10, 60);
            this.groupBoxB.Name = "groupBoxB";
            this.groupBoxB.Size = new System.Drawing.Size(734, 568);
            this.groupBoxB.TabIndex = 0;
            this.groupBoxB.TabStop = false;
            // 
            // belsoLabel
            // 
            this.belsoLabel.AutoSize = true;
            this.belsoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.belsoLabel.Location = new System.Drawing.Point(52, 0);
            this.belsoLabel.Name = "belsoLabel";
            this.belsoLabel.Size = new System.Drawing.Size(136, 29);
            this.belsoLabel.TabIndex = 0;
            this.belsoLabel.Text = "Belső rész";
            // 
            // minimizeButton
            // 
            this.minimizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold);
            this.minimizeButton.Location = new System.Drawing.Point(1040, 5);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(50, 50);
            this.minimizeButton.TabIndex = 1;
            this.minimizeButton.Text = "_";
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // itallapButton
            // 
            this.itallapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.itallapButton.Location = new System.Drawing.Point(924, 5);
            this.itallapButton.Name = "itallapButton";
            this.itallapButton.Size = new System.Drawing.Size(110, 50);
            this.itallapButton.TabIndex = 2;
            this.itallapButton.Text = "Itallap";
            this.itallapButton.UseVisualStyleBackColor = true;
            this.itallapButton.Click += new System.EventHandler(this.itallapButton_Click);
            // 
            // kifizetesButton
            // 
            this.kifizetesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.kifizetesButton.Location = new System.Drawing.Point(793, 5);
            this.kifizetesButton.Name = "kifizetesButton";
            this.kifizetesButton.Size = new System.Drawing.Size(125, 50);
            this.kifizetesButton.TabIndex = 3;
            this.kifizetesButton.Text = "Kifizetés";
            this.kifizetesButton.UseVisualStyleBackColor = true;
            this.kifizetesButton.Click += new System.EventHandler(this.kifizetesButton_Click);
            // 
            // ablak
            // 
            this.ClientSize = new System.Drawing.Size(1150, 640);
            this.Controls.Add(this.kifizetesButton);
            this.Controls.Add(this.itallapButton);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.pluszB);
            this.Controls.Add(this.pluszK);
            this.Controls.Add(this.groupBoxB);
            this.Controls.Add(this.groupBoxK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon"))); // <----- comment out this line to compile with mono
            this.Name = "ablak";
            this.Text = "Bartender";
            this.groupBoxK.ResumeLayout(false);
            this.groupBoxK.PerformLayout();
            this.groupBoxB.ResumeLayout(false);
            this.groupBoxB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pluszK;
        private System.Windows.Forms.Button pluszB;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.GroupBox groupBoxB;
        private System.Windows.Forms.GroupBox groupBoxK;
        private System.Windows.Forms.Button itallapButton;
        private System.Windows.Forms.Label belsoLabel;
        private System.Windows.Forms.Label kulsoLabel;
        private System.Windows.Forms.Button kifizetesButton;
    }
}

