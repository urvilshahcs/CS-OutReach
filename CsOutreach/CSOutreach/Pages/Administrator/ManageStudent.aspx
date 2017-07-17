<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/AdministratorMasterpage.master" AutoEventWireup="true" CodeBehind="ManageStudent.aspx.cs" Inherits="CSOutreach.Pages.Administrator.ManageStudent" %>

<asp:Content ID="Content2" ContentPlaceHolderID="AdminContent" runat="server">

    <div class="row">
       <h3>Manage Student</h3>
       <p>Use the form below to remove or change student registration.</p>
    </div>
        
    <div class="row">
        <hr class="col-md-6" />
    </div>

    <div class="row">
        <div class="form-group col-md-3">
            <label for="">Student Name:</label>
            <input type="text" class="form-control" id="StudentName" runat="server" />
        </div>
        
    </div>
        
        <div class="row">
            <hr class="col-md-6" />
        </div>

        <asp:Button runat ="server"  CssClass="btn btn-primary" Text="Search" OnClick="Unnamed1_Click" />
        <div class="row">
            <hr class="col-md-6" />
        </div>
        
        
        <div class="row" id="studentsearchdiv" runat="server">
        
        <asp:Repeater ID="SearchStudentRepeater" runat="server">
        <HeaderTemplate>
            <table id="StudentsTable" class="table table-striped table-bordered" width="100%" cellspacing="0">
                <thead>
                    <tr>
                    <td style="display:none"></td>    
                    <td>First Name</td>
                    <td>Last Name</td>
                    <!--<td>Skills</td>-->
                    <td>Email</td>                 
                    
                    <td>Remove</td>
                        <td>Add</td>
                        </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
           <tr>
               <td style="display:none"><asp:HiddenField ID="StudentID" runat="server"></asp:HiddenField></td>
               <td><asp:Label ID="LabelFirstName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"firstname")%>'></asp:Label></td>
               
               <td><asp:Label ID="LabelLastName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"lastname")%>'></asp:Label></td>
               <td><asp:Label ID="LabelEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"email") %>'></asp:Label></td>
              
               <td><asp:Button ID="btnSelect" runat="server"  type="submit" Text="Select" value='<%# DataBinder.Eval(Container.DataItem,"studentID") %>' OnClick="btnSelect_Click"></asp:Button></td>
               <td><asp:Button ID="btnAddToEvent" runat="server"  type="submit" Text="Add to Event" value='<%# DataBinder.Eval(Container.DataItem,"studentID") %>' OnClick="btnAddToEvent_Click"></asp:Button></td>
           </tr>
        </ItemTemplate>
        <FooterTemplate>
            
            </tbody>

            </table>
            
        </FooterTemplate>
    </asp:Repeater>
            </div>
    <div class="row" id="RegisteredEvent" runat="server">
            <asp:Repeater ID="StudentEventRepeater" runat="server">
        <HeaderTemplate>
            <table id="StudentEventTable" class="table table-striped table-bordered" width="100%" cellspacing="0">
                <thead>
                    <tr>
                    <td style="display:none"></td>    
                    <td>Event Name</td>
                   
                    <td>Start Date</td>
                    <td>Start Time</td>                                    
                    <td>Select</td>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
           <tr>
               <td style="display:none"><asp:HiddenField ID="StudentID" runat="server"></asp:HiddenField></td>
               <td><asp:Label ID="LabelEventName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"eventname")%>'></asp:Label></td>
              
               <td><asp:Label ID="LabelStartDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"startdate") %>'></asp:Label></td>
              <td><asp:Label ID="LabelStartTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"starttime") %>'></asp:Label></td>
               <td><asp:Button ID="btnDelete" runat="server"  type="submit" Text="Delete" value='<%# DataBinder.Eval(Container.DataItem,"studenteventID") %>' OnClick="btnDelete_Click"></asp:Button></td>
           </tr>
        </ItemTemplate>
        <FooterTemplate>
            
            </tbody>

            </table>
            
        </FooterTemplate>
    </asp:Repeater>
        
    </div>
    <div class="row">
       <div class="alert alert-success" id="delsuccess" runat="server">
           <span class="glyphicon glyphicon-ok"></span><label>The student has been removed successfully from the event.</label>
       </div>
     </div>
 
      <div class="row">
       <div class="alert alert-danger" id="delcatch" runat="server">
           <span class="glyphicon glyphicon-exclamation-sign"></span><label> Student entry has not been removed from the event.</label>
       </div>
     </div>

    
</asp:Content>
