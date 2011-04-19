<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Blog.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%if (((List<PostModel>)ViewData["Posty"]).Count > 0) {%>
    <table border="1">
        <tr>
            <th>Data dodania</th>
            <th>Tresc</th>
            <th>Tytul</th>
            <th>Status</th>
            <th>Data Modyfikacji</th>
            <th>Tagi</th>
            <th>Ilosc komentarzy</th>
        </tr>
        <% foreach (PostModel each in (List<PostModel>)ViewData["Posty"])
           {
               TagModel t = null;
               foreach(TagModel eachT in (List<TagModel>)ViewData["Tagi"])
               {
                   if(eachT.IdPosta == each.Id)
                       t = eachT;
               }
               String[] tags = null;
               if(t != null)
                   tags = t.Keywords.Split(", \\".ToCharArray(), 3);
        %>
            <tr>
                <td><%: each.DataDodania %></td>
                <td><%: each.Tytul%></td>
                <td><%: each.Tresc%></td>
                <td><%: each.Status%></td>
                <td><%: each.DataModyfikacji%></td>
                <td><%: tags != null ? tags[0] : "no tags" %></td>
                <td><%: ((List<KomentarzModel>)ViewData["Komentarze"]).Count%></td>
            </tr>
        <%} %>
    </table>
    <%} %>
</asp:Content>
