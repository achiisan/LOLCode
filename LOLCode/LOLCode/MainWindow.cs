using System;
using Gtk;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using LOLCode;

public partial class MainWindow: Gtk.Window
{

	public LinkedList<Lexeme> lexemelist;
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		BuildLexemes ();

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButton1Clicked (object sender, EventArgs e)
	{
		textview4.Buffer.Text = "";
		textview5.Buffer.Text = "";

		Gtk.TextBuffer bfr = textview3.Buffer;
		String stringer = bfr.Text;



		String [] arr = stringer.Split ('\n');


		foreach (String a in arr) {
			foreach (Lexeme l in lexemelist) {
				
				Match m = Regex.Match (a, "" + l.regex);

				if (m.Success) {
					Match k;

					Gtk.TextBuffer bfr2 = textview4.Buffer;
					bfr2.Text = bfr2.Text + " " + l.lexeme + "\n";
					Gtk.TextBuffer bfr3 = textview5.Buffer;
					bfr3.Text = bfr3.Text + " " + l.classification + "\n";

					if (l.lexeme.Equals ("I HAS A") || l.lexeme.Equals ("GIMMEH") || l.lexeme.Equals("VISIBLE")) {
						//evaluate kadikit ng command
						String cleanPath = cutText (m.Value, l.lexeme);

					
						bfr2.Text = bfr2.Text + " " + cleanPath + "\n";
						bfr3.Text = bfr3.Text + " " + "Identifier" + "\n"; //get variable

						//evaluate second command
					
						if(l.lexeme.Equals("I HAS A")){ //for I HAS A check for ITZ
							k = Regex.Match(a, "ITZ ?[A-Za-z0-9][A-Za-z0-9]*");
							if (k.Success) {
								bfr2.Text = bfr2.Text + " " + "ITZ" + "\n";
								bfr3.Text = bfr3.Text + " " + "Value Indicator" + "\n"; //get variable

								cleanPath = cutText (k.Value, "ITZ");

								bfr2.Text = bfr2.Text + " " + cleanPath + "\n";
								bfr3.Text = bfr3.Text + " " + "Variable Value" + "\n"; //get variable
							}
						}
					}
					if (l.lexeme.Equals ("R") || l.lexeme.Equals ("SUM OF") || l.lexeme.Equals("DIFF OF") || l.lexeme.Equals("QUOSHUNT OF") || l.lexeme.Equals("PRODUKT OF") || l.lexeme.Equals("MOD OF") || l.lexeme.Equals("BIGGR OF") || l.lexeme.Equals("SMALLR OF")) {
						
						Console.WriteLine ("PASOK");
						if (l.lexeme.Equals ("R")) {
							
							int index = m.Value.IndexOf (" R ");
							String c = cutText (m.Value, index + 1, 2);
							Console.WriteLine (c);
							String[] x = c.Split (' ');
							bfr2.Text = bfr2.Text + x [0] + "\n";
							bfr3.Text = bfr3.Text + " " + "Variable Indicator" + "\n"; //get variable
							bfr2.Text = bfr2.Text + x [1] + "\n";
							bfr3.Text = bfr3.Text + " " + "Variable Value" + "\n"; //get variable
						}else {
							Console.WriteLine ("PASOK");
							String d = cutText (m.Value, l.lexeme+" ");
							int index = d.IndexOf (" AN ");
							String c = cutText (d, index + 1, 3);
							Console.WriteLine (c);
							String[] x = c.Split (' ');
							bfr2.Text = bfr2.Text + x [0] + "\n";
							bfr3.Text = bfr3.Text + " " + "Variable Indicator" + "\n"; //get variable
							bfr2.Text = bfr2.Text + "AN" + "\n";
							bfr3.Text = bfr3.Text + " " + "And Operator" + "\n"; //get variable
							bfr2.Text = bfr2.Text + x [1] + "\n";
							bfr3.Text = bfr3.Text + " " + "Variable Value" + "\n"; //get variable


						}
					} 
							
							//evaluate comment
					k = Regex.Match(a, @"BTW .*");
						if(k.Success){
							bfr2.Text = bfr2.Text + " " + "BTW" + "\n";
							bfr3.Text = bfr3.Text + " " + "Comment Indicator" + "\n"; //get variable

							string cleanPath = cutText (k.Value, "BTW");

							bfr2.Text = bfr2.Text + " " + cleanPath + "\n";
							bfr3.Text = bfr3.Text + " " + "Comment Block" + "\n"; //get variable
						}

				}
			}
		}

	}

	protected void BuildLexemes() {
		lexemelist = new LinkedList<Lexeme> ();

		lexemelist.AddLast(new Lexeme("HAI", "Code Delimeter", "HAI$"));
		lexemelist.AddLast(new Lexeme("KTHXBYE", "Code Delimeter", "KTHXBYE$"));
		lexemelist.AddLast (new Lexeme ("I HAS A", "Variable Declaration", "I HAS A [A-Za-z][a-zA-Z0-9]*"));
		lexemelist.AddLast (new Lexeme ("GIMMEH", "Input Declaration", "GIMMEH [A-Za-z][a-zA-Z0-9]*"));
		lexemelist.AddLast (new Lexeme ("VISIBLE", "Output Declaration", "VISIBLE .*"));
		lexemelist.AddLast (new Lexeme ("OBTW", "Comment Block Identifier", "^OBTW$"));
		lexemelist.AddLast(new Lexeme("TLDR", "Comment Block End Identifier", "^TLDR$"));
		lexemelist.AddLast (new Lexeme ("R", "Assignment Statement", "[A-Za-z][A-Za-z0-9]* R .*"));
		lexemelist.AddLast(new Lexeme("SUM OF", "Addition Operator", "SUM OF ([A-Za-z][A-Za-z0-9]*|[0-9]*) AN ([A-Za-z][A-Za-z0-9]*|[0-9]*)"));
		lexemelist.AddLast(new Lexeme("DIFF OF", "Subtraction Operator", "DIFF OF ([A-Za-z][A-Za-z0-9]*|[0-9]*) AN ([A-Za-z][A-Za-z0-9]*|[0-9]*)"));
		lexemelist.AddLast(new Lexeme("QUOSHUNT OF", "Division Operator", "QUOSHUNT OF ([A-Za-z][A-Za-z0-9]*|[0-9]*) AN ([A-Za-z][A-Za-z0-9]*|[0-9]*)"));
		lexemelist.AddLast(new Lexeme("PRODUKT OF", "Multiplication Operator", "PRODUKT OF ([A-Za-z][A-Za-z0-9]*|[0-9]*) AN ([A-Za-z][A-Za-z0-9]*|[0-9]*)"));
		lexemelist.AddLast(new Lexeme("MOD OF", "Modulo Operator", "MOD OF ([A-Za-z][A-Za-z0-9]*|[0-9]*) AN ([A-Za-z][A-Za-z0-9]*|[0-9]*)"));
		lexemelist.AddLast(new Lexeme("BIGGR OF", "Maximum Operator", "BIGGR OF ([A-Za-z][A-Za-z0-9]*|[0-9]*) AN ([A-Za-z][A-Za-z0-9]*|[0-9]*)"));
		lexemelist.AddLast(new Lexeme("SMALLR OF", "Minimum Operator", "MOD OF ([A-Za-z][A-Za-z0-9]*|[0-9]*) AN ([A-Za-z][A-Za-z0-9]*|[0-9]*)"));
	
	}

	public String cutText(String toCut, String cutter) {
		Console.WriteLine (toCut);
		Console.WriteLine (cutter);
		int index = toCut.IndexOf(cutter);
		String cleanPath = (index < 0)
			? toCut
			: toCut.Remove(index, cutter.Length);


		return cleanPath;
	}
	public String cutText(String toCut, int index, int length) {
		Console.WriteLine (toCut);

	
		String cleanPath = (index < 0)
			? toCut
			: toCut.Remove(index, length);


		return cleanPath;
	}

	protected void OnButton2Clicked (object sender, EventArgs e)
	{
		Gtk.FileChooserDialog filechooser =
			new Gtk.FileChooserDialog("Choose the file to open",
				this,
				FileChooserAction.Open,
				"Cancel",ResponseType.Cancel,
				"Open",ResponseType.Accept);

		if (filechooser.Run() == (int)ResponseType.Accept) 
		{
			StreamReader file = File.OpenText(filechooser.Filename);
			// Read the file into a string
			string s = file.ReadToEnd();
			// Close the file so it can be accessed again.
			textview3.Buffer.Text = s;
			file.Close();

		}

		filechooser.Destroy();

	}
}

