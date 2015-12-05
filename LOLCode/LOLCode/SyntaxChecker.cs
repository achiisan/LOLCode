using System;

using System.Collections;
using System.Collections.Generic;
using CSE;

namespace LOLCode
{
	public class SyntaxChecker
	{
		ArrayList gl;
		ArrayList varlist;

		int i;
		String s = "";
		Boolean  var = false;
		int val = 0;

		public SyntaxChecker ()
		{
			gl = new ArrayList ();
			varlist = new ArrayList ();
		}

		public void addtogl(String lexeme, String classif){
			gl.Add (new GeneratedLexeme (lexeme, classif));
		}

		public void addtovarlist(String value){
			varlist.Add (value);
		}

		public Boolean checkSyntax() {
			Console.WriteLine("CHECKING SYNTAX...");
		
			i = 0;
			GeneratedCode.symtable.Add ("IT", "0");


			Boolean syntaxCheck = S ();
		
			return syntaxCheck;

		}
		public Boolean Terminal(String s){
			try{
			GeneratedLexeme d = (GeneratedLexeme)gl [i];

				if (d.getClassification ().Equals (s)) {
					if(d.getClassification().Equals("Variable Identifier") || d.getClassification().Equals("Troof Identifier") || d.getClassification().Equals("Numbar Identifier") ||d.getClassification().Equals("Numbr Identifier")) {
						addtovarlist(d.getLexeme());
					}
					i++;
					return true;
				} else {
					return false;
				}
		} catch(Exception e) {
				return false;
			}
		}

		public Boolean S() {
			return Terminal ("Start Code Delimeter") && CodeBlock() && Terminal ("End Code Delimeter");
		}

		public Boolean CodeBlock() {
			int save = i;
			return ( ( (i = save) == save & (SimpleCommands() && CodeBlock())) ||
				((i = save) ==  save & SimpleCommands ())

				);
				
		}

		public Boolean SimpleCommands() {
			int save = i;
			return ( 	((i = save) == save & IHasA()) ||
						((i = save) == save & (Gimmeh())) ||
						((i = save) == save & (Visible())) ||
						((i = save) == save & (Gimmeh())) ||
						((i = save) == save & (R())) ||
						((i = save) == save & (Comment())) 
			);
		}

		public Boolean Comment() {
			int save = i;
			return ( 	((i = save) == save & ( Terminal("One Line Comment")) && CommentBlocks() ));
		}

		public Boolean CommentBlocks() {
			int save = i;
			return ( 	((i = save) == save & (Terminal("Comment Block") && CommentBlocks())) || 
				((i = save) == save & (Terminal("Comment Block"))) );
		}
			

		public Boolean ArithmeticCommands() {
			int save = i;
			return  (((i = save) == save & SumOf()) ||
					((i = save) == save & (DiffOf())) ||
					((i = save) == save & (QuoshuntOf())) ||
					((i = save) == save & (ProduktOf())) 
			);
		}

		public Boolean IHasA(){
			int save = i;
		
			Boolean k = ((i = save) == save & (Terminal ("Variable Declaration") && Terminal ("Variable Identifier") && Terminal ("Assignment Statement") && ArithmeticCommands()));
			if (k == true) {
				GeneratedLexeme temp = (GeneratedLexeme) gl [save+1];

				String[] args = new String[2];
				args [0] = temp.getLexeme ();
				args [1] = GeneratedCode.symtable ["IT"];
				GeneratedCode.actions.AddLast (new GeneratedCode (2,null, args ,null));
				return k;
			}
				
				
			k = ((i = save) == save & (Terminal ("Variable Declaration") && Terminal ("Variable Identifier") && Terminal ("Assignment Statement") && Terminal ("Numbr Identifier") ));
			if (k == true) {
				GeneratedLexeme temp = (GeneratedLexeme) gl [save+1];
				GeneratedLexeme temp2 = (GeneratedLexeme) gl [save + 3];
				String[] args = new String[2];
				args [0] = temp.getLexeme ();
				args [1] = temp2.getLexeme ();
				GeneratedCode.actions.AddLast (new GeneratedCode (1,null, args ,null));
				return k;
			}

			k = ((i = save) == save & (Terminal ("Variable Declaration") && Terminal ("Variable Identifier") && Terminal ("Assignment Statement") && Terminal ("Numbar Identifier") ));
			if (k == true) {
				GeneratedLexeme temp = (GeneratedLexeme) gl [save+1];
				GeneratedLexeme temp2 = (GeneratedLexeme) gl [save + 3];
				String[] args = new String[2];
				args [0] = temp.getLexeme ();
				args [1] = temp2.getLexeme ();
				GeneratedCode.actions.AddLast (new GeneratedCode (1,null, args ,null));

				return k;
			}


			k = ((i = save) == save & (Terminal ("Variable Declaration") && Terminal ("Variable Identifier") && Terminal ("Assignment Statement") && Terminal ("Variable Identifier")));
			if (k == true) {
				GeneratedLexeme temp = (GeneratedLexeme) gl [save+1];
				GeneratedLexeme temp2 = (GeneratedLexeme) gl [save + 3];
				String[] args = new String[2];
				args [0] = temp.getLexeme ();
				args [1] = temp2.getLexeme ();
				GeneratedCode.actions.AddLast (new GeneratedCode (1,null, args ,null));

				return k;
			}

			k = ((i = save) == save & (Terminal ("Variable Declaration") && Terminal ("Variable Identifier") && Terminal ("Assignment Statement") && Terminal ("Troof Identifier")));
			if (k == true) {
				GeneratedLexeme temp = (GeneratedLexeme) gl [save+1];
				GeneratedLexeme temp2 = (GeneratedLexeme) gl [save + 3];
				String[] args = new String[2];
				args [0] = temp.getLexeme ();
				args [1] = temp2.getLexeme ();
				GeneratedCode.actions.AddLast (new GeneratedCode (1,null, args ,null));
				return k;
			}

			 k = ((i = save) == save & (Terminal ("Variable Declaration") && Terminal ("Variable Identifier")));
			if (k == true) {
				GeneratedLexeme temp = (GeneratedLexeme) gl [save+1];
				String[] args = new String[2];
				args [0] = temp.getLexeme ();
				args [1] = "0";
				GeneratedCode.actions.AddLast (new GeneratedCode (1,null, args ,null));

			}
			return k;
		}

		public Boolean Gimmeh(){
			int tempid = i;
			Boolean x = Terminal ("Input Declaration") && Terminal ("Variable Identifier");
	

			if (x == true) {
				GeneratedLexeme temp = (GeneratedLexeme) gl [tempid+1];
				String[] args = new String[2];
				args [0] = temp.getLexeme ();
				GeneratedCode.actions.AddLast (new GeneratedCode (13,null, args ,null));
			}
			return x;
		}

		public Boolean Visible() {
			int tempi = i;
			Console.WriteLine ("HAHAHHA");
			Boolean r =  ((i = tempi) == tempi & Terminal ("Output Declaration") && (Terminal ("Variable Identifier")));
				if (r == true) {
				
				GeneratedLexeme temp = (GeneratedLexeme) gl [tempi + 1];
				String[] args = new String[1];
				args [0] = temp.getLexeme ();

				GeneratedCode.actions.AddLast (new GeneratedCode (3,null, args ,null));
				return r;
				}

			r =  ((i = tempi) == tempi & Terminal ("Output Declaration") && ( Terminal ("Troof Identifier") || Terminal ("Numbr Identifier") || Terminal ("Numbar Identifier")));
			if (r == true) {

				GeneratedLexeme temp = (GeneratedLexeme) gl [tempi + 1];
				String[] args = new String[1];
				args [0] = temp.getLexeme ();

				GeneratedCode.actions.AddLast (new GeneratedCode (4,null, args ,null));
				return r;
			}

			r = ((i = tempi) == tempi & (Terminal ("Output Declaration") && ArithmeticCommands() ));
			if (r == true) {
				GeneratedLexeme temp = (GeneratedLexeme) gl [tempi + 1];
				String[] args = new String[1];
				args [0] = temp.getLexeme ();

				GeneratedCode.actions.AddLast (new GeneratedCode (5,null, args ,null));
				return r;

			}
			return r;
		}
			


		public Boolean R() {
			int tempi = i;

			Boolean k =  ((i = tempi) == tempi & Terminal("Variable Identifier") && Terminal ("Assignment Statement") && (Terminal ("Troof Identifier") || Terminal ("Numbr Identifier") || Terminal ("Numbar Identifier")  || Terminal("Variable Identifier") ));

			if (k == true) {
				GeneratedLexeme temp = (GeneratedLexeme) gl [tempi];
				GeneratedLexeme temp2 = (GeneratedLexeme) gl [tempi+2];
				String[] args = new String[2];
				args [0] = temp.getLexeme ();
				args [1] = temp2.getLexeme ();

				GeneratedCode.actions.AddLast (new GeneratedCode (11,null, args ,null));
				return k;
			}

			k =  ((i = tempi) == tempi & Terminal("Variable Identifier") && Terminal ("Assignment Statement") && (ArithmeticCommands()));

			if (k == true) {
				GeneratedLexeme temp = (GeneratedLexeme) gl [tempi];
				String[] args = new String[1];
				args [0] = temp.getLexeme ();


				GeneratedCode.actions.AddLast (new GeneratedCode (12,null, args ,null));
			}
			Console.WriteLine (k);
			return k;
		}


		public Boolean SumOf() {
			int tempi = i;
			varlist = new ArrayList ();

			Boolean k = Terminal ("Addition Operator");
			int counter = 0;
			do{
				 k = k && (Terminal("Numbr Identifier") || Terminal("Numbar Identifier") || Terminal("Variable Identifier"));
				counter ++;
			}while(Terminal("And Token"));

			if (counter == 1) {
				k = false;
			}
				
				if (k == true) {
				String[] args = new String[varlist.Count];
			
				counter = 0;
				foreach (String s in varlist) {
					args [counter] = s;
				
					counter++;
				}

				GeneratedCode.actions.AddLast (new GeneratedCode (6,null, args ,null));
				}
			Console.WriteLine (k);
				return k;
				}

		public Boolean DiffOf() {
			int tempi = i;
			varlist = new ArrayList ();

			Boolean k = Terminal ("Subtraction Operator");
			int counter = 0;
			do{
				k = k && (Terminal("Numbr Identifier") || Terminal("Numbar Identifier") || Terminal("Variable Identifier"));
				counter ++;
			}while(Terminal("And Token"));

			if (counter == 1) {
				k = false;
			}

			if (k == true) {
				String[] args = new String[varlist.Count];

				counter = 0;
				foreach (String s in varlist) {
					args [counter] = s;
				
					counter++;
				}

				GeneratedCode.actions.AddLast (new GeneratedCode (7,null, args ,null));
			}
			Console.WriteLine (k);
			return k;
		}

		public Boolean QuoshuntOf() {
			int tempi = i;
			varlist = new ArrayList ();

			Boolean k = Terminal ("Division Operator");
			int counter = 0;
			do{
				k = k && (Terminal("Numbr Identifier") || Terminal("Numbar Identifier") || Terminal("Variable Identifier"));
				counter ++;
			}while(Terminal("And Token"));

			if (counter == 1) {
				k = false;
			}

			if (k == true) {
				String[] args = new String[varlist.Count];
			
				counter = 0;
				foreach (String s in varlist) {
					args [counter] = s;
			
					counter++;
				}

				GeneratedCode.actions.AddLast (new GeneratedCode (9,null, args ,null));
			}
			Console.WriteLine (k);
			return k;
		}

		public Boolean ProduktOf() {
			int tempi = i;
			varlist = new ArrayList ();

			Boolean k = Terminal ("Multiplication Operator");
			int counter = 0;
			do{
				k = k && (Terminal("Numbr Identifier") || Terminal("Numbar Identifier") || Terminal("Variable Identifier"));
				counter ++;
			}while(Terminal("And Token"));

			if (counter == 1) {
				k = false;
			}

			if (k == true) {
				String[] args = new String[varlist.Count];
				Console.WriteLine (varlist.Count + "=EQUAL NOM");
				counter = 0;
				foreach (String s in varlist) {
					args [counter] = s;
					Console.WriteLine (s + "HEHEHE");
					counter++;
				}

				GeneratedCode.actions.AddLast (new GeneratedCode (8,null, args ,null));
			}
			Console.WriteLine (k);
			return k;
		}

		public Boolean ModOf() {
			int tempi = i;
			varlist = new ArrayList ();

			Boolean k = Terminal ("Modulo Operator");
			int counter = 0;
			do{
				k = k && (Terminal("Numbr Identifier") || Terminal("Numbar Identifier") || Terminal("Variable Identifier"));
				counter ++;
			}while(Terminal("And Token"));

			if (counter == 1) {
				k = false;
			}

			if (k == true) {
				String[] args = new String[varlist.Count];
				Console.WriteLine (varlist.Count + "=EQUAL NOM");
				counter = 0;
				foreach (String s in varlist) {
					args [counter] = s;
					Console.WriteLine (s + "HEHEHE");
					counter++;
				}

				GeneratedCode.actions.AddLast (new GeneratedCode (10,null, args ,null));
			}
			Console.WriteLine (k);
			return k;
		}
			

		public Boolean LogicOperations(){
			return false;
		}




	}
}

