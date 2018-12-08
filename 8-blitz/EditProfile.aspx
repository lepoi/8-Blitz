<%@ Page Title="Edit my Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="_8_blitz._EditProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="jumbotron">
		<div class="form-group">
			<h2>
				Username: 
			</h2>
			<asp:TextBox ID="usernameText" CssClass="form-control" runat="server" required />

			<h3>
				About:
			</h3>
			<asp:TextBox ID="aboutText" CssClass="form-control" TextMode="MultiLine" Columns="50" Rows="6" runat="server" />

			<asp:Button CssClass="btn btn-default" Text="Update" runat="server" OnClick="UpdateData" />
		</div>
	</div>	
</asp:Content>