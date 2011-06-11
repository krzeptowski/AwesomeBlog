<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="Blog.Models" %>
<div  class="widget">
    <h1>Archiwum</h1>
    <%  int year = 0;
        foreach(ArchiveModel each in (List<ArchiveModel>)ViewData["Archiwum"] ) {
            if (year != each.year)
            {
                year = each.year; %>
                <h2><%= year.ToString() %></h2>
           <% }
       
            string link = each.year + " - " + each.month + " (" + each.count + ")"; %>
       
           <%--<%: Html.ActionLink(link, "Index", "Home", new { year = each.year, month=each.month }, new { })%><br />--%>
           <a href="/Home/Index/<%: each.year %>/<%: each.month %>">
           <% switch (each.month)
              {
                  case 1: %>
                       styczeń
                      <% break;
                  case 2: %>
                       luty
                      <% break;
                  case 3: %>
                       marzec
                      <% break;
                  case 4: %>
                       kwiecień
                      <% break;
                  case 5: %>
                       maj
                      <% break;
                  case 6: %>
                       czerwiec
                      <% break;
                  case 7: %>
                       lipiec
                      <% break;
                  case 8: %>
                       sierpień
                      <% break;
                  case 9: %>
                       wrzesień
                      <% break;
                  case 10: %>
                       październik
                      <% break;
                  case 11: %>
                       listopad
                      <% break;
                  case 12: %>
                       grudzień
                      <% break;
                  default:%>
                      a to co?
                      <% break;
              } %>
              &nbsp(<%= each.count %>)</a><br />
           <%--<a href="/Home/Index/<%: each.year %>/<%: each.month %>"><%= each.year %> - <%= each.month %> (<%= each.count %>)</a><br />--%>
    <% } %>
</div>