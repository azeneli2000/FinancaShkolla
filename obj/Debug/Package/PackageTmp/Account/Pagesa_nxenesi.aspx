<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pagesa_nxenesi.aspx.cs" Inherits="financa_shkolla.Account.Pagesa_nxenesi" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        height: 21px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                Font-Names="Copperplate Gothic Light" Font-Overline="False" Font-Size="Large" 
                Font-Underline="True" ForeColor="#006699" Text="Raporti i Pagesave te nxenesit"></asp:Label>
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
        <td class="style1">
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
                <asp:DropDownList ID="Nxenesiddl" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="Nxenesiddl_SelectedIndexChanged" 
                    ondatabound="Nxenesiddl_DataBound">
                </asp:DropDownList>
                <asp:Label ID="kestelbl" runat="server"></asp:Label>
        </td>
        <td class="style1">
        </td>
        <td class="style1">
        </td>
    </tr>
    <tr>
        <td>
                <asp:Label ID="Atesialbl" runat="server" ForeColor="Black"></asp:Label>
                <asp:Label ID="Memesialbl" runat="server" ForeColor="Black"></asp:Label>
                <asp:Label ID="Tellbl" runat="server" ForeColor="Black"></asp:Label>
                <asp:Label ID="Amzalbl" runat="server" ForeColor="Black"></asp:Label>
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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" onrowdatabound="GridView1_RowDataBound" 
                onrowcommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Id_pagesa" HeaderText="Nr_fat" 
                        SortExpression="Id_pagesa" />
                    <asp:BoundField DataField="Data" DataFormatString="{0:dd/MM/yyyy}" 
                        HeaderText="Data" SortExpression="Data" />
                    <asp:BoundField DataField="Totali" HeaderText="Totali" 
                        SortExpression="Totali" />
                    <asp:BoundField DataField="Monedha" HeaderText="Valuta" 
                        SortExpression="Monedha" />
                    <asp:BoundField DataField="tr" HeaderText="Paguar ne" 
                        SortExpression="Vendndodhja" />
                    <asp:BoundField DataField="Nr_kestesh" HeaderText="Nr_keste" 
                        SortExpression="Nr_keste" />
                    <asp:BoundField DataField="Skonto" HeaderText="Ulje %" 
                        SortExpression="Skonto" />
                    <asp:BoundField DataField="Penaliteti" HeaderText="Pen" 
                        SortExpression="Penaliteti" />
                    <asp:BoundField DataField="Koment" HeaderText="Koment" 
                        SortExpression="Koment" />

                    <asp:CommandField ShowSelectButton="True" 
            SelectText="<img src='/Styles/printer.png' border=0 title='This is a Tooltip'>">
        </asp:CommandField>
                    
                  <%--  <asp:CommandField SelectText="~/Styles/printer.png" ShowSelectButton="True" />--%>
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
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
                <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Black" 
                    Text="Totali i Mbetur : "></asp:Label>
                <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
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
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Printo" 
                BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30px" 
                Width="100px" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
