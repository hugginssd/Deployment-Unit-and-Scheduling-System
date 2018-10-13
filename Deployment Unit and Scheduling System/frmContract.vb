Public Class frmContract

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If txtContactName.Text = "" Then
            MsgBox("Please enter contract name", vbExclamation)
            Exit Sub
        End If
        If txtNumber.Text = "" Then
            MsgBox("Please enter contract number", vbExclamation)
            Exit Sub
        End If

        With rs("tbl_contract")
            .AddNew()
            .Fields("contract_number").Value = txtNumber.Text
            .Fields("contract_name").Value = txtName.Text
            .Fields("start_date").Value = dtStart.Value.Year & "-" & dtStart.Value.Month & "-" & dtStart.Value.Day
            .Fields("end_date").Value = dtEnd.Value.Year & "-" & dtEnd.Value.Month & "-" & dtEnd.Value.Day
            .Fields("number_of_guards").Value = txtNumberOfGuards.Text
            .Fields("contract_value").Value = txtValue.Text
            .Fields("method_of_payment").Value = txtMethod.Text
            .Fields("address").Value = txtAddress.Text
            .Fields("contact_name").Value = txtContactName.Text
            .Fields("contact_number").Value = txtContactNumber.Text
            .Update()

            MsgBox("Contract successfully saved", vbInformation)
            Me.Dispose()
        End With
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Dispose()
    End Sub

    Private Sub frmContract_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cnt As Integer = 0

        txtNumber.Text = getRowCount("tbl_contract") + 1
    End Sub
End Class