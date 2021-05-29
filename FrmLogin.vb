Public Class FrmLogin
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If validation() Then
            userLoginValidated(txtUserName.Text.Trim(), txtPwd.Text.Trim())
        End If

    End Sub

    Private Sub userLoginValidated(strUserName As String, strUserPwd As String)
        Try
            Dim getClassQuery As String = "SELECT * FROM `userlogin` where `UserName` = '" + strUserName + "'  and `Pwd` = '" + strUserPwd + "'"
            Dim userLogin As String = "userlogin"
            Dim userLoginTable As New DataTable
            userLoginTable = getData(getClassQuery, userLogin)

            If userLoginTable.Rows.Count > 0 Then

                getUserLoginDetails(strUserName)

                Me.Hide()
                Dim frmMain As New FrmMain
                'frmMain.ShowDialog()
                frmMain.Show()
            Else
                MsgBox("Enter valid 'User Name' Or 'Password'", vbOKOnly, "User Login")
                txtUserName.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Function validation() As Boolean

        If txtUserName.Text.Trim() = "" Then
            MsgBox("Enter valid 'User Name'", vbOKOnly, "User Login")
            txtUserName.Focus()
            Return False
        ElseIf txtPwd.Text.Trim() = "" Then
            MsgBox("Enter valid 'Password'", vbOKOnly, "User Login")
            txtPwd.Focus()
            Return False
        End If
        Return True

    End Function

End Class