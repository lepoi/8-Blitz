using System;
using System.Data;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _8_blitz {
	public partial class _MyProfile: Page {
		private static string ConnStr = "SERVER=localhost;Port=3306;DATABASE=Blitz;UID=root;PASSWORD=terminal";
		private MySqlConnection Conn;
		private MySqlCommand Cmd;
		private MySqlDataAdapter Adapter;
		private DataTable Data;
		public DataRowCollection MyBlitz;

		protected void Page_Load(object sender, EventArgs e) {
			if (Session["email"] == null)
				Response.Redirect("Login.aspx");

			Conn = new MySqlConnection(ConnStr);
			Conn.Open();

			Cmd = new MySqlCommand("SELECT id, name FROM Blitz WHERE author = @id", Conn);
			Cmd.Parameters.AddWithValue("@id", Session["id"]);

			Adapter = new MySqlDataAdapter(Cmd);
			Data = new DataTable();
			Adapter.Fill(Data);

			MyBlitz = Data.Rows;
		}

		public void gotoBlitz(int id) {
			MessageBox.Show("" + id);
		}
	}
}