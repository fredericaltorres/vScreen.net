namespace vScreen {
    partial class frmClipboard {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClipboard));
            this.lbClipboardEntries = new System.Windows.Forms.ListBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.butCopy = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.butClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbClipboardEntries
            // 
            this.lbClipboardEntries.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClipboardEntries.FormattingEnabled = true;
            this.lbClipboardEntries.ItemHeight = 16;
            this.lbClipboardEntries.Location = new System.Drawing.Point(12, 12);
            this.lbClipboardEntries.Name = "lbClipboardEntries";
            this.lbClipboardEntries.Size = new System.Drawing.Size(152, 356);
            this.lbClipboardEntries.TabIndex = 0;
            this.lbClipboardEntries.Click += new System.EventHandler(this.lbClipboardEntries_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(170, 12);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox.Size = new System.Drawing.Size(652, 101);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(170, 119);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(652, 120);
            this.textBox.TabIndex = 2;
            // 
            // butCopy
            // 
            this.butCopy.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butCopy.Location = new System.Drawing.Point(624, 356);
            this.butCopy.Name = "butCopy";
            this.butCopy.Size = new System.Drawing.Size(96, 29);
            this.butCopy.TabIndex = 3;
            this.butCopy.Text = "Copy";
            this.butCopy.UseVisualStyleBackColor = true;
            this.butCopy.Click += new System.EventHandler(this.butCopy_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(726, 357);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(96, 29);
            this.butCancel.TabIndex = 5;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // butClear
            // 
            this.butClear.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butClear.Location = new System.Drawing.Point(522, 356);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(96, 29);
            this.butClear.TabIndex = 6;
            this.butClear.Text = "Clear";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // frmClipboard
            // 
            this.AcceptButton = this.butCopy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(834, 398);
            this.Controls.Add(this.butClear);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butCopy);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.lbClipboardEntries);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClipboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clipboard History";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbClipboardEntries;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button butCopy;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butClear;
    }
}