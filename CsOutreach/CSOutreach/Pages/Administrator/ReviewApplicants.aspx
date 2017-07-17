<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/AdministratorMasterpage.master" AutoEventWireup="true" CodeBehind="ReviewApplicants.aspx.cs" Inherits="CSOutreach.Pages.ReviewApplicants" %>
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
<h3>Review Applicants</h3>
</div>
<div class="row">
<hr class="col-md-12" />
</div>
     <div class="row">
       <div class="alert alert-success" id="divsuccess" runat="server">
           <span class="glyphicon glyphicon-ok"></span><label>Applicant Updated Successfully.</label>
       </div>
     </div>
 

<div class="row">
<div class="form-group col-md-3">
<label>Applicant Name :</label>
<asp:TextBox ID="ApplicantName" CssClass="form-control" runat="server"></asp:TextBox>
</div>
<div class="form-group col-md-3">
<label>Semester Started :</label>
<asp:TextBox ID="SemStarted" CssClass="form-control" runat="server"></asp:TextBox>
</div>

</div> 
<!--<div class="row">
<div class="form-group col-md-6">
<label for="">Applicant Skill Set:</label>

<asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" CssClass="form-control" DataTextField="SkillName" DataValueField="SkillSetId" >
</asp:ListBox>
</div>

</div>-->


<div class="row">
<hr class="col-md-6" />
</div>

<div class="row">
<div class="form-group col-md-3">
<asp:Button ID="btnSearchApplcnt" runat="server" type="submit" class="btn btn-primary" Text="Search" OnClick="btnSearchApplcnt_Click" />
</div>
</div>

<div class="row">
<hr class="col-md-12" />
</div>

<div class="row">
<asp:Repeater ID="ReviewApplcntRepeater" runat="server">
<HeaderTemplate>
<table id="DataEventsTable"  class="tablesorter table-hover table table-striped table-bordered" width="100%" cellspacing="0">
<thead>
<tr>
<td style="display:none"></td> 
<td>First Name</td>
<td>Last Name</td>
<td>Degree Major</td>
<td>Has Car</td>
<td>Phone Number</td>
<td>Joined Utd</td>
<td>select</td>
</tr>
</thead>
<tbody>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td style="display:none"><asp:HiddenField ID="instructorID" runat="server"></asp:HiddenField></td>
<td><asp:Label ID="LabelfName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"firstname")%>'></asp:Label></td>
<td><asp:Label ID="LabellName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"lastname")%>'></asp:Label></td>
<td><asp:Label ID="LabelDegreeMajor" runat="server" Text='CS'></asp:Label></td>
<td><asp:Label ID="Labelhascar" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"hascar")%>'></asp:Label></td>
<td><asp:Label ID="LabelPhoneNum" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"contactnum") %>'></asp:Label></td>
<td><asp:Label ID="LabelJoinedUtd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"joinedUtd") %>'></asp:Label></td>
<td><asp:CheckBox ID="checkbx" runat="server" type="submit" value='<%# DataBinder.Eval(Container.DataItem,"instructorID")%>'></asp:CheckBox></td>
</tr>
</ItemTemplate>
<FooterTemplate>

</tbody>

</table>
<div class="row">
<div class="form-group col-md-3">
    <asp:Button ID="btnAccept" runat="server" type="submit" class="btn btn-success" Text="Accept" OnClick="btnAccept_Click"></asp:button>
</div>
</div>

</FooterTemplate>
</asp:Repeater>
</div>

</asp:Content>