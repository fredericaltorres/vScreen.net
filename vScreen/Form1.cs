using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicSugar;
using System.Reflection;
using HotKey;
 
namespace vScreen {

    public partial class frmVScreen : Form {

        const int MAX_SCREEN = 4;

        int                          _tmrBackground2SecondCounter = 0;
        vScreen.lib.ClipboardMonitor _clipboardMonitor = new lib.ClipboardMonitor();
        vScreen.lib.Taskbar          _taskBar;
        int                          _indexButtonToShowBitmap = -1;
        IntPtr                       _currentWindowHandle;
        List<Button>                 _buttons = new List<Button>();
        HotkeyManager               _hotkeyManager;
        bool                        _showAllScreenForm;

        public vScreen.lib.ScreenManager ScreenManager;

        public frmVScreen() {

            InitializeComponent();
        }

        List<ToolStripMenuItem> _moveToMenuItems;

        private void InitializeHotKeys() {

            if(_hotkeyManager != null)
                _hotkeyManager.Dispose();
            
            _hotkeyManager = new HotkeyManager(this);

            var m = HotKeyModifierKeys.None;

            if(Settings1.Default.HotKeyAlt) m |= HotKeyModifierKeys.Alt;
            if(Settings1.Default.HotKeyShift) m |= HotKeyModifierKeys.Shift;
            if(Settings1.Default.HotKeyCtrl) m |= HotKeyModifierKeys.Control;

            // In case we run for the first time and there is no config save
            if(m == HotKeyModifierKeys.None) m |= HotKeyModifierKeys.Control;

            _hotkeyManager.RegisterHotKey(m, Keys.D1);
            _hotkeyManager.RegisterHotKey(m, Keys.D2);
            _hotkeyManager.RegisterHotKey(m, Keys.D3);
            _hotkeyManager.RegisterHotKey(m, Keys.D4);
            _hotkeyManager.RegisterHotKey(m, Keys.D0);
        }
        
        protected override void WndProc(ref Message m) {
         
            base.WndProc(ref m);

            if (m.Msg == HotkeyManager.WM_HOTKEY) {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                HotKeyModifierKeys modifier = (HotKeyModifierKeys)((int)m.LParam & 0xFFFF);
                HotkeyPressed(modifier, key);
            }
        }

        public void HotkeyPressed(HotKeyModifierKeys modifierKeys, Keys key) {

            int x = -1;
            switch(key) {
                case Keys.D1 : x = 0; break;
                case Keys.D2 : x = 1; break;
                case Keys.D3 : x = 2; break;
                case Keys.D4 : x = 3; break;
                case Keys.D0 : _showAllScreenForm = true;  break;
                    
            }
            if(x != -1)
                butScreen_Click(_buttons[x], new EventArgs());
        }

        private void frmVScreen_Load(object sender, EventArgs e) {
            
            this.Text = Application.ProductName;

            vScreen.Settings1.Default.Reload();

            _buttons.AddRange(DS.List(butScreen1, butScreen2, butScreen3, butScreen4));

            this._moveToMenuItems   = DS.List(moveTo1ToolStripMenuItem, moveTo2ToolStripMenuItem, moveTo3ToolStripMenuItem, moveTo4ToolStripMenuItem);
            this.lblCurrentApp.Text = string.Empty;
            this._taskBar           = new lib.Taskbar();
            this.Left               = Screen.PrimaryScreen.Bounds.Width - this.Width - 3;
            this.Top                = Screen.PrimaryScreen.Bounds.Height - this.Height - 3 - (this._taskBar.Size.Height);
            ScreenManager           = new lib.ScreenManager(MAX_SCREEN);

            this.butScreen1.Click      += new System.EventHandler(this.butScreen_Click);
            this.butScreen2.Click      += new System.EventHandler(this.butScreen_Click);
            this.butScreen3.Click      += new System.EventHandler(this.butScreen_Click);
            this.butScreen4.Click      += new System.EventHandler(this.butScreen_Click);

            this.butScreen1.MouseLeave += new System.EventHandler(this.butScreen1_MouseLeave);
            this.butScreen1.MouseEnter += new System.EventHandler(this.butScreen1_MouseEnter);
            this.butScreen2.MouseLeave += new System.EventHandler(this.butScreen1_MouseLeave);
            this.butScreen2.MouseEnter += new System.EventHandler(this.butScreen1_MouseEnter);
            this.butScreen3.MouseLeave += new System.EventHandler(this.butScreen1_MouseLeave);
            this.butScreen3.MouseEnter += new System.EventHandler(this.butScreen1_MouseEnter);
            this.butScreen4.MouseLeave += new System.EventHandler(this.butScreen1_MouseLeave);
            this.butScreen4.MouseEnter += new System.EventHandler(this.butScreen1_MouseEnter);

            tmrBkTask.Enabled    = true;
            tmrClipboard.Enabled = true;

            this.InitializeHotKeys();
        }

        private void butScreen_Click(object sender, EventArgs e) {

            // The user clicked on a button, cancel all Desktop bitmap display
            this.butScreen1_MouseLeave(sender, e);

            var currentIndex = this.ScreenManager.ScreenIndex;
            var index        = this._buttons.IndexOf((Button)sender);

            this.ScreenManager.Switch(index, this._currentWindowHandle);

            this.ClearCurrentAppInfo();
            ((Button)(sender)).Focus();
        }

        private void Out(string s) {
            System.Diagnostics.Debug.WriteLine(s);
        }

        private void frmVScreen_FormClosing(object sender, FormClosingEventArgs e) {

            _hotkeyManager.Dispose();

            if(vScreen.lib.Util.MsgBoxYesNo("Do you want to close {0}?".format(Application.ProductName))) {

                this.ScreenManager.Close();
            }
            else {

                e.Cancel = true;
                this.InitializeHotKeys();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            
            if (new frmSettings().OpenDialog()) {

                Settings1.Default.Save();
                InitializeHotKeys();
            }
        }

        private void ShowDesktopBitmap(int index) {

            this.ScreenManager.ShowDesktopBitmap(0, this.Top);
        }


        private void butScreen1_MouseEnter(object sender, EventArgs e) {
            
            this._indexButtonToShowBitmap = _buttons.IndexOf((Button)sender);

            // Do not show the desktop bitmap for the current screen
            if(ScreenManager.ScreenIndex ==  this._indexButtonToShowBitmap) {
                this._indexButtonToShowBitmap = -1;
                return;
            }
            this.tmrShowDesktopBitmap.Enabled = true;
            this.Out("About to show bitpmap for {0}".format(this._indexButtonToShowBitmap));
        }

        private void butScreen1_MouseLeave(object sender, EventArgs e) {

             if(tmrShowDesktopBitmap.Enabled) {
                 // Cancel request to show desktop bitmap
                 this._indexButtonToShowBitmap = -1;
                 tmrShowDesktopBitmap.Enabled = false;
                 this.Out("Canceling showing bitpmap for {0}".format(this._indexButtonToShowBitmap));
             }
             else {
                 // If the bitpmap is already open, close it
                 if( this._indexButtonToShowBitmap != -1) {
                     if(ScreenManager[ this._indexButtonToShowBitmap ].IsDisplayingDesktopBitpmap) {
                         ScreenManager[ this._indexButtonToShowBitmap ].HideDesktopImage();
                         this.Out("Hiding  bitpmap for {0}".format(this._indexButtonToShowBitmap));
                     }
                 }
                 this._indexButtonToShowBitmap = -1; // Cancel request to show desktop bitmp
             }
        }

        private void tmrShowDesktopBitmap_Tick(object sender, EventArgs e) {
            
            tmrShowDesktopBitmap.Enabled = false;

            if(this._indexButtonToShowBitmap != -1 && this.ScreenManager[this._indexButtonToShowBitmap].HasDesktopBitmap) {
                // The user waiting for the desktop bitmap tool tip
                // Let's show it to him
                this.Out("Timer Showing bitpmap for {0}".format(this._indexButtonToShowBitmap));
                this.ScreenManager.ShowDesktopBitmap(this._indexButtonToShowBitmap, this.Top);
            }
        }


        private void tmrBkTask_Tick(object sender, EventArgs e) {

            this._currentWindowHandle = vScreen.lib.WinApi.GetForegroundWindow();
            this._tmrBackground2SecondCounter++;

            if(_showAllScreenForm) {
                this.Focus();
                this.Activate();
                Application.DoEvents();
                _showAllScreenForm = false;
                showAllScreensToolStripMenuItem_Click(null, null);
            }

            if(this._tmrBackground2SecondCounter >= 2) {

                this._tmrBackground2SecondCounter = 0;
                var w                             =  new vScreen.lib.Window(this._currentWindowHandle);

                if(!vScreen.lib.Screen.WindowShouldBeIgnored(w.Title, w.ClassName)) {
                    
                    this.lblCurrentApp.Tag            = w;
                    this.lblCurrentApp.Text           = w.Title;
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e) {

            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {

            vScreen.lib.Util.MsgBox(
                "{0} v {1}\n{2}".format( Application.ProductName, 
                                    Application.ProductVersion,
                                     vScreen.lib.Util.GetAssemblyCopyright(Assembly.GetExecutingAssembly())));
        }

        private void tmrClipboard_Tick(object sender, EventArgs e) {

            if(this._clipboardMonitor.Update()) {

                this.UpdateClipboardButton();
            }
        }

        private void UpdateClipboardButton() {

            butClipBoard.Text = "c{0}".format(this._clipboardMonitor.Snapshots.Count);
        }

        private void butClipBoard_Click(object sender, EventArgs e) {

            var fc = new frmClipboard();
            fc.Open(this._clipboardMonitor);
            this.UpdateClipboardButton();
        }


        private void moveTo1ToolStripMenuItem_Click(object sender, EventArgs e) {

            MoveCurrentAppToScreen(0);
        }

        private void MoveCurrentAppToScreen(int index) {

            var w = this.lblCurrentApp.Tag as vScreen.lib.Window;
            if(w != null) {

                this.ScreenManager.MoveAppToScreen(this.ScreenManager.ScreenIndex, w.Handle, index, true, true);
                this.ClearCurrentAppInfo();
            }
        }

        private void ClearCurrentAppInfo() {

            this.lblCurrentApp.Text = "";
            this.lblCurrentApp.Tag = null;
        }

        private void moveTo2ToolStripMenuItem_Click(object sender, EventArgs e) {

            MoveCurrentAppToScreen(1);
        }

        private void moveTo3ToolStripMenuItem_Click(object sender, EventArgs e) {

            MoveCurrentAppToScreen(2);
        }

        private void moveTo4ToolStripMenuItem_Click(object sender, EventArgs e) {

            MoveCurrentAppToScreen(3);
        }
        
        private void contextMenuCurrentApp_Opening(object sender, CancelEventArgs e) {

            this._moveToMenuItems.ForEach( a => a.Enabled = true );
            this._moveToMenuItems[this.ScreenManager.ScreenIndex].Enabled = false;
        }


        private void showAllScreensToolStripMenuItem_Click(object sender, EventArgs e) {

            int r = 1;

            using(var f = new frmAllScreens()) {

                r = f.OpenDialog(this.ScreenManager);
            }
            if(r != -1 && r != this.ScreenManager.ScreenIndex) {
        
                this.butScreen_Click(_buttons[r], new EventArgs());
            }
        }
    }
}
