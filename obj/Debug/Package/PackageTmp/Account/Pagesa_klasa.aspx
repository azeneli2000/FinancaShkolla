<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pagesa_klasa.aspx.cs" Inherits="financa_shkolla.Account.Pagesa_klasa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #TextArea1
        {
            height: 34px;
        }
        .style1
        {
            width: 620px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="color: #003366" class="style1">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" 
                    Font-Names="Copperplate Gothic Light" Font-Overline="False" Font-Size="Large" 
                    Font-Underline="True" ForeColor="#006699" 
                    Text="Raporti i pagesave sipas klasave"></asp:Label>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="color: #003366" class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="color: #003366" class="style1">
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
                Indeksi<asp:DropDownList ID="Indeksiddl" runat="server" AutoPostBack="True" 
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
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                    ForeColor="#CC0000" oncheckedchanged="CheckBox1_CheckedChanged" 
                    Text="Vetem me vonese" />
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" ForeColor="#006699" 
                    Text="Kesti aktual : "></asp:Label>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#006699"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:GridView ID="GridView1" runat="server" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" AutoGenerateColumns="False" 
                    onrowdatabound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="emri1" HeaderText="Emri" SortExpression="emri1" />
                        <asp:BoundField DataField="mbiemri1" HeaderText="Mbiemri" 
                            SortExpression="mbiemri1" />
                        <asp:BoundField DataField="keste_pa" HeaderText="Paguar" 
                            SortExpression="keste_pa" />
                        <asp:BoundField DataField="keste_paguar" HeaderText="Mbetur" 
                            SortExpression="keste_paguar" />
                        <asp:BoundField DataField="vlera_papag" DataFormatString="{0:n2}" 
                            HeaderText="Vlera Pag" HtmlEncode="False" />
                        <asp:BoundField DataField="vlera_paguar" DataFormatString="{0:n2}" 
                            HeaderText="Vlera Mbetur" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Black" 
                    Text="Totali Klasa : " Visible="False"></asp:Label>
                <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="#009933" 
                    Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Black" 
                    Text="-"></asp:Label>
                <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#CC0000" 
                    Text="Label" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:GridView ID="GridView2" runat="server" 
                    onrowdatabound="GridView2_RowDataBound" Visible="False">
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Black" 
                    Text="Totali Shkolla : " Visible="False"></asp:Label>
                <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="#009933" 
                    Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="Black" 
                    Text="-"></asp:Label>
                <asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="#CC0000" 
                    Text="Label" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Printo" 
                    BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30px" 
                    Width="100px" Visible="False" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
