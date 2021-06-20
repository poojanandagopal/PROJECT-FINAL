Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class frm_applicationSettings
    Dim StrMode As String = ""

    Private Sub frm_applicationSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Label6.Text = "Histogram stretch correction: [" & Track_Histogram.Value & "]"
        Label10.Text = "Gamma correction: [" & Format(Track_Gamma.Value / 10, "#.0") & "]"
        GroupBox5.Text = "Sharpness filter strength[" & Track_Sharp.Value & "]"
        GroupBox11.Text = "Smoothing filter strength[" & Track_Smooth.Value & "]"
        txtComputerName.Text = My.Computer.Name
        Dim ObjClass As New ClassFunctions()
        Dim dt As New DataTable()
        Dim dtchk As New DataTable()
        dt = ObjClass.returndatatable("select * from application_settings_General", dt)
        If dt.Rows.Count > 0 Then
            StrMode = "MODIFY"
            cmbLanguage.Text = dt.Rows(0).Item("general_language")
            cmbMonitor.Text = dt.Rows(0).Item("general_startupMonitor")
            chkReopen.Checked = dt.Rows(0).Item("general_reopenimage")
            chkmultiple.Checked = dt.Rows(0).Item("General_AllowMultiple")
            chkDentist.Checked = dt.Rows(0).Item("General_Dentist")
            chkPtID.Checked = dt.Rows(0).Item("General_PatientId")
            chkptName.Checked = dt.Rows(0).Item("General_PatientName")
            chkOrderNo.Checked = dt.Rows(0).Item("General_OrderNo")
            chkSSNNo.Checked = dt.Rows(0).Item("General_SSNNo")
            txtLabel.Text = dt.Rows(0).Item("General_Label")
            chkadmnID.Checked = dt.Rows(0).Item("General_OpenAdmnId")
            chkOpenDentist.Checked = dt.Rows(0).Item("General_OpenDentist")

            dtchk = ObjClass.returndatatable("select * from application_settings_View", dtchk)
            If dtchk.Rows.Count > 0 Then
                chkImageid.Checked = dtchk.Rows(0).Item("View_ImageId")
                chkCreationDate.Checked = dtchk.Rows(0).Item("View_CreationDate")
                chkImageNotes.Checked = dtchk.Rows(0).Item("View_ImageNotes")
                chkPositions.Checked = dtchk.Rows(0).Item("View_ToothPositions")
                chkImageID1.Checked = dtchk.Rows(0).Item("View_ImageId1")
                chkCreationDate1.Checked = dtchk.Rows(0).Item("View_CreationDate1")
                chkImageNotes1.Checked = dtchk.Rows(0).Item("View_ImageNotes1")
                chkPositions1.Checked = dtchk.Rows(0).Item("View_ToothPositions1")
                chkImageid2.Checked = dtchk.Rows(0).Item("View_ImageId2")
                chkCreationDate2.Checked = dtchk.Rows(0).Item("View_CreationDate2")
                chkImageNotes2.Checked = dtchk.Rows(0).Item("View_ImageNotes2")
                chkPositions2.Checked = dtchk.Rows(0).Item("View_ToothPositions2")

                If dtchk.Rows(0).Item("View_StartupView") = "Compare" Then
                    rbCompare.Checked = True
                ElseIf dtchk.Rows(0).Item("View_StartupView") = "Xray" Then
                    rbXray.Checked = True
                ElseIf dtchk.Rows(0).Item("View_StartupView") = "Xray" Then
                    rbColors.Checked = True
                ElseIf dtchk.Rows(0).Item("View_StartupView") = "Panoramic" Then
                    rbpanoramic.Checked = True
                ElseIf dtchk.Rows(0).Item("View_StartupView") = "Profile" Then
                    rbProfile.Checked = True
                ElseIf dtchk.Rows(0).Item("View_StartupView") = "Documents" Then
                    rbDoc.Checked = True
                ElseIf dtchk.Rows(0).Item("View_StartupView") = "Files" Then
                    rbFiles.Checked = True
                End If
                cmbSplitMode.Text = dtchk.Rows(0).Item("View_SplitMode")
                chkWithImage.Checked = dtchk.Rows(0).Item("View_AgeWithImage")
            End If
            dtchk.Rows.Clear()
            dtchk = ObjClass.returndatatable("select * from application_settings_Image", dtchk)
            If dtchk.Rows.Count > 0 Then
                Track_Histogram.Value = dtchk.Rows(0).Item("Image_histogram")
                Track_Gamma.Value = dtchk.Rows(0).Item("Image_Gamma")
                Track_Sharp.Value = dtchk.Rows(0).Item("Image_sharpness")
                Track_Smooth.Value = dtchk.Rows(0).Item("Image_smoothing")
                If dtchk.Rows(0).Item("Image_histogramversion") = "1.0" Then
                    rb1.Checked = True
                Else
                    rb2.Checked = True
                End If
            End If

            dtchk = ObjClass.returndatatable("select * from application_settings_License", dtchk)
            If dtchk.Rows.Count > 0 Then
                txtLicenseName.Text = dtchk.Rows(0).Item("License_Name")
                txtLicenseCode.Text = dtchk.Rows(0).Item("License_Code")
                txtMaxUsers.Text = dtchk.Rows(0).Item("License_MaxUsers")
                dtpRegDate.Value = Format(dtchk.Rows(0).Item("License_Expireon"), "dd/MM/yyyy")
            End If

            dtchk = ObjClass.returndatatable("select * from application_settings_Color", dtchk)
            If dtchk.Rows.Count > 0 Then


            End If



        Else
            StrMode = "ADD"
        End If
    End Sub

    Private Sub TrackBar4_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Track_Smooth.Scroll
        GroupBox11.Text = "Smoothing filter strength[" & Track_Smooth.Value & "]"
    End Sub

    Private Sub Track_Sharp_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Track_Sharp.Scroll
        GroupBox5.Text = "Sharpness filter strength[" & Track_Sharp.Value & "]"
    End Sub

    Private Sub Track_Histogram_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Track_Histogram.Scroll
        Label6.Text = "Histogram stretch correction: [" & Track_Histogram.Value & "]"
    End Sub

    Private Sub Track_Gamma_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Track_Gamma.Scroll
        Label10.Text = "Gamma correction: [" & Format(Track_Gamma.Value / 10, "#.0") & "]"
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Normal.Click
        ColorDialog1.ShowDialog()
        Normal.BackColor = ColorDialog1.Color
    End Sub

    Private Sub Green_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Selected.Click
        ColorDialog2.ShowDialog()
        Selected.BackColor = ColorDialog2.Color
    End Sub

    Private Sub Blue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Active.Click
        ColorDialog3.ShowDialog()
        Active.BackColor = ColorDialog3.Color
    End Sub

    Private Sub outside_edge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles outside_edge.Click
        ColorDialog4.ShowDialog()
        outside_edge.BackColor = ColorDialog4.Color
    End Sub

    Private Sub btnA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnA.Click
        btnA.FlatStyle = FlatStyle.Popup
        btnB.FlatStyle = FlatStyle.Standard
        btnC.FlatStyle = FlatStyle.Standard
        btnD.FlatStyle = FlatStyle.Standard
        Dim ObjClass As New ClassFunctions()
        Dim dtchk As New DataTable()
        dtchk = ObjClass.returndatatable("select * from application_settings_superfilter where filter_category='A'", dtchk)
        If dtchk.Rows.Count > 0 Then
            trkPixel.Value = dtchk.Rows(0).Item("Filter_PixelSize")
            trkAmount.Value = dtchk.Rows(0).Item("Filter_Amount")
            trkThreshold.Value = dtchk.Rows(0).Item("Filter_Threshold")
            If dtchk.Rows(0).Item("Filter_Automatic") = "True" Then
                chkAutoUpdate.Checked = True
            Else
                chkAutoUpdate.Checked = False
            End If
        End If
    End Sub

    Private Sub btnB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnB.Click
        btnA.FlatStyle = FlatStyle.Standard
        btnB.FlatStyle = FlatStyle.Popup
        btnC.FlatStyle = FlatStyle.Standard
        btnD.FlatStyle = FlatStyle.Standard
        Dim ObjClass As New ClassFunctions()
        Dim dtchk As New DataTable()
        dtchk = ObjClass.returndatatable("select * from application_settings_superfilter where filter_category='B'", dtchk)
        If dtchk.Rows.Count > 0 Then
            trkPixel.Value = dtchk.Rows(0).Item("Filter_PixelSize")
            trkAmount.Value = dtchk.Rows(0).Item("Filter_Amount")
            trkThreshold.Value = dtchk.Rows(0).Item("Filter_Threshold")
            If dtchk.Rows(0).Item("Filter_Automatic") = "True" Then
                chkAutoUpdate.Checked = True
            Else
                chkAutoUpdate.Checked = False
            End If
        End If
    End Sub

    Private Sub btnC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC.Click
        btnA.FlatStyle = FlatStyle.Standard
        btnB.FlatStyle = FlatStyle.Standard
        btnC.FlatStyle = FlatStyle.Popup
        btnD.FlatStyle = FlatStyle.Standard
        Dim ObjClass As New ClassFunctions()
        Dim dtchk As New DataTable()
        dtchk = ObjClass.returndatatable("select * from application_settings_superfilter where filter_category='C'", dtchk)
        If dtchk.Rows.Count > 0 Then
            trkPixel.Value = dtchk.Rows(0).Item("Filter_PixelSize")
            trkAmount.Value = dtchk.Rows(0).Item("Filter_Amount")
            trkThreshold.Value = dtchk.Rows(0).Item("Filter_Threshold")
            If dtchk.Rows(0).Item("Filter_Automatic") = "True" Then
                chkAutoUpdate.Checked = True
            Else
                chkAutoUpdate.Checked = False
            End If
        End If
    End Sub

    Private Sub btnD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnD.Click
        btnA.FlatStyle = FlatStyle.Standard
        btnB.FlatStyle = FlatStyle.Standard
        btnC.FlatStyle = FlatStyle.Standard
        btnD.FlatStyle = FlatStyle.Popup
        Dim ObjClass As New ClassFunctions()
        Dim dtchk As New DataTable()
        dtchk = ObjClass.returndatatable("select * from application_settings_superfilter where filter_category='D'", dtchk)
        If dtchk.Rows.Count > 0 Then
            trkPixel.Value = dtchk.Rows(0).Item("Filter_PixelSize")
            trkAmount.Value = dtchk.Rows(0).Item("Filter_Amount")
            trkThreshold.Value = dtchk.Rows(0).Item("Filter_Threshold")
            If dtchk.Rows(0).Item("Filter_Automatic") = "True" Then
                chkAutoUpdate.Checked = True
            Else
                chkAutoUpdate.Checked = False
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
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
            cmd.CommandText = "SP_Application_Settings_General"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = StrMode
            If StrMode = "ADD" Then
                cmd.Parameters.Add(New SqlParameter("@General_Id", SqlDbType.VarChar, 7)).Value = objClass.getIndexKey()
            End If
            cmd.Parameters.Add(New SqlParameter("@General_Language", SqlDbType.VarChar, 50)).Value = cmbLanguage.Text
            cmd.Parameters.Add(New SqlParameter("@General_StartUpMonitor", SqlDbType.VarChar, 50)).Value = cmbMonitor.Text
            cmd.Parameters.Add(New SqlParameter("@General_ReopenImage", SqlDbType.VarChar, 10)).Value = chkReopen.Checked
            cmd.Parameters.Add(New SqlParameter("@General_AllowMultiple", SqlDbType.VarChar, 10)).Value = chkmultiple.Checked
            cmd.Parameters.Add(New SqlParameter("@General_Dentist", SqlDbType.VarChar, 10)).Value = chkDentist.Checked
            cmd.Parameters.Add(New SqlParameter("@General_PatientId", SqlDbType.VarChar, 10)).Value = chkPtID.Checked
            cmd.Parameters.Add(New SqlParameter("@General_PatientName", SqlDbType.VarChar, 10)).Value = chkptName.Checked
            cmd.Parameters.Add(New SqlParameter("@General_OrderNo", SqlDbType.VarChar, 10)).Value = chkOrderNo.Checked
            cmd.Parameters.Add(New SqlParameter("@General_SSNNo", SqlDbType.VarChar, 10)).Value = chkSSNNo.Checked
            cmd.Parameters.Add(New SqlParameter("@General_Label", SqlDbType.VarChar, 50)).Value = Trim(txtLabel.Text)
            cmd.Parameters.Add(New SqlParameter("@General_OpenAdmnId", SqlDbType.VarChar, 10)).Value = chkadmnID.Checked
            cmd.Parameters.Add(New SqlParameter("@General_OpenDentist", SqlDbType.VarChar, 10)).Value = chkOpenDentist.Checked
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            Dim startup As String = ""
            If rbCompare.Checked = True Then
                startup = "Compare"
            ElseIf rbXray.Checked = True Then
                startup = "Xray"
            ElseIf rbColors.Checked = True Then
                startup = "Colors"
            ElseIf rbpanoramic.Checked = True Then
                startup = "Panoramic"
            ElseIf rbProfile.Checked = True Then
                startup = "Profile"
            ElseIf rbDoc.Checked = True Then
                startup = "Documents"
            ElseIf rbFiles.Checked = True Then
                startup = "Files"
            End If
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Application_Settings_View"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = StrMode
            If StrMode = "ADD" Then
                cmd.Parameters.Add(New SqlParameter("@View_Id", SqlDbType.VarChar, 7)).Value = objClass.getIndexKey()
            End If
            cmd.Parameters.Add(New SqlParameter("@View_ImageId", SqlDbType.VarChar, 10)).Value = chkImageid.Checked
            cmd.Parameters.Add(New SqlParameter("@View_CreationDate", SqlDbType.VarChar, 10)).Value = chkCreationDate.Checked
            cmd.Parameters.Add(New SqlParameter("@View_ImageNotes", SqlDbType.VarChar, 10)).Value = chkImageNotes.Checked
            cmd.Parameters.Add(New SqlParameter("@View_ToothPositions", SqlDbType.VarChar, 10)).Value = chkPositions.Checked
            cmd.Parameters.Add(New SqlParameter("@View_ImageId1", SqlDbType.VarChar, 10)).Value = chkImageID1.Checked
            cmd.Parameters.Add(New SqlParameter("@View_CreationDate1", SqlDbType.VarChar, 10)).Value = chkCreationDate1.Checked
            cmd.Parameters.Add(New SqlParameter("@View_ImageNotes1", SqlDbType.VarChar, 10)).Value = chkImageNotes1.Checked
            cmd.Parameters.Add(New SqlParameter("@View_ToothPositions1", SqlDbType.VarChar, 10)).Value = chkPositions1.Checked
            cmd.Parameters.Add(New SqlParameter("@View_ImageId2", SqlDbType.VarChar, 10)).Value = chkImageid2.Checked
            cmd.Parameters.Add(New SqlParameter("@View_CreationDate2", SqlDbType.VarChar, 10)).Value = chkCreationDate2.Checked
            cmd.Parameters.Add(New SqlParameter("@View_ImageNotes2", SqlDbType.VarChar, 10)).Value = chkImageNotes2.Checked
            cmd.Parameters.Add(New SqlParameter("@View_ToothPositions2", SqlDbType.VarChar, 10)).Value = chkPositions2.Checked
            cmd.Parameters.Add(New SqlParameter("@View_StartupView", SqlDbType.VarChar, 10)).Value = startup
            cmd.Parameters.Add(New SqlParameter("@View_SplitMode", SqlDbType.VarChar, 50)).Value = cmbSplitMode.Text
            cmd.Parameters.Add(New SqlParameter("@View_AgeWithImage", SqlDbType.VarChar, 10)).Value = chkWithImage.Checked
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            Dim histogram As String = ""
            If rb1.Checked = True Then
                histogram = "1.0"
            ElseIf rb2.Checked = True Then
                histogram = "2.0"
            End If
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Application_Settings_Image"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = StrMode
            If StrMode = "ADD" Then
                cmd.Parameters.Add(New SqlParameter("@Image_Id", SqlDbType.VarChar, 7)).Value = objClass.getIndexKey()
            End If
            cmd.Parameters.Add(New SqlParameter("@Image_Histogram", SqlDbType.VarChar, 10)).Value = Track_Histogram.Value
            cmd.Parameters.Add(New SqlParameter("@Image_Gamma", SqlDbType.VarChar, 10)).Value = Track_Gamma.Value
            cmd.Parameters.Add(New SqlParameter("@Image_Sharpness", SqlDbType.VarChar, 10)).Value = Track_Sharp.Value
            cmd.Parameters.Add(New SqlParameter("@Image_Smoothing", SqlDbType.VarChar, 10)).Value = Track_Smooth.Value
            cmd.Parameters.Add(New SqlParameter("@Image_HistogramVersion", SqlDbType.VarChar, 10)).Value = histogram
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            Dim NewMode As String = ""
            Dim id As String = ""
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Application_Settings_SuperFilter"
            cmd.Connection = con
            Dim dtchk As New DataTable()
            Dim selection As String = ""
            If btnA.FlatStyle = FlatStyle.Popup Then
                selection = btnA.Text
            ElseIf btnB.FlatStyle = FlatStyle.Popup Then
                selection = btnB.Text
            ElseIf btnC.FlatStyle = FlatStyle.Popup Then
                selection = btnC.Text
            ElseIf btnD.FlatStyle = FlatStyle.Popup Then
                selection = btnD.Text
            End If
            dtchk = objClass.returndatatable("select * from application_settings_superfilter where filter_category='" & selection & "'", dtchk)
            If dtchk.Rows.Count > 0 Then
                NewMode = "MODIFY"
                id = dtchk.Rows(0).Item("filter_id")
            Else
                NewMode = "ADD"
            End If
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = NewMode
            If NewMode = "ADD" Then
                cmd.Parameters.Add(New SqlParameter("@Filter_Id", SqlDbType.VarChar, 7)).Value = objClass.getIndexKey()
            ElseIf NewMode = "MODIFY" Then
                cmd.Parameters.Add(New SqlParameter("@Filter_Id", SqlDbType.VarChar, 7)).Value = id
            End If
            cmd.Parameters.Add(New SqlParameter("@Filter_Category", SqlDbType.VarChar, 50)).Value = selection
            cmd.Parameters.Add(New SqlParameter("@Filter_PixelSize", SqlDbType.VarChar, 50)).Value = trkPixel.Value
            cmd.Parameters.Add(New SqlParameter("@Filter_Amount", SqlDbType.VarChar, 50)).Value = trkAmount.Value
            cmd.Parameters.Add(New SqlParameter("@Filter_Threshold", SqlDbType.VarChar, 50)).Value = trkThreshold.Value
            cmd.Parameters.Add(New SqlParameter("@Filter_Automatic", SqlDbType.VarChar, 10)).Value = chkAutoUpdate.Checked
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()




            
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Application_Settings_Color"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = StrMode
            cmd.Parameters.Add(New SqlParameter("@Color_Id", SqlDbType.VarChar, 7)).Value = objClass.getIndexKey()
            cmd.Parameters.Add(New SqlParameter("@Color_Normal", SqlDbType.VarChar, 50)).Value = Normal.BackColor.Name
            cmd.Parameters.Add(New SqlParameter("@Color_Selected", SqlDbType.VarChar, 50)).Value = Selected.BackColor.Name
            cmd.Parameters.Add(New SqlParameter("@Color_Active", SqlDbType.VarChar, 50)).Value = Active.BackColor.Name
            cmd.Parameters.Add(New SqlParameter("@Color_OutsideEdge", SqlDbType.VarChar, 50)).Value = outside_edge.BackColor.Name
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Application_Settings_Sound"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = StrMode
            If StrMode = "ADD" Then
                cmd.Parameters.Add(New SqlParameter("@Sound_Id", SqlDbType.VarChar, 7)).Value = objClass.getIndexKey()
            End If
            cmd.Parameters.Add(New SqlParameter("@Sound_On", SqlDbType.VarChar, 10)).Value = CheckBox11.Checked
            cmd.Parameters.Add(New SqlParameter("@Sound_Startup", SqlDbType.VarChar, 100)).Value = txtSound_StartUp.Text
            cmd.Parameters.Add(New SqlParameter("@Sound_OpenPatient", SqlDbType.VarChar, 100)).Value = txtSoundOpenPt.Text
            cmd.Parameters.Add(New SqlParameter("@Sound_NewPatient", SqlDbType.VarChar, 100)).Value = txtNewPatient.Text
            cmd.Parameters.Add(New SqlParameter("@Sound_NewPhoto", SqlDbType.VarChar, 100)).Value = txtNewPhoto.Text
            cmd.Parameters.Add(New SqlParameter("@Sound_LoadPhoto", SqlDbType.VarChar, 100)).Value = txtLoadPhoto.Text
            cmd.Parameters.Add(New SqlParameter("@Sound_ReadytoExpose", SqlDbType.VarChar, 100)).Value = txtExpose.Text
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Application_Settings_License"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = StrMode
            If StrMode = "ADD" Then
                cmd.Parameters.Add(New SqlParameter("@License_Id", SqlDbType.VarChar, 7)).Value = objClass.getIndexKey()
            End If
            cmd.Parameters.Add(New SqlParameter("@License_Name", SqlDbType.VarChar, 50)).Value = txtLicenseName.Text
            cmd.Parameters.Add(New SqlParameter("@License_Code", SqlDbType.VarChar, 50)).Value = txtLicenseCode.Text
            cmd.Parameters.Add(New SqlParameter("@License_MaxUsers", SqlDbType.VarChar, 50)).Value = txtMaxUsers.Text
            cmd.Parameters.Add(New SqlParameter("@License_ExpireOn", SqlDbType.DateTime)).Value = Format(dtpRegDate.Value, "yyyy-MM-dd")
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Track_Histogram_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Track_Histogram.ValueChanged
        Label6.Text = "Histogram stretch correction: [" & Track_Histogram.Value & "]"
    End Sub

    Private Sub Track_Gamma_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Track_Gamma.ValueChanged
        Label10.Text = "Gamma correction: [" & Format(Track_Gamma.Value / 10, "#.0") & "]"
    End Sub

    Private Sub Track_Sharp_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Track_Sharp.ValueChanged
        GroupBox5.Text = "Sharpness filter strength[" & Track_Sharp.Value & "]"
    End Sub

    Private Sub Track_Smooth_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Track_Smooth.ValueChanged
        GroupBox11.Text = "Smoothing filter strength[" & Track_Smooth.Value & "]"
    End Sub

    Private Sub btnFromDisk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromDisk.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub btnStartup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartup.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.txtSound_StartUp.Text = OpenFileDialog1.FileName
        End If

    End Sub

    Private Sub btnOpenPt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenPt.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.txtSoundOpenPt.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnOpenNewPt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenNewPt.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.txtNewPatient.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnOpenPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenPhoto.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.txtNewPhoto.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnLoadPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPhoto.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.txtLoadPhoto.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnReady_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReady.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.txtExpose.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnStartup_Play_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartup_Play.Click
        Me.AxWindowsMediaPlayer1.URL = txtSound_StartUp.Text
        btnStartup_Stop.Visible = True
    End Sub

    Private Sub btnStartup_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartup_Stop.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        btnStartup_Stop.Visible = False
    End Sub

    Private Sub btnOpenPt_Play_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenPt_Play.Click
        Me.AxWindowsMediaPlayer1.URL = txtSoundOpenPt.Text
        btnOpenPt_Stop.Visible = True
    End Sub

    Private Sub btnOpenPt_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenPt_Stop.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        btnOpenPt_Stop.Visible = False
    End Sub

    Private Sub btnOpenNewPt_Play_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenNewPt_Play.Click
        Me.AxWindowsMediaPlayer1.URL = txtNewPatient.Text
        btnOpenNewPt_Stop.Visible = True
    End Sub

    Private Sub btnOpenNewPt_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenNewPt_Stop.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        btnOpenNewPt_Stop.Visible = False
    End Sub

    Private Sub btnOpenPhoto_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenPhoto_Stop.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        btnOpenPhoto_Stop.Visible = False
    End Sub

    Private Sub btnLoadPhoto_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPhoto_Stop.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        btnLoadPhoto_Stop.Visible = False
    End Sub

    Private Sub btnReady_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReady_Stop.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        btnReady_Stop.Visible = False
    End Sub

    Private Sub btnOpenPhoto_Play_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenPhoto_Play.Click
        Me.AxWindowsMediaPlayer1.URL = txtNewPhoto.Text
        btnOpenPhoto_Stop.Visible = True
    End Sub

    Private Sub btnLoadPhoto_Play_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPhoto_Play.Click
        Me.AxWindowsMediaPlayer1.URL = txtLoadPhoto.Text
        btnLoadPhoto_Stop.Visible = True
    End Sub

    Private Sub btnReady_Play_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReady_Play.Click
        Me.AxWindowsMediaPlayer1.URL = txtExpose.Text
        btnReady_Stop.Visible = True
    End Sub
End Class