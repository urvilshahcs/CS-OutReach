<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/AdministratorMasterpage.master" AutoEventWireup="true" CodeBehind="UpdateEvent.aspx.cs" Inherits="CSOutreach.Pages.Administrator.UpdateEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="row">
        <h3>Update Event</h3>
        <p>Use the form below to update event.</p>
    </div>
    <div class="updateForm">
        <div class="row">
            <hr class="col-md-6" />
        </div>

        <div class="form-updateEvent">
            <div class="row">
                <div class="form-group col-md-3">
                    <label for="">Enter Event Type:</label>
                    <asp:DropDownList ID="drpEventName" CssClass="form-control" runat="server" DataTextField="TypeName" DataValueField="EventTypeId">
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-3">
                    <label for="">Course Name:</label>
                    <asp:DropDownList ID="drpCourseName" CssClass="form-control" runat="server" DataTextField="CourseName" DataValueField="CourseId">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row">
                <hr class="col-md-6" />
            </div>

            <div class="row">
                <div class="form-group col-md-3">
                    <label for="">Instructor Name:</label>
                    <input type="text" class="form-control" id="Instructor" runat="server" />
                </div>
                <div class="form-group col-md-3">
                    <label for="">Location:</label>
                    <input type="text" class="form-control" id="Location" runat="server" />
                </div>
            </div>

            <div class="row">
                <hr class="col-md-6" />
            </div>

            <asp:Button runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSearchEvents_Click" ID="btnSearchEvents" />


        </div>
        <div class="row">
            <hr class="col-md-6" />
        </div>
    </div>

    <div class="row">
        <asp:Repeater ID="updateEventRepeater" runat="server">
            <HeaderTemplate>
                <table id="DataEventsTable" class="table table-striped table-bordered" width="100%" cellspacing="0">
                    <thead>
                        <tr>
                            <td style="display: none"></td>
                            <td>Name</td>
                            <td>Event_Type</td>
                            <td>Course</td>
                            <!--<td>Skills</td>-->
                            <td>Start Date</td>
                            <td>Start Time</td>
                            <td>End Date</td>
                            <td>End Time</td>
                            <td>Location</td>
                            <td>Show Students</td>
                            <td>Edit Option</td>
                            <td>Delete Option</td>
                           

                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td style="display: none">
                        <asp:HiddenField ID="EventID" runat="server"></asp:HiddenField>
                    </td>
                    <td>
                        <asp:Label ID="EventName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"name")%>'></asp:Label></td>
                    <td>
                        <asp:Label ID="EventTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"eventTypeName") %>'></asp:Label></td>
                    <!--<td><asp:ListBox ID="ResultList" runat="server" CssClass="form-control"></asp:ListBox></td>-->
                    <td>
                        <asp:Label ID="CourseName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"eventCourseName")%>'></asp:Label></td>
                    <td>
                        <asp:Label ID="StartDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"sDate") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="StartTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"sTime") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="EndDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"eDate") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="EndTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"eTime") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="Location" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"locationTextname") %>'></asp:Label></td>

                    <td>
                        <asp:Button CssClass="btn btn-primary" ID="btnShowStudents" runat="server" Text="Show Students" OnClick="btnShowStudents_Click" value='<%# DataBinder.Eval(Container.DataItem,"id") %>'></asp:Button></td>
                    <td>
                        <asp:Button CssClass="btn btn-primary" ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" value='<%# DataBinder.Eval(Container.DataItem,"id") %>'></asp:Button></td>
                    <td>
                        <asp:Button ID="btnDelete" CssClass="btn btn-primary" runat="server" Text="Delete" OnClick="btnDelete_Click" value='<%# DataBinder.Eval(Container.DataItem,"id") %>'></asp:Button></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>

            </table>
              
        
            </FooterTemplate>
        </asp:Repeater>


    </div>



</asp:Content>
