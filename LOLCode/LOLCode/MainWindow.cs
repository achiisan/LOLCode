using System;
using Gtk;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using LOLCode;

public partial class MainWindow: Gtk.Window
{

	public LinkedList<Lexeme> lexemelist;
	SyntaxChecker sc = new SyntaxChecker ();


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
		GeneratedCode.symtable = new Dictionary<String, String>();
		GeneratedCode.actions = new LinkedList<GeneratedCode>();


		sc = new SyntaxChecker ();



		String [] arr = stringer.Split ('\n');


		foreach (String a in arr) {
			Boolean tester = false;
			Boolean comment = false;
			String k = a;
			String lexeme;
			String classif;

				foreach (Lexeme l in lexemelist) {
					
					Match m = Regex.Match (k, "^" + l.lexeme);

				if (m.Success && tester == false && !(l.lexeme.Equals("R"))) {
					
						Gtk.TextBuffer bfr2 = textview4.Buffer;
						Gtk.TextBuffer bfr3 = textview5.Buffer;
						tester = true;

						if (l.classification.Equals ("Variable Identifier") || l.classification.Equals ("Troof Identifier") || l.classification.Equals ("Numbr Identifier") || l.classification.Equals ("Numbar Identifier")) {
							bfr2.Text = bfr2.Text +m.Value + "\n";
							lexeme = m.Value;
						} else {
							bfr2.Text = bfr2.Text + " " + l.lexeme + "\n";
						lexeme = l.lexeme;	
						}
						bfr3.Text = bfr3.Text + " " + l.classification + "\n";
						classif = l.classification;
					if (l.classification.Equals ("One Line Comment")) {
						comment = true;
					}
						sc.addtogl (lexeme, classif);
						k = cutText (k, m.Value);		



						Boolean dumaan = false;
					Match f = null;

					while (!Regex.Match (k, "^\\s*$").Success) {

						dumaan = false;
						foreach (Lexeme g in lexemelist) {
						

							k = k.Trim ();
							String lex = "^"+g.lexeme;
							Console.WriteLine ("X=" + lex + "Y="+k);

							f = Regex.Match (k, lex);

							if (f.Success && dumaan == false) {

								if (g.classification.Equals ("Variable Identifier") || g.classification.Equals ("Troof Identifier") || g.classification.Equals ("Numbr Identifier") || g.classification.Equals ("Numbar Identifier")) {
									bfr2.Text = bfr2.Text + f.Value + "\n";
									lexeme = f.Value;
								}else {
									bfr2.Text = bfr2.Text + " " + g.lexeme + "\n";
									lexeme = g.lexeme;
								}
							
								Console.WriteLine (l.classification);

								if (comment == true) {
									bfr3.Text = bfr3.Text + " " + "Comment Block" + "\n";
									classif = "Comment Block";  
								}else{
								bfr3.Text = bfr3.Text + " " + g.classification + "\n";
								classif = g.classification;  
								}

								if (g.classification.Equals ("One Line Comment")) {
									comment = true;
								}

								sc.addtogl (lexeme, classif);
								k = cutText (k, f.Value);
								dumaan = true;
							}
						}
					}

						
						k = "";
					}
			}
		}
		textview8.Buffer.Text = "";

		Boolean s = sc.checkSyntax ();
		if (s == false) {
			textview8.Buffer.Text = "SYNTAX ERROR. CANNOT EXECUTE CODE." + "\n";
		} else {
			Console.WriteLine ("EXECUTING CODE");
			GeneratedCode.output = "";
			foreach (GeneratedCode d in GeneratedCode.actions) {
				d.executeCode ();
			}
			textview8.Buffer.Text = GeneratedCode.output;
		}
	}

	protected void BuildLexemes() {
		lexemelist = new LinkedList<Lexeme> ();
		//general operations
		lexemelist.AddLast(new Lexeme("HAI", "Start Code Delimeter", "^HAI$"));
		lexemelist.AddLast(new Lexeme("KTHXBYE", "End Code Delimeter", "^KTHXBYE$"));
		lexemelist.AddLast (new Lexeme ("I HAS A ", "Variable Declaration", "^I HAS A .*"));
		lexemelist.AddLast (new Lexeme ("GIMMEH ", "Input Declaration", "^GIMMEH .*"));
		lexemelist.AddLast (new Lexeme ("VISIBLE ", "Output Declaration", "^VISIBLE .*"));
		lexemelist.AddLast (new Lexeme ("BTW ", "One Line Comment", "^OBTW( .*)?"));
		lexemelist.AddLast (new Lexeme ("OBTW ", "Comment Block Identifier", "^OBTW( .*)?"));
		lexemelist.AddLast(new Lexeme("TLDR ", "Comment Block End Identifier", "^TLDR$"));
		lexemelist.AddLast (new Lexeme ("R ", "Assignment Statement", ".* R .*"));
		lexemelist.AddLast (new Lexeme ("ITZ", "Assignment Statement", "ITZ .*"));
		lexemelist.AddLast (new Lexeme ("AN ", "And Token", "AN .*"));

		//mathemathical operations
		lexemelist.AddLast(new Lexeme("SUM OF ", "Addition Operator", "^SUM OF (.*|[0-9]*) AN (.*|[0-9]*)"));
		lexemelist.AddLast(new Lexeme("DIFF OF ", "Subtraction Operator", "^DIFF OF (.*|[0-9]*) AN (.*|[0-9]*)"));
		lexemelist.AddLast(new Lexeme("QUOSHUNT OF ", "Division Operator", "^QUOSHUNT OF (.*|[0-9]*) AN (.*|[0-9]*)"));
		lexemelist.AddLast(new Lexeme("PRODUKT OF ", "Multiplication Operator", "^PRODUKT OF (.*|[0-9]*) AN (.*|[0-9]*)"));
		lexemelist.AddLast(new Lexeme("MOD OF ", "Modulo Operator", "^MOD OF (.*|[0-9]*) AN (.*|[0-9]*)"));
		lexemelist.AddLast(new Lexeme("BIGGR OF ", "Maximum Operator", "^BIGGR OF (.*|[0-9]*) AN (.*|[0-9]*)"));
		lexemelist.AddLast(new Lexeme("SMALLR OF ", "Minimum Operator", "^MOD OF (.*|[0-9]*) AN (.*|[0-9]*)"));

		//switch case
		lexemelist.AddLast(new Lexeme("WTF? ", "Switch case indicator", "^WTF$"));
		lexemelist.AddLast(new Lexeme("OMG ", "Case operator", "^OMG .*"));
		lexemelist.AddLast(new Lexeme("GTFO ", "Case break operator", "^GTFO .*"));
		lexemelist.AddLast(new Lexeme("OMGWTF ", "Default Else operator", "^GTFO .*"));
		lexemelist.AddLast(new Lexeme("OIC ", "Default case operator", "^OIC$"));

		//boolean
		lexemelist.AddLast(new Lexeme("BOTH OF ", "And Operation", "^WTF$"));
		lexemelist.AddLast(new Lexeme("EITHER OF ", "Or Operation", "^WTF$"));
		lexemelist.AddLast(new Lexeme("WON OF ", "Xor Operation", "^WTF$"));	
		lexemelist.AddLast(new Lexeme("NOT ", "Negation Operation", "^WTF$"));
		lexemelist.AddLast(new Lexeme("ALL OF ", "Infinite Arity And", "^WTF$"));
		lexemelist.AddLast(new Lexeme("ANY OF ", "Infinite Arity And", "^WTF$"));

		//comparison
		lexemelist.AddLast(new Lexeme("BOTH SAEM ", "Equal Correspondence", "^WTF$"));
		lexemelist.AddLast(new Lexeme("DIFFRINT ", "Unequal Correspondence", "^WTF$"));

		lexemelist.AddLast(new Lexeme("WIN ", "True Correspondence", "^WTF$"));
		lexemelist.AddLast(new Lexeme("FAIL ", "False Correspondence", "^WTF$"));


		//loops
		lexemelist.AddLast(new Lexeme("IM IN YR ", "Loop Indicator", "^IM IN YR .*"));
		lexemelist.AddLast(new Lexeme("UPPIN YR", "Indicates to increase variable as loop iterates", "^UPPIN YR .*"));
		lexemelist.AddLast(new Lexeme("NERFIN YR ", "Indicates to decrease variable as loop iterates", "^NERFIN YR .*"));
		lexemelist.AddLast(new Lexeme("TIL ", "Until", "^TIL .*"));
		lexemelist.AddLast(new Lexeme("WILE ", "While", "^WILE .*"));
		lexemelist.AddLast(new Lexeme("GTFO ", "Terminates loop immediately", "^GTFO .*"));
		lexemelist.AddLast(new Lexeme("IM OUTTA YR ", "End of loop code block", "^IM OUTTA YR .*"));


		//if-else	
		lexemelist.AddLast(new Lexeme("O RLY? ", "If-Statements", "^O RLY? .*"));
		lexemelist.AddLast(new Lexeme("YA RLY ", "Executes if true", "^YA RLY .*"));
		lexemelist.AddLast(new Lexeme("NO WAI ", "Executes if false", "^NO WAI .*"));
		lexemelist.AddLast(new Lexeme("OIC ", "Ends the ff-else statement", "^OIC .*"));

		//random 
		lexemelist.AddLast(new Lexeme("[A-Za-z][A-Za-z0-9]*", "Variable Identifier", "[A-Za-z][A-Za-z0-9]*"));
		lexemelist.AddLast(new Lexeme("\".*\"", "Troof Identifier", "\".*\""));
		lexemelist.AddLast(new Lexeme("-?\\d+\\.\\d+", "Numbar Identifier", "\".*\""));
		lexemelist.AddLast(new Lexeme("-?\\d+", "Numbr Identifier", "\".*\""));

		//n-ary statement (statement that does not happen on the first try
	
	}




	public String cutText(String toCut, String cutter) {

		int index = toCut.IndexOf(cutter);
		String cleanPath = (index < 0)
			? toCut
			: toCut.Remove(index, cutter.Length);


		return cleanPath;
	}
	public String cutText(String toCut, int index, int length) {

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
		filechooser.Run ();
		if (filechooser.Run () == (int)ResponseType.Accept) {
			StreamReader file = File.OpenText (filechooser.Filename);
			// Read the file into a string
			string s = file.ReadToEnd ();
			// Close the file so it can be accessed again.
			textview3.Buffer.Text = s;
			file.Close ();
			filechooser.Destroy ();
		} else {
			filechooser.Destroy ();
		}

	}

	public void evaluatePerWord(String k){
		//evaluate every line
		Gtk.TextBuffer bfr2 = textview4.Buffer;
		Gtk.TextBuffer bfr3 = textview5.Buffer;
		String[] splittr = k.Split (' ');
		String lexeme;
		String classif;

		foreach (String d in splittr) {

			Boolean dumaan = false;
			foreach(Lexeme g in lexemelist) {
				Match f = Regex.Match(d+" ", "(^| )"+g.lexeme+"$");

				if(f.Success && dumaan == false){

					if (g.classification.Equals ("Variable Identifier") || g.classification.Equals ("Troof Identifier") || g.classification.Equals ("Numbr Identifier") || g.classification.Equals ("Numbar Identifier")) {
						bfr2.Text = bfr2.Text + d + "\n";
						lexeme = d;
					} else {
						bfr2.Text = bfr2.Text + " " + g.lexeme + "\n";
						lexeme = g.lexeme;
					}
					bfr3.Text = bfr3.Text + " " + g.classification + "\n";
					classif = g.classification;

					sc.addtogl (lexeme, classif);

					dumaan = true;
				}
			}
		}
	}
}

