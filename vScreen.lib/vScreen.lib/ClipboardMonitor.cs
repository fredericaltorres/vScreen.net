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
using System.Windows.Forms;
using DynamicSugar;

namespace vScreen.lib {

    public class ClipboardSnapshot {

        byte _errorCounter;

        public DateTime TimeStamp;
        public TextDataFormat Format;
        public string Text;
        public Dictionary<string, object> TextFormatted = new Dictionary<string,object>();

        public bool IsRtf {
            get {
                return this.TextFormatted.ContainsKey(ClipboardMonitor.CLIPBOARD_FORMAT_RTF);
            }
        }
        public bool IsHtml {
            get {
                return this.TextFormatted.ContainsKey(ClipboardMonitor.CLIPBOARD_FORMAT_HTML);
            }
        }
        public bool IsText {
            get {
                return this.TextFormatted.ContainsKey(ClipboardMonitor.CLIPBOARD_FORMAT_TEXT) || this.TextFormatted.ContainsKey(ClipboardMonitor.CLIPBOARD_FORMAT_UNICODETEXT);
            }
        }
        private string GetStringTypeInfo() {

            if(this.IsRtf) return "Rtf";
            if(this.IsHtml) return "Html";
            if(this.IsText) return "Text";
            return "Unknown";
        }
        public string GetTextFirstChars(int max = 512) {
            
            if(this.Text.Length < max)
                return this.Text;

            return this.Text.Substring(0, max);
        }
        public bool Copy() {

            try {
                var o = new DataObject();

                foreach (string format in TextFormatted.Keys)
                {
                    o.SetData(format, TextFormatted[format]);
                }
                Clipboard.SetDataObject(o);
                return true;
            }
            catch {
            }
            return false;
        }
        public ClipboardSnapshot Initialize(bool fastMode) {
            try {
                if(Clipboard.ContainsText()) {

                    this.TimeStamp = DateTime.Now;
                    this.Text      = Clipboard.GetText().Trim(' ','\t','\r','\n');

                    if(this.Text != null && fastMode) {
                        return this;
                    }
                    else if(this.Text != null && !fastMode) {

                        IDataObject _iData = Clipboard.GetDataObject();

                        var formats = _iData.GetFormats();

                        foreach (string format in formats) {

                            if(!format.In(ClipboardMonitor.CLIPBOARD_FORMAT_ENHANCEDMETAFILE))
                                TextFormatted.Add(format, _iData.GetData(format));
                        }

                        var trimmed = this.Text.Trim(' ','\t','\r','\n');

                        if(trimmed.Length > 0) {
                
                            this.Text = trimmed;
                            return this;
                        }
                    }
                }
            }
            catch {
            }
            return null;
        }
        public override bool Equals(object obj) {

            try {
                var o = obj as ClipboardSnapshot;

                if(o != null)
                    return this.Text == o.Text;

                return false;
            }
            catch(System.Exception ex) {
                if(_errorCounter++<3)
                    Util.MsgBoxError("Equals() {0}".FormatString(ex.ToString()));
                return false;
            }
        }
        public override int GetHashCode() {

            return base.GetHashCode();
        }
        public override string ToString() {

            return "{0} - {1}".FormatString(this.GetStringTypeInfo(), this.GetTextFirstChars().Replace(Environment.NewLine, " "));
        }
    }
    public class ClipboardMonitor {

        int _errorCounter = 0;

        const int MAX_ENTRY = 32;

        public const string CLIPBOARD_FORMAT_TEXT        = "Text";
        public const string CLIPBOARD_FORMAT_UNICODETEXT = "UnicodeText";
        public const string CLIPBOARD_FORMAT_HTML        = "HTML Format";
        public const string CLIPBOARD_FORMAT_RTF         = "Rich Text Format";
        public const string CLIPBOARD_FORMAT_ENHANCEDMETAFILE  = "EnhancedMetafile";
         
        public List<ClipboardSnapshot> Snapshots = new List<ClipboardSnapshot>();

        public ClipboardMonitor() {

        }

        public void Clear() {

            Clipboard.Clear();
            this.Snapshots.Clear();
        }

        public void Populate(ListBox lb) {

            lb.Items.Clear();
            var l = Snapshots.Clone();
            l.Reverse();

            foreach(var e in l) {
                if(e != null)
                    lb.Items.Add(e);
            }
        }

        private bool IsNew(ClipboardSnapshot snapshot) {

            try {
                if(this.Snapshots.Count == 0) 
                    return true;

                foreach(var s in this.Snapshots)
                    if(s.Equals(snapshot))
                        return false;

                return true;
            }
            catch(System.Exception ex) {
                if(_errorCounter++<3)
                    Util.MsgBoxError("IsNew() {0}".FormatString(ex.ToString()));
                return false;
            }
        }

        public bool Update() {
             
            if(Clipboard.ContainsText()) {
                var snapshot = new ClipboardSnapshot().Initialize(true);
                if(snapshot == null)
                    return false;

                if(this.IsNew(snapshot)) {

                    var snapshot2 = new ClipboardSnapshot().Initialize(false);
                    if(snapshot2 != null) {
                        this.Snapshots.Add(snapshot2);
                        if(this.Snapshots.Count > MAX_ENTRY) {
                            this.Snapshots.RemoveAt(0);
                        }
                        return true;
                    }
                }
            }
            return false;
        }
    }
}



 /*
                    this.Format = TextDataFormat.Html;
                    if(_iData.GetDataPresent(DataFormats.Html)) {
                        TextFormatted.Add(TextDataFormat.Html, (string) _iData.GetData(DataFormats.Html));
                    }
                    if(_iData.GetDataPresent(DataFormats.Rtf)) {
                       TextFormatted.Add(TextDataFormat.Rtf, (string) _iData.GetData(DataFormats.Rtf));
                    }
                    if(_iData.GetDataPresent(DataFormats.UnicodeText)) {
                        TextFormatted.Add(TextDataFormat.UnicodeText, (string) _iData.GetData(DataFormats.UnicodeText));
                    }
                    if(_iData.GetDataPresent(DataFormats.Text)) {
                        TextFormatted.Add(TextDataFormat.Text, (string) _iData.GetData(DataFormats.Text));
                    }*/



            /*
             * Clipboard.SetDataObject(_iData, true);
            Clipboard.Clear();

            foreach(var f in TextFormatted) {
             
                 Clipboard.SetText(f.Value, f.Key);
            }*/

            //Clipboard.SetText(this.Text, TextDataFormat.Text);
            //switch(this.Format) {
            //    case TextDataFormat.Html :  Clipboard.SetText(this.TextFormatted, this.Format); break;
            //    case TextDataFormat.Rtf :  Clipboard.SetText(this.TextFormatted, this.Format); break;
            //    case TextDataFormat.UnicodeText :  Clipboard.SetText(this.TextFormatted, this.Format); break;
            //}