<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Blog.Models.KomentarzModel>" %>

    <% using (Html.BeginForm("Create", "Komentarz")) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
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
                <%: Html.TextAreaFor(model => model.Tresc, new { @cols = "40", @rows = "5" })%>
                <%: Html.ValidationMessageFor(model => model.Tresc) %>
            </div>

            <%: Html.HiddenFor(model => model.IdPosta) %>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

