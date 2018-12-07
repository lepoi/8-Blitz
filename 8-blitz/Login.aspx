<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_8_blitz._Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="row">
		<div class="col-sm-6 col-sm-offset-3">
			<h2>Unlock your potential</h2>
			<div class="form-group access-form">
				
				<div class="input-container">
					<label for="email">Email:</label>
					<asp:TextBox ID="email" CssClass="form-control" TextMode="Email" runat="server" required></asp:TextBox>
				</div>
				
				<div class="input-container">
					<label for="password">Password:</label>
					<asp:TextBox ID="password" CssClass="form-control" TextMode="Password" pattern="^[_A-z0-9]{8,12}$" runat="server" oninvalid="this.setCustomValidity('enter between 8 and 12 alphanumeric characters')" oninput="setCustomValidity('')" required></asp:TextBox>
				</div>
				
				<asp:Button Text="Register" CssClass="btn btn-default" runat="server" onclick="Register" />
				<asp:Button Text="Login" CssClass="btn btn-default" runat="server" onclick="Login" />

				<div>
					<asp:Label ID="labelRepeated" Text="" ForeColor="Red" runat="server" />
				</div>
			</div>
		</div>
	</div>

</asp:Content>