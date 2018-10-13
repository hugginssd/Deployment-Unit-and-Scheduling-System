Public Class frmIncidentsAnalysis

    Private Sub Label5_Click(sender As System.Object, e As System.EventArgs) Handles Label5.Click
        If DialogResult.OK = MessageBox.Show("Do you want to close the form?" + vbNewLine + "Be sure to visualize all statistical data before you close.", "Deployment Unit and Scheduling Sytem", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) Then
            Close()
        End If
    End Sub

    Private Sub frmIncidentsAnalysis_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

    End Sub
End Class