Public Class FormClassLogin
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Oracle.UserName = txtboxUsername.Text
        Oracle.PassWord = txtboxPassword.Text
        Oracle.Server = txtboxHost.Text

        Oracle.Result = Oracle.ResponseType.OK

        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Oracle.Result = Oracle.ResponseType.Cancel

        Me.Close()
    End Sub

    Private Sub FormClassLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
