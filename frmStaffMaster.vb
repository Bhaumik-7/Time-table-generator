Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmStaffMaster

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'connect()

        getStaffData()
        cleraControls()
        txtFirstName.Focus()

        'cmbFacultyType.SelectedText = "Teacher"
    End Sub

    Public Sub getStaffData()
        Try
            Dim getStaffQuery As String = "SELECT 
                                                FirstName,
                                                MidName,
                                                LastName,
                                                StaffType as FacultyType
                                            FROM staffmst where StaffType <> 'Student'"
            'StaffID
            Dim staffTable As String = "staffmst"
            dgvFacultyView.DataSource = getData(getStaffQuery, staffTable)
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        txtFirstName.Focus()
    End Sub

    Public Sub insrtStaffData(FirstName As String, MidName As String, LastName As String, StaffType As String)
        Try
            Dim inertData As String
            Dim Values = String.Empty
            'inertData = String.Format("INSERT INTO `staffmst` (`FirstName` , `MidName`, `LastName`, `StaffType`, `StaffID`) VALUES ('{0}' , '{1}', '{2}', '{3}', '{4}')", FirstName, MidName, LastName, StaffType, StaffID)
            inertData = String.Format("INSERT INTO `staffmst` (`FirstName` , `MidName`, `LastName`, `StaffType`) VALUES ('{0}', '{1}', '{2}', '{3}')", FirstName, MidName, LastName, StaffType)

            If insertUpdateDelete(inertData) > 0 Then
                MsgBox("Faculty data saved successfully..", vbOKOnly, "Save Data")
                cleraControls()
            End If


            'connect()
            ''conn.Open()
            ''Catch ex As Exception
            ''End Try

            'Dim FirstName As String = String.Empty
            'Dim MidName As String = String.Empty
            'Dim LastName As String = String.Empty
            'Dim StaffType As String = String.Empty
            'Dim StaffID As String = String.Empty
            'Dim Values = String.Empty

            ''Values = String.Format("INSERT INTO `staffmst` (`FirstName` , `MidName`, `LastName`, `StaffType`, `StaffID`) VALUES ('{0}' , '{1}', '{2}', '{3}', '{4}')", FirstName, MidName, LastName, StaffType, StaffID)
            'Dim cmd As New MySqlCommand(Values)
            'cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        conn.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        cleraControls()
    End Sub

    Private Sub cleraControls()
        txtFirstName.Text = String.Empty
        txtMiddleName.Text = String.Empty
        txtLastName.Text = String.Empty
        cmbFacultyType.SelectedIndex = 0
        txtFirstName.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If validation() And validatedDublicateFacultyData(txtFirstName.Text.ToString().Trim(), txtMiddleName.Text.ToString().Trim(), txtLastName.Text.ToString().Trim(), cmbFacultyType.Text.ToString().Trim()) Then

            Dim FirstName As String = txtFirstName.Text.ToString().Trim()
            Dim MidName As String = txtMiddleName.Text.ToString().Trim()
            Dim LastName As String = txtLastName.Text.ToString().Trim()
            Dim FacultyType As String = cmbFacultyType.Text.Trim()

            insrtStaffData(FirstName, MidName, LastName, FacultyType)

            getStaffData()

        End If

    End Sub

    Private Function validation() As Boolean

        If txtFirstName.Text.Trim() = "" Then
            MsgBox("Enter valid 'First Name'", vbOKOnly, "Staff Master")
            txtFirstName.Focus()
            Return False
        ElseIf txtMiddleName.Text.Trim() = "" Then
            MsgBox("Enter valid 'Middle Name'", vbOKOnly, "Staff Master")
            txtMiddleName.Focus()
            Return False
        ElseIf txtLastName.Text.Trim() = "" Then
            MsgBox("Enter valid 'Last Name'", vbOKOnly, "Staff Master")
            txtLastName.Focus()
            Return False
        End If
        Return True

    End Function

    Public Function validatedDublicateFacultyData(FirstName As String, MidName As String, LastName As String, StaffType As String) As Boolean
        Try
            Dim getStaffQuery As String = "SELECT
	                                            FirstName,
                                                MidName,
                                                LastName,
                                                StaffType                                                                                                
                                            FROM 
	                                            staffmst
                                            Where  FirstName ='" + FirstName + "'" +
                                                   "and MidName ='" + MidName + "'" +
                                                   "and LastName ='" + LastName + "'" +
                                                   "and StaffType ='" + StaffType + "'"
            Dim StaffTable As String = "Subjectbl"

            Dim Staffdtl As New DataTable
            Staffdtl = getData(getStaffQuery, StaffTable)

            If Staffdtl.Rows.Count() > 0 Then
                MsgBox("This faculty name already exists, Please enter different 'Faculty Name'", vbOKOnly, "Faculty Master")
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
