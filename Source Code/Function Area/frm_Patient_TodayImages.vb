Imports System.Windows.Forms
Imports System.Drawing.Point
Imports System.Drawing.Color
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Collections.Generic
Public Class frm_Patient_TodayImages

    Private Sub frm_Patient_TodayImages_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CenterToScreen()
        Dim ObjClass As New ClassFunctions()
        Dim fullpath As String
        Dim folder As String
        Dim dt As New DataTable()
        Dim dt1 As New DataTable()
        Dim dt2 As New DataTable()

        Dim i As Integer
        Dim pdate As Date
     
        pdate = ObjClass.GetCurrentDate()
            dt = ObjClass.returndatatable("select * from patient_Image where image_isdeleted='0' and image_d='" + Format(pdate, "yyyy-MM-dd") + "'", dt)
            If dt.Rows.Count > 0 Then


                Dim Top As Integer = 0
                Dim count As Integer = 0
                For i = 0 To dt.Rows.Count - 1
                    folder = ObjClass.ReturnFieldName("select ptReg_code from Master_ptReg where ptreg_id='" + dt.Rows(i).Item("image_ptregid").ToString() + "'")

                    'dt1 = ObjClass.returndatatable("select * from Master_ptReg", dt1)
                    'folder = dt1.Rows(i).Item("ptReg_code").ToString()

                    fullpath = Application.StartupPath & "\Images\" & folder
                    Dim FileDirectory As New IO.DirectoryInfo(fullpath)
                    Dim FileJpg As IO.FileInfo() = FileDirectory.GetFiles("*.jpg")
                    'Dim FileGif As IO.FileInfo() = FileDirectory.GetFiles("*.gif")
                    'Dim FileBmp As IO.FileInfo() = FileDirectory.GetFiles("*.bmp")

                    For Each File As IO.FileInfo In FileJpg
                        If (File.Name = dt.Rows(i).Item("image_path").ToString()) Then
                            dt1 = ObjClass.returndatatable("select * from Master_ptReg where ptreg_id='" + dt.Rows(i).Item("image_ptregid").ToString() + "'", dt1)

                            Dim PicBox As New PictureBox
                            Dim lbl As New Label
                            Dim patinfo As New Label
                            Dim patname As New Label
                            Dim dob As New Label
                            Dim lblNotes As New Label
                            PicBox.ImageLocation = fullpath & "\" & File.Name
                            PicBox.Width = 100
                            PicBox.Height = 50
                            PicBox.Top = 35 + Top
                            PicBox.Left = 8
                            PicBox.SizeMode = PictureBoxSizeMode.Zoom
                            PicBox.BorderStyle = BorderStyle.FixedSingle
                            ''PicBox.ContextMenuStrip = ContextMenuStrip2
                        PicBox.Tag = dt.Rows(i).Item("image_id").ToString() 'PicBox.ImageLocation
                            PicBox.AllowDrop = True
                            PicBox.BorderStyle = BorderStyle.None

                        patinfo.Text = "Patient Id:" + dt1.Rows(0).Item("ptReg_regno").ToString()

                            patinfo.Top = 35 + Top
                            patinfo.Left = 110
                            patinfo.Width = 105
                            patinfo.ForeColor = Black
                            patinfo.Height = 15
                        patname.Text = "Name:" + dt1.Rows(0).Item("ptReg_firstname").ToString() + " " + dt1.Rows(0).Item("ptReg_lastname").ToString()

                            patname.Top = patinfo.Top + patinfo.Height

                        patname.Left = 110
                            patname.Width = 105
                            patname.ForeColor = Black
                            patname.Height = 15

                        dob.Text = "DOB:" + dt1.Rows(0).Item("ptReg_dob").ToString()

                            dob.Top = patname.Top + patname.Height

                            dob.Left = 110
                            dob.Width = 105
                            dob.ForeColor = Black
                            dob.Height = 15


                            lbl.Text = ObjClass.ReturnFieldName("select image_name from patient_image where  image_path='" & File.Name & "'")
                            lbl.Top = PicBox.Top + PicBox.Height + 5
                            lbl.Left = 5
                            lbl.Width = 105
                            lbl.ForeColor = Black
                            Dim strDate = PicBox.ImageLocation
                            'strDate = System.IO.File.GetLastWriteTime(strDate).ToShortDateString()
                            strDate = ObjClass.ReturnFieldName("select image_d from patient_image where  image_path='" & File.Name & "'")
                            lbl.Text = lbl.Text & "  " & strDate
                            lbl.Height = 12
                            Me.GroupBox1.Controls.Add(PicBox)
                            Me.GroupBox1.Controls.Add(lbl)
                            Me.GroupBox1.Controls.Add(patinfo)
                            Me.GroupBox1.Controls.Add(patname)
                            Me.GroupBox1.Controls.Add(dob)
                            lblNotes.Text = ObjClass.ReturnFieldName("select image_Notes from patient_image where image_path='" & PicBox.ImageLocation & "'")

                            lblNotes.Top = PicBox.Top + PicBox.Height + lbl.Height + 10
                            lblNotes.Left = 5
                            lblNotes.Width = 105
                            lblNotes.ForeColor = Black
                            lblNotes.Height = 15
                            Me.GroupBox1.Controls.Add(lblNotes)
                            'Me.GroupBox2.Controls.Add(lblDt)
                            Top = PicBox.Top + 60

                        AddHandler PicBox.DoubleClick, AddressOf picBox_Onclick
                            ''AddHandler PicBox.MouseDown, AddressOf PicBox_mousedown
                            ''AddHandler PicBox.MouseMove, AddressOf PicBox_MouseMove
                            ''AddHandler PicBox.DragEnter, AddressOf PicBox_DragEnter
                            If PicBox.Top + 200 > Me.Height Then
                                Panel1.AutoScroll = True
                            End If
                            count = count + 1
                        End If
                    Next
                Next
            '  grp2X.Visible = True
            End If
    End Sub
    Private Sub picBox_Onclick(ByVal sender As Object, ByVal e As EventArgs)
        Dim pic1 As PictureBox = DirectCast(sender, PictureBox)
        Dim dt As New DataTable()
        Dim ObjClass As New ClassFunctions()
        dt = ObjClass.returndatatable("select * from patient_image inner join master_ptreg on ptreg_id=image_ptregid where image_id='" & pic1.Tag & "'", dt)
        If dt.Rows.Count > 0 Then
            PatientId = dt.Rows(0).Item("image_ptregid")
            frm_MainScreen.Text = "LynxVision Professional - " & dt.Rows(0).Item("ptReg_FirstName") & " " & dt.Rows(0).Item("ptReg_LastName")
            Call frm_MainScreen.FillDetails()
            If frm_MainScreen.grpViewer.Visible = True Then
                Dim con As Control
                For controlIndex As Integer = Me.GroupBox2.Controls.Count - 1 To 0 Step -1
                    con = Me.GroupBox2.Controls(controlIndex)
                    If TypeOf con Is PictureBox Then
                        Me.GroupBox2.Controls.Remove(con)
                    End If
                    If TypeOf con Is Label Then
                        Me.GroupBox2.Controls.Remove(con)
                    End If
                Next
            End If
            frm_MainScreen.Panel2.Width = 110
            frm_MainScreen.GroupBox2.Width = 114
            frm_MainScreen.Panel3.Left = 110
            frm_MainScreen.Panel3.Width = frm_MainScreen.Width - frm_MainScreen.Panel2.Width
            frm_MainScreen.grp1X.Visible = True
            frm_MainScreen.grp4X.Visible = False
            frm_MainScreen.grp2X.Visible = False
            frm_MainScreen.grp9X.Visible = False
            frm_MainScreen.grp16X.Visible = False
            frm_MainScreen.grpFullMouth.Visible = False
            frm_MainScreen.GroupBox3.Visible = False
            frm_MainScreen.grpViewer.Visible = False
            frm_MainScreen.btnImport.Visible = False
            frm_MainScreen.Pic_1_grp1X.ImageLocation = Application.StartupPath & "\Images\" & dt.Rows(0).Item("ptReg_code") & "\" & dt.Rows(0).Item("image_path")
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim ObjClass As New ClassFunctions()
        Dim fullpath As String
        Dim folder As String
        Dim dt As New DataTable()
        Dim dt1 As New DataTable()
        Dim dt2 As New DataTable()
        Dim ptStatus As String
        Dim i As Integer
        Dim pdate As Date
        Dim sdate As Date
        Dim ddate As Date

        pdate = ObjClass.GetCurrentDate()

        sdate = ObjClass.GetCurrentDate().AddDays(-7)
        ddate = ObjClass.GetCurrentDate().AddDays(-31)


        If TabControl1.SelectedIndex = 0 Then



            dt = ObjClass.returndatatable("select * from patient_Image where image_isdeleted='0' and image_d='" + Format(pdate, "yyyy-MM-dd") + "'", dt)
            If dt.Rows.Count > 0 Then


                Dim Top As Integer = 0
                Dim count As Integer = 0
                For i = 0 To dt.Rows.Count - 1
                    folder = ObjClass.ReturnFieldName("select ptReg_code from Master_ptReg where ptreg_id='" + dt.Rows(i).Item("image_ptregid").ToString() + "'")

                    'dt1 = ObjClass.returndatatable("select * from Master_ptReg", dt1)
                    'folder = dt1.Rows(i).Item("ptReg_code").ToString()

                    fullpath = Application.StartupPath & "\Images\" & folder
                    Dim FileDirectory As New IO.DirectoryInfo(fullpath)
                    Dim FileJpg As IO.FileInfo() = FileDirectory.GetFiles("*.jpg")
                    'Dim FileGif As IO.FileInfo() = FileDirectory.GetFiles("*.gif")
                    'Dim FileBmp As IO.FileInfo() = FileDirectory.GetFiles("*.bmp")

                    For Each File As IO.FileInfo In FileJpg
                        If (File.Name = dt.Rows(i).Item("image_path").ToString()) Then
                            dt1 = ObjClass.returndatatable("select * from Master_ptReg where ptreg_id='" + dt.Rows(i).Item("image_ptregid").ToString() + "'", dt1)

                            Dim PicBox As New PictureBox
                            Dim lbl As New Label
                            Dim patinfo As New Label
                            Dim patname As New Label
                            Dim dob As New Label
                            Dim lblNotes As New Label
                            PicBox.ImageLocation = fullpath & "\" & File.Name
                            PicBox.Width = 100
                            PicBox.Height = 50
                            PicBox.Top = 35 + Top
                            PicBox.Left = 8
                            PicBox.SizeMode = PictureBoxSizeMode.Zoom
                            PicBox.BorderStyle = BorderStyle.FixedSingle
                            ''PicBox.ContextMenuStrip = ContextMenuStrip2
                            PicBox.Tag = dt.Rows(i).Item("image_id").ToString() 'PicBox.ImageLocation
                            PicBox.AllowDrop = True
                            PicBox.BorderStyle = BorderStyle.None

                            patinfo.Text = "Patient Id:" + dt1.Rows(i).Item("ptReg_regno").ToString()

                            patinfo.Top = 35 + Top
                            patinfo.Left = 110
                            patinfo.Width = 105
                            patinfo.ForeColor = Black
                            patinfo.Height = 15



                            patname.Text = "Name:" + dt1.Rows(i).Item("ptReg_firstname").ToString() + " " + dt1.Rows(i).Item("ptReg_lastname").ToString()

                            patname.Top = patinfo.Top + patinfo.Height

                            patname.Left = 110
                            patname.Width = 105
                            patname.ForeColor = Black
                            patname.Height = 15

                            dob.Text = "DOB:" + dt1.Rows(i).Item("ptReg_dob").ToString()

                            dob.Top = patname.Top + patname.Height

                            dob.Left = 110
                            dob.Width = 105
                            dob.ForeColor = Black
                            dob.Height = 15


                            lbl.Text = ObjClass.ReturnFieldName("select image_name from patient_image where  image_path='" & File.Name & "'")
                            lbl.Top = PicBox.Top + PicBox.Height + 5
                            lbl.Left = 5
                            lbl.Width = 105
                            lbl.ForeColor = Black
                            Dim strDate = PicBox.ImageLocation
                            'strDate = System.IO.File.GetLastWriteTime(strDate).ToShortDateString()
                            strDate = ObjClass.ReturnFieldName("select image_d from patient_image where  image_path='" & File.Name & "'")
                            lbl.Text = lbl.Text & "  " & strDate
                            lbl.Height = 12
                            Me.GroupBox1.Controls.Add(PicBox)
                            Me.GroupBox1.Controls.Add(lbl)
                            Me.GroupBox1.Controls.Add(patinfo)
                            Me.GroupBox1.Controls.Add(patname)
                            Me.GroupBox1.Controls.Add(dob)
                            lblNotes.Text = ObjClass.ReturnFieldName("select image_Notes from patient_image where image_path='" & PicBox.ImageLocation & "'")

                            lblNotes.Top = PicBox.Top + PicBox.Height + lbl.Height + 10
                            lblNotes.Left = 5
                            lblNotes.Width = 105
                            lblNotes.ForeColor = Black
                            lblNotes.Height = 15
                            Me.GroupBox1.Controls.Add(lblNotes)
                            'Me.GroupBox2.Controls.Add(lblDt)
                            Top = PicBox.Top + 60

                            AddHandler PicBox.DoubleClick, AddressOf picBox_Onclick
                            ''AddHandler PicBox.MouseDown, AddressOf PicBox_mousedown
                            ''AddHandler PicBox.MouseMove, AddressOf PicBox_MouseMove
                            ''AddHandler PicBox.DragEnter, AddressOf PicBox_DragEnter
                            If PicBox.Top + 200 > Me.Height Then
                                Panel1.AutoScroll = True
                            End If
                            count = count + 1
                        End If
                    Next
                Next

                '  grp2X.Visible = True
            End If

        End If
        If TabControl1.SelectedIndex = 1 Then
            dt = ObjClass.returndatatable("select * from patient_Image where image_isdeleted='0' and image_d between '" + Format(sdate, "yyyy-MM-dd") + "' and '" + Format(pdate, "yyyy-MM-dd") + "'", dt)
            If dt.Rows.Count > 0 Then


                Dim Top As Integer = 0
                Dim count As Integer = 0
                For i = 0 To dt.Rows.Count - 1
                    folder = ObjClass.ReturnFieldName("select ptReg_code from Master_ptReg where ptreg_id='" + dt.Rows(i).Item("image_ptregid").ToString() + "'")

                    'dt1 = ObjClass.returndatatable("select * from Master_ptReg", dt1)
                    'folder = dt1.Rows(i).Item("ptReg_code").ToString()

                    fullpath = Application.StartupPath & "\Images\" & folder
                    Dim FileDirectory As New IO.DirectoryInfo(fullpath)
                    Dim FileJpg As IO.FileInfo() = FileDirectory.GetFiles("*.jpg")
                    'Dim FileGif As IO.FileInfo() = FileDirectory.GetFiles("*.gif")
                    'Dim FileBmp As IO.FileInfo() = FileDirectory.GetFiles("*.bmp")

                    For Each File As IO.FileInfo In FileJpg
                        If (File.Name = dt.Rows(i).Item("image_path").ToString()) Then
                            dt1 = ObjClass.returndatatable("select * from Master_ptReg where ptreg_id='" + dt.Rows(i).Item("image_ptregid").ToString() + "'", dt1)

                            Dim PicBox As New PictureBox
                            Dim lbl As New Label
                            Dim patinfo As New Label
                            Dim patname As New Label
                            Dim dob As New Label
                            Dim lblNotes As New Label
                            PicBox.ImageLocation = fullpath & "\" & File.Name
                            PicBox.Width = 100
                            PicBox.Height = 50
                            PicBox.Top = 35 + Top
                            PicBox.Left = 8
                            PicBox.SizeMode = PictureBoxSizeMode.Zoom
                            PicBox.BorderStyle = BorderStyle.FixedSingle
                            ''PicBox.ContextMenuStrip = ContextMenuStrip2
                            PicBox.Tag = dt.Rows(i).Item("image_id").ToString() 'PicBox.ImageLocation
                            PicBox.AllowDrop = True
                            PicBox.BorderStyle = BorderStyle.None

                            patinfo.Text = "Patient Id:" + dt1.Rows(0).Item("ptReg_regno").ToString()

                            patinfo.Top = 35 + Top
                            patinfo.Left = 110
                            patinfo.Width = 105
                            patinfo.ForeColor = Black
                            patinfo.Height = 15



                            patname.Text = "Name:" + dt1.Rows(0).Item("ptReg_firstname").ToString() + " " + dt1.Rows(0).Item("ptReg_lastname").ToString()

                            patname.Top = patinfo.Top + patinfo.Height

                            patname.Left = 110
                            patname.Width = 105
                            patname.ForeColor = Black
                            patname.Height = 15

                            dob.Text = "DOB:" + dt1.Rows(0).Item("ptReg_dob").ToString()

                            dob.Top = patname.Top + patname.Height

                            dob.Left = 110
                            dob.Width = 105
                            dob.ForeColor = Black
                            dob.Height = 15


                            lbl.Text = ObjClass.ReturnFieldName("select image_name from patient_image where  image_path='" & File.Name & "'")
                            lbl.Top = PicBox.Top + PicBox.Height + 5
                            lbl.Left = 5
                            lbl.Width = 105
                            lbl.ForeColor = Black
                            Dim strDate = PicBox.ImageLocation
                            'strDate = System.IO.File.GetLastWriteTime(strDate).ToShortDateString()
                            strDate = ObjClass.ReturnFieldName("select image_d from patient_image where  image_path='" & File.Name & "'")
                            lbl.Text = lbl.Text & "  " & strDate
                            lbl.Height = 12
                            Me.GroupBox2.Controls.Add(PicBox)
                            Me.GroupBox2.Controls.Add(lbl)
                            Me.GroupBox2.Controls.Add(patinfo)
                            Me.GroupBox2.Controls.Add(patname)
                            Me.GroupBox2.Controls.Add(dob)
                            lblNotes.Text = ObjClass.ReturnFieldName("select image_Notes from patient_image where image_path='" & PicBox.ImageLocation & "'")

                            lblNotes.Top = PicBox.Top + PicBox.Height + lbl.Height + 10
                            lblNotes.Left = 5
                            lblNotes.Width = 105
                            lblNotes.ForeColor = Black
                            lblNotes.Height = 15
                            Me.GroupBox2.Controls.Add(lblNotes)
                            'Me.GroupBox2.Controls.Add(lblDt)
                            Top = PicBox.Top + 60

                            AddHandler PicBox.DoubleClick, AddressOf picBox_Onclick
                            ''AddHandler PicBox.MouseDown, AddressOf PicBox_mousedown
                            ''AddHandler PicBox.MouseMove, AddressOf PicBox_MouseMove
                            ''AddHandler PicBox.DragEnter, AddressOf PicBox_DragEnter
                            If PicBox.Top + 200 > Me.Height Then
                                Panel2.AutoScroll = True
                            End If
                            count = count + 1
                        End If
                    Next
                Next

                '  grp2X.Visible = True
            End If

        End If
        If TabControl1.SelectedIndex = 2 Then

            dt = ObjClass.returndatatable("select * from patient_Image where image_isdeleted='0' and image_d between '" + Format(ddate, "yyyy-MM-dd") + "' and '" + Format(pdate, "yyyy-MM-dd") + "'", dt)
            If dt.Rows.Count > 0 Then


                Dim Top As Integer = 0
                Dim count As Integer = 0
                For i = 0 To dt.Rows.Count - 1
                    folder = ObjClass.ReturnFieldName("select ptReg_code from Master_ptReg where ptreg_id='" + dt.Rows(i).Item("image_ptregid").ToString() + "'")

                    'dt1 = ObjClass.returndatatable("select * from Master_ptReg", dt1)
                    'folder = dt1.Rows(i).Item("ptReg_code").ToString()

                    fullpath = Application.StartupPath & "\Images\" & folder
                    Dim FileDirectory As New IO.DirectoryInfo(fullpath)
                    Dim FileJpg As IO.FileInfo() = FileDirectory.GetFiles("*.jpg")
                    'Dim FileGif As IO.FileInfo() = FileDirectory.GetFiles("*.gif")
                    'Dim FileBmp As IO.FileInfo() = FileDirectory.GetFiles("*.bmp")

                    For Each File As IO.FileInfo In FileJpg
                        If (File.Name = dt.Rows(i).Item("image_path").ToString()) Then
                            dt1 = ObjClass.returndatatable("select * from Master_ptReg where ptreg_id='" + dt.Rows(i).Item("image_ptregid").ToString() + "'", dt1)

                            Dim PicBox As New PictureBox
                            Dim lbl As New Label
                            Dim patinfo As New Label
                            Dim patname As New Label
                            Dim dob As New Label
                            Dim lblNotes As New Label
                            PicBox.ImageLocation = fullpath & "\" & File.Name
                            PicBox.Width = 100
                            PicBox.Height = 50
                            PicBox.Top = 35 + Top
                            PicBox.Left = 8
                            PicBox.SizeMode = PictureBoxSizeMode.Zoom
                            PicBox.BorderStyle = BorderStyle.FixedSingle
                            ''PicBox.ContextMenuStrip = ContextMenuStrip2
                            PicBox.Tag = dt.Rows(i).Item("image_id").ToString() ' PicBox.ImageLocation
                            PicBox.AllowDrop = True
                            PicBox.BorderStyle = BorderStyle.None

                            patinfo.Text = "Patient Id:" + dt1.Rows(0).Item("ptReg_regno").ToString()

                            patinfo.Top = 35 + Top
                            patinfo.Left = 110
                            patinfo.Width = 105
                            patinfo.ForeColor = Black
                            patinfo.Height = 15



                            patname.Text = "Name:" + dt1.Rows(0).Item("ptReg_firstname").ToString() + " " + dt1.Rows(0).Item("ptReg_lastname").ToString()

                            patname.Top = patinfo.Top + patinfo.Height

                            patname.Left = 110
                            patname.Width = 105
                            patname.ForeColor = Black
                            patname.Height = 15

                            dob.Text = "DOB:" + dt1.Rows(0).Item("ptReg_dob").ToString()

                            dob.Top = patname.Top + patname.Height

                            dob.Left = 110
                            dob.Width = 105
                            dob.ForeColor = Black
                            dob.Height = 15


                            lbl.Text = ObjClass.ReturnFieldName("select image_name from patient_image where  image_path='" & File.Name & "'")
                            lbl.Top = PicBox.Top + PicBox.Height + 5
                            lbl.Left = 5
                            lbl.Width = 105
                            lbl.ForeColor = Black
                            Dim strDate = PicBox.ImageLocation
                            'strDate = System.IO.File.GetLastWriteTime(strDate).ToShortDateString()
                            strDate = ObjClass.ReturnFieldName("select image_d from patient_image where  image_path='" & File.Name & "'")
                            lbl.Text = lbl.Text & "  " & strDate
                            lbl.Height = 12
                            Me.GroupBox3.Controls.Add(PicBox)
                            Me.GroupBox3.Controls.Add(lbl)
                            Me.GroupBox3.Controls.Add(patinfo)
                            Me.GroupBox3.Controls.Add(patname)
                            Me.GroupBox3.Controls.Add(dob)
                            lblNotes.Text = ObjClass.ReturnFieldName("select image_Notes from patient_image where image_path='" & PicBox.ImageLocation & "'")

                            lblNotes.Top = PicBox.Top + PicBox.Height + lbl.Height + 10
                            lblNotes.Left = 5
                            lblNotes.Width = 105
                            lblNotes.ForeColor = Black
                            lblNotes.Height = 15
                            Me.GroupBox3.Controls.Add(lblNotes)
                            'Me.GroupBox2.Controls.Add(lblDt)
                            Top = PicBox.Top + 60

                            AddHandler PicBox.DoubleClick, AddressOf picBox_Onclick
                            ''AddHandler PicBox.MouseDown, AddressOf PicBox_mousedown
                            ''AddHandler PicBox.MouseMove, AddressOf PicBox_MouseMove
                            ''AddHandler PicBox.DragEnter, AddressOf PicBox_DragEnter
                            If PicBox.Top + 200 > Me.Height Then
                                Panel3.AutoScroll = True
                            End If
                            count = count + 1
                        End If
                    Next
                Next

                '  grp2X.Visible = True
            End If

        End If

    End Sub


   
End Class