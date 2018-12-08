<%@ Page Title="{ username }'s Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="_8_blitz._Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="jumbotron">
		<h1><%= username %></h1>
		<p>
			<%= about %>
		</p>
	</div>

	<div class="row">
		<h2>Blitz created</h2>

		<%= blitzListMarkup %>	
	</div>
	
</asp:Content>