<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsCtrl
  Inherits JHSoftware.SimpleDNS.Plugin.OptionsUI ' System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim Label1 As System.Windows.Forms.Label
    Dim Label2 As System.Windows.Forms.Label
    Dim Label4 As System.Windows.Forms.Label
    Dim Label6 As System.Windows.Forms.Label
    Dim Label7 As System.Windows.Forms.Label
    Dim Label8 As System.Windows.Forms.Label
    Dim Label9 As System.Windows.Forms.Label
    Dim Label10 As System.Windows.Forms.Label
    Me.txtConn = New System.Windows.Forms.TextBox
    Me.txtSel1 = New System.Windows.Forms.TextBox
    Me.txtSel2 = New System.Windows.Forms.TextBox
    Me.txtSel3 = New System.Windows.Forms.TextBox
    Me.txtSel4 = New System.Windows.Forms.TextBox
    Me.btnTestConn = New System.Windows.Forms.Button
    Me.btnTestSel1 = New System.Windows.Forms.Button
    Me.btnTestSel2 = New System.Windows.Forms.Button
    Me.btnTestSel3 = New System.Windows.Forms.Button
    Me.btnTestSel4 = New System.Windows.Forms.Button
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
    Me.btnBuildConn = New System.Windows.Forms.Button
    Me.btnBuildSel1 = New System.Windows.Forms.Button
    Me.btnBuildSel2 = New System.Windows.Forms.Button
    Me.btnBuildSel3 = New System.Windows.Forms.Button
    Me.btnBuildSel4 = New System.Windows.Forms.Button
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Label1 = New System.Windows.Forms.Label
    Label2 = New System.Windows.Forms.Label
    Label4 = New System.Windows.Forms.Label
    Label6 = New System.Windows.Forms.Label
    Label7 = New System.Windows.Forms.Label
    Label8 = New System.Windows.Forms.Label
    Label9 = New System.Windows.Forms.Label
    Label10 = New System.Windows.Forms.Label
    Me.TableLayoutPanel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Label1.AutoSize = True
    Me.TableLayoutPanel1.SetColumnSpan(Label1, 2)
    Label1.Location = New System.Drawing.Point(3, 0)
    Label1.Name = "Label1"
    Label1.Size = New System.Drawing.Size(140, 13)
    Label1.TabIndex = 0
    Label1.Text = "Database connection string:"
    '
    'Label2
    '
    Label2.AutoSize = True
    Me.TableLayoutPanel1.SetColumnSpan(Label2, 4)
    Label2.Location = New System.Drawing.Point(3, 57)
    Label2.Margin = New System.Windows.Forms.Padding(3, 15, 3, 0)
    Label2.Name = "Label2"
    Label2.Size = New System.Drawing.Size(383, 26)
    Label2.TabIndex = 4
    Label2.Text = "SELECT statements to fetch IP address for a host name (forward lookup):" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Must inc" & _
        "lude a @hostname parameter, and must return 2 columns; IP and TTL *"
    '
    'Label4
    '
    Label4.AutoSize = True
    Me.TableLayoutPanel1.SetColumnSpan(Label4, 4)
    Label4.Location = New System.Drawing.Point(3, 156)
    Label4.Margin = New System.Windows.Forms.Padding(3, 15, 3, 0)
    Label4.Name = "Label4"
    Label4.Size = New System.Drawing.Size(420, 26)
    Label4.TabIndex = 13
    Label4.Text = "SELECT statements to fetch host name for an IP address (reverse lookup):" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Must in" & _
        "clude a @ipaddress parameter, and must return 2 columns; Hostname and TTL *"
    '
    'Label6
    '
    Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Label6.AutoSize = True
    Me.TableLayoutPanel1.SetColumnSpan(Label6, 4)
    Label6.Location = New System.Drawing.Point(3, 268)
    Label6.Name = "Label6"
    Label6.Size = New System.Drawing.Size(304, 26)
    Label6.TabIndex = 22
    Label6.Text = "* Returned IP and Hostname columns must be character types." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   Returned TTL colu" & _
        "mn must be integer type (seconds). "
    '
    'Label7
    '
    Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
    Label7.AutoSize = True
    Label7.Location = New System.Drawing.Point(3, 91)
    Label7.Name = "Label7"
    Label7.Size = New System.Drawing.Size(32, 13)
    Label7.TabIndex = 5
    Label7.Text = "IPv4:"
    '
    'Label8
    '
    Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
    Label8.AutoSize = True
    Label8.Location = New System.Drawing.Point(3, 120)
    Label8.Name = "Label8"
    Label8.Size = New System.Drawing.Size(32, 13)
    Label8.TabIndex = 9
    Label8.Text = "IPv6:"
    '
    'Label9
    '
    Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
    Label9.AutoSize = True
    Label9.Location = New System.Drawing.Point(3, 190)
    Label9.Name = "Label9"
    Label9.Size = New System.Drawing.Size(32, 13)
    Label9.TabIndex = 14
    Label9.Text = "IPv4:"
    '
    'Label10
    '
    Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
    Label10.AutoSize = True
    Label10.Location = New System.Drawing.Point(3, 219)
    Label10.Name = "Label10"
    Label10.Size = New System.Drawing.Size(32, 13)
    Label10.TabIndex = 18
    Label10.Text = "IPv6:"
    '
    'txtConn
    '
    Me.txtConn.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TableLayoutPanel1.SetColumnSpan(Me.txtConn, 2)
    Me.txtConn.Location = New System.Drawing.Point(3, 17)
    Me.txtConn.Name = "txtConn"
    Me.txtConn.Size = New System.Drawing.Size(367, 20)
    Me.txtConn.TabIndex = 1
    '
    'txtSel1
    '
    Me.txtSel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtSel1.Location = New System.Drawing.Point(41, 87)
    Me.txtSel1.Name = "txtSel1"
    Me.txtSel1.Size = New System.Drawing.Size(329, 20)
    Me.txtSel1.TabIndex = 6
    '
    'txtSel2
    '
    Me.txtSel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtSel2.Location = New System.Drawing.Point(41, 116)
    Me.txtSel2.Name = "txtSel2"
    Me.txtSel2.Size = New System.Drawing.Size(329, 20)
    Me.txtSel2.TabIndex = 10
    '
    'txtSel3
    '
    Me.txtSel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtSel3.Location = New System.Drawing.Point(41, 186)
    Me.txtSel3.Name = "txtSel3"
    Me.txtSel3.Size = New System.Drawing.Size(329, 20)
    Me.txtSel3.TabIndex = 15
    '
    'txtSel4
    '
    Me.txtSel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtSel4.Location = New System.Drawing.Point(41, 215)
    Me.txtSel4.Name = "txtSel4"
    Me.txtSel4.Size = New System.Drawing.Size(329, 20)
    Me.txtSel4.TabIndex = 19
    '
    'btnTestConn
    '
    Me.btnTestConn.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.btnTestConn.Location = New System.Drawing.Point(405, 16)
    Me.btnTestConn.Name = "btnTestConn"
    Me.btnTestConn.Size = New System.Drawing.Size(55, 23)
    Me.btnTestConn.TabIndex = 3
    Me.btnTestConn.Text = "Test"
    Me.btnTestConn.UseVisualStyleBackColor = True
    '
    'btnTestSel1
    '
    Me.btnTestSel1.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.btnTestSel1.Location = New System.Drawing.Point(405, 86)
    Me.btnTestSel1.Name = "btnTestSel1"
    Me.btnTestSel1.Size = New System.Drawing.Size(55, 23)
    Me.btnTestSel1.TabIndex = 8
    Me.btnTestSel1.Text = "Test..."
    Me.btnTestSel1.UseVisualStyleBackColor = True
    '
    'btnTestSel2
    '
    Me.btnTestSel2.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.btnTestSel2.Location = New System.Drawing.Point(405, 115)
    Me.btnTestSel2.Name = "btnTestSel2"
    Me.btnTestSel2.Size = New System.Drawing.Size(55, 23)
    Me.btnTestSel2.TabIndex = 12
    Me.btnTestSel2.Text = "Test..."
    Me.btnTestSel2.UseVisualStyleBackColor = True
    '
    'btnTestSel3
    '
    Me.btnTestSel3.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.btnTestSel3.Location = New System.Drawing.Point(405, 185)
    Me.btnTestSel3.Name = "btnTestSel3"
    Me.btnTestSel3.Size = New System.Drawing.Size(55, 23)
    Me.btnTestSel3.TabIndex = 17
    Me.btnTestSel3.Text = "Test..."
    Me.btnTestSel3.UseVisualStyleBackColor = True
    '
    'btnTestSel4
    '
    Me.btnTestSel4.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.btnTestSel4.Location = New System.Drawing.Point(405, 214)
    Me.btnTestSel4.Name = "btnTestSel4"
    Me.btnTestSel4.Size = New System.Drawing.Size(55, 23)
    Me.btnTestSel4.TabIndex = 21
    Me.btnTestSel4.Text = "Test..."
    Me.btnTestSel4.UseVisualStyleBackColor = True
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.ColumnCount = 4
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
    Me.TableLayoutPanel1.Controls.Add(Me.btnTestSel4, 3, 7)
    Me.TableLayoutPanel1.Controls.Add(Me.txtSel4, 1, 7)
    Me.TableLayoutPanel1.Controls.Add(Me.btnTestSel3, 3, 6)
    Me.TableLayoutPanel1.Controls.Add(Me.btnTestConn, 3, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.btnTestSel2, 3, 4)
    Me.TableLayoutPanel1.Controls.Add(Me.txtSel3, 1, 6)
    Me.TableLayoutPanel1.Controls.Add(Me.btnTestSel1, 3, 3)
    Me.TableLayoutPanel1.Controls.Add(Me.txtSel1, 1, 3)
    Me.TableLayoutPanel1.Controls.Add(Me.txtSel2, 1, 4)
    Me.TableLayoutPanel1.Controls.Add(Label7, 0, 3)
    Me.TableLayoutPanel1.Controls.Add(Label8, 0, 4)
    Me.TableLayoutPanel1.Controls.Add(Label9, 0, 6)
    Me.TableLayoutPanel1.Controls.Add(Label10, 0, 7)
    Me.TableLayoutPanel1.Controls.Add(Label2, 0, 2)
    Me.TableLayoutPanel1.Controls.Add(Label4, 0, 5)
    Me.TableLayoutPanel1.Controls.Add(Me.txtConn, 0, 1)
    Me.TableLayoutPanel1.Controls.Add(Label1, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Label6, 0, 8)
    Me.TableLayoutPanel1.Controls.Add(Me.btnBuildConn, 2, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.btnBuildSel1, 2, 3)
    Me.TableLayoutPanel1.Controls.Add(Me.btnBuildSel2, 2, 4)
    Me.TableLayoutPanel1.Controls.Add(Me.btnBuildSel3, 2, 6)
    Me.TableLayoutPanel1.Controls.Add(Me.btnBuildSel4, 2, 7)
    Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 9
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(463, 294)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'btnBuildConn
    '
    Me.btnBuildConn.Location = New System.Drawing.Point(376, 16)
    Me.btnBuildConn.Name = "btnBuildConn"
    Me.btnBuildConn.Size = New System.Drawing.Size(23, 23)
    Me.btnBuildConn.TabIndex = 2
    Me.btnBuildConn.Text = ".."
    Me.ToolTip1.SetToolTip(Me.btnBuildConn, "Build")
    Me.btnBuildConn.UseVisualStyleBackColor = True
    '
    'btnBuildSel1
    '
    Me.btnBuildSel1.Location = New System.Drawing.Point(376, 86)
    Me.btnBuildSel1.Name = "btnBuildSel1"
    Me.btnBuildSel1.Size = New System.Drawing.Size(23, 23)
    Me.btnBuildSel1.TabIndex = 7
    Me.btnBuildSel1.Text = ".."
    Me.ToolTip1.SetToolTip(Me.btnBuildSel1, "Build")
    Me.btnBuildSel1.UseVisualStyleBackColor = True
    '
    'btnBuildSel2
    '
    Me.btnBuildSel2.Location = New System.Drawing.Point(376, 115)
    Me.btnBuildSel2.Name = "btnBuildSel2"
    Me.btnBuildSel2.Size = New System.Drawing.Size(23, 23)
    Me.btnBuildSel2.TabIndex = 11
    Me.btnBuildSel2.Text = ".."
    Me.ToolTip1.SetToolTip(Me.btnBuildSel2, "Build")
    Me.btnBuildSel2.UseVisualStyleBackColor = True
    '
    'btnBuildSel3
    '
    Me.btnBuildSel3.Location = New System.Drawing.Point(376, 185)
    Me.btnBuildSel3.Name = "btnBuildSel3"
    Me.btnBuildSel3.Size = New System.Drawing.Size(23, 23)
    Me.btnBuildSel3.TabIndex = 16
    Me.btnBuildSel3.Text = ".."
    Me.ToolTip1.SetToolTip(Me.btnBuildSel3, "Build")
    Me.btnBuildSel3.UseVisualStyleBackColor = True
    '
    'btnBuildSel4
    '
    Me.btnBuildSel4.Location = New System.Drawing.Point(376, 214)
    Me.btnBuildSel4.Name = "btnBuildSel4"
    Me.btnBuildSel4.Size = New System.Drawing.Size(23, 23)
    Me.btnBuildSel4.TabIndex = 20
    Me.btnBuildSel4.Text = ".."
    Me.ToolTip1.SetToolTip(Me.btnBuildSel4, "Build")
    Me.btnBuildSel4.UseVisualStyleBackColor = True
    '
    'OptionsCtrl
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.Name = "OptionsCtrl"
    Me.Size = New System.Drawing.Size(463, 294)
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.TableLayoutPanel1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents txtConn As System.Windows.Forms.TextBox
  Friend WithEvents txtSel1 As System.Windows.Forms.TextBox
  Friend WithEvents txtSel2 As System.Windows.Forms.TextBox
  Friend WithEvents txtSel3 As System.Windows.Forms.TextBox
  Friend WithEvents txtSel4 As System.Windows.Forms.TextBox
  Friend WithEvents btnTestConn As System.Windows.Forms.Button
  Friend WithEvents btnTestSel1 As System.Windows.Forms.Button
  Friend WithEvents btnTestSel2 As System.Windows.Forms.Button
  Friend WithEvents btnTestSel3 As System.Windows.Forms.Button
  Friend WithEvents btnTestSel4 As System.Windows.Forms.Button
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents btnBuildConn As System.Windows.Forms.Button
  Friend WithEvents btnBuildSel1 As System.Windows.Forms.Button
  Friend WithEvents btnBuildSel2 As System.Windows.Forms.Button
  Friend WithEvents btnBuildSel3 As System.Windows.Forms.Button
  Friend WithEvents btnBuildSel4 As System.Windows.Forms.Button
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
