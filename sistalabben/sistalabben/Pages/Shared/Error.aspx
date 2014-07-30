<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="sistalabben.Pages.Shared.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="~/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
     <div id="page">
        <div id="AllContent">
    <form id="form1" runat="server">
    <div>
    <h1>Serverfel</h1>
    <p>Ett fel inträffade då förfrågan behandlades.</p>
    <asp:HyperLink ID="HyperLink1"  runat="server" Text="Tillbaka till startsidan" NavigateUrl="<%$ RouteUrl:routename=ContactListing %>" 
        CssClass="nyKund" />
        <br />
    </div>
    </form>
            </div>
         </div>
</body>
</html>
