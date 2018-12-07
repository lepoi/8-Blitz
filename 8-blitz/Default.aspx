<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_8_blitz._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="text-center">8 - Blitz</h1>
        <p class="lead text-center">8-bit music creation platform</p>
		<div class="col-md-offset-5">
			<p>
				Created by:
				 <br /> &raquo; <a href="https://github.com/lepoi">Luis Naranjo</a>
				 <br /> &raquo; <a href="https://github.com/EdgarMagdaleno">Edgar Magdaleno</a>
			</p>
		</div>
    </div>

    <div class="row">
        <div class="col-xs-12 col-md-6">
            <h2>Become a creator</h2>
            <p>
                Compose short 8-bit music clips, save them to your profile and share them with anyone!
            </p>
            <p>
			<!-- TODO: links -->
			<!-- Login and Register pages -->
                <a class="btn btn-default" href="/Login">Login</a> or <a class="btn btn-default" href="/Login">Register</a>
            </p>
        </div>
        <div class="col-xs-12 col-md-6">
            <h2>Find your Blitz</h2>
            <p>
                Explore the ever-growing library of creative bursts, no strings attached.
            </p>
            <p>
			<!-- TODO: link -->
			<!-- Blitz directory page -->
                <a class="btn btn-default" href="/Directory">Blitz directory</a>
            </p>
        </div>
    </div>

</asp:Content>
