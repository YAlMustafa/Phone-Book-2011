Public Class FrmEdit
    Dim CCPCode
    Dim CL, LCP
    Dim mi
    Dim Cnamcode, Cnumcode, Ctypecode, Cnotescode
    Dim lnam, lnum, ltype, lnotes
    Dim Hcom
    Dim Pore
    Private Sub FormEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Tag = 1
        lnam = 1
        lnum = 1
        ltype = 1
        lnotes = 1
        StateAddNewItem.Enabled = True
        StateCountItem.Enabled = True
        If FormMain.LenRow <> 0 Then
            Pore = -1
            For i = 0 To FormMain.MainTab.Rows.Count - 1
                If Val(FormMain.MainTab.Rows(i).Tag) = Val(StatePositionItem.Text) Then
                    Pore = i
                    Exit For
                End If
            Next
            Maintabout()
        End If
        txtNam.Select()
        txtNam.SelectAll()
    End Sub
    Private Sub FrmEdit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Tag = 0
    End Sub
    Private Sub FrmEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter And e.Control = True Then StateAddNewItem_Click(sender, e)
        If e.KeyCode = Keys.Delete And e.Control = True And StateDeleteItem.Enabled = True Then StateDeleteItem_Click(sender, e)
        If e.KeyCode = Keys.Escape Then Hide()
    End Sub

    Private Sub StateButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StateButtonClose.Click
        Tag = 0
        Hide()
    End Sub

    Private Sub StateAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StateAddNewItem.Click
        FormMain.ToolStripButtonAll.Checked = True
        FormMain.LenRow = FormMain.LenRow + 1
        '***
        GroupBoxData.Enabled = True
        StateCountItem.Tag = Val(StateCountItem.Tag) + 1
        StateCountItem.Text = "of {" & Val(StateCountItem.Tag) & "}"
        StatePositionItem.Text = Val(StateCountItem.Tag)
        If StateDeleteItem.Enabled = False Then txtNam.Select()
        '
        'State
        '
        StateAddNewItem.Tag = 1
        StateMoveFirstItem.Enabled = True
        StateMovePreviousItem.Enabled = True
        StatePositionItem.Enabled = True
        StateCountItem.Enabled = True
        StateMoveNextItem.Enabled = True
        StateMoveLastItem.Enabled = True
        StateDeleteItem.Enabled = True
        '
        FormMain.NamCode = FormMain.NamCode & "&"
        FormMain.NumCode = FormMain.NumCode & "&"
        '
        FormMain.MainTab.Rows.Add(Val(StatePositionItem.Text))
        If comType.Text = "بلا" Then Hcom = "" Else Hcom = comType.Text
        If comType.Text = "هاتف/أرضي" Then If comAdj.Text <> "بلا" Then Hcom = Hcom & " - " & comAdj.Text
        FormMain.MainTab.Rows(StatePositionItem.Text - 1).Cells(3).Value = Hcom
        FormMain.TypeCode = FormMain.TypeCode & Hcom & "&"
        '
        FormMain.CPCode = FormMain.CPCode & CheckCun0.Tag & "$" & CheckCun1.Tag & "$" & CheckPla.Tag & "$"
        FormMain.NotesCode = FormMain.NotesCode & "&"
        txtCun0.Text = ""
        txtCun1.Text = ""
        txtNam.Text = ""
        txtNotes.Text = ""
        txtPla.Text = ""
        txtTNum.Text = ""
        State.Left = Val(GroupBoxData.Left) + (Val(GroupBoxData.Width) - Val(State.Width)) / 2
        StateAddNewItem.Tag = 0
        If FormMain.LenRow <> 0 Then FormMain.ToolStripSave.Enabled = True
        FormMain.MainTab.ClearSelection()
        FormMain.MainTab.Rows(StatePositionItem.Text - 1).Selected = 1
        Clipboard.SetData(1, FormMain.MainTab)
        FormMain.MainTab.Rows(FormMain.MainTab.Rows.Count - 1).Tag = StatePositionItem.Text
        If FormMain.LenRow <> 0 Then
            Pore = -1
            For i = 0 To FormMain.MainTab.Rows.Count - 1
                If Val(FormMain.MainTab.Rows(i).Tag) = Val(StatePositionItem.Text) Then
                    Pore = i - 1
                    Exit For
                End If
            Next
            Maintabout()
        End If
    End Sub
    Private Sub StateDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StateDeleteItem.Click
        FormMain.LenRow = FormMain.LenRow - 1
        FormMain.MainTab.Rows.RemoveAt(StatePositionItem.Text - 1)
        ''
        If FormMain.LenRow = 0 Then
            txtNam.Text = ""
            txtTNum.Text = ""
            txtCun0.Text = ""
            txtCun1.Text = ""
            txtPla.Text = ""
            txtNotes.Text = ""
        End If
        '
        'NamCode
        '
        If lnam = 1 Then
            Cnamcode = FormMain.NamCode
            For i = 1 To Len(FormMain.NamCode)
                If Mid(Cnamcode, i, 1) = "&" Then
                    If StatePositionItem.Text = 1 Then
                        FormMain.NamCode = Mid(Cnamcode, i + 1, Len(Cnamcode) - i)
                        Exit For
                    Else
                        If StatePositionItem.Text = Val(StateCountItem.Tag) Then
                            If lnam = StatePositionItem.Text - 1 Then
                                FormMain.NamCode = Mid(Cnamcode, 1, i)
                                Exit For
                            End If
                        Else
                            If lnam = StatePositionItem.Text - 1 Then FormMain.NamCode = Mid(Cnamcode, 1, i)
                            If lnam = StatePositionItem.Text Then
                                FormMain.NamCode = FormMain.NamCode & Mid(Cnamcode, i + 1, Len(Cnamcode) - i)
                                Exit For
                            End If
                        End If
                    End If
                    lnam = lnam + 1
                End If
            Next
            lnam = 1
        End If
        '
        'NumCode
        '
        If lnum = 1 Then
            Cnumcode = FormMain.NumCode
            For i = 1 To Len(FormMain.NumCode)
                If Mid(Cnumcode, i, 1) = "&" Then
                    If StatePositionItem.Text = 1 Then
                        FormMain.NumCode = Mid(Cnumcode, i + 1, Len(Cnumcode) - i)
                        Exit For
                    Else
                        If StatePositionItem.Text = Val(StateCountItem.Tag) Then
                            If lnum = StatePositionItem.Text - 1 Then
                                FormMain.NumCode = Mid(Cnumcode, 1, i)
                                Exit For
                            End If
                        Else
                            If lnum = StatePositionItem.Text - 1 Then FormMain.NumCode = Mid(Cnumcode, 1, i)
                            If lnum = StatePositionItem.Text Then
                                FormMain.NumCode = FormMain.NumCode & Mid(Cnumcode, i + 1, Len(Cnumcode) - i)
                                Exit For
                            End If
                        End If
                    End If
                    lnum = lnum + 1
                End If
            Next
            lnum = 1
        End If
        '
        'TypeCode
        '
        If ltype = 1 Then
            Ctypecode = FormMain.TypeCode
            For i = 1 To Len(FormMain.TypeCode)
                If Mid(Ctypecode, i, 1) = "&" Then
                    If StatePositionItem.Text = 1 Then
                        FormMain.TypeCode = Mid(Ctypecode, i + 1, Len(Ctypecode) - i)
                        Exit For
                    Else
                        If StatePositionItem.Text = Val(StateCountItem.Tag) Then
                            If ltype = StatePositionItem.Text - 1 Then
                                FormMain.TypeCode = Mid(Ctypecode, 1, i)
                                Exit For
                            End If
                        Else
                            If ltype = StatePositionItem.Text - 1 Then FormMain.TypeCode = Mid(Ctypecode, 1, i)
                            If ltype = StatePositionItem.Text Then
                                FormMain.TypeCode = FormMain.TypeCode & Mid(Ctypecode, i + 1, Len(Ctypecode) - i)
                                Exit For
                            End If
                        End If
                    End If
                    ltype = ltype + 1
                End If
            Next
            ltype = 1
        End If
        '
        'CPCode
        '
        CCPCode = FormMain.CPCode
        LCP = 0
        CL = 1
        For i = 1 To Len(CCPCode)
            If Mid(CCPCode, i, 1) = "$" Then
                LCP = LCP + 1
                If LCP = 3 Then
                    If StatePositionItem.Text = 1 Then FormMain.CPCode = Mid(CCPCode, i + 1, Len(CCPCode) - i) : Exit For
                    If CL = StatePositionItem.Text - 1 Then FormMain.CPCode = Mid(CCPCode, 1, i)
                    If CL = StatePositionItem.Text Then FormMain.CPCode = FormMain.CPCode & Mid(CCPCode, i + 1, Len(CCPCode) - i) : Exit For
                    LCP = 0
                    CL = CL + 1
                End If
            End If
        Next
        LCP = 0
        '
        'NotesCode
        '
        If lnotes = 1 Then
            Cnotescode = FormMain.NotesCode
            For i = 1 To Len(FormMain.NotesCode)
                If Mid(Cnotescode, i, 1) = "&" Then
                    If StatePositionItem.Text = 1 Then
                        FormMain.NotesCode = Mid(Cnotescode, i + 1, Len(Cnotescode) - i)
                        Exit For
                    Else
                        If StatePositionItem.Text = Val(StateCountItem.Tag) Then
                            If lnotes = StatePositionItem.Text - 1 Then
                                FormMain.NotesCode = Mid(Cnotescode, 1, i)
                                Exit For
                            End If
                        Else
                            If lnotes = StatePositionItem.Text - 1 Then FormMain.NotesCode = Mid(Cnotescode, 1, i)
                            If lnotes = StatePositionItem.Text Then
                                FormMain.NotesCode = FormMain.NotesCode & Mid(Cnotescode, i + 1, Len(Cnotescode) - i)
                                Exit For
                            End If
                        End If
                    End If
                    lnotes = lnotes + 1
                End If
            Next
            lnotes = 1
        End If
        ''
        ''
        StateCountItem.Tag = Val(StateCountItem.Tag) - 1
        StateCountItem.Text = "of {" & Val(StateCountItem.Tag) & "}"
        If StatePositionItem.Text > Val(StateCountItem.Tag) Then StatePositionItem.Text = Val(StateCountItem.Tag)
        If Val(StateCountItem.Tag) = 0 Then
            StateDeleteItem.Enabled = False
            StateMoveFirstItem.Enabled = False
            StateMoveLastItem.Enabled = False
            StateMoveNextItem.Enabled = False
            StateMovePreviousItem.Enabled = False
            StatePositionItem.Enabled = False
            GroupBoxData.Enabled = False
        Else
            For i = 1 To FormMain.MainTab.Rows.Count - 1
                FormMain.MainTab.Rows(i - 1).Cells(0).Value = Val(i)
            Next
        End If
        ''
        Maintabout()
        State.Left = Val(GroupBoxData.Left) + (Val(GroupBoxData.Width) - Val(State.Width)) / 2
        If FormMain.LenRow = 0 Then
            FormMain.ToolStripSave.Enabled = False
            FormMain.ToolStripSearch.Enabled = False
        End If
        FormMain.MainTab.ClearSelection()
        FormMain.MainTab.Rows(StatePositionItem.Text - 1).Selected = 1
        FormMain.MainTab.Rows(FormMain.MainTab.Rows.Count - 1).Tag = StatePositionItem.Text
        If FormMain.LenRow <> 0 Then
            Pore = -1
            For i = 0 To FormMain.MainTab.Rows.Count - 1
                If Val(FormMain.MainTab.Rows(i).Tag) = Val(StatePositionItem.Text) Then
                    Pore = i - 1
                    Exit For
                End If
            Next
            Maintabout()
        End If
    End Sub

    Private Sub StatePositionItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StatePositionItem.TextChanged
        If FormMain.LenRow <> 0 Then
            If Val(StatePositionItem.Text) > Val(StateCountItem.Tag) Then StatePositionItem.Text = StateCountItem.Tag
            If Val(StatePositionItem.Text) < 1 Then StatePositionItem.Text = 1
            '
            Pore = -1
            For i = 0 To FormMain.MainTab.Rows.Count - 1
                If Val(FormMain.MainTab.Rows(i).Tag) = Val(StatePositionItem.Text) Then
                    Pore = i
                    Exit For
                End If
            Next
            If GroupBoxData.Enabled = True Then Maintabout()
        End If
    End Sub

    Private Sub StateMovePreviousItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StateMovePreviousItem.Click
        If StatePositionItem.Text > 1 Then StatePositionItem.Text = StatePositionItem.Text - 1
    End Sub
    Private Sub StateMoveNextItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StateMoveNextItem.Click
        If StatePositionItem.Text < Val(Val(StateCountItem.Tag)) Then StatePositionItem.Text = StatePositionItem.Text + 1
    End Sub
    
    Private Sub StateMoveLastItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StateMoveLastItem.Click
        StatePositionItem.Text = Val(Val(StateCountItem.Tag))
    End Sub
    Private Sub StateMoveFirstItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StateMoveFirstItem.Click
        StatePositionItem.Text = 1
    End Sub

    Private Sub txtNam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNam.TextChanged
        If Tag = 1 Then
            If lnam = 1 Then
                If Pore > -1 Then FormMain.MainTab.Rows(Pore).Cells(1).Value = Trim(txtNam.Text)
                Cnamcode = FormMain.NamCode
                For i = 1 To Len(FormMain.NamCode)
                    If Mid(Cnamcode, i, 1) = "&" Then
                        If StatePositionItem.Text = 1 Then
                            FormMain.NamCode = Trim(txtNam.Text) & "&"
                            FormMain.NamCode = FormMain.NamCode & Mid(Cnamcode, i + 1, Len(Cnamcode) - i)
                            Exit For
                        Else
                            If StatePositionItem.Text = Val(StateCountItem.Tag) Then
                                If lnam = StatePositionItem.Text - 1 Then
                                    FormMain.NamCode = Mid(Cnamcode, 1, i) & Trim(txtNam.Text) & "&"
                                    Exit For
                                End If
                            Else
                                If lnam = StatePositionItem.Text - 1 Then FormMain.NamCode = Mid(Cnamcode, 1, i) & Trim(txtNam.Text) & "&"
                                If lnam = StatePositionItem.Text Then
                                    FormMain.NamCode = FormMain.NamCode & Mid(Cnamcode, i + 1, Len(Cnamcode) - i)
                                    Exit For
                                End If
                            End If
                        End If
                        lnam = lnam + 1
                    End If
                Next
                lnam = 1
            End If
        End If
    End Sub

    Private Sub txtTNum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTNum.TextChanged
        If Tag = 1 Then
            For i = 1 To Len(txtTNum.Text)
                If Mid(txtTNum.Text, i, 1) <> "1" And _
                   Mid(txtTNum.Text, i, 1) <> "2" And _
                   Mid(txtTNum.Text, i, 1) <> "3" And _
                   Mid(txtTNum.Text, i, 1) <> "4" And _
                   Mid(txtTNum.Text, i, 1) <> "5" And _
                   Mid(txtTNum.Text, i, 1) <> "6" And _
                   Mid(txtTNum.Text, i, 1) <> "7" And _
                   Mid(txtTNum.Text, i, 1) <> "8" And _
                   Mid(txtTNum.Text, i, 1) <> "9" And _
                   Mid(txtTNum.Text, i, 1) <> "0" And _
                   Mid(txtTNum.Text, i, 1) <> "+" And _
                   Mid(txtTNum.Text, i, 1) <> "#" And _
                   Mid(txtTNum.Text, i, 1) <> "*" And _
                   Mid(txtTNum.Text, i, 1) <> "-" And _
                   Mid(txtTNum.Text, i, 1) <> " " Then
                    txtTNum.Text = txtTNum.Tag
                    txtTNum.SelectionStart = Len(txtTNum.Text)
                    Exit Sub
                End If
            Next
            txtTNum.Tag = txtTNum.Text
            '
            If lnum = 1 Then
                If Pore > -1 Then FormMain.MainTab.Rows(Pore).Cells(2).Value = Trim(txtTNum.Text)
                Cnumcode = FormMain.NumCode
                For i = 1 To Len(FormMain.NumCode)
                    If Mid(Cnumcode, i, 1) = "&" Then
                        If StatePositionItem.Text = 1 Then
                            FormMain.NumCode = Trim(txtTNum.Text) & "&"
                            FormMain.NumCode = FormMain.NumCode & Mid(Cnumcode, i + 1, Len(Cnumcode) - i)
                            Exit For
                        Else
                            If StatePositionItem.Text = Val(StateCountItem.Tag) Then
                                If lnum = StatePositionItem.Text - 1 Then
                                    FormMain.NumCode = Mid(Cnumcode, 1, i) & Trim(txtTNum.Text) & "&"
                                    Exit For
                                End If
                            Else
                                If lnum = StatePositionItem.Text - 1 Then FormMain.NumCode = Mid(Cnumcode, 1, i) & Trim(txtTNum.Text) & "&"
                                If lnum = StatePositionItem.Text Then
                                    FormMain.NumCode = FormMain.NumCode & Mid(Cnumcode, i + 1, Len(Cnumcode) - i)
                                    Exit For
                                End If
                            End If
                        End If
                        lnum = lnum + 1
                    End If
                Next
                lnum = 1
            End If
        End If
    End Sub

    Private Sub comType_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles comType.LostFocus
        If ltype = 1 Then
            comType.Text = Trim(comType.Text)
            If comType.Text = "0" Then comType.Text = "بلا"
            If comType.Text = "1" Then comType.Text = "هاتف/أرضي"
            If comType.Text = "2" Then comType.Text = "هاتف/موبايل"
            If comType.Text = "3" Then comType.Text = "هاتف/ثريا"
            If comType.Text <> "بلا" And comType.Text <> "هانف/أرضي" And comType.Text <> "هانف/موبايل" And comType.Text <> "هانف/ثريا" Then comType.Text = comType.Tag
            comType.Tag = comType.Text
        End If
    End Sub
    Private Sub comType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comType.SelectedIndexChanged
        If Tag = 1 Then
            If ltype = 1 Then
                If ltype = 1 Then
                    If comType.Text = "هاتف/أرضي" Then
                        comAdj.Enabled = True
                        comAdj.Text = comAdj.Tag
                        Hcom = comType.Text
                        If comAdj.Text = "بلا" Then Hcom = comType.Text Else Hcom = comType.Text & " - " & comAdj.Text
                    Else
                        comAdj.Enabled = False
                        comAdj.Text = "بلا"
                        If comType.Text = "بلا" Then Hcom = "" Else Hcom = comType.Text
                    End If
                    If Pore > -1 Then FormMain.MainTab.Rows(Pore).Cells(3).Value = Hcom
                    '
                    Ctypecode = FormMain.TypeCode
                    For i = 1 To Len(FormMain.TypeCode)
                        If Mid(Ctypecode, i, 1) = "&" Then
                            If StatePositionItem.Text = 1 Then
                                FormMain.TypeCode = Hcom & "&"
                                FormMain.TypeCode = FormMain.TypeCode & Mid(Ctypecode, i + 1, Len(Ctypecode) - i)
                                Exit For
                            Else
                                If StatePositionItem.Text = Val(StateCountItem.Tag) Then
                                    If ltype = StatePositionItem.Text - 1 Then
                                        FormMain.TypeCode = Mid(Ctypecode, 1, i) & Hcom & "&"
                                        Exit For
                                    End If
                                Else
                                    If ltype = StatePositionItem.Text - 1 Then
                                        FormMain.TypeCode = Mid(Ctypecode, 1, i) & Hcom & "&"
                                    End If
                                    If ltype = StatePositionItem.Text Then
                                        FormMain.TypeCode = FormMain.TypeCode & Mid(Ctypecode, i + 1, Len(Ctypecode) - i)
                                        Exit For
                                    End If
                                End If
                            End If
                            ltype = ltype + 1
                        End If
                    Next
                    ltype = 1
                End If
            End If
            comType.Tag = comType.Text
        End If
    End Sub
    Private Sub comType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comType.TextChanged
        If ltype = 1 Then
            If comType.Text = "هاتف/أرضي" Or comType.Text = "1" Then comAdj.Enabled = True Else comAdj.Enabled = False
        End If
    End Sub
    Private Sub comAdj_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles comAdj.LostFocus
        If ltype = 1 Then
            comAdj.Text = Trim(comAdj.Text)
            For i = 0 To comAdj.Items.Count - 1
                If comAdj.Text = comAdj.Items(i) Then Exit Sub
            Next
            comAdj.Text = comAdj.Tag
        End If
    End Sub
    Private Sub comAdj_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comAdj.SelectedIndexChanged
        If Tag = 1 Then
            If ltype = 1 And comType.Text = "هاتف/أرضي" Then
                If ltype = 1 Then
                    If comAdj.Text = "بلا" Then Hcom = comType.Text Else Hcom = comType.Text & " - " & comAdj.Text
                    comAdj.Tag = comAdj.Text
                    If Pore > -1 Then FormMain.MainTab.Rows(Pore).Cells(3).Value = Hcom
                    '
                    Ctypecode = FormMain.TypeCode
                    For i = 1 To Len(FormMain.TypeCode)
                        If Mid(Ctypecode, i, 1) = "&" Then
                            If StatePositionItem.Text = 1 Then
                                FormMain.TypeCode = Hcom & "&"
                                FormMain.TypeCode = FormMain.TypeCode & Mid(Ctypecode, i + 1, Len(Ctypecode) - i)
                                Exit For
                            Else
                                If StatePositionItem.Text = Val(StateCountItem.Tag) Then
                                    If ltype = StatePositionItem.Text - 1 Then
                                        FormMain.TypeCode = Mid(Ctypecode, 1, i) & Hcom & "&"
                                        Exit For
                                    End If
                                Else
                                    If ltype = StatePositionItem.Text - 1 Then FormMain.TypeCode = Mid(Ctypecode, 1, i) & Hcom & "&"
                                    If ltype = StatePositionItem.Text Then
                                        FormMain.TypeCode = FormMain.TypeCode & Mid(Ctypecode, i + 1, Len(Ctypecode) - i)
                                        Exit For
                                    End If
                                End If
                            End If
                            ltype = ltype + 1
                        End If
                    Next
                    ltype = 1
                End If
            End If
        End If
    End Sub

    Private Sub txtNotes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotes.TextChanged
        If Tag = 1 Then
            If lnotes = 1 Then
                If Pore > -1 Then FormMain.MainTab.Rows(Pore).Cells(5).Value = Trim(txtNotes.Text)
                Cnotescode = FormMain.NotesCode
                For i = 1 To Len(FormMain.NotesCode)
                    If Mid(Cnotescode, i, 1) = "&" Then
                        If StatePositionItem.Text = 1 Then
                            FormMain.NotesCode = Trim(txtNotes.Text) & "&"
                            FormMain.NotesCode = FormMain.NotesCode & Mid(Cnotescode, i + 1, Len(Cnotescode) - i)
                            Exit For
                        Else
                            If StatePositionItem.Text = Val(StateCountItem.Tag) Then
                                If lnotes = StatePositionItem.Text - 1 Then
                                    FormMain.NotesCode = Mid(Cnotescode, 1, i) & Trim(txtNotes.Text) & "&"
                                    Exit For
                                End If
                            Else
                                If lnotes = StatePositionItem.Text - 1 Then FormMain.NotesCode = Mid(Cnotescode, 1, i) & Trim(txtNotes.Text) & "&"
                                If lnotes = StatePositionItem.Text Then
                                    FormMain.NotesCode = FormMain.NotesCode & Mid(Cnotescode, i + 1, Len(Cnotescode) - i)
                                    Exit For
                                End If
                            End If
                        End If
                        lnotes = lnotes + 1
                    End If
                Next
                lnotes = 1
            End If
        End If
    End Sub

    Private Sub txtCun0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCun0.TextChanged, txtCun1.TextChanged, txtPla.TextChanged
        If Tag = 1 Then
            If LCP = 0 Then
                If Pore > -1 Then
                    FormMain.MainTab.Rows(Pore).Cells(4).Value = ""
                    If txtCun0.Text <> "" And CheckCun0.Checked = True Then
                        FormMain.MainTab.Rows(Pore).Cells(4).Value = Trim(txtCun0.Text)
                        If CheckCun1.Checked = True And txtCun1.Text <> "" Or CheckPla.Checked = True And txtPla.Text <> "" Then FormMain.MainTab.Rows(Pore).Cells(4).Value = FormMain.MainTab.Rows(Pore).Cells(4).Value & "/"
                    End If
                    If txtCun1.Text <> "" And CheckCun1.Checked = True Then
                        FormMain.MainTab.Rows(Pore).Cells(4).Value = FormMain.MainTab.Rows(Pore).Cells(4).Value & Trim(txtCun1.Text)
                        If CheckPla.Checked = True And txtPla.Text <> "" Then FormMain.MainTab.Rows(Pore).Cells(4).Value = FormMain.MainTab.Rows(Pore).Cells(4).Value & " - "
                    End If
                    If txtPla.Text <> "" And CheckPla.Checked = True Then FormMain.MainTab.Rows(Pore).Cells(4).Value = FormMain.MainTab.Rows(Pore).Cells(4).Value & Trim(txtPla.Text)
                End If
                inputCPCode()
            End If
        End If
    End Sub

    Sub inputCPCode()
        '
        'CPCode
        '
        CCPCode = FormMain.CPCode
        LCP = 0
        CL = 1
        For i = 1 To Len(CCPCode)
            If Mid(CCPCode, i, 1) = "$" Then
                LCP = LCP + 1
                If LCP = 3 Then
                    If StatePositionItem.Text = 1 Then
                        FormMain.CPCode = CheckCun0.Tag & Trim(txtCun0.Text) & "$" & CheckCun1.Tag & Trim(txtCun1.Text) & "$" & CheckPla.Tag & Trim(txtPla.Text) & "$" & Mid(CCPCode, i + 1, Len(CCPCode) - i)
                        Exit For
                    End If
                    If CL = StatePositionItem.Text - 1 Then
                        FormMain.CPCode = Mid(CCPCode, 1, i)
                        If StatePositionItem.Text = Val(StateCountItem.Tag) Then
                            FormMain.CPCode = FormMain.CPCode & CheckCun0.Tag & Trim(txtCun0.Text) & "$" & CheckCun1.Tag & Trim(txtCun1.Text) & "$" & CheckPla.Tag & Trim(txtPla.Text) & "$"
                            Exit For
                        End If
                    End If
                    If CL = StatePositionItem.Text Then
                        FormMain.CPCode = FormMain.CPCode & CheckCun0.Tag & Trim(txtCun0.Text) & "$" & CheckCun1.Tag & Trim(txtCun1.Text) & "$" & CheckPla.Tag & Trim(txtPla.Text) & "$" & Mid(CCPCode, i + 1, Len(CCPCode) - i)
                        Exit For
                    End If
                    LCP = 0
                    CL = CL + 1
                End If
            End If
        Next
        LCP = 0
    End Sub

    Sub Maintabout()
        If Tag = 1 Then
            If StatePositionItem.Text <> 0 Then
                '
                'TxtNam
                '
                If lnam = 1 Then
                    Cnamcode = 0
                    For i = 1 To Len(FormMain.NamCode)
                        If Mid(FormMain.NamCode, i, 1) = "&" Then
                            If lnam = StatePositionItem.Text Then txtNam.Text = Mid(FormMain.NamCode, Cnamcode + 1, i - Cnamcode - 1) : Exit For
                            Cnamcode = i
                            lnam = lnam + 1
                        End If
                    Next
                    lnam = 1
                End If
                '
                'TxtNum
                '
                If lnum = 1 Then
                    Cnumcode = 0
                    For i = 1 To Len(FormMain.NumCode)
                        If Mid(FormMain.NumCode, i, 1) = "&" Then
                            If lnum = StatePositionItem.Text Then txtTNum.Text = Mid(FormMain.NumCode, Cnumcode + 1, i - Cnumcode - 1) : Exit For
                            Cnumcode = i
                            lnum = lnum + 1
                        End If
                    Next
                    lnum = 1
                End If
                '
                'TxtType
                '
                If ltype = 1 Then
                    Ctypecode = 0
                    For i = 1 To Len(FormMain.TypeCode)
                        If Mid(FormMain.TypeCode, i, 1) = "&" Then
                            If ltype = StatePositionItem.Text Then
                                Hcom = Mid(FormMain.TypeCode, Ctypecode + 1, i - Ctypecode - 1)
                            End If
                            Ctypecode = i
                            ltype = ltype + 1
                        End If
                    Next
                    '
                    If Mid(Hcom, 1, 9) = "هاتف/أرضي" Then
                        comType.Text = "هاتف/أرضي"
                        If Len(Hcom) = 9 Then comAdj.Text = "بلا" Else comAdj.Text = Mid(Hcom, 13, Len(Hcom))
                    Else
                        If Hcom = "" Then comType.Text = "بلا" Else comType.Text = Hcom
                    End If
                    ltype = 1
                End If
                '
                'TxtCP
                '
                LCP = 0
                CL = 1
                mi = 0
                For i = 1 To Len(FormMain.CPCode)
                    If Mid(FormMain.CPCode, i, 1) = "$" Then
                        LCP = LCP + 1
                        If CL = StatePositionItem.Text Then
                            If LCP = 1 Then
                                If mi <> 0 Then
                                    If Mid(FormMain.CPCode, mi + 1, 1) = "1" Then CheckCun0.Checked = True Else CheckCun0.Checked = False
                                    txtCun0.Text = Mid(FormMain.CPCode, mi + 2, i - mi - 2)
                                Else
                                    If Mid(FormMain.CPCode, 1, 1) = "1" Then CheckCun0.Checked = True Else CheckCun0.Checked = False
                                    txtCun0.Text = Mid(FormMain.CPCode, 2, i - 2)
                                End If
                            End If
                            If LCP = 2 Then
                                If Mid(FormMain.CPCode, mi + 1, 1) = "1" Then CheckCun1.Checked = True Else CheckCun1.Checked = False
                                txtCun1.Text = Mid(FormMain.CPCode, mi + 2, i - mi - 2)
                            End If
                            If LCP = 3 Then
                                If Mid(FormMain.CPCode, mi + 1, 1) = "1" Then CheckPla.Checked = True Else CheckPla.Checked = False
                                txtPla.Text = Mid(FormMain.CPCode, mi + 2, i - mi - 2)
                                ''
                                ''
                                If CheckCun0.Checked = True Or CheckCun1.Checked = True Or CheckPla.Checked = True Then CheckCP.CheckState = CheckState.Indeterminate
                                If CheckCun0.Checked = True And CheckCun1.Checked = True And CheckPla.Checked = True Then CheckCP.CheckState = CheckState.Checked
                                If CheckCun0.Checked = False And CheckCun1.Checked = False And CheckPla.Checked = False Then CheckCP.CheckState = CheckState.Unchecked
                                Exit For
                            End If
                        End If
                        mi = i
                        If LCP = 3 Then
                            LCP = 0
                            CL = CL + 1
                        End If
                    End If
                Next
                LCP = 0
                '
                'TxtNotes
                '
                If lnotes = 1 Then
                    Cnotescode = 0
                    For i = 1 To Len(FormMain.NotesCode)
                        If Mid(FormMain.NotesCode, i, 1) = "&" Then
                            If lnotes = StatePositionItem.Text Then txtNotes.Text = Mid(FormMain.NotesCode, Cnotescode + 1, i - Cnotescode - 1) : Exit For
                            Cnotescode = i
                            lnotes = lnotes + 1
                        End If
                    Next
                    lnotes = 1
                End If
            End If
            FormMain.MainTab.ClearSelection()
            If Pore > -1 Then FormMain.MainTab.Rows(Pore).Selected = 1
        End If
    End Sub

    Private Sub CheckCun0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCun0.CheckedChanged, CheckCun1.CheckedChanged, CheckPla.CheckedChanged
        If CheckCun0.Checked = True Then CheckCun0.Tag = 1 Else CheckCun0.Tag = 0
        If CheckCun1.Checked = True Then CheckCun1.Tag = 1 Else CheckCun1.Tag = 0
        If CheckPla.Checked = True Then CheckPla.Tag = 1 Else CheckPla.Tag = 0
        If CheckCun0.Checked = True Or CheckCun1.Checked = True Or CheckPla.Checked = True Then CheckCP.CheckState = CheckState.Indeterminate
        If CheckCun0.Checked = True And CheckCun1.Checked = True And CheckPla.Checked = True Then CheckCP.CheckState = CheckState.Checked
        If CheckCun0.Checked = False And CheckCun1.Checked = False And CheckPla.Checked = False Then CheckCP.CheckState = CheckState.Unchecked
        txtCun0_TextChanged(sender, e)
    End Sub
    Private Sub CheckCP_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckCP.CheckedChanged
        If CheckCP.CheckState = CheckState.Checked Then
            CheckCun0.Checked = True
            CheckCun1.Checked = True
            CheckCun1.Checked = True
            CheckPla.Checked = True
            CheckCun0.Tag = 1
            CheckCun1.Tag = 1
            CheckCun1.Tag = 1
            CheckPla.Tag = 1
        End If
        If CheckCP.CheckState = CheckState.Unchecked Then
            CheckCun0.Checked = False
            CheckCun1.Checked = False
            CheckCun1.Checked = False
            CheckPla.Checked = False
            CheckCun0.Tag = 0
            CheckCun1.Tag = 0
            CheckCun1.Tag = 0
            CheckPla.Tag = 0
        End If
    End Sub
    'KeyDown
    Private Sub txtNam_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNam.KeyDown
        If e.KeyCode = Keys.Enter And e.Control = False Or e.KeyCode = Keys.Down Then
            txtTNum.Select()
            txtTNum.SelectAll()
        End If
        If e.KeyCode = Keys.Up Then
            txtNotes.Select()
            txtNotes.SelectAll()
        End If
    End Sub
    Private Sub txttNum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTNum.KeyDown
        If e.KeyCode = Keys.Down Then
            txtCun0.Select()
            txtCun0.SelectAll()
        End If
        If e.KeyCode = Keys.Enter And e.Control = False Then
            comType.Select()
            comType.SelectAll()
        End If
        If e.KeyCode = Keys.Up Then
            txtNam.Select()
            txtNam.SelectAll()
        End If
    End Sub
    Private Sub comType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles comType.KeyDown
        If e.KeyCode = Keys.Enter And e.Control = False Then
            If comType.Text = "هاتف/أرضي" Or comType.Text = "1" Then
                comAdj.Select()
                comAdj.SelectAll()
            Else
                txtCun0.Select()
                txtCun0.SelectAll()
            End If
        End If
    End Sub
    Private Sub comAdj_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles comAdj.KeyDown
        If e.KeyCode = Keys.Enter And e.Control = False Then
            txtCun0.Select()
            txtCun0.SelectAll()
        End If
    End Sub
    Private Sub txtCun0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCun0.KeyDown
        If e.KeyCode = Keys.Enter And e.Control = False Or e.KeyCode = Keys.Down Then
            txtCun1.Select()
            txtCun1.SelectAll()
        End If
        If e.KeyCode = Keys.Up Then
            txtTNum.Select()
            txtTNum.SelectAll()
        End If
    End Sub
    Private Sub txtCun1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Down Then
            txtPla.Select()
            txtPla.SelectAll()
        End If
        If e.KeyCode = Keys.Enter And e.Control = False Then
            txtCun1.Select()
            txtCun1.SelectAll()
        End If
        If e.KeyCode = Keys.Up Then
            txtNam.Select()
            txtNam.SelectAll()
        End If
    End Sub
    Private Sub txtCun2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCun1.KeyDown
        If e.KeyCode = Keys.Down Then
            txtNotes.Select()
            txtNotes.SelectAll()
        End If
        If e.KeyCode = Keys.Enter And e.Control = False Then
            txtPla.Select()
            txtPla.SelectAll()
        End If
        If e.KeyCode = Keys.Up Then
            txtCun0.Select()
            txtCun0.SelectAll()
        End If
    End Sub
    Private Sub txtpla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPla.KeyDown
        If e.KeyCode = Keys.Down Then
            txtNotes.Select()
            txtNotes.SelectAll()
        End If
        If e.KeyCode = Keys.Enter And e.Control = False Then
            txtNotes.Select()
            txtNotes.SelectAll()
        End If
        If e.KeyCode = Keys.Up Then
            txtCun1.Select()
            txtCun1.SelectAll()
        End If
    End Sub
    Private Sub txtnotes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNotes.KeyDown
        If e.KeyCode = Keys.Enter And e.Control = False Or e.KeyCode = Keys.Down Then
            txtNam.Select()
            txtNam.SelectAll()
        End If
        If e.KeyCode = Keys.Up Then
            txtPla.Select()
            txtPla.SelectAll()
        End If
    End Sub

    Private Sub StatePositionItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles StatePositionItem.KeyDown
        If e.KeyCode = Keys.Enter And e.Control = False Or e.KeyCode = Keys.Down Then
            txtNam.Select()
            txtNam.SelectAll()
        End If
        If e.KeyCode = Keys.Up Then
            txtCun1.Select()
            txtCun1.SelectAll()
        End If
    End Sub
End Class
