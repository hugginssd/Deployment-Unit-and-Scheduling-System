Public Class frmLogin

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        End
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim validLogin As Boolean = False
        Dim usrID As String = 0

        With rs("select * from tbl_user where tbl_user.username = '" & txtUserName.Text & "' and tbl_user.password = '" & txtPassword.Text & "'")
            If Not .EOF Or Not .BOF Then
                validLogin = True
                usrID = .Fields("id").Value

                If .Fields("level").Value = "Clerk" Then
                    frmMain.GuardMonitoringToolStripMenuItem.Enabled = False
                    frmMain.RunPayrollToolStripMenuItem.Enabled = False
                    frmMain.AdministrationToolStripMenuItem.Enabled = False
                End If

                frmMain.ToolStripLabel3.Text = "Welcome " & .Fields("fullname").Value
                frmMain.ToolStripLabel5.Text = Now

                frmMain.logged_id = usrID
            End If
            .Close()
        End With

        If validLogin Then
            'userID = usrID

            frmMain.Show()
            Me.Hide()
        Else
            MsgBox("Invalid login details", vbExclamation)

        End If
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        openConneciton(Application.StartupPath)
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Application.Exit()
    End Sub
End Class