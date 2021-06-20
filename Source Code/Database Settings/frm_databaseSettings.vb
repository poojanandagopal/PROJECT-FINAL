Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Public Class frm_databaseSettings
    Dim StrMode As String = ""
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub frm_databaseSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Dim ObjClass As New ClassFunctions()
        Dim dt As New DataTable()
        dt = ObjClass.returndatatable("select * from Database_Settings_General", dt)
        If dt.Rows.Count > 0 Then
            StrMode = "MODIFY"
            chkAutoPt_ID.Checked = dt.Rows(0).Item("General_AutoPatientId")
            chkAutoOpen.Checked = dt.Rows(0).Item("General_AutoOpen")
            chkDisableDelete.Checked = dt.Rows(0).Item("General_DisableDelete")
            chkPerformTest.Checked = dt.Rows(0).Item("General_PerformTest")
        Else
            StrMode = "ADD"
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            Call SaveData()
            Me.Close()
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
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Database_Settings_General"
            cmd.Connection = con
            Dim dt As New DataTable()
            dt = objClass.returndatatable("select * from Database_Settings_General", dt)
            If dt.Rows.Count > 0 Then
                StrMode = "MODIFY"
            Else
                StrMode = "ADD"
            End If
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = StrMode
            If StrMode = "ADD" Then
                cmd.Parameters.Add(New SqlParameter("@General_Id", SqlDbType.VarChar, 7)).Value = objClass.getIndexKey()
            End If
            cmd.Parameters.Add(New SqlParameter("@General_AutoPatientId", SqlDbType.VarChar, 50)).Value = chkAutoPt_ID.Checked
            cmd.Parameters.Add(New SqlParameter("@General_AutoOpen", SqlDbType.VarChar, 50)).Value = chkAutoOpen.Checked
            cmd.Parameters.Add(New SqlParameter("@General_DisableDelete", SqlDbType.VarChar, 50)).Value = chkDisableDelete.Checked
            cmd.Parameters.Add(New SqlParameter("@General_PerformTest", SqlDbType.VarChar, 50)).Value = chkPerformTest.Checked
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Database_Settings_Database"
            cmd.Connection = con
            dt = objClass.returndatatable("select * from Database_Settings_Database", dt)
            If dt.Rows.Count > 0 Then
                StrMode = "MODIFY"
            Else
                StrMode = "ADD"
            End If
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = StrMode
            If StrMode = "ADD" Then
                cmd.Parameters.Add(New SqlParameter("@Database_Id", SqlDbType.VarChar, 7)).Value = objClass.getIndexKey()
            End If
            cmd.Parameters.Add(New SqlParameter("@Database_DBPath", SqlDbType.VarChar, 100)).Value = Trim(txtDbase_path.Text)
            cmd.Parameters.Add(New SqlParameter("@Database_DBFilePath", SqlDbType.VarChar, 100)).Value = Trim(txtFileDbase_path.Text)
            cmd.Parameters.Add(New SqlParameter("@Database_ImplantsFolder", SqlDbType.VarChar, 100)).Value = Trim(txtImplants_folder.Text)
            cmd.Parameters.Add(New SqlParameter("@Database_LocksFolder", SqlDbType.VarChar, 100)).Value = Trim(txtLocks_folder.Text)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Database_Settings_Compression"
            cmd.Connection = con
            dt = objClass.returndatatable("select * from Database_Settings_Compression", dt)
            If dt.Rows.Count > 0 Then
                StrMode = "MODIFY"
            Else
                StrMode = "ADD"
            End If
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = StrMode
            If StrMode = "ADD" Then
                cmd.Parameters.Add(New SqlParameter("@Compression_Id", SqlDbType.VarChar, 7)).Value = objClass.getIndexKey()
            End If
            cmd.Parameters.Add(New SqlParameter("@Compression_XrayFotos", SqlDbType.VarChar, 100)).Value = cmbXRay_fotos.Text
            cmd.Parameters.Add(New SqlParameter("@Compression_XrayJPEG", SqlDbType.VarChar, 10)).Value = XrayJPEG.Value
            cmd.Parameters.Add(New SqlParameter("@Compression_ColorImages", SqlDbType.VarChar, 100)).Value = cmbColorImages.Text
            cmd.Parameters.Add(New SqlParameter("@Compression_ColorJPEG", SqlDbType.VarChar, 10)).Value = ColorJPEG.Value
            cmd.Parameters.Add(New SqlParameter("@Compression_Thumbnails", SqlDbType.VarChar, 100)).Value = cmbColorThumbnails.Text
            cmd.Parameters.Add(New SqlParameter("@Compression_ThumbnailsJPEG", SqlDbType.VarChar, 10)).Value = ThumbnailsJPEG.Value
            cmd.Parameters.Add(New SqlParameter("@Compression_LetterImages", SqlDbType.VarChar, 100)).Value = cmbLetterImg.Text
            cmd.Parameters.Add(New SqlParameter("@Compression_LetterJPEG", SqlDbType.VarChar, 10)).Value = LetterJPEG.Value
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Database_Settings_WorkStations"
            cmd.Connection = con
            dt = objClass.returndatatable("select * from Database_Settings_WorkStations", dt)
            If dt.Rows.Count > 0 Then
                StrMode = "MODIFY"
            Else
                StrMode = "ADD"
            End If
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = StrMode
            If StrMode = "ADD" Then
                cmd.Parameters.Add(New SqlParameter("@WorkStations_Id", SqlDbType.VarChar, 7)).Value = objClass.getIndexKey()
            End If
            cmd.Parameters.Add(New SqlParameter("@WorkStations_Enable", SqlDbType.VarChar, 10)).Value = chkWorkstations.Checked
            cmd.Parameters.Add(New SqlParameter("@WorkStations_DispDentist", SqlDbType.VarChar, 10)).Value = chkDentist_ID.Checked
            cmd.Parameters.Add(New SqlParameter("@WorkStations_Name", SqlDbType.VarChar, 50)).Value = Trim(txtWorkstation_Name.Text)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Database_Settings_Sync"
            cmd.Connection = con
            dt = objClass.returndatatable("select * from Database_Settings_Sync", dt)
            If dt.Rows.Count > 0 Then
                StrMode = "MODIFY"
            Else
                StrMode = "ADD"
            End If
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = StrMode
            If StrMode = "ADD" Then
                cmd.Parameters.Add(New SqlParameter("@Sync_Id", SqlDbType.VarChar, 7)).Value = objClass.getIndexKey()
            End If
            cmd.Parameters.Add(New SqlParameter("@Sync_SendRequest", SqlDbType.VarChar, 10)).Value = chkSendSync.Checked
            cmd.Parameters.Add(New SqlParameter("@Sync_Auto", SqlDbType.VarChar, 10)).Value = chkSyncAuto.Checked
            cmd.Parameters.Add(New SqlParameter("@Sync_AutoSlave", SqlDbType.VarChar, 10)).Value = chkAutoStart_Slave.Checked
            cmd.Parameters.Add(New SqlParameter("@Sync_FilePathSend", SqlDbType.VarChar, 10)).Value = Trim(txtFilePath_Send.Text)
            cmd.Parameters.Add(New SqlParameter("@Sync_ReceiveRequest", SqlDbType.VarChar, 10)).Value = chkReceiveSync.Checked
            cmd.Parameters.Add(New SqlParameter("@Sync_FilePathReceive", SqlDbType.VarChar, 100)).Value = Trim(txtFilePath_Read.Text)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Database_Settings_Replication"
            cmd.Connection = con
            dt = objClass.returndatatable("select * from Database_Settings_Replication", dt)
            If dt.Rows.Count > 0 Then
                StrMode = "MODIFY"
            Else
                StrMode = "ADD"
            End If
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = StrMode
            If StrMode = "ADD" Then
                cmd.Parameters.Add(New SqlParameter("@Replication_Id", SqlDbType.VarChar, 7)).Value = objClass.getIndexKey()
            End If
            cmd.Parameters.Add(New SqlParameter("@Replication_Enable", SqlDbType.VarChar, 10)).Value = chkReplication.Checked
            cmd.Parameters.Add(New SqlParameter("@Replication_HostName", SqlDbType.VarChar, 50)).Value = Trim(txtHostName.Text)
            cmd.Parameters.Add(New SqlParameter("@Replication_PortNo", SqlDbType.VarChar, 50)).Value = Trim(txtPortNumber.Text)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    
End Class
