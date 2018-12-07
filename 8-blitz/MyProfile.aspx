<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="_8_blitz._MyProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="jumbotron">
		<h1>
			<%: Session["username"] %>
		</h1>
		<p>
			<%: Session["about"] %>
		</p>
	</div>

	<div class="row">
		<div class="col-sm-4 col-sm-offset-4">
			<h2>Blitz created</h2>
			
			<div id="blitz-list"></div>
			
		</div>
	</div>

	<script>
		function gotoBlitz(id) {
			window.location.replace('localhost:49716/');
		}
		var str = '';
		<% foreach (System.Data.DataRow Blitz in MyBlitz) { %>
		str += '<div class="blitz-item"><button class="btn btn-outline-primary" onclick="gotoBlitz(<%= Blitz["id"] %>)"><%= Blitz["name"] %></button></div>';
		<% } %>
		document.getElementById("blitz-list").innerHTML = str;
	</script>
	
</asp:Content>