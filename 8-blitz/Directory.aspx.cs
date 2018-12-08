using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;

namespace _8_blitz {
	public partial class _Directory: Page {
		private static string ConnStr = "SERVER=localhost;Port=3306;DATABASE=Blitz;UID=root;PASSWORD=terminal";
		private MySqlConnection Conn;
		private MySqlCommand Cmd;
		private MySqlDataAdapter Adapter;
		private DataTable Data;
		public string DirectoryListMarkup = "";

		protected void Page_Load(object sender, EventArgs e) {
			Conn = new MySqlConnection(ConnStr);
			Conn.Open();

			Cmd = new MySqlCommand("SELECT Blitz.id as blitz, Blitz.name as name, User.id as user, User.username as username FROM Blitz, User WHERE User.id = Blitz.author", Conn);

			Adapter = new MySqlDataAdapter(Cmd);
			Data = new DataTable();
			Adapter.Fill(Data);
			
			for (int i = 0; i < Data.Rows.Count; i++) {
				DirectoryListMarkup += "<tr><td><a href=\"/Listen?blitz=" + Data.Rows[i]["blitz"] + "\" class=\"btn btn-info btn-block\" role=\"button\">" + Data.Rows[i]["name"] + "</a></td><td><a href=\"/Profile?id=" + Data.Rows[i]["user"] + "\" class=\"btn btn-primary btn-block\">" + Data.Rows[i]["username"] + "</a></td></tr>";
			}

			Conn.Close();
		}
	}
}