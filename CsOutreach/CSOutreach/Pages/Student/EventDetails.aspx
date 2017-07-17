<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/StudentMasterPage.master" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="CSOutreach.Pages.Student.EventDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <style>
        .Label {
            float: left;
            width: 110px;
            font-size: 12px;
            font-weight: bold;
        }

        #EventDetailMain {
            width: 100%;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-style: solid;
            border-width: 1px;
            border-color: lightgray;
            box-shadow: 4px 4px 3px #888888;
            margin-bottom: 5px;
        }

            #EventDetailMain #TitleRegion {
                width: 100%;
                border-top-left-radius: 5px;
                border-top-right-radius: 5px;
                background-color: #008542;
                padding-top: 4px;
                padding-bottom: 4px;
                padding-left: 7px;
                color: white;
            }

            #EventDetailMain #ContentRegion {
                padding-left: 7px;
                padding-bottom: 20px;
            }

            #EventDetailMain #FooterArea {
                border-top-style: solid;
                border-top-color: lightgray;
                border-top-width: 1px;
                padding-top: 2px;
                padding-bottom: 7px;
            }

            #EventDetailMain #ContentRegion div {
                padding-top: 3px;
                padding-bottom: 3px;
            }

        #ArtifactsSection {
            border-style: solid;
            border-width: 1px;
            border-color: lightgray;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            margin-bottom: 7px;
            margin-left: 10px;
            width: 40%;
        }

            #ArtifactsSection #Title {
                font-size: 10px;
                font-weight: bold;
                color: black;
                background-color: lightgray;
                border-top-left-radius: 5px;
                border-top-right-radius: 5px;
                padding-left:7px;
            }

             #ArtifactsSection div
             {
                 padding-left:7px;
                 padding-top:3px;
                 padding-bottom:3px;
                 font-size:11px;
                 font-weight:bold;
             }
    </style>

    <div id="EventDetailMain">
        <div id="TitleRegion">
            <asp:Label ID="CourseName" runat="server" Text="#CourseName"></asp:Label>
        </div>
        <div id="ContentRegion">
            <div>
                <div class="Label">
                    Event
                </div>
                <div>
                    <asp:Label ID="LabelEventName" runat="server" Text="#EventName"></asp:Label>
                </div>
            </div>

            <div>
                <div class="Label">
                    <asp:Label ID="DateLabel" runat="server" Text="Start Date"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Date1" runat="server" Text="#Date"></asp:Label>
                </div>
            </div>
            <div>
                <div class="Label">
                    <asp:Label ID="ConditionalEndDateLabel" runat="server" Text="End Date"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Date2" runat="server" Text="#Date"></asp:Label>
                </div>
            </div>

            <div>
                <div class="Label">
                    Start Time
                </div>
                <div>
                    <asp:Label ID="StartTimeLabel" runat="server" Text="#StartTime"></asp:Label>
                </div>
            </div>

            <div>
                <div class="Label">
                    End Time
                </div>
                <div>
                    <asp:Label ID="EndTimeLabel" runat="server" Text="#EndTime"></asp:Label>
                </div>
            </div>
            <div>
                <div class="Label">
                    Event Description
                </div>
                <div>
                    <asp:Label ID="EventDescLabel" runat="server" Text="#EventDesc"></asp:Label>
                </div>
            </div>
        </div>

        <div id="ArtifactsSection">
            <div id="Title">
                Related Artifacts
            </div>
            <div id="Content">
               <asp:Repeater ID="ArtifactsRepeater" runat="server">
                   <ItemTemplate>
                       <div>
                           <a id="DocLink" href='<%# Eval("DocumentLink") %>' runat="server">'<%# Eval("DocumentName") %>'</a>
                       </div>
                   </ItemTemplate>
               </asp:Repeater>
            </div>

        </div>

        <div id="FooterArea" align="right">
            <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />
        </div>
    </div>

</asp:Content>
