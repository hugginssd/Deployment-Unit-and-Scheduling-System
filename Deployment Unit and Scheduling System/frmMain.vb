Public Class frmMain
    Public logged_id As Integer
    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        'frmChangePassword.MdiParent = Me
        frmChangePassword.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        End
    End Sub

    Private Sub RegisterNewEmployeeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterNewEmployeeToolStripMenuItem.Click
        frmEmployee.id = 0
        ' frmEmployee.MdiParent = Me
        frmEmployee.Show()
    End Sub

    Private Sub ManageEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageEmployeesToolStripMenuItem.Click
        'frmViewEmployees.MdiParent = Me
        frmViewEmployees.Show()
    End Sub

    Private Sub NewContractToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewContractToolStripMenuItem.Click
        ' frmContract.MdiParent = Me
        frmContract.Show()
    End Sub

    Private Sub ManageContractsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageContractsToolStripMenuItem.Click
        ' frmViewContracts.MdiParent = Me
        frmViewContracts.Show()
    End Sub

    Private Sub ManageDeploymentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageDeploymentsToolStripMenuItem.Click
        'frmDeployment.MdiParent = Me
        frmDeployment.Show()
    End Sub

    Private Sub ShiftRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShiftRegisterToolStripMenuItem.Click
        'frmShifts.MdiParent = Me
        frmShifts.Show()
    End Sub

    Private Sub RunPayrollToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunPayrollToolStripMenuItem.Click
        'frmRunPayroll.MdiParent = Me
        frmRunPayroll.Show()
    End Sub

    Private Sub GuardMonitoringToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardMonitoringToolStripMenuItem.Click
        'frmGuardPatrol.MdiParent = Me
        frmGuardPatrol.Show()
    End Sub

    Private Sub PayrollToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayrollToolStripMenuItem.Click
        'frmPayReport.MdiParent = Me
        frmPayReport.Show()
    End Sub

    Private Sub ContractsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContractsToolStripMenuItem1.Click
        ' frmWebView.MdiParent = Me
        frmWebView.WebBrowser1.Navigate("http://localhost/guard/rpt_contract.php")
        frmWebView.Show()
    End Sub

    Private Sub DeploymentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeploymentsToolStripMenuItem.Click
        'frmContractSelect.MdiParent = Me
        frmContractSelect.Show()
    End Sub

    Private Sub NewSystemUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewSystemUserToolStripMenuItem.Click
        'frmAddUser.MdiParent = Me
        frmAddUser.Show()
    End Sub

    Private Sub ShiftsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShiftsToolStripMenuItem1.Click
        frmContractSelect.rpt = "rpt_shifts.php"
        'frmContractSelect.MdiParent = Me
        frmContractSelect.Show()
    End Sub

    Private Sub ManageShiftsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageShiftsToolStripMenuItem.Click
        frmContractSelect.rpt = "rpt_shifts.php"
        'frmContractSelect.MdiParent = Me
        frmContractSelect.Show()
    End Sub

    Private Sub ManageSystemUsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageSystemUsersToolStripMenuItem.Click
        'frmViewUsers.MdiParent = Me
        frmViewUsers.Show()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RunPayrollToolStripMenuItem.Visible = False
        GuardMonitoringToolStripMenuItem.Visible = False
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Disposed
        End
    End Sub

    Private Sub DisciplinaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisciplinaryToolStripMenuItem.Click
        frmWebView.WebBrowser1.Navigate("http://localhost/guard/rpt_displinary.php")
        'frmWebView.MdiParent = Me
        frmWebView.Show()
    End Sub

    Private Sub ToolStripLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel2.Click

    End Sub

    Private Sub NewIncidentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewIncidentsToolStripMenuItem.Click
        'frmIncidents.MdiParent = Me
        frmIncidents.Show()
    End Sub

    Private Sub ViewIncidentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewIncidentsToolStripMenuItem.Click
        'frmViewIncidents.MdiParent = Me
        frmViewIncidents.Show()
    End Sub

    Private Sub AnalysisToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AnalysisToolStripMenuItem.Click
        frmIncidentsAnalysis.Show()
    End Sub
End Class