Public Class frmDisplinary
    Public employee_id As Integer
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Dispose()
        frmEmployee.Dispose()
    End Sub

    Private Sub frmDisplinary_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        frmEmployee.Dispose()
    End Sub

    Private Sub frmDisplinary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cmbSection.Text = "" Then
            MsgBox("Please select section", vbExclamation)
            Exit Sub
        End If

        If cmbAction.Text = "" Then
            MsgBox("Please select action", vbExclamation)
            Exit Sub
        End If

        With rs("tbl_displinary")
            .AddNew()
            .Fields("employee_id").Value = employee_id
            .Fields("section").Value = cmbSection.Text
            .Fields("action").Value = cmbAction.Text
            .Fields("date").Value = dtDate.Value.Year & "-" & dtDate.Value.Month & "-" & dtDate.Value.Day
            .Fields("notes").Value = txtNotes.Text
            .Update()

            MsgBox("Displinary record successfully saved", vbInformation)
            Me.Dispose()
            frmEmployee.Dispose()
        End With
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Close()
    End Sub
End Class