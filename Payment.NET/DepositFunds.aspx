<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DepositFunds.aspx.vb"
    Inherits="XXXX.DepositFunds" Title="Deposit Funds" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Deposit Funds</title>

    <script type="text/javascript">
	function validateDepositAmount(sender, args){
        //Trim the input.
        var reg = /^\s*(\S+(\s+\S+)*)\s*$/
        var matches = args.Value.match(reg);
        args.Value = (matches == null) ? "" : matches[1];
        
        //Check the string has length.
        if(args.Value.length > 0){
            //Test for correct decimal format.
            reg = /^(\d+)(\.\d{2})$/
            matches = args.Value.match(reg);
            //Return the validity of the validation.
            if(matches != null && args.Value == matches[0]){
                document.forms[0].paymentAmount.value = args.Value.replace(".","");
                args.IsValid = true;
            }else{
                args.IsValid = false;
            }
        }else{
            args.IsValid = false;
        } 
        return;      
    }
	function replaceAction() {
		if(document.forms[0].merchantSig.value != "") {
		    document.forms[0].method = "post";
		    document.forms[0].action='<%=System.Configuration.ConfigurationManager.AppSettings.Item("FormAction")%>';
		    //document.forms[0].submit();
		}
	}
	window.onload = replaceAction;	
	</script>

</head>
<body>
    <form id="paymentForm" runat="server">
        <div>
            <table>
                <tr>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Amount to deposit :</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="decPaymentAmount" runat="server" MaxLength="10" TabIndex="4" ToolTip="Please enter the amount you wish to deposit (GBP)"
                            ValidationGroup="vgDeposit">
                        </asp:TextBox></td>
                    <td>
                        <asp:CustomValidator ID="cvPaymentAmount" runat="server" ClientValidationFunction="validateDepositAmount"
                            ControlToValidate="decPaymentAmount" Display="Dynamic" ErrorMessage="Please enter an amount £0.00 (GBP)."
                            ValidateEmptyText="true" TabIndex="-1" ToolTip="Please enter an amount £0.00 (GBP)."
                            ValidationGroup="vgDeposit">Please enter an amount £0.00 (GBP).</asp:CustomValidator></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                        <asp:Button ID="uxSubmit" runat="server" TabIndex="5" Text="Submit" ValidationGroup="vgDeposit"
                            UseSubmitBehavior="False" /></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
                </tr>
            </table>
            <asp:HiddenField ID="merchantSig" runat="server" />
            <asp:HiddenField ID="merchantReference" runat="server" />
            <asp:HiddenField ID="paymentAmount" runat="server" />
            <asp:HiddenField ID="currencyCode" runat="server" />
            <asp:HiddenField ID="shipBeforeDate" runat="server" />
            <asp:HiddenField ID="merchantAccount" runat="server" />
            <asp:HiddenField ID="shopperLocale" runat="server" />
            <asp:HiddenField ID="sessionValidity" runat="server" />
            <asp:HiddenField ID="countryCode" runat="server" />
            <asp:HiddenField ID="skinCode" runat="server" />
        </div>
    </form>
</body>
</html>
