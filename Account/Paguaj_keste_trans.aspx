﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Paguaj_keste_trans.aspx.cs" Inherits="financa_shkolla.Account.Paguaj_keste_trans" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
        .style2
        {
            width: 713px;
        }
        .style3
        {
            height: 21px;
            width: 713px;
        }
    </style>

  </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%; height: 294px;">
        <tr>
            <td class="style2">
                <asp:Label ID="Label11" runat="server" Font-Bold="True" 
                    Font-Names="Copperplate Gothic Light" Font-Overline="False" Font-Size="Large" 
                    Font-Underline="True" ForeColor="#006699" 
                    Text="Pagesa e kesteve te  transportit"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" style="color: #003366">
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
                    ondatabound="Nxenesiddl_DataBound" style="height: 22px">
                </asp:DropDownList>
                <asp:Label ID="kestelbl" runat="server"></asp:Label>
                <asp:Button ID="Button2" runat="server" Text="Krijo keste" Visible="False" 
                    onclick="Button2_Click" BackColor="#006699" Font-Bold="True" 
                    ForeColor="White" Height="30px" Width="100px" />
                </td>
            <td class="style1">
            </td>
            <td class="style1">
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Atesialbl" runat="server" ForeColor="Black"></asp:Label>
                &nbsp;&nbsp;
                <asp:Label ID="Memesialbl" runat="server" ForeColor="Black"></asp:Label>
                &nbsp;&nbsp;
                <asp:Label ID="Tellbl" runat="server" ForeColor="Black"></asp:Label>
                &nbsp;&nbsp;
                <asp:Label ID="Amzalbl" runat="server" ForeColor="Black"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" onrowdatabound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="Nr_kesti" HeaderText="Nr" 
                            SortExpression="Nr_kesti" />
                        <asp:BoundField DataField="Vlera" HeaderText="Vlera" SortExpression="Vlera" />
                        <asp:TemplateField SortExpression="Paguar">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="CheckBox1_CheckedChanged" 
                                    Checked='<%# Convert.ToBoolean(Eval("Paguar")) %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Aktiv" HeaderText="Flag" SortExpression="Aktiv">
                        </asp:BoundField>
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

<SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

<SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>

<SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

<SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
                </asp:GridView>
            </td>
            <td>
                <table style="width:100%;">
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
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="VLERA : " Font-Bold="True" 
                    ForeColor="#006699"></asp:Label>
                <asp:Label ID="kestetotlbl" runat="server" Font-Bold="True" ForeColor="#006699"></asp:Label>
                <asp:Label ID="valutalbl" runat="server" Font-Bold="True" ForeColor="#006699"></asp:Label>
        </td>
        </tr>
          
        <tr>
            <td class="style2">
                &nbsp;</td>
        </tr>
          
        <tr>
            <td class="style2">
                <asp:Label ID="Label7" runat="server" Text="Ulje : " ForeColor="#006600"></asp:Label>
                <asp:Label ID="skontolbl" runat="server" Text="0" ForeColor="#006600"></asp:Label>
                <asp:Label ID="Label9" runat="server" Text="%" ForeColor="#006600"></asp:Label>
                <asp:TextBox ID="datepicker" runat="server" Width="32px" 
                    ontextchanged="datepicker_TextChanged" AutoPostBack="True" 
                    ForeColor="#006600"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="datepicker" ErrorMessage="*" 
                    ValidationExpression="^[+]?[0-9]\d{0,5}(\.\d{1,4})?%?$" 
                    ForeColor="#CC0000"></asp:RegularExpressionValidator>
                <asp:Label ID="Label8" runat="server" Text="Kamate : " ForeColor="#CC0000"></asp:Label>
                <asp:Label ID="penlbl" runat="server" Text="0" ForeColor="#CC0000"></asp:Label>
                <asp:Label ID="Label5" runat="server" Text="%" ForeColor="#CC0000"></asp:Label>
                <asp:TextBox ID="datepicker1" runat="server" Width="32px" AutoPostBack="True" 
                    ontextchanged="datepicker1_TextChanged" ForeColor="Red"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="datepicker1" ErrorMessage="*" 
                    ValidationExpression="^[+]?[0-9]\d{0,5}(\.\d{1,4})?%?$" 
                    ForeColor="#CC0000"></asp:RegularExpressionValidator>
            </td>
        </tr>
          
        <tr>
            <td class="style2">
                &nbsp;</td>
        </tr>
          
        <tr>
            <td class="style3">
                <asp:Label ID="Label4" runat="server" Text="Koment" ForeColor="Black"></asp:Label>
                <asp:TextBox ID="datepicker0" runat="server" Width="195px"></asp:TextBox>
        </td>
        </tr>
          
        <tr>
            <td class="style3">
                &nbsp;</td>
        </tr>
          
        <tr>
            <td class="style2">
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                    <asp:ListItem>EUR</asp:ListItem>
                    <asp:ListItem>LEK</asp:ListItem>
                    <asp:ListItem>USD</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label10" runat="server" Text="Kursi : " ForeColor="#000099"></asp:Label>
                <asp:Label ID="Kursilbl" runat="server" Text="1" ForeColor="#000099"></asp:Label>
                <asp:TextBox ID="kursi" runat="server" Width="32px" 
                    ontextchanged="kursi_TextChanged" AutoPostBack="True" ForeColor="#000099"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="kursi" ErrorMessage="*" 
                    ValidationExpression="^[+]?[0-9]\d{0,5}(\.\d{1,4})?%?$" 
                    ForeColor="#CC0000"></asp:RegularExpressionValidator>
        </td>
        </tr>
          
        <tr>
            <td class="style2">
                &nbsp;</td>
        </tr>
          
        <tr>
            <td class="style2">
                <asp:Label ID="Label6" runat="server" Text="TOTALI :  " Font-Bold="True" 
                    ForeColor="#006699"></asp:Label>
                <asp:Label ID="totalilbl" runat="server" Font-Bold="True" ForeColor="#006699"></asp:Label>
                <asp:Label ID="valutalbl0" runat="server" Font-Bold="True" ForeColor="#006699"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Cash</asp:ListItem>
                    <asp:ListItem>BKT</asp:ListItem>
                    <asp:ListItem>Pro credit</asp:ListItem>
                </asp:DropDownList>
        </td>
        </tr>
          
        <tr>
            <td class="style2">
                &nbsp;</td>
        </tr>
          
        <tr>
            <td class="style2">
                <asp:Button ID="Button1" runat="server" Text="Paguaj" Width="100px" 
                    onclick="Button1_Click" UseSubmitBehavior="False" Visible="False" 
                    BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30px" />
            </td>
        </tr>
          
        <tr>
            <td class="style2">
                &nbsp;</td>
        </tr>
          
             </table>

        
                    
</asp:Content>

