Public Class FormClassEmployee

    Private staffBindingSource As New BindingSource
    Private qualificationsBindingSource As New BindingSource
    Private workExperienceBindingSource As New BindingSource


    ' Binding in the form load event 
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Oracle.LogInAtRunTime()


        'txtStaffNo.DataBindings.Add("Text", Oracle.StaffTable, "StaffNo")
        'txtFName.DataBindings.Add("Text", Oracle.StaffTable, "FName")
        'txtLName.DataBindings.Add("Text", Oracle.StaffTable, "LName")
        'txtStreet.DataBindings.Add("Text", Oracle.StaffTable, "Street")
        'txtCity.DataBindings.Add("Text", Oracle.StaffTable, "City")
        'txtState.DataBindings.Add("Text", Oracle.StaffTable, "State")
        'txtZip.DataBindings.Add("Text", Oracle.StaffTable, "Zip")
        'txtPhone.DataBindings.Add("Text", Oracle.StaffTable, "Phone")
        'DatePickerDOB.DataBindings.Add("Text", Oracle.StaffTable, "DOB")
        'txtGender.DataBindings.Add("Text", Oracle.StaffTable, "Gender")
        'txtNin.DataBindings.Add("Text", Oracle.StaffTable, "NIN")
        'txtEmpPosition.DataBindings.Add("Text", Oracle.StaffTable, "Position")
        'txtCurrSalary.DataBindings.Add("Text", Oracle.StaffTable, "CurSalary")
        'txtSalaryScale.DataBindings.Add("Text", Oracle.StaffTable, "SalaryScale")
        'txtHrsPerWk.DataBindings.Add("Text", Oracle.StaffTable, "HrsPerWk")
        'txtPosPermTemp.DataBindings.Add("Text", Oracle.StaffTable, "PosPermTemp")
        'txtPayType.DataBindings.Add("Text", Oracle.StaffTable, "TypeOfPay")

        'DatePickerQual.DataBindings.Add("Text", Oracle.QualificationsTable, "QualDate")
        'txtQualType.DataBindings.Add("Text", Oracle.QualificationsTable, "Type")
        'txtInstName.DataBindings.Add("Text", Oracle.QualificationsTable, "InstName")

        'txtOrgName.DataBindings.Add("Text", Oracle.WorkExperienceTable, "OrgName")
        'txtWorkPosition.DataBindings.Add("Text", Oracle.WorkExperienceTable, "Position")
        'DatePickerStartDate.DataBindings.Add("Text", Oracle.WorkExperienceTable, "StartDate")
        'DatePickerFinishDate.DataBindings.Add("Text", Oracle.WorkExperienceTable, "FinishDate")


        staffBindingSource.DataSource = Oracle.StaffTable
        qualificationsBindingSource.DataSource = Oracle.QualificationsTable
        workExperienceBindingSource.DataSource = Oracle.WorkExperienceTable

        txtStaffNo.DataBindings.Add("Text", staffBindingSource, "StaffNo")
        txtFName.DataBindings.Add("Text", staffBindingSource, "FName")
        txtLName.DataBindings.Add("Text", staffBindingSource, "LName")
        txtStreet.DataBindings.Add("Text", staffBindingSource, "Street")
        txtCity.DataBindings.Add("Text", staffBindingSource, "City")
        txtState.DataBindings.Add("Text", staffBindingSource, "State")
        txtZip.DataBindings.Add("Text", staffBindingSource, "Zip")
        txtPhone.DataBindings.Add("Text", staffBindingSource, "Phone")
        DatePickerDOB.DataBindings.Add("Text", staffBindingSource, "DOB")
        txtGender.DataBindings.Add("Text", staffBindingSource, "Gender")
        txtNin.DataBindings.Add("Text", staffBindingSource, "NIN")
        txtEmpPosition.DataBindings.Add("Text", staffBindingSource, "Position")
        txtCurrSalary.DataBindings.Add("Text", staffBindingSource, "CurSalary")
        txtSalaryScale.DataBindings.Add("Text", staffBindingSource, "SalaryScale")
        txtHrsPerWk.DataBindings.Add("Text", staffBindingSource, "HrsPerWk")
        txtPosPermTemp.DataBindings.Add("Text", staffBindingSource, "PosPermTemp")
        txtPayType.DataBindings.Add("Text", staffBindingSource, "TypeOfPay")

        DatePickerQual.DataBindings.Add("Text", qualificationsBindingSource, "QualDate")
        txtQualType.DataBindings.Add("Text", qualificationsBindingSource, "Type")
        txtInstName.DataBindings.Add("Text", qualificationsBindingSource, "InstName")

        txtOrgName.DataBindings.Add("Text", workExperienceBindingSource, "OrgName")
        txtWorkPosition.DataBindings.Add("Text", workExperienceBindingSource, "Position")
        DatePickerStartDate.DataBindings.Add("Text", workExperienceBindingSource, "StartDate")
        DatePickerFinishDate.DataBindings.Add("Text", workExperienceBindingSource, "FinishDate")

        txtEmpPageNum.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
        txtBoxQualPg.Text = (qualificationsBindingSource.Position + 1) & "/" & qualificationsBindingSource.Count
        txtBoxExpPg.Text = (workExperienceBindingSource.Position + 1) & "/" & workExperienceBindingSource.Count
    End Sub

    Private Sub btnQualNext_Click(sender As Object, e As EventArgs) Handles btnQualNext.Click
        qualificationsBindingSource.MoveNext()
        txtBoxQualPg.Text = (qualificationsBindingSource.Position + 1) & "/" & qualificationsBindingSource.Count
    End Sub

    Private Sub btnQualPrev_Click(sender As Object, e As EventArgs) Handles btnQualPrev.Click
        qualificationsBindingSource.MovePrevious()
        txtBoxQualPg.Text = (qualificationsBindingSource.Position + 1) & "/" & qualificationsBindingSource.Count
    End Sub

    Private Sub btnQualNew_Click(sender As Object, e As EventArgs) Handles btnQualNew.Click

    End Sub

    Private Sub btnInfoNext_Click(sender As Object, e As EventArgs) Handles btnInfoNext.Click
        staffBindingSource.MoveNext()
        txtEmpPageNum.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
    End Sub

    Private Sub btnInfoPrev_Click(sender As Object, e As EventArgs) Handles btnInfoPrev.Click
        staffBindingSource.MovePrevious()
        txtEmpPageNum.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
    End Sub

    Private Sub btnExpPrev_Click(sender As Object, e As EventArgs) Handles btnExpPrev.Click
        workExperienceBindingSource.MovePrevious()
        txtBoxExpPg.Text = (workExperienceBindingSource.Position + 1) & "/" & workExperienceBindingSource.Count
    End Sub

    Private Sub btnExpNext_Click(sender As Object, e As EventArgs) Handles btnExpNext.Click
        workExperienceBindingSource.MoveNext()
        txtBoxExpPg.Text = (workExperienceBindingSource.Position + 1) & "/" & workExperienceBindingSource.Count
    End Sub

    Private Sub btnInfoFirst_Click(sender As Object, e As EventArgs) Handles btnInfoFirst.Click
        staffBindingSource.MoveFirst()
        txtEmpPageNum.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
    End Sub

    Private Sub btnInfoLast_Click(sender As Object, e As EventArgs) Handles btnInfoLast.Click
        staffBindingSource.MoveLast()
        txtEmpPageNum.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
    End Sub

    Private Sub btnQualFirst_Click(sender As Object, e As EventArgs) Handles btnQualFirst.Click
        qualificationsBindingSource.MoveFirst()
        txtBoxQualPg.Text = (qualificationsBindingSource.Position + 1) & "/" & qualificationsBindingSource.Count
    End Sub

    Private Sub btnQualLast_Click(sender As Object, e As EventArgs) Handles btnQualLast.Click
        qualificationsBindingSource.MoveLast()
        txtBoxQualPg.Text = (qualificationsBindingSource.Position + 1) & "/" & qualificationsBindingSource.Count
    End Sub

    Private Sub btnExpFirst_Click(sender As Object, e As EventArgs) Handles btnExpFirst.Click
        workExperienceBindingSource.MoveFirst()
        txtBoxExpPg.Text = (workExperienceBindingSource.Position + 1) & "/" & workExperienceBindingSource.Count
    End Sub

    Private Sub btnExpLast_Click(sender As Object, e As EventArgs) Handles btnExpLast.Click
        workExperienceBindingSource.MoveLast()
        txtBoxExpPg.Text = (workExperienceBindingSource.Position + 1) & "/" & workExperienceBindingSource.Count
    End Sub

    Private Sub btnInfoDelete_Click(sender As Object, e As EventArgs) Handles btnInfoDelete.Click
        Try
            staffBindingSource.RemoveCurrent()
            txtEmpPageNum.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnInfoNew_Click(sender As Object, e As EventArgs) Handles btnInfoNew.Click
        Dim r As DataRow

        r = Oracle.StaffTable.NewRow
        Oracle.StaffTable.Rows.Add(r)
        ' The new row is added at the end
        staffBindingSource.MoveLast()

        txtEmpPageNum.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
    End Sub

    Private Sub btnInfoSave_Click(sender As Object, e As EventArgs) Handles btnInfoSave.Click
        Try
            staffBindingSource.EndEdit()
            Oracle.StaffAdapter.Update(Oracle.StaffTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class