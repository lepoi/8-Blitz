using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _8_blitz {
	public partial class _EditProfile: Page {
		private static string ConnStr = "SERVER=localhost;Port=3306;DATABASE=Blitz;UID=root;PASSWORD=terminal";
		private MySqlConnection Conn;
		private MySqlCommand Cmd;
		private MySqlDataAdapter Adapter;
		private DataTable Data;

		protected void Page_Load(object sender, EventArgs e) {
			if (Session["id"] == null)
				Response.Redirect("/Login");

			usernameText.Text = "" + Session["username"];
			aboutText.Text = "" + Session["about"];
		}

		public void UpdateData(object sender, EventArgs e) {
			Conn = new MySqlConnection(ConnStr);
			Conn.Open();

			Cmd = new MySqlCommand("UPDATE User SET username = @username, about = @about WHERE id = @id", Conn);
			Cmd.Parameters.AddWithValue("@username", usernameText.Text);
			Cmd.Parameters.AddWithValue("@about", aboutText.Text);
			Cmd.Parameters.AddWithValue("@id", Session["id"]);

			Session["username"] = usernameText.Text;
			Session["about"] = aboutText.Text;

			int? i = (int?) Cmd.ExecuteScalar();
			if (i != 0)
				Response.Redirect("/MyProfile.aspx");
		}
	}
}