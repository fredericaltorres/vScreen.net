/*
 * vScreen.net
 * (C) Torres Frederic 2013
 * Release under MIT license
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vScreen.lib {

    public class Window {

        public IntPtr Handle;

        public Window(IntPtr handle) {
        
            this.Handle = handle;
        }

        public bool IsProgramManager {
            get {
                return this.Title == "Program Manager" && this.ClassName == "Progman";
            }
        }

        public  string GetInfo() {

            return DynamicSugar.ExtendedFormat.Format(this, "{ClassName}, {Title}");
        }

        public override string ToString() {

            return DynamicSugar.ExtendedFormat.Format(this, "Handle:{Handle}, ClassName:{ClassName}, Title:{Title}, ({Left},{Top})({Width},{Height})");
        }

        private StringBuilder GetBuffer() {
            
            return new StringBuilder().Append("".PadLeft(1024));
        }

        public void SetAsCurrentWindow() {

            this.Activate();

            WinApi.SetForegroundWindow(this.Handle);
            this.Show();

            var o = new object();
            System.Runtime.InteropServices.HandleRef hd = new System.Runtime.InteropServices.HandleRef(o, this.Handle);

            WinApi.PostMessage(hd, (uint)WinApi.WM.PAINT, IntPtr.Zero, IntPtr.Zero);
        }

        public bool IsValid() {

            return WinApi.IsWindow(this.Handle);
        }

        public void Show() {

            WinApi.ShowWindow(this.Handle, WinApi.ShowWindowCommands.Show);
        }

        public void Hide() {

            WinApi.ShowWindow(this.Handle, WinApi.ShowWindowCommands.Hide);
        }

        public void Maximize() {

            WinApi.ShowWindow(this.Handle, WinApi.ShowWindowCommands.Maximize);
        }

        public void Minimize() {

            WinApi.ShowWindow(this.Handle, WinApi.ShowWindowCommands.Minimize);
        }

        public void UnMinimize() {

            WinApi.ShowWindow(this.Handle, WinApi.ShowWindowCommands.Restore);
        }

        public void Close() {

            WinApi.SendMessage(this.Handle, (uint)WinApi.WM.CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        public string ClassName {
            get {
                var b = GetBuffer();
                var r = WinApi.GetClassName(this.Handle, b, b.Length);
                return b.ToString();
            }
        }

        public string Title {
            get {
                var b = GetBuffer(); 
                var r = WinApi.GetWindowText(this.Handle, b, b.Length);
                return b.ToString();
            }
            set { 
                // TODO: Implement
                throw new NotImplementedException();
            }
        }

        public bool Visible {
            get {
                var b = GetBuffer();
                return WinApi.IsWindowVisible(this.Handle);
            }
            set {
                if (value) {
                    this.Show();
                }
                else {
                    this.Hide();
                }
            }
        }

        public WinApi.RECT Rectangle {
            get {
                WinApi.RECT r;
                var o = new object();
                System.Runtime.InteropServices.HandleRef hd = new System.Runtime.InteropServices.HandleRef(o, this.Handle);
                var rr = WinApi.GetWindowRect(hd, out r);
                return r;
            }
        }

        public int Left {
            get {
                return this.Rectangle.Left;
            }
            set {
                WinApi.MoveWindow(this.Handle, value, this.Top, this.Width, this.Height, true);
            }
        }

        public int Top {
            get {
                return this.Rectangle.Top;
            }
            set {
                WinApi.MoveWindow(this.Handle, this.Left, value, this.Width, this.Height, true);
            }
        }

        public int Width {
            get {
                return this.Rectangle.Right - this.Rectangle.Left;
            }
            set {
                WinApi.MoveWindow(this.Handle, this.Left, this.Top, value, this.Height, true);
            }
        }

        public int Height {
            get {
                return this.Rectangle.Bottom - this.Rectangle.Top;
            }
            set {
                WinApi.MoveWindow(this.Handle, this.Left, this.Top, this.Width, value, true);
            }
        }

        public Bitmap GrabBitMap() {
            throw new NotImplementedException();
        }

        public void Activate() {

           WinApi.SetActiveWindow(this.Handle);
        }

        public void Flash() {
            WinApi.FlashWindow(this.Handle, true);
        }
    }
}
