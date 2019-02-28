<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Skonto.aspx.cs" Inherits="financa_shkolla.Account.Skonto1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                    Font-Names="Copperplate Gothic Light" Font-Overline="False" Font-Size="Large" 
                    Font-Underline="True" ForeColor="#006699" Text="Uljet sipas klasave"></asp:Label>
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
    <asp:Label ID="Label17" runat="server" Text="Viti shkollor" ForeColor="#006699"></asp:Label>
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
    <asp:Label ID="Label20" runat="server" Text="Klasa" ForeColor="#006699"></asp:Label>
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
                    DataKeyNames="Id_nxenesi" onrowdeleting="GridView1_RowDeleting" 
                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                    BorderWidth="1px">
                    <Columns>
                        <asp:BoundField DataField="Emri" HeaderText="Emri" SortExpression="Emri" />
                        <asp:BoundField DataField="Mbiemri" HeaderText="Mbiemri" 
                            SortExpression="Mbiemri" />
                        <asp:BoundField DataField="Ulje_1" HeaderText="B1" SortExpression="Ulje_1" />
                        <asp:BoundField DataField="Ulje_2" HeaderText="B2" SortExpression="Ulje_2" />
                        <asp:BoundField DataField="Ulje_3" HeaderText="B3" SortExpression="Ulje_3" />
                        <asp:BoundField DataField="Ulje_4" HeaderText="B4" SortExpression="Ulje_4" />
                        <asp:BoundField DataField="Ulje_5" HeaderText="B5" SortExpression="Ulje_5" />
                        <asp:BoundField DataField="Ulje_6" HeaderText="B6" SortExpression="Ulje_6" />
                        <asp:BoundField DataField="Ulje_7" HeaderText="B7" SortExpression="Ulje_7" />
                        <asp:BoundField DataField="Ulje_8" HeaderText="B8" SortExpression="Ulje_8" />
                        <asp:BoundField DataField="Ulje_9" HeaderText="B9" SortExpression="Ulje_9" />
                        <asp:BoundField DataField="Ulje_10" HeaderText="B10" SortExpression="Ulje_10" />
                        <asp:BoundField DataField="Ulje_11" HeaderText="U1" SortExpression="Ulje_11" />
                        <asp:BoundField DataField="Ulje_12" HeaderText="U2" SortExpression="Ulje_12" />
                        <asp:BoundField DataField="Id_nxenesi" HeaderText="Id_nxenesi" 
                            SortExpression="Id_nxenesi" Visible="False" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                    CommandName="Delete" ImageUrl="~/Styles/delete_button.gif" 
                                    onclientclick="return confirm('Ketij nxenesi do ti fshihen kestet, jeni te sigurte ?')" 
                                    Text="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
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
    </table>
</asp:Content>
