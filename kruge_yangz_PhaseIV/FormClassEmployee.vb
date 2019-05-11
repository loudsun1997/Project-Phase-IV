Public Class FormClassEmployee
    Private StaffDataView As New DataView()
    Private WorkExperienceDataView As New DataView()
    Private QualificationsDataView As New DataView()

    Private staffBindingSource As New BindingSource
    Private qualificationsBindingSource As New BindingSource
    Private workExperienceBindingSource As New BindingSource


    ' Binding in the form load event 
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'binding sources
        staffBindingSource.DataSource = Oracle.StaffTable


        'staff
        txtStaffNo.DataBindings.Add("Text", staffBindingSource, "StaffNo")
        txtFName.DataBindings.Add("Text", staffBindingSource, "FName")
        txtLName.DataBindings.Add("Text", staffBindingSource, "LName")
        txtStreet.DataBindings.Add("Text", staffBindingSource, "Street")
        txtCity.DataBindings.Add("Text", staffBindingSource, "City")
        txtState.DataBindings.Add("Text", staffBindingSource, "State")
        txtZip.DataBindings.Add("Text", staffBindingSource, "Zip")
        txtPhone.DataBindings.Add("Text", staffBindingSource, "Phone")
        DatePickerDOB.DataBindings.Add("Text", staffBindingSource, "DOB")
        DatePickerDOB.Format = DateTimePickerFormat.Custom   'format date
        DatePickerDOB.CustomFormat = "MM/dd/yyyy"
        txtGender.DataBindings.Add("Text", staffBindingSource, "Gender")
        txtNin.DataBindings.Add("Text", staffBindingSource, "NIN")
        txtEmpPosition.DataBindings.Add("Text", staffBindingSource, "Position")
        txtCurrSalary.DataBindings.Add("Text", staffBindingSource, "CurSalary")
        txtSalaryScale.DataBindings.Add("Text", staffBindingSource, "SalaryScale")
        txtHrsPerWk.DataBindings.Add("Text", staffBindingSource, "HrsPerWk")
        txtPosPermTemp.DataBindings.Add("Text", staffBindingSource, "PosPermTemp")
        txtPayType.DataBindings.Add("Text", staffBindingSource, "TypeOfPay")


        'page nums
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

        Oracle.StaffCommand.CommandText = "Select Distinct S.* " &
                                          "From UWP_Staff S" &
                                          "Left Join UWP_Qualifications Q" &
                                          " on  S.Staff_No = Q.Staff_No " &
                                          "Left Join UWP_WorkExperience W" &
                                          " on  S.Staff_No = W.Staff_No "
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

            qualificationsBindingSource.RemoveCurrent() 'remove qualifications associated with the staff no
            workExperienceBindingSource.RemoveCurrent() 'remove workexperience associated with the staff no



            staffBindingSource.EndEdit()     'Update Not sure if this line is necessary???????
            Oracle.StaffAdapter.Update(Oracle.StaffTable)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnInfoNew_Click(sender As Object, e As EventArgs) Handles btnInfoNew.Click
        btnQualNew.Enabled = False
        btnQualSave.Enabled = False
        btnQualDelete.Enabled = False
        btnExpNew.Enabled = False
        btnExpSave.Enabled = False
        btnExpDelete.Enabled = False
        btnAll.Enabled = False
        btnSearch.Enabled = False



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

            btnQualNew.Enabled = True
            btnQualSave.Enabled = True
            btnQualDelete.Enabled = True
            btnExpNew.Enabled = True
            btnExpSave.Enabled = True
            btnExpDelete.Enabled = True
            btnAll.Enabled = True
            btnSearch.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        'clear staff control boxes
        txtHrsPerWk.DataBindings.Clear()
        txtSalaryScale.DataBindings.Clear()
        txtPayType.DataBindings.Clear()
        txtPosPermTemp.DataBindings.Clear()
        txtCurrSalary.DataBindings.Clear()
        txtEmpPosition.DataBindings.Clear()
        txtStaffNo.DataBindings.Clear()
        txtFName.DataBindings.Clear()
        txtLName.DataBindings.Clear()
        txtStreet.DataBindings.Clear()
        txtCity.DataBindings.Clear()
        txtState.DataBindings.Clear()
        txtZip.DataBindings.Clear()
        txtPhone.DataBindings.Clear()
        txtGender.DataBindings.Clear()
        txtNin.DataBindings.Clear()
        DatePickerDOB.DataBindings.Clear()

        staffBindingSource.DataSource = Nothing
        Oracle.SpecStaffTable.Clear() 'clear SpecWorkExperienceTable

        If boxField.Text = "TYPE" Then
            Oracle.searchQualType(boxValue.Text)
        Else
            Oracle.searchORGNAME(boxValue.Text)

        End If

        staffBindingSource.DataSource = Oracle.SpecStaffTable
        txtStaffNo.DataBindings.Add("Text", staffBindingSource, "StaffNo")
        txtFName.DataBindings.Add("Text", staffBindingSource, "FName")
        txtLName.DataBindings.Add("Text", staffBindingSource, "LName")
        txtStreet.DataBindings.Add("Text", staffBindingSource, "Street")
        txtCity.DataBindings.Add("Text", staffBindingSource, "City")
        txtState.DataBindings.Add("Text", staffBindingSource, "State")
        txtZip.DataBindings.Add("Text", staffBindingSource, "Zip")
        txtPhone.DataBindings.Add("Text", staffBindingSource, "Phone")
        DatePickerDOB.DataBindings.Add("Text", staffBindingSource, "DOB")
        DatePickerDOB.Format = DateTimePickerFormat.Custom   'format date
        DatePickerDOB.CustomFormat = "MM/dd/yyyy"
        txtGender.DataBindings.Add("Text", staffBindingSource, "Gender")
        txtNin.DataBindings.Add("Text", staffBindingSource, "NIN")
        txtEmpPosition.DataBindings.Add("Text", staffBindingSource, "Position")
        txtCurrSalary.DataBindings.Add("Text", staffBindingSource, "CurSalary")
        txtSalaryScale.DataBindings.Add("Text", staffBindingSource, "SalaryScale")
        txtHrsPerWk.DataBindings.Add("Text", staffBindingSource, "HrsPerWk")
        txtPosPermTemp.DataBindings.Add("Text", staffBindingSource, "PosPermTemp")
        txtPayType.DataBindings.Add("Text", staffBindingSource, "TypeOfPay")

        txtEmpPageNum.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
    End Sub

    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click




        DatePickerQual.DataBindings.Clear()
        txtQualType.DataBindings.Clear()
        txtInstName.DataBindings.Clear()

        txtOrgName.DataBindings.Clear()
        txtWorkPosition.DataBindings.Clear()
        DatePickerStartDate.DataBindings.Clear()
        DatePickerFinishDate.DataBindings.Clear()



        txtHrsPerWk.DataBindings.Clear()
        txtSalaryScale.DataBindings.Clear()
        txtPayType.DataBindings.Clear()
        txtPosPermTemp.DataBindings.Clear()
        txtCurrSalary.DataBindings.Clear()
        txtEmpPosition.DataBindings.Clear()
        txtStaffNo.DataBindings.Clear()
        txtFName.DataBindings.Clear()
        txtLName.DataBindings.Clear()
        txtStreet.DataBindings.Clear()
        txtCity.DataBindings.Clear()
        txtState.DataBindings.Clear()
        txtZip.DataBindings.Clear()
        txtPhone.DataBindings.Clear()
        txtGender.DataBindings.Clear()
        txtNin.DataBindings.Clear()
        DatePickerDOB.DataBindings.Clear()

        staffBindingSource.DataSource = Nothing
        qualificationsBindingSource.DataSource = Nothing
        workExperienceBindingSource.DataSource = Nothing

        Oracle.StaffTable.Clear() 'clear SpecWorkExperienceTable
        Oracle.SpecQualificationsTable.Clear() 'clear SpecQualificationsTable
        Oracle.SpecWorkExperienceTable.Clear() 'clear SpecWorkExperienceTable

        Oracle.allStaff()

        staffBindingSource.DataSource = Oracle.StaffTable


        'staff
        txtStaffNo.DataBindings.Add("Text", staffBindingSource, "StaffNo")
        txtFName.DataBindings.Add("Text", staffBindingSource, "FName")
        txtLName.DataBindings.Add("Text", staffBindingSource, "LName")
        txtStreet.DataBindings.Add("Text", staffBindingSource, "Street")
        txtCity.DataBindings.Add("Text", staffBindingSource, "City")
        txtState.DataBindings.Add("Text", staffBindingSource, "State")
        txtZip.DataBindings.Add("Text", staffBindingSource, "Zip")
        txtPhone.DataBindings.Add("Text", staffBindingSource, "Phone")
        DatePickerDOB.DataBindings.Add("Text", staffBindingSource, "DOB")
        DatePickerDOB.Format = DateTimePickerFormat.Custom   'format date
        DatePickerDOB.CustomFormat = "MM/dd/yyyy"
        txtGender.DataBindings.Add("Text", staffBindingSource, "Gender")
        txtNin.DataBindings.Add("Text", staffBindingSource, "NIN")
        txtEmpPosition.DataBindings.Add("Text", staffBindingSource, "Position")
        txtCurrSalary.DataBindings.Add("Text", staffBindingSource, "CurSalary")
        txtSalaryScale.DataBindings.Add("Text", staffBindingSource, "SalaryScale")
        txtHrsPerWk.DataBindings.Add("Text", staffBindingSource, "HrsPerWk")
        txtPosPermTemp.DataBindings.Add("Text", staffBindingSource, "PosPermTemp")
        txtPayType.DataBindings.Add("Text", staffBindingSource, "TypeOfPay")


        'page nums
        txtEmpPageNum.Text = (staffBindingSource.Position + 1) & "/" & staffBindingSource.Count
        txtBoxQualPg.Text = (qualificationsBindingSource.Position + 1) & "/" & qualificationsBindingSource.Count
        txtBoxExpPg.Text = (workExperienceBindingSource.Position + 1) & "/" & workExperienceBindingSource.Count


    End Sub

    Private Sub btnQualDelete_Click(sender As Object, e As EventArgs) Handles btnQualDelete.Click
        qualificationsBindingSource.RemoveCurrent()
        txtBoxQualPg.Text = (qualificationsBindingSource.Position + 1) & "/" & qualificationsBindingSource.Count
    End Sub

    Private Sub btnExpDelete_Click(sender As Object, e As EventArgs) Handles btnExpDelete.Click
        workExperienceBindingSource.RemoveCurrent()
        txtBoxExpPg.Text = (workExperienceBindingSource.Position + 1) & "/" & workExperienceBindingSource.Count
    End Sub

    Private Sub loadSubTables(staffNo As String)
        Oracle.SpecQualificationsTable.Clear() 'clear SpecQualificationsTable
        Oracle.SpecWorkExperienceTable.Clear() 'clear SpecWorkExperienceTable
        Oracle.getQual(staffNo)
        Oracle.getEx(staffNo)
        qualificationsBindingSource.DataSource = Oracle.SpecQualificationsTable
        workExperienceBindingSource.DataSource = Oracle.SpecWorkExperienceTable

        DatePickerQual.DataBindings.Add("Text", qualificationsBindingSource, "QualDate")
        DatePickerQual.Format = DateTimePickerFormat.Custom   'format date
        DatePickerQual.CustomFormat = "MM/dd/yyyy"
        txtQualType.DataBindings.Add("Text", qualificationsBindingSource, "Type")
        txtInstName.DataBindings.Add("Text", qualificationsBindingSource, "InstName")



        txtOrgName.DataBindings.Add("Text", workExperienceBindingSource, "OrgName")
        txtWorkPosition.DataBindings.Add("Text", workExperienceBindingSource, "Position")
        DatePickerStartDate.DataBindings.Add("Text", workExperienceBindingSource, "StartDate")
        DatePickerFinishDate.DataBindings.Add("Text", workExperienceBindingSource, "FinishDate")
        DatePickerStartDate.Format = DateTimePickerFormat.Custom   'format date
        DatePickerStartDate.CustomFormat = "MM/dd/yyyy"
        DatePickerFinishDate.Format = DateTimePickerFormat.Custom   'format date
        DatePickerFinishDate.CustomFormat = "MM/dd/yyyy"

    End Sub

    Private Sub txtStaffNo_TextChanged(sender As Object, e As EventArgs) Handles txtStaffNo.TextChanged
        DatePickerQual.Value = DateTime.Now
        txtQualType.Text = ""
        txtInstName.Text = ""
        txtOrgName.Text = ""
        txtWorkPosition.Text = ""
        DatePickerStartDate.Value = DateTime.Now
        DatePickerFinishDate.Value = DateTime.Now

        DatePickerQual.DataBindings.Clear()
        txtQualType.DataBindings.Clear()
        txtInstName.DataBindings.Clear()

        txtOrgName.DataBindings.Clear()
        txtWorkPosition.DataBindings.Clear()
        DatePickerStartDate.DataBindings.Clear()
        DatePickerFinishDate.DataBindings.Clear()


        qualificationsBindingSource.DataSource = Nothing
        workExperienceBindingSource.DataSource = Nothing
        loadSubTables(txtStaffNo.Text)
        txtBoxQualPg.Text = (qualificationsBindingSource.Position + 1) & "/" & qualificationsBindingSource.Count
        txtBoxExpPg.Text = (workExperienceBindingSource.Position + 1) & "/" & workExperienceBindingSource.Count

    End Sub

    Private Sub txtBoxQualPg_TextChanged(sender As Object, e As EventArgs) Handles txtBoxQualPg.TextChanged
        If qualificationsBindingSource.Count <= 1 Then
            btnQualFirst.Enabled = False
            btnQualPrev.Enabled = False
            btnQualNext.Enabled = False
            btnQualLast.Enabled = False

        ElseIf qualificationsBindingSource.Position + 1 = qualificationsBindingSource.Count Then
            btnQualNext.Enabled = False
            btnQualLast.Enabled = False
            btnQualFirst.Enabled = True
            btnQualPrev.Enabled = True
        ElseIf qualificationsBindingSource.Position + 1 = 1 Then
            btnQualNext.Enabled = True
            btnQualLast.Enabled = True
            btnQualFirst.Enabled = False
            btnQualPrev.Enabled = False
        Else
            btnQualNext.Enabled = True
            btnQualLast.Enabled = True
            btnQualFirst.Enabled = True
            btnQualPrev.Enabled = True

        End If
    End Sub

    Private Sub txtEmpPageNum_TextChanged(sender As Object, e As EventArgs) Handles txtEmpPageNum.TextChanged
        If staffBindingSource.Count <= 1 Then
            btnInfoFirst.Enabled = False
            btnInfoPrev.Enabled = False
            btnInfoNext.Enabled = False
            btnInfoLast.Enabled = False

        ElseIf staffBindingSource.Position + 1 = staffBindingSource.Count Then
            btnInfoNext.Enabled = False
            btnInfoLast.Enabled = False
            btnInfoFirst.Enabled = True
            btnInfoPrev.Enabled = True
        ElseIf staffBindingSource.Position + 1 = 1 Then
            btnInfoNext.Enabled = True
            btnInfoLast.Enabled = True
            btnInfoFirst.Enabled = False
            btnInfoPrev.Enabled = False
        Else
            btnInfoNext.Enabled = True
            btnInfoLast.Enabled = True
            btnInfoFirst.Enabled = True
            btnInfoPrev.Enabled = True

        End If
    End Sub

    Private Sub txtBoxExpPg_TextChanged(sender As Object, e As EventArgs) Handles txtBoxExpPg.TextChanged
        If workExperienceBindingSource.Count <= 1 Then
            btnExpFirst.Enabled = False
            btnExpPrev.Enabled = False
            btnExpNext.Enabled = False
            btnExpLast.Enabled = False

        ElseIf workExperienceBindingSource.Position + 1 = staffBindingSource.Count Then
            btnExpFirst.Enabled = True
            btnExpPrev.Enabled = True
            btnExpNext.Enabled = False
            btnExpLast.Enabled = False
        ElseIf workExperienceBindingSource.Position + 1 = 1 Then
            btnExpFirst.Enabled = False
            btnExpPrev.Enabled = False
            btnExpNext.Enabled = True
            btnExpLast.Enabled = True
        Else
            btnExpFirst.Enabled = True
            btnExpPrev.Enabled = True
            btnExpNext.Enabled = True
            btnExpLast.Enabled = True

        End If
    End Sub
End Class