Public Class FormClassEmployee

    ' Binding in the form load event 
    Private Sub Form1_Load(. . .) Handles MyBase.Load
        Oracle.LogInAtRunTime()

        txtHrsPerWk.DataBindings.Add("Text", Oracle.hotelTable, "Address")
        txtSalaryScale.DataBindings.Add("Text", Oracle.hotelTable, "Name")
        txtPayType.DataBindings.Add("Text", Oracle.hotelTable, "Hotel_No")

        txtPosPermTemp.DataBindings.Add("Text", Oracle.bookingTable, "Hotel_No")
        txtCurrSalary.DataBindings.Add("Text", Oracle.bookingTable, "Guest_No")
        DatePickerDOB.DataBindings.Add("Text", Oracle.bookingTable, "Date_From")

    End Sub

    Private Sub btnQualNext_Click(sender As Object, e As EventArgs) Handles btnQualNext.Click

    End Sub

    Private Sub btnQualPrev_Click(sender As Object, e As EventArgs) Handles btnQualPrev.Click

    End Sub
End Class