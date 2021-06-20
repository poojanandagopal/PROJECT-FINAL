Public Class frm_Measurements

    Private Sub frm_Measurements_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub pic_distance_measure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_distance_measure.Click
        frm_MainScreen.measure = "Line"
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        frm_MainScreen.measure = "Pins"
    End Sub
End Class