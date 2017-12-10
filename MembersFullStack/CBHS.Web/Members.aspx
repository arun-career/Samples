<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="CBHS.Web.Members" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>CBHS Evaluation</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="formMembers" runat="server" method="post">
        <table class="table">
            <tr>
                <td>First Name</td>
                <td><input type="text" name="FirstName" id="FirstName" runat="server"/></td>
                <td>Email</td>
                <td><input type="text" name="Email" id="Email" runat="server"/></td>
            </tr>
            <tr>
                <td>Last Name</td>
                <td><input type="text" name="LastName" id="LastName" runat="server"/></td>
                <td>Date Of Birth</td>
                <td><input type="text" name="DateOfBirth" id="DateOfBirth" runat="server"/></td>
            </tr>
            <tr>
                <td colspan="3"></td>
                <td align="right"><input type="submit" name="Add" id="Add" value="Add" class="btn-default"  runat="server"/></td>
            </tr>
        </table>
        <asp:DataGrid AllowPaging="true" AllowSorting="true" AutoGenerateColumns="true" runat="server"></asp:DataGrid>
    </form>
</body>
</html>
