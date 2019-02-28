<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="aaa.aspx.cs" Inherits="financa_shkolla.Account.p1.aaa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                        Font-Names="Copperplate Gothic Light" Font-Overline="False" Font-Size="Large" 
                        Font-Underline="True" ForeColor="Red" Text="Anullimi i faturave"></asp:Label>
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
                    <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged" 
                        Width="50px"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Shkolla</asp:ListItem>
                        <asp:ListItem>Transporti</asp:ListItem>
                        <asp:ListItem>Prenotim</asp:ListItem>
                        <asp:ListItem>Pag ekstra</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Kerko" 
                        BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30px" 
                        Width="100px" />
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
                        CellPadding="3">
                        <Columns>
                            <asp:BoundField DataField="Id_pagesa" HeaderText="Nr_Pag" 
                                SortExpression="Id_pagesa" />
                            <asp:BoundField DataField="Data" HeaderText="Data" SortExpression="Data" />
                            <asp:BoundField DataField="Totali" HeaderText="Vlera" SortExpression="Totali" />
                            <asp:BoundField DataField="Monedha" HeaderText="Valuta" 
                                SortExpression="Monedha" />
                            <asp:BoundField DataField="Nr_kestesh" HeaderText="Nr_keste" 
                                SortExpression="Nr_kestesh" />
                            <asp:BoundField DataField="Skonto" HeaderText="Ulje" SortExpression="Skonto" />
                            <asp:BoundField DataField="Penaliteti" HeaderText="Kamate" 
                                SortExpression="Penaliteti" />
                            <asp:BoundField DataField="Koment" HeaderText="Koment" 
                                SortExpression="Koment" />
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
                    <asp:Label ID="Label2" runat="server" Text="Koment per anullimin"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="194px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Anullo" 
                        UseSubmitBehavior="False" Width="100px" BackColor="#006699" 
                        Font-Bold="True" ForeColor="White" Height="30px" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </p>
</asp:Content>
