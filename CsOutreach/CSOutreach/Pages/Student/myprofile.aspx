<%@ Page Title="myprofile" Language="C#" MasterPageFile="~/Pages/MasterPages/StudentMasterPage.master" AutoEventWireup="true" CodeBehind="myprofile.aspx.cs" Inherits="CSOutreach.Pages.Student.myprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <div class="row">
        <div class="alert alert-success" id="divsuccess" runat="server">
            <span class="glyphicon glyphicon-ok"></span>
            <label>You have successfully edit the content</label>
        </div>
    </div>
    <div class="row">
        <div class="alert alert-danger" id="diverror" runat="server">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <label>Error occured while editing. Please try again later.</label>
        </div>
    </div>
    <div class="form-edit">
        <div class="row">
            <div class="form-group col-md-3">
                <label for="">First Name:</label>
                <input type="text" class="form-control" value="" id="First_Name" runat="server" maxlength="50" datatextfield="First_Name" datavaluefield="First_Name" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="First_Name" CssClass="rfv"
                    ErrorMessage="Please enter First Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-md-3">
                <label for="">Last Name:</label>
                <input type="text" class="form-control" id="Last_Name" value="" runat="server" maxlength="50" datatextfield="Last_Name" datavaluefield="Last_Name" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="Last_Name" CssClass="rfv"
                    ErrorMessage="Please enter Last Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <hr class="col-md-6" />
        </div>

        <div class="row">
            <div class="form-group col-md-6">
                <label for="">Address:</label>
                <textarea class="form-control" id="Address" runat="server" maxlength="85" datatextfield="Address_1" datavaluefield="Address_1"></textarea>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="Address" CssClass="rfv" ForeColor="Red"
                    ErrorMessage="Please enter Address"></asp:RequiredFieldValidator>
            </div>
        </div>


        <div class="row">
            <div class="col-md-3">
                <label for="">Contact Phone Number:</label>
                <input type="text" class="form-control" id="Contact_Number" runat="server" maxlength="10" datatextfield="Contact_Number" datavaluefield="Contact_Number" />
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4"
                    runat="server" CssClass="rfv"
                    ControlToValidate="Contact_Number"
                    Text="Contact Number is Required">  
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1"
                    runat="server"
                    ValidationExpression="\d{10}"
                    ControlToValidate="Contact_Number"
                    ErrorMessage="Input valid Phone Number!"></asp:RegularExpressionValidator>

            </div>
        </div>

        <div class="row">
            <hr class="col-md-6" />
        </div>

        <div class="row">
            <div class="form-group col-md-3">
                <label for="">Email:</label>
                <input type="text" class="form-control" id="Email" runat="server" datatextfield="Email" datavaluefield="Email" />
            </div>

            <div class="col-md-1" id="email-ok"></div>
        </div>
        <br />
        <div class="row">
            <asp:LinkButton ID="lnk_changepassword" runat="server"
                OnClick="lnk_changepassword_Click">Change Password</asp:LinkButton>
        </div>
        <%--<div class="row">
            <div class="form-group col-md-3">
                <label for="">Password:</label>
                <input type="password" class="form-control" id="Password" runat="server" maxlength="6" datatextfield="Password" datavaluefield="Password" />


            </div>
            <div class="form-group col-md-3">
                <label for="">Confirm Password:</label>
                <input type="password" class="form-control" id="CPassword" runat="server" />
            </div>
            <div class="col-md-1" id="password-ok"></div>
        </div>--%>
        <br />

        <asp:Button class="btn btn-primary" value="btnSubmit" ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
        <div class="row">
            <hr class="col-md-6" />
        </div>
    </div>

    <script>

        $(document).ready(function () {

            jQuery.validator.addMethod("letters", function (value, element) {
                return this.optional(element) || /^[a-zA-Z]+$/.test(value);
            }, "Please enter letters only without spaces");

            jQuery.validator.addMethod("letters_spaces", function (value, element) {
                return this.optional(element) || /^[a-zA-Z\s]+$/.test(value);
            }, "Please enter letters only");

            jQuery.validator.addMethod("checkpassword", function (value, element) {
                return this.optional(element) || /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])([a-zA-Z0-9]{8,15})+$/.test(value);
            }, "Entered password does not meet minimum requirements");

            jQuery.validator.addMethod("matchfield", function (value, element, param) {
                if (param == "email")
                    var fieldval = $("#" + "<%=Email.ClientID%>").val();
             <%--if (param == "password")
                 var fieldval = $("#" + "<%=Password.ClientID%>").val();--%>

                 return this.optional(element) || value === fieldval;
             });

             jQuery.validator.addMethod("checkaddress", function (value, element) {
                 return this.optional(element) || /^[a-zA-Z0-9'\-\,\.\s]+$/.test(value);
             }, "Address contains some invalid characters");


             $("#pageform").validate({

                 rules: {
                     "<%=First_Name.UniqueID%>": { required: true, letters: true },
                 "<%=Last_Name.UniqueID%>": { required: true, letters: true },
                 "<%=Address.UniqueID%>": { required: true, checkaddress: true },
                 "<%=Email.UniqueID%>": {
                     required: true,
                     email: true,
                     remote: function () { //call a webmethod to check user name availability
                         return {
                             url: "Signup.aspx/CheckUserExists",
                             data: "{userName: '" + $("#" + "<%=Email.ClientID%>").val() + "'}",
                                    cache: false,
                                    type: 'POST',
                                    Async: false,
                                    dataType: "json",
                                    contentType: 'application/json; charset=utf-8',
                                    dataFilter: function (response) {
                                        return $.parseJSON(response).d;  //show error message(return false) if user name alreadu exists
                                    },
                                }

                            },
                        },

                       <%-- "<%=EmailConfirm.UniqueID%>": { required: true, email: true, matchfield: "email" },
                        "<%=Password.UniqueID%>": { required: true, checkpassword: true },
                        "<%=PasswordConfirm.UniqueID%>": { required: true, checkpassword: true, matchfield: "password" },--%>


             },
             groups: {
             },
             messages: {
                 "<%=First_Name.UniqueID%>": { required: "Please enter your Firstname" },
                        "<%=Last_Name.UniqueID%>": { required: "Please enter your Lastname" },
                        "<%=Address.UniqueID%>": { required: "Please enter your Address" },

                        "<%=Email.UniqueID%>": { required: "Please enter your email", email: "Please enter a valid email address", remote: "Email already in use" },


                    },
             errorClass: "has-error",
             errorPlacement: function (error, element) {

             },
             highlight: function (element, errorClass) {
                 $(element).parent().children("input").addClass("error_vld");
             },
             unhighlight: function (element, errorClass) {
                 $(element).parent().children("input").removeClass("error_vld");
             }
         });


         });

    </script>

</asp:Content>
