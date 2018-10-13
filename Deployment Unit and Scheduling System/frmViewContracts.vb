Public Class frmViewContracts

    Private Sub frmViewContracts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadListview()
    End Sub

    Sub loadListview()
        ListView1.Items.Clear()
        With rs("select * from tbl_contract where contract_number like '%" & txtSearch.Text & "%' or contract_name like '%" & txtSearch.Text & "%'")
            If Not .EOF Or Not .BOF Then
                Do
                    Dim lvx As ListViewItem = New ListViewItem

                    lvx.Text = .Fields("contract_number").Value
                    lvx.SubItems.Add(.Fields("contract_name").Value)
                    lvx.SubItems.Add(.Fields("start_date").Value)
                    lvx.SubItems.Add(.Fields("end_date").Value)
                    lvx.SubItems.Add(.Fields("number_of_guards").Value)
                    ListView1.Items.Add(lvx)
                    .MoveNext()
                Loop While Not .EOF
            End If
        End With
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        With rs("select * from tbl_contract where contract_number = '" & ListView1.SelectedItems(0).Text & "'")
            frmContractSites.contract_id = .Fields("id").Value
            frmContractSites.lblContractName.Text = .Fields("contract_name").Value
            frmContractSites.lblContractNumber.Text = .Fields("contract_number").Value

            frmContractSites.Show()
            frmContractSites.MdiParent = frmMain
            Me.Hide()
        End With
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        loadListview()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Close()
    End Sub
End Class