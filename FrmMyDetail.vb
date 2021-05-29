Public Class FrmMyDetail
    Private Sub FrmMyDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getMyDetailData()
    End Sub

    Public Sub getMyDetailData()
        Try
            Dim getMyDetailQuery As String = "SELECT 
                                                FirstName,
                                                MidName,
                                                LastName,
                                                StaffType,
                                                sm.ClassID,
                                                CONCAT_WS('', cm.ClassName,' ',cm.DivName) AS ClassName,    
                                                RollNo 
                                            FROM staffmst as sm 
                                            LEFT JOIN classmst cm
                                             on cm.ClassID = sm.ClassID
                                             where sm.StaffID = " + loginStaffID
            'StaffID
            Dim MyDetailTable As String = "MyDetailTdbl"
            Dim MyDetailTbl As New DataTable
            MyDetailTbl = getData(getMyDetailQuery, MyDetailTable)

            If MyDetailTbl.Rows.Count > 0 Then
                txtFirstName.Text = MyDetailTbl.Rows(0)("FirstName").ToString()
                txtMiddleName.Text = MyDetailTbl.Rows(0)("MidName").ToString()
                txtLastName.Text = MyDetailTbl.Rows(0)("LastName").ToString()
                txtFacultyType.Text = MyDetailTbl.Rows(0)("StaffType").ToString()
                txtClassName.Text = MyDetailTbl.Rows(0)("ClassName").ToString()
                txtRollNo.Text = MyDetailTbl.Rows(0)("RollNo").ToString()

                If loginUserType = "Student" Then
                    lblClassName.Visible = True
                    lblRollNo.Visible = True
                    txtClassName.Visible = True
                    txtRollNo.Visible = True
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        txtFirstName.Focus()
    End Sub

End Class