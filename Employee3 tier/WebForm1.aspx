<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Employee3_tier.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Employee management</h2>
            Enter Employee ID:
            <asp:TextBox ID="txtEmpid" runat="server"></asp:TextBox>
            <br /><br />
            Enter Employee Name:
            <asp:TextBox ID="txtEmpname" runat="server"></asp:TextBox>
            <br /><br />
            Enter Email:
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br /><br />
            Enter salary;
            <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
            <br /><br />
            Country 
            <asp:DropDownList ID="ddlcountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged">
            </asp:DropDownList>
            <br /><br />

            State
            <asp:DropDownList ID="ddlstate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
            </asp:DropDownList>

            <br />

            City
            <asp:DropDownList ID="ddlcity" runat="server">
            </asp:DropDownList>

            <br />
            <br />

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>

            <asp:GridView ID="gridemp" runat="server" AutoGenerateColumns="False"  DataKeyNames="Empid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowDeleting="gridemp_RowDeleting" OnRowUpdating="gridemp_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="Empid">
                        <ItemTemplate>
                            <%# Eval("Empid") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                       <asp:TextBox ID="txtEditEmpid" runat="server" Text='<%# Eval("Empid") %>' ReadOnly="true"></asp:TextBox>
                       </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Empname">
                        <ItemTemplate>
                            <%# Eval("Empname") %>
                        </ItemTemplate>
                        </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <%# Eval("Email") %>
                        </ItemTemplate>
                        </asp:TemplateField>

                    <asp:TemplateField HeaderText="Salary">
                        <ItemTemplate>
                            <%# Eval("Salary") %>
                        </ItemTemplate>
                         <EditItemTemplate>
                         <asp:TextBox ID="txtEditSalary" runat="server" Text='<%# Eval("Salary") %>'></asp:TextBox>
                         </EditItemTemplate>
                        </asp:TemplateField>

                     <asp:TemplateField HeaderText="Country">
                       <ItemTemplate>
                     <%# Eval("cname") %>
                    </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="State">
                    <ItemTemplate>
                    <%# Eval("stname") %>
                  </ItemTemplate>
                  </asp:TemplateField>

                   <asp:TemplateField HeaderText="City">
                     <ItemTemplate>
                       <%# Eval("cityname") %>
                       </ItemTemplate>
                       </asp:TemplateField>

                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
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

            <asp:Label ID="lblmsg" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
