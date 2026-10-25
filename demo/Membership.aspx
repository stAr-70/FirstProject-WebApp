<%@ Page  Language="C#"  AutoEventWireup="true" CodeBehind="Membership.aspx.cs" 
    Inherits="Sarah10415WebApp.demo.Membership" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 443px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Choose a Membership Plan :</td>
                    <td>
                        <asp:RadioButtonList ID="RblMembership" runat="server">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Which services would you like to include?</td>
                    <td>
                        <asp:CheckBoxList ID="CblServices" runat="server">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
