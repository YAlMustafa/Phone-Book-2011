<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEdit))
        Me.GroupBoxData = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckPla = New System.Windows.Forms.CheckBox()
        Me.CheckCun1 = New System.Windows.Forms.CheckBox()
        Me.CheckCP = New System.Windows.Forms.CheckBox()
        Me.CheckCun0 = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPla = New System.Windows.Forms.TextBox()
        Me.txtCun1 = New System.Windows.Forms.TextBox()
        Me.txtCun0 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTNum = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.comAdj = New System.Windows.Forms.ComboBox()
        Me.comType = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.txtNam = New System.Windows.Forms.TextBox()
        Me.State = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.StateAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.StateCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.StateDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.StateMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.StateMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.StatePositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.StateMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.StateMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.StateButtonClose = New System.Windows.Forms.ToolStripButton()
        Me.GroupBoxData.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.State, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.State.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxData
        '
        Me.GroupBoxData.Controls.Add(Me.GroupBox2)
        Me.GroupBoxData.Controls.Add(Me.GroupBox1)
        Me.GroupBoxData.Controls.Add(Me.Label7)
        Me.GroupBoxData.Controls.Add(Me.Label1)
        Me.GroupBoxData.Controls.Add(Me.txtNotes)
        Me.GroupBoxData.Controls.Add(Me.txtNam)
        Me.GroupBoxData.Enabled = False
        Me.GroupBoxData.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxData.Name = "GroupBoxData"
        Me.GroupBoxData.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBoxData.Size = New System.Drawing.Size(398, 318)
        Me.GroupBoxData.TabIndex = 8
        Me.GroupBoxData.TabStop = False
        Me.GroupBoxData.Text = "حقل البيانات"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckPla)
        Me.GroupBox2.Controls.Add(Me.CheckCun1)
        Me.GroupBox2.Controls.Add(Me.CheckCP)
        Me.GroupBox2.Controls.Add(Me.CheckCun0)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtPla)
        Me.GroupBox2.Controls.Add(Me.txtCun1)
        Me.GroupBox2.Controls.Add(Me.txtCun0)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 149)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(381, 117)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "العنوان :       "
        '
        'CheckPla
        '
        Me.CheckPla.AutoSize = True
        Me.CheckPla.Checked = True
        Me.CheckPla.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckPla.Location = New System.Drawing.Point(5, 91)
        Me.CheckPla.Name = "CheckPla"
        Me.CheckPla.Size = New System.Drawing.Size(15, 14)
        Me.CheckPla.TabIndex = 13
        Me.CheckPla.Tag = "1"
        Me.CheckPla.UseVisualStyleBackColor = True
        '
        'CheckCun1
        '
        Me.CheckCun1.AutoSize = True
        Me.CheckCun1.Checked = True
        Me.CheckCun1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckCun1.Location = New System.Drawing.Point(5, 42)
        Me.CheckCun1.Name = "CheckCun1"
        Me.CheckCun1.Size = New System.Drawing.Size(15, 14)
        Me.CheckCun1.TabIndex = 13
        Me.CheckCun1.Tag = "1"
        Me.CheckCun1.UseVisualStyleBackColor = True
        '
        'CheckCP
        '
        Me.CheckCP.AutoSize = True
        Me.CheckCP.Checked = True
        Me.CheckCP.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.CheckCP.Location = New System.Drawing.Point(315, 1)
        Me.CheckCP.Name = "CheckCP"
        Me.CheckCP.Size = New System.Drawing.Size(15, 14)
        Me.CheckCP.TabIndex = 13
        Me.CheckCP.UseVisualStyleBackColor = True
        '
        'CheckCun0
        '
        Me.CheckCun0.AutoSize = True
        Me.CheckCun0.Location = New System.Drawing.Point(196, 42)
        Me.CheckCun0.Name = "CheckCun0"
        Me.CheckCun0.Size = New System.Drawing.Size(15, 14)
        Me.CheckCun0.TabIndex = 13
        Me.CheckCun0.Tag = "0"
        Me.CheckCun0.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(332, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "العنوان :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(141, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "المدينة :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(344, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "البلد :"
        '
        'txtPla
        '
        Me.txtPla.Location = New System.Drawing.Point(26, 88)
        Me.txtPla.Name = "txtPla"
        Me.txtPla.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPla.Size = New System.Drawing.Size(348, 20)
        Me.txtPla.TabIndex = 7
        '
        'txtCun1
        '
        Me.txtCun1.Location = New System.Drawing.Point(26, 39)
        Me.txtCun1.Name = "txtCun1"
        Me.txtCun1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCun1.Size = New System.Drawing.Size(158, 20)
        Me.txtCun1.TabIndex = 6
        '
        'txtCun0
        '
        Me.txtCun0.Location = New System.Drawing.Point(217, 39)
        Me.txtCun0.Name = "txtCun0"
        Me.txtCun0.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCun0.Size = New System.Drawing.Size(158, 20)
        Me.txtCun0.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtTNum)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.comAdj)
        Me.GroupBox1.Controls.Add(Me.comType)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(381, 68)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "الهاتف"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(315, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "رقم الهاتف :"
        '
        'txtTNum
        '
        Me.txtTNum.Location = New System.Drawing.Point(218, 41)
        Me.txtTNum.Name = "txtTNum"
        Me.txtTNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTNum.Size = New System.Drawing.Size(156, 20)
        Me.txtTNum.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(41, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "وصف الهاتف :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(174, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "الهاتف :"
        '
        'comAdj
        '
        Me.comAdj.Enabled = False
        Me.comAdj.FormattingEnabled = True
        Me.comAdj.Items.AddRange(New Object() {"منزل", "مكتب", "مشفى", "مقهى", "مطعم", "مدرسة", "جامعة", "محل", "دكان", "شركة", "مول", "معمل", "وزارة", "مديرية", "مطار"})
        Me.comAdj.Location = New System.Drawing.Point(7, 41)
        Me.comAdj.Name = "comAdj"
        Me.comAdj.Size = New System.Drawing.Size(100, 21)
        Me.comAdj.TabIndex = 3
        Me.comAdj.Tag = "بلا"
        Me.comAdj.Text = "بلا"
        '
        'comType
        '
        Me.comType.FormattingEnabled = True
        Me.comType.Items.AddRange(New Object() {"بلا", "هاتف/أرضي", "هاتف/موبايل", "هاتف/ثريا"})
        Me.comType.Location = New System.Drawing.Point(113, 41)
        Me.comType.Name = "comType"
        Me.comType.Size = New System.Drawing.Size(100, 21)
        Me.comType.TabIndex = 2
        Me.comType.Tag = "بلا"
        Me.comType.Text = "بلا"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(328, 269)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "ملاحظات :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(340, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "الاسم :"
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(12, 285)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNotes.Size = New System.Drawing.Size(368, 20)
        Me.txtNotes.TabIndex = 8
        '
        'txtNam
        '
        Me.txtNam.Location = New System.Drawing.Point(12, 41)
        Me.txtNam.Name = "txtNam"
        Me.txtNam.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNam.Size = New System.Drawing.Size(368, 20)
        Me.txtNam.TabIndex = 0
        '
        'State
        '
        Me.State.AddNewItem = Me.StateAddNewItem
        Me.State.CountItem = Me.StateCountItem
        Me.State.DeleteItem = Me.StateDeleteItem
        Me.State.Dock = System.Windows.Forms.DockStyle.None
        Me.State.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.State.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StateMoveFirstItem, Me.StateMovePreviousItem, Me.BindingNavigatorSeparator, Me.StatePositionItem, Me.StateCountItem, Me.BindingNavigatorSeparator1, Me.StateMoveNextItem, Me.StateMoveLastItem, Me.BindingNavigatorSeparator2, Me.StateAddNewItem, Me.StateDeleteItem, Me.ToolStripSeparator1, Me.StateButtonClose})
        Me.State.Location = New System.Drawing.Point(12, 333)
        Me.State.MoveFirstItem = Me.StateMoveFirstItem
        Me.State.MoveLastItem = Me.StateMoveLastItem
        Me.State.MoveNextItem = Me.StateMoveNextItem
        Me.State.MovePreviousItem = Me.StateMovePreviousItem
        Me.State.Name = "State"
        Me.State.PositionItem = Me.StatePositionItem
        Me.State.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.State.Size = New System.Drawing.Size(291, 25)
        Me.State.TabIndex = 15
        Me.State.Text = "BindingNavigator1"
        '
        'StateAddNewItem
        '
        Me.StateAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StateAddNewItem.Image = CType(resources.GetObject("StateAddNewItem.Image"), System.Drawing.Image)
        Me.StateAddNewItem.Name = "StateAddNewItem"
        Me.StateAddNewItem.RightToLeftAutoMirrorImage = True
        Me.StateAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.StateAddNewItem.Text = "Add new"
        '
        'StateCountItem
        '
        Me.StateCountItem.Name = "StateCountItem"
        Me.StateCountItem.Size = New System.Drawing.Size(35, 22)
        Me.StateCountItem.Tag = "0"
        Me.StateCountItem.Text = "of {0}"
        Me.StateCountItem.ToolTipText = "Total number of items"
        '
        'StateDeleteItem
        '
        Me.StateDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StateDeleteItem.Image = CType(resources.GetObject("StateDeleteItem.Image"), System.Drawing.Image)
        Me.StateDeleteItem.Name = "StateDeleteItem"
        Me.StateDeleteItem.RightToLeftAutoMirrorImage = True
        Me.StateDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.StateDeleteItem.Text = "Delete"
        '
        'StateMoveFirstItem
        '
        Me.StateMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StateMoveFirstItem.Image = CType(resources.GetObject("StateMoveFirstItem.Image"), System.Drawing.Image)
        Me.StateMoveFirstItem.Name = "StateMoveFirstItem"
        Me.StateMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.StateMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.StateMoveFirstItem.Text = "Move first"
        '
        'StateMovePreviousItem
        '
        Me.StateMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StateMovePreviousItem.Image = CType(resources.GetObject("StateMovePreviousItem.Image"), System.Drawing.Image)
        Me.StateMovePreviousItem.Name = "StateMovePreviousItem"
        Me.StateMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.StateMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.StateMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'StatePositionItem
        '
        Me.StatePositionItem.AccessibleName = "Position"
        Me.StatePositionItem.AutoSize = False
        Me.StatePositionItem.Name = "StatePositionItem"
        Me.StatePositionItem.Size = New System.Drawing.Size(50, 23)
        Me.StatePositionItem.Text = "0"
        Me.StatePositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'StateMoveNextItem
        '
        Me.StateMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StateMoveNextItem.Image = CType(resources.GetObject("StateMoveNextItem.Image"), System.Drawing.Image)
        Me.StateMoveNextItem.Name = "StateMoveNextItem"
        Me.StateMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.StateMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.StateMoveNextItem.Text = "Move next"
        '
        'StateMoveLastItem
        '
        Me.StateMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StateMoveLastItem.Image = CType(resources.GetObject("StateMoveLastItem.Image"), System.Drawing.Image)
        Me.StateMoveLastItem.Name = "StateMoveLastItem"
        Me.StateMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.StateMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.StateMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'StateButtonClose
        '
        Me.StateButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.StateButtonClose.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.StateButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.StateButtonClose.Name = "StateButtonClose"
        Me.StateButtonClose.Size = New System.Drawing.Size(39, 22)
        Me.StateButtonClose.Text = "إغلاق"
        '
        'FrmEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 356)
        Me.Controls.Add(Me.State)
        Me.Controls.Add(Me.GroupBoxData)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEdit"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تحرير"
        Me.GroupBoxData.ResumeLayout(False)
        Me.GroupBoxData.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.State, System.ComponentModel.ISupportInitialize).EndInit()
        Me.State.ResumeLayout(False)
        Me.State.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBoxData As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPla As System.Windows.Forms.TextBox
    Friend WithEvents txtCun1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCun0 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTNum As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents comAdj As System.Windows.Forms.ComboBox
    Friend WithEvents comType As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents txtNam As System.Windows.Forms.TextBox
    Friend WithEvents State As System.Windows.Forms.BindingNavigator
    Friend WithEvents StateAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents StateCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents StateDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents StateMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents StateMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StatePositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StateMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents StateMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StateButtonClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents CheckCun0 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPla As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCun1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCP As System.Windows.Forms.CheckBox

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
