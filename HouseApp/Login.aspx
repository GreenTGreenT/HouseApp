<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HouseApp.Login" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>
<style>
table, th, td {
  border: 1px solid black;
  border-collapse: collapse;
}
th, td {
  padding: 5px;
  text-align: left;    
}
    .auto-style3 {
        width: 243px;
    }
    .auto-style4 {
        height: 52px;
    }
    .auto-style5 {
        width: 243px;
        height: 52px;
    }
</style>
</head>
<body>

<h2>Login</h2>
<form  runat="server" >
<div>
<table style="width:30%">
  <tr>
      <td>
          <asp:Label ID="Label1" runat="server" text="Username"></asp:Label>
      </td>
      <td class="auto-style3">
          <asp:TextBox ID="user_name" runat="server"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td>
          <asp:Label ID="Lable2" runat="server" text="Password"></asp:Label>
      </td> 
    <td class="auto-style3">
        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
    </td>
  </tr>  
  <tr>    
        <td></td>
        <td class="auto-style3">
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"></asp:Button>
        </td>
  </tr>
  <tr>    
        <td class="auto-style4"></td>
        <td class="auto-style5">
            <asp:Label ID="ErrorMassage" runat="server" Text="Incorrcet user credentials" ForeColor="Red"></asp:Label>
        </td>
  </tr>
</table>
</div>
</form>
</body>
</html>
