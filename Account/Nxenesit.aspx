<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Nxenesit.aspx.cs" Inherits="financa_shkolla.Account.Nxenesit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 1417px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; height: 38px;">
        <tr>
            <td class="style1">
                <asp:Label ID="Label112" runat="server" Font-Bold="True" 
                    Font-Names="Copperplate Gothic Light" Font-Overline="False" Font-Size="Large" 
                    Font-Underline="True" ForeColor="#006699" Text="Konfigurimi i nxenesve"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
    <asp:Label ID="Label17" runat="server" Text="Viti shkollor" ForeColor="#006699"></asp:Label>
    <asp:DropDownList ID="vitiddl0" runat="server">
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
<asp:DropDownList ID="DropDownList1" runat="server">
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
<asp:DropDownList ID="DropDownList2" runat="server">
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
                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Shfaq" 
                    BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30px" 
                    Width="100px" />
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
                DataKeyNames="Id_nxenesi" onrowcancelingedit="GridView1_RowCancelingEdit" 
                onrowcommand="GridView1_RowCommand" onrowdeleting="GridView1_RowDeleting" 
                onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                ShowFooter="True" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" 
                BorderStyle="None" BorderWidth="1px">
                <Columns>
                    <asp:TemplateField HeaderText="ID" SortExpression="Id_nxenesi" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id_nxenesi") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id_nxenesi") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Emri" SortExpression="Emri">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" BackColor="#4B6C9E" ForeColor="White" 
                                Text='<%# Bind("Emri") %>' Height="19px" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TextBox5" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Emri") %>' 
                                Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                ControlToValidate="TextBox5" ErrorMessage="*" ForeColor="Red" 
                                ValidationGroup="Insert"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Emri") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mbiemri" SortExpression="Mbiemri">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" BackColor="#4B6C9E" ForeColor="White" 
                                Text='<%# Bind("Mbiemri") %>' Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TextBox6" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Mbiemri") %>' 
                                Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                ControlToValidate="TextBox6" ErrorMessage="*" ForeColor="Red" 
                                ValidationGroup="Insert"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Mbiemri") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Atesia" SortExpression="Atesia">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" BackColor="#4B6C9E" ForeColor="White" 
                                Text='<%# Bind("Atesia") %>' Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="TextBox7" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Atesia") %>' 
                                Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                ControlToValidate="TextBox7" ErrorMessage="*" ForeColor="Red" 
                                ValidationGroup="Insert"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Atesia") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Memesia" SortExpression="Memesia">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" BackColor="#4B6C9E" ForeColor="White" 
                                Text='<%# Bind("Memesia") %>' Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="TextBox8" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Memesia") %>' 
                                Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                ControlToValidate="TextBox8" ErrorMessage="*" ForeColor="Red" 
                                ValidationGroup="Insert"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Memesia") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ditelindja" SortExpression="Ditelindja">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox33" runat="server" BackColor="#4B6C9E" 
                                ForeColor="White" Text='<%# Bind("Ditelindja") %>' Width="70px"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox33" runat="server" Text='<%# Bind("Ditelindja") %>' 
                                Width="70px"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label111" runat="server" Text='<%# Bind("Ditelindja") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefon" SortExpression="Nr_tel">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" BackColor="#4B6C9E" ForeColor="White" 
                                Text='<%# Bind("Nr_tel") %>' Width="50px"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Nr_tel") %>' 
                                Width="50px"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("Nr_tel") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Viti Shkollor" SortExpression="Viti_shkollor">
                        <EditItemTemplate>
                            <asp:DropDownList ID="vitiddl" runat="server" BackColor="#4B6C9E" 
                                ForeColor="White">
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="vitiddl" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="vitiddl" runat="server">
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                ControlToValidate="vitiddl" ErrorMessage="*" ForeColor="Red" 
                                ValidationGroup="Insert"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("Viti_shkollor") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amza" SortExpression="Nr_amza">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" BackColor="#4B6C9E" ForeColor="White" 
                                Text='<%# Bind("Nr_amza") %>' Width="30px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Nr_amza") %>' 
                                Width="30px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="Red" 
                                ValidationGroup="Insert"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Nr_amza") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Klasa" SortExpression="Klasa">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList11" runat="server" BackColor="#4B6C9E" 
                                ForeColor="White">
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                ControlToValidate="DropDownList11" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="DropDownList11" runat="server">
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                ControlToValidate="DropDownList11" ErrorMessage="*" ForeColor="Red" 
                                ValidationGroup="Insert"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Klasa") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Indeksi" SortExpression="Indeksi">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList22" runat="server" BackColor="#4B6C9E" 
                                ForeColor="White">
                                <asp:ListItem>A</asp:ListItem>
                                <asp:ListItem>B</asp:ListItem>
                                <asp:ListItem>C</asp:ListItem>
                                <asp:ListItem>D</asp:ListItem>
                                <asp:ListItem>E</asp:ListItem>
                                <asp:ListItem>F</asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ControlToValidate="DropDownList22" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="DropDownList22" runat="server">
                                <asp:ListItem>A</asp:ListItem>
                                <asp:ListItem>B</asp:ListItem>
                                <asp:ListItem>C</asp:ListItem>
                                <asp:ListItem>D</asp:ListItem>
                                <asp:ListItem>E</asp:ListItem>
                                <asp:ListItem>F</asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                                ControlToValidate="DropDownList22" ErrorMessage="*" ForeColor="Red" 
                                ValidationGroup="Insert"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Indeksi") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                CommandName="Update" ImageUrl="~/Styles/15px-Yes_check.svg.png" Text="" />
                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" 
                                CommandName="Cancel" ImageUrl="~/Styles/incorrect.png" Text="" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" 
                                CommandName="Insert" ImageAlign="Middle" ImageUrl="~/Styles/Icone_Plus.png" 
                                Text="" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                CommandName="Edit" ImageUrl="~/Styles/edit.png" Text="" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" 
                                CommandName="Delete" ImageUrl="~/Styles/delete_button.gif" Text="" 
                                onclientclick=" return confirm('Ta Fshi ?')" />
                        </ItemTemplate>
                    </asp:TemplateField>
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
            <asp:Label ID="Label11" runat="server" Text="Emri" Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="Emritxt" runat="server" Visible="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                ControlToValidate="Emritxt" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label12" runat="server" Text="Mbiemri" Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="Mbiemritxt" runat="server" Visible="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                ControlToValidate="Mbiemritxt" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label18" runat="server" Text="Atesia" Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="Atesiatxt" runat="server" Visible="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                ControlToValidate="Atesiatxt" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label14" runat="server" Text="Memsia" Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="Memesiatxt" runat="server" Visible="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                ControlToValidate="Memesiatxt" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label15" runat="server" Text="Ditelindja" Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="Ditelindjatxt" runat="server" Visible="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" 
                ControlToValidate="Ditelindjatxt" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label16" runat="server" Text="Telefon" Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="Teltxt" runat="server" Visible="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" 
                ControlToValidate="Teltxt" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label19" runat="server" Text="Amza" Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="Amzatxt" runat="server" Visible="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                ControlToValidate="Amzatxt" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Shto" 
                Visible="False" BackColor="#006699" ForeColor="White" Height="30px" 
                Width="100px" />
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
