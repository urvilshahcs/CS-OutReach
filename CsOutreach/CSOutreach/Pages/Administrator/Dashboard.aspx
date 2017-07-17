<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/AdministratorMasterpage.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="CSOutreach.Pages.Administrator.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
        <div class="row">
            <div class ="col-md-6">
                <div id="upcommingEvents">
                     <div class="module">
                <h5 class="disblock" style="cursor: default;">Upcomming Events</h5>
                <div class="moduleBody">
                    <asp:Repeater ID="mdlEvents" runat="server">
                        <HeaderTemplate>
                            <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                    <a href='<%# Eval("Name")%>'>
                                        <%# Eval("Name")%></a>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
            </div>
            <div class ="col-md-6">
                <div id="courses">
                     <div class="module">
                <h5 class="disblock" style="cursor: default;">Current Courses</h5>
                <div class="moduleBody">
                     <asp:Repeater ID="mdlCourses" runat="server">
                        <HeaderTemplate>
                            <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                    <a href='<%# Eval("CourseName")%>'>
                                        <%# Eval("CourseName")%></a>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
            </div>
            </div>
            <div class="row">
            <div class ="col-md-6">
                <div id="Announcements">
                     <div class="module">
                <h5 class="disblock" style="cursor: default;">Announcements</h5>
                <div class="moduleBody">
                    <ul>
                        <li>Welcome to the new CS Outreach website</li>
                        <li>Please find all the naviation on the left hand side</li>
                    </ul>
                </div>
            </div>
        </div>
            </div>
            <div class ="col-md-6">
                <div id="instructorsOnLeave">
                     <div class="module">
                <h5 class="disblock" style="cursor: default;">Instructors On Leave</h5>
                <div class="moduleBody">
                    <asp:Repeater ID="mdlLeave" runat="server">
                        <HeaderTemplate>
                            <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                    <a href='<%# Eval("FirstName")%>'>
                                        <%# Eval("FirstName")%> <%# Eval("LastName")%></a>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
            </div>
            </div>
      
</asp:Content>
