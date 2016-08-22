using System;
using System.Net;
using Gtk;

namespace Texttale
{
    public class TextHandler
    {
        private TextView _textView;
        private TextBuffer _textBuffer;
        public TextHandler(TextView textView){
            this._textView = textView;
            this._textBuffer = textView.Buffer;
            DownloadScript();
        }

        public bool Init(){
            bool successful = true;
            _textView.Editable = false;
            if (successful == true) return true;
            return false;
        }

        public void DownloadScript(){
            WebClient wc = new WebClient();
            wc.DownloadFile("http://arbituaryotter.bitballoon.com/intro.xml", "intro.xml");
        }
    }
}