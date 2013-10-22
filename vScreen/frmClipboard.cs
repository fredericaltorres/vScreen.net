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

namespace vScreen {

    public partial class frmClipboard : Form {


        vScreen.lib.ClipboardMonitor _clipboardMonitor = new lib.ClipboardMonitor();

        public frmClipboard() {
            InitializeComponent();
        }

        public void Open(vScreen.lib.ClipboardMonitor clipboardMonitor) {

            vScreen.lib.Screen.AddHandleToIgnore(this.Handle);

            this._clipboardMonitor  = clipboardMonitor; 
            this.textBox.Top        = this.richTextBox.Top;
            this.textBox.Height     = this.richTextBox.Height = (this.Height/4*3);
            this.textBox.Visible    = false;

            this.Populate();
            this.ShowDialog();
        }

        private void Populate() {

            this._clipboardMonitor.Populate(this.lbClipboardEntries);
        }

        private vScreen.lib.ClipboardSnapshot GetSelectedSnapshot() {

            if(this.lbClipboardEntries.SelectedIndex != -1)
                return lbClipboardEntries.Items[lbClipboardEntries.SelectedIndex] as vScreen.lib.ClipboardSnapshot;

            return null;
        }

      
        private void lbClipboardEntries_Click(object sender, EventArgs e) {

            var snapshot = this.GetSelectedSnapshot();

            if(snapshot != null) {

                this.textBox.Visible     = false;
                this.richTextBox.Visible = false;

                TextDataFormat formatToDisplay = TextDataFormat.Text;

                if(snapshot.TextFormatted.ContainsKey(ClipboardMonitor.CLIPBOARD_FORMAT_RTF))
                    formatToDisplay = TextDataFormat.Rtf;
                else if(snapshot.TextFormatted.ContainsKey(ClipboardMonitor.CLIPBOARD_FORMAT_HTML))
                    formatToDisplay = TextDataFormat.Html;
                else if(snapshot.TextFormatted.ContainsKey(ClipboardMonitor.CLIPBOARD_FORMAT_UNICODETEXT))
                    formatToDisplay = TextDataFormat.UnicodeText;
                else if(snapshot.TextFormatted.ContainsKey(ClipboardMonitor.CLIPBOARD_FORMAT_TEXT))
                    formatToDisplay = TextDataFormat.Text;

                switch(formatToDisplay) {

                    case TextDataFormat.Rtf: 
                        this.richTextBox.Visible = true;
                        this.richTextBox.Rtf = snapshot.TextFormatted[ClipboardMonitor.CLIPBOARD_FORMAT_RTF] as string;
                        break;
                    case TextDataFormat.Html: 
                        this.textBox.Visible = true;
                        this.textBox.Text = snapshot.TextFormatted[ClipboardMonitor.CLIPBOARD_FORMAT_HTML] as string;
                        break;
                        case TextDataFormat.UnicodeText: 
                        this.textBox.Visible = true;
                        this.textBox.Text = snapshot.TextFormatted[ClipboardMonitor.CLIPBOARD_FORMAT_UNICODETEXT] as string;
                        break;
                    default :
                        this.textBox.Visible = true;
                        this.textBox.Text = snapshot.TextFormatted[ClipboardMonitor.CLIPBOARD_FORMAT_TEXT] as string;
                        break;
                }
            }
        }

        private void butCopy_Click(object sender, EventArgs e) {
            
            var snapshot = this.GetSelectedSnapshot();

            if(snapshot != null) {

                snapshot.Copy();
            }
        }

        private void butClear_Click(object sender, EventArgs e) {

            this._clipboardMonitor.Clear();
            
        }
    }
}
