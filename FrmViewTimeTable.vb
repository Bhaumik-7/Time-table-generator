Imports System.IO

Public Class FrmViewTimeTable
    Private Sub FrmViewTimeTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fillStaffData()
        fillSUbjectData()
        fillClassData()
        cleraControls()

        If loginUserType = "Student" Then
            'getViewTimeTableData(0, 0, 0, 0, 0)
            'GroupBox1.Location = New Point(24, 12)
            ddlClassName.SelectedValue = getClassIDData().ToString()
            ddlClassName.Enabled = False
        ElseIf loginUserType = "Teacher" Then
            ddlTeacherName.SelectedValue = selectedStaffIDData().ToString()
            ddlTeacherName.Enabled = False
        End If

        'WebBrowser1
        ''WebBrowser1.Navigate("about:blank")

        'WebBrowserContentDisplay()

    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        If validation() Then

            'selectedStaffID As String, selectedSubjectID As String, selectedClassId As String, selectedTime As String, selectedWeekOftheDay As String
            Dim selectedStaffID As String = ddlTeacherName.SelectedValue()
            Dim selectedSubjectID As String = ddlSubjectName.SelectedValue()
            Dim selectedClassId As String = ddlClassName.SelectedValue()
            Dim selectedTime As String = ddlTimes.Text.Trim()
            Dim selectedWeekOftheDay As String = ddlWeekOfDays.Text.Trim()

            IIf(ddlTeacherName.Text = "---Select---", "", selectedStaffID)
            IIf(ddlSubjectName.Text = "---Select---", "", selectedSubjectID)
            IIf(ddlClassName.Text = "---Select---", "", selectedClassId)
            IIf(ddlTimes.SelectedItem = "---Select---", "", selectedTime)
            IIf(ddlWeekOfDays.SelectedItem = "---Select---", "", selectedWeekOftheDay)

            getViewTimeTableData(selectedStaffID, selectedSubjectID, selectedClassId, selectedTime, selectedWeekOftheDay)

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        cleraControls()
        'WebBrowserContentDisplay()
    End Sub

    Private Sub cleraControls()
        'ddlTeacherName.Text = "---Select---"
        ddlSubjectName.Text = "---Select---"
        ddlTimes.SelectedItem = "---Select---"
        ddlWeekOfDays.SelectedItem = "---Select---"
        'ddlTeacherName.Focus()
        'GroupBox2.Enabled = False
        'getUpdatedTimeTableData(TimeTableID)
        dgvViewTimeTableView.DataSource = Nothing

        If loginUserType = "Student" Then
            'ddlClassName.SelectedValue = getClassIDData().ToString()
            ddlClassName.Enabled = False
        ElseIf loginUserType = "Teacher" Then
            ddlTeacherName.Enabled = False
        Else
            ddlClassName.Text = "---Select---"
            ddlTeacherName.Text = "---Select---"
        End If

        btnViewTimeTable.Visible = False
    End Sub

    Private Sub getViewTimeTableData(selectedStaffID As String, selectedSubjectID As String, selectedClassId As String, selectedTime As String, selectedWeekOftheDay As String)
        Try
            Dim getViewTimeTableQuery As String = "Select    
                                                        WeekOfDay, 
                                                        Time, 
                                                        subm.SubjectName,
                                                        CONCAT_WS('', cm.ClassName,' ',cm.DivName) AS ClassName,                                                   
                                                        CONCAT_WS('', sm.FirstName,' ',sm.MidName,' ',sm.LastName) AS StaffName
                                                    FROM  
	                                                    genratedtimetable gtt
                                                    LEFT join staffmst sm 
                                                        on sm.StaffID =   gtt.StaffID 
                                                    LEFT join classmst cm 
                                                        on cm.ClassID =   gtt.ClassID 
                                                    LEFT join subjectmst subm 
                                                        on subm.SubjectID =  gtt.SubjectID " +
                                                "Where 1 = 1 "
            'If loginUserType <> "Student" Then

            If loginUserType <> "Teacher" Then
                If selectedStaffID.Equals("0") Then
                    getViewTimeTableQuery = getViewTimeTableQuery + ""
                Else
                    getViewTimeTableQuery = getViewTimeTableQuery + " And gtt.StaffID =" + selectedStaffID
                End If
            End If

            If selectedSubjectID.Equals("0") Then
                getViewTimeTableQuery = getViewTimeTableQuery + ""
            Else
                getViewTimeTableQuery = getViewTimeTableQuery + " And gtt.SubjectID =" + selectedSubjectID
            End If

            If loginUserType <> "Student" Then
                If selectedClassId.Equals("0") Then
                    getViewTimeTableQuery = getViewTimeTableQuery + ""
                Else
                    getViewTimeTableQuery = getViewTimeTableQuery + " And gtt.ClassID =" + selectedClassId
                End If
            End If

            If selectedTime.Equals("---Select---") Then
                getViewTimeTableQuery = getViewTimeTableQuery + ""
            Else
                getViewTimeTableQuery = getViewTimeTableQuery + " And Time ='" + selectedTime + "'"
            End If

            If selectedWeekOftheDay.Equals("---Select---") Then
                getViewTimeTableQuery = getViewTimeTableQuery + ""
            Else
                getViewTimeTableQuery = getViewTimeTableQuery + " And WeekOfDay ='" + selectedWeekOftheDay + "'"
            End If

            'IIf(selectedStaffID.Equals("0"), getViewTimeTableQuery = getViewTimeTableQuery + "", getViewTimeTableQuery = getViewTimeTableQuery + " gtt.StaffID =" + selectedStaffID) +
            '+IIf(selectedSubjectID.Equals("0"), getViewTimeTableQuery = getViewTimeTableQuery + "", getViewTimeTableQuery = getViewTimeTableQuery + " And gtt.SubjectID = " + selectedSubjectID) +
            '+IIf(selectedClassId.Equals("0"), getViewTimeTableQuery = getViewTimeTableQuery + "", getViewTimeTableQuery = getViewTimeTableQuery + " And gtt.ClassID = " + selectedClassId) +
            '+IIf(selectedTime.Equals(""), getViewTimeTableQuery = getViewTimeTableQuery + "", getViewTimeTableQuery = getViewTimeTableQuery + " And Time = '" + selectedTime) + "'" +
            '+IIf(selectedWeekOftheDay.Equals(""), getViewTimeTableQuery = getViewTimeTableQuery + "", getViewTimeTableQuery = getViewTimeTableQuery + " And WeekOfDay = '" + selectedWeekOftheDay + "'") +

            If loginUserType = "Student" Then
                getViewTimeTableQuery = getViewTimeTableQuery + " And gtt.ClassID = " + getClassIDData().ToString()
            End If

            If loginUserType = "Teacher" Then
                getViewTimeTableQuery = getViewTimeTableQuery + " And gtt.StaffID =" + selectedStaffIDData().ToString()
            End If

            getViewTimeTableQuery = getViewTimeTableQuery + "  order by WeekPriority,TimePriority"

            Dim StrViewtimetable As String = "viewtimetable"
            dgvViewTimeTableView.DataSource = getData(getViewTimeTableQuery, StrViewtimetable)

            logViewTimeTableQuery = getViewTimeTableQuery

            logTblUserData = getData(logViewTimeTableQuery.Replace("WeekOfDay, ", "WeekOfDay,TimePriority,WeekPriority,gtt.ClassID "), "logViewTimeTableQuery")

            If logTblUserData.Rows.Count() > 0 Then
                btnViewTimeTable.Visible = True
            Else
                'MsgBox("No data for selected Value", vbOKOnly, "View Time Table")
                'Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        ddlTeacherName.Focus()
    End Sub
    Private Function validation() As Boolean
        Dim ClassId As String = ddlClassName.SelectedValue

        If ddlTeacherName.Text = " - --Select---" And
        ddlSubjectName.Text = "---Select---" And
        ddlClassName.Text = "---Select---" And
        ddlTimes.SelectedItem = "---Select---" And
        ddlWeekOfDays.SelectedItem = "---Select---" Then

            'If (txtFirstName.Text.Trim() = "" And txtMiddleName.Text.Trim() = "" And txtLastName.Text.Trim() = "" And txtRollNo.Text.Trim() = "" And ClassId = 0) Then
            MsgBox("Enter Or Selcet atleast one value for view time table", vbOKOnly, "View Time Table")
            ddlTeacherName.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub fillClassData()
        Try
            Dim getClassQuery As String = "Select ClassID, CONCAT_WS('', ClassName,' - ',DivName) AS ClassName FROM `classmst`"

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

    Private Function getClassIDData() As Int32
        Try

            Dim retVale As Int32 = 0
            Dim getClassIDQuery As String = "SELECT 
	                                             COALESCE(ClassID,0) as ClassID 
                                           FROM staffmst where StaffID = " + loginStaffID

            Dim staffTable As String = "staffmst"

            Dim staffTbl As New DataTable
            staffTbl = getData(getClassIDQuery, staffTable)

            retVale = Convert.ToInt32(staffTbl.Rows(0)("ClassID"))
            Return retVale

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        Return 0
    End Function

    Private Function selectedStaffIDData() As Int32
        Try

            Dim retVale As Int32 = 0
            Dim getStaffIDQuery As String = "SELECT 
	                                             COALESCE(StaffID,0) as StaffID 
                                           FROM staffmst where StaffID = " + loginStaffID

            Dim staffTable As String = "staffmst"

            Dim staffTbl As New DataTable
            staffTbl = getData(getStaffIDQuery, staffTable)

            retVale = Convert.ToInt32(staffTbl.Rows(0)("StaffID"))
            Return retVale

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        Return 0
    End Function

    Private Sub btnViewTimeTable_Click(sender As Object, e As EventArgs) Handles btnViewTimeTable.Click
        If ddlClassName.Text = "---Select---" Then
            MsgBox("Selcet class name for view 'Time Table Format'", vbOKOnly, "View Time Table Format")
            ddlClassName.Focus()
        Else
            btnSave_Click(sender, e)

            If logTblUserData.Rows.Count() > 0 Then
                Dim frmViewTimeTableFormat As New FrmViewTimeTableFormat
                frmViewTimeTableFormat.Show()
            Else
                MsgBox("No data for selected Value", vbOKOnly, "View Time Table")
                Return
            End If
        End If

    End Sub
End Class