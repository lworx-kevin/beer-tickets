<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContainer" Runat="Server">
<style>
table, th, td {
   border: 1px solid black;
}
td {
    height: 20px;
    vertical-align: center;
    padding: 15px;
    text-align: right;
}
</style>
     <div class="row">
	<ol class="breadcrumb">
		<li><a href="#"><svg class="glyph stroked home"><use xlink:href="#stroked-home"/></svg></a></li>
		<li class="active">Welcome</li>
	</ol>
    </div>

    <script>
        var currPage = "dashboard";
    </script>
</asp:Content>

