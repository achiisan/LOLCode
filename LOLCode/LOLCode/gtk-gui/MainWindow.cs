
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.Fixed fixed3;
	
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	
	private global::Gtk.TextView textview3;
	
	private global::Gtk.Table table1;
	
	private global::Gtk.ScrolledWindow scrolledwindow1;
	
	private global::Gtk.TextView textview5;
	
	private global::Gtk.ScrolledWindow scrolledwindow2;
	
	private global::Gtk.TextView textview4;
	
	private global::Gtk.Label label2;
	
	private global::Gtk.Table table2;
	
	private global::Gtk.ScrolledWindow scrolledwindow3;
	
	private global::Gtk.TextView textview7;
	
	private global::Gtk.ScrolledWindow scrolledwindow4;
	
	private global::Gtk.TextView textview6;
	
	private global::Gtk.Label label3;
	
	private global::Gtk.Label label1;
	
	private global::Gtk.Button button1;
	
	private global::Gtk.Button button2;
	
	private global::Gtk.ScrolledWindow GtkScrolledWindow1;
	
	private global::Gtk.TextView textview8;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.WidthRequest = 800;
		this.HeightRequest = 600;
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.DefaultWidth = 1100;
		this.DefaultHeight = 768;
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.fixed3 = new global::Gtk.Fixed ();
		this.fixed3.Name = "fixed3";
		this.fixed3.HasWindow = false;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.WidthRequest = 200;
		this.GtkScrolledWindow.HeightRequest = 277;
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.textview3 = new global::Gtk.TextView ();
		this.textview3.CanFocus = true;
		this.textview3.Name = "textview3";
		this.GtkScrolledWindow.Add (this.textview3);
		this.fixed3.Add (this.GtkScrolledWindow);
		global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.GtkScrolledWindow]));
		w2.X = 30;
		w2.Y = 36;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.table1 = new global::Gtk.Table (((uint)(1)), ((uint)(2)), false);
		this.table1.WidthRequest = 356;
		this.table1.HeightRequest = 278;
		this.table1.Name = "table1";
		this.table1.RowSpacing = ((uint)(6));
		this.table1.ColumnSpacing = ((uint)(6));
		// Container child table1.Gtk.Table+TableChild
		this.scrolledwindow1 = new global::Gtk.ScrolledWindow ();
		this.scrolledwindow1.CanFocus = true;
		this.scrolledwindow1.Name = "scrolledwindow1";
		this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child scrolledwindow1.Gtk.Container+ContainerChild
		this.textview5 = new global::Gtk.TextView ();
		this.textview5.CanFocus = true;
		this.textview5.Name = "textview5";
		this.scrolledwindow1.Add (this.textview5);
		this.table1.Add (this.scrolledwindow1);
		global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1 [this.scrolledwindow1]));
		w4.LeftAttach = ((uint)(1));
		w4.RightAttach = ((uint)(2));
		// Container child table1.Gtk.Table+TableChild
		this.scrolledwindow2 = new global::Gtk.ScrolledWindow ();
		this.scrolledwindow2.CanFocus = true;
		this.scrolledwindow2.Name = "scrolledwindow2";
		this.scrolledwindow2.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child scrolledwindow2.Gtk.Container+ContainerChild
		this.textview4 = new global::Gtk.TextView ();
		this.textview4.Buffer.Text = "\n";
		this.textview4.CanFocus = true;
		this.textview4.Name = "textview4";
		this.scrolledwindow2.Add (this.textview4);
		this.table1.Add (this.scrolledwindow2);
		this.fixed3.Add (this.table1);
		global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.table1]));
		w7.X = 293;
		w7.Y = 40;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.label2 = new global::Gtk.Label ();
		this.label2.Name = "label2";
		this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Lexemes");
		this.fixed3.Add (this.label2);
		global::Gtk.Fixed.FixedChild w8 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.label2]));
		w8.X = 445;
		w8.Y = 16;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.table2 = new global::Gtk.Table (((uint)(1)), ((uint)(2)), false);
		this.table2.WidthRequest = 338;
		this.table2.HeightRequest = 277;
		this.table2.Name = "table2";
		this.table2.RowSpacing = ((uint)(6));
		this.table2.ColumnSpacing = ((uint)(6));
		// Container child table2.Gtk.Table+TableChild
		this.scrolledwindow3 = new global::Gtk.ScrolledWindow ();
		this.scrolledwindow3.CanFocus = true;
		this.scrolledwindow3.Name = "scrolledwindow3";
		this.scrolledwindow3.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child scrolledwindow3.Gtk.Container+ContainerChild
		this.textview7 = new global::Gtk.TextView ();
		this.textview7.CanFocus = true;
		this.textview7.Name = "textview7";
		this.scrolledwindow3.Add (this.textview7);
		this.table2.Add (this.scrolledwindow3);
		global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table2 [this.scrolledwindow3]));
		w10.LeftAttach = ((uint)(1));
		w10.RightAttach = ((uint)(2));
		// Container child table2.Gtk.Table+TableChild
		this.scrolledwindow4 = new global::Gtk.ScrolledWindow ();
		this.scrolledwindow4.CanFocus = true;
		this.scrolledwindow4.Name = "scrolledwindow4";
		this.scrolledwindow4.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child scrolledwindow4.Gtk.Container+ContainerChild
		this.textview6 = new global::Gtk.TextView ();
		this.textview6.CanFocus = true;
		this.textview6.Name = "textview6";
		this.scrolledwindow4.Add (this.textview6);
		this.table2.Add (this.scrolledwindow4);
		this.fixed3.Add (this.table2);
		global::Gtk.Fixed.FixedChild w13 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.table2]));
		w13.X = 719;
		w13.Y = 39;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.label3 = new global::Gtk.Label ();
		this.label3.Name = "label3";
		this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Symbol Table");
		this.fixed3.Add (this.label3);
		global::Gtk.Fixed.FixedChild w14 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.label3]));
		w14.X = 835;
		w14.Y = 12;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Input");
		this.label1.UseMarkup = true;
		this.label1.UseUnderline = true;
		this.fixed3.Add (this.label1);
		global::Gtk.Fixed.FixedChild w15 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.label1]));
		w15.X = 109;
		w15.Y = 12;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.button1 = new global::Gtk.Button ();
		this.button1.CanFocus = true;
		this.button1.Name = "button1";
		this.button1.UseUnderline = true;
		this.button1.Label = global::Mono.Unix.Catalog.GetString ("Analyze");
		this.fixed3.Add (this.button1);
		global::Gtk.Fixed.FixedChild w16 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.button1]));
		w16.X = 45;
		w16.Y = 322;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.button2 = new global::Gtk.Button ();
		this.button2.CanFocus = true;
		this.button2.Name = "button2";
		this.button2.UseUnderline = true;
		this.button2.Label = global::Mono.Unix.Catalog.GetString ("Load File");
		this.fixed3.Add (this.button2);
		global::Gtk.Fixed.FixedChild w17 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.button2]));
		w17.X = 126;
		w17.Y = 324;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
		this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
		this.textview8 = new global::Gtk.TextView ();
		this.textview8.WidthRequest = 1050;
		this.textview8.HeightRequest = 300;
		this.textview8.CanFocus = true;
		this.textview8.Name = "textview8";
		this.GtkScrolledWindow1.Add (this.textview8);
		this.fixed3.Add (this.GtkScrolledWindow1);
		global::Gtk.Fixed.FixedChild w19 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.GtkScrolledWindow1]));
		w19.X = 28;
		w19.Y = 363;
		this.Add (this.fixed3);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.button1.Clicked += new global::System.EventHandler (this.OnButton1Clicked);
	}
}
