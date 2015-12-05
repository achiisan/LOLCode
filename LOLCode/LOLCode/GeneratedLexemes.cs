using System;

namespace LOLCode
{
	public class GeneratedLexeme
	{
		String lexeme;
		String classification;

		public GeneratedLexeme (String lexeme, String classification)
		{
			this.lexeme = lexeme;
			this.classification = classification;
		}

		public String getLexeme() {
			return this.lexeme;
		} 
		public String getClassification() {
			return this.classification;
			} 
	}
}

