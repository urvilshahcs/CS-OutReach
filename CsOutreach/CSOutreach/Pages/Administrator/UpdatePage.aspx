<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/AdministratorMasterpage.master" AutoEventWireup="true" CodeBehind="UpdatePage.aspx.cs" Inherits="CSOutreach.Pages.Administrator.UpdatePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <link href="../../css/datepicker.css" rel="stylesheet" />
    <link href="../../css/bootstrap-timepicker.css" rel="stylesheet" />
    <script src="../../js/bootstrap-datepicker.js"></script>
    <script src="../../js/bootstrap-timepicker.js"></script>
    <script>

        $(document).ready(function () {

            var nowTemp = new Date();
            var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate(), 0, 0, 0, 0);

            var checkin = $('.startdate').datepicker({
                
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
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContent" runat="server">

     <div>
       <h3>Update Event Details</h3>
         <p>Use the form below to update this event.</p>
    </div>
    
    <div class="row">
       <div class="alert alert-success" id="divsuccess" runat="server">
           <span class="glyphicon glyphicon-ok"></span><label>Event Updated Successfully.</label>
       </div>
     </div>
 


    <div class="row">
        <div class="form-group col-md-4">
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
                <label for="">Course Type:</label>
               <asp:DropDownList ID="drpCourseType" class="form-control" runat="server" DataTextField="CourseName">
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
         <div class="form-group col-md-4">
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


     <br />
        <asp:Button ID="btnUpdateEvent" runat="server"  type="submit" class="btn btn-primary" Text="Update Event" OnClick="btnUpdateEvent_Click" />
       
        <div class="row">
            <hr class="col-md-6" />
        </div>
              
    <script>
        function showHideOthersTxt() {
            if (document.getElementById('<%=drpEventType.ClientID%>').value == "0") {
                document.getElementById('othrLabel').style.display = "block";
            }
            else {
                document.getElementById('othrLabel').style.display = "none";
            }
        }
    </script>

</asp:Content>
