<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/StudentMasterPage.master" AutoEventWireup="true" CodeBehind="DetailedEventsListing.aspx.cs" Inherits="CSOutreach.Pages.Student.DetailedEventsListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">

    <script>
        $("document").ready(function () {
            $("#DataEventsTable").dataTable();
        });
    </script>
    <style>
        #CourseSelector
        {
            padding-top:7px;
            padding-bottom:7px;
            font-weight:bold;
        }
    </style>

   <div id="CourseSelector">
      Course <asp:DropDownList ID="CourseFilterList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CourseFilterList_SelectedIndexChanged"></asp:DropDownList>
   </div>
  
    <div>

        <asp:Repeater ID="EventDetailsRepeater" runat="server" OnItemCommand="EventDetailsRepeater_ItemCommand">
            <HeaderTemplate>
                <table id="DataEventsTable" class="table table-striped table-bordered" width="100%" cellspacing="0">
                    <thead>
                        <tr>
                            <td>No.</td>
                            <td>Event</td>
                            <td>Date</td>
                            <td>Time</td>
                            <td>Details</td>
                            <td>Action</td>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>

                    <td>
                        <asp:Label ID="LabelNo" runat="server" Text='<%# Eval("EventNo") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="LabelEvent" runat="server" Text='<%# Eval("EventName") %>'></asp:Label>
                        <asp:Label ID="EventID" runat="server" Text='<%# Eval("EventID") %>' Visible="false"></asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="LabelDate" runat="server" Text='<%# Eval("EventStartDate") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="LabelTime" runat="server" Text='<%# Eval("EventStartTime") %>'></asp:Label></td>
                    <td>
                        <asp:Button ID="ButtonDetails" runat="server" Text="Details"></asp:Button></td>
                    <td>
                        <asp:Button ID="ButtonRegister" runat="server" Text="Register"></asp:Button></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>

            </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
