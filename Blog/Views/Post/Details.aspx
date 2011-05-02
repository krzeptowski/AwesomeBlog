<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Blog.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="post">
        <% PostModel post = (PostModel)ViewData["Post"]; %>
        <% TagModel tagi = (TagModel)ViewData["Tagi"]; %>
        <% List<KomentarzModel> komentarze = (List<KomentarzModel>)ViewData["Komentarze"]; %>

        <h2><a href="Post/Details/<%: post.Id %>" title="<%: post.Tytul %>"><%: post.Tytul %></a></h2>
        <div class="time">
        Dodano: <%: post.DataModyfikacji.ToString() %>
            &nbsp|&nbsp Tagi: 
            <% 
                try
                {
                    List<string> tags = (tagi.Keywords.Split(", \\".ToCharArray())).Take(4).ToList();
                    foreach (String tag in tags)
                    { %>
                        <a href="" title="Zobacz wszystkie wpisy oznaczone jako: <%: tag %>"><%: tag.ToLower() %></a><%--: (tags.IndexOf(tag) < tags.Count - 1)?",":""--%>
                    <% }
                }
                catch (Exception e)
                {
                    if (e.Message.ToString() == "Sequence contains no matching element")
                    { %>brak przypisanych tagów<% }
                    else
                    { %>wystąpił błąd<% }
                }
                %>
        </div>  
        <div style="clear:both;"></div>  
        <div class="content">
            <%= post.Tresc %>
        </div>
        <div class="coments"><a href="Post/Details/<%: post.Id %>" title=""><%: komentarze.Count(i => i.IdPosta == post.Id).ToString()%> Komentarzy</a></div>
    </div>
    

</asp:Content>
