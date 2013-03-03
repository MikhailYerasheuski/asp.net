using System;
using System.Web;
using System.Web.UI;
using System.Security.Cryptography;
using System.Globalization;


public partial class Default : Page
{

		
	protected override void OnLoad(EventArgs e) {
		// Some default values are set here
			
		// Pay within the hour
		if(sessionValidity.Text.Trim() == "") sessionValidity.Text = 
				DateTime.Now.AddHours(1).ToUniversalTime().ToString("s", DateTimeFormatInfo.InvariantInfo) + "Z";
		// Ship in 5 days
		if(shipBeforeDate.Text.Trim() == "") shipBeforeDate.Text = 
				DateTime.Now.AddDays(5).ToUniversalTime().ToString("yyyy-MM-dd");
					
		if(shopperLocale.Text.Trim() == "") shopperLocale.Text = "en_GB";
		if(merchantAccount.Text.Trim() == "") merchantAccount.Text = "YourMerchantAccount";
		if(paymentAmount.Text.Trim() == "") paymentAmount.Text = "1230";
		if(currencyCode.Text.Trim() == "") currencyCode.Text = "EUR";
		if(skinCode.Text.Trim() == "") skinCode.Text = "aFa33qPs";
		if(shopperEmail.Text.Trim() == "") shopperEmail.Text = "shopper@some.domain.com";
		if(merchantReference.Text.Trim() == "") merchantReference.Text = "My Reference 12341234";
	}

	public virtual void onButtonClick(object sender, EventArgs e) {
			
		// The HMAC secret as configured in the skin
		string hmacSecret = "TheHM4C$ecretF0rTheSk1n";

		// Generate the signing string
		string signingString =  paymentAmount.Text + currencyCode.Text + shipBeforeDate.Text 
								+ merchantReference.Text + skinCode.Text + merchantAccount.Text 
								+ sessionValidity.Text + shopperEmail.Text;
			
		// Values are always transferred using UTF-8 encoding
		System.Text.UTF8Encoding encoding=new System.Text.UTF8Encoding();
			
		// Calculate the HMAC
	    HMACSHA1 myhmacsha1 = new HMACSHA1(encoding.GetBytes(hmacSecret));
	    merchantSig.Text = System.Convert.ToBase64String(myhmacsha1.ComputeHash(encoding.GetBytes(signingString)));
		myhmacsha1.Clear();
			
		// Ready to pay
		button1.Text = "Pay";
	}
}

