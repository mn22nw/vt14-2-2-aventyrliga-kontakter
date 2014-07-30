<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="sistalabben.Pages.ContactPages.Listing" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Äventyrliga Kontakter</title>
    <link href="~/Style.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
</head>
<body>
    <div id="page">
        <div id="AllContent">
    <form id="form1" runat="server">
        <h1>Kundlista</h1>
        <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
                <asp:Literal runat="server" ID="SuccessMessageLiteral" />
            <asp:Button CssClass="exit" runat="server" Text="Stäng" OnClientClick="nyKund exitbutton_OnClick" />
            </asp:Panel>
        <asp:HyperLink  runat="server" Text="Ny Kund" NavigateUrl="<%$ RouteUrl:routename=ContactCreate %>" CssClass="nyKund right" />

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Följande fel inträffade:" 
            CssClass="validation-summary-errors"/>
    <div>
        <asp:ListView ID="ContactListView" runat="server" AllowPaging="True"
            ItemType="sistalabben.MODEL.Contact"
            SelectMethod="ContactListView_GetData"
            DeleteMethod="ContactListView_DeleteItem"
            DataKeyNames="ContactId"
            >
            
            <LayoutTemplate>
                <table class="HeaderTb">
                    <tr>
                        <th class="firstName">Förnamn:
                        </th>
                        <th class="lastName">Efternamn:
                        </th>
                        <th class="emailTb">Email:
                        </th>
                    </tr>
                <%-- Platshallare för nya rader --%>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </table>
                <div class="paging">
                <asp:DataPager ID="DataPager1" runat="server" PageSize="5">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="true" FirstPageText="Första "
                            ShowNextPageButton="false" ShowPreviousPageButton="false" />
                        
                        <asp:NumericPagerField />
                       
                        <asp:NextPreviousPagerField ShowFirstPageButton="false" LastPageText="Sista"
                            ShowNextPageButton="false" ShowPreviousPageButton="false" ShowLastPageButton="true"/>
                    </Fields>
                </asp:DataPager>
                </div>

            </LayoutTemplate>
            <ItemTemplate>
                 <%-- Mall för nya rader --%>
                    <table id="allContactsTable" >
                    <tr>
                        <th class="firstName">
                            <asp:Label ID="FirstNameLabel" runat="server" Text="<%# Item.FirstName %>" />
                        </th>
                        <th class="lastName">
                            <asp:Label ID="SecondNameLabel" runat="server" Text="<%# Item.LastName %>" />
                        </th>
                        <th class="emailTb">
                            <asp:Label ID="EmailLabel" runat="server" Text="<%# Item.EmailAddress %> " />
                        </th>
                         <th>
                            <asp:HyperLink ID="HyperLink1" runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("ContactEdit", new { id= Item.ContactId}) %>' CssClass="nyKund smaller" />
                        </th>
                        <th>
                             <asp:LinkButton ID="LinkButton1"  runat="server" CommandName="Delete" Text="Radera"  CssClass="nyKund smaller"
                              OnClientClick='<%# String.Format("return confirm(\"Ta bort kontakten {0}?\")", Item.FirstName) %>'/>
                        </th>
                       
                    </tr>
                        <hr />
                        </table>
            </ItemTemplate>        
            <EmptyDataTemplate>
                <%-- Om kunduppgifter saknas --%>
                <table class="grid">
                    <tr>

                        <td>
                            Kunduppgifter saknas.
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            
             </asp:ListView>
    </div>
    </form>
    </div>
    </div>
</body>
</html>

