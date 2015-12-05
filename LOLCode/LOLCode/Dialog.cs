using System;

namespace LOLCode
{
	public partial class Dialog : Gtk.Dialog
	{
		public Dialog ()
		{
			this.Build ();
		}

		protected void OnButtonOkClicked (object sender, EventArgs e)
		{
			this.Respond (Gtk.ResponseType.Ok);
		}

		protected void OnButtonCancelClicked (object sender, EventArgs e)
		{
			this.Respond (Gtk.ResponseType.Cancel);
		}

		public String Text {
			get {
				return textview1.Buffer.Text;
			}
		}
	}
}

