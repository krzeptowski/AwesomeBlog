<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Blog.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Logowanie
</asp:Content>

<asp:Content ID="main" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="LeftContent" runat="server">
    <div class="inside_left_content">
        <h2>Logowanie</h2>
        <p>
            Wprowadź login oraz hasło używkotnika. <%--Html.ActionLink("Register", "Register")--%>
        </p>

        <% using (Html.BeginForm()) { %>
            <span class="error"><%: Html.ValidationSummary(true, "Logowanie nie powiodło się. Sprawdź listę błędów i ponów próbę.") %></span>
            <div>
                <fieldset class="fieldset">
                    <legend>Dane użytkownika</legend>
                
                    <div class="editor-label">
                        <%: Html.LabelFor(m => m.UserName) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(m => m.UserName) %>
                        <%: Html.ValidationMessageFor(m => m.UserName) %>
                    </div>
                
                    <div class="editor-label">
                        <%: Html.LabelFor(m => m.Password) %>
                    </div>
                    <div class="editor-field">
                        <%: Html.PasswordFor(m => m.Password) %>
                        <%: Html.ValidationMessageFor(m => m.Password) %>
                    </div>
                
                    <div class="editor-label">
                        <%: Html.CheckBoxFor(m => m.RememberMe) %>
                        <%: Html.LabelFor(m => m.RememberMe) %>
                    </div>
                
                    <p>
                        <input type="submit" value="Zaloguj" />
                    </p>
                </fieldset>
            </div>
        <% } %>
    </div>
</asp:Content>
