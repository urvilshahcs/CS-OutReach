<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="CSOutreach.Pages.Common.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <div class="row">
       <h3>New User Sign Up</h3>
       <p>Use the form below to sign up.</p>
       <p>Once you have become a user, you will be able to register as a student or apply to be an instructor.</p>
    </div>

    <div class="row">
        <hr class="col-md-6" />
    </div>
    <div class="row">
       <div class="alert alert-success" id="divsuccess" runat="server">
           <span class="glyphicon glyphicon-ok"></span><label>You have been successfully registered. Please use your email and passwod to login.</label>
       </div>
     </div>
      <div class="row">
       <div class="alert alert-danger" id="diverror" runat="server">
           <span class="glyphicon glyphicon-exclamation-sign"></span><label> Error occured while registartion. Please try again later.</label>
       </div>
     </div>

    <div class="form-signup">
        <div class="row">
            <div class="form-group col-md-3">
                <label for="">First Name:</label>
                <input type="text" class="form-control" id="FirstName" runat="server" maxlength="50"/>
            </div>
            <div class="form-group col-md-3">
                <label for="">Last Name:</label>
                <input type="text" class="form-control" id="LastName" runat="server" maxlength="50"/>
            </div>
        </div>

        <div class="row">
            <hr class="col-md-6" />
        </div>

        <div class="row">
            <div class="form-group col-md-6">
                <label for="">Address 1:</label>
                <input type="text" class="form-control" id="Address1" runat="server" maxlength="85"/>
            </div>
        </div>
        <div class="row">
            <div class="form-group col-md-6">
                <label for="">Address 2:</label>
                <input type="text" class="form-control" id="Address2" runat="server" maxlength="85"/>
            </div>
        </div>
        <div class="row">
            <div class="form-group col-md-3">
                <label for="">City:</label>
                <input type="text" class="form-control" id="City" runat="server" maxlength="22"/>
            </div>
            <div class="form-group col-md-1">
                <label for="">State:</label>
                <input type="text" class="form-control" id="State" runat="server" maxlength="2"/>
            </div>
            <div class="form-group col-md-2">
                <label for="">Zip:</label>
                <input type="text" class="form-control" id="Zip" runat="server" maxlength="6"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <label for="">Contact Phone Number:</label>
            </div>
        </div>
        <div class="row">
            <div class="form-group col-md-1">
                <input type="text" class="form-control col-md-1" maxlength="3"  id="PhoneAreaCode" runat="server" />
            </div>
            <div class="form-group col-md-1">
                <input type="text" class="form-control col-md-1" maxlength="3" id="PhoneFirstPart" runat="server" />
            </div>
            <div class="form-group col-md-1">
                <input type="text" class="form-control col-md-1" maxlength="4" id="PhoneSecondPart" runat="server" />
            </div>
        </div>

        <div class="row">
            <hr class="col-md-6" />
        </div>

        <div class="row">
            <div class="form-group col-md-3">
                <label for="">Email:</label>
                <input type="text" class="form-control" id="Email" runat="server" />
            </div>
            <div class="form-group col-md-3">
                <label for="">Confirm Email:</label>
                <input type="text" class="form-control" id="EmailConfirm" runat="server" />
            </div>
            <div class="col-md-1" id="email-ok"></div>
        </div>
        <p class="has-error"><em>*Use your UTDallas email address if you have one.</em></p>
        <br />
        <div class="row">
            <div class="form-group col-md-3">
                <label for="">Password:</label>
                <input type="password" class="form-control" id="Password" runat="server" />
            </div>
            <div class="form-group col-md-3">
                <label for="">Confirm Password:</label>
                <input type="password" class="form-control" id="PasswordConfirm" runat="server" />
            </div>
            <div class="col-md-1" id="password-ok"></div>
        </div>
        <div class="row">
            <p class="has-error col-md-6"><em>*Password must be 8-15 characters long and contain at least 1 uppercase letter, 1 lowercase letter, and 1 number.</em></p>
        </div>
        <br />
        <input type="submit" class="btn btn-primary" value="Sign Up" id="btnclick" runat="server" onserverclick="btnSubmit_ServerClick"/>
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
                    if (param == "password")
                        var fieldval = $("#" + "<%=Password.ClientID%>").val();

                    return this.optional(element) || value === fieldval;
                });

                jQuery.validator.addMethod("checkaddress", function (value, element) {
                    return this.optional(element) || /^[a-zA-Z0-9'\-\,\.\s]+$/.test(value);
                }, "Address contains some invalid characters");


                $("#pageform").validate({

                    rules: {
                        "<%=FirstName.UniqueID%>": { required: true, letters: true },
                        "<%=LastName.UniqueID%>": { required: true, letters: true },
                        "<%=Address1.UniqueID%>": { required: true, checkaddress: true },
                        "<%=Address2.UniqueID%>": { required: true, checkaddress: true },
                        "<%=City.UniqueID%>": { required: true, letters_spaces: true },
                        "<%=State.UniqueID%>": { required: true, letters: true, minlength: 2 },
                        "<%=Zip.UniqueID%>": { required: true, digits: true, minlength: 6 },
                        "<%=PhoneAreaCode.UniqueID%>": { required: true, digits: true, minlength: 3 },
                        "<%=PhoneFirstPart.UniqueID%>": { required: true, digits: true, minlength: 3 },
                        "<%=PhoneSecondPart.UniqueID%>": { required: true, digits: true, minlength: 4 },
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

                        "<%=EmailConfirm.UniqueID%>": { required: true, email: true, matchfield: "email" },
                        "<%=Password.UniqueID%>": { required: true, checkpassword: true },
                        "<%=PasswordConfirm.UniqueID%>": { required: true, checkpassword: true, matchfield: "password" },


                    },
                    groups: {
                        phoneno: "<%=PhoneAreaCode.UniqueID%> <%=PhoneFirstPart.UniqueID%> <%=PhoneSecondPart.UniqueID%>",
                        location: "<%=City.UniqueID%> <%=State.UniqueID%> <%=Zip.UniqueID%>"
                    },
                    messages: {
                        "<%=FirstName.UniqueID%>": { required: "Please enter your Firstname" },
                        "<%=LastName.UniqueID%>": { required: "Please enter your Lastname" },
                        "<%=Address1.UniqueID%>": { required: "Please enter your Address" },
                        "<%=City.UniqueID%>": { required: "Please enter your City,State and Zip code" },
                        "<%=State.UniqueID%>": { required: "Please enter your City,State and Zip code", minlength: "Enter state code" },
                        "<%=Zip.UniqueID%>": { required: "Please enter your City,State and Zip code", digits: "Please enter numbers only for zip code", minlength: "minimum 6 digits required" },
                        "<%=PhoneAreaCode.UniqueID%>": { required: "Please enter your Contact phone number", digits: "Please enter numbers only", minlength: "minimum 3 digits required" },
                        "<%=PhoneFirstPart.UniqueID%>": { required: "Please enter your Contact phone number", digits: "Please enter numbers only", minlength: "minimum 3 digits required" },
                        "<%=PhoneSecondPart.UniqueID%>": { required: "Please enter your Contact phone number", digits: "Please enter numbers only", minlength: "minimum 4 digits required" },
                        "<%=Email.UniqueID%>": { required: "Please enter your email", email: "Please enter a valid email address", remote: "Email already in use" },
                        "<%=EmailConfirm.UniqueID%>": { required: "Please confirm your email", email: "Please enter a valid email address", matchfield: "Email and Confirm email not same" },
                        "<%=Password.UniqueID%>": { required: "Please enter your password" },
                        "<%=PasswordConfirm.UniqueID%>": { required: "Please confirm your password", matchfield: "Password and Confirm password not same" },

                    },
                    errorClass: "has-error",
                    errorPlacement: function (error, element) {
                        //show a single error message for {Phoneno} and {City,State and Zip} groups validation
                        if ($(element).attr("name") == "<%=PhoneAreaCode.UniqueID%>" || $(element).attr("name") == "<%=PhoneFirstPart.UniqueID%>" || $(element).attr("name") == "<%=PhoneSecondPart.UniqueID%>"
                            || $(element).attr("name") == "<%=City.UniqueID%>" || $(element).attr("name") == "<%=State.UniqueID%>" || $(element).attr("name") == "<%=Zip.UniqueID%>") {
                            error.insertAfter($(element).parent().parent());
                        }
                        else { error.insertAfter($(element)); }
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
<asp:Content ID="Content3" ContentPlaceHolderID="PageScripts" runat="server">
</asp:Content>
