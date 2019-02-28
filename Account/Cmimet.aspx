<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cmimet.aspx.cs" Inherits="financa_shkolla.Account.Cmimet1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
        .style2
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="color: #003366">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                    Font-Names="Copperplate Gothic Light" Font-Overline="False" Font-Size="Large" 
                    Font-Underline="True" ForeColor="#006699" Text="Konfigurimi i cmimeve"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="color: #003366">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="color: #003366">
                Viti shkollor&nbsp;&nbsp;&nbsp; Klasa</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList 
                    ID="vitiddl1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="vitiddl1_SelectedIndexChanged">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>2012-2013</asp:ListItem>
        <asp:ListItem>2013-2014</asp:ListItem>
        <asp:ListItem>2014-2015</asp:ListItem>
        <asp:ListItem Value="2015-2016">2015-2016</asp:ListItem>
        <asp:ListItem>2016-2017</asp:ListItem>
        <asp:ListItem>2017-2018</asp:ListItem>
        <asp:ListItem>2018-2019</asp:ListItem>
        <asp:ListItem>2019-2020</asp:ListItem>
    </asp:DropDownList>
                <asp:DropDownList ID="Klasaddl" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="Klasaddl_SelectedIndexChanged" style="height: 22px">
    <asp:ListItem>1</asp:ListItem>
    <asp:ListItem>2</asp:ListItem>
    <asp:ListItem>3</asp:ListItem>
    <asp:ListItem>4</asp:ListItem>
    <asp:ListItem>5</asp:ListItem>
    <asp:ListItem>6</asp:ListItem>
    <asp:ListItem>7</asp:ListItem>
    <asp:ListItem>8</asp:ListItem>
    <asp:ListItem>9</asp:ListItem>
    <asp:ListItem>10</asp:ListItem>
    <asp:ListItem>11</asp:ListItem>
    <asp:ListItem>12</asp:ListItem>
    <asp:ListItem></asp:ListItem>
</asp:DropDownList>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" style="color: #003366">
                Cmimi i shkolles</td>
            <td class="style1">
            </td>
            <td class="style1">
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:TextBox ID="TextBox1" runat="server" Width="90px"></asp:TextBox>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="EUR">EUR</asp:ListItem>
                    <asp:ListItem Value="LEK">LEK</asp:ListItem>
                    <asp:ListItem Value="USD">USD</asp:ListItem>
                </asp:DropDownList>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="*" 
                    ValidationExpression="^[+]?[0-9]\d{0,5}(\.\d{1,4})?%?$" 
                    ForeColor="#CC0000"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="Vendos cmimin e shkolles"></asp:RequiredFieldValidator>
            </td>
            <td class="style2">
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td style="color: #003366">
                Cmimi i Transportit</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Width="90px"></asp:TextBox>
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem>EUR</asp:ListItem>
                    <asp:ListItem>LEK</asp:ListItem>
                    <asp:ListItem>USD</asp:ListItem>
                </asp:DropDownList>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="TextBox2" ErrorMessage="*" 
                    ValidationExpression="^[+]?[0-9]\d{0,5}(\.\d{1,4})?%?$" 
                    ForeColor="#CC0000"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox2" ErrorMessage="Vendos cmimin e transportit"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="color: #003366">
                Prenotimi</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Width="90px"></asp:TextBox>
                <asp:DropDownList ID="DropDownList3" runat="server">
                    <asp:ListItem>EUR</asp:ListItem>
                    <asp:ListItem>LEK</asp:ListItem>
                    <asp:ListItem>USD</asp:ListItem>
                </asp:DropDownList>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="TextBox3" ErrorMessage="*" 
                    ValidationExpression="^[+]?[0-9]\d{0,5}(\.\d{1,4})?%?$" 
                    ForeColor="#CC0000"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox3" ErrorMessage="Vendos vleren e prenotimit"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>

            <script type = "text/javascript">
                function Confirm() {
                    var confirm_value = document.createElement("INPUT");
                    confirm_value.type = "hidden";
                    confirm_value.name = "confirm_value";
                    if (confirm("Jeni te sigurte qe doni te modifikoni cmimet ? ")) {
                        confirm_value.value = "Yes";
                    } else {
                        confirm_value.value = "No";
                    }
                    document.forms[0].appendChild(confirm_value);
                }
    </script>

                <asp:Button ID="Button1" runat="server" onclick="OnConfirm" Text = "Modifiko" OnClientClick = "Confirm()"
                    Visible="False" BackColor="#006699" ForeColor="White" Height="30px" 
                    Width="100px" />
                <asp:Button ID="Button2" runat="server" Text="Vendos" Visible="False" 
                    onclick="Button2_Click" UseSubmitBehavior="False" BackColor="#006699" 
                    ForeColor="White" Height="30px" Width="100px" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
