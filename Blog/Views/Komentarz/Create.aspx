<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteClear.Master" Inherits="System.Web.Mvc.ViewPage<Blog.Models.KomentarzModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Nowy komentarz
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--    <div class="new_comment">
        <h2>Utwórz nowy komentarz</h2>
        <p>
            Wprowadź imię autora oraz treść komenatrza.
        </p>
        <% Html.EnableClientValidation(); %>
        <% using (Html.BeginForm("Create", "Komentarz")) {%>
            <%: Html.ValidationSummary(true) %>
        
                <fieldset class="fieldset radius">
                    <legend>Twórz komentarz</legend>

                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Autor) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Autor) %>
                        <%: Html.ValidationMessageFor(model => model.Autor) %>
                    </div>

                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Tresc) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextAreaFor(model => model.Tresc, new { rows="15" })%>
                        <%: Html.ValidationMessageFor(model => model.Tresc) %>
                    </div>

                    <div class="button"><input type="submit" value="Create" class="button_label" /></div>
                    <% int id = Convert.ToInt32(ViewData["idPosta"]); %>
                    <div class="button"><%: Html.ActionLink("Anuluj", "Details", "Post", new { id }, null) %></div>

                </fieldset>
                <div class="clear20"></div>
        
        <% } %>
    </div>--%>
</asp:Content>
