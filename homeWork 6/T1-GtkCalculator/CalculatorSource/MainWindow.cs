using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnNumButtonClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        EntryBox.Text += button.Label;
    }

    protected void OnClearButtonClicked(object sender, EventArgs e)
    {
        EntryBox.Text = "";
    }

    protected void OnBackspaceButtonClicked(object sender, EventArgs e)
    {
        if (EntryBox.Text.Length > 0)
        {
            EntryBox.Text = EntryBox.Text.Remove(EntryBox.Text.Length - 1);
        }
    }
}
