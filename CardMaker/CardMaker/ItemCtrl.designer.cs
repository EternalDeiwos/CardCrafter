namespace CardMaker
{
    partial class ItemCtrl
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
            this.label2 = new System.Windows.Forms.Label();
            this.flavourText = new System.Windows.Forms.TextBox();
            this.levelText = new System.Windows.Forms.TextBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.elementsPanel = new System.Windows.Forms.Panel();
            this.elementTabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.addElementButton = new System.Windows.Forms.Button();
            this.removeElementButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.itemVersionPanel = new System.Windows.Forms.Panel();
            this.itemVersionTabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.addVersionButton = new System.Windows.Forms.Button();
            this.removeVersionButton = new System.Windows.Forms.Button();
            this.elementsPanel.SuspendLayout();
            this.elementTabCtrl.SuspendLayout();
            this.itemVersionPanel.SuspendLayout();
            this.itemVersionTabCtrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Flavour Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Level Text";
            // 
            // flavourText
            // 
            this.flavourText.Location = new System.Drawing.Point(77, 55);
            this.flavourText.Multiline = true;
            this.flavourText.Name = "flavourText";
            this.flavourText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.flavourText.Size = new System.Drawing.Size(244, 50);
            this.flavourText.TabIndex = 10;
            // 
            // levelText
            // 
            this.levelText.Location = new System.Drawing.Point(77, 29);
            this.levelText.Name = "levelText";
            this.levelText.Size = new System.Drawing.Size(244, 20);
            this.levelText.TabIndex = 9;
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(77, 3);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(244, 20);
            this.nameText.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Power Name";
            // 
            // elementsPanel
            // 
            this.elementsPanel.Controls.Add(this.elementTabCtrl);
            this.elementsPanel.Location = new System.Drawing.Point(6, 317);
            this.elementsPanel.Name = "elementsPanel";
            this.elementsPanel.Size = new System.Drawing.Size(315, 183);
            this.elementsPanel.TabIndex = 17;
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
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(307, 157);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Element 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // addElementButton
            // 
            this.addElementButton.Location = new System.Drawing.Point(3, 506);
            this.addElementButton.Name = "addElementButton";
            this.addElementButton.Size = new System.Drawing.Size(75, 23);
            this.addElementButton.TabIndex = 24;
            this.addElementButton.Text = "Add";
            this.addElementButton.UseVisualStyleBackColor = true;
            this.addElementButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeElementButton
            // 
            this.removeElementButton.Location = new System.Drawing.Point(84, 506);
            this.removeElementButton.Name = "removeElementButton";
            this.removeElementButton.Size = new System.Drawing.Size(75, 23);
            this.removeElementButton.TabIndex = 23;
            this.removeElementButton.Text = "Remove";
            this.removeElementButton.UseVisualStyleBackColor = true;
            this.removeElementButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(165, 506);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 22;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(246, 506);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 21;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // itemVersionPanel
            // 
            this.itemVersionPanel.Controls.Add(this.itemVersionTabCtrl);
            this.itemVersionPanel.Location = new System.Drawing.Point(6, 111);
            this.itemVersionPanel.Name = "itemVersionPanel";
            this.itemVersionPanel.Size = new System.Drawing.Size(311, 171);
            this.itemVersionPanel.TabIndex = 25;
            // 
            // itemVersionTabCtrl
            // 
            this.itemVersionTabCtrl.Controls.Add(this.tabPage2);
            this.itemVersionTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemVersionTabCtrl.Location = new System.Drawing.Point(0, 0);
            this.itemVersionTabCtrl.Name = "itemVersionTabCtrl";
            this.itemVersionTabCtrl.SelectedIndex = 0;
            this.itemVersionTabCtrl.Size = new System.Drawing.Size(311, 171);
            this.itemVersionTabCtrl.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(303, 145);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Item Version 1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // addVersionButton
            // 
            this.addVersionButton.Location = new System.Drawing.Point(165, 288);
            this.addVersionButton.Name = "addVersionButton";
            this.addVersionButton.Size = new System.Drawing.Size(75, 23);
            this.addVersionButton.TabIndex = 27;
            this.addVersionButton.Text = "Add";
            this.addVersionButton.UseVisualStyleBackColor = true;
            this.addVersionButton.Click += new System.EventHandler(this.addVersionButton_Click);
            // 
            // removeVersionButton
            // 
            this.removeVersionButton.Location = new System.Drawing.Point(246, 288);
            this.removeVersionButton.Name = "removeVersionButton";
            this.removeVersionButton.Size = new System.Drawing.Size(75, 23);
            this.removeVersionButton.TabIndex = 26;
            this.removeVersionButton.Text = "Remove";
            this.removeVersionButton.UseVisualStyleBackColor = true;
            this.removeVersionButton.Click += new System.EventHandler(this.removeVersionButton_Click);
            // 
            // ItemCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addVersionButton);
            this.Controls.Add(this.removeVersionButton);
            this.Controls.Add(this.itemVersionPanel);
            this.Controls.Add(this.addElementButton);
            this.Controls.Add(this.removeElementButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.elementsPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flavourText);
            this.Controls.Add(this.levelText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.label1);
            this.Name = "ItemCtrl";
            this.Size = new System.Drawing.Size(324, 532);
            this.elementsPanel.ResumeLayout(false);
            this.elementTabCtrl.ResumeLayout(false);
            this.itemVersionPanel.ResumeLayout(false);
            this.itemVersionTabCtrl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox flavourText;
        public System.Windows.Forms.TextBox levelText;
        public System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel elementsPanel;
        private System.Windows.Forms.TabControl elementTabCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button addElementButton;
        private System.Windows.Forms.Button removeElementButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel itemVersionPanel;
        private System.Windows.Forms.TabControl itemVersionTabCtrl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button addVersionButton;
        private System.Windows.Forms.Button removeVersionButton;
    }
}
