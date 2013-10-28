/*
 * vScreen.net
 * (C) Torres Frederic 2013
 * Release under MIT license
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vScreen.lib {

    public class ScreenManager : List<Screen> {

        public int ScreenIndex = 0;

        public ScreenManager(int max) {

            for(int i = 0; i < max; i++) {

                this.Add(new Screen(i, false));
            }
            this.Current.CollectWindows();
        }

        public void HideAllScreenShot() {

            this.ForEach( s => s.HideDesktopImage() );
        }

        public void MoveAppToScreen(int currentScreenIndex, IntPtr appHandle, int targeScreenIndex, bool hideApp, bool move) {

            this[targeScreenIndex].MoveAppToScreen(appHandle, hideApp);
            if(move && this[currentScreenIndex].ContainsKey(appHandle)) 
                this[currentScreenIndex].Remove(appHandle);
            this.SaveState();
        }

        public Screen Current {
            get {
                return this[this.ScreenIndex];
            }
        }

        public void Close() {

            foreach(var s in this)
                s.ShowAll();
        }

        public bool HasBitmap(int index) {

           return this[index].HasDesktopBitmap;
        }

        public void ShowDesktopBitmap(int index, int topRef) {

            if(this.ScreenIndex == index)
                return;

            if(this.HasBitmap(index))
                this[index].ShowDesktopImage(topRef);
        }

        public void HideDesktopBitmap(int index) {

            if(this.ScreenIndex == index)
                return;

            if(this.HasBitmap(index))
                this[index].HideDesktopImage();
        }

        public void Switch(int index, IntPtr currentWindowHandle) {

            if (index == this.ScreenIndex)
                return;

            this.Current.CaptureDesktopImage();
            this.Current.HideAll(currentWindowHandle);
            this.ScreenIndex = index;
            this.Current.ShowAll();
            this.SaveState();
        }

        private static string StateFileName {
            get {
                return Path.Combine(Environment.GetEnvironmentVariable("TEMP"), System.Windows.Forms.Application.ProductName + ".state");
            }
        }

        private void SaveState() {

            var source = new StringBuilder();
            foreach(var s in this) {

                source.Append(s.GetState()).AppendLine();
            }
            System.IO.File.WriteAllText(StateFileName, source.ToString());
        }

        public static void RestoreState() {
            
            var source  = System.IO.File.ReadAllText(StateFileName);
            source      = source.Replace(Environment.NewLine, " ");
            var handles = source.Split(' ');

            foreach(var handleString in handles) {
                
                if(handleString.Trim().Length > 0) {

                    var handle = int.Parse(handleString);
                    var w      = new Window(new IntPtr(handle));

                    if(w.IsValid())
                        w.Show();
                }
            }
        }
    }
}
