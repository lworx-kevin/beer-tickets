<%@ Page Title="" Language="C#" MasterPageFile="~/VGC.master" AutoEventWireup="true" CodeFile="PortalSession.aspx.cs" Inherits="PortalSession" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContainer" Runat="Server">
     <div class="row">
	<ol class="breadcrumb">
		<li><a href="/"><svg class="glyph stroked home"><use xlink:href="#stroked-home"/></svg></a></li>
       <%=navPath %>
	</ol>
    </div>
    <br />

     
      <div class="panel panel-info">
        <div class="panel-heading">
            <div class="row">
                <div class="col-sm-8"> <h4 class="text-primary">Portal Admin Log</h4></div>
                <%--<div class="col-sm-4 text-right">
                     <button type="button" class="btn btn-primary" onclick="CreateNew();">Create New</button>    
                </div>--%>
            </div>                          
                  
        </div>
        <div class="panel-body">
            <div class="col-md-12">
                <table id="tblUserList" class="table table-bordered table-hover table-condensed table-responsive">
                    <thead>
                        <tr>
                            <th>timestamp</th> 
                            <th>user</th>  
                            <th>action</th>                                                                                  
                        </tr>
                    </thead>
                    <tbody></tbody>                    
                </table>
            </div>
        </div>
        </div>
       

     <script>
            var currPage = "module<%=moduleId%>";
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctlscript" Runat="Server">
    <script type="text/javascript">
       
        function BindTable() {
            $("#tblUserList").dataTable().fnDestroy();
            $.ajax({
                type: "POST",
                url: "PortalSession.aspx/GETAdminLog",
                dataType: "json",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                async: true,
                cache: false,
                success: function (msg) {
                    $('#tblUserList').dataTable({
                        "responsive": true,
                        "lengthMenu": [[10, 20, 50, -1], [10, 20, 50, "All"]],
                        data: JSON.parse(msg.d),
                        columns: [                            
                              { data: "timestamp" },
                              { data: "username" },
                              { data: "action" }
                        ]
                    });
                }
            });
        }


        $(document).ready(function () {                
            BindTable();
        });
          </script>
</asp:Content>

