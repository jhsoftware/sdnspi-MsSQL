Imports JHSoftware.SimpleDNS.Plugin
Imports System.Data.SqlClient

Public Class MsSqlPlugIn
  Implements ILookupHost
  Implements ILookupReverse
  Implements IOptionsUI

  Friend dbConnStr As String
  Friend SelectFwd4 As String
  Friend SelectFwd6 As String
  Friend SelectRev4 As String
  Friend SelectRev6 As String

  Public Property Host As IHost Implements IPlugInBase.Host


#Region "not implemeted"
  Public Function InstanceConflict(ByVal configXML1 As String, ByVal configXML2 As String, ByRef errorMsg As String) As Boolean Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.InstanceConflict
    Return False
  End Function

  Public Sub LoadState(ByVal stateXML As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LoadState
    REM nothing
  End Sub

  Public Function SaveState() As String Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.SaveState
    Return ""
  End Function

  Public Function StartService() As Threading.Tasks.Task Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.StartService
    Return Threading.Tasks.Task.CompletedTask
  End Function

  Public Sub StopService() Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.StopService
  End Sub
#End Region

  Public Function GetPlugInTypeInfo() As JHSoftware.SimpleDNS.Plugin.IPlugInBase.PlugInTypeInfo Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetPlugInTypeInfo
    With GetPlugInTypeInfo
      .Name = "MS SQL Server"
      .Description = "Fetches host records from a Microsoft SQL server"
      .InfoURL = "https://simpledns.plus/kb/181/ms-sql-server-plug-in"
    End With
  End Function

  Public Sub LoadConfig(ByVal config As String, ByVal instanceID As Guid, ByVal dataPath As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LoadConfig
    If config.Length = 0 Then Exit Sub
    Dim doc As New Xml.XmlDocument
    Dim root As Xml.XmlElement = doc.CreateElement("root")
    doc.AppendChild(root)
    root.InnerXml = config
    For Each node As Xml.XmlNode In root.ChildNodes
      If Not TypeOf node Is Xml.XmlElement Then Continue For
      Select Case DirectCast(node, Xml.XmlElement).Name
        Case "DBConnStr"
          dbConnStr = node.InnerText
        Case "SelectFwd4"
          SelectFwd4 = node.InnerText
        Case "SelectFwd6"
          SelectFwd6 = node.InnerText
        Case "SelectRev4"
          SelectRev4 = node.InnerText
        Case "SelectRev6"
          SelectRev6 = node.InnerText
      End Select
    Next
  End Sub

  Public Async Function LookupHost(name As DomName, ipv6 As Boolean, req As IDNSRequest) As Threading.Tasks.Task(Of JHSoftware.SimpleDNS.Plugin.LookupResult(Of SdnsIP)) Implements JHSoftware.SimpleDNS.Plugin.ILookupHost.LookupHost
    Dim selStr = If(ipv6, SelectFwd6, SelectFwd4)
    If String.IsNullOrEmpty(selStr) Then Return Nothing
    Using dbConn = New SqlConnection(dbConnStr)
      Await dbConn.OpenAsync()
      Dim nameStr As String = req.ToString()
      Dim cmd = dbConn.CreateCommand
      cmd.CommandText = selStr
      cmd.Parameters.AddWithValue("@hostname", nameStr)
      If selStr.IndexOf("@clientip") >= 0 Then cmd.Parameters.AddWithValue("@clientip", req.FromIP.ToString)
      Dim rdr = Await cmd.ExecuteReaderAsync
      If Not Await rdr.ReadAsync() Then rdr.Close() : Return Nothing
      Dim rv = New LookupResult(Of SdnsIP) With {.Value = SdnsIP.Parse(CStr(rdr(0))), .TTL = CInt(rdr(1))}
      rdr.Close()
      If ipv6 <> rv.Value.IsIPv6 Then Return Nothing
      Return rv
    End Using
  End Function

  Public Async Function LookupReverse(ip As SdnsIP, req As IDNSRequest) As Threading.Tasks.Task(Of LookupResult(Of DomName)) Implements JHSoftware.SimpleDNS.Plugin.ILookupReverse.LookupReverse
    Dim selStr = If(ip.IsIPv4, SelectRev4, SelectRev6)
    If String.IsNullOrEmpty(selStr) Then Return Nothing
    Using dbConn = New SqlConnection(dbConnStr)
      Await dbConn.OpenAsync()
      Dim cmd = dbConn.CreateCommand
      cmd.CommandText = selStr
      cmd.Parameters.AddWithValue("@ipaddress", ip.ToString)
      If selStr.IndexOf("@clientip") >= 0 Then cmd.Parameters.AddWithValue("@clientip", ip.ToString)
      Dim rdr = Await cmd.ExecuteReaderAsync
      If Not Await rdr.ReadAsync Then rdr.Close() : Return Nothing
      Dim rv = New LookupResult(Of DomName) With {.Value = DomName.Parse(CStr(rdr(0))), .TTL = CInt(rdr(1))}
      rdr.Close()
      Return rv
    End Using
  End Function

  Public Function GetOptionsUI(ByVal instanceID As Guid, ByVal dataPath As String) As JHSoftware.SimpleDNS.Plugin.OptionsUI Implements JHSoftware.SimpleDNS.Plugin.IOptionsUI.GetOptionsUI
    Return New OptionsCtrl
  End Function

End Class
