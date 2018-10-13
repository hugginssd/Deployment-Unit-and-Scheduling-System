Public Class frmAddUser

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If txtFullName.Text = "" Then
            MsgBox("Please enter full name", vbExclamation)
            Exit Sub
        End If

        If txtUsername.Text = "" Then
            MsgBox("Please enter login name", vbExclamation)
            Exit Sub
        End If

        If txtPassword.Text = "" Then
            MsgBox("Please enter password", vbExclamation)
            Exit Sub
        End If

        If txtPassword.Text <> txtPassword2.Text Then
            MsgBox("Passwords do not match", vbExclamation)
            Exit Sub
        End If

        With rs("tbl_user")
            .AddNew()
            .Fields("fullname").Value = txtFullName.Text
            .Fields("username").Value = txtUsername.Text
            .Fields("password").Value = txtPassword.Text
            .Fields("level").Value = cmbLevel.Text
            .Update()

            MsgBox("New user added successfully", vbInformation)
            Me.Dispose()
        End With
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Dispose()
    End Sub

    Private Sub frmAddUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Close()
    End Sub
End Class