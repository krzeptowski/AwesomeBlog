<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
    <%: Html.ActionLink("Strona główna", "Index", "Home")%>
    <%: Html.ActionLink("O blogu", "Show", "Page", new { tytul = "o_blogu" }, null)%>
    <%: Html.ActionLink("Autorzy", "Show", "Page", new { tytul = "autorzy" }, null)%>
    <%: Html.ActionLink("Kontakt", "Show", "Page", new { tytul = "kontakt" }, null)%>