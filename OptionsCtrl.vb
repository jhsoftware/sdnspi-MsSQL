Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class OptionsCtrl

  Public Overrides Sub LoadData(ByVal config As String)
    If config Is Nothing Then Exit Sub 'new instance
    If config.Length = 0 Then Exit Sub
    Dim doc As New Xml.XmlDocument
    Dim root As Xml.XmlElement = doc.CreateElement("root")
    doc.AppendChild(root)
    root.InnerXml = config
    For Each node As Xml.XmlNode In root.ChildNodes
      If Not TypeOf node Is Xml.XmlElement Then Continue For
      Select Case DirectCast(node, Xml.XmlElement).Name
        Case "DBConnStr"
          txtConn.Text = node.InnerText
        Case "SelectFwd4"
          txtSel1.Text = node.InnerText
        Case "SelectFwd6"
          txtSel2.Text = node.InnerText
        Case "SelectRev4"
          txtSel3.Text = node.InnerText
        Case "SelectRev6"
          txtSel4.Text = node.InnerText
      End Select
    Next
  End Sub

  Public Overrides Function SaveData() As String
    Dim doc As New Xml.XmlDocument
    Dim root As Xml.XmlElement = doc.CreateElement("root")
    doc.AppendChild(root)
    Dim elem As Xml.XmlElement

    elem = doc.CreateElement("DBConnStr")
    elem.InnerText = txtConn.Text.Trim
    root.AppendChild(elem)

    If txtSel1.Text.Trim.Length > 0 Then
      elem = doc.CreateElement("SelectFwd4")
      elem.InnerText = txtSel1.Text.Trim
      root.AppendChild(elem)
    End If

    If txtSel2.Text.Trim.Length > 0 Then
      elem = doc.CreateElement("SelectFwd6")
      elem.InnerText = txtSel2.Text.Trim
      root.AppendChild(elem)
    End If

    If txtSel3.Text.Trim.Length > 0 Then
      elem = doc.CreateElement("SelectRev4")
      elem.InnerText = txtSel3.Text.Trim
      root.AppendChild(elem)
    End If

    If txtSel4.Text.Trim.Length > 0 Then
      elem = doc.CreateElement("SelectRev6")
      elem.InnerText = txtSel4.Text.Trim
      root.AppendChild(elem)
    End If

    Return root.InnerXml
  End Function

  Public Overrides Function ValidateData() As Boolean
    If txtConn.Text.Trim.Length = 0 Then
      MessageBox.Show("Database connection string is empty", "Plug-In settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End If
    If txtSel1.Text.Trim.Length = 0 AndAlso _
       txtSel2.Text.Trim.Length = 0 AndAlso _
       txtSel3.Text.Trim.Length = 0 AndAlso _
       txtSel4.Text.Trim.Length = 0 Then
      MessageBox.Show("At least one SELECT statement must be specified", "Plug-In settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End If
    Return True
  End Function

  Private Sub btnBuildConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuildConn.Click
    Dim frm As New frmBuildDBConn
    If txtConn.Text.Trim.Length > 0 Then frm.LoadData(txtConn.Text.Trim)
    If frm.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
    txtConn.Text = frm.ConnStr
  End Sub

  Private Sub btnBuildSel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuildSel1.Click, btnBuildSel2.Click
    Dim frm As New frmBuildSelect
    frm.LoadSQL(If(sender Is btnBuildSel1, txtSel1.Text, txtSel2.Text).Trim, False)
    If frm.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
    Dim sql = "SELECT TOP 1 " & frm.TextBox3.Text.Trim & ", " & _
                   If(frm.radTTL1.Checked, frm.TextBox4.Text.Trim, "ttl=" & frm.CtlTTL1.Value) & _
                   " FROM " & frm.TextBox1.Text & _
                   " WHERE " & frm.TextBox2.Text & "=@hostname"
    If sender Is btnBuildSel1 Then txtSel1.Text = sql Else txtSel2.Text = sql
  End Sub

  Private Sub btnBuildSel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuildSel3.Click, btnBuildSel4.Click
    Dim frm As New frmBuildSelect
    frm.LoadSQL(If(sender Is btnBuildSel3, txtSel3.Text, txtSel4.Text).Trim, True)
    If frm.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
    Dim sql = "SELECT TOP 1 " & frm.TextBox2.Text.Trim & ", " & _
                   If(frm.radTTL1.Checked, frm.TextBox4.Text.Trim, "ttl=" & frm.CtlTTL1.Value) & _
                   " FROM " & frm.TextBox1.Text & _
                   " WHERE " & frm.TextBox3.Text & "=@ipaddress"
    If sender Is btnBuildSel3 Then txtSel3.Text = sql Else txtSel4.Text = sql
  End Sub

  Private Sub btnTestConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestConn.Click
    Dim conn = OpenDBConn("Test database connection string")
    If conn Is Nothing Then Exit Sub
    conn.Close()
    MessageBox.Show("Connected succesfully!", "Test database connection string ", MessageBoxButtons.OK, MessageBoxIcon.Information)
  End Sub

  Function OpenDBConn(ByVal title As String) As SqlConnection
    If txtConn.Text.Trim.Length = 0 Then Return Nothing
    Try
      Dim conn As New SqlConnection(txtConn.Text)
      conn.Open()
      Return conn
    Catch ex As Exception
      MessageBox.Show("Could not connect to database!" & vbCrLf & vbCrLf & _
                      ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return Nothing
    End Try
  End Function

  Private Sub btnTestSel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestSel1.Click, btnTestSel2.Click, btnTestSel3.Click, btnTestSel4.Click
    If txtConn.Text.Trim.Length = 0 Then
      MessageBox.Show("Database connection string is empty", "Test SELECT statement", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End If
    Dim sql As String
    If sender Is btnTestSel1 Then
      sql = txtSel1.Text.Trim
    ElseIf sender Is btnTestSel2 Then
      sql = txtSel2.Text.Trim
    ElseIf sender Is btnTestSel3 Then
      sql = txtSel3.Text.Trim
    Else
      sql = txtSel4.Text.Trim
    End If
    If sql.Length = 0 Then
      MessageBox.Show("SELECT statement is empty", "Test SELECT statement", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End If
    Dim reverse As Boolean = (sender Is btnTestSel3 OrElse sender Is btnTestSel4)
    Dim IPv6 As Boolean = (sender Is btnTestSel2 OrElse sender Is btnTestSel4)
    If reverse Then
      If sql.IndexOf("@ipaddress") < 0 Then
        MessageBox.Show("SELECT statement does not contain @ipaddress parameter", "Test SELECT statement", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If
    Else
      If sql.IndexOf("@hostname") < 0 Then
        MessageBox.Show("SELECT statement does not contain @hostname parameter", "Test SELECT statement", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If
    End If

    Dim tst = InputBox("Enter " & If(reverse, "IP address", "host name") & " to test:", "Test SELECT statement").Trim.ToLower
    If tst.Length = 0 Then Exit Sub
    If reverse Then
      Dim ip As System.Net.IPAddress
      If Not System.Net.IPAddress.TryParse(tst, ip) OrElse _
         (ip.AddressFamily = Net.Sockets.AddressFamily.InterNetwork And IPv6) OrElse _
         (ip.AddressFamily = Net.Sockets.AddressFamily.InterNetworkV6 And Not IPv6) Then
        MessageBox.Show("Invalid IP address", "Test SELECT statement", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If
      tst = ip.ToString
    End If

    Dim conn = OpenDBConn("Test SELECT statement")
    If conn Is Nothing Then Exit Sub
    Dim cmd As SqlCommand
    Try
      cmd = New SqlCommand(sql, conn)
    Catch ex As Exception
      conn.Close()
      MessageBox.Show("Error instantiating SQL command" & vbCrLf & vbCrLf & _
                      ex.Message, "Test SELECT statement", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End Try

    Try
      If reverse Then
        cmd.Parameters.AddWithValue("@ipaddress", tst)
      Else
        cmd.Parameters.AddWithValue("@hostname", tst)
      End If
    Catch ex As Exception
      conn.Close()
      MessageBox.Show("Error adding " & If(reverse, "@ipaddress", "@hostname") & " parameter to SQL command" & vbCrLf & vbCrLf & _
                      ex.Message, "Test SELECT statement", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End Try

    Dim rdr As SqlDataReader
    Dim gotSome As Boolean
    Try
      rdr = cmd.ExecuteReader
      gotSome = rdr.Read
    Catch ex As Exception
      conn.Close()
      MessageBox.Show("Error executing SQL" & vbCrLf & vbCrLf & _
                      ex.Message, "Test SELECT statement", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End Try

    If Not gotSome Then
      rdr.Close()
      conn.Close()
      MessageBox.Show("SQL executed succesfully, but no data was returned", "Test SELECT statement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    If rdr.FieldCount <> 2 Then
      rdr.Close()
      conn.Close()
      MessageBox.Show("SELECT statement did not return 2 columns", "Test SELECT statement", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End If

    Dim col1 As String
    Try
      col1 = rdr.GetString(0)
    Catch ex As Exception
      rdr.Close()
      conn.Close()
      MessageBox.Show("First column returned was not a string value", "Test SELECT statement", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End Try

    Dim col2 As Integer
    Try
      col2 = rdr.GetInt32(1)
    Catch ex As Exception
      rdr.Close()
      conn.Close()
      MessageBox.Show("Second column returned was not an integer value", "Test SELECT statement", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End Try

    If Not reverse Then
      Dim ip As System.Net.IPAddress
      If Not System.Net.IPAddress.TryParse(col1, ip) OrElse _
        (ip.AddressFamily = Net.Sockets.AddressFamily.InterNetwork And IPv6) OrElse _
        (ip.AddressFamily = Net.Sockets.AddressFamily.InterNetworkV6 And Not IPv6) Then
        rdr.Close()
        conn.Close()
        MessageBox.Show("SELECT statement did not return a valid IP address", "Test SELECT statement", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If
    End If

    If rdr.Read Then
      rdr.Close()
      conn.Close()
      MessageBox.Show("SELECT statement returned more than one data row", "Test SELECT statement", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End If

    rdr.Close()
    conn.Close()
    MessageBox.Show("SELECT statement executed successfully and returned:" & vbCrLf & vbCrLf & _
                    If(reverse, "Host name: ", "IP address: ") & col1 & vbCrLf & _
                    "TTL: " & col2, "Test SELECT statement", MessageBoxButtons.OK, MessageBoxIcon.Information)
  End Sub


End Class

