Public Class Oracle
    Friend Shared frmLogin As New FormClassLogin
    Private Shared frmEmployee As New FormClassEmployee


    Friend Shared OracleConnection As New System.Data.OracleClient.OracleConnection

    ' variables for booking
    Friend Shared bookingAdapter As New System.Data.OracleClient.OracleDataAdapter
    Friend Shared bookingCommand As New System.Data.OracleClient.OracleCommand
    Friend Shared bookingCommandBuilder As System.Data.OracleClient.OracleCommandBuilder
    Friend Shared myTable As New System.Data.DataTable

    ' One command, adapter and builder for each table
    Friend Shared hotelAdapter As New System.Data.OracleClient.OracleDataAdapter
    Friend Shared hotelCommand As New System.Data.OracleClient.OracleCommand
    Friend Shared hotelBuilder As System.Data.OracleClient.OracleCommandBuilder
    Friend Shared hotelTable As New System.Data.DataTable

    Public Shared Sub LogInAtRunTime()
        ' set the connecting string   
        OracleConnection.ConnectionString = "Data Source=" & Server & ";User ID=" & UserName & ";Password=" & PassWord & ";Unicode=True"
        ' Set up booking table


        ' Set up hotel table 
        hotelCommand.CommandType = CommandType.Text
        hotelCommand.CommandText = "Select * from UWP_Staff"
        hotelCommand.Connection = OracleConnection

        hotelAdapter.SelectCommand = hotelCommand
        hotelBuilder = New System.Data.OracleClient.OracleCommandBuilder(hotelAdapter)
        hotelAdapter.Fill(hotelTable)


        ' Set up hotel table 
        hotelCommand.CommandType = CommandType.Text
        hotelCommand.CommandText = "Select * from hotel"
        hotelCommand.Connection = OracleConnection

        hotelAdapter.SelectCommand = hotelCommand
        hotelBuilder = New System.Data.OracleClient.OracleCommandBuilder(hotelAdapter)
        hotelAdapter.Fill(hotelTable)
    End Sub
    ' set the connecting string to debug 
    ' The Enumeration Data Type for user response 
    Public Enum ResponseType
        OK
        Cancel
    End Enum

    Friend Shared Result As ResponseType
    Friend Shared UserName As String
        Friend Shared PassWord As String
        Friend Shared Server As String



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
            Application.Run(frmEmployee)
        End If
    End Sub


End Class

