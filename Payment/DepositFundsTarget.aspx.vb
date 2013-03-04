Partial Public Class DepositFundsTarget
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer
        For i = 0 To Request.Form.Count - 1
            label1.Text += "<BR>" & Request.Form.AllKeys(i)
            label1.Text += "<BR>" & Request.Form(i)
            label1.Text += "<BR>"
        Next
    End Sub

End Class