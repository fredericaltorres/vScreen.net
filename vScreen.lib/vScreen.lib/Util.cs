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
using System.Windows.Forms;
using System.Reflection;

namespace vScreen.lib {

    public class Util {

        public static string GetAssemblyCopyright(Assembly assembly = null) {
            if(assembly==null)
                assembly = Assembly.GetExecutingAssembly();
            string s = ((AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCopyrightAttribute), false)).Copyright;
            return s;
        }

        public static string GetAssemblyCompany(Assembly assembly = null) {

            if(assembly==null)
                assembly = Assembly.GetExecutingAssembly();
            string s = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCompanyAttribute), false)).Company;
            return s;
        }

        public static void MsgBox(string message)
        {
            System.Windows.Forms.MessageBox.Show(message, Application.ProductName);
        }
        public static void MsgBoxError(System.Exception ex, string message = null)
        {
            if (message == null)
            {
                System.Windows.Forms.MessageBox.Show("Error:{0}\r\n{1}".FormatString(ex.Message, ex.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Error:{0}\r\n{1}".FormatString(message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error));
            }
        }
        public static void MsgBoxError(string message)
        {
            System.Windows.Forms.MessageBox.Show("Error:{0}".FormatString(message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static bool MsgBoxYesNo(string message, string title = null)
        {
            title = title == null ? Application.ProductName : title;
            return System.Windows.Forms.MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static string CreateFolder(string f) {

            if(!System.IO.Directory.Exists(f))
                System.IO.Directory.CreateDirectory(f);
            return f;
        }

        public static string GetAppTempFolder() {

            return CreateFolder(System.IO.Path.Combine(Environment.GetEnvironmentVariable("TEMP"), "vScreen"));
        }
        
    }
}
