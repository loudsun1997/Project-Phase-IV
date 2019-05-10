Public Class Oracle
    Friend Shared frmLogin As New FormClassLogin
    Private Shared frmEmployee As New FormClassEmployee


    Friend Shared OracleConnection As New System.Data.OracleClient.OracleConnection

    ' variables for Staff
    Friend Shared StaffAdapter As New System.Data.OracleClient.OracleDataAdapter
    Friend Shared StaffCommand As New System.Data.OracleClient.OracleCommand
    Friend Shared StaffCommandBuilder As System.Data.OracleClient.OracleCommandBuilder
    Friend Shared StaffTable As New System.Data.DataTable

    ' One command, adapter and builder for each table
    Friend Shared WorkExperienceAdapter As New System.Data.OracleClient.OracleDataAdapter
    Friend Shared WorkExperienceCommand As New System.Data.OracleClient.OracleCommand
    Friend Shared WorkExperienceBuilder As System.Data.OracleClient.OracleCommandBuilder
    Friend Shared WorkExperienceTable As New System.Data.DataTable

    Friend Shared QualificationsAdapter As New System.Data.OracleClient.OracleDataAdapter
    Friend Shared QualificationsCommand As New System.Data.OracleClient.OracleCommand
    Friend Shared QualificationsBuilder As System.Data.OracleClient.OracleCommandBuilder
    Friend Shared QualificationsTable As New System.Data.DataTable

    Public Shared Sub LogInAtRunTime()
        ' set the connecting string   
        OracleConnection.ConnectionString = "Data Source=" & Server & ";User ID=" & UserName & ";Password=" & PassWord & ";Unicode=True"



        ' Set up staff table 
        StaffCommand.CommandType = CommandType.Text
        StaffCommand.CommandText = "Select * from UWP_Staff"
        StaffCommand.Connection = OracleConnection

        StaffAdapter.SelectCommand = StaffCommand
        StaffCommandBuilder = New System.Data.OracleClient.OracleCommandBuilder(StaffAdapter)
        StaffAdapter.Fill(StaffTable) 'name for the staff table

        ' Set up workExperience table 
        WorkExperienceCommand.CommandType = CommandType.Text
        WorkExperienceCommand.CommandText = "Select * from UWP_WorkExperience"
        WorkExperienceCommand.Connection = OracleConnection

        WorkExperienceAdapter.SelectCommand = WorkExperienceCommand
        WorkExperienceBuilder = New System.Data.OracleClient.OracleCommandBuilder(WorkExperienceAdapter)
        WorkExperienceAdapter.Fill(WorkExperienceTable) 'name for the staff table

        ' Set up Qualifications table 
        QualificationsCommand.CommandType = CommandType.Text
        QualificationsCommand.CommandText = "Select * from UWP_Qualifications"
        QualificationsCommand.Connection = OracleConnection

        QualificationsAdapter.SelectCommand = QualificationsCommand
        QualificationsBuilder = New System.Data.OracleClient.OracleCommandBuilder(QualificationsAdapter)
        QualificationsAdapter.Fill(QualificationsTable) 'name for the staff table



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

