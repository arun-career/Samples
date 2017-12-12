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
            <tr class="tableHeader">
                <th colspan="5">Input Member</th>
            </tr>
            <tr>
                <th>First Name</th>
                <td>
                    <input type="text" name="FirstName" id="FirstName" runat="server" maxlength="30" placeholder="John" class="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server" ControlToValidate="FirstName" ErrorMessage="Please input First name" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </td>
                <th>Email</th>
                <td>
                    <input type="text" name="Email" id="Email" runat="server" maxlength="50" placeholder="John.Doe@email.com" class="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldEmail" runat="server" ControlToValidate="LastName" ErrorMessage="Please input Email" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>Last Name</th>
                <td>
                    <input type="text" name="LastName" id="LastName" runat="server" maxlength="30" placeholder="Doe" class="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" ControlToValidate="LastName" ErrorMessage="Please input Last name" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </td>
                <th>Date Of Birth</th>
                <td>
                    <input type="text" name="DateOfBirth" id="DateOfBirth" runat="server" maxlength="10" placeholder="10/10/1980" class="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDateOfBirth" runat="server" ControlToValidate="DateOfBirth" ErrorMessage="Please input Date Of birth" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3"></td>
                <td align="right">
                    <asp:Button runat="server" name="addMember" id="addMember" Text="Add" class="tn btn-primary" OnClick="addMember_Click" />
                </td>
            </tr>
        </table>
        <asp:DataGrid AutoGenerateColumns="true" runat="server" ID="MembersGrid" name="MembersGrid" CssClass="table table-bordered table-responsive">
            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Top" CssClass="tableHeader" />
        </asp:DataGrid>
        <table class="table" id="oldestMemberTable" name="oldestMemberTable" runat="server" visible="false">
            <tr>
                <td align="left" colspan="5"><b>Oldest Member : </b> <asp:Label runat="server" id="oldestMemberLabel" name="oldestMemberLabel" ></asp:Label></td>
            </tr>
        </table>
    </form>
</body>
</html>
