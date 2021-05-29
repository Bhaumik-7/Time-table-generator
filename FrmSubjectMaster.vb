Public Class FrmSubjectMaster
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If validation() And validatedDublicateSubjectData(txtSubjectName.Text.Trim()) Then

            Dim SubjectName As String = txtSubjectName.Text.ToString().Trim()

            insrtSubjectData(SubjectName)

            getSubjectData()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        cleraControls()
    End Sub

    Private Sub FrmSubjectMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getSubjectData()
        cleraControls()
        txtSubjectName.Focus()
    End Sub

    Public Sub getSubjectData()
        Try
            Dim getSubjectQuery As String = "SELECT SubjectName FROM `subjectmst`"
            'StaffType, sm.ClassID, SubjectID
            Dim subjectTable As String = "subjectmst"
            dgvSubjectView.DataSource = getData(getSubjectQuery, subjectTable)
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        txtSubjectName.Focus()
    End Sub

    Public Sub insrtSubjectData(Subject As String)
        Try
            Dim inertData As String
            Dim Values = String.Empty
            inertData = String.Format("INSERT INTO `subjectmst` (`SubjectName`) VALUES ('{0}')", Subject)

            If insertUpdateDelete(inertData) > 0 Then
                MsgBox("Subject data saved successfully..", vbOKOnly, "Save Data")
                cleraControls()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        conn.Close()
    End Sub

    Private Sub cleraControls()
        txtSubjectName.Text = String.Empty
        txtSubjectName.Focus()
    End Sub

    Private Function validation() As Boolean

        If txtSubjectName.Text.Trim() = "" Then
            MsgBox("Enter valid 'Subject Name'", vbOKOnly, "Subject Master")
            txtSubjectName.Focus()
            Return False
        End If
        Return True
    End Function

    Public Function validatedDublicateSubjectData(SubjectName As String) As Boolean
        Try
            Dim getStaffQuery As String = "SELECT
	                                            SubjectName                                                                                                  
                                            FROM 
	                                            subjectmst
                                            Where SubjectName ='" + SubjectName + "'"
            Dim SubjectTable As String = "Subjectbl"

            Dim Subjectdtl As New DataTable
            Subjectdtl = getData(getStaffQuery, SubjectTable)

            If Subjectdtl.Rows.Count() > 0 Then
                MsgBox("This subject name name already exists, Please enter different 'Subject Name'", vbOKOnly, "Subject Master")
                txtSubjectName.Focus()
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