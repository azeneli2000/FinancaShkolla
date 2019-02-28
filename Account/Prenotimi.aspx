<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prenotimi.aspx.cs" Inherits="financa_shkolla.Account.Prenotimi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 1417px;
    }
        .style2
        {
            width: 1417px;
            height: 24px;
        }
        .style3
        {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; height: 38px;">
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                    Font-Names="Copperplate Gothic Light" Font-Overline="False" Font-Size="Large" 
                    Font-Underline="True" ForeColor="#006699" Text="Pagesa e prenotimit"></asp:Label>
            </td>
            <td class="style3">
                </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
    <asp:Label ID="Label17" runat="server" Text="Viti shkollor" ForeColor="#006699"></asp:Label>
    <asp:DropDownList ID="vitiddl0" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="vitiddl0_SelectedIndexChanged">
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" 
                    ControlToValidate="vitiddl0" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
    <asp:Label ID="Label20" runat="server" Text="Klasa" ForeColor="#006699"></asp:Label>
<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" 
                    ControlToValidate="DropDownList1" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList2_SelectedIndexChanged">
    <asp:ListItem></asp:ListItem>
    <asp:ListItem>A</asp:ListItem>
    <asp:ListItem>B</asp:ListItem>
    <asp:ListItem>C</asp:ListItem>
    <asp:ListItem>D</asp:ListItem>
    <asp:ListItem>E</asp:ListItem>
    <asp:ListItem>F</asp:ListItem>
    <asp:ListItem></asp:ListItem>
</asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" 
                    ControlToValidate="DropDownList2" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
<br />
<table style="width:100%;">
    <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="Id_nxenesi" 
                onrowcommand="GridView1_RowCommand" 
                ShowFooter="True" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" 
                BorderStyle="None" BorderWidth="1px" 
                onrowdatabound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Emri" SortExpression="Emri">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Emri") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mbiemri" SortExpression="Mbiemri">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Mbiemri") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="Paguar">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Paguar") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                                Checked='<%# Convert.ToBoolean(Eval("Paguar")) %>'
                                 OnClientClick="return confirm('Are you sure you want to delete?')"                                
                                oncheckedchanged="CheckBox1_CheckedChanged1" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Id_nxenesi" HeaderText="ID" 
                        SortExpression="Id_nxenesi" />
                </Columns>
                <EmptyDataTemplate>
                    Ska te dhena
                </EmptyDataTemplate>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
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
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
