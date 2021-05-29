Public Class FrmStudentDetails
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        If validation() Then

            Dim FirstName As String = txtFirstName.Text.ToString().Trim()
            Dim MidName As String = txtMiddleName.Text.ToString().Trim()
            Dim LastName As String = txtLastName.Text.ToString().Trim()
            Dim ClassId As String = ddlClassName.SelectedValue
            Dim RollNo As String = Convert.ToInt32(IIf(txtRollNo.Text.Trim().Equals(""), 0, txtRollNo.Text.Trim()))

            getStudentData(FirstName, MidName, LastName, ClassId, RollNo)

        End If

    End Sub

    Private Sub FrmStudentDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fillClassData()

    End Sub

    Public Sub getStudentData(FirstName As String, MidName As String, LastName As String, ClassId As String, RollNo As String)
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
                                            where sm.StaffType = 'Student'
                                            and (                                           
                                                    FirstName = '" + IIf(FirstName.Equals(""), "''", FirstName) + "' OR " +
                                                   " MidName = '" + IIf(MidName.Equals(""), "''", MidName) + "' OR " +
                                                   " LastName = '" + IIf(LastName.Equals(""), "''", LastName) + "' OR " +
                                                   " RollNo = " + RollNo + " OR " +
                                                   " sm.ClassID =  " + ClassId +
                                                " )"

            'StaffType, sm.ClassID,
            Dim studentTable As String = "studentmst"
            dgvStudenView.DataSource = getData(getStaffQuery, studentTable)
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        txtFirstName.Focus()
    End Sub

    Private Function validation() As Boolean
        Dim ClassId As String = ddlClassName.SelectedValue

        If (txtFirstName.Text.Trim() = "" And txtMiddleName.Text.Trim() = "" And txtLastName.Text.Trim() = "" And txtRollNo.Text.Trim() = "" And ClassId = 0) Then
            MsgBox("Enter or selcet atleast one value for student details", vbOKOnly, "Student Master")
            txtFirstName.Focus()
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
        txtFirstName.Focus()
    End Sub

End Class