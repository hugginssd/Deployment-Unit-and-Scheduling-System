Public Class frmIncidents
    Public id As Integer = 0
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If cmSeverity.SelectedItem = "" Then
            MsgBox("Please select incident severity before you save")
            Return
        End If
        Dim sql As String = "tblincidents"
        If id <> 0 Then
            sql = "select * from tblincidents where id = " & id
        End If
        With rs(sql)

            If id = 0 Then
                .AddNew()
            End If
            .Fields("incidentid").Value = txtIncidentId.Text
            .Fields("incidentname").Value = txtIncidentName.Text
            .Fields("officersinvolved").Value = txtOfficersInvolved.Text
            .Fields("scene").Value = txtScene.Text
            .Fields("incidentdate").Value = dtpDate.Value.Year & "-" & dtpDate.Value.Month & "-" & dtpDate.Value.Day
            .Fields("description").Value = txtDescription.Text
            .Update()

            MsgBox("Incident successfully captured", vbInformation)
            Me.Dispose()
        End With

    End Sub
    Private Sub frmIncidents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cnt As Integer = 0

        If id = 0 Then
            txtIncidentId.Text = getRowCount("tblincidents") + 1
            txtIncidentId.Text = "INC0" + txtIncidentId.Text
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Close()
    End Sub

    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
        If dtpDate.Value > Date.Now Then
            MessageBox.Show("Please the incident date cannot be any day before today")
            Return
        End If
    End Sub
End Class