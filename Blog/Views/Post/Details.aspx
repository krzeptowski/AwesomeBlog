<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Blog.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
    
    <div class="post">
        <% PostModel post = (PostModel)ViewData["Post"]; %>
        <% TagModel tagi = (TagModel)ViewData["Tagi"]; %>
        <% List<KomentarzModel> komentarze = (List<KomentarzModel>)ViewData["Komentarze"]; %>

        <% if (Request.IsAuthenticated) { %>
            <div class="button_edit"><a href="/Admin/Edit/<%: post.Id.ToString() %>">&nbsp;</a></div>
            <div class="button_delete"><a href="/Admin/Delete/<%: post.Id.ToString() %>">&nbsp;</a></div>
            <%--<div class="button_delete"><%: Html.ActionLink("&nbsp;", "Delete", "Admin", new { post.Id }, new { })%></div>--%>
        <% } %>

        <h2><%: String.IsNullOrEmpty(post.Tytul)?"Brak tytułu":post.Tytul %></h2>
        <div class="time">
        Dodano: <%: post.DataModyfikacji.ToString() %>
            &nbsp|&nbsp Tagi: 
            <% 
                try
                {
                    List<string> tags = (tagi.Keywords.Split(", \\".ToCharArray())).Take(4).ToList();
                    foreach (String tag in tags)
                    { %>
                        <a href="" title="Zobacz wszystkie wpisy oznaczone jako: <%: tag %>"><%: tag.ToLower()%></a>
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
            <%= post.Tresc %>
        </div>
        <hr />
        <% bool trigger = true;
           foreach (KomentarzModel each in komentarze)
           {
               string style = "";
               string name = "background-color:";
               string color = "";
               if (!trigger)
                   style = name + "#34342F";
               else
                   style = "";
               trigger = !trigger;
               %>
            <div class="comment" style="<%: style %>">
                <div class="button_delete"><a href="/Admin/DeleteComment/<%: each.Id %>,<%: post.Id %>">&nbsp;</a></div>
                <!--<div class="button_delete"><a href="/Admin/DeleteComment/<%--: each.Id --%>">&nbsp;</a></div>-->
               <div class="autor">Autor: <%: each.Autor%></div>
               <div class="data">Dodano: <%: each.DataDodania%></div> <br /> <br />
               <div class="tresc"><%: each.Tresc%></div> <br />
               <hr />
           </div>
        <%  }%>

        <div class="comment_add_link">
            <div class="comment_add_link button">
                <%: Html.ActionLink("Dodaj komentarz", "Create", "Komentarz", new { post.Id }, null) %> 
                <%--TODO: tutaj trzeba cos naprawic ale nie wiem co ;P--%>
            </div>
        </div>
    </div>

<%--Zostawiam do ajaxa. Moze sie przyda --%>
<%--    <div class="komentarz_dodaj">
    <% KomentarzModel model = new KomentarzModel
       {
           IdPosta = post.Id
       };
    %>
    <% Html.RenderPartial("../Komentarz/CreateKomentarz", model); %>
    </div>--%>

</asp:Content>
