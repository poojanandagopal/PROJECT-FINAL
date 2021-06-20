Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient

Public Class frm_Patient_Registration
    Private strMode As String
    Private v_ptRegId As String
    Private Sub frm_Patient_Registration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Dim ObjClass As New ClassFunctions()
        txtCode.Text = ObjClass.Returnsinglevalue("select max(ptReg_Code) from master_ptReg")
        txtCode.Text = Val(txtCode.Text) + 1
        If PatientId = "" Then
            strMode = "ADD"
            btnModify.Enabled = False
            btnDelete.Enabled = False
        Else
            strMode = "MODIFY"
            btnSave.Enabled = False
            Call FillDetails()
        End If
    End Sub
    Private Sub FillDetails()
        Try
            Dim objClass As New ClassFunctions
            Dim dt As New DataTable()
            Dim str As String
            str = Nothing
            str = "Select * from Master_ptReg where ptReg_Id='" & PatientId & "'"
            dt = objClass.returndatatable(str, dt)
            If dt.Rows.Count > 0 Then
                txtCode.Text = dt.Rows(0).Item("ptReg_Code")
                dtpRegDate.Value = dt.Rows(0).Item("ptReg_Date") 'Format(dt.Rows(0).Item("ptReg_Date"), "dd/MM/yyyy")
                cmbPrefix.Text = dt.Rows(0).Item("ptReg_Prefix")
                txtFirstName.Text = dt.Rows(0).Item("ptReg_FirstName")
                txtLastName.Text = dt.Rows(0).Item("ptReg_LastName")
                dtpDOB.Value = dt.Rows(0).Item("ptReg_DOB") 'Format(dt.Rows(0).Item("ptReg_DOB"), "dd/MM/yyyy")
                txtAge.Text = dt.Rows(0).Item("ptReg_Age")
                txtStreet.Text = dt.Rows(0).Item("ptReg_Street")
                txtZip.Text = dt.Rows(0).Item("ptReg_Zip")
                txtCity.Text = dt.Rows(0).Item("ptReg_City")
                txtState.Text = dt.Rows(0).Item("ptReg_state")
                txtEmail.Text = dt.Rows(0).Item("ptReg_Email")
                txtMobile.Text = dt.Rows(0).Item("ptReg_Mobile")
                cmbStatus.Text = dt.Rows(0).Item("ptReg_Status")
                txtRegNo.Text = dt.Rows(0).Item("ptReg_RegNo")
                txtNotes.Text = dt.Rows(0).Item("ptReg_Notes")
                txtDiagnosis.Text = dt.Rows(0).Item("ptReg_Diagnosis")
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cmbPrefix_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrefix.SelectedIndexChanged
        If cmbPrefix.SelectedIndex = 0 Then
            RBMale.Checked = True
        ElseIf cmbPrefix.SelectedIndex = 1 Then
            RBFemale.Checked = True
        ElseIf cmbPrefix.SelectedIndex = 2 Then
            RBMale.Checked = True
        ElseIf cmbPrefix.SelectedIndex = 3 Then
            RBFemale.Checked = True
        ElseIf cmbPrefix.SelectedIndex = 4 Then
            RBMale.Checked = False
            RBFemale.Checked = False
        ElseIf cmbPrefix.SelectedIndex = 5 Then
            RBMale.Checked = False
            RBFemale.Checked = False
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim objClass As New ClassFunctions
            Dim email As Boolean
            Dim phone As Boolean
            If Trim(txtFirstName.Text) = "" Then
                MsgBox("Enter the First Name!")
                Exit Sub
            End If
            If Trim(txtLastName.Text) = "" Then
                MsgBox("Enter the Last Name!")
                Exit Sub
            End If
            If Trim(txtAge.Text) = "" Then
                MsgBox("Enter the Age!")
                Exit Sub
            End If

            If Trim(txtRegNo.Text) = "" Then
                MsgBox("Enter the SSN NO!")
                Exit Sub
            End If

            email = objClass.IsValidEmailAddress(txtEmail.Text)
           
            If (email = False) Then
                MsgBox("Email Id is invalid")
                Exit Sub

            End If

            phone = objClass.IsValidPhoneNumber(txtMobile.Text)
            If (phone = False) Then
                MsgBox("phone no is invalid")
                Exit Sub

            End If



            Dim dt As New DataTable()
            Dim str As String

            str = Nothing
            str = "Select ptReg_RegNo from Master_ptReg where ptReg_RegNo='" & txtRegNo.Text & "' "
            dt = objClass.returndatatable(str, dt)
            If dt.Rows.Count > 0 Then

                MsgBox("SSN Number is already present please change!")
                Exit Sub
            End If
            Call SaveData()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub SaveData()
        Try
            Dim objClass As New ClassFunctions
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            con = New SqlConnection(objClass.ConnectionString)
            con.Open()
            Dim Gender As String = ""
            If RBMale.Checked = True Then
                Gender = "M"
            ElseIf RBFemale.Checked = True Then
                Gender = "F"
            End If
            If strMode = "ADD" Then
                v_ptRegId = objClass.getIndexKey()
                txtCode.Text = objClass.Returnsinglevalue("select max(ptReg_Code) from master_ptReg")
                txtCode.Text = Val(txtCode.Text) + 1

            ElseIf strMode = "MODIFY" Then
                v_ptRegId = PatientId

            ElseIf strMode = "DELETE" Then
                v_ptRegId = PatientId
                objClass.ExecuteQuery("delete from master_ptreg where ptReg_Id='" & v_ptRegId & "'")
                Call frm_Patient_Search.FillDataGridView()
                MsgBox("Patient Details deleted Successfully!")
                Me.Close()
            End If
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Master_ptReg"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = strMode
            cmd.Parameters.Add(New SqlParameter("@ptReg_Id", SqlDbType.VarChar, 7)).Value = v_ptRegId
            cmd.Parameters.Add(New SqlParameter("@ptReg_Code", SqlDbType.Decimal, 18, 0)).Value = Val(txtCode.Text)
            cmd.Parameters.Add(New SqlParameter("@ptReg_Date", SqlDbType.DateTime)).Value = Format(dtpRegDate.Value, "yyyy-MM-dd")
            cmd.Parameters.Add(New SqlParameter("@ptReg_Prefix", SqlDbType.VarChar, 10)).Value = cmbPrefix.Text
            cmd.Parameters.Add(New SqlParameter("@ptReg_FirstName", SqlDbType.VarChar, 50)).Value = Trim(txtFirstName.Text)
            cmd.Parameters.Add(New SqlParameter("@ptReg_LastName", SqlDbType.VarChar, 50)).Value = Trim(txtLastName.Text)
            cmd.Parameters.Add(New SqlParameter("@ptReg_Gender", SqlDbType.VarChar, 10)).Value = Gender
            cmd.Parameters.Add(New SqlParameter("@ptReg_DOB", SqlDbType.DateTime)).Value = Format(dtpDOB.Value, "yyyy-MM-dd")
            cmd.Parameters.Add(New SqlParameter("@ptReg_Age", SqlDbType.Decimal, 3, 0)).Value = Val(txtAge.Text)
            cmd.Parameters.Add(New SqlParameter("@ptReg_Street", SqlDbType.VarChar, 250)).Value = Trim(txtStreet.Text)
            cmd.Parameters.Add(New SqlParameter("@ptReg_Zip", SqlDbType.VarChar, 10)).Value = Trim(txtZip.Text)
            cmd.Parameters.Add(New SqlParameter("@ptReg_City", SqlDbType.VarChar, 50)).Value = Trim(txtCity.Text)
            cmd.Parameters.Add(New SqlParameter("@ptReg_State", SqlDbType.VarChar, 50)).Value = Trim(txtState.Text)
            cmd.Parameters.Add(New SqlParameter("@ptReg_Email", SqlDbType.VarChar, 100)).Value = Trim(txtEmail.Text)
            cmd.Parameters.Add(New SqlParameter("@ptReg_Mobile", SqlDbType.Decimal, 10, 0)).Value = Val(txtMobile.Text)
            cmd.Parameters.Add(New SqlParameter("@ptReg_RegNo", SqlDbType.VarChar, 50)).Value = Trim(txtRegNo.Text)
            cmd.Parameters.Add(New SqlParameter("@ptReg_Status", SqlDbType.VarChar, 50)).Value = Trim(cmbStatus.Text)
            cmd.Parameters.Add(New SqlParameter("@ptReg_Notes", SqlDbType.VarChar, 250)).Value = Trim(txtNotes.Text)
            cmd.Parameters.Add(New SqlParameter("@ptReg_Diagnosis", SqlDbType.VarChar, 250)).Value = Trim(txtDiagnosis.Text)
            cmd.Parameters.Add(New SqlParameter("@ptReg_ModifiedOn", SqlDbType.DateTime)).Value = Format(Date.Now, "yyyy-MM-dd")
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            If UCase(strMode) = "ADD" Then
                MsgBox("Patient details added Successfully!")
            ElseIf UCase(strMode) = "MODIFY" Then
                MsgBox("Patient details modified Successfully!")
            End If
            PatientId = v_ptRegId
            frm_MainScreen.FillDetails()

            frm_Patient_NewImage.Show()
           
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub cmbPrefix_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPrefix.TextChanged
        If cmbPrefix.SelectedIndex = 0 Then
            RBMale.Checked = True
        ElseIf cmbPrefix.SelectedIndex = 1 Then
            RBFemale.Checked = True
        ElseIf cmbPrefix.SelectedIndex = 2 Then
            RBMale.Checked = True
        ElseIf cmbPrefix.SelectedIndex = 3 Then
            RBFemale.Checked = True
        ElseIf cmbPrefix.SelectedIndex = 4 Then
            RBMale.Checked = False
            RBFemale.Checked = False
        ElseIf cmbPrefix.SelectedIndex = 5 Then
            RBMale.Checked = False
            RBFemale.Checked = False
        End If
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Try
            Call SaveData()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Do you want to Delete this Patient Details?", MsgBoxStyle.Question + vbYesNo) = MsgBoxResult.Yes Then
            strMode = "DELETE"
            Call SaveData()
        End If
    End Sub

   
    Private Sub txtMobile_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMobile.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub

   
    Private Sub txtAge_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAge.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub

    Private Sub txtZip_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZip.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub
End Class