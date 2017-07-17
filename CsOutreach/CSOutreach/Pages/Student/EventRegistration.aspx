<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Pages/MasterPages/StudentMasterPage.Master" AutoEventWireup="true" CodeBehind="EventRegistration.aspx.cs" Inherits="CSOutreach.Pages.Student.EventRegistration" %>

<asp:Content ID="Content2" ContentPlaceHolderID="StudentContent" runat="server">
    <div id="eventRegisterForm">
        <div id="eventHeader">
            <div class="row">
                <h4 class="col-md-4 text-left">
                    <asp:Literal ID="EventTime" runat="server" />
                </h4>
                <h2 class="col-md-4">
                    <asp:Literal ID="EventTitle" runat="server" />
                </h2>
                <h3 class="col-md-4 text-right">
                    <asp:Literal ID="EventType" runat="server" />
                </h3>
            </div>
            <hr />
            <div class="progress text-right">
                <div class="progress-bar progress-bar-success progress-bar-striped active" id="progressbar" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%">
                </div>
            </div>
            <hr />
        </div>
        
        <div id="eventBody">
            <div id="regStep1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4>Student Information</h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="form-group col-md-6">
                                <label for="">First Name:</label>
                                <input type="text" class="form-control text-capitalize" id="FirstName" runat="server" readonly="true" />
                            </div>
                            <div class="form-group col-md-6">
                                <label for="">Last Name:</label>
                                <input type="text" class="form-control text-capitalize" id="LastName" runat="server" readonly="true" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label for="">Emergency Contact:</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-md-6">
                                <label for="">Name:</label>
                                <input type="text" class="form-control text-capitalize" maxlength="20" id="EmergConName" runat="server" />
                            </div>
                            <div class="form-group col-md-6">
                                <label for="">Relation:</label>
                                <input type="text" class="form-control text-capitalize" maxlength="15" id="EmergConRelation" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <label class="form-group col-md-2" for="">Contact Number:</label>                        
                            <div class="form-group col-md-2 ">
                                <input type="text" class="form-control col-md-1 text-center" maxlength="3" id="EmergPhoneArea" runat="server" />
                            </div>
                            <div class="form-group col-md-2 ">
                                <input type="text" class="form-control col-md-1 text-center" maxlength="3" id="EmergPhoneFirst" runat="server" />
                            </div>
                            <div class="form-group col-md-2 ">
                                <input type="text" class="form-control col-md-2 text-center" maxlength="4" id="EmergPhoneSecond" runat="server" />
                            </div>                        
                        </div>
                    </div>
                    <div class="panel-footer">
                        <div class="alert alert-danger" role="alert">
                          <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                          <span class="sr-only">Error:</span>                          
                            <span id="msg1"></span>                            
                        </div>
                        <div class="text-right">
                            <a class="btn btn-warning" href="DetailedEventsListing.aspx" id="step1PrevBtn" >Cancel Registration</a>
                            <input type="button" class="btn btn-primary" value="Next" id="step1NextBtn" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="regStep2">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 id="regStep2Title">Pre-requisites & Schedule Conflicts</h4>
                    </div>
                    <div class="panel-body">                                       
                        <div id="prereqBlock" class="col-md-6">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">Event Prerequisites</h3>
                                </div>
                                <div class="panel-body">
                                     <table class="table" id="prereqTable">
                                        <asp:Repeater ID="preReqRepeater" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# DataBinder.Eval(Container.DataItem, "Name")%></td>                                                    
                                                </tr>                                                
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                            </div>
                        </div>

                        <div id="conflictsBlock" class="col-md-6">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">Event Schedule Conflicts</h3>
                                </div>
                                <div class="panel-body">
                                    <table class="table" id="conflictsTable">
                                        <asp:Repeater ID="conflictsRepeater" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# DataBinder.Eval(Container.DataItem, "Name")%></td>
                                                    <td><%# DataBinder.Eval(Container.DataItem, "StartDate")%></td>
                                                    <td><%# DataBinder.Eval(Container.DataItem, "StartTime")%></td>
                                                    <td><%# DataBinder.Eval(Container.DataItem, "EndTime")%></td>
                                                </tr>                                                
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>                                    
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <div class="alert alert-danger" role="alert">
                          <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                          <span class="sr-only">Error:</span>                          
                            <span id="msg3"></span>                            
                            <span id="msg4"></span>  
                        </div>
                        <div class="text-right">
                            <input type="button" class="btn btn-primary" value="Prev" id="step2PrevBtn" />
                            <input type="button" class="btn btn-primary" value="Next" id="step2NextBtn" />
                        </div>
                    </div>
                </div>
            </div>

            <div id="regStep3">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 id="regStep3Title">Consent Forms</h3>
                    </div>
                    <div class="panel-body">
                        <div class="panel-group" id="accordion">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseFormOne">Consent Form 1</a>
                                    </h4>
                                </div>
                                <div id="collapseFormOne" class="panel-collapse collapse in">
                                    <div class="panel-body">
                                        <embed src="../../img/sample.pdf" width="800" height="600" id="consentForm1" />
                                        <div class="row text-center">
                                            <p>
                                                <input type="checkbox" id="form1Check" />
                                                I accept to the terms and conditions specified
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseFormTwo">Consent Form 2</a>
                                    </h4>
                                </div>
                                <div id="collapseFormTwo" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <embed src="../../img/sample.pdf" width="800" height="600" id="consentForm2" />
                                        <div class="row text-center">
                                            <p>
                                                <input type="checkbox" id="form2Check" />
                                                I accept to the terms and conditions specified
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseFormThree">Consent Form 3</a>
                                    </h4>
                                </div>
                                <div id="collapseFormThree" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <embed src="../../img/sample.pdf" width="800" height="600" id="consentForm3" />
                                        <div class="row text-center">
                                            <p>
                                                <input type="checkbox" id="form3Check" />
                                                I accept to the terms and conditions specified
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
            
                    <div class="panel-footer text-right">
                        <input type="button" class="btn btn-primary" value="Prev" id="step3PrevBtn" />
                        <input type="button" class="btn btn-primary" value="Next" id="step3NextBtn" />
                    </div>            
                </div>
            </div>

            <div id="regStep4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 id="regStep4Title">Confirmation</h3>
                    </div>
                    <div class="panel-body">                       
                        <div class="text-capitalize text-justify text-success">
                            Do You Want to register for this course?
                            <table class="table" id="confirmTable">
                                <tr>
                                    <td>Course Fees: </td>
                                    <td> $75.00 </td>
                                </tr>
                            </table>                                
                        </div>                        
                    </div>
                    <div class="panel-footer">
                        <div class="alert alert-danger" id="divError" role="alert">
                          <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                          <span class="sr-only">Error:</span>                          
                            <span id="msg5">Failed to register</span>                            
                        </div>
                        <div class="text-right">                            
                            <a class="btn btn-warning" href="DetailedEventsListing.aspx" id="step3CancelBtn" >Cancel Registration</a>
                            <asp:Button runat="server" Text="Register" ID="step4SubmitBtn" CssClass="btn btn-success" OnClick="registerEvent"/>                        
                        </div>
                    </div>                
                </div>
            </div>
        
            <div class="modal hide" id="pleaseWaitDialog" data-backdrop="static" data-keyboard="false">
                <div class="modal-header">
                    <h1>Processing...</h1>
                </div>
                <div class="modal-body">
                    <div class="progress progress-striped active">
                        <div class="bar" style="width: 100%;"></div>
                    </div>
                </div>
            </div>
            <%--<div class="modal fade" id="emergContModal">
              <div class="modal-dialog">
                <div class="modal-content">
                  <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Modal title</h4>
                  </div>
                  <div class="modal-body">
                    <p>One fine body&hellip;</p>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                  </div>
                </div><!-- /.modal-content -->
              </div><!-- /.modal-dialog -->
            </div><!-- /.modal -->--%>
        </div>               
    </div>
    <script>
        $(document).ready(function () {
            $('#regStep2').hide();
            $('#regStep3').hide();
            $('#regStep4').hide();
            resetMethod();
        });

        function resetMethod() {
            $('#regStep1 .panel .panel-footer .alert').hide();
            $('#regStep2 .panel .panel-footer .alert').hide();
            $('#regStep4 .panel .panel-footer .alert').hide();
        }

        $('#step1NextBtn').click(function () {
            var emergConName = $('#BodyContent_StudentContent_EmergConName').val();
            var emergConRelation = $('#BodyContent_StudentContent_EmergConRelation').val();
            var emergPhoneArea = $('#BodyContent_StudentContent_EmergPhoneArea').val();
            var emergPhoneFirst = $('#BodyContent_StudentContent_EmergPhoneFirst').val();
            var emergPhoneSecond = $('#BodyContent_StudentContent_EmergPhoneSecond').val();
            var emergPhone = emergPhoneArea + emergPhoneFirst + emergPhoneSecond;
            if (emergConName.length == 0) {
                $('#regStep1 .panel .panel-footer .alert').show();
                $('#regStep1 .panel .panel-footer .alert #msg1').empty();                
                $('#regStep1 .panel .panel-footer .alert #msg1').text("Pls Fill Emergency Contact Name");
                return;
            }
            if (emergConRelation.length == 0) {
                $('#regStep1 .panel .panel-footer .alert').show();
                $('#regStep1 .panel .panel-footer .alert #msg1').empty();                
                $('#regStep1 .panel .panel-footer .alert #msg1').text("Pls Fill Emergency Contact Relation");
                return;
            }
            
            if (emergPhoneArea.length == 0 ||
                emergPhoneFirst.length == 0 ||
                emergPhoneSecond.length == 0) {
                $('#regStep1 .panel .panel-footer .alert').show();
                $('#regStep1 .panel .panel-footer .alert #msg1').empty();                
                $('#regStep1 .panel .panel-footer .alert #msg1').text("Pls Fill Complete Emergency Contact Number");
                return;
            }

            var emergDetails = {EmergencyName: emergConName, EmergencyRelation: emergConRelation, EmergencyNumber: emergPhone };
            $.ajax({
                url: "EventRegistration.aspx/isEmergDataAvailable",
                data: JSON.stringify({ 'studentData': emergDetails }),
                cache: false,
                type: 'POST',
                Async: false,
                dataType: "json",
                contentType: 'application/json; charset=utf-8',                
                success: function (response) {
//                    alert(response.d);
                },
                error: function () {
                    Console.log("Error in making ajax conversation with the server");
                }
            });

            $('#regStep1').hide();
            $('#regStep2').show();
            $('#progressbar').css('width', '25%');
            $('#progressbar').text("25%");
            var eventName = $('#eventTitle').text();           
            var noPreReq = $('#prereqTable tr').length;
            var noConflicts = $('#conflictsTable tr').length;
            if (noPreReq != 0) {                
                $('#prereqBlock .panel').addClass('panel-danger');
            } else {
                $('#prereqBlock .panel').addClass('panel-success');                
            }
            if (noConflicts != 0) {
                $('#conflictsBlock .panel').addClass('panel-danger');
            } else {                
                $('#conflictsBlock .panel').addClass('panel-success');
            }

        });
       
        $('#step2NextBtn').click(function () {
            var noPreReq = $('#prereqTable tr').length;
            var noConflicts = $('#conflictsTable tr').length;
            $('#regStep2 .panel .panel-footer .alert #msg3').empty();
            $('#regStep2 .panel .panel-footer .alert #msg4').empty();
            
            
            if (noPreReq != 0) {
                $('#regStep2 .panel .panel-footer .alert').show();                
                $('#regStep2 .panel .panel-footer .alert #msg3').text("Prerequisites found!! Cannot register for the event");
                $('#step2NextBtn').hide();
                $('#step2PrevBtn').prop('value', 'Cancel');
                return;
            }
            if (noConflicts != 0) {
                $('#regStep2 .panel .panel-footer .alert').show();                
                $('#regStep2 .panel .panel-footer .alert #msg4').text("Conflicts found!! Cannot register for the event");
                return;
            }
            
            $('#regStep2').hide();
            $('#regStep3').show();
            $('#progressbar').css('width', '50%');
            $('#progressbar').text("50%");            
            
        });

        $('#step3NextBtn').click(function () {
            if (!$('#form1Check').is(':checked')) {
                alert("Kindly accept to the condtions specified in consent form 1");
                return;
            }
            if (!$('#form2Check').is(':checked')) {
                alert("Kindly accept to the condtions specified in consent form 2");
                return;
            }
            if (!$('#form3Check').is(':checked')) {
                alert("Kindly accept to the condtions specified in consent form 3");
                return;
            }
            $('#regStep3').hide();
            $('#regStep4').show();
            $('#progressbar').css('width', '75%');
            $('#progressbar').text("75%");
        });

        $('#step2PrevBtn').click(function () {
            $('#regStep1 .panel .panel-footer .alert').hide();
            $('#regStep1 .panel .panel-footer .alert #msg1').empty();            
            $('#regStep2').hide();
            $('#regStep1').show();
            $('#progressbar').css('width', '0%');
            $('#progressbar').text("0%");
        });

        $('#step3PrevBtn').click(function () {
            $('#regStep2 .panel .panel-footer .alert').hide();
            $('#regStep2 .panel .panel-footer .alert #msg3 #msg4').empty();            
            $('#regStep3').hide();
            $('#regStep2').show();
            $('#progressbar').css('width', '25%');
            $('#progressbar').text("25%");
        });
                
        $("#form1Check").change(function() {
            if(this.checked) {
                $('#collapseFormOne').removeClass("in");
                $('#collapseFormTwo').addClass("in");
            }
        });
        $("#form2Check").change(function () {
            if (this.checked) {
                $('#collapseFormTwo').removeClass("in");
                $('#collapseFormThree').addClass("in");
            }
        });

        var myApp;
        myApp = myApp || (function () {
            var pleaseWaitDiv = $('<div class="modal hide" id="pleaseWaitDialog" data-backdrop="static" data-keyboard="false"><div class="modal-header"><h1>Processing...</h1></div><div class="modal-body"><div class="progress progress-striped active"><div class="bar" style="width: 100%;"></div></div></div></div>');
            return {
                showPleaseWait: function () {
                    pleaseWaitDiv.modal();
                },
                hidePleaseWait: function () {
                    pleaseWaitDiv.modal('hide');
                },

            };
        })();

        //$('#BodyContent_StudentContent_step4SubmitBtn').click(function () {
        //    myApp.showPleaseWait();
        //});
    </script>
</asp:Content>

