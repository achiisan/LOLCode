using System;
using System.Collections;
using System.Collections.Generic;

namespace LOLCode
{
	public class GeneratedCode
	{
		public static Dictionary<String, String> symtable = new Dictionary<String, String>();
		public static LinkedList<GeneratedCode> actions = new LinkedList<GeneratedCode>();

		public int action;
		int[] num;
		String[] str;
		double[] flpt;
		public static String output = "";

		public GeneratedCode (int action, int[] num, String[] str, double[] flpt){
				this.action = action;
				this.str = str;
				this.num = num;
				this.flpt = flpt;
		}

		public void executeCode() {
			
			if (action == 1) { // I HAS A(DIRECT VALUE)
				if (!symtable.ContainsKey (str [0])) { 
					symtable.Add (str [0], str [1]);
				} else {
					GeneratedCode.output = output + "ASSERTION ERROR: VARIABLE " + str [0] + " HAS ALREADY BEEN DECLARED\n";
				}
			
			} else if (action == 2) { //I HAS A (EXPRESSION)
				Console.WriteLine ("PASOK HERE");
				if (!symtable.ContainsKey (str [0])) {
					symtable.Add (str [0], symtable ["IT"]);
				} else {
					GeneratedCode.output = output + "ASSERTION ERROR: VARIABLE " + str [0] + " HAS ALREADY BEEN DECLARED\n";
				}
			} else if (action == 3) {	 //Visible (Variable)
			
				if (symtable.ContainsKey (str [0])) {
					Console.WriteLine (symtable [str [0]]);
					GeneratedCode.output = output + symtable [str [0]] + "\n";
				} else {
					GeneratedCode.output = output + "ASSERTION ERROR: NO VARIABLE NAMED " + str [0] + "\n";
				}
			} else if (action == 4) { //visible (Direct Value)
				GeneratedCode.output = output + str [0] + "\n";
			} else if (action == 5) { //visible (Expression)
				GeneratedCode.output = output + symtable ["IT"] + "\n";
			} else if (action == 6) { //sum of
				double sum = 0;
			
				for (int w = 0; w < str.Length; w++) {

					
				
					try {
						double temp = Double.Parse (str [w]);
						sum = sum + temp;
					} catch {
						if (GeneratedCode.symtable.ContainsKey (str [w])) {
							try {
								double temp = Double.Parse (GeneratedCode.symtable [str [w]]);
								sum = sum + temp;
							} catch {
								GeneratedCode.output = output + "ASSERTION ERROR: CANNOT PERFORM OPERATION ON " + str [w] + "\n";
							}
						} else {
							GeneratedCode.output = output + "ASSERTION ERROR: " + str [w] + " NOT FOUND\n";
						}

					}
				}
				GeneratedCode.symtable ["IT"] = "" + sum + "";
			} else if (action == 7) { //diff of
				double sum = 0;
			
				for (int w = 0; w < str.Length; w++) {


				
					try {
						double temp = Double.Parse (str [w]);
						if (w == 0) {
							sum = temp;
						} else {
							sum = sum - temp;
						}
					} catch {
						if (GeneratedCode.symtable.ContainsKey (str [w])) {
							try {
								double temp = Double.Parse (GeneratedCode.symtable [str [w]]);
								if (w == 0) {
									sum = temp;
								} else {
									sum = sum - temp;
								}
							} catch {
								GeneratedCode.output = output + "ASSERTION ERROR: CANNOT PERFORM OPERATION ON " + str [w] + "\n";
							}
						} else {
							GeneratedCode.output = output + "ASSERTION ERROR: " + str [w] + " NOT FOUND\n";
						}

					}
				}
				GeneratedCode.symtable ["IT"] = "" + sum + "";

			} else if (action == 8) { //produkt of
				double sum = 1;
		
				for (int w = 0; w < str.Length; w++) {
					Console.WriteLine (str [w]);


					try {
						double temp = Double.Parse (str [w]);
						sum = sum * temp;
					} catch {
						if (GeneratedCode.symtable.ContainsKey (str [w])) {
							try {
								double temp = Double.Parse (GeneratedCode.symtable [str [w]]);
								sum = sum * temp;
							} catch {
								GeneratedCode.output = output + "ASSERTION ERROR: CANNOT PERFORM OPERATION ON " + str [w] + "\n";
							}
						} else {
							GeneratedCode.output = output + "ASSERTION ERROR: " + str [w] + " NOT FOUND\n";
						}

					}
				}
				GeneratedCode.symtable ["IT"] = "" + sum + "";
					
			} else if (action == 9) { //quoshunt of
				double sum = 0;
			
				for (int w = 0; w < str.Length; w++) {


				
					try {
						double temp = Double.Parse (str [w]);
						if (w == 0) {
							sum = temp;
						} else {
							sum = sum / temp;
						}
					} catch {
						if (GeneratedCode.symtable.ContainsKey (str [w])) {
							try {
								double temp = Double.Parse (GeneratedCode.symtable [str [w]]);
								if (w == 0) {
									sum = temp;
								} else {
									sum = sum / temp;
								}
							} catch {
								GeneratedCode.output = output + "ASSERTION ERROR: CANNOT PERFORM OPERATION ON " + str [w] + "\n";
							}
						} else {
							GeneratedCode.output = output + "ASSERTION ERROR: " + str [w] + " NOT FOUND\n";
						}

					}
				}
				GeneratedCode.symtable ["IT"] = "" + sum + "";
					
			} else if (action == 10) { //modulo operator
				double sum = 0;
			
				for (int w = 0; w < str.Length; w++) {

					try {
						double temp = Double.Parse (str [w]);
						sum = sum % temp;
					} catch {
						if (GeneratedCode.symtable.ContainsKey (str [w])) {
							try {
								double temp = Double.Parse (GeneratedCode.symtable [str [w]]);
								sum = sum % temp;
							} catch {
								GeneratedCode.output = output + "ASSERTION ERROR: CANNOT PERFORM OPERATION ON " + str [w] + "\n";
							}
						} else {
							GeneratedCode.output = output + "ASSERTION ERROR: " + str [w] + " NOT FOUND\n";
						}

					}
				}
				GeneratedCode.symtable ["IT"] = "" + sum + "";
			} else if (action == 11) {
				Console.WriteLine (str [0]);
				if (symtable.ContainsKey (str [0])) { 
					if (symtable.ContainsKey (str [1])) {
						symtable [str [0]] = symtable [str [1]];
					} else {
						symtable [str [0]] = str [1];
					}
				} else {
					GeneratedCode.output = output + "ASSERTION ERROR: VARIABLE " + str [0] + " IS NOT FOUND\n";
				}
			} else if (action == 12) {
				if (symtable.ContainsKey (str [0])) { 
					symtable [str [0]] = symtable ["IT"];
				} else {
					GeneratedCode.output = output + "ASSERTION ERROR: VARIABLE " + str [0] + " IS NOT FOUND\n";
				}
			} else if (action == 13) {
				Dialog cid = new Dialog ();
				if (cid.Run () == (int)Gtk.ResponseType.Ok) {
					if (symtable.ContainsKey (str [0])) {
						symtable [str [0]] = cid.Text;
					} else {
						GeneratedCode.output = output + "ASSERTION ERROR: VARIABLE " + str [0] + " IS NOT FOUND\n";
					}
				}
				cid.Destroy ();
			}
		
		}
}
}