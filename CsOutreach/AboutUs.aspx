<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="CSOutreach.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
     <div class="page-header">
        <h1>About Us</h1>
     </div>
    
    <div class="missionHdr"><h3>Introduce the magical world of Computer Programming in enjoyable manner</h3> <h4>to every school student in greater Dallas area</h4></div>
    <div class="row">
        <div class="col-sm-6 col-md-3">
		    <div class="thumbnail">
                <div class="circle">
                    <img src="img/workshops.jpg" alt="..." class="img-circle" style="width: 120px;height: 110px;margin-top:23px;"/>			    			        
                </div>
                <div class="caption">
			        <h3><a href="#" title="Workshops">Workshops</a></h3>
			        <p>Our workshops cover every one from 3rd grader to working professionals!</p>
			    </div>                
		    </div>
		</div>
        <div class="col-sm-6 col-md-3">
		    <div class="thumbnail">
                <div class="circle">
                    <img src="img/camp.jpg" alt="Summer Camps" class="img-circle" style="width: 120px;height: 110px;margin-top:23px;"/>			    			        
                </div>
                <div class="caption">
			        <h3><a href="#" title="Summer Camps">Summer Camps</a></h3>
			        <p>Summer camps are primarily targeted towards school students runs for one whole week!</p>
			    </div>                
		    </div>
		</div>
        <div class="col-sm-6 col-md-3">
		    <div class="thumbnail">
                <div class="circle">
                    <img src="img/contest.jpg" alt="Programming Contests" class="img-circle" style="width: 120px;height: 110px;margin-top:23px;"/>			    			        
                </div>
                <div class="caption">
			        <h3><a href="#" title="Programming Contests">Programming Contests</a></h3>
			        <p>Test your programming skills </p>
			    </div>                
		    </div>
		</div>
        <div class="col-sm-6 col-md-3">
		    <div class="thumbnail">
                <div class="circle">
                    <img src="img/school.jpg" alt="..." class="img-circle" style="width: 120px;height: 110px;margin-top:23px;"/>			    			        
                </div>
                <div class="caption">
			        <h3><a href="#" title="Workshops">Custom Workshops</a></h3>
			        <p>Custom Workshops & campus tour for schools!</p>
			    </div>                
		    </div>
		</div>
    </div>
      
</asp:Content>
