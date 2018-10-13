Public Class frmWebView

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        WebBrowser1.ShowPrintDialog()
    End Sub
End Class