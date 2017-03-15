Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class frmBuildDBConn

  Friend ConnStr As String

  Friend Sub LoadData(ByVal s As String)
    Dim bldr As SqlConnectionStringBuilder
    Try
      bldr = New SqlConnectionStringBuilder(s)
      TextBox1.Text = bldr.DataSource
      TextBox2.Text = bldr.InitialCatalog
      TextBox3.Text = bldr.UserID
      TextBox4.Text = bldr.Password
    Catch
    End Try
  End Sub

  Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    If TextBox1.Text.Trim.Length = 0 OrElse _
        TextBox2.Text.Trim.Length = 0 OrElse _
        TextBox3.Text.Trim.Length = 0 OrElse _
        TextBox4.Text.Trim.Length = 0 Then
      MessageBox.Show("Please enter a value in all 4 fields", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End If

    Dim bldr As New SqlConnectionStringBuilder
    bldr.DataSource = TextBox1.Text.Trim
    bldr.InitialCatalog = TextBox2.Text.Trim
    bldr.UserID = TextBox3.Text.Trim
    bldr.Password = TextBox4.Text.Trim
    bldr.ApplicationName = "Simple DNS Plus"
    ConnStr = bldr.ConnectionString
    Me.DialogResult = Windows.Forms.DialogResult.OK
  End Sub

End Class