using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace _8_blitz {
	public partial class _Listen: Page {
		private static string ConnStr = "SERVER=localhost;Port=3306;DATABASE=Blitz;UID=root;PASSWORD=terminal";
		private MySqlConnection Conn;
		private MySqlCommand Cmd;
		private MySqlDataAdapter Adapter;
		private DataTable Data;
		public string Query;
		public string BlitzName;
		public string BlitzContent;

		protected void Page_Load(object sender, EventArgs e) {
			if (Session["id"] == null)
				Response.Redirect("Login.aspx");

			Query = Request.Url.Query.Replace("?blitz=", "");
			if (Query == "")
				Response.Redirect("/Default.aspx");

			Conn = new MySqlConnection(ConnStr);
			Conn.Open();

			Cmd = new MySqlCommand("SELECT name, content FROM Blitz WHERE id = @id", Conn);
			Cmd.Parameters.AddWithValue("@id", Query);

			Adapter = new MySqlDataAdapter(Cmd);
			Data = new DataTable();
			Adapter.Fill(Data);

			if (Data.Rows.Count > 0) {
				BlitzName = "" + Data.Rows[0]["name"];
				BlitzContent = "" + Data.Rows[0]["content"];
			}
			else
				Response.Redirect("/Directory.aspx");

			Conn.Close();
		}
	}
}