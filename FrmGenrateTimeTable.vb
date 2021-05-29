Public Class FrmGenrateTimeTable
    Private Sub FrmGenrateTimeTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fillStaffData()
        fillSUbjectData()
        fillClassData()

        ddlTimes.SelectedItem = "---Select---"
        ddlWeekOfDays.SelectedItem = "---Select---"

        getGenratedTimeTableData()

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
    Private Function validation() As Boolean
        Dim ClassId As String = ddlClassName.SelectedValue

        If (ddlTeacherName.Text.Equals("---Select---")) Then
            MsgBox("Selcet atleast one 'Teacher Name'", vbOKOnly, "Genrate Time Table")
            ddlTeacherName.Focus()
            Return False
        ElseIf (ddlSubjectName.Text.Equals("---Select---")) Then
            MsgBox("Selcet atleast one 'Subject Name'", vbOKOnly, "Genrate Time Table")
            ddlSubjectName.Focus()
            Return False
        ElseIf (ddlClassName.Text.Equals("---Select---")) Then
            MsgBox("Selcet atleast one 'Class Name'", vbOKOnly, "Genrate Time Table")
            ddlClassName.Focus()
            Return False
        ElseIf (ddlTimes.Text.Equals("---Select---")) Then
            MsgBox("Selcet atleast one 'Time'", vbOKOnly, "Genrate Time Table")
            ddlTimes.Focus()
            Return False
        ElseIf (ddlWeekOfDays.Text.Equals("---Select---") And chbxAllWeek.Checked = False) Then
            MsgBox("Selcet atleast one 'Week Of The Day'", vbOKOnly, "Genrate Time Table")
            ddlWeekOfDays.Focus()
            Return False
        ElseIf (ddlTeacherName.Text.Equals("---Select---")) Then
            MsgBox("Selcet atleast one 'Subject Name'", vbOKOnly, "Genrate Time Table")
            ddlSubjectName.Focus()
            Return False
        End If

        Return True

    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim TeacherId As String = ddlTeacherName.SelectedValue()
        Dim SubjectId As String = ddlSubjectName.SelectedValue()
        Dim ClassId As String = ddlClassName.SelectedValue()
        Dim Time As String = ddlTimes.Text.Trim()
        Dim TimePriority As String = 0
        Dim WeekPriority As String = ""
        Dim WeekOfTheDay As String = ddlWeekOfDays.Text.Trim()

        If validation() Then
            If chbxAllWeek.Checked Then

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

                For i As Integer = i To 5
                    'i = 4

                    'MsgBox("i = " & i, vbOKOnly, "I Value")

                    If i = 0 Then
                        WeekOfTheDay = "Monday"
                        WeekPriority = 1
                        'i = i + 1
                    ElseIf i = 1 Then
                        WeekOfTheDay = "Tuesday"
                        WeekPriority = 2
                        'i = i + 1
                    ElseIf i = 2 Then
                        WeekOfTheDay = "Wednesday"
                        WeekPriority = 3
                        'i = i + 1
                    ElseIf i = 3 Then
                        WeekOfTheDay = "Thursday"
                        WeekPriority = 4
                        'i = i + 1
                    ElseIf i = 4 Then
                        WeekOfTheDay = "Friday"
                        WeekPriority = 5
                        'i = i + 1
                    ElseIf i = 5 Then
                        WeekOfTheDay = "Saturday"
                        WeekPriority = 6
                        'i = i + 1
                    End If

                    If checkDublicateData(TeacherId, ClassId, Time, WeekOfTheDay, SubjectId) Then
                        If (insrtGenratedtimetableData(TeacherId, SubjectId, ClassId, Time, WeekOfTheDay, TimePriority, WeekPriority)) Then
                            MsgBox("Data saved successfully for '" & WeekOfTheDay & "'", vbOKOnly, "Save Data")
                        End If
                    End If

                    'MsgBox("i = " & i + 1, vbOKOnly, "I Value")
                Next

            Else
                If checkDublicateData(TeacherId, ClassId, Time, WeekOfTheDay, SubjectId) Then

                    '10:30 - 11:30
                    '11:30 - 12:30
                    '12:30 - 01:30
                    '02:00 - 03:00	
                    '03:00 - 04:00
                    '04:00 - 05:00

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

                    'Monday
                    'Tuesday
                    'Wednesday
                    'Thursday
                    'Friday
                    'Saturday

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

                    'TimePriority
                    'WeekPriority

                    'Public Function insrtGenratedtimetableData(TeacherId As String, SubjectId As String, ClassId As String, Time As String, WeekOfTheDay As String) As Int32
                    If (insrtGenratedtimetableData(TeacherId, SubjectId, ClassId, Time, WeekOfTheDay, TimePriority, WeekPriority)) Then
                        MsgBox("Genrate time table data saved successfully..", vbOKOnly, "Save Data")
                    End If
                End If
            End If
        End If


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        cleraControls()
    End Sub

    Private Sub cleraControls()
        ddlTeacherName.Text = "---Select---"
        ddlSubjectName.Text = "---Select---"
        ddlClassName.Text = "---Select---"
        ddlTimes.SelectedItem = "---Select---"
        ddlWeekOfDays.SelectedItem = "---Select---"
        ddlTeacherName.Focus()
    End Sub
    Private Sub enableFalseItems(comboBox As ComboBox)
        'For Each item As ListViewItem In comboBox.Items
        '    If comboBox.SelectedValue <> item.Text Then
        '        item.Sel = False
        '    End If
        'Next

        'For Each obj In comboBox.Items
        '    Dim item = TryCast(obj, {the object type Or class})
        '    If Not item Is Nothing Then
        '        'use the item as it is converted correctly
        '    End If
        'Next

        'For Each item As DataRowView In comboBox.Items
        '    'MsgBox(item.Row("valuecolumnname"))
        'Next
    End Sub

    Private Function insrtGenratedtimetableData(TeacherId As String, SubjectId As String, ClassId As String, Time As String, WeekOfTheDay As String, TimePriority As String, WeekPriority As String) As Int32
        Dim retValue As Int32
        Try 'TimeTableID, StaffID, WeekOfDay, ClassId, SubjectId, Time
            Dim inertData As String
            Dim Values = String.Empty
            inertData = String.Format("INSERT INTO `genratedtimetable` (`StaffID`, `WeekOfDay`, `ClassId`, `SubjectId`,`Time`,`TimePriority`,`WeekPriority`) VALUES ({0}, '{1}', {2}, {3}, '{4}', {5}, {6})", TeacherId, WeekOfTheDay, ClassId, SubjectId, Time, TimePriority, WeekPriority)
            retValue = insertUpdateDelete(inertData)
            If retValue > 0 Then
                'MsgBox("Data saved successfully..", vbOKOnly, "Genrate Time Table")
                MsgBox("Data saved successfully for '" & WeekOfTheDay & "'", vbOKOnly, "Save Data")
                cleraControls()
                retValue = 1
                getGenratedTimeTableData()
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
                                           Where " +
                                                   " Time ='" + selectedTime + "'" +
                                                   " and WeekOfDay ='" + selectedWeekOftheDay + "'" +
                                                     " and gtt.StaffID =" + selectedTeacherId
            'StaffID =" + selectedTeacherId + "" +  " and StaffType = 'Teacher'"  Where gtt.ClassID =" + selectedClassId + "" + 

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

    Private Sub getGenratedTimeTableData()
        Try
            Dim getGenratedTimeTableQuery As String = "SELECT 
                                                        CONCAT_WS('', sm.FirstName,' ',sm.MidName,' ',sm.LastName) AS StaffName,
                                                        subm.SubjectName,
                                                        CONCAT_WS('', cm.ClassName,' ',cm.DivName) AS ClassName,
                                                        Time,
                                                        WeekOfDay 
                                                    FROM  
	                                                    genratedtimetable gtt
                                                    LEFT join staffmst sm 
                                                        on sm.StaffID =   gtt.StaffID 
                                                    LEFT join classmst cm 
                                                        on cm.ClassID =   gtt.ClassID 
                                                    LEFT join subjectmst subm 
                                                        on subm.SubjectID =  gtt.SubjectID order by WeekPriority,TimePriority "

            'StaffType, sm.ClassID, TimeTableID, ClassName, DivName
            'gtt.StaffID,
            'gtt.SubjectID,
            'gtt.ClassID,
            Dim Strgenratedtimetable As String = "genratedtimetable"
            dgvGenratedTimeTableView.DataSource = getData(getGenratedTimeTableQuery, Strgenratedtimetable)
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        ddlTeacherName.Focus()
    End Sub

    Private Sub chbxAllWeek_Click(sender As Object, e As EventArgs) Handles chbxAllWeek.Click
        If chbxAllWeek.Checked Then
            ddlWeekOfDays.Enabled = False
        Else
            ddlWeekOfDays.Enabled = True
        End If
    End Sub
End Class