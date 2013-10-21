using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DynamicSugar;

namespace vScreen {

    public partial class frmAllScreens : Form {

        vScreen.lib.ScreenManager _screenManager;
        int                       _selected = -1;
        List<PictureBox>          _pictureBoxes;

        public frmAllScreens() {

            InitializeComponent();
        }

        public void Clean() {

            this._pictureBoxes.ForEach(p => {
                if(p.Image != null)
                    p.Image.Dispose();
                p.Dispose();
            });
        }
        
        public int OpenDialog(vScreen.lib.ScreenManager screenManager) {

            this._pictureBoxes            = DS.List(pictureBox1, pictureBox2, pictureBox3, pictureBox4);
            this._pictureBoxes.ForEach(pp => pp.BorderStyle = BorderStyle.None);
            this._screenManager           = screenManager;
            int margin                    = 4;
            var foundOneImage             = false;

            for(var i=0; i<this._screenManager.Count; i++) {

                var s                         = this._screenManager[i];
                this._pictureBoxes[i].Visible = false;

                if(s.HasDesktopBitmap) {
                
                    foundOneImage = true;
                    var p         = this._pictureBoxes[i];
                    p.Tag         = i;
                    p.Visible     = true;
                    p.Image       = Image.FromFile(s.PngFile);
                    p.Width       = p.Image.Width;
                    p.Height      = p.Image.Height; 
                    switch(i) {
                        case 0 : p.Left = margin; p.Top = margin;                              break;
                        case 1 : p.Left = p.Width + (2*margin); p.Top = margin;                break;
                        case 2 : p.Left = margin; p.Top = p.Height + (2*margin);               break;
                        case 3 : p.Left = p.Width + (2*margin); p.Top = p.Height + (2*margin); break;
                    }
                    this.Width  = p.Width * 2 + margin * 4;
                    this.Height = p.Height * 2 + margin * 8;
                }
            }

            if(!foundOneImage)
                return -1;

            this.butCancel.Left = this.Width + 100; // Hide button

            var r = this.ShowDialog();
            if(r == System.Windows.Forms.DialogResult.OK)
                return _selected;
            else
                return -1;
        }
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {

            if (disposing && (components != null)) {
                components.Dispose();
            }
            this.Clean();
            base.Dispose(disposing);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e) {

            SetStyle(sender, BorderStyle.FixedSingle);
        }

        private static void SetStyle(object sender, BorderStyle borderStyle) {
            var p = sender as PictureBox;
            p.BorderStyle = borderStyle;;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e) {
            SetStyle(sender, BorderStyle.None);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e) {
            var p = sender as PictureBox;
            this._selected = p.Tag.ToString().ToInt();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmAllScreens_Load(object sender, EventArgs e) {

        }
    }
}
