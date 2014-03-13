<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="labb2punkt2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListView ID="ContactListView" runat="server"
            ItemType="labb2punk2.Model.Contact"
            SelectMethod="ContactListView_GetData"
            DataKeyNames="ContactId">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>Förnamn:
                        </th>
                        <th>Efternamn:
                        </th>
                        <th>Email:
                        </th>
                    </tr>
                <%-- Platshallare för nya rader --%>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                 <%-- Mall för nya rader --%>
                    <table>
                    <tr>
                        <th>
                            <asp:Label ID="FirstNameLabel" runat="server" Text="<% Item.FirstName %>" />
                        </th>
                        <th>
                            <asp:Label ID="SecondNameLabel" runat="server" Text="<% Item.LastName %>" />
                        </th>
                        <th>
                            <asp:Label ID="EmailLabel" runat="server" Text="<% Item.EmailAddress %>" />
                        </th>
                    </tr>

            </ItemTemplate>
           

        </asp:ListView>
    </div>
    </form>
</body>
</html>
