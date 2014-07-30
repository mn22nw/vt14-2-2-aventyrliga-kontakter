<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="sistalabben.Pages.ContactPages.Create" %>

<!DOCTYPE html>

<head id="Head1" runat="server">
    <title>Äventyrliga Kontakter</title>
    <link href="~/Style.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
</head>
<body>
    <div id="page">
        <div id="AllContent">
    <form id="form1" runat="server">
        <h1>Ny kund</h1>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Följande fel inträffade:" 
            CssClass="validation-summary-errors"/>
        <asp:PlaceHolder ID="MessagePlaceHolder" runat="server" Visible="false">
            <p>Kunden lades till</p>
        </asp:PlaceHolder>
        <asp:FormView ID="FormView1" runat="server" 
            ItemType="sistalabben.MODEL.Contact"
            InsertMethod="ContactListView_InsertItem"
            DefaultMode="Insert"
            RenderOuterTable="false" >
         <InsertItemTemplate>
        <div class="editor-label">
            <label for="Name">Namn</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="Name" runat="server" Text="<%# BindItem.FirstName %>"></asp:TextBox>
        </div>
        <div class="editor-label">
            <label for="LastName">Efternamn</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="LastName" runat="server" Text="<%# BindItem.LastName %>"></asp:TextBox>
        </div>
        <div class="editor-label">
            <label for="Email">Email</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="Email" runat="server" Text="<%# BindItem.EmailAddress %>"></asp:TextBox>
        </div>
             <br />
             <asp:Button ID="SaveButton" runat="server" Text="Spara" CommandName="Insert" CssClass="nyKund"/>
            </InsertItemTemplate>
        </asp:FormView>
    </form>
            
    <asp:HyperLink ID="HyperLink1"  runat="server" Text="Tillbaka" NavigateUrl="<%$ RouteUrl:routename=ContactListing %>" CssClass="nyKund smaller" />
    </div>
    </div>
</body>
</html>


