/*
 * vScreen.net
 * (C) Torres Frederic 2013
 * Release under MIT license
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicSugar;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.Drawing;

namespace vScreen.lib {

    public class Screen : Dictionary<IntPtr, Window> {

        public  static int DefaultDesktopBitMapWidth = 384; // 512;
        private static List<IntPtr> _handleToIgnore = new List<IntPtr>();
 
        private static Regex IgnoreTitleRegEx;
        private static Regex IgnoreClassRegEx;

        IntPtr           _currentWindowHandle;
        int              _index;
        frmDesktopBitmap _formDesktopImage;

        public bool IsDisplayingDesktopBitpmap;
        public Window   ProgramManager;
        public string   PngFile;

        public static void AddHandleToIgnore(IntPtr handle) {

            if(!handle.In(_handleToIgnore))
                _handleToIgnore.Add(handle);
        }
        
        public List<IntPtr> GetHandles() {

            var l = (from w in this select w.Value.Handle).ToList(); 
            return l;   
        }

        public bool MoveAppToScreen(IntPtr appHandle, bool hideApp) {

            var r = false;
            var w = new Window(appHandle);

            if(!this.GetHandles().Contains(appHandle)) {
                this.Add(appHandle, w);
                r = true;
            }
            if(hideApp)
                w.Hide();
            return r;
        }

        public string GetLabelText() {

            return "{0} Apps".format(this.Keys.Count);
        }

        public void ShowDesktopImage(int topRef) {

            if(this._formDesktopImage == null)
                this._formDesktopImage = new frmDesktopBitmap();

            this._formDesktopImage.SetImage(this.PngFile, topRef);
            this._formDesktopImage.Show();
            this.IsDisplayingDesktopBitpmap = true;
        }

        public void HideDesktopImage() {

            if(this._formDesktopImage != null) {
                
                this._formDesktopImage.Clean();
                this._formDesktopImage.Hide();
                this.IsDisplayingDesktopBitpmap = false;
                this._formDesktopImage.Close();
                this._formDesktopImage = null;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public bool HasDesktopBitmap {
            get {
                return this.PngFile != null && System.IO.File.Exists(this.PngFile);
            }
        }

        public Screen(int index, bool collect = true) {

            this._index = index;

            if(IgnoreTitleRegEx == null) {

                IgnoreTitleRegEx = new Regex(Settings1.Default.IgnoreTitleRegEx);
                IgnoreClassRegEx = new Regex(Settings1.Default.IgnoreClassRegEx);
            }

            if(collect)
                this.CollectWindows();
        }

        public void CaptureDesktopImage() {

            this.HideDesktopImage();
            this.PngFile = Path.Combine(Util.GetAppTempFolder(), "vScreen.Desktop_{0}.png".format(this._index));
            DesktopGrabber.Capture(this.PngFile, DefaultDesktopBitMapWidth);
        }

        public List<Window> GetWindowByTitle(string regexTitle) {

            var re = new Regex(regexTitle);
            var l = new List<Window>();

            foreach (var k in this)
                if (re.IsMatch(k.Value.Title))
                    l.Add(k.Value);
            
            return l;
        }

        public string GetWindowsInfo() {

            var buf = new StringBuilder();
            foreach (var k in this) {
                buf.Append(k.Value.Title).AppendLine();
            }
            return buf.ToString();
        }

        public List<Window> GetWindowByClass(string regexClass) {

            var re = new Regex(regexClass);
            var l = new List<Window>();

            foreach (var k in this)
                if (re.IsMatch(k.Value.ClassName))
                    l.Add(k.Value);

            return l;
        }

        public void ShowAll() {

            foreach (var k in this)
                k.Value.Show();

            if (this._currentWindowHandle != null && this._currentWindowHandle != IntPtr.Zero)
                new Window(this._currentWindowHandle).SetAsCurrentWindow();

            System.Windows.Forms.Application.DoEvents();
        }

        public void HideAll(IntPtr currentWindowHandle) {

            this.CollectWindows();
            _currentWindowHandle = currentWindowHandle;

            foreach (var k in this)
                k.Value.Hide();
        }

        private bool HandleShouldBeIgnoreForCollection(IntPtr handle) {
        
            return handle.In(_handleToIgnore);
        }

        public static bool WindowShouldBeIgnored(string title, string className) {

            return (title     == null || IgnoreTitleRegEx.IsMatch(title)) || 
                   (className == null || IgnoreClassRegEx.IsMatch(className));
        }

        public Screen CollectWindows() {
            
            this.Clear();

            var deskTopChildrenHandle = WinApi.GetWindow(WinApi.GetDesktopWindow(), WinApi.GetWindow_Cmd.GW_CHILD);
            var handle                = deskTopChildrenHandle;

            while (handle != IntPtr.Zero) {

                if (WinApi.IsWindowVisible(handle) && (!HandleShouldBeIgnoreForCollection(handle))) {

                    var w           = new Window(handle);
                    var title       = w.Title;
                    var className   = w.ClassName;

                    Debug.WriteLine(w.ToString());

                    if (!title.IsNullOrEmpty()) {

                        var include = true;

                        if (w.IsProgramManager)
                            ProgramManager = w;

                        if (WindowShouldBeIgnored(title, className)) {

                            include = false;
                        }

                        if (include)
                            this.Add(w.Handle, w);
                    }
                }
                handle = WinApi.GetWindow(handle, WinApi.GetWindow_Cmd.GW_HWNDNEXT);
            }
            return this;
        }
    }
}
