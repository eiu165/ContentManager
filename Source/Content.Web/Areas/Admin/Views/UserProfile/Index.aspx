<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ContentNamespace.Web.Code.Entities.UserProfile>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content> 
            
<asp:Content ID="Content5" ContentPlaceHolderID="Header" runat="server">   
	<link rel="stylesheet" type="text/css" href="../../Content/Styles/Thickbox.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
    <h2>Index</h2> 
    <table>
        <tr>
            <th></th>
            <th>Id</th>
            <th>Name</th>
            <th>UserName</th>
            <th>OpenIdId</th>
            <th>Application</th> 
            <th>Email</th>
            <th>Roles</th>
            <th>LastSignInDate</th> 
        </tr> 
        <% foreach (var item in Model) { %> 
        <tr>
            <td><%= Html.ActionLink("Details", "Details", new {  id=item.Id })%></td>
            <td><%= Html.Encode(item.Id) %></td>
            <td><%= Html.Encode(item.Name) %></td>
            <td><%= Html.Encode(item.UserName) %></td>
            <td><%= Html.Encode(item.OpenIdId) %></td>
            <td><%= Html.Encode(item.ApplicationsString) %></td>
            <td><%= Html.Encode(item.Email) %></td>
            <td><%= Html.Encode(item.UserRolesString ) %></td>
            <td><%= Html.Encode(String.Format("{0:g}", item.LastSignInDate)) %></td>   
        </tr> 
        <% } %> 
    </table> 
    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p> 
</asp:Content> 

<asp:Content ID="Content4" ContentPlaceHolderID="JavaScript" runat="server"> 
    <script type="text/javascript"> 
        $(function() {
            TruncateColumn(5);
            TruncateColumn(8);
        });

        function TruncateColumn(col) {
            var i = 0;
            $('tr>td:nth-child('+col+')').each(function() { 
                truncate($(this), col ,  i++);
            });
        }

        function truncate(e, col,  i) { 
            var cutOff = 3;
            if (e.text().length > cutOff) { 
                var a = $("<a href='#TB_inline?height=200&width=650&inlineId=c" + col + "r" + i + "' class='thickbox'>...</a>");
                var model = $("<div id='c" + col + "r" + i + "' style='display:none' ><div>" + e.text() + "</div></div>");
                var substr = e.text().substring(0, cutOff);
                e.text(substr).append(a).append(model);
            }
        }
     </script> 
     <script src="../../Scripts/Thickbox.js" type="text/javascript"></script>  
    
</asp:Content>

