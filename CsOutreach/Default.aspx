<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSOutreach.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <div class="page-header">
        <h1>Center for Computer Science Education & Outreach</h1>
      </div>
          <div id="carousel-cs-outreach" class="carousel slide" data-ride="carousel">
            <ol class="carousel-indicators">
              <li data-target="#carousel-cs-outreach" data-slide-to="0" class="active"></li>
              <li data-target="#carousel-cs-outreach" data-slide-to="1"></li>
              <li data-target="#carousel-cs-outreach" data-slide-to="2"></li>
            </ol>
            <div class="carousel-inner" role="listbox">
              <div class="item active">
                <img src="img/slider-test.jpg" alt="First slide"/>
                <div class="carousel-caption">
                    <h3>Mission</h3>
                    <p>Introduce the magical world of Computer Programming in enjoyable manner to every school student in greater Dallas area.</p>
                </div>
              </div>
              <div class="item">
                <img src="img/slider-test.jpg" alt="Second slide"/>
                <div class="carousel-caption">
                    <h3>Activities</h3>
                    <p>Summer Camps, Workshops during School Breaks/Holidays, Weekend Clubs, Online Clubs, Programming Contests, and much more!</p>
                </div>
              </div>
              <div class="item">
                <img src="img/slider-test.jpg" alt="Third slide"/>
                <div class="carousel-caption">
                    <h3>Our Leaders</h3>
                    <p>Director: Dr. Jey Veerasamy</p>
                    <p>Associate Director: Prof. John Cole</p>
                </div>
            </div>
            <a class="left carousel-control" href="#carousel-cs-outreach" role="button" data-slide="prev">
              <span class="glyphicon glyphicon-chevron-left"></span>
              <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#carousel-cs-outreach" role="button" data-slide="next">
              <span class="glyphicon glyphicon-chevron-right"></span>
              <span class="sr-only">Next</span>
            </a>
          </div>
      </div>

</asp:Content>
