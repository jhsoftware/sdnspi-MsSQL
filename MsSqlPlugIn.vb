Imports JHSoftware.SimpleDNS.Plugin
Imports System.Data.SqlClient

Public Class MsSqlPlugIn
  Implements IGetHostPlugIn

  Friend dbConnStr As String
  Friend SelectFwd4 As String
  Friend SelectFwd6 As String
  Friend SelectRev4 As String
  Friend SelectRev6 As String

  '  Friend dbConn As SqlConnection
  'Private LastConnectAttempt As DateTime

#Region "events"
  Public Event LogLine(ByVal text As String) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.LogLine
  Public Event AsyncError(ByVal ex As System.Exception) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.AsyncError
  Public Event SaveConfig(ByVal config As String) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.SaveConfig
#End Region

#Region "not implemeted"
  Public Function InstanceConflict(ByVal configXML1 As String, ByVal configXML2 As String, ByRef errorMsg As String) As Boolean Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.InstanceConflict
    Return False
  End Function

  Public Sub LookupTXT(ByVal req As IDNSRequest, ByRef resultText As String, ByRef resultTTL As Integer) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.LookupTXT
    Throw New NotSupportedException
  End Sub

  Public Sub LoadState(ByVal stateXML As String) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.LoadState
  End Sub

  Public Function SaveState() As String Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.SaveState
    Return ""
  End Function
#End Region

#Region "Other Methods"

  Public Function GetPlugInTypeInfo() As JHSoftware.SimpleDNS.Plugin.IPlugInBase.PlugInTypeInfo Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetPlugInTypeInfo
    With GetPlugInTypeInfo
      .Name = "MS SQL Server"
      .Description = "Fetches host records from a Microsoft SQL server"
      .InfoURL = "http://www.simpledns.com/kb.aspx?kbid=1211"
      .ConfigFile = False
      .MultiThreaded = True
    End With
  End Function

  Public Function GetDNSAskAbout() As JHSoftware.SimpleDNS.Plugin.DNSAskAboutGH Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.GetDNSAskAbout
    With GetDNSAskAbout
      .ForwardIPv4 = Not String.IsNullOrEmpty(SelectFwd4)
      .ForwardIPv6 = Not String.IsNullOrEmpty(SelectFwd6)
      .RevIPv4Addr = If(String.IsNullOrEmpty(SelectRev4), Nothing, IPAddressV4.Any)
      .RevIPv6Addr = If(String.IsNullOrEmpty(SelectRev6), Nothing, IPAddressV6.Any)
      .RevIPv4MaskSize = 0
      .RevIPv6MaskSize = 0
    End With
  End Function

  Public Sub LoadConfig(ByVal config As String, ByVal instanceID As Guid, ByVal dataPath As String, ByRef maxThreads As Integer) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.LoadConfig
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

  Public Sub StartService() Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.StartService
    'dbConn = New SqlConnection(dbConnStr)
    'LastConnectAttempt = DateTime.UtcNow
    'dbConn.Open()
  End Sub

  Public Sub StopService() Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.StopService
    'If dbConn IsNot Nothing Then dbConn.Close() : dbConn = Nothing
  End Sub

  Public Sub Lookup(ByVal req As IDNSRequest, ByRef resultIP As IPAddress, ByRef resultTTL As Integer) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.Lookup
    Using dbConn = New SqlConnection(dbConnStr)
      dbConn.Open()

      Dim selStr = If(req.QType = 1US, SelectFwd4, SelectFwd6)
      If String.IsNullOrEmpty(selStr) Then resultIP = Nothing : Exit Sub
      Dim name As String = req.QName.ToString
      Dim cmd = dbConn.CreateCommand
      cmd.CommandText = selStr
      cmd.Parameters.AddWithValue("@hostname", name)
      If selStr.IndexOf("@clientip") >= 0 Then cmd.Parameters.AddWithValue("@clientip", req.FromIP.ToString)
      Dim rdr = cmd.ExecuteReader
      If Not rdr.Read Then rdr.Close() : resultIP = Nothing : Exit Sub

      resultIP = IPAddress.Parse(CStr(rdr(0)))
      resultTTL = CInt(rdr(1))
      rdr.Close()
      If (req.QType = 1US) <> (resultIP.IPVersion = 4) Then resultIP = Nothing
    End Using
  End Sub

  Public Sub LookupReverse(ByVal req As IDNSRequest, ByRef resultName As DomainName, ByRef resultTTL As Integer) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.LookupReverse
    Using dbConn = New SqlConnection(dbConnStr)
      dbConn.Open()

      Dim selStr = If(req.QNameIP.IPVersion = 4, SelectRev4, SelectRev6)
      If String.IsNullOrEmpty(selStr) Then resultName = Nothing : Exit Sub
      Dim cmd = dbConn.CreateCommand
      cmd.CommandText = selStr
      cmd.Parameters.AddWithValue("@ipaddress", req.QNameIP.ToString)
      If selStr.IndexOf("@clientip") >= 0 Then cmd.Parameters.AddWithValue("@clientip", req.FromIP.ToString)
      Dim rdr = cmd.ExecuteReader
      If Not rdr.Read Then rdr.Close() : resultName = Nothing : Exit Sub
      resultName = DomainName.Parse(CStr(rdr(0)))
      resultTTL = CInt(rdr(1))
      rdr.Close()
    End Using
  End Sub

  Public Function GetOptionsUI(ByVal instanceID As Guid, ByVal dataPath As String) As JHSoftware.SimpleDNS.Plugin.OptionsUI Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.GetOptionsUI
    Return New OptionsCtrl
  End Function

#End Region


End Class
