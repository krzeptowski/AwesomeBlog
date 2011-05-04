<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteClear.Master" Inherits="System.Web.Mvc.ViewPage<Blog.Models.PostTagModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Nowy wpis
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("AdministrationTools"); %>

    <div class="new_post">
        <h2>Utwórz nowy wpis</h2>
        <p>
            Wprowadź dane nowego wpisu, a następnie zatwierdź formularz.
        </p>
        <% using (Html.BeginForm()) {%>
            <span class="error">
                <%: Html.ValidationSummary(true, "Dodawanie nowego wpisu nie powiodło się. Sprawdź listę błędów i spróbuj ponownie.") %>
                <% if (ViewData["result"] != null)
                   { %>
                        <%: ViewData["result"] %>
                <% } %>
            </span>
            <fieldset class="fieldset radius">
                <legend>Dane nowego wpisu</legend>
            
                <div class="editor-label-left">
                    <%: Html.LabelFor(model => model.Tytul) %>: <span class="error"><%: Html.ValidationMessageFor(model => model.Tytul) %></span>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.Tytul) %>
                </div>
            
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Tresc) %>: <span class="error"><%: Html.ValidationMessageFor(model => model.Tresc)%></span>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(model => model.Tresc, new {rows="15"} ) %>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Desc) %>: <span class="error"><%: Html.ValidationMessageFor(model => model.Desc)%></span>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(model => model.Desc, new {rows="3"} ) %>
                </div>

                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Keywords) %>: <span class="error"><%: Html.ValidationMessageFor(model => model.Keywords)%></span>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.Keywords) %>
                </div>
            
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Status) %>: <span class="error"><%: Html.ValidationMessageFor(model => model.Status)%></span>
                </div>
                <div class="editor-field">
                    <%: Html.DropDownListFor(model => model.Status, new List<SelectListItem> { new SelectListItem{Text="Widoczny",Value="1"}, new SelectListItem{Text="Ukryty", Value="0"} } )%>
                </div>
            
                <div class="button"><input type="submit" value="Stwórz" class="button_label"/></div>
                <div class="button"><%: Html.ActionLink("Anuluj", "Index", "Home") %></div>
            </fieldset>
        <% } %>
        <div class="clear20"></div>
    </div>

</asp:Content>

