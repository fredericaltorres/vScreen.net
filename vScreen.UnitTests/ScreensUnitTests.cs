using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace vScreen.UnitTests {
    
    [TestClass]
    public class ScreensUnitTests {

        [TestMethod]
        public void InitializeAndSwitch() {

            var sm = new vScreen.lib.ScreenManager(4);
            sm.Switch(1, IntPtr.Zero);
            WindowUnitTests.Wait(1);
            sm.Switch(0, IntPtr.Zero);
        }
    }
}
