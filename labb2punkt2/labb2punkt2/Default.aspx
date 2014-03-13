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
            ItemType="labb2punkt2.Model.Contact"
            SelectMethod="ContactListView_GetData"
            InsertMethod="ContactListView_InsertItem"
            UpdateMethod="ContactListView_UpdateItem"
            DeleteMethod="ContactListView_DeleteItem"
            DataKeyNames="ContactId"
            InsertItemPosition="FirstItem">
            
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
                <asp:DataPager ID="DataPager1" runat="server" PageSize="5">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="true" FirstPageText=" << "
                            ShowNextPageButton="false" ShowPreviousPageButton="false" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowFirstPageButton="true" LastPageText=" >> "
                            ShowNextPageButton="false" ShowPreviousPageButton="false" />
                    </Fields>
                </asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                 <%-- Mall för nya rader --%>
                    <table>
                    <tr>
                        <th>
                            <asp:Label ID="FirstNameLabel" runat="server" Text="<% Item.FirstName %>" />
                             <asp:LinkButton ID="LinkButton1"  runat="server" CommandName="Delete" Text="Radera" 
                              OnClientClick='<%# String.Format("return confirm(\"Ta bort namnet {0}?\")", Item.FirstName %>'/>
                        </th>
                        <th>
                            <asp:Label ID="SecondNameLabel" runat="server" Text="<% Item.LastName %>" />
                            <asp:LinkButton runat="server" CommandName="Delete" Text="Radera" 
                              OnClientClick='<%# String.Format("return confirm(\"Ta bort namnet {0}?\")", Item.LastName %>'/>
                        </th>
                        <th>
                            <asp:Label ID="EmailLabel" runat="server" Text="<% Item.EmailAddress %>" />
                            <asp:LinkButton runat="server" CommandName="Delete" Text="Radera" 
                              OnClientClick='<%# String.Format("return confirm(\"Ta bort namnet {0}?\")", Item.EmailAddress %>'/>
                        </th>
                    </tr>
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
       <InsertItemTemplate>
             <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="FirstName" runat="server" Text="<% BindItem.FirstName %>" />
                        </td>
                        <td>
                            <asp:TextBox ID="LastName" runat="server" Text="<% BindItem.LastName %>" />
                        </td>
                        <td>
                            <asp:TextBox ID="EmailAdress" runat="server" Text="<% BindItem.EmailAdress %>" />
                        </td>
                        <td>
                            <%-- Kommandoknappar för att lägga till kontaktuppgift och rensa textfält. --%>
                            <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" />
                             <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                         
                            <%-- Kommer renderas ut som en a-tag krävs javascript fixar till sa den betraktas som en postning. --%>
                        </td>
                    </tr>
             </table>
       </InsertItemTemplate>
            <EditItemTemplate>
                       <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="FirstName" runat="server" Text="<% BindItem.FirstName %>" />
                        </td>
                        <td>
                            <asp:TextBox ID="LastName" runat="server" Text="<% BindItem.LastName %>" />
                        </td>
                        <td>
                            <asp:TextBox ID="EmailAdress" runat="server" Text="<% BindItem.EmailAdress %>" />
                        </td>
                        <td>
                            <%-- Kommandoknappar för att uppdatera kontaktuppgift och avbryta. --%>
                            <asp:LinkButton runat="server" CommandName="Update" Text="Spara" />
                             <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                            <%-- Kommer renderas ut som en a-tag krävs javascript fixar till sa den betraktas som en postning. --%>
                        </td>
                    </tr>
             </table>
            </EditItemTemplate>
             </asp:ListView>
    </div>
    </form>
</body>
</html>
