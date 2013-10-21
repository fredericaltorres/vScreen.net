using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace vScreen.UnitTests {
    
    [TestClass]
    public class ScreenUnitTests {

        [TestMethod]
        public void Collect() {

            var w = new vScreen.lib.Window(WindowUnitTests.StartTestApp());
            var s = new vScreen.lib.Screen(0);

            Assert.IsTrue(s.Count > 0);
            Assert.IsTrue(s.GetWindowByTitle(WindowUnitTests.TestAppTitle).Count == 1);

            WindowUnitTests.KillTestApp();
        }

        [TestMethod]
        public void DoNotCollectNotVisibleWindow() {

            var w = new vScreen.lib.Window(WindowUnitTests.StartTestApp());

            var s1 = new vScreen.lib.Screen(0);
            Assert.IsTrue(s1.GetWindowByTitle(WindowUnitTests.TestAppTitle).Count == 1);

            w.Hide();
            var s2 = new vScreen.lib.Screen(0);
            Assert.IsTrue(s2.GetWindowByTitle(WindowUnitTests.TestAppTitle).Count == 0);

            w.Show();
            var s3 = new vScreen.lib.Screen(0);
            Assert.IsTrue(s3.GetWindowByTitle(WindowUnitTests.TestAppTitle).Count == 1);

            WindowUnitTests.KillTestApp();
        }

        [TestMethod]
        public void HideAllShowAll() {

            WindowUnitTests.Wait(1);
            var s1 = new vScreen.lib.Screen(0);
            s1.HideAll(IntPtr.Zero);
            WindowUnitTests.Wait(2);
            s1.ShowAll();
            WindowUnitTests.Wait(1);
        }
        
        [TestMethod]
        public void HideShowProgramManager() {

            var s = new vScreen.lib.Screen(0);

            if (s.ProgramManager != null) {

                s.ProgramManager.Hide();
                WindowUnitTests.Wait(1);
                s.ProgramManager.Show();
                WindowUnitTests.Wait(1);
            }
        }
    }
}
