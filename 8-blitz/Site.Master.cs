using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _8_blitz {
	public partial class SiteMaster: MasterPage {
		public bool LoggedIn = Global.LoggedIn;

		protected void Page_Load(object sender, EventArgs e) {

		}
	}
}