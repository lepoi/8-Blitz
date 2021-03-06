﻿<%@ Page Title="Directory Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Directory.aspx.cs" Inherits="_8_blitz._Directory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="row">
		<h1>
			Search all uploaded Blitz
		</h1>

		<table class="table table-striped">
			<thead>
				<tr>
					<th>
						Blitz
					</th>
					<th>
						Author
					</th>
				</tr>
			</thead>
			<tbody>
				<%= DirectoryListMarkup %>
			</tbody>
		</table>
	</div>

</asp:Content>