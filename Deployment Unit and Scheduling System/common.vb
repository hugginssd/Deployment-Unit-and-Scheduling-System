Module common
    Public cn As New ADODB.Connection

    Public Sub openConneciton(ByVal path)
        Try
            cn.ConnectionString = "DSN=zrp_monitor"
            cn.Open()
        Catch ex As Exception
            MsgBox("Could not connect to server.")
        End Try
    End Sub
    Public Function rs(ByVal table As String) As ADODB.Recordset
        Try
            rs = New ADODB.Recordset
            rs.Open(table, cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Catch ex As Exception

        End Try


    End Function
    Public Sub closeConnection()
        cn.Close()
    End Sub

    Public Function getEmployeeID(ByVal employee_number As String) As String
        Dim emp_id As String = 0

        With rs("select * from tbl_employee where employee_number = '" & employee_number & "'")
            If Not .EOF Or Not .BOF Then
                emp_id = .Fields("id").Value
            End If
        End With

        Return emp_id
    End Function

    Public Function employeeDeployed(ByVal site_id As String, ByVal employee_id As String) As Boolean

        With rs("select * from tbl_deployment where site_id = " & site_id & " and employee_id = " & employee_id)
            If Not .EOF Or Not .BOF Then
                Return True
            End If
        End With

        Return False
    End Function

    Public Function getRowCount(ByVal table As String) As Integer
        Dim cnt As Integer = 0
        With rs("select count(*) as cnt from " & table)
            cnt = .Fields("cnt").Value
        End With
        Return cnt
    End Function
End Module
