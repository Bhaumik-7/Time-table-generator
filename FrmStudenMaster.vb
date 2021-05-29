Public Class FrmStudenMaster
    Private Sub FrmStudenMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillClassData()
        getStudentData()
        cleraControls()
        txtFirstName.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If validation() And validatedDublicateStaffData(txtFirstName.Text.ToString().Trim(), txtMiddleName.Text.ToString().Trim(), txtLastName.Text.ToString().Trim(), Convert.ToInt32(ddlClassName.SelectedValue), Convert.ToInt32(IIf(txtRollNo.Text.Trim().Equals(""), 0, txtRollNo.Text.Trim()))) Then

            Dim FirstName As String = txtFirstName.Text.ToString().Trim()
            Dim MidName As String = txtMiddleName.Text.ToString().Trim()
            Dim LastName As String = txtLastName.Text.ToString().Trim()
            Dim FacultyType As String = "Student"
            Dim ClassId As String = ddlClassName.SelectedValue
            Dim RollNo As String = txtRollNo.Text.Trim()

            insrtStudentData(FirstName, MidName, LastName, FacultyType, ClassId, RollNo)

            getStudentData()

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        cleraControls()
    End Sub

    Public Sub getStudentData()
        Try
            Dim getStaffQuery As String = "SELECT 
                                                RollNo,
                                                FirstName,
                                                MidName,
                                                LastName,
                                                CONCAT_WS('', cm.ClassName,'-',cm.DivName) AS ClassName                                                
                                            FROM staffmst as sm
                                            Left Join classmst as cm
                                            	on cm.ClassID = sm.ClassID   
                                            where sm.StaffType = 'Student'"
            'StaffType, sm.ClassID,
            Dim studentTable As String = "studentmst"
            dgvStudenView.DataSource = getData(getStaffQuery, studentTable)
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        txtFirstName.Focus()
    End Sub

    Public Sub insrtStudentData(FirstName As String, MidName As String, LastName As String, StaffType As String, ClassId As Int32, RollNo As Int32)
        Try
            Dim inertData As String
            Dim Values = String.Empty
            'inertData = String.Format("INSERT INTO `staffmst` (`FirstName` , `MidName`, `LastName`, `StaffType`, `StaffID`) VALUES ('{0}' , '{1}', '{2}', '{3}', '{4}')", FirstName, MidName, LastName, StaffType, StaffID)
            inertData = String.Format("INSERT INTO `staffmst` (`FirstName` , `MidName`, `LastName`, `StaffType`, `ClassID`,`RollNo`) VALUES ('{0}', '{1}', '{2}', '{3}',{4}, {5})", FirstName, MidName, LastName, StaffType, ClassId, RollNo)

            If insertUpdateDelete(inertData) > 0 Then
                MsgBox("Student data saved successfully..", vbOKOnly, "Save Data")
                cleraControls()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        conn.Close()
    End Sub
    Private Sub cleraControls()
        txtFirstName.Text = String.Empty
        txtMiddleName.Text = String.Empty
        txtLastName.Text = String.Empty
        'cmbClassName.SelectedIndex = 0
        txtFirstName.Focus()
    End Sub

    Private Sub fillClassData()
        Try
            Dim getClassQuery As String = "SELECT ClassID, CONCAT_WS('', ClassName,' - ',DivName) AS ClassName FROM `classmst`"

            Dim classTable As String = "classmst"

            Dim clsTable As New DataTable
            clsTable = getData(getClassQuery, classTable)
            'cmbClassName.DisplayMember = "ClassName"
            'cmbClassName.ValueMember = "ClassID"
            'cmbClassName.DataSource = clsTable

            With ddlClassName
                .DataSource = clsTable.DefaultView
                .ValueMember = "ClassID"
                .DisplayMember = "ClassName"
            End With

            'ddlClassName.DisplayMember = "ClassName"
            'ddlClassName.ValueMember = "ClassID"
            'ddlClassName.DataSource = getData(getClassQuery, classTable)

            'ddlClassName.ValueMember = clsTable.Columns(1).ToString()
            'ddlClassName.DisplayMember = clsTable.Columns(0).ToString()
            'ddlClassName.DataSource = clsTable

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        txtFirstName.Focus()
    End Sub

    Private Function validation() As Boolean

        If txtFirstName.Text.Trim() = "" Then
            MsgBox("Enter valid 'First Name'", vbOKOnly, "Student Master")
            txtFirstName.Focus()
            Return False
        ElseIf txtMiddleName.Text.Trim() = "" Then
            MsgBox("Enter valid 'Middle Name'", vbOKOnly, "Student Master")
            txtMiddleName.Focus()
            Return False
        ElseIf txtLastName.Text.Trim() = "" Then
            MsgBox("Enter valid 'Last Name'", vbOKOnly, "Student Master")
            txtLastName.Focus()
            Return False
        ElseIf txtRollNo.Text.Trim() = "" Then
            MsgBox("Enter valid 'Roll No.'", vbOKOnly, "Student Master")
            txtRollNo.Focus()
            Return False
        End If
        Return True
    End Function

    Public Function validatedDublicateStaffData(FirstName As String, MidName As String, LastName As String, ClassId As Int32, RollNo As Int32) As Boolean
        Try
            Dim getStaffQuery As String = "SELECT
	                                            FirstName,
                                                MidName,
                                                LastName,
                                                StaffType                                                                                                 
                                            FROM  
	                                            staffmst 
                                            Where  FirstName ='" + FirstName + "'" +
                                                   " and MidName ='" + MidName + "'" +
                                                   " and LastName ='" + LastName + "'" +
                                                   " and ClassID =" + ClassId.ToString() + "" +
                                                   " and RollNo =" + RollNo.ToString() + "" +
                                                   " and StaffType = 'Student'"

            Dim StaffTable As String = "Subjectbl"

            Dim Staffdtl As New DataTable
            Staffdtl = getData(getStaffQuery, StaffTable)

            If Staffdtl.Rows.Count() > 0 Then
                MsgBox("This student name already exists with same class, Please enter different 'Student Name'", vbOKOnly, "Student Master")
                txtFirstName.Focus()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
            Return False
        End Try
        Return True
    End Function

End Class