<%@ Page Language="C#" src="Default.aspx.cs" Inherits="Projects.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head>
  <title>Default</title>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

	<script type="text/javascript">
	function replaceAction() {
		// if merchantSig has a value, we are ready to pay
		if(document.forms[0].merchantSig.value != "") {
			document.forms[0].action="http://localhost:8080/hpp/select.shtml";
			document.getElementById("startagain").style.display = "inline"; 
		}
	}
	window.onload = replaceAction;
	</script>
</head>
<body>
    <h1>Test ASP.NET Page</h1>
    
	<form id="form1" runat="server">
	<table>
		<tr>
			<td>Signature</td>
			<td><asp:TextBox Size="80" id="merchantSig" runat="server"/>  (generated when you press "Submit") </td>
		</tr>		
		<tr>
			<td>Session Valid Till</td>
			<td><asp:TextBox Size="50" id="sessionValidity" runat="server"/></td>
		</tr>
		<tr>
			<td>Ship Before Date</td>
			<td><asp:TextBox Size="50" id="shipBeforeDate" runat="server"/></td>
		</tr>
		<tr>
			<td>Shopper's Locale</td>
			<td><asp:TextBox Size="9" id="shopperLocale" runat="server"/> (e.g. nl, en_GB, de....)</td>
		</tr>
		<tr>
			<td>Merchant Account</td>
			<td><asp:TextBox Size="30" id="merchantAccount" runat="server"/></td>
		</tr>
		<tr>
			<td>Payment Amount</td>
			<td><asp:TextBox Size="10" id="paymentAmount" runat="server"/></td>
		</tr>
		<tr>
			<td>Currency Code</td>
			<td><asp:TextBox Size="4" id="currencyCode" runat="server"/></td>
		</tr>
		<tr>
			<td>Skin Code</td>
			<td><asp:TextBox Size="10" id="skinCode" runat="server"/></td>
		</tr>
		<tr>
			<td>Merchant Reference</td>
			<td><asp:TextBox Size="40" id="merchantReference" runat="server"/></td>
		</tr>
		<tr>
			<td>Shopper Email Address</td>
			<td><asp:TextBox Size="40" id="shopperEmail" runat="server"/></td>
		</tr>
		<tr>
			<td colspan="2" style="text-align: right">
			<span id="startagain" style="display: none">[<a href=""> Reset </a>]</span>
			<asp:Button id="button1" Text="Submit" runat="server" OnClick="onButtonClick"/>
			</td>
		</tr>
	</form>
	
</body>
</html>
