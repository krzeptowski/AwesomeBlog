<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteClear.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Blog.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edytuj post
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="new_post">
        <h2>Edytuj wpis</h2>
        <p>
            Wprowadź dane do istniejącego wpisu, a następnie zatwierdź formularz.
        </p>
        <div class="clear20"></div>
        <% using (Html.BeginForm("Edit", "Admin"))
           {%>
        <fieldset class="fieldset radius">
            <legend>Zmień zawartość wpisu</legend>
            
            <%= Html.Label("Tytuł wpisu") %><br />
            <div class="editor-field">
                <%= Html.TextBox("Tytul", ((PostModel)ViewData["post"]).Tytul) %><br />
            </div>
            
            <%= Html.Label("Treść wpisu") %><br />
            <div class="editor-field">
                <%= Html.TextArea("Tresc", ((PostModel)ViewData["post"]).Tresc, new { rows = "15" })%><br />
            </div>

            <%= Html.Label("Skrócony opis") %><br />
            <div class="editor-field">
                <%= Html.TextArea("Opis", ((TagModel)ViewData["tagi"]).Desc, new {rows="3"} ) %><br />
            </div>
            
            <%= Html.Label("Słowa kluczowe") %><br />
            <div class="editor-field">
                <%= Html.TextBox("Tagi", ((TagModel)ViewData["tagi"]).Keywords) %><br />
            </div>

            <%= Html.Label("Status wpisu") %><br />
            <div class="editor-field">
                <!--<%--= Html.CheckBox("Status", ((PostModel)ViewData["post"]).Status) --%><br />-->
                <%-- Html.DropDownListFor(model => model.Status, new List<SelectListItem> { new SelectListItem{Text="Widoczny",Value="1"}, new SelectListItem{Text="Ukryty", Value="0"} } )--%>
                <%: Html.DropDownList("Status", new List<SelectListItem> { new SelectListItem{Text="Widoczny",Value="1"}, new SelectListItem{Text="Ukryty", Value="0"} })%>
            </div>
            
            <div class="button"><input type="submit" value="Zapisz" class="button_label"/></div>
            <div class="button"><%: Html.ActionLink("Anuluj", "Index", "Home") %></div>
        </fieldset>
        <% } %>
        <div class="clear20"></div>
    </div>

</asp:Content>
