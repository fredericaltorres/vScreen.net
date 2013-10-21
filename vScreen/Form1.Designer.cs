namespace vScreen {
    partial class frmVScreen {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVScreen));
            this.butScreen2 = new System.Windows.Forms.Button();
            this.butScreen3 = new System.Windows.Forms.Button();
            this.butScreen4 = new System.Windows.Forms.Button();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showAllScreensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrShowDesktopBitmap = new System.Windows.Forms.Timer(this.components);
            this.butScreen1 = new System.Windows.Forms.Button();
            this.tmrBkTask = new System.Windows.Forms.Timer(this.components);
            this.tmrClipboard = new System.Windows.Forms.Timer(this.components);
            this.butClipBoard = new System.Windows.Forms.Button();
            this.lblCurrentApp = new System.Windows.Forms.Label();
            this.contextMenuCurrentApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveTo1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveTo2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveTo3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveTo4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripMain.SuspendLayout();
            this.contextMenuCurrentApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // butScreen2
            // 
            this.butScreen2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butScreen2.Location = new System.Drawing.Point(29, 1);
            this.butScreen2.Name = "butScreen2";
            this.butScreen2.Size = new System.Drawing.Size(28, 28);
            this.butScreen2.TabIndex = 1;
            this.butScreen2.Text = "2";
            this.butScreen2.UseVisualStyleBackColor = true;
            // 
            // butScreen3
            // 
            this.butScreen3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butScreen3.Location = new System.Drawing.Point(58, 1);
            this.butScreen3.Name = "butScreen3";
            this.butScreen3.Size = new System.Drawing.Size(28, 28);
            this.butScreen3.TabIndex = 2;
            this.butScreen3.Text = "3";
            this.butScreen3.UseVisualStyleBackColor = true;
            // 
            // butScreen4
            // 
            this.butScreen4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butScreen4.Location = new System.Drawing.Point(87, 1);
            this.butScreen4.Name = "butScreen4";
            this.butScreen4.Size = new System.Drawing.Size(28, 28);
            this.butScreen4.TabIndex = 3;
            this.butScreen4.Text = "4";
            this.butScreen4.UseVisualStyleBackColor = true;
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllScreensToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStrip1";
            this.contextMenuStripMain.Size = new System.Drawing.Size(262, 108);
            // 
            // showAllScreensToolStripMenuItem
            // 
            this.showAllScreensToolStripMenuItem.Name = "showAllScreensToolStripMenuItem";
            this.showAllScreensToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.showAllScreensToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.showAllScreensToolStripMenuItem.Text = "Show All Screens";
            this.showAllScreensToolStripMenuItem.Click += new System.EventHandler(this.showAllScreensToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // tmrShowDesktopBitmap
            // 
            this.tmrShowDesktopBitmap.Interval = 655;
            this.tmrShowDesktopBitmap.Tick += new System.EventHandler(this.tmrShowDesktopBitmap_Tick);
            // 
            // butScreen1
            // 
            this.butScreen1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butScreen1.Location = new System.Drawing.Point(0, 1);
            this.butScreen1.Name = "butScreen1";
            this.butScreen1.Size = new System.Drawing.Size(28, 28);
            this.butScreen1.TabIndex = 0;
            this.butScreen1.Text = "1";
            this.butScreen1.UseVisualStyleBackColor = true;
            // 
            // tmrBkTask
            // 
            this.tmrBkTask.Interval = 1000;
            this.tmrBkTask.Tick += new System.EventHandler(this.tmrBkTask_Tick);
            // 
            // tmrClipboard
            // 
            this.tmrClipboard.Interval = 2000;
            this.tmrClipboard.Tick += new System.EventHandler(this.tmrClipboard_Tick);
            // 
            // butClipBoard
            // 
            this.butClipBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butClipBoard.Location = new System.Drawing.Point(116, 1);
            this.butClipBoard.Name = "butClipBoard";
            this.butClipBoard.Size = new System.Drawing.Size(28, 28);
            this.butClipBoard.TabIndex = 5;
            this.butClipBoard.Text = "C";
            this.butClipBoard.UseVisualStyleBackColor = true;
            this.butClipBoard.Click += new System.EventHandler(this.butClipBoard_Click);
            // 
            // lblCurrentApp
            // 
            this.lblCurrentApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblCurrentApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentApp.ContextMenuStrip = this.contextMenuCurrentApp;
            this.lblCurrentApp.Location = new System.Drawing.Point(0, 35);
            this.lblCurrentApp.Name = "lblCurrentApp";
            this.lblCurrentApp.Size = new System.Drawing.Size(144, 15);
            this.lblCurrentApp.TabIndex = 6;
            this.lblCurrentApp.Text = "Current App";
            // 
            // contextMenuCurrentApp
            // 
            this.contextMenuCurrentApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveTo1ToolStripMenuItem,
            this.moveTo2ToolStripMenuItem,
            this.moveTo3ToolStripMenuItem,
            this.moveTo4ToolStripMenuItem});
            this.contextMenuCurrentApp.Name = "contextMenuCurrentApp";
            this.contextMenuCurrentApp.Size = new System.Drawing.Size(169, 108);
            this.contextMenuCurrentApp.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuCurrentApp_Opening);
            // 
            // moveTo1ToolStripMenuItem
            // 
            this.moveTo1ToolStripMenuItem.Name = "moveTo1ToolStripMenuItem";
            this.moveTo1ToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.moveTo1ToolStripMenuItem.Text = "Move To 1";
            this.moveTo1ToolStripMenuItem.Click += new System.EventHandler(this.moveTo1ToolStripMenuItem_Click);
            // 
            // moveTo2ToolStripMenuItem
            // 
            this.moveTo2ToolStripMenuItem.Name = "moveTo2ToolStripMenuItem";
            this.moveTo2ToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.moveTo2ToolStripMenuItem.Text = "Move To 2";
            this.moveTo2ToolStripMenuItem.Click += new System.EventHandler(this.moveTo2ToolStripMenuItem_Click);
            // 
            // moveTo3ToolStripMenuItem
            // 
            this.moveTo3ToolStripMenuItem.Name = "moveTo3ToolStripMenuItem";
            this.moveTo3ToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.moveTo3ToolStripMenuItem.Text = "Move To 3";
            this.moveTo3ToolStripMenuItem.Click += new System.EventHandler(this.moveTo3ToolStripMenuItem_Click);
            // 
            // moveTo4ToolStripMenuItem
            // 
            this.moveTo4ToolStripMenuItem.Name = "moveTo4ToolStripMenuItem";
            this.moveTo4ToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.moveTo4ToolStripMenuItem.Text = "Move To 4";
            this.moveTo4ToolStripMenuItem.Click += new System.EventHandler(this.moveTo4ToolStripMenuItem_Click);
            // 
            // frmVScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(146, 52);
            this.ContextMenuStrip = this.contextMenuStripMain;
            this.Controls.Add(this.lblCurrentApp);
            this.Controls.Add(this.butClipBoard);
            this.Controls.Add(this.butScreen4);
            this.Controls.Add(this.butScreen3);
            this.Controls.Add(this.butScreen2);
            this.Controls.Add(this.butScreen1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "vScreen";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVScreen_FormClosing);
            this.Load += new System.EventHandler(this.frmVScreen_Load);
            this.contextMenuStripMain.ResumeLayout(false);
            this.contextMenuCurrentApp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butScreen1;
        private System.Windows.Forms.Button butScreen2;
        private System.Windows.Forms.Button butScreen3;
        private System.Windows.Forms.Button butScreen4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Timer tmrShowDesktopBitmap;
        private System.Windows.Forms.Timer tmrBkTask;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer tmrClipboard;
        private System.Windows.Forms.Button butClipBoard;
        private System.Windows.Forms.Label lblCurrentApp;
        private System.Windows.Forms.ContextMenuStrip contextMenuCurrentApp;
        private System.Windows.Forms.ToolStripMenuItem moveTo1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveTo2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveTo3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveTo4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllScreensToolStripMenuItem;
    }
}

