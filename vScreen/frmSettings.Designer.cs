namespace vScreen {
    partial class frmSettings {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.groupBoxHotKey = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkShift = new System.Windows.Forms.CheckBox();
            this.chkCtrl = new System.Windows.Forms.CheckBox();
            this.chkAlt = new System.Windows.Forms.CheckBox();
            this.groupBoxHotKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // butOK
            // 
            this.butOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOK.Location = new System.Drawing.Point(142, 119);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 0;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(223, 119);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // groupBoxHotKey
            // 
            this.groupBoxHotKey.Controls.Add(this.label1);
            this.groupBoxHotKey.Controls.Add(this.chkShift);
            this.groupBoxHotKey.Controls.Add(this.chkCtrl);
            this.groupBoxHotKey.Controls.Add(this.chkAlt);
            this.groupBoxHotKey.Location = new System.Drawing.Point(12, 12);
            this.groupBoxHotKey.Name = "groupBoxHotKey";
            this.groupBoxHotKey.Size = new System.Drawing.Size(286, 92);
            this.groupBoxHotKey.TabIndex = 4;
            this.groupBoxHotKey.TabStop = false;
            this.groupBoxHotKey.Text = "Hotkeys";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "The use the following key + 1, 2, 3 and 4 keys \r\nto select the four screens\r\n";
            // 
            // chkShift
            // 
            this.chkShift.AutoSize = true;
            this.chkShift.Checked = global::vScreen.Settings1.Default.HotKeyShift;
            this.chkShift.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::vScreen.Settings1.Default, "HotKeyShift", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkShift.Location = new System.Drawing.Point(120, 19);
            this.chkShift.Name = "chkShift";
            this.chkShift.Size = new System.Drawing.Size(47, 17);
            this.chkShift.TabIndex = 2;
            this.chkShift.Text = "Shift";
            this.chkShift.UseVisualStyleBackColor = true;
            // 
            // chkCtrl
            // 
            this.chkCtrl.AutoSize = true;
            this.chkCtrl.Checked = global::vScreen.Settings1.Default.HotKeyCtrl;
            this.chkCtrl.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::vScreen.Settings1.Default, "HotKeyCtrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkCtrl.Location = new System.Drawing.Point(64, 19);
            this.chkCtrl.Name = "chkCtrl";
            this.chkCtrl.Size = new System.Drawing.Size(41, 17);
            this.chkCtrl.TabIndex = 1;
            this.chkCtrl.Text = "Ctrl";
            this.chkCtrl.UseVisualStyleBackColor = true;
            // 
            // chkAlt
            // 
            this.chkAlt.AutoSize = true;
            this.chkAlt.Checked = global::vScreen.Settings1.Default.HotKeyAlt;
            this.chkAlt.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::vScreen.Settings1.Default, "HotKeyAlt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkAlt.Location = new System.Drawing.Point(6, 19);
            this.chkAlt.Name = "chkAlt";
            this.chkAlt.Size = new System.Drawing.Size(38, 17);
            this.chkAlt.TabIndex = 0;
            this.chkAlt.Text = "Alt";
            this.chkAlt.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AcceptButton = this.butOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(311, 153);
            this.Controls.Add(this.groupBoxHotKey);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.groupBoxHotKey.ResumeLayout(false);
            this.groupBoxHotKey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.GroupBox groupBoxHotKey;
        private System.Windows.Forms.CheckBox chkShift;
        private System.Windows.Forms.CheckBox chkCtrl;
        private System.Windows.Forms.CheckBox chkAlt;
        private System.Windows.Forms.Label label1;
    }
}