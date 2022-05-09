using System.Drawing;
using System.Windows.Forms;

namespace LookAtTheSteps
{
    partial class Form1
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
            this.ShowMoves = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.ShowMoves.Location = new System.Drawing.Point(450, 34);
            this.ShowMoves.Name = "label1";
            this.ShowMoves.Size = new System.Drawing.Size(25, 25);
            this.ShowMoves.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ShowMoves);
            this.Name = "Form1";
            this.Text = "LookAtTheSteps";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label ShowMoves;

        #endregion
    }
}