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
	public partial class _Blitz: Page {
		private static string ConnStr = "SERVER=localhost;Port=3306;DATABASE=Blitz;UID=root;PASSWORD=terminal";
		private MySqlConnection Conn;
		private MySqlCommand Cmd;
		private MySqlDataAdapter Adapter;
		private DataTable Data;
		public string blitzListMarkup = "";
		protected void Page_Load(object sender, EventArgs e) {
			if (Session["id"] == null)
				Response.Redirect("Login.aspx");

			if (Request.Form["ctl00$MainContent$blitzContent"] != null && Request.Form["ctl00$MainContent$blitzName"] != null) {

				Conn = new MySqlConnection(ConnStr);
				Conn.Open();

				Cmd = new MySqlCommand("INSERT INTO Blitz (name, content, author) VALUES (@name, @content, @author);", Conn);
				Cmd.Parameters.AddWithValue("@name", Request.Form["ctl00$MainContent$blitzName"]);
				Cmd.Parameters.AddWithValue("@content", Request.Form["ctl00$MainContent$blitzContent"]);
				Cmd.Parameters.AddWithValue("@author", Session["id"]);

				int? i = (int?) Cmd.ExecuteScalar();

				if (i == 1)
					Response.Redirect("/MyProfile.aspx");
			}

		}

		public void Upload(object sender, EventArgs e) {
		}
	}
}