Imports System.Windows.Forms

Public Class FrmMain

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub Utility_Click(sender As Object, e As EventArgs) Handles Utility.Click

    End Sub

    Private Sub DivMasterToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim divMaster As New FrmLogin
        divMaster.MdiParent = Me
        divMaster.Show()
    End Sub

    Private Sub StaffMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaffMasterToolStripMenuItem.Click
        Dim staffMaster As New frmStaffMaster
        staffMaster.MdiParent = Me
        staffMaster.Show()
    End Sub

    Private Sub StudenMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudenMasterToolStripMenuItem.Click
        Dim studentMaster As New FrmStudenMaster
        studentMaster.MdiParent = Me
        studentMaster.Show()
    End Sub

    Private Sub SubjectMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubjectMasterToolStripMenuItem.Click
        Dim subjectMaster As New FrmSubjectMaster
        subjectMaster.MdiParent = Me
        subjectMaster.Show()
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        setUserAccessRights()

    End Sub

    Private Sub FrmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'Me.Dispose()
    End Sub

    Public Sub setUserAccessRights()
        Try
            tsslLoginName.Text = "User Name : '" + loginUserName + "' || "
            tsslAccessBy.Text = "User Type : '" + loginUserType + "' || "
            tsslAllowToAccess.Text = "Date : " + DateTime.Now.ToShortDateString()

            'Dim strUserRoleAdmin As String = "Admin"
            'Dim strUtilityMenu As String = "Utility"
            'MenuStrip.Items.Item("Utility").Enabled = False

            For Each mainMenu As ToolStripMenuItem In MenuStrip.Items
                If loginUserType <> "Admin" Then
                    MenuStrip.Items.Item("Masters").Enabled = False
                    If mainMenu.Name = "Utility" Then
                        For Each subItem As ToolStripMenuItem In mainMenu.DropDownItems
                            If loginUserType = "Teacher" Then
                                If subItem.Name = "GenerateTimeTableToolStripMenuItem" Or subItem.Name = "UpdateToolStripMenuItem" Or subItem.Name = "AddUser" Then
                                    subItem.Visible = False
                                End If
                            ElseIf loginUserType = "Student" Then
                                If subItem.Name = "StudentDetailsToolStripMenuItem" Or subItem.Name = "GenerateTimeTableToolStripMenuItem" Or subItem.Name = "UpdateToolStripMenuItem" Or subItem.Name = "AddUser" Then
                                    subItem.Visible = False
                                End If
                            End If
                        Next
                    End If
                End If
                'Return
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub

    Private Sub tsmExit_Click(sender As Object, e As EventArgs) Handles tsmExit.Click
        Me.Hide()
        Dim frmLogin As New FrmLogin
        frmLogin.Show()
    End Sub

    Private Sub AddUser_Click(sender As Object, e As EventArgs) Handles AddUser.Click
        Dim frmAddUser As New FrmAddUser
        frmAddUser.MdiParent = Me
        frmAddUser.Show()
    End Sub

    Private Sub MyDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MyDetailsToolStripMenuItem.Click
        Dim frmMyDetail As New FrmMyDetail
        frmMyDetail.MdiParent = Me
        frmMyDetail.Show()
    End Sub

    Private Sub StudentDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentDetailsToolStripMenuItem.Click
        Dim frmStudentDetails As New FrmStudentDetails
        frmStudentDetails.MdiParent = Me
        frmStudentDetails.Show()
    End Sub

    Private Sub GenerateTimeTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateTimeTableToolStripMenuItem.Click
        Dim frmGenrateTimeTable As New FrmGenrateTimeTable
        frmGenrateTimeTable.MdiParent = Me
        frmGenrateTimeTable.Show()
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
        Dim FrmupdateTimeTable As New FrmUpdateTimeTable
        FrmupdateTimeTable.MdiParent = Me
        FrmupdateTimeTable.Show()
    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        Dim frmViewTimeTable As New FrmViewTimeTable
        frmViewTimeTable.MdiParent = Me
        frmViewTimeTable.Show()
    End Sub
End Class
