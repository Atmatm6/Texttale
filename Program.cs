using System;
using Gtk;
// ReSharper disable SuggestVarOrType_SimpleTypes

namespace Texttale {
    class MainClass {
	    public static void Main(string[] args) {
	        Application.Init();
	        MainWindow win = new MainWindow();
            Application.Run();
        }
    }
}
