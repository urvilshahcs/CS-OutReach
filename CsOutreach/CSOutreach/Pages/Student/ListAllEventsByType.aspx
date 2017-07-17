<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/StudentMasterPage.master" AutoEventWireup="true" CodeBehind="ListAllEventsByType.aspx.cs" Inherits="CSOutreach.Pages.Student.ListAllEventsByType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">

    <!--
    <ul class="nav nav-tabs nav-justified" id="eventsType" role="tablist">        
        <asp:Repeater ID="repRegisteredEvents" runat="server">
            <ItemTemplate>
                <li role="presentation" class="active"><a href="#workshops" role="tab" data-toggle="tab">Workshops</a></li>
                <div id="workshops" role="tabpanel" class="tab-pane active">
                    List of Workshops
                    <asp:Literal ID="ltrlDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description")%>'></asp:Literal>
                </div>
            </ItemTemplate>
        </asp:Repeater>      
    </ul>
    -->

    <ul class="nav nav-tabs nav-justified" id="eventsType" role="tablist">        
      <li role="presentation" class="active"><a href="#workshops" role="tab" data-toggle="tab">Workshops</a></li>      
      <li role="presentation"><a href="#summerCamps" role="tab" data-toggle="tab">SummerCamps</a></li>
      <li role="presentation"><a href="#clubs" role="tab" data-toggle="tab">Trainings</a></li>
    </ul>
    <div class="tab-content">
        <div id="workshops" role="tabpanel" class="tab-pane active">
            List of Workshops
        </div>
        <div id="summerCamps" role="tabpanel" class="tab-pane">
            List of Summercamps
        </div>
        <div id="clubs" role="tabpanel" class="tab-pane">
            List of clubs
        </div>
    </div>
    
    <!--<script>
        $('#eventsType li:eq(0) a').tab('show');
    </script>-->
</asp:Content>
