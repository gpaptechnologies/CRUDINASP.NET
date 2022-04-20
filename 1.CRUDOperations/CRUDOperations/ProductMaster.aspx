<%@ Page Title="Product Master" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductMaster.aspx.cs" Inherits="CRUDOperations.ProductMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hfProductID" runat="server" />
    <div>
        <asp:Table ID="tblProducts" runat="server" BorderColor="Black" BorderWidth="1" BorderStyle="Solid" HorizontalAlign="Center">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell ColumnSpan="2">
                    <b>Product Master</b><hr />
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Product Code</b><span style="color:red">*</span>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtProductCode" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtProductCode" runat="server" ControlToValidate="txtProductCode" Display="Dynamic"
                        ErrorMessage="Enter Product Code" SetFocusOnError="true" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Product Name</b><span style="color:red">*</span>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtProductName" runat="server" ControlToValidate="txtProductName" Display="Dynamic"
                        ErrorMessage="Enter Product Name" SetFocusOnError="true" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Product Qty</b><span style="color:red">*</span>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtQty" runat="server" ControlToValidate="txtQty" Display="Dynamic"
                        ErrorMessage="Enter Product Qty" SetFocusOnError="true" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Product Price</b><span style="color:red">*</span>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtPrice" runat="server" ControlToValidate="txtPrice" Display="Dynamic"
                        ErrorMessage="Enter Product Price" SetFocusOnError="true" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Remarks</b><span style="color:red">*</span>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <hr />
                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Submit" OnClick="btnSave_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />&nbsp;&nbsp;
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableFooterRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblSuccessMessage" runat="server" style="color:green"></asp:Label><br />
                    <asp:Label ID="lblErrorMessage" runat="server" style="color:red"></asp:Label>
                </asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
        <br />
        <asp:GridView ID="gvProducts" runat="server" HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="false" DataKeyNames="ProductID" ShowHeaderWhenEmpty="true" OnRowEditing="gvProducts_RowEditing">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            <Columns>
                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" CommandName="Edit" ToolTip="Edit" ImageUrl="~/Images/Edit.png" Height="16px" Width="16px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Code" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblProductCode" runat="server" Text='<%# Bind("ProductCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Name" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblQty" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblRemakrs" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
