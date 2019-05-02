Public Class FormClassLogin

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Oracle.UserName = TextBox1.Text
        Oracle.PassWord = TextBox2.Text
        Oracle.Server = TextBox3.Text

        Oracle.Result = Oracle.ResponseType.OK

        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Oracle.Result = Oracle.ResponseType.Cancel

        Me.Close()
    End Sub
End Class