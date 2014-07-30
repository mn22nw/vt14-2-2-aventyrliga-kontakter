<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="sistalabben.Pages.ContactPages.Edit" ViewStateMode="Disabled" %>
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
        <h1>Redigera Kund</h1>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Följande fel inträffade:" 
            CssClass="validation-summary-errors"/>
        <asp:PlaceHolder ID="MessagePlaceHolder" runat="server" Visible="false">
            
        </asp:PlaceHolder>
        
        <asp:FormView ID="FormView1" runat="server" 
            ItemType="sistalabben.MODEL.Contact"
            DefaultMode="Edit"
            RenderOuterTable="false" 
            SelectMethod="ContactFormView_GetItem"
            UpdateMethod="ContactFormView_UpdateItem"
            DataKeyNames="ContactId"
                >
         <EditItemTemplate>
        <div class="editor-label">
            <label for="Name">Namn</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="Name" runat="server" MaxLength="50" Text="<%# BindItem.FirstName %>"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Ett förnamn måste anges." ControlToValidate="Name" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="editor-label">
            <label for="LastName">Efternamn</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="LastName" runat="server" MaxLength="50" Text="<%# BindItem.LastName %>"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="Ett efternamn måste anges." ControlToValidate="LastName" Display="None"></asp:RequiredFieldValidator>
        </div>
        <div class="editor-label">
            <label for="Email">Email</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="Email" runat="server" MaxLength="50" Text="<%# BindItem.EmailAddress %>"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ErrorMessage="Email-fältet får ej lämnas tomt." ControlToValidate="Email" Display="None"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                 runat="server" ErrorMessage="Emailadressen verkar inte vara rätt formaterad." 
                Display="None" ControlToValidate="Email" ValidationExpression='^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$'></asp:RegularExpressionValidator>
        </div>
             <br />
             <asp:LinkButton ID="LinkButton2"  runat="server" CommandName="Update" Text="SPARA" CssClass="nyKund" />
             <asp:HyperLink ID="HyperLink1"  runat="server" Text="Avbryt" NavigateUrl="<%$ RouteUrl:routename=ContactListing %>" CssClass="nyKund" />
            </EditItemTemplate>
           
        </asp:FormView>
    </form>
    
    </div>
    </div>
</body>
</html>


