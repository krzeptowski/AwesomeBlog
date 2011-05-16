<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="Blog.Models" %>

<% /*pokaz tylko jesli sa jakiekolwiek posty*/
    try
    {
        if (((List<PostTagModel>)ViewData["PostyTagi"]).Count > 0)
        {
            int aktywny = ((List<int>)ViewData["Nawigacja"])[0];
            int postow = ((List<int>)ViewData["Nawigacja"])[1];
            int porcja = ((List<int>)ViewData["Nawigacja"])[2];

            if (aktywny != 1)
            {%>
                <span class="left"><%: Html.ActionLink("<< nowsze wpisy","Index","Home",new{offset=aktywny-1}, null ) %></span>
            <%}
            if ((aktywny * porcja) < postow)
            {%>
                <span class="right"><%: Html.ActionLink("starsze wpisy >>","Index","Home",new{offset=aktywny+1}, null ) %></span>
            <%}
            %>
                <div class="clear"></div>
            <%
        }
    }
    catch (Exception)
    { Response.Write("Wystąpił błąd podczas tworzenia nawigacji"); }
%>
