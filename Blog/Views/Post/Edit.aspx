<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Blog.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="post_edycja">
        <% using (Html.BeginForm("Edit", "Post"))
           {%>
        <fieldset>
            <%= Html.Label("Tytul") %><br />
            <%= Html.TextBox("Tytul", ((PostModel)ViewData["post"]).Tytul) %><br />
        
            <%= Html.Label("Tresc") %><br />
            <%= Html.TextBox("Tresc", ((PostModel)ViewData["post"]).Tresc) %><br />

            <%= Html.Label("Status") %><br />
            <%= Html.CheckBox("Status", ((PostModel)ViewData["post"]).Status) %><br />

            <%= Html.Label("Tagi") %><br />
            <%= Html.TextBox("Tagi", ((TagModel)ViewData["tagi"]).Keywords) %><br />

            <%= Html.Label("Opis") %><br />
            <%= Html.TextBox("Opis", ((TagModel)ViewData["tagi"]).Desc) %><br />

            <input value="Submit" type="submit" />
        </fieldset>
        <% } %>
    </div>
</asp:Content>
