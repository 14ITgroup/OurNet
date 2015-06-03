<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EFHelperDemo.aspx.cs" Inherits="EFHelperDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="增加" OnClick="Button1_Click" />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="删除" />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="更新" />
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="查询" />
        <br />
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>

            </HeaderTemplate>
            <ItemTemplate>
                <table>
                    <tr>
                        <th>id</th>
                        <th>name</th>
                        <th>password</th>
                    </tr>
                    <tr>
                        <td><%#Eval("id") %></td>
                        <td><%#Eval("name") %></td>
                        <td><%#Eval("password") %></td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>

            </FooterTemplate>
        </asp:Repeater>
    
    </div>
    </form>
</body>
</html>