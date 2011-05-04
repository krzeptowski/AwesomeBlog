<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%: new Blog.DAL.UstawieniaServices().getSettings("nazwa_strony") %>
