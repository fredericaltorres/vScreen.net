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
    public partial class frmSettings : Form {

        public frmSettings() {
            InitializeComponent();
        }

        public bool OpenDialog() {

       

            if (this.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                return true;
            }
            return false;
        }
    }
}
