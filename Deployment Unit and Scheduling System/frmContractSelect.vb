Public Class frmContractSelect
    Public rpt As String = "rpt_deployment.php"
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim start As String = dtStart.Value.Year & "-" & dtStart.Value.Month & "-" & dtStart.Value.Day
        Dim endd As String = dtEnd.Value.Year & "-" & dtEnd.Value.Month & "-" & dtEnd.Value.Day

        frmWebView.WebBrowser1.Navigate("http://localhost/guard/" & rpt & "?contract=" & cmbContractID.SelectedValue & "&start=" & start & "&end=" & endd)
        Me.Hide()

        'frmWebView.MdiParent = frmMain
        frmWebView.Show()
    End Sub

    Private Sub frmContractSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim siteSource As New Dictionary(Of String, String)()
        With rs("select * from tbl_contract")
            If Not .EOF Or Not .BOF Then
                Do
                    siteSource.Add(.Fields("id").Value, .Fields("contract_name").Value)
                    .MoveNext()
                Loop While Not .EOF
            End If
        End With

        cmbContractID.DataSource = New BindingSource(siteSource, Nothing)
        cmbContractID.DisplayMember = "Value"
        cmbContractID.ValueMember = "Key"
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Close()
    End Sub
End Class