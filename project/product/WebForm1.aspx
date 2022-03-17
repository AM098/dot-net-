<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="productmanagment.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
<div style="padding:5px;">
<h2>Add Data using SQL Stored Procedure</h2>
<table class="table table-condensed" style="width:500px;">
<tr>
<td>
Product Name:
</td>
<td>
<asp:TextBox runat="server" ID="txtProductName" placeholder="Enter Product Name"
Width="150px"/>
</td>
</tr>
<tr>
<td>
Product Description:
</td>
<td>
<asp:TextBox TextMode="MultiLine" runat="server" ID="txtProductDesc"
Width="150px" placeholder="Enter Product Description"/>
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
<asp:GridView runat="server" ID="proDataGrid" CssClass="table table-condensed" Width="500px"/>
</div>
</form>
</body>
</html>