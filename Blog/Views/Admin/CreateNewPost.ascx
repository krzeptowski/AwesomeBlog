<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Blog.Models.PostTagModel>" %>
<div class="new_post">
    <h2>Utwórz nowy wpis</h2>
    <p>
        Wprowadź dane nowego wpisu, a następnie zatwierdź formularz.
    </p>
    <% using (Html.BeginForm()) {%>
        <span class="error"><%: Html.ValidationSummary(true, "Dodawanie nowego wpisu nie powiodło się. Sprawdź listę błędów i spróbuj ponownie.") %></span>

        <fieldset class="fieldset radius">
            <legend>Dane nowego wpisu</legend>
            
            <div class="editor-label-left">
                <%: Html.LabelFor(model => model.Tytul) %>:&nbsp;
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Tytul) %>
                <%: Html.ValidationMessageFor(model => model.Tytul) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Tresc) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Tresc) %>
                <%: Html.ValidationMessageFor(model => model.Tresc) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Desc) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Desc) %>
                <%: Html.ValidationMessageFor(model => model.Desc) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Keywords) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Keywords) %>
                <%: Html.ValidationMessageFor(model => model.Keywords) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Status) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Status) %>
                <%: Html.ValidationMessageFor(model => model.Status) %>
            </div>
            
            <div class="button"><input type="submit" value="Stwórz" class="button_label"/></div>
            <div class="button"><%: Html.ActionLink("Anuluj", "Index") %></div>
        </fieldset>
    <% } %>
    <div class="clear20"></div>
</div>

