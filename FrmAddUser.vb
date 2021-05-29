Public Class FrmAddUser
    Private Sub FrmAddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'UserID, userName, Pwd, StaffID, IsActive
        'UserID, userName, StaffID, StaffType, IsActive  

        fillStaffData()
        getUserData()
        cleraControls()
        txtUserName.Focus()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If validation() And validatedDublicateUserData(txtUserName.Text.Trim()) Then

            Dim UserName As String = txtUserName.Text.ToString().Trim()
            Dim Password As String = txtPassword.Text.ToString().Trim()
            Dim StaffID As String = ddlFacultyName.SelectedValue
            'Dim IsActive As String = ddlIsActive.SelectedValue

            insertUserData(UserName, Password, StaffID)

            fillStaffData()
            getUserData()

        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        cleraControls()
    End Sub

    Public Sub getUserData()
        Try
            Dim getStaffQuery As String = "SELECT
	                                            `UserName`, 
                                                CONCAT_WS('', sm.FirstName,' ',sm.MidName,' ',sm.LastName,' - ',sm.StaffType) AS StaffName                                                  
                                            FROM 
	                                            userlogin as ul
                                            Left Join staffmst as sm
	                                            on sm.StaffID = ul.StaffID"
            'IF(`IsActive` = 1,'Yes','No') `IsActive`, `UserID` 
            Dim UserTable As String = "Userlogin"
            dgvUserView.DataSource = getData(getStaffQuery, UserTable)
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        txtUserName.Focus()
    End Sub
    Public Sub insertUserData(UserName As String, Password As String, StaffID As Int32)
        Try
            Dim inertData As String
            Dim Values = String.Empty
            inertData = String.Format("INSERT INTO `userlogin` (`UserName`, `Pwd`, `StaffID`, `IsActive`) VALUES ('{0}', '{1}', '{2}', '{3}')", UserName, Password, StaffID, 1)

            If insertUpdateDelete(inertData) > 0 Then
                MsgBox("User data saved successfully..", vbOKOnly, "Save Data")
                cleraControls()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        conn.Close()
    End Sub
    Private Sub cleraControls()
        txtUserName.Text = String.Empty
        txtPassword.Text = String.Empty
        'ddlFacultyName.SelectedIndex = 0
        txtUserName.Focus()
    End Sub

    Private Sub fillStaffData()
        Try
            Dim getStaffQuery As String = "SELECT 
	                                            StaffID, CONCAT_WS('', FirstName,' ',MidName,' ',LastName,' - ',`StaffType`) AS StaffName 
                                            FROM `staffmst` 
                                            where 
	                                            StaffID NOT IN (SELECT StaffID from userlogin) order by FirstName"

            Dim staffTable As String = "staffmst"

            Dim staffTb As New DataTable
            staffTb = getData(getStaffQuery, staffTable)
            'cmbClassName.DisplayMember = "ClassName"
            'cmbClassName.ValueMember = "ClassID"
            'cmbClassName.DataSource = clsTable

            With ddlFacultyName
                .DataSource = staffTb.DefaultView
                .ValueMember = "StaffID"
                .DisplayMember = "StaffName"
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        txtUserName.Focus()
    End Sub

    Private Function validation() As Boolean

        If txtUserName.Text.Trim() = "" Then
            MsgBox("Enter valid 'First Name'", vbOKOnly, "User Master")
            txtUserName.Focus()
            Return False
        ElseIf txtPassword.Text.Trim() = "" Then
            MsgBox("Enter valid 'Password'", vbOKOnly, "User Master")
            txtPassword.Focus()
            Return False
        ElseIf ddlFacultyName.Items.Count() = 0 Then
            MsgBox("Add first new faculty/student", vbOKOnly, "User Master")
            ddlFacultyName.Focus()
            Return False
        End If
        Return True
    End Function

    Public Function validatedDublicateUserData(UserName As String) As Boolean
        Try
            Dim getStaffQuery As String = "SELECT
	                                            `UserID`, `UserName`                                                                                                  
                                            FROM 
	                                            userlogin
                                            Where UserName ='" + UserName + "'"
            Dim UserTable As String = "Userlogin"

            Dim Userdtl As New DataTable
            Userdtl = getData(getStaffQuery, UserTable)

            If Userdtl.Rows.Count() > 0 Then
                MsgBox("This user name already exists, Please enter different 'User Name'", vbOKOnly, "User Master")
                txtUserName.Focus()
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