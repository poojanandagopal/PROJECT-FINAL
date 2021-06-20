Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Public Class frm_communicationSettings
    Dim strMode As String = ""
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            Call SaveData()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub frm_communicationSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Dim ObjClass As New ClassFunctions()
        Dim dt As New DataTable()
        Dim dtchk As New DataTable()
        dt = ObjClass.returndatatable("select * from Communication_settings_Email", dt)
        If dt.Rows.Count > 0 Then

        End If
        strMode = "MODIFY"
        rbsend_MAPI.Checked = dt.Rows(0).Item("Email_Send_MAPI")
        rbsend_Interestate.Checked = dt.Rows(0).Item("Email_Send_Interestate")
        rbsend_Direct.Checked = dt.Rows(0).Item("Email_Send_Direct")
        rbreceive_MAPI.Checked = dt.Rows(0).Item("Email_Receive_MAPI")
        rbreceive_Interestate.Checked = dt.Rows(0).Item("Email_Receive_Interestate")
        rbreceive_Direct.Checked = dt.Rows(0).Item("Email_Receive_Direct")
        chkdisplaymsg.Checked = dt.Rows(0).Item("Email_DisplayReceive")
        chkreceivedlist.Checked = dt.Rows(0).Item("Email_OpenReceive")

        dtchk = ObjClass.returndatatable("select * from Communication_settings_AddressBook", dtchk)
        If dtchk.Rows.Count > 0 Then
            txtDisplayName.Text = dtchk.Rows(0).Item("AddressBook_Name")
            txtEmail.Text = dtchk.Rows(0).Item("AddressBook_Email")
            chkPatientID.Checked = dtchk.Rows(0).Item("AddressBook_Data_PtId")
            chkSSNNo.Checked = dtchk.Rows(0).Item("AddressBook_Data_SSNNo")
            chkPtName.Checked = dtchk.Rows(0).Item("AddressBook_Data_PtName")
            chkBirthDate.Checked = dtchk.Rows(0).Item("AddressBook_Data_BirthDate")
            chkGender.Checked = dtchk.Rows(0).Item("AddressBook_Data_Gender")
            chkAddress.Checked = dtchk.Rows(0).Item("AddressBook_Data_Address")
            chkTelephone.Checked = dtchk.Rows(0).Item("AddressBook_Data_Phone")
            chkFax.Checked = dtchk.Rows(0).Item("AddressBook_Data_FAX")
            chkEmail.Checked = dtchk.Rows(0).Item("AddressBook_Data_Email")
            chkPtNotes.Checked = dtchk.Rows(0).Item("AddressBook_Data_Notes")
            chkDiagnose.Checked = dtchk.Rows(0).Item("AddressBook_Data_Diagnose")

            If dtchk.Rows(0).Item("AddressBook_Sendformat") = "1" Then
                rbSinglefiles_orginal.Checked = True
            ElseIf dtchk.Rows(0).Item("AddressBook_Sendformat") = "2" Then
                rbSinglefiles_processed.Checked = True
            ElseIf dtchk.Rows(0).Item("AddressBook_Sendformat") = "3" Then
                rbVisiQuickformat.Checked = True
            ElseIf dtchk.Rows(0).Item("AddressBook_Sendformat") = "4" Then
                rbVisiQuickformat_secure.Checked = True
            ElseIf dtchk.Rows(0).Item("AddressBook_Sendformat") = "5" Then
                rbCtakt.Checked = True
            End If
        Else
            strMode = "ADD"
        End If
    End Sub

    Private Sub SaveData()
        Try
            Dim objClass As New ClassFunctions
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            con = New SqlConnection(objClass.ConnectionString)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Communication_Settings_Email"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = strMode
            If strMode = "ADD" Then
                cmd.Parameters.Add(New SqlParameter("@Email_Id", SqlDbType.VarChar, 7)).Value = objClass.getIndexKey()
            End If
            cmd.Parameters.Add(New SqlParameter("@Email_Send_MAPI", SqlDbType.VarChar, 10)).Value = rbsend_MAPI.Checked
            cmd.Parameters.Add(New SqlParameter("@Email_Send_Interestate", SqlDbType.VarChar, 10)).Value = rbsend_Interestate.Checked
            cmd.Parameters.Add(New SqlParameter("@Email_Send_Direct", SqlDbType.VarChar, 10)).Value = rbsend_Direct.Checked
            cmd.Parameters.Add(New SqlParameter("@Email_Receive_MAPI", SqlDbType.VarChar, 10)).Value = rbreceive_MAPI.Checked
            cmd.Parameters.Add(New SqlParameter("@Email_Receive_Interestate", SqlDbType.VarChar, 10)).Value = rbreceive_Interestate.Checked
            cmd.Parameters.Add(New SqlParameter("@Email_Receive_Direct", SqlDbType.VarChar, 10)).Value = rbreceive_Direct.Checked
            cmd.Parameters.Add(New SqlParameter("@Email_DisplayReceive", SqlDbType.VarChar, 10)).Value = chkdisplaymsg.Checked
            cmd.Parameters.Add(New SqlParameter("@Email_OpenReceive", SqlDbType.VarChar, 10)).Value = chkreceivedlist.Checked
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            Dim SendFormat As String = ""
            If rbSinglefiles_orginal.Checked = True Then
                SendFormat = "1"
            ElseIf rbSinglefiles_processed.Checked = True Then
                SendFormat = "2"
            ElseIf rbVisiQuickformat.Checked = True Then
                SendFormat = "3"
            ElseIf rbVisiQuickformat_secure.Checked = True Then
                SendFormat = "4"
            ElseIf rbCtakt.Checked = True Then
                SendFormat = "5"
            End If
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Communication_Settings_AddressBook"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = strMode
            If strMode = "ADD" Then
                cmd.Parameters.Add(New SqlParameter("@AddressBook_Id", SqlDbType.VarChar, 7)).Value = objClass.getIndexKey()
            End If
            cmd.Parameters.Add(New SqlParameter("@AddressBook_Name", SqlDbType.VarChar, 50)).Value = Trim(txtDisplayName.Text)
            cmd.Parameters.Add(New SqlParameter("@AddressBook_Email", SqlDbType.VarChar, 100)).Value = Trim(txtEmail.Text)
            cmd.Parameters.Add(New SqlParameter("@AddressBook_SendFormat", SqlDbType.VarChar, 10)).Value = SendFormat
            cmd.Parameters.Add(New SqlParameter("@AddressBook_Data_PtId", SqlDbType.VarChar, 10)).Value = chkPatientID.Checked
            cmd.Parameters.Add(New SqlParameter("@AddressBook_Data_SSNNo", SqlDbType.VarChar, 10)).Value = chkSSNNo.Checked
            cmd.Parameters.Add(New SqlParameter("@AddressBook_Data_PtName", SqlDbType.VarChar, 10)).Value = chkPtName.Checked
            cmd.Parameters.Add(New SqlParameter("@AddressBook_Data_BirthDate", SqlDbType.VarChar, 10)).Value = chkBirthDate.Checked
            cmd.Parameters.Add(New SqlParameter("@AddressBook_Data_Gender", SqlDbType.VarChar, 10)).Value = chkGender.Checked
            cmd.Parameters.Add(New SqlParameter("@AddressBook_Data_Address", SqlDbType.VarChar, 10)).Value = chkAddress.Checked
            cmd.Parameters.Add(New SqlParameter("@AddressBook_Data_Phone", SqlDbType.VarChar, 10)).Value = chkTelephone.Checked
            cmd.Parameters.Add(New SqlParameter("@AddressBook_Data_FAX", SqlDbType.VarChar, 10)).Value = chkFax.Checked
            cmd.Parameters.Add(New SqlParameter("@AddressBook_Data_Email", SqlDbType.VarChar, 10)).Value = chkEmail.Checked
            cmd.Parameters.Add(New SqlParameter("@AddressBook_Data_Notes", SqlDbType.VarChar, 10)).Value = chkPtNotes.Checked
            cmd.Parameters.Add(New SqlParameter("@AddressBook_Data_Diagnose", SqlDbType.VarChar, 10)).Value = chkDiagnose.Checked
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
End Class