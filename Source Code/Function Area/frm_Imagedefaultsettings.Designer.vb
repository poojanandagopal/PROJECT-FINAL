<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Imagedefaultsettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkImgScalefactor = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumUpDContrast = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NumUpDBrightness = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        CType(Me.NumUpDContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDBrightness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 33)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ignore image scalefactor:"
        '
        'chkImgScalefactor
        '
        Me.chkImgScalefactor.AutoSize = True
        Me.chkImgScalefactor.Checked = True
        Me.chkImgScalefactor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImgScalefactor.Location = New System.Drawing.Point(220, 33)
        Me.chkImgScalefactor.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkImgScalefactor.Name = "chkImgScalefactor"
        Me.chkImgScalefactor.Size = New System.Drawing.Size(15, 14)
        Me.chkImgScalefactor.TabIndex = 1
        Me.chkImgScalefactor.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(145, 68)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Contrast:"
        '
        'NumUpDContrast
        '
        Me.NumUpDContrast.Location = New System.Drawing.Point(220, 67)
        Me.NumUpDContrast.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.NumUpDContrast.Name = "NumUpDContrast"
        Me.NumUpDContrast.Size = New System.Drawing.Size(101, 22)
        Me.NumUpDContrast.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(133, 107)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Brightness:"
        '
        'NumUpDBrightness
        '
        Me.NumUpDBrightness.Location = New System.Drawing.Point(220, 105)
        Me.NumUpDBrightness.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.NumUpDBrightness.Name = "NumUpDBrightness"
        Me.NumUpDBrightness.Size = New System.Drawing.Size(101, 22)
        Me.NumUpDBrightness.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(147, 146)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Sharpen:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(136, 185)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 14)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Smoothen:"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(439, 65)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(125, 25)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "OK"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(439, 96)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(125, 25)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "Cancel"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(439, 129)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(125, 25)
        Me.Button6.TabIndex = 11
        Me.Button6.Text = "Help"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'frm_Imagedefaultsettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 256)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NumUpDBrightness)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumUpDContrast)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkImgScalefactor)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frm_Imagedefaultsettings"
        Me.Text = "Edit Default image settings"
        CType(Me.NumUpDContrast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDBrightness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkImgScalefactor As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumUpDContrast As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NumUpDBrightness As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
End Class
