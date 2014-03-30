namespace CardMaker
{
    partial class ElementCtrl
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
            this.nameText = new System.Windows.Forms.TextBox();
            this.descText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.appearanceType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.indentType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(87, 3);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(208, 20);
            this.nameText.TabIndex = 7;
            this.nameText.TextChanged += new System.EventHandler(this.nameText_TextChanged);
            // 
            // descText
            // 
            this.descText.Location = new System.Drawing.Point(87, 29);
            this.descText.Multiline = true;
            this.descText.Name = "descText";
            this.descText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descText.Size = new System.Drawing.Size(208, 50);
            this.descText.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Text";
            // 
            // appearanceType
            // 
            this.appearanceType.FormattingEnabled = true;
            this.appearanceType.Items.AddRange(new object[] {
            CardMaker.Appearance.Shaded,
            CardMaker.Appearance.Not_Shaded});
            this.appearanceType.Location = new System.Drawing.Point(87, 85);
            this.appearanceType.Name = "appearanceType";
            this.appearanceType.Size = new System.Drawing.Size(208, 21);
            this.appearanceType.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Appearance";
            // 
            // indentType
            // 
            this.indentType.FormattingEnabled = true;
            this.indentType.Items.AddRange(new object[] {
            CardMaker.Indentation.Primary,
            CardMaker.Indentation.Secondary,
            CardMaker.Indentation.Tertiary});
            this.indentType.Location = new System.Drawing.Point(87, 112);
            this.indentType.Name = "indentType";
            this.indentType.Size = new System.Drawing.Size(208, 21);
            this.indentType.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Indentation";
            // 
            // ElementCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.indentType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.appearanceType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.descText);
            this.Controls.Add(this.nameText);
            this.Name = "ElementCtrl";
            this.Size = new System.Drawing.Size(298, 144);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox nameText;
        public System.Windows.Forms.TextBox descText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox appearanceType;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox indentType;
        private System.Windows.Forms.Label label7;

    }
}
