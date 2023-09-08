Public Class FormMain
    Public NamCode, NumCode, TypeCode, NotesCode
    Dim mNam, mNum, mType, mNotes
    Dim lNam, lNum, lType, lNotes
    Public CPCode
    Dim CL, LCP
    Dim mi1, mi2, mi3, mi4, mi1m
    Dim Bout, LBout
    Public LenRow
    Dim LLenRow
    Dim LColumn
    Dim LWColumn
    Dim LHRow
    Dim Bput
    Dim pathMFile
    Dim TF, Mid2
    '
    Public GPOptions
    Dim ColorCode
    Dim Ao, Ro, Go, Bo, mis
    Public GPView
    Public GPMove
    Dim miMove, lMove
    Dim one
    Dim mb
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        one = 1
        ToolStripMenuFileNew.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\Data\Button_Img_s\New.di")
        ToolStripNew.Image = ToolStripMenuFileNew.Image
        ToolStripMenuFileOpen.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\Data\Button_Img_s\Open.di")
        ToolStripOpen.Image = ToolStripMenuFileOpen.Image
        ToolStripMenuFileSave.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\Data\Button_Img_s\Save.di")
        ToolStripSave.Image = ToolStripMenuFileSave.Image
        ToolStripMenuED.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\Data\Button_Img_s\Doc-Edit.di")
        ToolStripED.Image = ToolStripMenuED.Image
        ToolStripSearch.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\Data/Button_Img_s\Search.di")
        MS.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\Data\BG_Img_s\Bgi_H.di")
        ToolStrip.BackgroundImage = MS.BackgroundImage
        ToolStrip28.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\Data\BG_Img_s\Bgi_V.di")
        '
        GPMove = ""
        GPOptions = ""
        GPView = ""
        On Error Resume Next
        FileOpen(2, My.Application.Info.DirectoryPath & "\Options.stng", OpenMode.Binary, OpenAccess.Default, OpenShare.Default, 1)
        FileGetObject(2, GPOptions, 1)
        If GPOptions <> "" Then GetOptions() Else PutOptions()
        '
        FileOpen(3, My.Application.Info.DirectoryPath & "\View.stng", OpenMode.Binary, OpenAccess.Default, OpenShare.Default, 1)
        FileGetObject(3, GPView, 1)
        If GPView <> "" Then GetView() Else FilePutObject(3, "#View# <Search><" & ToolStripVisibleSearch.Checked & "> <LT><" & ToolStripVisibleLt.Checked & ", " & ToolStripSearch.Checked & ">", 1)
        '
        FileOpen(4, My.Application.Info.DirectoryPath & "\Move.sls", OpenMode.Binary, OpenAccess.Default, OpenShare.Default, 1)
        FileGetObject(4, GPMove, 1)
        If GPMove <> "" Then GetMove() Else FilePutObject(4, "#Move# <WindowState><" & WindowState & "> <Move><" & Left & ", " & Top & ", " & Width & ", " & Height & ">", 1)
        '
6:      FrmEdit.State.Left = Val(FrmEdit.GroupBoxData.Left) + (Val(FrmEdit.GroupBoxData.Width) - Val(FrmEdit.State.Width)) / 2
        pathMFile = ""
        If ToolStrip28.Visible = False Then
            MainTab.Width = Width - 16
            MainTab.Left = 0
        Else
            MainTab.Width = Width - 15 - ToolStrip28.Width
            MainTab.Left = ToolStrip28.Width - 1
        End If
        MainTab.Height = Height - 90
        MainTab.Top = 52
        LenRow = 0
        '
        'comAdj
        '
        SearchComAdj.Items.Clear()
        SearchComAdj.Items.Add("بلا")
        SearchComAdj.Items.Add("منزل")
        SearchComAdj.Items.Add("مكتب")
        SearchComAdj.Items.Add("مشفى")
        SearchComAdj.Items.Add("مقهى")
        SearchComAdj.Items.Add("مطعم")
        SearchComAdj.Items.Add("مدرسة")
        SearchComAdj.Items.Add("جامعة")
        SearchComAdj.Items.Add("محل")
        SearchComAdj.Items.Add("دكان")
        SearchComAdj.Items.Add("شركة")
        SearchComAdj.Items.Add("مول")
        SearchComAdj.Items.Add("معمل")
        SearchComAdj.Items.Add("وزارة")
        SearchComAdj.Items.Add("مديرية")
        SearchComAdj.Items.Add("مطار")
        SearchComAdj.Items.Add("إذاعة")
        '
        FrmEdit.comAdj.Items.Clear()
        FrmEdit.comAdj.Items.Add("بلا")
        FrmEdit.comAdj.Items.Add("منزل")
        FrmEdit.comAdj.Items.Add("مكتب")
        FrmEdit.comAdj.Items.Add("مشفى")
        FrmEdit.comAdj.Items.Add("مقهى")
        FrmEdit.comAdj.Items.Add("مطعم")
        FrmEdit.comAdj.Items.Add("مدرسة")
        FrmEdit.comAdj.Items.Add("جامعة")
        FrmEdit.comAdj.Items.Add("محل")
        FrmEdit.comAdj.Items.Add("دكان")
        FrmEdit.comAdj.Items.Add("شركة")
        FrmEdit.comAdj.Items.Add("مول")
        FrmEdit.comAdj.Items.Add("معمل")
        FrmEdit.comAdj.Items.Add("وزارة")
        FrmEdit.comAdj.Items.Add("مديرية")
        FrmEdit.comAdj.Items.Add("مطار")
        FrmEdit.comAdj.Items.Add("إذاعة")
        '
    End Sub
    Private Sub FormMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If pathMFile <> "" Then
            mb = MsgBox("                                                               هل تريد حفظ التغيرات ؟", MsgBoxStyle.YesNoCancel)
            If mb = vbCancel Then e.Cancel = True
            If mb = vbNo Then End
            If mb = vbYes Then
                SaveMN2()
                End
            End If
        End If
    End Sub
    Private Sub FormMain_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        If one = 1 Then FilePutObject(4, "#Move# <WindowState><" & WindowState & "> <Move><" & Left & ", " & Top & ", " & Width & ", " & Height & ">", 1)
    End Sub
    Private Sub FormMain_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If ToolStrip28.Visible = False Then
            MainTab.Width = Width - 16
            MainTab.Left = 0
        Else
            MainTab.Width = Width - 15 - ToolStrip28.Width
            MainTab.Left = ToolStrip28.Width - 1
        End If
        MainTab.Height = Height - 90
        If one = 1 Then FilePutObject(4, "#Move# <WindowState><" & WindowState & "> <Move><" & Left & ", " & Top & ", " & Width & ", " & Height & ">", 1)
    End Sub
    Private Sub FormMain_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If one = 1 Then FilePutObject(4, "#Move# <WindowState><" & WindowState & "> <Move><" & Left & ", " & Top & ", " & Width & ", " & Height & ">", 1)
    End Sub

    Private Sub OpFile_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpFile.FileOk
        FileOpen(1, OpFile.FileName, OpenMode.Binary, OpenAccess.Default, OpenShare.Default, 1)
        FileGetObject(1, Bout, 1)
        pathMFile = OpFile.FileName
        LBout = ""
        LenRow = 0
        LLenRow = 0
        LColumn = 1
        LWColumn = 1
        LHRow = 0
        MainTab.Rows.Clear()
        For i = 1 To Len(Bout)
            If Mid(Bout, i, 1) = "%" Then
                If LenRow = 0 Then
                    LenRow = Mid(Bout, 1, i - 1)
                    FrmEdit.StateCountItem.Tag = LenRow
                    FrmEdit.StateCountItem.Text = "of {" & LenRow & "}"
                    FrmEdit.StatePositionItem.Text = LenRow
                    For j = 1 To Val(LenRow)
                        MainTab.Rows.Add(j)
                        MainTab.Rows(j - 1).Tag = j
                    Next
                Else
                    If LWColumn = MainTab.Columns.Count Then
                        If LHRow < LenRow Then
                            If MainTab.Rows(LHRow).Height <> Val(Mid(Bout, Val(LBout), Val(i) - Val(LBout))) Then MainTab.Rows(LHRow).Height = Val(Mid(Bout, Val(LBout), Val(i) - Val(LBout)))
                            LHRow = LHRow + 1
                        End If
                    End If
                    If LWColumn < MainTab.Columns.Count Then
                        If MainTab.Columns(LWColumn).Width <> Val(Mid(Bout, Val(LBout), Val(i) - Val(LBout))) Then MainTab.Columns(LWColumn).Width = Val(Mid(Bout, Val(LBout), Val(i) - Val(LBout)))
                        LWColumn = LWColumn + 1
                    End If
                End If
                LBout = i + 1
            End If
            If Mid(Bout, i, 9) = "END C1235" Then
                MainTab.Rows(Val(LLenRow)).Cells(LColumn).Value = Mid(Bout, Val(LBout), Val(i) - Val(LBout))
                CPCode = Mid(Bout, i + 9, Len(Bout) - i - 8)
                Exit For
            End If
            If Mid(Bout, i, 1) = "&" Then
                LLenRow = LLenRow + 1
                If LLenRow = LenRow Then
                    If LColumn = 1 Then NamCode = Mid(Bout, LBout, i - LBout + 1)
                    If LColumn = 2 Then NumCode = Mid(Bout, LBout, i - LBout + 1)
                    If LColumn = 3 Then TypeCode = Mid(Bout, LBout, i - LBout + 1)
                    If LColumn = 4 Then NotesCode = Mid(Bout, LBout, i - LBout + 1)
                    LLenRow = 0
                    LColumn = LColumn + 1
                    LBout = i + 1
                End If
            End If
        Next
        FrmEdit.GroupBoxData.Enabled = True
        FrmEdit.StateDeleteItem.Enabled = True
        FrmEdit.StateMoveFirstItem.Enabled = True
        FrmEdit.StateMoveLastItem.Enabled = True
        FrmEdit.StateMoveNextItem.Enabled = True
        FrmEdit.StateMovePreviousItem.Enabled = True
        FrmEdit.StatePositionItem.Enabled = True
        AllMaintab()
        ToolStripSave.Enabled = True
        MainTab.ClearSelection()
    End Sub

    Sub AllMaintab()
        '
        lNam = 0
        mNam = 0
        For i = 1 To Len(NamCode)
            If Mid(NamCode, i, 1) = "&" Then
                MainTab.Rows(lNam).Cells(1).Value = Mid(NamCode, mNam + 1, i - mNam - 1)
                lNam = lNam + 1
                mNam = i
            End If
        Next
        '
        lNum = 0
        mNum = 0
        For i = 1 To Len(NumCode)
            If Mid(NumCode, i, 1) = "&" Then
                MainTab.Rows(lNum).Cells(2).Value = Mid(NumCode, mNum + 1, i - mNum - 1)
                lNum = lNum + 1
                mNum = i
            End If
        Next
        '
        lType = 0
        mType = 0
        For i = 1 To Len(TypeCode)
            If Mid(TypeCode, i, 1) = "&" Then
                MainTab.Rows(lType).Cells(3).Value = Mid(TypeCode, mType + 1, i - mType - 1)
                lType = lType + 1
                mType = i
            End If
        Next
        '
        lNotes = 0
        mNotes = 0
        For i = 1 To Len(NotesCode)
            If Mid(NotesCode, i, 1) = "&" Then
                MainTab.Rows(lNotes).Cells(5).Value = Mid(NotesCode, mNotes + 1, i - mNotes - 1)
                lNotes = lNotes + 1
                mNotes = i
            End If
        Next
        '
        CL = 1
        LCP = 0
        mi1m = 0
        mi1 = 0
        mi2 = 0
        mi3 = 0
        mi4 = 0
        For i = 1 To Len(CPCode)
            If Mid(CPCode, i, 1) = "$" Then
                LCP = LCP + 1
                If LCP = 1 Then mi2 = i
                If LCP = 2 Then mi3 = i
                If LCP = 3 Then
                    mi1m = mi4
                    mi4 = i
                    '
                    MainTab.Rows(CL - 1).Cells(4).Value = ""
                    If Mid(CPCode, mi1 + 2, mi2 - mi1 - 2) <> "" And Mid(CPCode, mi1 + 1, 1) = 1 Then
                        MainTab.Rows(CL - 1).Cells(4).Value = Mid(CPCode, mi1 + 2, mi2 - mi1 - 2)
                        If Mid(CPCode, mi2 + 1, 1) = 1 And Mid(CPCode, mi2 + 2, mi3 - mi2 - 2) <> "" Or Mid(CPCode, mi3 + 1, 1) = 1 And Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Then MainTab.Rows(CL - 1).Cells(4).Value = MainTab.Rows(CL - 1).Cells(4).Value & "/"
                    End If
                    If Mid(CPCode, mi2 + 2, mi3 - mi2 - 2) <> "" And Mid(CPCode, mi2 + 1, 1) = 1 Then
                        MainTab.Rows(CL - 1).Cells(4).Value = MainTab.Rows(CL - 1).Cells(4).Value & Mid(CPCode, mi2 + 2, mi3 - mi2 - 2)
                        If Mid(CPCode, mi3 + 1, 1) = 1 And Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Then MainTab.Rows(CL - 1).Cells(4).Value = MainTab.Rows(CL - 1).Cells(4).Value & " - "
                    End If
                    If Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" And Mid(CPCode, mi3 + 1, 1) = 1 Then MainTab.Rows(CL - 1).Cells(4).Value = MainTab.Rows(CL - 1).Cells(4).Value & Mid(CPCode, mi3 + 2, mi4 - mi3 - 2)
                    LCP = 0
                    If CL = LenRow Then Exit For
                    CL = CL + 1
                    mi1 = mi1m
                End If
            End If
        Next
    End Sub
    Private Sub SaFile_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaFile.FileOk
        SaveMN2()
    End Sub
    Sub SaveMN2()
        If pathMFile = "" Then FileOpen(1, SaFile.FileName, OpenMode.Binary, OpenAccess.Default, OpenShare.Default, 1)
        pathMFile = SaFile.FileName
        Bput = LenRow & "%"
        For i = 1 To MainTab.Columns.Count - 1
            Bput = Bput & MainTab.Columns(i).Width & "%"
        Next
        For i = 0 To MainTab.Rows.Count - 2
            Bput = Bput & MainTab.Rows(i).Height & "%"
        Next
        Bput = Bput & NamCode & NumCode & TypeCode & NotesCode & "END C1235" & CPCode
        FilePutObject(1, Bput, 1)
    End Sub

    Private Sub ToolStripMenuFileNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuFileNew.Click, ToolStripNew.Click
        LenRow = 0
        pathMFile = ""
        NamCode = ""
        NumCode = ""
        TypeCode = ""
        CPCode = ""
        NotesCode = ""
        MainTab.Rows.Clear()
        FrmEdit.StateCountItem.Tag = 0
        FrmEdit.StateCountItem.Text = "of {0}"
        FrmEdit.StatePositionItem.Text = 0
        FrmEdit.GroupBoxData.Enabled = False
        FrmEdit.StateDeleteItem.Enabled = False
        FrmEdit.StateMoveFirstItem.Enabled = False
        FrmEdit.StateMoveLastItem.Enabled = False
        FrmEdit.StateMoveNextItem.Enabled = False
        FrmEdit.StateMovePreviousItem.Enabled = False
        FrmEdit.StatePositionItem.Enabled = False
        FrmEdit.CheckCun0.Checked = False
        FrmEdit.CheckCun1.Checked = True
        FrmEdit.CheckCun1.Checked = True
        FrmEdit.CheckPla.Checked = True
        FrmEdit.txtNam.Text = ""
        FrmEdit.txtTNum.Text = ""
        FrmEdit.comType.Text = "بلا"
        FrmEdit.comAdj.Text = "بلا"
        FrmEdit.txtCun0.Text = ""
        FrmEdit.txtCun1.Text = ""
        FrmEdit.txtPla.Text = ""
        FrmEdit.txtNotes.Text = ""
        FrmEdit.ShowDialog()
    End Sub

    Private Sub ToolStripMenuFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuFileOpen.Click, ToolStripOpen.Click
        On Error Resume Next
        FileClose(1)
        OpFile.ShowDialog()
        FileOpen(1, pathMFile, OpenMode.Binary, OpenAccess.Default, OpenShare.Default, 1)
    End Sub

    Private Sub ToolStripMenuFileSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuFileSave.Click, ToolStripSave.Click
        If pathMFile = "" Then SaFile.ShowDialog() Else SaveMN2()
    End Sub
    Private Sub ToolStripMenuFileSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuFileSaveAs.Click
        SaFile.ShowDialog()
    End Sub

    Private Sub ToolStripMenuED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuED.Click, ToolStripED.Click
        FrmEdit.ShowDialog()
    End Sub
    'LeftMenu
    Sub SortMaintab()
        ToolStripPB.Visible = True
        ToolStripPB.Value = 0
        MainTab.Rows.Clear()
        mNam = 0
        lNam = -1
        For i = 1 To Len(NamCode)
            If Mid(NamCode, i, 1) = "&" Or i = 1 Then
                If mNam <> 0 Then
                    MainTab.Rows.Add(MainTab.Rows.Count, Mid(NamCode, mNam, i - mNam))
                    MainTab.Rows(MainTab.Rows.Count - 1).Tag = mNam + 1
                    '
                    lNum = 0
                    mNum = 0
                    For j = 1 To Len(NumCode)
                        If Mid(NumCode, j, 1) = "&" Then
                            If lNum = lNam Then MainTab.Rows(lNam).Cells(2).Value = Mid(NumCode, mNum + 1, j - mNum - 1) : Exit For
                            lNum = lNum + 1
                            mNum = j
                        End If
                    Next
                    '
                    lType = 0
                    mType = 0
                    For j = 1 To Len(TypeCode)
                        If Mid(TypeCode, j, 1) = "&" Then
                            If lType = lNam Then MainTab.Rows(lNam).Cells(3).Value = Mid(TypeCode, mType + 1, j - mType - 1) : Exit For
                            lType = lType + 1
                            mType = j
                        End If
                    Next
                    '
                    lNotes = 0
                    mNotes = 0
                    For j = 1 To Len(NotesCode)
                        If Mid(NotesCode, j, 1) = "&" Then
                            If lNotes = lNam Then MainTab.Rows(lNam).Cells(3).Value = Mid(NotesCode, mNotes + 1, j - mNotes - 1) : Exit For
                            lNotes = lNotes + 1
                            mNotes = j
                        End If
                    Next
                    '
                    CL = 1
                    LCP = 0
                    mi1m = 0
                    mi1 = 0
                    mi2 = 0
                    mi3 = 0
                    mi4 = 0
                    For j = 1 To Len(CPCode)
                        If Mid(CPCode, i, 1) = "$" Then
                            LCP = LCP + 1
                            If LCP = 1 Then mi2 = i
                            If LCP = 2 Then mi3 = i
                            If LCP = 3 Then
                                mi1m = mi4
                                mi4 = i
                                '
                                If CL - 1 = lNam Then
                                    MainTab.Rows(CL - 1).Cells(4).Value = ""
                                    If Mid(CPCode, mi1 + 2, mi2 - mi1 - 2) <> "" And Mid(CPCode, mi1 + 1, 1) = 1 Then
                                        MainTab.Rows(CL - 1).Cells(4).Value = Mid(CPCode, mi1 + 2, mi2 - mi1 - 2)
                                        If Mid(CPCode, mi2 + 1, 1) = 1 And Mid(CPCode, mi2 + 2, mi3 - mi2 - 2) <> "" Or Mid(CPCode, mi3 + 1, 1) = 1 And Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Then MainTab.Rows(CL - 1).Cells(4).Value = MainTab.Rows(CL - 1).Cells(4).Value & "/"
                                    End If
                                    If Mid(CPCode, mi2 + 2, mi3 - mi2 - 2) <> "" And Mid(CPCode, mi2 + 1, 1) = 1 Then
                                        MainTab.Rows(CL - 1).Cells(4).Value = MainTab.Rows(CL - 1).Cells(4).Value & Mid(CPCode, mi2 + 2, mi3 - mi2 - 2)
                                        If Mid(CPCode, mi3 + 1, 1) = 1 And Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Then MainTab.Rows(CL - 1).Cells(4).Value = MainTab.Rows(CL - 1).Cells(4).Value & " - "
                                    End If
                                    If Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" And Mid(CPCode, mi3 + 1, 1) = 1 Then MainTab.Rows(CL - 1).Cells(4).Value = MainTab.Rows(CL - 1).Cells(4).Value & Mid(CPCode, mi3 + 2, mi4 - mi3 - 2)
                                End If
                                LCP = 0
                                CL = CL + 1
                                mi1 = mi1m
                            End If
                        End If
                    Next
                    '
                    mNam = 0
                End If
                If i = 1 Then Mid2 = 1 Else Mid2 = i + 1
                lNam = lNam + 1
                ToolStripPB.Value = ToolStripPB.Value + 100 / LenRow
                If mNam = 0 Then
                    If Mid(NamCode, Mid2, 1) = "ا" And ToolStripButtonH1.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "أ" And ToolStripButtonH1.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "إ" And ToolStripButtonH1.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "آ" And ToolStripButtonH1.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ء" And ToolStripButtonH1.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ب" And ToolStripButtonH2.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ت" And ToolStripButtonH3.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ث" And ToolStripButtonH4.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ج" And ToolStripButtonH5.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ح" And ToolStripButtonH6.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "خ" And ToolStripButtonH7.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "د" And ToolStripButtonH8.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ذ" And ToolStripButtonH9.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ر" And ToolStripButtonH10.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ز" And ToolStripButtonH11.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "س" And ToolStripButtonH12.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ش" And ToolStripButtonH13.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ص" And ToolStripButtonH14.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ض" And ToolStripButtonH15.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ط" And ToolStripButtonH16.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ظ" And ToolStripButtonH17.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ع" And ToolStripButtonH18.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "غ" And ToolStripButtonH19.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ف" And ToolStripButtonH20.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ق" And ToolStripButtonH21.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ك" And ToolStripButtonH22.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ل" And ToolStripButtonH23.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "م" And ToolStripButtonH24.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ن" And ToolStripButtonH25.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ه" And ToolStripButtonH26.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "و" And ToolStripButtonH27.Checked = True _
                    Or Mid(NamCode, Mid2, 1) = "ي" And ToolStripButtonH28.Checked = True _
                    Then mNam = Mid2
                End If
            End If
        Next
        ToolStripPB.Visible = False
    End Sub
    Sub RePaint_CheckFalse()
        ToolStripButtonAll.Checked = False
        ToolStripButtonH1.Checked = False
        ToolStripButtonH2.Checked = False
        ToolStripButtonH3.Checked = False
        ToolStripButtonH4.Checked = False
        ToolStripButtonH5.Checked = False
        ToolStripButtonH6.Checked = False
        ToolStripButtonH7.Checked = False
        ToolStripButtonH8.Checked = False
        ToolStripButtonH9.Checked = False
        ToolStripButtonH10.Checked = False
        ToolStripButtonH11.Checked = False
        ToolStripButtonH12.Checked = False
        ToolStripButtonH13.Checked = False
        ToolStripButtonH14.Checked = False
        ToolStripButtonH15.Checked = False
        ToolStripButtonH16.Checked = False
        ToolStripButtonH17.Checked = False
        ToolStripButtonH18.Checked = False
        ToolStripButtonH19.Checked = False
        ToolStripButtonH20.Checked = False
        ToolStripButtonH21.Checked = False
        ToolStripButtonH22.Checked = False
        ToolStripButtonH23.Checked = False
        ToolStripButtonH24.Checked = False
        ToolStripButtonH25.Checked = False
        ToolStripButtonH26.Checked = False
        ToolStripButtonH27.Checked = False
        ToolStripButtonH28.Checked = False
        ToolStripButtonAll.ForeColor = Color.Black
        ToolStripButtonH1.ForeColor = Color.Black
        ToolStripButtonH2.ForeColor = Color.Black
        ToolStripButtonH3.ForeColor = Color.Black
        ToolStripButtonH4.ForeColor = Color.Black
        ToolStripButtonH5.ForeColor = Color.Black
        ToolStripButtonH6.ForeColor = Color.Black
        ToolStripButtonH7.ForeColor = Color.Black
        ToolStripButtonH8.ForeColor = Color.Black
        ToolStripButtonH9.ForeColor = Color.Black
        ToolStripButtonH10.ForeColor = Color.Black
        ToolStripButtonH11.ForeColor = Color.Black
        ToolStripButtonH12.ForeColor = Color.Black
        ToolStripButtonH13.ForeColor = Color.Black
        ToolStripButtonH14.ForeColor = Color.Black
        ToolStripButtonH15.ForeColor = Color.Black
        ToolStripButtonH16.ForeColor = Color.Black
        ToolStripButtonH17.ForeColor = Color.Black
        ToolStripButtonH18.ForeColor = Color.Black
        ToolStripButtonH19.ForeColor = Color.Black
        ToolStripButtonH20.ForeColor = Color.Black
        ToolStripButtonH21.ForeColor = Color.Black
        ToolStripButtonH22.ForeColor = Color.Black
        ToolStripButtonH23.ForeColor = Color.Black
        ToolStripButtonH24.ForeColor = Color.Black
        ToolStripButtonH25.ForeColor = Color.Black
        ToolStripButtonH26.ForeColor = Color.Black
        ToolStripButtonH27.ForeColor = Color.Black
        ToolStripButtonH28.ForeColor = Color.Black
    End Sub

    Private Sub ToolStripButtonAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButtonAll.CheckedChanged
        If Val(LenRow) <> 0 Then
            MainTab.Rows.Clear()
            For i = 1 To Val(LenRow) + 1
                MainTab.Rows.Add(i)
            Next
            AllMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonAll.Click
        RePaint_CheckFalse()
        ToolStripButtonAll.Checked = True
        ToolStripButtonAll.ForeColor = Color.DodgerBlue
        ToolStripButtonH1.ForeColor = Color.DodgerBlue
        ToolStripButtonH2.ForeColor = Color.DodgerBlue
        ToolStripButtonH3.ForeColor = Color.DodgerBlue
        ToolStripButtonH4.ForeColor = Color.DodgerBlue
        ToolStripButtonH5.ForeColor = Color.DodgerBlue
        ToolStripButtonH6.ForeColor = Color.DodgerBlue
        ToolStripButtonH7.ForeColor = Color.DodgerBlue
        ToolStripButtonH8.ForeColor = Color.DodgerBlue
        ToolStripButtonH9.ForeColor = Color.DodgerBlue
        ToolStripButtonH10.ForeColor = Color.DodgerBlue
        ToolStripButtonH11.ForeColor = Color.DodgerBlue
        ToolStripButtonH12.ForeColor = Color.DodgerBlue
        ToolStripButtonH13.ForeColor = Color.DodgerBlue
        ToolStripButtonH14.ForeColor = Color.DodgerBlue
        ToolStripButtonH15.ForeColor = Color.DodgerBlue
        ToolStripButtonH16.ForeColor = Color.DodgerBlue
        ToolStripButtonH17.ForeColor = Color.DodgerBlue
        ToolStripButtonH18.ForeColor = Color.DodgerBlue
        ToolStripButtonH19.ForeColor = Color.DodgerBlue
        ToolStripButtonH20.ForeColor = Color.DodgerBlue
        ToolStripButtonH21.ForeColor = Color.DodgerBlue
        ToolStripButtonH22.ForeColor = Color.DodgerBlue
        ToolStripButtonH23.ForeColor = Color.DodgerBlue
        ToolStripButtonH24.ForeColor = Color.DodgerBlue
        ToolStripButtonH25.ForeColor = Color.DodgerBlue
        ToolStripButtonH26.ForeColor = Color.DodgerBlue
        ToolStripButtonH27.ForeColor = Color.DodgerBlue
        ToolStripButtonH28.ForeColor = Color.DodgerBlue
    End Sub
    Sub AllBB()
        If ToolStripButtonAll.Checked = True Then
            ToolStripButtonAll.Checked = False
            ToolStripButtonAll.ForeColor = Color.Black
            ToolStripButtonH1.ForeColor = Color.Black
            ToolStripButtonH2.ForeColor = Color.Black
            ToolStripButtonH3.ForeColor = Color.Black
            ToolStripButtonH4.ForeColor = Color.Black
            ToolStripButtonH5.ForeColor = Color.Black
            ToolStripButtonH6.ForeColor = Color.Black
            ToolStripButtonH7.ForeColor = Color.Black
            ToolStripButtonH8.ForeColor = Color.Black
            ToolStripButtonH9.ForeColor = Color.Black
            ToolStripButtonH10.ForeColor = Color.Black
            ToolStripButtonH11.ForeColor = Color.Black
            ToolStripButtonH12.ForeColor = Color.Black
            ToolStripButtonH13.ForeColor = Color.Black
            ToolStripButtonH14.ForeColor = Color.Black
            ToolStripButtonH15.ForeColor = Color.Black
            ToolStripButtonH16.ForeColor = Color.Black
            ToolStripButtonH17.ForeColor = Color.Black
            ToolStripButtonH18.ForeColor = Color.Black
            ToolStripButtonH19.ForeColor = Color.Black
            ToolStripButtonH20.ForeColor = Color.Black
            ToolStripButtonH21.ForeColor = Color.Black
            ToolStripButtonH22.ForeColor = Color.Black
            ToolStripButtonH23.ForeColor = Color.Black
            ToolStripButtonH24.ForeColor = Color.Black
            ToolStripButtonH25.ForeColor = Color.Black
            ToolStripButtonH26.ForeColor = Color.Black
            ToolStripButtonH27.ForeColor = Color.Black
            ToolStripButtonH28.ForeColor = Color.Black
        End If
    End Sub
    Private Sub ToolStripButtonH1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH1.Checked = False Then ToolStripButtonH1.Checked = True Else ToolStripButtonH1.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH1.Checked = True
            End If
            AllBB()
            If ToolStripButtonH1.Checked = True Then ToolStripButtonH1.ForeColor = Color.DodgerBlue Else ToolStripButtonH1.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH2.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH2.Checked = False Then ToolStripButtonH2.Checked = True Else ToolStripButtonH2.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH2.Checked = True
            End If
            AllBB()
            If ToolStripButtonH2.Checked = True Then ToolStripButtonH2.ForeColor = Color.DodgerBlue Else ToolStripButtonH2.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH3.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH3.Checked = False Then ToolStripButtonH3.Checked = True Else ToolStripButtonH3.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH3.Checked = True
            End If
            AllBB()
            If ToolStripButtonH3.Checked = True Then ToolStripButtonH3.ForeColor = Color.DodgerBlue Else ToolStripButtonH3.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH4.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH4.Checked = False Then ToolStripButtonH4.Checked = True Else ToolStripButtonH4.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH4.Checked = True
            End If
            AllBB()
            If ToolStripButtonH4.Checked = True Then ToolStripButtonH4.ForeColor = Color.DodgerBlue Else ToolStripButtonH4.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH5.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH5.Checked = False Then ToolStripButtonH5.Checked = True Else ToolStripButtonH5.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH5.Checked = True
            End If
            AllBB()
            If ToolStripButtonH5.Checked = True Then ToolStripButtonH5.ForeColor = Color.DodgerBlue Else ToolStripButtonH5.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH6_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH6.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH6.Checked = False Then ToolStripButtonH6.Checked = True Else ToolStripButtonH6.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH6.Checked = True
            End If
            AllBB()
            If ToolStripButtonH6.Checked = True Then ToolStripButtonH6.ForeColor = Color.DodgerBlue Else ToolStripButtonH6.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH7_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH7.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH7.Checked = False Then ToolStripButtonH7.Checked = True Else ToolStripButtonH7.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH7.Checked = True
            End If
            AllBB()
            If ToolStripButtonH7.Checked = True Then ToolStripButtonH7.ForeColor = Color.DodgerBlue Else ToolStripButtonH7.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH8_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH8.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH8.Checked = False Then ToolStripButtonH8.Checked = True Else ToolStripButtonH8.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH8.Checked = True
            End If
            AllBB()
            If ToolStripButtonH8.Checked = True Then ToolStripButtonH8.ForeColor = Color.DodgerBlue Else ToolStripButtonH8.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH9_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH9.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH9.Checked = False Then ToolStripButtonH9.Checked = True Else ToolStripButtonH9.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH9.Checked = True
            End If
            AllBB()
            If ToolStripButtonH9.Checked = True Then ToolStripButtonH9.ForeColor = Color.DodgerBlue Else ToolStripButtonH9.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH10_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH10.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH10.Checked = False Then ToolStripButtonH10.Checked = True Else ToolStripButtonH10.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH10.Checked = True
            End If
            AllBB()
            If ToolStripButtonH10.Checked = True Then ToolStripButtonH10.ForeColor = Color.DodgerBlue Else ToolStripButtonH10.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH11_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH11.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH11.Checked = False Then ToolStripButtonH11.Checked = True Else ToolStripButtonH11.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH11.Checked = True
            End If
            AllBB()
            If ToolStripButtonH11.Checked = True Then ToolStripButtonH11.ForeColor = Color.DodgerBlue Else ToolStripButtonH11.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH12_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH12.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH12.Checked = False Then ToolStripButtonH12.Checked = True Else ToolStripButtonH12.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH12.Checked = True
            End If
            AllBB()
            If ToolStripButtonH12.Checked = True Then ToolStripButtonH12.ForeColor = Color.DodgerBlue Else ToolStripButtonH12.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH13_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH13.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH13.Checked = False Then ToolStripButtonH13.Checked = True Else ToolStripButtonH13.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH13.Checked = True
            End If
            AllBB()
            If ToolStripButtonH13.Checked = True Then ToolStripButtonH13.ForeColor = Color.DodgerBlue Else ToolStripButtonH13.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH14_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH14.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH14.Checked = False Then ToolStripButtonH14.Checked = True Else ToolStripButtonH14.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH14.Checked = True
            End If
            AllBB()
            If ToolStripButtonH14.Checked = True Then ToolStripButtonH14.ForeColor = Color.DodgerBlue Else ToolStripButtonH14.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH15_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH15.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH15.Checked = False Then ToolStripButtonH15.Checked = True Else ToolStripButtonH15.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH15.Checked = True
            End If
            AllBB()
            If ToolStripButtonH15.Checked = True Then ToolStripButtonH15.ForeColor = Color.DodgerBlue Else ToolStripButtonH15.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH16_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH16.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH16.Checked = False Then ToolStripButtonH16.Checked = True Else ToolStripButtonH16.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH16.Checked = True
            End If
            AllBB()
            If ToolStripButtonH16.Checked = True Then ToolStripButtonH16.ForeColor = Color.DodgerBlue Else ToolStripButtonH16.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH18_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH18.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH18.Checked = False Then ToolStripButtonH18.Checked = True Else ToolStripButtonH18.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH18.Checked = True
            End If
            AllBB()
            If ToolStripButtonH18.Checked = True Then ToolStripButtonH18.ForeColor = Color.DodgerBlue Else ToolStripButtonH18.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH19_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH19.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH19.Checked = False Then ToolStripButtonH19.Checked = True Else ToolStripButtonH19.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH19.Checked = True
            End If
            AllBB()
            If ToolStripButtonH19.Checked = True Then ToolStripButtonH19.ForeColor = Color.DodgerBlue Else ToolStripButtonH19.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH20_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH20.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH20.Checked = False Then ToolStripButtonH20.Checked = True Else ToolStripButtonH20.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH20.Checked = True
            End If
            AllBB()
            If ToolStripButtonH20.Checked = True Then ToolStripButtonH20.ForeColor = Color.DodgerBlue Else ToolStripButtonH20.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH21_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH21.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH21.Checked = False Then ToolStripButtonH21.Checked = True Else ToolStripButtonH21.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH21.Checked = True
            End If
            AllBB()
            If ToolStripButtonH21.Checked = True Then ToolStripButtonH21.ForeColor = Color.DodgerBlue Else ToolStripButtonH21.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH22_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH22.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH22.Checked = False Then ToolStripButtonH22.Checked = True Else ToolStripButtonH22.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH22.Checked = True
            End If
            AllBB()
            If ToolStripButtonH22.Checked = True Then ToolStripButtonH22.ForeColor = Color.DodgerBlue Else ToolStripButtonH22.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH23_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH23.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH23.Checked = False Then ToolStripButtonH23.Checked = True Else ToolStripButtonH23.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH23.Checked = True
            End If
            AllBB()
            If ToolStripButtonH23.Checked = True Then ToolStripButtonH23.ForeColor = Color.DodgerBlue Else ToolStripButtonH23.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH24_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH24.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH24.Checked = False Then ToolStripButtonH24.Checked = True Else ToolStripButtonH24.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH24.Checked = True
            End If
            AllBB()
            If ToolStripButtonH24.Checked = True Then ToolStripButtonH24.ForeColor = Color.DodgerBlue Else ToolStripButtonH24.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH25_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH25.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH25.Checked = False Then ToolStripButtonH25.Checked = True Else ToolStripButtonH25.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH25.Checked = True
            End If
            AllBB()
            If ToolStripButtonH25.Checked = True Then ToolStripButtonH25.ForeColor = Color.DodgerBlue Else ToolStripButtonH25.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH26_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH26.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH26.Checked = False Then ToolStripButtonH26.Checked = True Else ToolStripButtonH26.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH26.Checked = True
            End If
            AllBB()
            If ToolStripButtonH26.Checked = True Then ToolStripButtonH26.ForeColor = Color.DodgerBlue Else ToolStripButtonH26.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH27_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH27.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH27.Checked = False Then ToolStripButtonH27.Checked = True Else ToolStripButtonH27.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH27.Checked = True
            End If
            AllBB()
            If ToolStripButtonH27.Checked = True Then ToolStripButtonH27.ForeColor = Color.DodgerBlue Else ToolStripButtonH27.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    Private Sub ToolStripButtonH28_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonH28.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Or e.Button = Windows.Forms.MouseButtons.Right Then
            If ToolStripButtonH28.Checked = False Then ToolStripButtonH28.Checked = True Else ToolStripButtonH28.Checked = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RePaint_CheckFalse()
                ToolStripButtonH28.Checked = True
            End If
            AllBB()
            If ToolStripButtonH28.Checked = True Then ToolStripButtonH28.ForeColor = Color.DodgerBlue Else ToolStripButtonH28.ForeColor = Color.Black
            SortMaintab()
        End If
    End Sub
    '
    Private Sub SearchTxtNam_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchTxtNam.TextChanged, SearchTxtNum.TextChanged, SearchTxtNotes.TextChanged, SearchComAdj.TextChanged, SearchTxtCun0.TextChanged, SearchTxtPla.TextChanged, SearchTxtCun1.TextChanged
        MainTab.Rows.Clear()
        ToolStripPB.Visible = True
        ToolStripPB.Value = 0
        '
        'STxtNam
        '
        If ToolStripSearch.Checked = True Then
            If Trim(SearchTxtNam.Text) <> "" Then
                lNam = 0
                mNam = 0
                For i = 1 To Len(NamCode)
                    If Mid(NamCode, i, 1) = "&" Then
                        For j = 1 To i - mNam - 1
                            If Mid(NamCode, mNam + j, Len(SearchTxtNam.Text)) = SearchTxtNam.Text Then
                                '
                                MainTab.Rows.Add(MainTab.Rows.Count, Mid(NamCode, mNam + 1, i - mNam - 1))
                                MainTab.Rows(MainTab.Rows.Count - 1).Tag = lNam + 1
                                '
                                lNum = 0
                                mNum = 0
                                For k = 1 To Len(NumCode)
                                    If Mid(NumCode, k, 1) = "&" Then
                                        If lNum = lNam Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(2).Value = Mid(NumCode, mNum + 1, k - mNum - 1) : Exit For
                                        lNum = lNum + 1
                                        mNum = k
                                    End If
                                Next
                                '
                                lType = 0
                                mType = 0
                                For k = 1 To Len(TypeCode)
                                    If Mid(TypeCode, k, 1) = "&" Then
                                        If lType = lNam Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(3).Value = Mid(TypeCode, mType + 1, k - mType - 1) : Exit For
                                        lType = lType + 1
                                        mType = k
                                    End If
                                Next
                                '
                                lNotes = 0
                                mNotes = 0
                                For k = 1 To Len(NotesCode)
                                    If Mid(NotesCode, k, 1) = "&" Then
                                        If lNotes = lNam Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(3).Value = Mid(NotesCode, mNotes + 1, k - mNotes - 1) : Exit For
                                        lNotes = lNotes + 1
                                        mNotes = k
                                    End If
                                Next
                                CL = 1
                                LCP = 0
                                mi1m = 0
                                mi1 = 0
                                mi2 = 0
                                mi3 = 0
                                mi4 = 0
                                For k = 1 To Len(CPCode)
                                    If Mid(CPCode, k, 1) = "$" Then
                                        LCP = LCP + 1
                                        If LCP = 1 Then mi2 = k
                                        If LCP = 2 Then mi3 = k
                                        If LCP = 3 Then
                                            mi1m = mi4
                                            mi4 = k
                                            '
                                            If CL - 1 = lNam Then
                                                MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = ""
                                                If Mid(CPCode, mi1 + 2, mi2 - mi1 - 2) <> "" And Mid(CPCode, mi1 + 1, 1) = 1 Then
                                                    MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = Mid(CPCode, mi1 + 2, mi2 - mi1 - 2)
                                                    If Mid(CPCode, mi2 + 1, 1) = 1 And Mid(CPCode, mi2 + 2, mi3 - mi2 - 2) <> "" Or Mid(CPCode, mi3 + 1, 1) = 1 And Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Or Mid(CPCode, mi3 + 1, 1) = 1 And Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & "/"
                                                End If
                                                If Mid(CPCode, mi2 + 2, mi3 - mi2 - 2) <> "" And Mid(CPCode, mi2 + 1, 1) = 1 Then
                                                    MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & Mid(CPCode, mi2 + 2, mi3 - mi2 - 2)
                                                    If Mid(CPCode, mi3 + 1, 1) = 1 And Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Or Mid(CPCode, mi3 + 1, 1) = 1 And Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & " - "
                                                End If
                                                If Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" And Mid(CPCode, mi3 + 1, 1) = 1 Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & Mid(CPCode, mi3 + 2, mi4 - mi3 - 2)
                                                GoTo 1
                                            End If
                                            LCP = 0
                                            CL = CL + 1
                                            mi1 = mi1m
                                        End If
                                    End If
                                Next
                                '
                            End If
                        Next
1:                      ToolStripPB.Value = ToolStripPB.Value + 100 / (LenRow * 5)
                        lNam = lNam + 1
                        mNam = i
                    End If
                Next
            End If
            '
            'STxtNum
            '
            If Trim(SearchTxtNum.Text) <> "" Then
                lNum = 0
                mNum = 0
                For i = 1 To Len(NumCode)
                    If Mid(NumCode, i, 1) = "&" Then
                        For j = 1 To i - mNum - 1
                            If Mid(NumCode, mNum + j, Len(SearchTxtNum.Text)) = SearchTxtNum.Text Then
                                If Trim(SearchTxtNam.Text) <> "" Then
                                    For k = 0 To MainTab.Rows.Count - 1
                                        If MainTab.Rows(k).Tag = lNum Then GoTo 2
                                    Next
                                End If
                                '
                                MainTab.Rows.Add(MainTab.Rows.Count, "", Mid(NumCode, mNum + 1, i - mNum - 1))
                                MainTab.Rows(MainTab.Rows.Count - 1).Tag = lNum + 1
                                '
                                lNam = 0
                                mNam = 0
                                For k = 1 To Len(NamCode)
                                    If Mid(NamCode, k, 1) = "&" Then
                                        If lNam = lNum Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(1).Value = Mid(NamCode, mNam + 1, k - mNam - 1) : Exit For
                                        lNam = lNam + 1
                                        mNam = k
                                    End If
                                Next
                                '
                                lType = 0
                                mType = 0
                                For k = 1 To Len(TypeCode)
                                    If Mid(TypeCode, k, 1) = "&" Then
                                        If lType = lNum Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(3).Value = Mid(TypeCode, mType + 1, k - mType - 1) : Exit For
                                        lType = lType + 1
                                        mType = k
                                    End If
                                Next
                                '
                                lNotes = 0
                                mNotes = 0
                                For k = 1 To Len(NotesCode)
                                    If Mid(NotesCode, k, 1) = "&" Then
                                        If lNotes = lNum Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(3).Value = Mid(NotesCode, mNotes + 1, k - mNotes - 1) : Exit For
                                        lNotes = lNotes + 1
                                        mNotes = k
                                    End If
                                Next
                                CL = 1
                                LCP = 0
                                mi1m = 0
                                mi1 = 0
                                mi2 = 0
                                mi3 = 0
                                mi4 = 0
                                For k = 1 To Len(CPCode)
                                    If Mid(CPCode, k, 1) = "$" Then
                                        LCP = LCP + 1
                                        If LCP = 1 Then mi2 = k
                                        If LCP = 2 Then mi3 = k
                                        If LCP = 3 Then
                                            mi1m = mi4
                                            mi4 = k
                                            '
                                            If CL - 1 = lNum Then
                                                MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = ""
                                                If Mid(CPCode, mi1 + 2, mi2 - mi1 - 2) <> "" And Mid(CPCode, mi1 + 1, 1) = 1 Then
                                                    MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = Mid(CPCode, mi1 + 2, mi2 - mi1 - 2)
                                                    If Mid(CPCode, mi2 + 1, 1) = 1 And Mid(CPCode, mi2 + 2, mi3 - mi2 - 2) <> "" Or Mid(CPCode, mi3 + 1, 1) = 1 And Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & "/"
                                                End If
                                                If Mid(CPCode, mi2 + 2, mi3 - mi2 - 2) <> "" And Mid(CPCode, mi2 + 1, 1) = 1 Then
                                                    MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & Mid(CPCode, mi2 + 2, mi3 - mi2 - 2)
                                                    If Mid(CPCode, mi3 + 1, 1) = 1 And Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & " - "
                                                End If
                                                If Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" And Mid(CPCode, mi3 + 1, 1) = 1 Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & Mid(CPCode, mi3 + 2, mi4 - mi3 - 2)
                                                GoTo 2
                                            End If
                                            LCP = 0
                                            CL = CL + 1
                                            mi1 = mi1m
                                        End If
                                    End If
                                Next
                                '
                            End If
                        Next
2:                      ToolStripPB.Value = ToolStripPB.Value + 100 / (LenRow * 5)
                        lNum = lNum + 1
                        mNum = i
                    End If
                Next
            End If
            '
            'STxtType
            '
            If SearchComType.Text <> "بلا" Then
                lType = 0
                mType = 0
                For i = 1 To Len(TypeCode)
                    If Mid(TypeCode, i, 1) = "&" Then
                        If Mid(TypeCode, mType + 1, Len(SearchComType.Text)) = SearchComType.Text Then
                            If Trim(SearchTxtNam.Text) <> "" Or Trim(SearchTxtNum.Text) <> "" Then
                                For k = 0 To MainTab.Rows.Count - 1
                                    If MainTab.Rows(k).Tag = lType Then GoTo 3
                                Next
                            End If
                            '
                            MainTab.Rows.Add(MainTab.Rows.Count, "", "", Mid(TypeCode, mType + 1, i - mType - 1))
                            MainTab.Rows(MainTab.Rows.Count - 1).Tag = lType + 1
                            '
                            lNam = 0
                            mNam = 0
                            For k = 1 To Len(NamCode)
                                If Mid(NamCode, k, 1) = "&" Then
                                    If lNam = lType Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(1).Value = Mid(NamCode, mNam + 1, k - mNam - 1) : Exit For
                                    lNam = lNam + 1
                                    mNam = k
                                End If
                            Next
                            '
                            lNum = 0
                            mNum = 0
                            For k = 1 To Len(NumCode)
                                If Mid(NumCode, k, 1) = "&" Then
                                    If lNum = lType Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(2).Value = Mid(NumCode, mNum + 1, k - mNum - 1) : Exit For
                                    lNum = lNum + 1
                                    mNum = k
                                End If
                            Next
                            '
                            lNotes = 0
                            mNotes = 0
                            For k = 1 To Len(NotesCode)
                                If Mid(NotesCode, k, 1) = "&" Then
                                    If lNotes = lType Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(5).Value = Mid(NotesCode, mNotes + 1, k - mNotes - 1) : Exit For
                                    lNotes = lNotes + 1
                                    mNotes = k
                                End If
                            Next
                            '
                            CL = 1
                            LCP = 0
                            mi1m = 0
                            mi1 = 0
                            mi2 = 0
                            mi3 = 0
                            mi4 = 0
                            For k = 1 To Len(CPCode)
                                If Mid(CPCode, k, 1) = "$" Then
                                    LCP = LCP + 1
                                    If LCP = 1 Then mi2 = k
                                    If LCP = 2 Then mi3 = k
                                    If LCP = 3 Then
                                        mi1m = mi4
                                        mi4 = k
                                        '
                                        If CL - 1 = lType Then
                                            MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = ""
                                            If Mid(CPCode, mi1 + 2, mi2 - mi1 - 2) <> "" And Mid(CPCode, mi1 + 1, 1) = 1 Then
                                                MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = Mid(CPCode, mi1 + 2, mi2 - mi1 - 2)
                                                If Mid(CPCode, mi2 + 1, 1) = 1 And Mid(CPCode, mi2 + 2, mi3 - mi2 - 2) <> "" Or Mid(CPCode, mi3 + 1, 1) = 1 And Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & "/"
                                            End If
                                            If Mid(CPCode, mi2 + 2, mi3 - mi2 - 2) <> "" And Mid(CPCode, mi2 + 1, 1) = 1 Then
                                                MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & Mid(CPCode, mi2 + 2, mi3 - mi2 - 2)
                                                If Mid(CPCode, mi3 + 1, 1) = 1 And Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & " - "
                                            End If
                                            If Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" And Mid(CPCode, mi3 + 1, 1) = 1 Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & Mid(CPCode, mi3 + 2, mi4 - mi3 - 2)
                                            GoTo 3
                                        End If
                                        LCP = 0
                                        CL = CL + 1
                                        mi1 = mi1m
                                    End If
                                End If
                            Next
                            '
                        End If
3:                      ToolStripPB.Value = ToolStripPB.Value + 100 / (LenRow * 5)
                        lType = lType + 1
                        mType = i
                    End If
                Next
            End If
            '
            'STxtCP
            '
            If Trim(SearchTxtCun0.Text) <> "" Or Trim(SearchTxtCun1.Text) <> "" Or Trim(SearchTxtPla.Text) <> "" Then
                CL = 1
                LCP = 0
                mi1m = 0
                mi1 = 0
                mi2 = 0
                mi3 = 0
                mi4 = 0
                For i = 1 To Len(CPCode)
                    If Mid(CPCode, i, 1) = "$" Then
                        LCP = LCP + 1
                        If LCP = 1 Then mi2 = i
                        If LCP = 2 Then mi3 = i
                        If LCP = 3 Then
                            mi1m = mi4
                            mi4 = i
                            '
                            If Trim(SearchTxtCun0.Text) <> "" Then
                                For j = 2 To mi2 - mi1 - 1
                                    If Mid(CPCode, mi1 + j, Len(SearchTxtCun0.Text)) = SearchTxtCun0.Text Then
                                        SearchCPPut()
                                        GoTo 4
                                    End If
                                Next
                            End If
                            '
                            If Trim(SearchTxtCun1.Text) <> "" Then
                                For j = 2 To mi3 - mi2 - 1
                                    If Mid(CPCode, mi2 + j, Len(SearchTxtCun1.Text)) = SearchTxtCun1.Text Then
                                        SearchCPPut()
                                        GoTo 4
                                    End If
                                Next
                            End If
                            '
                            If Trim(SearchTxtPla.Text) <> "" Then
                                For j = 2 To mi4 - mi3 - 1
                                    If Mid(CPCode, mi3 + j, Len(SearchTxtPla.Text)) = SearchTxtPla.Text Then
                                        SearchCPPut()
                                        GoTo 4
                                    End If
                                Next
                            End If
                            '
4:                          ToolStripPB.Value = ToolStripPB.Value + 100 / (LenRow * 5)
                            LCP = 0
                            CL = CL + 1
                            mi1 = mi1m
                        End If
                    End If
                Next
            End If
            '
            'STxtNotes
            '
            If Trim(SearchTxtNotes.Text) <> "" Then
                lNotes = 0
                mNotes = 0
                For i = 1 To Len(NotesCode)
                    If Mid(NotesCode, i, 1) = "&" Then
                        For j = 1 To i - mNotes - 1
                            If Mid(NotesCode, mNotes + j, Len(SearchTxtNotes.Text)) = SearchTxtNotes.Text Then
                                If Trim(SearchTxtNam.Text) <> "" Or Trim(SearchTxtNum.Text) <> "" Or Trim(SearchComType.Text) <> "بلا" Or Trim(SearchTxtCun0.Text) <> "" Or Trim(SearchTxtCun1.Text) <> "" Or Trim(SearchTxtPla.Text) <> "" Then
                                    For k = 0 To MainTab.Rows.Count - 1
                                        If MainTab.Rows(k).Tag = lNotes Then GoTo 5
                                    Next
                                End If
                                '
                                MainTab.Rows.Add(MainTab.Rows.Count, "", "", "", "", Mid(NotesCode, mNotes + 1, i - mNotes - 1))
                                MainTab.Rows(MainTab.Rows.Count - 1).Tag = lNotes + 1
                                '
                                lNam = 0
                                mNam = 0
                                For k = 1 To Len(NamCode)
                                    If Mid(NamCode, k, 1) = "&" Then
                                        If lNam = lNotes Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(1).Value = Mid(NamCode, mNam + 1, k - mNam - 1) : Exit For
                                        lNam = lNam + 1
                                        mNam = k
                                    End If
                                Next
                                '
                                lNum = 0
                                mNum = 0
                                For k = 1 To Len(NumCode)
                                    If Mid(NumCode, k, 1) = "&" Then
                                        If lNum = lNotes Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(3).Value = Mid(NumCode, mNum + 1, k - mNum - 1) : Exit For
                                        lNum = lNum + 1
                                        mNum = k
                                    End If
                                Next
                                '
                                lType = 0
                                mType = 0
                                For k = 1 To Len(TypeCode)
                                    If Mid(TypeCode, k, 1) = "&" Then
                                        If lType = lNotes Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(3).Value = Mid(TypeCode, mType + 1, k - mType - 1) : Exit For
                                        lType = lType + 1
                                        mType = k
                                    End If
                                Next
                                CL = 1
                                LCP = 0
                                mi1m = 0
                                mi1 = 0
                                mi2 = 0
                                mi3 = 0
                                mi4 = 0
                                For k = 1 To Len(CPCode)
                                    If Mid(CPCode, k, 1) = "$" Then
                                        LCP = LCP + 1
                                        If LCP = 1 Then mi2 = k
                                        If LCP = 2 Then mi3 = k
                                        If LCP = 3 Then
                                            mi1m = mi4
                                            mi4 = k
                                            '
                                            If CL - 1 = lNotes Then
                                                MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = ""
                                                If Mid(CPCode, mi1 + 2, mi2 - mi1 - 2) <> "" And Mid(CPCode, mi1 + 1, 1) = 1 Then
                                                    MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = Mid(CPCode, mi1 + 2, mi2 - mi1 - 2)
                                                    If Mid(CPCode, mi2 + 1, 1) = 1 And Mid(CPCode, mi2 + 2, mi3 - mi2 - 2) <> "" Or Mid(CPCode, mi3 + 1, 1) = 1 And Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & "/"
                                                End If
                                                If Mid(CPCode, mi2 + 2, mi3 - mi2 - 2) <> "" And Mid(CPCode, mi2 + 1, 1) = 1 Then
                                                    MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & Mid(CPCode, mi2 + 2, mi3 - mi2 - 2)
                                                    If Mid(CPCode, mi3 + 1, 1) = 1 And Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & " - "
                                                End If
                                                If Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" And Mid(CPCode, mi3 + 1, 1) = 1 Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & Mid(CPCode, mi3 + 2, mi4 - mi3 - 2)
                                                GoTo 5
                                            End If
                                            LCP = 0
                                            CL = CL + 1
                                            mi1 = mi1m
                                        End If
                                    End If
                                Next
                            End If
                        Next
5:                      ToolStripPB.Value = ToolStripPB.Value + 100 / (LenRow * 5)
                        lNotes = lNotes + 1
                        mNotes = i
                    End If
                Next
            End If
        End If
        '
        If Trim(SearchTxtNam.Text) = "" And Trim(SearchTxtNum.Text) = "" And Trim(SearchTxtNotes.Text) = "" And SearchComType.Text = "بلا" And Trim(SearchTxtCun0.Text) = "" And Trim(SearchTxtCun1.Text) = "" And Trim(SearchTxtPla.Text) = "" Then
            If LenRow <> 0 Then
                For i = 1 To Val(LenRow)
                    MainTab.Rows.Add(i)
                Next
                AllMaintab()
            End If
        End If
        ToolStripPB.Visible = False
    End Sub
    Sub SearchCPPut()
        If Trim(SearchTxtNam.Text) <> "" Or Trim(SearchTxtNum.Text) <> "" Or Trim(SearchComType.Text) <> "بلا" Then
            For k = 0 To MainTab.Rows.Count - 1
                If MainTab.Rows(k).Tag = CL - 1 Then Exit Sub
            Next
        End If
        '''''
        MainTab.Rows.Add(MainTab.Rows.Count)
        If Mid(CPCode, mi1 + 2, mi2 - mi1 - 2) <> "" Then
            MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = Mid(CPCode, mi1 + 2, mi2 - mi1 - 2)
            If Mid(CPCode, mi2 + 2, mi3 - mi2 - 2) <> "" Or Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & "/"
        End If
        If Mid(CPCode, mi2 + 2, mi3 - mi2 - 2) <> "" Then
            MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & Mid(CPCode, mi2 + 2, mi3 - mi2 - 2)
            If Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & " - "
        End If
        If Mid(CPCode, mi3 + 2, mi4 - mi3 - 2) <> "" Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value = MainTab.Rows(MainTab.Rows.Count - 2).Cells(4).Value & Mid(CPCode, mi3 + 2, mi4 - mi3 - 2)
        '''''
        MainTab.Rows(MainTab.Rows.Count - 1).Tag = CL
        '
        lNam = 0
        mNam = 0
        For k = 1 To Len(NamCode)
            If Mid(NamCode, k, 1) = "&" Then
                If lNam = CL - 1 Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(1).Value = Mid(NamCode, mNam + 1, k - mNam - 1) : Exit For
                lNam = lNam + 1
                mNam = k
            End If
        Next
        '
        lNum = 0
        mNum = 0
        For k = 1 To Len(NumCode)
            If Mid(NumCode, k, 1) = "&" Then
                If lNum = CL - 1 Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(2).Value = Mid(NumCode, mNum + 1, k - mNum - 1) : Exit For
                lNum = lNum + 1
                mNum = k
            End If
        Next
        '
        lType = 0
        mType = 0
        For k = 1 To Len(TypeCode)
            If Mid(TypeCode, k, 1) = "&" Then
                If lType = CL - 1 Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(3).Value = Mid(TypeCode, mType + 1, k - mType - 1) : Exit For
                lType = lType + 1
                mType = k
            End If
        Next
        '
        lNotes = 0
        mNotes = 0
        For k = 1 To Len(NotesCode)
            If Mid(NotesCode, k, 1) = "&" Then
                If lNotes = CL - 1 Then MainTab.Rows(MainTab.Rows.Count - 2).Cells(5).Value = Mid(NotesCode, mNotes + 1, k - mNotes - 1) : Exit For
                lNotes = lNotes + 1
                mNotes = k
            End If
        Next
    End Sub

    Private Sub SearchComType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchComType.TextChanged
        If SearchComType.Text = "هاتف/أرضي" Then
            SearchComAdj.Visible = True
            ToolStripLabel4.Visible = True
        Else
            If SearchComAdj.Visible = True Then
                SearchComAdj.Visible = False
                ToolStripLabel4.Visible = False
            End If
        End If
        SearchTxtNam_TextChanged(sender, e)
    End Sub

    Private Sub ToolStripSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSearch.Click
        If ToolStripSearch.Checked = True And ToolStripSearch.Visible = True Then
            SearchTxtNam.Visible = True
            SearchTxtNum.Visible = True
            SearchComType.Visible = True
            SearchTxtCun0.Visible = True
            SearchTxtCun1.Visible = True
            SearchTxtPla.Visible = True
            SearchTxtNotes.Visible = True
            ToolStripLabel1.Visible = True
            ToolStripLabel2.Visible = True
            ToolStripLabel3.Visible = True
            ToolStripLabel5.Visible = True
            ToolStripLabel6.Visible = True
            ToolStripLabel7.Visible = True
            ToolStripLabel8.Visible = True
        Else
            SearchTxtNam.Text = ""
            SearchTxtNum.Text = ""
            SearchComType.Text = "بلا"
            SearchTxtCun0.Text = ""
            SearchTxtCun1.Text = ""
            SearchTxtPla.Text = ""
            SearchTxtNotes.Text = ""
            SearchTxtNam.Visible = False
            SearchTxtNum.Visible = False
            SearchComType.Visible = False
            SearchTxtCun0.Visible = False
            SearchTxtCun1.Visible = False
            SearchTxtPla.Visible = False
            SearchTxtNotes.Visible = False
            ToolStripLabel1.Visible = False
            ToolStripLabel2.Visible = False
            ToolStripLabel3.Visible = False
            ToolStripLabel5.Visible = False
            ToolStripLabel6.Visible = False
            ToolStripLabel7.Visible = False
            ToolStripLabel8.Visible = False
        End If
        FilePutObject(3, "#View# <Search><" & ToolStripVisibleSearch.Checked & "> <LT><" & ToolStripVisibleLt.Checked & ", " & ToolStripSearch.Checked & ">", 1)
    End Sub

    Private Sub ToolStripVisibleLt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripVisibleLt.Click
        ToolStrip28.Visible = ToolStripVisibleLt.Checked
        If ToolStrip28.Visible = False Then
            MainTab.Width = Width - 16
            MainTab.Left = 0
        Else
            MainTab.Width = Width - 15 - ToolStrip28.Width
            MainTab.Left = ToolStrip28.Width - 1
        End If
        FilePutObject(3, "#View# <Search><" & ToolStripVisibleSearch.Checked & "> <LT><" & ToolStripVisibleLt.Checked & ", " & ToolStripSearch.Checked & ">", 1)
    End Sub

    Private Sub ToolStripVisibleSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripVisibleSearch.Click
        ToolStripSearch.Visible = ToolStripVisibleSearch.Checked
        ToolStripSearch_Click(sender, e)
        FilePutObject(3, "#View# <Search><" & ToolStripVisibleSearch.Checked & "> <LT><" & ToolStripVisibleLt.Checked & ", " & ToolStripSearch.Checked & ">", 1)
    End Sub

    Private Sub ToolStripMenuOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuOptions.Click
        FrmProperties.ShowDialog()
    End Sub

    Private Sub ToolStripMenuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuFileExit.Click
        End
    End Sub

    Sub PutOptions()
        GPOptions = "#Options# <Maintab.RaightToLeft>"
        If FrmProperties.CheckMainTabR.Checked = True Then GPOptions = GPOptions & "<Yes> " Else GPOptions = GPOptions & "<No> "
        GPOptions = GPOptions & "<Maintab.BackGroundColor>" & "<" & FrmProperties.ButtonColorMainTab.BackColor.ToString & ">"
        FilePutObject(2, GPOptions, 1)
    End Sub
    Sub GetOptions()
        mis = 0
        For i = 1 To Len(GPOptions)
            If Mid(GPOptions, i, 22) = "<Maintab.RaightToLeft>" Then
                If Mid(GPOptions, i + 22, 4) = "<No>" Then
                    FrmProperties.CheckMainTabR.Checked = False
                Else
                    FrmProperties.CheckMainTabR.Checked = True
                End If
            End If
            ' color
            If Mid(GPOptions, i, 33) = "<Maintab.BackGroundColor><Color [" Then mis = i + 33 : i = i + 33
            If mis <> 0 Then If Mid(GPOptions, i, 1) = "]" Then ColorCode = Mid(GPOptions, mis, i - mis) : Exit For
        Next
        mis = 0
        Ao = ""
        Ro = ""
        Go = ""
        Bo = ""
        For i = 1 To Len(ColorCode)
            If Mid(ColorCode, i, 2) = "A=" Then mis = i + 2
            If Mid(ColorCode, i, 2) = "R=" Then mis = i + 2
            If Mid(ColorCode, i, 2) = "G=" Then mis = i + 2
            If Mid(ColorCode, i, 2) = "B=" Then mis = i + 2
            If mis <> 0 Then
                If Mid(ColorCode, i, 1) = "," Or i = Len(ColorCode) Then
                    If Ao = "" Then
                        Ao = Mid(ColorCode, mis, i - mis)
                        mis = 0
                    Else
                        If Ro = "" Then
                            Ro = Mid(ColorCode, mis, i - mis)
                            mis = 0
                        Else
                            If Go = "" Then
                                Go = Mid(ColorCode, mis, i - mis)
                                mis = 0
                            Else
                                Bo = Mid(ColorCode, mis, i - mis + 1)
                                Exit For
                            End If
                        End If
                    End If
                End If
            End If
        Next
        If Ao = "" Then
            FrmProperties.ButtonColorMainTab.BackColor = Color.FromName(ColorCode)
        Else
            FrmProperties.ButtonColorMainTab.BackColor = Color.FromArgb(Ao, Ro, Go, Bo)
        End If
        '
    End Sub

    Sub GetView()
        FileGetObject(3, GPView, 1)
        For i = 1 To Len(GPView)
            If Mid(GPView, i, 8) = "<Search>" Then
                If Mid(GPView, i + 8, 6) = "<True>" Then ToolStripVisibleSearch.Checked = True Else ToolStripVisibleSearch.Checked = False
            End If
            If Mid(GPView, i, 4) = "<LT>" Then
                If Mid(GPView, i + 4, 5) = "<True" Then ToolStripVisibleLt.Checked = True Else ToolStripVisibleLt.Checked = False
            End If
            If Mid(GPView, i, 1) = "," Then
                If Mid(GPView, i + 2, 5) = "True>" Then ToolStripSearch.Checked = True Else ToolStripSearch.Checked = False
                Exit For
            End If
        Next
        '
        ToolStripSearch.Visible = ToolStripVisibleSearch.Checked
        '
        ToolStrip28.Visible = ToolStripVisibleLt.Checked
        If ToolStrip28.Visible = False Then
            MainTab.Width = Width - 16
            MainTab.Left = 0
        Else
            MainTab.Width = Width - 15 - ToolStrip28.Width
            MainTab.Left = ToolStrip28.Width - 1
        End If
        '        
        If ToolStripSearch.Checked = True And ToolStripSearch.Visible = True Then
            SearchTxtNam.Visible = True
            SearchTxtNum.Visible = True
            SearchComType.Visible = True
            SearchTxtCun0.Visible = True
            SearchTxtCun1.Visible = True
            SearchTxtPla.Visible = True
            SearchTxtNotes.Visible = True
            ToolStripLabel1.Visible = True
            ToolStripLabel2.Visible = True
            ToolStripLabel3.Visible = True
            ToolStripLabel5.Visible = True
            ToolStripLabel6.Visible = True
            ToolStripLabel7.Visible = True
            ToolStripLabel8.Visible = True
        Else
            SearchTxtNam.Text = ""
            SearchTxtNum.Text = ""
            SearchComType.Text = "بلا"
            SearchTxtCun0.Text = ""
            SearchTxtCun1.Text = ""
            SearchTxtPla.Text = ""
            SearchTxtNotes.Text = ""
            SearchTxtNam.Visible = False
            SearchTxtNum.Visible = False
            SearchComType.Visible = False
            SearchTxtCun0.Visible = False
            SearchTxtCun1.Visible = False
            SearchTxtPla.Visible = False
            SearchTxtNotes.Visible = False
            ToolStripLabel1.Visible = False
            ToolStripLabel2.Visible = False
            ToolStripLabel3.Visible = False
            ToolStripLabel5.Visible = False
            ToolStripLabel6.Visible = False
            ToolStripLabel7.Visible = False
            ToolStripLabel8.Visible = False
        End If
    End Sub

    Sub GetMove()
        lMove = 1
        miMove = 0
        For i = 1 To Len(GPMove)
            If Mid(GPMove, i, 13) = "<WindowState>" Then
                If Mid(GPMove, i + 13, 3) = "<0>" Then
                    WindowState = FormWindowState.Normal
                Else
                    WindowState = FormWindowState.Maximized
                End If
            End If
            If Mid(GPMove, i, 6) = "<Move>" Then miMove = i + 7 : i = i + 7
            If miMove <> 0 Then
                If Mid(GPMove, i, 1) = "," Or Mid(GPMove, i, 1) = ">" Then
                    If lMove = 1 Then Left = Mid(GPMove, miMove, i - miMove)
                    If lMove = 2 Then Top = Mid(GPMove, miMove, i - miMove)
                    If lMove = 3 Then Width = Mid(GPMove, miMove, i - miMove)
                    If lMove = 4 Then Height = Mid(GPMove, miMove, i - miMove) : Exit For
                    lMove = lMove + 1
                    miMove = i + 2
                End If
            End If
        Next
    End Sub

End Class
