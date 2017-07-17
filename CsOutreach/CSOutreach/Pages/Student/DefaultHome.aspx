<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Pages/MasterPages/StudentMasterPage.Master" AutoEventWireup="true" CodeBehind="DefaultHome.aspx.cs" Inherits="CSOutreach.Pages.DefaultHome" %>

<asp:Content ID="Content2" ContentPlaceHolderID="StudentContent" runat="server">
    <div class="col-md-6">
        <div id="registeredEvents">
            <div class="module">
                <h5 class="disblock" style="cursor: default;">Registered Events
                </h5>
                <div class="moduleBody">
                    <ul class="ulEvent">
                        <asp:Repeater ID="repRegisteredEvents" runat="server" OnItemDataBound="repRegisteredEvents_ItemDataBound">
                            <ItemTemplate>
                                <li><a id="lnkName" runat="server"><%# DataBinder.Eval(Container.DataItem, "Name")%></a></li>
                                <div>
                                    <asp:Literal ID="ltrlDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description")%>'></asp:Literal>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-6">
        <div id="UpComingEvents">
            <div class="module">
                <h5 class="disblock" style="cursor: default;">Upcoming Events Of Your Interest
                </h5>
                <div class="moduleBody">
                    <ul class="ulEvent">
                        <asp:Repeater ID="repUpcomingEvents" runat="server" OnItemDataBound="repUpcomingEvents_ItemDataBound">
                            <ItemTemplate>
                                <li><a id="lnkUpcomingEventName" runat="server"><%# DataBinder.Eval(Container.DataItem, "Name")%></a></li>
                                <div>
                                    <span class="modulesubcontent">Starts on </span>
                                    <asp:Literal ID="ltrlUpcomingDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "StartDate")).ToString("MMM dd, yyyy")%>'></asp:Literal>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>

                    </ul>
                </div>
            </div>

        </div>
    </div>
    <div class="clearfix"></div>
    <div class="col-md-6">
        <div id="EventSchedule">
            <div class="module">
                <h5 class="disblock" style="cursor: default;">Event Schedule
                </h5>
                <div class="moduleBody">
                    <ul class="ulEvent">
                        <asp:Repeater ID="repEventSchedule" runat="server" OnItemDataBound="repEventSchedule_ItemDataBound">
                            <ItemTemplate>
                                <li><a id="lnkEventName" runat="server"><%# DataBinder.Eval(Container.DataItem, "Name")%></a></li>
                                <div>
                                    <span class="modulesubcontent">Starts on </span>
                                    <asp:Literal ID="ltrlDate" runat="server"></asp:Literal>
                                    <span class="modulesubcontent">from </span>
                                    <asp:Literal ID="ltrlTimings" runat="server"></asp:Literal><br />
                                    <span class="modulesubcontent">at </span>
                                    <asp:Literal ID="ltrlLocation" runat="server"></asp:Literal>

                                </div>
                            </ItemTemplate>

                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-6">
        <div id="Announcements">
            <div class="module">
                <h5 class="disblock" style="cursor: default;">Announcements
                </h5>
                <div class="moduleBody">
                    <ul class="ulEvent">
                        <li><a href="#">
                            <asp:Literal runat="server" ID="ltrlPaperWorkComplete"></asp:Literal></a></li>
                        <asp:Repeater ID="repAnnouncements" runat="server">
                            <ItemTemplate>
                            </ItemTemplate>

                        </asp:Repeater>

                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

