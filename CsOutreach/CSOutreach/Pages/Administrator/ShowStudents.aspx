<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/AdministratorMasterpage.master" AutoEventWireup="true" CodeBehind="ShowStudents.aspx.cs" Inherits="CSOutreach.Pages.Administrator.ShowStudents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContent" runat="server">
    <div>
       <h3>Registered Students</h3>
         
    </div>
   
    <div class="row" id="showstudentsdiv" runat="server">
        
        <asp:Repeater ID="ShowStudentsRepeater" runat="server">
        <HeaderTemplate>
            <table id="ShowStudentsTable" class="table table-striped table-bordered" width="100%" cellspacing="0">
                <thead>
                    <tr>
                     
                    <td>First Name</td>
                    <td>Last Name</td>
                    <td>Email</td>                     
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
           <tr>
              
               <td><asp:Label ID="LabelFName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"firstname")%>'></asp:Label></td>
               <td><asp:Label ID="LabelLName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"lastname")%>'></asp:Label></td>
               <td><asp:Label ID="LabelEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"email") %>'></asp:Label></td>   
           </tr>
        </ItemTemplate>
        <FooterTemplate>
            
            </tbody>

            </table>
            
        </FooterTemplate>
    </asp:Repeater>
            </div>
</asp:Content>

   

