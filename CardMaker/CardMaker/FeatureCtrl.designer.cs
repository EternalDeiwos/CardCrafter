﻿namespace CardMaker
{
    partial class FeatureCtrl<T>
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
            this.label2 = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.descText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Description";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(69, 3);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(218, 20);
            this.nameText.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Name";
            // 
            // descText
            // 
            this.descText.Location = new System.Drawing.Point(69, 28);
            this.descText.Multiline = true;
            this.descText.Name = "descText";
            this.descText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descText.Size = new System.Drawing.Size(218, 50);
            this.descText.TabIndex = 49;
            // 
            // FeatureCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.descText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.label1);
            this.Name = "FeatureCtrl";
            this.Size = new System.Drawing.Size(290, 81);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox descText;
    }
}
