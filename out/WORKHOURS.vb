Imports system
Imports system.IO
Imports system.xml
Imports System.Net
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Newtonsoft.Json

Namespace OData
    
    <QueryTitle("Work Hour Reporting")>  _
    Public Class QUERY_WORKHOURS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of WORKHOURS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of WORKHOURS)
            _Parent = nothing
            _Name = "WORKHOURS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of WORKHOURS)
            _Parent = Parent
            _name = "WORKHOURS_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        <JsonProperty("@odata.context")>  _
        Protected Friend Property Name() As String
            Get
                return _Name
            End Get
            Set
                _Name = value
            End Set
        End Property
        
        Public Property Value() As list(of WORKHOURS)
            Get
                return _Value
            End Get
            Set
                _Value = value
            End Set
        End Property
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                return _Name
            End Get
        End Property
        
        Public Overrides Property Parent() As oDataObject
            Get
                return _Parent
            End Get
            Set
                _Parent = value
            End Set
        End Property
        
        Public Overrides ReadOnly Property ObjectType() As System.Type
            Get
                return GetType(WORKHOURS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _WORKHOURS As WORKHOURS In JsonConvert.DeserializeObject(Of QUERY_WORKHOURS)(stream.ReadToEnd).Value
              With _WORKHOURS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_WORKHOURS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as WORKHOURS = JsonConvert.DeserializeObject(Of WORKHOURS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, WORKHOURS)
                  .USERLOGIN = obj.USERLOGIN
                  .BRANCHNAME = obj.BRANCHNAME
                  .WDATE = obj.WDATE
                  .WDAY = obj.WDAY
                  .FROMTIMEA = obj.FROMTIMEA
                  .TOTIME = obj.TOTIME
                  .DIFTIME = obj.DIFTIME
                  .KM = obj.KM
                  .STANDBYFLAG = obj.STANDBYFLAG
                  .DES = obj.DES
                  .MANUAL = obj.MANUAL
                  .SUSERLOGIN = obj.SUSERLOGIN
                  .SDATE = obj.SDATE
                  .FROMTIME = obj.FROMTIME
                  .USER = obj.USER
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new WORKHOURS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _WORKHOURS as WORKHOURS in value
              If _WORKHOURS.Equals(trycast(obj,WORKHOURS)) Then
                  value.remove(_WORKHOURS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class WORKHOURS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetUSERLOGIN As Boolean = Boolean.FalseString
        
        Private _USERLOGIN As String
        
        Private _BRANCHNAME As String
        
        Private _IsSetWDATE As Boolean = Boolean.FalseString
        
        Private _WDATE As System.DateTimeOffset
        
        Private _IsSetWDAY As Boolean = Boolean.FalseString
        
        Private _WDAY As String
        
        Private _IsSetFROMTIMEA As Boolean = Boolean.FalseString
        
        Private _FROMTIMEA As String
        
        Private _IsSetTOTIME As Boolean = Boolean.FalseString
        
        Private _TOTIME As String
        
        Private _DIFTIME As String
        
        Private _IsSetKM As Boolean = Boolean.FalseString
        
        Private _KM As Long
        
        Private _IsSetSTANDBYFLAG As Boolean = Boolean.FalseString
        
        Private _STANDBYFLAG As String
        
        Private _IsSetDES As Boolean = Boolean.FalseString
        
        Private _DES As String
        
        Private _MANUAL As String
        
        Private _SUSERLOGIN As String
        
        Private _SDATE As System.DateTimeOffset
        
        Private _IsSetFROMTIME As Boolean = Boolean.FalseString
        
        Private _FROMTIME As String
        
        Private _IsSetUSER As Boolean = Boolean.FalseString
        
        Private _USER As Long
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
        End Sub
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "WORKHOURS"
                else
                    return "WORKHOURS_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "WDATE={0},FROMTIME={1},USER={2}", _
                  string.format("{0}",WDATE), _
                  string.format("'{0}'",FROMTIME), _
                  string.format("{0}",USER) _ 
               )
            End Get
        End Property
        
        Public Overrides Property Parent() As oDataObject
            Get
                return _Parent
            End Get
            Set
                _Parent = value
            End Set
        End Property
        
        <DisplayName("User Name"),  _
         nType("Edm.String"),  _
         tab("User Name"),  _
         Pos(2),  _
         twodBarcode("USERLOGIN")>  _
        Public Property USERLOGIN() As String
            Get
                return _USERLOGIN
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("User Name", value, "^.{0,20}$") then Exit Property
                _IsSetUSERLOGIN = True
                If loading Then
                  _USERLOGIN = Value
                Else
                    if not _USERLOGIN = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("USERLOGIN", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _USERLOGIN = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Branch Code"),  _
         nType("Edm.String"),  _
         tab("User Name"),  _
         Pos(3),  _
         [ReadOnly](true),  _
         twodBarcode("BRANCHNAME")>  _
        Public Property BRANCHNAME() As String
            Get
                return _BRANCHNAME
            End Get
            Set
                if not(value is nothing) then
                  _BRANCHNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("User Name"),  _
         Pos(20),  _
         twodBarcode("WDATE")>  _
        Public Property WDATE() As nullable (of DateTimeOffset)
            Get
                return _WDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Date", value, "^.*$") then Exit Property
                _IsSetWDATE = True
                If loading Then
                  _WDATE = Value
                Else
                    if not _WDATE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("WDATE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _WDATE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Day"),  _
         nType("Edm.String"),  _
         tab("User Name"),  _
         Pos(22),  _
         twodBarcode("WDAY")>  _
        Public Property WDAY() As String
            Get
                return _WDAY
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Day", value, "^.{0,3}$") then Exit Property
                _IsSetWDAY = True
                If loading Then
                  _WDAY = Value
                Else
                    if not _WDAY = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("WDAY", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _WDAY = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Start"),  _
         nType("Edm.String"),  _
         tab("User Name"),  _
         Pos(30),  _
         twodBarcode("FROMTIMEA")>  _
        Public Property FROMTIMEA() As String
            Get
                return _FROMTIMEA
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Start", value, "^.{0,5}$") then Exit Property
                _IsSetFROMTIMEA = True
                If loading Then
                  _FROMTIMEA = Value
                Else
                    if not _FROMTIMEA = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FROMTIMEA", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FROMTIMEA = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("End"),  _
         nType("Edm.String"),  _
         tab("User Name"),  _
         Pos(40),  _
         twodBarcode("TOTIME")>  _
        Public Property TOTIME() As String
            Get
                return _TOTIME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("End", value, "^.{0,5}$") then Exit Property
                _IsSetTOTIME = True
                If loading Then
                  _TOTIME = Value
                Else
                    if not _TOTIME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TOTIME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TOTIME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Total Hours"),  _
         nType("Edm.String"),  _
         tab("User Name"),  _
         Pos(44),  _
         [ReadOnly](true),  _
         twodBarcode("DIFTIME")>  _
        Public Property DIFTIME() As String
            Get
                return _DIFTIME
            End Get
            Set
                if not(value is nothing) then
                  _DIFTIME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Travel Miles"),  _
         nType("Edm.Int64"),  _
         tab("User Name"),  _
         Pos(46),  _
         twodBarcode("KM")>  _
        Public Property KM() As nullable (of int64)
            Get
                return _KM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Travel Miles", value, "^[0-9\-]+$") then Exit Property
                _IsSetKM = True
                If loading Then
                  _KM = Value
                Else
                    if not _KM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("KM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _KM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("On Call Hours"),  _
         nType("Edm.String"),  _
         tab("On Call Hours"),  _
         Pos(48),  _
         twodBarcode("STANDBYFLAG")>  _
        Public Property STANDBYFLAG() As String
            Get
                return _STANDBYFLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("On Call Hours", value, "^.{0,1}$") then Exit Property
                _IsSetSTANDBYFLAG = True
                If loading Then
                  _STANDBYFLAG = Value
                Else
                    if not _STANDBYFLAG = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("STANDBYFLAG", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _STANDBYFLAG = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Remark-Manual Entry"),  _
         nType("Edm.String"),  _
         tab("On Call Hours"),  _
         Pos(60),  _
         twodBarcode("DES")>  _
        Public Property DES() As String
            Get
                return _DES
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Remark-Manual Entry", value, "^.{0,40}$") then Exit Property
                _IsSetDES = True
                If loading Then
                  _DES = Value
                Else
                    if not _DES = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("DES", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _DES = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Manual"),  _
         nType("Edm.String"),  _
         tab("On Call Hours"),  _
         Pos(70),  _
         [ReadOnly](true),  _
         twodBarcode("MANUAL")>  _
        Public Property MANUAL() As String
            Get
                return _MANUAL
            End Get
            Set
                if not(value is nothing) then
                  _MANUAL = Value
                end if
            End Set
        End Property
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("On Call Hours"),  _
         Pos(80),  _
         [ReadOnly](true),  _
         twodBarcode("SUSERLOGIN")>  _
        Public Property SUSERLOGIN() As String
            Get
                return _SUSERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _SUSERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Time Stamp"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("On Call Hours"),  _
         Pos(90),  _
         [ReadOnly](true),  _
         twodBarcode("SDATE")>  _
        Public Property SDATE() As nullable (of DateTimeOffset)
            Get
                return _SDATE
            End Get
            Set
                if not(value is nothing) then
                  _SDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Start"),  _
         nType("Edm.String"),  _
         tab("On Call Hours"),  _
         Pos(30),  _
         Browsable(false),  _
         twodBarcode("FROMTIME")>  _
        Public Property FROMTIME() As String
            Get
                return _FROMTIME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Start", value, "^.{0,5}$") then Exit Property
                _IsSetFROMTIME = True
                If loading Then
                  _FROMTIME = Value
                Else
                    if not _FROMTIME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FROMTIME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FROMTIME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("User (ID)"),  _
         nType("Edm.Int64"),  _
         tab("On Call Hours"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("USER")>  _
        Public Property USER() As nullable (of int64)
            Get
                return _USER
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("User (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetUSER = True
                If loading Then
                  _USER = Value
                Else
                    if not _USER = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("USER", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _USER = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetUSERLOGIN then
              if f then
                  jw.WriteRaw(", ""USERLOGIN"": ")
              else
                  jw.WriteRaw("""USERLOGIN"": ")
                  f = true
              end if
              jw.WriteValue(me.USERLOGIN)
            end if
            if _IsSetWDATE then
              if f then
                  jw.WriteRaw(", ""WDATE"": ")
              else
                  jw.WriteRaw("""WDATE"": ")
                  f = true
              end if
              jw.WriteValue(me.WDATE)
            end if
            if _IsSetWDAY then
              if f then
                  jw.WriteRaw(", ""WDAY"": ")
              else
                  jw.WriteRaw("""WDAY"": ")
                  f = true
              end if
              jw.WriteValue(me.WDAY)
            end if
            if _IsSetFROMTIMEA then
              if f then
                  jw.WriteRaw(", ""FROMTIMEA"": ")
              else
                  jw.WriteRaw("""FROMTIMEA"": ")
                  f = true
              end if
              jw.WriteValue(me.FROMTIMEA)
            end if
            if _IsSetTOTIME then
              if f then
                  jw.WriteRaw(", ""TOTIME"": ")
              else
                  jw.WriteRaw("""TOTIME"": ")
                  f = true
              end if
              jw.WriteValue(me.TOTIME)
            end if
            if _IsSetKM then
              if f then
                  jw.WriteRaw(", ""KM"": ")
              else
                  jw.WriteRaw("""KM"": ")
                  f = true
              end if
              jw.WriteValue(me.KM)
            end if
            if _IsSetSTANDBYFLAG then
              if f then
                  jw.WriteRaw(", ""STANDBYFLAG"": ")
              else
                  jw.WriteRaw("""STANDBYFLAG"": ")
                  f = true
              end if
              jw.WriteValue(me.STANDBYFLAG)
            end if
            if _IsSetDES then
              if f then
                  jw.WriteRaw(", ""DES"": ")
              else
                  jw.WriteRaw("""DES"": ")
                  f = true
              end if
              jw.WriteValue(me.DES)
            end if
            if _IsSetFROMTIME then
              if f then
                  jw.WriteRaw(", ""FROMTIME"": ")
              else
                  jw.WriteRaw("""FROMTIME"": ")
                  f = true
              end if
              jw.WriteValue(me.FROMTIME)
            end if
            if _IsSetUSER then
              if f then
                  jw.WriteRaw(", ""USER"": ")
              else
                  jw.WriteRaw("""USER"": ")
                  f = true
              end if
              jw.WriteValue(me.USER)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "WORKHOURS")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "WDATE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "FROMTIME")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "5")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "USER")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetUSERLOGIN then
              .WriteStartElement("field")
              .WriteAttributeString("name", "USERLOGIN")
              .WriteAttributeString("value", me.USERLOGIN)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
              .WriteEndElement
            end if
            if _IsSetWDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "WDATE")
              .WriteAttributeString("value", me.WDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetWDAY then
              .WriteStartElement("field")
              .WriteAttributeString("name", "WDAY")
              .WriteAttributeString("value", me.WDAY)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
            end if
            if _IsSetFROMTIMEA then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FROMTIMEA")
              .WriteAttributeString("value", me.FROMTIMEA)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "5")
              .WriteEndElement
            end if
            if _IsSetTOTIME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TOTIME")
              .WriteAttributeString("value", me.TOTIME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "5")
              .WriteEndElement
            end if
            if _IsSetKM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "KM")
              .WriteAttributeString("value", me.KM)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetSTANDBYFLAG then
              .WriteStartElement("field")
              .WriteAttributeString("name", "STANDBYFLAG")
              .WriteAttributeString("value", me.STANDBYFLAG)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetDES then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DES")
              .WriteAttributeString("value", me.DES)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "40")
              .WriteEndElement
            end if
            if _IsSetFROMTIME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FROMTIME")
              .WriteAttributeString("value", me.FROMTIME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "5")
              .WriteEndElement
            end if
            if _IsSetUSER then
              .WriteStartElement("field")
              .WriteAttributeString("name", "USER")
              .WriteAttributeString("value", me.USER)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as WORKHOURS = JsonConvert.DeserializeObject(Of WORKHOURS)(e.StreamReader.ReadToEnd)
                With obj
                  _USERLOGIN = .USERLOGIN
                  _BRANCHNAME = .BRANCHNAME
                  _WDATE = .WDATE
                  _WDAY = .WDAY
                  _FROMTIMEA = .FROMTIMEA
                  _TOTIME = .TOTIME
                  _DIFTIME = .DIFTIME
                  _KM = .KM
                  _STANDBYFLAG = .STANDBYFLAG
                  _DES = .DES
                  _MANUAL = .MANUAL
                  _SUSERLOGIN = .SUSERLOGIN
                  _SDATE = .SDATE
                  _FROMTIME = .FROMTIME
                  _USER = .USER
                end with
            End If
        End Sub
    End Class
End Namespace
