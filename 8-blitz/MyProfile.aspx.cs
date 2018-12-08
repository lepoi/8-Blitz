using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _8_blitz {
	public partial class _MyProfile: Page {
		private static string ConnStr = "SERVER=localhost;Port=3306;DATABASE=Blitz;UID=root;PASSWORD=terminal";
		private MySqlConnection Conn;
		private MySqlCommand Cmd;
		private MySqlDataAdapter Adapter;
		private DataTable Data;
		public string blitzListMarkup = "";

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

			if (!IsPostBack) {
				for (int i = 0; i < Data.Rows.Count; i++) {
					blitzListMarkup += "<div class=\"col-xs-4\"><a class=\"btn btn-info btn-block\" href=\"Listen.aspx?blitz=" + Data.Rows[i]["id"] + "\">" + Data.Rows[i]["name"] + "</a></div>";
				}
			}
		}

		public void GoToBlitz(object sender, EventArgs e) {
			Session["blitz"] = (sender as System.Web.UI.WebControls.Button).Attributes["id"];
			Response.Redirect("Listen.aspx");
		}
	}
}