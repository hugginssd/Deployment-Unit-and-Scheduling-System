Public Class frmPayReport

    Private Sub frmPayReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim siteSource As New Dictionary(Of String, String)()
       
        siteSource.Add(1, "January")
        siteSource.Add(2, "February")
        siteSource.Add(3, "March")
        siteSource.Add(4, "April")
        siteSource.Add(5, "May")
        siteSource.Add(6, "June")
        siteSource.Add(7, "July")
        siteSource.Add(8, "August")
        siteSource.Add(9, "September")
        siteSource.Add(10, "October")
        siteSource.Add(11, "November")
        siteSource.Add(12, "December")

        cmbMonth.DataSource = New BindingSource(siteSource, Nothing)
        cmbMonth.DisplayMember = "Value"
        cmbMonth.ValueMember = "Key"


    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        frmWebView.WebBrowser1.Navigate("http://localhost/guard/rpt_pay.php?month=" & cmbMonth.SelectedValue)
        Me.Hide()
        frmWebView.MdiParent = frmMain
        frmWebView.Show()
    End Sub
End Class