<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="client.aspx.cs" 
    Inherits="Sarah10415WebApp.demo.client"
    EnableEventValidation="false" ValidateRequest="false"
    %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    

    <br />

    <div>

         <table class="nav-justified">
        <tr>
            <td colspan="2">
                <asp:Label ID="LblOutput" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 168px; font-weight: bold">client ID</td>
            <td>
                <asp:TextBox ID="txtClientId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 168px; font-weight: bold">First Name</td>
            <td>
                <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 168px; font-weight: bold">Last Name</td>
            <td>
                <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 168px; font-weight: bold">Email</td>
            <td>
                <asp:TextBox ID="txtEmeil" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 168px; font-weight: bold">Active</td>
            <td>
                <asp:CheckBox ID="cbActive" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 168px; font-weight: bold">City</td>
            <td>
                <asp:DropDownList ID="ddlCity" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 168px; font-weight: bold">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 168px; height: 20px">&nbsp;</td>
            <td style="height: 20px">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                    OnClientClick="return confirm('Are you Sure  you want to Delete ?')" />

                <asp:Button ID="btnGetClientInfo" runat="server" Text="GetClientInfo" OnClick="btnGetClientInfo_Click" />
                <asp:Button ID="btnExportToExcel" runat="server" Text="ExportToExcel" OnClick="btnExportToExcel_Click" />
                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 168px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

    </div>

    <div>
        <asp:GridView ID="gvClientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="clientId">
            <Columns>
                                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="clientId">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkupdate" runat="server"  
                                        CommandArgument='<%# Bind("clientId") %>' OnClick="populateForm_Click"
                                        Text='<%# Eval("clientId")  %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left"></ItemStyle>
                            </asp:TemplateField>

                <asp:BoundField DataField="fName" HeaderText="fName" SortExpression="fName" />
                <asp:BoundField DataField="lName" HeaderText="lName" SortExpression="lName" />
                <asp:BoundField DataField="emeil" HeaderText="emeil" SortExpression="emeil" />
                <asp:BoundField DataField="active" HeaderText="active" ReadOnly="True" SortExpression="active" />
                <asp:BoundField DataField="registrationDate" HeaderText="registrationDate" SortExpression="registrationDate" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
               
            </Columns>
        </asp:GridView>
        
        
    </div>

</asp:Content>
