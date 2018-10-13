Imports MySql.Data.MySqlClient

Public Class frmGuardPatrol

    Dim conn As New MySqlConnection("Server=127.0.0.1;user id=root;password=;database=guard;Convert Zero Datetime=True;Allow Zero Datetime=True")
    Dim cloud_conn As New MySqlConnection("Server=chat-builder.com;user id=chatbuil_guard;password=l0tu5n0t35;database=chatbuil_guard;Convert Zero Datetime=True;Allow Zero Datetime=True")

    Dim procRunning As Boolean = False
    Dim selectedLat As String
    Dim selectedLng As String

    Private Sub frmGuardPatrol_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        conn.Close()
        cloud_conn.Close()
    End Sub

    Private Sub frmGuardPatrol_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Try
            conn.Open()
            cloud_conn.Open()

        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox(ex.ToString)
        End Try
    End Sub


    Sub syncRecords()

        If procRunning Then
            Exit Sub
        End If

        procRunning = True
        Dim rd As MySqlDataReader
        Dim cmd As New MySqlCommand



        cmd.CommandText = "select id from tbl_monitoring order by id desc"
        cmd.Connection = conn
        rd = cmd.ExecuteReader
        Dim last_id As String = 0
        If rd.Read Then

            last_id = rd.GetString(0)

        End If
        rd.Close()

        cmd.CommandText = "select * from tbl_monitoring where id > '" & last_id & "'"
        cmd.Connection = cloud_conn
        rd = cmd.ExecuteReader
        If rd.Read Then
            Debug.WriteLine(rd.GetString(0) & rd.GetString(1) & rd.GetString(2) & rd.GetString(3) & rd.GetString(5) & rd.GetString(6).ToString)
            saveMonitorRecord(rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(5), rd.GetString(6).ToString)

            Dim lvx As ListViewItem = New ListViewItem
            lvx.Text = rd.GetString(1)
            lvx.SubItems.Add(rd.GetString(2))
            lvx.SubItems.Add(rd.GetString(3))
            lvx.SubItems.Add(rd.GetString(5))
            lvx.SubItems.Add(rd.GetString(6))

            ListView1.Items.Add(lvx)
            Try
                If rd.GetString(1) = "PANIC_ALERT" Then
                    cmdAlert.BackColor = Color.Red
                    lblEmp.Text = "Employee id: " & rd.GetString(2)
                    lblLat.Text = "GPS Lat: " & rd.GetString(5)
                    lblLng.Text = "GPS Lng: " & rd.GetString(6)
                    lblTime.Text = "Time: " & rd.GetString(3)

                    selectedLat = rd.GetString(5)
                    selectedLng = rd.GetString(6)

                    Dim path As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                    My.Computer.Audio.Play(path & "\alarm.wav")

                    Timer2.Enabled = True


                End If
            Catch ex As Exception
            End Try
            'computer payroll hours
            Try
                If rd.GetString(1).Substring(0, 4) = "EXIT" Then

                    'get last entrance record
                    Dim rd_p As MySqlDataReader
                    Dim cmd_p As New MySqlCommand
                    cmd_p.CommandText = "select * from tbl_monitoring where emp_number = '" & rd.GetString(2) & "' and qr_code like 'ENTANCE%' order by id desc"
                    cmd_p.Connection = conn
                    rd_p = cmd_p.ExecuteReader

                    Dim last_entrance As String
                    Dim d1 As DateTime = vbDate(rd.GetString(3))
                    Dim d2 As DateTime = New DateTime
                    Dim hoursWorked As Decimal

                    If rd_p.Read Then

                        last_entrance = rd_p.GetString(3)
                        d2 = vbDate(last_entrance)

                        Dim diff1 As System.TimeSpan
                        diff1 = d1.Subtract(d2)

                        Debug.WriteLine(diff1)
                        hoursWorked = diff1.Hours

                        If diff1.Minutes > 0 Then
                            hoursWorked += (diff1.Minutes / 60)
                        End If

                        Debug.WriteLine(hoursWorked)
                        If hoursWorked > 12 Then
                            hoursWorked = 12
                        End If

                    Else
                        hoursWorked = 12
                    End If

                    rd_p.Close()
                    rd.Close()

                    savePayrollHours(rd.GetString(2), d2, d1, hoursWorked)
                End If
            Catch ex As Exception
            End Try
        End If
        Try
            rd.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Data")
        End Try

        procRunning = False
    End Sub

    Sub savePayrollHours(ByVal employee_id As String, ByVal in_time As DateTime, ByVal out_time As DateTime, ByVal hours As String)
        Dim cmd As New MySqlCommand
        cmd.Connection = conn
        cmd.CommandText = "insert into tbl_payroll_hours (employee_id, in_date, in_time, out_date, out_time, hours) values(@employee_id, @in_date, @in_time, @out_date, @out_time, @hours)"
        cmd.CommandType = CommandType.Text

        cmd.Parameters.AddWithValue("@employee_id", employee_id)
        cmd.Parameters.AddWithValue("@in_date", in_time.Year & "-" & in_time.Month & "-" & in_time.Day)
        cmd.Parameters.AddWithValue("@in_time", in_time.Hour & ":" & in_time.Minute & ":" & in_time.Second)
        cmd.Parameters.AddWithValue("@out_date", out_time.Year & "-" & out_time.Month & "-" & out_time.Day)
        cmd.Parameters.AddWithValue("@out_time", out_time.Hour & ":" & out_time.Minute & ":" & out_time.Second)
        cmd.Parameters.AddWithValue("@hours", hours)
        Try

            cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            ' MsgBox(ex.Message.ToString)
            Debug.WriteLine(ex.Message.ToString)
        Finally

        End Try
    End Sub

    Sub saveMonitorRecord(ByVal id As String, ByVal qr_code As String, ByVal emp_number As String, ByVal date_time As String, ByVal gps_lat As String, ByVal gps_lng As String)

        Dim cmd As New MySqlCommand
        cmd.Connection = conn
        cmd.CommandText = "insert into tbl_monitoring (id, qr_code, emp_number, date_time, gps_lat, gps_lng) values(@id, @qr_code, @emp_number, @date_time, @gps_lat, @gps_lng)"
        cmd.CommandType = CommandType.Text

        cmd.Parameters.AddWithValue("@id", id)
        cmd.Parameters.AddWithValue("@qr_code", qr_code)
        cmd.Parameters.AddWithValue("@emp_number", emp_number)
        cmd.Parameters.AddWithValue("@date_time", date_time)
        cmd.Parameters.AddWithValue("@gps_lat", gps_lat)
        cmd.Parameters.AddWithValue("@gps_lng", gps_lng)
        Try

            cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            ' MsgBox(ex.Message.ToString)
            Debug.WriteLine(ex.Message.ToString)
        Finally

        End Try

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Debug.WriteLine("In bg worker")
        syncRecords()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Debug.WriteLine("In timer")
        Try
            BackgroundWorker1.RunWorkerAsync()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Debug.WriteLine("blink")
        If cmdAlert.BackColor = Color.Red Then
            cmdAlert.BackColor = Color.LightGray
        Else
            cmdAlert.BackColor = Color.Red
        End If
    End Sub

    Public Function vbDate(ByVal mysqlDate As String) As DateTime

        Dim tmp() As String = mysqlDate.Split(" ")
        Dim date_part() As String = tmp(0).Split("-")
        Dim time_part() As String = tmp(1).Split(":")

        Dim dt As DateTime = New DateTime(date_part(0), date_part(1), date_part(2), time_part(0), time_part(1), time_part(2))


        Return dt
    End Function

    Private Sub cmdAlert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlert.Click
        Timer2.Enabled = False
        cmdAlert.BackColor = Color.LightGray

        Process.Start("http://glocal.chat-builder.com/guard/map.php?lat=" & selectedLat & "&lng=" & selectedLng)
    End Sub
End Class