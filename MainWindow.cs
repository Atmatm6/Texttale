using System;
using System.Net;
using System.Threading;
using Gdk;
using Gtk;
// ReSharper disable ArrangeThisQualifier
// ReSharper disable UnusedAnonymousMethodSignature

namespace Texttale
{
    public class MainWindow : Gtk.Window
    {
        public MainWindow() : base(Gtk.WindowType.Toplevel)
        {
            SetDefaultSize(250, 200);
            SetPosition(WindowPosition.Center);
            DeleteEvent += delegate { Application.Quit(); };

            MenuBar mb = new MenuBar();

            Menu filemenu = new Menu();
            MenuItem file = new MenuItem("File");
            file.Submenu = filemenu;

            MenuItem exit = new MenuItem("Exit");
            exit.Activated += OnActivated;
            filemenu.Append(exit);

            mb.Append(file);

            TextView textView = new TextView();
            new Thread(delegate(object o) {
                new TextHandler(textView);
            });

            VBox vbox = new VBox(false, 2);
            vbox.PackStart(mb, false, false, 0);
            vbox.PackStart(textView, true, true, 0);

            Add(vbox);
            WebClient wc = new WebClient();
            byte[] img = wc.DownloadData("http://arbituaryotter.bitballoon.com/def.ico");
            this.Icon = new Pixbuf(img);
            Title = "Texttale";
            ShowAll();
        }

        void OnActivated(object sender, EventArgs args){
            Application.Quit();
        }
    }
}

