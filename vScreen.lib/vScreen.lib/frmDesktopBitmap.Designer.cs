namespace vScreen {
    partial class frmDesktopBitmap {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.desktopImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.desktopImage)).BeginInit();
            this.SuspendLayout();
            // 
            // desktopImage
            // 
            this.desktopImage.Location = new System.Drawing.Point(0, 0);
            this.desktopImage.Name = "desktopImage";
            this.desktopImage.Size = new System.Drawing.Size(192, 197);
            this.desktopImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.desktopImage.TabIndex = 0;
            this.desktopImage.TabStop = false;
            // 
            // frmDesktopBitmap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 370);
            this.Controls.Add(this.desktopImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDesktopBitmap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmDesktopBitmap";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmDesktopBitmap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.desktopImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox desktopImage;
    }
}