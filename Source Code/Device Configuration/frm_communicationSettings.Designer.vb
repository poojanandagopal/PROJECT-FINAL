<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_communicationSettings
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chkreceivedlist = New System.Windows.Forms.CheckBox()
        Me.chkdisplaymsg = New System.Windows.Forms.CheckBox()
        Me.btnConfig1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbreceive_Interestate = New System.Windows.Forms.RadioButton()
        Me.rbreceive_Direct = New System.Windows.Forms.RadioButton()
        Me.rbreceive_MAPI = New System.Windows.Forms.RadioButton()
        Me.btnConfig = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbsend_Interestate = New System.Windows.Forms.RadioButton()
        Me.rbsend_Direct = New System.Windows.Forms.RadioButton()
        Me.rbsend_MAPI = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkDiagnose = New System.Windows.Forms.CheckBox()
        Me.chkPtNotes = New System.Windows.Forms.CheckBox()
        Me.chkEmail = New System.Windows.Forms.CheckBox()
        Me.chkGender = New System.Windows.Forms.CheckBox()
        Me.chkAddress = New System.Windows.Forms.CheckBox()
        Me.chkTelephone = New System.Windows.Forms.CheckBox()
        Me.chkFax = New System.Windows.Forms.CheckBox()
        Me.chkBirthDate = New System.Windows.Forms.CheckBox()
        Me.chkPtName = New System.Windows.Forms.CheckBox()
        Me.chkSSNNo = New System.Windows.Forms.CheckBox()
        Me.chkPatientID = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbCtakt = New System.Windows.Forms.RadioButton()
        Me.rbVisiQuickformat_secure = New System.Windows.Forms.RadioButton()
        Me.rbVisiQuickformat = New System.Windows.Forms.RadioButton()
        Me.rbSinglefiles_processed = New System.Windows.Forms.RadioButton()
        Me.rbSinglefiles_orginal = New System.Windows.Forms.RadioButton()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDisplayName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAddressBook = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(1, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(837, 467)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkreceivedlist)
        Me.TabPage1.Controls.Add(Me.chkdisplaymsg)
        Me.TabPage1.Controls.Add(Me.btnConfig1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.btnConfig)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(829, 440)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "E-mail"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkreceivedlist
        '
        Me.chkreceivedlist.AutoSize = True
        Me.chkreceivedlist.Location = New System.Drawing.Point(17, 270)
        Me.chkreceivedlist.Name = "chkreceivedlist"
        Me.chkreceivedlist.Size = New System.Drawing.Size(233, 18)
        Me.chkreceivedlist.TabIndex = 5
        Me.chkreceivedlist.Text = "Open received list after receiving"
        Me.chkreceivedlist.UseVisualStyleBackColor = True
        '
        'chkdisplaymsg
        '
        Me.chkdisplaymsg.AutoSize = True
        Me.chkdisplaymsg.Location = New System.Drawing.Point(17, 246)
        Me.chkdisplaymsg.Name = "chkdisplaymsg"
        Me.chkdisplaymsg.Size = New System.Drawing.Size(215, 18)
        Me.chkdisplaymsg.TabIndex = 4
        Me.chkdisplaymsg.Text = "Display message after receive"
        Me.chkdisplaymsg.UseVisualStyleBackColor = True
        '
        'btnConfig1
        '
        Me.btnConfig1.Location = New System.Drawing.Point(391, 139)
        Me.btnConfig1.Name = "btnConfig1"
        Me.btnConfig1.Size = New System.Drawing.Size(94, 32)
        Me.btnConfig1.TabIndex = 3
        Me.btnConfig1.Text = "Configure..."
        Me.btnConfig1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbreceive_Interestate)
        Me.GroupBox2.Controls.Add(Me.rbreceive_Direct)
        Me.GroupBox2.Controls.Add(Me.rbreceive_MAPI)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 131)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(360, 81)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Method for receiving e-mails"
        '
        'rbreceive_Interestate
        '
        Me.rbreceive_Interestate.AutoSize = True
        Me.rbreceive_Interestate.Location = New System.Drawing.Point(169, 18)
        Me.rbreceive_Interestate.Name = "rbreceive_Interestate"
        Me.rbreceive_Interestate.Size = New System.Drawing.Size(125, 18)
        Me.rbreceive_Interestate.TabIndex = 2
        Me.rbreceive_Interestate.TabStop = True
        Me.rbreceive_Interestate.Text = "Interestate Mail"
        Me.rbreceive_Interestate.UseVisualStyleBackColor = True
        '
        'rbreceive_Direct
        '
        Me.rbreceive_Direct.AutoSize = True
        Me.rbreceive_Direct.Location = New System.Drawing.Point(6, 48)
        Me.rbreceive_Direct.Name = "rbreceive_Direct"
        Me.rbreceive_Direct.Size = New System.Drawing.Size(135, 18)
        Me.rbreceive_Direct.TabIndex = 1
        Me.rbreceive_Direct.TabStop = True
        Me.rbreceive_Direct.Text = "Direct(POP/SMTP)"
        Me.rbreceive_Direct.UseVisualStyleBackColor = True
        '
        'rbreceive_MAPI
        '
        Me.rbreceive_MAPI.AutoSize = True
        Me.rbreceive_MAPI.Location = New System.Drawing.Point(3, 18)
        Me.rbreceive_MAPI.Name = "rbreceive_MAPI"
        Me.rbreceive_MAPI.Size = New System.Drawing.Size(149, 18)
        Me.rbreceive_MAPI.TabIndex = 0
        Me.rbreceive_MAPI.TabStop = True
        Me.rbreceive_MAPI.Text = "MAPI(MS Exchange)"
        Me.rbreceive_MAPI.UseVisualStyleBackColor = True
        '
        'btnConfig
        '
        Me.btnConfig.Location = New System.Drawing.Point(391, 27)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(94, 32)
        Me.btnConfig.TabIndex = 1
        Me.btnConfig.Text = "Configure..."
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbsend_Interestate)
        Me.GroupBox1.Controls.Add(Me.rbsend_Direct)
        Me.GroupBox1.Controls.Add(Me.rbsend_MAPI)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 81)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Method for sending e-mails"
        '
        'rbsend_Interestate
        '
        Me.rbsend_Interestate.AutoSize = True
        Me.rbsend_Interestate.Location = New System.Drawing.Point(169, 18)
        Me.rbsend_Interestate.Name = "rbsend_Interestate"
        Me.rbsend_Interestate.Size = New System.Drawing.Size(125, 18)
        Me.rbsend_Interestate.TabIndex = 2
        Me.rbsend_Interestate.TabStop = True
        Me.rbsend_Interestate.Text = "Interestate Mail"
        Me.rbsend_Interestate.UseVisualStyleBackColor = True
        '
        'rbsend_Direct
        '
        Me.rbsend_Direct.AutoSize = True
        Me.rbsend_Direct.Location = New System.Drawing.Point(6, 48)
        Me.rbsend_Direct.Name = "rbsend_Direct"
        Me.rbsend_Direct.Size = New System.Drawing.Size(135, 18)
        Me.rbsend_Direct.TabIndex = 1
        Me.rbsend_Direct.TabStop = True
        Me.rbsend_Direct.Text = "Direct(POP/SMTP)"
        Me.rbsend_Direct.UseVisualStyleBackColor = True
        '
        'rbsend_MAPI
        '
        Me.rbsend_MAPI.AutoSize = True
        Me.rbsend_MAPI.Location = New System.Drawing.Point(3, 18)
        Me.rbsend_MAPI.Name = "rbsend_MAPI"
        Me.rbsend_MAPI.Size = New System.Drawing.Size(149, 18)
        Me.rbsend_MAPI.TabIndex = 0
        Me.rbsend_MAPI.TabStop = True
        Me.rbsend_MAPI.Text = "MAPI(MS Exchange)"
        Me.rbsend_MAPI.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.txtEmail)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.txtDisplayName)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.btnAddressBook)
        Me.TabPage2.Controls.Add(Me.btnDelete)
        Me.TabPage2.Controls.Add(Me.btnAdd)
        Me.TabPage2.Controls.Add(Me.ListBox1)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(829, 440)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Address book"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkDiagnose)
        Me.GroupBox4.Controls.Add(Me.chkPtNotes)
        Me.GroupBox4.Controls.Add(Me.chkEmail)
        Me.GroupBox4.Controls.Add(Me.chkGender)
        Me.GroupBox4.Controls.Add(Me.chkAddress)
        Me.GroupBox4.Controls.Add(Me.chkTelephone)
        Me.GroupBox4.Controls.Add(Me.chkFax)
        Me.GroupBox4.Controls.Add(Me.chkBirthDate)
        Me.GroupBox4.Controls.Add(Me.chkPtName)
        Me.GroupBox4.Controls.Add(Me.chkSSNNo)
        Me.GroupBox4.Controls.Add(Me.chkPatientID)
        Me.GroupBox4.Location = New System.Drawing.Point(561, 144)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(218, 259)
        Me.GroupBox4.TabIndex = 32
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Send this data"
        '
        'chkDiagnose
        '
        Me.chkDiagnose.AutoSize = True
        Me.chkDiagnose.Location = New System.Drawing.Point(17, 216)
        Me.chkDiagnose.Name = "chkDiagnose"
        Me.chkDiagnose.Size = New System.Drawing.Size(85, 18)
        Me.chkDiagnose.TabIndex = 10
        Me.chkDiagnose.Text = "Diagnose"
        Me.chkDiagnose.UseVisualStyleBackColor = True
        '
        'chkPtNotes
        '
        Me.chkPtNotes.AutoSize = True
        Me.chkPtNotes.Location = New System.Drawing.Point(17, 196)
        Me.chkPtNotes.Name = "chkPtNotes"
        Me.chkPtNotes.Size = New System.Drawing.Size(111, 18)
        Me.chkPtNotes.TabIndex = 9
        Me.chkPtNotes.Text = "Patient notes"
        Me.chkPtNotes.UseVisualStyleBackColor = True
        '
        'chkEmail
        '
        Me.chkEmail.AutoSize = True
        Me.chkEmail.Location = New System.Drawing.Point(17, 177)
        Me.chkEmail.Name = "chkEmail"
        Me.chkEmail.Size = New System.Drawing.Size(64, 18)
        Me.chkEmail.TabIndex = 8
        Me.chkEmail.Text = "E-mail"
        Me.chkEmail.UseVisualStyleBackColor = True
        '
        'chkGender
        '
        Me.chkGender.AutoSize = True
        Me.chkGender.Location = New System.Drawing.Point(17, 101)
        Me.chkGender.Name = "chkGender"
        Me.chkGender.Size = New System.Drawing.Size(72, 18)
        Me.chkGender.TabIndex = 7
        Me.chkGender.Text = "Gender"
        Me.chkGender.UseVisualStyleBackColor = True
        '
        'chkAddress
        '
        Me.chkAddress.AutoSize = True
        Me.chkAddress.Location = New System.Drawing.Point(17, 119)
        Me.chkAddress.Name = "chkAddress"
        Me.chkAddress.Size = New System.Drawing.Size(77, 18)
        Me.chkAddress.TabIndex = 6
        Me.chkAddress.Text = "Address"
        Me.chkAddress.UseVisualStyleBackColor = True
        '
        'chkTelephone
        '
        Me.chkTelephone.AutoSize = True
        Me.chkTelephone.Location = New System.Drawing.Point(17, 138)
        Me.chkTelephone.Name = "chkTelephone"
        Me.chkTelephone.Size = New System.Drawing.Size(92, 18)
        Me.chkTelephone.TabIndex = 5
        Me.chkTelephone.Text = "Telephone"
        Me.chkTelephone.UseVisualStyleBackColor = True
        '
        'chkFax
        '
        Me.chkFax.AutoSize = True
        Me.chkFax.Location = New System.Drawing.Point(17, 158)
        Me.chkFax.Name = "chkFax"
        Me.chkFax.Size = New System.Drawing.Size(48, 18)
        Me.chkFax.TabIndex = 4
        Me.chkFax.Text = "Fax"
        Me.chkFax.UseVisualStyleBackColor = True
        '
        'chkBirthDate
        '
        Me.chkBirthDate.AutoSize = True
        Me.chkBirthDate.Location = New System.Drawing.Point(17, 83)
        Me.chkBirthDate.Name = "chkBirthDate"
        Me.chkBirthDate.Size = New System.Drawing.Size(88, 18)
        Me.chkBirthDate.TabIndex = 3
        Me.chkBirthDate.Text = "Birth date"
        Me.chkBirthDate.UseVisualStyleBackColor = True
        '
        'chkPtName
        '
        Me.chkPtName.AutoSize = True
        Me.chkPtName.Location = New System.Drawing.Point(17, 64)
        Me.chkPtName.Name = "chkPtName"
        Me.chkPtName.Size = New System.Drawing.Size(110, 18)
        Me.chkPtName.TabIndex = 2
        Me.chkPtName.Text = "Patient name"
        Me.chkPtName.UseVisualStyleBackColor = True
        '
        'chkSSNNo
        '
        Me.chkSSNNo.AutoSize = True
        Me.chkSSNNo.Location = New System.Drawing.Point(17, 44)
        Me.chkSSNNo.Name = "chkSSNNo"
        Me.chkSSNNo.Size = New System.Drawing.Size(103, 18)
        Me.chkSSNNo.TabIndex = 1
        Me.chkSSNNo.Text = "SSN number"
        Me.chkSSNNo.UseVisualStyleBackColor = True
        '
        'chkPatientID
        '
        Me.chkPatientID.AutoSize = True
        Me.chkPatientID.Location = New System.Drawing.Point(17, 25)
        Me.chkPatientID.Name = "chkPatientID"
        Me.chkPatientID.Size = New System.Drawing.Size(90, 18)
        Me.chkPatientID.TabIndex = 0
        Me.chkPatientID.Text = "Patient-ID"
        Me.chkPatientID.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbCtakt)
        Me.GroupBox3.Controls.Add(Me.rbVisiQuickformat_secure)
        Me.GroupBox3.Controls.Add(Me.rbVisiQuickformat)
        Me.GroupBox3.Controls.Add(Me.rbSinglefiles_processed)
        Me.GroupBox3.Controls.Add(Me.rbSinglefiles_orginal)
        Me.GroupBox3.Location = New System.Drawing.Point(315, 246)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(227, 118)
        Me.GroupBox3.TabIndex = 31
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Send-format"
        '
        'rbCtakt
        '
        Me.rbCtakt.AutoSize = True
        Me.rbCtakt.Location = New System.Drawing.Point(3, 93)
        Me.rbCtakt.Name = "rbCtakt"
        Me.rbCtakt.Size = New System.Drawing.Size(64, 18)
        Me.rbCtakt.TabIndex = 4
        Me.rbCtakt.TabStop = True
        Me.rbCtakt.Text = "C-takt"
        Me.rbCtakt.UseVisualStyleBackColor = True
        '
        'rbVisiQuickformat_secure
        '
        Me.rbVisiQuickformat_secure.AutoSize = True
        Me.rbVisiQuickformat_secure.Location = New System.Drawing.Point(3, 74)
        Me.rbVisiQuickformat_secure.Name = "rbVisiQuickformat_secure"
        Me.rbVisiQuickformat_secure.Size = New System.Drawing.Size(188, 18)
        Me.rbVisiQuickformat_secure.TabIndex = 3
        Me.rbVisiQuickformat_secure.TabStop = True
        Me.rbVisiQuickformat_secure.Text = "LynxVision format(secure)"
        Me.rbVisiQuickformat_secure.UseVisualStyleBackColor = True
        '
        'rbVisiQuickformat
        '
        Me.rbVisiQuickformat.AutoSize = True
        Me.rbVisiQuickformat.Location = New System.Drawing.Point(3, 55)
        Me.rbVisiQuickformat.Name = "rbVisiQuickformat"
        Me.rbVisiQuickformat.Size = New System.Drawing.Size(136, 18)
        Me.rbVisiQuickformat.TabIndex = 2
        Me.rbVisiQuickformat.TabStop = True
        Me.rbVisiQuickformat.Text = "LynxVision format"
        Me.rbVisiQuickformat.UseVisualStyleBackColor = True
        '
        'rbSinglefiles_processed
        '
        Me.rbSinglefiles_processed.AutoSize = True
        Me.rbSinglefiles_processed.Location = New System.Drawing.Point(3, 36)
        Me.rbSinglefiles_processed.Name = "rbSinglefiles_processed"
        Me.rbSinglefiles_processed.Size = New System.Drawing.Size(167, 18)
        Me.rbSinglefiles_processed.TabIndex = 1
        Me.rbSinglefiles_processed.TabStop = True
        Me.rbSinglefiles_processed.Text = "Single files(processed)"
        Me.rbSinglefiles_processed.UseVisualStyleBackColor = True
        '
        'rbSinglefiles_orginal
        '
        Me.rbSinglefiles_orginal.AutoSize = True
        Me.rbSinglefiles_orginal.Location = New System.Drawing.Point(3, 18)
        Me.rbSinglefiles_orginal.Name = "rbSinglefiles_orginal"
        Me.rbSinglefiles_orginal.Size = New System.Drawing.Size(145, 18)
        Me.rbSinglefiles_orginal.TabIndex = 0
        Me.rbSinglefiles_orginal.TabStop = True
        Me.rbSinglefiles_orginal.Text = "Single files(orginal)"
        Me.rbSinglefiles_orginal.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Location = New System.Drawing.Point(315, 211)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(227, 22)
        Me.txtEmail.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(312, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 14)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "E-mail address:"
        '
        'txtDisplayName
        '
        Me.txtDisplayName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDisplayName.Location = New System.Drawing.Point(315, 164)
        Me.txtDisplayName.Name = "txtDisplayName"
        Me.txtDisplayName.Size = New System.Drawing.Size(227, 22)
        Me.txtDisplayName.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(312, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 14)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Displayed name:"
        '
        'btnAddressBook
        '
        Me.btnAddressBook.Location = New System.Drawing.Point(308, 63)
        Me.btnAddressBook.Name = "btnAddressBook"
        Me.btnAddressBook.Size = New System.Drawing.Size(227, 23)
        Me.btnAddressBook.TabIndex = 4
        Me.btnAddressBook.Text = "From system address book..."
        Me.btnAddressBook.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(435, 32)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "-    Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(308, 32)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(105, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "+     Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 14
        Me.ListBox1.Location = New System.Drawing.Point(11, 32)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(278, 396)
        Me.ListBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Recipients:"
        '
        'btnOk
        '
        Me.btnOk.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(715, 40)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(94, 31)
        Me.btnOk.TabIndex = 30
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(715, 134)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(94, 31)
        Me.btnHelp.TabIndex = 32
        Me.btnHelp.Text = "&Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(715, 86)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(94, 31)
        Me.btnCancel.TabIndex = 31
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frm_communicationSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 464)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_communicationSettings"
        Me.Text = "frm_communicationSettings"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents chkdisplaymsg As System.Windows.Forms.CheckBox
    Friend WithEvents btnConfig1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbreceive_Interestate As System.Windows.Forms.RadioButton
    Friend WithEvents rbreceive_Direct As System.Windows.Forms.RadioButton
    Friend WithEvents rbreceive_MAPI As System.Windows.Forms.RadioButton
    Friend WithEvents btnConfig As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbsend_Interestate As System.Windows.Forms.RadioButton
    Friend WithEvents rbsend_Direct As System.Windows.Forms.RadioButton
    Friend WithEvents rbsend_MAPI As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents chkreceivedlist As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDiagnose As System.Windows.Forms.CheckBox
    Friend WithEvents chkPtNotes As System.Windows.Forms.CheckBox
    Friend WithEvents chkEmail As System.Windows.Forms.CheckBox
    Friend WithEvents chkGender As System.Windows.Forms.CheckBox
    Friend WithEvents chkAddress As System.Windows.Forms.CheckBox
    Friend WithEvents chkTelephone As System.Windows.Forms.CheckBox
    Friend WithEvents chkFax As System.Windows.Forms.CheckBox
    Friend WithEvents chkBirthDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkPtName As System.Windows.Forms.CheckBox
    Friend WithEvents chkSSNNo As System.Windows.Forms.CheckBox
    Friend WithEvents chkPatientID As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbCtakt As System.Windows.Forms.RadioButton
    Friend WithEvents rbVisiQuickformat_secure As System.Windows.Forms.RadioButton
    Friend WithEvents rbVisiQuickformat As System.Windows.Forms.RadioButton
    Friend WithEvents rbSinglefiles_processed As System.Windows.Forms.RadioButton
    Friend WithEvents rbSinglefiles_orginal As System.Windows.Forms.RadioButton
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAddressBook As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
