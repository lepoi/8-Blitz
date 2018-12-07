using System;
using System.Data;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace _8_blitz {
	public partial class _Login: Page {
		private static string ConnStr = "SERVER=localhost;Port=3306;DATABASE=Blitz;UID=root;PASSWORD=terminal";
		private MySqlConnection Conn;
		private MySqlCommand Cmd;
		private MySqlDataAdapter Adapter;
		private DataTable Data;

		protected void Page_Load(object sender, EventArgs e) {
			if (Session["username"] != null)
				Response.Redirect("MyProfile.aspx");
		}

		public void Register(object sender, EventArgs e) {
			Conn = new MySqlConnection(ConnStr);
			Conn.Open();

			Cmd = new MySqlCommand("SELECT EXISTS(SELECT 1 FROM User WHERE email = @email)", Conn);
			Cmd.Parameters.AddWithValue("@email", email.Text);

			int i = Convert.ToInt32(Cmd.ExecuteScalar());
			
			// e-mail already exists
			if (i == 1)
				labelRepeated.Text = "That e-mail is already registered";
			// e-mail does not exist
			else if (i == 0) {
				string username = email.Text.Split('@')[0];

				labelRepeated.Text = "";
				Cmd = new MySqlCommand("INSERT INTO User (username, email, password) VALUES (@username, @email, @password);", Conn);
				Cmd.Parameters.AddWithValue("@email", email.Text);
				Cmd.Parameters.AddWithValue("@username", username);
				
				// error registering
				if (Cmd.ExecuteNonQuery() < 1)
					labelRepeated.Text = "ocurrió un error, disculpe las molestias";
				// register succeeded
				else {
					Session["id"] = Cmd.LastInsertedId;
					Session["email"] = email;
					Session["username"] = username;
					Session["about"] = "";
				}
			}

			Conn.Close();
		}

		public void Login(object sender, EventArgs e) {
			Conn = new MySqlConnection(ConnStr);
			Conn.Open();

			Cmd = new MySqlCommand("SELECT id, email, username, about FROM User WHERE email = @email AND password = @password", Conn);
			Cmd.Parameters.AddWithValue("@email", email.Text);
			Cmd.Parameters.AddWithValue("@password", password.Text);

			Adapter = new MySqlDataAdapter(Cmd);
			Data = new DataTable();
			Adapter.Fill(Data);

			// wrong credentials
			if (Data.Rows.Count == 0)
				labelRepeated.Text = "wrong credentials";
			else {
				Session["id"] = Data.Rows[0]["id"];
				Session["email"] = Data.Rows[0]["email"];
				Session["username"] = Data.Rows[0]["username"];
				Session["about"] = Data.Rows[0]["about"];

				Response.Redirect("MyProfile.aspx");
			}
		}
	}
}