<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/MasterPages/StudentMasterPage.master" CodeBehind="Changepassword.aspx.cs" Inherits="CSOutreach.Pages.Student.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">

    <div class="row">
        <div class="alert alert-success" id="divsuccess" runat="server">
            <span class="glyphicon glyphicon-ok"></span>
            <label>You have successfully changed the password</label>
        </div>
    </div>
    <div class="row">
        <div class="alert alert-danger" id="diverror" runat="server">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <label>Error occured while editing. Please try again later.</label>
        </div>
    </div>
    <div class="row">
        <div class="alert alert-danger" id="divmismatch" runat="server">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <label>Password mismatch.</label>
        </div>
    </div>

    <div class="row">
        <p class="has-error col-md-6"><em>*Password must be 8-15 characters long and contain at least 1 uppercase letter, 1 lowercase letter, and 1 number.</em></p>
    </div>

    <div class="row">
        <div class="form-group col-md-4">
            <asp:Label ID="Label1" runat="server" Text="Current password" Width="120px"></asp:Label>
            <asp:TextBox ID="txt_cpassword" TextMode="Password" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txt_cpassword" ForeColor="Red"
                ErrorMessage="Please enter Current password" ValidationGroup="val"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Label ID="Label2" runat="server" Text="New password"></asp:Label>
            <asp:TextBox ID="txt_npassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="txt_npassword" ForeColor="Red" ErrorMessage="Please enter New password" ValidationGroup="val"></asp:RequiredFieldValidator>
              
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-4">
            <asp:Label ID="Label3" runat="server" Text="Confirm password"></asp:Label>
            <asp:TextBox ID="txt_ccpassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ControlToValidate="txt_ccpassword" Display="Dynamic"
                ErrorMessage="Please enter Confirm  password" ForeColor="Red" ValidationGroup="val"></asp:RequiredFieldValidator>

            <asp:CompareValidator ID="CompareValidator1" runat="server"
                ControlToCompare="txt_npassword" ControlToValidate="txt_ccpassword"
                ErrorMessage="Password Mismatch" ForeColor="Red" Display="Dynamic" ValidationGroup="val"></asp:CompareValidator>
        </div>
    </div>


    <div class="row">

        <div class="form-group col-md-4">
            <asp:Button ID="btn_update" runat="server" CssClass="btn btn-primary" OnClick="btn_update_Click" Text="Update" ValidationGroup="val" />

        </div>
    </div>
</asp:Content>
