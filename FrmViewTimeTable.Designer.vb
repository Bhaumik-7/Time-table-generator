<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmViewTimeTable
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ddlSubjectName = New System.Windows.Forms.ComboBox()
        Me.ddlTeacherName = New System.Windows.Forms.ComboBox()
        Me.ddlClassName = New System.Windows.Forms.ComboBox()
        Me.ddlWeekOfDays = New System.Windows.Forms.ComboBox()
        Me.ddlTimes = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnViewTimeTable = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvViewTimeTableView = New System.Windows.Forms.DataGridView()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvViewTimeTableView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ddlSubjectName)
        Me.GroupBox2.Controls.Add(Me.ddlTeacherName)
        Me.GroupBox2.Controls.Add(Me.ddlClassName)
        Me.GroupBox2.Controls.Add(Me.ddlWeekOfDays)
        Me.GroupBox2.Controls.Add(Me.ddlTimes)
        Me.GroupBox2.Controls.Add(Me.btnSearch)
        Me.GroupBox2.Controls.Add(Me.btnViewTimeTable)
        Me.GroupBox2.Controls.Add(Me.btnCancel)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(24, 12)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.Size = New System.Drawing.Size(645, 230)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search time table details"
        '
        'ddlSubjectName
        '
        Me.ddlSubjectName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ddlSubjectName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlSubjectName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddlSubjectName.FormattingEnabled = True
        Me.ddlSubjectName.Location = New System.Drawing.Point(173, 69)
        Me.ddlSubjectName.Name = "ddlSubjectName"
        Me.ddlSubjectName.Size = New System.Drawing.Size(251, 21)
        Me.ddlSubjectName.TabIndex = 3
        '
        'ddlTeacherName
        '
        Me.ddlTeacherName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ddlTeacherName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlTeacherName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddlTeacherName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ddlTeacherName.FormattingEnabled = True
        Me.ddlTeacherName.Location = New System.Drawing.Point(173, 38)
        Me.ddlTeacherName.Name = "ddlTeacherName"
        Me.ddlTeacherName.Size = New System.Drawing.Size(251, 21)
        Me.ddlTeacherName.TabIndex = 3
        '
        'ddlClassName
        '
        Me.ddlClassName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ddlClassName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlClassName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddlClassName.FormattingEnabled = True
        Me.ddlClassName.Location = New System.Drawing.Point(173, 96)
        Me.ddlClassName.Name = "ddlClassName"
        Me.ddlClassName.Size = New System.Drawing.Size(251, 21)
        Me.ddlClassName.TabIndex = 3
        '
        'ddlWeekOfDays
        '
        Me.ddlWeekOfDays.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ddlWeekOfDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlWeekOfDays.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddlWeekOfDays.FormattingEnabled = True
        Me.ddlWeekOfDays.Items.AddRange(New Object() {"---Select---", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"})
        Me.ddlWeekOfDays.Location = New System.Drawing.Point(173, 153)
        Me.ddlWeekOfDays.Name = "ddlWeekOfDays"
        Me.ddlWeekOfDays.Size = New System.Drawing.Size(251, 21)
        Me.ddlWeekOfDays.TabIndex = 3
        '
        'ddlTimes
        '
        Me.ddlTimes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ddlTimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlTimes.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddlTimes.FormattingEnabled = True
        Me.ddlTimes.Items.AddRange(New Object() {"---Select---", "10:30 - 11:30", "11:30 - 12:30", "12:30 - 01:30", "02:00 - 03:00", "03:00 - 04:00", "04:00 - 05:00"})
        Me.ddlTimes.Location = New System.Drawing.Point(173, 125)
        Me.ddlTimes.Name = "ddlTimes"
        Me.ddlTimes.Size = New System.Drawing.Size(251, 21)
        Me.ddlTimes.TabIndex = 3
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(163, 189)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(63, 25)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnViewTimeTable
        '
        Me.btnViewTimeTable.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewTimeTable.Location = New System.Drawing.Point(300, 189)
        Me.btnViewTimeTable.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnViewTimeTable.Name = "btnViewTimeTable"
        Me.btnViewTimeTable.Size = New System.Drawing.Size(124, 25)
        Me.btnViewTimeTable.TabIndex = 6
        Me.btnViewTimeTable.Text = "View Time Table Format"
        Me.btnViewTimeTable.UseVisualStyleBackColor = True
        Me.btnViewTimeTable.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(234, 189)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(58, 25)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(118, 129)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Time :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(67, 157)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Week Of Day :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(75, 100)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Class Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(60, 73)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Subject Name :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 42)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Teacher Name :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvViewTimeTableView)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 248)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(653, 231)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View Genrated Time Table"
        '
        'dgvViewTimeTableView
        '
        Me.dgvViewTimeTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvViewTimeTableView.Location = New System.Drawing.Point(8, 20)
        Me.dgvViewTimeTableView.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dgvViewTimeTableView.Name = "dgvViewTimeTableView"
        Me.dgvViewTimeTableView.ReadOnly = True
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvViewTimeTableView.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvViewTimeTableView.Size = New System.Drawing.Size(637, 205)
        Me.dgvViewTimeTableView.TabIndex = 7
        '
        'FrmViewTimeTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 485)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FrmViewTimeTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Time Table"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvViewTimeTableView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ddlSubjectName As ComboBox
    Friend WithEvents ddlTeacherName As ComboBox
    Friend WithEvents ddlClassName As ComboBox
    Friend WithEvents ddlWeekOfDays As ComboBox
    Friend WithEvents ddlTimes As ComboBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgvViewTimeTableView As DataGridView
    Friend WithEvents btnViewTimeTable As Button
End Class
