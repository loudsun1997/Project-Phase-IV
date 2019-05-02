Public Class FormClassBooking
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Oracle.LogInAtRunTime()

        ' Binding it to myTable
        DataGridView1.DataSource = Oracle.bookingTable
    End Sub




    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        'Sql Query

        'Select Case*
        'From Booking
        'Where SearchCondition
        'Order By sttributes

        'VB.NET
        Dim field As String = cobField.Text
        Dim op As String = cobOp.Text
        Dim value As String = txtValue.Text

        ' For string values
        If field = "HOTEL_NO" Or field = "GUEST_NO" Or field = "ROOM_NO" Then
            Oracle.bookingCommand.CommandText =
                       "Select * " &
                       "From Booking " &
                       "Where " & field & op & " '" & value & "'"
        ElseIf field = "DATE_TO" Or field = "DATE_FROM" Then


            ' For Date values
            ' Could enter dates in different formats 
            ' Must Try-and-Catch!
            Dim theDate As Date = value

            Oracle.bookingCommand.CommandText =
                       "Select * " &
                       "From Booking " &
                       "Where " & field & op & "to_Date('" & theDate & "', 'mm/dd/yyyy')"
        Else
            Oracle.bookingCommand.CommandText =
                       "Select * " &
                       "From Booking " &
                       "Where " & field & op & " '" & value & "'"
        End If
        ' Check CommandText 
        'MessageBox.Show(Oracle.bookingCommand.CommandText)

        ' Catch exception
        Try
            Oracle.bookingTable.Clear()
            Oracle.bookingAdapter.Fill(Oracle.bookingTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' Exit
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    ' Update
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Me.BindingContext(Oracle.bookingTable).EndCurrentEdit()
            Oracle.bookingAdapter.Update(Oracle.bookingTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click
        ' For All
        Oracle.bookingCommand.CommandText = "Select * from booking"
        Try
            Oracle.bookingTable.Clear()
            Oracle.bookingAdapter.Fill(Oracle.bookingTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class