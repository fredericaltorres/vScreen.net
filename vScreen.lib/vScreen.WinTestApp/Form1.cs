using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vScreen.lib;
using DynamicSugar;

namespace vScreen.WinTestApp {

    public partial class Form1 : Form {
    
        public Form1() {
            InitializeComponent();
        }

        void ShowUser(string m) {
            this.textBox1.Text += m + Environment.NewLine;
        }

        private void button1_Click(object sender, EventArgs e) {
            
            var w = new Window(this.Handle);
            this.ShowUser("Left:{0}".format(this.Left));
            this.ShowUser("ClassName:{0}\r\nText:{1}\r\n`Visible:{2}\r\nLeft:{3}".format(w.ClassName, w.Title, w.Visible, w.Left));
            this.ShowUser(w.ToString());
        }

        private void Form1_Load(object sender, EventArgs e) {

            this.ShowUser("Ready...");

            var size = 500;
            this.Left = size;
            this.Top = size;
            this.Width = size;
            this.Height = size;
        }
    }
}
