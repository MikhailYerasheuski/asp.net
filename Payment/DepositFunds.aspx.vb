Partial Public Class DepositFunds
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblError.Visible = False
            If HttpContext.Current.User.Identity.IsAuthenticated Then
                'Some default values are set here
                With System.Configuration.ConfigurationManager.AppSettings
                    sessionValidity.Value = DateTime.Now.AddSeconds(CInt(.Item("SessionValidity"))).ToUniversalTime().ToString("s", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "Z"
                    shipBeforeDate.Value = DateTime.Now.AddSeconds(CInt(.Item("ShipBeforeDateAddition"))).ToUniversalTime().ToString("yyyy-MM-dd")
                    shopperLocale.Value = .Item("ShopperLocale")
                    merchantAccount.Value = .Item("MerchantAccount")
                    currencyCode.Value = .Item("CurrencyCode")
                    skinCode.Value = .Item("SkinCode")
                    merchantReference.Value = .Item("MerchantReference")
                    countryCode.Value = .Item("CountryCode")
                    'shopperEmail.Value = HttpContext.Current.User.Identity.Name.ToString
                End With
            Else
                lblError.Visible = True
                lblError.Text = "An error occurred loading the page. Please refresh, and try again."
            End If
        End If
    End Sub

    Protected Sub uxSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxSubmit.Click
        If HttpContext.Current.User.Identity.IsAuthenticated Then
            If Page.IsValid Then

                Try
                    Int32.Parse(paymentAmount.Value)
                Catch ex As Exception
                    cvPaymentAmount.IsValid = False
                    Exit Sub
                End Try

                If paymentAmount.Value.Length > 0 AndAlso paymentAmount.Value.Length < 11 AndAlso Convert.ToInt32(paymentAmount.Value) > 0 Then
                    If HttpContext.Current.User.Identity.IsAuthenticated Then
                        'The HMAC secret as configured in the skin
                        Dim hmacSecret As String = System.Configuration.ConfigurationManager.AppSettings.Item("HMACSecret")

                        'Generate the signing string
                        Dim signingString As String = paymentAmount.Value + currencyCode.Value + shipBeforeDate.Value _
                                                     + merchantReference.Value + skinCode.Value + merchantAccount.Value _
                                                     + sessionValidity.Value

                        'Values are always transferred using UTF-8 encoding
                        Dim encoding As System.Text.UTF8Encoding = New System.Text.UTF8Encoding()

                        'Calculate the HMAC
                        Dim myhmacsha1 As System.Security.Cryptography.HMACSHA1 = New System.Security.Cryptography.HMACSHA1(encoding.GetBytes(hmacSecret))
                        merchantSig.Value = System.Convert.ToBase64String(myhmacsha1.ComputeHash(encoding.GetBytes(signingString)))
                        myhmacsha1.Clear()
                    Else
                        lblError.Visible = True
                        lblError.Text = "An error occurred loading the page. Please refresh, and try again."
                    End If
                Else
                    cvPaymentAmount.IsValid = False
                End If
            End If
        End If
    End Sub
End Class