Public Class Oracle

    Friend Shared frmLogin As New FormClassLogin
    Private Shared frmBooking As New FormClassBooking

    ' The Enumeration Data Type for user response 
    Public Enum ResponseType
        OK
        Cancel
    End Enum

    Friend Shared Result As ResponseType
    Friend Shared UserName As String
    Friend Shared PassWord As String
    Friend Shared Server As String

    Friend Shared OracleConnection As New System.Data.OracleClient.OracleConnection

    ' variables for booking
    Friend Shared bookingAdapter As New System.Data.OracleClient.OracleDataAdapter
    Friend Shared bookingCommand As New System.Data.OracleClient.OracleCommand
    Friend Shared bookingCommandBuilder As System.Data.OracleClient.OracleCommandBuilder
    Friend Shared bookingTable As New System.Data.DataTable

    Public Shared Sub LogInAtRunTime()
        ' set the connecting string   

        ' Make sure the connection string is correct.
        OracleConnection.ConnectionString = "Data Source=" & Server & ";User ID=" & UserName & ";Password=" & PassWord & ";Unicode=True"

        ' Set up Booking table 
        bookingCommand.CommandType = CommandType.Text
        bookingCommand.CommandText = "Select * from booking"
        bookingCommand.Connection = OracleConnection

        bookingAdapter.SelectCommand = bookingCommand
        bookingCommandBuilder = New System.Data.OracleClient.OracleCommandBuilder(bookingAdapter)
        bookingAdapter.Fill(bookingTable)
    End Sub

    Public Shared Sub main()
        Dim connected As Boolean

        While Not connected
            frmLogin.ShowDialog()
            If Result = ResponseType.Cancel Then
                Exit While
            End If

            Try
                LogInAtRunTime()
                connected = True
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End While

        If connected Then
            Application.Run(frmBooking)
        End If
    End Sub

End Class