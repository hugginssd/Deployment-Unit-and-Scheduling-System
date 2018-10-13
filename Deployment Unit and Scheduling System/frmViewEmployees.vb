Public Class frmViewEmployees

    Private Sub frmViewEmployees_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadListview()
    End Sub

    Sub loadListview()
        ListView1.Items.Clear()
        With rs("select * from tbl_employee where firstnames like '%" & txtSearch.Text & "%' or lastname like '%" & txtSearch.Text & "%' or employee_number  like '%" & txtSearch.Text & "%'")
            If Not .EOF Or Not .BOF Then
                Do
                    Dim lvx As ListViewItem = New ListViewItem

                    lvx.Text = .Fields("employee_number").Value
                    lvx.SubItems.Add(.Fields("firstnames").Value)
                    lvx.SubItems.Add(.Fields("lastname").Value)
                    lvx.SubItems.Add(.Fields("contact_number").Value.ToString)
                    lvx.SubItems.Add(.Fields("address").Value.ToString)
                    ListView1.Items.Add(lvx)
                    .MoveNext()
                Loop While Not .EOF
            End If
        End With
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        loadListview()
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        With rs("select * from tbl_employee where employee_number = '" & ListView1.SelectedItems(0).Text & "'")
            frmEmployee.id = .Fields("id").Value
            frmEmployee.txtNumber.Text = .Fields("employee_number").Value.ToString
            frmEmployee.txtFirstnames.Text = .Fields("firstnames").Value.ToString
            frmEmployee.txtLastname.Text = .Fields("lastname").Value.ToString

            frmEmployee.txtIDNumber.Text = .Fields("id_number").Value.ToString

            frmEmployee.txtJobTitle.Text = .Fields("job_title").Value.ToString
            frmEmployee.txtContactNo.Text = .Fields("contact_number").Value.ToString
            frmEmployee.txtAddress.Text = .Fields("address").Value.ToString
            frmEmployee.txtNOKFirstnames.Text = .Fields("nok_firstname").Value.ToString
            frmEmployee.txtNOKLastname.Text = .Fields("nok_lastname").Value.ToString
            frmEmployee.txtNOKContactNo.Text = .Fields("nok_contact_number").Value.ToString
            frmEmployee.txtNOKAddress.Text = .Fields("nok_address").Value.ToString
            frmEmployee.txtNOKRelationship.Text = .Fields("nok_relationship").Value.ToString
            frmEmployee.txtBankName.Text = .Fields("bank_name").Value.ToString
            frmEmployee.txtBranhName.Text = .Fields("bank_branch").Value.ToString
            frmEmployee.txtAccountNumber.Text = .Fields("bank_account_number").Value.ToString

            Try
                Dim byteImage() As Byte = .Fields("picture").Value
                Dim frmImageView As New System.IO.MemoryStream(byteImage)
                frmEmployee.PictureBox1.Image = Image.FromStream(frmImageView)

            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try

            ''frmEmployee.MdiParent = frmMain
            frmEmployee.Show()

            Me.Hide()

        End With
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Close()
    End Sub
End Class