namespace CardMaker
{
    partial class AuraCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.descText = new System.Windows.Forms.TextBox();
            this.radiusText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.typeText = new System.Windows.Forms.TextBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Description";
            // 
            // descText
            // 
            this.descText.Location = new System.Drawing.Point(69, 81);
            this.descText.Name = "descText";
            this.descText.Size = new System.Drawing.Size(238, 20);
            this.descText.TabIndex = 34;
            // 
            // radiusText
            // 
            this.radiusText.Location = new System.Drawing.Point(69, 55);
            this.radiusText.Name = "radiusText";
            this.radiusText.Size = new System.Drawing.Size(238, 20);
            this.radiusText.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Radius";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Type";
            // 
            // typeText
            // 
            this.typeText.Location = new System.Drawing.Point(69, 29);
            this.typeText.Name = "typeText";
            this.typeText.Size = new System.Drawing.Size(238, 20);
            this.typeText.TabIndex = 30;
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(69, 3);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(238, 20);
            this.nameText.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Name";
            // 
            // AuraCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.descText);
            this.Controls.Add(this.radiusText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.typeText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.label1);
            this.Name = "AuraCtrl";
            this.Size = new System.Drawing.Size(311, 107);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox descText;
        public System.Windows.Forms.TextBox radiusText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox typeText;
        public System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label label1;
    }
}
