Imports System.Windows.Forms

Public Class frmBuildSelect

  Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    If TextBox1.Text.Trim.Length = 0 OrElse _
        TextBox2.Text.Trim.Length = 0 OrElse _
        TextBox3.Text.Trim.Length = 0 OrElse _
        (radTTL1.Checked And TextBox4.Text.Trim.Length = 0) Then
      MessageBox.Show("Please enter a value in all fields", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End If
    Me.DialogResult = Windows.Forms.DialogResult.OK
  End Sub

  Private Sub radTTL1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTTL1.CheckedChanged, radTTL2.CheckedChanged
    TextBox4.Enabled = radTTL1.Checked
    CtlTTL1.Enabled = radTTL2.Checked
  End Sub

  Friend Sub LoadSQL(ByVal s As String, ByVal reverse As Boolean)
    Dim col1, col2 As String
    Dim ttlStatic As Boolean, ttlCol As String = "", ttlVal As Integer
    Dim table As String

    If s.Length < 13 OrElse s.Substring(0, 13) <> "SELECT TOP 1 " Then Exit Sub
    s = s.Substring(13)
    Dim i As Integer = s.IndexOf(","c)
    If i < 0 Then Exit Sub
    col1 = s.Substring(0, i).Trim
    If col1.Length = 0 OrElse col1.IndexOf(" "c) > 0 Then Exit Sub
    s = s.Substring(i + 1).Trim
    If s.Length < 4 Then Exit Sub
    If s.Substring(0, 4) = "ttl=" Then
      ttlStatic = True
      s = s.Substring(4)
      i = s.IndexOf(" "c)
      If i < 1 Then Exit Sub
      If Not Integer.TryParse(s.Substring(0, i), ttlVal) Then Exit Sub
      s = s.Substring(i + 1).Trim
    Else
      ttlStatic = False
      i = s.IndexOf(" "c)
      If i < 0 Then Exit Sub
      ttlCol = s.Substring(0, i)
      s = s.Substring(i + 1).Trim
    End If
    If s.Length < 5 OrElse s.Substring(0, 5) <> "FROM " Then Exit Sub
    s = s.Substring(5).Trim
    i = s.IndexOf(" "c)
    If i < 0 Then Exit Sub
    table = s.Substring(0, i)
    s = s.Substring(i + 1).Trim
    If s.Length < 6 OrElse s.Substring(0, 6) <> "WHERE " Then Exit Sub
    s = s.Substring(6).Trim
    i = s.IndexOf("="c)
    If i < 0 Then Exit Sub
    col2 = s.Substring(0, i)
    If col2.Length = 0 OrElse col2.IndexOf(" "c) > 0 Then Exit Sub
    s = s.Substring(i + 1).Trim

    If reverse Then
      If s <> "@ipaddress" Then Exit Sub
      TextBox2.Text = col1
      TextBox3.Text = col2
    Else
      If s <> "@hostname" Then Exit Sub
      TextBox2.Text = col2
      TextBox3.Text = col1
    End If
    TextBox1.Text = table
    If ttlStatic Then
      radTTL2.Checked = True
      CtlTTL1.Value = ttlVal
    Else
      radTTL1.Checked = True
      TextBox4.Text = ttlCol
    End If
  End Sub

End Class