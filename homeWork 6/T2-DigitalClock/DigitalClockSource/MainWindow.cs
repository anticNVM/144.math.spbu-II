using System;
using Gtk;
using System.Timers;

public partial class MainWindow : Gtk.Window
{
    /// <summary>
    /// The timer.
    /// </summary>
    private Timer _timer;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        SetClockLabelSettings();
        InitializeAndStartTimer();
    }

    /// <summary>
    /// Sets the clock label settings.
    /// </summary>
    private void SetClockLabelSettings()
    {
        clockLabel.Text = System.DateTime.Now.ToLongTimeString();
        clockLabel.ModifyFg(StateType.Normal, new Gdk.Color(0, 255, 0));
        clockLabel.ModifyFont(Pango.FontDescription.FromString("Monospace 36"));
    }

    /// <summary>
    /// Initializes the and start timer.
    /// </summary>
    private void InitializeAndStartTimer()
    {
        _timer = new Timer(1000);
        _timer.Elapsed += OnTimedEvent;
        _timer.Start();
    }

    /// <summary>
    /// Ons the timed event.
    /// </summary>
    /// <param name="source">sender.</param>
    /// <param name="e">args.</param>
    protected void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        clockLabel.Text = System.DateTime.Now.ToLongTimeString();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        _timer.Close();

        Application.Quit();
        a.RetVal = true;
    }
}
