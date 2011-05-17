<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Blog.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Blog
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("AdministrationTools"); %>
    <%-- Html.RenderPartial("../Admin/CreateNewPost"); doda się ten partial jak będziemy robić ajaxem--%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
    
    <% try
       { %>
    <% if (((List<PostTagModel>)ViewData["PostyTagi"]).Count <= 0)
       { %>
            <span class="allert">Brak wpisów w Blogu</span>
    <% }
       else
       {
           foreach (PostTagModel post in (List<PostTagModel>)ViewData["PostyTagi"])
           { %>
                <div class="post">
                    
                    <% if (Request.IsAuthenticated) { %>
                        <div class="button_edit"><a href="/Admin/Edit/<%: post.Id.ToString() %>">&nbsp;</a></div>
                        <div class="button_delete"><a href="/Admin/Delete/<%: post.Id.ToString() %>">&nbsp;</a></div>
                        <%--<div class="button_delete"><%: Html.ActionLink("&nbsp;", "Delete", "Admin", new { post.Id }, new { })%></div>--%>
                    <% } %>
                    
                    <h2><%: Html.ActionLink(String.IsNullOrEmpty(post.Tytul)?"Brak tytułu":post.Tytul, "Details", "Post", new { post.Id }, new { tile = "post.Tytul" })%></h2>
                    <div class="time">
                    Dodano: <%: post.DataModyfikacji.ToString()%>
                        &nbsp|&nbsp Tagi: 
                        <% 
        try
        {
            List<string> tags = (post.Keywords.Split(", \\".ToCharArray())).Take(4).ToList();
            foreach (String tag in tags)
            { %>
                <%: Html.ActionLink(tag,"Tag",new{tag=tag},new{title="Zobacz wszystkie wpisy oznaczone jako: "+tag}) %>
                <%--<a href="" title="Zobacz wszystkie wpisy oznaczone jako: <%: tag %>"><%: tag.ToLower()%></a>--%>
                <%--: (tags.IndexOf(tag) < tags.Count - 1)?",":""--%>
            <% }
        }
        catch(NullReferenceException)
        {
            %>brak przypisanych tagów<%
        }    
        catch(InvalidOperationException)
        {
            %>brak przypisanych tagów<%
        }
        catch (Exception)
        {
            %>wystąpił błąd<%
        }
                            %>
                    </div>  
                    <div style="clear:both;"></div>  
                    <div class="content">
                        <%= post.Tresc%>
                    </div>
                    <div class="comments_count"><a href="../Post/Details/<%: post.Id %>" title=""><%: ((List<KomentarzModel>)ViewData["Komentarze"]).Count(i => i.IdPosta == post.Id).ToString()%> Komentarzy</a></div>
                </div>

                <% if (((List<PostTagModel>)ViewData["PostyTagi"]).IndexOf(post) < (((List<PostTagModel>)ViewData["PostyTagi"]).Count - 1))
                   { %>
                        <hr />
                <% } %>

        <% } /* /foreach */%> 
    <% } /* /else */%>
	<% }
       catch (NullReferenceException)
       {%>
            <span class="allert">Brak kolekcji wpisów</span>
    <% } %>
    <div id="posts_navigation">
        <% Html.RenderPartial("PostsNavigation"); %>
    </div>

</asp:Content>
