<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="functions.aspx.cs" Inherits="functions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContainer" runat="server">
 <div class="row">
	<ol class="breadcrumb">
		<li><a href="/"><svg class="glyph stroked home"><use xlink:href="#stroked-home"/></svg></a></li>
		<li class="active"><%=module_title %></li>
	</ol>
    </div>
    <br />
    <div class="row bd_panel">
           <%=sB.ToString() %>
  		</div>
    <script>
        var currPage = "module<%=module_id%>";

    </script>
</asp:Content>



