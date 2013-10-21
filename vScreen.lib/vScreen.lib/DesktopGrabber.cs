/*
 * vScreen.net
 * (C) Torres Frederic 2013
 * Release under MIT license
 * 
 * http://www.codeproject.com/Articles/3024/Capturing-the-Screen-Image-in-C
 * Capturing the Screen Image in C#
 * By Agha Ali Raza, 27 Feb 2003
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using DynamicSugar;

namespace vScreen.lib {

    public class DesktopGrabber {

        private static int __errorCounter;

        /// <summary>
        /// Capture the screen by using the clipboard which is not good
        /// </summary>
        /// <param name="pngFileName"></param>
        /// <param name="desktopImageWidth"></param>
        /// <returns></returns>
        public static string Capture(string pngFileName, int desktopImageWidth) {  
            try {
                Bitmap b = CaptureScreen.CaptureScreen.GetDesktopImage();

                if(System.IO.File.Exists(pngFileName)) {
                    System.IO.File.Delete(pngFileName);
                }

                var imagePercentResize = desktopImageWidth * 100.0 / b.Width ;
                var size               = new Size() { Width = desktopImageWidth, Height = b.Height * (int)imagePercentResize / 100 };
                var b2                 = new Bitmap(b, size);

                b2.Save(pngFileName);
                b.Dispose();
                b2.Dispose();
                return pngFileName;
            }
            catch(System.Exception ex) {
                // Show the error for the first three time, after that give up.
                // This more for me to be aware of this issue
                if(++__errorCounter < 32) {
                    Util.MsgBoxError(ex, "Error capturing screen file:{0}".format(pngFileName));
                }
                var m = ex.ToString();
            }
            return null;
        }
    }


namespace CaptureScreen
{
	public class PlatformInvokeUSER32
	{
		public  const int SM_CXSCREEN=0;
		public  const int SM_CYSCREEN=1;
	
		[DllImport("user32.dll", EntryPoint="GetDesktopWindow")]
		public static extern IntPtr GetDesktopWindow();

		[DllImport("user32.dll",EntryPoint="GetDC")]
		public static extern IntPtr GetDC(IntPtr ptr);

		[DllImport("user32.dll",EntryPoint="GetSystemMetrics")]
		public static extern int GetSystemMetrics(int abc);

		[DllImport("user32.dll",EntryPoint="GetWindowDC")]
		public static extern IntPtr GetWindowDC(Int32 ptr);

		[DllImport("user32.dll",EntryPoint="ReleaseDC")]
		public static extern IntPtr ReleaseDC(IntPtr hWnd,IntPtr hDc);

		public PlatformInvokeUSER32()
		{
		}
	}
	public struct SIZE
	{
		public int cx;
		public int cy;
	}
	public class PlatformInvokeGDI32
	{
		public  const int SRCCOPY = 13369376;
		[DllImport("gdi32.dll",EntryPoint="DeleteDC")]
		public static extern IntPtr DeleteDC(IntPtr hDc);

		[DllImport("gdi32.dll",EntryPoint="DeleteObject")]
		public static extern IntPtr DeleteObject(IntPtr hDc);

		[DllImport("gdi32.dll",EntryPoint="BitBlt")]
		public static extern bool BitBlt(IntPtr hdcDest,int xDest,int yDest,int wDest,int hDest,IntPtr hdcSource,int xSrc,int ySrc,int RasterOp);

		[DllImport ("gdi32.dll",EntryPoint="CreateCompatibleBitmap")]
		public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc,	int nWidth, int nHeight);

		[DllImport ("gdi32.dll",EntryPoint="CreateCompatibleDC")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		[DllImport ("gdi32.dll",EntryPoint="SelectObject")]
		public static extern IntPtr SelectObject(IntPtr hdc,IntPtr bmp);
	
		public PlatformInvokeGDI32()
		{
		}
	}
    
	public class CaptureScreen
	{
		public static Bitmap GetDesktopImage()
		{
			SIZE size;
			IntPtr hBitmap;
			IntPtr 	hDC = PlatformInvokeUSER32.GetDC(PlatformInvokeUSER32.GetDesktopWindow()); 
			IntPtr hMemDC = PlatformInvokeGDI32.CreateCompatibleDC(hDC);
			size.cx = PlatformInvokeUSER32.GetSystemMetrics(PlatformInvokeUSER32.SM_CXSCREEN);
			size.cy = PlatformInvokeUSER32.GetSystemMetrics(PlatformInvokeUSER32.SM_CYSCREEN);
			hBitmap = PlatformInvokeGDI32.CreateCompatibleBitmap(hDC, size.cx, size.cy);

			if (hBitmap!=IntPtr.Zero)
			{
				IntPtr hOld = (IntPtr) PlatformInvokeGDI32.SelectObject(hMemDC, hBitmap);
				PlatformInvokeGDI32.BitBlt(hMemDC, 0, 0,size.cx,size.cy, hDC, 0, 0, PlatformInvokeGDI32.SRCCOPY);
				PlatformInvokeGDI32.SelectObject(hMemDC, hOld);
				PlatformInvokeGDI32.DeleteDC(hMemDC);
				PlatformInvokeUSER32.ReleaseDC(PlatformInvokeUSER32.GetDesktopWindow(), hDC);
				Bitmap bmp = System.Drawing.Image.FromHbitmap(hBitmap); 
				PlatformInvokeGDI32.DeleteObject(hBitmap);
				return bmp;
			}
			return null;
		}
	}
}







}
