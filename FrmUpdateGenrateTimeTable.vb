Public Class FrmUpdateTimeTable
    Dim TimeTableID As String = String.Empty
    Dim SetTimeTableID As String = 0

    Private Sub FrmUpdateTimeTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fillStaffData()
        fillSUbjectData()
        fillClassData()

        getUpdatedTimeTableData(TimeTableID)

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim TeacherId As String = ddlTeacherName.SelectedValue()
        Dim SubjectId As String = ddlSubjectName.SelectedValue()
        Dim ClassId As String = ddlClassName.SelectedValue()
        Dim Time As String = ddlTimes.Text.Trim()
        Dim TimePriority As String = 0
        Dim WeekPriority As String = ""
        Dim WeekOfTheDay As String = ddlWeekOfDays.Text.Trim()

        If checkDublicateData(TeacherId, ClassId, Time, WeekOfTheDay, SubjectId) Then

            If (Time.Equals("10:30 - 11:30")) Then
                TimePriority = 1
            ElseIf (Time.Equals("11:30 - 12:30")) Then
                TimePriority = 2
            ElseIf (Time.Equals("12:30 - 01:30")) Then
                TimePriority = 3
            ElseIf (Time.Equals("02:00 - 03:00")) Then
                TimePriority = 4
            ElseIf (Time.Equals("03:00 - 04:00")) Then
                TimePriority = 5
            ElseIf (Time.Equals("04:00 - 05:00")) Then
                TimePriority = 6
            End If

            If (WeekOfTheDay.Equals("Monday")) Then
                WeekPriority = 1
            ElseIf (WeekOfTheDay.Equals("Tuesday")) Then
                WeekPriority = 2
            ElseIf (WeekOfTheDay.Equals("Wednesday")) Then
                WeekPriority = 3
            ElseIf (WeekOfTheDay.Equals("Thursday")) Then
                WeekPriority = 4
            ElseIf (WeekOfTheDay.Equals("Friday")) Then
                WeekPriority = 5
            ElseIf (WeekOfTheDay.Equals("Saturday")) Then
                WeekPriority = 6
            End If

            If (updateTimeTableData(TeacherId, SubjectId, ClassId, Time, WeekOfTheDay, TimePriority, WeekPriority, SetTimeTableID)) Then
                MsgBox("Time table data updated successfully..", vbOKOnly, "Update Data")
                cleraControls()
            End If

        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        cleraControls()
    End Sub

    Private Sub getUpdatedTimeTableData(TimeTableID As String)
        Try
            Dim getUpdatedTimeTableQuery As String = "SELECT                                                        
                                                        CONCAT_WS('', sm.FirstName,' ',sm.MidName,' ',sm.LastName) AS StaffName,
                                                        subm.SubjectName,
                                                        CONCAT_WS('', cm.ClassName,' ',cm.DivName) AS ClassName,
                                                        Time,
                                                        WeekOfDay,
                                                        gtt.StaffID,
                                                        gtt.SubjectID,
                                                        gtt.ClassID,
                                                        gtt.TimeTableID 
                                                    FROM  
	                                                    genratedtimetable gtt
                                                    LEFT join staffmst sm 
                                                        on sm.StaffID =   gtt.StaffID 
                                                    LEFT join classmst cm 
                                                        on cm.ClassID =   gtt.ClassID 
                                                    LEFT join subjectmst subm 
                                                        on subm.SubjectID =  gtt.SubjectID "

            If TimeTableID.Equals(String.Empty) Then

                'StaffType, sm.ClassID, TimeTableID, ClassName, DivName
                'gtt.StaffID,
                'gtt.SubjectID,
                'gtt.ClassID,
                Dim StrUpdatedtimetable As String = "updatedtimetable"
                dgvUpdateTimeTableView.AutoGenerateColumns = False
                getUpdatedTimeTableQuery = getUpdatedTimeTableQuery + " order by WeekPriority,TimePriority"
                dgvUpdateTimeTableView.DataSource = getData(getUpdatedTimeTableQuery, StrUpdatedtimetable)

            Else
                GroupBox2.Enabled = True
                getUpdatedTimeTableQuery = getUpdatedTimeTableQuery + " Where gtt.TimeTableID = " + TimeTableID
                getUpdatedTimeTableQuery = getUpdatedTimeTableQuery + " order by WeekPriority,TimePriority"

                Dim updatedtimeTbl As New DataTable
                updatedtimeTbl = getData(getUpdatedTimeTableQuery, "updatedtimeTblById")

                ddlTeacherName.SelectedValue = updatedtimeTbl.Rows(0)("StaffID").ToString()
                ddlSubjectName.SelectedValue = updatedtimeTbl.Rows(0)("SubjectID").ToString()
                ddlClassName.SelectedValue = updatedtimeTbl.Rows(0)("ClassID").ToString()
                ddlTimes.Text = updatedtimeTbl.Rows(0)("Time").ToString()
                ddlWeekOfDays.Text = updatedtimeTbl.Rows(0)("WeekOfDay").ToString()
                ddlTeacherName.Focus()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        ddlTeacherName.Focus()
    End Sub

    Private Sub dgvUpdateTimeTableView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUpdateTimeTableView.CellClick

        If e.ColumnIndex = 5 And e.RowIndex <> -1 Then

            Dim currentRow As Integer = Integer.Parse(e.RowIndex.ToString())
            'Dim currentColumnIndex As Integer = Integer.Parse(e.ColumnIndex.ToString())
            'Dim i As Integer
            'i = dgvUpdateTimeTableView.CurrentRow.Index

            'MsgBox(dgvUpdateTimeTableView.Rows(currentRow).Cells(9).Value.ToString())
            SetTimeTableID = dgvUpdateTimeTableView.Rows(currentRow).Cells(9).Value.ToString()
            getUpdatedTimeTableData(SetTimeTableID)
        End If

    End Sub
    Private Sub cleraControls()
        ddlTeacherName.Text = "---Select---"
        ddlSubjectName.Text = "---Select---"
        ddlClassName.Text = "---Select---"
        ddlTimes.SelectedItem = "---Select---"
        ddlWeekOfDays.SelectedItem = "---Select---"
        'ddlTeacherName.Focus()
        GroupBox2.Enabled = False
        SetTimeTableID = 0
        getUpdatedTimeTableData(TimeTableID)
    End Sub

    Private Sub fillClassData()
        Try
            Dim getClassQuery As String = "SELECT ClassID, CONCAT_WS('', ClassName,' - ',DivName) AS ClassName FROM `classmst`"

            Dim classTable As String = "classmst"

            Dim clsTable As New DataTable
            clsTable = getData(getClassQuery, classTable)

            ' Create a new row
            Dim dr As DataRow = clsTable.NewRow()
            dr("ClassID") = "0"
            dr("ClassName") = "---Select---"
            ' Insert it into the 0th index
            clsTable.Rows.InsertAt(dr, 0)

            With ddlClassName
                .DataSource = clsTable.DefaultView
                .ValueMember = "ClassID"
                .DisplayMember = "ClassName"
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub fillStaffData()
        Try
            Dim getStaffQuery As String = "SELECT 
	                                            StaffID, CONCAT_WS('', FirstName,' ',MidName,' ',LastName) AS StaffName 
                                            FROM `staffmst` 
                                            where 
	                                            StaffType = 'Teacher'"
            'StaffID, CONCAT_WS('', FirstName,' ',MidName,' ',LastName,' - ',`StaffType`) AS StaffName 
            Dim staffTable As String = "staffmst"

            Dim staffTb As New DataTable
            staffTb = getData(getStaffQuery, staffTable)

            ' Create a new row
            Dim dr As DataRow = staffTb.NewRow()
            dr("StaffID") = "0"
            dr("StaffName") = "---Select---"
            ' Insert it into the 0th index
            staffTb.Rows.InsertAt(dr, 0)

            With ddlTeacherName
                .DataSource = staffTb.DefaultView
                .ValueMember = "StaffID"
                .DisplayMember = "StaffName"
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub fillSUbjectData()
        Try
            Dim getStaffQuery As String = "SELECT 
	                                            SubjectID, SubjectName 
                                           FROM subjectmst"

            Dim subjectTable As String = "subjectmst"

            Dim subjectTbl As New DataTable
            subjectTbl = getData(getStaffQuery, subjectTable)

            ' Create a new row
            Dim dr As DataRow = subjectTbl.NewRow()
            dr("SubjectID") = "0"
            dr("SubjectName") = "---Select---"
            ' Insert it into the 0th index
            subjectTbl.Rows.InsertAt(dr, 0)

            With ddlSubjectName
                .DataSource = subjectTbl.DefaultView
                .ValueMember = "SubjectID"
                .DisplayMember = "SubjectName"
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Function checkDublicateData(selectedTeacherId As String, selectedClassId As String, selectedTime As String, selectedWeekOftheDay As String, selectedSubjectId As String) As Int32
        Try
            Dim checkDublicateDatQuery As String = "SELECT
	                                                TimeTableID, 
                                                    gtt.StaffID, 
                                                    gtt.SubjectID,
                                                    gtt.ClassID,
                                                    Time,
                                                    WeekOfDay,
                                                    CONCAT_WS('', sm.FirstName,' ',sm.MidName,' ',sm.LastName) AS StaffName,
                                                    subm.SubjectName 
                                            FROM  
	                                            genratedtimetable gtt
                                            LEFT join staffmst sm 
                                                on sm.StaffID =   gtt.StaffID 
                                            LEFT join subjectmst subm 
                                                on subm.SubjectID =   gtt.SubjectID  
                                            Where gtt.ClassID =" + selectedClassId + "" +
                                                   " And Time ='" + selectedTime + "'" +
                                                   " and WeekOfDay ='" + selectedWeekOftheDay + "'" +
                                                " and gtt.SubjectID ='" + selectedSubjectId + "'"
            'StaffID =" + selectedTeacherId + "" +  " and StaffType = 'Teacher'"  

            Dim chkDublicateTable As String = "GenrateTimeTable"

            Dim chkDublicatedTbl As New DataTable
            chkDublicatedTbl = getData(checkDublicateDatQuery, chkDublicateTable)

            'myTableData.Rows(i)(1)
            If chkDublicatedTbl.Rows.Count() > 0 Then
                MsgBox("Teacher: '" + chkDublicatedTbl.Rows(0)("StaffName").ToString() + "' with Subject: '" + chkDublicatedTbl.Rows(0)("SubjectName") + "' is already exists with same class name with same Time: '" + chkDublicatedTbl.Rows(0)("Time") + "' on '" + chkDublicatedTbl.Rows(0)("WeekOfDay").ToString() + "', Please enter different data", vbOKOnly, "Genrate Time Table")
                ddlTeacherName.Focus()
                Return False
            Else
                Dim checkDublicateDatQuery2 As String = "SELECT
	                                                TimeTableID, 
                                                    gtt.StaffID, 
                                                    gtt.SubjectID,
                                                    gtt.ClassID,
                                                    Time,
                                                    WeekOfDay,
                                                    CONCAT_WS('', sm.FirstName,' ',sm.MidName,' ',sm.LastName) AS StaffName,
                                                    subm.SubjectName 
                                            FROM  
	                                            genratedtimetable gtt
                                            LEFT join staffmst sm 
                                                on sm.StaffID =   gtt.StaffID 
                                            LEFT join subjectmst subm 
                                                on subm.SubjectID =   gtt.SubjectID  
                                            Where gtt.ClassID =" + selectedClassId + "" +
                                                   " And gtt.SubjectID ='" + selectedSubjectId + "'" +
                                                   " and WeekOfDay ='" + selectedWeekOftheDay + "'"
                'StaffID =" + selectedTeacherId + "" +  " and StaffType = 'Teacher'"  

                Dim chkDublicateTable2 As String = "GenrateTimeTable2"

                Dim chkDublicatedTbl2 As New DataTable
                chkDublicatedTbl2 = getData(checkDublicateDatQuery2, chkDublicateTable2)

                If chkDublicatedTbl2.Rows.Count() > 0 Then
                    MsgBox("Teacher: '" + chkDublicatedTbl2.Rows(0)("StaffName").ToString() + "' with same Subject: '" + chkDublicatedTbl2.Rows(0)("SubjectName") + "'" + " is already exists with same class name with different Time: '" + chkDublicatedTbl2.Rows(0)("Time") + "' on '" + chkDublicatedTbl2.Rows(0)("WeekOfDay").ToString() + "', Please enter different data", vbOKOnly, "Genrate Time Table")
                    ddlTeacherName.Focus()
                    Return False
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
            Return False
        End Try
        Return True
    End Function

    Private Function updateTimeTableData(TeacherId As String, SubjectId As String, ClassId As String, Time As String, WeekOfTheDay As String, TimePriority As String, WeekPriority As String, SetTimeTableID As String) As Int32
        Dim retValue As Int32
        Try 'TimeTableID, StaffID, WeekOfDay, ClassId, SubjectId, Time
            Dim inertData As String
            Dim Values = String.Empty
            inertData = "UPDATE genratedtimetable SET StaffID=" + TeacherId + ", WeekOfDay='" + WeekOfTheDay + "', ClassId=" + ClassId + ", SubjectId=" + SubjectId + ", Time='" + Time + "', TimePriority=" + TimePriority + ", WeekPriority=" + WeekPriority +
             " Where TimeTableID = " + SetTimeTableID
            retValue = insertUpdateDelete(inertData)
            If retValue > 0 Then
                MsgBox("Data updated successfully..", vbOKOnly, "Updated Time Table")
                cleraControls()
                retValue = 1
                getUpdatedTimeTableData(TimeTableID)
            End If
            retValue = 0
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
            retValue = 0
        End Try
        conn.Close()
        Return retValue
    End Function
End Class