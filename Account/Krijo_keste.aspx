<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Krijo_keste.aspx.cs" Inherits="financa_shkolla.Account.Krijo_keste" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #TextArea1
        {
            height: 41px;
            width: 225px;
        }
        .style1
        {
            height: 21px;
        }
        .style2
        {
            height: 26px;
        }
        .style3
        {
            height: 18px;
        }
        #koment
        {
            height: 50px;
        }
        .style4
        {
            height: 5px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="color: #003366">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                    Font-Names="Copperplate Gothic Light" Font-Overline="False" Font-Size="Large" 
                    Font-Underline="True" ForeColor="#006699" Text="Konfigurimi i kesteve"></asp:Label>
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
                Viti shkollor<asp:DropDownList 
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
                Klasa<asp:DropDownList ID="Klasaddl" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="Klasaddl_SelectedIndexChanged" style="height: 22px">
    <asp:ListItem></asp:ListItem>
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
<asp:DropDownList ID="Indeksiddl" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="Indeksiddl_SelectedIndexChanged">
    <asp:ListItem></asp:ListItem>
    <asp:ListItem>A</asp:ListItem>
    <asp:ListItem>B</asp:ListItem>
    <asp:ListItem>C</asp:ListItem>
    <asp:ListItem>D</asp:ListItem>
    <asp:ListItem>E</asp:ListItem>
    <asp:ListItem>F</asp:ListItem>
    <asp:ListItem></asp:ListItem>
</asp:DropDownList>
                Nxenesit<asp:DropDownList ID="Nxenesiddl" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="Nxenesiddl_SelectedIndexChanged" 
                    ondatabound="Nxenesiddl_DataBound">
                </asp:DropDownList>
                <asp:Label ID="krijuar_keste" runat="server" Font-Bold="False" 
                    Text="Nxenesit i jane konfiguruar kestet" Visible="False" 
                    ForeColor="#CC0000"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="cmimi_skonto" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Atesialbl" runat="server" ForeColor="Black"></asp:Label>
                &nbsp&nbsp
                <asp:Label ID="Memesialbl" runat="server" ForeColor="Black"></asp:Label>
                &nbsp&nbsp;&nbsp;
                <asp:Label ID="Tellbl" runat="server" ForeColor="Black"></asp:Label>
                &nbsp&nbsp
                &nbsp&nbsp
                <asp:Label ID="Amzalbl" runat="server" ForeColor="Black"></asp:Label>
            &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <br />
                </td>
            <td class="style3">
                </td>
            <td class="style3">
                </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Cmimilbl" runat="server" Font-Bold="True" ForeColor="#006699"></asp:Label>
                <asp:Label ID="Valutalbl" runat="server" Font-Bold="True" ForeColor="#006699"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Prenotimilbl" runat="server" Font-Bold="True" 
                    ForeColor="#006699"></asp:Label>
                <asp:Label ID="v_prenotimilbl" runat="server" Font-Bold="True" 
                    ForeColor="#006699"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="Skonto totale : " Visible="False" 
                    ForeColor="Black"></asp:Label>
                <asp:Label ID="skonto_tot" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label>
                <asp:Label ID="vlera_tot" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label>
            </td>
            <td class="style1">
                </td>
            <td class="style1">
                </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="skontoddl" runat="server" Visible="False">
                    <asp:ListItem Value="1">B1</asp:ListItem>
                    <asp:ListItem Value="2">B2</asp:ListItem>
                    <asp:ListItem Value="3">B3</asp:ListItem>
                    <asp:ListItem Value="4">B4</asp:ListItem>
                    <asp:ListItem Value="5">B5</asp:ListItem>
                    <asp:ListItem Value="6">B6</asp:ListItem>
                    <asp:ListItem Value="7">B7</asp:ListItem>
                    <asp:ListItem Value="8">B8</asp:ListItem>
                    <asp:ListItem Value="9">B9</asp:ListItem>
                    <asp:ListItem Value="10">B10</asp:ListItem>
                    <asp:ListItem Value="11">U1</asp:ListItem>
                    <asp:ListItem Value="12">U2</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="TextBox1" runat="server" Width="47px" 
                    ontextchanged="TextBox1_TextChanged" Visible="False" AutoPostBack="True" 
                    ForeColor="#006600"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" Text="%" Visible="False"></asp:Label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="*" 
                    ValidationExpression="^[+]?[0-9]\d{0,5}(\.\d{1,4})?%?$" 
                    ForeColor="#CC0000"></asp:RegularExpressionValidator>
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="Large" 
                    onclick="LinkButton1_Click" Visible="False">?</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="bb1" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:Label ID="b1" runat="server" ForeColor="#006600"></asp:Label>
                <asp:Label ID="bb2" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:Label ID="b2" runat="server" ForeColor="#006600"></asp:Label>
                <asp:Label ID="bb3" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:Label ID="b3" runat="server" ForeColor="#006600"></asp:Label>
                <asp:Label ID="bb4" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:Label ID="b4" runat="server" ForeColor="#006600"></asp:Label>
                <asp:Label ID="bb5" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:Label ID="b5" runat="server" ForeColor="#006600"></asp:Label>
                <asp:Label ID="bb6" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:Label ID="b6" runat="server" Font-Bold="False" ForeColor="#006600"></asp:Label>
                <asp:Label ID="uu1" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:Label ID="u1" runat="server" Font-Bold="False" ForeColor="#006600"></asp:Label>
                <asp:Label ID="uu2" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:Label ID="u2" runat="server" Font-Bold="False" ForeColor="#006600"></asp:Label>
                <asp:Label ID="uu3" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:Label ID="u3" runat="server" Font-Bold="False" ForeColor="#006600"></asp:Label>
                <asp:Label ID="uu4" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:Label ID="u4" runat="server" Font-Bold="False" ForeColor="#006600"></asp:Label>
                <asp:Label ID="uu5" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:Label ID="u5" runat="server" Font-Bold="False" ForeColor="#006600"></asp:Label>
                <asp:Label ID="uu6" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:Label ID="u6" runat="server" Font-Bold="False" ForeColor="#006600"></asp:Label>
            </td>
            <td class="style2">
                </td>
            <td class="style2">
                </td>

               
        </tr>
        <tr>
            <td style="color: #000000">
                <asp:Label ID="Label3" runat="server" Text="Koment" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <asp:TextBox ID="komenttxt" runat="server" Visible="False" Width="289px"></asp:TextBox>
            </td>
            <td class="style4">
                </td>
            <td class="style4">
                </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="totalilbl" runat="server" Font-Bold="True" ForeColor="#006699"></asp:Label>
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
                <asp:Label ID="kestetlbl" runat="server" Font-Bold="True" ForeColor="#006699"></asp:Label>
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
                <asp:Button ID="Krijo" runat="server" Text="Krijo keste" Height="30px" 
                    Width="100px" Visible="False" onclick="Krijo_Click" 
                    UseSubmitBehavior="False" BackColor="#006699" Font-Bold="True" 
                    ForeColor="White" />
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
                &nbsp;</td>
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
      <div id="mydiv" runat="server">
  
  
   </div>
    
</asp:Content>
