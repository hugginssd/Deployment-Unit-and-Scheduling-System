Public Class frmEmployee
    Dim a As New OpenFileDialog
    Public id As Integer = 0
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim d As Double = DateDiff(DateInterval.Year, dtDOB.Value, Date.Now)
        If d < 18 Then
            MessageBox.Show("Please date should be valid", "Deployment Unit and Scheduling System", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Return
        End If
        If txtFirstnames.Text = "" Then
            MsgBox("Enter employee firstname", vbExclamation)
            Exit Sub
        End If

        If txtLastname.Text = "" Then
            MsgBox("Enter employee lastname", vbExclamation)
            Exit Sub
        End If

        If txtIDNumber.Text = "" Then
            MsgBox("Enter employee id number", vbExclamation)
            Exit Sub
        End If

        Dim sql As String = "tbl_employee"
        If id <> 0 Then
            sql = "select * from tbl_employee where id = " & id
        End If
        With rs(sql)

            If id = 0 Then
                .AddNew()
            End If
            .Fields("employee_number").Value = txtNumber.Text
            .Fields("firstnames").Value = txtFirstnames.Text
            .Fields("lastname").Value = txtLastname.Text
            .Fields("dob").Value = dtDOB.Value.Year & "-" & dtDOB.Value.Month & "-" & dtDOB.Value.Day
            .Fields("id_number").Value = txtIDNumber.Text
            .Fields("date_employed").Value = txtDateEmployed.Value.Year & "-" & txtDateEmployed.Value.Month & "-" & txtDateEmployed.Value.Day
            .Fields("job_title").Value = txtJobTitle.Text
            .Fields("contact_number").Value = txtContactNo.Text
            .Fields("address").Value = txtAddress.Text
            .Fields("nok_firstname").Value = txtNOKFirstnames.Text
            .Fields("nok_lastname").Value = txtNOKLastname.Text
            .Fields("nok_contact_number").Value = txtNOKContactNo.Text
            .Fields("nok_address").Value = txtNOKAddress.Text
            .Fields("nok_relationship").Value = txtNOKRelationship.Text
            .Fields("bank_name").Value = txtBankName.Text
            .Fields("bank_branch").Value = txtBranhName.Text
            .Fields("bank_account_number").Value = txtAccountNumber.Text
            Try
                .Fields("picture").Value = IO.File.ReadAllBytes(a.FileName)
            Catch
            End Try
            .Update()

            MsgBox("Employee successfully saved", vbInformation)
            Me.Dispose()
        End With

    End Sub

    Private Sub frmEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cnt As Integer = 0

        If id = 0 Then
            txtNumber.Text = getRowCount("tbl_employee") + 1
            txtNumber.Text = "EMP0" + txtNumber.Text
        End If

    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click
        Dim piclocation As String
        a.Filter = Nothing
        piclocation = a.FileName
        a.ShowDialog()
        Try
            PictureBox1.Image = Image.FromFile(a.FileName)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdDisplinary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisplinary.Click
        If id <> 0 Then
            frmDisplinary.lblFirstnames.Text = txtFirstnames.Text
            frmDisplinary.lblLastname.Text = txtLastname.Text
            frmDisplinary.lblNO.Text = txtNumber.Text

            frmDisplinary.employee_id = id
            frmDisplinary.MdiParent = frmMain
            frmDisplinary.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Dispose()

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click
        Close()
    End Sub

    Private Sub dtDOB_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDOB.ValueChanged

        Dim d As Double = DateDiff(DateInterval.Year, dtDOB.Value, Date.Now)
        If d < 18 Then
            MessageBox.Show("Please date should be valid", "Deployment Unit and Scheduling System", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Return
        End If
    End Sub

    Private Sub txtContactNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContactNo.TextChanged
     
       

    End Sub
End Class
