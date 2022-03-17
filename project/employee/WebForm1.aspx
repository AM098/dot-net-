<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="employee_table.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
<div style="padding:5px;">
<h2>Add  Employee Data using SQL DB Procedure</h2>
<table class="table table-condensed" style="width:500px;">
<tr>
<td>
Employee Name:
</td>
<td>
    <asp:TextBox ID="txtempName" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Employee Designation:
</td>
<td>
    <asp:TextBox ID="txtempdes" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="2" align="left">
    <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
</td>
</tr>
</table>
<asp:Label runat="server" ID="lblInfo" />

<br /><br />
 <asp:GridView ID="prodatagrid" runat="server" CssClass="table table-condensed" Width="500px"/>
</div>
</form>
</body>
</html>
