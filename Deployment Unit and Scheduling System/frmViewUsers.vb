Public Class frmViewUsers

    Private Sub frmViewUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadListview()
    End Sub
    Sub loadListview()
        ListView1.Items.Clear()
        With rs("select * from tbl_user where fullname like '%" & txtSearch.Text & "%' or username like '%" & txtSearch.Text & "%' ")
            If Not .EOF Or Not .BOF Then
                Do
                    Dim lvx As ListViewItem = New ListViewItem

                    lvx.Text = .Fields("fullname").Value
                    lvx.SubItems.Add(.Fields("username").Value)
                    lvx.SubItems.Add(.Fields("level").Value)
                    ListView1.Items.Add(lvx)
                    .MoveNext()
                Loop While Not .EOF
            End If
        End With
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        loadListview()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Close()
    End Sub
End Class