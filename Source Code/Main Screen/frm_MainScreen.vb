Imports System.Windows.Forms
Imports System.Drawing.Point
Imports System.Drawing.Color
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Collections.Generic
Public Class frm_MainScreen
    Dim ObjClass As New ClassFunctions()
    Private m_MouseIsDown As Boolean = False
    Dim picture As String = ""
    Dim Pic As String = ""
    Dim currentImage As String = ""
    Dim TempPath As String = ""
    Dim path As String = ""
    Dim FName As String = ""
    Dim flag As Integer = 0
    Dim test As Integer = 0
    Dim Contrast As Integer = 0
    Dim Bright As Integer = 0
    Dim mouseX As Integer = 0
    Dim mouseY As Integer = 0
    Dim p As Point
    Dim mouseX2 As Integer = 0
    Dim mouseY2 As Integer = 0
    Public CapturePath As String = ""
    Private _Previous As System.Nullable(Of Point) = Nothing
    Public measure As String = ""

    Private m_Markers_2X1 As New List(Of Rectangle)
    Private m_Markers_2X2 As New List(Of Rectangle)

    Private m_Markers_4X1 As New List(Of Rectangle)
    Private m_Markers_4X2 As New List(Of Rectangle)
    Private m_Markers_4X3 As New List(Of Rectangle)
    Private m_Markers_4X4 As New List(Of Rectangle)

    Private m_Markers_9X1 As New List(Of Rectangle)
    Private m_Markers_9X2 As New List(Of Rectangle)
    Private m_Markers_9X3 As New List(Of Rectangle)
    Private m_Markers_9X4 As New List(Of Rectangle)
    Private m_Markers_9X5 As New List(Of Rectangle)
    Private m_Markers_9X6 As New List(Of Rectangle)
    Private m_Markers_9X7 As New List(Of Rectangle)
    Private m_Markers_9X8 As New List(Of Rectangle)
    Private m_Markers_9X9 As New List(Of Rectangle)

    Private m_Markers_16X1 As New List(Of Rectangle)
    Private m_Markers_16X2 As New List(Of Rectangle)
    Private m_Markers_16X3 As New List(Of Rectangle)
    Private m_Markers_16X4 As New List(Of Rectangle)
    Private m_Markers_16X5 As New List(Of Rectangle)
    Private m_Markers_16X6 As New List(Of Rectangle)
    Private m_Markers_16X7 As New List(Of Rectangle)
    Private m_Markers_16X8 As New List(Of Rectangle)
    Private m_Markers_16X9 As New List(Of Rectangle)
    Private m_Markers_16X10 As New List(Of Rectangle)
    Private m_Markers_16X11 As New List(Of Rectangle)
    Private m_Markers_16X12 As New List(Of Rectangle)
    Private m_Markers_16X13 As New List(Of Rectangle)
    Private m_Markers_16X14 As New List(Of Rectangle)
    Private m_Markers_16X15 As New List(Of Rectangle)
    Private m_Markers_16X16 As New List(Of Rectangle)

    Private m_Markers_18X1 As New List(Of Rectangle)
    Private m_Markers_18X2 As New List(Of Rectangle)
    Private m_Markers_18X3 As New List(Of Rectangle)
    Private m_Markers_18X4 As New List(Of Rectangle)
    Private m_Markers_18X5 As New List(Of Rectangle)
    Private m_Markers_18X6 As New List(Of Rectangle)
    Private m_Markers_18X7 As New List(Of Rectangle)
    Private m_Markers_18X8 As New List(Of Rectangle)
    Private m_Markers_18X9 As New List(Of Rectangle)
    Private m_Markers_18X10 As New List(Of Rectangle)
    Private m_Markers_18X11 As New List(Of Rectangle)
    Private m_Markers_18X12 As New List(Of Rectangle)
    Private m_Markers_18X13 As New List(Of Rectangle)
    Private m_Markers_18X14 As New List(Of Rectangle)
    Private m_Markers_18X15 As New List(Of Rectangle)
    Private m_Markers_18X16 As New List(Of Rectangle)
    Private m_Markers_18X17 As New List(Of Rectangle)
    Private m_Markers_18X18 As New List(Of Rectangle)

    Private m_X(0 To 3) As Single
    Private m_Y(0 To 3) As Single
    Private m_NextPoint As Integer


    ' The smiley image.
    Private Smiley As Bitmap
    ' The smiley image's location.
    Private SmileyLocation As Rectangle
    ' True when we are dragging.
    Private Dragging As Boolean = False
    ' The offset from the mouse's down position
    ' and the picture's upper left corner.
    Private OffsetX As Integer, OffsetY As Integer

    'Line Tool with drag and drop
    Private Const object_radius As Integer = 3
    Private Const over_dist_squared As Integer = object_radius * object_radius
    Private Pt1 As New List(Of Point)()
    Private Pt2 As New List(Of Point)()
    Private IsDrawing As Boolean = False
    Private NewPt1 As Point, NewPt2 As Point

    Private Sub frm_MainScreen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SplashScreen.Close()
    End Sub

    Private Sub frm_MainScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SplashScreen.Visible = False
        SplashScreen.Timer1.Enabled = False
        Panel3.Height = Me.Height - 100
        Panel3.Width = Me.Width - Panel2.Width
        Panel3.Top = 68
        Panel2.Top = 68

        Panel2.Height = Me.Height - 70
        GroupBox2.Height = Panel2.Height
        GroupBox3.Height = Panel3.Height

        GroupBox3.Width = Panel3.Width

        MouseWheelRedirector.Attach(Pic_1_grp1X)
        MouseWheelRedirector.Attach(pic_1_grp2X)
        MouseWheelRedirector.Attach(pic_2_grp2X)
        MouseWheelRedirector.Attach(Pic_1_grp4X)
        MouseWheelRedirector.Attach(Pic_2_grp4X)
        MouseWheelRedirector.Attach(Pic_3_grp4X)
        MouseWheelRedirector.Attach(Pic_4_grp4X)
        MouseWheelRedirector.Attach(pic_1_grp9x)
        MouseWheelRedirector.Attach(pic_2_grp9x)
        MouseWheelRedirector.Attach(pic_3_grp9x)
        MouseWheelRedirector.Attach(pic_4_grp9x)
        MouseWheelRedirector.Attach(pic_5_grp9x)
        MouseWheelRedirector.Attach(pic_6_grp9x)
        MouseWheelRedirector.Attach(pic_7_grp9x)
        MouseWheelRedirector.Attach(pic_8_grp9x)
        MouseWheelRedirector.Attach(pic_9_grp9x)
        MouseWheelRedirector.Attach(pic_1_grp16X)
        MouseWheelRedirector.Attach(pic_2_grp16X)
        MouseWheelRedirector.Attach(pic_3_grp16X)
        MouseWheelRedirector.Attach(pic_4_grp16X)
        MouseWheelRedirector.Attach(pic_5_grp16X)
        MouseWheelRedirector.Attach(pic_6_grp16X)
        MouseWheelRedirector.Attach(pic_7_grp16X)
        MouseWheelRedirector.Attach(pic_8_grp16X)
        MouseWheelRedirector.Attach(pic_9_grp16X)
        MouseWheelRedirector.Attach(pic_10_grp16X)
        MouseWheelRedirector.Attach(pic_11_grp16X)
        MouseWheelRedirector.Attach(pic_12_grp16X)
        MouseWheelRedirector.Attach(pic_13_grp16X)
        MouseWheelRedirector.Attach(pic_14_grp16X)
        MouseWheelRedirector.Attach(pic_15_grp16X)
        MouseWheelRedirector.Attach(pic_16_grp16X)
        MouseWheelRedirector.Active = True
        grp1X.Height = GroupBox3.Height
        grp1X.Width = GroupBox3.Width
        grp1X.Top = GroupBox3.Top
        grp2X.Height = GroupBox3.Height
        grp2X.Width = GroupBox3.Width
        grp2X.Top = GroupBox3.Top
        grp4X.Height = GroupBox3.Height
        grp4X.Width = GroupBox3.Width
        grp4X.Top = GroupBox3.Top
        grp9X.Height = GroupBox3.Height
        grp9X.Width = GroupBox3.Width
        grp9X.Top = GroupBox3.Top
        grp16X.Height = GroupBox3.Height
        grp16X.Width = GroupBox3.Width
        grp16X.Top = GroupBox3.Top
        grpFullMouth.Height = GroupBox3.Height
        grpFullMouth.Width = GroupBox3.Width
        grpFullMouth.Top = GroupBox3.Top
        grpViewer.Height = GroupBox3.Height
        grpViewer.Width = GroupBox3.Width
        grpViewer.Top = GroupBox3.Top

        'grp1X
        '' Larger View Screen controls allignment and size
        Pnl_1X1.Width = (grp2X.Width - 50)
        Pnl_1X1.Height = grp2X.Height - 35
        Pnl_1X1.Left = grp2X.Left + 20
        Pnl_1X1.Top = grp2X.Top + 27
        Pic_1_grp1X.Top = Pnl_1X1.Top - 25
        Pic_1_grp1X.Height = Pnl_1X1.Height
        Pic_1_grp1X.Width = Pnl_1X1.Width
        Pic_1_grp1X.Left = Pnl_1X1.Left - 30
        'grp2X
        '' 2 Horizontal View Screen controls allignment and size

        Pnl_2X1.Width = (grp2X.Width - 50) / 2
        Pnl_2X1.Height = grp2X.Height - 35
        Pnl_2X1.Left = grp2X.Left + 20
        Pnl_2X1.Top = grp2X.Top + 27
        pic_1_grp2X.Top = Pnl_2X1.Top - 25
        pic_1_grp2X.Height = Pnl_2X1.Height
        pic_1_grp2X.Width = Pnl_2X1.Width
        pic_1_grp2X.Left = Pnl_2X1.Left - 30
        Pnl_2X2.Top = grp2X.Top + 27
        Pnl_2X2.Height = grp2X.Height - 35
        Pnl_2X2.Width = (grp2X.Width - 50) / 2
        Pnl_2X2.Left = Pnl_2X1.Right + 10
        pic_2_grp2X.Top = Pnl_2X2.Top - 25
        pic_2_grp2X.Height = Pnl_2X2.Height
        pic_2_grp2X.Width = Pnl_2X2.Width
        pic_2_grp2X.Left = pic_2_grp2X.Left - 30
        'grp4X
        '' 2 X 2 Grid View Screen controls allignment and size
        Pnl_4X1.Height = (grp4X.Height - 39) / 2
        Pnl_4X2.Height = (grp4X.Height - 39) / 2
        Pnl_4X3.Height = (grp4X.Height - 39) / 2
        Pnl_4X4.Height = (grp4X.Height - 39) / 2
        Pnl_4X1.Width = (grp4X.Width - 48) / 2
        Pnl_4X2.Width = (grp4X.Width - 48) / 2
        Pnl_4X3.Width = (grp4X.Width - 48) / 2
        Pnl_4X4.Width = (grp4X.Width - 48) / 2
        Pnl_4X1.Left = grp4X.Left + 10
        Pnl_4X2.Left = Pnl_4X1.Right + 10
        Pnl_4X3.Left = Pnl_4X1.Left
        Pnl_4X4.Left = Pnl_4X2.Left
        Pnl_4X3.Top = Pnl_4X1.Bottom + 10
        Pnl_4X4.Top = Pnl_4X2.Bottom + 10


        Pic_1_grp4X.Height = (grp4X.Height - 39) / 2
        Pic_2_grp4X.Height = (grp4X.Height - 39) / 2
        Pic_3_grp4X.Height = (grp4X.Height - 39) / 2
        Pic_4_grp4X.Height = (grp4X.Height - 39) / 2
        Pic_1_grp4X.Width = (grp4X.Width - 48) / 2
        Pic_2_grp4X.Width = (grp4X.Width - 48) / 2
        Pic_3_grp4X.Width = (grp4X.Width - 48) / 2
        Pic_4_grp4X.Width = (grp4X.Width - 48) / 2
        Pic_1_grp4X.Left = 0 'grp4X.Left + 10
        Pic_2_grp4X.Left = 0 'Pic_1_grp4X.Right + 10
        Pic_3_grp4X.Left = 0 'Pic_1_grp4X.Left
        Pic_4_grp4X.Left = 0 'Pic_2_grp4X.Left
        Pic_1_grp4X.Top = 0
        Pic_2_grp4X.Top = 0
        Pic_3_grp4X.Top = 0  'Pic_1_grp4X.Bottom + 10
        Pic_4_grp4X.Top = 0 'Pic_2_grp4X.Bottom + 10
        'grp9X
        '' 3 X 3 Grid View Screen controls allignment and size 

        Pnl_9X1.Height = (grp9X.Height - 50) / 3
        Pnl_9X2.Height = (grp9X.Height - 50) / 3
        Pnl_9X3.Height = (grp9X.Height - 50) / 3
        Pnl_9X4.Height = (grp9X.Height - 50) / 3
        Pnl_9X5.Height = (grp9X.Height - 50) / 3
        Pnl_9X6.Height = (grp9X.Height - 50) / 3
        Pnl_9X7.Height = (grp9X.Height - 50) / 3
        Pnl_9X8.Height = (grp9X.Height - 50) / 3
        Pnl_9X9.Height = (grp9X.Height - 50) / 3
        Pnl_9X1.Width = (grp9X.Width - 58) / 3
        Pnl_9X2.Width = (grp9X.Width - 58) / 3
        Pnl_9X3.Width = (grp9X.Width - 58) / 3
        Pnl_9X4.Width = (grp9X.Width - 58) / 3
        Pnl_9X5.Width = (grp9X.Width - 58) / 3
        Pnl_9X6.Width = (grp9X.Width - 58) / 3
        Pnl_9X7.Width = (grp9X.Width - 58) / 3
        Pnl_9X8.Width = (grp9X.Width - 58) / 3
        Pnl_9X9.Width = (grp9X.Width - 58) / 3
        Pnl_9X1.Left = grp9X.Left + 10
        Pnl_9X2.Left = Pnl_9X1.Right + 10
        Pnl_9X3.Left = Pnl_9X2.Right + 10
        Pnl_9X4.Left = Pnl_9X1.Left
        Pnl_9X5.Left = Pnl_9X4.Right + 10
        Pnl_9X6.Left = Pnl_9X5.Right + 10
        Pnl_9X7.Left = Pnl_9X1.Left
        Pnl_9X8.Left = Pnl_9X7.Right + 10
        Pnl_9X9.Left = Pnl_9X8.Right + 10
        Pnl_9X1.Top = grp9X.Top + 23
        Pnl_9X2.Top = grp9X.Top + 23
        Pnl_9X3.Top = grp9X.Top + 23
        Pnl_9X4.Top = Pnl_9X1.Bottom + 10
        Pnl_9X5.Top = Pnl_9X2.Bottom + 10
        Pnl_9X6.Top = Pnl_9X3.Bottom + 10
        Pnl_9X7.Top = Pnl_9X4.Bottom + 10
        Pnl_9X8.Top = Pnl_9X5.Bottom + 10
        Pnl_9X9.Top = Pnl_9X6.Bottom + 10


        pic_1_grp9x.Height = (grp9X.Height - 50) / 3
        pic_2_grp9x.Height = (grp9X.Height - 50) / 3
        pic_3_grp9x.Height = (grp9X.Height - 50) / 3
        pic_4_grp9x.Height = (grp9X.Height - 50) / 3
        pic_5_grp9x.Height = (grp9X.Height - 50) / 3
        pic_6_grp9x.Height = (grp9X.Height - 50) / 3
        pic_7_grp9x.Height = (grp9X.Height - 50) / 3
        pic_8_grp9x.Height = (grp9X.Height - 50) / 3
        pic_9_grp9x.Height = (grp9X.Height - 50) / 3
        pic_1_grp9x.Width = (grp9X.Width - 58) / 3
        pic_2_grp9x.Width = (grp9X.Width - 58) / 3
        pic_3_grp9x.Width = (grp9X.Width - 58) / 3
        pic_4_grp9x.Width = (grp9X.Width - 58) / 3
        pic_5_grp9x.Width = (grp9X.Width - 58) / 3
        pic_6_grp9x.Width = (grp9X.Width - 58) / 3
        pic_7_grp9x.Width = (grp9X.Width - 58) / 3
        pic_8_grp9x.Width = (grp9X.Width - 58) / 3
        pic_9_grp9x.Width = (grp9X.Width - 58) / 3
        pic_1_grp9x.Top = 0 ' grp9X.Top + 23
        pic_2_grp9x.Top = 0 'grp9X.Top + 23
        pic_3_grp9x.Top = 0 'grp9X.Top + 23
        pic_1_grp9x.Left = 0 'grp9X.Left + 10
        pic_2_grp9x.Left = 0 'pic_1_grp9x.Right + 10
        pic_3_grp9x.Left = 0 'pic_2_grp9x.Right + 10
        pic_4_grp9x.Left = 0 'pic_1_grp9x.Left
        pic_5_grp9x.Left = 0 'pic_4_grp9x.Right + 10
        pic_6_grp9x.Left = 0 'pic_5_grp9x.Right + 10
        pic_7_grp9x.Left = 0 'pic_1_grp9x.Left
        pic_8_grp9x.Left = 0 'pic_7_grp9x.Right + 10
        pic_9_grp9x.Left = 0 'pic_8_grp9x.Right + 10
        pic_4_grp9x.Top = 0 'pic_1_grp9x.Bottom + 10
        pic_5_grp9x.Top = 0 'pic_2_grp9x.Bottom + 10
        pic_6_grp9x.Top = 0 'pic_3_grp9x.Bottom + 10
        pic_7_grp9x.Top = 0 'pic_4_grp9x.Bottom + 10
        pic_8_grp9x.Top = 0 'pic_5_grp9x.Bottom + 10
        pic_9_grp9x.Top = 0 'pic_6_grp9x.Bottom + 10

        'grp16X
        '' 4 X 4 Grid View Screen controls allignment and size 
        pic_1_grp16X.Height = (grp16X.Height - 50) / 4
        pic_2_grp16X.Height = (grp16X.Height - 50) / 4
        pic_3_grp16X.Height = (grp16X.Height - 50) / 4
        pic_4_grp16X.Height = (grp16X.Height - 50) / 4
        pic_5_grp16X.Height = (grp16X.Height - 50) / 4
        pic_6_grp16X.Height = (grp16X.Height - 50) / 4
        pic_7_grp16X.Height = (grp16X.Height - 50) / 4
        pic_8_grp16X.Height = (grp16X.Height - 50) / 4
        pic_9_grp16X.Height = (grp16X.Height - 50) / 4
        pic_10_grp16X.Height = (grp16X.Height - 50) / 4
        pic_11_grp16X.Height = (grp16X.Height - 50) / 4
        pic_12_grp16X.Height = (grp16X.Height - 50) / 4
        pic_13_grp16X.Height = (grp16X.Height - 50) / 4
        pic_14_grp16X.Height = (grp16X.Height - 50) / 4
        pic_15_grp16X.Height = (grp16X.Height - 50) / 4
        pic_16_grp16X.Height = (grp16X.Height - 50) / 4

        pic_1_grp16X.Width = (grp16X.Width - 58) / 4
        pic_2_grp16X.Width = (grp16X.Width - 58) / 4
        pic_3_grp16X.Width = (grp16X.Width - 58) / 4
        pic_4_grp16X.Width = (grp16X.Width - 58) / 4
        pic_5_grp16X.Width = (grp16X.Width - 58) / 4
        pic_6_grp16X.Width = (grp16X.Width - 58) / 4
        pic_7_grp16X.Width = (grp16X.Width - 58) / 4
        pic_8_grp16X.Width = (grp16X.Width - 58) / 4
        pic_9_grp16X.Width = (grp16X.Width - 58) / 4
        pic_10_grp16X.Width = (grp16X.Width - 58) / 4
        pic_11_grp16X.Width = (grp16X.Width - 58) / 4
        pic_12_grp16X.Width = (grp16X.Width - 58) / 4
        pic_13_grp16X.Width = (grp16X.Width - 58) / 4
        pic_14_grp16X.Width = (grp16X.Width - 58) / 4
        pic_15_grp16X.Width = (grp16X.Width - 58) / 4
        pic_16_grp16X.Width = (grp16X.Width - 58) / 4

        pic_1_grp16X.Top = grp16X.Top + 23
        pic_2_grp16X.Top = grp16X.Top + 23
        pic_3_grp16X.Top = grp16X.Top + 23
        pic_4_grp16X.Top = grp16X.Top + 23

        pic_1_grp16X.Left = grp16X.Left + 10
        pic_2_grp16X.Left = pic_1_grp16X.Right + 10
        pic_3_grp16X.Left = pic_2_grp16X.Right + 10
        pic_4_grp16X.Left = pic_3_grp16X.Right + 10
        pic_5_grp16X.Left = grp16X.Left + 10
        pic_6_grp16X.Left = pic_5_grp16X.Right + 10
        pic_7_grp16X.Left = pic_6_grp16X.Right + 10
        pic_8_grp16X.Left = pic_7_grp16X.Right + 10
        pic_9_grp16X.Left = grp16X.Left + 10
        pic_10_grp16X.Left = pic_9_grp16X.Right + 10
        pic_11_grp16X.Left = pic_10_grp16X.Right + 10
        pic_12_grp16X.Left = pic_11_grp16X.Right + 10
        pic_13_grp16X.Left = grp16X.Left + 10
        pic_14_grp16X.Left = pic_13_grp16X.Right + 10
        pic_15_grp16X.Left = pic_14_grp16X.Right + 10
        pic_16_grp16X.Left = pic_15_grp16X.Right + 10

        pic_5_grp16X.Top = pic_1_grp16X.Bottom + 10
        pic_6_grp16X.Top = pic_2_grp16X.Bottom + 10
        pic_7_grp16X.Top = pic_3_grp16X.Bottom + 10
        pic_8_grp16X.Top = pic_4_grp16X.Bottom + 10
        pic_9_grp16X.Top = pic_5_grp16X.Bottom + 10
        pic_10_grp16X.Top = pic_6_grp16X.Bottom + 10
        pic_11_grp16X.Top = pic_7_grp16X.Bottom + 10
        pic_12_grp16X.Top = pic_8_grp16X.Bottom + 10
        pic_13_grp16X.Top = pic_9_grp16X.Bottom + 10
        pic_14_grp16X.Top = pic_10_grp16X.Bottom + 10
        pic_15_grp16X.Top = pic_11_grp16X.Bottom + 10
        pic_16_grp16X.Top = pic_12_grp16X.Bottom + 10

        'grpFullMouth
        '' Full Mouth View Screen controls allignment and size 
        pic_1_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2
        pic_2_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2
        pic_3_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2
        pic_4_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2
        pic_5_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2
        pic_6_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2

        pic_1_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2
        pic_2_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2
        pic_3_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2
        pic_4_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2
        pic_5_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2
        pic_6_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2

        pic_1_grpFullMouth.Left = grpFullMouth.Left + 10
        pic_2_grpFullMouth.Left = pic_1_grpFullMouth.Right + 10
        pic_3_grpFullMouth.Left = pic_1_grpFullMouth.Left
        pic_4_grpFullMouth.Left = pic_1_grpFullMouth.Right + 10
        pic_5_grpFullMouth.Left = pic_1_grpFullMouth.Left
        pic_6_grpFullMouth.Left = pic_1_grpFullMouth.Right + 10

        pic_1_grpFullMouth.Top = grpFullMouth.Top + 223
        pic_2_grpFullMouth.Top = grpFullMouth.Top + 223
        pic_3_grpFullMouth.Top = pic_1_grpFullMouth.Bottom + 10
        pic_4_grpFullMouth.Top = pic_1_grpFullMouth.Bottom + 10
        pic_5_grpFullMouth.Top = pic_3_grpFullMouth.Bottom + 10
        pic_6_grpFullMouth.Top = pic_3_grpFullMouth.Bottom + 10


        pic_7_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2
        pic_8_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2
        pic_9_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2
        pic_10_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2
        pic_11_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2
        pic_12_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2

        pic_7_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2
        pic_8_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2
        pic_9_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2
        pic_10_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2
        pic_11_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2
        pic_12_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2

        pic_7_grpFullMouth.Left = pic_2_grpFullMouth.Right + 10
        pic_8_grpFullMouth.Left = pic_7_grpFullMouth.Right + 10
        pic_9_grpFullMouth.Left = pic_8_grpFullMouth.Right + 10
        pic_10_grpFullMouth.Left = pic_2_grpFullMouth.Right + 10
        pic_11_grpFullMouth.Left = pic_7_grpFullMouth.Right + 10
        pic_12_grpFullMouth.Left = pic_8_grpFullMouth.Right + 10

        pic_7_grpFullMouth.Top = grpFullMouth.Top + 273
        pic_8_grpFullMouth.Top = grpFullMouth.Top + 273
        pic_9_grpFullMouth.Top = grpFullMouth.Top + 273
        pic_10_grpFullMouth.Top = pic_7_grpFullMouth.Bottom + 10
        pic_11_grpFullMouth.Top = pic_7_grpFullMouth.Bottom + 10
        pic_12_grpFullMouth.Top = pic_7_grpFullMouth.Bottom + 10


        pic_13_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2
        pic_14_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2
        pic_15_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2
        pic_16_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2
        pic_17_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2
        pic_18_grpFullMouth.Height = (grpFullMouth.Height - 50) / 7.2

        pic_13_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2
        pic_14_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2
        pic_15_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2
        pic_16_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2
        pic_17_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2
        pic_18_grpFullMouth.Width = (grpFullMouth.Width - 58) / 7.2

        pic_13_grpFullMouth.Left = pic_9_grpFullMouth.Right + 10
        pic_14_grpFullMouth.Left = pic_13_grpFullMouth.Right + 10
        pic_15_grpFullMouth.Left = pic_13_grpFullMouth.Left
        pic_16_grpFullMouth.Left = pic_15_grpFullMouth.Right + 10
        pic_17_grpFullMouth.Left = pic_13_grpFullMouth.Left
        pic_18_grpFullMouth.Left = pic_17_grpFullMouth.Right + 10

        pic_13_grpFullMouth.Top = grpFullMouth.Top + 223
        pic_14_grpFullMouth.Top = grpFullMouth.Top + 223
        pic_15_grpFullMouth.Top = pic_13_grpFullMouth.Bottom + 10
        pic_16_grpFullMouth.Top = pic_13_grpFullMouth.Bottom + 10
        pic_17_grpFullMouth.Top = pic_15_grpFullMouth.Bottom + 10
        pic_18_grpFullMouth.Top = pic_15_grpFullMouth.Bottom + 10

        ''Background color for Frames
        Me.BackColor = System.Drawing.ColorTranslator.FromHtml("#10183D")
        grp1X.BackColor = System.Drawing.ColorTranslator.FromHtml("#10183D")
        grp2X.BackColor = System.Drawing.ColorTranslator.FromHtml("#10183D")
        grp4X.BackColor = System.Drawing.ColorTranslator.FromHtml("#10183D")
        grp9X.BackColor = System.Drawing.ColorTranslator.FromHtml("#10183D")
        grp16X.BackColor = System.Drawing.ColorTranslator.FromHtml("#10183D")
        grpFullMouth.BackColor = System.Drawing.ColorTranslator.FromHtml("#10183D")
        grpViewer.BackColor = System.Drawing.ColorTranslator.FromHtml("#10183D")
        ''Eanble drag and drop for all image controls
        Pic_1_grp1X.AllowDrop = True
        pic_1_grp2X.AllowDrop = True
        pic_2_grp2X.AllowDrop = True
        Pic_1_grp4X.AllowDrop = True
        Pic_2_grp4X.AllowDrop = True
        Pic_3_grp4X.AllowDrop = True
        Pic_4_grp4X.AllowDrop = True
        pic_1_grp9x.AllowDrop = True
        pic_2_grp9x.AllowDrop = True
        pic_3_grp9x.AllowDrop = True
        pic_4_grp9x.AllowDrop = True
        pic_5_grp9x.AllowDrop = True
        pic_6_grp9x.AllowDrop = True
        pic_7_grp9x.AllowDrop = True
        pic_8_grp9x.AllowDrop = True
        pic_9_grp9x.AllowDrop = True
        pic_1_grp16X.AllowDrop = True
        pic_2_grp16X.AllowDrop = True
        pic_3_grp16X.AllowDrop = True
        pic_4_grp16X.AllowDrop = True
        pic_5_grp16X.AllowDrop = True
        pic_6_grp16X.AllowDrop = True
        pic_7_grp16X.AllowDrop = True
        pic_8_grp16X.AllowDrop = True
        pic_9_grp16X.AllowDrop = True
        pic_10_grp16X.AllowDrop = True
        pic_11_grp16X.AllowDrop = True
        pic_12_grp16X.AllowDrop = True
        pic_13_grp16X.AllowDrop = True
        pic_14_grp16X.AllowDrop = True
        pic_15_grp16X.AllowDrop = True
        pic_16_grp16X.AllowDrop = True
        pic_1_grpFullMouth.AllowDrop = True
        pic_2_grpFullMouth.AllowDrop = True
        pic_3_grpFullMouth.AllowDrop = True
        pic_4_grpFullMouth.AllowDrop = True
        pic_5_grpFullMouth.AllowDrop = True
        pic_6_grpFullMouth.AllowDrop = True
        pic_7_grpFullMouth.AllowDrop = True
        pic_8_grpFullMouth.AllowDrop = True
        pic_9_grpFullMouth.AllowDrop = True
        pic_10_grpFullMouth.AllowDrop = True
        pic_11_grpFullMouth.AllowDrop = True
        pic_12_grpFullMouth.AllowDrop = True
        pic_13_grpFullMouth.AllowDrop = True
        pic_14_grpFullMouth.AllowDrop = True
        pic_15_grpFullMouth.AllowDrop = True
        pic_16_grpFullMouth.AllowDrop = True
        pic_17_grpFullMouth.AllowDrop = True
        pic_18_grpFullMouth.AllowDrop = True


    End Sub

    Public Sub RefreshImages()
        If picture = "P1_1" Then
            Pic_1_grp1X.Image.Save(Pic_1_grp1X.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P2_1" Then
            pic_1_grp2X.Image.Save(pic_1_grp2X.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P2_2" Then
            pic_2_grp2X.Image.Save(pic_2_grp2X.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P4_1" Then
            Pic_1_grp4X.Image.Save(Pic_1_grp4X.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P4_2" Then
            Pic_2_grp4X.Image.Save(Pic_2_grp4X.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P4_3" Then
            Pic_3_grp4X.Image.Save(Pic_3_grp4X.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P4_4" Then
            Pic_4_grp4X.Image.Save(Pic_4_grp4X.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P9_1" Then
            pic_1_grp9x.Image.Save(pic_1_grp9x.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P9_2" Then
            pic_2_grp9x.Image.Save(pic_2_grp9x.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P9_3" Then
            pic_3_grp9x.Image.Save(pic_3_grp9x.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P9_4" Then
            pic_4_grp9x.Image.Save(pic_4_grp9x.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P9_5" Then
            pic_5_grp9x.Image.Save(pic_5_grp9x.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P9_6" Then
            pic_6_grp9x.Image.Save(pic_6_grp9x.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P9_7" Then
            pic_7_grp9x.Image.Save(pic_7_grp9x.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P9_8" Then
            pic_8_grp9x.Image.Save(pic_8_grp9x.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P9_9" Then
            pic_9_grp9x.Image.Save(pic_9_grp9x.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_1" Then
            pic_1_grpFullMouth.Image.Save(pic_1_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_2" Then
            pic_2_grpFullMouth.Image.Save(pic_2_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_3" Then
            pic_3_grpFullMouth.Image.Save(pic_3_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_4" Then
            pic_4_grpFullMouth.Image.Save(pic_4_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_5" Then
            pic_5_grpFullMouth.Image.Save(pic_5_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_6" Then
            pic_6_grpFullMouth.Image.Save(pic_6_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_7" Then
            pic_7_grpFullMouth.Image.Save(pic_7_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_8" Then
            pic_8_grpFullMouth.Image.Save(pic_8_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_9" Then
            pic_9_grpFullMouth.Image.Save(pic_9_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_10" Then
            pic_10_grpFullMouth.Image.Save(pic_10_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_11" Then
            pic_11_grpFullMouth.Image.Save(pic_11_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_12" Then
            pic_12_grpFullMouth.Image.Save(pic_12_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_13" Then
            pic_13_grpFullMouth.Image.Save(pic_13_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_14" Then
            pic_14_grpFullMouth.Image.Save(pic_14_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_15" Then
            pic_15_grpFullMouth.Image.Save(pic_15_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_16" Then
            pic_16_grpFullMouth.Image.Save(pic_16_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_17" Then
            pic_17_grpFullMouth.Image.Save(pic_17_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        ElseIf picture = "P18_18" Then
            pic_18_grpFullMouth.Image.Save(pic_18_grpFullMouth.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
    End Sub
    Public Sub FillDetails()
        Call clearImages()
        Panel2.Width = 110
        GroupBox2.Width = Panel2.Width
        Panel3.Left = 110
        Panel3.Width = Me.Width - Panel2.Width
        '' Load images in left side panel with Image Name, Date & Notes
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
        btnImport.Visible = False
        Dim fullpath As String
        Dim folder As String
        Dim dt As New DataTable()
        Dim ptStatus As String
        ''Enable/Disable necessary options after selecting the patient
        SynchronizeToolStripMenuItem.Enabled = True
        StatusToolStripMenuItem.Enabled = True
        ClosePatientToolStripMenuItem.Enabled = True
        SaveToolStripMenuItem.Enabled = True
        ''Display patient current status(Treated/Untreated/Diagnosed/Undiagnosed/Attention)
        ptStatus = ObjClass.ReturnFieldName("select ptReg_status from Master_ptReg where ptReg_id='" & PatientId & "'")
        If ptStatus = "Treated" Then
            TreatedToolStripMenuItem.Checked = True
            UntreatedToolStripMenuItem.Checked = False
            DiagnosedToolStripMenuItem.Checked = False
            UndiagnosedToolStripMenuItem.Checked = False
            AttenToolStripMenuItem.Checked = False
        ElseIf ptStatus = "Untreated" Then
            TreatedToolStripMenuItem.Checked = False
            UntreatedToolStripMenuItem.Checked = True
            DiagnosedToolStripMenuItem.Checked = False
            UndiagnosedToolStripMenuItem.Checked = False
            AttenToolStripMenuItem.Checked = False
        ElseIf ptStatus = "Diagnosed" Then
            TreatedToolStripMenuItem.Checked = False
            UntreatedToolStripMenuItem.Checked = False
            DiagnosedToolStripMenuItem.Checked = True
            UndiagnosedToolStripMenuItem.Checked = False
            AttenToolStripMenuItem.Checked = False
        ElseIf ptStatus = "Undiagnosed" Then
            TreatedToolStripMenuItem.Checked = False
            UntreatedToolStripMenuItem.Checked = False
            DiagnosedToolStripMenuItem.Checked = False
            UndiagnosedToolStripMenuItem.Checked = True
            AttenToolStripMenuItem.Checked = False
        ElseIf ptStatus = "Attention" Then
            TreatedToolStripMenuItem.Checked = False
            UntreatedToolStripMenuItem.Checked = False
            DiagnosedToolStripMenuItem.Checked = False
            UndiagnosedToolStripMenuItem.Checked = False
            AttenToolStripMenuItem.Checked = True
        End If

        Dim dt1 As New DataTable()
        dt1 = ObjClass.returndatatable("select * from master_ptreg where ptreg_id='" & PatientId & "'", dt)
        Me.Text = "LynxVision Professional - " & dt1.Rows(0).Item("ptreg_Firstname") & " " & dt1.Rows(0).Item("ptreg_lastname")
        dt = ObjClass.returndatatable("select * from patient_Image where image_ptRegId='" & PatientId & "' and image_isdeleted='0'", dt)
        If dt.Rows.Count > 0 Then
            
            folder = ObjClass.ReturnFieldName("select ptReg_code from Master_ptReg where ptReg_id='" & PatientId & "'")
            fullpath = Application.StartupPath & "\Images\" & folder
            Dim FileDirectory As New IO.DirectoryInfo(fullpath)
            Dim FileJpg As IO.FileInfo() = FileDirectory.GetFiles("*.jpg")
            'Dim FileGif As IO.FileInfo() = FileDirectory.GetFiles("*.gif")
            'Dim FileBmp As IO.FileInfo() = FileDirectory.GetFiles("*.bmp")
            Dim Top As Integer = 0
            Dim count As Integer = 0
            For Each File As IO.FileInfo In FileJpg
                Dim PicBox As New PictureBox
                Dim lbl As New Label
                Dim lblNotes As New Label
                PicBox.ImageLocation = fullpath & "\" & File.Name
                PicBox.Width = 100
                PicBox.Height = 50
                PicBox.Top = 35 + Top
                PicBox.Left = 8
                PicBox.SizeMode = PictureBoxSizeMode.Zoom
                PicBox.BorderStyle = BorderStyle.FixedSingle
                PicBox.ContextMenuStrip = ContextMenuStrip2
                PicBox.Tag = File.Name
                PicBox.AllowDrop = True
                PicBox.BorderStyle = BorderStyle.None
                lbl.Text = ObjClass.ReturnFieldName("select image_name from patient_image where image_ptregid='" & PatientId & "' and image_path='" & File.Name & "'")
                lbl.Top = PicBox.Top + PicBox.Height + 5
                lbl.Left = 5
                lbl.Width = 105
                lbl.ForeColor = White
                Dim strDate = PicBox.ImageLocation
                strDate = ObjClass.ReturnFieldName("select image_D from patient_image where image_ptregid='" & PatientId & "' and image_path='" & File.Name & "'") ' System.IO.File.GetLastWriteTime(strDate).ToShortDateString()
                lbl.Text = lbl.Text & "  " & strDate
                lbl.Height = 12
                Me.GroupBox2.Controls.Add(PicBox)
                Me.GroupBox2.Controls.Add(lbl)
                lblNotes.Text = ObjClass.ReturnFieldName("select image_Notes from patient_image where image_ptregid='" & PatientId & "' and image_path='" & File.Name & "'")

                lblNotes.Top = PicBox.Top + PicBox.Height + lbl.Height + 10
                lblNotes.Left = 5
                lblNotes.Width = 105
                lblNotes.ForeColor = White
                lblNotes.Height = 15
                Me.GroupBox2.Controls.Add(lblNotes)
                'Me.GroupBox2.Controls.Add(lblDt)
                Top = PicBox.Top + 60

                AddHandler PicBox.Click, AddressOf PicBox_Click
                AddHandler PicBox.MouseDown, AddressOf PicBox_mousedown
                AddHandler PicBox.MouseMove, AddressOf PicBox_MouseMove
                AddHandler PicBox.DragEnter, AddressOf PicBox_DragEnter

                If PicBox.Top + 200 > Me.Height Then
                    Panel2.AutoScroll = True
                End If

                count = count + 1
            Next
            '  grp2X.Visible = True
        End If
        If Not Pic_1_grp1X.Image Is Nothing Then
            If Not File.Exists(Pic_1_grp1X.ImageLocation) Then
                Pic_1_grp1X.Image = Nothing
                Pic_1_grp1X.ImageLocation = ""
            Else
                Pic_1_grp1X.Image = Pic_1_grp1X.Image
            End If
        End If
        If Not pic_1_grp2X.Image Is Nothing Then
            If Not File.Exists(pic_1_grp2X.ImageLocation) Then
                pic_1_grp2X.Image = Nothing
                pic_1_grp2X.ImageLocation = ""
            Else
                pic_1_grp2X.Image = pic_1_grp2X.Image
            End If
        End If
        If Not pic_2_grp2X.Image Is Nothing Then
            If Not File.Exists(pic_2_grp2X.ImageLocation) Then
                pic_2_grp2X.Image = Nothing
                pic_2_grp2X.ImageLocation = ""
            Else
                pic_2_grp2X.Image = pic_2_grp2X.Image
            End If
        End If
        If Not Pic_1_grp4X.Image Is Nothing Then
            If Not File.Exists(Pic_1_grp4X.ImageLocation) Then
                Pic_1_grp4X.Image = Nothing
                Pic_1_grp4X.ImageLocation = ""
            Else
                Pic_1_grp4X.Image = Pic_1_grp4X.Image
            End If
        End If
        If Not Pic_2_grp4X.Image Is Nothing Then
            If Not File.Exists(Pic_2_grp4X.ImageLocation) Then
                Pic_2_grp4X.Image = Nothing
                Pic_2_grp4X.ImageLocation = ""
            Else
                Pic_2_grp4X.Image = Pic_2_grp4X.Image
            End If
        End If
        If Not Pic_3_grp4X.Image Is Nothing Then
            If Not File.Exists(Pic_3_grp4X.ImageLocation) Then
                Pic_3_grp4X.Image = Nothing
                Pic_3_grp4X.ImageLocation = ""
            Else
                Pic_3_grp4X.Image = Pic_3_grp4X.Image
            End If
        End If
        If Not Pic_4_grp4X.Image Is Nothing Then
            If Not File.Exists(Pic_4_grp4X.ImageLocation) Then
                Pic_4_grp4X.Image = Nothing
                Pic_4_grp4X.ImageLocation = ""
            Else
                Pic_4_grp4X.Image = Pic_4_grp4X.Image
            End If
        End If
        If Not pic_1_grp9x.Image Is Nothing Then
            If Not File.Exists(pic_1_grp9x.ImageLocation) Then
                pic_1_grp9x.Image = Nothing
                pic_1_grp9x.ImageLocation = ""
            Else
                pic_1_grp9x.Image = pic_1_grp9x.Image
            End If
        End If
        If Not pic_2_grp9x.Image Is Nothing Then
            If Not File.Exists(pic_2_grp9x.ImageLocation) Then
                pic_2_grp9x.Image = Nothing
                pic_2_grp9x.ImageLocation = ""
            Else
                pic_2_grp9x.Image = pic_2_grp9x.Image
            End If
        End If
        If Not pic_3_grp9x.Image Is Nothing Then
            If Not File.Exists(pic_3_grp9x.ImageLocation) Then
                pic_3_grp9x.Image = Nothing
                pic_3_grp9x.ImageLocation = ""
            Else
                pic_3_grp9x.Image = pic_3_grp9x.Image
            End If
        End If
        If Not pic_4_grp9x.Image Is Nothing Then
            If Not File.Exists(pic_4_grp9x.ImageLocation) Then
                pic_4_grp9x.Image = Nothing
                pic_4_grp9x.ImageLocation = ""
            Else
                pic_4_grp9x.Image = pic_4_grp9x.Image
            End If
        End If
        If Not pic_5_grp9x.Image Is Nothing Then
            If Not File.Exists(pic_5_grp9x.ImageLocation) Then
                pic_5_grp9x.Image = Nothing
                pic_5_grp9x.ImageLocation = ""
            Else
                pic_5_grp9x.Image = pic_5_grp9x.Image
            End If
        End If
        If Not pic_6_grp9x.Image Is Nothing Then
            If Not File.Exists(pic_6_grp9x.ImageLocation) Then
                pic_6_grp9x.Image = Nothing
                pic_6_grp9x.ImageLocation = ""
            Else
                pic_6_grp9x.Image = pic_6_grp9x.Image
            End If
        End If
        If Not pic_7_grp9x.Image Is Nothing Then
            If Not File.Exists(pic_7_grp9x.ImageLocation) Then
                pic_7_grp9x.Image = Nothing
                pic_7_grp9x.ImageLocation = ""
            Else
                pic_7_grp9x.Image = pic_7_grp9x.Image
            End If
        End If
        If Not pic_8_grp9x.Image Is Nothing Then
            If Not File.Exists(pic_8_grp9x.ImageLocation) Then
                pic_8_grp9x.Image = Nothing
                pic_8_grp9x.ImageLocation = ""
            Else
                pic_8_grp9x.Image = pic_8_grp9x.Image
            End If
        End If
        If Not pic_9_grp9x.Image Is Nothing Then
            If Not File.Exists(pic_9_grp9x.ImageLocation) Then
                pic_9_grp9x.Image = Nothing
                pic_9_grp9x.ImageLocation = ""
            Else
                pic_9_grp9x.Image = pic_9_grp9x.Image
            End If
        End If

        '' 4 X 4 Grid View
        If Not pic_1_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_1_grp16X.ImageLocation) Then
                pic_1_grp16X.Image = Nothing
                pic_1_grp16X.ImageLocation = ""
            Else
                pic_1_grp16X.Image = pic_1_grp16X.Image
            End If
        End If
        If Not pic_2_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_2_grp16X.ImageLocation) Then
                pic_2_grp16X.Image = Nothing
                pic_2_grp16X.ImageLocation = ""
            Else
                pic_2_grp16X.Image = pic_2_grp16X.Image
            End If
        End If
        If Not pic_3_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_3_grp16X.ImageLocation) Then
                pic_3_grp16X.Image = Nothing
                pic_3_grp16X.ImageLocation = ""
            Else
                pic_3_grp16X.Image = pic_3_grp16X.Image
            End If
        End If
        If Not pic_4_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_4_grp16X.ImageLocation) Then
                pic_4_grp16X.Image = Nothing
                pic_4_grp16X.ImageLocation = ""
            Else
                pic_4_grp16X.Image = pic_4_grp16X.Image
            End If
        End If
        If Not pic_5_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_5_grp16X.ImageLocation) Then
                pic_5_grp16X.Image = Nothing
                pic_5_grp16X.ImageLocation = ""
            Else
                pic_5_grp16X.Image = pic_5_grp16X.Image
            End If
        End If
        If Not pic_6_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_6_grp16X.ImageLocation) Then
                pic_6_grp16X.Image = Nothing
                pic_6_grp16X.ImageLocation = ""
            Else
                pic_6_grp16X.Image = pic_6_grp16X.Image
            End If
        End If
        If Not pic_7_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_7_grp16X.ImageLocation) Then
                pic_7_grp16X.Image = Nothing
                pic_7_grp16X.ImageLocation = ""
            Else
                pic_7_grp16X.Image = pic_7_grp16X.Image
            End If
        End If
        If Not pic_8_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_8_grp16X.ImageLocation) Then
                pic_8_grp16X.Image = Nothing
                pic_8_grp16X.ImageLocation = ""
            Else
                pic_8_grp16X.Image = pic_8_grp16X.Image
            End If
        End If
        If Not pic_9_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_9_grp16X.ImageLocation) Then
                pic_9_grp16X.Image = Nothing
                pic_9_grp16X.ImageLocation = ""
            Else
                pic_9_grp16X.Image = pic_9_grp16X.Image
            End If
        End If
        If Not pic_10_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_10_grp16X.ImageLocation) Then
                pic_10_grp16X.Image = Nothing
                pic_10_grp16X.ImageLocation = ""
            Else
                pic_10_grp16X.Image = pic_10_grp16X.Image
            End If
        End If
        If Not pic_11_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_11_grp16X.ImageLocation) Then
                pic_11_grp16X.Image = Nothing
                pic_11_grp16X.ImageLocation = ""
            Else
                pic_11_grp16X.Image = pic_11_grp16X.Image
            End If
        End If
        If Not pic_12_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_12_grp16X.ImageLocation) Then
                pic_12_grp16X.Image = Nothing
                pic_12_grp16X.ImageLocation = ""
            Else
                pic_12_grp16X.Image = pic_12_grp16X.Image
            End If
        End If
        If Not pic_13_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_13_grp16X.ImageLocation) Then
                pic_13_grp16X.Image = Nothing
                pic_13_grp16X.ImageLocation = ""
            Else
                pic_13_grp16X.Image = pic_13_grp16X.Image
            End If
        End If
        If Not pic_14_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_14_grp16X.ImageLocation) Then
                pic_14_grp16X.Image = Nothing
                pic_14_grp16X.ImageLocation = ""
            Else
                pic_14_grp16X.Image = pic_14_grp16X.Image
            End If
        End If
        If Not pic_15_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_15_grp16X.ImageLocation) Then
                pic_15_grp16X.Image = Nothing
                pic_15_grp16X.ImageLocation = ""
            Else
                pic_15_grp16X.Image = pic_15_grp16X.Image
            End If
        End If
        If Not pic_16_grp16X.Image Is Nothing Then
            If Not File.Exists(pic_16_grp16X.ImageLocation) Then
                pic_16_grp16X.Image = Nothing
                pic_16_grp16X.ImageLocation = ""
            Else
                pic_16_grp16X.Image = pic_16_grp16X.Image
            End If
        End If

        '' Full mouth series view
        If Not pic_1_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_1_grpFullMouth.ImageLocation) Then
                pic_1_grpFullMouth.Image = Nothing
                pic_1_grpFullMouth.ImageLocation = ""
            Else
                pic_1_grpFullMouth.Image = pic_1_grpFullMouth.Image
            End If
        End If
        If Not pic_2_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_2_grpFullMouth.ImageLocation) Then
                pic_2_grpFullMouth.Image = Nothing
                pic_2_grpFullMouth.ImageLocation = ""
            Else
                pic_2_grpFullMouth.Image = pic_2_grpFullMouth.Image
            End If
        End If
        If Not pic_3_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_3_grpFullMouth.ImageLocation) Then
                pic_3_grpFullMouth.Image = Nothing
                pic_3_grpFullMouth.ImageLocation = ""
            Else
                pic_3_grpFullMouth.Image = pic_3_grpFullMouth.Image
            End If
        End If
        If Not pic_4_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_4_grpFullMouth.ImageLocation) Then
                pic_4_grpFullMouth.Image = Nothing
                pic_4_grpFullMouth.ImageLocation = ""
            Else
                pic_4_grpFullMouth.Image = pic_4_grpFullMouth.Image
            End If
        End If
        If Not pic_5_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_5_grpFullMouth.ImageLocation) Then
                pic_5_grpFullMouth.Image = Nothing
                pic_5_grpFullMouth.ImageLocation = ""
            Else
                pic_5_grpFullMouth.Image = pic_5_grpFullMouth.Image
            End If
        End If
        If Not pic_6_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_6_grpFullMouth.ImageLocation) Then
                pic_6_grpFullMouth.Image = Nothing
                pic_6_grpFullMouth.ImageLocation = ""
            Else
                pic_6_grpFullMouth.Image = pic_6_grpFullMouth.Image
            End If
        End If
        If Not pic_7_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_7_grpFullMouth.ImageLocation) Then
                pic_7_grpFullMouth.Image = Nothing
                pic_7_grpFullMouth.ImageLocation = ""
            Else
                pic_7_grpFullMouth.Image = pic_7_grpFullMouth.Image
            End If
        End If
        If Not pic_8_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_8_grpFullMouth.ImageLocation) Then
                pic_8_grpFullMouth.Image = Nothing
                pic_8_grpFullMouth.ImageLocation = ""
            Else
                pic_8_grpFullMouth.Image = pic_8_grpFullMouth.Image
            End If
        End If
        If Not pic_9_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_9_grpFullMouth.ImageLocation) Then
                pic_9_grpFullMouth.Image = Nothing
                pic_9_grpFullMouth.ImageLocation = ""
            Else
                pic_9_grpFullMouth.Image = pic_9_grpFullMouth.Image
            End If
        End If
        If Not pic_10_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_10_grpFullMouth.ImageLocation) Then
                pic_10_grpFullMouth.Image = Nothing
                pic_10_grpFullMouth.ImageLocation = ""
            Else
                pic_10_grpFullMouth.Image = pic_10_grpFullMouth.Image
            End If
        End If
        If Not pic_11_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_11_grpFullMouth.ImageLocation) Then
                pic_11_grpFullMouth.Image = Nothing
                pic_11_grpFullMouth.ImageLocation = ""
            Else
                pic_11_grpFullMouth.Image = pic_11_grpFullMouth.Image
            End If
        End If
        If Not pic_12_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_12_grpFullMouth.ImageLocation) Then
                pic_12_grpFullMouth.Image = Nothing
                pic_12_grpFullMouth.ImageLocation = ""
            Else
                pic_12_grpFullMouth.Image = pic_12_grpFullMouth.Image
            End If
        End If
        If Not pic_13_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_13_grpFullMouth.ImageLocation) Then
                pic_13_grpFullMouth.Image = Nothing
                pic_13_grpFullMouth.ImageLocation = ""
            Else
                pic_13_grpFullMouth.Image = pic_13_grpFullMouth.Image
            End If
        End If
        If Not pic_14_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_14_grpFullMouth.ImageLocation) Then
                pic_14_grpFullMouth.Image = Nothing
                pic_14_grpFullMouth.ImageLocation = ""
            Else
                pic_14_grpFullMouth.Image = pic_14_grpFullMouth.Image
            End If
        End If
        If Not pic_15_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_15_grpFullMouth.ImageLocation) Then
                pic_15_grpFullMouth.Image = Nothing
                pic_15_grpFullMouth.ImageLocation = ""
            Else
                pic_15_grpFullMouth.Image = pic_15_grpFullMouth.Image
            End If
        End If
        If Not pic_16_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_16_grpFullMouth.ImageLocation) Then
                pic_16_grpFullMouth.Image = Nothing
                pic_16_grpFullMouth.ImageLocation = ""
            Else
                pic_16_grpFullMouth.Image = pic_16_grpFullMouth.Image
            End If
        End If
        If Not pic_17_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_17_grpFullMouth.ImageLocation) Then
                pic_17_grpFullMouth.Image = Nothing
                pic_17_grpFullMouth.ImageLocation = ""
            Else
                pic_17_grpFullMouth.Image = pic_17_grpFullMouth.Image
            End If
        End If
        If Not pic_18_grpFullMouth.Image Is Nothing Then
            If Not File.Exists(pic_18_grpFullMouth.ImageLocation) Then
                pic_18_grpFullMouth.Image = Nothing
                pic_18_grpFullMouth.ImageLocation = ""
            Else
                pic_18_grpFullMouth.Image = pic_18_grpFullMouth.Image
            End If
        End If
    End Sub

    Private Sub PicBox_Click(ByVal sender As Object, ByVal e As EventArgs)
        Pic = ""
        Dim pic1 As PictureBox = DirectCast(sender, PictureBox)
        currentImage = ""
        If grp1X.Visible = True Then
            If Pic_1_grp1X.ImageLocation = pic1.ImageLocation Then
                Exit Sub
            End If
            If Pic_1_grp1X.Image Is Nothing Then
                Pic_1_grp1X.ImageLocation = pic1.ImageLocation
                Pic_1_grp1X.Tag = pic1.Tag
                currentImage = "1X1"
                Exit Sub
            End If
        ElseIf grp2X.Visible = True Then
            If pic_1_grp2X.ImageLocation = pic1.ImageLocation Or pic_2_grp2X.ImageLocation = pic1.ImageLocation Then
                Exit Sub
            End If
            If pic_1_grp2X.Image Is Nothing Then
                pic_1_grp2X.ImageLocation = pic1.ImageLocation
                pic_1_grp2X.Tag = pic1.Tag
                currentImage = "2X1"
                Exit Sub
            End If
            If pic_2_grp2X.Image Is Nothing Then
                pic_2_grp2X.ImageLocation = pic1.ImageLocation
                pic_2_grp2X.Tag = pic1.Tag
                currentImage = "2X2"
                Exit Sub
            End If
        ElseIf grp4X.Visible = True Then
            If Pic_1_grp4X.ImageLocation = pic1.ImageLocation Or Pic_2_grp4X.ImageLocation = pic1.ImageLocation Or Pic_3_grp4X.ImageLocation = pic1.ImageLocation Or Pic_4_grp4X.ImageLocation = pic1.ImageLocation Then
                Exit Sub
            End If
            If Pic_1_grp4X.Image Is Nothing Then
                Pic_1_grp4X.ImageLocation = pic1.ImageLocation
                Pic_1_grp4X.Tag = pic1.Tag
                currentImage = "4X1"
                Exit Sub
            End If
            If Pic_2_grp4X.Image Is Nothing Then
                Pic_2_grp4X.ImageLocation = pic1.ImageLocation
                Pic_2_grp4X.Tag = pic1.Tag
                currentImage = "4X2"
                Exit Sub
            End If
            If Pic_3_grp4X.Image Is Nothing Then
                Pic_3_grp4X.ImageLocation = pic1.ImageLocation
                Pic_3_grp4X.Tag = pic1.Tag
                currentImage = "4X3"
                Exit Sub
            End If
            If Pic_4_grp4X.Image Is Nothing Then
                Pic_4_grp4X.ImageLocation = pic1.ImageLocation
                Pic_4_grp4X.Tag = pic1.Tag
                currentImage = "4X4"
                Exit Sub
            End If
        ElseIf grp9X.Visible = True Then
            If pic_1_grp9x.ImageLocation = pic1.ImageLocation Or pic_2_grp9x.ImageLocation = pic1.ImageLocation Or pic_3_grp9x.ImageLocation = pic1.ImageLocation Or pic_4_grp9x.ImageLocation = pic1.ImageLocation Or pic_5_grp9x.ImageLocation = pic1.ImageLocation Or pic_6_grp9x.ImageLocation = pic1.ImageLocation Or pic_7_grp9x.ImageLocation = pic1.ImageLocation Or pic_8_grp9x.ImageLocation = pic1.ImageLocation Or pic_9_grp9x.ImageLocation = pic1.ImageLocation Then
                Exit Sub
            End If
            If pic_1_grp9x.Image Is Nothing Then
                pic_1_grp9x.ImageLocation = pic1.ImageLocation
                pic_1_grp9x.Tag = pic1.Tag
                currentImage = "9X1"
                Exit Sub
            End If
            If pic_2_grp9x.Image Is Nothing Then
                pic_2_grp9x.ImageLocation = pic1.ImageLocation
                pic_2_grp9x.Tag = pic1.Tag
                currentImage = "9X2"
                Exit Sub
            End If
            If pic_3_grp9x.Image Is Nothing Then
                pic_3_grp9x.ImageLocation = pic1.ImageLocation
                pic_3_grp9x.Tag = pic1.Tag
                currentImage = "9X3"
                Exit Sub
            End If
            If pic_4_grp9x.Image Is Nothing Then
                pic_4_grp9x.ImageLocation = pic1.ImageLocation
                pic_4_grp9x.Tag = pic1.Tag
                currentImage = "9X4"
                Exit Sub
            End If
            If pic_5_grp9x.Image Is Nothing Then
                pic_5_grp9x.ImageLocation = pic1.ImageLocation
                pic_5_grp9x.Tag = pic1.Tag
                currentImage = "9X5"
                Exit Sub
            End If
            If pic_6_grp9x.Image Is Nothing Then
                pic_6_grp9x.ImageLocation = pic1.ImageLocation
                pic_6_grp9x.Tag = pic1.Tag
                currentImage = "9X6"
                Exit Sub
            End If
            If pic_7_grp9x.ImageLocation = Nothing Then
                pic_7_grp9x.ImageLocation = pic1.ImageLocation
                currentImage = "9X7"
                Exit Sub
            End If
            If pic_8_grp9x.Image Is Nothing Then
                pic_8_grp9x.ImageLocation = pic1.ImageLocation
                pic_8_grp9x.Tag = pic1.Tag
                currentImage = "9X8"
                Exit Sub
            End If
            If pic_9_grp9x.Image Is Nothing Then
                pic_9_grp9x.ImageLocation = pic1.ImageLocation
                pic_9_grp9x.Tag = pic1.Tag
                currentImage = "9X9"
                Exit Sub
            End If
        ElseIf grp16X.Visible = True Then
            If pic_1_grp16X.ImageLocation = pic1.ImageLocation Or pic_2_grp16X.ImageLocation = pic1.ImageLocation Or pic_3_grp16X.ImageLocation = pic1.ImageLocation Or pic_4_grp16X.ImageLocation = pic1.ImageLocation Or pic_5_grp16X.ImageLocation = pic1.ImageLocation Or pic_6_grp16X.ImageLocation = pic1.ImageLocation Or pic_7_grp16X.ImageLocation = pic1.ImageLocation Or pic_8_grp16X.ImageLocation = pic1.ImageLocation Or pic_9_grp16X.ImageLocation = pic1.ImageLocation Or pic_10_grp16X.ImageLocation = pic1.ImageLocation Or pic_11_grp16X.ImageLocation = pic1.ImageLocation Or pic_12_grp16X.ImageLocation = pic1.ImageLocation Or pic_13_grp16X.ImageLocation = pic1.ImageLocation Or pic_14_grp16X.ImageLocation = pic1.ImageLocation Or pic_15_grp16X.ImageLocation = pic1.ImageLocation Or pic_16_grp16X.ImageLocation = pic1.ImageLocation Then
                Exit Sub
            End If
            If pic_1_grp16X.Image Is Nothing Then
                pic_1_grp16X.ImageLocation = pic1.ImageLocation
                pic_1_grp16X.Tag = pic1.Tag
                currentImage = "16X1"
                Exit Sub
            End If
            If pic_2_grp16X.Image Is Nothing Then
                pic_2_grp16X.ImageLocation = pic1.ImageLocation
                pic_2_grp16X.Tag = pic1.Tag
                currentImage = "16X2"
                Exit Sub
            End If
            If pic_3_grp16X.Image Is Nothing Then
                pic_3_grp16X.ImageLocation = pic1.ImageLocation
                pic_3_grp16X.Tag = pic1.Tag
                currentImage = "16X3"
                Exit Sub
            End If
            If pic_4_grp16X.Image Is Nothing Then
                pic_4_grp16X.ImageLocation = pic1.ImageLocation
                pic_4_grp16X.Tag = pic1.Tag
                currentImage = "16X4"
                Exit Sub
            End If
            If pic_5_grp16X.Image Is Nothing Then
                pic_5_grp16X.ImageLocation = pic1.ImageLocation
                pic_5_grp16X.Tag = pic1.Tag
                currentImage = "16X5"
                Exit Sub
            End If
            If pic_6_grp16X.Image Is Nothing Then
                pic_6_grp16X.ImageLocation = pic1.ImageLocation
                pic_6_grp16X.Tag = pic1.Tag
                currentImage = "16X6"
                Exit Sub
            End If
            If pic_7_grp16X.ImageLocation = Nothing Then
                pic_7_grp16X.ImageLocation = pic1.ImageLocation
                pic_7_grp16X.Tag = pic1.Tag
                currentImage = "16X7"
                Exit Sub
            End If
            If pic_8_grp16X.Image Is Nothing Then
                pic_8_grp16X.ImageLocation = pic1.ImageLocation
                pic_8_grp16X.Tag = pic1.Tag
                currentImage = "16X8"
                Exit Sub
            End If
            If pic_9_grp16X.Image Is Nothing Then
                pic_9_grp16X.ImageLocation = pic1.ImageLocation
                pic_9_grp16X.Tag = pic1.Tag
                currentImage = "16X9"
                Exit Sub
            End If
            If pic_10_grp16X.Image Is Nothing Then
                pic_10_grp16X.ImageLocation = pic1.ImageLocation
                pic_10_grp16X.Tag = pic1.Tag
                currentImage = "16X10"
                Exit Sub
            End If
            If pic_11_grp16X.Image Is Nothing Then
                pic_11_grp16X.ImageLocation = pic1.ImageLocation
                pic_11_grp16X.Tag = pic1.Tag
                currentImage = "16X11"
                Exit Sub
            End If
            If pic_12_grp16X.Image Is Nothing Then
                pic_12_grp16X.ImageLocation = pic1.ImageLocation
                pic_12_grp16X.Tag = pic1.Tag
                currentImage = "16X12"
                Exit Sub
            End If
            If pic_13_grp16X.Image Is Nothing Then
                pic_13_grp16X.ImageLocation = pic1.ImageLocation
                pic_13_grp16X.Tag = pic1.Tag
                currentImage = "16X13"
                Exit Sub
            End If
            If pic_14_grp16X.Image Is Nothing Then
                pic_14_grp16X.ImageLocation = pic1.ImageLocation
                pic_14_grp16X.Tag = pic1.Tag
                currentImage = "16X14"
                Exit Sub
            End If
            If pic_15_grp16X.Image Is Nothing Then
                pic_15_grp16X.ImageLocation = pic1.ImageLocation
                pic_15_grp16X.Tag = pic1.Tag
                currentImage = "16X15"
                Exit Sub
            End If
            If pic_16_grp16X.ImageLocation = Nothing Then
                pic_16_grp16X.ImageLocation = pic1.ImageLocation
                pic_16_grp16X.Tag = pic1.Tag
                currentImage = "16X16"
                Exit Sub
            End If
        ElseIf grpFullMouth.Visible = True Then
            If pic_1_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_2_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_3_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_4_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_5_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_6_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_7_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_8_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_9_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_10_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_11_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_12_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_13_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_14_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_15_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_16_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_17_grpFullMouth.ImageLocation = pic1.ImageLocation Or pic_18_grpFullMouth.ImageLocation = pic1.ImageLocation Then
                Exit Sub
            End If
            If pic_1_grpFullMouth.Image Is Nothing Then
                pic_1_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_1_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X1"
                Exit Sub
            End If
            If pic_2_grpFullMouth.Image Is Nothing Then
                pic_2_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_2_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X2"
                Exit Sub
            End If
            If pic_3_grpFullMouth.Image Is Nothing Then
                pic_3_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_3_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X3"
                Exit Sub
            End If
            If pic_4_grpFullMouth.Image Is Nothing Then
                pic_4_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_4_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X4"
                Exit Sub
            End If
            If pic_5_grpFullMouth.Image Is Nothing Then
                pic_5_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_5_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X5"
                Exit Sub
            End If
            If pic_6_grpFullMouth.Image Is Nothing Then
                pic_6_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_6_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X6"
                Exit Sub
            End If
            If pic_7_grpFullMouth.ImageLocation = Nothing Then
                pic_7_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_7_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X7"
                Exit Sub
            End If
            If pic_8_grpFullMouth.Image Is Nothing Then
                pic_8_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_8_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X8"
                Exit Sub
            End If
            If pic_9_grpFullMouth.Image Is Nothing Then
                pic_9_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_9_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X9"
                Exit Sub
            End If
            If pic_10_grpFullMouth.Image Is Nothing Then
                pic_10_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_10_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X10"
                Exit Sub
            End If
            If pic_11_grpFullMouth.Image Is Nothing Then
                pic_11_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_11_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X11"
                Exit Sub
            End If
            If pic_12_grpFullMouth.Image Is Nothing Then
                pic_12_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_12_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X12"
                Exit Sub
            End If
            If pic_13_grpFullMouth.Image Is Nothing Then
                pic_13_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_13_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X13"
                Exit Sub
            End If
            If pic_14_grpFullMouth.Image Is Nothing Then
                pic_14_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_14_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X14"
                Exit Sub
            End If
            If pic_15_grpFullMouth.Image Is Nothing Then
                pic_15_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_15_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X15"
                Exit Sub
            End If
            If pic_16_grpFullMouth.ImageLocation = Nothing Then
                pic_16_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_16_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X16"
                Exit Sub
            End If
            If pic_17_grpFullMouth.Image Is Nothing Then
                pic_17_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_17_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X17"
                Exit Sub
            End If
            If pic_18_grpFullMouth.Image Is Nothing Then
                pic_18_grpFullMouth.ImageLocation = pic1.ImageLocation
                pic_18_grpFullMouth.Tag = pic1.Tag
                currentImage = "18X18"
                Exit Sub
            End If
        End If

    End Sub

    Private Sub PicBox_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub PicBox_mousedown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim con As Control
        con = sender
        FName = con.Tag
        Dim pic1 As PictureBox = DirectCast(sender, PictureBox)
        path = pic1.ImageLocation
        'If Not pic_1_grp2X.Image Is Nothing Then
        m_MouseIsDown = True
        '    pic = "2X1"
        '    path = pic.ImageLocation
        'End If
    End Sub

    Private Sub PicBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim pic1 As PictureBox = DirectCast(sender, PictureBox)
        If m_MouseIsDown Then
            pic1.DoDragDrop(pic1.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        End If
        Pic = ""
        m_MouseIsDown = False
    End Sub

    Private Sub SelectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectToolStripMenuItem.Click
        ''Panel2.Width = 110
        ''GroupBox2.Width = 114
        ''Panel3.Left = 110
        ''Panel3.Width = Me.Width - Panel2.Width
        ''Call ClosePatientToolStripMenuItem_Click(sender, e)

        frm_Patient_Search.Show()
    End Sub
   
    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        PatientId = ""
        Call ClosePatientToolStripMenuItem_Click(sender, e)
        'frm_Patient_Registration.MdiParent = MDI
        frm_Patient_Registration.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        If grpViewer.Visible = True Then
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
        Panel2.Width = 110
        GroupBox2.Width = 114
        Panel3.Left = 110
        Panel3.Width = Me.Width - Panel2.Width
        grp1X.Visible = False
        grp2X.Visible = True
        grp4X.Visible = False
        grp9X.Visible = False
        grp16X.Visible = False
        grpFullMouth.Visible = False
        GroupBox3.Visible = False
        grpViewer.Visible = False
        btnImport.Visible = False
        Call FillDetails()
    End Sub

    Private Sub ScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScreenToolStripMenuItem.Click
        If grpViewer.Visible = True Then
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
        Panel2.Width = 110
        GroupBox2.Width = 114
        Panel3.Left = 110
        Panel3.Width = Me.Width - Panel2.Width
        grp1X.Visible = False
        grp4X.Visible = True
        grp2X.Visible = False
        grp9X.Visible = False
        grp16X.Visible = False
        grpFullMouth.Visible = False
        GroupBox3.Visible = False
        grpViewer.Visible = False
        btnImport.Visible = False
        Call FillDetails()
    End Sub

    Private Sub ClosePatientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClosePatientToolStripMenuItem.Click
        SaveToolStripMenuItem.Enabled = False
        StatusToolStripMenuItem.Enabled = False
        ClosePatientToolStripMenuItem.Enabled = False
        SynchronizeToolStripMenuItem.Enabled = False
        ExportOriginalToolStripMenuItem.Enabled = False
        ExportProcessedToolStripMenuItem.Enabled = False
        CopyToolStripMenuItem.Enabled = False
        DuplicateToolStripMenuItem.Enabled = True
        Panel2.Width = 110
        GroupBox2.Width = 114
        Panel3.Left = 110
        Panel3.Width = Me.Width - Panel2.Width
        grp1X.Visible = False
        grp2X.Visible = False
        grp4X.Visible = False
        grp9X.Visible = False
        grp16X.Visible = False
        grpFullMouth.Visible = False
        GroupBox3.Visible = True
        grpViewer.Visible = False
        btnImport.Visible = False
        Me.Text = "LynxVision Professional"
        PatientId = ""
        Panel2.AutoScroll = False
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
        Pic_1_grp1X.Image = Nothing
        pic_1_grp2X.Image = Nothing
        pic_2_grp2X.Image = Nothing
        Pic_1_grp4X.Image = Nothing
        Pic_2_grp4X.Image = Nothing
        Pic_3_grp4X.Image = Nothing
        Pic_4_grp4X.Image = Nothing
        pic_1_grp9x.Image = Nothing
        pic_2_grp9x.Image = Nothing
        pic_3_grp9x.Image = Nothing
        pic_4_grp9x.Image = Nothing
        pic_5_grp9x.Image = Nothing
        pic_6_grp9x.Image = Nothing
        pic_7_grp9x.Image = Nothing
        pic_8_grp9x.Image = Nothing
        pic_9_grp9x.Image = Nothing
        pic_1_grp16X.Image = Nothing
        pic_2_grp16X.Image = Nothing
        pic_3_grp16X.Image = Nothing
        pic_4_grp16X.Image = Nothing
        pic_5_grp16X.Image = Nothing
        pic_6_grp16X.Image = Nothing
        pic_7_grp16X.Image = Nothing
        pic_8_grp16X.Image = Nothing
        pic_9_grp16X.Image = Nothing
        pic_10_grp16X.Image = Nothing
        pic_11_grp16X.Image = Nothing
        pic_12_grp16X.Image = Nothing
        pic_13_grp16X.Image = Nothing
        pic_14_grp16X.Image = Nothing
        pic_15_grp16X.Image = Nothing
        pic_16_grp16X.Image = Nothing
        pic_1_grp2X.ImageLocation = Nothing
        pic_2_grp2X.ImageLocation = Nothing
        Pic_1_grp4X.ImageLocation = Nothing
        Pic_2_grp4X.ImageLocation = Nothing
        Pic_3_grp4X.ImageLocation = Nothing
        Pic_4_grp4X.ImageLocation = Nothing
        pic_1_grp9x.ImageLocation = Nothing
        pic_2_grp9x.ImageLocation = Nothing
        pic_3_grp9x.ImageLocation = Nothing
        pic_4_grp9x.ImageLocation = Nothing
        pic_5_grp9x.ImageLocation = Nothing
        pic_6_grp9x.ImageLocation = Nothing
        pic_7_grp9x.ImageLocation = Nothing
        pic_8_grp9x.ImageLocation = Nothing
        pic_9_grp9x.ImageLocation = Nothing
    End Sub

    Private Sub clearImages()
        Pic_1_grp1X.Image = Nothing
        pic_1_grp2X.Image = Nothing
        pic_2_grp2X.Image = Nothing
        Pic_1_grp4X.Image = Nothing
        Pic_2_grp4X.Image = Nothing
        Pic_3_grp4X.Image = Nothing
        Pic_4_grp4X.Image = Nothing
        pic_1_grp9x.Image = Nothing
        pic_2_grp9x.Image = Nothing
        pic_3_grp9x.Image = Nothing
        pic_4_grp9x.Image = Nothing
        pic_5_grp9x.Image = Nothing
        pic_6_grp9x.Image = Nothing
        pic_7_grp9x.Image = Nothing
        pic_8_grp9x.Image = Nothing
        pic_9_grp9x.Image = Nothing
        pic_1_grp16X.Image = Nothing
        pic_2_grp16X.Image = Nothing
        pic_3_grp16X.Image = Nothing
        pic_4_grp16X.Image = Nothing
        pic_5_grp16X.Image = Nothing
        pic_6_grp16X.Image = Nothing
        pic_7_grp16X.Image = Nothing
        pic_8_grp16X.Image = Nothing
        pic_9_grp16X.Image = Nothing
        pic_10_grp16X.Image = Nothing
        pic_11_grp16X.Image = Nothing
        pic_12_grp16X.Image = Nothing
        pic_13_grp16X.Image = Nothing
        pic_14_grp16X.Image = Nothing
        pic_15_grp16X.Image = Nothing
        pic_16_grp16X.Image = Nothing
        pic_1_grp2X.ImageLocation = Nothing
        pic_2_grp2X.ImageLocation = Nothing
        Pic_1_grp4X.ImageLocation = Nothing
        Pic_2_grp4X.ImageLocation = Nothing
        Pic_3_grp4X.ImageLocation = Nothing
        Pic_4_grp4X.ImageLocation = Nothing
        pic_1_grp9x.ImageLocation = Nothing
        pic_2_grp9x.ImageLocation = Nothing
        pic_3_grp9x.ImageLocation = Nothing
        pic_4_grp9x.ImageLocation = Nothing
        pic_5_grp9x.ImageLocation = Nothing
        pic_6_grp9x.ImageLocation = Nothing
        pic_7_grp9x.ImageLocation = Nothing
        pic_8_grp9x.ImageLocation = Nothing
        pic_9_grp9x.ImageLocation = Nothing
    End Sub
    Private Sub ScreenToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScreenToolStripMenuItem2.Click
        If grpViewer.Visible = True Then
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
        Panel2.Width = 110
        GroupBox2.Width = 114
        Panel3.Left = 110
        Panel3.Width = Me.Width - Panel2.Width
        grp1X.Visible = False
        grp4X.Visible = False
        grp2X.Visible = False
        grp9X.Visible = True
        grp16X.Visible = False
        grpFullMouth.Visible = False
        GroupBox3.Visible = False
        grpViewer.Visible = False
        btnImport.Visible = False
        Call FillDetails()
    End Sub

    Private Sub ToolStripButton25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frm_Tooth_Numbering.Show()
    End Sub

    Private Sub NewImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewImageToolStripMenuItem.Click
        If PatientId <> "" Then
            'frm_Patient_NewImage.MdiParent = MDI
            frm_Patient_NewImage.Show()
        Else
            MsgBox("Select any Patient!")
        End If
    End Sub

    Private Sub ImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripMenuItem.Click
        If PatientId <> "" Then
            ' frm_Patient_NewImage.MdiParent = MDI
            frm_Patient_NewImage.Show()
        Else
            MsgBox("Select any Patient!")
        End If
    End Sub

    Private Sub ApplicationSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApplicationSettingsToolStripMenuItem.Click
        frm_applicationSettings.Show()
    End Sub

    Private Sub DatabaseSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatabaseSettingsToolStripMenuItem.Click
        frm_databaseSettings.Show()
    End Sub

    Private Sub ExternalApplicationSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExternalApplicationSettingsToolStripMenuItem.Click
        frm_externalapplicationSettingsvb.Show()
    End Sub

    Private Sub CommunicationSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommunicationSettingsToolStripMenuItem.Click
        frm_communicationSettings.Show()
    End Sub

    Private Sub DeviceSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeviceSettingsToolStripMenuItem.Click
        frm_deviceSettings.Show()
    End Sub

    Private Sub XRaySettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XRaySettingsToolStripMenuItem.Click
        frm_xraySettingsvb.Show()
    End Sub

    Private Sub UserWithPrivateSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserWithPrivateSettingsToolStripMenuItem.Click
        frm_userswithprivateSettings.Show()
    End Sub

    Private Sub pic_1_grp2X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_1_grp2X.DoubleClick
        If pic_1_grp2X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub Pic_1_grp2X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_1_grp2X.DragDrop
        If (pic_1_grp2X.ImageLocation = path Or pic_2_grp2X.ImageLocation = path) And Pic = "" Then
            Exit Sub
        End If
        pic_1_grp2X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_1_grp2X.ImageLocation = path
        pic_1_grp2X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "2X2" Then
                pic_2_grp2X.Image = Nothing
                pic_2_grp2X.ImageLocation = ""
            ElseIf Pic = "2X1" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
            Pic = ""
        End If
    End Sub

    Private Sub Pic_1_grp2X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_1_grp2X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub Pic_1_grp2X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_1_grp2X.MouseDown

        If Not pic_1_grp2X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "2X1"
            If Pic = "2X1" And Contrast = 1 Then
                pic_1_grp2X.Cursor = Cursors.NoMoveVert
                pic_2_grp2X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "2X1" And Bright = 1 Then
                pic_1_grp2X.Cursor = Cursors.NoMoveHoriz
                pic_2_grp2X.Cursor = Cursors.Default
                mouseY = e.X
            End If
            FName = pic_1_grp2X.Tag
            path = pic_1_grp2X.ImageLocation
            ExportOriginalToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub


    Private Sub Pic_1_grp2X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_1_grp2X.MouseMove

        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_1_grp2X.Image Is Nothing Then
            pic_1_grp2X.DoDragDrop(pic_1_grp2X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "2X1" Then
                    pic_1_grp2X.Image = Fun_Contrast(pic_1_grp2X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "2X1" Then
                    pic_1_grp2X.Image = Fun_Contrast(pic_1_grp2X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "2X1" Then
                    pic_1_grp2X.Image = Fun_Brightness(pic_1_grp2X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "2X1" Then
                    pic_1_grp2X.Image = Fun_Brightness(pic_1_grp2X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Public Shared Function Fun_Brightness(ByVal sourceBitmap As Bitmap, ByVal threshold As Integer) As Bitmap

        Dim value As Double = threshold * 0.01F
        Dim colorMatrixElements As Single()() = { _
          New Single() {1, 0, 0, 0, 0}, _
          New Single() {0, 1, 0, 0, 0}, _
          New Single() {0, 0, 1, 0, 0}, _
          New Single() {0, 0, 0, 1, 0}, _
          New Single() {value, value, value, 0, 1}}
        Dim colorMatrix As New Imaging.ColorMatrix(colorMatrixElements)
        Dim imageAttributes As New ImageAttributes()


        imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap)



        Dim _img As Image = sourceBitmap 'Img 'PictureBox1.Image
        Dim _g As Graphics
        Dim bm_dest As New Bitmap(CInt(_img.Width), CInt(_img.Height))
        _g = Graphics.FromImage(bm_dest)

        ' Dim resultBitmap As New Bitmap(sourceBitmap.Width, sourceBitmap.Height)
        _g.DrawImage(_img, New Rectangle(0, 0, bm_dest.Width + 1, bm_dest.Height + 1), 0, 0, bm_dest.Width + 1, bm_dest.Height + 1, GraphicsUnit.Pixel, imageAttributes)
        ' PictureBox1.Image = bm_dest


        Return bm_dest
    End Function

    Public Shared Function Fun_Contrast(ByVal sourceBitmap As Bitmap, ByVal threshold As Integer) As Bitmap
        Dim sourceData As BitmapData = sourceBitmap.LockBits(New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.[ReadOnly], PixelFormat.Format32bppArgb)
        Dim pixelBuffer As Byte() = New Byte(sourceData.Stride * sourceData.Height - 1) {}
        Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length)
        sourceBitmap.UnlockBits(sourceData)
        Dim contrastLevel As Double = Math.Pow((100.0 + threshold) / 100.0, 2)
        Dim blue As Double = 0
        Dim green As Double = 0
        Dim red As Double = 0
        Dim k As Integer = 0
        While k + 4 < pixelBuffer.Length
            blue = ((((pixelBuffer(k) / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0
            green = ((((pixelBuffer(k + 1) / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0
            red = ((((pixelBuffer(k + 2) / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0
            If blue > 255 Then
                blue = 255
            ElseIf blue < 0 Then
                blue = 0
            End If
            If green > 255 Then
                green = 255
            ElseIf green < 0 Then
                green = 0
            End If
            If red > 255 Then
                red = 255
            ElseIf red < 0 Then
                red = 0
            End If
            pixelBuffer(k) = CByte(blue)
            pixelBuffer(k + 1) = CByte(green)
            pixelBuffer(k + 2) = CByte(red)
            k += 4
        End While
        Dim resultBitmap As New Bitmap(sourceBitmap.Width, sourceBitmap.Height)
        Dim resultData As BitmapData = resultBitmap.LockBits(New Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.[WriteOnly], PixelFormat.Format32bppArgb)
        Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length)
        resultBitmap.UnlockBits(resultData)
        Return resultBitmap
    End Function

    Private Sub pic_2_grp2X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_2_grp2X.DoubleClick

        If pic_2_grp2X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub Pic_2_grp2X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_2_grp2X.DragDrop
        If (pic_1_grp2X.ImageLocation = path Or pic_2_grp2X.ImageLocation = path) And Pic = "" Then
            Exit Sub
        End If
        pic_2_grp2X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_2_grp2X.ImageLocation = path
        pic_2_grp2X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "2X1" Then
                pic_1_grp2X.Image = Nothing
                Pic = ""
            ElseIf Pic = "2X2" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
        End If
    End Sub

    Private Sub Pic_2_grp2X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_2_grp2X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_2_grp2X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_2_grp2X.MouseDown
        If Not pic_2_grp2X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "2X2"
            If Pic = "2X2" And Contrast = 1 Then
                pic_2_grp2X.Cursor = Cursors.NoMoveVert
                pic_1_grp2X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "2X2" And Bright = 1 Then
                pic_1_grp2X.Cursor = Cursors.Default
                pic_2_grp2X.Cursor = Cursors.NoMoveHoriz
                mouseY = e.X
            ElseIf measure <> "" Then
                mouseX = e.Y
                mouseY = e.X
                ' measure = False
            End If
            FName = pic_2_grp2X.Tag
            path = pic_2_grp2X.ImageLocation
            ExportOriginalToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_2_grp2X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_2_grp2X.MouseMove
       
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_2_grp2X.Image Is Nothing Then
            pic_2_grp2X.DoDragDrop(pic_2_grp2X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "2X2" Then
                    pic_2_grp2X.Image = Fun_Contrast(pic_2_grp2X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "2X2" Then
                    pic_2_grp2X.Image = Fun_Contrast(pic_2_grp2X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "2X2" Then
                    pic_2_grp2X.Image = Fun_Brightness(pic_2_grp2X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "2X2" Then
                    pic_2_grp2X.Image = Fun_Brightness(pic_2_grp2X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_1_grp2X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_1_grp2X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P2_1"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "2X1"
        End If
    End Sub

    Private Sub Pic_1_grp4X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pic_1_grp4X.DoubleClick
        If Pic_1_grp4X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub Pic_1_grp4X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Pic_1_grp4X.DragDrop
        If Pic = "" And (Pic_1_grp4X.ImageLocation = path Or Pic_2_grp4X.ImageLocation = path Or Pic_3_grp4X.ImageLocation = path Or Pic_4_grp4X.ImageLocation = path) Then
            Exit Sub
        End If
        Pic_1_grp4X.Image = e.Data.GetData(DataFormats.Bitmap)
        Pic_1_grp4X.ImageLocation = path
        Pic_1_grp4X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "4X2" Then
                Pic_2_grp4X.Image = Nothing
            ElseIf Pic = "4X3" Then
                Pic_3_grp4X.Image = Nothing
            ElseIf Pic = "4X4" Then
                Pic_4_grp4X.Image = Nothing
            ElseIf Pic = "4X1" Then
                If path <> "" Then
                    'frm_Image_FullScreen.PictureBox1.ImageLocation = path
                    'frm_Image_FullScreen.Show()
                    m_MouseIsDown = False
                End If
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_1_grp4X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Pic_1_grp4X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move

            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub



    Private Sub Pic_1_grp4X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_1_grp4X.MouseDown
        If Not Pic_1_grp4X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "4X1"
            If Pic = "4X1" And Contrast = 1 Then
                Pic_1_grp4X.Cursor = Cursors.NoMoveVert
                Pic_2_grp4X.Cursor = Cursors.Default
                Pic_3_grp4X.Cursor = Cursors.Default
                Pic_4_grp4X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "4X1" And Bright = 1 Then
                Pic_1_grp4X.Cursor = Cursors.NoMoveHoriz
                Pic_2_grp4X.Cursor = Cursors.Default
                Pic_3_grp4X.Cursor = Cursors.Default
                Pic_4_grp4X.Cursor = Cursors.Default
                mouseY = e.X
            End If
            path = Pic_1_grp4X.ImageLocation
            FName = Pic_1_grp4X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_1_grp4X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_1_grp4X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not Pic_1_grp4X.Image Is Nothing Then
            Pic_1_grp4X.DoDragDrop(Pic_1_grp4X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "4X1" Then
                    Pic_1_grp4X.Image = Fun_Contrast(Pic_1_grp4X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "4X1" Then
                    Pic_1_grp4X.Image = Fun_Contrast(Pic_1_grp4X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "4X1" Then
                    Pic_1_grp4X.Image = Fun_Brightness(Pic_1_grp4X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "4X1" Then
                    Pic_1_grp4X.Image = Fun_Brightness(Pic_1_grp4X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_2_grp4X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pic_2_grp4X.DoubleClick
        If Pic_2_grp4X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    ''
    Private Sub Pic_2_grp4X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Pic_2_grp4X.DragDrop
        If Pic = "" And (Pic_1_grp4X.ImageLocation = path Or Pic_2_grp4X.ImageLocation = path Or Pic_3_grp4X.ImageLocation = path Or Pic_4_grp4X.ImageLocation = path) Then
            Exit Sub
        End If
        Pic_2_grp4X.Image = e.Data.GetData(DataFormats.Bitmap)
        Pic_2_grp4X.ImageLocation = path
        Pic_2_grp4X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "4X1" Then
                Pic_1_grp4X.Image = Nothing
            ElseIf Pic = "4X3" Then
                Pic_3_grp4X.Image = Nothing
            ElseIf Pic = "4X4" Then
                Pic_4_grp4X.Image = Nothing
            ElseIf Pic = "4X2" Then
                If path <> "" Then
                    'frm_Image_FullScreen.PictureBox1.ImageLocation = path
                    'frm_Image_FullScreen.Show()
                    m_MouseIsDown = False
                End If
            End If
        End If

    End Sub

    Private Sub Pic_2_grp4X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Pic_2_grp4X.DragEnter

        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move

            End If
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub


    Private Sub Pic_2_grp4X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_2_grp4X.MouseDown

        If Not Pic_2_grp4X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "4X2"
            If Pic = "4X2" And Contrast = 1 Then
                Pic_2_grp4X.Cursor = Cursors.NoMoveVert
                Pic_1_grp4X.Cursor = Cursors.Default
                Pic_3_grp4X.Cursor = Cursors.Default
                Pic_4_grp4X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "4X2" And Bright = 1 Then
                Pic_1_grp4X.Cursor = Cursors.Default
                Pic_2_grp4X.Cursor = Cursors.NoMoveHoriz
                Pic_3_grp4X.Cursor = Cursors.Default
                Pic_4_grp4X.Cursor = Cursors.Default
                mouseY = e.X
            End If
            path = Pic_2_grp4X.ImageLocation
            FName = Pic_2_grp4X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If

    End Sub

    Private Sub Pic_2_grp4X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_2_grp4X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not Pic_2_grp4X.Image Is Nothing Then
            Pic_2_grp4X.DoDragDrop(Pic_2_grp4X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "4X2" Then
                    Pic_2_grp4X.Image = Fun_Contrast(Pic_2_grp4X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "4X2" Then
                    Pic_2_grp4X.Image = Fun_Contrast(Pic_2_grp4X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "4X2" Then
                    Pic_2_grp4X.Image = Fun_Brightness(Pic_2_grp4X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "4X2" Then
                    Pic_2_grp4X.Image = Fun_Brightness(Pic_2_grp4X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_3_grp4X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pic_3_grp4X.DoubleClick
        If Pic_3_grp4X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    ''
    Private Sub Pic_3_grp4X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Pic_3_grp4X.DragDrop
        If Pic = "" And (Pic_1_grp4X.ImageLocation = path Or Pic_2_grp4X.ImageLocation = path Or Pic_3_grp4X.ImageLocation = path Or Pic_4_grp4X.ImageLocation = path) Then
            Exit Sub
        End If
        Pic_3_grp4X.Image = e.Data.GetData(DataFormats.Bitmap)
        Pic_3_grp4X.ImageLocation = path
        Pic_3_grp4X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "4X1" Then
                Pic_1_grp4X.Image = Nothing
            ElseIf Pic = "4X2" Then
                Pic_2_grp4X.Image = Nothing
            ElseIf Pic = "4X4" Then
                Pic_4_grp4X.Image = Nothing
            ElseIf Pic = "4X3" Then
                If path <> "" Then
                    'frm_Image_FullScreen.PictureBox1.ImageLocation = path
                    'frm_Image_FullScreen.Show()
                    m_MouseIsDown = False
                End If
            End If
        End If

    End Sub

    Private Sub Pic_3_grp4X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Pic_3_grp4X.DragEnter

        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub Pic_3_grp4X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_3_grp4X.MouseDown

        If Not Pic_3_grp4X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "4X3"
            If Pic = "4X3" And Contrast = 1 Then
                Pic_3_grp4X.Cursor = Cursors.NoMoveVert
                Pic_1_grp4X.Cursor = Cursors.Default
                Pic_2_grp4X.Cursor = Cursors.Default
                Pic_4_grp4X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "4X3" And Bright = 1 Then
                Pic_1_grp4X.Cursor = Cursors.Default
                Pic_2_grp4X.Cursor = Cursors.Default
                Pic_3_grp4X.Cursor = Cursors.NoMoveHoriz
                Pic_4_grp4X.Cursor = Cursors.Default
                mouseY = e.X
            End If
            path = Pic_3_grp4X.ImageLocation
            FName = Pic_3_grp4X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_3_grp4X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_3_grp4X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not Pic_3_grp4X.Image Is Nothing Then
            Pic_3_grp4X.DoDragDrop(Pic_3_grp4X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "4X3" Then
                    Pic_3_grp4X.Image = Fun_Contrast(Pic_3_grp4X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "4X3" Then
                    Pic_3_grp4X.Image = Fun_Contrast(Pic_3_grp4X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "4X3" Then
                    Pic_3_grp4X.Image = Fun_Brightness(Pic_3_grp4X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "4X3" Then
                    Pic_3_grp4X.Image = Fun_Brightness(Pic_3_grp4X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_4_grp4X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pic_4_grp4X.DoubleClick
        If Pic_4_grp4X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub
    ''
    Private Sub Pic_4_grp4X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Pic_4_grp4X.DragDrop
        If Pic = "" And (Pic_1_grp4X.ImageLocation = path Or Pic_2_grp4X.ImageLocation = path Or Pic_3_grp4X.ImageLocation = path Or Pic_4_grp4X.ImageLocation = path) Then
            Exit Sub
        End If
        Pic_4_grp4X.Image = e.Data.GetData(DataFormats.Bitmap)
        Pic_4_grp4X.ImageLocation = path
        Pic_4_grp4X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "4X1" Then
                Pic_1_grp4X.Image = Nothing
            ElseIf Pic = "4X2" Then
                Pic_2_grp4X.Image = Nothing
            ElseIf Pic = "4X3" Then
                Pic_3_grp4X.Image = Nothing
            ElseIf Pic = "4X4" Then
                If path <> "" Then
                    'frm_Image_FullScreen.PictureBox1.ImageLocation = path
                    'frm_Image_FullScreen.Show()
                    m_MouseIsDown = False
                End If
            End If
        End If

    End Sub

    Private Sub Pic_4_grp4X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Pic_4_grp4X.DragEnter

        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub Pic_4_grp4X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_4_grp4X.MouseDown
        If Not Pic_4_grp4X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "4X4"
            If Pic = "4X4" And Contrast = 1 Then
                Pic_4_grp4X.Cursor = Cursors.NoMoveVert
                Pic_1_grp4X.Cursor = Cursors.Default
                Pic_3_grp4X.Cursor = Cursors.Default
                Pic_2_grp4X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "4X4" And Bright = 1 Then
                Pic_1_grp4X.Cursor = Cursors.Default
                Pic_2_grp4X.Cursor = Cursors.Default
                Pic_3_grp4X.Cursor = Cursors.Default
                Pic_4_grp4X.Cursor = Cursors.NoMoveHoriz
                mouseY = e.X
            End If
            path = Pic_4_grp4X.ImageLocation
            FName = Pic_4_grp4X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_4_grp4X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_4_grp4X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not Pic_4_grp4X.Image Is Nothing Then
            Pic_4_grp4X.DoDragDrop(Pic_4_grp4X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "4X4" Then
                    Pic_4_grp4X.Image = Fun_Contrast(Pic_4_grp4X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "4X4" Then
                    Pic_4_grp4X.Image = Fun_Contrast(Pic_4_grp4X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "4X4" Then
                    Pic_4_grp4X.Image = Fun_Brightness(Pic_4_grp4X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "4X4" Then
                    Pic_4_grp4X.Image = Fun_Brightness(Pic_4_grp4X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_1_grp9x_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_1_grp9x.DoubleClick
        If pic_1_grp9x.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub
    ''9X
    Private Sub Pic_1_grp9X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_1_grp9x.DragDrop
        If Pic = "" And (pic_1_grp9x.ImageLocation = path Or pic_2_grp9x.ImageLocation = path Or pic_3_grp9x.ImageLocation = path Or pic_4_grp9x.ImageLocation = path Or pic_5_grp9x.ImageLocation = path Or pic_6_grp9x.ImageLocation = path Or pic_7_grp9x.ImageLocation = path Or pic_8_grp9x.ImageLocation = path Or pic_9_grp9x.ImageLocation = path) Then
            Exit Sub
        End If
        pic_1_grp9x.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_1_grp9x.ImageLocation = path
        pic_1_grp9x.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "9X2" Then
                pic_2_grp9x.Image = Nothing
            ElseIf Pic = "9X3" Then
                pic_3_grp9x.Image = Nothing
            ElseIf Pic = "9X4" Then
                pic_4_grp9x.Image = Nothing
            ElseIf Pic = "9X5" Then
                pic_5_grp9x.Image = Nothing
            ElseIf Pic = "9X6" Then
                pic_6_grp9x.Image = Nothing
            ElseIf Pic = "9X7" Then
                pic_7_grp9x.Image = Nothing
            ElseIf Pic = "9X8" Then
                pic_8_grp9x.Image = Nothing
            ElseIf Pic = "9X9" Then
                pic_9_grp9x.Image = Nothing
            ElseIf Pic = "9X1" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
        End If

    End Sub

    Private Sub Pic_1_grp9X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_1_grp9x.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub Pic_1_grp9X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_1_grp9x.MouseDown
        If Not pic_1_grp9x.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "9X1"
            path = pic_1_grp9x.ImageLocation
            FName = pic_1_grp9x.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "9X1" And Contrast = 1 Then
                pic_1_grp9x.Cursor = Cursors.NoMoveVert
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "9X1" And Bright = 1 Then
                pic_1_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub Pic_1_grp9X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_1_grp9x.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_1_grp9x.Image Is Nothing Then
            pic_1_grp9x.DoDragDrop(pic_1_grp9x.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "9X1" Then
                    pic_1_grp9x.Image = Fun_Contrast(pic_1_grp9x.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "9X1" Then
                    pic_1_grp9x.Image = Fun_Contrast(pic_1_grp9x.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "9X1" Then
                    pic_1_grp9x.Image = Fun_Brightness(pic_1_grp9x.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "9X1" Then
                    pic_1_grp9x.Image = Fun_Brightness(pic_1_grp9x.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_2_grp9x_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_2_grp9x.DoubleClick
        If pic_2_grp9x.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub
    ''
    Private Sub Pic_2_grp9X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_2_grp9x.DragDrop
        If Pic = "" And (pic_1_grp9x.ImageLocation = path Or pic_2_grp9x.ImageLocation = path Or pic_3_grp9x.ImageLocation = path Or pic_4_grp9x.ImageLocation = path Or pic_5_grp9x.ImageLocation = path Or pic_6_grp9x.ImageLocation = path Or pic_7_grp9x.ImageLocation = path Or pic_8_grp9x.ImageLocation = path Or pic_9_grp9x.ImageLocation = path) Then
            Exit Sub
        End If
        pic_2_grp9x.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_2_grp9x.ImageLocation = path
        pic_2_grp9x.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "9X1" Then
                pic_1_grp9x.Image = Nothing
            ElseIf Pic = "9X3" Then
                pic_3_grp9x.Image = Nothing
            ElseIf Pic = "9X4" Then
                pic_4_grp9x.Image = Nothing
            ElseIf Pic = "9X5" Then
                pic_5_grp9x.Image = Nothing
            ElseIf Pic = "9X6" Then
                pic_6_grp9x.Image = Nothing
            ElseIf Pic = "9X7" Then
                pic_7_grp9x.Image = Nothing
            ElseIf Pic = "9X8" Then
                pic_8_grp9x.Image = Nothing
            ElseIf Pic = "9X9" Then
                pic_9_grp9x.Image = Nothing
            ElseIf Pic = "9X2" Then
                If path <> "" Then
                    'frm_Image_FullScreen.PictureBox1.ImageLocation = path
                    'frm_Image_FullScreen.Show()
                    m_MouseIsDown = False
                End If
            End If
        End If

    End Sub

    Private Sub Pic_2_grp9X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_2_grp9x.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub Pic_2_grp9X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_2_grp9x.MouseDown
        If Not pic_2_grp9x.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "9X2"
            If Pic = "9X2" And Contrast = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.NoMoveVert
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "9X2" And Bright = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
                mouseY = e.X
            End If
            path = pic_2_grp9x.ImageLocation
            FName = pic_2_grp9x.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_2_grp9X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_2_grp9x.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_2_grp9x.Image Is Nothing Then
            pic_2_grp9x.DoDragDrop(pic_2_grp9x.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "9X2" Then
                    pic_2_grp9x.Image = Fun_Contrast(pic_2_grp9x.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "9X2" Then
                    pic_2_grp9x.Image = Fun_Contrast(pic_2_grp9x.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "9X2" Then
                    pic_2_grp9x.Image = Fun_Brightness(pic_2_grp9x.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "9X2" Then
                    pic_2_grp9x.Image = Fun_Brightness(pic_2_grp9x.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_3_grp9x_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_3_grp9x.DoubleClick
        If pic_3_grp9x.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub
    ''
    Private Sub Pic_3_grp9X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_3_grp9x.DragDrop
        If Pic = "" And (pic_1_grp9x.ImageLocation = path Or pic_2_grp9x.ImageLocation = path Or pic_3_grp9x.ImageLocation = path Or pic_4_grp9x.ImageLocation = path Or pic_5_grp9x.ImageLocation = path Or pic_6_grp9x.ImageLocation = path Or pic_7_grp9x.ImageLocation = path Or pic_8_grp9x.ImageLocation = path Or pic_9_grp9x.ImageLocation = path) Then
            Exit Sub
        End If
        pic_3_grp9x.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_3_grp9x.ImageLocation = path
        pic_3_grp9x.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "9X1" Then
                pic_1_grp9x.Image = Nothing
            ElseIf Pic = "9X2" Then
                pic_2_grp9x.Image = Nothing
            ElseIf Pic = "9X4" Then
                pic_4_grp9x.Image = Nothing
            ElseIf Pic = "9X5" Then
                pic_5_grp9x.Image = Nothing
            ElseIf Pic = "9X6" Then
                pic_6_grp9x.Image = Nothing
            ElseIf Pic = "9X7" Then
                pic_7_grp9x.Image = Nothing
            ElseIf Pic = "9X8" Then
                pic_8_grp9x.Image = Nothing
            ElseIf Pic = "9X9" Then
                pic_9_grp9x.Image = Nothing
            ElseIf Pic = "9X3" Then
                If path <> "" Then
                    
                    m_MouseIsDown = False
                End If
            End If
        End If

    End Sub

    Private Sub Pic_3_grp9X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_3_grp9x.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub Pic_3_grp9X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_3_grp9x.MouseDown
        If Not pic_3_grp9x.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "9X3"
            If Pic = "9X3" And Contrast = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.NoMoveVert
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "9X3" And Bright = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
                mouseY = e.X
            End If
            path = pic_3_grp9x.ImageLocation
            FName = pic_3_grp9x.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_3_grp9X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_3_grp9x.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_3_grp9x.Image Is Nothing Then
            pic_3_grp9x.DoDragDrop(pic_3_grp9x.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "9X3" Then
                    pic_3_grp9x.Image = Fun_Contrast(pic_3_grp9x.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "9X3" Then
                    pic_3_grp9x.Image = Fun_Contrast(pic_3_grp9x.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "9X3" Then
                    pic_3_grp9x.Image = Fun_Brightness(pic_3_grp9x.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "9X3" Then
                    pic_3_grp9x.Image = Fun_Brightness(pic_3_grp9x.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_4_grp9x_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_4_grp9x.DoubleClick
        If pic_4_grp9x.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub
    ''
    Private Sub Pic_4_grp9X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_4_grp9x.DragDrop
        If Pic = "" And (pic_1_grp9x.ImageLocation = path Or pic_2_grp9x.ImageLocation = path Or pic_3_grp9x.ImageLocation = path Or pic_4_grp9x.ImageLocation = path Or pic_5_grp9x.ImageLocation = path Or pic_6_grp9x.ImageLocation = path Or pic_7_grp9x.ImageLocation = path Or pic_8_grp9x.ImageLocation = path Or pic_9_grp9x.ImageLocation = path) Then
            Exit Sub
        End If
        pic_4_grp9x.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_4_grp9x.ImageLocation = path
        pic_4_grp9x.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "9X1" Then
                pic_1_grp9x.Image = Nothing
            ElseIf Pic = "9X2" Then
                pic_2_grp9x.Image = Nothing
            ElseIf Pic = "9X3" Then
                pic_3_grp9x.Image = Nothing
            ElseIf Pic = "9X5" Then
                pic_5_grp9x.Image = Nothing
            ElseIf Pic = "9X6" Then
                pic_6_grp9x.Image = Nothing
            ElseIf Pic = "9X7" Then
                pic_7_grp9x.Image = Nothing
            ElseIf Pic = "9X8" Then
                pic_8_grp9x.Image = Nothing
            ElseIf Pic = "9X9" Then
                pic_9_grp9x.Image = Nothing
            ElseIf Pic = "9X4" Then
                If path <> "" Then
                    'frm_Image_FullScreen.PictureBox1.ImageLocation = path
                    'frm_Image_FullScreen.Show()
                    m_MouseIsDown = False
                End If
            End If
        End If

    End Sub

    Private Sub Pic_4_grp9X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_4_grp9x.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

  

    Private Sub Pic_4_grp9X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_4_grp9x.MouseDown
        If Not pic_4_grp9x.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "9X4"
            If Pic = "9X4" And Contrast = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.NoMoveVert
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "9X4" And Bright = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
                mouseY = e.X
            End If
            path = pic_4_grp9x.ImageLocation
            FName = pic_4_grp9x.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_4_grp9X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_4_grp9x.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_4_grp9x.Image Is Nothing Then
            pic_4_grp9x.DoDragDrop(pic_4_grp9x.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "9X4" Then
                    pic_4_grp9x.Image = Fun_Contrast(pic_4_grp9x.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "9X4" Then
                    pic_4_grp9x.Image = Fun_Contrast(pic_4_grp9x.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "9X4" Then
                    pic_4_grp9x.Image = Fun_Brightness(pic_4_grp9x.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "9X4" Then
                    pic_4_grp9x.Image = Fun_Brightness(pic_4_grp9x.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_5_grp9x_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_5_grp9x.DoubleClick
        If pic_5_grp9x.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub Pic_5_grp9X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_5_grp9x.DragDrop
        If Pic = "" And (pic_1_grp9x.ImageLocation = path Or pic_2_grp9x.ImageLocation = path Or pic_3_grp9x.ImageLocation = path Or pic_4_grp9x.ImageLocation = path Or pic_5_grp9x.ImageLocation = path Or pic_6_grp9x.ImageLocation = path Or pic_7_grp9x.ImageLocation = path Or pic_8_grp9x.ImageLocation = path Or pic_9_grp9x.ImageLocation = path) Then
            Exit Sub
        End If
        pic_5_grp9x.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_5_grp9x.ImageLocation = path
        pic_5_grp9x.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "9X1" Then
                pic_1_grp9x.Image = Nothing
            ElseIf Pic = "9X2" Then
                pic_2_grp9x.Image = Nothing
            ElseIf Pic = "9X3" Then
                pic_3_grp9x.Image = Nothing
            ElseIf Pic = "9X4" Then
                pic_4_grp9x.Image = Nothing
            ElseIf Pic = "9X6" Then
                pic_6_grp9x.Image = Nothing
            ElseIf Pic = "9X7" Then
                pic_7_grp9x.Image = Nothing
            ElseIf Pic = "9X8" Then
                pic_8_grp9x.Image = Nothing
            ElseIf Pic = "9X9" Then
                pic_9_grp9x.Image = Nothing
            ElseIf Pic = "9X5" Then
                If path <> "" Then
                    'frm_Image_FullScreen.PictureBox1.ImageLocation = path
                    'frm_Image_FullScreen.Show()
                    m_MouseIsDown = False
                End If
            End If
        End If

    End Sub

    Private Sub Pic_5_grp9X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_5_grp9x.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_5_grp9X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_5_grp9x.MouseDown
        If Not pic_5_grp9x.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "9X5"
            If Pic = "9X5" And Contrast = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.NoMoveVert
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "9X5" And Bright = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
                mouseY = e.X
            End If
            path = pic_5_grp9x.ImageLocation
            FName = pic_5_grp9x.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_5_grp9X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_5_grp9x.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_5_grp9x.Image Is Nothing Then
            pic_5_grp9x.DoDragDrop(pic_5_grp9x.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "9X5" Then
                    pic_5_grp9x.Image = Fun_Contrast(pic_5_grp9x.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "9X5" Then
                    pic_5_grp9x.Image = Fun_Contrast(pic_5_grp9x.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "9X5" Then
                    pic_5_grp9x.Image = Fun_Brightness(pic_5_grp9x.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "9X5" Then
                    pic_5_grp9x.Image = Fun_Brightness(pic_5_grp9x.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_6_grp9x_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_6_grp9x.DoubleClick
        If pic_6_grp9x.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub
    ''
    Private Sub Pic_6_grp9X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_6_grp9x.DragDrop
        If Pic = "" And (pic_1_grp9x.ImageLocation = path Or pic_2_grp9x.ImageLocation = path Or pic_3_grp9x.ImageLocation = path Or pic_4_grp9x.ImageLocation = path Or pic_5_grp9x.ImageLocation = path Or pic_6_grp9x.ImageLocation = path Or pic_7_grp9x.ImageLocation = path Or pic_8_grp9x.ImageLocation = path Or pic_9_grp9x.ImageLocation = path) Then
            Exit Sub
        End If
        pic_6_grp9x.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_6_grp9x.ImageLocation = path
        pic_6_grp9x.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "9X1" Then
                pic_1_grp9x.Image = Nothing
            ElseIf Pic = "9X2" Then
                pic_2_grp9x.Image = Nothing
            ElseIf Pic = "9X3" Then
                pic_3_grp9x.Image = Nothing
            ElseIf Pic = "9X4" Then
                pic_4_grp9x.Image = Nothing
            ElseIf Pic = "9X5" Then
                pic_5_grp9x.Image = Nothing
            ElseIf Pic = "9X7" Then
                pic_7_grp9x.Image = Nothing
            ElseIf Pic = "9X8" Then
                pic_8_grp9x.Image = Nothing
            ElseIf Pic = "9X9" Then
                pic_9_grp9x.Image = Nothing
            ElseIf Pic = "9X6" Then
                If path <> "" Then
                    'frm_Image_FullScreen.PictureBox1.ImageLocation = path
                    'frm_Image_FullScreen.Show()
                    m_MouseIsDown = False
                End If
            End If
        End If

    End Sub

    Private Sub Pic_6_grp9X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_6_grp9x.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub Pic_6_grp9X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_6_grp9x.MouseDown
        If Not pic_6_grp9x.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "9X6"
            If Pic = "9X6" And Contrast = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.NoMoveVert
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "9X6" And Bright = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
                mouseY = e.X
            End If
            path = pic_6_grp9x.ImageLocation
            FName = pic_6_grp9x.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_6_grp9X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_6_grp9x.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_6_grp9x.Image Is Nothing Then
            pic_6_grp9x.DoDragDrop(pic_6_grp9x.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "9X6" Then
                    pic_6_grp9x.Image = Fun_Contrast(pic_6_grp9x.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "9X6" Then
                    pic_6_grp9x.Image = Fun_Contrast(pic_6_grp9x.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "9X6" Then
                    pic_6_grp9x.Image = Fun_Brightness(pic_6_grp9x.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "9X6" Then
                    pic_6_grp9x.Image = Fun_Brightness(pic_6_grp9x.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_7_grp9x_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_7_grp9x.DoubleClick
        If pic_7_grp9x.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub
    ''
    Private Sub Pic_7_grp9X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_7_grp9x.DragDrop
        If Pic = "" And (pic_1_grp9x.ImageLocation = path Or pic_2_grp9x.ImageLocation = path Or pic_3_grp9x.ImageLocation = path Or pic_4_grp9x.ImageLocation = path Or pic_5_grp9x.ImageLocation = path Or pic_6_grp9x.ImageLocation = path Or pic_7_grp9x.ImageLocation = path Or pic_8_grp9x.ImageLocation = path Or pic_9_grp9x.ImageLocation = path) Then
            Exit Sub
        End If
        pic_7_grp9x.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_7_grp9x.ImageLocation = path
        pic_7_grp9x.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "9X1" Then
                pic_1_grp9x.Image = Nothing
            ElseIf Pic = "9X2" Then
                pic_2_grp9x.Image = Nothing
            ElseIf Pic = "9X3" Then
                pic_3_grp9x.Image = Nothing
            ElseIf Pic = "9X4" Then
                pic_4_grp9x.Image = Nothing
            ElseIf Pic = "9X5" Then
                pic_5_grp9x.Image = Nothing
            ElseIf Pic = "9X6" Then
                pic_6_grp9x.Image = Nothing
            ElseIf Pic = "9X8" Then
                pic_8_grp9x.Image = Nothing
            ElseIf Pic = "9X9" Then
                pic_9_grp9x.Image = Nothing
            ElseIf Pic = "9X7" Then
                If path <> "" Then
                    'frm_Image_FullScreen.PictureBox1.ImageLocation = path
                    'frm_Image_FullScreen.Show()
                    m_MouseIsDown = False
                End If
            End If
        End If

    End Sub

    Private Sub Pic_7_grp9X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_7_grp9x.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

  

    Private Sub Pic_7_grp9X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_7_grp9x.MouseDown
        If Not pic_7_grp9x.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "9X7"
            If Pic = "9X7" And Contrast = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.NoMoveVert
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "9X7" And Bright = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
                mouseY = e.X
            End If
            path = pic_7_grp9x.ImageLocation
            FName = pic_7_grp9x.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_7_grp9X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_7_grp9x.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_7_grp9x.Image Is Nothing Then
            pic_7_grp9x.DoDragDrop(pic_7_grp9x.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "9X7" Then
                    pic_7_grp9x.Image = Fun_Contrast(pic_7_grp9x.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "9X7" Then
                    pic_7_grp9x.Image = Fun_Contrast(pic_7_grp9x.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "9X7" Then
                    pic_7_grp9x.Image = Fun_Brightness(pic_7_grp9x.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "9X7" Then
                    pic_7_grp9x.Image = Fun_Brightness(pic_7_grp9x.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_8_grp9x_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_8_grp9x.DoubleClick
        If pic_8_grp9x.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub
    ''
    Private Sub Pic_8_grp9X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_8_grp9x.DragDrop
        If Pic = "" And (pic_1_grp9x.ImageLocation = path Or pic_2_grp9x.ImageLocation = path Or pic_3_grp9x.ImageLocation = path Or pic_4_grp9x.ImageLocation = path Or pic_5_grp9x.ImageLocation = path Or pic_6_grp9x.ImageLocation = path Or pic_7_grp9x.ImageLocation = path Or pic_8_grp9x.ImageLocation = path Or pic_9_grp9x.ImageLocation = path) Then
            Exit Sub
        End If
        pic_8_grp9x.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_8_grp9x.ImageLocation = path
        pic_8_grp9x.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "9X1" Then
                pic_1_grp9x.Image = Nothing
            ElseIf Pic = "9X2" Then
                pic_2_grp9x.Image = Nothing
            ElseIf Pic = "9X3" Then
                pic_3_grp9x.Image = Nothing
            ElseIf Pic = "9X4" Then
                pic_4_grp9x.Image = Nothing
            ElseIf Pic = "9X5" Then
                pic_5_grp9x.Image = Nothing
            ElseIf Pic = "9X6" Then
                pic_6_grp9x.Image = Nothing
            ElseIf Pic = "9X7" Then
                pic_7_grp9x.Image = Nothing
            ElseIf Pic = "9X9" Then
                pic_9_grp9x.Image = Nothing
            ElseIf Pic = "9X8" Then
                If path <> "" Then
                    'frm_Image_FullScreen.PictureBox1.ImageLocation = path
                    'frm_Image_FullScreen.Show()
                    m_MouseIsDown = False
                End If
            End If
        End If

    End Sub

    Private Sub Pic_8_grp9X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_8_grp9x.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub Pic_8_grp9X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_8_grp9x.MouseDown
        If Not pic_8_grp9x.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "9X8"
            If Pic = "9X8" And Contrast = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.NoMoveVert
                pic_9_grp9x.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "9X8" And Bright = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_9_grp9x.Cursor = Cursors.Default
                mouseY = e.X
            End If
            path = pic_8_grp9x.ImageLocation
            FName = pic_8_grp9x.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_8_grp9X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_8_grp9x.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_8_grp9x.Image Is Nothing Then
            pic_8_grp9x.DoDragDrop(pic_8_grp9x.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "9X8" Then
                    pic_8_grp9x.Image = Fun_Contrast(pic_8_grp9x.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "9X8" Then
                    pic_8_grp9x.Image = Fun_Contrast(pic_8_grp9x.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "9X8" Then
                    pic_8_grp9x.Image = Fun_Brightness(pic_8_grp9x.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "9X8" Then
                    pic_8_grp9x.Image = Fun_Brightness(pic_8_grp9x.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_9_grp9x_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_9_grp9x.DoubleClick
        If pic_9_grp9x.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub
    ''
    Private Sub Pic_9_grp9X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_9_grp9x.DragDrop
        If Pic = "" And (pic_1_grp9x.ImageLocation = path Or pic_2_grp9x.ImageLocation = path Or pic_3_grp9x.ImageLocation = path Or pic_4_grp9x.ImageLocation = path Or pic_5_grp9x.ImageLocation = path Or pic_6_grp9x.ImageLocation = path Or pic_7_grp9x.ImageLocation = path Or pic_8_grp9x.ImageLocation = path Or pic_9_grp9x.ImageLocation = path) Then
            Exit Sub
        End If
        pic_9_grp9x.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_9_grp9x.ImageLocation = path
        pic_9_grp9x.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "9X1" Then
                pic_1_grp9x.Image = Nothing
            ElseIf Pic = "9X2" Then
                pic_2_grp9x.Image = Nothing
            ElseIf Pic = "9X3" Then
                pic_3_grp9x.Image = Nothing
            ElseIf Pic = "9X4" Then
                pic_4_grp9x.Image = Nothing
            ElseIf Pic = "9X5" Then
                pic_5_grp9x.Image = Nothing
            ElseIf Pic = "9X6" Then
                pic_6_grp9x.Image = Nothing
            ElseIf Pic = "9X7" Then
                pic_7_grp9x.Image = Nothing
            ElseIf Pic = "9X8" Then
                pic_8_grp9x.Image = Nothing
            ElseIf Pic = "9X9" Then
                If path <> "" Then
                    'frm_Image_FullScreen.PictureBox1.ImageLocation = path
                    'frm_Image_FullScreen.Show()
                    m_MouseIsDown = False
                End If
            End If
        End If

    End Sub

    Private Sub Pic_9_grp9X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_9_grp9x.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_9_grp9X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_9_grp9x.MouseDown
        If Not pic_9_grp9x.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "9X9"
            If Pic = "9X9" And Contrast = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.NoMoveVert
                mouseX = e.Y
            ElseIf Pic = "9X9" And Bright = 1 Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.NoMoveHoriz
                mouseY = e.X
            End If
            path = pic_9_grp9x.ImageLocation
            FName = pic_9_grp9x.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_9_grp9X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_9_grp9x.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_9_grp9x.Image Is Nothing Then
            pic_9_grp9x.DoDragDrop(pic_9_grp9x.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "9X9" Then
                    pic_9_grp9x.Image = Fun_Contrast(pic_9_grp9x.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "9X9" Then
                    pic_9_grp9x.Image = Fun_Contrast(pic_9_grp9x.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "9X9" Then
                    pic_9_grp9x.Image = Fun_Brightness(pic_9_grp9x.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "9X9" Then
                    pic_9_grp9x.Image = Fun_Brightness(pic_9_grp9x.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_1_grp4X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_1_grp4X.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P4_1"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "4X1"
        End If
    End Sub

    Private Sub pic_1_grp9x_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_1_grp9x.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P9_1"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "9X1"
        End If
    End Sub

    Private Sub pic_2_grp2X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_2_grp2X.MouseUp

        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P2_2"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "2X2"
        End If
    End Sub

    Private Sub Rotate90ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rotate90ToolStripMenuItem1.Click
        m_MouseIsDown = False
        If picture = "P1_1" Then
            If Pic_1_grp1X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp1X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Pic_1_grp1X.Width = Pic_1_grp1X.Width
            Pic_1_grp1X.Height = Pic_1_grp1X.Height
        ElseIf picture = "P2_1" Then
            If pic_1_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp2X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_1_grp2X.Width = pic_1_grp2X.Width
            pic_1_grp2X.Height = pic_1_grp2X.Height
        ElseIf picture = "P2_2" Then
            If pic_2_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp2X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_2_grp2X.Width = pic_2_grp2X.Width
            pic_2_grp2X.Height = pic_2_grp2X.Height
        ElseIf picture = "P4_1" Then
            If Pic_1_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp4X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Pic_1_grp4X.Width = Pic_1_grp4X.Width
            Pic_1_grp4X.Height = Pic_1_grp4X.Height
        ElseIf picture = "P4_2" Then
            If Pic_2_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_2_grp4X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Pic_2_grp4X.Width = Pic_2_grp4X.Width
            Pic_2_grp4X.Height = Pic_2_grp4X.Height
        ElseIf picture = "P4_3" Then
            If Pic_3_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_3_grp4X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Pic_3_grp4X.Width = Pic_3_grp4X.Width
            Pic_3_grp4X.Height = Pic_3_grp4X.Height
        ElseIf picture = "P4_4" Then
            If Pic_4_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_4_grp4X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Pic_4_grp4X.Width = Pic_4_grp4X.Width
            Pic_4_grp4X.Height = Pic_4_grp4X.Height
        ElseIf picture = "P9_1" Then
            If pic_1_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_1_grp9x.Width = pic_1_grp9x.Width
            pic_1_grp9x.Height = pic_1_grp9x.Height
        ElseIf picture = "P9_2" Then
            If pic_2_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_2_grp9x.Width = pic_2_grp9x.Width
            pic_2_grp9x.Height = pic_2_grp9x.Height
        ElseIf picture = "P9_3" Then
            If pic_3_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_3_grp9x.Width = pic_3_grp9x.Width
            pic_3_grp9x.Height = pic_3_grp9x.Height
        ElseIf picture = "P9_4" Then
            If pic_4_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_4_grp9x.Width = pic_4_grp9x.Width
            pic_4_grp9x.Height = pic_4_grp9x.Height
        ElseIf picture = "P9_5" Then
            If pic_5_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_5_grp9x.Width = pic_5_grp9x.Width
            pic_5_grp9x.Height = pic_5_grp9x.Height
        ElseIf picture = "P9_6" Then
            If pic_6_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_6_grp9x.Width = pic_6_grp9x.Width
            pic_6_grp9x.Height = pic_6_grp9x.Height
        ElseIf picture = "P9_7" Then
            If pic_7_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_7_grp9x.Width = pic_7_grp9x.Width
            pic_7_grp9x.Height = pic_7_grp9x.Height
        ElseIf picture = "P9_8" Then
            If pic_8_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_8_grp9x.Width = pic_8_grp9x.Width
            pic_8_grp9x.Height = pic_8_grp9x.Height
        ElseIf picture = "P9_9" Then
            If pic_9_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_9_grp9x.Width = pic_9_grp9x.Width
            pic_9_grp9x.Height = pic_9_grp9x.Height
        ElseIf picture = "P16_1" Then
            If pic_1_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_1_grp16X.Width = pic_1_grp16X.Width
            pic_1_grp16X.Height = pic_1_grp16X.Height
        ElseIf picture = "P16_2" Then
            If pic_2_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_2_grp16X.Width = pic_2_grp16X.Width
            pic_2_grp16X.Height = pic_2_grp16X.Height
        ElseIf picture = "P16_3" Then
            If pic_3_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_3_grp16X.Width = pic_3_grp16X.Width
            pic_3_grp16X.Height = pic_3_grp16X.Height
        ElseIf picture = "P16_4" Then
            If pic_4_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_4_grp16X.Width = pic_4_grp16X.Width
            pic_4_grp16X.Height = pic_4_grp16X.Height
        ElseIf picture = "P16_5" Then
            If pic_5_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_5_grp16X.Width = pic_5_grp16X.Width
            pic_5_grp16X.Height = pic_5_grp16X.Height
        ElseIf picture = "P16_6" Then
            If pic_6_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_6_grp16X.Width = pic_6_grp16X.Width
            pic_6_grp16X.Height = pic_6_grp16X.Height
        ElseIf picture = "P16_7" Then
            If pic_7_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_7_grp16X.Width = pic_7_grp16X.Width
            pic_7_grp16X.Height = pic_7_grp16X.Height
        ElseIf picture = "P16_8" Then
            If pic_8_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_8_grp16X.Width = pic_8_grp16X.Width
            pic_8_grp16X.Height = pic_8_grp16X.Height
        ElseIf picture = "P16_9" Then
            If pic_9_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_9_grp16X.Width = pic_9_grp16X.Width
            pic_9_grp16X.Height = pic_9_grp16X.Height
        ElseIf picture = "P16_10" Then
            If pic_10_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_10_grp16X.Width = pic_10_grp16X.Width
            pic_10_grp16X.Height = pic_10_grp16X.Height
        ElseIf picture = "P16_11" Then
            If pic_11_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_11_grp16X.Width = pic_11_grp16X.Width
            pic_11_grp16X.Height = pic_11_grp16X.Height
        ElseIf picture = "P16_12" Then
            If pic_12_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_12_grp16X.Width = pic_12_grp16X.Width
            pic_12_grp16X.Height = pic_12_grp16X.Height
        ElseIf picture = "P16_13" Then
            If pic_13_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_13_grp16X.Width = pic_13_grp16X.Width
            pic_13_grp16X.Height = pic_13_grp16X.Height
        ElseIf picture = "P16_14" Then
            If pic_14_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_14_grp16X.Width = pic_14_grp16X.Width
            pic_14_grp16X.Height = pic_14_grp16X.Height
        ElseIf picture = "P16_15" Then
            If pic_15_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_15_grp16X.Width = pic_15_grp16X.Width
            pic_15_grp16X.Height = pic_15_grp16X.Height
        ElseIf picture = "P16_16" Then
            If pic_16_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_16_grp16X.Width = pic_16_grp16X.Width
            pic_16_grp16X.Height = pic_16_grp16X.Height
        ElseIf picture = "P18_1" Then
            If pic_1_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_1_grpFullMouth.Width = pic_1_grpFullMouth.Width
            pic_1_grpFullMouth.Height = pic_1_grpFullMouth.Height
        ElseIf picture = "P18_2" Then
            If pic_2_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_2_grpFullMouth.Width = pic_2_grpFullMouth.Width
            pic_2_grpFullMouth.Height = pic_2_grpFullMouth.Height
        ElseIf picture = "P18_3" Then
            If pic_3_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_3_grpFullMouth.Width = pic_3_grpFullMouth.Width
            pic_3_grpFullMouth.Height = pic_3_grpFullMouth.Height
        ElseIf picture = "P18_4" Then
            If pic_4_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_4_grpFullMouth.Width = pic_4_grpFullMouth.Width
            pic_4_grpFullMouth.Height = pic_4_grpFullMouth.Height
        ElseIf picture = "P18_5" Then
            If pic_5_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_5_grpFullMouth.Width = pic_5_grpFullMouth.Width
            pic_5_grpFullMouth.Height = pic_5_grpFullMouth.Height
        ElseIf picture = "P18_6" Then
            If pic_6_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_6_grpFullMouth.Width = pic_6_grpFullMouth.Width
            pic_6_grpFullMouth.Height = pic_6_grpFullMouth.Height
        ElseIf picture = "P18_7" Then
            If pic_7_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_7_grpFullMouth.Width = pic_7_grpFullMouth.Width
            pic_7_grpFullMouth.Height = pic_7_grpFullMouth.Height
        ElseIf picture = "P18_8" Then
            If pic_8_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_8_grpFullMouth.Width = pic_8_grpFullMouth.Width
            pic_8_grpFullMouth.Height = pic_8_grpFullMouth.Height
        ElseIf picture = "P18_9" Then
            If pic_9_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_9_grpFullMouth.Width = pic_9_grpFullMouth.Width
            pic_9_grpFullMouth.Height = pic_9_grpFullMouth.Height
        ElseIf picture = "P18_10" Then
            If pic_10_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_10_grpFullMouth.Width = pic_10_grpFullMouth.Width
            pic_10_grpFullMouth.Height = pic_10_grpFullMouth.Height
        ElseIf picture = "P18_11" Then
            If pic_11_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_11_grpFullMouth.Width = pic_11_grpFullMouth.Width
            pic_11_grpFullMouth.Height = pic_11_grpFullMouth.Height
        ElseIf picture = "P18_12" Then
            If pic_12_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_12_grpFullMouth.Width = pic_12_grpFullMouth.Width
            pic_12_grpFullMouth.Height = pic_12_grpFullMouth.Height
        ElseIf picture = "P18_13" Then
            If pic_13_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_13_grpFullMouth.Width = pic_13_grpFullMouth.Width
            pic_13_grpFullMouth.Height = pic_13_grpFullMouth.Height
        ElseIf picture = "P18_14" Then
            If pic_14_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_14_grpFullMouth.Width = pic_14_grpFullMouth.Width
            pic_14_grpFullMouth.Height = pic_14_grpFullMouth.Height
        ElseIf picture = "P18_15" Then
            If pic_15_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_15_grpFullMouth.Width = pic_15_grpFullMouth.Width
            pic_15_grpFullMouth.Height = pic_15_grpFullMouth.Height
        ElseIf picture = "P18_16" Then
            If pic_16_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_16_grpFullMouth.Width = pic_16_grpFullMouth.Width
            pic_16_grpFullMouth.Height = pic_16_grpFullMouth.Height
        ElseIf picture = "P18_17" Then
            If pic_17_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_17_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_17_grpFullMouth.Width = pic_17_grpFullMouth.Width
            pic_17_grpFullMouth.Height = pic_17_grpFullMouth.Height
        ElseIf picture = "P18_18" Then
            If pic_18_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_18_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_18_grpFullMouth.Width = pic_18_grpFullMouth.Width
            pic_18_grpFullMouth.Height = pic_18_grpFullMouth.Height
        End If

        Call RefreshImages()
        Call FillDetails()
    End Sub

    Private Sub Pic_2_grp4X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_2_grp4X.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P4_2"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "4X2"
        End If
    End Sub

    Private Sub pic_2_grp9x_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_2_grp9x.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P9_2"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "9X2"
        End If
    End Sub

    Private Sub Pic_3_grp4X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_3_grp4X.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P4_3"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "4X3"
        End If
    End Sub

    Private Sub pic_3_grp9x_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_3_grp9x.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P9_3"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "9X3"
        End If
    End Sub

    Private Sub Pic_4_grp4X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_4_grp4X.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P4_4"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "4X4"
        End If
    End Sub

    Private Sub pic_4_grp9x_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_4_grp9x.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P9_4"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "9X4"
        End If
    End Sub

    Private Sub pic_5_grp9x_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_5_grp9x.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P9_5"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "9X5"
        End If
    End Sub

    Private Sub pic_6_grp9x_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_6_grp9x.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P9_6"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "9X6"
        End If
    End Sub

    Private Sub pic_7_grp9x_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_7_grp9x.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P9_7"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "9X7"
        End If
    End Sub

    Private Sub pic_8_grp9x_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_8_grp9x.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P9_8"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "9X8"
        End If
    End Sub

    Private Sub pic_9_grp9x_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_9_grp9x.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P9_9"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "9X9"
        End If
    End Sub

    Private Sub Rotate180ºToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rotate180ºToolStripMenuItem.Click
        m_MouseIsDown = False
        If picture = "P1_1" Then
            If Pic_1_grp1X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp1X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Pic_1_grp1X.Width = Pic_1_grp1X.Width
            Pic_1_grp1X.Height = Pic_1_grp1X.Height
        ElseIf picture = "P2_1" Then
            If pic_1_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp2X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_1_grp2X.Width = pic_1_grp2X.Width
            pic_1_grp2X.Height = pic_1_grp2X.Height
        ElseIf picture = "P2_2" Then
            If pic_2_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp2X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_2_grp2X.Width = pic_2_grp2X.Width
            pic_2_grp2X.Height = pic_2_grp2X.Height
        ElseIf picture = "P4_1" Then
            If Pic_1_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp4X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Pic_1_grp4X.Width = Pic_1_grp4X.Width
            Pic_1_grp4X.Height = Pic_1_grp4X.Height
        ElseIf picture = "P4_2" Then
            If Pic_2_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_2_grp4X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Pic_2_grp4X.Width = Pic_2_grp4X.Width
            Pic_2_grp4X.Height = Pic_2_grp4X.Height
        ElseIf picture = "P4_3" Then
            If Pic_3_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_3_grp4X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Pic_3_grp4X.Width = Pic_3_grp4X.Width
            Pic_3_grp4X.Height = Pic_3_grp4X.Height
        ElseIf picture = "P4_4" Then
            If Pic_4_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_4_grp4X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Pic_4_grp4X.Width = Pic_4_grp4X.Width
            Pic_4_grp4X.Height = Pic_4_grp4X.Height
        ElseIf picture = "P9_1" Then
            If pic_1_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_1_grp9x.Width = pic_1_grp9x.Width
            pic_1_grp9x.Height = pic_1_grp9x.Height
        ElseIf picture = "P9_2" Then
            If pic_2_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_2_grp9x.Width = pic_2_grp9x.Width
            pic_2_grp9x.Height = pic_2_grp9x.Height
        ElseIf picture = "P9_3" Then
            If pic_3_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_3_grp9x.Width = pic_3_grp9x.Width
            pic_3_grp9x.Height = pic_3_grp9x.Height
        ElseIf picture = "P9_4" Then
            If pic_4_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_4_grp9x.Width = pic_4_grp9x.Width
            pic_4_grp9x.Height = pic_4_grp9x.Height
        ElseIf picture = "P9_5" Then
            If pic_5_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_5_grp9x.Width = pic_5_grp9x.Width
            pic_5_grp9x.Height = pic_5_grp9x.Height
        ElseIf picture = "P9_6" Then
            If pic_6_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_6_grp9x.Width = pic_6_grp9x.Width
            pic_6_grp9x.Height = pic_6_grp9x.Height
        ElseIf picture = "P9_7" Then
            If pic_7_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_7_grp9x.Width = pic_7_grp9x.Width
            pic_7_grp9x.Height = pic_7_grp9x.Height
        ElseIf picture = "P9_8" Then
            If pic_8_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_8_grp9x.Width = pic_8_grp9x.Width
            pic_8_grp9x.Height = pic_8_grp9x.Height
        ElseIf picture = "P9_9" Then
            If pic_9_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_9_grp9x.Width = pic_9_grp9x.Width
            pic_9_grp9x.Height = pic_9_grp9x.Height
        ElseIf picture = "P16_1" Then
            If pic_1_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_1_grp16X.Width = pic_1_grp16X.Width
            pic_1_grp16X.Height = pic_1_grp16X.Height
        ElseIf picture = "P16_2" Then
            If pic_2_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_2_grp16X.Width = pic_2_grp16X.Width
            pic_2_grp16X.Height = pic_2_grp16X.Height
        ElseIf picture = "P16_3" Then
            If pic_3_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_3_grp16X.Width = pic_3_grp16X.Width
            pic_3_grp16X.Height = pic_3_grp16X.Height
        ElseIf picture = "P16_4" Then
            If pic_4_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_4_grp16X.Width = pic_4_grp16X.Width
            pic_4_grp16X.Height = pic_4_grp16X.Height
        ElseIf picture = "P16_5" Then
            If pic_5_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_5_grp16X.Width = pic_5_grp16X.Width
            pic_5_grp16X.Height = pic_5_grp16X.Height
        ElseIf picture = "P16_6" Then
            If pic_6_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_6_grp16X.Width = pic_6_grp16X.Width
            pic_6_grp16X.Height = pic_6_grp16X.Height
        ElseIf picture = "P16_7" Then
            If pic_7_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_7_grp16X.Width = pic_7_grp16X.Width
            pic_7_grp16X.Height = pic_7_grp16X.Height
        ElseIf picture = "P16_8" Then
            If pic_8_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_8_grp16X.Width = pic_8_grp16X.Width
            pic_8_grp16X.Height = pic_8_grp16X.Height
        ElseIf picture = "P16_9" Then
            If pic_9_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_9_grp16X.Width = pic_9_grp16X.Width
            pic_9_grp16X.Height = pic_9_grp16X.Height
        ElseIf picture = "P16_10" Then
            If pic_10_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_10_grp16X.Width = pic_10_grp16X.Width
            pic_10_grp16X.Height = pic_10_grp16X.Height
        ElseIf picture = "P16_11" Then
            If pic_11_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_11_grp16X.Width = pic_11_grp16X.Width
            pic_11_grp16X.Height = pic_11_grp16X.Height
        ElseIf picture = "P16_12" Then
            If pic_12_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_12_grp16X.Width = pic_12_grp16X.Width
            pic_12_grp16X.Height = pic_12_grp16X.Height
        ElseIf picture = "P16_13" Then
            If pic_13_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_13_grp16X.Width = pic_13_grp16X.Width
            pic_13_grp16X.Height = pic_13_grp16X.Height
        ElseIf picture = "P16_14" Then
            If pic_14_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_14_grp16X.Width = pic_14_grp16X.Width
            pic_14_grp16X.Height = pic_14_grp16X.Height
        ElseIf picture = "P16_15" Then
            If pic_15_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_15_grp16X.Width = pic_15_grp16X.Width
            pic_15_grp16X.Height = pic_15_grp16X.Height
        ElseIf picture = "P16_16" Then
            If pic_16_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_16_grp16X.Width = pic_16_grp16X.Width
            pic_16_grp16X.Height = pic_16_grp16X.Height
        ElseIf picture = "P18_1" Then
            If pic_1_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_1_grpFullMouth.Width = pic_1_grpFullMouth.Width
            pic_1_grpFullMouth.Height = pic_1_grpFullMouth.Height
        ElseIf picture = "P18_2" Then
            If pic_2_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_2_grpFullMouth.Width = pic_2_grpFullMouth.Width
            pic_2_grpFullMouth.Height = pic_2_grpFullMouth.Height
        ElseIf picture = "P18_3" Then
            If pic_3_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_3_grpFullMouth.Width = pic_3_grpFullMouth.Width
            pic_3_grpFullMouth.Height = pic_3_grpFullMouth.Height
        ElseIf picture = "P18_4" Then
            If pic_4_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_4_grpFullMouth.Width = pic_4_grpFullMouth.Width
            pic_4_grpFullMouth.Height = pic_4_grpFullMouth.Height
        ElseIf picture = "P18_5" Then
            If pic_5_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_5_grpFullMouth.Width = pic_5_grpFullMouth.Width
            pic_5_grpFullMouth.Height = pic_5_grpFullMouth.Height
        ElseIf picture = "P18_6" Then
            If pic_6_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_6_grpFullMouth.Width = pic_6_grpFullMouth.Width
            pic_6_grpFullMouth.Height = pic_6_grpFullMouth.Height
        ElseIf picture = "P18_7" Then
            If pic_7_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_7_grpFullMouth.Width = pic_7_grpFullMouth.Width
            pic_7_grpFullMouth.Height = pic_7_grpFullMouth.Height
        ElseIf picture = "P18_8" Then
            If pic_8_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_8_grpFullMouth.Width = pic_8_grpFullMouth.Width
            pic_8_grpFullMouth.Height = pic_8_grpFullMouth.Height
        ElseIf picture = "P18_9" Then
            If pic_9_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_9_grpFullMouth.Width = pic_9_grpFullMouth.Width
            pic_9_grpFullMouth.Height = pic_9_grpFullMouth.Height
        ElseIf picture = "P18_10" Then
            If pic_10_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_10_grpFullMouth.Width = pic_10_grpFullMouth.Width
            pic_10_grpFullMouth.Height = pic_10_grpFullMouth.Height
        ElseIf picture = "P18_11" Then
            If pic_11_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_11_grpFullMouth.Width = pic_11_grpFullMouth.Width
            pic_11_grpFullMouth.Height = pic_11_grpFullMouth.Height
        ElseIf picture = "P18_12" Then
            If pic_12_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_12_grpFullMouth.Width = pic_12_grpFullMouth.Width
            pic_12_grpFullMouth.Height = pic_12_grpFullMouth.Height
        ElseIf picture = "P18_13" Then
            If pic_13_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_13_grpFullMouth.Width = pic_13_grpFullMouth.Width
            pic_13_grpFullMouth.Height = pic_13_grpFullMouth.Height
        ElseIf picture = "P18_14" Then
            If pic_14_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_14_grpFullMouth.Width = pic_14_grpFullMouth.Width
            pic_14_grpFullMouth.Height = pic_14_grpFullMouth.Height
        ElseIf picture = "P18_15" Then
            If pic_15_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_15_grpFullMouth.Width = pic_15_grpFullMouth.Width
            pic_15_grpFullMouth.Height = pic_15_grpFullMouth.Height
        ElseIf picture = "P18_16" Then
            If pic_16_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_16_grpFullMouth.Width = pic_16_grpFullMouth.Width
            pic_16_grpFullMouth.Height = pic_16_grpFullMouth.Height
        ElseIf picture = "P18_17" Then
            If pic_17_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_17_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_17_grpFullMouth.Width = pic_17_grpFullMouth.Width
            pic_17_grpFullMouth.Height = pic_17_grpFullMouth.Height
        ElseIf picture = "P18_18" Then
            If pic_18_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_18_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_18_grpFullMouth.Width = pic_18_grpFullMouth.Width
            pic_18_grpFullMouth.Height = pic_18_grpFullMouth.Height
        End If
         Call RefreshImages()
        Call FillDetails()
    End Sub

    Private Sub Rotate270ºToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rotate270ºToolStripMenuItem.Click
        m_MouseIsDown = False
        If picture = "P1_1" Then
            If Pic_1_grp1X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp1X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Pic_1_grp1X.Width = Pic_1_grp1X.Width
            Pic_1_grp1X.Height = Pic_1_grp1X.Height
        ElseIf picture = "P2_1" Then
            If pic_1_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp2X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_1_grp2X.Width = pic_1_grp2X.Width
            pic_1_grp2X.Height = pic_1_grp2X.Height
        ElseIf picture = "P2_2" Then
            If pic_2_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp2X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_2_grp2X.Width = pic_2_grp2X.Width
            pic_2_grp2X.Height = pic_2_grp2X.Height
        ElseIf picture = "P4_1" Then
            If Pic_1_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp4X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Pic_1_grp4X.Width = Pic_1_grp4X.Width
            Pic_1_grp4X.Height = Pic_1_grp4X.Height
        ElseIf picture = "P4_2" Then
            If Pic_2_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_2_grp4X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Pic_2_grp4X.Width = Pic_2_grp4X.Width
            Pic_2_grp4X.Height = Pic_2_grp4X.Height
        ElseIf picture = "P4_3" Then
            If Pic_3_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_3_grp4X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Pic_3_grp4X.Width = Pic_3_grp4X.Width
            Pic_3_grp4X.Height = Pic_3_grp4X.Height
        ElseIf picture = "P4_4" Then
            If Pic_4_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_4_grp4X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Pic_4_grp4X.Width = Pic_4_grp4X.Width
            Pic_4_grp4X.Height = Pic_4_grp4X.Height
        ElseIf picture = "P9_1" Then
            If pic_1_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_1_grp9x.Width = pic_1_grp9x.Width
            pic_1_grp9x.Height = pic_1_grp9x.Height
        ElseIf picture = "P9_2" Then
            If pic_2_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_2_grp9x.Width = pic_2_grp9x.Width
            pic_2_grp9x.Height = pic_2_grp9x.Height
        ElseIf picture = "P9_3" Then
            If pic_3_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_3_grp9x.Width = pic_3_grp9x.Width
            pic_3_grp9x.Height = pic_3_grp9x.Height
        ElseIf picture = "P9_4" Then
            If pic_4_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_4_grp9x.Width = pic_4_grp9x.Width
            pic_4_grp9x.Height = pic_4_grp9x.Height
        ElseIf picture = "P9_5" Then
            If pic_5_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_5_grp9x.Width = pic_5_grp9x.Width
            pic_5_grp9x.Height = pic_5_grp9x.Height
        ElseIf picture = "P9_6" Then
            If pic_6_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_6_grp9x.Width = pic_6_grp9x.Width
            pic_6_grp9x.Height = pic_6_grp9x.Height
        ElseIf picture = "P9_7" Then
            If pic_7_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_7_grp9x.Width = pic_7_grp9x.Width
            pic_7_grp9x.Height = pic_7_grp9x.Height
        ElseIf picture = "P9_8" Then
            If pic_8_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_8_grp9x.Width = pic_8_grp9x.Width
            pic_8_grp9x.Height = pic_8_grp9x.Height
        ElseIf picture = "P9_9" Then
            If pic_9_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_9_grp9x.Width = pic_9_grp9x.Width
            pic_9_grp9x.Height = pic_9_grp9x.Height
        ElseIf picture = "P16_1" Then
            If pic_1_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_1_grp16X.Width = pic_1_grp16X.Width
            pic_1_grp16X.Height = pic_1_grp16X.Height
        ElseIf picture = "P16_2" Then
            If pic_2_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_2_grp16X.Width = pic_2_grp16X.Width
            pic_2_grp16X.Height = pic_2_grp16X.Height
        ElseIf picture = "P16_3" Then
            If pic_3_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_3_grp16X.Width = pic_3_grp16X.Width
            pic_3_grp16X.Height = pic_3_grp16X.Height
        ElseIf picture = "P16_4" Then
            If pic_4_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_4_grp16X.Width = pic_4_grp16X.Width
            pic_4_grp16X.Height = pic_4_grp16X.Height
        ElseIf picture = "P16_5" Then
            If pic_5_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_5_grp16X.Width = pic_5_grp16X.Width
            pic_5_grp16X.Height = pic_5_grp16X.Height
        ElseIf picture = "P16_6" Then
            If pic_6_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_6_grp16X.Width = pic_6_grp16X.Width
            pic_6_grp16X.Height = pic_6_grp16X.Height
        ElseIf picture = "P16_7" Then
            If pic_7_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_7_grp16X.Width = pic_7_grp16X.Width
            pic_7_grp16X.Height = pic_7_grp16X.Height
        ElseIf picture = "P16_8" Then
            If pic_8_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_8_grp16X.Width = pic_8_grp16X.Width
            pic_8_grp16X.Height = pic_8_grp16X.Height
        ElseIf picture = "P16_9" Then
            If pic_9_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_9_grp16X.Width = pic_9_grp16X.Width
            pic_9_grp16X.Height = pic_9_grp16X.Height
        ElseIf picture = "P16_10" Then
            If pic_10_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_10_grp16X.Width = pic_10_grp16X.Width
            pic_10_grp16X.Height = pic_10_grp16X.Height
        ElseIf picture = "P16_11" Then
            If pic_11_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_11_grp16X.Width = pic_11_grp16X.Width
            pic_11_grp16X.Height = pic_11_grp16X.Height
        ElseIf picture = "P16_12" Then
            If pic_12_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_12_grp16X.Width = pic_12_grp16X.Width
            pic_12_grp16X.Height = pic_12_grp16X.Height
        ElseIf picture = "P16_13" Then
            If pic_13_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_13_grp16X.Width = pic_13_grp16X.Width
            pic_13_grp16X.Height = pic_13_grp16X.Height
        ElseIf picture = "P16_14" Then
            If pic_14_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_14_grp16X.Width = pic_14_grp16X.Width
            pic_14_grp16X.Height = pic_14_grp16X.Height
        ElseIf picture = "P16_15" Then
            If pic_15_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_15_grp16X.Width = pic_15_grp16X.Width
            pic_15_grp16X.Height = pic_15_grp16X.Height
        ElseIf picture = "P16_16" Then
            If pic_16_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_16_grp16X.Width = pic_16_grp16X.Width
            pic_16_grp16X.Height = pic_16_grp16X.Height
        ElseIf picture = "P18_1" Then
            If pic_1_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_1_grpFullMouth.Width = pic_1_grpFullMouth.Width
            pic_1_grpFullMouth.Height = pic_1_grpFullMouth.Height
        ElseIf picture = "P18_2" Then
            If pic_2_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_2_grpFullMouth.Width = pic_2_grpFullMouth.Width
            pic_2_grpFullMouth.Height = pic_2_grpFullMouth.Height
        ElseIf picture = "P18_3" Then
            If pic_3_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_3_grpFullMouth.Width = pic_3_grpFullMouth.Width
            pic_3_grpFullMouth.Height = pic_3_grpFullMouth.Height
        ElseIf picture = "P18_4" Then
            If pic_4_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_4_grpFullMouth.Width = pic_4_grpFullMouth.Width
            pic_4_grpFullMouth.Height = pic_4_grpFullMouth.Height
        ElseIf picture = "P18_5" Then
            If pic_5_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_5_grpFullMouth.Width = pic_5_grpFullMouth.Width
            pic_5_grpFullMouth.Height = pic_5_grpFullMouth.Height
        ElseIf picture = "P18_6" Then
            If pic_6_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_6_grpFullMouth.Width = pic_6_grpFullMouth.Width
            pic_6_grpFullMouth.Height = pic_6_grpFullMouth.Height
        ElseIf picture = "P18_7" Then
            If pic_7_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_7_grpFullMouth.Width = pic_7_grpFullMouth.Width
            pic_7_grpFullMouth.Height = pic_7_grpFullMouth.Height
        ElseIf picture = "P18_8" Then
            If pic_8_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_8_grpFullMouth.Width = pic_8_grpFullMouth.Width
            pic_8_grpFullMouth.Height = pic_8_grpFullMouth.Height
        ElseIf picture = "P18_9" Then
            If pic_9_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_9_grpFullMouth.Width = pic_9_grpFullMouth.Width
            pic_9_grpFullMouth.Height = pic_9_grpFullMouth.Height
        ElseIf picture = "P18_10" Then
            If pic_10_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_10_grpFullMouth.Width = pic_10_grpFullMouth.Width
            pic_10_grpFullMouth.Height = pic_10_grpFullMouth.Height
        ElseIf picture = "P18_11" Then
            If pic_11_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_11_grpFullMouth.Width = pic_11_grpFullMouth.Width
            pic_11_grpFullMouth.Height = pic_11_grpFullMouth.Height
        ElseIf picture = "P18_12" Then
            If pic_12_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_12_grpFullMouth.Width = pic_12_grpFullMouth.Width
            pic_12_grpFullMouth.Height = pic_12_grpFullMouth.Height
        ElseIf picture = "P18_13" Then
            If pic_13_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_13_grpFullMouth.Width = pic_13_grpFullMouth.Width
            pic_13_grpFullMouth.Height = pic_13_grpFullMouth.Height
        ElseIf picture = "P18_14" Then
            If pic_14_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_14_grpFullMouth.Width = pic_14_grpFullMouth.Width
            pic_14_grpFullMouth.Height = pic_14_grpFullMouth.Height
        ElseIf picture = "P18_15" Then
            If pic_15_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_15_grpFullMouth.Width = pic_15_grpFullMouth.Width
            pic_15_grpFullMouth.Height = pic_15_grpFullMouth.Height
        ElseIf picture = "P18_16" Then
            If pic_16_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_16_grpFullMouth.Width = pic_16_grpFullMouth.Width
            pic_16_grpFullMouth.Height = pic_16_grpFullMouth.Height
        ElseIf picture = "P18_17" Then
            If pic_17_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_17_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_17_grpFullMouth.Width = pic_17_grpFullMouth.Width
            pic_17_grpFullMouth.Height = pic_17_grpFullMouth.Height
        ElseIf picture = "P18_18" Then
            If pic_18_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_18_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_18_grpFullMouth.Width = pic_18_grpFullMouth.Width
            pic_18_grpFullMouth.Height = pic_18_grpFullMouth.Height
        End If
         Call RefreshImages()
        Call FillDetails()
    End Sub

    Private Sub MirrorXToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MirrorXToolStripMenuItem1.Click
        m_MouseIsDown = False
        If picture = "P1_1" Then
            If Pic_1_grp1X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp1X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            Pic_1_grp1X.Width = Pic_1_grp1X.Width
            Pic_1_grp1X.Height = Pic_1_grp1X.Height
        ElseIf picture = "P2_1" Then
            If pic_1_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp2X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_1_grp2X.Width = pic_1_grp2X.Width
            pic_1_grp2X.Height = pic_1_grp2X.Height
        ElseIf picture = "P2_2" Then
            If pic_2_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp2X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_2_grp2X.Width = pic_2_grp2X.Width
            pic_2_grp2X.Height = pic_2_grp2X.Height

        ElseIf picture = "P4_1" Then
            If Pic_1_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            Pic_1_grp4X.Width = Pic_1_grp4X.Width
            Pic_1_grp4X.Height = Pic_1_grp4X.Height
        ElseIf picture = "P4_2" Then
            If Pic_2_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_2_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            Pic_2_grp4X.Width = Pic_2_grp4X.Width
            Pic_2_grp4X.Height = Pic_2_grp4X.Height
        ElseIf picture = "P4_3" Then
            If Pic_3_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_3_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            Pic_3_grp4X.Width = Pic_3_grp4X.Width
            Pic_3_grp4X.Height = Pic_3_grp4X.Height
        ElseIf picture = "P4_4" Then
            If Pic_4_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_4_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            Pic_4_grp4X.Width = Pic_4_grp4X.Width
            Pic_4_grp4X.Height = Pic_4_grp4X.Height
        ElseIf picture = "P9_1" Then
            If pic_1_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_1_grp9x.Width = pic_1_grp9x.Width
            pic_1_grp9x.Height = pic_1_grp9x.Height
        ElseIf picture = "P9_2" Then
            If pic_2_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_2_grp9x.Width = pic_2_grp9x.Width
            pic_2_grp9x.Height = pic_2_grp9x.Height
        ElseIf picture = "P9_3" Then
            If pic_3_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_3_grp9x.Width = pic_3_grp9x.Width
            pic_3_grp9x.Height = pic_3_grp9x.Height
        ElseIf picture = "P9_4" Then
            If pic_4_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_4_grp9x.Width = pic_4_grp9x.Width
            pic_4_grp9x.Height = pic_4_grp9x.Height
        ElseIf picture = "P9_5" Then
            If pic_5_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_5_grp9x.Width = pic_5_grp9x.Width
            pic_5_grp9x.Height = pic_5_grp9x.Height
        ElseIf picture = "P9_6" Then
            If pic_6_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_6_grp9x.Width = pic_6_grp9x.Width
            pic_6_grp9x.Height = pic_6_grp9x.Height
        ElseIf picture = "P9_7" Then
            If pic_7_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_7_grp9x.Width = pic_7_grp9x.Width
            pic_7_grp9x.Height = pic_7_grp9x.Height
        ElseIf picture = "P9_8" Then
            If pic_8_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_8_grp9x.Width = pic_8_grp9x.Width
            pic_8_grp9x.Height = pic_8_grp9x.Height
        ElseIf picture = "P9_9" Then
            If pic_9_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_9_grp9x.Width = pic_9_grp9x.Width
            pic_9_grp9x.Height = pic_9_grp9x.Height
        ElseIf picture = "P16_1" Then
            If pic_1_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_1_grp16X.Width = pic_1_grp16X.Width
            pic_1_grp16X.Height = pic_1_grp16X.Height
        ElseIf picture = "P16_2" Then
            If pic_2_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_2_grp16X.Width = pic_2_grp16X.Width
            pic_2_grp16X.Height = pic_2_grp16X.Height
        ElseIf picture = "P16_3" Then
            If pic_3_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_3_grp16X.Width = pic_3_grp16X.Width
            pic_3_grp16X.Height = pic_3_grp16X.Height
        ElseIf picture = "P16_4" Then
            If pic_4_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_4_grp16X.Width = pic_4_grp16X.Width
            pic_4_grp16X.Height = pic_4_grp16X.Height
        ElseIf picture = "P16_5" Then
            If pic_5_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_5_grp16X.Width = pic_5_grp16X.Width
            pic_5_grp16X.Height = pic_5_grp16X.Height
        ElseIf picture = "P16_6" Then
            If pic_6_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_6_grp16X.Width = pic_6_grp16X.Width
            pic_6_grp16X.Height = pic_6_grp16X.Height
        ElseIf picture = "P16_7" Then
            If pic_7_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_7_grp16X.Width = pic_7_grp16X.Width
            pic_7_grp16X.Height = pic_7_grp16X.Height
        ElseIf picture = "P16_8" Then
            If pic_8_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_8_grp16X.Width = pic_8_grp16X.Width
            pic_8_grp16X.Height = pic_8_grp16X.Height
        ElseIf picture = "P16_9" Then
            If pic_9_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_9_grp16X.Width = pic_9_grp16X.Width
            pic_9_grp16X.Height = pic_9_grp16X.Height
        ElseIf picture = "P16_10" Then
            If pic_10_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_10_grp16X.Width = pic_10_grp16X.Width
            pic_10_grp16X.Height = pic_10_grp16X.Height
        ElseIf picture = "P16_11" Then
            If pic_11_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_11_grp16X.Width = pic_11_grp16X.Width
            pic_11_grp16X.Height = pic_11_grp16X.Height
        ElseIf picture = "P16_12" Then
            If pic_12_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_12_grp16X.Width = pic_12_grp16X.Width
            pic_12_grp16X.Height = pic_12_grp16X.Height
        ElseIf picture = "P16_13" Then
            If pic_13_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_13_grp16X.Width = pic_13_grp16X.Width
            pic_13_grp16X.Height = pic_13_grp16X.Height
        ElseIf picture = "P16_14" Then
            If pic_14_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_14_grp16X.Width = pic_14_grp16X.Width
            pic_14_grp16X.Height = pic_14_grp16X.Height
        ElseIf picture = "P16_15" Then
            If pic_15_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_15_grp16X.Width = pic_15_grp16X.Width
            pic_15_grp16X.Height = pic_15_grp16X.Height
        ElseIf picture = "P16_16" Then
            If pic_16_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_16_grp16X.Width = pic_16_grp16X.Width
            pic_16_grp16X.Height = pic_16_grp16X.Height
        ElseIf picture = "P18_1" Then
            If pic_1_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_1_grpFullMouth.Width = pic_1_grpFullMouth.Width
            pic_1_grpFullMouth.Height = pic_1_grpFullMouth.Height
        ElseIf picture = "P18_2" Then
            If pic_2_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_2_grpFullMouth.Width = pic_2_grpFullMouth.Width
            pic_2_grpFullMouth.Height = pic_2_grpFullMouth.Height
        ElseIf picture = "P18_3" Then
            If pic_3_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_3_grpFullMouth.Width = pic_3_grpFullMouth.Width
            pic_3_grpFullMouth.Height = pic_3_grpFullMouth.Height
        ElseIf picture = "P18_4" Then
            If pic_4_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_4_grpFullMouth.Width = pic_4_grpFullMouth.Width
            pic_4_grpFullMouth.Height = pic_4_grpFullMouth.Height
        ElseIf picture = "P18_5" Then
            If pic_5_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_5_grpFullMouth.Width = pic_5_grpFullMouth.Width
            pic_5_grpFullMouth.Height = pic_5_grpFullMouth.Height
        ElseIf picture = "P18_6" Then
            If pic_6_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_6_grpFullMouth.Width = pic_6_grpFullMouth.Width
            pic_6_grpFullMouth.Height = pic_6_grpFullMouth.Height
        ElseIf picture = "P18_7" Then
            If pic_7_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_7_grpFullMouth.Width = pic_7_grpFullMouth.Width
            pic_7_grpFullMouth.Height = pic_7_grpFullMouth.Height
        ElseIf picture = "P18_8" Then
            If pic_8_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_8_grpFullMouth.Width = pic_8_grpFullMouth.Width
            pic_8_grpFullMouth.Height = pic_8_grpFullMouth.Height
        ElseIf picture = "P18_9" Then
            If pic_9_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_9_grpFullMouth.Width = pic_9_grpFullMouth.Width
            pic_9_grpFullMouth.Height = pic_9_grpFullMouth.Height
        ElseIf picture = "P18_10" Then
            If pic_10_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_10_grpFullMouth.Width = pic_10_grpFullMouth.Width
            pic_10_grpFullMouth.Height = pic_10_grpFullMouth.Height
        ElseIf picture = "P18_11" Then
            If pic_11_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_11_grpFullMouth.Width = pic_11_grpFullMouth.Width
            pic_11_grpFullMouth.Height = pic_11_grpFullMouth.Height
        ElseIf picture = "P18_12" Then
            If pic_12_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_12_grpFullMouth.Width = pic_12_grpFullMouth.Width
            pic_12_grpFullMouth.Height = pic_12_grpFullMouth.Height
        ElseIf picture = "P18_13" Then
            If pic_13_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_13_grpFullMouth.Width = pic_13_grpFullMouth.Width
            pic_13_grpFullMouth.Height = pic_13_grpFullMouth.Height
        ElseIf picture = "P18_14" Then
            If pic_14_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_14_grpFullMouth.Width = pic_14_grpFullMouth.Width
            pic_14_grpFullMouth.Height = pic_14_grpFullMouth.Height
        ElseIf picture = "P18_15" Then
            If pic_15_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_15_grpFullMouth.Width = pic_15_grpFullMouth.Width
            pic_15_grpFullMouth.Height = pic_15_grpFullMouth.Height
        ElseIf picture = "P18_16" Then
            If pic_16_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_16_grpFullMouth.Width = pic_16_grpFullMouth.Width
            pic_16_grpFullMouth.Height = pic_16_grpFullMouth.Height
        ElseIf picture = "P18_17" Then
            If pic_17_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_17_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_17_grpFullMouth.Width = pic_17_grpFullMouth.Width
            pic_17_grpFullMouth.Height = pic_17_grpFullMouth.Height
        ElseIf picture = "P18_18" Then
            If pic_18_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_18_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_18_grpFullMouth.Width = pic_18_grpFullMouth.Width
            pic_18_grpFullMouth.Height = pic_18_grpFullMouth.Height
        End If
         Call RefreshImages()
        Call FillDetails()
    End Sub

    Private Sub MirrorYToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MirrorYToolStripMenuItem1.Click
        m_MouseIsDown = False
        If picture = "P1_1" Then
            If Pic_1_grp1X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp1X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            Pic_1_grp1X.Width = Pic_1_grp1X.Width
            Pic_1_grp1X.Height = Pic_1_grp1X.Height

        ElseIf picture = "P2_1" Then
            If pic_1_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp2X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_1_grp2X.Width = pic_1_grp2X.Width
            pic_1_grp2X.Height = pic_1_grp2X.Height

        ElseIf picture = "P2_2" Then
            If pic_2_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp2X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_2_grp2X.Width = pic_2_grp2X.Width
            pic_2_grp2X.Height = pic_2_grp2X.Height

        ElseIf picture = "P4_1" Then
            If Pic_1_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            Pic_1_grp4X.Width = Pic_1_grp4X.Width
            Pic_1_grp4X.Height = Pic_1_grp4X.Height

        ElseIf picture = "P4_2" Then
            If Pic_2_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_2_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            Pic_2_grp4X.Width = Pic_2_grp4X.Width
            Pic_2_grp4X.Height = Pic_2_grp4X.Height

        ElseIf picture = "P4_3" Then
            If Pic_3_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_3_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            Pic_3_grp4X.Width = Pic_3_grp4X.Width
            Pic_3_grp4X.Height = Pic_3_grp4X.Height

        ElseIf picture = "P4_4" Then
            If Pic_4_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_4_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            Pic_4_grp4X.Width = Pic_4_grp4X.Width
            Pic_4_grp4X.Height = Pic_4_grp4X.Height

        ElseIf picture = "P9_1" Then
            If pic_1_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_1_grp9x.Width = pic_1_grp9x.Width
            pic_1_grp9x.Height = pic_1_grp9x.Height

        ElseIf picture = "P9_2" Then
            If pic_2_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_2_grp9x.Width = pic_2_grp9x.Width
            pic_2_grp9x.Height = pic_2_grp9x.Height
        ElseIf picture = "P9_3" Then
            If pic_3_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_3_grp9x.Width = pic_3_grp9x.Width
            pic_3_grp9x.Height = pic_3_grp9x.Height
        ElseIf picture = "P9_4" Then
            If pic_4_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_4_grp9x.Width = pic_4_grp9x.Width
            pic_4_grp9x.Height = pic_4_grp9x.Height
        ElseIf picture = "P9_5" Then
            If pic_5_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_5_grp9x.Width = pic_5_grp9x.Width
            pic_5_grp9x.Height = pic_5_grp9x.Height
        ElseIf picture = "P9_6" Then
            If pic_6_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_6_grp9x.Width = pic_6_grp9x.Width
            pic_6_grp9x.Height = pic_6_grp9x.Height
        ElseIf picture = "P9_7" Then
            If pic_7_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_7_grp9x.Width = pic_7_grp9x.Width
            pic_7_grp9x.Height = pic_7_grp9x.Height
        ElseIf picture = "P9_8" Then
            If pic_8_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_8_grp9x.Width = pic_8_grp9x.Width
            pic_8_grp9x.Height = pic_8_grp9x.Height
        ElseIf picture = "P9_9" Then
            If pic_9_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_9_grp9x.Width = pic_9_grp9x.Width
            pic_9_grp9x.Height = pic_9_grp9x.Height
        ElseIf picture = "P16_1" Then
            If pic_1_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_1_grp16X.Width = pic_1_grp16X.Width
            pic_1_grp16X.Height = pic_1_grp16X.Height
        ElseIf picture = "P16_2" Then
            If pic_2_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_2_grp16X.Width = pic_2_grp16X.Width
            pic_2_grp16X.Height = pic_2_grp16X.Height
        ElseIf picture = "P16_3" Then
            If pic_3_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_3_grp16X.Width = pic_3_grp16X.Width
            pic_3_grp16X.Height = pic_3_grp16X.Height
        ElseIf picture = "P16_4" Then
            If pic_4_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_4_grp16X.Width = pic_4_grp16X.Width
            pic_4_grp16X.Height = pic_4_grp16X.Height
        ElseIf picture = "P16_5" Then
            If pic_5_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_5_grp16X.Width = pic_5_grp16X.Width
            pic_5_grp16X.Height = pic_5_grp16X.Height
        ElseIf picture = "P16_6" Then
            If pic_6_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_6_grp16X.Width = pic_6_grp16X.Width
            pic_6_grp16X.Height = pic_6_grp16X.Height
        ElseIf picture = "P16_7" Then
            If pic_7_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_7_grp16X.Width = pic_7_grp16X.Width
            pic_7_grp16X.Height = pic_7_grp16X.Height
        ElseIf picture = "P16_8" Then
            If pic_8_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_8_grp16X.Width = pic_8_grp16X.Width
            pic_8_grp16X.Height = pic_8_grp16X.Height
        ElseIf picture = "P16_9" Then
            If pic_9_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_9_grp16X.Width = pic_9_grp16X.Width
            pic_9_grp16X.Height = pic_9_grp16X.Height
        ElseIf picture = "P16_10" Then
            If pic_10_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_10_grp16X.Width = pic_10_grp16X.Width
            pic_10_grp16X.Height = pic_10_grp16X.Height
        ElseIf picture = "P16_11" Then
            If pic_11_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_11_grp16X.Width = pic_11_grp16X.Width
            pic_11_grp16X.Height = pic_11_grp16X.Height
        ElseIf picture = "P16_12" Then
            If pic_12_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_12_grp16X.Width = pic_12_grp16X.Width
            pic_12_grp16X.Height = pic_12_grp16X.Height
        ElseIf picture = "P16_13" Then
            If pic_13_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_13_grp16X.Width = pic_13_grp16X.Width
            pic_13_grp16X.Height = pic_13_grp16X.Height
        ElseIf picture = "P16_14" Then
            If pic_14_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_14_grp16X.Width = pic_14_grp16X.Width
            pic_14_grp16X.Height = pic_14_grp16X.Height
        ElseIf picture = "P16_15" Then
            If pic_15_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_15_grp16X.Width = pic_15_grp16X.Width
            pic_15_grp16X.Height = pic_15_grp16X.Height
        ElseIf picture = "P16_16" Then
            If pic_16_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_16_grp16X.Width = pic_16_grp16X.Width
            pic_16_grp16X.Height = pic_16_grp16X.Height
        ElseIf picture = "P18_1" Then
            If pic_1_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_1_grpFullMouth.Width = pic_1_grpFullMouth.Width
            pic_1_grpFullMouth.Height = pic_1_grpFullMouth.Height
        ElseIf picture = "P18_2" Then
            If pic_2_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_2_grpFullMouth.Width = pic_2_grpFullMouth.Width
            pic_2_grpFullMouth.Height = pic_2_grpFullMouth.Height
        ElseIf picture = "P18_3" Then
            If pic_3_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_3_grpFullMouth.Width = pic_3_grpFullMouth.Width
            pic_3_grpFullMouth.Height = pic_3_grpFullMouth.Height
        ElseIf picture = "P18_4" Then
            If pic_4_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_4_grpFullMouth.Width = pic_4_grpFullMouth.Width
            pic_4_grpFullMouth.Height = pic_4_grpFullMouth.Height
        ElseIf picture = "P18_5" Then
            If pic_5_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_5_grpFullMouth.Width = pic_5_grpFullMouth.Width
            pic_5_grpFullMouth.Height = pic_5_grpFullMouth.Height
        ElseIf picture = "P18_6" Then
            If pic_6_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_6_grpFullMouth.Width = pic_6_grpFullMouth.Width
            pic_6_grpFullMouth.Height = pic_6_grpFullMouth.Height
        ElseIf picture = "P18_7" Then
            If pic_7_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_7_grpFullMouth.Width = pic_7_grpFullMouth.Width
            pic_7_grpFullMouth.Height = pic_7_grpFullMouth.Height
        ElseIf picture = "P18_8" Then
            If pic_8_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_8_grpFullMouth.Width = pic_8_grpFullMouth.Width
            pic_8_grpFullMouth.Height = pic_8_grpFullMouth.Height
        ElseIf picture = "P18_9" Then
            If pic_9_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_9_grpFullMouth.Width = pic_9_grpFullMouth.Width
            pic_9_grpFullMouth.Height = pic_9_grpFullMouth.Height
        ElseIf picture = "P18_10" Then
            If pic_10_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_10_grpFullMouth.Width = pic_10_grpFullMouth.Width
            pic_10_grpFullMouth.Height = pic_10_grpFullMouth.Height
        ElseIf picture = "P18_11" Then
            If pic_11_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_11_grpFullMouth.Width = pic_11_grpFullMouth.Width
            pic_11_grpFullMouth.Height = pic_11_grpFullMouth.Height
        ElseIf picture = "P18_12" Then
            If pic_12_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_12_grpFullMouth.Width = pic_12_grpFullMouth.Width
            pic_12_grpFullMouth.Height = pic_12_grpFullMouth.Height
        ElseIf picture = "P18_13" Then
            If pic_13_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_13_grpFullMouth.Width = pic_13_grpFullMouth.Width
            pic_13_grpFullMouth.Height = pic_13_grpFullMouth.Height
        ElseIf picture = "P18_14" Then
            If pic_14_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_14_grpFullMouth.Width = pic_14_grpFullMouth.Width
            pic_14_grpFullMouth.Height = pic_14_grpFullMouth.Height
        ElseIf picture = "P18_15" Then
            If pic_15_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_15_grpFullMouth.Width = pic_15_grpFullMouth.Width
            pic_15_grpFullMouth.Height = pic_15_grpFullMouth.Height
        ElseIf picture = "P18_16" Then
            If pic_16_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_16_grpFullMouth.Width = pic_16_grpFullMouth.Width
            pic_16_grpFullMouth.Height = pic_16_grpFullMouth.Height
        ElseIf picture = "P18_17" Then
            If pic_17_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_17_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_17_grpFullMouth.Width = pic_17_grpFullMouth.Width
            pic_17_grpFullMouth.Height = pic_17_grpFullMouth.Height
        ElseIf picture = "P18_18" Then
            If pic_18_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_18_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_18_grpFullMouth.Width = pic_18_grpFullMouth.Width
            pic_18_grpFullMouth.Height = pic_18_grpFullMouth.Height
        End If
       Call RefreshImages()
        Call FillDetails()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        m_MouseIsDown = False
        ExportOriginalToolStripMenuItem.Enabled = False
        If picture = "P1_1" Then
            If Pic_1_grp1X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp1X.Image = Nothing
            Pic_1_grp1X.ImageLocation = ""
        ElseIf picture = "P2_1" Then
            If pic_1_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp2X.Image = Nothing
            pic_1_grp2X.ImageLocation = ""
        ElseIf picture = "P2_2" Then
            If pic_2_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp2X.Image = Nothing
            pic_2_grp2X.ImageLocation = ""
        ElseIf picture = "P4_1" Then
            If Pic_1_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp4X.Image = Nothing
            Pic_1_grp4X.ImageLocation = ""
        ElseIf picture = "P4_2" Then
            If Pic_2_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_2_grp4X.Image = Nothing
            Pic_2_grp4X.ImageLocation = ""
        ElseIf picture = "P4_3" Then
            If Pic_3_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_3_grp4X.Image = Nothing
            Pic_3_grp4X.ImageLocation = ""
        ElseIf picture = "P4_4" Then
            If Pic_4_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_4_grp4X.Image = Nothing
            Pic_4_grp4X.ImageLocation = ""
        ElseIf picture = "P9_1" Then
            If pic_1_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp9x.Image = Nothing
            pic_1_grp9x.ImageLocation = ""
        ElseIf picture = "P9_2" Then
            If pic_2_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp9x.Image = Nothing
            pic_2_grp9x.ImageLocation = ""
        ElseIf picture = "P9_3" Then
            If pic_3_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp9x.Image = Nothing
            pic_3_grp9x.ImageLocation = ""
        ElseIf picture = "P9_4" Then
            If pic_4_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp9x.Image = Nothing
            pic_4_grp9x.ImageLocation = ""
        ElseIf picture = "P9_5" Then
            If pic_5_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp9x.Image = Nothing
            pic_5_grp9x.ImageLocation = ""
        ElseIf picture = "P9_6" Then
            If pic_6_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp9x.Image = Nothing
        ElseIf picture = "P9_7" Then
            If pic_7_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp9x.Image = Nothing
            pic_7_grp9x.ImageLocation = ""
        ElseIf picture = "P9_8" Then
            If pic_8_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp9x.Image = Nothing
            pic_8_grp9x.ImageLocation = ""
        ElseIf picture = "P9_9" Then
            If pic_9_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp9x.Image = Nothing
            pic_9_grp9x.ImageLocation = ""

        ElseIf picture = "P16_1" Then
            If pic_1_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp16X.Image = Nothing
            pic_1_grp16X.ImageLocation = ""
        ElseIf picture = "P16_2" Then
            If pic_2_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp16X.Image = Nothing
            pic_2_grp16X.ImageLocation = ""
        ElseIf picture = "P16_3" Then
            If pic_3_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp16X.Image = Nothing
            pic_3_grp16X.ImageLocation = ""
        ElseIf picture = "P16_4" Then
            If pic_4_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp16X.Image = Nothing
            pic_4_grp16X.ImageLocation = ""
        ElseIf picture = "P16_5" Then
            If pic_5_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp16X.Image = Nothing
            pic_5_grp16X.ImageLocation = ""
        ElseIf picture = "P16_6" Then
            If pic_6_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp16X.Image = Nothing
        ElseIf picture = "P16_7" Then
            If pic_7_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp16X.Image = Nothing
            pic_7_grp16X.ImageLocation = ""
        ElseIf picture = "P16_8" Then
            If pic_8_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp16X.Image = Nothing
            pic_8_grp16X.ImageLocation = ""
        ElseIf picture = "P16_9" Then
            If pic_9_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp16X.Image = Nothing
            pic_9_grp16X.ImageLocation = ""
        ElseIf picture = "P16_10" Then
            If pic_10_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grp16X.Image = Nothing
            pic_10_grp16X.ImageLocation = ""
        ElseIf picture = "P16_11" Then
            If pic_11_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grp16X.Image = Nothing
            pic_11_grp16X.ImageLocation = ""
        ElseIf picture = "P16_12" Then
            If pic_12_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grp16X.Image = Nothing
            pic_12_grp16X.ImageLocation = ""
        ElseIf picture = "P16_13" Then
            If pic_13_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grp16X.Image = Nothing
            pic_13_grp16X.ImageLocation = ""
        ElseIf picture = "P16_14" Then
            If pic_14_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grp16X.Image = Nothing
            pic_14_grp16X.ImageLocation = ""
        ElseIf picture = "P16_15" Then
            If pic_15_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grp16X.Image = Nothing
        ElseIf picture = "P16_16" Then
            If pic_16_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grp16X.Image = Nothing
            pic_16_grp16X.ImageLocation = ""

        ElseIf picture = "P18_1" Then
            If pic_1_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grpFullMouth.Image = Nothing
            pic_1_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_2" Then
            If pic_2_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grpFullMouth.Image = Nothing
            pic_2_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_3" Then
            If pic_3_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grpFullMouth.Image = Nothing
            pic_3_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_4" Then
            If pic_4_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grpFullMouth.Image = Nothing
            pic_4_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_5" Then
            If pic_5_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grpFullMouth.Image = Nothing
            pic_5_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_6" Then
            If pic_6_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grpFullMouth.Image = Nothing
            pic_6_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_7" Then
            If pic_7_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grpFullMouth.Image = Nothing
            pic_7_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_8" Then
            If pic_8_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grpFullMouth.Image = Nothing
            pic_8_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_9" Then
            If pic_9_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grpFullMouth.Image = Nothing
            pic_9_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_10" Then
            If pic_10_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grpFullMouth.Image = Nothing
            pic_10_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_11" Then
            If pic_11_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grpFullMouth.Image = Nothing
            pic_11_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_12" Then
            If pic_12_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grpFullMouth.Image = Nothing
            pic_12_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_13" Then
            If pic_13_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grpFullMouth.Image = Nothing
            pic_13_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_14" Then
            If pic_14_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grpFullMouth.Image = Nothing
            pic_14_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_15" Then
            If pic_15_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grpFullMouth.Image = Nothing
            pic_15_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_16" Then
            If pic_16_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grpFullMouth.Image = Nothing
            pic_16_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_17" Then
            If pic_17_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_17_grpFullMouth.Image = Nothing
            pic_17_grpFullMouth.ImageLocation = ""
        ElseIf picture = "P18_18" Then
            If pic_18_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_18_grpFullMouth.Image = Nothing
            pic_18_grpFullMouth.ImageLocation = ""
        End If
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
        m_MouseIsDown = False
        ExportOriginalToolStripMenuItem.Enabled = False
        If grp1X.Visible = True Then
            Pic_1_grp1X.Image = Nothing
            Pic_1_grp1X.ImageLocation = ""
        ElseIf grp2X.Visible = True Then
            pic_1_grp2X.Image = Nothing
            pic_2_grp2X.Image = Nothing
            pic_1_grp2X.ImageLocation = ""
            pic_2_grp2X.ImageLocation = ""
        ElseIf grp4X.Visible = True Then
            Pic_1_grp4X.Image = Nothing
            Pic_2_grp4X.Image = Nothing
            Pic_3_grp4X.Image = Nothing
            Pic_4_grp4X.Image = Nothing
            Pic_1_grp4X.ImageLocation = ""
            Pic_2_grp4X.ImageLocation = ""
            Pic_3_grp4X.ImageLocation = ""
            Pic_4_grp4X.ImageLocation = ""
        ElseIf grp9X.Visible = True Then
            pic_1_grp9x.Image = Nothing
            pic_2_grp9x.Image = Nothing
            pic_3_grp9x.Image = Nothing
            pic_4_grp9x.Image = Nothing
            pic_5_grp9x.Image = Nothing
            pic_6_grp9x.Image = Nothing
            pic_7_grp9x.Image = Nothing
            pic_8_grp9x.Image = Nothing
            pic_9_grp9x.Image = Nothing
            pic_1_grp9x.ImageLocation = ""
            pic_2_grp9x.ImageLocation = ""
            pic_3_grp9x.ImageLocation = ""
            pic_4_grp9x.ImageLocation = ""
            pic_5_grp9x.ImageLocation = ""
            pic_6_grp9x.ImageLocation = ""
            pic_7_grp9x.ImageLocation = ""
            pic_8_grp9x.ImageLocation = ""
            pic_9_grp9x.ImageLocation = ""
        ElseIf grp16X.Visible = True Then
            pic_1_grp16X.Image = Nothing
            pic_2_grp16X.Image = Nothing
            pic_3_grp16X.Image = Nothing
            pic_4_grp16X.Image = Nothing
            pic_5_grp16X.Image = Nothing
            pic_6_grp16X.Image = Nothing
            pic_7_grp16X.Image = Nothing
            pic_8_grp16X.Image = Nothing
            pic_9_grp16X.Image = Nothing
            pic_10_grp16X.Image = Nothing
            pic_11_grp16X.Image = Nothing
            pic_12_grp16X.Image = Nothing
            pic_13_grp16X.Image = Nothing
            pic_14_grp16X.Image = Nothing
            pic_15_grp16X.Image = Nothing
            pic_16_grp16X.Image = Nothing
            pic_1_grp16X.ImageLocation = ""
            pic_2_grp16X.ImageLocation = ""
            pic_3_grp16X.ImageLocation = ""
            pic_4_grp16X.ImageLocation = ""
            pic_5_grp16X.ImageLocation = ""
            pic_6_grp16X.ImageLocation = ""
            pic_7_grp16X.ImageLocation = ""
            pic_8_grp16X.ImageLocation = ""
            pic_9_grp16X.ImageLocation = ""
            pic_10_grp16X.ImageLocation = ""
            pic_11_grp16X.ImageLocation = ""
            pic_12_grp16X.ImageLocation = ""
            pic_13_grp16X.ImageLocation = ""
            pic_14_grp16X.ImageLocation = ""
            pic_15_grp16X.ImageLocation = ""
            pic_16_grp16X.ImageLocation = ""
        ElseIf grpFullMouth.Visible = True Then
            pic_1_grpFullMouth.Image = Nothing
            pic_2_grpFullMouth.Image = Nothing
            pic_3_grpFullMouth.Image = Nothing
            pic_4_grpFullMouth.Image = Nothing
            pic_5_grpFullMouth.Image = Nothing
            pic_6_grpFullMouth.Image = Nothing
            pic_7_grpFullMouth.Image = Nothing
            pic_8_grpFullMouth.Image = Nothing
            pic_9_grpFullMouth.Image = Nothing
            pic_10_grpFullMouth.Image = Nothing
            pic_11_grpFullMouth.Image = Nothing
            pic_12_grpFullMouth.Image = Nothing
            pic_13_grpFullMouth.Image = Nothing
            pic_14_grpFullMouth.Image = Nothing
            pic_15_grpFullMouth.Image = Nothing
            pic_16_grpFullMouth.Image = Nothing
            pic_17_grpFullMouth.Image = Nothing
            pic_18_grpFullMouth.Image = Nothing
            pic_1_grpFullMouth.ImageLocation = ""
            pic_2_grpFullMouth.ImageLocation = ""
            pic_3_grpFullMouth.ImageLocation = ""
            pic_4_grpFullMouth.ImageLocation = ""
            pic_5_grpFullMouth.ImageLocation = ""
            pic_6_grpFullMouth.ImageLocation = ""
            pic_7_grpFullMouth.ImageLocation = ""
            pic_8_grpFullMouth.ImageLocation = ""
            pic_9_grpFullMouth.ImageLocation = ""
            pic_10_grpFullMouth.ImageLocation = ""
            pic_11_grpFullMouth.ImageLocation = ""
            pic_12_grpFullMouth.ImageLocation = ""
            pic_13_grpFullMouth.ImageLocation = ""
            pic_14_grpFullMouth.ImageLocation = ""
            pic_15_grpFullMouth.ImageLocation = ""
            pic_16_grpFullMouth.ImageLocation = ""
            pic_17_grpFullMouth.ImageLocation = ""
            pic_18_grpFullMouth.ImageLocation = ""
        End If
    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        m_MouseIsDown = False
        If FName <> "" Then
            frm_Image_Properties.FName = FName
            frm_Image_Properties.Show()
        End If
    End Sub

    Private Sub ToolStripButton26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton26.Click
        If PatientId <> "" Then

        Else
            MsgBox("Select any Patient!")
            Exit Sub
        End If
        If currentImage = "1X1" Then
            If Pic_1_grp1X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & Pic_1_grp1X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(Pic_1_grp1X.ImageLocation)
            Pic_1_grp1X.Image = Nothing
        ElseIf currentImage = "2X1" Then
            If pic_1_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_1_grp2X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_1_grp2X.ImageLocation)
            pic_1_grp2X.Image = Nothing
        ElseIf currentImage = "2X2" Then
            If pic_2_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_2_grp2X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_2_grp2X.ImageLocation)
            pic_2_grp2X.Image = Nothing
        ElseIf currentImage = "4X1" Then
            If Pic_1_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & Pic_1_grp4X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(Pic_1_grp4X.ImageLocation)
            Pic_1_grp4X.Image = Nothing
        ElseIf currentImage = "4X2" Then
            If Pic_2_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & Pic_2_grp4X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(Pic_2_grp4X.ImageLocation)
            Pic_2_grp4X.Image = Nothing
        ElseIf currentImage = "4X3" Then
            If Pic_3_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & Pic_3_grp4X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(Pic_3_grp4X.ImageLocation)
            Pic_3_grp4X.Image = Nothing
        ElseIf currentImage = "4X4" Then
            If Pic_4_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & Pic_4_grp4X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(Pic_4_grp4X.ImageLocation)
            Pic_4_grp4X.Image = Nothing
        ElseIf currentImage = "9X1" Then
            If pic_1_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_1_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_1_grp9x.ImageLocation)
            pic_1_grp9x.Image = Nothing
        ElseIf currentImage = "9X2" Then
            If pic_2_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_2_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_2_grp9x.ImageLocation)
            pic_2_grp9x.Image = Nothing
        ElseIf currentImage = "9X3" Then
            If pic_3_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_3_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_3_grp9x.ImageLocation)
            pic_3_grp9x.Image = Nothing
        ElseIf currentImage = "9X4" Then
            If pic_4_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_4_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_4_grp9x.ImageLocation)
            pic_4_grp9x.Image = Nothing
        ElseIf currentImage = "9X5" Then
            If pic_5_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_5_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_5_grp9x.ImageLocation)
            pic_5_grp9x.Image = Nothing
        ElseIf currentImage = "9X6" Then
            If pic_6_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_6_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_6_grp9x.ImageLocation)
            pic_6_grp9x.Image = Nothing
        ElseIf currentImage = "9X7" Then
            If pic_7_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_7_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_3_grp9x.ImageLocation)
            pic_7_grp9x.Image = Nothing
        ElseIf currentImage = "9X8" Then
            If pic_8_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_8_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_8_grp9x.ImageLocation)
            pic_8_grp9x.Image = Nothing
        ElseIf currentImage = "9X9" Then
            If pic_9_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_9_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_9_grp9x.ImageLocation)
            pic_9_grp9x.Image = Nothing
        ElseIf currentImage = "18X1" Then
            If pic_1_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_1_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_1_grpFullMouth.ImageLocation)
            pic_1_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X2" Then
            If pic_2_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_2_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_2_grpFullMouth.ImageLocation)
            pic_2_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X3" Then
            If pic_3_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_3_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_3_grpFullMouth.ImageLocation)
            pic_3_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X4" Then
            If pic_4_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_4_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_4_grpFullMouth.ImageLocation)
            pic_4_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X5" Then
            If pic_5_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_5_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_5_grpFullMouth.ImageLocation)
            pic_5_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X6" Then
            If pic_6_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_6_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_6_grpFullMouth.ImageLocation)
            pic_6_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X7" Then
            If pic_7_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_7_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_7_grpFullMouth.ImageLocation)
            pic_7_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X8" Then
            If pic_8_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_8_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_8_grpFullMouth.ImageLocation)
            pic_8_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X9" Then
            If pic_9_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_9_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_9_grpFullMouth.ImageLocation)
            pic_9_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X10" Then
            If pic_10_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_10_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_10_grpFullMouth.ImageLocation)
            pic_10_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X11" Then
            If pic_11_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_11_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_11_grpFullMouth.ImageLocation)
            pic_11_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X12" Then
            If pic_12_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_12_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_12_grpFullMouth.ImageLocation)
            pic_12_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X13" Then
            If pic_13_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_13_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_13_grpFullMouth.ImageLocation)
            pic_13_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X14" Then
            If pic_14_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_14_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_14_grpFullMouth.ImageLocation)
            pic_14_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X15" Then
            If pic_15_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_15_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_15_grpFullMouth.ImageLocation)
            pic_15_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X16" Then
            If pic_16_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_16_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_16_grpFullMouth.ImageLocation)
            pic_16_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X17" Then
            If pic_17_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_17_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_17_grpFullMouth.ImageLocation)
            pic_17_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X18" Then
            If pic_18_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_18_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_18_grpFullMouth.ImageLocation)
            pic_18_grpFullMouth.Image = Nothing
        ElseIf currentImage = "16X1" Then
            If pic_1_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_1_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_1_grp16X.ImageLocation)
            pic_1_grp16X.Image = Nothing
        ElseIf currentImage = "16X2" Then
            If pic_2_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_2_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_2_grp16X.ImageLocation)
            pic_2_grp16X.Image = Nothing
        ElseIf currentImage = "16X3" Then
            If pic_3_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_3_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_3_grp16X.ImageLocation)
            pic_3_grp16X.Image = Nothing
        ElseIf currentImage = "16X4" Then
            If pic_4_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_4_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_4_grp16X.ImageLocation)
            pic_4_grp16X.Image = Nothing
        ElseIf currentImage = "16X5" Then
            If pic_5_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_5_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_5_grp16X.ImageLocation)
            pic_5_grp16X.Image = Nothing
        ElseIf currentImage = "16X6" Then
            If pic_6_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_6_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_6_grp16X.ImageLocation)
            pic_6_grp16X.Image = Nothing
        ElseIf currentImage = "16X7" Then
            If pic_7_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_7_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_7_grp16X.ImageLocation)
            pic_7_grp16X.Image = Nothing
        ElseIf currentImage = "16X8" Then
            If pic_8_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_8_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_8_grp16X.ImageLocation)
            pic_8_grp16X.Image = Nothing
        ElseIf currentImage = "16X9" Then
            If pic_9_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_9_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_9_grp16X.ImageLocation)
            pic_9_grp16X.Image = Nothing
        ElseIf currentImage = "16X10" Then
            If pic_10_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_10_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_10_grp16X.ImageLocation)
            pic_10_grp16X.Image = Nothing
        ElseIf currentImage = "16X11" Then
            If pic_11_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_11_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_11_grp16X.ImageLocation)
            pic_11_grp16X.Image = Nothing
        ElseIf currentImage = "16X12" Then
            If pic_12_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_12_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_12_grp16X.ImageLocation)
            pic_12_grp16X.Image = Nothing
        ElseIf currentImage = "16X13" Then
            If pic_13_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_13_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_13_grp16X.ImageLocation)
            pic_13_grp16X.Image = Nothing
        ElseIf currentImage = "16X14" Then
            If pic_14_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_14_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_14_grp16X.ImageLocation)
            pic_14_grp16X.Image = Nothing
        ElseIf currentImage = "16X15" Then
            If pic_15_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_15_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_15_grp16X.ImageLocation)
            pic_15_grp16X.Image = Nothing
        ElseIf currentImage = "16X16" Then
            If pic_16_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_16_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_16_grp16X.ImageLocation)
            pic_16_grp16X.Image = Nothing
        End If
        Call FillDetails()
    End Sub

    Private Sub HistogramToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistogramToolStripMenuItem1.Click
        m_MouseIsDown = False
        If path <> "" Then
            If Pic = "1X1" Then
                frm_Histogram.PictureBox1.Image = Pic_1_grp1X.Image
            ElseIf Pic = "2X1" Then
                frm_Histogram.PictureBox1.Image = pic_1_grp2X.Image
            ElseIf Pic = "2X2" Then
                frm_Histogram.PictureBox1.Image = pic_2_grp2X.Image
            ElseIf Pic = "4X1" Then
                frm_Histogram.PictureBox1.Image = Pic_1_grp4X.Image
            ElseIf Pic = "4X2" Then
                frm_Histogram.PictureBox1.Image = Pic_2_grp4X.Image
            ElseIf Pic = "4X3" Then
                frm_Histogram.PictureBox1.Image = Pic_3_grp4X.Image
            ElseIf Pic = "4X4" Then
                frm_Histogram.PictureBox1.Image = Pic_4_grp4X.Image
            ElseIf Pic = "9X1" Then
                frm_Histogram.PictureBox1.Image = pic_1_grp9x.Image
            ElseIf Pic = "9X2" Then
                frm_Histogram.PictureBox1.Image = pic_2_grp9x.Image
            ElseIf Pic = "9X3" Then
                frm_Histogram.PictureBox1.Image = pic_3_grp9x.Image
            ElseIf Pic = "9X4" Then
                frm_Histogram.PictureBox1.Image = pic_4_grp9x.Image
            ElseIf Pic = "9X5" Then
                frm_Histogram.PictureBox1.Image = pic_5_grp9x.Image
            ElseIf Pic = "9X6" Then
                frm_Histogram.PictureBox1.Image = pic_6_grp9x.Image
            ElseIf Pic = "9X7" Then
                frm_Histogram.PictureBox1.Image = pic_7_grp9x.Image
            ElseIf Pic = "9X8" Then
                frm_Histogram.PictureBox1.Image = pic_8_grp9x.Image
            ElseIf Pic = "9X9" Then
                frm_Histogram.PictureBox1.Image = pic_9_grp9x.Image
            ElseIf Pic = "16X1" Then
                frm_Histogram.PictureBox1.Image = pic_1_grp16X.Image
            ElseIf Pic = "16X2" Then
                frm_Histogram.PictureBox1.Image = pic_2_grp16X.Image
            ElseIf Pic = "16X3" Then
                frm_Histogram.PictureBox1.Image = pic_3_grp16X.Image
            ElseIf Pic = "16X4" Then
                frm_Histogram.PictureBox1.Image = pic_4_grp16X.Image
            ElseIf Pic = "16X5" Then
                frm_Histogram.PictureBox1.Image = pic_5_grp16X.Image
            ElseIf Pic = "16X6" Then
                frm_Histogram.PictureBox1.Image = pic_6_grp16X.Image
            ElseIf Pic = "16X7" Then
                frm_Histogram.PictureBox1.Image = pic_7_grp16X.Image
            ElseIf Pic = "16X8" Then
                frm_Histogram.PictureBox1.Image = pic_8_grp16X.Image
            ElseIf Pic = "16X9" Then
                frm_Histogram.PictureBox1.Image = pic_9_grp16X.Image
            ElseIf Pic = "16X10" Then
                frm_Histogram.PictureBox1.Image = pic_10_grp16X.Image
            ElseIf Pic = "16X11" Then
                frm_Histogram.PictureBox1.Image = pic_11_grp16X.Image
            ElseIf Pic = "16X12" Then
                frm_Histogram.PictureBox1.Image = pic_12_grp16X.Image
            ElseIf Pic = "16X13" Then
                frm_Histogram.PictureBox1.Image = pic_13_grp16X.Image
            ElseIf Pic = "16X14" Then
                frm_Histogram.PictureBox1.Image = pic_14_grp16X.Image
            ElseIf Pic = "16X15" Then
                frm_Histogram.PictureBox1.Image = pic_15_grp16X.Image
            ElseIf Pic = "16X16" Then
                frm_Histogram.PictureBox1.Image = pic_16_grp16X.Image
            ElseIf Pic = "18X1" Then
                frm_Histogram.PictureBox1.Image = pic_1_grpFullMouth.Image
            ElseIf Pic = "18X2" Then
                frm_Histogram.PictureBox1.Image = pic_2_grpFullMouth.Image
            ElseIf Pic = "18X3" Then
                frm_Histogram.PictureBox1.Image = pic_3_grpFullMouth.Image
            ElseIf Pic = "18X4" Then
                frm_Histogram.PictureBox1.Image = pic_4_grpFullMouth.Image
            ElseIf Pic = "18X5" Then
                frm_Histogram.PictureBox1.Image = pic_5_grpFullMouth.Image
            ElseIf Pic = "18X6" Then
                frm_Histogram.PictureBox1.Image = pic_6_grpFullMouth.Image
            ElseIf Pic = "18X7" Then
                frm_Histogram.PictureBox1.Image = pic_7_grpFullMouth.Image
            ElseIf Pic = "18X8" Then
                frm_Histogram.PictureBox1.Image = pic_8_grpFullMouth.Image
            ElseIf Pic = "18X9" Then
                frm_Histogram.PictureBox1.Image = pic_9_grpFullMouth.Image
            ElseIf Pic = "18X10" Then
                frm_Histogram.PictureBox1.Image = pic_10_grpFullMouth.Image
            ElseIf Pic = "18X11" Then
                frm_Histogram.PictureBox1.Image = pic_11_grpFullMouth.Image
            ElseIf Pic = "18X12" Then
                frm_Histogram.PictureBox1.Image = pic_12_grpFullMouth.Image
            ElseIf Pic = "18X13" Then
                frm_Histogram.PictureBox1.Image = pic_13_grpFullMouth.Image
            ElseIf Pic = "18X14" Then
                frm_Histogram.PictureBox1.Image = pic_14_grpFullMouth.Image
            ElseIf Pic = "18X15" Then
                frm_Histogram.PictureBox1.Image = pic_15_grpFullMouth.Image
            ElseIf Pic = "18X16" Then
                frm_Histogram.PictureBox1.Image = pic_16_grpFullMouth.Image
            ElseIf Pic = "18X17" Then
                frm_Histogram.PictureBox1.Image = pic_17_grpFullMouth.Image
            ElseIf Pic = "18X18" Then
                frm_Histogram.PictureBox1.Image = pic_18_grpFullMouth.Image
            End If
            frm_Histogram.lblImage.Text = Pic
            frm_Histogram.PictureBox1.ImageLocation = path
            frm_Histogram.Show()
        End If
    End Sub

    Private Sub PropertiesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem1.Click
        m_MouseIsDown = False
        If FName <> "" Then
            frm_Image_Properties.FName = FName
            frm_Image_Properties.Show()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem2.Click
        m_MouseIsDown = False
        If path <> "" Then
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & path & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(path)
        End If
        Call FillDetails()
    End Sub

    Private Sub ColorBrandingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorBrandingToolStripMenuItem.Click
        If currentImage = "2X1" Then
            If pic_1_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            Dim bm As New Bitmap(pic_1_grp2X.Image)
            Dim X As Integer
            Dim Y As Integer
            Dim clr As Integer

            For X = 0 To bm.Width - 1
                For Y = 0 To bm.Height - 1
                    clr = (CInt(bm.GetPixel(X, Y).R) + _
                           bm.GetPixel(X, Y).G + _
                           bm.GetPixel(X, Y).B) \ 3
                    bm.SetPixel(X, Y, Color.FromArgb(clr, clr, clr))
                Next Y
            Next X
            pic_1_grp2X.Image = bm

        End If
    End Sub

    Private Sub HistogramToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistogramToolStripMenuItem.Click
        If PatientId <> "" Then
            frm_Histogram.Show()

        Else
            MsgBox("Select any Patient!")
        End If
    End Sub

    Private Sub ImagePropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagePropertiesToolStripMenuItem.Click
        If PatientId <> "" Then
            If FName <> "" Then
                frm_Image_Properties.FName = FName
                frm_Image_Properties.Show()
            End If
        Else
            MsgBox("Select any Patient!")
        End If
    End Sub

    Private Sub FullScreenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullScreenToolStripMenuItem1.Click
        If path <> "" Then
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call FillDetails()
    End Sub

    Private Sub pic_1_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_1_grpFullMouth.DoubleClick
        If pic_1_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_1_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_1_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_1"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X1"
        End If
    End Sub

    Private Sub pic_2_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_2_grpFullMouth.DoubleClick
        If pic_2_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub


    Private Sub pic_2_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_2_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_2"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X2"
        End If
    End Sub

    Private Sub pic_3_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_3_grpFullMouth.DoubleClick
        If pic_3_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub


    Private Sub pic_3_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_3_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_3"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X3"
        End If
    End Sub

    Private Sub pic_4_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_4_grpFullMouth.DoubleClick
        If pic_4_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

   
    Private Sub pic_4_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_4_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_4"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X4"
        End If
    End Sub

    Private Sub pic_5_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_5_grpFullMouth.DoubleClick
        If pic_5_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_5_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_5_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_5"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X5"
        End If
    End Sub

    Private Sub pic_6_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_6_grpFullMouth.DoubleClick
        If pic_16_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_6_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_6_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_6"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X6"
        End If
    End Sub

    Private Sub pic_7_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_7_grpFullMouth.DoubleClick
        If pic_7_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_7_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_7_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_7"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X7"
        End If
    End Sub

    Private Sub pic_8_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_8_grpFullMouth.DoubleClick
        If pic_8_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_8_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_8_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_8"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X8"
        End If
    End Sub

    Private Sub pic_9_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_9_grpFullMouth.DoubleClick
        If pic_9_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_9_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_9_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_9"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X9"
        End If
    End Sub

    Private Sub pic_10_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_10_grpFullMouth.DoubleClick
        If pic_10_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_10_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_10_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_10"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X10"
        End If
    End Sub

    Private Sub pic_11_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_11_grpFullMouth.DoubleClick
        If pic_11_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_11_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_11_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_11"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X11"
        End If
    End Sub

    Private Sub pic_12_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_12_grpFullMouth.DoubleClick
        If pic_12_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_12_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_12_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_12"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X12"
        End If
    End Sub

    Private Sub pic_13_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_13_grpFullMouth.DoubleClick
        If pic_13_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_13_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_13_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_13"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X13"
        End If
    End Sub

    Private Sub pic_14_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_14_grpFullMouth.DoubleClick
        If pic_14_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_14_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_14_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_14"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X14"
        End If
    End Sub

    Private Sub pic_15_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_15_grpFullMouth.DoubleClick
        If pic_15_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_15_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_15_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_15"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X15"
        End If
    End Sub

    Private Sub pic_16_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_16_grpFullMouth.DoubleClick
        If pic_16_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_16_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_16_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_16"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X16"
        End If
    End Sub

    Private Sub pic_17_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_17_grpFullMouth.DoubleClick
        If pic_17_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_17_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_17_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_17"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X17"
        End If
    End Sub

    Private Sub pic_18_grpFullMouth_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_18_grpFullMouth.DoubleClick
        If pic_18_grpFullMouth.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_18_grpFullMouth_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_18_grpFullMouth.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P18_18"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "18X18"
        End If
    End Sub

    Private Sub Pic_1_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_1_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_1_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_1_grpFullMouth.ImageLocation = path
        pic_1_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_1_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_1_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_1_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_1_grpFullMouth.MouseDown
        If Not pic_1_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X1"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_1_grpFullMouth.ImageLocation
            FName = pic_1_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_1_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_1_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_1_grpFullMouth.Image Is Nothing Then
            pic_1_grpFullMouth.DoDragDrop(pic_1_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X1" Then
                    pic_1_grpFullMouth.Image = Fun_Contrast(pic_1_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X1" Then
                    pic_1_grpFullMouth.Image = Fun_Contrast(pic_1_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_2_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_2_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_2_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_2_grpFullMouth.ImageLocation = path
        pic_2_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_2_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_2_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_2_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_2_grpFullMouth.MouseDown
        If Not pic_2_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X2"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_2_grpFullMouth.ImageLocation
            FName = pic_2_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_2_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_2_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_2_grpFullMouth.Image Is Nothing Then
            pic_2_grpFullMouth.DoDragDrop(pic_2_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X2" Then
                    pic_2_grpFullMouth.Image = Fun_Contrast(pic_2_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X2" Then
                    pic_2_grpFullMouth.Image = Fun_Contrast(pic_2_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_3_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_3_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_3_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_3_grpFullMouth.ImageLocation = path
        pic_3_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_3_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_3_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_3_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_3_grpFullMouth.MouseDown
        If Not pic_3_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X3"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_3_grpFullMouth.ImageLocation
            FName = pic_3_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_3_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_3_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_3_grpFullMouth.Image Is Nothing Then
            pic_3_grpFullMouth.DoDragDrop(pic_3_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X3" Then
                    pic_3_grpFullMouth.Image = Fun_Contrast(pic_3_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X3" Then
                    pic_3_grpFullMouth.Image = Fun_Contrast(pic_3_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_4_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_4_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_4_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_4_grpFullMouth.ImageLocation = path
        pic_4_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_4_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_4_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_4_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_4_grpFullMouth.MouseDown
        If Not pic_4_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X4"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_4_grpFullMouth.ImageLocation
            FName = pic_4_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_4_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_4_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_4_grpFullMouth.Image Is Nothing Then
            pic_4_grpFullMouth.DoDragDrop(pic_4_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X4" Then
                    pic_4_grpFullMouth.Image = Fun_Contrast(pic_1_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X4" Then
                    pic_4_grpFullMouth.Image = Fun_Contrast(pic_4_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_5_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_5_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_5_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_5_grpFullMouth.ImageLocation = path
        pic_5_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_5_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_5_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_5_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_5_grpFullMouth.MouseDown
        If Not pic_5_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X5"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_5_grpFullMouth.ImageLocation
            FName = pic_5_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_5_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_5_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_5_grpFullMouth.Image Is Nothing Then
            pic_5_grpFullMouth.DoDragDrop(pic_5_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X5" Then
                    pic_5_grpFullMouth.Image = Fun_Contrast(pic_5_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X5" Then
                    pic_5_grpFullMouth.Image = Fun_Contrast(pic_5_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_6_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_6_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_6_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_6_grpFullMouth.ImageLocation = path
        pic_6_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_6_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_6_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_6_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_6_grpFullMouth.MouseDown
        If Not pic_6_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X6"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_6_grpFullMouth.ImageLocation
            FName = pic_6_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_6_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_6_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_6_grpFullMouth.Image Is Nothing Then
            pic_6_grpFullMouth.DoDragDrop(pic_6_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X6" Then
                    pic_6_grpFullMouth.Image = Fun_Contrast(pic_6_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X6" Then
                    pic_6_grpFullMouth.Image = Fun_Contrast(pic_6_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_7_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_7_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_7_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_7_grpFullMouth.ImageLocation = path
        pic_7_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_7_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_7_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_7_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_7_grpFullMouth.MouseDown
        If Not pic_7_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X7"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_7_grpFullMouth.ImageLocation
            FName = pic_7_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_7_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_7_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_7_grpFullMouth.Image Is Nothing Then
            pic_7_grpFullMouth.DoDragDrop(pic_7_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X7" Then
                    pic_7_grpFullMouth.Image = Fun_Contrast(pic_7_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X7" Then
                    pic_7_grpFullMouth.Image = Fun_Contrast(pic_7_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_8_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_8_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_8_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_8_grpFullMouth.ImageLocation = path
        pic_8_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_8_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_8_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_8_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_8_grpFullMouth.MouseDown
        If Not pic_8_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X8"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_8_grpFullMouth.ImageLocation
            FName = pic_8_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_8_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_8_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_8_grpFullMouth.Image Is Nothing Then
            pic_8_grpFullMouth.DoDragDrop(pic_8_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X8" Then
                    pic_8_grpFullMouth.Image = Fun_Contrast(pic_8_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X8" Then
                    pic_8_grpFullMouth.Image = Fun_Contrast(pic_8_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_9_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_9_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_9_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_9_grpFullMouth.ImageLocation = path
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_9_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_9_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_9_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_9_grpFullMouth.MouseDown
        If Not pic_9_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X9"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_9_grpFullMouth.ImageLocation
            FName = pic_9_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_9_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_9_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_9_grpFullMouth.Image Is Nothing Then
            pic_9_grpFullMouth.DoDragDrop(pic_9_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X9" Then
                    pic_9_grpFullMouth.Image = Fun_Contrast(pic_9_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X9" Then
                    pic_9_grpFullMouth.Image = Fun_Contrast(pic_9_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_10_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_10_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_10_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_10_grpFullMouth.ImageLocation = path
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_10_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_10_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_10_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_10_grpFullMouth.MouseDown
        If Not pic_10_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X10"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_10_grpFullMouth.ImageLocation
            FName = pic_10_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_10_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_10_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_10_grpFullMouth.Image Is Nothing Then
            pic_10_grpFullMouth.DoDragDrop(pic_10_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X10" Then
                    pic_10_grpFullMouth.Image = Fun_Contrast(pic_10_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X10" Then
                    pic_10_grpFullMouth.Image = Fun_Contrast(pic_10_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_11_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_11_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_11_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_11_grpFullMouth.ImageLocation = path
        pic_11_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_11_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_11_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_11_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_11_grpFullMouth.MouseDown
        If Not pic_11_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X11"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_11_grpFullMouth.ImageLocation
            FName = pic_11_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_11_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_11_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_11_grpFullMouth.Image Is Nothing Then
            pic_11_grpFullMouth.DoDragDrop(pic_11_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X11" Then
                    pic_11_grpFullMouth.Image = Fun_Contrast(pic_11_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X11" Then
                    pic_11_grpFullMouth.Image = Fun_Contrast(pic_11_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_12_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_12_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_12_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_12_grpFullMouth.ImageLocation = path
        pic_12_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_12_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_12_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_12_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_12_grpFullMouth.MouseDown
        If Not pic_12_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X12"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_12_grpFullMouth.ImageLocation
            FName = pic_12_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_12_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_12_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_12_grpFullMouth.Image Is Nothing Then
            pic_12_grpFullMouth.DoDragDrop(pic_12_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X12" Then
                    pic_12_grpFullMouth.Image = Fun_Contrast(pic_12_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X12" Then
                    pic_12_grpFullMouth.Image = Fun_Contrast(pic_12_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_13_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_13_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_13_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_13_grpFullMouth.ImageLocation = path
        pic_13_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_13_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_13_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_13_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_13_grpFullMouth.MouseDown
        If Not pic_13_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X13"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_13_grpFullMouth.ImageLocation
            FName = pic_13_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_13_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_13_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_13_grpFullMouth.Image Is Nothing Then
            pic_13_grpFullMouth.DoDragDrop(pic_13_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X13" Then
                    pic_13_grpFullMouth.Image = Fun_Contrast(pic_13_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X13" Then
                    pic_13_grpFullMouth.Image = Fun_Contrast(pic_13_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_14_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_14_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_14_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_14_grpFullMouth.ImageLocation = path
        pic_14_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_14_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_14_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_14_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_14_grpFullMouth.MouseDown
        If Not pic_14_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X14"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_14_grpFullMouth.ImageLocation
            FName = pic_14_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_14_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_14_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_14_grpFullMouth.Image Is Nothing Then
            pic_14_grpFullMouth.DoDragDrop(pic_14_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X14" Then
                    pic_14_grpFullMouth.Image = Fun_Contrast(pic_14_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X14" Then
                    pic_14_grpFullMouth.Image = Fun_Contrast(pic_14_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_15_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_15_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_15_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_15_grpFullMouth.ImageLocation = path
        pic_15_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_15_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_15_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_15_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_15_grpFullMouth.MouseDown
        If Not pic_15_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X15"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_15_grpFullMouth.ImageLocation
            FName = pic_15_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_15_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_15_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_15_grpFullMouth.Image Is Nothing Then
            pic_15_grpFullMouth.DoDragDrop(pic_15_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X15" Then
                    pic_15_grpFullMouth.Image = Fun_Contrast(pic_15_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X15" Then
                    pic_15_grpFullMouth.Image = Fun_Contrast(pic_15_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_16_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_16_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_16_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_16_grpFullMouth.ImageLocation = path
        pic_16_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_16_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_16_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_16_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_16_grpFullMouth.MouseDown
        If Not pic_16_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X16"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_16_grpFullMouth.ImageLocation
            FName = pic_16_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_16_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_16_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_16_grpFullMouth.Image Is Nothing Then
            pic_16_grpFullMouth.DoDragDrop(pic_16_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X16" Then
                    pic_16_grpFullMouth.Image = Fun_Contrast(pic_16_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X16" Then
                    pic_16_grpFullMouth.Image = Fun_Contrast(pic_16_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_17_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_17_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_17_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_17_grpFullMouth.ImageLocation = path
        pic_17_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X18" Then
                pic_18_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_17_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_17_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_17_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_17_grpFullMouth.MouseDown
        If Not pic_17_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X17"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_18_grpFullMouth.Cursor = Cursors.Default
                mouseX = e.Y
            End If
            path = pic_17_grpFullMouth.ImageLocation
            FName = pic_17_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_17_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_17_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_17_grpFullMouth.Image Is Nothing Then
            pic_17_grpFullMouth.DoDragDrop(pic_17_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X17" Then
                    pic_17_grpFullMouth.Image = Fun_Contrast(pic_17_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X17" Then
                    pic_17_grpFullMouth.Image = Fun_Contrast(pic_17_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub Pic_18_grpFullMouth_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_18_grpFullMouth.DragDrop
        If Pic = "" And (pic_1_grpFullMouth.ImageLocation = path Or pic_2_grpFullMouth.ImageLocation = path Or pic_3_grpFullMouth.ImageLocation = path Or pic_4_grpFullMouth.ImageLocation = path Or pic_5_grpFullMouth.ImageLocation = path Or pic_6_grpFullMouth.ImageLocation = path Or pic_7_grpFullMouth.ImageLocation = path Or pic_8_grpFullMouth.ImageLocation = path Or pic_9_grpFullMouth.ImageLocation = path Or pic_10_grpFullMouth.ImageLocation = path Or pic_11_grpFullMouth.ImageLocation = path Or pic_12_grpFullMouth.ImageLocation = path Or pic_13_grpFullMouth.ImageLocation = path Or pic_14_grpFullMouth.ImageLocation = path Or pic_15_grpFullMouth.ImageLocation = path Or pic_16_grpFullMouth.ImageLocation = path Or pic_17_grpFullMouth.ImageLocation = path Or pic_18_grpFullMouth.ImageLocation = path) Then
            Exit Sub
        End If
        pic_18_grpFullMouth.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_18_grpFullMouth.ImageLocation = path
        pic_18_grpFullMouth.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "18X2" Then
                pic_2_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X3" Then
                pic_3_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X4" Then
                pic_4_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X5" Then
                pic_5_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X6" Then
                pic_6_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X7" Then
                pic_7_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X8" Then
                pic_8_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X9" Then
                pic_9_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X10" Then
                pic_10_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X11" Then
                pic_11_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X12" Then
                pic_12_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X13" Then
                pic_13_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X14" Then
                pic_14_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X15" Then
                pic_15_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X16" Then
                pic_16_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X17" Then
                pic_17_grpFullMouth.Image = Nothing
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Image = Nothing
            Else
                m_MouseIsDown = False
            End If
            Pic = ""
        End If

    End Sub

    Private Sub Pic_18_grpFullMouth_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_18_grpFullMouth.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_18_grpFullMouth_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_18_grpFullMouth.MouseDown
        If Not pic_18_grpFullMouth.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "18X18"
            If Contrast = 1 Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.NoMoveVert
                mouseX = e.Y
            End If
            path = pic_18_grpFullMouth.ImageLocation
            FName = pic_18_grpFullMouth.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_18_grpFullMouth_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_18_grpFullMouth.MouseMove
        If m_MouseIsDown And Contrast = 0 And Not pic_18_grpFullMouth.Image Is Nothing Then
            pic_18_grpFullMouth.DoDragDrop(pic_18_grpFullMouth.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "18X18" Then
                    pic_18_grpFullMouth.Image = Fun_Contrast(pic_18_grpFullMouth.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "18X18" Then
                    pic_18_grpFullMouth.Image = Fun_Contrast(pic_18_grpFullMouth.Image, -50)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub ToolStripButton21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton21.Click
        If Contrast = 1 Then
            Contrast = 0
            pic_1_grp2X.Cursor = Cursors.Default
            pic_2_grp2X.Cursor = Cursors.Default
            Pic_1_grp4X.Cursor = Cursors.Default
            Pic_2_grp4X.Cursor = Cursors.Default
            Pic_3_grp4X.Cursor = Cursors.Default
            Pic_4_grp4X.Cursor = Cursors.Default
            pic_1_grp9x.Cursor = Cursors.Default
            pic_2_grp9x.Cursor = Cursors.Default
            pic_3_grp9x.Cursor = Cursors.Default
            pic_4_grp9x.Cursor = Cursors.Default
            pic_5_grp9x.Cursor = Cursors.Default
            pic_6_grp9x.Cursor = Cursors.Default
            pic_7_grp9x.Cursor = Cursors.Default
            pic_8_grp9x.Cursor = Cursors.Default
            pic_9_grp9x.Cursor = Cursors.Default
            pic_1_grpFullMouth.Cursor = Cursors.Default
            pic_2_grpFullMouth.Cursor = Cursors.Default
            pic_3_grpFullMouth.Cursor = Cursors.Default
            pic_4_grpFullMouth.Cursor = Cursors.Default
            pic_5_grpFullMouth.Cursor = Cursors.Default
            pic_6_grpFullMouth.Cursor = Cursors.Default
            pic_7_grpFullMouth.Cursor = Cursors.Default
            pic_8_grpFullMouth.Cursor = Cursors.Default
            pic_9_grpFullMouth.Cursor = Cursors.Default
            pic_10_grpFullMouth.Cursor = Cursors.Default
            pic_11_grpFullMouth.Cursor = Cursors.Default
            pic_12_grpFullMouth.Cursor = Cursors.Default
            pic_13_grpFullMouth.Cursor = Cursors.Default
            pic_14_grpFullMouth.Cursor = Cursors.Default
            pic_15_grpFullMouth.Cursor = Cursors.Default
            pic_16_grpFullMouth.Cursor = Cursors.Default
            pic_17_grpFullMouth.Cursor = Cursors.Default
            pic_18_grpFullMouth.Cursor = Cursors.Default
        Else
            Contrast = 1
            If Pic = "2X1" Then
                pic_1_grp2X.Cursor = Cursors.NoMoveVert
                pic_2_grp2X.Cursor = Cursors.Default
            ElseIf Pic = "2X2" Then
                pic_2_grp2X.Cursor = Cursors.NoMoveVert
                pic_1_grp2X.Cursor = Cursors.Default
            ElseIf Pic = "4X1" Then
                Pic_1_grp4X.Cursor = Cursors.NoMoveVert
                Pic_2_grp4X.Cursor = Cursors.Default
                Pic_3_grp4X.Cursor = Cursors.Default
                Pic_4_grp4X.Cursor = Cursors.Default
            ElseIf Pic = "4X2" Then
                Pic_2_grp4X.Cursor = Cursors.NoMoveVert
                Pic_1_grp4X.Cursor = Cursors.Default
                Pic_3_grp4X.Cursor = Cursors.Default
                Pic_4_grp4X.Cursor = Cursors.Default
            ElseIf Pic = "4X3" Then
                Pic_3_grp4X.Cursor = Cursors.NoMoveVert
                Pic_2_grp4X.Cursor = Cursors.Default
                Pic_1_grp4X.Cursor = Cursors.Default
                Pic_4_grp4X.Cursor = Cursors.Default
            ElseIf Pic = "4X4" Then
                Pic_4_grp4X.Cursor = Cursors.NoMoveVert
                Pic_2_grp4X.Cursor = Cursors.Default
                Pic_3_grp4X.Cursor = Cursors.Default
                Pic_1_grp4X.Cursor = Cursors.Default
            ElseIf Pic = "9X1" Then
                pic_1_grp9x.Cursor = Cursors.NoMoveVert
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X2" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.NoMoveVert
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X3" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.NoMoveVert
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X4" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.NoMoveVert
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X5" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.NoMoveVert
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X6" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.NoMoveVert
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X7" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.NoMoveVert
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X8" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.NoMoveVert
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X9" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.NoMoveVert
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X2" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X3" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X4" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X5" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X6" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X7" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X8" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X9" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X10" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X11" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X12" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X13" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X14" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X15" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X16" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X17" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.NoMoveVert
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X18" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.NoMoveVert
            End If
        End If

    End Sub

    Private Sub ResetContrastToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetContrastToolStripMenuItem.Click
        Contrast = 0
        If Pic = "2X1" Then
            pic_1_grp2X.Cursor = Cursors.Default
            pic_1_grp2X.Image = pic_1_grp2X.Image
        ElseIf Pic = "2X2" Then
            pic_2_grp2X.Cursor = Cursors.Default
            pic_2_grp2X.Image = pic_2_grp2X.Image
        ElseIf Pic = "4X1" Then
            Pic_1_grp4X.Cursor = Cursors.Default
            Pic_1_grp4X.Image = Pic_1_grp4X.Image
        ElseIf Pic = "4X2" Then
            Pic_2_grp4X.Cursor = Cursors.Default
            Pic_2_grp4X.Image = Pic_2_grp4X.Image
        ElseIf Pic = "4X3" Then
            Pic_3_grp4X.Cursor = Cursors.Default
            Pic_3_grp4X.Image = Pic_3_grp4X.Image
        ElseIf Pic = "4X4" Then
            Pic_4_grp4X.Cursor = Cursors.Default
            Pic_4_grp4X.Image = Pic_4_grp4X.Image
        ElseIf Pic = "9X1" Then
            pic_1_grp9x.Cursor = Cursors.Default
            pic_1_grp9x.Image = pic_1_grp9x.Image
        ElseIf Pic = "9X2" Then
            pic_2_grp9x.Cursor = Cursors.Default
            pic_2_grp9x.Image = pic_2_grp9x.Image
        ElseIf Pic = "9X3" Then
            pic_3_grp9x.Cursor = Cursors.Default
            pic_3_grp9x.Image = pic_3_grp9x.Image
        ElseIf Pic = "9X4" Then
            pic_4_grp9x.Cursor = Cursors.Default
            pic_4_grp9x.Image = pic_4_grp9x.Image
        ElseIf Pic = "9X5" Then
            pic_5_grp9x.Cursor = Cursors.Default
            pic_5_grp9x.Image = pic_1_grp9x.Image
        ElseIf Pic = "9X6" Then
            pic_6_grp9x.Cursor = Cursors.Default
            pic_6_grp9x.Image = pic_6_grp9x.Image
        ElseIf Pic = "9X7" Then
            pic_7_grp9x.Cursor = Cursors.Default
            pic_7_grp9x.Image = pic_7_grp9x.Image
        ElseIf Pic = "9X8" Then
            pic_8_grp9x.Cursor = Cursors.Default
            pic_8_grp9x.Image = pic_8_grp9x.Image
        ElseIf Pic = "9X9" Then
            pic_9_grp9x.Cursor = Cursors.Default
            pic_9_grp9x.Image = pic_9_grp9x.Image
        End If
    End Sub

    Private Sub ToolStripButton15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton15.Click
        If PatientId <> "" Then
            frm_Patient_NewImage.Show()
        Else
            MsgBox("Select any Patient!")
        End If
    End Sub

    Private Sub ToolStripButton20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton20.Click
        If Bright = 1 Then
            Bright = 0
            pic_1_grp2X.Cursor = Cursors.Default
            pic_2_grp2X.Cursor = Cursors.Default
            Pic_1_grp4X.Cursor = Cursors.Default
            Pic_2_grp4X.Cursor = Cursors.Default
            Pic_3_grp4X.Cursor = Cursors.Default
            Pic_4_grp4X.Cursor = Cursors.Default
            pic_1_grp9x.Cursor = Cursors.Default
            pic_2_grp9x.Cursor = Cursors.Default
            pic_3_grp9x.Cursor = Cursors.Default
            pic_4_grp9x.Cursor = Cursors.Default
            pic_5_grp9x.Cursor = Cursors.Default
            pic_6_grp9x.Cursor = Cursors.Default
            pic_7_grp9x.Cursor = Cursors.Default
            pic_8_grp9x.Cursor = Cursors.Default
            pic_9_grp9x.Cursor = Cursors.Default
            pic_1_grpFullMouth.Cursor = Cursors.Default
            pic_2_grpFullMouth.Cursor = Cursors.Default
            pic_3_grpFullMouth.Cursor = Cursors.Default
            pic_4_grpFullMouth.Cursor = Cursors.Default
            pic_5_grpFullMouth.Cursor = Cursors.Default
            pic_6_grpFullMouth.Cursor = Cursors.Default
            pic_7_grpFullMouth.Cursor = Cursors.Default
            pic_8_grpFullMouth.Cursor = Cursors.Default
            pic_9_grpFullMouth.Cursor = Cursors.Default
            pic_10_grpFullMouth.Cursor = Cursors.Default
            pic_11_grpFullMouth.Cursor = Cursors.Default
            pic_12_grpFullMouth.Cursor = Cursors.Default
            pic_13_grpFullMouth.Cursor = Cursors.Default
            pic_14_grpFullMouth.Cursor = Cursors.Default
            pic_15_grpFullMouth.Cursor = Cursors.Default
            pic_16_grpFullMouth.Cursor = Cursors.Default
            pic_17_grpFullMouth.Cursor = Cursors.Default
            pic_18_grpFullMouth.Cursor = Cursors.Default
        Else
            Bright = 1
            If Pic = "2X1" Then
                pic_1_grp2X.Cursor = Cursors.NoMoveHoriz
                pic_2_grp2X.Cursor = Cursors.Default
            ElseIf Pic = "2X2" Then
                pic_2_grp2X.Cursor = Cursors.NoMoveHoriz
                pic_1_grp2X.Cursor = Cursors.Default
            ElseIf Pic = "4X1" Then
                Pic_1_grp4X.Cursor = Cursors.NoMoveHoriz
                Pic_2_grp4X.Cursor = Cursors.Default
                Pic_3_grp4X.Cursor = Cursors.Default
                Pic_4_grp4X.Cursor = Cursors.Default
            ElseIf Pic = "4X2" Then
                Pic_2_grp4X.Cursor = Cursors.NoMoveHoriz
                Pic_1_grp4X.Cursor = Cursors.Default
                Pic_3_grp4X.Cursor = Cursors.Default
                Pic_4_grp4X.Cursor = Cursors.Default
            ElseIf Pic = "4X3" Then
                Pic_3_grp4X.Cursor = Cursors.NoMoveHoriz
                Pic_2_grp4X.Cursor = Cursors.Default
                Pic_1_grp4X.Cursor = Cursors.Default
                Pic_4_grp4X.Cursor = Cursors.Default
            ElseIf Pic = "4X4" Then
                Pic_4_grp4X.Cursor = Cursors.NoMoveHoriz
                Pic_2_grp4X.Cursor = Cursors.Default
                Pic_3_grp4X.Cursor = Cursors.Default
                Pic_1_grp4X.Cursor = Cursors.Default
            ElseIf Pic = "9X1" Then
                pic_1_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X2" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X3" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X4" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X5" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X6" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X7" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X8" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.NoMoveHoriz
                pic_9_grp9x.Cursor = Cursors.Default
            ElseIf Pic = "9X9" Then
                pic_1_grp9x.Cursor = Cursors.Default
                pic_2_grp9x.Cursor = Cursors.Default
                pic_3_grp9x.Cursor = Cursors.Default
                pic_4_grp9x.Cursor = Cursors.Default
                pic_5_grp9x.Cursor = Cursors.Default
                pic_6_grp9x.Cursor = Cursors.Default
                pic_7_grp9x.Cursor = Cursors.Default
                pic_8_grp9x.Cursor = Cursors.Default
                pic_9_grp9x.Cursor = Cursors.NoMoveHoriz
            ElseIf Pic = "18X1" Then
                pic_1_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X2" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X3" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X4" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X5" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X6" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X7" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X8" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X9" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X10" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X11" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X12" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X13" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X14" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X15" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X16" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X17" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.NoMoveHoriz
                pic_18_grpFullMouth.Cursor = Cursors.Default
            ElseIf Pic = "18X18" Then
                pic_1_grpFullMouth.Cursor = Cursors.Default
                pic_2_grpFullMouth.Cursor = Cursors.Default
                pic_3_grpFullMouth.Cursor = Cursors.Default
                pic_4_grpFullMouth.Cursor = Cursors.Default
                pic_5_grpFullMouth.Cursor = Cursors.Default
                pic_6_grpFullMouth.Cursor = Cursors.Default
                pic_7_grpFullMouth.Cursor = Cursors.Default
                pic_8_grpFullMouth.Cursor = Cursors.Default
                pic_9_grpFullMouth.Cursor = Cursors.Default
                pic_10_grpFullMouth.Cursor = Cursors.Default
                pic_11_grpFullMouth.Cursor = Cursors.Default
                pic_12_grpFullMouth.Cursor = Cursors.Default
                pic_13_grpFullMouth.Cursor = Cursors.Default
                pic_14_grpFullMouth.Cursor = Cursors.Default
                pic_15_grpFullMouth.Cursor = Cursors.Default
                pic_16_grpFullMouth.Cursor = Cursors.Default
                pic_17_grpFullMouth.Cursor = Cursors.Default
                pic_18_grpFullMouth.Cursor = Cursors.NoMoveHoriz
            End If
        End If
    End Sub

    Private Sub DentistToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DentistToolStripMenuItem1.Click
        frm_Dentist.Show()
    End Sub

    Private Sub ToolStripButton24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton24.Click
        If PatientId <> "" Then
            Panel1.Visible = True
        Else
            MsgBox("Select any Patient!")
        End If
    End Sub

    Private Sub FullMouthSeriesViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullMouthSeriesViewToolStripMenuItem.Click
        If grpViewer.Visible = True Then
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
        Panel2.Width = 110
        GroupBox2.Width = 114
        Panel3.Left = 110
        Panel3.Width = Me.Width - Panel2.Width
        grp1X.Visible = False
        grp4X.Visible = False
        grp2X.Visible = False
        grp9X.Visible = False
        grp16X.Visible = False
        grpFullMouth.Visible = True
        GroupBox3.Visible = False
        grpViewer.Visible = False
        btnImport.Visible = False
        Call FillDetails()
    End Sub

    Private Sub NegativeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NegativeToolStripMenuItem.Click
        If path <> "" Then
            Dim IA As New Imaging.ImageAttributes
            Dim CM As New Imaging.ColorMatrix
            CM.Matrix00 = -1 : CM.Matrix11 = -1 : CM.Matrix22 = -1
            CM.Matrix40 = 1 : CM.Matrix41 = 1 : CM.Matrix42 = 1
            IA.SetColorMatrix(CM)
            Dim bmap As Bitmap
            If Pic = "1X1" Then
                bmap = Pic_1_grp1X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                Pic_1_grp1X.Image = bmap
            ElseIf Pic = "2X1" Then
                bmap = pic_1_grp2X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_1_grp2X.Image = bmap
            ElseIf Pic = "2X2" Then
                bmap = pic_2_grp2X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_2_grp2X.Image = bmap
            ElseIf Pic = "4X1" Then
                bmap = Pic_1_grp4X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                Pic_1_grp4X.Image = bmap
            ElseIf Pic = "4X2" Then
                bmap = Pic_2_grp4X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                Pic_2_grp4X.Image = bmap
            ElseIf Pic = "4X3" Then
                bmap = Pic_3_grp4X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                Pic_3_grp4X.Image = bmap
            ElseIf Pic = "4X4" Then
                bmap = Pic_4_grp4X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                Pic_4_grp4X.Image = bmap
            ElseIf Pic = "9X1" Then
                bmap = pic_1_grp9x.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_1_grp9x.Image = bmap
            ElseIf Pic = "9X2" Then
                bmap = pic_2_grp9x.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_2_grp9x.Image = bmap
            ElseIf Pic = "9X3" Then
                bmap = pic_3_grp9x.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_3_grp9x.Image = bmap
            ElseIf Pic = "9X4" Then
                bmap = pic_4_grp9x.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_4_grp9x.Image = bmap
            ElseIf Pic = "9X5" Then
                bmap = pic_5_grp9x.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_5_grp9x.Image = bmap
            ElseIf Pic = "9X6" Then
                bmap = pic_6_grp9x.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_6_grp9x.Image = bmap
            ElseIf Pic = "9X7" Then
                bmap = pic_7_grp9x.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_7_grp9x.Image = bmap
            ElseIf Pic = "9X8" Then
                bmap = pic_8_grp9x.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_8_grp9x.Image = bmap
            ElseIf Pic = "9X9" Then
                bmap = pic_9_grp9x.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_9_grp9x.Image = bmap
            ElseIf Pic = "16X1" Then
                bmap = pic_1_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_1_grp16X.Image = bmap
            ElseIf Pic = "16X2" Then
                bmap = pic_2_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_2_grp16X.Image = bmap
            ElseIf Pic = "16X3" Then
                bmap = pic_3_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_3_grp16X.Image = bmap
            ElseIf Pic = "16X4" Then
                bmap = pic_4_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_4_grp16X.Image = bmap
            ElseIf Pic = "16X5" Then
                bmap = pic_5_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_5_grp16X.Image = bmap
            ElseIf Pic = "16X6" Then
                bmap = pic_6_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_6_grp16X.Image = bmap
            ElseIf Pic = "16X7" Then
                bmap = pic_7_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_7_grp16X.Image = bmap
            ElseIf Pic = "16X8" Then
                bmap = pic_8_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_8_grp16X.Image = bmap
            ElseIf Pic = "16X9" Then
                bmap = pic_9_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_9_grp16X.Image = bmap
            ElseIf Pic = "16X10" Then
                bmap = pic_10_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_10_grp16X.Image = bmap
            ElseIf Pic = "16X11" Then
                bmap = pic_11_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_11_grp16X.Image = bmap
            ElseIf Pic = "16X12" Then
                bmap = pic_12_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_12_grp16X.Image = bmap
            ElseIf Pic = "16X13" Then
                bmap = pic_13_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_13_grp16X.Image = bmap
            ElseIf Pic = "16X14" Then
                bmap = pic_14_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_14_grp16X.Image = bmap
            ElseIf Pic = "16X15" Then
                bmap = pic_15_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_15_grp16X.Image = bmap
            ElseIf Pic = "16X16" Then
                bmap = pic_16_grp16X.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_16_grp16X.Image = bmap
            ElseIf Pic = "18X1" Then
                bmap = pic_1_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_1_grpFullMouth.Image = bmap
            ElseIf Pic = "18X2" Then
                bmap = pic_2_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_2_grpFullMouth.Image = bmap
            ElseIf Pic = "18X3" Then
                bmap = pic_3_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_3_grpFullMouth.Image = bmap
            ElseIf Pic = "18X4" Then
                bmap = pic_4_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_4_grpFullMouth.Image = bmap
            ElseIf Pic = "18X5" Then
                bmap = pic_5_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_5_grpFullMouth.Image = bmap
            ElseIf Pic = "18X6" Then
                bmap = pic_6_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_6_grpFullMouth.Image = bmap
            ElseIf Pic = "18X7" Then
                bmap = pic_7_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_7_grpFullMouth.Image = bmap
            ElseIf Pic = "18X8" Then
                bmap = pic_8_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_8_grpFullMouth.Image = bmap
            ElseIf Pic = "18X9" Then
                bmap = pic_9_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_9_grpFullMouth.Image = bmap
            ElseIf Pic = "18X10" Then
                bmap = pic_10_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_10_grpFullMouth.Image = bmap
            ElseIf Pic = "18X11" Then
                bmap = pic_11_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_11_grpFullMouth.Image = bmap
            ElseIf Pic = "18X12" Then
                bmap = pic_12_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_12_grpFullMouth.Image = bmap
            ElseIf Pic = "18X13" Then
                bmap = pic_13_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_13_grpFullMouth.Image = bmap
            ElseIf Pic = "18X14" Then
                bmap = pic_14_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_14_grpFullMouth.Image = bmap
            ElseIf Pic = "18X15" Then
                bmap = pic_15_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_15_grpFullMouth.Image = bmap
            ElseIf Pic = "18X16" Then
                bmap = pic_16_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_16_grpFullMouth.Image = bmap
            ElseIf Pic = "18X17" Then
                bmap = pic_17_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_17_grpFullMouth.Image = bmap
            ElseIf Pic = "18X18" Then
                bmap = pic_18_grpFullMouth.Image
                Dim R As New Rectangle(0, 0, bmap.Width, bmap.Height)
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(bmap, R, R.X, R.Y, R.Width, R.Height, GraphicsUnit.Pixel, IA)
                pic_18_grpFullMouth.Image = bmap
            End If
        End If
    End Sub

    Private Sub ToolStripButton16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton16.Click
        If path <> "" Then
            If Pic = "2X1" Then
                ''Negative
                Dim img As Bitmap = New Bitmap(pic_1_grp2X.Image)
                Dim c As Color
                Dim i As Integer = 0
                Do While (i < img.Width)
                    Dim j As Integer = 0
                    Do While (j < img.Height)
                        c = img.GetPixel(i, j)
                        Dim r As Integer = 0
                        r = Convert.ToInt16(c.R)
                        Dim g As Integer = 0
                        g = Convert.ToInt16(c.G)
                        Dim b As Integer = 0
                        b = Convert.ToInt16(c.B)
                        Dim newr As Integer = 0
                        newr = (255 - r)
                        Dim newg As Integer = 0
                        newg = (255 - g)
                        Dim newb As Integer = 0
                        newb = (255 - b)
                        c = Color.FromArgb(newr, newg, newb)
                        img.SetPixel(i, j, c)
                        j = (j + 1)
                    Loop
                    i = (i + 1)
                Loop
                pic_1_grp2X.Image = img
            End If
        End If
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        If PatientId <> "" Then
            grp4X.Visible = True
            grp2X.Visible = False
            grp9X.Visible = False
            grpFullMouth.Visible = False
            GroupBox3.Visible = False
        Else
            MsgBox("Select any Patient!")
        End If

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If PatientId <> "" Then

        Else
            MsgBox("Select any Patient!")
            Exit Sub
        End If
        If grpViewer.Visible = True Then
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
        Panel2.Width = 110
        GroupBox2.Width = 114
        Panel3.Left = 110
        Panel3.Width = Me.Width - Panel2.Width
        grp4X.Visible = False
        grp2X.Visible = False
        grp9X.Visible = False
        grp16X.Visible = False
        grpFullMouth.Visible = True
        GroupBox3.Visible = False
        grpViewer.Visible = False
        btnImport.Visible = False
        Call FillDetails()
    End Sub

    Private Sub X4GridToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles X4GridToolStripMenuItem.Click
        If grpViewer.Visible = True Then
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
        Panel2.Width = 110
        GroupBox2.Width = 114
        Panel3.Left = 110
        Panel3.Width = Me.Width - Panel2.Width
        grp1X.Visible = False
        grp4X.Visible = False
        grp2X.Visible = False
        grp9X.Visible = False
        grp16X.Visible = True
        grpFullMouth.Visible = False
        GroupBox3.Visible = False
        grpViewer.Visible = False
        btnImport.Visible = False
        Call FillDetails()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        If PatientId <> "" Then
            Panel2.Width = 110 + 100
            Panel3.Left = Panel2.Right
            GroupBox2.Width = Panel2.Width
            Panel3.Width = Me.Width - Panel2.Width

            grp4X.Visible = False
            grp2X.Visible = False
            grp9X.Visible = False
            grp16X.Visible = False
            grpFullMouth.Visible = False
            GroupBox3.Visible = False
            grpViewer.Visible = True
            btnImport.Visible = True
            Call LoadFiles()
        Else
            MsgBox("Select any Patient!")
        End If

    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim ObjClass As New ClassFunctions()
        Dim folder As String = ""
        Dim FullPath As String = ""
        folder = ObjClass.ReturnFieldName("select ptReg_code from Master_ptReg where ptReg_id='" & PatientId & "'")
        Dim path As String = Application.StartupPath & "\Images\Files\" & folder
        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If
        ' folder = folder & "_" & Format(Date.Now, "ddMMyyyyhhmmss")
        folder = OpenFileDialog1.SafeFileName
        ' PictureBox1.Image.Save(path & "\" & folder, System.Drawing.Imaging.ImageFormat.Jpeg)
        FullPath = path & "\" & folder
        My.Computer.FileSystem.CopyFile(OpenFileDialog1.FileName, FullPath)
        Call LoadFiles()
    End Sub

    Private Sub LoadFiles()

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
        Dim ObjClass As New ClassFunctions()
        Dim folder As String = ""
        folder = ObjClass.ReturnFieldName("select ptReg_code from Master_ptReg where ptReg_id='" & PatientId & "'")
        Dim path As String = Application.StartupPath & "\Images\Files\" & folder
        Dim FileDirectory As New IO.DirectoryInfo(path)
        If Directory.Exists(path) Then
            Dim FileJpg As IO.FileInfo() = FileDirectory.GetFiles("*.*")
            Dim ht As Integer = btnImport.Bottom
            For Each File As IO.FileInfo In FileJpg
                Dim lbl As New Label
                Dim lblNotes As New Label
                lbl.Text = File.Name
                lbl.Top = ht + 10
                lbl.Left = 10
                lbl.Width = 200
                lbl.ForeColor = White
                lbl.Height = 15
                Me.GroupBox2.Controls.Add(lbl)
                lblNotes.Text = File.CreationTime
                lblNotes.Top = ht + lbl.Height + 10
                lblNotes.Left = 10
                lblNotes.Width = 200
                lblNotes.ForeColor = White
                lblNotes.Height = 15
                Me.GroupBox2.Controls.Add(lblNotes)
                AddHandler lbl.Click, AddressOf lbl_Click
                If lbl.Top + 200 > Me.Height Then
                    Panel2.AutoScroll = True
                End If
                ht = lbl.Bottom + 10
            Next
        End If
    End Sub

    Private Sub lbl_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim ObjClass As New ClassFunctions()
        Dim folder As String = ""
        folder = ObjClass.ReturnFieldName("select ptReg_code from Master_ptReg where ptReg_id='" & PatientId & "'")
        Dim path As String = Application.StartupPath & "\Images\Files\" & folder
        path = path & "\" & sender.text()
        WebBrowser1.Navigate(path)
    End Sub

    Private Sub Panel1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_2X1.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If pic_1_grp2X.Width < 700 Then
                    Pnl_2X1.AutoScroll = False
                    Exit Sub 'minimum 500?
                End If
            Else
                If pic_1_grp2X.Width > 2000 Then Exit Sub 'maximum 2000?
            End If
            Pnl_2X1.AutoScroll = True
            pic_1_grp2X.Width += CInt(pic_1_grp2X.Width * e.Delta / 1000)
            pic_1_grp2X.Height += CInt(pic_1_grp2X.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub Pnl_2X2_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_2X2.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If pic_2_grp2X.Width < 700 Then
                    Pnl_2X2.AutoScroll = False
                    Exit Sub 'minimum 700?
                End If
            Else
                If pic_2_grp2X.Width > 1800 Then Exit Sub 'maximum 2000?
            End If
            Pnl_2X2.AutoScroll = True
            pic_2_grp2X.Width += CInt(pic_2_grp2X.Width * e.Delta / 1000)
            pic_2_grp2X.Height += CInt(pic_2_grp2X.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub Pnl_4X1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_4X1.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If Pic_1_grp4X.Width < 700 Then
                    Pnl_4X1.AutoScroll = False
                    Exit Sub 'minimum 500?
                End If

            Else
                If Pic_1_grp4X.Width > 2000 Then Exit Sub 'maximum 2000?
            End If
            Pnl_4X1.AutoScroll = True
            Pic_1_grp4X.Width += CInt(Pic_1_grp4X.Width * e.Delta / 1000)
            Pic_1_grp4X.Height += CInt(Pic_1_grp4X.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub Pnl_4X2_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_4X2.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If Pic_2_grp4X.Width < 700 Then
                    Pnl_4X2.AutoScroll = False
                    Exit Sub 'minimum 500?
                End If
            Else
                If Pic_2_grp4X.Width > 2000 Then Exit Sub 'maximum 2000?
            End If
            Pnl_4X2.AutoScroll = True
            Pic_2_grp4X.Width += CInt(Pic_2_grp4X.Width * e.Delta / 1000)
            Pic_2_grp4X.Height += CInt(Pic_2_grp4X.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub Pnl_4X3_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_4X3.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If Pic_3_grp4X.Width < 700 Then
                    Pnl_4X3.AutoScroll = False
                    Exit Sub 'minimum 500?
                End If

            Else
                If Pic_3_grp4X.Width > 2000 Then Exit Sub 'maximum 2000?
            End If
            Pnl_4X3.AutoScroll = True
            Pic_3_grp4X.Width += CInt(Pic_3_grp4X.Width * e.Delta / 1000)
            Pic_3_grp4X.Height += CInt(Pic_3_grp4X.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub Pnl_4X4_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_4X4.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If Pic_4_grp4X.Width < 700 Then
                    Pnl_4X4.AutoScroll = False
                    Exit Sub 'minimum 500?
                End If

            Else
                If Pic_4_grp4X.Width > 2000 Then Exit Sub 'maximum 2000?
            End If
            Pnl_4X4.AutoScroll = True
            Pic_4_grp4X.Width += CInt(Pic_4_grp4X.Width * e.Delta / 1000)
            Pic_4_grp4X.Height += CInt(Pic_4_grp4X.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        If PatientId <> "" Then

        Else
            MsgBox("Select any Patient!")
            Exit Sub
        End If
        If grpViewer.Visible = True Then
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
        Panel2.Width = 110
        GroupBox2.Width = 114
        Panel3.Left = 110
        Panel3.Width = Me.Width - Panel2.Width
        grp4X.Visible = False
        grp2X.Visible = False
        grp9X.Visible = True
        grp16X.Visible = False
        grpFullMouth.Visible = False
        GroupBox3.Visible = False
        grpViewer.Visible = False
        btnImport.Visible = False
        Call FillDetails()
    End Sub

    Private Sub StatusViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusViewToolStripMenuItem.Click
        If grpViewer.Visible = True Then
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
        Panel2.Width = 110
        GroupBox2.Width = 114
        Panel3.Left = 110
        Panel3.Width = Me.Width - Panel2.Width
        grp1X.Visible = False
        grp4X.Visible = False
        grp2X.Visible = False
        grp9X.Visible = True
        grp16X.Visible = False
        grpFullMouth.Visible = False
        GroupBox3.Visible = False
        grpViewer.Visible = False
        btnImport.Visible = False
        Call FillDetails()
    End Sub

    Private Sub pic_2_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_2_grp16X.DoubleClick
        If pic_2_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_2_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_2_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_2_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_2_grp16X.ImageLocation = path
        pic_2_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X1" Then
                pic_1_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                pic_3_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                pic_4_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                pic_5_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                pic_6_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                pic_7_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                pic_8_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                pic_9_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                pic_10_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                pic_11_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                pic_12_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                pic_13_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                pic_14_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                pic_15_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                pic_16_grp16X.Image = Nothing
            ElseIf Pic = "16X2" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
        End If
    End Sub

    Private Sub pic_2_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_2_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pic_2_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_2_grp16X.MouseDown
        If Not pic_2_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X2"
            path = pic_2_grp16X.ImageLocation
            FName = pic_2_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X2" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.NoMoveVert
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "16X2" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.NoMoveHoriz
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_2_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_2_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_2_grp16X.Image Is Nothing Then
            pic_2_grp16X.DoDragDrop(pic_2_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X2" Then
                    pic_2_grp16X.Image = Fun_Contrast(pic_2_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X2" Then
                    pic_2_grp16X.Image = Fun_Contrast(pic_2_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X2" Then
                    pic_2_grp16X.Image = Fun_Brightness(pic_2_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X2" Then
                    pic_2_grp16X.Image = Fun_Brightness(pic_2_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_2_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_2_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_2"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X2"
        End If
    End Sub

    Private Sub pic_1_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_1_grp16X.DoubleClick
        If pic_1_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_1_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_1_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_1_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_1_grp16X.ImageLocation = path
        pic_1_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X2" Then
                pic_2_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                pic_3_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                pic_4_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                pic_5_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                pic_6_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                pic_7_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                pic_8_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                pic_9_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                pic_10_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                pic_11_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                pic_12_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                pic_13_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                pic_14_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                pic_15_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                pic_16_grp16X.Image = Nothing
            ElseIf Pic = "16X1" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
            Pic = "16X1"
        End If
    End Sub

    Private Sub pic_1_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_1_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pic_3_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_3_grp16X.DoubleClick
        If pic_3_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub


    Private Sub pic_3_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_3_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_3_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_3_grp16X.ImageLocation = path
        pic_3_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X2" Then
                pic_2_grp16X.Image = Nothing
            ElseIf Pic = "16X1" Then
                pic_1_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                pic_4_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                pic_5_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                pic_6_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                pic_7_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                pic_8_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                pic_9_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                pic_10_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                pic_11_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                pic_12_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                pic_13_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                pic_14_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                pic_15_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                pic_16_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
        End If
    End Sub

    Private Sub pic_3_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_3_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pic_4_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_4_grp16X.DoubleClick
        If pic_4_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_4_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_4_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_4_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_4_grp16X.ImageLocation = path
        pic_4_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X2" Then
                pic_2_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                pic_3_grp16X.Image = Nothing
            ElseIf Pic = "16X1" Then
                pic_1_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                pic_5_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                pic_6_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                pic_7_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                pic_8_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                pic_9_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                pic_10_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                pic_11_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                pic_12_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                pic_13_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                pic_14_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                pic_15_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                pic_16_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
        End If
    End Sub

    Private Sub pic_4_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_4_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub pic_1_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_1_grp16X.MouseDown
        If Not pic_1_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X1"
            path = pic_1_grp16X.ImageLocation
            FName = pic_1_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X1" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.NoMoveVert
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "16X1" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.NoMoveHoriz
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_1_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_1_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_1_grp16X.Image Is Nothing Then
            pic_1_grp16X.DoDragDrop(pic_1_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X1" Then
                    pic_1_grp16X.Image = Fun_Contrast(pic_1_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X1" Then
                    pic_1_grp16X.Image = Fun_Contrast(pic_1_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X1" Then
                    pic_1_grp16X.Image = Fun_Brightness(pic_1_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X1" Then
                    pic_1_grp16X.Image = Fun_Brightness(pic_1_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_1_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_1_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_1"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X1"
        End If
    End Sub


    Private Sub pic_3_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_3_grp16X.MouseDown
        If Not pic_3_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X3"
            path = pic_3_grp16X.ImageLocation
            FName = pic_3_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X3" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.NoMoveVert
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "16X3" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.NoMoveHoriz
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_3_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_3_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_3_grp16X.Image Is Nothing Then
            pic_3_grp16X.DoDragDrop(pic_3_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X3" Then
                    pic_3_grp16X.Image = Fun_Contrast(pic_3_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X3" Then
                    pic_3_grp16X.Image = Fun_Contrast(pic_3_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X3" Then
                    pic_3_grp16X.Image = Fun_Brightness(pic_3_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X3" Then
                    pic_3_grp16X.Image = Fun_Brightness(pic_3_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_3_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_3_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_3"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X3"
        End If
    End Sub


    Private Sub pic_4_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_4_grp16X.MouseDown
        If Not pic_4_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X4"
            path = pic_4_grp16X.ImageLocation
            FName = pic_4_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X4" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.NoMoveVert
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "16X4" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.NoMoveHoriz
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_4_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_4_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_4_grp16X.Image Is Nothing Then
            pic_4_grp16X.DoDragDrop(pic_4_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X4" Then
                    pic_4_grp16X.Image = Fun_Contrast(pic_4_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X1" Then
                    pic_4_grp16X.Image = Fun_Contrast(pic_4_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X4" Then
                    pic_4_grp16X.Image = Fun_Brightness(pic_4_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X4" Then
                    pic_4_grp16X.Image = Fun_Brightness(pic_4_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_4_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_4_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_4"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X4"
        End If
    End Sub

    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        p.X = e.X
        p.Y = e.Y
    End Sub

    Private Sub Panel1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.MouseHover
        Panel1.Cursor = Cursors.SizeAll
    End Sub

    Private Sub Panel1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.MouseLeave
        Panel1.Cursor = Cursors.Default
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        Panel1.Location = New Point(e.X - p.X + Panel1.Location.X, e.Y - p.Y + Panel1.Location.Y)
    End Sub

    Private Sub btnCloseMeasurement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseMeasurement.Click
        Panel1.Visible = False
    End Sub


    ' Return true if the point is over the picture's current location.
    Private Function PointIsOverPicture(ByVal x As Integer, ByVal y As Integer) As Boolean
        ' See if it's over the picture's bounding rectangle.
        If (x < SmileyLocation.Left) OrElse (x >= SmileyLocation.Right) OrElse (y < SmileyLocation.Top) OrElse (y >= SmileyLocation.Bottom) Then
            Return False
        End If

        ' See if the point is above a non-transparent pixel.
        Dim i As Integer = x - SmileyLocation.X
        Dim j As Integer = y - SmileyLocation.Y
        Return (Smiley.GetPixel(i, j).A > 0)
    End Function

    Private Sub DeleteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem1.Click
        If currentImage = "1X1" Then
            If Pic_1_grp1X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & Pic_1_grp1X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(Pic_1_grp1X.ImageLocation)
            Pic_1_grp1X.Image = Nothing
        ElseIf currentImage = "2X1" Then
            If pic_1_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_1_grp2X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_1_grp2X.ImageLocation)
            pic_1_grp2X.Image = Nothing
        ElseIf currentImage = "2X2" Then
            If pic_2_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_2_grp2X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_2_grp2X.ImageLocation)
            pic_2_grp2X.Image = Nothing
        ElseIf currentImage = "4X1" Then
            If Pic_1_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & Pic_1_grp4X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(Pic_1_grp4X.ImageLocation)
            Pic_1_grp4X.Image = Nothing
        ElseIf currentImage = "4X2" Then
            If Pic_2_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & Pic_2_grp4X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(Pic_2_grp4X.ImageLocation)
            Pic_2_grp4X.Image = Nothing
        ElseIf currentImage = "4X3" Then
            If Pic_3_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & Pic_3_grp4X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(Pic_3_grp4X.ImageLocation)
            Pic_3_grp4X.Image = Nothing
        ElseIf currentImage = "4X4" Then
            If Pic_4_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & Pic_4_grp4X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(Pic_4_grp4X.ImageLocation)
            Pic_4_grp4X.Image = Nothing
        ElseIf currentImage = "9X1" Then
            If pic_1_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_1_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_1_grp9x.ImageLocation)
            pic_1_grp9x.Image = Nothing
        ElseIf currentImage = "9X2" Then
            If pic_2_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_2_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_2_grp9x.ImageLocation)
            pic_2_grp9x.Image = Nothing
        ElseIf currentImage = "9X3" Then
            If pic_3_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_3_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_3_grp9x.ImageLocation)
            pic_3_grp9x.Image = Nothing
        ElseIf currentImage = "9X4" Then
            If pic_4_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_4_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_4_grp9x.ImageLocation)
            pic_4_grp9x.Image = Nothing
        ElseIf currentImage = "9X5" Then
            If pic_5_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_5_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_5_grp9x.ImageLocation)
            pic_5_grp9x.Image = Nothing
        ElseIf currentImage = "9X6" Then
            If pic_6_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_6_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_6_grp9x.ImageLocation)
            pic_6_grp9x.Image = Nothing
        ElseIf currentImage = "9X7" Then
            If pic_7_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_7_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_3_grp9x.ImageLocation)
            pic_7_grp9x.Image = Nothing
        ElseIf currentImage = "9X8" Then
            If pic_8_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_8_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_8_grp9x.ImageLocation)
            pic_8_grp9x.Image = Nothing
        ElseIf currentImage = "9X9" Then
            If pic_9_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_9_grp9x.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_9_grp9x.ImageLocation)
            pic_9_grp9x.Image = Nothing
        ElseIf currentImage = "18X1" Then
            If pic_1_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_1_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_1_grpFullMouth.ImageLocation)
            pic_1_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X2" Then
            If pic_2_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_2_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_2_grpFullMouth.ImageLocation)
            pic_2_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X3" Then
            If pic_3_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_3_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_3_grpFullMouth.ImageLocation)
            pic_3_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X4" Then
            If pic_4_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_4_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_4_grpFullMouth.ImageLocation)
            pic_4_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X5" Then
            If pic_5_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_5_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_5_grpFullMouth.ImageLocation)
            pic_5_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X6" Then
            If pic_6_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_6_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_6_grpFullMouth.ImageLocation)
            pic_6_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X7" Then
            If pic_7_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_7_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_7_grpFullMouth.ImageLocation)
            pic_7_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X8" Then
            If pic_8_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_8_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_8_grpFullMouth.ImageLocation)
            pic_8_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X9" Then
            If pic_9_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_9_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_9_grpFullMouth.ImageLocation)
            pic_9_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X10" Then
            If pic_10_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_10_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_10_grpFullMouth.ImageLocation)
            pic_10_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X11" Then
            If pic_11_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_11_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_11_grpFullMouth.ImageLocation)
            pic_11_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X12" Then
            If pic_12_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_12_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_12_grpFullMouth.ImageLocation)
            pic_12_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X13" Then
            If pic_13_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_13_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_13_grpFullMouth.ImageLocation)
            pic_13_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X14" Then
            If pic_14_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_14_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_14_grpFullMouth.ImageLocation)
            pic_14_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X15" Then
            If pic_15_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_15_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_15_grpFullMouth.ImageLocation)
            pic_15_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X16" Then
            If pic_16_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_16_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_16_grpFullMouth.ImageLocation)
            pic_16_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X17" Then
            If pic_17_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_17_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_17_grpFullMouth.ImageLocation)
            pic_17_grpFullMouth.Image = Nothing
        ElseIf currentImage = "18X18" Then
            If pic_18_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_18_grpFullMouth.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_18_grpFullMouth.ImageLocation)
            pic_18_grpFullMouth.Image = Nothing
        ElseIf currentImage = "16X1" Then
            If pic_1_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_1_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_1_grp16X.ImageLocation)
            pic_1_grp16X.Image = Nothing
        ElseIf currentImage = "16X2" Then
            If pic_2_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_2_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_2_grp16X.ImageLocation)
            pic_2_grp16X.Image = Nothing
        ElseIf currentImage = "16X3" Then
            If pic_3_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_3_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_3_grp16X.ImageLocation)
            pic_3_grp16X.Image = Nothing
        ElseIf currentImage = "16X4" Then
            If pic_4_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_4_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_4_grp16X.ImageLocation)
            pic_4_grp16X.Image = Nothing
        ElseIf currentImage = "16X5" Then
            If pic_5_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_5_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_5_grp16X.ImageLocation)
            pic_5_grp16X.Image = Nothing
        ElseIf currentImage = "16X6" Then
            If pic_6_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_6_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_6_grp16X.ImageLocation)
            pic_6_grp16X.Image = Nothing
        ElseIf currentImage = "16X7" Then
            If pic_7_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_7_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_7_grp16X.ImageLocation)
            pic_7_grp16X.Image = Nothing
        ElseIf currentImage = "16X8" Then
            If pic_8_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_8_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_8_grp16X.ImageLocation)
            pic_8_grp16X.Image = Nothing
        ElseIf currentImage = "16X9" Then
            If pic_9_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_9_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_9_grp16X.ImageLocation)
            pic_9_grp16X.Image = Nothing
        ElseIf currentImage = "16X10" Then
            If pic_10_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_10_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_10_grp16X.ImageLocation)
            pic_10_grp16X.Image = Nothing
        ElseIf currentImage = "16X11" Then
            If pic_11_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_11_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_11_grp16X.ImageLocation)
            pic_11_grp16X.Image = Nothing
        ElseIf currentImage = "16X12" Then
            If pic_12_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_12_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_12_grp16X.ImageLocation)
            pic_12_grp16X.Image = Nothing
        ElseIf currentImage = "16X13" Then
            If pic_13_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_13_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_13_grp16X.ImageLocation)
            pic_13_grp16X.Image = Nothing
        ElseIf currentImage = "16X14" Then
            If pic_14_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_14_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_14_grp16X.ImageLocation)
            pic_14_grp16X.Image = Nothing
        ElseIf currentImage = "16X15" Then
            If pic_15_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_15_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_15_grp16X.ImageLocation)
            pic_15_grp16X.Image = Nothing
        ElseIf currentImage = "16X16" Then
            If pic_16_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            ObjClass.ExecuteQuery("update patient_image set Image_isdeleted='1' where image_path='" & pic_16_grp16X.ImageLocation & "' and image_ptregid='" & PatientId & "'")
            System.IO.File.Delete(pic_16_grp16X.ImageLocation)
            pic_16_grp16X.Image = Nothing
        End If
        Call FillDetails()
    End Sub

    Private Sub pic_10_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_10_grp16X.DoubleClick
        If pic_10_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_10_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_10_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_10_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_10_grp16X.ImageLocation = path
        pic_10_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X2" Then
                pic_2_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                pic_3_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                pic_4_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                pic_5_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                pic_6_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                pic_7_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                pic_8_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                pic_9_grp16X.Image = Nothing
            ElseIf Pic = "16X1" Then
                pic_1_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                pic_11_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                pic_12_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                pic_13_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                pic_14_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                pic_15_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                pic_16_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
            Pic = "16X10"
        End If
    End Sub

    Private Sub pic_10_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_10_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pic_10_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_10_grp16X.MouseDown
        If Not pic_10_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X10"
            path = pic_10_grp16X.ImageLocation
            FName = pic_10_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X10" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.NoMoveVert
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "16X10" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.NoMoveHoriz
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_10_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_10_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_10_grp16X.Image Is Nothing Then
            pic_10_grp16X.DoDragDrop(pic_10_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X10" Then
                    pic_10_grp16X.Image = Fun_Contrast(pic_10_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X10" Then
                    pic_10_grp16X.Image = Fun_Contrast(pic_10_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X10" Then
                    pic_10_grp16X.Image = Fun_Brightness(pic_10_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X10" Then
                    pic_10_grp16X.Image = Fun_Brightness(pic_10_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_10_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_10_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_10"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X10"
        End If
    End Sub

    Private Sub pic_11_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_11_grp16X.DoubleClick
        If pic_11_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_11_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_11_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_11_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_11_grp16X.ImageLocation = path
        pic_11_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X2" Then
                pic_2_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                pic_3_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                pic_4_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                pic_5_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                pic_6_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                pic_7_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                pic_8_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                pic_9_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                pic_10_grp16X.Image = Nothing
            ElseIf Pic = "16X1" Then
                pic_1_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                pic_12_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                pic_13_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                pic_14_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                pic_15_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                pic_16_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
            Pic = "16X11"
        End If
    End Sub

    Private Sub pic_11_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_11_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pic_11_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_11_grp16X.MouseDown
        If Not pic_11_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X11"
            path = pic_11_grp16X.ImageLocation
            FName = pic_11_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X11" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.NoMoveVert
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "16X11" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.NoMoveHoriz
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_11_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_11_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_11_grp16X.Image Is Nothing Then
            pic_11_grp16X.DoDragDrop(pic_11_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X11" Then
                    pic_11_grp16X.Image = Fun_Contrast(pic_11_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X11" Then
                    pic_11_grp16X.Image = Fun_Contrast(pic_11_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X11" Then
                    pic_11_grp16X.Image = Fun_Brightness(pic_11_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X11" Then
                    pic_11_grp16X.Image = Fun_Brightness(pic_11_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_11_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_11_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_11"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X11"
        End If
    End Sub

    Private Sub pic_12_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_12_grp16X.DoubleClick
        If pic_12_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_12_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_12_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_12_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_12_grp16X.ImageLocation = path
        pic_12_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X2" Then
                pic_2_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                pic_3_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                pic_4_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                pic_5_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                pic_6_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                pic_7_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                pic_8_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                pic_9_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                pic_10_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                pic_11_grp16X.Image = Nothing
            ElseIf Pic = "16X1" Then
                pic_1_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                pic_13_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                pic_14_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                pic_15_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                pic_16_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
        End If
    End Sub

    Private Sub pic_12_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_12_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pic_12_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_12_grp16X.MouseDown
        If Not pic_12_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X12"
            path = pic_12_grp16X.ImageLocation
            FName = pic_12_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X12" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.NoMoveVert
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "16X12" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.NoMoveHoriz
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_12_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_12_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_12_grp16X.Image Is Nothing Then
            pic_12_grp16X.DoDragDrop(pic_12_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X12" Then
                    pic_12_grp16X.Image = Fun_Contrast(pic_12_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X12" Then
                    pic_12_grp16X.Image = Fun_Contrast(pic_12_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X12" Then
                    pic_12_grp16X.Image = Fun_Brightness(pic_12_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X12" Then
                    pic_12_grp16X.Image = Fun_Brightness(pic_12_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_12_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_12_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_12"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X12"
        End If
    End Sub

    Private Sub pic_13_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_13_grp16X.DoubleClick
        If pic_13_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_13_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_13_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_13_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_13_grp16X.ImageLocation = path
        pic_13_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X2" Then
                pic_2_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                pic_3_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                pic_4_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                pic_5_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                pic_6_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                pic_7_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                pic_8_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                pic_9_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                pic_10_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                pic_11_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                pic_12_grp16X.Image = Nothing
            ElseIf Pic = "16X1" Then
                pic_1_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                pic_14_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                pic_15_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                pic_16_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
        End If
    End Sub

    Private Sub pic_13_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_13_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pic_13_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_13_grp16X.MouseDown
        If Not pic_13_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X13"
            path = pic_13_grp16X.ImageLocation
            FName = pic_13_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X13" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.NoMoveVert
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "16X13" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.NoMoveHoriz
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_13_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_13_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_13_grp16X.Image Is Nothing Then
            pic_13_grp16X.DoDragDrop(pic_13_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X13" Then
                    pic_13_grp16X.Image = Fun_Contrast(pic_13_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X13" Then
                    pic_13_grp16X.Image = Fun_Contrast(pic_13_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X13" Then
                    pic_13_grp16X.Image = Fun_Brightness(pic_13_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X13" Then
                    pic_13_grp16X.Image = Fun_Brightness(pic_13_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_13_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_13_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_13"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X130"
        End If
    End Sub

    Private Sub pic_14_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_14_grp16X.DoubleClick
        If pic_14_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_14_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_14_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_14_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_14_grp16X.ImageLocation = path
        pic_14_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X2" Then
                pic_2_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                pic_3_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                pic_4_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                pic_5_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                pic_6_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                pic_7_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                pic_8_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                pic_9_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                pic_10_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                pic_11_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                pic_12_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                pic_13_grp16X.Image = Nothing
            ElseIf Pic = "16X1" Then
                pic_1_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                pic_15_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                pic_16_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
        End If
    End Sub

    Private Sub pic_14_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_14_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pic_14_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_14_grp16X.MouseDown
        If Not pic_14_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X14"
            path = pic_14_grp16X.ImageLocation
            FName = pic_14_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X14" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.NoMoveVert
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "16X14" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.NoMoveHoriz
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_14_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_14_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_14_grp16X.Image Is Nothing Then
            pic_14_grp16X.DoDragDrop(pic_14_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X14" Then
                    pic_14_grp16X.Image = Fun_Contrast(pic_14_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X14" Then
                    pic_14_grp16X.Image = Fun_Contrast(pic_14_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X14" Then
                    pic_14_grp16X.Image = Fun_Brightness(pic_14_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X14" Then
                    pic_14_grp16X.Image = Fun_Brightness(pic_14_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_14_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_14_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_14"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X14"
        End If
    End Sub

    Private Sub pic_15_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_15_grp16X.DoubleClick
        If pic_15_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_15_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_15_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_15_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_15_grp16X.ImageLocation = path
        pic_15_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X2" Then
                pic_2_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                pic_3_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                pic_4_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                pic_5_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                pic_6_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                pic_7_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                pic_8_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                pic_9_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                pic_10_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                pic_11_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                pic_12_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                pic_13_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                pic_14_grp16X.Image = Nothing
            ElseIf Pic = "16X1" Then
                pic_1_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                pic_16_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
        End If
    End Sub

    Private Sub pic_15_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_15_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pic_15_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_15_grp16X.MouseDown
        If Not pic_15_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X15"
            path = pic_15_grp16X.ImageLocation
            FName = pic_15_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X15" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.NoMoveVert
                pic_16_grp16X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "16X15" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.NoMoveHoriz
                pic_16_grp16X.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_15_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_15_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_15_grp16X.Image Is Nothing Then
            pic_15_grp16X.DoDragDrop(pic_15_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X15" Then
                    pic_15_grp16X.Image = Fun_Contrast(pic_15_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X15" Then
                    pic_15_grp16X.Image = Fun_Contrast(pic_15_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X15" Then
                    pic_15_grp16X.Image = Fun_Brightness(pic_15_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X15" Then
                    pic_15_grp16X.Image = Fun_Brightness(pic_15_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_15_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_15_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_15"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X15"
        End If
    End Sub

    Private Sub pic_16_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_16_grp16X.DoubleClick
        If pic_16_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_16_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_16_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_16_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_16_grp16X.ImageLocation = path
        pic_16_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X2" Then
                pic_2_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                pic_3_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                pic_4_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                pic_5_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                pic_6_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                pic_7_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                pic_8_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                pic_9_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                pic_10_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                pic_11_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                pic_12_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                pic_13_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                pic_14_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                pic_15_grp16X.Image = Nothing
            ElseIf Pic = "16X1" Then
                pic_1_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
        End If
    End Sub

    Private Sub pic_16_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_16_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pic_16_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_16_grp16X.MouseDown
        If Not pic_16_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X16"
            path = pic_16_grp16X.ImageLocation
            FName = pic_16_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X16" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.NoMoveVert
                mouseX = e.Y
            ElseIf Pic = "16X16" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.NoMoveHoriz
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_16_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_16_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_16_grp16X.Image Is Nothing Then
            pic_16_grp16X.DoDragDrop(pic_16_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X16" Then
                    pic_16_grp16X.Image = Fun_Contrast(pic_16_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X16" Then
                    pic_16_grp16X.Image = Fun_Contrast(pic_16_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X16" Then
                    pic_16_grp16X.Image = Fun_Brightness(pic_16_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X16" Then
                    pic_16_grp16X.Image = Fun_Brightness(pic_16_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_16_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_16_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_16"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X16"
        End If
    End Sub

    Private Sub pic_5_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_5_grp16X.DoubleClick
        If pic_5_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_5_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_5_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_5_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_5_grp16X.ImageLocation = path
        pic_5_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X2" Then
                pic_2_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                pic_3_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                pic_4_grp16X.Image = Nothing
            ElseIf Pic = "16X1" Then
                pic_1_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                pic_6_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                pic_7_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                pic_8_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                pic_9_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                pic_10_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                pic_11_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                pic_12_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                pic_13_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                pic_14_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                pic_15_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                pic_16_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
        End If
    End Sub

    Private Sub pic_5_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_5_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pic_5_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_5_grp16X.MouseDown
        If Not pic_5_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X5"
            path = pic_5_grp16X.ImageLocation
            FName = pic_5_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X5" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.NoMoveVert
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "16X5" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.NoMoveHoriz
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_5_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_5_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_5_grp16X.Image Is Nothing Then
            pic_5_grp16X.DoDragDrop(pic_5_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X5" Then
                    pic_5_grp16X.Image = Fun_Contrast(pic_5_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X5" Then
                    pic_5_grp16X.Image = Fun_Contrast(pic_5_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X5" Then
                    pic_5_grp16X.Image = Fun_Brightness(pic_5_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X5" Then
                    pic_5_grp16X.Image = Fun_Brightness(pic_5_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_5_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_5_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_5"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X5"
        End If
    End Sub

    Private Sub pic_6_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_6_grp16X.DoubleClick
        If pic_6_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_6_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_6_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_6_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_6_grp16X.ImageLocation = path
        pic_6_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X2" Then
                pic_2_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                pic_3_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                pic_4_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                pic_5_grp16X.Image = Nothing
            ElseIf Pic = "16X1" Then
                pic_1_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                pic_7_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                pic_8_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                pic_9_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                pic_10_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                pic_11_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                pic_12_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                pic_13_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                pic_14_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                pic_15_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                pic_16_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
        End If
    End Sub

    Private Sub pic_6_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_6_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pic_6_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_6_grp16X.MouseDown
        If Not pic_6_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X6"
            path = pic_6_grp16X.ImageLocation
            FName = pic_6_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X6" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.NoMoveVert
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "16X6" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.NoMoveHoriz
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_6_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_6_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_6_grp16X.Image Is Nothing Then
            pic_6_grp16X.DoDragDrop(pic_6_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X6" Then
                    pic_6_grp16X.Image = Fun_Contrast(pic_6_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X6" Then
                    pic_6_grp16X.Image = Fun_Contrast(pic_6_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X6" Then
                    pic_6_grp16X.Image = Fun_Brightness(pic_6_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X6" Then
                    pic_6_grp16X.Image = Fun_Brightness(pic_6_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_6_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_6_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_6"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X6"
        End If
    End Sub

    Private Sub pic_7_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_7_grp16X.DoubleClick
        If pic_7_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_7_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_7_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_7_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_7_grp16X.ImageLocation = path
        pic_7_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X2" Then
                pic_2_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                pic_3_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                pic_4_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                pic_5_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                pic_6_grp16X.Image = Nothing
            ElseIf Pic = "16X1" Then
                pic_1_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                pic_8_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                pic_9_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                pic_10_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                pic_11_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                pic_12_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                pic_13_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                pic_14_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                pic_15_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                pic_16_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
        End If
    End Sub

    Private Sub pic_7_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_7_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pic_7_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_7_grp16X.MouseDown
        If Not pic_7_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X7"
            path = pic_7_grp16X.ImageLocation
            FName = pic_7_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X7" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.NoMoveVert
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "16X7" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.NoMoveHoriz
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_7_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_7_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_7_grp16X.Image Is Nothing Then
            pic_7_grp16X.DoDragDrop(pic_7_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X7" Then
                    pic_7_grp16X.Image = Fun_Contrast(pic_7_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X7" Then
                    pic_7_grp16X.Image = Fun_Contrast(pic_7_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X7" Then
                    pic_7_grp16X.Image = Fun_Brightness(pic_7_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X7" Then
                    pic_7_grp16X.Image = Fun_Brightness(pic_7_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_7_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_7_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_7"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X7"
        End If
    End Sub

    Private Sub pic_8_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_8_grp16X.DoubleClick
        If pic_8_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_8_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_8_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_8_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_8_grp16X.ImageLocation = path
        pic_8_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X2" Then
                pic_2_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                pic_3_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                pic_4_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                pic_5_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                pic_6_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                pic_7_grp16X.Image = Nothing
            ElseIf Pic = "16X1" Then
                pic_1_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                pic_9_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                pic_10_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                pic_11_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                pic_12_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                pic_13_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                pic_14_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                pic_15_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                pic_16_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
        End If
    End Sub

    Private Sub pic_8_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_8_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pic_8_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_8_grp16X.MouseDown
        If Not pic_8_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X8"
            path = pic_8_grp16X.ImageLocation
            FName = pic_8_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X8" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.NoMoveVert
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "16X8" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.NoMoveHoriz
                pic_9_grp16X.Cursor = Cursors.Default
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_8_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_8_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_8_grp16X.Image Is Nothing Then
            pic_8_grp16X.DoDragDrop(pic_8_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X8" Then
                    pic_8_grp16X.Image = Fun_Contrast(pic_8_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X8" Then
                    pic_8_grp16X.Image = Fun_Contrast(pic_8_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X8" Then
                    pic_8_grp16X.Image = Fun_Brightness(pic_8_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X8" Then
                    pic_8_grp16X.Image = Fun_Brightness(pic_8_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_8_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_8_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_8"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X8"
        End If
    End Sub

    Private Sub pic_9_grp16X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_9_grp16X.DoubleClick
        If pic_9_grp16X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub pic_9_grp16X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_9_grp16X.DragDrop
        If Pic = "" And (pic_1_grp16X.ImageLocation = path Or pic_2_grp16X.ImageLocation = path Or pic_3_grp16X.ImageLocation = path Or pic_4_grp16X.ImageLocation = path Or pic_5_grp16X.ImageLocation = path Or pic_6_grp16X.ImageLocation = path Or pic_7_grp16X.ImageLocation = path Or pic_8_grp16X.ImageLocation = path Or pic_9_grp16X.ImageLocation = path Or pic_10_grp16X.ImageLocation = path Or pic_11_grp16X.ImageLocation = path Or pic_12_grp16X.ImageLocation = path Or pic_13_grp16X.ImageLocation = path Or pic_14_grp16X.ImageLocation = path Or pic_15_grp16X.ImageLocation = path Or pic_16_grp16X.ImageLocation = path) Then
            Exit Sub
        End If
        pic_9_grp16X.Image = e.Data.GetData(DataFormats.Bitmap)
        pic_9_grp16X.ImageLocation = path
        pic_9_grp16X.Tag = FName
        If Not e.KeyState = 8 Then
            If Pic = "16X2" Then
                pic_2_grp16X.Image = Nothing
            ElseIf Pic = "16X3" Then
                pic_3_grp16X.Image = Nothing
            ElseIf Pic = "16X4" Then
                pic_4_grp16X.Image = Nothing
            ElseIf Pic = "16X5" Then
                pic_5_grp16X.Image = Nothing
            ElseIf Pic = "16X6" Then
                pic_6_grp16X.Image = Nothing
            ElseIf Pic = "16X7" Then
                pic_7_grp16X.Image = Nothing
            ElseIf Pic = "16X8" Then
                pic_8_grp16X.Image = Nothing
            ElseIf Pic = "16X1" Then
                pic_1_grp16X.Image = Nothing
            ElseIf Pic = "16X10" Then
                pic_10_grp16X.Image = Nothing
            ElseIf Pic = "16X11" Then
                pic_11_grp16X.Image = Nothing
            ElseIf Pic = "16X12" Then
                pic_12_grp16X.Image = Nothing
            ElseIf Pic = "16X13" Then
                pic_13_grp16X.Image = Nothing
            ElseIf Pic = "16X14" Then
                pic_14_grp16X.Image = Nothing
            ElseIf Pic = "16X15" Then
                pic_15_grp16X.Image = Nothing
            ElseIf Pic = "16X16" Then
                pic_16_grp16X.Image = Nothing
            ElseIf Pic = "16X9" Then
                If path <> "" Then
                    m_MouseIsDown = False
                End If
            End If
        End If
    End Sub

    Private Sub pic_9_grp16X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pic_9_grp16X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pic_9_grp16X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_9_grp16X.MouseDown
        If Not pic_9_grp16X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "16X9"
            path = pic_9_grp16X.ImageLocation
            FName = pic_9_grp16X.Tag
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
            If Pic = "16X9" And Contrast = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.NoMoveVert
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseX = e.Y
            ElseIf Pic = "16X9" And Bright = 1 Then
                pic_1_grp16X.Cursor = Cursors.Default
                pic_2_grp16X.Cursor = Cursors.Default
                pic_3_grp16X.Cursor = Cursors.Default
                pic_4_grp16X.Cursor = Cursors.Default
                pic_5_grp16X.Cursor = Cursors.Default
                pic_6_grp16X.Cursor = Cursors.Default
                pic_7_grp16X.Cursor = Cursors.Default
                pic_8_grp16X.Cursor = Cursors.Default
                pic_9_grp16X.Cursor = Cursors.NoMoveHoriz
                pic_10_grp16X.Cursor = Cursors.Default
                pic_11_grp16X.Cursor = Cursors.Default
                pic_12_grp16X.Cursor = Cursors.Default
                pic_13_grp16X.Cursor = Cursors.Default
                pic_14_grp16X.Cursor = Cursors.Default
                pic_15_grp16X.Cursor = Cursors.Default
                pic_16_grp16X.Cursor = Cursors.Default
                mouseY = e.X
            End If
        End If
    End Sub

    Private Sub pic_9_grp16X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_9_grp16X.MouseMove
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not pic_9_grp16X.Image Is Nothing Then
            pic_9_grp16X.DoDragDrop(pic_9_grp16X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "16X9" Then
                    pic_9_grp16X.Image = Fun_Contrast(pic_9_grp16X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "16X9" Then
                    pic_9_grp16X.Image = Fun_Contrast(pic_9_grp16X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "16X9" Then
                    pic_9_grp16X.Image = Fun_Brightness(pic_9_grp16X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "16X9" Then
                    pic_9_grp16X.Image = Fun_Brightness(pic_9_grp16X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub pic_9_grp16X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_9_grp16X.MouseUp
        Dragging = False
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P16_9"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "16X9"
        End If
    End Sub

    Private Sub BitewingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BitewingToolStripMenuItem.Click
        grp4X.Visible = True
        grp2X.Visible = False
        grp9X.Visible = False
        grpFullMouth.Visible = False
        GroupBox3.Visible = False
    End Sub

    Private Sub Rotate90ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rotate90ToolStripMenuItem.Click
        If currentImage = "1X1" Then
            If Pic_1_grp1X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp1X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Pic_1_grp1X.Width = Pic_1_grp1X.Width
            Pic_1_grp1X.Height = Pic_1_grp1X.Height
        ElseIf currentImage = "2X1" Then
            If pic_1_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp2X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_1_grp2X.Width = pic_1_grp2X.Width
            pic_1_grp2X.Height = pic_1_grp2X.Height
        ElseIf currentImage = "2X2" Then
            If pic_2_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp2X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_2_grp2X.Width = pic_2_grp2X.Width
            pic_2_grp2X.Height = pic_2_grp2X.Height
        ElseIf currentImage = "4X1" Then
            If Pic_1_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp4X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Pic_1_grp4X.Width = Pic_1_grp4X.Width
            Pic_1_grp4X.Height = Pic_1_grp4X.Height
        ElseIf currentImage = "4X2" Then
            If Pic_2_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_2_grp4X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Pic_2_grp4X.Width = Pic_2_grp4X.Width
            Pic_2_grp4X.Height = Pic_2_grp4X.Height
        ElseIf currentImage = "4X3" Then
            If Pic_3_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_3_grp4X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Pic_3_grp4X.Width = Pic_3_grp4X.Width
            Pic_3_grp4X.Height = Pic_3_grp4X.Height
        ElseIf currentImage = "4X4" Then
            If Pic_4_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_4_grp4X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Pic_4_grp4X.Width = Pic_4_grp4X.Width
            Pic_4_grp4X.Height = Pic_4_grp4X.Height
        ElseIf currentImage = "9X1" Then
            If pic_1_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_1_grp9x.Width = pic_1_grp9x.Width
            pic_1_grp9x.Height = pic_1_grp9x.Height
        ElseIf currentImage = "9X2" Then
            If pic_2_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_2_grp9x.Width = pic_2_grp9x.Width
            pic_2_grp9x.Height = pic_2_grp9x.Height
        ElseIf currentImage = "9X3" Then
            If pic_3_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_3_grp9x.Width = pic_3_grp9x.Width
            pic_3_grp9x.Height = pic_3_grp9x.Height
        ElseIf currentImage = "9X4" Then
            If pic_4_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_4_grp9x.Width = pic_4_grp9x.Width
            pic_4_grp9x.Height = pic_4_grp9x.Height
        ElseIf currentImage = "9X5" Then
            If pic_5_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_5_grp9x.Width = pic_5_grp9x.Width
            pic_5_grp9x.Height = pic_5_grp9x.Height
        ElseIf currentImage = "9X6" Then
            If pic_6_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_6_grp9x.Width = pic_6_grp9x.Width
            pic_6_grp9x.Height = pic_6_grp9x.Height
        ElseIf currentImage = "9X7" Then
            If pic_7_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_7_grp9x.Width = pic_7_grp9x.Width
            pic_7_grp9x.Height = pic_7_grp9x.Height
        ElseIf currentImage = "9X8" Then
            If pic_8_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_8_grp9x.Width = pic_8_grp9x.Width
            pic_8_grp9x.Height = pic_8_grp9x.Height
        ElseIf currentImage = "9X9" Then
            If pic_9_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp9x.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_9_grp9x.Width = pic_9_grp9x.Width
            pic_9_grp9x.Height = pic_9_grp9x.Height
        ElseIf currentImage = "16X1" Then
            If pic_1_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_1_grp16X.Width = pic_1_grp16X.Width
            pic_1_grp16X.Height = pic_1_grp16X.Height
        ElseIf currentImage = "16X2" Then
            If pic_2_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_2_grp16X.Width = pic_2_grp16X.Width
            pic_2_grp16X.Height = pic_2_grp16X.Height
        ElseIf currentImage = "16X3" Then
            If pic_3_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_3_grp16X.Width = pic_3_grp16X.Width
            pic_3_grp16X.Height = pic_3_grp16X.Height
        ElseIf currentImage = "16X4" Then
            If pic_4_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_4_grp16X.Width = pic_4_grp16X.Width
            pic_4_grp16X.Height = pic_4_grp16X.Height
        ElseIf currentImage = "16X5" Then
            If pic_5_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_5_grp16X.Width = pic_5_grp16X.Width
            pic_5_grp16X.Height = pic_5_grp16X.Height
        ElseIf currentImage = "16X6" Then
            If pic_6_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_6_grp16X.Width = pic_6_grp16X.Width
            pic_6_grp16X.Height = pic_6_grp16X.Height
        ElseIf currentImage = "16X7" Then
            If pic_7_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_7_grp16X.Width = pic_7_grp16X.Width
            pic_7_grp16X.Height = pic_7_grp16X.Height
        ElseIf currentImage = "16X8" Then
            If pic_8_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_8_grp16X.Width = pic_8_grp16X.Width
            pic_8_grp16X.Height = pic_8_grp16X.Height
        ElseIf currentImage = "16X9" Then
            If pic_9_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_9_grp16X.Width = pic_9_grp16X.Width
            pic_9_grp16X.Height = pic_9_grp16X.Height
        ElseIf currentImage = "16X10" Then
            If pic_10_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_10_grp16X.Width = pic_10_grp16X.Width
            pic_10_grp16X.Height = pic_10_grp16X.Height
        ElseIf currentImage = "16X11" Then
            If pic_11_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_11_grp16X.Width = pic_11_grp16X.Width
            pic_11_grp16X.Height = pic_11_grp16X.Height
        ElseIf currentImage = "16X12" Then
            If pic_12_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_12_grp16X.Width = pic_12_grp16X.Width
            pic_12_grp16X.Height = pic_12_grp16X.Height
        ElseIf currentImage = "16X13" Then
            If pic_13_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_13_grp16X.Width = pic_13_grp16X.Width
            pic_13_grp16X.Height = pic_13_grp16X.Height
        ElseIf currentImage = "16X14" Then
            If pic_14_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_14_grp16X.Width = pic_14_grp16X.Width
            pic_14_grp16X.Height = pic_14_grp16X.Height
        ElseIf currentImage = "16X15" Then
            If pic_15_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_15_grp16X.Width = pic_15_grp16X.Width
            pic_15_grp16X.Height = pic_15_grp16X.Height
        ElseIf currentImage = "16X16" Then
            If pic_16_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grp16X.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_16_grp16X.Width = pic_16_grp16X.Width
            pic_16_grp16X.Height = pic_16_grp16X.Height
        ElseIf currentImage = "18X1" Then
            If pic_1_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_1_grpFullMouth.Width = pic_1_grpFullMouth.Width
            pic_1_grpFullMouth.Height = pic_1_grpFullMouth.Height
        ElseIf currentImage = "18X2" Then
            If pic_2_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_2_grpFullMouth.Width = pic_2_grpFullMouth.Width
            pic_2_grpFullMouth.Height = pic_2_grpFullMouth.Height
        ElseIf currentImage = "18X3" Then
            If pic_3_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_3_grpFullMouth.Width = pic_3_grpFullMouth.Width
            pic_3_grpFullMouth.Height = pic_3_grpFullMouth.Height
        ElseIf currentImage = "18X4" Then
            If pic_4_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_4_grpFullMouth.Width = pic_4_grpFullMouth.Width
            pic_4_grpFullMouth.Height = pic_4_grpFullMouth.Height
        ElseIf currentImage = "18X5" Then
            If pic_5_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_5_grpFullMouth.Width = pic_5_grpFullMouth.Width
            pic_5_grpFullMouth.Height = pic_5_grpFullMouth.Height
        ElseIf currentImage = "18X6" Then
            If pic_6_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_6_grpFullMouth.Width = pic_6_grpFullMouth.Width
            pic_6_grpFullMouth.Height = pic_6_grpFullMouth.Height
        ElseIf currentImage = "18X7" Then
            If pic_7_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_7_grpFullMouth.Width = pic_7_grpFullMouth.Width
            pic_7_grpFullMouth.Height = pic_7_grpFullMouth.Height
        ElseIf currentImage = "18X8" Then
            If pic_8_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_8_grpFullMouth.Width = pic_8_grpFullMouth.Width
            pic_8_grpFullMouth.Height = pic_8_grpFullMouth.Height
        ElseIf currentImage = "18X9" Then
            If pic_9_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_9_grpFullMouth.Width = pic_9_grpFullMouth.Width
            pic_9_grpFullMouth.Height = pic_9_grpFullMouth.Height
        ElseIf currentImage = "18X10" Then
            If pic_10_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_10_grpFullMouth.Width = pic_10_grpFullMouth.Width
            pic_10_grpFullMouth.Height = pic_10_grpFullMouth.Height
        ElseIf currentImage = "18X11" Then
            If pic_11_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_11_grpFullMouth.Width = pic_11_grpFullMouth.Width
            pic_11_grpFullMouth.Height = pic_11_grpFullMouth.Height
        ElseIf currentImage = "18X12" Then
            If pic_12_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_12_grpFullMouth.Width = pic_12_grpFullMouth.Width
            pic_12_grpFullMouth.Height = pic_12_grpFullMouth.Height
        ElseIf currentImage = "18X13" Then
            If pic_13_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_13_grpFullMouth.Width = pic_13_grpFullMouth.Width
            pic_13_grpFullMouth.Height = pic_13_grpFullMouth.Height
        ElseIf currentImage = "18X14" Then
            If pic_14_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_14_grpFullMouth.Width = pic_14_grpFullMouth.Width
            pic_14_grpFullMouth.Height = pic_14_grpFullMouth.Height
        ElseIf currentImage = "18X15" Then
            If pic_15_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_15_grpFullMouth.Width = pic_15_grpFullMouth.Width
            pic_15_grpFullMouth.Height = pic_15_grpFullMouth.Height
        ElseIf currentImage = "18X16" Then
            If pic_16_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_16_grpFullMouth.Width = pic_16_grpFullMouth.Width
            pic_16_grpFullMouth.Height = pic_16_grpFullMouth.Height
        ElseIf currentImage = "18X17" Then
            If pic_17_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_17_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_17_grpFullMouth.Width = pic_17_grpFullMouth.Width
            pic_17_grpFullMouth.Height = pic_17_grpFullMouth.Height
        ElseIf currentImage = "18X18" Then
            If pic_18_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_18_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pic_18_grpFullMouth.Width = pic_18_grpFullMouth.Width
            pic_18_grpFullMouth.Height = pic_18_grpFullMouth.Height
        End If

        Call RefreshImages()
        Call FillDetails()
    End Sub

    Private Sub Rotate180ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rotate180ToolStripMenuItem.Click
        If currentImage = "1X1" Then
            If Pic_1_grp1X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp1X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Pic_1_grp1X.Width = Pic_1_grp1X.Width
            Pic_1_grp1X.Height = Pic_1_grp1X.Height
        ElseIf currentImage = "2X1" Then
            If pic_1_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp2X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_1_grp2X.Width = pic_1_grp2X.Width
            pic_1_grp2X.Height = pic_1_grp2X.Height
        ElseIf currentImage = "2X2" Then
            If pic_2_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp2X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_2_grp2X.Width = pic_2_grp2X.Width
            pic_2_grp2X.Height = pic_2_grp2X.Height
        ElseIf currentImage = "4X1" Then
            If Pic_1_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp4X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Pic_1_grp4X.Width = Pic_1_grp4X.Width
            Pic_1_grp4X.Height = Pic_1_grp4X.Height
        ElseIf currentImage = "4X2" Then
            If Pic_2_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_2_grp4X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Pic_2_grp4X.Width = Pic_2_grp4X.Width
            Pic_2_grp4X.Height = Pic_2_grp4X.Height
        ElseIf currentImage = "4X3" Then
            If Pic_3_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_3_grp4X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Pic_3_grp4X.Width = Pic_3_grp4X.Width
            Pic_3_grp4X.Height = Pic_3_grp4X.Height
        ElseIf currentImage = "4X4" Then
            If Pic_4_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_4_grp4X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Pic_4_grp4X.Width = Pic_4_grp4X.Width
            Pic_4_grp4X.Height = Pic_4_grp4X.Height
        ElseIf currentImage = "9X1" Then
            If pic_1_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_1_grp9x.Width = pic_1_grp9x.Width
            pic_1_grp9x.Height = pic_1_grp9x.Height
        ElseIf currentImage = "9X2" Then
            If pic_2_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_2_grp9x.Width = pic_2_grp9x.Width
            pic_2_grp9x.Height = pic_2_grp9x.Height
        ElseIf currentImage = "9X3" Then
            If pic_3_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_3_grp9x.Width = pic_3_grp9x.Width
            pic_3_grp9x.Height = pic_3_grp9x.Height
        ElseIf currentImage = "9X4" Then
            If pic_4_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_4_grp9x.Width = pic_4_grp9x.Width
            pic_4_grp9x.Height = pic_4_grp9x.Height
        ElseIf currentImage = "9X5" Then
            If pic_5_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_5_grp9x.Width = pic_5_grp9x.Width
            pic_5_grp9x.Height = pic_5_grp9x.Height
        ElseIf currentImage = "9X6" Then
            If pic_6_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_6_grp9x.Width = pic_6_grp9x.Width
            pic_6_grp9x.Height = pic_6_grp9x.Height
        ElseIf currentImage = "9X7" Then
            If pic_7_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_7_grp9x.Width = pic_7_grp9x.Width
            pic_7_grp9x.Height = pic_7_grp9x.Height
        ElseIf currentImage = "9X8" Then
            If pic_8_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_8_grp9x.Width = pic_8_grp9x.Width
            pic_8_grp9x.Height = pic_8_grp9x.Height
        ElseIf currentImage = "9X9" Then
            If pic_9_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp9x.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_9_grp9x.Width = pic_9_grp9x.Width
            pic_9_grp9x.Height = pic_9_grp9x.Height
        ElseIf currentImage = "16X1" Then
            If pic_1_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_1_grp16X.Width = pic_1_grp16X.Width
            pic_1_grp16X.Height = pic_1_grp16X.Height
        ElseIf currentImage = "16X2" Then
            If pic_2_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_2_grp16X.Width = pic_2_grp16X.Width
            pic_2_grp16X.Height = pic_2_grp16X.Height
        ElseIf currentImage = "16X3" Then
            If pic_3_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_3_grp16X.Width = pic_3_grp16X.Width
            pic_3_grp16X.Height = pic_3_grp16X.Height
        ElseIf currentImage = "16X4" Then
            If pic_4_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_4_grp16X.Width = pic_4_grp16X.Width
            pic_4_grp16X.Height = pic_4_grp16X.Height
        ElseIf currentImage = "16X5" Then
            If pic_5_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_5_grp16X.Width = pic_5_grp16X.Width
            pic_5_grp16X.Height = pic_5_grp16X.Height
        ElseIf currentImage = "16X6" Then
            If pic_6_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_6_grp16X.Width = pic_6_grp16X.Width
            pic_6_grp16X.Height = pic_6_grp16X.Height
        ElseIf currentImage = "16X7" Then
            If pic_7_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_7_grp16X.Width = pic_7_grp16X.Width
            pic_7_grp16X.Height = pic_7_grp16X.Height
        ElseIf currentImage = "16X8" Then
            If pic_8_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_8_grp16X.Width = pic_8_grp16X.Width
            pic_8_grp16X.Height = pic_8_grp16X.Height
        ElseIf currentImage = "16X9" Then
            If pic_9_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_9_grp16X.Width = pic_9_grp16X.Width
            pic_9_grp16X.Height = pic_9_grp16X.Height
        ElseIf currentImage = "16X10" Then
            If pic_10_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_10_grp16X.Width = pic_10_grp16X.Width
            pic_10_grp16X.Height = pic_10_grp16X.Height
        ElseIf currentImage = "16X11" Then
            If pic_11_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_11_grp16X.Width = pic_11_grp16X.Width
            pic_11_grp16X.Height = pic_11_grp16X.Height
        ElseIf currentImage = "16X12" Then
            If pic_12_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_12_grp16X.Width = pic_12_grp16X.Width
            pic_12_grp16X.Height = pic_12_grp16X.Height
        ElseIf currentImage = "16X13" Then
            If pic_13_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_13_grp16X.Width = pic_13_grp16X.Width
            pic_13_grp16X.Height = pic_13_grp16X.Height
        ElseIf currentImage = "16X14" Then
            If pic_14_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_14_grp16X.Width = pic_14_grp16X.Width
            pic_14_grp16X.Height = pic_14_grp16X.Height
        ElseIf currentImage = "16X15" Then
            If pic_15_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_15_grp16X.Width = pic_15_grp16X.Width
            pic_15_grp16X.Height = pic_15_grp16X.Height
        ElseIf currentImage = "16X16" Then
            If pic_16_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grp16X.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_16_grp16X.Width = pic_16_grp16X.Width
            pic_16_grp16X.Height = pic_16_grp16X.Height
        ElseIf currentImage = "18X1" Then
            If pic_1_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_1_grpFullMouth.Width = pic_1_grpFullMouth.Width
            pic_1_grpFullMouth.Height = pic_1_grpFullMouth.Height
        ElseIf currentImage = "18X2" Then
            If pic_2_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_2_grpFullMouth.Width = pic_2_grpFullMouth.Width
            pic_2_grpFullMouth.Height = pic_2_grpFullMouth.Height
        ElseIf currentImage = "18X3" Then
            If pic_3_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_3_grpFullMouth.Width = pic_3_grpFullMouth.Width
            pic_3_grpFullMouth.Height = pic_3_grpFullMouth.Height
        ElseIf currentImage = "18X4" Then
            If pic_4_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_4_grpFullMouth.Width = pic_4_grpFullMouth.Width
            pic_4_grpFullMouth.Height = pic_4_grpFullMouth.Height
        ElseIf currentImage = "18X5" Then
            If pic_5_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_5_grpFullMouth.Width = pic_5_grpFullMouth.Width
            pic_5_grpFullMouth.Height = pic_5_grpFullMouth.Height
        ElseIf currentImage = "18X6" Then
            If pic_6_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_6_grpFullMouth.Width = pic_6_grpFullMouth.Width
            pic_6_grpFullMouth.Height = pic_6_grpFullMouth.Height
        ElseIf currentImage = "18X7" Then
            If pic_7_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_7_grpFullMouth.Width = pic_7_grpFullMouth.Width
            pic_7_grpFullMouth.Height = pic_7_grpFullMouth.Height
        ElseIf currentImage = "18X8" Then
            If pic_8_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_8_grpFullMouth.Width = pic_8_grpFullMouth.Width
            pic_8_grpFullMouth.Height = pic_8_grpFullMouth.Height
        ElseIf currentImage = "18X9" Then
            If pic_9_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_9_grpFullMouth.Width = pic_9_grpFullMouth.Width
            pic_9_grpFullMouth.Height = pic_9_grpFullMouth.Height
        ElseIf currentImage = "18X10" Then
            If pic_10_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_10_grpFullMouth.Width = pic_10_grpFullMouth.Width
            pic_10_grpFullMouth.Height = pic_10_grpFullMouth.Height
        ElseIf currentImage = "18X11" Then
            If pic_11_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_11_grpFullMouth.Width = pic_11_grpFullMouth.Width
            pic_11_grpFullMouth.Height = pic_11_grpFullMouth.Height
        ElseIf currentImage = "18X12" Then
            If pic_12_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_12_grpFullMouth.Width = pic_12_grpFullMouth.Width
            pic_12_grpFullMouth.Height = pic_12_grpFullMouth.Height
        ElseIf currentImage = "18X13" Then
            If pic_13_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_13_grpFullMouth.Width = pic_13_grpFullMouth.Width
            pic_13_grpFullMouth.Height = pic_13_grpFullMouth.Height
        ElseIf currentImage = "18X14" Then
            If pic_14_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_14_grpFullMouth.Width = pic_14_grpFullMouth.Width
            pic_14_grpFullMouth.Height = pic_14_grpFullMouth.Height
        ElseIf currentImage = "18X15" Then
            If pic_15_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_15_grpFullMouth.Width = pic_15_grpFullMouth.Width
            pic_15_grpFullMouth.Height = pic_15_grpFullMouth.Height
        ElseIf currentImage = "18X16" Then
            If pic_16_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_16_grpFullMouth.Width = pic_16_grpFullMouth.Width
            pic_16_grpFullMouth.Height = pic_16_grpFullMouth.Height
        ElseIf currentImage = "18X17" Then
            If pic_17_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_17_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_17_grpFullMouth.Width = pic_17_grpFullMouth.Width
            pic_17_grpFullMouth.Height = pic_17_grpFullMouth.Height
        ElseIf currentImage = "18X18" Then
            If pic_18_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_18_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            pic_18_grpFullMouth.Width = pic_18_grpFullMouth.Width
            pic_18_grpFullMouth.Height = pic_18_grpFullMouth.Height
        End If
        Call RefreshImages()
        Call FillDetails()
    End Sub

    Private Sub Rotate270ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rotate270ToolStripMenuItem.Click
        If currentImage = "1X1" Then
            If Pic_1_grp1X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp1X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Pic_1_grp1X.Width = Pic_1_grp1X.Width
            Pic_1_grp1X.Height = Pic_1_grp1X.Height
        ElseIf currentImage = "2X1" Then
            If pic_1_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp2X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_1_grp2X.Width = pic_1_grp2X.Width
            pic_1_grp2X.Height = pic_1_grp2X.Height
        ElseIf currentImage = "2X2" Then
            If pic_2_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp2X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_2_grp2X.Width = pic_2_grp2X.Width
            pic_2_grp2X.Height = pic_2_grp2X.Height
        ElseIf currentImage = "4X1" Then
            If Pic_1_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp4X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Pic_1_grp4X.Width = Pic_1_grp4X.Width
            Pic_1_grp4X.Height = Pic_1_grp4X.Height
        ElseIf currentImage = "4X2" Then
            If Pic_2_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_2_grp4X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Pic_2_grp4X.Width = Pic_2_grp4X.Width
            Pic_2_grp4X.Height = Pic_2_grp4X.Height
        ElseIf currentImage = "4X3" Then
            If Pic_3_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_3_grp4X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Pic_3_grp4X.Width = Pic_3_grp4X.Width
            Pic_3_grp4X.Height = Pic_3_grp4X.Height
        ElseIf currentImage = "4X4" Then
            If Pic_4_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_4_grp4X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Pic_4_grp4X.Width = Pic_4_grp4X.Width
            Pic_4_grp4X.Height = Pic_4_grp4X.Height
        ElseIf currentImage = "9X1" Then
            If pic_1_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_1_grp9x.Width = pic_1_grp9x.Width
            pic_1_grp9x.Height = pic_1_grp9x.Height
        ElseIf currentImage = "9X2" Then
            If pic_2_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_2_grp9x.Width = pic_2_grp9x.Width
            pic_2_grp9x.Height = pic_2_grp9x.Height
        ElseIf currentImage = "9X3" Then
            If pic_3_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_3_grp9x.Width = pic_3_grp9x.Width
            pic_3_grp9x.Height = pic_3_grp9x.Height
        ElseIf currentImage = "9X4" Then
            If pic_4_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_4_grp9x.Width = pic_4_grp9x.Width
            pic_4_grp9x.Height = pic_4_grp9x.Height
        ElseIf currentImage = "9X5" Then
            If pic_5_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_5_grp9x.Width = pic_5_grp9x.Width
            pic_5_grp9x.Height = pic_5_grp9x.Height
        ElseIf currentImage = "9X6" Then
            If pic_6_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_6_grp9x.Width = pic_6_grp9x.Width
            pic_6_grp9x.Height = pic_6_grp9x.Height
        ElseIf currentImage = "9X7" Then
            If pic_7_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_7_grp9x.Width = pic_7_grp9x.Width
            pic_7_grp9x.Height = pic_7_grp9x.Height
        ElseIf currentImage = "9X8" Then
            If pic_8_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_8_grp9x.Width = pic_8_grp9x.Width
            pic_8_grp9x.Height = pic_8_grp9x.Height
        ElseIf currentImage = "9X9" Then
            If pic_9_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp9x.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_9_grp9x.Width = pic_9_grp9x.Width
            pic_9_grp9x.Height = pic_9_grp9x.Height
        ElseIf currentImage = "16X1" Then
            If pic_1_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_1_grp16X.Width = pic_1_grp16X.Width
            pic_1_grp16X.Height = pic_1_grp16X.Height
        ElseIf currentImage = "16X2" Then
            If pic_2_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_2_grp16X.Width = pic_2_grp16X.Width
            pic_2_grp16X.Height = pic_2_grp16X.Height
        ElseIf currentImage = "16X3" Then
            If pic_3_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_3_grp16X.Width = pic_3_grp16X.Width
            pic_3_grp16X.Height = pic_3_grp16X.Height
        ElseIf currentImage = "16X4" Then
            If pic_4_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_4_grp16X.Width = pic_4_grp16X.Width
            pic_4_grp16X.Height = pic_4_grp16X.Height
        ElseIf currentImage = "16X5" Then
            If pic_5_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_5_grp16X.Width = pic_5_grp16X.Width
            pic_5_grp16X.Height = pic_5_grp16X.Height
        ElseIf currentImage = "16X6" Then
            If pic_6_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_6_grp16X.Width = pic_6_grp16X.Width
            pic_6_grp16X.Height = pic_6_grp16X.Height
        ElseIf currentImage = "16X7" Then
            If pic_7_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_7_grp16X.Width = pic_7_grp16X.Width
            pic_7_grp16X.Height = pic_7_grp16X.Height
        ElseIf currentImage = "16X8" Then
            If pic_8_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_8_grp16X.Width = pic_8_grp16X.Width
            pic_8_grp16X.Height = pic_8_grp16X.Height
        ElseIf currentImage = "16X9" Then
            If pic_9_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_9_grp16X.Width = pic_9_grp16X.Width
            pic_9_grp16X.Height = pic_9_grp16X.Height
        ElseIf currentImage = "16X10" Then
            If pic_10_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_10_grp16X.Width = pic_10_grp16X.Width
            pic_10_grp16X.Height = pic_10_grp16X.Height
        ElseIf currentImage = "16X11" Then
            If pic_11_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_11_grp16X.Width = pic_11_grp16X.Width
            pic_11_grp16X.Height = pic_11_grp16X.Height
        ElseIf currentImage = "16X12" Then
            If pic_12_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_12_grp16X.Width = pic_12_grp16X.Width
            pic_12_grp16X.Height = pic_12_grp16X.Height
        ElseIf currentImage = "16X13" Then
            If pic_13_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_13_grp16X.Width = pic_13_grp16X.Width
            pic_13_grp16X.Height = pic_13_grp16X.Height
        ElseIf currentImage = "16X14" Then
            If pic_14_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_14_grp16X.Width = pic_14_grp16X.Width
            pic_14_grp16X.Height = pic_14_grp16X.Height
        ElseIf currentImage = "16X15" Then
            If pic_15_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_15_grp16X.Width = pic_15_grp16X.Width
            pic_15_grp16X.Height = pic_15_grp16X.Height
        ElseIf currentImage = "16X16" Then
            If pic_16_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grp16X.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_16_grp16X.Width = pic_16_grp16X.Width
            pic_16_grp16X.Height = pic_16_grp16X.Height
        ElseIf currentImage = "18X1" Then
            If pic_1_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_1_grpFullMouth.Width = pic_1_grpFullMouth.Width
            pic_1_grpFullMouth.Height = pic_1_grpFullMouth.Height
        ElseIf currentImage = "18X2" Then
            If pic_2_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_2_grpFullMouth.Width = pic_2_grpFullMouth.Width
            pic_2_grpFullMouth.Height = pic_2_grpFullMouth.Height
        ElseIf currentImage = "18X3" Then
            If pic_3_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_3_grpFullMouth.Width = pic_3_grpFullMouth.Width
            pic_3_grpFullMouth.Height = pic_3_grpFullMouth.Height
        ElseIf currentImage = "18X4" Then
            If pic_4_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_4_grpFullMouth.Width = pic_4_grpFullMouth.Width
            pic_4_grpFullMouth.Height = pic_4_grpFullMouth.Height
        ElseIf currentImage = "18X5" Then
            If pic_5_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_5_grpFullMouth.Width = pic_5_grpFullMouth.Width
            pic_5_grpFullMouth.Height = pic_5_grpFullMouth.Height
        ElseIf currentImage = "18X6" Then
            If pic_6_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_6_grpFullMouth.Width = pic_6_grpFullMouth.Width
            pic_6_grpFullMouth.Height = pic_6_grpFullMouth.Height
        ElseIf currentImage = "18X7" Then
            If pic_7_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_7_grpFullMouth.Width = pic_7_grpFullMouth.Width
            pic_7_grpFullMouth.Height = pic_7_grpFullMouth.Height
        ElseIf currentImage = "18X8" Then
            If pic_8_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_8_grpFullMouth.Width = pic_8_grpFullMouth.Width
            pic_8_grpFullMouth.Height = pic_8_grpFullMouth.Height
        ElseIf currentImage = "18X9" Then
            If pic_9_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_9_grpFullMouth.Width = pic_9_grpFullMouth.Width
            pic_9_grpFullMouth.Height = pic_9_grpFullMouth.Height
        ElseIf currentImage = "18X10" Then
            If pic_10_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_10_grpFullMouth.Width = pic_10_grpFullMouth.Width
            pic_10_grpFullMouth.Height = pic_10_grpFullMouth.Height
        ElseIf currentImage = "18X11" Then
            If pic_11_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_11_grpFullMouth.Width = pic_11_grpFullMouth.Width
            pic_11_grpFullMouth.Height = pic_11_grpFullMouth.Height
        ElseIf currentImage = "18X12" Then
            If pic_12_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_12_grpFullMouth.Width = pic_12_grpFullMouth.Width
            pic_12_grpFullMouth.Height = pic_12_grpFullMouth.Height
        ElseIf currentImage = "18X13" Then
            If pic_13_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_13_grpFullMouth.Width = pic_13_grpFullMouth.Width
            pic_13_grpFullMouth.Height = pic_13_grpFullMouth.Height
        ElseIf currentImage = "18X14" Then
            If pic_14_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_14_grpFullMouth.Width = pic_14_grpFullMouth.Width
            pic_14_grpFullMouth.Height = pic_14_grpFullMouth.Height
        ElseIf currentImage = "18X15" Then
            If pic_15_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_15_grpFullMouth.Width = pic_15_grpFullMouth.Width
            pic_15_grpFullMouth.Height = pic_15_grpFullMouth.Height
        ElseIf currentImage = "18X16" Then
            If pic_16_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_16_grpFullMouth.Width = pic_16_grpFullMouth.Width
            pic_16_grpFullMouth.Height = pic_16_grpFullMouth.Height
        ElseIf currentImage = "18X17" Then
            If pic_17_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_17_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_17_grpFullMouth.Width = pic_17_grpFullMouth.Width
            pic_17_grpFullMouth.Height = pic_17_grpFullMouth.Height
        ElseIf currentImage = "18X18" Then
            If pic_18_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_18_grpFullMouth.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            pic_18_grpFullMouth.Width = pic_18_grpFullMouth.Width
            pic_18_grpFullMouth.Height = pic_18_grpFullMouth.Height
        End If
        Call RefreshImages()
        Call FillDetails()
    End Sub

    Private Sub MirrorXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MirrorXToolStripMenuItem.Click
        If currentImage = "1X1" Then
            If Pic_1_grp1X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp1X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            Pic_1_grp1X.Width = Pic_1_grp1X.Width
            Pic_1_grp1X.Height = Pic_1_grp1X.Height
        ElseIf currentImage = "2X1" Then
            If pic_1_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp2X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_1_grp2X.Width = pic_1_grp2X.Width
            pic_1_grp2X.Height = pic_1_grp2X.Height
        ElseIf currentImage = "2X2" Then
            If pic_2_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp2X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_2_grp2X.Width = pic_2_grp2X.Width
            pic_2_grp2X.Height = pic_2_grp2X.Height
        ElseIf currentImage = "4X1" Then
            If Pic_1_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            Pic_1_grp4X.Width = Pic_1_grp4X.Width
            Pic_1_grp4X.Height = Pic_1_grp4X.Height
        ElseIf currentImage = "4X2" Then
            If Pic_2_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_2_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            Pic_2_grp4X.Width = Pic_2_grp4X.Width
            Pic_2_grp4X.Height = Pic_2_grp4X.Height
        ElseIf currentImage = "4X3" Then
            If Pic_3_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_3_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            Pic_3_grp4X.Width = Pic_3_grp4X.Width
            Pic_3_grp4X.Height = Pic_3_grp4X.Height
        ElseIf currentImage = "4X4" Then
            If Pic_4_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_4_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            Pic_4_grp4X.Width = Pic_4_grp4X.Width
            Pic_4_grp4X.Height = Pic_4_grp4X.Height
        ElseIf currentImage = "9X1" Then
            If pic_1_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_1_grp9x.Width = pic_1_grp9x.Width
            pic_1_grp9x.Height = pic_1_grp9x.Height
        ElseIf currentImage = "9X2" Then
            If pic_2_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_2_grp9x.Width = pic_2_grp9x.Width
            pic_2_grp9x.Height = pic_2_grp9x.Height
        ElseIf currentImage = "9X3" Then
            If pic_3_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_3_grp9x.Width = pic_3_grp9x.Width
            pic_3_grp9x.Height = pic_3_grp9x.Height
        ElseIf currentImage = "9X4" Then
            If pic_4_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_4_grp9x.Width = pic_4_grp9x.Width
            pic_4_grp9x.Height = pic_4_grp9x.Height
        ElseIf currentImage = "9X5" Then
            If pic_5_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_5_grp9x.Width = pic_5_grp9x.Width
            pic_5_grp9x.Height = pic_5_grp9x.Height
        ElseIf currentImage = "9X6" Then
            If pic_6_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_6_grp9x.Width = pic_6_grp9x.Width
            pic_6_grp9x.Height = pic_6_grp9x.Height
        ElseIf currentImage = "9X7" Then
            If pic_7_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_7_grp9x.Width = pic_7_grp9x.Width
            pic_7_grp9x.Height = pic_7_grp9x.Height
        ElseIf currentImage = "9X8" Then
            If pic_8_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_8_grp9x.Width = pic_8_grp9x.Width
            pic_8_grp9x.Height = pic_8_grp9x.Height
        ElseIf currentImage = "9X9" Then
            If pic_9_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_9_grp9x.Width = pic_9_grp9x.Width
            pic_9_grp9x.Height = pic_9_grp9x.Height
        ElseIf currentImage = "16X1" Then
            If pic_1_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_1_grp16X.Width = pic_1_grp16X.Width
            pic_1_grp16X.Height = pic_1_grp16X.Height
        ElseIf currentImage = "16X2" Then
            If pic_2_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_2_grp16X.Width = pic_2_grp16X.Width
            pic_2_grp16X.Height = pic_2_grp16X.Height
        ElseIf currentImage = "16X3" Then
            If pic_3_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_3_grp16X.Width = pic_3_grp16X.Width
            pic_3_grp16X.Height = pic_3_grp16X.Height
        ElseIf currentImage = "16X4" Then
            If pic_4_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_4_grp16X.Width = pic_4_grp16X.Width
            pic_4_grp16X.Height = pic_4_grp16X.Height
        ElseIf currentImage = "16X5" Then
            If pic_5_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_5_grp16X.Width = pic_5_grp16X.Width
            pic_5_grp16X.Height = pic_5_grp16X.Height
        ElseIf currentImage = "16X6" Then
            If pic_6_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_6_grp16X.Width = pic_6_grp16X.Width
            pic_6_grp16X.Height = pic_6_grp16X.Height
        ElseIf currentImage = "16X7" Then
            If pic_7_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_7_grp16X.Width = pic_7_grp16X.Width
            pic_7_grp16X.Height = pic_7_grp16X.Height
        ElseIf currentImage = "16X8" Then
            If pic_8_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_8_grp16X.Width = pic_8_grp16X.Width
            pic_8_grp16X.Height = pic_8_grp16X.Height
        ElseIf currentImage = "16X9" Then
            If pic_9_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_9_grp16X.Width = pic_9_grp16X.Width
            pic_9_grp16X.Height = pic_9_grp16X.Height
        ElseIf currentImage = "16X10" Then
            If pic_10_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_10_grp16X.Width = pic_10_grp16X.Width
            pic_10_grp16X.Height = pic_10_grp16X.Height
        ElseIf currentImage = "16X11" Then
            If pic_11_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_11_grp16X.Width = pic_11_grp16X.Width
            pic_11_grp16X.Height = pic_11_grp16X.Height
        ElseIf currentImage = "16X12" Then
            If pic_12_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_12_grp16X.Width = pic_12_grp16X.Width
            pic_12_grp16X.Height = pic_12_grp16X.Height
        ElseIf currentImage = "16X13" Then
            If pic_13_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_13_grp16X.Width = pic_13_grp16X.Width
            pic_13_grp16X.Height = pic_13_grp16X.Height
        ElseIf currentImage = "16X14" Then
            If pic_14_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_14_grp16X.Width = pic_14_grp16X.Width
            pic_14_grp16X.Height = pic_14_grp16X.Height
        ElseIf currentImage = "16X15" Then
            If pic_15_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_15_grp16X.Width = pic_15_grp16X.Width
            pic_15_grp16X.Height = pic_15_grp16X.Height
        ElseIf currentImage = "16X16" Then
            If pic_16_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_16_grp16X.Width = pic_16_grp16X.Width
            pic_16_grp16X.Height = pic_16_grp16X.Height
        ElseIf currentImage = "18X1" Then
            If pic_1_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_1_grpFullMouth.Width = pic_1_grpFullMouth.Width
            pic_1_grpFullMouth.Height = pic_1_grpFullMouth.Height
        ElseIf currentImage = "18X2" Then
            If pic_2_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_2_grpFullMouth.Width = pic_2_grpFullMouth.Width
            pic_2_grpFullMouth.Height = pic_2_grpFullMouth.Height
        ElseIf currentImage = "18X3" Then
            If pic_3_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_3_grpFullMouth.Width = pic_3_grpFullMouth.Width
            pic_3_grpFullMouth.Height = pic_3_grpFullMouth.Height
        ElseIf currentImage = "18X4" Then
            If pic_4_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_4_grpFullMouth.Width = pic_4_grpFullMouth.Width
            pic_4_grpFullMouth.Height = pic_4_grpFullMouth.Height
        ElseIf currentImage = "18X5" Then
            If pic_5_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_5_grpFullMouth.Width = pic_5_grpFullMouth.Width
            pic_5_grpFullMouth.Height = pic_5_grpFullMouth.Height
        ElseIf currentImage = "18X6" Then
            If pic_6_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_6_grpFullMouth.Width = pic_6_grpFullMouth.Width
            pic_6_grpFullMouth.Height = pic_6_grpFullMouth.Height
        ElseIf currentImage = "18X7" Then
            If pic_7_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_7_grpFullMouth.Width = pic_7_grpFullMouth.Width
            pic_7_grpFullMouth.Height = pic_7_grpFullMouth.Height
        ElseIf currentImage = "18X8" Then
            If pic_8_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_8_grpFullMouth.Width = pic_8_grpFullMouth.Width
            pic_8_grpFullMouth.Height = pic_8_grpFullMouth.Height
        ElseIf currentImage = "18X9" Then
            If pic_9_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_9_grpFullMouth.Width = pic_9_grpFullMouth.Width
            pic_9_grpFullMouth.Height = pic_9_grpFullMouth.Height
        ElseIf currentImage = "18X10" Then
            If pic_10_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_10_grpFullMouth.Width = pic_10_grpFullMouth.Width
            pic_10_grpFullMouth.Height = pic_10_grpFullMouth.Height
        ElseIf currentImage = "18X11" Then
            If pic_11_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_11_grpFullMouth.Width = pic_11_grpFullMouth.Width
            pic_11_grpFullMouth.Height = pic_11_grpFullMouth.Height
        ElseIf currentImage = "18X12" Then
            If pic_12_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_12_grpFullMouth.Width = pic_12_grpFullMouth.Width
            pic_12_grpFullMouth.Height = pic_12_grpFullMouth.Height
        ElseIf currentImage = "18X13" Then
            If pic_13_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_13_grpFullMouth.Width = pic_13_grpFullMouth.Width
            pic_13_grpFullMouth.Height = pic_13_grpFullMouth.Height
        ElseIf currentImage = "18X14" Then
            If pic_14_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_14_grpFullMouth.Width = pic_14_grpFullMouth.Width
            pic_14_grpFullMouth.Height = pic_14_grpFullMouth.Height
        ElseIf currentImage = "18X15" Then
            If pic_15_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_15_grpFullMouth.Width = pic_15_grpFullMouth.Width
            pic_15_grpFullMouth.Height = pic_15_grpFullMouth.Height
        ElseIf currentImage = "18X16" Then
            If pic_16_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_16_grpFullMouth.Width = pic_16_grpFullMouth.Width
            pic_16_grpFullMouth.Height = pic_16_grpFullMouth.Height
        ElseIf currentImage = "18X17" Then
            If pic_17_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_17_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_17_grpFullMouth.Width = pic_17_grpFullMouth.Width
            pic_17_grpFullMouth.Height = pic_17_grpFullMouth.Height
        ElseIf currentImage = "18X18" Then
            If pic_18_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_18_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pic_18_grpFullMouth.Width = pic_18_grpFullMouth.Width
            pic_18_grpFullMouth.Height = pic_18_grpFullMouth.Height
        End If
        Call RefreshImages()
        Call FillDetails()
    End Sub

    Private Sub MirrorYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MirrorYToolStripMenuItem.Click
        If currentImage = "1X1" Then
            If Pic_1_grp1X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp1X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            Pic_1_grp1X.Width = Pic_1_grp1X.Width
            Pic_1_grp1X.Height = Pic_1_grp1X.Height
        ElseIf currentImage = "2X1" Then
            If pic_1_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp2X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_1_grp2X.Width = pic_1_grp2X.Width
            pic_1_grp2X.Height = pic_1_grp2X.Height
        ElseIf currentImage = "2X2" Then
            If pic_2_grp2X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp2X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_2_grp2X.Width = pic_2_grp2X.Width
            pic_2_grp2X.Height = pic_2_grp2X.Height
        ElseIf currentImage = "4X1" Then
            If Pic_1_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_1_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            Pic_1_grp4X.Width = Pic_1_grp4X.Width
            Pic_1_grp4X.Height = Pic_1_grp4X.Height
        ElseIf currentImage = "4X2" Then
            If Pic_2_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_2_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            Pic_2_grp4X.Width = Pic_2_grp4X.Width
            Pic_2_grp4X.Height = Pic_2_grp4X.Height
        ElseIf currentImage = "4X3" Then
            If Pic_3_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_3_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            Pic_3_grp4X.Width = Pic_3_grp4X.Width
            Pic_3_grp4X.Height = Pic_3_grp4X.Height
        ElseIf currentImage = "4X4" Then
            If Pic_4_grp4X.Image Is Nothing Then
                Exit Sub
            End If
            Pic_4_grp4X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            Pic_4_grp4X.Width = Pic_4_grp4X.Width
            Pic_4_grp4X.Height = Pic_4_grp4X.Height
        ElseIf currentImage = "9X1" Then
            If pic_1_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_1_grp9x.Width = pic_1_grp9x.Width
            pic_1_grp9x.Height = pic_1_grp9x.Height
        ElseIf currentImage = "9X2" Then
            If pic_2_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_2_grp9x.Width = pic_2_grp9x.Width
            pic_2_grp9x.Height = pic_2_grp9x.Height
        ElseIf currentImage = "9X3" Then
            If pic_3_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_3_grp9x.Width = pic_3_grp9x.Width
            pic_3_grp9x.Height = pic_3_grp9x.Height
        ElseIf currentImage = "9X4" Then
            If pic_4_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_4_grp9x.Width = pic_4_grp9x.Width
            pic_4_grp9x.Height = pic_4_grp9x.Height
        ElseIf currentImage = "9X5" Then
            If pic_5_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_5_grp9x.Width = pic_5_grp9x.Width
            pic_5_grp9x.Height = pic_5_grp9x.Height
        ElseIf currentImage = "9X6" Then
            If pic_6_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_6_grp9x.Width = pic_6_grp9x.Width
            pic_6_grp9x.Height = pic_6_grp9x.Height
        ElseIf currentImage = "9X7" Then
            If pic_7_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_7_grp9x.Width = pic_7_grp9x.Width
            pic_7_grp9x.Height = pic_7_grp9x.Height
        ElseIf currentImage = "9X8" Then
            If pic_8_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_8_grp9x.Width = pic_8_grp9x.Width
            pic_8_grp9x.Height = pic_8_grp9x.Height
        ElseIf currentImage = "9X9" Then
            If pic_9_grp9x.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp9x.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_9_grp9x.Width = pic_9_grp9x.Width
            pic_9_grp9x.Height = pic_9_grp9x.Height
        ElseIf currentImage = "16X1" Then
            If pic_1_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_1_grp16X.Width = pic_1_grp16X.Width
            pic_1_grp16X.Height = pic_1_grp16X.Height
        ElseIf currentImage = "16X2" Then
            If pic_2_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_2_grp16X.Width = pic_2_grp16X.Width
            pic_2_grp16X.Height = pic_2_grp16X.Height
        ElseIf currentImage = "16X3" Then
            If pic_3_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_3_grp16X.Width = pic_3_grp16X.Width
            pic_3_grp16X.Height = pic_3_grp16X.Height
        ElseIf currentImage = "16X4" Then
            If pic_4_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_4_grp16X.Width = pic_4_grp16X.Width
            pic_4_grp16X.Height = pic_4_grp16X.Height
        ElseIf currentImage = "16X5" Then
            If pic_5_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_5_grp16X.Width = pic_5_grp16X.Width
            pic_5_grp16X.Height = pic_5_grp16X.Height
        ElseIf currentImage = "16X6" Then
            If pic_6_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_6_grp16X.Width = pic_6_grp16X.Width
            pic_6_grp16X.Height = pic_6_grp16X.Height
        ElseIf currentImage = "16X7" Then
            If pic_7_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_7_grp16X.Width = pic_7_grp16X.Width
            pic_7_grp16X.Height = pic_7_grp16X.Height
        ElseIf currentImage = "16X8" Then
            If pic_8_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_8_grp16X.Width = pic_8_grp16X.Width
            pic_8_grp16X.Height = pic_8_grp16X.Height
        ElseIf currentImage = "16X9" Then
            If pic_9_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_9_grp16X.Width = pic_9_grp16X.Width
            pic_9_grp16X.Height = pic_9_grp16X.Height
        ElseIf currentImage = "16X10" Then
            If pic_10_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_10_grp16X.Width = pic_10_grp16X.Width
            pic_10_grp16X.Height = pic_10_grp16X.Height
        ElseIf currentImage = "16X11" Then
            If pic_11_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_11_grp16X.Width = pic_11_grp16X.Width
            pic_11_grp16X.Height = pic_11_grp16X.Height
        ElseIf currentImage = "16X12" Then
            If pic_12_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_12_grp16X.Width = pic_12_grp16X.Width
            pic_12_grp16X.Height = pic_12_grp16X.Height
        ElseIf currentImage = "16X13" Then
            If pic_13_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_13_grp16X.Width = pic_13_grp16X.Width
            pic_13_grp16X.Height = pic_13_grp16X.Height
        ElseIf currentImage = "16X14" Then
            If pic_14_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_14_grp16X.Width = pic_14_grp16X.Width
            pic_14_grp16X.Height = pic_14_grp16X.Height
        ElseIf currentImage = "16X15" Then
            If pic_15_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_15_grp16X.Width = pic_15_grp16X.Width
            pic_15_grp16X.Height = pic_15_grp16X.Height
        ElseIf currentImage = "16X16" Then
            If pic_16_grp16X.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grp16X.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_16_grp16X.Width = pic_16_grp16X.Width
            pic_16_grp16X.Height = pic_16_grp16X.Height
        ElseIf currentImage = "18X1" Then
            If pic_1_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_1_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_1_grpFullMouth.Width = pic_1_grpFullMouth.Width
            pic_1_grpFullMouth.Height = pic_1_grpFullMouth.Height
        ElseIf currentImage = "18X2" Then
            If pic_2_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_2_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_2_grpFullMouth.Width = pic_2_grpFullMouth.Width
            pic_2_grpFullMouth.Height = pic_2_grpFullMouth.Height
        ElseIf currentImage = "18X3" Then
            If pic_3_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_3_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_3_grpFullMouth.Width = pic_3_grpFullMouth.Width
            pic_3_grpFullMouth.Height = pic_3_grpFullMouth.Height
        ElseIf currentImage = "18X4" Then
            If pic_4_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_4_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_4_grpFullMouth.Width = pic_4_grpFullMouth.Width
            pic_4_grpFullMouth.Height = pic_4_grpFullMouth.Height
        ElseIf currentImage = "18X5" Then
            If pic_5_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_5_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_5_grpFullMouth.Width = pic_5_grpFullMouth.Width
            pic_5_grpFullMouth.Height = pic_5_grpFullMouth.Height
        ElseIf currentImage = "18X6" Then
            If pic_6_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_6_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_6_grpFullMouth.Width = pic_6_grpFullMouth.Width
            pic_6_grpFullMouth.Height = pic_6_grpFullMouth.Height
        ElseIf currentImage = "18X7" Then
            If pic_7_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_7_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_7_grpFullMouth.Width = pic_7_grpFullMouth.Width
            pic_7_grpFullMouth.Height = pic_7_grpFullMouth.Height
        ElseIf currentImage = "18X8" Then
            If pic_8_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_8_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_8_grpFullMouth.Width = pic_8_grpFullMouth.Width
            pic_8_grpFullMouth.Height = pic_8_grpFullMouth.Height
        ElseIf currentImage = "18X9" Then
            If pic_9_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_9_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_9_grpFullMouth.Width = pic_9_grpFullMouth.Width
            pic_9_grpFullMouth.Height = pic_9_grpFullMouth.Height
        ElseIf currentImage = "18X10" Then
            If pic_10_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_10_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_10_grpFullMouth.Width = pic_10_grpFullMouth.Width
            pic_10_grpFullMouth.Height = pic_10_grpFullMouth.Height
        ElseIf currentImage = "18X11" Then
            If pic_11_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_11_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_11_grpFullMouth.Width = pic_11_grpFullMouth.Width
            pic_11_grpFullMouth.Height = pic_11_grpFullMouth.Height
        ElseIf currentImage = "18X12" Then
            If pic_12_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_12_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_12_grpFullMouth.Width = pic_12_grpFullMouth.Width
            pic_12_grpFullMouth.Height = pic_12_grpFullMouth.Height
        ElseIf currentImage = "18X13" Then
            If pic_13_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_13_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_13_grpFullMouth.Width = pic_13_grpFullMouth.Width
            pic_13_grpFullMouth.Height = pic_13_grpFullMouth.Height
        ElseIf currentImage = "18X14" Then
            If pic_14_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_14_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_14_grpFullMouth.Width = pic_14_grpFullMouth.Width
            pic_14_grpFullMouth.Height = pic_14_grpFullMouth.Height
        ElseIf currentImage = "18X15" Then
            If pic_15_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_15_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_15_grpFullMouth.Width = pic_15_grpFullMouth.Width
            pic_15_grpFullMouth.Height = pic_15_grpFullMouth.Height
        ElseIf currentImage = "18X16" Then
            If pic_16_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_16_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_16_grpFullMouth.Width = pic_16_grpFullMouth.Width
            pic_16_grpFullMouth.Height = pic_16_grpFullMouth.Height
        ElseIf currentImage = "18X17" Then
            If pic_17_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_17_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_17_grpFullMouth.Width = pic_17_grpFullMouth.Width
            pic_17_grpFullMouth.Height = pic_17_grpFullMouth.Height
        ElseIf currentImage = "18X18" Then
            If pic_18_grpFullMouth.Image Is Nothing Then
                Exit Sub
            End If
            pic_18_grpFullMouth.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            pic_18_grpFullMouth.Width = pic_18_grpFullMouth.Width
            pic_18_grpFullMouth.Height = pic_18_grpFullMouth.Height
        End If
        Call RefreshImages()
        Call FillDetails()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Me.Close()
    End Sub

    Private Sub MeasurementsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MeasurementsToolStripMenuItem.Click
        Panel1.Visible = True
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If PatientId <> "" Then

        Else
            MsgBox("Select any Patient!")
            Exit Sub
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        frm_Patient_Delete.Show()
    End Sub

    Private Sub FullScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullScreenToolStripMenuItem.Click
        If path <> "" Then
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub ToOtherMonitorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToOtherMonitorToolStripMenuItem.Click
        Me.Location = Screen.AllScreens(UBound(Screen.AllScreens)).Bounds.Location + New Point(100, 100)
    End Sub

    Private Sub Pnl_9X1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_9X1.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If pic_1_grp9x.Width < 500 Then
                    Pnl_9X1.AutoScroll = False
                    Exit Sub 'minimum 500?
                End If
            Else
                If pic_1_grp9x.Width > 2000 Then Exit Sub 'maximum 2000?
            End If
            Pnl_9X1.AutoScroll = True
            pic_1_grp9x.Width += CInt(pic_1_grp9x.Width * e.Delta / 1000)
            pic_1_grp9x.Height += CInt(pic_1_grp9x.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub Pnl_9X2_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_9X2.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If pic_2_grp9x.Width < 500 Then
                    Pnl_9X2.AutoScroll = False
                    Exit Sub 'minimum 500?
                End If
            Else
                If pic_2_grp9x.Width > 2000 Then Exit Sub 'maximum 2000?
            End If
            Pnl_9X2.AutoScroll = True
            pic_2_grp9x.Width += CInt(pic_2_grp9x.Width * e.Delta / 1000)
            pic_2_grp9x.Height += CInt(pic_2_grp9x.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub Pnl_9X3_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_9X3.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If pic_3_grp9x.Width < 500 Then
                    Pnl_9X3.AutoScroll = False
                    Exit Sub 'minimum 500?
                End If
            Else
                If pic_3_grp9x.Width > 2000 Then Exit Sub 'maximum 2000?
            End If
            Pnl_9X3.AutoScroll = True
            pic_3_grp9x.Width += CInt(pic_3_grp9x.Width * e.Delta / 1000)
            pic_3_grp9x.Height += CInt(pic_3_grp9x.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub Pnl_9X4_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_9X4.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If pic_4_grp9x.Width < 500 Then
                    Pnl_9X4.AutoScroll = False
                    Exit Sub 'minimum 500?
                End If
            Else
                If pic_4_grp9x.Width > 2000 Then Exit Sub 'maximum 2000?
            End If
            Pnl_9X4.AutoScroll = True
            pic_4_grp9x.Width += CInt(pic_4_grp9x.Width * e.Delta / 1000)
            pic_4_grp9x.Height += CInt(pic_4_grp9x.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub Pnl_9X5_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_9X5.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If pic_5_grp9x.Width < 500 Then
                    Pnl_9X5.AutoScroll = False
                    Exit Sub 'minimum 500?
                End If
            Else
                If pic_5_grp9x.Width > 2000 Then Exit Sub 'maximum 2000?
            End If
            Pnl_9X5.AutoScroll = True
            pic_5_grp9x.Width += CInt(pic_5_grp9x.Width * e.Delta / 1000)
            pic_5_grp9x.Height += CInt(pic_5_grp9x.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub Pnl_9X6_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_9X6.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If pic_6_grp9x.Width < 500 Then
                    Pnl_9X6.AutoScroll = False
                    Exit Sub 'minimum 500?
                End If
            Else
                If pic_6_grp9x.Width > 2000 Then Exit Sub 'maximum 2000?
            End If
            Pnl_9X6.AutoScroll = True
            pic_6_grp9x.Width += CInt(pic_6_grp9x.Width * e.Delta / 1000)
            pic_6_grp9x.Height += CInt(pic_6_grp9x.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub Pnl_9X7_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_9X7.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If pic_7_grp9x.Width < 500 Then
                    Pnl_9X7.AutoScroll = False
                    Exit Sub 'minimum 500?
                End If
            Else
                If pic_7_grp9x.Width > 2000 Then Exit Sub 'maximum 2000?
            End If
            Pnl_9X7.AutoScroll = True
            pic_7_grp9x.Width += CInt(pic_7_grp9x.Width * e.Delta / 1000)
            pic_7_grp9x.Height += CInt(pic_7_grp9x.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub Pnl_9X8_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_9X8.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If pic_8_grp9x.Width < 500 Then
                    Pnl_9X8.AutoScroll = False
                    Exit Sub 'minimum 500?
                End If
            Else
                If pic_8_grp9x.Width > 2000 Then Exit Sub 'maximum 2000?
            End If
            Pnl_9X8.AutoScroll = True
            pic_8_grp9x.Width += CInt(pic_8_grp9x.Width * e.Delta / 1000)
            pic_8_grp9x.Height += CInt(pic_8_grp9x.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub Pnl_9X9_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_9X9.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If pic_9_grp9x.Width < 500 Then
                    Pnl_9X9.AutoScroll = False
                    Exit Sub 'minimum 500?
                End If
            Else
                If pic_9_grp9x.Width > 2000 Then Exit Sub 'maximum 2000?
            End If
            Pnl_9X9.AutoScroll = True
            pic_9_grp9x.Width += CInt(pic_9_grp9x.Width * e.Delta / 1000)
            pic_9_grp9x.Height += CInt(pic_9_grp9x.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub TodaysImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TodaysImageToolStripMenuItem.Click
        frm_Patient_TodayImages.Show()
    End Sub

    Private Sub StatisticsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatisticsToolStripMenuItem.Click
        frm_DatabaseStatistics.Show()
    End Sub

    Private Sub UsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsersToolStripMenuItem.Click
        frm_DatabaseUsers.Show()
    End Sub

    Private Sub NormalPrinterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NormalPrinterToolStripMenuItem.Click
        PageSetupDialog1.Document = PrintDocument1
        PageSetupDialog1.Document.DefaultPageSettings.Color = False
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub ImagePrinterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagePrinterToolStripMenuItem.Click
        PageSetupDialog1.Document = PrintDocument1
        PageSetupDialog1.Document.DefaultPageSettings.Color = False
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub TestPrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestPrintToolStripMenuItem.Click
        Dim computerName As String = System.Windows.Forms.SystemInformation.ComputerName
        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            'format the printer name correctly
            Dim PrinterName As String = String.Format("\\{0}\{1}", computerName, printer)
            'format the arguments 
            Dim args As String = String.Format("printui.DLL, PrintUIEntry /k /n {0}{1}{0}", Chr(34), PrinterName)
            'make the call 
            Process.Start("c:\Windows\System32\rundll32.EXE", args)
        Next
    End Sub

    Private Sub SynchronizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SynchronizeToolStripMenuItem.Click
        frm_Patient_Registration.Show()
    End Sub

    Private Sub FullViewAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullViewAreaToolStripMenuItem.Click
        If grpViewer.Visible = True Then
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
        Panel2.Width = 110
        GroupBox2.Width = 114
        Panel3.Left = 110
        Panel3.Width = Me.Width - Panel2.Width
        grp1X.Visible = True
        grp4X.Visible = False
        grp2X.Visible = False
        grp9X.Visible = False
        grp16X.Visible = False
        grpFullMouth.Visible = False
        GroupBox3.Visible = False
        grpViewer.Visible = False
        btnImport.Visible = False
        Call FillDetails()
    End Sub

    Private Sub Pic_1_grp1X_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pic_1_grp1X.DoubleClick
        If Pic_1_grp1X.Image Is Nothing Then
            Exit Sub
        End If
        If path <> "" Then
            test = 0
            frm_Image_FullScreen.PictureBox1.ImageLocation = path
            frm_Image_FullScreen.Show()
            m_MouseIsDown = False
        End If
    End Sub

    Private Sub Pic_1_grp1X_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Pic_1_grp1X.DragDrop
        If Pic_1_grp1X.ImageLocation = path And Pic = "" Then
            Exit Sub
        End If
        Pic_1_grp1X.Image = e.Data.GetData(DataFormats.Bitmap)
        Pic_1_grp1X.ImageLocation = path
        Pic_1_grp1X.Tag = FName
        If path <> "" Then
            m_MouseIsDown = False
        End If
        Pic = ""

    End Sub

    Private Sub Pic_1_grp1X_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Pic_1_grp1X.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Pic_1_grp1X_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_1_grp1X.MouseDown
        If Not Pic_1_grp1X.Image Is Nothing Then
            m_MouseIsDown = True
            Pic = "1X1"
            mouseX = e.Y
            mouseY = e.X
            If Pic = "1X1" And Contrast = 1 Then
                Pic_1_grp1X.Cursor = Cursors.NoMoveVert
                mouseX = e.Y
            ElseIf Pic = "1X1" And Bright = 1 Then
                Pic_1_grp1X.Cursor = Cursors.NoMoveHoriz
                mouseY = e.X
            End If
            FName = Pic_1_grp1X.Tag
            path = Pic_1_grp1X.ImageLocation
            ExportOriginalToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
            ExportProcessedToolStripMenuItem.Enabled = True
            DuplicateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Pic_1_grp1X_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_1_grp1X.MouseMove
        'If Panel1.Visible = True Then
        '    mouseY = e.X
        '    mouseY = e.Y
        'End If
        If m_MouseIsDown And Contrast = 0 And Bright = 0 And Not Pic_1_grp1X.Image Is Nothing Then
            Pic_1_grp1X.DoDragDrop(Pic_1_grp1X.Image, DragDropEffects.Copy Or _
    DragDropEffects.Move)
        ElseIf Contrast = 1 And m_MouseIsDown Then
            If e.Y < mouseX Then
                If Contrast = 1 And Pic = "1X1" Then
                    Pic_1_grp1X.Image = Fun_Contrast(Pic_1_grp1X.Image, 50)
                End If
            ElseIf e.Y > mouseX Then
                If Contrast = 1 And Pic = "1X1" Then
                    Pic_1_grp1X.Image = Fun_Contrast(Pic_1_grp1X.Image, -50)
                End If
            End If
        ElseIf Bright = 1 And m_MouseIsDown Then
            If e.X < mouseY Then
                If Bright = 1 And Pic = "1X1" Then
                    Pic_1_grp1X.Image = Fun_Brightness(Pic_1_grp1X.Image, -10)
                End If
            ElseIf e.X > mouseY Then
                If Bright = 1 And Pic = "1X1" Then
                    Pic_1_grp1X.Image = Fun_Brightness(Pic_1_grp1X.Image, 10)
                End If
            End If
        End If
        m_MouseIsDown = False
    End Sub

  

    Private Sub Pic_1_grp1X_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic_1_grp1X.MouseUp
        Dragging = False
        If measure = "T" Then
            Dim txt As New TextBox
            txt.Text = ""
            txt.Top = mouseX
            txt.Left = mouseY
            txt.Width = 105
            txt.ForeColor = Black
            txt.AllowDrop = True
            Me.grp1X.Controls.Add(txt)
            txt.BringToFront()
            'AddHandler txt.MouseUp, AddressOf txt_mouseup
            'AddHandler txt.MouseDown, AddressOf txt_mousedown
            'AddHandler txt.MouseMove, AddressOf txt_MouseMove

            measure = ""
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Right Then
            picture = "P1_1"
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            m_MouseIsDown = False
            currentImage = "1X1"
        End If
    End Sub

    Private Sub Pnl_1X1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_1X1.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If Pic_1_grp1X.Width < 1350 Then
                    Pnl_1X1.AutoScroll = False
                    Exit Sub 'minimum 500?
                End If
            Else
                If Pic_1_grp1X.Width > 2000 Then Exit Sub 'maximum 2000?
            End If
            Pnl_1X1.AutoScroll = True
            Pic_1_grp1X.Width += CInt(Pic_1_grp1X.Width * e.Delta / 1000)
            Pic_1_grp1X.Height += CInt(Pic_1_grp1X.Height * e.Delta / 1000)
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        frm_Patient_Export.Show()
    End Sub

    Private Sub SpecificImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpecificImageToolStripMenuItem.Click
        frm_Patient_AllImages.Show()
    End Sub

    Private Sub MediaFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediaFilterToolStripMenuItem.Click
        Dim img As Bitmap
        Me.Cursor = Cursors.WaitCursor
        If Pic = "1X1" Then
            img = New Bitmap(Pic_1_grp1X.Image)
        ElseIf Pic = "2X1" Then
            img = New Bitmap(pic_1_grp2X.Image)
        ElseIf Pic = "2X2" Then
            img = New Bitmap(pic_2_grp2X.Image)
        ElseIf Pic = "4X1" Then
            img = New Bitmap(Pic_1_grp4X.Image)
        ElseIf Pic = "4X2" Then
            img = New Bitmap(Pic_2_grp4X.Image)
        ElseIf Pic = "4X3" Then
            img = New Bitmap(Pic_3_grp4X.Image)
        ElseIf Pic = "4X4" Then
            img = New Bitmap(Pic_4_grp4X.Image)
        ElseIf Pic = "9X1" Then
            img = New Bitmap(pic_1_grp9x.Image)
        ElseIf Pic = "9X2" Then
            img = New Bitmap(pic_2_grp9x.Image)
        ElseIf Pic = "9X3" Then
            img = New Bitmap(pic_3_grp9x.Image)
        ElseIf Pic = "9X4" Then
            img = New Bitmap(pic_4_grp9x.Image)
        ElseIf Pic = "9X5" Then
            img = New Bitmap(pic_5_grp9x.Image)
        ElseIf Pic = "9X6" Then
            img = New Bitmap(pic_6_grp9x.Image)
        ElseIf Pic = "9X7" Then
            img = New Bitmap(pic_7_grp9x.Image)
        ElseIf Pic = "9X8" Then
            img = New Bitmap(pic_8_grp9x.Image)
        ElseIf Pic = "9X9" Then
            img = New Bitmap(pic_9_grp9x.Image)
        ElseIf Pic = "16X1" Then
            img = New Bitmap(pic_1_grp16X.Image)
        ElseIf Pic = "16X2" Then
            img = New Bitmap(pic_2_grp16X.Image)
        ElseIf Pic = "16X3" Then
            img = New Bitmap(pic_3_grp16X.Image)
        ElseIf Pic = "16X4" Then
            img = New Bitmap(pic_4_grp16X.Image)
        ElseIf Pic = "16X5" Then
            img = New Bitmap(pic_5_grp16X.Image)
        ElseIf Pic = "16X6" Then
            img = New Bitmap(pic_6_grp16X.Image)
        ElseIf Pic = "16X7" Then
            img = New Bitmap(pic_7_grp16X.Image)
        ElseIf Pic = "16X8" Then
            img = New Bitmap(pic_8_grp16X.Image)
        ElseIf Pic = "16X9" Then
            img = New Bitmap(pic_9_grp16X.Image)
        ElseIf Pic = "16X10" Then
            img = New Bitmap(pic_10_grp16X.Image)
        ElseIf Pic = "16X11" Then
            img = New Bitmap(pic_11_grp16X.Image)
        ElseIf Pic = "16X12" Then
            img = New Bitmap(pic_12_grp16X.Image)
        ElseIf Pic = "16X13" Then
            img = New Bitmap(pic_13_grp16X.Image)
        ElseIf Pic = "16X14" Then
            img = New Bitmap(pic_14_grp16X.Image)
        ElseIf Pic = "16X15" Then
            img = New Bitmap(pic_15_grp16X.Image)
        ElseIf Pic = "16X16" Then
            img = New Bitmap(pic_16_grp16X.Image)
        ElseIf Pic = "18X1" Then
            img = New Bitmap(pic_1_grpFullMouth.Image)
        ElseIf Pic = "18X2" Then
            img = New Bitmap(pic_2_grpFullMouth.Image)
        ElseIf Pic = "18X3" Then
            img = New Bitmap(pic_3_grpFullMouth.Image)
        ElseIf Pic = "18X4" Then
            img = New Bitmap(pic_4_grpFullMouth.Image)
        ElseIf Pic = "18X5" Then
            img = New Bitmap(pic_5_grpFullMouth.Image)
        ElseIf Pic = "18X6" Then
            img = New Bitmap(pic_6_grpFullMouth.Image)
        ElseIf Pic = "18X7" Then
            img = New Bitmap(pic_7_grpFullMouth.Image)
        ElseIf Pic = "18X8" Then
            img = New Bitmap(pic_8_grpFullMouth.Image)
        ElseIf Pic = "18X9" Then
            img = New Bitmap(pic_9_grpFullMouth.Image)
        ElseIf Pic = "18X10" Then
            img = New Bitmap(pic_10_grpFullMouth.Image)
        ElseIf Pic = "18X11" Then
            img = New Bitmap(pic_11_grpFullMouth.Image)
        ElseIf Pic = "18X12" Then
            img = New Bitmap(pic_12_grpFullMouth.Image)
        ElseIf Pic = "18X13" Then
            img = New Bitmap(pic_13_grpFullMouth.Image)
        ElseIf Pic = "18X14" Then
            img = New Bitmap(pic_14_grpFullMouth.Image)
        ElseIf Pic = "18X15" Then
            img = New Bitmap(pic_15_grpFullMouth.Image)
        ElseIf Pic = "18X16" Then
            img = New Bitmap(pic_16_grpFullMouth.Image)
        ElseIf Pic = "18X17" Then
            img = New Bitmap(pic_17_grpFullMouth.Image)
        ElseIf Pic = "18X18" Then
            img = New Bitmap(pic_18_grpFullMouth.Image)
        Else
            Exit Sub
        End If
        Dim c As Color
        Dim mask As Integer() = New Integer(8) {}
        Dim i As Integer = 0
        Do While (i < img.Width)
            Dim j As Integer = 0
            Do While (j < img.Height)
                c = img.GetPixel(i, j)
                Dim r As Integer = 0
                r = Convert.ToInt16(c.R)
                Dim g As Integer = 0
                g = Convert.ToInt16(c.G)
                Dim b As Integer = 0
                b = Convert.ToInt16(c.B)
                Dim max1 As Integer = System.Math.Max(r, g)
                Dim final As Integer = System.Math.Max(max1, b)
                r = final
                g = final
                b = final
                c = Color.FromArgb(r, g, b)
                img.SetPixel(i, j, c)
                j = (j + 1)
            Loop
            i = (i + 1)
        Loop

        For ii As Integer = 0 To img.Width - 1
            For jj As Integer = 0 To img.Height - 1

                If ii - 1 >= 0 AndAlso jj - 1 >= 0 Then
                    c = img.GetPixel(ii - 1, jj - 1)
                    mask(0) = Convert.ToInt16(c.R)
                Else
                    mask(0) = 0
                End If

                If jj - 1 >= 0 AndAlso ii + 1 < img.Width Then
                    c = img.GetPixel(ii + 1, jj - 1)
                    mask(1) = Convert.ToInt16(c.R)
                Else
                    mask(1) = 0
                End If

                If jj - 1 >= 0 Then
                    c = img.GetPixel(ii, jj - 1)
                    mask(2) = Convert.ToInt16(c.R)
                Else
                    mask(2) = 0
                End If

                If ii + 1 < img.Width Then
                    c = img.GetPixel(ii + 1, jj)
                    mask(3) = Convert.ToInt16(c.R)
                Else
                    mask(3) = 0
                End If

                If ii - 1 >= 0 Then
                    c = img.GetPixel(ii - 1, jj)
                    mask(4) = Convert.ToInt16(c.R)
                Else
                    mask(4) = 0
                End If

                If ii - 1 >= 0 AndAlso jj + 1 < img.Height Then
                    c = img.GetPixel(ii - 1, jj + 1)
                    mask(5) = Convert.ToInt16(c.R)
                Else
                    mask(5) = 0
                End If

                If jj + 1 < img.Height Then
                    c = img.GetPixel(ii, jj + 1)
                    mask(6) = Convert.ToInt16(c.R)
                Else
                    mask(6) = 0
                End If


                If ii + 1 < img.Width AndAlso jj + 1 < img.Height Then
                    c = img.GetPixel(ii + 1, jj + 1)
                    mask(7) = Convert.ToInt16(c.R)
                Else
                    mask(7) = 0
                End If
                c = img.GetPixel(ii, jj)
                mask(8) = Convert.ToInt16(c.R)
                Array.Sort(mask)
                Dim mid As Integer = mask(4)
                img.SetPixel(ii, jj, Color.FromArgb(mid, mid, mid))
            Next
        Next
        If Pic = "1X1" Then
            Pic_1_grp1X.Image = img
        ElseIf Pic = "2X1" Then
            pic_1_grp2X.Image = img
        ElseIf Pic = "2X2" Then
            pic_2_grp2X.Image = img
        ElseIf Pic = "4X1" Then
            Pic_1_grp4X.Image = img
        ElseIf Pic = "4X2" Then
            Pic_2_grp4X.Image = img
        ElseIf Pic = "4X3" Then
            Pic_3_grp4X.Image = img
        ElseIf Pic = "4X4" Then
            Pic_4_grp4X.Image = img
        ElseIf Pic = "9X1" Then
            pic_1_grp9x.Image = img
        ElseIf Pic = "9X2" Then
            pic_2_grp9x.Image = img
        ElseIf Pic = "9X3" Then
            pic_3_grp9x.Image = img
        ElseIf Pic = "9X4" Then
            pic_4_grp9x.Image = img
        ElseIf Pic = "9X5" Then
            pic_5_grp9x.Image = img
        ElseIf Pic = "9X6" Then
            pic_6_grp9x.Image = img
        ElseIf Pic = "9X7" Then
            pic_7_grp9x.Image = img
        ElseIf Pic = "9X8" Then
            pic_8_grp9x.Image = img
        ElseIf Pic = "9X9" Then
            pic_9_grp9x.Image = img
        ElseIf Pic = "16X1" Then
            pic_1_grp16X.Image = img
        ElseIf Pic = "16X2" Then
            pic_2_grp16X.Image = img
        ElseIf Pic = "16X3" Then
            pic_3_grp16X.Image = img
        ElseIf Pic = "16X4" Then
            pic_4_grp16X.Image = img
        ElseIf Pic = "16X5" Then
            pic_5_grp16X.Image = img
        ElseIf Pic = "16X6" Then
            pic_6_grp16X.Image = img
        ElseIf Pic = "16X7" Then
            pic_7_grp16X.Image = img
        ElseIf Pic = "16X8" Then
            pic_8_grp16X.Image = img
        ElseIf Pic = "16X9" Then
            pic_9_grp16X.Image = img
        ElseIf Pic = "16X10" Then
            pic_10_grp16X.Image = img
        ElseIf Pic = "16X11" Then
            pic_11_grp16X.Image = img
        ElseIf Pic = "16X12" Then
            pic_12_grp16X.Image = img
        ElseIf Pic = "16X13" Then
            pic_14_grp16X.Image = img
        ElseIf Pic = "16X14" Then
            pic_14_grp16X.Image = img
        ElseIf Pic = "16X15" Then
            pic_15_grp16X.Image = img
        ElseIf Pic = "16X16" Then
            pic_16_grp16X.Image = img
        ElseIf Pic = "18X1" Then
            pic_1_grpFullMouth.Image = img
        ElseIf Pic = "18X2" Then
            pic_2_grpFullMouth.Image = img
        ElseIf Pic = "18X3" Then
            pic_3_grpFullMouth.Image = img
        ElseIf Pic = "18X4" Then
            pic_4_grpFullMouth.Image = img
        ElseIf Pic = "18X5" Then
            pic_5_grpFullMouth.Image = img
        ElseIf Pic = "18X6" Then
            pic_6_grpFullMouth.Image = img
        ElseIf Pic = "18X7" Then
            pic_7_grpFullMouth.Image = img
        ElseIf Pic = "18X8" Then
            pic_8_grpFullMouth.Image = img
        ElseIf Pic = "18X9" Then
            pic_9_grpFullMouth.Image = img
        ElseIf Pic = "18X10" Then
            pic_10_grpFullMouth.Image = img
        ElseIf Pic = "18X11" Then
            pic_11_grpFullMouth.Image = img
        ElseIf Pic = "18X12" Then
            pic_12_grpFullMouth.Image = img
        ElseIf Pic = "18X13" Then
            pic_13_grpFullMouth.Image = img
        ElseIf Pic = "18X14" Then
            pic_14_grpFullMouth.Image = img
        ElseIf Pic = "18X15" Then
            pic_15_grpFullMouth.Image = img
        ElseIf Pic = "18X16" Then
            pic_16_grpFullMouth.Image = img
        ElseIf Pic = "18X17" Then
            pic_17_grpFullMouth.Image = img
        ElseIf Pic = "18X18" Then
            pic_18_grpFullMouth.Image = img
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ExportOriginalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportOriginalToolStripMenuItem.Click
        Dim sfd As New SaveFileDialog
        sfd.Filter = "Jpg Image|*.jpg|Bmp Image|*.bmp|Png Image|*.png"
        sfd.FileName = "Untitled"
        sfd.AddExtension = True 'Make sure the extension is added to the FileName
        If sfd.ShowDialog = DialogResult.OK Then 'If the user presses "Ok" button on the SaveFileDialog
            If Pic = "1X1" Then
                FileCopy(Pic_1_grp1X.ImageLocation, sfd.FileName)
            ElseIf Pic = "2X1" Then
                FileCopy(pic_1_grp2X.ImageLocation, sfd.FileName)
            ElseIf Pic = "2X2" Then
                FileCopy(pic_2_grp2X.ImageLocation, sfd.FileName)
            ElseIf Pic = "4X1" Then
                FileCopy(Pic_1_grp4X.ImageLocation, sfd.FileName)
            ElseIf Pic = "4X2" Then
                FileCopy(Pic_2_grp4X.ImageLocation, sfd.FileName)
            ElseIf Pic = "4X3" Then
                FileCopy(Pic_3_grp4X.ImageLocation, sfd.FileName)
            ElseIf Pic = "4X4" Then
                FileCopy(Pic_4_grp4X.ImageLocation, sfd.FileName)
            ElseIf Pic = "9X1" Then
                FileCopy(pic_1_grp9x.ImageLocation, sfd.FileName)
            ElseIf Pic = "9X2" Then
                FileCopy(pic_2_grp9x.ImageLocation, sfd.FileName)
            ElseIf Pic = "9X3" Then
                FileCopy(pic_3_grp9x.ImageLocation, sfd.FileName)
            ElseIf Pic = "9X4" Then
                FileCopy(pic_4_grp9x.ImageLocation, sfd.FileName)
            ElseIf Pic = "9X5" Then
                FileCopy(pic_5_grp9x.ImageLocation, sfd.FileName)
            ElseIf Pic = "9X6" Then
                FileCopy(pic_6_grp9x.ImageLocation, sfd.FileName)
            ElseIf Pic = "9X7" Then
                FileCopy(pic_7_grp9x.ImageLocation, sfd.FileName)
            ElseIf Pic = "9X8" Then
                FileCopy(pic_8_grp9x.ImageLocation, sfd.FileName)
            ElseIf Pic = "9X9" Then
                FileCopy(pic_9_grp9x.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X1" Then
                FileCopy(pic_1_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X2" Then
                FileCopy(pic_2_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X3" Then
                FileCopy(pic_3_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X4" Then
                FileCopy(pic_4_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X5" Then
                FileCopy(pic_5_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X6" Then
                FileCopy(pic_6_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X7" Then
                FileCopy(pic_7_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X8" Then
                FileCopy(pic_8_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X9" Then
                FileCopy(pic_9_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X10" Then
                FileCopy(pic_10_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X11" Then
                FileCopy(pic_11_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X12" Then
                FileCopy(pic_12_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X13" Then
                FileCopy(pic_13_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X14" Then
                FileCopy(pic_14_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X15" Then
                FileCopy(pic_15_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "16X16" Then
                FileCopy(pic_16_grp16X.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X1" Then
                FileCopy(pic_1_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X2" Then
                FileCopy(pic_2_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X3" Then
                FileCopy(pic_3_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X4" Then
                FileCopy(pic_4_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X5" Then
                FileCopy(pic_5_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X6" Then
                FileCopy(pic_6_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X7" Then
                FileCopy(pic_7_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X8" Then
                FileCopy(pic_8_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X9" Then
                FileCopy(pic_9_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X10" Then
                FileCopy(pic_10_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X11" Then
                FileCopy(pic_11_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X12" Then
                FileCopy(pic_12_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X13" Then
                FileCopy(pic_13_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X14" Then
                FileCopy(pic_14_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X15" Then
                FileCopy(pic_15_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X16" Then
                FileCopy(pic_16_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X17" Then
                FileCopy(pic_17_grpFullMouth.ImageLocation, sfd.FileName)
            ElseIf Pic = "18X18" Then
                FileCopy(pic_18_grpFullMouth.ImageLocation, sfd.FileName)
            Else
                MsgBox("Select Any Image!")
                Exit Sub
            End If
        End If
        sfd.Dispose() 'Dispose the SaveFileDialog when no longer needed
        MsgBox("Original Picture Saved Successfully")
    End Sub

    Private Sub SharpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SharpenToolStripMenuItem.Click
        If Pic = "" Then Pic = currentImage
        Me.Cursor = Cursors.WaitCursor
        Dim Height As Integer
        Dim Width As Integer
        Dim oldBitmap As Bitmap
        If Pic = "1X1" Then
            Height = Me.Pic_1_grp1X.Image.Height
            Width = Me.Pic_1_grp1X.Image.Width
            oldBitmap = DirectCast(Me.Pic_1_grp1X.Image, Bitmap)
        ElseIf Pic = "2X1" Then
            Height = Me.pic_1_grp2X.Image.Height
            Width = Me.pic_1_grp2X.Image.Width
            oldBitmap = DirectCast(Me.pic_1_grp2X.Image, Bitmap)
        ElseIf Pic = "2X2" Then
            Height = Me.pic_2_grp2X.Image.Height
            Width = Me.pic_2_grp2X.Image.Width
            oldBitmap = DirectCast(Me.pic_2_grp2X.Image, Bitmap)
        ElseIf Pic = "4X1" Then
            Height = Me.Pic_1_grp4X.Image.Height
            Width = Me.Pic_1_grp4X.Image.Width
            oldBitmap = DirectCast(Me.Pic_1_grp4X.Image, Bitmap)
        ElseIf Pic = "4X2" Then
            Height = Me.Pic_2_grp4X.Image.Height
            Width = Me.Pic_2_grp4X.Image.Width
            oldBitmap = DirectCast(Me.Pic_2_grp4X.Image, Bitmap)
        ElseIf Pic = "4X3" Then
            Height = Me.Pic_3_grp4X.Image.Height
            Width = Me.Pic_3_grp4X.Image.Width
            oldBitmap = DirectCast(Me.Pic_3_grp4X.Image, Bitmap)
        ElseIf Pic = "4X4" Then
            Height = Me.Pic_4_grp4X.Image.Height
            Width = Me.Pic_4_grp4X.Image.Width
            oldBitmap = DirectCast(Me.Pic_4_grp4X.Image, Bitmap)
        ElseIf Pic = "9X1" Then
            Height = Me.pic_1_grp9x.Image.Height
            Width = Me.pic_1_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_1_grp9x.Image, Bitmap)
        ElseIf Pic = "9X2" Then
            Height = Me.pic_2_grp9x.Image.Height
            Width = Me.pic_2_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_2_grp9x.Image, Bitmap)
        ElseIf Pic = "9X3" Then
            Height = Me.pic_3_grp9x.Image.Height
            Width = Me.pic_3_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_3_grp9x.Image, Bitmap)
        ElseIf Pic = "9X4" Then
            Height = Me.pic_4_grp9x.Image.Height
            Width = Me.pic_4_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_4_grp9x.Image, Bitmap)
        ElseIf Pic = "9X5" Then
            Height = Me.pic_5_grp9x.Image.Height
            Width = Me.pic_5_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_5_grp9x.Image, Bitmap)
        ElseIf Pic = "9X6" Then
            Height = Me.pic_6_grp9x.Image.Height
            Width = Me.pic_6_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_6_grp9x.Image, Bitmap)
        ElseIf Pic = "9X7" Then
            Height = Me.pic_7_grp9x.Image.Height
            Width = Me.pic_7_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_7_grp9x.Image, Bitmap)
        ElseIf Pic = "9X8" Then
            Height = Me.pic_8_grp9x.Image.Height
            Width = Me.pic_8_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_8_grp9x.Image, Bitmap)
        ElseIf Pic = "9X9" Then
            Height = Me.pic_9_grp9x.Image.Height
            Width = Me.pic_9_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_9_grp9x.Image, Bitmap)
        ElseIf Pic = "16X1" Then
            Height = Me.pic_1_grp16X.Image.Height
            Width = Me.pic_1_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_1_grp16X.Image, Bitmap)
        ElseIf Pic = "16X2" Then
            Height = Me.pic_2_grp16X.Image.Height
            Width = Me.pic_2_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_2_grp16X.Image, Bitmap)
        ElseIf Pic = "16X3" Then
            Height = Me.pic_3_grp16X.Image.Height
            Width = Me.pic_3_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_3_grp16X.Image, Bitmap)
        ElseIf Pic = "16X4" Then
            Height = Me.pic_4_grp16X.Image.Height
            Width = Me.pic_4_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_4_grp16X.Image, Bitmap)
        ElseIf Pic = "16X5" Then
            Height = Me.pic_5_grp16X.Image.Height
            Width = Me.pic_5_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_5_grp16X.Image, Bitmap)
        ElseIf Pic = "16X6" Then
            Height = Me.pic_6_grp16X.Image.Height
            Width = Me.pic_6_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_6_grp16X.Image, Bitmap)
        ElseIf Pic = "16X7" Then
            Height = Me.pic_7_grp16X.Image.Height
            Width = Me.pic_7_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_7_grp16X.Image, Bitmap)
        ElseIf Pic = "16X8" Then
            Height = Me.pic_8_grp16X.Image.Height
            Width = Me.pic_8_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_8_grp16X.Image, Bitmap)
        ElseIf Pic = "16X9" Then
            Height = Me.pic_9_grp16X.Image.Height
            Width = Me.pic_9_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_9_grp16X.Image, Bitmap)
        ElseIf Pic = "16X10" Then
            Height = Me.pic_10_grp16X.Image.Height
            Width = Me.pic_10_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_10_grp16X.Image, Bitmap)
        ElseIf Pic = "16X11" Then
            Height = Me.pic_11_grp16X.Image.Height
            Width = Me.pic_11_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_11_grp16X.Image, Bitmap)
        ElseIf Pic = "16X12" Then
            Height = Me.pic_12_grp16X.Image.Height
            Width = Me.pic_12_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_12_grp16X.Image, Bitmap)
        ElseIf Pic = "16X13" Then
            Height = Me.pic_13_grp16X.Image.Height
            Width = Me.pic_13_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_13_grp16X.Image, Bitmap)
        ElseIf Pic = "16X14" Then
            Height = Me.pic_14_grp16X.Image.Height
            Width = Me.pic_14_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_14_grp16X.Image, Bitmap)
        ElseIf Pic = "16X15" Then
            Height = Me.pic_15_grp16X.Image.Height
            Width = Me.pic_15_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_15_grp16X.Image, Bitmap)
        ElseIf Pic = "16X16" Then
            Height = Me.pic_16_grp16X.Image.Height
            Width = Me.pic_16_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_16_grp16X.Image, Bitmap)
        ElseIf Pic = "18X1" Then
            Height = Me.pic_1_grpFullMouth.Image.Height
            Width = Me.pic_1_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_1_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X2" Then
            Height = Me.pic_2_grpFullMouth.Image.Height
            Width = Me.pic_2_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_2_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X3" Then
            Height = Me.pic_3_grpFullMouth.Image.Height
            Width = Me.pic_3_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_3_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X4" Then
            Height = Me.pic_4_grpFullMouth.Image.Height
            Width = Me.pic_4_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_4_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X5" Then
            Height = Me.pic_5_grpFullMouth.Image.Height
            Width = Me.pic_5_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_5_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X6" Then
            Height = Me.pic_6_grpFullMouth.Image.Height
            Width = Me.pic_6_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_6_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X7" Then
            Height = Me.pic_7_grpFullMouth.Image.Height
            Width = Me.pic_7_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_7_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X8" Then
            Height = Me.pic_8_grpFullMouth.Image.Height
            Width = Me.pic_8_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_8_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X9" Then
            Height = Me.pic_9_grpFullMouth.Image.Height
            Width = Me.pic_9_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_9_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X10" Then
            Height = Me.pic_10_grpFullMouth.Image.Height
            Width = Me.pic_10_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_10_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X11" Then
            Height = Me.pic_11_grpFullMouth.Image.Height
            Width = Me.pic_11_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_11_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X12" Then
            Height = Me.pic_12_grpFullMouth.Image.Height
            Width = Me.pic_12_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_12_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X13" Then
            Height = Me.pic_13_grpFullMouth.Image.Height
            Width = Me.pic_13_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_13_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X14" Then
            Height = Me.pic_14_grpFullMouth.Image.Height
            Width = Me.pic_14_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_14_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X15" Then
            Height = Me.pic_15_grpFullMouth.Image.Height
            Width = Me.pic_15_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_15_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X16" Then
            Height = Me.pic_16_grpFullMouth.Image.Height
            Width = Me.pic_16_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_16_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X17" Then
            Height = Me.pic_17_grpFullMouth.Image.Height
            Width = Me.pic_17_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_17_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X18" Then
            Height = Me.pic_18_grpFullMouth.Image.Height
            Width = Me.pic_18_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_18_grpFullMouth.Image, Bitmap)
        Else
            Exit Sub
        End If

        Dim img As New Bitmap(Width, Height)
        Dim pixel As Color
        'Laplasse template
        Dim Laplacian As Integer() = {-1, -1, -1, -1, 9, -1, _
         -1, -1, -1}
        For x As Integer = 1 To Width - 2
            For y As Integer = 1 To Height - 2
                Dim r As Integer = 0, g As Integer = 0, b As Integer = 0
                Dim Index As Integer = 0
                For col As Integer = -1 To 1
                    For row As Integer = -1 To 1
                        pixel = oldBitmap.GetPixel(x + row, y + col)
                        r += pixel.R * Laplacian(Index)
                        g += pixel.G * Laplacian(Index)
                        b += pixel.B * Laplacian(Index)
                        Index += 1
                    Next
                Next
                'Color value overflow
                r = If(r > 255, 255, r)
                r = If(r < 0, 0, r)
                g = If(g > 255, 255, g)
                g = If(g < 0, 0, g)
                b = If(b > 255, 255, b)
                b = If(b < 0, 0, b)
                img.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b))
            Next
        Next
        If Pic = "1X1" Then
            Pic_1_grp1X.Image = img
        ElseIf Pic = "2X1" Then
            pic_1_grp2X.Image = img
        ElseIf Pic = "2X2" Then
            pic_2_grp2X.Image = img
        ElseIf Pic = "4X1" Then
            Pic_1_grp4X.Image = img
        ElseIf Pic = "4X2" Then
            Pic_2_grp4X.Image = img
        ElseIf Pic = "4X3" Then
            Pic_3_grp4X.Image = img
        ElseIf Pic = "4X4" Then
            Pic_4_grp4X.Image = img
        ElseIf Pic = "9X1" Then
            pic_1_grp9x.Image = img
        ElseIf Pic = "9X2" Then
            pic_2_grp9x.Image = img
        ElseIf Pic = "9X3" Then
            pic_3_grp9x.Image = img
        ElseIf Pic = "9X4" Then
            pic_4_grp9x.Image = img
        ElseIf Pic = "9X5" Then
            pic_5_grp9x.Image = img
        ElseIf Pic = "9X6" Then
            pic_6_grp9x.Image = img
        ElseIf Pic = "9X7" Then
            pic_7_grp9x.Image = img
        ElseIf Pic = "9X8" Then
            pic_8_grp9x.Image = img
        ElseIf Pic = "9X9" Then
            pic_9_grp9x.Image = img
        ElseIf Pic = "16X1" Then
            pic_1_grp16X.Image = img
        ElseIf Pic = "16X2" Then
            pic_2_grp16X.Image = img
        ElseIf Pic = "16X3" Then
            pic_3_grp16X.Image = img
        ElseIf Pic = "16X4" Then
            pic_4_grp16X.Image = img
        ElseIf Pic = "16X5" Then
            pic_5_grp16X.Image = img
        ElseIf Pic = "16X6" Then
            pic_6_grp16X.Image = img
        ElseIf Pic = "16X7" Then
            pic_7_grp16X.Image = img
        ElseIf Pic = "16X8" Then
            pic_8_grp16X.Image = img
        ElseIf Pic = "16X9" Then
            pic_9_grp16X.Image = img
        ElseIf Pic = "16X10" Then
            pic_10_grp16X.Image = img
        ElseIf Pic = "16X11" Then
            pic_11_grp16X.Image = img
        ElseIf Pic = "16X12" Then
            pic_12_grp16X.Image = img
        ElseIf Pic = "16X13" Then
            pic_14_grp16X.Image = img
        ElseIf Pic = "16X14" Then
            pic_14_grp16X.Image = img
        ElseIf Pic = "16X15" Then
            pic_15_grp16X.Image = img
        ElseIf Pic = "16X16" Then
            pic_16_grp16X.Image = img
        ElseIf Pic = "18X1" Then
            pic_1_grpFullMouth.Image = img
        ElseIf Pic = "18X2" Then
            pic_2_grpFullMouth.Image = img
        ElseIf Pic = "18X3" Then
            pic_3_grpFullMouth.Image = img
        ElseIf Pic = "18X4" Then
            pic_4_grpFullMouth.Image = img
        ElseIf Pic = "18X5" Then
            pic_5_grpFullMouth.Image = img
        ElseIf Pic = "18X6" Then
            pic_6_grpFullMouth.Image = img
        ElseIf Pic = "18X7" Then
            pic_7_grpFullMouth.Image = img
        ElseIf Pic = "18X8" Then
            pic_8_grpFullMouth.Image = img
        ElseIf Pic = "18X9" Then
            pic_9_grpFullMouth.Image = img
        ElseIf Pic = "18X10" Then
            pic_10_grpFullMouth.Image = img
        ElseIf Pic = "18X11" Then
            pic_11_grpFullMouth.Image = img
        ElseIf Pic = "18X12" Then
            pic_12_grpFullMouth.Image = img
        ElseIf Pic = "18X13" Then
            pic_13_grpFullMouth.Image = img
        ElseIf Pic = "18X14" Then
            pic_14_grpFullMouth.Image = img
        ElseIf Pic = "18X15" Then
            pic_15_grpFullMouth.Image = img
        ElseIf Pic = "18X16" Then
            pic_16_grpFullMouth.Image = img
        ElseIf Pic = "18X17" Then
            pic_17_grpFullMouth.Image = img
        ElseIf Pic = "18X18" Then
            pic_18_grpFullMouth.Image = img
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SmoothenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmoothenToolStripMenuItem.Click
        If Pic = "" Then Pic = currentImage
        Me.Cursor = Cursors.WaitCursor
        Dim Height As Integer
        Dim Width As Integer
        Dim oldBitmap As Bitmap
        If Pic = "1X1" Then
            Height = Me.Pic_1_grp1X.Image.Height
            Width = Me.Pic_1_grp1X.Image.Width
            oldBitmap = DirectCast(Me.Pic_1_grp1X.Image, Bitmap)
        ElseIf Pic = "2X1" Then
            Height = Me.pic_1_grp2X.Image.Height
            Width = Me.pic_1_grp2X.Image.Width
            oldBitmap = DirectCast(Me.pic_1_grp2X.Image, Bitmap)
        ElseIf Pic = "2X2" Then
            Height = Me.pic_2_grp2X.Image.Height
            Width = Me.pic_2_grp2X.Image.Width
            oldBitmap = DirectCast(Me.pic_2_grp2X.Image, Bitmap)
        ElseIf Pic = "4X1" Then
            Height = Me.Pic_1_grp4X.Image.Height
            Width = Me.Pic_1_grp4X.Image.Width
            oldBitmap = DirectCast(Me.Pic_1_grp4X.Image, Bitmap)
        ElseIf Pic = "4X2" Then
            Height = Me.Pic_2_grp4X.Image.Height
            Width = Me.Pic_2_grp4X.Image.Width
            oldBitmap = DirectCast(Me.Pic_2_grp4X.Image, Bitmap)
        ElseIf Pic = "4X3" Then
            Height = Me.Pic_3_grp4X.Image.Height
            Width = Me.Pic_3_grp4X.Image.Width
            oldBitmap = DirectCast(Me.Pic_3_grp4X.Image, Bitmap)
        ElseIf Pic = "4X4" Then
            Height = Me.Pic_4_grp4X.Image.Height
            Width = Me.Pic_4_grp4X.Image.Width
            oldBitmap = DirectCast(Me.Pic_4_grp4X.Image, Bitmap)
        ElseIf Pic = "9X1" Then
            Height = Me.pic_1_grp9x.Image.Height
            Width = Me.pic_1_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_1_grp9x.Image, Bitmap)
        ElseIf Pic = "9X2" Then
            Height = Me.pic_2_grp9x.Image.Height
            Width = Me.pic_2_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_2_grp9x.Image, Bitmap)
        ElseIf Pic = "9X3" Then
            Height = Me.pic_3_grp9x.Image.Height
            Width = Me.pic_3_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_3_grp9x.Image, Bitmap)
        ElseIf Pic = "9X4" Then
            Height = Me.pic_4_grp9x.Image.Height
            Width = Me.pic_4_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_4_grp9x.Image, Bitmap)
        ElseIf Pic = "9X5" Then
            Height = Me.pic_5_grp9x.Image.Height
            Width = Me.pic_5_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_5_grp9x.Image, Bitmap)
        ElseIf Pic = "9X6" Then
            Height = Me.pic_6_grp9x.Image.Height
            Width = Me.pic_6_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_6_grp9x.Image, Bitmap)
        ElseIf Pic = "9X7" Then
            Height = Me.pic_7_grp9x.Image.Height
            Width = Me.pic_7_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_7_grp9x.Image, Bitmap)
        ElseIf Pic = "9X8" Then
            Height = Me.pic_8_grp9x.Image.Height
            Width = Me.pic_8_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_8_grp9x.Image, Bitmap)
        ElseIf Pic = "9X9" Then
            Height = Me.pic_9_grp9x.Image.Height
            Width = Me.pic_9_grp9x.Image.Width
            oldBitmap = DirectCast(Me.pic_9_grp9x.Image, Bitmap)
        ElseIf Pic = "16X1" Then
            Height = Me.pic_1_grp16X.Image.Height
            Width = Me.pic_1_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_1_grp16X.Image, Bitmap)
        ElseIf Pic = "16X2" Then
            Height = Me.pic_2_grp16X.Image.Height
            Width = Me.pic_2_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_2_grp16X.Image, Bitmap)
        ElseIf Pic = "16X3" Then
            Height = Me.pic_3_grp16X.Image.Height
            Width = Me.pic_3_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_3_grp16X.Image, Bitmap)
        ElseIf Pic = "16X4" Then
            Height = Me.pic_4_grp16X.Image.Height
            Width = Me.pic_4_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_4_grp16X.Image, Bitmap)
        ElseIf Pic = "16X5" Then
            Height = Me.pic_5_grp16X.Image.Height
            Width = Me.pic_5_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_5_grp16X.Image, Bitmap)
        ElseIf Pic = "16X6" Then
            Height = Me.pic_6_grp16X.Image.Height
            Width = Me.pic_6_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_6_grp16X.Image, Bitmap)
        ElseIf Pic = "16X7" Then
            Height = Me.pic_7_grp16X.Image.Height
            Width = Me.pic_7_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_7_grp16X.Image, Bitmap)
        ElseIf Pic = "16X8" Then
            Height = Me.pic_8_grp16X.Image.Height
            Width = Me.pic_8_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_8_grp16X.Image, Bitmap)
        ElseIf Pic = "16X9" Then
            Height = Me.pic_9_grp16X.Image.Height
            Width = Me.pic_9_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_9_grp16X.Image, Bitmap)
        ElseIf Pic = "16X10" Then
            Height = Me.pic_10_grp16X.Image.Height
            Width = Me.pic_10_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_10_grp16X.Image, Bitmap)
        ElseIf Pic = "16X11" Then
            Height = Me.pic_11_grp16X.Image.Height
            Width = Me.pic_11_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_11_grp16X.Image, Bitmap)
        ElseIf Pic = "16X12" Then
            Height = Me.pic_12_grp16X.Image.Height
            Width = Me.pic_12_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_12_grp16X.Image, Bitmap)
        ElseIf Pic = "16X13" Then
            Height = Me.pic_13_grp16X.Image.Height
            Width = Me.pic_13_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_13_grp16X.Image, Bitmap)
        ElseIf Pic = "16X14" Then
            Height = Me.pic_14_grp16X.Image.Height
            Width = Me.pic_14_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_14_grp16X.Image, Bitmap)
        ElseIf Pic = "16X15" Then
            Height = Me.pic_15_grp16X.Image.Height
            Width = Me.pic_15_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_15_grp16X.Image, Bitmap)
        ElseIf Pic = "16X16" Then
            Height = Me.pic_16_grp16X.Image.Height
            Width = Me.pic_16_grp16X.Image.Width
            oldBitmap = DirectCast(Me.pic_16_grp16X.Image, Bitmap)
        ElseIf Pic = "18X1" Then
            Height = Me.pic_1_grpFullMouth.Image.Height
            Width = Me.pic_1_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_1_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X2" Then
            Height = Me.pic_2_grpFullMouth.Image.Height
            Width = Me.pic_2_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_2_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X3" Then
            Height = Me.pic_3_grpFullMouth.Image.Height
            Width = Me.pic_3_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_3_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X4" Then
            Height = Me.pic_4_grpFullMouth.Image.Height
            Width = Me.pic_4_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_4_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X5" Then
            Height = Me.pic_5_grpFullMouth.Image.Height
            Width = Me.pic_5_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_5_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X6" Then
            Height = Me.pic_6_grpFullMouth.Image.Height
            Width = Me.pic_6_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_6_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X7" Then
            Height = Me.pic_7_grpFullMouth.Image.Height
            Width = Me.pic_7_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_7_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X8" Then
            Height = Me.pic_8_grpFullMouth.Image.Height
            Width = Me.pic_8_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_8_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X9" Then
            Height = Me.pic_9_grpFullMouth.Image.Height
            Width = Me.pic_9_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_9_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X10" Then
            Height = Me.pic_10_grpFullMouth.Image.Height
            Width = Me.pic_10_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_10_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X11" Then
            Height = Me.pic_11_grpFullMouth.Image.Height
            Width = Me.pic_11_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_11_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X12" Then
            Height = Me.pic_12_grpFullMouth.Image.Height
            Width = Me.pic_12_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_12_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X13" Then
            Height = Me.pic_13_grpFullMouth.Image.Height
            Width = Me.pic_13_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_13_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X14" Then
            Height = Me.pic_14_grpFullMouth.Image.Height
            Width = Me.pic_14_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_14_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X15" Then
            Height = Me.pic_15_grpFullMouth.Image.Height
            Width = Me.pic_15_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_15_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X16" Then
            Height = Me.pic_16_grpFullMouth.Image.Height
            Width = Me.pic_16_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_16_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X17" Then
            Height = Me.pic_17_grpFullMouth.Image.Height
            Width = Me.pic_17_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_17_grpFullMouth.Image, Bitmap)
        ElseIf Pic = "18X18" Then
            Height = Me.pic_18_grpFullMouth.Image.Height
            Width = Me.pic_18_grpFullMouth.Image.Width
            oldBitmap = DirectCast(Me.pic_18_grpFullMouth.Image, Bitmap)
        Else
            Exit Sub
        End If

        Dim img As New Bitmap(Width, Height)
        Dim pixel As Color
        'Gauss template
        Dim Gauss As Integer() = {1, 2, 1, 2, 4, 2, _
         1, 2, 1}
        For x As Integer = 1 To Width - 2
            For y As Integer = 1 To Height - 2
                Dim r As Integer = 0, g As Integer = 0, b As Integer = 0
                Dim Index As Integer = 0
                For col As Integer = -1 To 1
                    For row As Integer = -1 To 1
                        pixel = oldBitmap.GetPixel(x + row, y + col)
                        r += pixel.R * Gauss(Index)
                        g += pixel.G * Gauss(Index)
                        b += pixel.B * Gauss(Index)
                        Index += 1
                    Next
                Next
                r /= 16
                g /= 16
                b /= 16
                'Color value overflow
                r = If(r > 255, 255, r)
                r = If(r < 0, 0, r)
                g = If(g > 255, 255, g)
                g = If(g < 0, 0, g)
                b = If(b > 255, 255, b)
                b = If(b < 0, 0, b)
                img.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b))
            Next
        Next
        If Pic = "1X1" Then
            Pic_1_grp1X.Image = img
        ElseIf Pic = "2X1" Then
            pic_1_grp2X.Image = img
        ElseIf Pic = "2X2" Then
            pic_2_grp2X.Image = img
        ElseIf Pic = "4X1" Then
            Pic_1_grp4X.Image = img
        ElseIf Pic = "4X2" Then
            Pic_2_grp4X.Image = img
        ElseIf Pic = "4X3" Then
            Pic_3_grp4X.Image = img
        ElseIf Pic = "4X4" Then
            Pic_4_grp4X.Image = img
        ElseIf Pic = "9X1" Then
            pic_1_grp9x.Image = img
        ElseIf Pic = "9X2" Then
            pic_2_grp9x.Image = img
        ElseIf Pic = "9X3" Then
            pic_3_grp9x.Image = img
        ElseIf Pic = "9X4" Then
            pic_4_grp9x.Image = img
        ElseIf Pic = "9X5" Then
            pic_5_grp9x.Image = img
        ElseIf Pic = "9X6" Then
            pic_6_grp9x.Image = img
        ElseIf Pic = "9X7" Then
            pic_7_grp9x.Image = img
        ElseIf Pic = "9X8" Then
            pic_8_grp9x.Image = img
        ElseIf Pic = "9X9" Then
            pic_9_grp9x.Image = img
        ElseIf Pic = "16X1" Then
            pic_1_grp16X.Image = img
        ElseIf Pic = "16X2" Then
            pic_2_grp16X.Image = img
        ElseIf Pic = "16X3" Then
            pic_3_grp16X.Image = img
        ElseIf Pic = "16X4" Then
            pic_4_grp16X.Image = img
        ElseIf Pic = "16X5" Then
            pic_5_grp16X.Image = img
        ElseIf Pic = "16X6" Then
            pic_6_grp16X.Image = img
        ElseIf Pic = "16X7" Then
            pic_7_grp16X.Image = img
        ElseIf Pic = "16X8" Then
            pic_8_grp16X.Image = img
        ElseIf Pic = "16X9" Then
            pic_9_grp16X.Image = img
        ElseIf Pic = "16X10" Then
            pic_10_grp16X.Image = img
        ElseIf Pic = "16X11" Then
            pic_11_grp16X.Image = img
        ElseIf Pic = "16X12" Then
            pic_12_grp16X.Image = img
        ElseIf Pic = "16X13" Then
            pic_14_grp16X.Image = img
        ElseIf Pic = "16X14" Then
            pic_14_grp16X.Image = img
        ElseIf Pic = "16X15" Then
            pic_15_grp16X.Image = img
        ElseIf Pic = "16X16" Then
            pic_16_grp16X.Image = img
        ElseIf Pic = "18X1" Then
            pic_1_grpFullMouth.Image = img
        ElseIf Pic = "18X2" Then
            pic_2_grpFullMouth.Image = img
        ElseIf Pic = "18X3" Then
            pic_3_grpFullMouth.Image = img
        ElseIf Pic = "18X4" Then
            pic_4_grpFullMouth.Image = img
        ElseIf Pic = "18X5" Then
            pic_5_grpFullMouth.Image = img
        ElseIf Pic = "18X6" Then
            pic_6_grpFullMouth.Image = img
        ElseIf Pic = "18X7" Then
            pic_7_grpFullMouth.Image = img
        ElseIf Pic = "18X8" Then
            pic_8_grpFullMouth.Image = img
        ElseIf Pic = "18X9" Then
            pic_9_grpFullMouth.Image = img
        ElseIf Pic = "18X10" Then
            pic_10_grpFullMouth.Image = img
        ElseIf Pic = "18X11" Then
            pic_11_grpFullMouth.Image = img
        ElseIf Pic = "18X12" Then
            pic_12_grpFullMouth.Image = img
        ElseIf Pic = "18X13" Then
            pic_13_grpFullMouth.Image = img
        ElseIf Pic = "18X14" Then
            pic_14_grpFullMouth.Image = img
        ElseIf Pic = "18X15" Then
            pic_15_grpFullMouth.Image = img
        ElseIf Pic = "18X16" Then
            pic_16_grpFullMouth.Image = img
        ElseIf Pic = "18X17" Then
            pic_17_grpFullMouth.Image = img
        ElseIf Pic = "18X18" Then
            pic_18_grpFullMouth.Image = img
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        If Pic = "1X1" Then
            My.Computer.Clipboard.SetImage(Pic_1_grp1X.Image)
        ElseIf Pic = "2X1" Then
            My.Computer.Clipboard.SetImage(pic_1_grp2X.Image)
        ElseIf Pic = "2X2" Then
            My.Computer.Clipboard.SetImage(pic_2_grp2X.Image)
        ElseIf Pic = "4X1" Then
            My.Computer.Clipboard.SetImage(Pic_1_grp4X.Image)
        ElseIf Pic = "4X2" Then
            My.Computer.Clipboard.SetImage(Pic_2_grp4X.Image)
        ElseIf Pic = "4X3" Then
            My.Computer.Clipboard.SetImage(Pic_3_grp4X.Image)
        ElseIf Pic = "4X4" Then
            My.Computer.Clipboard.SetImage(Pic_4_grp4X.Image)
        ElseIf Pic = "9X1" Then
            My.Computer.Clipboard.SetImage(pic_1_grp9x.Image)
        ElseIf Pic = "9X2" Then
            My.Computer.Clipboard.SetImage(pic_2_grp9x.Image)
        ElseIf Pic = "9X3" Then
            My.Computer.Clipboard.SetImage(pic_3_grp9x.Image)
        ElseIf Pic = "9X4" Then
            My.Computer.Clipboard.SetImage(pic_4_grp9x.Image)
        ElseIf Pic = "9X5" Then
            My.Computer.Clipboard.SetImage(pic_5_grp9x.Image)
        ElseIf Pic = "9X6" Then
            My.Computer.Clipboard.SetImage(pic_6_grp9x.Image)
        ElseIf Pic = "9X7" Then
            My.Computer.Clipboard.SetImage(pic_7_grp9x.Image)
        ElseIf Pic = "9X8" Then
            My.Computer.Clipboard.SetImage(pic_8_grp9x.Image)
        ElseIf Pic = "9X9" Then
            My.Computer.Clipboard.SetImage(pic_9_grp9x.Image)
        ElseIf Pic = "16X1" Then
            My.Computer.Clipboard.SetImage(pic_1_grp16X.Image)
        ElseIf Pic = "16X2" Then
            My.Computer.Clipboard.SetImage(pic_2_grp16X.Image)
        ElseIf Pic = "16X3" Then
            My.Computer.Clipboard.SetImage(pic_3_grp16X.Image)
        ElseIf Pic = "16X4" Then
            My.Computer.Clipboard.SetImage(pic_4_grp16X.Image)
        ElseIf Pic = "16X5" Then
            My.Computer.Clipboard.SetImage(pic_5_grp16X.Image)
        ElseIf Pic = "16X6" Then
            My.Computer.Clipboard.SetImage(pic_6_grp16X.Image)
        ElseIf Pic = "16X7" Then
            My.Computer.Clipboard.SetImage(pic_7_grp16X.Image)
        ElseIf Pic = "16X8" Then
            My.Computer.Clipboard.SetImage(pic_8_grp16X.Image)
        ElseIf Pic = "16X9" Then
            My.Computer.Clipboard.SetImage(pic_9_grp16X.Image)
        ElseIf Pic = "16X10" Then
            My.Computer.Clipboard.SetImage(pic_10_grp16X.Image)
        ElseIf Pic = "16X11" Then
            My.Computer.Clipboard.SetImage(pic_11_grp16X.Image)
        ElseIf Pic = "16X12" Then
            My.Computer.Clipboard.SetImage(pic_12_grp16X.Image)
        ElseIf Pic = "16X13" Then
            My.Computer.Clipboard.SetImage(pic_13_grp16X.Image)
        ElseIf Pic = "16X14" Then
            My.Computer.Clipboard.SetImage(pic_14_grp16X.Image)
        ElseIf Pic = "16X15" Then
            My.Computer.Clipboard.SetImage(pic_15_grp16X.Image)
        ElseIf Pic = "16X16" Then
            My.Computer.Clipboard.SetImage(pic_16_grp16X.Image)
        ElseIf Pic = "18X1" Then
            My.Computer.Clipboard.SetImage(pic_1_grpFullMouth.Image)
        ElseIf Pic = "18X2" Then
            My.Computer.Clipboard.SetImage(pic_2_grpFullMouth.Image)
        ElseIf Pic = "18X3" Then
            My.Computer.Clipboard.SetImage(pic_3_grpFullMouth.Image)
        ElseIf Pic = "18X4" Then
            My.Computer.Clipboard.SetImage(pic_4_grpFullMouth.Image)
        ElseIf Pic = "18X5" Then
            My.Computer.Clipboard.SetImage(pic_5_grpFullMouth.Image)
        ElseIf Pic = "18X6" Then
            My.Computer.Clipboard.SetImage(pic_6_grpFullMouth.Image)
        ElseIf Pic = "18X7" Then
            My.Computer.Clipboard.SetImage(pic_7_grpFullMouth.Image)
        ElseIf Pic = "18X8" Then
            My.Computer.Clipboard.SetImage(pic_8_grpFullMouth.Image)
        ElseIf Pic = "18X9" Then
            My.Computer.Clipboard.SetImage(pic_9_grpFullMouth.Image)
        ElseIf Pic = "18X10" Then
            My.Computer.Clipboard.SetImage(pic_10_grpFullMouth.Image)
        ElseIf Pic = "18X11" Then
            My.Computer.Clipboard.SetImage(pic_11_grpFullMouth.Image)
        ElseIf Pic = "18X12" Then
            My.Computer.Clipboard.SetImage(pic_12_grpFullMouth.Image)
        ElseIf Pic = "18X13" Then
            My.Computer.Clipboard.SetImage(pic_13_grpFullMouth.Image)
        ElseIf Pic = "18X14" Then
            My.Computer.Clipboard.SetImage(pic_14_grpFullMouth.Image)
        ElseIf Pic = "18X15" Then
            My.Computer.Clipboard.SetImage(pic_15_grpFullMouth.Image)
        ElseIf Pic = "18X16" Then
            My.Computer.Clipboard.SetImage(pic_16_grpFullMouth.Image)
        ElseIf Pic = "18X17" Then
            My.Computer.Clipboard.SetImage(pic_17_grpFullMouth.Image)
        ElseIf Pic = "18X18" Then
            My.Computer.Clipboard.SetImage(pic_18_grpFullMouth.Image)
        Else
            MsgBox("Image Not Selected!")
            Exit Sub
        End If

        MsgBox("Copied!")
    End Sub

    Private Sub ExportProcessedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportProcessedToolStripMenuItem.Click
        If Pic = "" Then Pic = currentImage
        Dim sfd As New SaveFileDialog
        sfd.Filter = "Jpg Image|*.jpg|Bmp Image|*.bmp|Png Image|*.png"
        sfd.FileName = ""
        sfd.AddExtension = True 'Make sure the extension is added to the FileName
        If sfd.ShowDialog = DialogResult.OK Then 'If the user presses "Ok" button on the SaveFileDialog
            If Pic = "1X1" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    Pic_1_grp1X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    Pic_1_grp1X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    Pic_1_grp1X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "2X1" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_1_grp2X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_1_grp2X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_1_grp2X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "2X2" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_2_grp2X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_2_grp2X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_2_grp2X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "4X1" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    Pic_1_grp4X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    Pic_1_grp4X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    Pic_1_grp4X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "4X2" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    Pic_2_grp4X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    Pic_2_grp4X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    Pic_2_grp4X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "4X3" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    Pic_3_grp4X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    Pic_3_grp4X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    Pic_3_grp4X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "4X4" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    Pic_4_grp4X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    Pic_4_grp4X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    Pic_4_grp4X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "9X1" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_1_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_1_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_1_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "9X2" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_2_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_2_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_2_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "9X3" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_3_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_3_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_3_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "9X4" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_4_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_4_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_4_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "9X5" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_5_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_5_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_5_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "9X6" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_6_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_6_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_6_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "9X7" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_7_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_7_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_7_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "9X8" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_8_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_8_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_8_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "9X9" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_9_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_9_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_9_grp9x.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If

            ElseIf Pic = "16X1" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_1_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_1_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_1_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "16X2" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_2_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_2_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_2_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "16X3" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_3_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_3_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_3_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "16X4" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_4_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_4_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_4_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "16X5" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_5_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_5_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_5_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "16X6" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_6_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_6_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_6_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "16X7" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_7_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_7_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_7_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "16X8" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_8_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_8_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_8_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "16X9" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_9_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_9_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_9_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "16X10" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_10_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_10_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_10_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "16X11" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_11_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_11_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_11_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "16X12" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_12_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_12_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_12_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "16X13" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_13_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_13_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_13_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "16X14" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_14_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_14_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_14_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "16X15" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_15_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_15_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_15_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "16X16" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_16_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_16_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_16_grp16X.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If

            ElseIf Pic = "18X1" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_1_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_1_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_1_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X2" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_2_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_2_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_2_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X3" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_3_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_3_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_3_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X4" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_4_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_4_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_4_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X5" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_5_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_5_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_5_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X6" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_6_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_6_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_6_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X7" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_7_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_7_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_7_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X8" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_8_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_8_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_8_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X9" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_9_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_9_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_9_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X10" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_10_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_10_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_10_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X11" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_11_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_11_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_11_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X12" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_12_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_12_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_12_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X13" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_13_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_13_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_13_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X14" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_14_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_14_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_14_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X15" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_15_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_15_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_15_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X16" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_16_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_16_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_16_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X17" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_17_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_17_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_17_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            ElseIf Pic = "18X18" Then
                If sfd.FilterIndex = 1 Then 'If user picks the "Jpg Image" format
                    pic_18_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf sfd.FilterIndex = 2 Then 'If the user picks the "Bmp Image" format
                    pic_18_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                Else 'The user picked the "Png Image" format
                    pic_18_grpFullMouth.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                End If
            End If
            sfd.Dispose() 'Dispose the SaveFileDialog when no longer needed
            MsgBox("Modified Picture Saved Successfully!")
        End If
    End Sub

    Private Sub ResetAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetAllToolStripMenuItem.Click
        If Pic = "1X1" Then
            Pic_1_grp1X.ImageLocation = path
        ElseIf Pic = "2X1" Then
            pic_1_grp2X.ImageLocation = path
        ElseIf Pic = "2X2" Then
            pic_2_grp2X.ImageLocation = path
        ElseIf Pic = "4X1" Then
            Pic_1_grp4X.ImageLocation = path
        ElseIf Pic = "4X2" Then
            Pic_2_grp4X.ImageLocation = path
        ElseIf Pic = "4X3" Then
            Pic_3_grp4X.ImageLocation = path
        ElseIf Pic = "4X4" Then
            Pic_4_grp4X.ImageLocation = path
        ElseIf Pic = "9X1" Then
            pic_1_grp9x.ImageLocation = path
        ElseIf Pic = "9X2" Then
            pic_2_grp9x.ImageLocation = path
        ElseIf Pic = "9X3" Then
            pic_3_grp9x.ImageLocation = path
        ElseIf Pic = "9X4" Then
            pic_4_grp9x.ImageLocation = path
        ElseIf Pic = "9X5" Then
            pic_5_grp9x.ImageLocation = path
        ElseIf Pic = "9X6" Then
            pic_6_grp9x.ImageLocation = path
        ElseIf Pic = "9X7" Then
            pic_7_grp9x.ImageLocation = path
        ElseIf Pic = "9X8" Then
            pic_8_grp9x.ImageLocation = path
        ElseIf Pic = "9X9" Then
            pic_9_grp9x.ImageLocation = path
        ElseIf Pic = "16X1" Then
            pic_1_grp16X.ImageLocation = path
        ElseIf Pic = "16X2" Then
            pic_2_grp16X.ImageLocation = path
        ElseIf Pic = "16X3" Then
            pic_3_grp16X.ImageLocation = path
        ElseIf Pic = "16X4" Then
            pic_4_grp16X.ImageLocation = path
        ElseIf Pic = "16X5" Then
            pic_5_grp16X.ImageLocation = path
        ElseIf Pic = "16X6" Then
            pic_6_grp16X.ImageLocation = path
        ElseIf Pic = "16X7" Then
            pic_7_grp16X.ImageLocation = path
        ElseIf Pic = "16X8" Then
            pic_8_grp16X.ImageLocation = path
        ElseIf Pic = "16X9" Then
            pic_9_grp16X.ImageLocation = path
        ElseIf Pic = "16X10" Then
            pic_10_grp16X.ImageLocation = path
        ElseIf Pic = "16X11" Then
            pic_11_grp16X.ImageLocation = path
        ElseIf Pic = "16X12" Then
            pic_12_grp16X.ImageLocation = path
        ElseIf Pic = "16X13" Then
            pic_13_grp16X.ImageLocation = path
        ElseIf Pic = "16X14" Then
            pic_14_grp16X.ImageLocation = path
        ElseIf Pic = "16X15" Then
            pic_15_grp16X.ImageLocation = path
        ElseIf Pic = "16X16" Then
            pic_16_grp16X.ImageLocation = path
        ElseIf Pic = "18X1" Then
            pic_1_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X2" Then
            pic_2_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X3" Then
            pic_3_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X4" Then
            pic_4_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X5" Then
            pic_5_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X6" Then
            pic_6_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X7" Then
            pic_7_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X8" Then
            pic_8_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X9" Then
            pic_9_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X10" Then
            pic_10_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X11" Then
            pic_11_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X12" Then
            pic_12_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X13" Then
            pic_13_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X14" Then
            pic_14_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X15" Then
            pic_15_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X16" Then
            pic_16_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X17" Then
            pic_17_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X18" Then
            pic_18_grpFullMouth.ImageLocation = path
        Else
            MsgBox("Image Not Selected!")
            Exit Sub
        End If
    End Sub

    Private Sub ResetAllToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetAllToolStripMenuItem1.Click
        If Pic = "1X1" Then
            Pic_1_grp1X.ImageLocation = path
        ElseIf Pic = "2X1" Then
            pic_1_grp2X.ImageLocation = path
        ElseIf Pic = "2X2" Then
            pic_2_grp2X.ImageLocation = path
        ElseIf Pic = "4X1" Then
            Pic_1_grp4X.ImageLocation = path
        ElseIf Pic = "4X2" Then
            Pic_2_grp4X.ImageLocation = path
        ElseIf Pic = "4X3" Then
            Pic_3_grp4X.ImageLocation = path
        ElseIf Pic = "4X4" Then
            Pic_4_grp4X.ImageLocation = path
        ElseIf Pic = "9X1" Then
            pic_1_grp9x.ImageLocation = path
        ElseIf Pic = "9X2" Then
            pic_2_grp9x.ImageLocation = path
        ElseIf Pic = "9X3" Then
            pic_3_grp9x.ImageLocation = path
        ElseIf Pic = "9X4" Then
            pic_4_grp9x.ImageLocation = path
        ElseIf Pic = "9X5" Then
            pic_5_grp9x.ImageLocation = path
        ElseIf Pic = "9X6" Then
            pic_6_grp9x.ImageLocation = path
        ElseIf Pic = "9X7" Then
            pic_7_grp9x.ImageLocation = path
        ElseIf Pic = "9X8" Then
            pic_8_grp9x.ImageLocation = path
        ElseIf Pic = "9X9" Then
            pic_9_grp9x.ImageLocation = path
        ElseIf Pic = "16X1" Then
            pic_1_grp16X.ImageLocation = path
        ElseIf Pic = "16X2" Then
            pic_2_grp16X.ImageLocation = path
        ElseIf Pic = "16X3" Then
            pic_3_grp16X.ImageLocation = path
        ElseIf Pic = "16X4" Then
            pic_4_grp16X.ImageLocation = path
        ElseIf Pic = "16X5" Then
            pic_5_grp16X.ImageLocation = path
        ElseIf Pic = "16X6" Then
            pic_6_grp16X.ImageLocation = path
        ElseIf Pic = "16X7" Then
            pic_7_grp16X.ImageLocation = path
        ElseIf Pic = "16X8" Then
            pic_8_grp16X.ImageLocation = path
        ElseIf Pic = "16X9" Then
            pic_9_grp16X.ImageLocation = path
        ElseIf Pic = "16X10" Then
            pic_10_grp16X.ImageLocation = path
        ElseIf Pic = "16X11" Then
            pic_11_grp16X.ImageLocation = path
        ElseIf Pic = "16X12" Then
            pic_12_grp16X.ImageLocation = path
        ElseIf Pic = "16X13" Then
            pic_13_grp16X.ImageLocation = path
        ElseIf Pic = "16X14" Then
            pic_14_grp16X.ImageLocation = path
        ElseIf Pic = "16X15" Then
            pic_15_grp16X.ImageLocation = path
        ElseIf Pic = "16X16" Then
            pic_16_grp16X.ImageLocation = path
        ElseIf Pic = "18X1" Then
            pic_1_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X2" Then
            pic_2_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X3" Then
            pic_3_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X4" Then
            pic_4_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X5" Then
            pic_5_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X6" Then
            pic_6_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X7" Then
            pic_7_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X8" Then
            pic_8_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X9" Then
            pic_9_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X10" Then
            pic_10_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X11" Then
            pic_11_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X12" Then
            pic_12_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X13" Then
            pic_13_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X14" Then
            pic_14_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X15" Then
            pic_15_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X16" Then
            pic_16_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X17" Then
            pic_17_grpFullMouth.ImageLocation = path
        ElseIf Pic = "18X18" Then
            pic_18_grpFullMouth.ImageLocation = path
        Else
            MsgBox("Image Not Selected!")
            Exit Sub
        End If
    End Sub

    Private Sub DuplicateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DuplicateToolStripMenuItem.Click
        'Dim ObjClass As New ClassFunctions()
        'Dim folder As String = ""
        'Dim FullPath As String = ""
        'folder = ObjClass.ReturnFieldName("select ptReg_code from Master_ptReg where ptReg_id='" & PatientId & "'")
        'Dim path As String = Application.StartupPath & "\Images\" & folder
        'If Not Directory.Exists(path) Then
        '    Directory.CreateDirectory(path)
        'End If
        'folder = folder & "_" & Format(Date.Now, "ddMMyyyyhhmmss") & ".jpg"

        'FullPath = path & "\" & folder
        'Dim DispName As String
        'Dim count As Integer = 0

        'Dim dt As New DataTable()
        'dt = ObjClass.returndatatable("select * from patient_Image where image_path='" & pic_1_grp2X.Tag & "' and image_ptregid='" & PatientId & "'", dt)
        'Dim dtpday As Date = System.IO.File.GetLastWriteTime(path & "\" & pic_1_grp2X.Tag).ToShortDateString()
        'count = ObjClass.Returnsinglevalue("select count(*) from Patient_Image where Image_ptRegId='" & PatientId & "'")
        'DispName = "E" & count + 1
        'ObjClass.ExecuteQuery("insert into Patient_Image values('" & ObjClass.getIndexKey() & "','" & PatientId & "','" & folder & "','','" & Format(dtpday, "yyyy-MM-dd") & "','" & Teeth.Text & "','" & DispName & "','0','0','0')")


        'If Pic = "1X1" Then

        'ElseIf Pic = "2X1" Then
        '    pic_1_grp2X.Image.Save(path & "\" & folder, System.Drawing.Imaging.ImageFormat.Jpeg)
        'ElseIf Pic = "2X2" Then
        '    pic_2_grp2X.Image.Save(path & "\" & folder, System.Drawing.Imaging.ImageFormat.Jpeg)
        'ElseIf Pic = "4X1" Then

        'ElseIf Pic = "4X2" Then

        'ElseIf Pic = "4X3" Then

        'ElseIf Pic = "4X4" Then

        'ElseIf Pic = "9X1" Then

        'ElseIf Pic = "9X2" Then

        'ElseIf Pic = "9X3" Then

        'ElseIf Pic = "9X4" Then

        'ElseIf Pic = "9X5" Then

        'ElseIf Pic = "9X6" Then

        'ElseIf Pic = "9X7" Then

        'ElseIf Pic = "9X8" Then

        'ElseIf Pic = "9X9" Then

        'ElseIf Pic = "16X1" Then

        'ElseIf Pic = "16X2" Then

        'ElseIf Pic = "16X3" Then

        'ElseIf Pic = "16X4" Then

        'ElseIf Pic = "16X5" Then

        'ElseIf Pic = "16X6" Then

        'ElseIf Pic = "16X7" Then

        'ElseIf Pic = "16X8" Then

        'ElseIf Pic = "16X9" Then

        'ElseIf Pic = "16X10" Then

        'ElseIf Pic = "16X11" Then

        'ElseIf Pic = "16X12" Then

        'ElseIf Pic = "16X13" Then

        'ElseIf Pic = "16X14" Then

        'ElseIf Pic = "16X15" Then

        'ElseIf Pic = "16X16" Then

        'ElseIf Pic = "18X1" Then

        'ElseIf Pic = "18X2" Then

        'ElseIf Pic = "18X3" Then

        'ElseIf Pic = "18X4" Then

        'ElseIf Pic = "18X5" Then

        'ElseIf Pic = "18X6" Then

        'ElseIf Pic = "18X7" Then

        'ElseIf Pic = "18X8" Then

        'ElseIf Pic = "18X9" Then

        'ElseIf Pic = "18X10" Then

        'ElseIf Pic = "18X11" Then

        'ElseIf Pic = "18X12" Then

        'ElseIf Pic = "18X13" Then

        'ElseIf Pic = "18X14" Then

        'ElseIf Pic = "18X15" Then

        'ElseIf Pic = "18X16" Then

        'ElseIf Pic = "18X17" Then

        'ElseIf Pic = "18X18" Then

        'Else
        '    MsgBox("Image Not Selected!")
        '    Exit Sub
        'End If
        'Call FillDetails()
        'pic_2_grp2X.ImageLocation = path & "\" & folder
    End Sub

    Private Sub Measure_Text_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Measure_Text.Click
        measure = "T"
    End Sub

    Private Sub Measure_Move_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Measure_Move.Click
        measure = "M"
    End Sub
End Class