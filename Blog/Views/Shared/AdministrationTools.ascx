<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

    <% if (Request.IsAuthenticated) { %>
        <div id="admin_tools">
            <p>Narzędzia administracyjne:</p>

            <div class="button"><%: Html.ActionLink("Dodaj post", "Create", "Admin",null, new { title = "opis linku" })%></div>
            <!--<span style="float:left;">Zawartość menu można edytować w /Shared/AdministrationTool.ascx. Na koniec wyrypiemy ten koment</span>-->
            <div style="clear:both;"></div>
        </div>
        <div class="clear20"></div>
    <% } %>