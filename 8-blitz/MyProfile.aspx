<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="_8_blitz._MyProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="jumbotron">
		<h1>
			<%: Session["username"] %>
		</h1>
		<p>
			<%: Session["about"] %>
		</p>
		<a runat="server" href="~/EditProfile">Edit my profile</a>
	</div>

	<div class="row">
		<h2>Blitz created</h2>

		<%= blitzListMarkup %>
	</div>
	
</asp:Content>