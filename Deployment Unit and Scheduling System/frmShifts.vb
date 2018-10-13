Public Class frmShifts

    Private Sub frmShifts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim siteSource As New Dictionary(Of String, String)()
        With rs("select * from tbl_site")
            If Not .EOF Or Not .BOF Then
                Do
                    siteSource.Add(.Fields("id").Value, .Fields("name").Value)
                    .MoveNext()
                Loop While Not .EOF
            End If
        End With

        cmbSiteID.DataSource = New BindingSource(siteSource, Nothing)
        cmbSiteID.DisplayMember = "Value"
        cmbSiteID.ValueMember = "Key"


        Dim employeeSource As New Dictionary(Of String, String)()
        With rs("select * from tbl_employee")
            If Not .EOF Or Not .BOF Then
                Do
                    employeeSource.Add(.Fields("id").Value, .Fields("employee_number").Value & ": " & .Fields("firstnames").Value & " " & .Fields("lastname").Value)
                    .MoveNext()
                Loop While Not .EOF
            End If
        End With

        cmbEmployee.DataSource = New BindingSource(employeeSource, Nothing)
        cmbEmployee.DisplayMember = "Value"
        cmbEmployee.ValueMember = "Key"
    End Sub

    Private Sub cmbSiteID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSiteID.SelectedIndexChanged
        Try
            With rs("select * from tbl_site where id = " & cmbSiteID.SelectedValue)
                txtSiteName.Text = .Fields("name").Value
                txtSiteAddress.Text = .Fields("address").Value
                txtContactName.Text = .Fields("contact_name").Value
                txtContactNumber.Text = .Fields("contact_number").Value
                txtCoordinates.Text = .Fields("coordinates").Value

                loadListview()
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cmbSiteID.Text = "" Then
            MsgBox("Please select site", vbExclamation)
            Exit Sub
        End If
        If cmbEmployee.Text = "" Then
            MsgBox("Please select employee", vbExclamation)
            Exit Sub
        End If

        If cmbStartHr.Text = "" Then
            MsgBox("Please select start time", vbExclamation)
            Exit Sub
        End If
        If cmbStartMin.Text = "" Then
            MsgBox("Please select start time", vbExclamation)
            Exit Sub
        End If

        If cmbEndHr.Text = "" Then
            MsgBox("Please select end time", vbExclamation)
            Exit Sub
        End If
        If cmbEndMin.Text = "" Then
            MsgBox("Please select end time", vbExclamation)
            Exit Sub
        End If

        With rs("tbl_shift")
            .AddNew()
            .Fields("contract_id").Value = 0
            .Fields("site_id").Value = cmbSiteID.SelectedValue
            .Fields("date").Value = dtShift.Value.Year & "-" & dtShift.Value.Month & "-" & dtShift.Value.Day
            .Fields("start_time").Value = cmbStartHr.Text & ":" & cmbStartMin.Text
            .Fields("end_time").Value = cmbEndHr.Text & ":" & cmbEndMin.Text
            .Fields("employee_id").Value = cmbEmployee.SelectedValue
            .Update()
        End With
        loadListview()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Dispose()
    End Sub

    Sub loadListview()
        ListView1.Items.Clear()
        ' If cmbSiteID.SelectedValue <> "" Then
        Debug.WriteLine("select tbl_shift.*, concat(employee_number,': ', firstnames, ' ', lastname) as emp " & _
                "from tbl_shift, tbl_employee where tbl_shift.employee_id = tbl_employee.id " & _
                "and site_id = " & cmbSiteID.SelectedValue)

        With rs("select tbl_shift.*, concat(employee_number,': ', firstnames, ' ', lastname) as emp " & _
                "from tbl_shift, tbl_employee where tbl_shift.employee_id = tbl_employee.id " & _
                "and site_id = " & cmbSiteID.SelectedValue)
            If Not .EOF Or Not .BOF Then
                Do
                    Dim lvx As ListViewItem = New ListViewItem

                    lvx.Text = .Fields("date").Value
                    lvx.SubItems.Add(.Fields("start_time").Value)
                    lvx.SubItems.Add(.Fields("end_time").Value)
                    lvx.SubItems.Add(.Fields("emp").Value)
                    ListView1.Items.Add(lvx)
                    .MoveNext()
                Loop While Not .EOF
            End If
        End With
        'End If
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Close()
    End Sub
End Class