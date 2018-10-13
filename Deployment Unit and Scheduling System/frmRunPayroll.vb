Imports MySql.Data.MySqlClient

Public Class frmRunPayroll
    Dim conn As New MySqlConnection("Server=127.0.0.1;user id=root;password=;database=guard;Convert Zero Datetime=True;Allow Zero Datetime=True")

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Val(txtBasic.Text) = 0 Then
            MsgBox("Please enter basic salary")
            Exit Sub
        End If

        If Val(txtDeductions.Text) = 0 Then
            MsgBox("Please enter deductions")
            Exit Sub
        End If
        If Val(txtRate.Text) = 0 Then
            MsgBox("Please enter hourly rate")
            Exit Sub
        End If


        Dim sql As String = "select tbl_employee.*, sum(hours) as hours_worked from tbl_employee, tbl_payroll_hours " & _
                             "where tbl_employee.id = tbl_payroll_hours.employee_id " & _
                             " and month(in_date) = " & getMonth(cmbMonth.Text) & _
                             " group by tbl_employee.id"

        Dim rd As MySqlDataReader
        Dim cmd As New MySqlCommand
        Dim payRollTotal As Decimal = 0

        ListView1.Items.Clear()

        conn.Open()

        'clear old records
        Dim cmd1 As New MySqlCommand
        cmd1.Connection = conn
        cmd1.CommandText = "delete from tbl_payroll where `month` = '" & cmbMonth.Text & "'"
        cmd1.ExecuteNonQuery()

        cmd.CommandText = sql
        cmd.Connection = conn
        rd = cmd.ExecuteReader

        If rd.HasRows Then
            Do While rd.Read()
                Dim lvx As ListViewItem = New ListViewItem
                Dim total_worked As Decimal = rd.GetString(22) * txtRate.Text
                Dim net_pay As Decimal = total_worked + txtBasic.Text - txtDeductions.Text

                lvx.Text = rd.GetString(0)
                lvx.SubItems.Add(rd.GetString(5))
                lvx.SubItems.Add(rd.GetString(1) & " " & rd.GetString(2) & " " & rd.GetString(3))
                lvx.SubItems.Add(FormatCurrency(txtBasic.Text, 2))
                lvx.SubItems.Add(FormatCurrency(txtDeductions.Text, 2))
                lvx.SubItems.Add(rd.GetString(22))
                lvx.SubItems.Add(FormatCurrency(total_worked, 2))
                lvx.SubItems.Add(FormatCurrency(net_pay, 2))
                ListView1.Items.Add(lvx)

                savePayrollDetails(rd.GetString(22), txtBasic.Text, rd.GetString(22) * txtRate.Text, txtDeductions.Text, net_pay, rd)
            Loop
        Else
            Console.WriteLine("No rows found.")
        End If

        conn.Close()
    End Sub
    Sub savePayrollDetails(ByVal hours_worked As String, ByVal basic_salary As String, ByVal payment As String, ByVal deductions As String, ByVal netpay As String, ByVal emp As MySqlDataReader)
        Dim conn1 As New MySqlConnection("Server=127.0.0.1;user id=root;password=;database=edms;Convert Zero Datetime=True;Allow Zero Datetime=True")
        Dim cmd As New MySqlCommand
        conn1.Open()

        cmd.Connection = conn1
        cmd.CommandText = "insert into tbl_payroll (Employ_id, ID_No, Emp_fname, Surname, Employer_name, Employ_name, Date_payed,Hours_worked,Basic_salary,Payment,Deductions,Month,Netpay)" & _
                " values(@Employ_id, @ID_No, @Emp_fname, @Surname, @Employer_name, @Employ_name, @Date_payed, @Hours_worked, @Basic_salary, @Payment, @Deductions, @Month,@Netpay)"
        cmd.CommandType = CommandType.Text

        cmd.Parameters.AddWithValue("@Employ_id", emp.GetString(0))
        cmd.Parameters.AddWithValue("@ID_No", emp.GetString(5))
        cmd.Parameters.AddWithValue("@Emp_fname", emp.GetString(1))
        cmd.Parameters.AddWithValue("@Surname", emp.GetString(3))
        cmd.Parameters.AddWithValue("@Employer_name", "")
        cmd.Parameters.AddWithValue("@Employ_name", emp.GetString(2))
        cmd.Parameters.AddWithValue("@Date_payed", Now().Year & "-" & Now().Month & "-" & Now().Day)
        cmd.Parameters.AddWithValue("@Hours_worked", Format(hours_worked, 2))
        cmd.Parameters.AddWithValue("@Basic_salary", FormatCurrency(basic_salary, 2))
        cmd.Parameters.AddWithValue("@Payment", FormatCurrency(payment, 2))
        cmd.Parameters.AddWithValue("@Deductions", FormatCurrency(deductions, 2))
        cmd.Parameters.AddWithValue("@Month", cmbMonth.Text)
        cmd.Parameters.AddWithValue("@Netpay", FormatCurrency(netpay, 2))
        Try

            cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            ' MsgBox(ex.Message.ToString)
            Debug.WriteLine(ex.Message.ToString)
        Finally

        End Try
    End Sub
    Function getMonth(ByVal month As String) As Integer
        Dim mon As Integer = 0
        Select Case month
            Case "January"
                mon = 1
            Case "February"
                mon = 2
            Case "March"
                mon = 3
            Case "April"
                mon = 4
            Case "May"
                mon = 5
            Case "June"
                mon = 6
            Case "July"
                mon = 7
            Case "August"
                mon = 8
            Case "September"
                mon = 9
            Case "October"
                mon = 10
            Case "November"
                mon = 11
            Case "Dece,ber"
                mon = 12
        End Select

        Return mon
    End Function

    Private Sub frmRunPayroll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class