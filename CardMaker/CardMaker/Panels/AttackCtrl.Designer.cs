namespace CardMaker
{
    partial class AttackCtrl
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
            this.damageText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bonusText = new System.Windows.Forms.TextBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.targetDefType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Damage";
            // 
            // damageText
            // 
            this.damageText.Location = new System.Drawing.Point(89, 81);
            this.damageText.Name = "damageText";
            this.damageText.Size = new System.Drawing.Size(198, 20);
            this.damageText.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Target Defense";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Attack Bonus";
            // 
            // bonusText
            // 
            this.bonusText.Location = new System.Drawing.Point(89, 29);
            this.bonusText.Name = "bonusText";
            this.bonusText.Size = new System.Drawing.Size(198, 20);
            this.bonusText.TabIndex = 22;
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(89, 3);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(198, 20);
            this.nameText.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Name";
            // 
            // targetDefType
            // 
            this.targetDefType.FormattingEnabled = true;
            this.targetDefType.Items.AddRange(new object[] {
            CardMaker.ClassStuff.Defences.Armour_Class,
            CardMaker.ClassStuff.Defences.Fortitude,
            CardMaker.ClassStuff.Defences.Reflex,
            CardMaker.ClassStuff.Defences.Will});
            this.targetDefType.Location = new System.Drawing.Point(89, 55);
            this.targetDefType.Name = "targetDefType";
            this.targetDefType.Size = new System.Drawing.Size(198, 21);
            this.targetDefType.TabIndex = 28;
            // 
            // AttackCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.targetDefType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.damageText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bonusText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.label1);
            this.Name = "AttackCtrl";
            this.Size = new System.Drawing.Size(290, 106);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox damageText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox bonusText;
        public System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox targetDefType;
    }
}
