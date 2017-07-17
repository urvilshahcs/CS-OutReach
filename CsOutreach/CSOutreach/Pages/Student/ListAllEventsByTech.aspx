<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/StudentMasterPage.master" AutoEventWireup="true" CodeBehind="ListAllEventsByTech.aspx.cs" Inherits="CSOutreach.Pages.Student.ListAllEventsByTech" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">

    <!--<asp:Repeater ID="repRegisteredEvents" runat="server">
            <ItemTemplate>
                <li><a href="#"><%# DataBinder.Eval(Container.DataItem, "Name")%></a></li>
                <div>
                    <asp:Literal ID="ltrlDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description")%>'></asp:Literal>
                </div>
            </ItemTemplate>
        </asp:Repeater>-->

    <ul class="nav nav-tabs nav-justified" id="eventsType" role="tablist">        
      <li role="presentation" class="active"><a href="#javaEvents" role="tab" data-toggle="tab">Java</a></li>
      <li role="presentation"><a href="#dotnetEvents" role="tab" data-toggle="tab">DotNet</a></li>
      <li role="presentation"><a href="#androidEvents" role="tab" data-toggle="tab">Android</a></li>
    </ul>
    <div class="tab-content">
        <div id="javaEvents" role="tabpanel" class="tab-pane active">
            this is some java events
        </div>
        <div id="dotnetEvents" role="tabpanel" class="tab-pane">
            this is some dotnet events
        </div>
        <div id="androidEvents" role="tabpanel" class="tab-pane">
            this is some android events
        </div>
    </div>
    
    <!--<script>
        $('#eventsType li:eq(0) a').tab('show');
    </script>-->
</asp:Content>
