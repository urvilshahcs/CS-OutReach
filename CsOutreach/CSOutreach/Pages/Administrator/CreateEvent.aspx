<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/AdministratorMasterpage.master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="CSOutreach.Pages.Administrator.CreateEvent" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <link href="../../css/datepicker.css" rel="stylesheet" />
    <link href="../../css/bootstrap-timepicker.css" rel="stylesheet" />
    <script src="../../js/bootstrap-datepicker.js"></script>
    <script src="../../js/bootstrap-timepicker.js"></script>
    <script>

        $(document).ready(function () {

            var nowTemp = new Date();
            var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate(), 0, 0, 0, 0);

            var checkin = $('.startdate').datepicker({
                onRender: function (date) {
                    return date.valueOf() < now.valueOf() ? 'disabled' : '';
                }
            }).on('changeDate', function (ev) {
                if (ev.date.valueOf() > checkout.date.valueOf()) {
                    var newDate = new Date(ev.date)
                    newDate.setDate(newDate.getDate() + 1);
                    checkout.setValue(newDate);
                }
                checkin.hide();
                $('.enddate')[0].focus();
            }).data('datepicker');
            var checkout = $('.enddate').datepicker({
                onRender: function (date) {
                    return date.valueOf() <= checkin.date.valueOf() ? 'disabled' : '';
                }
            }).on('changeDate', function (ev) {
                checkout.hide();
            }).data('datepicker');

            $('.timepicker-default').timepicker();
        });




    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    
  <div>
       <h3>Create Event</h3>
         <p>Use the form below to create new event.</p>
    </div>
    
    <div class="row">
       <div class="alert alert-success" id="divsuccess" runat="server">
           <span class="glyphicon glyphicon-ok"></span><label>Event Created Successfully.</label>
       </div>
     </div>
 
      <div class="row">
       <div class="alert alert-danger" id="diverror" runat="server">
           <span class="glyphicon glyphicon-exclamation-sign"></span><label> Error occured while creating event</label>
       </div>
     </div>

    <div class="row">
        <div class="form-group col-md-3">
       <label>Event Name :</label> 
      <asp:TextBox ID="txtEventName" class="form-control" runat="server"></asp:TextBox> 
        </div>       
    </div>

        <div class="row">
            <div class="form-group col-md-4">
                <label>Event Type :</label>
               <asp:DropDownList ID="drpEventType" runat="server" class="form-control" DataTextField="TypeName" DataValueField="EventTypeId" onchange="showHideOthersTxt()" AppendDataBoundItems="True">
               </asp:DropDownList>
            </div>
           <div class="form-group col-md-4" ID="othrLabel" style="display:none;">
                <label for="">If selected Other:</label>
                <asp:TextBox ID="TextBox5" class="form-control" runat="server"></asp:TextBox> 
            </div>
             </div>

        <div class="row">
            <div class="form-group col-md-4">
                 <label for="">Event Recurrance:</label>
               <asp:DropDownList ID="EventRecurrance" class="form-control"  onchange="showHideEndDate()"  runat="server">
                   <asp:ListItem Value="0">---SELECT---</asp:ListItem>
                   <asp:ListItem>1 DAY</asp:ListItem>
                   <asp:ListItem>2 DAY</asp:ListItem>
                   <asp:ListItem>3 DAY</asp:ListItem>
                   <asp:ListItem>WEEKEND</asp:ListItem>
                   <asp:ListItem>WEEKLY</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-4">
                <label for="">Course Type:</label>
               <asp:DropDownList ID="drpCourseType" class="form-control" runat="server" DataTextField="CourseName">
                </asp:DropDownList>
            </div>
            <div class="form-group col-md-3">
                <label for="">Level:</label>
                <asp:DropDownList ID="Level" class="form-control" runat="server">
                    <asp:ListItem>---SELECT---</asp:ListItem>
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    
     <div class="row">
            <hr class="col-md-12" />
        </div>
    
     <div class="row">
            <div class="form-group col-md-4">
                <label for="">Start Date:</label>
                <asp:TextBox ID="startDate" class="datepicker startdate form-control" runat="server"></asp:TextBox> 
            </div>
         <div id="edate" class="form-group col-md-4">
                <label for="">End Date:</label>
                <asp:TextBox ID="endDate" class="datepicker enddate form-control" runat="server"></asp:TextBox> 
            </div>
        </div>
    <div class="row">
            <div class="form-group col-md-4">
                <label for="">Start Time:</label>
                <asp:TextBox id="starttime" class="timepicker-default form-control" runat="server"></asp:TextBox> 
            </div>
         <div class="form-group col-md-4">
                <label for="">End Time:</label>
                <asp:TextBox ID="endtime"  CssClass="timepicker-default form-control" runat="server"></asp:TextBox> 
            </div>
        </div>
     <div class="row">
            <div class="form-group col-md-4">
                <label for="">Location:</label>
                <asp:TextBox ID="txtLocation" class="form-control" runat="server"></asp:TextBox> 
            </div>
         <div class="form-group col-md-4">
                <label for="">Description:</label>
                <asp:TextBox ID="txtDescription" class="form-control" runat="server"></asp:TextBox> 
            </div>
        </div>

     <div class="row">
            <hr class="col-md-12" />
        </div>
       <div class="row">
           <div class="form-group col-md-4">
               <label for="">Selected Instructors:</label><br />
               <asp:ListBox ID="lstSelectedInstructors"  SelectionMode="Multiple" CssClass="form-control" runat="server">
                   
               </asp:ListBox>
           </div>
           
           <div class="form-group col-md-2">
               <br /> 
               <asp:LinkButton ID="btnRemoveInstructor" 
                        runat="server" 
                        CssClass="btn btn-default" OnClick="btnRemoveInstructor_Click"    
                        >
                    <i aria-hidden="true" class="glyphicon glyphicon-minus"></i> Remove
                </asp:LinkButton>
           </div>

             <div class="form-group col-md-4">

                 <label for="">Available Instructors:</label><br />
                 <asp:ListBox ID="lstInstructor" SelectionMode="Multiple" CssClass="form-control" runat="server"></asp:ListBox>
            </div>
           <div class="form-group col-md-2">
               <br />
               <asp:LinkButton ID="btnAddInstructor" 
                        runat="server" 
                        CssClass="btn btn-default" OnClick="btnAddInstructor_Click">
                    <i aria-hidden="true" class="glyphicon glyphicon-plus"></i> Add Instructor
                </asp:LinkButton>
             </div>
           

        </div>

     <br />
        <asp:Button ID="btnCreateEvent" runat="server"  type="submit" class="btn btn-primary" Text="Create Event" OnClick="btnCreateEvent_Click" />
       
        <div class="row">
            <hr class="col-md-6" />
        </div>
              
    <script>
        
        function showHideEndDate() {
            if (document.getElementById('<%=EventRecurrance.ClientID%>').value == "WEEKEND" ||document.getElementById('<%=EventRecurrance.ClientID%>').value == "WEEKLY") {
                document.getElementById('edate').style.display = "block";
            }
            else {
                document.getElementById('edate').style.display = "none";
            }
        }

        function showHideOthersTxt() {
            if (document.getElementById('<%=drpEventType.ClientID%>').value == "0") {
                document.getElementById('othrLabel').style.display = "block";
            }
            else {
                document.getElementById('othrLabel').style.display = "none";
            }
        }



        $(document).ready(function () {



            jQuery.validator.addMethod("drpEventType", function (value, element) {
                if (document.getElementById('<%=drpEventType.ClientID%>').value == "9999") return false;
                else return true;
            }, "Please select value for event type dropdown.");

            jQuery.validator.addMethod("EventRecurrance", function (value, element) {
                if (document.getElementById('<%=EventRecurrance.ClientID%>').value == "0") return false;
                else return true;
            }, "Please select value for event recurrance type dropdown.");

            jQuery.validator.addMethod("drpCourseType", function (value, element) {
                if (document.getElementById('<%=drpCourseType.ClientID%>').value == "9999") return false;
                else return true;
            }, "Please select value for event recurrance type dropdown.");



            $("#pageform").validate({

                rules: {
                    "<%=txtEventName.UniqueID%>": { required: true },
                    "<%=drpEventType.UniqueID%>": { required: true, drpEventType: true },
                    "<%=EventRecurrance.UniqueID%>": { required: true, EventRecurrance: true },
                    "<%=drpCourseType.UniqueID%>": { required: true, drpCourseType: true },
                    "<%=startDate.UniqueID%>": { required: true },
                    "<%=starttime.UniqueID%>": { required: true },
                    "<%=endtime.UniqueID%>": { required: true },
                    "<%=txtLocation.UniqueID%>": { required: true },
                },

                messages: {
                    "<%=txtEventName.UniqueID%>": { required: "Please enter Event Name" },
                    "<%=drpEventType.UniqueID%>": { required: "Please enter Event Type" },
                    "<%=EventRecurrance.UniqueID%>": { required: "Please enter Event Recurrance" },
                    "<%=drpCourseType.UniqueID%>": { required: "Please enter Course Type" },
                    "<%=startDate.UniqueID%>": { required: "Please enter start date" },
                    "<%=starttime.UniqueID%>": { required: "Please enter start time" },
                    "<%=endtime.UniqueID%>": { required: "Please enter end time" },
                    "<%=txtLocation.UniqueID%>": { required: "Please enter Location" },

                },
                errorClass: "has-error",
            });
        });
    </script>
</asp:Content>
