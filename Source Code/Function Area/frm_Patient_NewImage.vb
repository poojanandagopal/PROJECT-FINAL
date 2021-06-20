Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Collections.Generic

Public Class frm_Patient_NewImage
    Dim bmap As Bitmap
    Private _originalSize As Size = Nothing
    Private _scale As Single = 1
    Private _scaleDelta As Single = 0.0005
    Dim TeethNo As Integer = 0

    Private Sub frm_Patient_NewImage_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Panel3.Visible = False
            Teeth.Text = ""
        End If
    End Sub

    Private Sub frm_Patient_NewImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Me.CenterToScreen()
        Me.Top = 30
        Me.Left = 200
        PictureBox1.Visible = False
        Panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#10183D")
        Panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#10183D")
        If My.Computer.Clipboard.ContainsImage Then
            TSBPaste.Enabled = True
            PasteToolStripMenuItem.Enabled = True
        Else
            TSBPaste.Enabled = False
            PasteToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If PictureBox1.Image Is Nothing Then
            MsgBox("No Image Found!")
        Else
            Call SaveData()
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Panel3.Visible = False
        Teeth.Text = ""
        Me.Close()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.Click
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.FileName = "Photo"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        PictureBox1.ImageLocation = OpenFileDialog1.FileName
        Dim strFilepath = PictureBox1.ImageLocation  
        dtpRegDate.Value = System.IO.File.GetLastWriteTime(strFilepath).ToShortDateString()
        Panel3.Visible = False
        txtNotes.Enabled = True
        PictureBox1.BringToFront()
        Panel2.Visible = False
        PictureBox1.Visible = True
        If PictureBox1.Image Is Nothing Then
        Else
            TSBCopy.Enabled = True
            ToolStripMenuItem1.Enabled = True
        End If
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        If PictureBox1.Image Is Nothing Then
            MsgBox("No Image Found!")
        Else
            PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            PictureBox1.Width = Convert.ToInt32(PictureBox1.Height * PictureBox1.Image.Width / PictureBox1.Image.Height)
            PictureBox1.Width = 797
            PictureBox1.Height = 506
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        End If
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        If PictureBox1.Image Is Nothing Then
            MsgBox("No Image Found!")
        Else
            PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            PictureBox1.Width = Convert.ToInt32(PictureBox1.Height * PictureBox1.Image.Width / PictureBox1.Image.Height)
            PictureBox1.Width = 797
            PictureBox1.Height = 506
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        End If
    End Sub

    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        If PictureBox1.Image Is Nothing Then
            MsgBox("No Image Found!")
        Else
            PictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            PictureBox1.Width = Convert.ToInt32(PictureBox1.Height * PictureBox1.Image.Width / PictureBox1.Image.Height)
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            PictureBox1.Width = 797
            PictureBox1.Height = 506
        End If
    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        If PictureBox1.Image Is Nothing Then
            MsgBox("No Image Found!")
        Else
            PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            PictureBox1.Refresh()
        End If
    End Sub

    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click
        If PictureBox1.Image Is Nothing Then
            MsgBox("No Image Found!")
        Else
            PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            PictureBox1.Refresh()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        PictureBox1.Width = 797
        PictureBox1.Height = 506
    End Sub

    Private Sub SharpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bmap = New Bitmap(PictureBox1.Image)
        PictureBox1.Image = bmap
        Dim tempbmp As New Bitmap(PictureBox1.Image)
        Dim DX As Integer = 1
        Dim DY As Integer = 1
        Dim red, green, blue As Integer

        Dim pixCol, pixRow As Integer
        With tempbmp
            For pixCol = DX To .Height - DX - 1
                For pixRow = DY To .Width - DY - 1
                    red = Convert.ToInt32(.GetPixel(pixRow, pixCol).R + 0.5 * (Convert.ToInt32(.GetPixel(pixRow, pixCol).R) - Convert.ToInt32(.GetPixel(pixRow - DX, pixCol - DY).R)))
                    green = Convert.ToInt32(.GetPixel(pixRow, pixCol).G + 0.5 * (Convert.ToInt32(.GetPixel(pixRow, pixCol).G) - Convert.ToInt32(.GetPixel(pixRow - DX, pixCol - DY).G)))
                    blue = Convert.ToInt32(.GetPixel(pixRow, pixCol).B + 0.5 * (Convert.ToInt32(.GetPixel(pixRow, pixCol).B) - Convert.ToInt32(.GetPixel(pixRow - DX, pixCol - DY).B)))
                    red = Math.Min(Math.Max(red, 0), 255)
                    green = Math.Min(Math.Max(green, 0), 255)
                    blue = Math.Min(Math.Max(blue, 0), 255)
                    bmap.SetPixel(pixRow, pixCol, Color.FromArgb(red, green, blue))
                Next
                If pixCol Mod 10 = 0 Then
                    PictureBox1.Invalidate()
                    Me.Text = Int(100 * pixCol / (PictureBox1.Image.Height - 2)).ToString & "%"
                    PictureBox1.Refresh()
                    Application.DoEvents()
                End If
            Next
        End With
        PictureBox1.Refresh()
        Me.Text = "Done sharpening image"
    End Sub

    Private Sub DiffuseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bmap = New Bitmap(PictureBox1.Image)
        PictureBox1.Image = bmap
        Dim tempbmp As New Bitmap(PictureBox1.Image)
        Dim pixCol As Integer, pixRow As Integer
        Dim DX As Integer
        Dim DY As Integer
        Dim red As Integer, green As Integer, blue As Integer
        Dim rnd As New Random
        With tempbmp
            For pixCol = 3 To .Height - 3
                For pixRow = 3 To .Width - 3
                    DX = rnd.Next(1, 3)
                    DY = rnd.Next(1, 3)
                    red = .GetPixel(pixRow + DX, pixCol + DY).R
                    green = .GetPixel(pixRow + DX, pixCol + DY).G
                    blue = .GetPixel(pixRow + DX, pixCol + DY).B
                    bmap.SetPixel(pixRow, pixCol, Color.FromArgb(red, green, blue))
                Next
                Me.Text = Int(100 * pixCol / (.Height - 2)).ToString & "%"
                If pixCol Mod 10 = 0 Then
                    PictureBox1.Invalidate()
                    PictureBox1.Refresh()
                    Application.DoEvents()
                    Me.Text = Int(100 * pixCol / (PictureBox1.Image.Height - 2)).ToString & "%"
                End If
            Next
        End With
        PictureBox1.Refresh()
        Me.Text = "Done diffusing image"
    End Sub

    Private Sub EmbossToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bmap = New Bitmap(PictureBox1.Image)
        PictureBox1.Image = bmap
        Dim tempbmp As New Bitmap(PictureBox1.Image)
        Dim pixCol, pixRow As Integer
        Dim DispX As Integer = 1, DispY As Integer = 1
        Dim red, green, blue As Integer
        With tempbmp
            For pixCol = 0 To .Height - 2
                For pixRow = 0 To .Width - 2
                    Dim pixel1, pixel2 As System.Drawing.Color
                    pixel1 = .GetPixel(pixRow, pixCol)
                    pixel2 = .GetPixel(pixRow + DispX, pixCol + DispY)
                    red = Math.Min(Math.Abs(CInt(pixel1.R) - CInt(pixel2.R)) + 128, 255)
                    green = Math.Min(Math.Abs(CInt(pixel1.G) - CInt(pixel2.G)) + 128, 255)
                    blue = Math.Min(Math.Abs(CInt(pixel1.B) - CInt(pixel2.B)) + 128, 255)
                    bmap.SetPixel(pixRow, pixCol, Color.FromArgb(red, green, blue))
                Next

                If pixCol Mod 10 = 0 Then
                    PictureBox1.Invalidate()
                    PictureBox1.Refresh()
                    Me.Text = Int(100 * pixCol / (PictureBox1.Image.Height - 2)).ToString & "%"
                    Application.DoEvents()
                End If
            Next
        End With
        PictureBox1.Refresh()
        Me.Text = "Done embossing image"
    End Sub

    Private Sub SmoothToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bmap = New Bitmap(PictureBox1.Image)
        PictureBox1.Image = bmap
        Dim tempbmp As New Bitmap(PictureBox1.Image)
        Dim DX As Integer = 1
        Dim DY As Integer = 1
        Dim red, green, blue As Integer

        Dim pixCol, pixRow As Integer
        With tempbmp
            For pixCol = DX To .Height - DX - 1
                For pixRow = DY To .Width - DY - 1
                    red = CInt((CInt(.GetPixel(pixRow - 1, pixCol - 1).R) + _
                            CInt(.GetPixel(pixRow - 1, pixCol).R) + _
                            CInt(.GetPixel(pixRow - 1, pixCol + 1).R) + _
                            CInt(.GetPixel(pixRow, pixCol - 1).R) + _
                            CInt(.GetPixel(pixRow, pixCol).R) + _
                            CInt(.GetPixel(pixRow, pixCol + 1).R) + _
                            CInt(.GetPixel(pixRow + 1, pixCol - 1).R) + _
                            CInt(.GetPixel(pixRow + 1, pixCol).R) + _
                            CInt(.GetPixel(pixRow + 1, pixCol + 1).R)) / 9)

                    green = CInt((CInt(.GetPixel(pixRow - 1, pixCol - 1).G) + _
                            CInt(.GetPixel(pixRow - 1, pixCol).G) + _
                            CInt(.GetPixel(pixRow - 1, pixCol + 1).G) + _
                            CInt(.GetPixel(pixRow, pixCol - 1).G) + _
                            CInt(.GetPixel(pixRow, pixCol).G) + _
                            CInt(.GetPixel(pixRow, pixCol + 1).G) + _
                            CInt(.GetPixel(pixRow + 1, pixCol - 1).G) + _
                            CInt(.GetPixel(pixRow + 1, pixCol).G) + _
                            CInt(.GetPixel(pixRow + 1, pixCol + 1).G)) / 9)

                    blue = CInt((CInt(.GetPixel(pixRow - 1, pixCol - 1).B) + _
                            CInt(.GetPixel(pixRow - 1, pixCol).B) + _
                            CInt(.GetPixel(pixRow - 1, pixCol + 1).B) + _
                            CInt(.GetPixel(pixRow, pixCol - 1).B) + _
                            CInt(.GetPixel(pixRow, pixCol).B) + _
                            CInt(.GetPixel(pixRow, pixCol + 1).B) + _
                            CInt(.GetPixel(pixRow + 1, pixCol - 1).B) + _
                            CInt(.GetPixel(pixRow + 1, pixCol).B) + _
                            CInt(.GetPixel(pixRow + 1, pixCol + 1).B)) / 9)
                    red = Math.Min(Math.Max(red, 0), 255)
                    green = Math.Min(Math.Max(green, 0), 255)
                    blue = Math.Min(Math.Max(blue, 0), 255)
                    bmap.SetPixel(pixRow, pixCol, Color.FromArgb(red, green, blue))
                Next
                If pixCol Mod 10 = 0 Then
                    PictureBox1.Invalidate()
                    PictureBox1.Refresh()
                    Application.DoEvents()
                    Me.Text = Int(100 * pixCol / (PictureBox1.Image.Height - 2)).ToString & "%"
                End If
            Next
        End With
        PictureBox1.Refresh()
        Me.Text = "Done smoothing image"
    End Sub

    Private Sub Rotate180ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rotate180ToolStripMenuItem.Click
        PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
        PictureBox1.Width = Convert.ToInt32(PictureBox1.Height * PictureBox1.Image.Width / PictureBox1.Image.Height)
        PictureBox1.Width = 797
        PictureBox1.Height = 506
    End Sub

    Private Sub Rotate90ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rotate90ToolStripMenuItem.Click
        PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        PictureBox1.Width = Convert.ToInt32(PictureBox1.Height * PictureBox1.Image.Width / PictureBox1.Image.Height)
        PictureBox1.Width = 797
        PictureBox1.Height = 506
    End Sub

    Private Sub Rotate270ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rotate270ToolStripMenuItem.Click
        PictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
        PictureBox1.Width = Convert.ToInt32(PictureBox1.Height * PictureBox1.Image.Width / PictureBox1.Image.Height)
        PictureBox1.Width = 797
        PictureBox1.Height = 506
    End Sub

    Private Sub MirrorXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MirrorXToolStripMenuItem.Click
        PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
        PictureBox1.Refresh()
    End Sub

    Private Sub MirrorYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MirrorYToolStripMenuItem.Click
        PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
        PictureBox1.Refresh()
    End Sub

    Private Sub ZoomOutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PictureBox1.Width = PictureBox1.Width / 2
        PictureBox1.Height = PictureBox1.Height / 2
    End Sub

    Private Sub NormalToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PictureBox1.Width = 797
        PictureBox1.Height = 506
    End Sub

    Private Sub ZoomInToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PictureBox1.Width = PictureBox1.Width * 2
        PictureBox1.Height = PictureBox1.Height * 2
        PictureBox1.Left = Panel1.Left
    End Sub

    Private Sub FDIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FDIToolStripMenuItem.Click
        If FDIToolStripMenuItem.CheckState = CheckState.Checked Then
            FDIToolStripMenuItem.Checked = False
        Else
            FDIToolStripMenuItem.Checked = True
            USAToolStripMenuItem.Checked = False
            DanishToolStripMenuItem.Checked = False
            BritishToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub USAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USAToolStripMenuItem.Click
        If USAToolStripMenuItem.CheckState = CheckState.Checked Then
            USAToolStripMenuItem.Checked = False
        Else
            USAToolStripMenuItem.Checked = True
            FDIToolStripMenuItem.Checked = False
            DanishToolStripMenuItem.Checked = False
            BritishToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub DanishToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanishToolStripMenuItem.Click
        If DanishToolStripMenuItem.CheckState = CheckState.Checked Then
            DanishToolStripMenuItem.Checked = False
        Else
            FDIToolStripMenuItem.Checked = False
            USAToolStripMenuItem.Checked = False
            DanishToolStripMenuItem.Checked = True
            BritishToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub BritishToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BritishToolStripMenuItem.Click
        If BritishToolStripMenuItem.CheckState = CheckState.Checked Then
            BritishToolStripMenuItem.Checked = False
        Else
            FDIToolStripMenuItem.Checked = False
            USAToolStripMenuItem.Checked = False
            DanishToolStripMenuItem.Checked = False
            BritishToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Panel3.Visible = False
        Teeth.Text = ""
        Me.Close()
    End Sub

    Private Sub ImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripMenuItem.Click
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.FileName = "Photo"
        OpenFileDialog1.ShowDialog()

    End Sub

    Private Sub DefaultImageSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultImageSettingsToolStripMenuItem.Click
        frm_Imagedefaultsettings.Show()
    End Sub

    Private Sub ToolStripButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton13.Click
        If PictureBox1.Image Is Nothing Then
            MsgBox("No Image Found!")
        Else
            Call SaveData()
        End If
    End Sub

    Private Sub SaveData()
        Dim ObjClass As New ClassFunctions()
        Dim folder As String = ""
        Dim FullPath As String = ""
        folder = ObjClass.ReturnFieldName("select ptReg_code from Master_ptReg where ptReg_id='" & PatientId & "'")
        Dim path As String = Application.StartupPath & "\Images\" & folder
        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If
        folder = folder & "_" & Format(Date.Now, "ddMMyyyyhhmmss") & ".jpg"
        PictureBox1.Image.Save(path & "\" & folder, System.Drawing.Imaging.ImageFormat.Jpeg)
        FullPath = path & "\" & folder
        Dim DispName As String
        Dim count As Integer = 0
        count = ObjClass.Returnsinglevalue("select count(*) from Patient_Image where Image_ptRegId='" & PatientId & "'")
        DispName = "E" & count + 1
        ObjClass.ExecuteQuery("insert into Patient_Image values('" & ObjClass.getIndexKey() & "','" & PatientId & "','" & folder & "','" & Trim(txtNotes.Text) & "','" & Format(dtpRegDate.Value, "yyyy-MM-dd") & "','" & Teeth.Text & "','" & DispName & "','0','0','0')")
        MsgBox("Image Saved Successfully!")

        Call frm_MainScreen.FillDetails()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.FileName = "Photo"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub Teeth1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth1.Click
        TeethNo = 1
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth2.Click
        TeethNo = 2
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth3.Click
        TeethNo = 3
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth4.Click
        TeethNo = 4
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth5.Click
        TeethNo = 5
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth6.Click
        TeethNo = 6
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth7.Click
        TeethNo = 7
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth8.Click
        TeethNo = 8
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth9.Click
        TeethNo = 9
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth10.Click
        TeethNo = 10
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth11.Click
        TeethNo = 11
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth12.Click
        TeethNo = 12
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth13.Click
        TeethNo = 13
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth14.Click
        TeethNo = 14
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth15.Click
        TeethNo = 15
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth16.Click
        TeethNo = 16
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth17.Click
        TeethNo = 17
        Panel3.Visible = True
    End Sub

    Private Sub Teeth18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth18.Click
        TeethNo = 18
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth19.Click
        TeethNo = 19
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth20.Click
        TeethNo = 20
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth21.Click
        TeethNo = 21
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth22.Click
        TeethNo = 22
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth23.Click
        TeethNo = 23
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth24.Click
        TeethNo = 24
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth25.Click
        TeethNo = 25
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth26.Click
        TeethNo = 26
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth27.Click
        TeethNo = 27
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth28.Click
        TeethNo = 28
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth29.Click
        TeethNo = 29
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth30.Click
        TeethNo = 30
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth31.Click
        TeethNo = 31
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub Teeth32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Teeth32.Click
        TeethNo = 32
        Panel3.Visible = True
        Teeth.Text = TeethNo
    End Sub

    Private Sub btnCloseX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseX.Click
        Panel3.Visible = False
        Teeth.Text = ""
    End Sub

    Private Sub btnR1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnR1.Click

        Panel3.Visible = True
        Teeth.Text = "R1"
    End Sub

    Private Sub btnR2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnR2.Click
        Panel3.Visible = True
        Teeth.Text = "R2"
    End Sub

    Private Sub btnL1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnL1.Click
        Panel3.Visible = True
        Teeth.Text = "L1"
    End Sub

    Private Sub btnL2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnL2.Click
        Panel3.Visible = True
        Teeth.Text = "L2"
    End Sub

    Private Sub btnPAN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPAN.Click
        Panel3.Visible = True
        Teeth.Text = "PAN"
    End Sub

    Private Sub btnCEPH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCEPH.Click
        Panel3.Visible = True
        Teeth.Text = "CEPH"
    End Sub

    Private Sub PictureBox34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox34.Click
        frm_Device.Show()
    End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    If frm_MainScreen.CapturePath = "" Then

    '    Else
    '        PictureBox1.ImageLocation = frm_MainScreen.CapturePath
    '        frm_MainScreen.CapturePath = ""
    '        Panel3.Visible = False
    '        txtNotes.Enabled = True
    '        PictureBox1.BringToFront()
    '        Panel2.Visible = False
    '        PictureBox1.Visible = True
    '    End If
    'End Sub

    Private Sub TSBCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBCopy.Click

    End Sub

    Private Sub TSBPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBPaste.Click
        Dim ObjClass As New ClassFunctions()
        If My.Computer.Clipboard.ContainsImage Then
            Panel3.Visible = False
            txtNotes.Enabled = True
            PictureBox1.BringToFront()
            Panel2.Visible = False
            PictureBox1.Visible = True
            PictureBox1.Image = My.Computer.Clipboard.GetImage
            Teeth.Text = ""
            dtpRegDate.Value = ObjClass.GetCurrentDate()
            TSBCopy.Enabled = True
            ToolStripMenuItem1.Enabled = True
        End If
    End Sub

    Private Sub SaveToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem1.Click
        If PictureBox1.Image Is Nothing Then
            MsgBox("No Image Found!")
        Else
            Call SaveData()
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If PictureBox1.Image Is Nothing Then
            MsgBox("No Image Found!")
        Else
            Call SaveData()
            Me.Close()
        End If
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        Dim ObjClass As New ClassFunctions()
        If My.Computer.Clipboard.ContainsImage Then
            Panel3.Visible = False
            txtNotes.Enabled = True
            PictureBox1.BringToFront()
            Panel2.Visible = False
            PictureBox1.Visible = True
            PictureBox1.Image = My.Computer.Clipboard.GetImage
            Teeth.Text = ""
            dtpRegDate.Value = ObjClass.GetCurrentDate()
            TSBCopy.Enabled = True
            ToolStripMenuItem1.Enabled = True
        End If
    End Sub
End Class