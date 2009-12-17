<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentNamespace.Web.Code.Entities.HtmlContent>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="Header" runat="server">
    <style type="text/css" >
        .hand{ cursor:pointer; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset class="detailToEdit">
        <legend>Fields</legend>
        <p>
            Id:
            <%= Html.Encode(Model.Id) %>
        </p>
        <p>
            ContentData:
            <%= Html.Encode(Model.ContentData) %>
        </p>
        <p>
            ModifiedDate:
            <%= Html.Encode(String.Format("{0:g}", Model.ModifiedDate)) %>
        </p>
        <p>
            ExpireDate:
            <%= Html.Encode(String.Format("{0:g}", Model.ExpireDate)) %>
        </p>
        <p>
            ActiveDate:
            <%= Html.Encode(String.Format("{0:g}", Model.ActiveDate)) %>
        </p>
        <p>
            ModifiedBy:
            <%= Html.Encode(Model.ModifiedBy) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new {  id=Model.Id }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>




<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            $('.detailToEdit').addClass('hand').click(function() {
                var l = "/HtmlContent/Edit/<%= Model.Id %>";
                window.location = l;
                //alert('should link to:  ' + l);
            });
        });
    </script>
</asp:Content>

