using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;

namespace vScreen.UnitTests {
    
    [TestClass]
    public class WindowUnitTests {

        static string TEST_APP_PATH {
            get {
                return Path.Combine(Environment.GetEnvironmentVariable("TEMP"), "vScreen.WinTestApp.exe");
            }
        }

        static Process _testAppProcess;
        static IntPtr _testAppHandle;

        public static string TestAppTitle = "v Screen Test App";

        public static IntPtr StartTestApp() {

            _testAppProcess = Process.Start(TEST_APP_PATH);
            Wait(1);
            _testAppHandle = _testAppProcess.MainWindowHandle;
            return _testAppHandle;
        }

        public static void KillTestApp() {

            _testAppProcess.Kill();
        }

        public static void Wait(double second) {

            int d = (int)(second * 1000);
            System.Threading.Thread.Sleep(d);
        }

        private static void AssertDefaultSizeAndPositionOfTestAppMainWindow(lib.Window w) {

            var size = 500;
            Assert.AreEqual(size, w.Left);
            Assert.AreEqual(size, w.Top);
            Assert.AreEqual(size, w.Width);
            Assert.AreEqual(size, w.Height);
        }

        [TestMethod]
        public void MoveWindow() {

            var w = new vScreen.lib.Window(StartTestApp());

            AssertDefaultSizeAndPositionOfTestAppMainWindow(w);

            w.Left   += 100;
            w.Top    += 100;
            w.Width  += 100;
            w.Height += 100;

            var newSize = 600;
            Assert.AreEqual(newSize, w.Left);
            Assert.AreEqual(newSize, w.Top);
            Assert.AreEqual(newSize, w.Width);
            Assert.AreEqual(newSize, w.Height);

            KillTestApp();
        }

        [TestMethod]
        public void WindowBasicFeature() {

            var w = new vScreen.lib.Window(StartTestApp());

            Assert.AreEqual(TestAppTitle, w.Title);
            Assert.AreEqual("WindowsForms10.Window.8.app.0.2bf8098_r18_ad1", w.ClassName);

            Assert.IsTrue(w.ClassName.Contains("WindowsForms10"));
            Assert.IsTrue(w.ClassName.Contains(".Window."));

            AssertDefaultSizeAndPositionOfTestAppMainWindow(w);

            KillTestApp();
        }
    }
}
