namespace CardMaker
{
    partial class PowerCtrl
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.levelText = new System.Windows.Forms.TextBox();
            this.flavourText = new System.Windows.Forms.TextBox();
            this.usageText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.keywordsText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.actionType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.attackType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rangeText = new System.Windows.Forms.TextBox();
            this.elementsPanel = new System.Windows.Forms.Panel();
            this.elementTabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cancelButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.elementCtrl = new ElementCtrl(tabPage1);
            this.elementCtrl.SuspendLayout();
            this.elementsPanel.SuspendLayout();
            this.elementTabCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Power Name";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(77, 3);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(244, 20);
            this.nameText.TabIndex = 1;
            // 
            // levelText
            // 
            this.levelText.Location = new System.Drawing.Point(77, 29);
            this.levelText.Name = "levelText";
            this.levelText.Size = new System.Drawing.Size(244, 20);
            this.levelText.TabIndex = 2;
            // 
            // flavourText
            // 
            this.flavourText.Location = new System.Drawing.Point(77, 55);
            this.flavourText.Multiline = true;
            this.flavourText.Name = "flavourText";
            this.flavourText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.flavourText.Size = new System.Drawing.Size(244, 50);
            this.flavourText.TabIndex = 3;
            // 
            // usageText
            // 
            this.usageText.Location = new System.Drawing.Point(77, 111);
            this.usageText.Name = "usageText";
            this.usageText.Size = new System.Drawing.Size(244, 20);
            this.usageText.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Level Text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Flavour Text";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Usage";
            // 
            // keywordsText
            // 
            this.keywordsText.Location = new System.Drawing.Point(77, 137);
            this.keywordsText.Name = "keywordsText";
            this.keywordsText.Size = new System.Drawing.Size(244, 20);
            this.keywordsText.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Keywords";
            // 
            // actionType
            // 
            this.actionType.FormattingEnabled = true;
            this.actionType.Items.AddRange(new object[] {
            CardMaker.ActionType.None,
            CardMaker.ActionType.Free,
            CardMaker.ActionType.Interrupt,
            CardMaker.ActionType.Reaction,
            CardMaker.ActionType.Minor,
            CardMaker.ActionType.Move,
            CardMaker.ActionType.Standard});
            this.actionType.Location = new System.Drawing.Point(77, 163);
            this.actionType.Name = "actionType";
            this.actionType.Size = new System.Drawing.Size(244, 21);
            this.actionType.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Action";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Attack";
            // 
            // attackType
            // 
            this.attackType.FormattingEnabled = true;
            this.attackType.Items.AddRange(new object[] {
            CardMaker.AttackType.Melee,
            CardMaker.AttackType.Ranged,
            CardMaker.AttackType.Close_Burst,
            CardMaker.AttackType.Close_Blast,
            CardMaker.AttackType.Area_Blast,
            CardMaker.AttackType.Area_Wall,
            CardMaker.AttackType.Personal});
            this.attackType.Location = new System.Drawing.Point(77, 190);
            this.attackType.Name = "attackType";
            this.attackType.Size = new System.Drawing.Size(244, 21);
            this.attackType.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Range";
            // 
            // rangeText
            // 
            this.rangeText.Location = new System.Drawing.Point(77, 217);
            this.rangeText.Name = "rangeText";
            this.rangeText.Size = new System.Drawing.Size(244, 20);
            this.rangeText.TabIndex = 14;
            // 
            // elementsPanel
            // 
            this.elementsPanel.Controls.Add(this.elementTabCtrl);
            this.elementsPanel.Location = new System.Drawing.Point(6, 243);
            this.elementsPanel.Name = "elementsPanel";
            this.elementsPanel.Size = new System.Drawing.Size(315, 183);
            this.elementsPanel.TabIndex = 16;
            // 
            // elementTabCtrl
            // 
            this.elementTabCtrl.Controls.Add(this.tabPage1);
            this.elementTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementTabCtrl.Location = new System.Drawing.Point(0, 0);
            this.elementTabCtrl.Name = "elementTabCtrl";
            this.elementTabCtrl.SelectedIndex = 0;
            this.elementTabCtrl.Size = new System.Drawing.Size(315, 183);
            this.elementTabCtrl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.elementCtrl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(307, 157);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Element 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // elementCtrl
            // 
            this.elementCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementCtrl.Location = new System.Drawing.Point(3, 3);
            this.elementCtrl.Name = "elementCtrl";
            this.elementCtrl.Size = new System.Drawing.Size(301, 151);
            this.elementCtrl.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(246, 438);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(165, 438);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 18;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(3, 438);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 20;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(84, 438);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 19;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // PowerCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.elementsPanel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rangeText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.attackType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.actionType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.keywordsText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usageText);
            this.Controls.Add(this.flavourText);
            this.Controls.Add(this.levelText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.label1);
            this.Name = "PowerCtrl";
            this.Size = new System.Drawing.Size(324, 464);
            this.elementsPanel.ResumeLayout(false);
            this.elementTabCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel elementsPanel;
        public System.Windows.Forms.TextBox nameText;
        public System.Windows.Forms.TextBox levelText;
        public System.Windows.Forms.TextBox flavourText;
        public System.Windows.Forms.TextBox usageText;
        public System.Windows.Forms.TextBox keywordsText;
        public System.Windows.Forms.ComboBox actionType;
        public System.Windows.Forms.ComboBox attackType;
        public System.Windows.Forms.TextBox rangeText;
        private System.Windows.Forms.TabControl elementTabCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button updateButton;
        private ElementCtrl elementCtrl;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
    }
}
