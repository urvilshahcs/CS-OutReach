
<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/AdministratorMasterpage.master" AutoEventWireup="true" CodeBehind="ApproveLeave.aspx.cs" Inherits="CSOutreach.Pages.Administrator.ApproveLeave" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
<link href="../../css/theme.default.css" rel="stylesheet" />
<script src="../../js/jquery.tablesorter.js"></script>

<script type="text/javascript">
    $(document).ready(function () {

        $(".tablesorter").tablesorter({
            // prevent text selections (optional)
            onRenderHeader: function (index) {
                if (index > 0) {
                    $(this)
                    .addClass('no-select')
                    .attr('unselectable', 'on')
                    .bind('selectstart', false);
                }
            }

        });

    });


</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContent" runat="server">
<div class="row">
<h3>Leave Applicantions</h3>
<p>Use the form below to approve/discard leave applications.</p>
</div>

 <div class="row">
       <div id="hidden_label" runat="server">
           <span class="glyphicon glyphicon-ok"></span><label> There are no leave applications for review.</label>
       </div>
     </div>

<div class="row" >
    <div id="hidden_label2"  runat="server" >
        <span class="glyphicon glyphicon-ok"></span><label>The selected leave applications have been approved. </label>
    </div>
</div>

<div class="row">
<asp:Repeater ID="LeaveApplicationsRepeater" runat="server">
<HeaderTemplate>
<table id="DataEventInstructorTable"  class="tablesorter table-hover table table-striped table-bordered" width="100%" cellspacing="0">
<thead>
<tr> 
<td>Event ID</td>
<td>Instructor First Name</td>
<td>Instructor Last Name</td>
<td>Date</td>
<td>Accept</td>
</tr>
</thead>
<tbody>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td><asp:Label ID="EventId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"evId")%>'></asp:Label></td>
<td><asp:Label ID="InstructorFname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"instrFname")%>'></asp:Label></td>
<td><asp:Label ID="InstructorLname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"instrLname")%>'></asp:Label></td>
<td><asp:Label ID="Date" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"date")%>'></asp:Label></td>
<td><asp:CheckBox ID="chkbox" runat="server" type="submit" value='<%# DataBinder.Eval(Container.DataItem,"evInsId")%>'></asp:CheckBox></td>
</tr>
</ItemTemplate>
<FooterTemplate>

</tbody>

</table>
<div class="row">
<div class="form-group col-md-3">
    <asp:Button ID="butnAccept" runat="server" type="submit" class="btn btn-success" Text="Accept" OnClick="butnAccept_Click"></asp:button>
</div>
</div>

</FooterTemplate>
</asp:Repeater>
</div>

</asp:Content>
