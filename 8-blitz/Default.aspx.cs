﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _8_blitz {
	public partial class _Default: Page {
		protected void Page_Load(object sender, EventArgs e) {
			if (Session["id"] != null)
				Response.Redirect("/MyProfile.aspx");
		}
	}
}