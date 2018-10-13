Public Class frmViewIncidents
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Close()
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        loadListview()
    End Sub
    Sub loadListview()
        Try
            ListView1.Items.Clear()
            With rs("select * from tbincidents where incidentid like '%" & txtSearch.Text & "%' or incidentname like '%" & txtSearch.Text & "%' or officersinvolved  like '%" & txtSearch.Text & "%'")
                If Not .EOF Or Not .BOF Then
                    Do
                        Dim lvx As ListViewItem = New ListViewItem

                        lvx.Text = .Fields("incidentid").Value
                        lvx.SubItems.Add(.Fields("incidentname").Value)
                        lvx.SubItems.Add(.Fields("officersinvolved").Value)
                        lvx.SubItems.Add(.Fields("scene").Value.ToString)
                        lvx.SubItems.Add(.Fields("incidentdate").Value.ToString)
                        lvx.SubItems.Add(.Fields("description").Value.ToString)
                        ListView1.Items.Add(lvx)
                        .MoveNext()
                    Loop While Not .EOF
                End If
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmViewIncidents_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' loadListview()
    End Sub
End Class