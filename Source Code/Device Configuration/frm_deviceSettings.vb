Public Class frm_deviceSettings
    Dim strMode As String = ""
    Private Sub frm_deviceSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Dim ObjClass As New ClassFunctions()
        Dim dt As New DataTable()
        'dt = ObjClass.returndatatable("select * from device_Settings_General", dt)
        'If dt.Rows.Count > 0 Then
        '    strMode = "MODIFY"
        'Else
        '    strMode = "ADD"
        'End If
    End Sub

End Class