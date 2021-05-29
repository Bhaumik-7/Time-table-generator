Imports MySql.Data.MySqlClient
Imports System.Data

Module CommonUtility

    Public conn As New MySqlConnection
    Public DatabaseName As String = "timetable" '"Database Name"
    Public server As String = "127.0.0.1" '"ip address here"
    Public userName As String = "root" '"sarmasar here"
    Public password As String = "" '"password here"
    Public loginUserName As String = ""
    Public loginUserID As String = ""
    Public loginUserType As String = ""
    Public loginStaffID As String = ""
    Public logTblUserData As New DataTable
    Public logViewTimeTableQuery As String = ""

    Public Sub connect()

        If Not conn Is Nothing Then conn.Close()
        conn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, userName, password, DatabaseName)
        Try
            conn.Open()
            'MsgBox("Connected")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'conn.Close()
    End Sub

    Public Function getData(getQuery As String, getQueryTable As String) As DataTable
        Dim retTable As New DataTable
        Try
            connect()
            Dim Search As New MySqlDataAdapter(getQuery, conn)
            Dim ds As DataSet = New DataSet
            Search.Fill(ds, getQueryTable)
            'dgvStaffMasterView.DataSource = ds.Tables(getQueryTable)
            retTable = ds.Tables(getQueryTable)
            'conn.Close()
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        Return retTable
    End Function

    Public Function insertUpdateDelete(strInsertString As String) As Int32 ' insrtData
        Dim retSuccVal As New Int32
        Try
            connect()

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            'conn.Open()
            'Catch ex As Exception
            'End Try

            'Dim FirstName As String = String.Empty
            'Dim MidName As String = String.Empty
            'Dim LastName As String = String.Empty
            'Dim StaffType As String = String.Empty
            'Dim StaffID As String = String.Empty
            'Dim Values = String.Empty
            'Values = String.Format("INSERT INTO `staffmst` (`FirstName` , `MidName`, `LastName`, `StaffType`, `StaffID`) VALUES ('{0}' , '{1}', '{2}', '{3}', '{4}')", FirstName, MidName, LastName, StaffType, StaffID)
            Dim cmd As New MySqlCommand(strInsertString, conn)
            retSuccVal = cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        conn.Close()
        Return retSuccVal
    End Function

    Public Sub getUserLoginDetails(strUserName As String)
        Try
            Dim getUserLoginQuery As String = "SELECT 
                                                    UserID,UserName,ul.StaffID,IsActive,sm.`StaffType` 
                                               FROM 
                                                    `userlogin` as ul 
                                                LEFT JOIn `staffmst` as sm 
                                                    ON ul.`StaffID` = sm.`StaffID` where UserName = '" + strUserName + "' "
            Dim userLoginTable As String = "studentmst"
            Dim userLoginTbl As New DataTable
            userLoginTbl = getData(getUserLoginQuery, userLoginTable)

            If userLoginTbl.Rows.Count > 0 Then
                loginUserID = userLoginTbl.Rows(0)("UserID").ToString()
                loginUserName = userLoginTbl.Rows(0)("UserName").ToString()
                loginUserType = userLoginTbl.Rows(0)("StaffType").ToString()
                loginStaffID = userLoginTbl.Rows(0)("StaffID").ToString()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

End Module
