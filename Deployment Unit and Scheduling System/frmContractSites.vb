Public Class frmContractSites
    Public contract_id As Integer = 0

    Private Sub frmContractSites_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        frmViewContracts.Dispose()
    End Sub
    Private Sub frmContractSites_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadListview()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If txtSiteName.Text = "" Then
            MsgBox("Please enter the site name", vbExclamation)
            Exit Sub
        End If

        If txtSiteAddress.Text = "" Then
            MsgBox("Please enter the site address", vbExclamation)
            Exit Sub
        End If

        With rs("tbl_site")
            .AddNew()
            .Fields("contract_id").Value = contract_id
            .Fields("name").Value = txtSiteName.Text
            .Fields("address").Value = txtSiteAddress.Text
            .Fields("contact_name").Value = txtContactName.Text
            .Fields("contact_number").Value = txtContactNumber.Text
            .Fields("coordinates").Value = txtCoordinates.Text
            .Fields("instructions").Value = txtSiteInstructions.Text
            .Update()
        End With


        txtSiteName.Text = ""
        txtSiteAddress.Text = ""
        txtContactName.Text = ""
        txtContactNumber.Text = ""
        txtCoordinates.Text = ""
        txtSiteInstructions.Text = ""

        loadListview()
    End Sub

    Sub loadListview()
        ListView1.Items.Clear()
        With rs("select * from tbl_site where contract_id = " & contract_id)
            If Not .EOF Or Not .BOF Then
                Do
                    Dim lvx As ListViewItem = New ListViewItem

                    lvx.Text = .Fields("name").Value
                    lvx.SubItems.Add(.Fields("address").Value)
                    lvx.SubItems.Add(.Fields("contact_name").Value)
                    lvx.SubItems.Add(.Fields("coordinates").Value)
                    ListView1.Items.Add(lvx)

                    .MoveNext()
                Loop While Not .EOF
            End If
        End With
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Dispose()
        frmViewContracts.Dispose()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Close()
    End Sub
End Class