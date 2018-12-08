using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace _8_blitz {
	public partial class _Profile: Page {
		private static string ConnStr = "SERVER=localhost;Port=3306;DATABASE=Blitz;UID=root;PASSWORD=terminal";
		private MySqlConnection Conn;
		private MySqlCommand Cmd;
		private MySqlDataAdapter Adapter;
		private DataTable Data;
		private string Query;
		public string username;
		public string about;
		public string blitzListMarkup = "";

		protected void Page_Load(object sender, EventArgs e) {
			Query = Request.Url.Query.Replace("?id=", "");

			if (Query == "")
				Response.Redirect("/Default.aspx");
			if (Query == "" + Session["id"])
				Response.Redirect("/MyProfile.aspx");
			
			Conn = new MySqlConnection(ConnStr);
			Conn.Open();

			Cmd = new MySqlCommand("SELECT username, about FROM User WHERE id = @id", Conn);
			Cmd.Parameters.AddWithValue("@id", Query);

			Adapter = new MySqlDataAdapter(Cmd);
			Data = new DataTable();
			Adapter.Fill(Data);
			
			if (Data.Rows.Count == 0)
				Response.Redirect("/Default.aspx");
			else {
				username = (string) Data.Rows[0]["username"];
				about = (string) Data.Rows[0]["about"];

				Cmd = new MySqlCommand("SELECT id, name FROM Blitz WHERE author = @id", Conn);
				Cmd.Parameters.AddWithValue("@id", Query);

				Adapter = new MySqlDataAdapter(Cmd);
				Data = new DataTable();
				Adapter.Fill(Data);

				if (!IsPostBack) {
					for (int i = 0; i < Data.Rows.Count; i++) {
						blitzListMarkup += "<div class=\"col-xs-4\"><a class=\"btn btn-info btn-block\" href=\"Listen.aspx?blitz=" + Data.Rows[i]["id"] + "\">" + Data.Rows[i]["name"] + "</a></div>";
					}
				}
			}

			Conn.Close();
		}

	}
}