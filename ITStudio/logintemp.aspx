<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logintemp.aspx.cs" Inherits="logintemp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableHeaderCell>
                        项目
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        值
                    </asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        IP
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="LblIP" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        User Agent
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="LblUA" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        RequestFilePath
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="LblRequestFilePath" runat="server" Text="Label"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        
    </form>
</body>
</html>
