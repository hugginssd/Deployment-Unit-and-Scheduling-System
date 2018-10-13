Public Class frmChangePassword

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Dispose()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If txtPassword.Text = "" Then
            MsgBox("Please enter password", vbExclamation)
            Exit Sub
        End If

        If txtPassword.Text <> txtPassword1.Text Then
            MsgBox("Passwords do not match", vbExclamation)
            Exit Sub
        End If

        With rs("select * from  tbl_user where id = " & frmMain.logged_id & "  and password = " & txtOldPassword.Text)
            If Not .EOF Or Not .BOF Then
                .Fields("password").Value = txtPassword.Text
                .Update()
                MsgBox("Password successfully changed", vbInformation)
                Me.Dispose()
            Else
                MsgBox("Invalid old password", vbExclamation)
            End If
        End With
    End Sub

    Private Sub frmChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class