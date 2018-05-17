using System;
using Gtk;
using System.Timers;

public partial class MainWindow : Gtk.Window
{
    private Timer timer;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        label6.Text = System.DateTime.Now.ToLongTimeString();
        label6.ModifyBg(StateType.Normal, new Gdk.Color(255, 0, 255));
        label6.ModifyFg(StateType.Normal, new Gdk.Color(0, 255, 0));
        label6.ModifyFont(Pango.FontDescription.FromString("Monospace 36"));

        timer = new Timer(1000);
        timer.Elapsed += OnTimedEvent;
        timer.Start();
    }

    protected void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        //label6.Text = System.DateTime.Now.ToLongTimeString();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        timer.Close();
        Application.Quit();
        a.RetVal = true;
    }
}
