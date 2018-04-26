using System;
using Gtk;
using CalculatorSource;

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

    protected void OnEvaluateButtonClicked(object sender, EventArgs e)
    {
        try
        {
            EntryBox.Text = Calculator.Evaluate(EntryBox.Text).ToString();
        }
        catch (CalculatorSource.Exceptions.InvalidExpressionException ex)
        {
            MessageBox.Show(ex.Message);
            EntryBox.Text = string.Empty;
        }
    }

    private static class MessageBox 
    { 
        public static void Show(Gtk.Window parent_window, DialogFlags flags, MessageType msgtype, ButtonsType btntype, string msg)
        { 
            MessageDialog md = new MessageDialog (parent_window, flags, msgtype, btntype, msg); 
            md.Run (); 
            md.Destroy(); 
        } 
        public static void Show(string msg)
        { 
            MessageDialog md = new MessageDialog (null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, msg);
            md.Run ();
            md.Destroy();
        }   
    } 
}
