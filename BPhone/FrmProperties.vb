Public Class FrmProperties
    Private Sub CheckMainTabR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckMainTabR.CheckedChanged
        If CheckMainTabR.Checked = True Then FormMain.MainTab.RightToLeft = Windows.Forms.RightToLeft.Yes Else FormMain.MainTab.RightToLeft = Windows.Forms.RightToLeft.No
    End Sub

    Private Sub ButtonColorMainTab_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonColorMainTab.BackColorChanged
        FormMain.MainTab.BackgroundColor = ButtonColorMainTab.BackColor
        ColorMainTab.Color = ButtonColorMainTab.BackColor
    End Sub
    Private Sub ButtonColorMainTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonColorMainTab.Click
        ColorMainTab.ShowDialog()
        ButtonColorMainTab.BackColor = ColorMainTab.Color
    End Sub
    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        FormMain.PutOptions()
        '
        Hide()
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        FormMain.GetOptions()
        Hide()
    End Sub
    Private Sub ButtonReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReset.Click
        CheckMainTabR.Checked = True
        ButtonColorMainTab.BackColor = Color.FromArgb(222, 222, 255)
        FormMain.PutOptions()
    End Sub

    Private Sub FrmProperties_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then ButtonCancel_Click(sender, e)
    End Sub
End Class
