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
        <table class="table table-bordered table-responsive">
            <tr>
                <td colspan="5"><b>Input Member</b></td>
            </tr>
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
                <td align="right">
                    <asp:Button runat="server" name="addMember" id="addMember" Text="Add" class="tn btn-primary" OnClick="addMember_Click" />
                </td>
            </tr>
        </table>
        <asp:DataGrid AllowPaging="true" AutoGenerateColumns="true" runat="server" ID="MembersGrid" name="MembersGrid" CssClass="table table-bordered table-responsive"></asp:DataGrid>
        <table class="table" id="oldestMemberTable" name="oldestMemberTable" runat="server" visible="false">
            <tr>
                <td align="left"><b>Oldest Member</b></td>
                <td colspan="4"><br /></td>
            </tr>
            <tr>
                <td colspan="3"><asp:Label runat="server" id="oldestMemberLabel" name="oldestMemberLabel" ></asp:Label>
                </td>
                <td colspan="2"><br /></td>
            </tr>
        </table>
    </form>
</body>
</html>
