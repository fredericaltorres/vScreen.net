/*
 * vScreen.net
 * (C) Torres Frederic 2013
 * Release under MIT license
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vScreen {
    public partial class frmDesktopBitmap : Form {

        public frmDesktopBitmap() {

            InitializeComponent();
        }
        public void SetImage(string pngFile, int top) {

            vScreen.lib.Screen.AddHandleToIgnore(this.Handle);

            this.BackColor = Color.Black;
            this.desktopImage.Image = Image.FromFile(pngFile);
            
            this.desktopImage.Left  = 1; // Position control in the form
            this.desktopImage.Top   = 1;
            this.Width              = this.desktopImage.Image.Width+1;
            this.Height             = this.desktopImage.Image.Height+1;
            this.Top                = top - this.Height - 7;
            this.Left               = Screen.PrimaryScreen.Bounds.Width - this.Width - 7;

            this.desktopImage.Click += desktopImage_Click;

            Application.DoEvents();
        }
        void desktopImage_Click(object sender, EventArgs e) {

            #if AS_STAND_ALONE
                vScreen.Program.FormVScreen.ScreenManager.HideAllScreenShot();
            #endif
        }
        private void frmDesktopBitmap_Load(object sender, EventArgs e) {

        }
        public void Clean() {
            if(this.desktopImage.Image!=null)
                this.desktopImage.Image.Dispose();
            this.desktopImage.Image = null;
        }
    }
}
