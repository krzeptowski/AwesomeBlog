<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Blog.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Blog
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Dodatkowa zawartość :)
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
    <% if (((List<PostModel>)ViewData["Posty"]).Count <= 0)
       { %>
            <span class="allert">Brak wpisów w Blogu</span>
    <% }
       else
       {
           foreach (PostModel post in (List<PostModel>)ViewData["Posty"])
           { %>
                <div class="post">
                    <h2><a href="Post/Details/<%: post.Id %>" title="<%: post.Tytul %>"><%: post.Tytul %></a></h2>
                    <div class="time">
                    Dodano: <%: post.DataModyfikacji.ToString() %>
                        &nbsp|&nbsp Tagi: 
                        <% 
                            try
                            {
                                List<string> tags = (((TagModel)((List<TagModel>)ViewData["Tagi"]).Single(i => i.IdPosta == post.Id)).Keywords.Split(", \\".ToCharArray())).Take(4).ToList();
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
                    <div class="coments"><a href="Post/Details/<%: post.Id %>" title=""><%: ((List<KomentarzModel>)ViewData["Komentarze"]).Count(i => i.IdPosta == post.Id).ToString()%> Komentarzy</a></div>
                </div>

                <% if (((List<PostModel>)ViewData["Posty"]).IndexOf(post) < (((List<PostModel>)ViewData["Posty"]).Count - 1))
                   { %>
                        <hr />
                <% } %>

        <% } %> 
    <% } %>
	
</asp:Content>
