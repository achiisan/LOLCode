using System;

namespace LOLCode
{
	public class Lexeme
	{
		public String lexeme;
		public String classification;
		public String regex;


		public Lexeme (String lexeme, String classification, String regex)
		{
			this.lexeme = lexeme;
			this.classification = classification;
			this.regex = regex;

		}
	}
}

