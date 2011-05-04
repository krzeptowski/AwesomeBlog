<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Blog.Models.KomentarzModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">

    <% Html.EnableClientValidation(); %>
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
                <%: Html.TextBoxFor(model => model.Tresc) %>
                <%: Html.ValidationMessageFor(model => model.Tresc) %>
            </div>

            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>
    <% } %>

</asp:Content>