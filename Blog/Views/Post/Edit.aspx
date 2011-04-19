<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="Form2" method="post" runat="server">
        <asp:Label ID="Label2" runat="server" Text="" ClientIDMode="Static"></asp:Label>
        <asp:TextBox ID="tbTytul" runat="server" ClientIDMode="Static"></asp:TextBox><br />
        
        <asp:Label ID="Label3" runat="server" Text="Tresc" ClientIDMode="Static"></asp:Label>
        <asp:TextBox ID="tbTresc" runat="server" Height="104px" TextMode="MultiLine" 
            Width="230px" ClientIDMode="Static"></asp:TextBox><br />

        <asp:CheckBox ID="cbStatus" runat="server" Text="Ukryc?" /><br />

        <asp:Label ID="Label1" runat="server" Text="Tagi"></asp:Label>
        <asp:TextBox ID="tbTagi" runat="server" Width="232px"></asp:TextBox><br />

        <asp:Button ID="btSubmit" runat="server" Text="Submit" ClientIDMode="Static" />
    </form>

</asp:Content>
