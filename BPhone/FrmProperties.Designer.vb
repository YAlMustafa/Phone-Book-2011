<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProperties
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
        Me.CheckMainTabR = New System.Windows.Forms.CheckBox()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ButtonReset = New System.Windows.Forms.Button()
        Me.ButtonColorMainTab = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ColorMainTab = New System.Windows.Forms.ColorDialog()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckMainTabR
        '
        Me.CheckMainTabR.AutoSize = True
        Me.CheckMainTabR.Checked = True
        Me.CheckMainTabR.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckMainTabR.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CheckMainTabR.Location = New System.Drawing.Point(49, 19)
        Me.CheckMainTabR.Name = "CheckMainTabR"
        Me.CheckMainTabR.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckMainTabR.Size = New System.Drawing.Size(131, 17)
        Me.CheckMainTabR.TabIndex = 0
        Me.CheckMainTabR.Text = "جهة الجدول إلى اليمين"
        Me.CheckMainTabR.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(131, 98)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 1
        Me.ButtonOK.Text = "موافق"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(50, 98)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 1
        Me.ButtonCancel.Text = "إلغاء الأمر"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonReset)
        Me.GroupBox2.Controls.Add(Me.ButtonColorMainTab)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.CheckMainTabR)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(194, 80)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "الجدول"
        '
        'ButtonReset
        '
        Me.ButtonReset.Location = New System.Drawing.Point(6, 44)
        Me.ButtonReset.Name = "ButtonReset"
        Me.ButtonReset.Size = New System.Drawing.Size(75, 23)
        Me.ButtonReset.TabIndex = 4
        Me.ButtonReset.Text = "إعادة البيانات"
        Me.ButtonReset.UseVisualStyleBackColor = True
        '
        'ButtonColorMainTab
        '
        Me.ButtonColorMainTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonColorMainTab.Location = New System.Drawing.Point(87, 45)
        Me.ButtonColorMainTab.Name = "ButtonColorMainTab"
        Me.ButtonColorMainTab.Size = New System.Drawing.Size(22, 22)
        Me.ButtonColorMainTab.TabIndex = 5
        Me.ButtonColorMainTab.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(115, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "لون الخلفية :"
        '
        'ColorMainTab
        '
        Me.ColorMainTab.Color = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'FrmProperties
        '
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(219, 132)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.ButtonCancel)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProperties"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "خصائص"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents CheckMainTabR As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonColorMainTab As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColorMainTab As System.Windows.Forms.ColorDialog
    Friend WithEvents ButtonReset As System.Windows.Forms.Button

End Class
