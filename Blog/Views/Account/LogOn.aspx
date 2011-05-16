<%@ Page Language="C#" MasterPageFile="~/Views/Shared/SiteClear.Master" Inherits="System.Web.Mvc.ViewPage<Blog.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Logowanie
</asp:Content>

<asp:Content ID="main" ContentPlaceHolderID="MainContent" runat="server">
    <div class="logon">
        <h2>Logowanie</h2>
        <p>
            Wprowadź login oraz hasło używkotnika. <%--Html.ActionLink("Register", "Register")--%>
        </p>

        <% using (Html.BeginForm()) { %>
            <span class="error"><%: Html.ValidationSummary(true, "Logowanie nie powiodło się. Sprawdź listę błędów i ponów próbę.") %></span>
            <div>
                <fieldset class="fieldset radius">
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
                
                    <div class="button"><input type="submit" value="Zaloguj" class="button_label"/></div>
                    <!--<input type="submit" value="Zaloguj" />-->
                </fieldset>
            </div>
        <% } %>
    </div>
</asp:Content>
