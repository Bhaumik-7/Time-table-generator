Public Class FrmViewTimeTableFormat
    Private Sub FrmViewTimeTableFormat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'WebBrowser1.Navigate("about:blank")
        WebBrowserContentDisplay()
    End Sub

    Private Sub WebBrowserContentDisplay()

        ' WebBrowser1.Refresh()
        'WebBrowser1.Document.Write(HTMLString2)
        'WebBrowser1.Url = "TextFile1.txt"
        'WebBrowser1.Navigate("..TextFile1.txt")

        Dim applicationDirectory As String
        Dim myFile As String
        applicationDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
        myFile = System.IO.Path.Combine(applicationDirectory, "TimeTableFormat.html")
        WebBrowser1.Url = New Uri("file:///" + myFile)

        'WebBrowser1.Navigate(New Uri("ms-appx-web:///TextFile1.html"))
        'Dim urlToNavigate As String
        'urlToNavigate = Application.UserAppDataPath + "@\TextFile1.html"
        'WebBrowser1.Navigate(urlToNavigate)

        'WebBrowser1.Navigate("file:///E:/Dot%20Net/ProjTimeTable/ProjTimeTable/bin/Debug/TimeTableFormat.html")
        ''WebBrowser1.Navigate("file:///E:/Dot%20Net/ProjTimeTable/ProjTimeTable/TimeTableFormat.html")

        '----------The HTML CODE GOES FROM HERE AND DOWN----------
        ''HTMLString = "<HTML>" &
        ''        "<TITLE>Page On Load</TITLE>" &
        ''        "<BODY>" &
        ''        "<FONT COLOR = BLUE>" &
        ''        "This Is a " &
        ''        "<FONT SIZE = 5>" &
        ''        "<B>" &
        ''        "programmatically " &
        ''        "</B>" &
        ''        "</FONT SIZE>" &
        ''        "made page" &
        ''        "</FONT>" &
        ''        "</BODY>" &
        ''        "</HTML>"
        ''----------The HTML CODE GOES HERE AND ABOVE----------
        'WebBrowser1.Refresh()
        'WebBrowser1.Document.Write(HTMLString)

        If logTblUserData.Rows.Count() > 0 Then
            Dim DocumentHTML As String
            DocumentHTML = WebBrowser1.DocumentText.ToString()
            Dim j As Int32
            Dim strToolTip As String = ""
            If logTblUserData.Rows.Count() > 0 Then

                j = 0
                For i As Integer = i To logTblUserData.Rows.Count()
                    j = i
                    If j <> logTblUserData.Rows.Count() Then
                        'Monday	Tuesday	Wednesday	Thrusday	Friday	Saturday
                        'If logTblUserData.Rows(i)("WeekPriority") = 1 Then 'And tblMonday.Rows(i)("TimePriority") = j + 1 Then
                        'DocumentHTML = DocumentHTML.ToString().Replace("Monday" & j + 1, tblMonday.Rows(i)("SubjectName"))
                        'strToolTip = "<Label Class=label title=TeacherName>"
                        DocumentHTML = DocumentHTML.ToString().Replace(logTblUserData.Rows(i)("WeekOfDay") & logTblUserData.Rows(i)("TimePriority"), logTblUserData.Rows(i)("SubjectName"))
                        'DocumentHTML = DocumentHTML.ToString().Replace(logTblUserData.Rows(i)("WeekOfDay") & logTblUserData.Rows(i)("TimePriority"), strToolTip & logTblUserData.Rows(i)("SubjectName") & "</label>")
                        'End If
                    End If
                Next
                DocumentHTML = DocumentHTML.ToString().Replace("Time Table For Class : ClassName", "Time Table For Class :" & logTblUserData.Rows(0)("ClassName"))
            End If
            DocumentHTML = setReplaceData(DocumentHTML, "Monday")
            DocumentHTML = setReplaceData(DocumentHTML, "Tuesday")
            DocumentHTML = setReplaceData(DocumentHTML, "Wednesday")
            DocumentHTML = setReplaceData(DocumentHTML, "Thursday") 'Thrusday1
            DocumentHTML = setReplaceData(DocumentHTML, "Friday")
            DocumentHTML = setReplaceData(DocumentHTML, "Saturday")


            ' Comment Strat here..
            ''Dim tblMonday As New DataTable
            ''Dim dvMonday As New DataView(logTblUserData)
            ''dvMonday.RowFilter = "WeekPriority=1"
            ''tblMonday = dvMonday.ToTable()
            ''Dim j As Int32

            ''If tblMonday.Rows.Count() > 0 Then

            ''    j = 0
            ''    For i As Integer = i To tblMonday.Rows.Count()
            ''        j = i
            ''        If j <> tblMonday.Rows.Count() Then
            ''            'Monday	Tuesday	Wednesday	Thrusday	Friday	Saturday
            ''            If tblMonday.Rows(i)("WeekPriority") = 1 Then 'And tblMonday.Rows(i)("TimePriority") = j + 1 Then
            ''                'DocumentHTML = DocumentHTML.ToString().Replace("Monday" & j + 1, tblMonday.Rows(i)("SubjectName"))
            ''                DocumentHTML = DocumentHTML.ToString().Replace("Monday" & tblMonday.Rows(i)("TimePriority"), tblMonday.Rows(i)("SubjectName"))
            ''            End If
            ''        End If
            ''    Next
            ''End If
            ''DocumentHTML = setReplaceData(DocumentHTML, "Monday")

            ''DataView dv = New DataView(logTblUserData);
            ''dv.RowFilter = "GroupingID = 0";
            ''GridView1.DataSource = dv;

            ''Dim tblTuesdayy As New DataTable
            ''Dim dvTuesday As New DataView(logTblUserData)
            ''dvTuesday.RowFilter = "WeekPriority=2"
            ''tblTuesdayy = dvTuesday.ToTable()

            ''If tblTuesdayy.Rows.Count() > 0 Then
            ''    j = 0
            ''    For i As Integer = i To tblTuesdayy.Rows.Count()
            ''        j = i
            ''        If j <> tblTuesdayy.Rows.Count() Then
            ''            If tblTuesdayy.Rows(i)("WeekPriority") = 2 Then 'And tblTuesdayy.Rows(i)("TimePriority") = j + 1 Then
            ''                DocumentHTML = DocumentHTML.ToString().Replace("Tuesday" & tblTuesdayy.Rows(i)("TimePriority"), tblTuesdayy.Rows(i)("SubjectName"))
            ''            End If
            ''        End If
            ''    Next
            ''End If
            ''DocumentHTML = setReplaceData(DocumentHTML, "Tuesday")

            ''Dim tblWednesday As New DataTable
            ''Dim dvWednesday As New DataView(logTblUserData)
            ''dvWednesday.RowFilter = "WeekPriority=3"
            ''tblWednesday = dvWednesday.ToTable()

            ''If tblWednesday.Rows.Count() > 0 Then
            ''    j = 0
            ''    For i As Integer = i To tblWednesday.Rows.Count()
            ''        j = i
            ''        If j <> tblWednesday.Rows.Count() Then
            ''            If tblWednesday.Rows(i)("WeekPriority") = 3 Then 'And tblWednesday.Rows(i)("TimePriority") = j + 1 Then
            ''                DocumentHTML = DocumentHTML.ToString().Replace("Wednesday" & tblWednesday.Rows(i)("TimePriority"), tblWednesday.Rows(i)("SubjectName"))
            ''            End If
            ''        End If
            ''    Next
            ''End If
            ''DocumentHTML = setReplaceData(DocumentHTML, "Wednesday")

            ''Dim tblThrusday As New DataTable
            ''Dim dvThrusday As New DataView(logTblUserData)
            ''dvThrusday.RowFilter = "WeekPriority=4"
            ''tblThrusday = dvThrusday.ToTable()

            ''If tblThrusday.Rows.Count() > 0 Then
            ''    j = 0
            ''    For i As Integer = i To tblThrusday.Rows.Count()
            ''        j = i
            ''        If j <> tblThrusday.Rows.Count() Then
            ''            If j <> tblThrusday.Rows.Count() Then
            ''                If tblMonday.Rows(i)("WeekPriority") = 4 Then
            ''                    DocumentHTML = DocumentHTML.ToString().Replace("Thrusday" & tblThrusday.Rows(i)("TimePriority"), tblThrusday.Rows(i)("SubjectName"))
            ''                End If
            ''            End If
            ''            End If
            ''    Next
            ''End If
            ''DocumentHTML = setReplaceData(DocumentHTML, "Thrusday")

            ''Dim tblFriday As New DataTable
            ''Dim dvFriday As New DataView(logTblUserData)
            ''dvFriday.RowFilter = "WeekPriority=5"
            ''tblFriday = dvFriday.ToTable()

            ''If tblFriday.Rows.Count() > 0 Then
            ''    j = 0
            ''    For i As Integer = i To tblFriday.Rows.Count()
            ''        j = i
            ''        If j <> tblFriday.Rows.Count() Then
            ''            If tblFriday.Rows(i)("WeekPriority") = 5 Then 'And tblFriday.Rows(i)("TimePriority") = j + 1 Then
            ''                DocumentHTML = DocumentHTML.ToString().Replace("Friday" & tblFriday.Rows(i)("TimePriority"), tblFriday.Rows(i)("SubjectName"))
            ''            End If
            ''        End If
            ''    Next
            ''End If
            ''DocumentHTML = setReplaceData(DocumentHTML, "Friday")

            ''Dim tblSaturday As New DataTable
            ''Dim dvSaturday As New DataView(logTblUserData)
            ''dvSaturday.RowFilter = "WeekPriority=6"
            ''tblSaturday = dvSaturday.ToTable()

            ''If tblSaturday.Rows.Count() > 0 Then
            ''    j = 0
            ''    For i As Integer = i To tblSaturday.Rows.Count()
            ''        j = i
            ''        If j <> tblSaturday.Rows.Count() Then
            ''            If tblSaturday.Rows(i)("WeekPriority") = 6 Then 'And tblSaturday.Rows(i)("TimePriority") = j + 1 Then
            ''                DocumentHTML = DocumentHTML.ToString().Replace("Saturday" & tblSaturday.Rows(i)("TimePriority"), tblSaturday.Rows(i)("SubjectName"))
            ''            End If
            ''        End If
            ''    Next
            ''End If
            ''DocumentHTML = setReplaceData(DocumentHTML, "Saturday")

            'Coment End here....


            'DocumentHTML = DocumentHTML.ToString().Replace("Monday1", logTblUserData.Rows(0)("ClassName"))
            ''DocumentHTML = DocumentHTML.ToString().Replace("Lunch", "Lunch-Test")
            ''DocumentHTML = DocumentHTML.ToString().Replace("Monday2", logTblUserData.Rows(0)("StaffName"))

            'Dim HTMLString As String
            'HTMLString = "<HTML>" &
            '        "<TITLE>Page On Load</TITLE>" &
            '        "<BODY>" &
            '        "<FONT COLOR= BLUE>" &
            '        "This Is a " &
            '        "<FONT SIZE= 5>" &
            '        "<B>" &
            '        "programmatically " &
            '        "</B>" &
            '        "</FONT SIZE>" &
            '        "made page" &
            '        "</FONT>" &
            '        "</BODY>" &
            '        "</HTML>"

            WebBrowser1.Refresh()
            WebBrowser1.Document.Write(DocumentHTML)

        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'WebBrowserContentDisplay()
        Me.Close()
    End Sub

    Private Function setReplaceData(strHTMLConnets As String, strReplaceString As String) As String
        Dim retStr = String.Empty
        retStr = strHTMLConnets
        For i As Integer = i To 7
            retStr = retStr.Replace(strReplaceString & i + 1, "-")
        Next
        Return retStr
    End Function

End Class