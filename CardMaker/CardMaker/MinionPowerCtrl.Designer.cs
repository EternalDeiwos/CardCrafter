namespace CardMaker
{
    partial class MinionPowerCtrl
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
            this.descText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.keywordsText = new System.Windows.Forms.TextBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.actionComboBox = new System.Windows.Forms.ComboBox();
            this.rechargeComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // descText
            // 
            this.descText.Location = new System.Drawing.Point(62, 55);
            this.descText.Multiline = true;
            this.descText.Name = "descText";
            this.descText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descText.Size = new System.Drawing.Size(238, 94);
            this.descText.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Keywords";
            // 
            // keywordsText
            // 
            this.keywordsText.Location = new System.Drawing.Point(62, 29);
            this.keywordsText.Name = "keywordsText";
            this.keywordsText.Size = new System.Drawing.Size(238, 20);
            this.keywordsText.TabIndex = 30;
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(62, 3);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(238, 20);
            this.nameText.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Name";
            // 
            // actionComboBox
            // 
        //    this.actionComboBox.DataSource = new CardMaker.ActionType[] {
        //CardMaker.ActionType.None,
        //CardMaker.ActionType.Free,
        //CardMaker.ActionType.Interrupt,
        //CardMaker.ActionType.Reaction,
        //CardMaker.ActionType.Minor,
        //CardMaker.ActionType.Move,
        //CardMaker.ActionType.Standard};
            this.actionComboBox.FormattingEnabled = true;
            this.actionComboBox.Items.AddRange(new object[] {
            CardMaker.ActionType.None,
            CardMaker.ActionType.Free,
            CardMaker.ActionType.Interrupt,
            CardMaker.ActionType.Reaction,
            CardMaker.ActionType.Minor,
            CardMaker.ActionType.Move,
            CardMaker.ActionType.Standard});
            this.actionComboBox.Location = new System.Drawing.Point(62, 155);
            this.actionComboBox.Name = "actionComboBox";
            this.actionComboBox.Size = new System.Drawing.Size(238, 21);
            this.actionComboBox.TabIndex = 34;
            // 
            // rechargeComboBox
            // 
        //    this.rechargeComboBox.DataSource = new CardMaker.SpellUsage[] {
        //CardMaker.SpellUsage.AtWill,
        //CardMaker.SpellUsage.Daily,
        //CardMaker.SpellUsage.Encounter};
            this.rechargeComboBox.FormattingEnabled = true;
            this.rechargeComboBox.Items.AddRange(new object[] {
            CardMaker.SpellUsage.AtWill,
            CardMaker.SpellUsage.Daily,
            CardMaker.SpellUsage.Encounter});
            this.rechargeComboBox.Location = new System.Drawing.Point(62, 182);
            this.rechargeComboBox.Name = "rechargeComboBox";
            this.rechargeComboBox.Size = new System.Drawing.Size(238, 21);
            this.rechargeComboBox.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Recharge";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Action";
            // 
            // MinionPowerCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rechargeComboBox);
            this.Controls.Add(this.actionComboBox);
            this.Controls.Add(this.descText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.keywordsText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.label1);
            this.Name = "MinionPowerCtrl";
            this.Size = new System.Drawing.Size(304, 210);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox descText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox keywordsText;
        public System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox actionComboBox;
        private System.Windows.Forms.ComboBox rechargeComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
