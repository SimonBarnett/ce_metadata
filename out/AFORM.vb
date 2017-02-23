Imports system
Imports system.IO
Imports system.xml
Imports System.Net
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Newtonsoft.Json

Namespace OData
    
    <QueryTitle("Reporting Production")>  _
    Public Class QUERY_AFORM
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of AFORM)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of AFORM)
            _Parent = nothing
            _Name = "AFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Production Details")
            .add(1, "List of Styles")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of AFORM)
            _Parent = Parent
            _name = "AFORM_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Production Details")
            .add(1, "List of Styles")
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
        
        Public Property Value() As list(of AFORM)
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
                return GetType(AFORM)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _AFORM As AFORM In JsonConvert.DeserializeObject(Of QUERY_AFORM)(stream.ReadToEnd).Value
              With _AFORM
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_AFORM)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as AFORM = JsonConvert.DeserializeObject(Of AFORM)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, AFORM)
                  .CURDATE = obj.CURDATE
                  .FORMNAME = obj.FORMNAME
                  .SHIFTNAME = obj.SHIFTNAME
                  .DETAILS = obj.DETAILS
                  .USERID = obj.USERID
                  .FINAL = obj.FINAL
                  .GENERAL = obj.GENERAL
                  .FORM = obj.FORM
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new AFORM(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _AFORM as AFORM in value
              If _AFORM.Equals(trycast(obj,AFORM)) Then
                  value.remove(_AFORM)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class AFORM
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetCURDATE As Boolean = Boolean.FalseString
        
        Private _CURDATE As System.DateTimeOffset
        
        Private _IsSetFORMNAME As Boolean = Boolean.FalseString
        
        Private _FORMNAME As String
        
        Private _IsSetSHIFTNAME As Boolean = Boolean.FalseString
        
        Private _SHIFTNAME As String
        
        Private _IsSetDETAILS As Boolean = Boolean.FalseString
        
        Private _DETAILS As String
        
        Private _IsSetUSERID As Boolean = Boolean.FalseString
        
        Private _USERID As Long
        
        Private _IsSetFINAL As Boolean = Boolean.FalseString
        
        Private _FINAL As String
        
        Private _GENERAL As String
        
        Private _IsSetFORM As Boolean = Boolean.FalseString
        
        Private _FORM As Long
        
        Private _ALINE_SUBFORM As QUERY_ALINE
        
        Private _MATRIXSUM_SUBFORM As QUERY_MATRIXSUM
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Production Details"))
            ChildQuery.add(1, new oNavigation("List of Styles"))
            _ALINE_SUBFORM = new QUERY_ALINE(me)
            _MATRIXSUM_SUBFORM = new QUERY_MATRIXSUM(me)
            WITH ChildQuery(0)
               .setoDataQuery(_ALINE_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Production Details", _ALINE_SUBFORM))
                   .add(1, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_MATRIXSUM_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Production Details", _ALINE_SUBFORM))
                   .add(1, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Production Details"))
            ChildQuery.add(1, new oNavigation("List of Styles"))
            _ALINE_SUBFORM = new QUERY_ALINE(me)
            _MATRIXSUM_SUBFORM = new QUERY_MATRIXSUM(me)
            WITH ChildQuery(0)
               .setoDataQuery(_ALINE_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Production Details", _ALINE_SUBFORM))
                   .add(1, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_MATRIXSUM_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Production Details", _ALINE_SUBFORM))
                   .add(1, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "AFORM"
                else
                    return "AFORM_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "FORMNAME={0}", _
                  string.format("'{0}'",FORMNAME) _ 
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
        
        <DisplayName("Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Date"),  _
         Pos(1),  _
         Mandatory(true),  _
         twodBarcode("CURDATE")>  _
        Public Property CURDATE() As nullable (of DateTimeOffset)
            Get
                return _CURDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Date", value, "^.*$") then Exit Property
                _IsSetCURDATE = True
                If loading Then
                  _CURDATE = Value
                Else
                    if not _CURDATE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CURDATE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CURDATE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Form Number"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(2),  _
         twodBarcode("FORMNAME")>  _
        Public Property FORMNAME() As String
            Get
                return _FORMNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Form Number", value, "^.{0,16}$") then Exit Property
                _IsSetFORMNAME = True
                If loading Then
                  _FORMNAME = Value
                Else
                    if not _FORMNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FORMNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FORMNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Shift"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(10),  _
         twodBarcode("SHIFTNAME")>  _
        Public Property SHIFTNAME() As String
            Get
                return _SHIFTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Shift", value, "^.{0,8}$") then Exit Property
                _IsSetSHIFTNAME = True
                If loading Then
                  _SHIFTNAME = Value
                Else
                    if not _SHIFTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SHIFTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SHIFTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Details"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(20),  _
         twodBarcode("DETAILS")>  _
        Public Property DETAILS() As String
            Get
                return _DETAILS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Details", value, "^.{0,24}$") then Exit Property
                _IsSetDETAILS = True
                If loading Then
                  _DETAILS = Value
                Else
                    if not _DETAILS = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("DETAILS", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _DETAILS = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Employee ID"),  _
         nType("Edm.Int64"),  _
         tab("Date"),  _
         Pos(25),  _
         twodBarcode("USERID")>  _
        Public Property USERID() As nullable (of int64)
            Get
                return _USERID
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Employee ID", value, "^[0-9\-]+$") then Exit Property
                _IsSetUSERID = True
                If loading Then
                  _USERID = Value
                Else
                    if not _USERID = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("USERID", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _USERID = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Final"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(44),  _
         twodBarcode("FINAL")>  _
        Public Property FINAL() As String
            Get
                return _FINAL
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Final", value, "^.{0,1}$") then Exit Property
                _IsSetFINAL = True
                If loading Then
                  _FINAL = Value
                Else
                    if not _FINAL = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FINAL", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FINAL = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("General Form"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("GENERAL")>  _
        Public Property GENERAL() As String
            Get
                return _GENERAL
            End Get
            Set
                if not(value is nothing) then
                  _GENERAL = Value
                end if
            End Set
        End Property
        
        <DisplayName("Form (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Date"),  _
         Pos(2),  _
         Browsable(false),  _
         twodBarcode("FORM")>  _
        Public Property FORM() As nullable (of int64)
            Get
                return _FORM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Form (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetFORM = True
                If loading Then
                  _FORM = Value
                Else
                    if not _FORM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FORM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FORM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property ALINE_SUBFORM() As QUERY_ALINE
            Get
                return _ALINE_SUBFORM
            End Get
            Set
                _ALINE_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property MATRIXSUM_SUBFORM() As QUERY_MATRIXSUM
            Get
                return _MATRIXSUM_SUBFORM
            End Get
            Set
                _MATRIXSUM_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetCURDATE then
              if f then
                  jw.WriteRaw(", ""CURDATE"": ")
              else
                  jw.WriteRaw("""CURDATE"": ")
                  f = true
              end if
              jw.WriteValue(me.CURDATE)
            end if
            if _IsSetFORMNAME then
              if f then
                  jw.WriteRaw(", ""FORMNAME"": ")
              else
                  jw.WriteRaw("""FORMNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.FORMNAME)
            end if
            if _IsSetSHIFTNAME then
              if f then
                  jw.WriteRaw(", ""SHIFTNAME"": ")
              else
                  jw.WriteRaw("""SHIFTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SHIFTNAME)
            end if
            if _IsSetDETAILS then
              if f then
                  jw.WriteRaw(", ""DETAILS"": ")
              else
                  jw.WriteRaw("""DETAILS"": ")
                  f = true
              end if
              jw.WriteValue(me.DETAILS)
            end if
            if _IsSetUSERID then
              if f then
                  jw.WriteRaw(", ""USERID"": ")
              else
                  jw.WriteRaw("""USERID"": ")
                  f = true
              end if
              jw.WriteValue(me.USERID)
            end if
            if _IsSetFINAL then
              if f then
                  jw.WriteRaw(", ""FINAL"": ")
              else
                  jw.WriteRaw("""FINAL"": ")
                  f = true
              end if
              jw.WriteValue(me.FINAL)
            end if
            if _IsSetFORM then
              if f then
                  jw.WriteRaw(", ""FORM"": ")
              else
                  jw.WriteRaw("""FORM"": ")
                  f = true
              end if
              jw.WriteValue(me.FORM)
            end if
            if _ALINE_SUBFORM.value.count > 0 then
              jw.WriteRaw(", ALINE_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as ALINE in _ALINE_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _ALINE_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _MATRIXSUM_SUBFORM.value.count > 0 then
              jw.WriteRaw(", MATRIXSUM_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as MATRIXSUM in _MATRIXSUM_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _MATRIXSUM_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "AFORM")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "FORMNAME")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            if _IsSetCURDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CURDATE")
              .WriteAttributeString("value", me.CURDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetFORMNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FORMNAME")
              .WriteAttributeString("value", me.FORMNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetSHIFTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SHIFTNAME")
              .WriteAttributeString("value", me.SHIFTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "8")
              .WriteEndElement
            end if
            if _IsSetDETAILS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DETAILS")
              .WriteAttributeString("value", me.DETAILS)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "24")
              .WriteEndElement
            end if
            if _IsSetUSERID then
              .WriteStartElement("field")
              .WriteAttributeString("name", "USERID")
              .WriteAttributeString("value", me.USERID)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetFINAL then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FINAL")
              .WriteAttributeString("value", me.FINAL)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetFORM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FORM")
              .WriteAttributeString("value", me.FORM)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _ALINE_SUBFORM.value.count > 0 then
              for each itm as ALINE in _ALINE_SUBFORM.Value
                itm.toXML(xw,"ALINE_SUBFORM")
              next
            end if
            if _MATRIXSUM_SUBFORM.value.count > 0 then
              for each itm as MATRIXSUM in _MATRIXSUM_SUBFORM.Value
                itm.toXML(xw,"MATRIXSUM_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as AFORM = JsonConvert.DeserializeObject(Of AFORM)(e.StreamReader.ReadToEnd)
                With obj
                  _CURDATE = .CURDATE
                  _FORMNAME = .FORMNAME
                  _SHIFTNAME = .SHIFTNAME
                  _DETAILS = .DETAILS
                  _USERID = .USERID
                  _FINAL = .FINAL
                  _GENERAL = .GENERAL
                  _FORM = .FORM
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_AFORM
        
        ALINE = 0
        
        MATRIXSUM = 1
    End Enum
    
    <QueryTitle("Production Details")>  _
    Public Class QUERY_ALINE
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of ALINE)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of ALINE)
            _Parent = nothing
            _Name = "ALINE"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Reporting Workers")
            .add(1, "Manual Issues to Work Order")
            .add(2, "Serial Numbers in Transaction")
            .add(3, "Auto Recording of Serial Nos.")
            .add(4, "Prod. Complete (Warehouse Entry)")
            .add(5, "Report Defective Parts")
            .add(6, "Analysis Results")
            .add(7, "Electronic Signature")
            .add(8, "Expiration Date Extensions")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of ALINE)
            _Parent = Parent
            _name = "ALINE_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Reporting Workers")
            .add(1, "Manual Issues to Work Order")
            .add(2, "Serial Numbers in Transaction")
            .add(3, "Auto Recording of Serial Nos.")
            .add(4, "Prod. Complete (Warehouse Entry)")
            .add(5, "Report Defective Parts")
            .add(6, "Analysis Results")
            .add(7, "Electronic Signature")
            .add(8, "Expiration Date Extensions")
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
        
        Public Property Value() As list(of ALINE)
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
                return GetType(ALINE)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _ALINE As ALINE In JsonConvert.DeserializeObject(Of QUERY_ALINE)(stream.ReadToEnd).Value
              With _ALINE
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_ALINE)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ALINE = JsonConvert.DeserializeObject(Of ALINE)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, ALINE)
                  .SERIALNAME = obj.SERIALNAME
                  .SERQUANT = obj.SERQUANT
                  .PARTNAME = obj.PARTNAME
                  .ACTNAME = obj.ACTNAME
                  .WORKCNAME = obj.WORKCNAME
                  .USERID = obj.USERID
                  .BNAME = obj.BNAME
                  .QUANT = obj.QUANT
                  .SQUANT = obj.SQUANT
                  .DEFECTCODE = obj.DEFECTCODE
                  .DEFECTDESC = obj.DEFECTDESC
                  .MQUANT = obj.MQUANT
                  .UNITNAME = obj.UNITNAME
                  .TQUANT = obj.TQUANT
                  .TSQUANT = obj.TSQUANT
                  .TMQUANT = obj.TMQUANT
                  .TUNITNAME = obj.TUNITNAME
                  .NUMPACK = obj.NUMPACK
                  .PACKCODE = obj.PACKCODE
                  .STIME = obj.STIME
                  .ETIME = obj.ETIME
                  .ASPAN = obj.ASPAN
                  .EMPSTIME = obj.EMPSTIME
                  .EMPETIME = obj.EMPETIME
                  .EMPASPAN = obj.EMPASPAN
                  .SHIFTNAME = obj.SHIFTNAME
                  .TOOLNAME = obj.TOOLNAME
                  .RTYPEBOOL = obj.RTYPEBOOL
                  .MODE = obj.MODE
                  .WARHSNAME = obj.WARHSNAME
                  .LOCNAME = obj.LOCNAME
                  .NEWPALLET = obj.NEWPALLET
                  .TOPALLETNAME = obj.TOPALLETNAME
                  .ACTCANCEL = obj.ACTCANCEL
                  .SERCANCEL = obj.SERCANCEL
                  .REVNAME = obj.REVNAME
                  .MSERIALNAME = obj.MSERIALNAME
                  .VALIDITYEXTENSION = obj.VALIDITYEXTENSION
                  .ANALYSISVALID = obj.ANALYSISVALID
                  .ANALYSISNOTVALID = obj.ANALYSISNOTVALID
                  .ALA = obj.ALA
                  .KLINE = obj.KLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new ALINE(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _ALINE as ALINE in value
              If _ALINE.Equals(trycast(obj,ALINE)) Then
                  value.remove(_ALINE)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class ALINE
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetSERIALNAME As Boolean = Boolean.FalseString
        
        Private _SERIALNAME As String
        
        Private _SERQUANT As Decimal
        
        Private _IsSetPARTNAME As Boolean = Boolean.FalseString
        
        Private _PARTNAME As String
        
        Private _IsSetACTNAME As Boolean = Boolean.FalseString
        
        Private _ACTNAME As String
        
        Private _IsSetWORKCNAME As Boolean = Boolean.FalseString
        
        Private _WORKCNAME As String
        
        Private _IsSetUSERID As Boolean = Boolean.FalseString
        
        Private _USERID As Long
        
        Private _BNAME As String
        
        Private _IsSetQUANT As Boolean = Boolean.FalseString
        
        Private _QUANT As Decimal
        
        Private _IsSetSQUANT As Boolean = Boolean.FalseString
        
        Private _SQUANT As Decimal
        
        Private _IsSetDEFECTCODE As Boolean = Boolean.FalseString
        
        Private _DEFECTCODE As String
        
        Private _DEFECTDESC As String
        
        Private _IsSetMQUANT As Boolean = Boolean.FalseString
        
        Private _MQUANT As Decimal
        
        Private _UNITNAME As String
        
        Private _IsSetTQUANT As Boolean = Boolean.FalseString
        
        Private _TQUANT As Decimal
        
        Private _IsSetTSQUANT As Boolean = Boolean.FalseString
        
        Private _TSQUANT As Decimal
        
        Private _IsSetTMQUANT As Boolean = Boolean.FalseString
        
        Private _TMQUANT As Decimal
        
        Private _TUNITNAME As String
        
        Private _IsSetNUMPACK As Boolean = Boolean.FalseString
        
        Private _NUMPACK As Long
        
        Private _IsSetPACKCODE As Boolean = Boolean.FalseString
        
        Private _PACKCODE As String
        
        Private _IsSetSTIME As Boolean = Boolean.FalseString
        
        Private _STIME As String
        
        Private _IsSetETIME As Boolean = Boolean.FalseString
        
        Private _ETIME As String
        
        Private _IsSetASPAN As Boolean = Boolean.FalseString
        
        Private _ASPAN As String
        
        Private _IsSetEMPSTIME As Boolean = Boolean.FalseString
        
        Private _EMPSTIME As String
        
        Private _IsSetEMPETIME As Boolean = Boolean.FalseString
        
        Private _EMPETIME As String
        
        Private _IsSetEMPASPAN As Boolean = Boolean.FalseString
        
        Private _EMPASPAN As String
        
        Private _IsSetSHIFTNAME As Boolean = Boolean.FalseString
        
        Private _SHIFTNAME As String
        
        Private _IsSetTOOLNAME As Boolean = Boolean.FalseString
        
        Private _TOOLNAME As String
        
        Private _IsSetRTYPEBOOL As Boolean = Boolean.FalseString
        
        Private _RTYPEBOOL As String
        
        Private _IsSetMODE As Boolean = Boolean.FalseString
        
        Private _MODE As String
        
        Private _IsSetWARHSNAME As Boolean = Boolean.FalseString
        
        Private _WARHSNAME As String
        
        Private _IsSetLOCNAME As Boolean = Boolean.FalseString
        
        Private _LOCNAME As String
        
        Private _IsSetNEWPALLET As Boolean = Boolean.FalseString
        
        Private _NEWPALLET As String
        
        Private _IsSetTOPALLETNAME As Boolean = Boolean.FalseString
        
        Private _TOPALLETNAME As String
        
        Private _IsSetACTCANCEL As Boolean = Boolean.FalseString
        
        Private _ACTCANCEL As String
        
        Private _IsSetSERCANCEL As Boolean = Boolean.FalseString
        
        Private _SERCANCEL As String
        
        Private _REVNAME As String
        
        Private _MSERIALNAME As String
        
        Private _VALIDITYEXTENSION As Long
        
        Private _ANALYSISVALID As String
        
        Private _ANALYSISNOTVALID As String
        
        Private _IsSetALA As Boolean = Boolean.FalseString
        
        Private _ALA As Long
        
        Private _IsSetKLINE As Boolean = Boolean.FalseString
        
        Private _KLINE As Long
        
        Private _ALINEEMP_SUBFORM As QUERY_ALINEEMP
        
        Private _TRANSORDER_S_SUBFORM As QUERY_TRANSORDER_S
        
        Private _ALSERNTRANS_SUBFORM As QUERY_ALSERNTRANS
        
        Private _OPENSERNUM_SUBFORM As QUERY_OPENSERNUM
        
        Private _TRANSORDER_B_SUBFORM As QUERY_TRANSORDER_B
        
        Private _ALINEDEFECTCODES_SUBFORM As QUERY_ALINEDEFECTCODES
        
        Private _TRANSLABANALYSES_SUBFORM As QUERY_TRANSLABANALYSES
        
        Private _ALINESIGN_SUBFORM As QUERY_ALINESIGN
        
        Private _EXPDEXT_SUBFORM As QUERY_EXPDEXT
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Reporting Workers"))
            ChildQuery.add(1, new oNavigation("Manual Issues to Work Order"))
            ChildQuery.add(2, new oNavigation("Serial Numbers in Transaction"))
            ChildQuery.add(3, new oNavigation("Auto Recording of Serial Nos."))
            ChildQuery.add(4, new oNavigation("Prod. Complete (Warehouse Entry)"))
            ChildQuery.add(5, new oNavigation("Report Defective Parts"))
            ChildQuery.add(6, new oNavigation("Analysis Results"))
            ChildQuery.add(7, new oNavigation("Electronic Signature"))
            ChildQuery.add(8, new oNavigation("Expiration Date Extensions"))
            _ALINEEMP_SUBFORM = new QUERY_ALINEEMP(me)
            _TRANSORDER_S_SUBFORM = new QUERY_TRANSORDER_S(me)
            _ALSERNTRANS_SUBFORM = new QUERY_ALSERNTRANS(me)
            _OPENSERNUM_SUBFORM = new QUERY_OPENSERNUM(me)
            _TRANSORDER_B_SUBFORM = new QUERY_TRANSORDER_B(me)
            _ALINEDEFECTCODES_SUBFORM = new QUERY_ALINEDEFECTCODES(me)
            _TRANSLABANALYSES_SUBFORM = new QUERY_TRANSLABANALYSES(me)
            _ALINESIGN_SUBFORM = new QUERY_ALINESIGN(me)
            _EXPDEXT_SUBFORM = new QUERY_EXPDEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_ALINEEMP_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_TRANSORDER_S_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_ALSERNTRANS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_OPENSERNUM_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_TRANSORDER_B_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(5)
               .setoDataQuery(_ALINEDEFECTCODES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(6)
               .setoDataQuery(_TRANSLABANALYSES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(7)
               .setoDataQuery(_ALINESIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(8)
               .setoDataQuery(_EXPDEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Reporting Workers"))
            ChildQuery.add(1, new oNavigation("Manual Issues to Work Order"))
            ChildQuery.add(2, new oNavigation("Serial Numbers in Transaction"))
            ChildQuery.add(3, new oNavigation("Auto Recording of Serial Nos."))
            ChildQuery.add(4, new oNavigation("Prod. Complete (Warehouse Entry)"))
            ChildQuery.add(5, new oNavigation("Report Defective Parts"))
            ChildQuery.add(6, new oNavigation("Analysis Results"))
            ChildQuery.add(7, new oNavigation("Electronic Signature"))
            ChildQuery.add(8, new oNavigation("Expiration Date Extensions"))
            _ALINEEMP_SUBFORM = new QUERY_ALINEEMP(me)
            _TRANSORDER_S_SUBFORM = new QUERY_TRANSORDER_S(me)
            _ALSERNTRANS_SUBFORM = new QUERY_ALSERNTRANS(me)
            _OPENSERNUM_SUBFORM = new QUERY_OPENSERNUM(me)
            _TRANSORDER_B_SUBFORM = new QUERY_TRANSORDER_B(me)
            _ALINEDEFECTCODES_SUBFORM = new QUERY_ALINEDEFECTCODES(me)
            _TRANSLABANALYSES_SUBFORM = new QUERY_TRANSLABANALYSES(me)
            _ALINESIGN_SUBFORM = new QUERY_ALINESIGN(me)
            _EXPDEXT_SUBFORM = new QUERY_EXPDEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_ALINEEMP_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_TRANSORDER_S_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_ALSERNTRANS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_OPENSERNUM_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_TRANSORDER_B_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(5)
               .setoDataQuery(_ALINEDEFECTCODES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(6)
               .setoDataQuery(_TRANSLABANALYSES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(7)
               .setoDataQuery(_ALINESIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(8)
               .setoDataQuery(_EXPDEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Reporting Workers", _ALINEEMP_SUBFORM))
                   .add(1, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
                   .add(2, new oNavigation("Serial Numbers in Transaction", _ALSERNTRANS_SUBFORM))
                   .add(3, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(4, new oNavigation("Prod. Complete (Warehouse Entry)", _TRANSORDER_B_SUBFORM))
                   .add(5, new oNavigation("Report Defective Parts", _ALINEDEFECTCODES_SUBFORM))
                   .add(6, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _ALINESIGN_SUBFORM))
                   .add(8, new oNavigation("Expiration Date Extensions", _EXPDEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "ALINE"
                else
                    return "ALINE_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "KLINE={0}", _
                  string.format("{0}",KLINE) _ 
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
        
        <DisplayName("Work Order"),  _
         nType("Edm.String"),  _
         tab("Work Order"),  _
         Pos(4),  _
         Mandatory(true),  _
         twodBarcode("SERIALNAME")>  _
        Public Property SERIALNAME() As String
            Get
                return _SERIALNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Work Order", value, "^.{0,22}$") then Exit Property
                _IsSetSERIALNAME = True
                If loading Then
                  _SERIALNAME = Value
                Else
                    if not _SERIALNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SERIALNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SERIALNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Work Order Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Work Order"),  _
         Pos(6),  _
         [ReadOnly](true),  _
         twodBarcode("SERQUANT")>  _
        Public Property SERQUANT() As nullable(of decimal)
            Get
                return _SERQUANT
            End Get
            Set
                if not(value is nothing) then
                  _SERQUANT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Part Number"),  _
         nType("Edm.String"),  _
         tab("Work Order"),  _
         Pos(10),  _
         Mandatory(true),  _
         twodBarcode("PARTNAME")>  _
        Public Property PARTNAME() As String
            Get
                return _PARTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Part Number", value, "^.{0,15}$") then Exit Property
                _IsSetPARTNAME = True
                If loading Then
                  _PARTNAME = Value
                Else
                    if not _PARTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PARTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PARTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Operation"),  _
         nType("Edm.String"),  _
         tab("Work Order"),  _
         Pos(12),  _
         twodBarcode("ACTNAME")>  _
        Public Property ACTNAME() As String
            Get
                return _ACTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Operation", value, "^.{0,16}$") then Exit Property
                _IsSetACTNAME = True
                If loading Then
                  _ACTNAME = Value
                Else
                    if not _ACTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ACTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ACTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Work Cell"),  _
         nType("Edm.String"),  _
         tab("Work Order"),  _
         Pos(13),  _
         twodBarcode("WORKCNAME")>  _
        Public Property WORKCNAME() As String
            Get
                return _WORKCNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Work Cell", value, "^.{0,6}$") then Exit Property
                _IsSetWORKCNAME = True
                If loading Then
                  _WORKCNAME = Value
                Else
                    if not _WORKCNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("WORKCNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _WORKCNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Employee ID"),  _
         nType("Edm.Int64"),  _
         tab("Work Order"),  _
         Pos(14),  _
         twodBarcode("USERID")>  _
        Public Property USERID() As nullable (of int64)
            Get
                return _USERID
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Employee ID", value, "^[0-9\-]+$") then Exit Property
                _IsSetUSERID = True
                If loading Then
                  _USERID = Value
                Else
                    if not _USERID = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("USERID", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _USERID = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Employee Name"),  _
         nType("Edm.String"),  _
         tab("Work Order"),  _
         Pos(15),  _
         [ReadOnly](true),  _
         twodBarcode("BNAME")>  _
        Public Property BNAME() As String
            Get
                return _BNAME
            End Get
            Set
                if not(value is nothing) then
                  _BNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Qty Completed"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Work Order"),  _
         Pos(20),  _
         twodBarcode("QUANT")>  _
        Public Property QUANT() As nullable(of decimal)
            Get
                return _QUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Qty Completed", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetQUANT = True
                If loading Then
                  _QUANT = Value
                Else
                    if not _QUANT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("QUANT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _QUANT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Qty Rejected"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Qty Rejected"),  _
         Pos(22),  _
         twodBarcode("SQUANT")>  _
        Public Property SQUANT() As nullable(of decimal)
            Get
                return _SQUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Qty Rejected", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSQUANT = True
                If loading Then
                  _SQUANT = Value
                Else
                    if not _SQUANT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SQUANT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SQUANT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Defect Code"),  _
         nType("Edm.String"),  _
         tab("Qty Rejected"),  _
         Pos(23),  _
         twodBarcode("DEFECTCODE")>  _
        Public Property DEFECTCODE() As String
            Get
                return _DEFECTCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Defect Code", value, "^.{0,3}$") then Exit Property
                _IsSetDEFECTCODE = True
                If loading Then
                  _DEFECTCODE = Value
                Else
                    if not _DEFECTCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("DEFECTCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _DEFECTCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Descrip. of Defect"),  _
         nType("Edm.String"),  _
         tab("Qty Rejected"),  _
         Pos(24),  _
         [ReadOnly](true),  _
         twodBarcode("DEFECTDESC")>  _
        Public Property DEFECTDESC() As String
            Get
                return _DEFECTDESC
            End Get
            Set
                if not(value is nothing) then
                  _DEFECTDESC = Value
                end if
            End Set
        End Property
        
        <DisplayName("Qty for MRB"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Qty Rejected"),  _
         Pos(25),  _
         twodBarcode("MQUANT")>  _
        Public Property MQUANT() As nullable(of decimal)
            Get
                return _MQUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Qty for MRB", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetMQUANT = True
                If loading Then
                  _MQUANT = Value
                Else
                    if not _MQUANT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("MQUANT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _MQUANT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Factory Unit"),  _
         nType("Edm.String"),  _
         tab("Qty Rejected"),  _
         Pos(27),  _
         [ReadOnly](true),  _
         twodBarcode("UNITNAME")>  _
        Public Property UNITNAME() As String
            Get
                return _UNITNAME
            End Get
            Set
                if not(value is nothing) then
                  _UNITNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Completed (Buy/Sell)"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Qty Rejected"),  _
         Pos(30),  _
         twodBarcode("TQUANT")>  _
        Public Property TQUANT() As nullable(of decimal)
            Get
                return _TQUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Completed (Buy/Sell)", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetTQUANT = True
                If loading Then
                  _TQUANT = Value
                Else
                    if not _TQUANT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TQUANT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TQUANT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Rejected (Buy/Sell)"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Qty Rejected"),  _
         Pos(31),  _
         twodBarcode("TSQUANT")>  _
        Public Property TSQUANT() As nullable(of decimal)
            Get
                return _TSQUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Rejected (Buy/Sell)", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetTSQUANT = True
                If loading Then
                  _TSQUANT = Value
                Else
                    if not _TSQUANT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TSQUANT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TSQUANT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("MRB (Buy/Sell Units)"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Qty Rejected"),  _
         Pos(33),  _
         twodBarcode("TMQUANT")>  _
        Public Property TMQUANT() As nullable(of decimal)
            Get
                return _TMQUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("MRB (Buy/Sell Units)", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetTMQUANT = True
                If loading Then
                  _TMQUANT = Value
                Else
                    if not _TMQUANT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TMQUANT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TMQUANT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Buy/Sell Unit"),  _
         nType("Edm.String"),  _
         tab("Buy/Sell Unit"),  _
         Pos(34),  _
         [ReadOnly](true),  _
         twodBarcode("TUNITNAME")>  _
        Public Property TUNITNAME() As String
            Get
                return _TUNITNAME
            End Get
            Set
                if not(value is nothing) then
                  _TUNITNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Packing Crates (No.)"),  _
         nType("Edm.Int64"),  _
         tab("Buy/Sell Unit"),  _
         Pos(35),  _
         twodBarcode("NUMPACK")>  _
        Public Property NUMPACK() As nullable (of int64)
            Get
                return _NUMPACK
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Packing Crates (No.)", value, "^[0-9\-]+$") then Exit Property
                _IsSetNUMPACK = True
                If loading Then
                  _NUMPACK = Value
                Else
                    if not _NUMPACK = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("NUMPACK", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _NUMPACK = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Crate Type Code"),  _
         nType("Edm.String"),  _
         tab("Buy/Sell Unit"),  _
         Pos(36),  _
         twodBarcode("PACKCODE")>  _
        Public Property PACKCODE() As String
            Get
                return _PACKCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Crate Type Code", value, "^.{0,2}$") then Exit Property
                _IsSetPACKCODE = True
                If loading Then
                  _PACKCODE = Value
                Else
                    if not _PACKCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PACKCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PACKCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Start Time"),  _
         nType("Edm.String"),  _
         tab("Buy/Sell Unit"),  _
         Pos(37),  _
         twodBarcode("STIME")>  _
        Public Property STIME() As String
            Get
                return _STIME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Start Time", value, "^.{0,5}$") then Exit Property
                _IsSetSTIME = True
                If loading Then
                  _STIME = Value
                Else
                    if not _STIME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("STIME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _STIME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("End Time"),  _
         nType("Edm.String"),  _
         tab("Buy/Sell Unit"),  _
         Pos(38),  _
         twodBarcode("ETIME")>  _
        Public Property ETIME() As String
            Get
                return _ETIME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("End Time", value, "^.{0,5}$") then Exit Property
                _IsSetETIME = True
                If loading Then
                  _ETIME = Value
                Else
                    if not _ETIME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ETIME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ETIME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Span"),  _
         nType("Edm.String"),  _
         tab("Buy/Sell Unit"),  _
         Pos(39),  _
         twodBarcode("ASPAN")>  _
        Public Property ASPAN() As String
            Get
                return _ASPAN
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Span", value, "^.{0,6}$") then Exit Property
                _IsSetASPAN = True
                If loading Then
                  _ASPAN = Value
                Else
                    if not _ASPAN = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ASPAN", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ASPAN = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Start Labor"),  _
         nType("Edm.String"),  _
         tab("Buy/Sell Unit"),  _
         Pos(40),  _
         twodBarcode("EMPSTIME")>  _
        Public Property EMPSTIME() As String
            Get
                return _EMPSTIME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Start Labor", value, "^.{0,5}$") then Exit Property
                _IsSetEMPSTIME = True
                If loading Then
                  _EMPSTIME = Value
                Else
                    if not _EMPSTIME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EMPSTIME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EMPSTIME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("End Labor"),  _
         nType("Edm.String"),  _
         tab("Buy/Sell Unit"),  _
         Pos(45),  _
         twodBarcode("EMPETIME")>  _
        Public Property EMPETIME() As String
            Get
                return _EMPETIME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("End Labor", value, "^.{0,5}$") then Exit Property
                _IsSetEMPETIME = True
                If loading Then
                  _EMPETIME = Value
                Else
                    if not _EMPETIME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EMPETIME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EMPETIME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Labor Span"),  _
         nType("Edm.String"),  _
         tab("Labor Span"),  _
         Pos(50),  _
         twodBarcode("EMPASPAN")>  _
        Public Property EMPASPAN() As String
            Get
                return _EMPASPAN
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Labor Span", value, "^.{0,6}$") then Exit Property
                _IsSetEMPASPAN = True
                If loading Then
                  _EMPASPAN = Value
                Else
                    if not _EMPASPAN = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EMPASPAN", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EMPASPAN = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Shift"),  _
         nType("Edm.String"),  _
         tab("Labor Span"),  _
         Pos(55),  _
         twodBarcode("SHIFTNAME")>  _
        Public Property SHIFTNAME() As String
            Get
                return _SHIFTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Shift", value, "^.{0,8}$") then Exit Property
                _IsSetSHIFTNAME = True
                If loading Then
                  _SHIFTNAME = Value
                Else
                    if not _SHIFTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SHIFTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SHIFTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Tool"),  _
         nType("Edm.String"),  _
         tab("Labor Span"),  _
         Pos(62),  _
         twodBarcode("TOOLNAME")>  _
        Public Property TOOLNAME() As String
            Get
                return _TOOLNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Tool", value, "^.{0,15}$") then Exit Property
                _IsSetTOOLNAME = True
                If loading Then
                  _TOOLNAME = Value
                Else
                    if not _TOOLNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TOOLNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TOOLNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Rework?"),  _
         nType("Edm.String"),  _
         tab("Labor Span"),  _
         Pos(70),  _
         twodBarcode("RTYPEBOOL")>  _
        Public Property RTYPEBOOL() As String
            Get
                return _RTYPEBOOL
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Rework?", value, "^.{0,1}$") then Exit Property
                _IsSetRTYPEBOOL = True
                If loading Then
                  _RTYPEBOOL = Value
                Else
                    if not _RTYPEBOOL = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("RTYPEBOOL", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _RTYPEBOOL = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Set-up/Break (S/B)"),  _
         nType("Edm.String"),  _
         tab("Labor Span"),  _
         Pos(80),  _
         twodBarcode("MODE")>  _
        Public Property MODE() As String
            Get
                return _MODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Set-up/Break (S/B)", value, "^.{0,1}$") then Exit Property
                _IsSetMODE = True
                If loading Then
                  _MODE = Value
                Else
                    if not _MODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("MODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _MODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("To Warehouse"),  _
         nType("Edm.String"),  _
         tab("Labor Span"),  _
         Pos(90),  _
         twodBarcode("WARHSNAME")>  _
        Public Property WARHSNAME() As String
            Get
                return _WARHSNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("To Warehouse", value, "^.{0,4}$") then Exit Property
                _IsSetWARHSNAME = True
                If loading Then
                  _WARHSNAME = Value
                Else
                    if not _WARHSNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("WARHSNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _WARHSNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Bin"),  _
         nType("Edm.String"),  _
         tab("Labor Span"),  _
         Pos(91),  _
         twodBarcode("LOCNAME")>  _
        Public Property LOCNAME() As String
            Get
                return _LOCNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Bin", value, "^.{0,14}$") then Exit Property
                _IsSetLOCNAME = True
                If loading Then
                  _LOCNAME = Value
                Else
                    if not _LOCNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("LOCNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _LOCNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("New Pallet?"),  _
         nType("Edm.String"),  _
         tab("Labor Span"),  _
         Pos(94),  _
         twodBarcode("NEWPALLET")>  _
        Public Property NEWPALLET() As String
            Get
                return _NEWPALLET
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("New Pallet?", value, "^.{0,1}$") then Exit Property
                _IsSetNEWPALLET = True
                If loading Then
                  _NEWPALLET = Value
                Else
                    if not _NEWPALLET = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("NEWPALLET", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _NEWPALLET = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("To Pallet"),  _
         nType("Edm.String"),  _
         tab("To Pallet"),  _
         Pos(95),  _
         twodBarcode("TOPALLETNAME")>  _
        Public Property TOPALLETNAME() As String
            Get
                return _TOPALLETNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("To Pallet", value, "^.{0,16}$") then Exit Property
                _IsSetTOPALLETNAME = True
                If loading Then
                  _TOPALLETNAME = Value
                Else
                    if not _TOPALLETNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TOPALLETNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TOPALLETNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Remove Oper. Number?"),  _
         nType("Edm.String"),  _
         tab("To Pallet"),  _
         Pos(96),  _
         twodBarcode("ACTCANCEL")>  _
        Public Property ACTCANCEL() As String
            Get
                return _ACTCANCEL
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Remove Oper. Number?", value, "^.{0,1}$") then Exit Property
                _IsSetACTCANCEL = True
                If loading Then
                  _ACTCANCEL = Value
                Else
                    if not _ACTCANCEL = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ACTCANCEL", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ACTCANCEL = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Remove Wk Order No.?"),  _
         nType("Edm.String"),  _
         tab("To Pallet"),  _
         Pos(98),  _
         twodBarcode("SERCANCEL")>  _
        Public Property SERCANCEL() As String
            Get
                return _SERCANCEL
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Remove Wk Order No.?", value, "^.{0,1}$") then Exit Property
                _IsSetSERCANCEL = True
                If loading Then
                  _SERCANCEL = Value
                Else
                    if not _SERCANCEL = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SERCANCEL", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SERCANCEL = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Part Revision No."),  _
         nType("Edm.String"),  _
         tab("To Pallet"),  _
         Pos(100),  _
         [ReadOnly](true),  _
         twodBarcode("REVNAME")>  _
        Public Property REVNAME() As String
            Get
                return _REVNAME
            End Get
            Set
                if not(value is nothing) then
                  _REVNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Work Order for Style"),  _
         nType("Edm.String"),  _
         tab("To Pallet"),  _
         Pos(110),  _
         [ReadOnly](true),  _
         twodBarcode("MSERIALNAME")>  _
        Public Property MSERIALNAME() As String
            Get
                return _MSERIALNAME
            End Get
            Set
                if not(value is nothing) then
                  _MSERIALNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Max. No. Extensions"),  _
         nType("Edm.Int64"),  _
         tab("To Pallet"),  _
         Pos(110),  _
         [ReadOnly](true),  _
         twodBarcode("VALIDITYEXTENSION")>  _
        Public Property VALIDITYEXTENSION() As nullable (of int64)
            Get
                return _VALIDITYEXTENSION
            End Get
            Set
                if not(value is nothing) then
                  _VALIDITYEXTENSION = Value
                end if
            End Set
        End Property
        
        <DisplayName("Acceptable"),  _
         nType("Edm.String"),  _
         tab("To Pallet"),  _
         Pos(120),  _
         [ReadOnly](true),  _
         twodBarcode("ANALYSISVALID")>  _
        Public Property ANALYSISVALID() As String
            Get
                return _ANALYSISVALID
            End Get
            Set
                if not(value is nothing) then
                  _ANALYSISVALID = Value
                end if
            End Set
        End Property
        
        <DisplayName("Unacceptable"),  _
         nType("Edm.String"),  _
         tab("To Pallet"),  _
         Pos(130),  _
         [ReadOnly](true),  _
         twodBarcode("ANALYSISNOTVALID")>  _
        Public Property ANALYSISNOTVALID() As String
            Get
                return _ANALYSISNOTVALID
            End Get
            Set
                if not(value is nothing) then
                  _ANALYSISNOTVALID = Value
                end if
            End Set
        End Property
        
        <DisplayName("Form Line (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Form Line (ID)"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("ALA")>  _
        Public Property ALA() As nullable (of int64)
            Get
                return _ALA
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Form Line (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetALA = True
                If loading Then
                  _ALA = Value
                Else
                    if not _ALA = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ALA", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ALA = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Form Line (ID)"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("KLINE")>  _
        Public Property KLINE() As nullable (of int64)
            Get
                return _KLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Key Line", value, "^[0-9\-]+$") then Exit Property
                _IsSetKLINE = True
                If loading Then
                  _KLINE = Value
                Else
                    if not _KLINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("KLINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _KLINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property ALINEEMP_SUBFORM() As QUERY_ALINEEMP
            Get
                return _ALINEEMP_SUBFORM
            End Get
            Set
                _ALINEEMP_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSORDER_S_SUBFORM() As QUERY_TRANSORDER_S
            Get
                return _TRANSORDER_S_SUBFORM
            End Get
            Set
                _TRANSORDER_S_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property ALSERNTRANS_SUBFORM() As QUERY_ALSERNTRANS
            Get
                return _ALSERNTRANS_SUBFORM
            End Get
            Set
                _ALSERNTRANS_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property OPENSERNUM_SUBFORM() As QUERY_OPENSERNUM
            Get
                return _OPENSERNUM_SUBFORM
            End Get
            Set
                _OPENSERNUM_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSORDER_B_SUBFORM() As QUERY_TRANSORDER_B
            Get
                return _TRANSORDER_B_SUBFORM
            End Get
            Set
                _TRANSORDER_B_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property ALINEDEFECTCODES_SUBFORM() As QUERY_ALINEDEFECTCODES
            Get
                return _ALINEDEFECTCODES_SUBFORM
            End Get
            Set
                _ALINEDEFECTCODES_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSLABANALYSES_SUBFORM() As QUERY_TRANSLABANALYSES
            Get
                return _TRANSLABANALYSES_SUBFORM
            End Get
            Set
                _TRANSLABANALYSES_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property ALINESIGN_SUBFORM() As QUERY_ALINESIGN
            Get
                return _ALINESIGN_SUBFORM
            End Get
            Set
                _ALINESIGN_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property EXPDEXT_SUBFORM() As QUERY_EXPDEXT
            Get
                return _EXPDEXT_SUBFORM
            End Get
            Set
                _EXPDEXT_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetSERIALNAME then
              if f then
                  jw.WriteRaw(", ""SERIALNAME"": ")
              else
                  jw.WriteRaw("""SERIALNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SERIALNAME)
            end if
            if _IsSetPARTNAME then
              if f then
                  jw.WriteRaw(", ""PARTNAME"": ")
              else
                  jw.WriteRaw("""PARTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.PARTNAME)
            end if
            if _IsSetACTNAME then
              if f then
                  jw.WriteRaw(", ""ACTNAME"": ")
              else
                  jw.WriteRaw("""ACTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.ACTNAME)
            end if
            if _IsSetWORKCNAME then
              if f then
                  jw.WriteRaw(", ""WORKCNAME"": ")
              else
                  jw.WriteRaw("""WORKCNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.WORKCNAME)
            end if
            if _IsSetUSERID then
              if f then
                  jw.WriteRaw(", ""USERID"": ")
              else
                  jw.WriteRaw("""USERID"": ")
                  f = true
              end if
              jw.WriteValue(me.USERID)
            end if
            if _IsSetQUANT then
              if f then
                  jw.WriteRaw(", ""QUANT"": ")
              else
                  jw.WriteRaw("""QUANT"": ")
                  f = true
              end if
              jw.WriteValue(me.QUANT)
            end if
            if _IsSetSQUANT then
              if f then
                  jw.WriteRaw(", ""SQUANT"": ")
              else
                  jw.WriteRaw("""SQUANT"": ")
                  f = true
              end if
              jw.WriteValue(me.SQUANT)
            end if
            if _IsSetDEFECTCODE then
              if f then
                  jw.WriteRaw(", ""DEFECTCODE"": ")
              else
                  jw.WriteRaw("""DEFECTCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.DEFECTCODE)
            end if
            if _IsSetMQUANT then
              if f then
                  jw.WriteRaw(", ""MQUANT"": ")
              else
                  jw.WriteRaw("""MQUANT"": ")
                  f = true
              end if
              jw.WriteValue(me.MQUANT)
            end if
            if _IsSetTQUANT then
              if f then
                  jw.WriteRaw(", ""TQUANT"": ")
              else
                  jw.WriteRaw("""TQUANT"": ")
                  f = true
              end if
              jw.WriteValue(me.TQUANT)
            end if
            if _IsSetTSQUANT then
              if f then
                  jw.WriteRaw(", ""TSQUANT"": ")
              else
                  jw.WriteRaw("""TSQUANT"": ")
                  f = true
              end if
              jw.WriteValue(me.TSQUANT)
            end if
            if _IsSetTMQUANT then
              if f then
                  jw.WriteRaw(", ""TMQUANT"": ")
              else
                  jw.WriteRaw("""TMQUANT"": ")
                  f = true
              end if
              jw.WriteValue(me.TMQUANT)
            end if
            if _IsSetNUMPACK then
              if f then
                  jw.WriteRaw(", ""NUMPACK"": ")
              else
                  jw.WriteRaw("""NUMPACK"": ")
                  f = true
              end if
              jw.WriteValue(me.NUMPACK)
            end if
            if _IsSetPACKCODE then
              if f then
                  jw.WriteRaw(", ""PACKCODE"": ")
              else
                  jw.WriteRaw("""PACKCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.PACKCODE)
            end if
            if _IsSetSTIME then
              if f then
                  jw.WriteRaw(", ""STIME"": ")
              else
                  jw.WriteRaw("""STIME"": ")
                  f = true
              end if
              jw.WriteValue(me.STIME)
            end if
            if _IsSetETIME then
              if f then
                  jw.WriteRaw(", ""ETIME"": ")
              else
                  jw.WriteRaw("""ETIME"": ")
                  f = true
              end if
              jw.WriteValue(me.ETIME)
            end if
            if _IsSetASPAN then
              if f then
                  jw.WriteRaw(", ""ASPAN"": ")
              else
                  jw.WriteRaw("""ASPAN"": ")
                  f = true
              end if
              jw.WriteValue(me.ASPAN)
            end if
            if _IsSetEMPSTIME then
              if f then
                  jw.WriteRaw(", ""EMPSTIME"": ")
              else
                  jw.WriteRaw("""EMPSTIME"": ")
                  f = true
              end if
              jw.WriteValue(me.EMPSTIME)
            end if
            if _IsSetEMPETIME then
              if f then
                  jw.WriteRaw(", ""EMPETIME"": ")
              else
                  jw.WriteRaw("""EMPETIME"": ")
                  f = true
              end if
              jw.WriteValue(me.EMPETIME)
            end if
            if _IsSetEMPASPAN then
              if f then
                  jw.WriteRaw(", ""EMPASPAN"": ")
              else
                  jw.WriteRaw("""EMPASPAN"": ")
                  f = true
              end if
              jw.WriteValue(me.EMPASPAN)
            end if
            if _IsSetSHIFTNAME then
              if f then
                  jw.WriteRaw(", ""SHIFTNAME"": ")
              else
                  jw.WriteRaw("""SHIFTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SHIFTNAME)
            end if
            if _IsSetTOOLNAME then
              if f then
                  jw.WriteRaw(", ""TOOLNAME"": ")
              else
                  jw.WriteRaw("""TOOLNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.TOOLNAME)
            end if
            if _IsSetRTYPEBOOL then
              if f then
                  jw.WriteRaw(", ""RTYPEBOOL"": ")
              else
                  jw.WriteRaw("""RTYPEBOOL"": ")
                  f = true
              end if
              jw.WriteValue(me.RTYPEBOOL)
            end if
            if _IsSetMODE then
              if f then
                  jw.WriteRaw(", ""MODE"": ")
              else
                  jw.WriteRaw("""MODE"": ")
                  f = true
              end if
              jw.WriteValue(me.MODE)
            end if
            if _IsSetWARHSNAME then
              if f then
                  jw.WriteRaw(", ""WARHSNAME"": ")
              else
                  jw.WriteRaw("""WARHSNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.WARHSNAME)
            end if
            if _IsSetLOCNAME then
              if f then
                  jw.WriteRaw(", ""LOCNAME"": ")
              else
                  jw.WriteRaw("""LOCNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.LOCNAME)
            end if
            if _IsSetNEWPALLET then
              if f then
                  jw.WriteRaw(", ""NEWPALLET"": ")
              else
                  jw.WriteRaw("""NEWPALLET"": ")
                  f = true
              end if
              jw.WriteValue(me.NEWPALLET)
            end if
            if _IsSetTOPALLETNAME then
              if f then
                  jw.WriteRaw(", ""TOPALLETNAME"": ")
              else
                  jw.WriteRaw("""TOPALLETNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.TOPALLETNAME)
            end if
            if _IsSetACTCANCEL then
              if f then
                  jw.WriteRaw(", ""ACTCANCEL"": ")
              else
                  jw.WriteRaw("""ACTCANCEL"": ")
                  f = true
              end if
              jw.WriteValue(me.ACTCANCEL)
            end if
            if _IsSetSERCANCEL then
              if f then
                  jw.WriteRaw(", ""SERCANCEL"": ")
              else
                  jw.WriteRaw("""SERCANCEL"": ")
                  f = true
              end if
              jw.WriteValue(me.SERCANCEL)
            end if
            if _IsSetALA then
              if f then
                  jw.WriteRaw(", ""ALA"": ")
              else
                  jw.WriteRaw("""ALA"": ")
                  f = true
              end if
              jw.WriteValue(me.ALA)
            end if
            if _IsSetKLINE then
              if f then
                  jw.WriteRaw(", ""KLINE"": ")
              else
                  jw.WriteRaw("""KLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.KLINE)
            end if
            if _ALINEEMP_SUBFORM.value.count > 0 then
              jw.WriteRaw(", ALINEEMP_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as ALINEEMP in _ALINEEMP_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _ALINEEMP_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _TRANSORDER_S_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSORDER_S_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSORDER_S in _TRANSORDER_S_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSORDER_S_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _ALSERNTRANS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", ALSERNTRANS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as ALSERNTRANS in _ALSERNTRANS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _ALSERNTRANS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _OPENSERNUM_SUBFORM.value.count > 0 then
              jw.WriteRaw(", OPENSERNUM_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as OPENSERNUM in _OPENSERNUM_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _OPENSERNUM_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _TRANSORDER_B_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSORDER_B_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSORDER_B in _TRANSORDER_B_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSORDER_B_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _ALINEDEFECTCODES_SUBFORM.value.count > 0 then
              jw.WriteRaw(", ALINEDEFECTCODES_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as ALINEDEFECTCODES in _ALINEDEFECTCODES_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _ALINEDEFECTCODES_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _TRANSLABANALYSES_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSLABANALYSES_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSLABANALYSES in _TRANSLABANALYSES_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSLABANALYSES_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _ALINESIGN_SUBFORM.value.count > 0 then
              jw.WriteRaw(", ALINESIGN_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as ALINESIGN in _ALINESIGN_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _ALINESIGN_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _EXPDEXT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", EXPDEXT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as EXPDEXT in _EXPDEXT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _EXPDEXT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "ALINE")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetSERIALNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SERIALNAME")
              .WriteAttributeString("value", me.SERIALNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "22")
              .WriteEndElement
            end if
            if _IsSetPARTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PARTNAME")
              .WriteAttributeString("value", me.PARTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "15")
              .WriteEndElement
            end if
            if _IsSetACTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ACTNAME")
              .WriteAttributeString("value", me.ACTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetWORKCNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "WORKCNAME")
              .WriteAttributeString("value", me.WORKCNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "6")
              .WriteEndElement
            end if
            if _IsSetUSERID then
              .WriteStartElement("field")
              .WriteAttributeString("name", "USERID")
              .WriteAttributeString("value", me.USERID)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetQUANT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "QUANT")
              .WriteAttributeString("value", me.QUANT)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSQUANT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SQUANT")
              .WriteAttributeString("value", me.SQUANT)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetDEFECTCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DEFECTCODE")
              .WriteAttributeString("value", me.DEFECTCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
            end if
            if _IsSetMQUANT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "MQUANT")
              .WriteAttributeString("value", me.MQUANT)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetTQUANT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TQUANT")
              .WriteAttributeString("value", me.TQUANT)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetTSQUANT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TSQUANT")
              .WriteAttributeString("value", me.TSQUANT)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetTMQUANT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TMQUANT")
              .WriteAttributeString("value", me.TMQUANT)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetNUMPACK then
              .WriteStartElement("field")
              .WriteAttributeString("name", "NUMPACK")
              .WriteAttributeString("value", me.NUMPACK)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetPACKCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PACKCODE")
              .WriteAttributeString("value", me.PACKCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "2")
              .WriteEndElement
            end if
            if _IsSetSTIME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "STIME")
              .WriteAttributeString("value", me.STIME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "5")
              .WriteEndElement
            end if
            if _IsSetETIME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ETIME")
              .WriteAttributeString("value", me.ETIME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "5")
              .WriteEndElement
            end if
            if _IsSetASPAN then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ASPAN")
              .WriteAttributeString("value", me.ASPAN)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "6")
              .WriteEndElement
            end if
            if _IsSetEMPSTIME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EMPSTIME")
              .WriteAttributeString("value", me.EMPSTIME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "5")
              .WriteEndElement
            end if
            if _IsSetEMPETIME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EMPETIME")
              .WriteAttributeString("value", me.EMPETIME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "5")
              .WriteEndElement
            end if
            if _IsSetEMPASPAN then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EMPASPAN")
              .WriteAttributeString("value", me.EMPASPAN)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "6")
              .WriteEndElement
            end if
            if _IsSetSHIFTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SHIFTNAME")
              .WriteAttributeString("value", me.SHIFTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "8")
              .WriteEndElement
            end if
            if _IsSetTOOLNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TOOLNAME")
              .WriteAttributeString("value", me.TOOLNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "15")
              .WriteEndElement
            end if
            if _IsSetRTYPEBOOL then
              .WriteStartElement("field")
              .WriteAttributeString("name", "RTYPEBOOL")
              .WriteAttributeString("value", me.RTYPEBOOL)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetMODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "MODE")
              .WriteAttributeString("value", me.MODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetWARHSNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "WARHSNAME")
              .WriteAttributeString("value", me.WARHSNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "4")
              .WriteEndElement
            end if
            if _IsSetLOCNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "LOCNAME")
              .WriteAttributeString("value", me.LOCNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "14")
              .WriteEndElement
            end if
            if _IsSetNEWPALLET then
              .WriteStartElement("field")
              .WriteAttributeString("name", "NEWPALLET")
              .WriteAttributeString("value", me.NEWPALLET)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetTOPALLETNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TOPALLETNAME")
              .WriteAttributeString("value", me.TOPALLETNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetACTCANCEL then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ACTCANCEL")
              .WriteAttributeString("value", me.ACTCANCEL)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetSERCANCEL then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SERCANCEL")
              .WriteAttributeString("value", me.SERCANCEL)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetALA then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ALA")
              .WriteAttributeString("value", me.ALA)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetKLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", me.KLINE)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _ALINEEMP_SUBFORM.value.count > 0 then
              for each itm as ALINEEMP in _ALINEEMP_SUBFORM.Value
                itm.toXML(xw,"ALINEEMP_SUBFORM")
              next
            end if
            if _TRANSORDER_S_SUBFORM.value.count > 0 then
              for each itm as TRANSORDER_S in _TRANSORDER_S_SUBFORM.Value
                itm.toXML(xw,"TRANSORDER_S_SUBFORM")
              next
            end if
            if _ALSERNTRANS_SUBFORM.value.count > 0 then
              for each itm as ALSERNTRANS in _ALSERNTRANS_SUBFORM.Value
                itm.toXML(xw,"ALSERNTRANS_SUBFORM")
              next
            end if
            if _OPENSERNUM_SUBFORM.value.count > 0 then
              for each itm as OPENSERNUM in _OPENSERNUM_SUBFORM.Value
                itm.toXML(xw,"OPENSERNUM_SUBFORM")
              next
            end if
            if _TRANSORDER_B_SUBFORM.value.count > 0 then
              for each itm as TRANSORDER_B in _TRANSORDER_B_SUBFORM.Value
                itm.toXML(xw,"TRANSORDER_B_SUBFORM")
              next
            end if
            if _ALINEDEFECTCODES_SUBFORM.value.count > 0 then
              for each itm as ALINEDEFECTCODES in _ALINEDEFECTCODES_SUBFORM.Value
                itm.toXML(xw,"ALINEDEFECTCODES_SUBFORM")
              next
            end if
            if _TRANSLABANALYSES_SUBFORM.value.count > 0 then
              for each itm as TRANSLABANALYSES in _TRANSLABANALYSES_SUBFORM.Value
                itm.toXML(xw,"TRANSLABANALYSES_SUBFORM")
              next
            end if
            if _ALINESIGN_SUBFORM.value.count > 0 then
              for each itm as ALINESIGN in _ALINESIGN_SUBFORM.Value
                itm.toXML(xw,"ALINESIGN_SUBFORM")
              next
            end if
            if _EXPDEXT_SUBFORM.value.count > 0 then
              for each itm as EXPDEXT in _EXPDEXT_SUBFORM.Value
                itm.toXML(xw,"EXPDEXT_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ALINE = JsonConvert.DeserializeObject(Of ALINE)(e.StreamReader.ReadToEnd)
                With obj
                  _SERIALNAME = .SERIALNAME
                  _SERQUANT = .SERQUANT
                  _PARTNAME = .PARTNAME
                  _ACTNAME = .ACTNAME
                  _WORKCNAME = .WORKCNAME
                  _USERID = .USERID
                  _BNAME = .BNAME
                  _QUANT = .QUANT
                  _SQUANT = .SQUANT
                  _DEFECTCODE = .DEFECTCODE
                  _DEFECTDESC = .DEFECTDESC
                  _MQUANT = .MQUANT
                  _UNITNAME = .UNITNAME
                  _TQUANT = .TQUANT
                  _TSQUANT = .TSQUANT
                  _TMQUANT = .TMQUANT
                  _TUNITNAME = .TUNITNAME
                  _NUMPACK = .NUMPACK
                  _PACKCODE = .PACKCODE
                  _STIME = .STIME
                  _ETIME = .ETIME
                  _ASPAN = .ASPAN
                  _EMPSTIME = .EMPSTIME
                  _EMPETIME = .EMPETIME
                  _EMPASPAN = .EMPASPAN
                  _SHIFTNAME = .SHIFTNAME
                  _TOOLNAME = .TOOLNAME
                  _RTYPEBOOL = .RTYPEBOOL
                  _MODE = .MODE
                  _WARHSNAME = .WARHSNAME
                  _LOCNAME = .LOCNAME
                  _NEWPALLET = .NEWPALLET
                  _TOPALLETNAME = .TOPALLETNAME
                  _ACTCANCEL = .ACTCANCEL
                  _SERCANCEL = .SERCANCEL
                  _REVNAME = .REVNAME
                  _MSERIALNAME = .MSERIALNAME
                  _VALIDITYEXTENSION = .VALIDITYEXTENSION
                  _ANALYSISVALID = .ANALYSISVALID
                  _ANALYSISNOTVALID = .ANALYSISNOTVALID
                  _ALA = .ALA
                  _KLINE = .KLINE
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_ALINE
        
        ALINEEMP = 0
        
        TRANSORDER_S = 1
        
        ALSERNTRANS = 2
        
        OPENSERNUM = 3
        
        TRANSORDER_B = 4
        
        ALINEDEFECTCODES = 5
        
        TRANSLABANALYSES = 6
        
        ALINESIGN = 7
        
        EXPDEXT = 8
    End Enum
    
    <QueryTitle("Reporting Workers")>  _
    Public Class QUERY_ALINEEMP
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of ALINEEMP)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of ALINEEMP)
            _Parent = nothing
            _Name = "ALINEEMP"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of ALINEEMP)
            _Parent = Parent
            _name = "ALINEEMP_SUBFORM"
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
        
        Public Property Value() As list(of ALINEEMP)
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
                return GetType(ALINEEMP)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _ALINEEMP As ALINEEMP In JsonConvert.DeserializeObject(Of QUERY_ALINEEMP)(stream.ReadToEnd).Value
              With _ALINEEMP
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_ALINEEMP)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ALINEEMP = JsonConvert.DeserializeObject(Of ALINEEMP)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, ALINEEMP)
                  .USERID = obj.USERID
                  .BNAME = obj.BNAME
                  .STIME = obj.STIME
                  .ETIME = obj.ETIME
                  .ASPAN = obj.ASPAN
                  .SHIFTNAME = obj.SHIFTNAME
                  .KLINE = obj.KLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new ALINEEMP(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _ALINEEMP as ALINEEMP in value
              If _ALINEEMP.Equals(trycast(obj,ALINEEMP)) Then
                  value.remove(_ALINEEMP)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class ALINEEMP
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetUSERID As Boolean = Boolean.FalseString
        
        Private _USERID As Long
        
        Private _BNAME As String
        
        Private _IsSetSTIME As Boolean = Boolean.FalseString
        
        Private _STIME As String
        
        Private _IsSetETIME As Boolean = Boolean.FalseString
        
        Private _ETIME As String
        
        Private _IsSetASPAN As Boolean = Boolean.FalseString
        
        Private _ASPAN As String
        
        Private _IsSetSHIFTNAME As Boolean = Boolean.FalseString
        
        Private _SHIFTNAME As String
        
        Private _IsSetKLINE As Boolean = Boolean.FalseString
        
        Private _KLINE As Long
        
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
                    return "ALINEEMP"
                else
                    return "ALINEEMP_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "KLINE={0}", _
                  string.format("{0}",KLINE) _ 
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
        
        <DisplayName("Employee ID"),  _
         nType("Edm.Int64"),  _
         tab("Employee ID"),  _
         Pos(2),  _
         twodBarcode("USERID")>  _
        Public Property USERID() As nullable (of int64)
            Get
                return _USERID
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Employee ID", value, "^[0-9\-]+$") then Exit Property
                _IsSetUSERID = True
                If loading Then
                  _USERID = Value
                Else
                    if not _USERID = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("USERID", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _USERID = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Employee Name"),  _
         nType("Edm.String"),  _
         tab("Employee ID"),  _
         Pos(4),  _
         [ReadOnly](true),  _
         twodBarcode("BNAME")>  _
        Public Property BNAME() As String
            Get
                return _BNAME
            End Get
            Set
                if not(value is nothing) then
                  _BNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Start Labor"),  _
         nType("Edm.String"),  _
         tab("Employee ID"),  _
         Pos(20),  _
         twodBarcode("STIME")>  _
        Public Property STIME() As String
            Get
                return _STIME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Start Labor", value, "^.{0,5}$") then Exit Property
                _IsSetSTIME = True
                If loading Then
                  _STIME = Value
                Else
                    if not _STIME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("STIME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _STIME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("End Labor"),  _
         nType("Edm.String"),  _
         tab("Employee ID"),  _
         Pos(30),  _
         twodBarcode("ETIME")>  _
        Public Property ETIME() As String
            Get
                return _ETIME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("End Labor", value, "^.{0,5}$") then Exit Property
                _IsSetETIME = True
                If loading Then
                  _ETIME = Value
                Else
                    if not _ETIME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ETIME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ETIME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Span"),  _
         nType("Edm.String"),  _
         tab("Employee ID"),  _
         Pos(40),  _
         twodBarcode("ASPAN")>  _
        Public Property ASPAN() As String
            Get
                return _ASPAN
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Span", value, "^.{0,6}$") then Exit Property
                _IsSetASPAN = True
                If loading Then
                  _ASPAN = Value
                Else
                    if not _ASPAN = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ASPAN", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ASPAN = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Shift"),  _
         nType("Edm.String"),  _
         tab("Employee ID"),  _
         Pos(50),  _
         twodBarcode("SHIFTNAME")>  _
        Public Property SHIFTNAME() As String
            Get
                return _SHIFTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Shift", value, "^.{0,8}$") then Exit Property
                _IsSetSHIFTNAME = True
                If loading Then
                  _SHIFTNAME = Value
                Else
                    if not _SHIFTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SHIFTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SHIFTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Employee ID"),  _
         Pos(110),  _
         Browsable(false),  _
         twodBarcode("KLINE")>  _
        Public Property KLINE() As nullable (of int64)
            Get
                return _KLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Key Line", value, "^[0-9\-]+$") then Exit Property
                _IsSetKLINE = True
                If loading Then
                  _KLINE = Value
                Else
                    if not _KLINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("KLINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _KLINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetUSERID then
              if f then
                  jw.WriteRaw(", ""USERID"": ")
              else
                  jw.WriteRaw("""USERID"": ")
                  f = true
              end if
              jw.WriteValue(me.USERID)
            end if
            if _IsSetSTIME then
              if f then
                  jw.WriteRaw(", ""STIME"": ")
              else
                  jw.WriteRaw("""STIME"": ")
                  f = true
              end if
              jw.WriteValue(me.STIME)
            end if
            if _IsSetETIME then
              if f then
                  jw.WriteRaw(", ""ETIME"": ")
              else
                  jw.WriteRaw("""ETIME"": ")
                  f = true
              end if
              jw.WriteValue(me.ETIME)
            end if
            if _IsSetASPAN then
              if f then
                  jw.WriteRaw(", ""ASPAN"": ")
              else
                  jw.WriteRaw("""ASPAN"": ")
                  f = true
              end if
              jw.WriteValue(me.ASPAN)
            end if
            if _IsSetSHIFTNAME then
              if f then
                  jw.WriteRaw(", ""SHIFTNAME"": ")
              else
                  jw.WriteRaw("""SHIFTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SHIFTNAME)
            end if
            if _IsSetKLINE then
              if f then
                  jw.WriteRaw(", ""KLINE"": ")
              else
                  jw.WriteRaw("""KLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.KLINE)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "ALINEEMP")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetUSERID then
              .WriteStartElement("field")
              .WriteAttributeString("name", "USERID")
              .WriteAttributeString("value", me.USERID)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetSTIME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "STIME")
              .WriteAttributeString("value", me.STIME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "5")
              .WriteEndElement
            end if
            if _IsSetETIME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ETIME")
              .WriteAttributeString("value", me.ETIME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "5")
              .WriteEndElement
            end if
            if _IsSetASPAN then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ASPAN")
              .WriteAttributeString("value", me.ASPAN)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "6")
              .WriteEndElement
            end if
            if _IsSetSHIFTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SHIFTNAME")
              .WriteAttributeString("value", me.SHIFTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "8")
              .WriteEndElement
            end if
            if _IsSetKLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", me.KLINE)
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
                dim obj as ALINEEMP = JsonConvert.DeserializeObject(Of ALINEEMP)(e.StreamReader.ReadToEnd)
                With obj
                  _USERID = .USERID
                  _BNAME = .BNAME
                  _STIME = .STIME
                  _ETIME = .ETIME
                  _ASPAN = .ASPAN
                  _SHIFTNAME = .SHIFTNAME
                  _KLINE = .KLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Manual Issues to Work Order")>  _
    Public Class QUERY_TRANSORDER_S
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSORDER_S)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSORDER_S)
            _Parent = nothing
            _Name = "TRANSORDER_S"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Electronic Signature")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSORDER_S)
            _Parent = Parent
            _name = "TRANSORDER_S_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Electronic Signature")
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
        
        Public Property Value() As list(of TRANSORDER_S)
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
                return GetType(TRANSORDER_S)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSORDER_S As TRANSORDER_S In JsonConvert.DeserializeObject(Of QUERY_TRANSORDER_S)(stream.ReadToEnd).Value
              With _TRANSORDER_S
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSORDER_S)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSORDER_S = JsonConvert.DeserializeObject(Of TRANSORDER_S)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSORDER_S)
                  .PARTNAME = obj.PARTNAME
                  .PARTDES = obj.PARTDES
                  .SERIALNAME = obj.SERIALNAME
                  .REVNAME = obj.REVNAME
                  .REVNUM = obj.REVNUM
                  .CUSTNAME = obj.CUSTNAME
                  .SERNUM = obj.SERNUM
                  .QUANT = obj.QUANT
                  .UNITNAME = obj.UNITNAME
                  .ACTNAME = obj.ACTNAME
                  .WARHSNAME = obj.WARHSNAME
                  .LOCNAME = obj.LOCNAME
                  .REWORKFLAG = obj.REWORKFLAG
                  .TRANS = obj.TRANS
                  .TYPE = obj.TYPE
                  .SNTKLINE = obj.SNTKLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new TRANSORDER_S(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSORDER_S as TRANSORDER_S in value
              If _TRANSORDER_S.Equals(trycast(obj,TRANSORDER_S)) Then
                  value.remove(_TRANSORDER_S)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSORDER_S
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetPARTNAME As Boolean = Boolean.FalseString
        
        Private _PARTNAME As String
        
        Private _PARTDES As String
        
        Private _IsSetSERIALNAME As Boolean = Boolean.FalseString
        
        Private _SERIALNAME As String
        
        Private _IsSetREVNAME As Boolean = Boolean.FalseString
        
        Private _REVNAME As String
        
        Private _REVNUM As String
        
        Private _IsSetCUSTNAME As Boolean = Boolean.FalseString
        
        Private _CUSTNAME As String
        
        Private _IsSetSERNUM As Boolean = Boolean.FalseString
        
        Private _SERNUM As String
        
        Private _IsSetQUANT As Boolean = Boolean.FalseString
        
        Private _QUANT As Decimal
        
        Private _UNITNAME As String
        
        Private _IsSetACTNAME As Boolean = Boolean.FalseString
        
        Private _ACTNAME As String
        
        Private _IsSetWARHSNAME As Boolean = Boolean.FalseString
        
        Private _WARHSNAME As String
        
        Private _IsSetLOCNAME As Boolean = Boolean.FalseString
        
        Private _LOCNAME As String
        
        Private _IsSetREWORKFLAG As Boolean = Boolean.FalseString
        
        Private _REWORKFLAG As String
        
        Private _IsSetTRANS As Boolean = Boolean.FalseString
        
        Private _TRANS As Long
        
        Private _IsSetTYPE As Boolean = Boolean.FalseString
        
        Private _TYPE As String
        
        Private _IsSetSNTKLINE As Boolean = Boolean.FalseString
        
        Private _SNTKLINE As Long
        
        Private _TRANSSSIGN_SUBFORM As QUERY_TRANSSSIGN
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Electronic Signature"))
            _TRANSSSIGN_SUBFORM = new QUERY_TRANSSSIGN(me)
            WITH ChildQuery(0)
               .setoDataQuery(_TRANSSSIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Electronic Signature", _TRANSSSIGN_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Electronic Signature"))
            _TRANSSSIGN_SUBFORM = new QUERY_TRANSSSIGN(me)
            WITH ChildQuery(0)
               .setoDataQuery(_TRANSSSIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Electronic Signature", _TRANSSSIGN_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "TRANSORDER_S"
                else
                    return "TRANSORDER_S_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "TYPE={0},SNTKLINE={1}", _
                  string.format("'{0}'",TYPE), _
                  string.format("{0}",SNTKLINE) _ 
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
        
        <DisplayName("Part Number"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(1),  _
         Mandatory(true),  _
         twodBarcode("PARTNAME")>  _
        Public Property PARTNAME() As String
            Get
                return _PARTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Part Number", value, "^.{0,15}$") then Exit Property
                _IsSetPARTNAME = True
                If loading Then
                  _PARTNAME = Value
                Else
                    if not _PARTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PARTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PARTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Part Description"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(2),  _
         [ReadOnly](true),  _
         twodBarcode("PARTDES")>  _
        Public Property PARTDES() As String
            Get
                return _PARTDES
            End Get
            Set
                if not(value is nothing) then
                  _PARTDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Work Order/Lot"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(3),  _
         Mandatory(true),  _
         twodBarcode("SERIALNAME")>  _
        Public Property SERIALNAME() As String
            Get
                return _SERIALNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Work Order/Lot", value, "^.{0,22}$") then Exit Property
                _IsSetSERIALNAME = True
                If loading Then
                  _SERIALNAME = Value
                Else
                    if not _SERIALNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SERIALNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SERIALNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Part Revision No."),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(4),  _
         twodBarcode("REVNAME")>  _
        Public Property REVNAME() As String
            Get
                return _REVNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Part Revision No.", value, "^.{0,10}$") then Exit Property
                _IsSetREVNAME = True
                If loading Then
                  _REVNAME = Value
                Else
                    if not _REVNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("REVNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _REVNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("BOM Revision Number"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(5),  _
         [ReadOnly](true),  _
         twodBarcode("REVNUM")>  _
        Public Property REVNUM() As String
            Get
                return _REVNUM
            End Get
            Set
                if not(value is nothing) then
                  _REVNUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("Status"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(6),  _
         Mandatory(true),  _
         twodBarcode("CUSTNAME")>  _
        Public Property CUSTNAME() As String
            Get
                return _CUSTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Status", value, "^.{0,16}$") then Exit Property
                _IsSetCUSTNAME = True
                If loading Then
                  _CUSTNAME = Value
                Else
                    if not _CUSTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CUSTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CUSTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Serial Number"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(8),  _
         twodBarcode("SERNUM")>  _
        Public Property SERNUM() As String
            Get
                return _SERNUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Serial Number", value, "^.{0,20}$") then Exit Property
                _IsSetSERNUM = True
                If loading Then
                  _SERNUM = Value
                Else
                    if not _SERNUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SERNUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SERNUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Part Number"),  _
         Pos(14),  _
         twodBarcode("QUANT")>  _
        Public Property QUANT() As nullable(of decimal)
            Get
                return _QUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Quantity", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetQUANT = True
                If loading Then
                  _QUANT = Value
                Else
                    if not _QUANT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("QUANT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _QUANT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Unit"),  _
         nType("Edm.String"),  _
         tab("Unit"),  _
         Pos(16),  _
         [ReadOnly](true),  _
         twodBarcode("UNITNAME")>  _
        Public Property UNITNAME() As String
            Get
                return _UNITNAME
            End Get
            Set
                if not(value is nothing) then
                  _UNITNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Operation/Pallet"),  _
         nType("Edm.String"),  _
         tab("Unit"),  _
         Pos(60),  _
         twodBarcode("ACTNAME")>  _
        Public Property ACTNAME() As String
            Get
                return _ACTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Operation/Pallet", value, "^.{0,16}$") then Exit Property
                _IsSetACTNAME = True
                If loading Then
                  _ACTNAME = Value
                Else
                    if not _ACTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ACTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ACTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Warehouse"),  _
         nType("Edm.String"),  _
         tab("Unit"),  _
         Pos(70),  _
         Mandatory(true),  _
         twodBarcode("WARHSNAME")>  _
        Public Property WARHSNAME() As String
            Get
                return _WARHSNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Warehouse", value, "^.{0,4}$") then Exit Property
                _IsSetWARHSNAME = True
                If loading Then
                  _WARHSNAME = Value
                Else
                    if not _WARHSNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("WARHSNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _WARHSNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Bin"),  _
         nType("Edm.String"),  _
         tab("Unit"),  _
         Pos(72),  _
         Mandatory(true),  _
         twodBarcode("LOCNAME")>  _
        Public Property LOCNAME() As String
            Get
                return _LOCNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Bin", value, "^.{0,14}$") then Exit Property
                _IsSetLOCNAME = True
                If loading Then
                  _LOCNAME = Value
                Else
                    if not _LOCNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("LOCNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _LOCNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Rework?"),  _
         nType("Edm.String"),  _
         tab("Unit"),  _
         Pos(80),  _
         twodBarcode("REWORKFLAG")>  _
        Public Property REWORKFLAG() As String
            Get
                return _REWORKFLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Rework?", value, "^.{0,1}$") then Exit Property
                _IsSetREWORKFLAG = True
                If loading Then
                  _REWORKFLAG = Value
                Else
                    if not _REWORKFLAG = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("REWORKFLAG", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _REWORKFLAG = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Transaction (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Unit"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("TRANS")>  _
        Public Property TRANS() As nullable (of int64)
            Get
                return _TRANS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Transaction (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetTRANS = True
                If loading Then
                  _TRANS = Value
                Else
                    if not _TRANS = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TRANS", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TRANS = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Type"),  _
         nType("Edm.String"),  _
         tab("Unit"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("TYPE")>  _
        Public Property TYPE() As String
            Get
                return _TYPE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Type", value, "^.{0,1}$") then Exit Property
                _IsSetTYPE = True
                If loading Then
                  _TYPE = Value
                Else
                    if not _TYPE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TYPE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TYPE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Unit"),  _
         Pos(104),  _
         Browsable(false),  _
         twodBarcode("SNTKLINE")>  _
        Public Property SNTKLINE() As nullable (of int64)
            Get
                return _SNTKLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Key Line", value, "^[0-9\-]+$") then Exit Property
                _IsSetSNTKLINE = True
                If loading Then
                  _SNTKLINE = Value
                Else
                    if not _SNTKLINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SNTKLINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SNTKLINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSSSIGN_SUBFORM() As QUERY_TRANSSSIGN
            Get
                return _TRANSSSIGN_SUBFORM
            End Get
            Set
                _TRANSSSIGN_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetPARTNAME then
              if f then
                  jw.WriteRaw(", ""PARTNAME"": ")
              else
                  jw.WriteRaw("""PARTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.PARTNAME)
            end if
            if _IsSetSERIALNAME then
              if f then
                  jw.WriteRaw(", ""SERIALNAME"": ")
              else
                  jw.WriteRaw("""SERIALNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SERIALNAME)
            end if
            if _IsSetREVNAME then
              if f then
                  jw.WriteRaw(", ""REVNAME"": ")
              else
                  jw.WriteRaw("""REVNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.REVNAME)
            end if
            if _IsSetCUSTNAME then
              if f then
                  jw.WriteRaw(", ""CUSTNAME"": ")
              else
                  jw.WriteRaw("""CUSTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.CUSTNAME)
            end if
            if _IsSetSERNUM then
              if f then
                  jw.WriteRaw(", ""SERNUM"": ")
              else
                  jw.WriteRaw("""SERNUM"": ")
                  f = true
              end if
              jw.WriteValue(me.SERNUM)
            end if
            if _IsSetQUANT then
              if f then
                  jw.WriteRaw(", ""QUANT"": ")
              else
                  jw.WriteRaw("""QUANT"": ")
                  f = true
              end if
              jw.WriteValue(me.QUANT)
            end if
            if _IsSetACTNAME then
              if f then
                  jw.WriteRaw(", ""ACTNAME"": ")
              else
                  jw.WriteRaw("""ACTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.ACTNAME)
            end if
            if _IsSetWARHSNAME then
              if f then
                  jw.WriteRaw(", ""WARHSNAME"": ")
              else
                  jw.WriteRaw("""WARHSNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.WARHSNAME)
            end if
            if _IsSetLOCNAME then
              if f then
                  jw.WriteRaw(", ""LOCNAME"": ")
              else
                  jw.WriteRaw("""LOCNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.LOCNAME)
            end if
            if _IsSetREWORKFLAG then
              if f then
                  jw.WriteRaw(", ""REWORKFLAG"": ")
              else
                  jw.WriteRaw("""REWORKFLAG"": ")
                  f = true
              end if
              jw.WriteValue(me.REWORKFLAG)
            end if
            if _IsSetTRANS then
              if f then
                  jw.WriteRaw(", ""TRANS"": ")
              else
                  jw.WriteRaw("""TRANS"": ")
                  f = true
              end if
              jw.WriteValue(me.TRANS)
            end if
            if _IsSetTYPE then
              if f then
                  jw.WriteRaw(", ""TYPE"": ")
              else
                  jw.WriteRaw("""TYPE"": ")
                  f = true
              end if
              jw.WriteValue(me.TYPE)
            end if
            if _IsSetSNTKLINE then
              if f then
                  jw.WriteRaw(", ""SNTKLINE"": ")
              else
                  jw.WriteRaw("""SNTKLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.SNTKLINE)
            end if
            if _TRANSSSIGN_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSSSIGN_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSSSIGN in _TRANSSSIGN_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSSSIGN_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "TRANSORDER_S")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "TYPE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "SNTKLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetPARTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PARTNAME")
              .WriteAttributeString("value", me.PARTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "15")
              .WriteEndElement
            end if
            if _IsSetSERIALNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SERIALNAME")
              .WriteAttributeString("value", me.SERIALNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "22")
              .WriteEndElement
            end if
            if _IsSetREVNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REVNAME")
              .WriteAttributeString("value", me.REVNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "10")
              .WriteEndElement
            end if
            if _IsSetCUSTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CUSTNAME")
              .WriteAttributeString("value", me.CUSTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetSERNUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SERNUM")
              .WriteAttributeString("value", me.SERNUM)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
              .WriteEndElement
            end if
            if _IsSetQUANT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "QUANT")
              .WriteAttributeString("value", me.QUANT)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetACTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ACTNAME")
              .WriteAttributeString("value", me.ACTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetWARHSNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "WARHSNAME")
              .WriteAttributeString("value", me.WARHSNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "4")
              .WriteEndElement
            end if
            if _IsSetLOCNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "LOCNAME")
              .WriteAttributeString("value", me.LOCNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "14")
              .WriteEndElement
            end if
            if _IsSetREWORKFLAG then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REWORKFLAG")
              .WriteAttributeString("value", me.REWORKFLAG)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetTRANS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TRANS")
              .WriteAttributeString("value", me.TRANS)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetTYPE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TYPE")
              .WriteAttributeString("value", me.TYPE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetSNTKLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SNTKLINE")
              .WriteAttributeString("value", me.SNTKLINE)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _TRANSSSIGN_SUBFORM.value.count > 0 then
              for each itm as TRANSSSIGN in _TRANSSSIGN_SUBFORM.Value
                itm.toXML(xw,"TRANSSSIGN_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSORDER_S = JsonConvert.DeserializeObject(Of TRANSORDER_S)(e.StreamReader.ReadToEnd)
                With obj
                  _PARTNAME = .PARTNAME
                  _PARTDES = .PARTDES
                  _SERIALNAME = .SERIALNAME
                  _REVNAME = .REVNAME
                  _REVNUM = .REVNUM
                  _CUSTNAME = .CUSTNAME
                  _SERNUM = .SERNUM
                  _QUANT = .QUANT
                  _UNITNAME = .UNITNAME
                  _ACTNAME = .ACTNAME
                  _WARHSNAME = .WARHSNAME
                  _LOCNAME = .LOCNAME
                  _REWORKFLAG = .REWORKFLAG
                  _TRANS = .TRANS
                  _TYPE = .TYPE
                  _SNTKLINE = .SNTKLINE
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_TRANSORDER_S
        
        TRANSSSIGN = 0
    End Enum
    
    <QueryTitle("Electronic Signature")>  _
    Public Class QUERY_TRANSSSIGN
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSSSIGN)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSSSIGN)
            _Parent = nothing
            _Name = "TRANSSSIGN"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSSSIGN)
            _Parent = Parent
            _name = "TRANSSSIGN_SUBFORM"
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
        
        Public Property Value() As list(of TRANSSSIGN)
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
                return GetType(TRANSSSIGN)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSSSIGN As TRANSSSIGN In JsonConvert.DeserializeObject(Of QUERY_TRANSSSIGN)(stream.ReadToEnd).Value
              With _TRANSSSIGN
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSSSIGN)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSSSIGN = JsonConvert.DeserializeObject(Of TRANSSSIGN)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSSSIGN)
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .DOC = obj.DOC
                  .KLINE = obj.KLINE
                  .TYPE = obj.TYPE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new TRANSSSIGN(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSSSIGN as TRANSSSIGN in value
              If _TRANSSSIGN.Equals(trycast(obj,TRANSSSIGN)) Then
                  value.remove(_TRANSSSIGN)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSSSIGN
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _DOC As Long
        
        Private _KLINE As Long
        
        Private _TYPE As String
        
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
                    return "TRANSSSIGN"
                else
                    return "TRANSSSIGN_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "DOC={0},KLINE={1},TYPE={2}", _
                  string.format("{0}",DOC), _
                  string.format("{0}",KLINE), _
                  string.format("'{0}'",TYPE) _ 
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
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Signature"),  _
         Pos(1),  _
         [ReadOnly](true),  _
         twodBarcode("USERLOGIN")>  _
        Public Property USERLOGIN() As String
            Get
                return _USERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _USERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Time Stamp"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Signature"),  _
         Pos(2),  _
         [ReadOnly](true),  _
         twodBarcode("UDATE")>  _
        Public Property UDATE() As nullable (of DateTimeOffset)
            Get
                return _UDATE
            End Get
            Set
                if not(value is nothing) then
                  _UDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Document (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Signature"),  _
         Pos(100),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("DOC")>  _
        Public Property DOC() As nullable (of int64)
            Get
                return _DOC
            End Get
            Set
                if not(value is nothing) then
                  _DOC = Value
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Signature"),  _
         Pos(150),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("KLINE")>  _
        Public Property KLINE() As nullable (of int64)
            Get
                return _KLINE
            End Get
            Set
                if not(value is nothing) then
                  _KLINE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Type"),  _
         nType("Edm.String"),  _
         tab("Signature"),  _
         Pos(240),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("TYPE")>  _
        Public Property TYPE() As String
            Get
                return _TYPE
            End Get
            Set
                if not(value is nothing) then
                  _TYPE = Value
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "TRANSSSIGN")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "DOC")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "TYPE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSSSIGN = JsonConvert.DeserializeObject(Of TRANSSSIGN)(e.StreamReader.ReadToEnd)
                With obj
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _DOC = .DOC
                  _KLINE = .KLINE
                  _TYPE = .TYPE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Serial Numbers in Transaction")>  _
    Public Class QUERY_ALSERNTRANS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of ALSERNTRANS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of ALSERNTRANS)
            _Parent = nothing
            _Name = "ALSERNTRANS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Manual Issues to Work Order")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of ALSERNTRANS)
            _Parent = Parent
            _name = "ALSERNTRANS_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Manual Issues to Work Order")
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
        
        Public Property Value() As list(of ALSERNTRANS)
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
                return GetType(ALSERNTRANS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _ALSERNTRANS As ALSERNTRANS In JsonConvert.DeserializeObject(Of QUERY_ALSERNTRANS)(stream.ReadToEnd).Value
              With _ALSERNTRANS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_ALSERNTRANS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ALSERNTRANS = JsonConvert.DeserializeObject(Of ALSERNTRANS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, ALSERNTRANS)
                  .SERNUM = obj.SERNUM
                  .CUSTNAME = obj.CUSTNAME
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .SERN = obj.SERN
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new ALSERNTRANS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _ALSERNTRANS as ALSERNTRANS in value
              If _ALSERNTRANS.Equals(trycast(obj,ALSERNTRANS)) Then
                  value.remove(_ALSERNTRANS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class ALSERNTRANS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetSERNUM As Boolean = Boolean.FalseString
        
        Private _SERNUM As String
        
        Private _IsSetCUSTNAME As Boolean = Boolean.FalseString
        
        Private _CUSTNAME As String
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _IsSetSERN As Boolean = Boolean.FalseString
        
        Private _SERN As Long
        
        Private _TRANSORDER_S_SUBFORM As QUERY_TRANSORDER_S
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Manual Issues to Work Order"))
            _TRANSORDER_S_SUBFORM = new QUERY_TRANSORDER_S(me)
            WITH ChildQuery(0)
               .setoDataQuery(_TRANSORDER_S_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Manual Issues to Work Order"))
            _TRANSORDER_S_SUBFORM = new QUERY_TRANSORDER_S(me)
            WITH ChildQuery(0)
               .setoDataQuery(_TRANSORDER_S_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Manual Issues to Work Order", _TRANSORDER_S_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "ALSERNTRANS"
                else
                    return "ALSERNTRANS_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "SERN={0}", _
                  string.format("{0}",SERN) _ 
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
        
        <DisplayName("Serial Number"),  _
         nType("Edm.String"),  _
         tab("Serial Number"),  _
         Pos(10),  _
         twodBarcode("SERNUM")>  _
        Public Property SERNUM() As String
            Get
                return _SERNUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Serial Number", value, "^.{0,20}$") then Exit Property
                _IsSetSERNUM = True
                If loading Then
                  _SERNUM = Value
                Else
                    if not _SERNUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SERNUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SERNUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("To Status"),  _
         nType("Edm.String"),  _
         tab("Serial Number"),  _
         Pos(20),  _
         Mandatory(true),  _
         twodBarcode("CUSTNAME")>  _
        Public Property CUSTNAME() As String
            Get
                return _CUSTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("To Status", value, "^.{0,16}$") then Exit Property
                _IsSetCUSTNAME = True
                If loading Then
                  _CUSTNAME = Value
                Else
                    if not _CUSTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CUSTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CUSTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Serial Number"),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("USERLOGIN")>  _
        Public Property USERLOGIN() As String
            Get
                return _USERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _USERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Time Stamp"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Serial Number"),  _
         Pos(70),  _
         [ReadOnly](true),  _
         twodBarcode("UDATE")>  _
        Public Property UDATE() As nullable (of DateTimeOffset)
            Get
                return _UDATE
            End Get
            Set
                if not(value is nothing) then
                  _UDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Serial Number (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Serial Number"),  _
         Pos(40),  _
         Browsable(false),  _
         twodBarcode("SERN")>  _
        Public Property SERN() As nullable (of int64)
            Get
                return _SERN
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Serial Number (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetSERN = True
                If loading Then
                  _SERN = Value
                Else
                    if not _SERN = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SERN", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SERN = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSORDER_S_SUBFORM() As QUERY_TRANSORDER_S
            Get
                return _TRANSORDER_S_SUBFORM
            End Get
            Set
                _TRANSORDER_S_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetSERNUM then
              if f then
                  jw.WriteRaw(", ""SERNUM"": ")
              else
                  jw.WriteRaw("""SERNUM"": ")
                  f = true
              end if
              jw.WriteValue(me.SERNUM)
            end if
            if _IsSetCUSTNAME then
              if f then
                  jw.WriteRaw(", ""CUSTNAME"": ")
              else
                  jw.WriteRaw("""CUSTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.CUSTNAME)
            end if
            if _IsSetSERN then
              if f then
                  jw.WriteRaw(", ""SERN"": ")
              else
                  jw.WriteRaw("""SERN"": ")
                  f = true
              end if
              jw.WriteValue(me.SERN)
            end if
            if _TRANSORDER_S_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSORDER_S_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSORDER_S in _TRANSORDER_S_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSORDER_S_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "ALSERNTRANS")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "SERN")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetSERNUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SERNUM")
              .WriteAttributeString("value", me.SERNUM)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
              .WriteEndElement
            end if
            if _IsSetCUSTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CUSTNAME")
              .WriteAttributeString("value", me.CUSTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetSERN then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SERN")
              .WriteAttributeString("value", me.SERN)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _TRANSORDER_S_SUBFORM.value.count > 0 then
              for each itm as TRANSORDER_S in _TRANSORDER_S_SUBFORM.Value
                itm.toXML(xw,"TRANSORDER_S_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ALSERNTRANS = JsonConvert.DeserializeObject(Of ALSERNTRANS)(e.StreamReader.ReadToEnd)
                With obj
                  _SERNUM = .SERNUM
                  _CUSTNAME = .CUSTNAME
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _SERN = .SERN
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_ALSERNTRANS
        
        TRANSORDER_S = 0
    End Enum
    
    <QueryTitle("Manual Issues to Work Order")>  _
    Public Class QUERY_TRANSORDER_S
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSORDER_S)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSORDER_S)
            _Parent = nothing
            _Name = "TRANSORDER_S"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Electronic Signature")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSORDER_S)
            _Parent = Parent
            _name = "TRANSORDER_S_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Electronic Signature")
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
        
        Public Property Value() As list(of TRANSORDER_S)
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
                return GetType(TRANSORDER_S)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSORDER_S As TRANSORDER_S In JsonConvert.DeserializeObject(Of QUERY_TRANSORDER_S)(stream.ReadToEnd).Value
              With _TRANSORDER_S
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSORDER_S)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSORDER_S = JsonConvert.DeserializeObject(Of TRANSORDER_S)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSORDER_S)
                  .PARTNAME = obj.PARTNAME
                  .PARTDES = obj.PARTDES
                  .SERIALNAME = obj.SERIALNAME
                  .REVNAME = obj.REVNAME
                  .REVNUM = obj.REVNUM
                  .CUSTNAME = obj.CUSTNAME
                  .SERNUM = obj.SERNUM
                  .QUANT = obj.QUANT
                  .UNITNAME = obj.UNITNAME
                  .ACTNAME = obj.ACTNAME
                  .WARHSNAME = obj.WARHSNAME
                  .LOCNAME = obj.LOCNAME
                  .REWORKFLAG = obj.REWORKFLAG
                  .TRANS = obj.TRANS
                  .TYPE = obj.TYPE
                  .SNTKLINE = obj.SNTKLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new TRANSORDER_S(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSORDER_S as TRANSORDER_S in value
              If _TRANSORDER_S.Equals(trycast(obj,TRANSORDER_S)) Then
                  value.remove(_TRANSORDER_S)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSORDER_S
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetPARTNAME As Boolean = Boolean.FalseString
        
        Private _PARTNAME As String
        
        Private _PARTDES As String
        
        Private _IsSetSERIALNAME As Boolean = Boolean.FalseString
        
        Private _SERIALNAME As String
        
        Private _IsSetREVNAME As Boolean = Boolean.FalseString
        
        Private _REVNAME As String
        
        Private _REVNUM As String
        
        Private _IsSetCUSTNAME As Boolean = Boolean.FalseString
        
        Private _CUSTNAME As String
        
        Private _IsSetSERNUM As Boolean = Boolean.FalseString
        
        Private _SERNUM As String
        
        Private _IsSetQUANT As Boolean = Boolean.FalseString
        
        Private _QUANT As Decimal
        
        Private _UNITNAME As String
        
        Private _IsSetACTNAME As Boolean = Boolean.FalseString
        
        Private _ACTNAME As String
        
        Private _IsSetWARHSNAME As Boolean = Boolean.FalseString
        
        Private _WARHSNAME As String
        
        Private _IsSetLOCNAME As Boolean = Boolean.FalseString
        
        Private _LOCNAME As String
        
        Private _IsSetREWORKFLAG As Boolean = Boolean.FalseString
        
        Private _REWORKFLAG As String
        
        Private _IsSetTRANS As Boolean = Boolean.FalseString
        
        Private _TRANS As Long
        
        Private _IsSetTYPE As Boolean = Boolean.FalseString
        
        Private _TYPE As String
        
        Private _IsSetSNTKLINE As Boolean = Boolean.FalseString
        
        Private _SNTKLINE As Long
        
        Private _TRANSSSIGN_SUBFORM As QUERY_TRANSSSIGN
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Electronic Signature"))
            _TRANSSSIGN_SUBFORM = new QUERY_TRANSSSIGN(me)
            WITH ChildQuery(0)
               .setoDataQuery(_TRANSSSIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Electronic Signature", _TRANSSSIGN_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Electronic Signature"))
            _TRANSSSIGN_SUBFORM = new QUERY_TRANSSSIGN(me)
            WITH ChildQuery(0)
               .setoDataQuery(_TRANSSSIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Electronic Signature", _TRANSSSIGN_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "TRANSORDER_S"
                else
                    return "TRANSORDER_S_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "TYPE={0},SNTKLINE={1}", _
                  string.format("'{0}'",TYPE), _
                  string.format("{0}",SNTKLINE) _ 
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
        
        <DisplayName("Part Number"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(1),  _
         Mandatory(true),  _
         twodBarcode("PARTNAME")>  _
        Public Property PARTNAME() As String
            Get
                return _PARTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Part Number", value, "^.{0,15}$") then Exit Property
                _IsSetPARTNAME = True
                If loading Then
                  _PARTNAME = Value
                Else
                    if not _PARTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PARTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PARTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Part Description"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(2),  _
         [ReadOnly](true),  _
         twodBarcode("PARTDES")>  _
        Public Property PARTDES() As String
            Get
                return _PARTDES
            End Get
            Set
                if not(value is nothing) then
                  _PARTDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Work Order/Lot"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(3),  _
         Mandatory(true),  _
         twodBarcode("SERIALNAME")>  _
        Public Property SERIALNAME() As String
            Get
                return _SERIALNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Work Order/Lot", value, "^.{0,22}$") then Exit Property
                _IsSetSERIALNAME = True
                If loading Then
                  _SERIALNAME = Value
                Else
                    if not _SERIALNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SERIALNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SERIALNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Part Revision No."),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(4),  _
         twodBarcode("REVNAME")>  _
        Public Property REVNAME() As String
            Get
                return _REVNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Part Revision No.", value, "^.{0,10}$") then Exit Property
                _IsSetREVNAME = True
                If loading Then
                  _REVNAME = Value
                Else
                    if not _REVNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("REVNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _REVNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("BOM Revision Number"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(5),  _
         [ReadOnly](true),  _
         twodBarcode("REVNUM")>  _
        Public Property REVNUM() As String
            Get
                return _REVNUM
            End Get
            Set
                if not(value is nothing) then
                  _REVNUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("Status"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(6),  _
         Mandatory(true),  _
         twodBarcode("CUSTNAME")>  _
        Public Property CUSTNAME() As String
            Get
                return _CUSTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Status", value, "^.{0,16}$") then Exit Property
                _IsSetCUSTNAME = True
                If loading Then
                  _CUSTNAME = Value
                Else
                    if not _CUSTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CUSTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CUSTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Serial Number"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(8),  _
         twodBarcode("SERNUM")>  _
        Public Property SERNUM() As String
            Get
                return _SERNUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Serial Number", value, "^.{0,20}$") then Exit Property
                _IsSetSERNUM = True
                If loading Then
                  _SERNUM = Value
                Else
                    if not _SERNUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SERNUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SERNUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Part Number"),  _
         Pos(14),  _
         twodBarcode("QUANT")>  _
        Public Property QUANT() As nullable(of decimal)
            Get
                return _QUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Quantity", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetQUANT = True
                If loading Then
                  _QUANT = Value
                Else
                    if not _QUANT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("QUANT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _QUANT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Unit"),  _
         nType("Edm.String"),  _
         tab("Unit"),  _
         Pos(16),  _
         [ReadOnly](true),  _
         twodBarcode("UNITNAME")>  _
        Public Property UNITNAME() As String
            Get
                return _UNITNAME
            End Get
            Set
                if not(value is nothing) then
                  _UNITNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Operation/Pallet"),  _
         nType("Edm.String"),  _
         tab("Unit"),  _
         Pos(60),  _
         twodBarcode("ACTNAME")>  _
        Public Property ACTNAME() As String
            Get
                return _ACTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Operation/Pallet", value, "^.{0,16}$") then Exit Property
                _IsSetACTNAME = True
                If loading Then
                  _ACTNAME = Value
                Else
                    if not _ACTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ACTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ACTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Warehouse"),  _
         nType("Edm.String"),  _
         tab("Unit"),  _
         Pos(70),  _
         Mandatory(true),  _
         twodBarcode("WARHSNAME")>  _
        Public Property WARHSNAME() As String
            Get
                return _WARHSNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Warehouse", value, "^.{0,4}$") then Exit Property
                _IsSetWARHSNAME = True
                If loading Then
                  _WARHSNAME = Value
                Else
                    if not _WARHSNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("WARHSNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _WARHSNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Bin"),  _
         nType("Edm.String"),  _
         tab("Unit"),  _
         Pos(72),  _
         Mandatory(true),  _
         twodBarcode("LOCNAME")>  _
        Public Property LOCNAME() As String
            Get
                return _LOCNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Bin", value, "^.{0,14}$") then Exit Property
                _IsSetLOCNAME = True
                If loading Then
                  _LOCNAME = Value
                Else
                    if not _LOCNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("LOCNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _LOCNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Rework?"),  _
         nType("Edm.String"),  _
         tab("Unit"),  _
         Pos(80),  _
         twodBarcode("REWORKFLAG")>  _
        Public Property REWORKFLAG() As String
            Get
                return _REWORKFLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Rework?", value, "^.{0,1}$") then Exit Property
                _IsSetREWORKFLAG = True
                If loading Then
                  _REWORKFLAG = Value
                Else
                    if not _REWORKFLAG = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("REWORKFLAG", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _REWORKFLAG = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Transaction (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Unit"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("TRANS")>  _
        Public Property TRANS() As nullable (of int64)
            Get
                return _TRANS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Transaction (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetTRANS = True
                If loading Then
                  _TRANS = Value
                Else
                    if not _TRANS = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TRANS", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TRANS = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Type"),  _
         nType("Edm.String"),  _
         tab("Unit"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("TYPE")>  _
        Public Property TYPE() As String
            Get
                return _TYPE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Type", value, "^.{0,1}$") then Exit Property
                _IsSetTYPE = True
                If loading Then
                  _TYPE = Value
                Else
                    if not _TYPE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TYPE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TYPE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Unit"),  _
         Pos(104),  _
         Browsable(false),  _
         twodBarcode("SNTKLINE")>  _
        Public Property SNTKLINE() As nullable (of int64)
            Get
                return _SNTKLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Key Line", value, "^[0-9\-]+$") then Exit Property
                _IsSetSNTKLINE = True
                If loading Then
                  _SNTKLINE = Value
                Else
                    if not _SNTKLINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SNTKLINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SNTKLINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSSSIGN_SUBFORM() As QUERY_TRANSSSIGN
            Get
                return _TRANSSSIGN_SUBFORM
            End Get
            Set
                _TRANSSSIGN_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetPARTNAME then
              if f then
                  jw.WriteRaw(", ""PARTNAME"": ")
              else
                  jw.WriteRaw("""PARTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.PARTNAME)
            end if
            if _IsSetSERIALNAME then
              if f then
                  jw.WriteRaw(", ""SERIALNAME"": ")
              else
                  jw.WriteRaw("""SERIALNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SERIALNAME)
            end if
            if _IsSetREVNAME then
              if f then
                  jw.WriteRaw(", ""REVNAME"": ")
              else
                  jw.WriteRaw("""REVNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.REVNAME)
            end if
            if _IsSetCUSTNAME then
              if f then
                  jw.WriteRaw(", ""CUSTNAME"": ")
              else
                  jw.WriteRaw("""CUSTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.CUSTNAME)
            end if
            if _IsSetSERNUM then
              if f then
                  jw.WriteRaw(", ""SERNUM"": ")
              else
                  jw.WriteRaw("""SERNUM"": ")
                  f = true
              end if
              jw.WriteValue(me.SERNUM)
            end if
            if _IsSetQUANT then
              if f then
                  jw.WriteRaw(", ""QUANT"": ")
              else
                  jw.WriteRaw("""QUANT"": ")
                  f = true
              end if
              jw.WriteValue(me.QUANT)
            end if
            if _IsSetACTNAME then
              if f then
                  jw.WriteRaw(", ""ACTNAME"": ")
              else
                  jw.WriteRaw("""ACTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.ACTNAME)
            end if
            if _IsSetWARHSNAME then
              if f then
                  jw.WriteRaw(", ""WARHSNAME"": ")
              else
                  jw.WriteRaw("""WARHSNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.WARHSNAME)
            end if
            if _IsSetLOCNAME then
              if f then
                  jw.WriteRaw(", ""LOCNAME"": ")
              else
                  jw.WriteRaw("""LOCNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.LOCNAME)
            end if
            if _IsSetREWORKFLAG then
              if f then
                  jw.WriteRaw(", ""REWORKFLAG"": ")
              else
                  jw.WriteRaw("""REWORKFLAG"": ")
                  f = true
              end if
              jw.WriteValue(me.REWORKFLAG)
            end if
            if _IsSetTRANS then
              if f then
                  jw.WriteRaw(", ""TRANS"": ")
              else
                  jw.WriteRaw("""TRANS"": ")
                  f = true
              end if
              jw.WriteValue(me.TRANS)
            end if
            if _IsSetTYPE then
              if f then
                  jw.WriteRaw(", ""TYPE"": ")
              else
                  jw.WriteRaw("""TYPE"": ")
                  f = true
              end if
              jw.WriteValue(me.TYPE)
            end if
            if _IsSetSNTKLINE then
              if f then
                  jw.WriteRaw(", ""SNTKLINE"": ")
              else
                  jw.WriteRaw("""SNTKLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.SNTKLINE)
            end if
            if _TRANSSSIGN_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSSSIGN_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSSSIGN in _TRANSSSIGN_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSSSIGN_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "TRANSORDER_S")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "TYPE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "SNTKLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetPARTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PARTNAME")
              .WriteAttributeString("value", me.PARTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "15")
              .WriteEndElement
            end if
            if _IsSetSERIALNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SERIALNAME")
              .WriteAttributeString("value", me.SERIALNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "22")
              .WriteEndElement
            end if
            if _IsSetREVNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REVNAME")
              .WriteAttributeString("value", me.REVNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "10")
              .WriteEndElement
            end if
            if _IsSetCUSTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CUSTNAME")
              .WriteAttributeString("value", me.CUSTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetSERNUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SERNUM")
              .WriteAttributeString("value", me.SERNUM)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
              .WriteEndElement
            end if
            if _IsSetQUANT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "QUANT")
              .WriteAttributeString("value", me.QUANT)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetACTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ACTNAME")
              .WriteAttributeString("value", me.ACTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetWARHSNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "WARHSNAME")
              .WriteAttributeString("value", me.WARHSNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "4")
              .WriteEndElement
            end if
            if _IsSetLOCNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "LOCNAME")
              .WriteAttributeString("value", me.LOCNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "14")
              .WriteEndElement
            end if
            if _IsSetREWORKFLAG then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REWORKFLAG")
              .WriteAttributeString("value", me.REWORKFLAG)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetTRANS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TRANS")
              .WriteAttributeString("value", me.TRANS)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetTYPE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TYPE")
              .WriteAttributeString("value", me.TYPE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetSNTKLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SNTKLINE")
              .WriteAttributeString("value", me.SNTKLINE)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _TRANSSSIGN_SUBFORM.value.count > 0 then
              for each itm as TRANSSSIGN in _TRANSSSIGN_SUBFORM.Value
                itm.toXML(xw,"TRANSSSIGN_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSORDER_S = JsonConvert.DeserializeObject(Of TRANSORDER_S)(e.StreamReader.ReadToEnd)
                With obj
                  _PARTNAME = .PARTNAME
                  _PARTDES = .PARTDES
                  _SERIALNAME = .SERIALNAME
                  _REVNAME = .REVNAME
                  _REVNUM = .REVNUM
                  _CUSTNAME = .CUSTNAME
                  _SERNUM = .SERNUM
                  _QUANT = .QUANT
                  _UNITNAME = .UNITNAME
                  _ACTNAME = .ACTNAME
                  _WARHSNAME = .WARHSNAME
                  _LOCNAME = .LOCNAME
                  _REWORKFLAG = .REWORKFLAG
                  _TRANS = .TRANS
                  _TYPE = .TYPE
                  _SNTKLINE = .SNTKLINE
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_TRANSORDER_S
        
        TRANSSSIGN = 0
    End Enum
    
    <QueryTitle("Electronic Signature")>  _
    Public Class QUERY_TRANSSSIGN
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSSSIGN)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSSSIGN)
            _Parent = nothing
            _Name = "TRANSSSIGN"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSSSIGN)
            _Parent = Parent
            _name = "TRANSSSIGN_SUBFORM"
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
        
        Public Property Value() As list(of TRANSSSIGN)
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
                return GetType(TRANSSSIGN)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSSSIGN As TRANSSSIGN In JsonConvert.DeserializeObject(Of QUERY_TRANSSSIGN)(stream.ReadToEnd).Value
              With _TRANSSSIGN
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSSSIGN)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSSSIGN = JsonConvert.DeserializeObject(Of TRANSSSIGN)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSSSIGN)
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .DOC = obj.DOC
                  .KLINE = obj.KLINE
                  .TYPE = obj.TYPE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new TRANSSSIGN(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSSSIGN as TRANSSSIGN in value
              If _TRANSSSIGN.Equals(trycast(obj,TRANSSSIGN)) Then
                  value.remove(_TRANSSSIGN)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSSSIGN
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _DOC As Long
        
        Private _KLINE As Long
        
        Private _TYPE As String
        
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
                    return "TRANSSSIGN"
                else
                    return "TRANSSSIGN_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "DOC={0},KLINE={1},TYPE={2}", _
                  string.format("{0}",DOC), _
                  string.format("{0}",KLINE), _
                  string.format("'{0}'",TYPE) _ 
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
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Signature"),  _
         Pos(1),  _
         [ReadOnly](true),  _
         twodBarcode("USERLOGIN")>  _
        Public Property USERLOGIN() As String
            Get
                return _USERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _USERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Time Stamp"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Signature"),  _
         Pos(2),  _
         [ReadOnly](true),  _
         twodBarcode("UDATE")>  _
        Public Property UDATE() As nullable (of DateTimeOffset)
            Get
                return _UDATE
            End Get
            Set
                if not(value is nothing) then
                  _UDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Document (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Signature"),  _
         Pos(100),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("DOC")>  _
        Public Property DOC() As nullable (of int64)
            Get
                return _DOC
            End Get
            Set
                if not(value is nothing) then
                  _DOC = Value
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Signature"),  _
         Pos(150),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("KLINE")>  _
        Public Property KLINE() As nullable (of int64)
            Get
                return _KLINE
            End Get
            Set
                if not(value is nothing) then
                  _KLINE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Type"),  _
         nType("Edm.String"),  _
         tab("Signature"),  _
         Pos(240),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("TYPE")>  _
        Public Property TYPE() As String
            Get
                return _TYPE
            End Get
            Set
                if not(value is nothing) then
                  _TYPE = Value
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "TRANSSSIGN")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "DOC")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "TYPE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSSSIGN = JsonConvert.DeserializeObject(Of TRANSSSIGN)(e.StreamReader.ReadToEnd)
                With obj
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _DOC = .DOC
                  _KLINE = .KLINE
                  _TYPE = .TYPE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Auto Recording of Serial Nos.")>  _
    Public Class QUERY_OPENSERNUM
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of OPENSERNUM)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of OPENSERNUM)
            _Parent = nothing
            _Name = "OPENSERNUM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of OPENSERNUM)
            _Parent = Parent
            _name = "OPENSERNUM_SUBFORM"
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
        
        Public Property Value() As list(of OPENSERNUM)
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
                return GetType(OPENSERNUM)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _OPENSERNUM As OPENSERNUM In JsonConvert.DeserializeObject(Of QUERY_OPENSERNUM)(stream.ReadToEnd).Value
              With _OPENSERNUM
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_OPENSERNUM)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as OPENSERNUM = JsonConvert.DeserializeObject(Of OPENSERNUM)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, OPENSERNUM)
                  .OPENFLAG = obj.OPENFLAG
                  .PREFIX = obj.PREFIX
                  .FROMNUMA = obj.FROMNUMA
                  .TONUMA = obj.TONUMA
                  .SIZ = obj.SIZ
                  .USER = obj.USER
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new OPENSERNUM(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _OPENSERNUM as OPENSERNUM in value
              If _OPENSERNUM.Equals(trycast(obj,OPENSERNUM)) Then
                  value.remove(_OPENSERNUM)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class OPENSERNUM
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetOPENFLAG As Boolean = Boolean.FalseString
        
        Private _OPENFLAG As String
        
        Private _IsSetPREFIX As Boolean = Boolean.FalseString
        
        Private _PREFIX As String
        
        Private _IsSetFROMNUMA As Boolean = Boolean.FalseString
        
        Private _FROMNUMA As String
        
        Private _IsSetTONUMA As Boolean = Boolean.FalseString
        
        Private _TONUMA As String
        
        Private _IsSetSIZ As Boolean = Boolean.FalseString
        
        Private _SIZ As Long
        
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
                    return "OPENSERNUM"
                else
                    return "OPENSERNUM_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "USER={0}", _
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
        
        <DisplayName("Open New Serial Nos?"),  _
         nType("Edm.String"),  _
         tab("Open New Serial Nos?"),  _
         Pos(40),  _
         twodBarcode("OPENFLAG")>  _
        Public Property OPENFLAG() As String
            Get
                return _OPENFLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Open New Serial Nos?", value, "^.{0,1}$") then Exit Property
                _IsSetOPENFLAG = True
                If loading Then
                  _OPENFLAG = Value
                Else
                    if not _OPENFLAG = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("OPENFLAG", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _OPENFLAG = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Prefix"),  _
         nType("Edm.String"),  _
         tab("Open New Serial Nos?"),  _
         Pos(50),  _
         twodBarcode("PREFIX")>  _
        Public Property PREFIX() As String
            Get
                return _PREFIX
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Prefix", value, "^.{0,12}$") then Exit Property
                _IsSetPREFIX = True
                If loading Then
                  _PREFIX = Value
                Else
                    if not _PREFIX = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PREFIX", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PREFIX = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("From Serial Number"),  _
         nType("Edm.String"),  _
         tab("Open New Serial Nos?"),  _
         Pos(52),  _
         twodBarcode("FROMNUMA")>  _
        Public Property FROMNUMA() As String
            Get
                return _FROMNUMA
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("From Serial Number", value, "^.{0,8}$") then Exit Property
                _IsSetFROMNUMA = True
                If loading Then
                  _FROMNUMA = Value
                Else
                    if not _FROMNUMA = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FROMNUMA", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FROMNUMA = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("To Serial Number"),  _
         nType("Edm.String"),  _
         tab("Open New Serial Nos?"),  _
         Pos(54),  _
         twodBarcode("TONUMA")>  _
        Public Property TONUMA() As String
            Get
                return _TONUMA
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("To Serial Number", value, "^.{0,8}$") then Exit Property
                _IsSetTONUMA = True
                If loading Then
                  _TONUMA = Value
                Else
                    if not _TONUMA = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TONUMA", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TONUMA = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Serial Number Length"),  _
         nType("Edm.Int64"),  _
         tab("Open New Serial Nos?"),  _
         Pos(60),  _
         twodBarcode("SIZ")>  _
        Public Property SIZ() As nullable (of int64)
            Get
                return _SIZ
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Serial Number Length", value, "^[0-9\-]+$") then Exit Property
                _IsSetSIZ = True
                If loading Then
                  _SIZ = Value
                Else
                    if not _SIZ = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZ", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZ = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("User (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Open New Serial Nos?"),  _
         Pos(40),  _
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
            if _IsSetOPENFLAG then
              if f then
                  jw.WriteRaw(", ""OPENFLAG"": ")
              else
                  jw.WriteRaw("""OPENFLAG"": ")
                  f = true
              end if
              jw.WriteValue(me.OPENFLAG)
            end if
            if _IsSetPREFIX then
              if f then
                  jw.WriteRaw(", ""PREFIX"": ")
              else
                  jw.WriteRaw("""PREFIX"": ")
                  f = true
              end if
              jw.WriteValue(me.PREFIX)
            end if
            if _IsSetFROMNUMA then
              if f then
                  jw.WriteRaw(", ""FROMNUMA"": ")
              else
                  jw.WriteRaw("""FROMNUMA"": ")
                  f = true
              end if
              jw.WriteValue(me.FROMNUMA)
            end if
            if _IsSetTONUMA then
              if f then
                  jw.WriteRaw(", ""TONUMA"": ")
              else
                  jw.WriteRaw("""TONUMA"": ")
                  f = true
              end if
              jw.WriteValue(me.TONUMA)
            end if
            if _IsSetSIZ then
              if f then
                  jw.WriteRaw(", ""SIZ"": ")
              else
                  jw.WriteRaw("""SIZ"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZ)
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
                .WriteAttributeString("name", "OPENSERNUM")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "USER")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetOPENFLAG then
              .WriteStartElement("field")
              .WriteAttributeString("name", "OPENFLAG")
              .WriteAttributeString("value", me.OPENFLAG)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetPREFIX then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PREFIX")
              .WriteAttributeString("value", me.PREFIX)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "12")
              .WriteEndElement
            end if
            if _IsSetFROMNUMA then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FROMNUMA")
              .WriteAttributeString("value", me.FROMNUMA)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "8")
              .WriteEndElement
            end if
            if _IsSetTONUMA then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TONUMA")
              .WriteAttributeString("value", me.TONUMA)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "8")
              .WriteEndElement
            end if
            if _IsSetSIZ then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZ")
              .WriteAttributeString("value", me.SIZ)
              .WriteAttributeString("type", "Edm.Int64")
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
                dim obj as OPENSERNUM = JsonConvert.DeserializeObject(Of OPENSERNUM)(e.StreamReader.ReadToEnd)
                With obj
                  _OPENFLAG = .OPENFLAG
                  _PREFIX = .PREFIX
                  _FROMNUMA = .FROMNUMA
                  _TONUMA = .TONUMA
                  _SIZ = .SIZ
                  _USER = .USER
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Prod. Complete (Warehouse Entry)")>  _
    Public Class QUERY_TRANSORDER_B
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSORDER_B)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSORDER_B)
            _Parent = nothing
            _Name = "TRANSORDER_B"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Electronic Signature")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSORDER_B)
            _Parent = Parent
            _name = "TRANSORDER_B_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Electronic Signature")
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
        
        Public Property Value() As list(of TRANSORDER_B)
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
                return GetType(TRANSORDER_B)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSORDER_B As TRANSORDER_B In JsonConvert.DeserializeObject(Of QUERY_TRANSORDER_B)(stream.ReadToEnd).Value
              With _TRANSORDER_B
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSORDER_B)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSORDER_B = JsonConvert.DeserializeObject(Of TRANSORDER_B)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSORDER_B)
                  .SERIALNAME = obj.SERIALNAME
                  .TOSERIALNAME = obj.TOSERIALNAME
                  .PARTNAME = obj.PARTNAME
                  .REVNAME = obj.REVNAME
                  .REVNUM = obj.REVNUM
                  .ACTNAME = obj.ACTNAME
                  .TOACTNAME = obj.TOACTNAME
                  .CUSTNAME = obj.CUSTNAME
                  .QUANT = obj.QUANT
                  .UNITNAME = obj.UNITNAME
                  .WARHSNAME = obj.WARHSNAME
                  .LOCNAME = obj.LOCNAME
                  .TOWARHSNAME = obj.TOWARHSNAME
                  .TOLOCNAME = obj.TOLOCNAME
                  .KLINE = obj.KLINE
                  .TRANS = obj.TRANS
                  .TYPE = obj.TYPE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new TRANSORDER_B(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSORDER_B as TRANSORDER_B in value
              If _TRANSORDER_B.Equals(trycast(obj,TRANSORDER_B)) Then
                  value.remove(_TRANSORDER_B)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSORDER_B
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _SERIALNAME As String
        
        Private _TOSERIALNAME As String
        
        Private _PARTNAME As String
        
        Private _REVNAME As String
        
        Private _REVNUM As String
        
        Private _ACTNAME As String
        
        Private _TOACTNAME As String
        
        Private _CUSTNAME As String
        
        Private _QUANT As Decimal
        
        Private _UNITNAME As String
        
        Private _WARHSNAME As String
        
        Private _LOCNAME As String
        
        Private _TOWARHSNAME As String
        
        Private _TOLOCNAME As String
        
        Private _KLINE As Long
        
        Private _TRANS As Long
        
        Private _TYPE As String
        
        Private _TRANSBSIGN_SUBFORM As QUERY_TRANSBSIGN
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Electronic Signature"))
            _TRANSBSIGN_SUBFORM = new QUERY_TRANSBSIGN(me)
            WITH ChildQuery(0)
               .setoDataQuery(_TRANSBSIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Electronic Signature", _TRANSBSIGN_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Electronic Signature"))
            _TRANSBSIGN_SUBFORM = new QUERY_TRANSBSIGN(me)
            WITH ChildQuery(0)
               .setoDataQuery(_TRANSBSIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Electronic Signature", _TRANSBSIGN_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "TRANSORDER_B"
                else
                    return "TRANSORDER_B_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "KLINE={0},TYPE={1}", _
                  string.format("{0}",KLINE), _
                  string.format("'{0}'",TYPE) _ 
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
        
        <DisplayName("From Work Order"),  _
         nType("Edm.String"),  _
         tab("From Work Order"),  _
         Pos(1),  _
         [ReadOnly](true),  _
         twodBarcode("SERIALNAME")>  _
        Public Property SERIALNAME() As String
            Get
                return _SERIALNAME
            End Get
            Set
                if not(value is nothing) then
                  _SERIALNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("To Work Order"),  _
         nType("Edm.String"),  _
         tab("From Work Order"),  _
         Pos(2),  _
         [ReadOnly](true),  _
         twodBarcode("TOSERIALNAME")>  _
        Public Property TOSERIALNAME() As String
            Get
                return _TOSERIALNAME
            End Get
            Set
                if not(value is nothing) then
                  _TOSERIALNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Part Number"),  _
         nType("Edm.String"),  _
         tab("From Work Order"),  _
         Pos(3),  _
         [ReadOnly](true),  _
         twodBarcode("PARTNAME")>  _
        Public Property PARTNAME() As String
            Get
                return _PARTNAME
            End Get
            Set
                if not(value is nothing) then
                  _PARTNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Part Revision No."),  _
         nType("Edm.String"),  _
         tab("From Work Order"),  _
         Pos(4),  _
         [ReadOnly](true),  _
         twodBarcode("REVNAME")>  _
        Public Property REVNAME() As String
            Get
                return _REVNAME
            End Get
            Set
                if not(value is nothing) then
                  _REVNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("BOM Revision Number"),  _
         nType("Edm.String"),  _
         tab("From Work Order"),  _
         Pos(5),  _
         [ReadOnly](true),  _
         twodBarcode("REVNUM")>  _
        Public Property REVNUM() As String
            Get
                return _REVNUM
            End Get
            Set
                if not(value is nothing) then
                  _REVNUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("From Operation"),  _
         nType("Edm.String"),  _
         tab("From Work Order"),  _
         Pos(6),  _
         [ReadOnly](true),  _
         twodBarcode("ACTNAME")>  _
        Public Property ACTNAME() As String
            Get
                return _ACTNAME
            End Get
            Set
                if not(value is nothing) then
                  _ACTNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("To Operation"),  _
         nType("Edm.String"),  _
         tab("From Work Order"),  _
         Pos(7),  _
         [ReadOnly](true),  _
         twodBarcode("TOACTNAME")>  _
        Public Property TOACTNAME() As String
            Get
                return _TOACTNAME
            End Get
            Set
                if not(value is nothing) then
                  _TOACTNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Status"),  _
         nType("Edm.String"),  _
         tab("From Work Order"),  _
         Pos(9),  _
         [ReadOnly](true),  _
         twodBarcode("CUSTNAME")>  _
        Public Property CUSTNAME() As String
            Get
                return _CUSTNAME
            End Get
            Set
                if not(value is nothing) then
                  _CUSTNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Quantity"),  _
         Pos(14),  _
         [ReadOnly](true),  _
         twodBarcode("QUANT")>  _
        Public Property QUANT() As nullable(of decimal)
            Get
                return _QUANT
            End Get
            Set
                if not(value is nothing) then
                  _QUANT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Unit"),  _
         nType("Edm.String"),  _
         tab("Quantity"),  _
         Pos(16),  _
         [ReadOnly](true),  _
         twodBarcode("UNITNAME")>  _
        Public Property UNITNAME() As String
            Get
                return _UNITNAME
            End Get
            Set
                if not(value is nothing) then
                  _UNITNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("From Warehouse"),  _
         nType("Edm.String"),  _
         tab("Quantity"),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("WARHSNAME")>  _
        Public Property WARHSNAME() As String
            Get
                return _WARHSNAME
            End Get
            Set
                if not(value is nothing) then
                  _WARHSNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Bin"),  _
         nType("Edm.String"),  _
         tab("Quantity"),  _
         Pos(32),  _
         [ReadOnly](true),  _
         twodBarcode("LOCNAME")>  _
        Public Property LOCNAME() As String
            Get
                return _LOCNAME
            End Get
            Set
                if not(value is nothing) then
                  _LOCNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("To Warehouse"),  _
         nType("Edm.String"),  _
         tab("Quantity"),  _
         Pos(34),  _
         [ReadOnly](true),  _
         twodBarcode("TOWARHSNAME")>  _
        Public Property TOWARHSNAME() As String
            Get
                return _TOWARHSNAME
            End Get
            Set
                if not(value is nothing) then
                  _TOWARHSNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Bin"),  _
         nType("Edm.String"),  _
         tab("Quantity"),  _
         Pos(36),  _
         [ReadOnly](true),  _
         twodBarcode("TOLOCNAME")>  _
        Public Property TOLOCNAME() As String
            Get
                return _TOLOCNAME
            End Get
            Set
                if not(value is nothing) then
                  _TOLOCNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Quantity"),  _
         Pos(99),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("KLINE")>  _
        Public Property KLINE() As nullable (of int64)
            Get
                return _KLINE
            End Get
            Set
                if not(value is nothing) then
                  _KLINE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Transaction (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Quantity"),  _
         Pos(99),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("TRANS")>  _
        Public Property TRANS() As nullable (of int64)
            Get
                return _TRANS
            End Get
            Set
                if not(value is nothing) then
                  _TRANS = Value
                end if
            End Set
        End Property
        
        <DisplayName("Type"),  _
         nType("Edm.String"),  _
         tab("Type"),  _
         Pos(99),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("TYPE")>  _
        Public Property TYPE() As String
            Get
                return _TYPE
            End Get
            Set
                if not(value is nothing) then
                  _TYPE = Value
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSBSIGN_SUBFORM() As QUERY_TRANSBSIGN
            Get
                return _TRANSBSIGN_SUBFORM
            End Get
            Set
                _TRANSBSIGN_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _TRANSBSIGN_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSBSIGN_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSBSIGN in _TRANSBSIGN_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSBSIGN_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "TRANSORDER_B")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "TYPE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            if _TRANSBSIGN_SUBFORM.value.count > 0 then
              for each itm as TRANSBSIGN in _TRANSBSIGN_SUBFORM.Value
                itm.toXML(xw,"TRANSBSIGN_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSORDER_B = JsonConvert.DeserializeObject(Of TRANSORDER_B)(e.StreamReader.ReadToEnd)
                With obj
                  _SERIALNAME = .SERIALNAME
                  _TOSERIALNAME = .TOSERIALNAME
                  _PARTNAME = .PARTNAME
                  _REVNAME = .REVNAME
                  _REVNUM = .REVNUM
                  _ACTNAME = .ACTNAME
                  _TOACTNAME = .TOACTNAME
                  _CUSTNAME = .CUSTNAME
                  _QUANT = .QUANT
                  _UNITNAME = .UNITNAME
                  _WARHSNAME = .WARHSNAME
                  _LOCNAME = .LOCNAME
                  _TOWARHSNAME = .TOWARHSNAME
                  _TOLOCNAME = .TOLOCNAME
                  _KLINE = .KLINE
                  _TRANS = .TRANS
                  _TYPE = .TYPE
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_TRANSORDER_B
        
        TRANSBSIGN = 0
    End Enum
    
    <QueryTitle("Electronic Signature")>  _
    Public Class QUERY_TRANSBSIGN
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSBSIGN)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSBSIGN)
            _Parent = nothing
            _Name = "TRANSBSIGN"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSBSIGN)
            _Parent = Parent
            _name = "TRANSBSIGN_SUBFORM"
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
        
        Public Property Value() As list(of TRANSBSIGN)
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
                return GetType(TRANSBSIGN)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSBSIGN As TRANSBSIGN In JsonConvert.DeserializeObject(Of QUERY_TRANSBSIGN)(stream.ReadToEnd).Value
              With _TRANSBSIGN
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSBSIGN)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSBSIGN = JsonConvert.DeserializeObject(Of TRANSBSIGN)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSBSIGN)
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .DOC = obj.DOC
                  .KLINE = obj.KLINE
                  .TYPE = obj.TYPE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new TRANSBSIGN(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSBSIGN as TRANSBSIGN in value
              If _TRANSBSIGN.Equals(trycast(obj,TRANSBSIGN)) Then
                  value.remove(_TRANSBSIGN)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSBSIGN
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _DOC As Long
        
        Private _KLINE As Long
        
        Private _TYPE As String
        
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
                    return "TRANSBSIGN"
                else
                    return "TRANSBSIGN_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "DOC={0},KLINE={1},TYPE={2}", _
                  string.format("{0}",DOC), _
                  string.format("{0}",KLINE), _
                  string.format("'{0}'",TYPE) _ 
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
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Signature"),  _
         Pos(1),  _
         [ReadOnly](true),  _
         twodBarcode("USERLOGIN")>  _
        Public Property USERLOGIN() As String
            Get
                return _USERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _USERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Time Stamp"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Signature"),  _
         Pos(2),  _
         [ReadOnly](true),  _
         twodBarcode("UDATE")>  _
        Public Property UDATE() As nullable (of DateTimeOffset)
            Get
                return _UDATE
            End Get
            Set
                if not(value is nothing) then
                  _UDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Document (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Signature"),  _
         Pos(100),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("DOC")>  _
        Public Property DOC() As nullable (of int64)
            Get
                return _DOC
            End Get
            Set
                if not(value is nothing) then
                  _DOC = Value
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Signature"),  _
         Pos(150),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("KLINE")>  _
        Public Property KLINE() As nullable (of int64)
            Get
                return _KLINE
            End Get
            Set
                if not(value is nothing) then
                  _KLINE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Type"),  _
         nType("Edm.String"),  _
         tab("Signature"),  _
         Pos(240),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("TYPE")>  _
        Public Property TYPE() As String
            Get
                return _TYPE
            End Get
            Set
                if not(value is nothing) then
                  _TYPE = Value
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "TRANSBSIGN")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "DOC")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "TYPE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSBSIGN = JsonConvert.DeserializeObject(Of TRANSBSIGN)(e.StreamReader.ReadToEnd)
                With obj
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _DOC = .DOC
                  _KLINE = .KLINE
                  _TYPE = .TYPE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Report Defective Parts")>  _
    Public Class QUERY_ALINEDEFECTCODES
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of ALINEDEFECTCODES)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of ALINEDEFECTCODES)
            _Parent = nothing
            _Name = "ALINEDEFECTCODES"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of ALINEDEFECTCODES)
            _Parent = Parent
            _name = "ALINEDEFECTCODES_SUBFORM"
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
        
        Public Property Value() As list(of ALINEDEFECTCODES)
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
                return GetType(ALINEDEFECTCODES)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _ALINEDEFECTCODES As ALINEDEFECTCODES In JsonConvert.DeserializeObject(Of QUERY_ALINEDEFECTCODES)(stream.ReadToEnd).Value
              With _ALINEDEFECTCODES
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_ALINEDEFECTCODES)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ALINEDEFECTCODES = JsonConvert.DeserializeObject(Of ALINEDEFECTCODES)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, ALINEDEFECTCODES)
                  .DEFECTCODE = obj.DEFECTCODE
                  .DEFECTDESC = obj.DEFECTDESC
                  .QUANT = obj.QUANT
                  .UNITNAME = obj.UNITNAME
                  .REMARK = obj.REMARK
                  .DEFECT = obj.DEFECT
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new ALINEDEFECTCODES(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _ALINEDEFECTCODES as ALINEDEFECTCODES in value
              If _ALINEDEFECTCODES.Equals(trycast(obj,ALINEDEFECTCODES)) Then
                  value.remove(_ALINEDEFECTCODES)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class ALINEDEFECTCODES
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetDEFECTCODE As Boolean = Boolean.FalseString
        
        Private _DEFECTCODE As String
        
        Private _DEFECTDESC As String
        
        Private _IsSetQUANT As Boolean = Boolean.FalseString
        
        Private _QUANT As Decimal
        
        Private _UNITNAME As String
        
        Private _IsSetREMARK As Boolean = Boolean.FalseString
        
        Private _REMARK As String
        
        Private _IsSetDEFECT As Boolean = Boolean.FalseString
        
        Private _DEFECT As Long
        
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
                    return "ALINEDEFECTCODES"
                else
                    return "ALINEDEFECTCODES_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "DEFECT={0}", _
                  string.format("{0}",DEFECT) _ 
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
        
        <DisplayName("Defect Code"),  _
         nType("Edm.String"),  _
         tab("Defect Code"),  _
         Pos(10),  _
         twodBarcode("DEFECTCODE")>  _
        Public Property DEFECTCODE() As String
            Get
                return _DEFECTCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Defect Code", value, "^.{0,3}$") then Exit Property
                _IsSetDEFECTCODE = True
                If loading Then
                  _DEFECTCODE = Value
                Else
                    if not _DEFECTCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("DEFECTCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _DEFECTCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Descrip. of Defect"),  _
         nType("Edm.String"),  _
         tab("Defect Code"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("DEFECTDESC")>  _
        Public Property DEFECTDESC() As String
            Get
                return _DEFECTDESC
            End Get
            Set
                if not(value is nothing) then
                  _DEFECTDESC = Value
                end if
            End Set
        End Property
        
        <DisplayName("Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Defect Code"),  _
         Pos(30),  _
         twodBarcode("QUANT")>  _
        Public Property QUANT() As nullable(of decimal)
            Get
                return _QUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Quantity", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetQUANT = True
                If loading Then
                  _QUANT = Value
                Else
                    if not _QUANT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("QUANT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _QUANT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Unit"),  _
         nType("Edm.String"),  _
         tab("Defect Code"),  _
         Pos(35),  _
         [ReadOnly](true),  _
         twodBarcode("UNITNAME")>  _
        Public Property UNITNAME() As String
            Get
                return _UNITNAME
            End Get
            Set
                if not(value is nothing) then
                  _UNITNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Remark"),  _
         nType("Edm.String"),  _
         tab("Defect Code"),  _
         Pos(40),  _
         twodBarcode("REMARK")>  _
        Public Property REMARK() As String
            Get
                return _REMARK
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Remark", value, "^.{0,64}$") then Exit Property
                _IsSetREMARK = True
                If loading Then
                  _REMARK = Value
                Else
                    if not _REMARK = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("REMARK", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _REMARK = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Rejection (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Defect Code"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("DEFECT")>  _
        Public Property DEFECT() As nullable (of int64)
            Get
                return _DEFECT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Rejection (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetDEFECT = True
                If loading Then
                  _DEFECT = Value
                Else
                    if not _DEFECT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("DEFECT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _DEFECT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetDEFECTCODE then
              if f then
                  jw.WriteRaw(", ""DEFECTCODE"": ")
              else
                  jw.WriteRaw("""DEFECTCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.DEFECTCODE)
            end if
            if _IsSetQUANT then
              if f then
                  jw.WriteRaw(", ""QUANT"": ")
              else
                  jw.WriteRaw("""QUANT"": ")
                  f = true
              end if
              jw.WriteValue(me.QUANT)
            end if
            if _IsSetREMARK then
              if f then
                  jw.WriteRaw(", ""REMARK"": ")
              else
                  jw.WriteRaw("""REMARK"": ")
                  f = true
              end if
              jw.WriteValue(me.REMARK)
            end if
            if _IsSetDEFECT then
              if f then
                  jw.WriteRaw(", ""DEFECT"": ")
              else
                  jw.WriteRaw("""DEFECT"": ")
                  f = true
              end if
              jw.WriteValue(me.DEFECT)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "ALINEDEFECTCODES")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "DEFECT")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetDEFECTCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DEFECTCODE")
              .WriteAttributeString("value", me.DEFECTCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
            end if
            if _IsSetQUANT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "QUANT")
              .WriteAttributeString("value", me.QUANT)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetREMARK then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REMARK")
              .WriteAttributeString("value", me.REMARK)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "64")
              .WriteEndElement
            end if
            if _IsSetDEFECT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DEFECT")
              .WriteAttributeString("value", me.DEFECT)
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
                dim obj as ALINEDEFECTCODES = JsonConvert.DeserializeObject(Of ALINEDEFECTCODES)(e.StreamReader.ReadToEnd)
                With obj
                  _DEFECTCODE = .DEFECTCODE
                  _DEFECTDESC = .DEFECTDESC
                  _QUANT = .QUANT
                  _UNITNAME = .UNITNAME
                  _REMARK = .REMARK
                  _DEFECT = .DEFECT
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Analysis Results")>  _
    Public Class QUERY_TRANSLABANALYSES
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSLABANALYSES)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSLABANALYSES)
            _Parent = nothing
            _Name = "TRANSLABANALYSES"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Possible Analysis Results")
            .add(1, "Additional Results")
            .add(2, "Method of Analysis - Text")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSLABANALYSES)
            _Parent = Parent
            _name = "TRANSLABANALYSES_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Possible Analysis Results")
            .add(1, "Additional Results")
            .add(2, "Method of Analysis - Text")
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
        
        Public Property Value() As list(of TRANSLABANALYSES)
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
                return GetType(TRANSLABANALYSES)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSLABANALYSES As TRANSLABANALYSES In JsonConvert.DeserializeObject(Of QUERY_TRANSLABANALYSES)(stream.ReadToEnd).Value
              With _TRANSLABANALYSES
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSLABANALYSES)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSLABANALYSES = JsonConvert.DeserializeObject(Of TRANSLABANALYSES)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSLABANALYSES)
                  .ANALYSISCODE = obj.ANALYSISCODE
                  .ANALYSISDES = obj.ANALYSISDES
                  .METHODNAME = obj.METHODNAME
                  .MINVALUE = obj.MINVALUE
                  .MAXVALUE = obj.MAXVALUE
                  .RESCODE = obj.RESCODE
                  .QRANKCODE = obj.QRANKCODE
                  .VALID = obj.VALID
                  .NOTVALID = obj.NOTVALID
                  .STANDARDDEV = obj.STANDARDDEV
                  .PRINTFLAG = obj.PRINTFLAG
                  .AUTOFLAG = obj.AUTOFLAG
                  .ANALYSIS = obj.ANALYSIS
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new TRANSLABANALYSES(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSLABANALYSES as TRANSLABANALYSES in value
              If _TRANSLABANALYSES.Equals(trycast(obj,TRANSLABANALYSES)) Then
                  value.remove(_TRANSLABANALYSES)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSLABANALYSES
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetANALYSISCODE As Boolean = Boolean.FalseString
        
        Private _ANALYSISCODE As String
        
        Private _ANALYSISDES As String
        
        Private _IsSetMETHODNAME As Boolean = Boolean.FalseString
        
        Private _METHODNAME As String
        
        Private _IsSetMINVALUE As Boolean = Boolean.FalseString
        
        Private _MINVALUE As String
        
        Private _IsSetMAXVALUE As Boolean = Boolean.FalseString
        
        Private _MAXVALUE As String
        
        Private _IsSetRESCODE As Boolean = Boolean.FalseString
        
        Private _RESCODE As String
        
        Private _IsSetQRANKCODE As Boolean = Boolean.FalseString
        
        Private _QRANKCODE As String
        
        Private _VALID As String
        
        Private _NOTVALID As String
        
        Private _STANDARDDEV As String
        
        Private _IsSetPRINTFLAG As Boolean = Boolean.FalseString
        
        Private _PRINTFLAG As String
        
        Private _AUTOFLAG As String
        
        Private _IsSetANALYSIS As Boolean = Boolean.FalseString
        
        Private _ANALYSIS As Long
        
        Private _TRANSANALYSESRESULTS_SUBFORM As QUERY_TRANSANALYSESRESULTS
        
        Private _TRANSANALYSESITEMS_SUBFORM As QUERY_TRANSANALYSESITEMS
        
        Private _TRANSLABANALYSESTEXT_SUBFORM As QUERY_TRANSLABANALYSESTEXT
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Possible Analysis Results"))
            ChildQuery.add(1, new oNavigation("Additional Results"))
            ChildQuery.add(2, new oNavigation("Method of Analysis - Text"))
            _TRANSANALYSESRESULTS_SUBFORM = new QUERY_TRANSANALYSESRESULTS(me)
            _TRANSANALYSESITEMS_SUBFORM = new QUERY_TRANSANALYSESITEMS(me)
            _TRANSLABANALYSESTEXT_SUBFORM = new QUERY_TRANSLABANALYSESTEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_TRANSANALYSESRESULTS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Possible Analysis Results", _TRANSANALYSESRESULTS_SUBFORM))
                   .add(1, new oNavigation("Additional Results", _TRANSANALYSESITEMS_SUBFORM))
                   .add(2, new oNavigation("Method of Analysis - Text", _TRANSLABANALYSESTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_TRANSANALYSESITEMS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Possible Analysis Results", _TRANSANALYSESRESULTS_SUBFORM))
                   .add(1, new oNavigation("Additional Results", _TRANSANALYSESITEMS_SUBFORM))
                   .add(2, new oNavigation("Method of Analysis - Text", _TRANSLABANALYSESTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_TRANSLABANALYSESTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Possible Analysis Results", _TRANSANALYSESRESULTS_SUBFORM))
                   .add(1, new oNavigation("Additional Results", _TRANSANALYSESITEMS_SUBFORM))
                   .add(2, new oNavigation("Method of Analysis - Text", _TRANSLABANALYSESTEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Possible Analysis Results"))
            ChildQuery.add(1, new oNavigation("Additional Results"))
            ChildQuery.add(2, new oNavigation("Method of Analysis - Text"))
            _TRANSANALYSESRESULTS_SUBFORM = new QUERY_TRANSANALYSESRESULTS(me)
            _TRANSANALYSESITEMS_SUBFORM = new QUERY_TRANSANALYSESITEMS(me)
            _TRANSLABANALYSESTEXT_SUBFORM = new QUERY_TRANSLABANALYSESTEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_TRANSANALYSESRESULTS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Possible Analysis Results", _TRANSANALYSESRESULTS_SUBFORM))
                   .add(1, new oNavigation("Additional Results", _TRANSANALYSESITEMS_SUBFORM))
                   .add(2, new oNavigation("Method of Analysis - Text", _TRANSLABANALYSESTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_TRANSANALYSESITEMS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Possible Analysis Results", _TRANSANALYSESRESULTS_SUBFORM))
                   .add(1, new oNavigation("Additional Results", _TRANSANALYSESITEMS_SUBFORM))
                   .add(2, new oNavigation("Method of Analysis - Text", _TRANSLABANALYSESTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_TRANSLABANALYSESTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Possible Analysis Results", _TRANSANALYSESRESULTS_SUBFORM))
                   .add(1, new oNavigation("Additional Results", _TRANSANALYSESITEMS_SUBFORM))
                   .add(2, new oNavigation("Method of Analysis - Text", _TRANSLABANALYSESTEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "TRANSLABANALYSES"
                else
                    return "TRANSLABANALYSES_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "ANALYSIS={0}", _
                  string.format("{0}",ANALYSIS) _ 
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
        
        <DisplayName("Analysis Code"),  _
         nType("Edm.String"),  _
         tab("Analysis Code"),  _
         Pos(10),  _
         Mandatory(true),  _
         twodBarcode("ANALYSISCODE")>  _
        Public Property ANALYSISCODE() As String
            Get
                return _ANALYSISCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Analysis Code", value, "^.{0,10}$") then Exit Property
                _IsSetANALYSISCODE = True
                If loading Then
                  _ANALYSISCODE = Value
                Else
                    if not _ANALYSISCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ANALYSISCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ANALYSISCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Analysis Description"),  _
         nType("Edm.String"),  _
         tab("Analysis Code"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("ANALYSISDES")>  _
        Public Property ANALYSISDES() As String
            Get
                return _ANALYSISDES
            End Get
            Set
                if not(value is nothing) then
                  _ANALYSISDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Method of Analysis"),  _
         nType("Edm.String"),  _
         tab("Analysis Code"),  _
         Pos(25),  _
         twodBarcode("METHODNAME")>  _
        Public Property METHODNAME() As String
            Get
                return _METHODNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Method of Analysis", value, "^.{0,20}$") then Exit Property
                _IsSetMETHODNAME = True
                If loading Then
                  _METHODNAME = Value
                Else
                    if not _METHODNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("METHODNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _METHODNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Minimum Value"),  _
         nType("Edm.String"),  _
         tab("Analysis Code"),  _
         Pos(30),  _
         twodBarcode("MINVALUE")>  _
        Public Property MINVALUE() As String
            Get
                return _MINVALUE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Minimum Value", value, "^.{0,24}$") then Exit Property
                _IsSetMINVALUE = True
                If loading Then
                  _MINVALUE = Value
                Else
                    if not _MINVALUE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("MINVALUE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _MINVALUE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Maximum Value"),  _
         nType("Edm.String"),  _
         tab("Analysis Code"),  _
         Pos(40),  _
         twodBarcode("MAXVALUE")>  _
        Public Property MAXVALUE() As String
            Get
                return _MAXVALUE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Maximum Value", value, "^.{0,24}$") then Exit Property
                _IsSetMAXVALUE = True
                If loading Then
                  _MAXVALUE = Value
                Else
                    if not _MAXVALUE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("MAXVALUE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _MAXVALUE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Result"),  _
         nType("Edm.String"),  _
         tab("Analysis Code"),  _
         Pos(60),  _
         twodBarcode("RESCODE")>  _
        Public Property RESCODE() As String
            Get
                return _RESCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Result", value, "^.{0,24}$") then Exit Property
                _IsSetRESCODE = True
                If loading Then
                  _RESCODE = Value
                Else
                    if not _RESCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("RESCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _RESCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Quality Code"),  _
         nType("Edm.String"),  _
         tab("Analysis Code"),  _
         Pos(65),  _
         twodBarcode("QRANKCODE")>  _
        Public Property QRANKCODE() As String
            Get
                return _QRANKCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Quality Code", value, "^.{0,4}$") then Exit Property
                _IsSetQRANKCODE = True
                If loading Then
                  _QRANKCODE = Value
                Else
                    if not _QRANKCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("QRANKCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _QRANKCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Acceptable?"),  _
         nType("Edm.String"),  _
         tab("Analysis Code"),  _
         Pos(70),  _
         [ReadOnly](true),  _
         twodBarcode("VALID")>  _
        Public Property VALID() As String
            Get
                return _VALID
            End Get
            Set
                if not(value is nothing) then
                  _VALID = Value
                end if
            End Set
        End Property
        
        <DisplayName("Unacceptable?"),  _
         nType("Edm.String"),  _
         tab("Unacceptable?"),  _
         Pos(80),  _
         [ReadOnly](true),  _
         twodBarcode("NOTVALID")>  _
        Public Property NOTVALID() As String
            Get
                return _NOTVALID
            End Get
            Set
                if not(value is nothing) then
                  _NOTVALID = Value
                end if
            End Set
        End Property
        
        <DisplayName("Standard Deviation"),  _
         nType("Edm.String"),  _
         tab("Unacceptable?"),  _
         Pos(85),  _
         [ReadOnly](true),  _
         twodBarcode("STANDARDDEV")>  _
        Public Property STANDARDDEV() As String
            Get
                return _STANDARDDEV
            End Get
            Set
                if not(value is nothing) then
                  _STANDARDDEV = Value
                end if
            End Set
        End Property
        
        <DisplayName("Display in Printout?"),  _
         nType("Edm.String"),  _
         tab("Unacceptable?"),  _
         Pos(90),  _
         twodBarcode("PRINTFLAG")>  _
        Public Property PRINTFLAG() As String
            Get
                return _PRINTFLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Display in Printout?", value, "^.{0,1}$") then Exit Property
                _IsSetPRINTFLAG = True
                If loading Then
                  _PRINTFLAG = Value
                Else
                    if not _PRINTFLAG = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PRINTFLAG", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PRINTFLAG = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Automatic?"),  _
         nType("Edm.String"),  _
         tab("Unacceptable?"),  _
         Pos(100),  _
         [ReadOnly](true),  _
         twodBarcode("AUTOFLAG")>  _
        Public Property AUTOFLAG() As String
            Get
                return _AUTOFLAG
            End Get
            Set
                if not(value is nothing) then
                  _AUTOFLAG = Value
                end if
            End Set
        End Property
        
        <DisplayName("Analysis (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Unacceptable?"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("ANALYSIS")>  _
        Public Property ANALYSIS() As nullable (of int64)
            Get
                return _ANALYSIS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Analysis (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetANALYSIS = True
                If loading Then
                  _ANALYSIS = Value
                Else
                    if not _ANALYSIS = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ANALYSIS", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ANALYSIS = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSANALYSESRESULTS_SUBFORM() As QUERY_TRANSANALYSESRESULTS
            Get
                return _TRANSANALYSESRESULTS_SUBFORM
            End Get
            Set
                _TRANSANALYSESRESULTS_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSANALYSESITEMS_SUBFORM() As QUERY_TRANSANALYSESITEMS
            Get
                return _TRANSANALYSESITEMS_SUBFORM
            End Get
            Set
                _TRANSANALYSESITEMS_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSLABANALYSESTEXT_SUBFORM() As QUERY_TRANSLABANALYSESTEXT
            Get
                return _TRANSLABANALYSESTEXT_SUBFORM
            End Get
            Set
                _TRANSLABANALYSESTEXT_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetANALYSISCODE then
              if f then
                  jw.WriteRaw(", ""ANALYSISCODE"": ")
              else
                  jw.WriteRaw("""ANALYSISCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.ANALYSISCODE)
            end if
            if _IsSetMETHODNAME then
              if f then
                  jw.WriteRaw(", ""METHODNAME"": ")
              else
                  jw.WriteRaw("""METHODNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.METHODNAME)
            end if
            if _IsSetMINVALUE then
              if f then
                  jw.WriteRaw(", ""MINVALUE"": ")
              else
                  jw.WriteRaw("""MINVALUE"": ")
                  f = true
              end if
              jw.WriteValue(me.MINVALUE)
            end if
            if _IsSetMAXVALUE then
              if f then
                  jw.WriteRaw(", ""MAXVALUE"": ")
              else
                  jw.WriteRaw("""MAXVALUE"": ")
                  f = true
              end if
              jw.WriteValue(me.MAXVALUE)
            end if
            if _IsSetRESCODE then
              if f then
                  jw.WriteRaw(", ""RESCODE"": ")
              else
                  jw.WriteRaw("""RESCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.RESCODE)
            end if
            if _IsSetQRANKCODE then
              if f then
                  jw.WriteRaw(", ""QRANKCODE"": ")
              else
                  jw.WriteRaw("""QRANKCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.QRANKCODE)
            end if
            if _IsSetPRINTFLAG then
              if f then
                  jw.WriteRaw(", ""PRINTFLAG"": ")
              else
                  jw.WriteRaw("""PRINTFLAG"": ")
                  f = true
              end if
              jw.WriteValue(me.PRINTFLAG)
            end if
            if _IsSetANALYSIS then
              if f then
                  jw.WriteRaw(", ""ANALYSIS"": ")
              else
                  jw.WriteRaw("""ANALYSIS"": ")
                  f = true
              end if
              jw.WriteValue(me.ANALYSIS)
            end if
            if _TRANSANALYSESRESULTS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSANALYSESRESULTS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSANALYSESRESULTS in _TRANSANALYSESRESULTS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSANALYSESRESULTS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _TRANSANALYSESITEMS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSANALYSESITEMS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSANALYSESITEMS in _TRANSANALYSESITEMS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSANALYSESITEMS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _TRANSLABANALYSESTEXT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSLABANALYSESTEXT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSLABANALYSESTEXT in _TRANSLABANALYSESTEXT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSLABANALYSESTEXT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "TRANSLABANALYSES")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "ANALYSIS")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetANALYSISCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ANALYSISCODE")
              .WriteAttributeString("value", me.ANALYSISCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "10")
              .WriteEndElement
            end if
            if _IsSetMETHODNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "METHODNAME")
              .WriteAttributeString("value", me.METHODNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
              .WriteEndElement
            end if
            if _IsSetMINVALUE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "MINVALUE")
              .WriteAttributeString("value", me.MINVALUE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "24")
              .WriteEndElement
            end if
            if _IsSetMAXVALUE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "MAXVALUE")
              .WriteAttributeString("value", me.MAXVALUE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "24")
              .WriteEndElement
            end if
            if _IsSetRESCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "RESCODE")
              .WriteAttributeString("value", me.RESCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "24")
              .WriteEndElement
            end if
            if _IsSetQRANKCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "QRANKCODE")
              .WriteAttributeString("value", me.QRANKCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "4")
              .WriteEndElement
            end if
            if _IsSetPRINTFLAG then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PRINTFLAG")
              .WriteAttributeString("value", me.PRINTFLAG)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetANALYSIS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ANALYSIS")
              .WriteAttributeString("value", me.ANALYSIS)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _TRANSANALYSESRESULTS_SUBFORM.value.count > 0 then
              for each itm as TRANSANALYSESRESULTS in _TRANSANALYSESRESULTS_SUBFORM.Value
                itm.toXML(xw,"TRANSANALYSESRESULTS_SUBFORM")
              next
            end if
            if _TRANSANALYSESITEMS_SUBFORM.value.count > 0 then
              for each itm as TRANSANALYSESITEMS in _TRANSANALYSESITEMS_SUBFORM.Value
                itm.toXML(xw,"TRANSANALYSESITEMS_SUBFORM")
              next
            end if
            if _TRANSLABANALYSESTEXT_SUBFORM.value.count > 0 then
              for each itm as TRANSLABANALYSESTEXT in _TRANSLABANALYSESTEXT_SUBFORM.Value
                itm.toXML(xw,"TRANSLABANALYSESTEXT_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSLABANALYSES = JsonConvert.DeserializeObject(Of TRANSLABANALYSES)(e.StreamReader.ReadToEnd)
                With obj
                  _ANALYSISCODE = .ANALYSISCODE
                  _ANALYSISDES = .ANALYSISDES
                  _METHODNAME = .METHODNAME
                  _MINVALUE = .MINVALUE
                  _MAXVALUE = .MAXVALUE
                  _RESCODE = .RESCODE
                  _QRANKCODE = .QRANKCODE
                  _VALID = .VALID
                  _NOTVALID = .NOTVALID
                  _STANDARDDEV = .STANDARDDEV
                  _PRINTFLAG = .PRINTFLAG
                  _AUTOFLAG = .AUTOFLAG
                  _ANALYSIS = .ANALYSIS
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_TRANSLABANALYSES
        
        TRANSANALYSESRESULTS = 0
        
        TRANSANALYSESITEMS = 1
        
        TRANSLABANALYSESTEXT = 2
    End Enum
    
    <QueryTitle("Possible Analysis Results")>  _
    Public Class QUERY_TRANSANALYSESRESULTS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSANALYSESRESULTS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSANALYSESRESULTS)
            _Parent = nothing
            _Name = "TRANSANALYSESRESULTS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSANALYSESRESULTS)
            _Parent = Parent
            _name = "TRANSANALYSESRESULTS_SUBFORM"
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
        
        Public Property Value() As list(of TRANSANALYSESRESULTS)
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
                return GetType(TRANSANALYSESRESULTS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSANALYSESRESULTS As TRANSANALYSESRESULTS In JsonConvert.DeserializeObject(Of QUERY_TRANSANALYSESRESULTS)(stream.ReadToEnd).Value
              With _TRANSANALYSESRESULTS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSANALYSESRESULTS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSANALYSESRESULTS = JsonConvert.DeserializeObject(Of TRANSANALYSESRESULTS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSANALYSESRESULTS)
                  .RESCODE = obj.RESCODE
                  .VALID = obj.VALID
                  .NOTVALID = obj.NOTVALID
                  .QRANKCODE = obj.QRANKCODE
                  .FROMVAL = obj.FROMVAL
                  .TOVAL = obj.TOVAL
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new TRANSANALYSESRESULTS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSANALYSESRESULTS as TRANSANALYSESRESULTS in value
              If _TRANSANALYSESRESULTS.Equals(trycast(obj,TRANSANALYSESRESULTS)) Then
                  value.remove(_TRANSANALYSESRESULTS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSANALYSESRESULTS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetRESCODE As Boolean = Boolean.FalseString
        
        Private _RESCODE As String
        
        Private _IsSetVALID As Boolean = Boolean.FalseString
        
        Private _VALID As String
        
        Private _IsSetNOTVALID As Boolean = Boolean.FalseString
        
        Private _NOTVALID As String
        
        Private _IsSetQRANKCODE As Boolean = Boolean.FalseString
        
        Private _QRANKCODE As String
        
        Private _IsSetFROMVAL As Boolean = Boolean.FalseString
        
        Private _FROMVAL As String
        
        Private _IsSetTOVAL As Boolean = Boolean.FalseString
        
        Private _TOVAL As String
        
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
                    return "TRANSANALYSESRESULTS"
                else
                    return "TRANSANALYSESRESULTS_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "RESCODE={0}", _
                  string.format("'{0}'",RESCODE) _ 
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
        
        <DisplayName("Possible Result"),  _
         nType("Edm.String"),  _
         tab("Possible Result"),  _
         Pos(10),  _
         Mandatory(true),  _
         twodBarcode("RESCODE")>  _
        Public Property RESCODE() As String
            Get
                return _RESCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Possible Result", value, "^.{0,24}$") then Exit Property
                _IsSetRESCODE = True
                If loading Then
                  _RESCODE = Value
                Else
                    if not _RESCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("RESCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _RESCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Acceptable?"),  _
         nType("Edm.String"),  _
         tab("Possible Result"),  _
         Pos(20),  _
         twodBarcode("VALID")>  _
        Public Property VALID() As String
            Get
                return _VALID
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Acceptable?", value, "^.{0,1}$") then Exit Property
                _IsSetVALID = True
                If loading Then
                  _VALID = Value
                Else
                    if not _VALID = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("VALID", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _VALID = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Unacceptable?"),  _
         nType("Edm.String"),  _
         tab("Possible Result"),  _
         Pos(30),  _
         twodBarcode("NOTVALID")>  _
        Public Property NOTVALID() As String
            Get
                return _NOTVALID
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Unacceptable?", value, "^.{0,1}$") then Exit Property
                _IsSetNOTVALID = True
                If loading Then
                  _NOTVALID = Value
                Else
                    if not _NOTVALID = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("NOTVALID", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _NOTVALID = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Quality Code"),  _
         nType("Edm.String"),  _
         tab("Possible Result"),  _
         Pos(40),  _
         twodBarcode("QRANKCODE")>  _
        Public Property QRANKCODE() As String
            Get
                return _QRANKCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Quality Code", value, "^.{0,4}$") then Exit Property
                _IsSetQRANKCODE = True
                If loading Then
                  _QRANKCODE = Value
                Else
                    if not _QRANKCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("QRANKCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _QRANKCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Minimum QualityValue"),  _
         nType("Edm.String"),  _
         tab("Possible Result"),  _
         Pos(50),  _
         twodBarcode("FROMVAL")>  _
        Public Property FROMVAL() As String
            Get
                return _FROMVAL
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Minimum QualityValue", value, "^.{0,24}$") then Exit Property
                _IsSetFROMVAL = True
                If loading Then
                  _FROMVAL = Value
                Else
                    if not _FROMVAL = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FROMVAL", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FROMVAL = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Maximum QualityValue"),  _
         nType("Edm.String"),  _
         tab("Possible Result"),  _
         Pos(60),  _
         twodBarcode("TOVAL")>  _
        Public Property TOVAL() As String
            Get
                return _TOVAL
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Maximum QualityValue", value, "^.{0,24}$") then Exit Property
                _IsSetTOVAL = True
                If loading Then
                  _TOVAL = Value
                Else
                    if not _TOVAL = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TOVAL", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TOVAL = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetRESCODE then
              if f then
                  jw.WriteRaw(", ""RESCODE"": ")
              else
                  jw.WriteRaw("""RESCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.RESCODE)
            end if
            if _IsSetVALID then
              if f then
                  jw.WriteRaw(", ""VALID"": ")
              else
                  jw.WriteRaw("""VALID"": ")
                  f = true
              end if
              jw.WriteValue(me.VALID)
            end if
            if _IsSetNOTVALID then
              if f then
                  jw.WriteRaw(", ""NOTVALID"": ")
              else
                  jw.WriteRaw("""NOTVALID"": ")
                  f = true
              end if
              jw.WriteValue(me.NOTVALID)
            end if
            if _IsSetQRANKCODE then
              if f then
                  jw.WriteRaw(", ""QRANKCODE"": ")
              else
                  jw.WriteRaw("""QRANKCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.QRANKCODE)
            end if
            if _IsSetFROMVAL then
              if f then
                  jw.WriteRaw(", ""FROMVAL"": ")
              else
                  jw.WriteRaw("""FROMVAL"": ")
                  f = true
              end if
              jw.WriteValue(me.FROMVAL)
            end if
            if _IsSetTOVAL then
              if f then
                  jw.WriteRaw(", ""TOVAL"": ")
              else
                  jw.WriteRaw("""TOVAL"": ")
                  f = true
              end if
              jw.WriteValue(me.TOVAL)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "TRANSANALYSESRESULTS")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "RESCODE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "24")
              .WriteEndElement
            if _IsSetRESCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "RESCODE")
              .WriteAttributeString("value", me.RESCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "24")
              .WriteEndElement
            end if
            if _IsSetVALID then
              .WriteStartElement("field")
              .WriteAttributeString("name", "VALID")
              .WriteAttributeString("value", me.VALID)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetNOTVALID then
              .WriteStartElement("field")
              .WriteAttributeString("name", "NOTVALID")
              .WriteAttributeString("value", me.NOTVALID)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetQRANKCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "QRANKCODE")
              .WriteAttributeString("value", me.QRANKCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "4")
              .WriteEndElement
            end if
            if _IsSetFROMVAL then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FROMVAL")
              .WriteAttributeString("value", me.FROMVAL)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "24")
              .WriteEndElement
            end if
            if _IsSetTOVAL then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TOVAL")
              .WriteAttributeString("value", me.TOVAL)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "24")
              .WriteEndElement
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSANALYSESRESULTS = JsonConvert.DeserializeObject(Of TRANSANALYSESRESULTS)(e.StreamReader.ReadToEnd)
                With obj
                  _RESCODE = .RESCODE
                  _VALID = .VALID
                  _NOTVALID = .NOTVALID
                  _QRANKCODE = .QRANKCODE
                  _FROMVAL = .FROMVAL
                  _TOVAL = .TOVAL
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Additional Results")>  _
    Public Class QUERY_TRANSANALYSESITEMS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSANALYSESITEMS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSANALYSESITEMS)
            _Parent = nothing
            _Name = "TRANSANALYSESITEMS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSANALYSESITEMS)
            _Parent = Parent
            _name = "TRANSANALYSESITEMS_SUBFORM"
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
        
        Public Property Value() As list(of TRANSANALYSESITEMS)
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
                return GetType(TRANSANALYSESITEMS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSANALYSESITEMS As TRANSANALYSESITEMS In JsonConvert.DeserializeObject(Of QUERY_TRANSANALYSESITEMS)(stream.ReadToEnd).Value
              With _TRANSANALYSESITEMS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSANALYSESITEMS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSANALYSESITEMS = JsonConvert.DeserializeObject(Of TRANSANALYSESITEMS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSANALYSESITEMS)
                  .RESULT = obj.RESULT
                  .KLINE = obj.KLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new TRANSANALYSESITEMS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSANALYSESITEMS as TRANSANALYSESITEMS in value
              If _TRANSANALYSESITEMS.Equals(trycast(obj,TRANSANALYSESITEMS)) Then
                  value.remove(_TRANSANALYSESITEMS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSANALYSESITEMS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetRESULT As Boolean = Boolean.FalseString
        
        Private _RESULT As String
        
        Private _IsSetKLINE As Boolean = Boolean.FalseString
        
        Private _KLINE As Long
        
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
                    return "TRANSANALYSESITEMS"
                else
                    return "TRANSANALYSESITEMS_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "KLINE={0}", _
                  string.format("{0}",KLINE) _ 
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
        
        <DisplayName("Result"),  _
         nType("Edm.String"),  _
         tab("Result"),  _
         Pos(10),  _
         Mandatory(true),  _
         twodBarcode("RESULT")>  _
        Public Property RESULT() As String
            Get
                return _RESULT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Result", value, "^.{0,24}$") then Exit Property
                _IsSetRESULT = True
                If loading Then
                  _RESULT = Value
                Else
                    if not _RESULT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("RESULT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _RESULT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Result"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("KLINE")>  _
        Public Property KLINE() As nullable (of int64)
            Get
                return _KLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Key Line", value, "^[0-9\-]+$") then Exit Property
                _IsSetKLINE = True
                If loading Then
                  _KLINE = Value
                Else
                    if not _KLINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("KLINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _KLINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetRESULT then
              if f then
                  jw.WriteRaw(", ""RESULT"": ")
              else
                  jw.WriteRaw("""RESULT"": ")
                  f = true
              end if
              jw.WriteValue(me.RESULT)
            end if
            if _IsSetKLINE then
              if f then
                  jw.WriteRaw(", ""KLINE"": ")
              else
                  jw.WriteRaw("""KLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.KLINE)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "TRANSANALYSESITEMS")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetRESULT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "RESULT")
              .WriteAttributeString("value", me.RESULT)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "24")
              .WriteEndElement
            end if
            if _IsSetKLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", me.KLINE)
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
                dim obj as TRANSANALYSESITEMS = JsonConvert.DeserializeObject(Of TRANSANALYSESITEMS)(e.StreamReader.ReadToEnd)
                With obj
                  _RESULT = .RESULT
                  _KLINE = .KLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Method of Analysis - Text")>  _
    Public Class QUERY_TRANSLABANALYSESTEXT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSLABANALYSESTEXT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSLABANALYSESTEXT)
            _Parent = nothing
            _Name = "TRANSLABANALYSESTEXT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSLABANALYSESTEXT)
            _Parent = Parent
            _name = "TRANSLABANALYSESTEXT_SUBFORM"
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
        
        Public Property Value() As list(of TRANSLABANALYSESTEXT)
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
                return GetType(TRANSLABANALYSESTEXT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSLABANALYSESTEXT As TRANSLABANALYSESTEXT In JsonConvert.DeserializeObject(Of QUERY_TRANSLABANALYSESTEXT)(stream.ReadToEnd).Value
              With _TRANSLABANALYSESTEXT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSLABANALYSESTEXT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSLABANALYSESTEXT = JsonConvert.DeserializeObject(Of TRANSLABANALYSESTEXT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSLABANALYSESTEXT)
                  .TEXT = obj.TEXT
                  .TEXTLINE = obj.TEXTLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new TRANSLABANALYSESTEXT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSLABANALYSESTEXT as TRANSLABANALYSESTEXT in value
              If _TRANSLABANALYSESTEXT.Equals(trycast(obj,TRANSLABANALYSESTEXT)) Then
                  value.remove(_TRANSLABANALYSESTEXT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSLABANALYSESTEXT
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetTEXT As Boolean = Boolean.FalseString
        
        Private _TEXT As String
        
        Private _IsSetTEXTLINE As Boolean = Boolean.FalseString
        
        Private _TEXTLINE As Long
        
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
                    return "TRANSLABANALYSESTEXT"
                else
                    return "TRANSLABANALYSESTEXT_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "TEXTLINE={0}", _
                  string.format("{0}",TEXTLINE) _ 
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
        
        <DisplayName("Remarks"),  _
         nType("Edm.String"),  _
         tab("Remarks"),  _
         Pos(3),  _
         twodBarcode("TEXT")>  _
        Public Property TEXT() As String
            Get
                return _TEXT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Remarks", value, "^.{0,68}$") then Exit Property
                _IsSetTEXT = True
                If loading Then
                  _TEXT = Value
                Else
                    if not _TEXT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TEXT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TEXT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("TEXTLINE"),  _
         nType("Edm.Int64"),  _
         tab("Remarks"),  _
         Pos(4),  _
         Browsable(false),  _
         twodBarcode("TEXTLINE")>  _
        Public Property TEXTLINE() As nullable (of int64)
            Get
                return _TEXTLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("TEXTLINE", value, "^[0-9\-]+$") then Exit Property
                _IsSetTEXTLINE = True
                If loading Then
                  _TEXTLINE = Value
                Else
                    if not _TEXTLINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TEXTLINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TEXTLINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetTEXT then
              if f then
                  jw.WriteRaw(", ""TEXT"": ")
              else
                  jw.WriteRaw("""TEXT"": ")
                  f = true
              end if
              jw.WriteValue(me.TEXT)
            end if
            if _IsSetTEXTLINE then
              if f then
                  jw.WriteRaw(", ""TEXTLINE"": ")
              else
                  jw.WriteRaw("""TEXTLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.TEXTLINE)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "TRANSLABANALYSESTEXT")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "TEXTLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetTEXT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TEXT")
              .WriteAttributeString("value", me.TEXT)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "68")
              .WriteEndElement
            end if
            if _IsSetTEXTLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TEXTLINE")
              .WriteAttributeString("value", me.TEXTLINE)
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
                dim obj as TRANSLABANALYSESTEXT = JsonConvert.DeserializeObject(Of TRANSLABANALYSESTEXT)(e.StreamReader.ReadToEnd)
                With obj
                  _TEXT = .TEXT
                  _TEXTLINE = .TEXTLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Electronic Signature")>  _
    Public Class QUERY_ALINESIGN
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of ALINESIGN)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of ALINESIGN)
            _Parent = nothing
            _Name = "ALINESIGN"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of ALINESIGN)
            _Parent = Parent
            _name = "ALINESIGN_SUBFORM"
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
        
        Public Property Value() As list(of ALINESIGN)
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
                return GetType(ALINESIGN)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _ALINESIGN As ALINESIGN In JsonConvert.DeserializeObject(Of QUERY_ALINESIGN)(stream.ReadToEnd).Value
              With _ALINESIGN
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_ALINESIGN)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ALINESIGN = JsonConvert.DeserializeObject(Of ALINESIGN)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, ALINESIGN)
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .KLINE = obj.KLINE
                  .FORM = obj.FORM
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new ALINESIGN(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _ALINESIGN as ALINESIGN in value
              If _ALINESIGN.Equals(trycast(obj,ALINESIGN)) Then
                  value.remove(_ALINESIGN)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class ALINESIGN
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _KLINE As Long
        
        Private _FORM As Long
        
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
                    return "ALINESIGN"
                else
                    return "ALINESIGN_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "KLINE={0},FORM={1}", _
                  string.format("{0}",KLINE), _
                  string.format("{0}",FORM) _ 
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
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Signature"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("USERLOGIN")>  _
        Public Property USERLOGIN() As String
            Get
                return _USERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _USERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Time Stamp"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Signature"),  _
         Pos(160),  _
         [ReadOnly](true),  _
         twodBarcode("UDATE")>  _
        Public Property UDATE() As nullable (of DateTimeOffset)
            Get
                return _UDATE
            End Get
            Set
                if not(value is nothing) then
                  _UDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Signature"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("KLINE")>  _
        Public Property KLINE() As nullable (of int64)
            Get
                return _KLINE
            End Get
            Set
                if not(value is nothing) then
                  _KLINE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Form (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Signature"),  _
         Pos(70),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("FORM")>  _
        Public Property FORM() As nullable (of int64)
            Get
                return _FORM
            End Get
            Set
                if not(value is nothing) then
                  _FORM = Value
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "ALINESIGN")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "FORM")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ALINESIGN = JsonConvert.DeserializeObject(Of ALINESIGN)(e.StreamReader.ReadToEnd)
                With obj
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _KLINE = .KLINE
                  _FORM = .FORM
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Expiration Date Extensions")>  _
    Public Class QUERY_EXPDEXT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of EXPDEXT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of EXPDEXT)
            _Parent = nothing
            _Name = "EXPDEXT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of EXPDEXT)
            _Parent = Parent
            _name = "EXPDEXT_SUBFORM"
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
        
        Public Property Value() As list(of EXPDEXT)
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
                return GetType(EXPDEXT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _EXPDEXT As EXPDEXT In JsonConvert.DeserializeObject(Of QUERY_EXPDEXT)(stream.ReadToEnd).Value
              With _EXPDEXT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_EXPDEXT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as EXPDEXT = JsonConvert.DeserializeObject(Of EXPDEXT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, EXPDEXT)
                  .RENEWDATE = obj.RENEWDATE
                  .EXPIRYDATE = obj.EXPIRYDATE
                  .PREVEXPIRYDATE = obj.PREVEXPIRYDATE
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .KLINE = obj.KLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new EXPDEXT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _EXPDEXT as EXPDEXT in value
              If _EXPDEXT.Equals(trycast(obj,EXPDEXT)) Then
                  value.remove(_EXPDEXT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class EXPDEXT
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetRENEWDATE As Boolean = Boolean.FalseString
        
        Private _RENEWDATE As System.DateTimeOffset
        
        Private _IsSetEXPIRYDATE As Boolean = Boolean.FalseString
        
        Private _EXPIRYDATE As System.DateTimeOffset
        
        Private _PREVEXPIRYDATE As System.DateTimeOffset
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _IsSetKLINE As Boolean = Boolean.FalseString
        
        Private _KLINE As Long
        
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
                    return "EXPDEXT"
                else
                    return "EXPDEXT_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "KLINE={0}", _
                  string.format("{0}",KLINE) _ 
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
        
        <DisplayName("Expir. Renewal Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Expir. Renewal Date"),  _
         Pos(10),  _
         Mandatory(true),  _
         twodBarcode("RENEWDATE")>  _
        Public Property RENEWDATE() As nullable (of DateTimeOffset)
            Get
                return _RENEWDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Expir. Renewal Date", value, "^.*$") then Exit Property
                _IsSetRENEWDATE = True
                If loading Then
                  _RENEWDATE = Value
                Else
                    if not _RENEWDATE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("RENEWDATE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _RENEWDATE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("New Expir. Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Expir. Renewal Date"),  _
         Pos(15),  _
         Mandatory(true),  _
         twodBarcode("EXPIRYDATE")>  _
        Public Property EXPIRYDATE() As nullable (of DateTimeOffset)
            Get
                return _EXPIRYDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("New Expir. Date", value, "^.*$") then Exit Property
                _IsSetEXPIRYDATE = True
                If loading Then
                  _EXPIRYDATE = Value
                Else
                    if not _EXPIRYDATE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EXPIRYDATE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EXPIRYDATE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Previous Exp. Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Expir. Renewal Date"),  _
         Pos(17),  _
         [ReadOnly](true),  _
         twodBarcode("PREVEXPIRYDATE")>  _
        Public Property PREVEXPIRYDATE() As nullable (of DateTimeOffset)
            Get
                return _PREVEXPIRYDATE
            End Get
            Set
                if not(value is nothing) then
                  _PREVEXPIRYDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Expir. Renewal Date"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("USERLOGIN")>  _
        Public Property USERLOGIN() As String
            Get
                return _USERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _USERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Time Stamp"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Expir. Renewal Date"),  _
         Pos(22),  _
         [ReadOnly](true),  _
         twodBarcode("UDATE")>  _
        Public Property UDATE() As nullable (of DateTimeOffset)
            Get
                return _UDATE
            End Get
            Set
                if not(value is nothing) then
                  _UDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Expir. Renewal Date"),  _
         Pos(20),  _
         Browsable(false),  _
         twodBarcode("KLINE")>  _
        Public Property KLINE() As nullable (of int64)
            Get
                return _KLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Key Line", value, "^[0-9\-]+$") then Exit Property
                _IsSetKLINE = True
                If loading Then
                  _KLINE = Value
                Else
                    if not _KLINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("KLINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _KLINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetRENEWDATE then
              if f then
                  jw.WriteRaw(", ""RENEWDATE"": ")
              else
                  jw.WriteRaw("""RENEWDATE"": ")
                  f = true
              end if
              jw.WriteValue(me.RENEWDATE)
            end if
            if _IsSetEXPIRYDATE then
              if f then
                  jw.WriteRaw(", ""EXPIRYDATE"": ")
              else
                  jw.WriteRaw("""EXPIRYDATE"": ")
                  f = true
              end if
              jw.WriteValue(me.EXPIRYDATE)
            end if
            if _IsSetKLINE then
              if f then
                  jw.WriteRaw(", ""KLINE"": ")
              else
                  jw.WriteRaw("""KLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.KLINE)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "EXPDEXT")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetRENEWDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "RENEWDATE")
              .WriteAttributeString("value", me.RENEWDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetEXPIRYDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EXPIRYDATE")
              .WriteAttributeString("value", me.EXPIRYDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetKLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", me.KLINE)
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
                dim obj as EXPDEXT = JsonConvert.DeserializeObject(Of EXPDEXT)(e.StreamReader.ReadToEnd)
                With obj
                  _RENEWDATE = .RENEWDATE
                  _EXPIRYDATE = .EXPIRYDATE
                  _PREVEXPIRYDATE = .PREVEXPIRYDATE
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _KLINE = .KLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("List of Styles")>  _
    Public Class QUERY_MATRIXSUM
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of MATRIXSUM)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of MATRIXSUM)
            _Parent = nothing
            _Name = "MATRIXSUM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Assortment")
            .add(1, "Remarks")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of MATRIXSUM)
            _Parent = Parent
            _name = "MATRIXSUM_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Assortment")
            .add(1, "Remarks")
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
        
        Public Property Value() As list(of MATRIXSUM)
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
                return GetType(MATRIXSUM)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _MATRIXSUM As MATRIXSUM In JsonConvert.DeserializeObject(Of QUERY_MATRIXSUM)(stream.ReadToEnd).Value
              With _MATRIXSUM
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_MATRIXSUM)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as MATRIXSUM = JsonConvert.DeserializeObject(Of MATRIXSUM)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, MATRIXSUM)
                  .PARTNAME = obj.PARTNAME
                  .PARTDES = obj.PARTDES
                  .SQUANT = obj.SQUANT
                  .SBARCODE = obj.SBARCODE
                  .XCOLORCODE = obj.XCOLORCODE
                  .XCOLORNAME = obj.XCOLORNAME
                  .DISTRTYPECODE = obj.DISTRTYPECODE
                  .DISTRTYPEDES = obj.DISTRTYPEDES
                  .XQUANT = obj.XQUANT
                  .NUMPACK = obj.NUMPACK
                  .TOTQUANT = obj.TOTQUANT
                  .DUEDATE = obj.DUEDATE
                  .ACTNAME = obj.ACTNAME
                  .ACTDES = obj.ACTDES
                  .SERIALNAME = obj.SERIALNAME
                  .CUSTNAME = obj.CUSTNAME
                  .TOCUSTNAME = obj.TOCUSTNAME
                  .PRICE = obj.PRICE
                  .CURCODE = obj.CURCODE
                  .PRSOURCENAME = obj.PRSOURCENAME
                  .PERCENT = obj.PERCENT
                  .KLINE = obj.KLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new MATRIXSUM(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _MATRIXSUM as MATRIXSUM in value
              If _MATRIXSUM.Equals(trycast(obj,MATRIXSUM)) Then
                  value.remove(_MATRIXSUM)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class MATRIXSUM
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetPARTNAME As Boolean = Boolean.FalseString
        
        Private _PARTNAME As String
        
        Private _PARTDES As String
        
        Private _IsSetSQUANT As Boolean = Boolean.FalseString
        
        Private _SQUANT As Long
        
        Private _IsSetSBARCODE As Boolean = Boolean.FalseString
        
        Private _SBARCODE As String
        
        Private _IsSetXCOLORCODE As Boolean = Boolean.FalseString
        
        Private _XCOLORCODE As String
        
        Private _XCOLORNAME As String
        
        Private _IsSetDISTRTYPECODE As Boolean = Boolean.FalseString
        
        Private _DISTRTYPECODE As String
        
        Private _DISTRTYPEDES As String
        
        Private _XQUANT As Decimal
        
        Private _IsSetNUMPACK As Boolean = Boolean.FalseString
        
        Private _NUMPACK As Long
        
        Private _TOTQUANT As Decimal
        
        Private _IsSetDUEDATE As Boolean = Boolean.FalseString
        
        Private _DUEDATE As System.DateTimeOffset
        
        Private _IsSetACTNAME As Boolean = Boolean.FalseString
        
        Private _ACTNAME As String
        
        Private _ACTDES As String
        
        Private _IsSetSERIALNAME As Boolean = Boolean.FalseString
        
        Private _SERIALNAME As String
        
        Private _IsSetCUSTNAME As Boolean = Boolean.FalseString
        
        Private _CUSTNAME As String
        
        Private _IsSetTOCUSTNAME As Boolean = Boolean.FalseString
        
        Private _TOCUSTNAME As String
        
        Private _IsSetPRICE As Boolean = Boolean.FalseString
        
        Private _PRICE As Decimal
        
        Private _IsSetCURCODE As Boolean = Boolean.FalseString
        
        Private _CURCODE As String
        
        Private _PRSOURCENAME As String
        
        Private _IsSetPERCENT As Boolean = Boolean.FalseString
        
        Private _PERCENT As Decimal
        
        Private _IsSetKLINE As Boolean = Boolean.FalseString
        
        Private _KLINE As Long
        
        Private _MATRIX_SUBFORM As QUERY_MATRIX
        
        Private _MATRIXSUMTEXT_SUBFORM As QUERY_MATRIXSUMTEXT
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Assortment"))
            ChildQuery.add(1, new oNavigation("Remarks"))
            _MATRIX_SUBFORM = new QUERY_MATRIX(me)
            _MATRIXSUMTEXT_SUBFORM = new QUERY_MATRIXSUMTEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_MATRIX_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Assortment", _MATRIX_SUBFORM))
                   .add(1, new oNavigation("Remarks", _MATRIXSUMTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_MATRIXSUMTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Assortment", _MATRIX_SUBFORM))
                   .add(1, new oNavigation("Remarks", _MATRIXSUMTEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Assortment"))
            ChildQuery.add(1, new oNavigation("Remarks"))
            _MATRIX_SUBFORM = new QUERY_MATRIX(me)
            _MATRIXSUMTEXT_SUBFORM = new QUERY_MATRIXSUMTEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_MATRIX_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Assortment", _MATRIX_SUBFORM))
                   .add(1, new oNavigation("Remarks", _MATRIXSUMTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_MATRIXSUMTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Assortment", _MATRIX_SUBFORM))
                   .add(1, new oNavigation("Remarks", _MATRIXSUMTEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "MATRIXSUM"
                else
                    return "MATRIXSUM_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "KLINE={0}", _
                  string.format("{0}",KLINE) _ 
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
        
        <DisplayName("Base Product No."),  _
         nType("Edm.String"),  _
         tab("Base Product No."),  _
         Pos(10),  _
         Mandatory(true),  _
         twodBarcode("PARTNAME")>  _
        Public Property PARTNAME() As String
            Get
                return _PARTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Base Product No.", value, "^.{0,15}$") then Exit Property
                _IsSetPARTNAME = True
                If loading Then
                  _PARTNAME = Value
                Else
                    if not _PARTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PARTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PARTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Base Product Desc."),  _
         nType("Edm.String"),  _
         tab("Base Product No."),  _
         Pos(12),  _
         [ReadOnly](true),  _
         twodBarcode("PARTDES")>  _
        Public Property PARTDES() As String
            Get
                return _PARTDES
            End Get
            Set
                if not(value is nothing) then
                  _PARTDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Manual Quantity"),  _
         nType("Edm.Int64"),  _
         tab("Base Product No."),  _
         Pos(13),  _
         twodBarcode("SQUANT")>  _
        Public Property SQUANT() As nullable (of int64)
            Get
                return _SQUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Manual Quantity", value, "^[0-9\-]+$") then Exit Property
                _IsSetSQUANT = True
                If loading Then
                  _SQUANT = Value
                Else
                    if not _SQUANT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SQUANT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SQUANT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Bar Code/Manual"),  _
         nType("Edm.String"),  _
         tab("Base Product No."),  _
         Pos(14),  _
         twodBarcode("SBARCODE")>  _
        Public Property SBARCODE() As String
            Get
                return _SBARCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Bar Code/Manual", value, "^.{0,16}$") then Exit Property
                _IsSetSBARCODE = True
                If loading Then
                  _SBARCODE = Value
                Else
                    if not _SBARCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SBARCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SBARCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Color Code"),  _
         nType("Edm.String"),  _
         tab("Base Product No."),  _
         Pos(15),  _
         twodBarcode("XCOLORCODE")>  _
        Public Property XCOLORCODE() As String
            Get
                return _XCOLORCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Color Code", value, "^.{0,2}$") then Exit Property
                _IsSetXCOLORCODE = True
                If loading Then
                  _XCOLORCODE = Value
                Else
                    if not _XCOLORCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("XCOLORCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _XCOLORCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Color Name"),  _
         nType("Edm.String"),  _
         tab("Base Product No."),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("XCOLORNAME")>  _
        Public Property XCOLORNAME() As String
            Get
                return _XCOLORNAME
            End Get
            Set
                if not(value is nothing) then
                  _XCOLORNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Distribution Type"),  _
         nType("Edm.String"),  _
         tab("Base Product No."),  _
         Pos(30),  _
         twodBarcode("DISTRTYPECODE")>  _
        Public Property DISTRTYPECODE() As String
            Get
                return _DISTRTYPECODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Distribution Type", value, "^.{0,3}$") then Exit Property
                _IsSetDISTRTYPECODE = True
                If loading Then
                  _DISTRTYPECODE = Value
                Else
                    if not _DISTRTYPECODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("DISTRTYPECODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _DISTRTYPECODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Distrib. Type Desc."),  _
         nType("Edm.String"),  _
         tab("Base Product No."),  _
         Pos(35),  _
         [ReadOnly](true),  _
         twodBarcode("DISTRTYPEDES")>  _
        Public Property DISTRTYPEDES() As String
            Get
                return _DISTRTYPEDES
            End Get
            Set
                if not(value is nothing) then
                  _DISTRTYPEDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Qty in Assortment"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Qty in Assortment"),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("XQUANT")>  _
        Public Property XQUANT() As nullable(of decimal)
            Get
                return _XQUANT
            End Get
            Set
                if not(value is nothing) then
                  _XQUANT = Value
                end if
            End Set
        End Property
        
        <DisplayName("No. Assortments"),  _
         nType("Edm.Int64"),  _
         tab("Qty in Assortment"),  _
         Pos(42),  _
         twodBarcode("NUMPACK")>  _
        Public Property NUMPACK() As nullable (of int64)
            Get
                return _NUMPACK
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("No. Assortments", value, "^[0-9\-]+$") then Exit Property
                _IsSetNUMPACK = True
                If loading Then
                  _NUMPACK = Value
                Else
                    if not _NUMPACK = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("NUMPACK", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _NUMPACK = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Total Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Qty in Assortment"),  _
         Pos(44),  _
         [ReadOnly](true),  _
         twodBarcode("TOTQUANT")>  _
        Public Property TOTQUANT() As nullable(of decimal)
            Get
                return _TOTQUANT
            End Get
            Set
                if not(value is nothing) then
                  _TOTQUANT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Due Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Qty in Assortment"),  _
         Pos(46),  _
         twodBarcode("DUEDATE")>  _
        Public Property DUEDATE() As nullable (of DateTimeOffset)
            Get
                return _DUEDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Due Date", value, "^.*$") then Exit Property
                _IsSetDUEDATE = True
                If loading Then
                  _DUEDATE = Value
                Else
                    if not _DUEDATE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("DUEDATE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _DUEDATE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Operation"),  _
         nType("Edm.String"),  _
         tab("Qty in Assortment"),  _
         Pos(50),  _
         twodBarcode("ACTNAME")>  _
        Public Property ACTNAME() As String
            Get
                return _ACTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Operation", value, "^.{0,16}$") then Exit Property
                _IsSetACTNAME = True
                If loading Then
                  _ACTNAME = Value
                Else
                    if not _ACTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ACTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ACTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Operation Descrip."),  _
         nType("Edm.String"),  _
         tab("Qty in Assortment"),  _
         Pos(52),  _
         [ReadOnly](true),  _
         twodBarcode("ACTDES")>  _
        Public Property ACTDES() As String
            Get
                return _ACTDES
            End Get
            Set
                if not(value is nothing) then
                  _ACTDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Work Order"),  _
         nType("Edm.String"),  _
         tab("Qty in Assortment"),  _
         Pos(60),  _
         twodBarcode("SERIALNAME")>  _
        Public Property SERIALNAME() As String
            Get
                return _SERIALNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Work Order", value, "^.{0,22}$") then Exit Property
                _IsSetSERIALNAME = True
                If loading Then
                  _SERIALNAME = Value
                Else
                    if not _SERIALNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SERIALNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SERIALNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Status"),  _
         nType("Edm.String"),  _
         tab("Qty in Assortment"),  _
         Pos(65),  _
         twodBarcode("CUSTNAME")>  _
        Public Property CUSTNAME() As String
            Get
                return _CUSTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Status", value, "^.{0,16}$") then Exit Property
                _IsSetCUSTNAME = True
                If loading Then
                  _CUSTNAME = Value
                Else
                    if not _CUSTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CUSTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CUSTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Status"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(70),  _
         twodBarcode("TOCUSTNAME")>  _
        Public Property TOCUSTNAME() As String
            Get
                return _TOCUSTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Status", value, "^.{0,16}$") then Exit Property
                _IsSetTOCUSTNAME = True
                If loading Then
                  _TOCUSTNAME = Value
                Else
                    if not _TOCUSTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TOCUSTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TOCUSTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Unit Price"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(16),  _
         tab("Status"),  _
         Pos(80),  _
         twodBarcode("PRICE")>  _
        Public Property PRICE() As nullable(of decimal)
            Get
                return _PRICE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Unit Price", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetPRICE = True
                If loading Then
                  _PRICE = Value
                Else
                    if not _PRICE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PRICE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PRICE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Curr"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(85),  _
         twodBarcode("CURCODE")>  _
        Public Property CURCODE() As String
            Get
                return _CURCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Curr", value, "^.{0,3}$") then Exit Property
                _IsSetCURCODE = True
                If loading Then
                  _CURCODE = Value
                Else
                    if not _CURCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CURCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CURCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Price Source"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(90),  _
         [ReadOnly](true),  _
         twodBarcode("PRSOURCENAME")>  _
        Public Property PRSOURCENAME() As String
            Get
                return _PRSOURCENAME
            End Get
            Set
                if not(value is nothing) then
                  _PRSOURCENAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Discount(%)"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(16),  _
         tab("Status"),  _
         Pos(100),  _
         twodBarcode("PERCENT")>  _
        Public Property PERCENT() As nullable(of decimal)
            Get
                return _PERCENT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Discount(%)", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetPERCENT = True
                If loading Then
                  _PERCENT = Value
                Else
                    if not _PERCENT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PERCENT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PERCENT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Status"),  _
         Pos(20),  _
         Browsable(false),  _
         twodBarcode("KLINE")>  _
        Public Property KLINE() As nullable (of int64)
            Get
                return _KLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Key Line", value, "^[0-9\-]+$") then Exit Property
                _IsSetKLINE = True
                If loading Then
                  _KLINE = Value
                Else
                    if not _KLINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("KLINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _KLINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property MATRIX_SUBFORM() As QUERY_MATRIX
            Get
                return _MATRIX_SUBFORM
            End Get
            Set
                _MATRIX_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property MATRIXSUMTEXT_SUBFORM() As QUERY_MATRIXSUMTEXT
            Get
                return _MATRIXSUMTEXT_SUBFORM
            End Get
            Set
                _MATRIXSUMTEXT_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetPARTNAME then
              if f then
                  jw.WriteRaw(", ""PARTNAME"": ")
              else
                  jw.WriteRaw("""PARTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.PARTNAME)
            end if
            if _IsSetSQUANT then
              if f then
                  jw.WriteRaw(", ""SQUANT"": ")
              else
                  jw.WriteRaw("""SQUANT"": ")
                  f = true
              end if
              jw.WriteValue(me.SQUANT)
            end if
            if _IsSetSBARCODE then
              if f then
                  jw.WriteRaw(", ""SBARCODE"": ")
              else
                  jw.WriteRaw("""SBARCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.SBARCODE)
            end if
            if _IsSetXCOLORCODE then
              if f then
                  jw.WriteRaw(", ""XCOLORCODE"": ")
              else
                  jw.WriteRaw("""XCOLORCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.XCOLORCODE)
            end if
            if _IsSetDISTRTYPECODE then
              if f then
                  jw.WriteRaw(", ""DISTRTYPECODE"": ")
              else
                  jw.WriteRaw("""DISTRTYPECODE"": ")
                  f = true
              end if
              jw.WriteValue(me.DISTRTYPECODE)
            end if
            if _IsSetNUMPACK then
              if f then
                  jw.WriteRaw(", ""NUMPACK"": ")
              else
                  jw.WriteRaw("""NUMPACK"": ")
                  f = true
              end if
              jw.WriteValue(me.NUMPACK)
            end if
            if _IsSetDUEDATE then
              if f then
                  jw.WriteRaw(", ""DUEDATE"": ")
              else
                  jw.WriteRaw("""DUEDATE"": ")
                  f = true
              end if
              jw.WriteValue(me.DUEDATE)
            end if
            if _IsSetACTNAME then
              if f then
                  jw.WriteRaw(", ""ACTNAME"": ")
              else
                  jw.WriteRaw("""ACTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.ACTNAME)
            end if
            if _IsSetSERIALNAME then
              if f then
                  jw.WriteRaw(", ""SERIALNAME"": ")
              else
                  jw.WriteRaw("""SERIALNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SERIALNAME)
            end if
            if _IsSetCUSTNAME then
              if f then
                  jw.WriteRaw(", ""CUSTNAME"": ")
              else
                  jw.WriteRaw("""CUSTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.CUSTNAME)
            end if
            if _IsSetTOCUSTNAME then
              if f then
                  jw.WriteRaw(", ""TOCUSTNAME"": ")
              else
                  jw.WriteRaw("""TOCUSTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.TOCUSTNAME)
            end if
            if _IsSetPRICE then
              if f then
                  jw.WriteRaw(", ""PRICE"": ")
              else
                  jw.WriteRaw("""PRICE"": ")
                  f = true
              end if
              jw.WriteValue(me.PRICE)
            end if
            if _IsSetCURCODE then
              if f then
                  jw.WriteRaw(", ""CURCODE"": ")
              else
                  jw.WriteRaw("""CURCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.CURCODE)
            end if
            if _IsSetPERCENT then
              if f then
                  jw.WriteRaw(", ""PERCENT"": ")
              else
                  jw.WriteRaw("""PERCENT"": ")
                  f = true
              end if
              jw.WriteValue(me.PERCENT)
            end if
            if _IsSetKLINE then
              if f then
                  jw.WriteRaw(", ""KLINE"": ")
              else
                  jw.WriteRaw("""KLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.KLINE)
            end if
            if _MATRIX_SUBFORM.value.count > 0 then
              jw.WriteRaw(", MATRIX_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as MATRIX in _MATRIX_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _MATRIX_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _MATRIXSUMTEXT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", MATRIXSUMTEXT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as MATRIXSUMTEXT in _MATRIXSUMTEXT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _MATRIXSUMTEXT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "MATRIXSUM")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetPARTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PARTNAME")
              .WriteAttributeString("value", me.PARTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "15")
              .WriteEndElement
            end if
            if _IsSetSQUANT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SQUANT")
              .WriteAttributeString("value", me.SQUANT)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetSBARCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SBARCODE")
              .WriteAttributeString("value", me.SBARCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetXCOLORCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "XCOLORCODE")
              .WriteAttributeString("value", me.XCOLORCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "2")
              .WriteEndElement
            end if
            if _IsSetDISTRTYPECODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DISTRTYPECODE")
              .WriteAttributeString("value", me.DISTRTYPECODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
            end if
            if _IsSetNUMPACK then
              .WriteStartElement("field")
              .WriteAttributeString("name", "NUMPACK")
              .WriteAttributeString("value", me.NUMPACK)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetDUEDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DUEDATE")
              .WriteAttributeString("value", me.DUEDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetACTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ACTNAME")
              .WriteAttributeString("value", me.ACTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetSERIALNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SERIALNAME")
              .WriteAttributeString("value", me.SERIALNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "22")
              .WriteEndElement
            end if
            if _IsSetCUSTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CUSTNAME")
              .WriteAttributeString("value", me.CUSTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetTOCUSTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TOCUSTNAME")
              .WriteAttributeString("value", me.TOCUSTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetPRICE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PRICE")
              .WriteAttributeString("value", me.PRICE)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "2")
              .WriteAttributeString("Precision", "16")
              .WriteEndElement
            end if
            if _IsSetCURCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CURCODE")
              .WriteAttributeString("value", me.CURCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
            end if
            if _IsSetPERCENT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PERCENT")
              .WriteAttributeString("value", me.PERCENT)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "2")
              .WriteAttributeString("Precision", "16")
              .WriteEndElement
            end if
            if _IsSetKLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", me.KLINE)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _MATRIX_SUBFORM.value.count > 0 then
              for each itm as MATRIX in _MATRIX_SUBFORM.Value
                itm.toXML(xw,"MATRIX_SUBFORM")
              next
            end if
            if _MATRIXSUMTEXT_SUBFORM.value.count > 0 then
              for each itm as MATRIXSUMTEXT in _MATRIXSUMTEXT_SUBFORM.Value
                itm.toXML(xw,"MATRIXSUMTEXT_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as MATRIXSUM = JsonConvert.DeserializeObject(Of MATRIXSUM)(e.StreamReader.ReadToEnd)
                With obj
                  _PARTNAME = .PARTNAME
                  _PARTDES = .PARTDES
                  _SQUANT = .SQUANT
                  _SBARCODE = .SBARCODE
                  _XCOLORCODE = .XCOLORCODE
                  _XCOLORNAME = .XCOLORNAME
                  _DISTRTYPECODE = .DISTRTYPECODE
                  _DISTRTYPEDES = .DISTRTYPEDES
                  _XQUANT = .XQUANT
                  _NUMPACK = .NUMPACK
                  _TOTQUANT = .TOTQUANT
                  _DUEDATE = .DUEDATE
                  _ACTNAME = .ACTNAME
                  _ACTDES = .ACTDES
                  _SERIALNAME = .SERIALNAME
                  _CUSTNAME = .CUSTNAME
                  _TOCUSTNAME = .TOCUSTNAME
                  _PRICE = .PRICE
                  _CURCODE = .CURCODE
                  _PRSOURCENAME = .PRSOURCENAME
                  _PERCENT = .PERCENT
                  _KLINE = .KLINE
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_MATRIXSUM
        
        MATRIX = 0
        
        MATRIXSUMTEXT = 1
    End Enum
    
    <QueryTitle("Assortment")>  _
    Public Class QUERY_MATRIX
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of MATRIX)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of MATRIX)
            _Parent = nothing
            _Name = "MATRIX"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of MATRIX)
            _Parent = Parent
            _name = "MATRIX_SUBFORM"
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
        
        Public Property Value() As list(of MATRIX)
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
                return GetType(MATRIX)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _MATRIX As MATRIX In JsonConvert.DeserializeObject(Of QUERY_MATRIX)(stream.ReadToEnd).Value
              With _MATRIX
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_MATRIX)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as MATRIX = JsonConvert.DeserializeObject(Of MATRIX)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, MATRIX)
                  .XCOLORCODE = obj.XCOLORCODE
                  .XCOLORNAME = obj.XCOLORNAME
                  .MULT = obj.MULT
                  .TOTALSUM = obj.TOTALSUM
                  .SIZE1 = obj.SIZE1
                  .SIZE2 = obj.SIZE2
                  .SIZE3 = obj.SIZE3
                  .SIZE4 = obj.SIZE4
                  .SIZE5 = obj.SIZE5
                  .SIZE6 = obj.SIZE6
                  .SIZE7 = obj.SIZE7
                  .SIZE8 = obj.SIZE8
                  .SIZE9 = obj.SIZE9
                  .SIZE10 = obj.SIZE10
                  .SIZE11 = obj.SIZE11
                  .SIZE12 = obj.SIZE12
                  .SIZE13 = obj.SIZE13
                  .SIZE14 = obj.SIZE14
                  .SIZE15 = obj.SIZE15
                  .SIZE16 = obj.SIZE16
                  .SIZE17 = obj.SIZE17
                  .SIZE18 = obj.SIZE18
                  .SIZE19 = obj.SIZE19
                  .SIZE20 = obj.SIZE20
                  .SIZE21 = obj.SIZE21
                  .SIZE22 = obj.SIZE22
                  .SIZE23 = obj.SIZE23
                  .SIZE24 = obj.SIZE24
                  .SIZE25 = obj.SIZE25
                  .SIZE26 = obj.SIZE26
                  .SIZE27 = obj.SIZE27
                  .SIZE28 = obj.SIZE28
                  .SIZE29 = obj.SIZE29
                  .SIZE30 = obj.SIZE30
                  .SIZE31 = obj.SIZE31
                  .SIZE32 = obj.SIZE32
                  .SIZE33 = obj.SIZE33
                  .SIZE34 = obj.SIZE34
                  .SIZE35 = obj.SIZE35
                  .SIZE36 = obj.SIZE36
                  .SIZE37 = obj.SIZE37
                  .SIZE38 = obj.SIZE38
                  .SIZE39 = obj.SIZE39
                  .SIZE40 = obj.SIZE40
                  .XCOLOR = obj.XCOLOR
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new MATRIX(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _MATRIX as MATRIX in value
              If _MATRIX.Equals(trycast(obj,MATRIX)) Then
                  value.remove(_MATRIX)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class MATRIX
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetXCOLORCODE As Boolean = Boolean.FalseString
        
        Private _XCOLORCODE As String
        
        Private _XCOLORNAME As String
        
        Private _IsSetMULT As Boolean = Boolean.FalseString
        
        Private _MULT As Long
        
        Private _TOTALSUM As Decimal
        
        Private _IsSetSIZE1 As Boolean = Boolean.FalseString
        
        Private _SIZE1 As Decimal
        
        Private _IsSetSIZE2 As Boolean = Boolean.FalseString
        
        Private _SIZE2 As Decimal
        
        Private _IsSetSIZE3 As Boolean = Boolean.FalseString
        
        Private _SIZE3 As Decimal
        
        Private _IsSetSIZE4 As Boolean = Boolean.FalseString
        
        Private _SIZE4 As Decimal
        
        Private _IsSetSIZE5 As Boolean = Boolean.FalseString
        
        Private _SIZE5 As Decimal
        
        Private _IsSetSIZE6 As Boolean = Boolean.FalseString
        
        Private _SIZE6 As Decimal
        
        Private _IsSetSIZE7 As Boolean = Boolean.FalseString
        
        Private _SIZE7 As Decimal
        
        Private _IsSetSIZE8 As Boolean = Boolean.FalseString
        
        Private _SIZE8 As Decimal
        
        Private _IsSetSIZE9 As Boolean = Boolean.FalseString
        
        Private _SIZE9 As Decimal
        
        Private _IsSetSIZE10 As Boolean = Boolean.FalseString
        
        Private _SIZE10 As Decimal
        
        Private _IsSetSIZE11 As Boolean = Boolean.FalseString
        
        Private _SIZE11 As Decimal
        
        Private _IsSetSIZE12 As Boolean = Boolean.FalseString
        
        Private _SIZE12 As Decimal
        
        Private _IsSetSIZE13 As Boolean = Boolean.FalseString
        
        Private _SIZE13 As Decimal
        
        Private _IsSetSIZE14 As Boolean = Boolean.FalseString
        
        Private _SIZE14 As Decimal
        
        Private _IsSetSIZE15 As Boolean = Boolean.FalseString
        
        Private _SIZE15 As Decimal
        
        Private _IsSetSIZE16 As Boolean = Boolean.FalseString
        
        Private _SIZE16 As Decimal
        
        Private _IsSetSIZE17 As Boolean = Boolean.FalseString
        
        Private _SIZE17 As Decimal
        
        Private _IsSetSIZE18 As Boolean = Boolean.FalseString
        
        Private _SIZE18 As Decimal
        
        Private _IsSetSIZE19 As Boolean = Boolean.FalseString
        
        Private _SIZE19 As Decimal
        
        Private _IsSetSIZE20 As Boolean = Boolean.FalseString
        
        Private _SIZE20 As Decimal
        
        Private _IsSetSIZE21 As Boolean = Boolean.FalseString
        
        Private _SIZE21 As Decimal
        
        Private _IsSetSIZE22 As Boolean = Boolean.FalseString
        
        Private _SIZE22 As Decimal
        
        Private _IsSetSIZE23 As Boolean = Boolean.FalseString
        
        Private _SIZE23 As Decimal
        
        Private _IsSetSIZE24 As Boolean = Boolean.FalseString
        
        Private _SIZE24 As Decimal
        
        Private _IsSetSIZE25 As Boolean = Boolean.FalseString
        
        Private _SIZE25 As Decimal
        
        Private _IsSetSIZE26 As Boolean = Boolean.FalseString
        
        Private _SIZE26 As Decimal
        
        Private _IsSetSIZE27 As Boolean = Boolean.FalseString
        
        Private _SIZE27 As Decimal
        
        Private _IsSetSIZE28 As Boolean = Boolean.FalseString
        
        Private _SIZE28 As Decimal
        
        Private _IsSetSIZE29 As Boolean = Boolean.FalseString
        
        Private _SIZE29 As Decimal
        
        Private _IsSetSIZE30 As Boolean = Boolean.FalseString
        
        Private _SIZE30 As Decimal
        
        Private _IsSetSIZE31 As Boolean = Boolean.FalseString
        
        Private _SIZE31 As Decimal
        
        Private _IsSetSIZE32 As Boolean = Boolean.FalseString
        
        Private _SIZE32 As Decimal
        
        Private _IsSetSIZE33 As Boolean = Boolean.FalseString
        
        Private _SIZE33 As Decimal
        
        Private _IsSetSIZE34 As Boolean = Boolean.FalseString
        
        Private _SIZE34 As Decimal
        
        Private _IsSetSIZE35 As Boolean = Boolean.FalseString
        
        Private _SIZE35 As Decimal
        
        Private _IsSetSIZE36 As Boolean = Boolean.FalseString
        
        Private _SIZE36 As Decimal
        
        Private _IsSetSIZE37 As Boolean = Boolean.FalseString
        
        Private _SIZE37 As Decimal
        
        Private _IsSetSIZE38 As Boolean = Boolean.FalseString
        
        Private _SIZE38 As Decimal
        
        Private _IsSetSIZE39 As Boolean = Boolean.FalseString
        
        Private _SIZE39 As Decimal
        
        Private _IsSetSIZE40 As Boolean = Boolean.FalseString
        
        Private _SIZE40 As Decimal
        
        Private _IsSetXCOLOR As Boolean = Boolean.FalseString
        
        Private _XCOLOR As Long
        
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
                    return "MATRIX"
                else
                    return "MATRIX_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "XCOLOR={0}", _
                  string.format("{0}",XCOLOR) _ 
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
        
        <DisplayName("Color Code"),  _
         nType("Edm.String"),  _
         tab("Color Code"),  _
         Pos(10),  _
         twodBarcode("XCOLORCODE")>  _
        Public Property XCOLORCODE() As String
            Get
                return _XCOLORCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Color Code", value, "^.{0,2}$") then Exit Property
                _IsSetXCOLORCODE = True
                If loading Then
                  _XCOLORCODE = Value
                Else
                    if not _XCOLORCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("XCOLORCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _XCOLORCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Color Name"),  _
         nType("Edm.String"),  _
         tab("Color Code"),  _
         Pos(12),  _
         [ReadOnly](true),  _
         twodBarcode("XCOLORNAME")>  _
        Public Property XCOLORNAME() As String
            Get
                return _XCOLORNAME
            End Get
            Set
                if not(value is nothing) then
                  _XCOLORNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Number of Sets"),  _
         nType("Edm.Int64"),  _
         tab("Color Code"),  _
         Pos(20),  _
         twodBarcode("MULT")>  _
        Public Property MULT() As nullable (of int64)
            Get
                return _MULT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Number of Sets", value, "^[0-9\-]+$") then Exit Property
                _IsSetMULT = True
                If loading Then
                  _MULT = Value
                Else
                    if not _MULT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("MULT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _MULT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Total Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("Color Code"),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("TOTALSUM")>  _
        Public Property TOTALSUM() As nullable(of decimal)
            Get
                return _TOTALSUM
            End Get
            Set
                if not(value is nothing) then
                  _TOTALSUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("1"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Color Code"),  _
         Pos(60),  _
         twodBarcode("SIZE1")>  _
        Public Property SIZE1() As nullable(of decimal)
            Get
                return _SIZE1
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("1", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE1 = True
                If loading Then
                  _SIZE1 = Value
                Else
                    if not _SIZE1 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE1", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE1 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("2"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Color Code"),  _
         Pos(70),  _
         twodBarcode("SIZE2")>  _
        Public Property SIZE2() As nullable(of decimal)
            Get
                return _SIZE2
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("2", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE2 = True
                If loading Then
                  _SIZE2 = Value
                Else
                    if not _SIZE2 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE2", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE2 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("3"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Color Code"),  _
         Pos(80),  _
         twodBarcode("SIZE3")>  _
        Public Property SIZE3() As nullable(of decimal)
            Get
                return _SIZE3
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("3", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE3 = True
                If loading Then
                  _SIZE3 = Value
                Else
                    if not _SIZE3 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE3", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE3 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("4"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Color Code"),  _
         Pos(90),  _
         twodBarcode("SIZE4")>  _
        Public Property SIZE4() As nullable(of decimal)
            Get
                return _SIZE4
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("4", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE4 = True
                If loading Then
                  _SIZE4 = Value
                Else
                    if not _SIZE4 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE4", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE4 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("5"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("5"),  _
         Pos(100),  _
         twodBarcode("SIZE5")>  _
        Public Property SIZE5() As nullable(of decimal)
            Get
                return _SIZE5
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("5", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE5 = True
                If loading Then
                  _SIZE5 = Value
                Else
                    if not _SIZE5 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE5", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE5 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("6"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("5"),  _
         Pos(110),  _
         twodBarcode("SIZE6")>  _
        Public Property SIZE6() As nullable(of decimal)
            Get
                return _SIZE6
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("6", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE6 = True
                If loading Then
                  _SIZE6 = Value
                Else
                    if not _SIZE6 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE6", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE6 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("7"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("5"),  _
         Pos(120),  _
         twodBarcode("SIZE7")>  _
        Public Property SIZE7() As nullable(of decimal)
            Get
                return _SIZE7
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("7", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE7 = True
                If loading Then
                  _SIZE7 = Value
                Else
                    if not _SIZE7 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE7", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE7 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("8"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("5"),  _
         Pos(130),  _
         twodBarcode("SIZE8")>  _
        Public Property SIZE8() As nullable(of decimal)
            Get
                return _SIZE8
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("8", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE8 = True
                If loading Then
                  _SIZE8 = Value
                Else
                    if not _SIZE8 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE8", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE8 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("9"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("5"),  _
         Pos(140),  _
         twodBarcode("SIZE9")>  _
        Public Property SIZE9() As nullable(of decimal)
            Get
                return _SIZE9
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("9", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE9 = True
                If loading Then
                  _SIZE9 = Value
                Else
                    if not _SIZE9 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE9", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE9 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("10"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("5"),  _
         Pos(150),  _
         twodBarcode("SIZE10")>  _
        Public Property SIZE10() As nullable(of decimal)
            Get
                return _SIZE10
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("10", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE10 = True
                If loading Then
                  _SIZE10 = Value
                Else
                    if not _SIZE10 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE10", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE10 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("11"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("5"),  _
         Pos(160),  _
         twodBarcode("SIZE11")>  _
        Public Property SIZE11() As nullable(of decimal)
            Get
                return _SIZE11
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("11", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE11 = True
                If loading Then
                  _SIZE11 = Value
                Else
                    if not _SIZE11 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE11", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE11 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("12"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("5"),  _
         Pos(170),  _
         twodBarcode("SIZE12")>  _
        Public Property SIZE12() As nullable(of decimal)
            Get
                return _SIZE12
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("12", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE12 = True
                If loading Then
                  _SIZE12 = Value
                Else
                    if not _SIZE12 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE12", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE12 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("13"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("13"),  _
         Pos(180),  _
         twodBarcode("SIZE13")>  _
        Public Property SIZE13() As nullable(of decimal)
            Get
                return _SIZE13
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("13", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE13 = True
                If loading Then
                  _SIZE13 = Value
                Else
                    if not _SIZE13 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE13", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE13 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("14"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("13"),  _
         Pos(190),  _
         twodBarcode("SIZE14")>  _
        Public Property SIZE14() As nullable(of decimal)
            Get
                return _SIZE14
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("14", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE14 = True
                If loading Then
                  _SIZE14 = Value
                Else
                    if not _SIZE14 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE14", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE14 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("15"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("13"),  _
         Pos(200),  _
         twodBarcode("SIZE15")>  _
        Public Property SIZE15() As nullable(of decimal)
            Get
                return _SIZE15
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("15", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE15 = True
                If loading Then
                  _SIZE15 = Value
                Else
                    if not _SIZE15 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE15", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE15 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("16"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("13"),  _
         Pos(210),  _
         twodBarcode("SIZE16")>  _
        Public Property SIZE16() As nullable(of decimal)
            Get
                return _SIZE16
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("16", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE16 = True
                If loading Then
                  _SIZE16 = Value
                Else
                    if not _SIZE16 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE16", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE16 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("17"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("13"),  _
         Pos(220),  _
         twodBarcode("SIZE17")>  _
        Public Property SIZE17() As nullable(of decimal)
            Get
                return _SIZE17
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("17", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE17 = True
                If loading Then
                  _SIZE17 = Value
                Else
                    if not _SIZE17 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE17", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE17 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("18"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("13"),  _
         Pos(230),  _
         twodBarcode("SIZE18")>  _
        Public Property SIZE18() As nullable(of decimal)
            Get
                return _SIZE18
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("18", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE18 = True
                If loading Then
                  _SIZE18 = Value
                Else
                    if not _SIZE18 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE18", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE18 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("19"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("13"),  _
         Pos(240),  _
         twodBarcode("SIZE19")>  _
        Public Property SIZE19() As nullable(of decimal)
            Get
                return _SIZE19
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("19", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE19 = True
                If loading Then
                  _SIZE19 = Value
                Else
                    if not _SIZE19 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE19", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE19 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("20"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("13"),  _
         Pos(250),  _
         twodBarcode("SIZE20")>  _
        Public Property SIZE20() As nullable(of decimal)
            Get
                return _SIZE20
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("20", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE20 = True
                If loading Then
                  _SIZE20 = Value
                Else
                    if not _SIZE20 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE20", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE20 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("21"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("21"),  _
         Pos(260),  _
         twodBarcode("SIZE21")>  _
        Public Property SIZE21() As nullable(of decimal)
            Get
                return _SIZE21
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("21", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE21 = True
                If loading Then
                  _SIZE21 = Value
                Else
                    if not _SIZE21 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE21", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE21 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("22"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("21"),  _
         Pos(270),  _
         twodBarcode("SIZE22")>  _
        Public Property SIZE22() As nullable(of decimal)
            Get
                return _SIZE22
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("22", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE22 = True
                If loading Then
                  _SIZE22 = Value
                Else
                    if not _SIZE22 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE22", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE22 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("23"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("21"),  _
         Pos(280),  _
         twodBarcode("SIZE23")>  _
        Public Property SIZE23() As nullable(of decimal)
            Get
                return _SIZE23
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("23", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE23 = True
                If loading Then
                  _SIZE23 = Value
                Else
                    if not _SIZE23 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE23", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE23 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("24"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("21"),  _
         Pos(290),  _
         twodBarcode("SIZE24")>  _
        Public Property SIZE24() As nullable(of decimal)
            Get
                return _SIZE24
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("24", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE24 = True
                If loading Then
                  _SIZE24 = Value
                Else
                    if not _SIZE24 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE24", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE24 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("25"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("21"),  _
         Pos(300),  _
         twodBarcode("SIZE25")>  _
        Public Property SIZE25() As nullable(of decimal)
            Get
                return _SIZE25
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("25", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE25 = True
                If loading Then
                  _SIZE25 = Value
                Else
                    if not _SIZE25 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE25", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE25 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("26"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("21"),  _
         Pos(310),  _
         twodBarcode("SIZE26")>  _
        Public Property SIZE26() As nullable(of decimal)
            Get
                return _SIZE26
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("26", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE26 = True
                If loading Then
                  _SIZE26 = Value
                Else
                    if not _SIZE26 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE26", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE26 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("27"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("21"),  _
         Pos(320),  _
         twodBarcode("SIZE27")>  _
        Public Property SIZE27() As nullable(of decimal)
            Get
                return _SIZE27
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("27", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE27 = True
                If loading Then
                  _SIZE27 = Value
                Else
                    if not _SIZE27 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE27", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE27 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("28"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("21"),  _
         Pos(330),  _
         twodBarcode("SIZE28")>  _
        Public Property SIZE28() As nullable(of decimal)
            Get
                return _SIZE28
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("28", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE28 = True
                If loading Then
                  _SIZE28 = Value
                Else
                    if not _SIZE28 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE28", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE28 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("29"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("29"),  _
         Pos(340),  _
         twodBarcode("SIZE29")>  _
        Public Property SIZE29() As nullable(of decimal)
            Get
                return _SIZE29
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("29", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE29 = True
                If loading Then
                  _SIZE29 = Value
                Else
                    if not _SIZE29 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE29", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE29 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("30"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("29"),  _
         Pos(350),  _
         twodBarcode("SIZE30")>  _
        Public Property SIZE30() As nullable(of decimal)
            Get
                return _SIZE30
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("30", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE30 = True
                If loading Then
                  _SIZE30 = Value
                Else
                    if not _SIZE30 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE30", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE30 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("S31"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("29"),  _
         Pos(355),  _
         twodBarcode("SIZE31")>  _
        Public Property SIZE31() As nullable(of decimal)
            Get
                return _SIZE31
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("S31", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE31 = True
                If loading Then
                  _SIZE31 = Value
                Else
                    if not _SIZE31 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE31", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE31 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("S32"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("29"),  _
         Pos(360),  _
         twodBarcode("SIZE32")>  _
        Public Property SIZE32() As nullable(of decimal)
            Get
                return _SIZE32
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("S32", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE32 = True
                If loading Then
                  _SIZE32 = Value
                Else
                    if not _SIZE32 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE32", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE32 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("S33"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("29"),  _
         Pos(365),  _
         twodBarcode("SIZE33")>  _
        Public Property SIZE33() As nullable(of decimal)
            Get
                return _SIZE33
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("S33", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE33 = True
                If loading Then
                  _SIZE33 = Value
                Else
                    if not _SIZE33 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE33", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE33 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("S34"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("29"),  _
         Pos(370),  _
         twodBarcode("SIZE34")>  _
        Public Property SIZE34() As nullable(of decimal)
            Get
                return _SIZE34
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("S34", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE34 = True
                If loading Then
                  _SIZE34 = Value
                Else
                    if not _SIZE34 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE34", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE34 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("S35"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("29"),  _
         Pos(375),  _
         twodBarcode("SIZE35")>  _
        Public Property SIZE35() As nullable(of decimal)
            Get
                return _SIZE35
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("S35", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE35 = True
                If loading Then
                  _SIZE35 = Value
                Else
                    if not _SIZE35 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE35", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE35 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("S36"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("29"),  _
         Pos(380),  _
         twodBarcode("SIZE36")>  _
        Public Property SIZE36() As nullable(of decimal)
            Get
                return _SIZE36
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("S36", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE36 = True
                If loading Then
                  _SIZE36 = Value
                Else
                    if not _SIZE36 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE36", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE36 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("S37"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("S37"),  _
         Pos(385),  _
         twodBarcode("SIZE37")>  _
        Public Property SIZE37() As nullable(of decimal)
            Get
                return _SIZE37
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("S37", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE37 = True
                If loading Then
                  _SIZE37 = Value
                Else
                    if not _SIZE37 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE37", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE37 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("S38"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("S37"),  _
         Pos(390),  _
         twodBarcode("SIZE38")>  _
        Public Property SIZE38() As nullable(of decimal)
            Get
                return _SIZE38
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("S38", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE38 = True
                If loading Then
                  _SIZE38 = Value
                Else
                    if not _SIZE38 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE38", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE38 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("S39"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("S37"),  _
         Pos(395),  _
         twodBarcode("SIZE39")>  _
        Public Property SIZE39() As nullable(of decimal)
            Get
                return _SIZE39
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("S39", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE39 = True
                If loading Then
                  _SIZE39 = Value
                Else
                    if not _SIZE39 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE39", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE39 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("S40"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("S37"),  _
         Pos(400),  _
         twodBarcode("SIZE40")>  _
        Public Property SIZE40() As nullable(of decimal)
            Get
                return _SIZE40
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("S40", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSIZE40 = True
                If loading Then
                  _SIZE40 = Value
                Else
                    if not _SIZE40 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SIZE40", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SIZE40 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Color (ID)"),  _
         nType("Edm.Int64"),  _
         tab("S37"),  _
         Pos(40),  _
         Browsable(false),  _
         twodBarcode("XCOLOR")>  _
        Public Property XCOLOR() As nullable (of int64)
            Get
                return _XCOLOR
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Color (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetXCOLOR = True
                If loading Then
                  _XCOLOR = Value
                Else
                    if not _XCOLOR = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("XCOLOR", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _XCOLOR = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetXCOLORCODE then
              if f then
                  jw.WriteRaw(", ""XCOLORCODE"": ")
              else
                  jw.WriteRaw("""XCOLORCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.XCOLORCODE)
            end if
            if _IsSetMULT then
              if f then
                  jw.WriteRaw(", ""MULT"": ")
              else
                  jw.WriteRaw("""MULT"": ")
                  f = true
              end if
              jw.WriteValue(me.MULT)
            end if
            if _IsSetSIZE1 then
              if f then
                  jw.WriteRaw(", ""SIZE1"": ")
              else
                  jw.WriteRaw("""SIZE1"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE1)
            end if
            if _IsSetSIZE2 then
              if f then
                  jw.WriteRaw(", ""SIZE2"": ")
              else
                  jw.WriteRaw("""SIZE2"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE2)
            end if
            if _IsSetSIZE3 then
              if f then
                  jw.WriteRaw(", ""SIZE3"": ")
              else
                  jw.WriteRaw("""SIZE3"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE3)
            end if
            if _IsSetSIZE4 then
              if f then
                  jw.WriteRaw(", ""SIZE4"": ")
              else
                  jw.WriteRaw("""SIZE4"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE4)
            end if
            if _IsSetSIZE5 then
              if f then
                  jw.WriteRaw(", ""SIZE5"": ")
              else
                  jw.WriteRaw("""SIZE5"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE5)
            end if
            if _IsSetSIZE6 then
              if f then
                  jw.WriteRaw(", ""SIZE6"": ")
              else
                  jw.WriteRaw("""SIZE6"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE6)
            end if
            if _IsSetSIZE7 then
              if f then
                  jw.WriteRaw(", ""SIZE7"": ")
              else
                  jw.WriteRaw("""SIZE7"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE7)
            end if
            if _IsSetSIZE8 then
              if f then
                  jw.WriteRaw(", ""SIZE8"": ")
              else
                  jw.WriteRaw("""SIZE8"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE8)
            end if
            if _IsSetSIZE9 then
              if f then
                  jw.WriteRaw(", ""SIZE9"": ")
              else
                  jw.WriteRaw("""SIZE9"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE9)
            end if
            if _IsSetSIZE10 then
              if f then
                  jw.WriteRaw(", ""SIZE10"": ")
              else
                  jw.WriteRaw("""SIZE10"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE10)
            end if
            if _IsSetSIZE11 then
              if f then
                  jw.WriteRaw(", ""SIZE11"": ")
              else
                  jw.WriteRaw("""SIZE11"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE11)
            end if
            if _IsSetSIZE12 then
              if f then
                  jw.WriteRaw(", ""SIZE12"": ")
              else
                  jw.WriteRaw("""SIZE12"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE12)
            end if
            if _IsSetSIZE13 then
              if f then
                  jw.WriteRaw(", ""SIZE13"": ")
              else
                  jw.WriteRaw("""SIZE13"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE13)
            end if
            if _IsSetSIZE14 then
              if f then
                  jw.WriteRaw(", ""SIZE14"": ")
              else
                  jw.WriteRaw("""SIZE14"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE14)
            end if
            if _IsSetSIZE15 then
              if f then
                  jw.WriteRaw(", ""SIZE15"": ")
              else
                  jw.WriteRaw("""SIZE15"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE15)
            end if
            if _IsSetSIZE16 then
              if f then
                  jw.WriteRaw(", ""SIZE16"": ")
              else
                  jw.WriteRaw("""SIZE16"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE16)
            end if
            if _IsSetSIZE17 then
              if f then
                  jw.WriteRaw(", ""SIZE17"": ")
              else
                  jw.WriteRaw("""SIZE17"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE17)
            end if
            if _IsSetSIZE18 then
              if f then
                  jw.WriteRaw(", ""SIZE18"": ")
              else
                  jw.WriteRaw("""SIZE18"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE18)
            end if
            if _IsSetSIZE19 then
              if f then
                  jw.WriteRaw(", ""SIZE19"": ")
              else
                  jw.WriteRaw("""SIZE19"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE19)
            end if
            if _IsSetSIZE20 then
              if f then
                  jw.WriteRaw(", ""SIZE20"": ")
              else
                  jw.WriteRaw("""SIZE20"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE20)
            end if
            if _IsSetSIZE21 then
              if f then
                  jw.WriteRaw(", ""SIZE21"": ")
              else
                  jw.WriteRaw("""SIZE21"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE21)
            end if
            if _IsSetSIZE22 then
              if f then
                  jw.WriteRaw(", ""SIZE22"": ")
              else
                  jw.WriteRaw("""SIZE22"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE22)
            end if
            if _IsSetSIZE23 then
              if f then
                  jw.WriteRaw(", ""SIZE23"": ")
              else
                  jw.WriteRaw("""SIZE23"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE23)
            end if
            if _IsSetSIZE24 then
              if f then
                  jw.WriteRaw(", ""SIZE24"": ")
              else
                  jw.WriteRaw("""SIZE24"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE24)
            end if
            if _IsSetSIZE25 then
              if f then
                  jw.WriteRaw(", ""SIZE25"": ")
              else
                  jw.WriteRaw("""SIZE25"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE25)
            end if
            if _IsSetSIZE26 then
              if f then
                  jw.WriteRaw(", ""SIZE26"": ")
              else
                  jw.WriteRaw("""SIZE26"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE26)
            end if
            if _IsSetSIZE27 then
              if f then
                  jw.WriteRaw(", ""SIZE27"": ")
              else
                  jw.WriteRaw("""SIZE27"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE27)
            end if
            if _IsSetSIZE28 then
              if f then
                  jw.WriteRaw(", ""SIZE28"": ")
              else
                  jw.WriteRaw("""SIZE28"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE28)
            end if
            if _IsSetSIZE29 then
              if f then
                  jw.WriteRaw(", ""SIZE29"": ")
              else
                  jw.WriteRaw("""SIZE29"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE29)
            end if
            if _IsSetSIZE30 then
              if f then
                  jw.WriteRaw(", ""SIZE30"": ")
              else
                  jw.WriteRaw("""SIZE30"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE30)
            end if
            if _IsSetSIZE31 then
              if f then
                  jw.WriteRaw(", ""SIZE31"": ")
              else
                  jw.WriteRaw("""SIZE31"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE31)
            end if
            if _IsSetSIZE32 then
              if f then
                  jw.WriteRaw(", ""SIZE32"": ")
              else
                  jw.WriteRaw("""SIZE32"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE32)
            end if
            if _IsSetSIZE33 then
              if f then
                  jw.WriteRaw(", ""SIZE33"": ")
              else
                  jw.WriteRaw("""SIZE33"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE33)
            end if
            if _IsSetSIZE34 then
              if f then
                  jw.WriteRaw(", ""SIZE34"": ")
              else
                  jw.WriteRaw("""SIZE34"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE34)
            end if
            if _IsSetSIZE35 then
              if f then
                  jw.WriteRaw(", ""SIZE35"": ")
              else
                  jw.WriteRaw("""SIZE35"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE35)
            end if
            if _IsSetSIZE36 then
              if f then
                  jw.WriteRaw(", ""SIZE36"": ")
              else
                  jw.WriteRaw("""SIZE36"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE36)
            end if
            if _IsSetSIZE37 then
              if f then
                  jw.WriteRaw(", ""SIZE37"": ")
              else
                  jw.WriteRaw("""SIZE37"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE37)
            end if
            if _IsSetSIZE38 then
              if f then
                  jw.WriteRaw(", ""SIZE38"": ")
              else
                  jw.WriteRaw("""SIZE38"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE38)
            end if
            if _IsSetSIZE39 then
              if f then
                  jw.WriteRaw(", ""SIZE39"": ")
              else
                  jw.WriteRaw("""SIZE39"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE39)
            end if
            if _IsSetSIZE40 then
              if f then
                  jw.WriteRaw(", ""SIZE40"": ")
              else
                  jw.WriteRaw("""SIZE40"": ")
                  f = true
              end if
              jw.WriteValue(me.SIZE40)
            end if
            if _IsSetXCOLOR then
              if f then
                  jw.WriteRaw(", ""XCOLOR"": ")
              else
                  jw.WriteRaw("""XCOLOR"": ")
                  f = true
              end if
              jw.WriteValue(me.XCOLOR)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "MATRIX")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "XCOLOR")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetXCOLORCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "XCOLORCODE")
              .WriteAttributeString("value", me.XCOLORCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "2")
              .WriteEndElement
            end if
            if _IsSetMULT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "MULT")
              .WriteAttributeString("value", me.MULT)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetSIZE1 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE1")
              .WriteAttributeString("value", me.SIZE1)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE2 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE2")
              .WriteAttributeString("value", me.SIZE2)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE3 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE3")
              .WriteAttributeString("value", me.SIZE3)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE4 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE4")
              .WriteAttributeString("value", me.SIZE4)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE5 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE5")
              .WriteAttributeString("value", me.SIZE5)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE6 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE6")
              .WriteAttributeString("value", me.SIZE6)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE7 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE7")
              .WriteAttributeString("value", me.SIZE7)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE8 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE8")
              .WriteAttributeString("value", me.SIZE8)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE9 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE9")
              .WriteAttributeString("value", me.SIZE9)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE10 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE10")
              .WriteAttributeString("value", me.SIZE10)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE11 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE11")
              .WriteAttributeString("value", me.SIZE11)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE12 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE12")
              .WriteAttributeString("value", me.SIZE12)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE13 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE13")
              .WriteAttributeString("value", me.SIZE13)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE14 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE14")
              .WriteAttributeString("value", me.SIZE14)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE15 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE15")
              .WriteAttributeString("value", me.SIZE15)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE16 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE16")
              .WriteAttributeString("value", me.SIZE16)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE17 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE17")
              .WriteAttributeString("value", me.SIZE17)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE18 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE18")
              .WriteAttributeString("value", me.SIZE18)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE19 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE19")
              .WriteAttributeString("value", me.SIZE19)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE20 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE20")
              .WriteAttributeString("value", me.SIZE20)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE21 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE21")
              .WriteAttributeString("value", me.SIZE21)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE22 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE22")
              .WriteAttributeString("value", me.SIZE22)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE23 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE23")
              .WriteAttributeString("value", me.SIZE23)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE24 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE24")
              .WriteAttributeString("value", me.SIZE24)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE25 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE25")
              .WriteAttributeString("value", me.SIZE25)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE26 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE26")
              .WriteAttributeString("value", me.SIZE26)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE27 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE27")
              .WriteAttributeString("value", me.SIZE27)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE28 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE28")
              .WriteAttributeString("value", me.SIZE28)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE29 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE29")
              .WriteAttributeString("value", me.SIZE29)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE30 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE30")
              .WriteAttributeString("value", me.SIZE30)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "17")
              .WriteEndElement
            end if
            if _IsSetSIZE31 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE31")
              .WriteAttributeString("value", me.SIZE31)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "13")
              .WriteEndElement
            end if
            if _IsSetSIZE32 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE32")
              .WriteAttributeString("value", me.SIZE32)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "13")
              .WriteEndElement
            end if
            if _IsSetSIZE33 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE33")
              .WriteAttributeString("value", me.SIZE33)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "13")
              .WriteEndElement
            end if
            if _IsSetSIZE34 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE34")
              .WriteAttributeString("value", me.SIZE34)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "13")
              .WriteEndElement
            end if
            if _IsSetSIZE35 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE35")
              .WriteAttributeString("value", me.SIZE35)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "13")
              .WriteEndElement
            end if
            if _IsSetSIZE36 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE36")
              .WriteAttributeString("value", me.SIZE36)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "13")
              .WriteEndElement
            end if
            if _IsSetSIZE37 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE37")
              .WriteAttributeString("value", me.SIZE37)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "13")
              .WriteEndElement
            end if
            if _IsSetSIZE38 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE38")
              .WriteAttributeString("value", me.SIZE38)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "13")
              .WriteEndElement
            end if
            if _IsSetSIZE39 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE39")
              .WriteAttributeString("value", me.SIZE39)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "13")
              .WriteEndElement
            end if
            if _IsSetSIZE40 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SIZE40")
              .WriteAttributeString("value", me.SIZE40)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "13")
              .WriteEndElement
            end if
            if _IsSetXCOLOR then
              .WriteStartElement("field")
              .WriteAttributeString("name", "XCOLOR")
              .WriteAttributeString("value", me.XCOLOR)
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
                dim obj as MATRIX = JsonConvert.DeserializeObject(Of MATRIX)(e.StreamReader.ReadToEnd)
                With obj
                  _XCOLORCODE = .XCOLORCODE
                  _XCOLORNAME = .XCOLORNAME
                  _MULT = .MULT
                  _TOTALSUM = .TOTALSUM
                  _SIZE1 = .SIZE1
                  _SIZE2 = .SIZE2
                  _SIZE3 = .SIZE3
                  _SIZE4 = .SIZE4
                  _SIZE5 = .SIZE5
                  _SIZE6 = .SIZE6
                  _SIZE7 = .SIZE7
                  _SIZE8 = .SIZE8
                  _SIZE9 = .SIZE9
                  _SIZE10 = .SIZE10
                  _SIZE11 = .SIZE11
                  _SIZE12 = .SIZE12
                  _SIZE13 = .SIZE13
                  _SIZE14 = .SIZE14
                  _SIZE15 = .SIZE15
                  _SIZE16 = .SIZE16
                  _SIZE17 = .SIZE17
                  _SIZE18 = .SIZE18
                  _SIZE19 = .SIZE19
                  _SIZE20 = .SIZE20
                  _SIZE21 = .SIZE21
                  _SIZE22 = .SIZE22
                  _SIZE23 = .SIZE23
                  _SIZE24 = .SIZE24
                  _SIZE25 = .SIZE25
                  _SIZE26 = .SIZE26
                  _SIZE27 = .SIZE27
                  _SIZE28 = .SIZE28
                  _SIZE29 = .SIZE29
                  _SIZE30 = .SIZE30
                  _SIZE31 = .SIZE31
                  _SIZE32 = .SIZE32
                  _SIZE33 = .SIZE33
                  _SIZE34 = .SIZE34
                  _SIZE35 = .SIZE35
                  _SIZE36 = .SIZE36
                  _SIZE37 = .SIZE37
                  _SIZE38 = .SIZE38
                  _SIZE39 = .SIZE39
                  _SIZE40 = .SIZE40
                  _XCOLOR = .XCOLOR
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Remarks")>  _
    Public Class QUERY_MATRIXSUMTEXT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of MATRIXSUMTEXT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of MATRIXSUMTEXT)
            _Parent = nothing
            _Name = "MATRIXSUMTEXT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of MATRIXSUMTEXT)
            _Parent = Parent
            _name = "MATRIXSUMTEXT_SUBFORM"
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
        
        Public Property Value() As list(of MATRIXSUMTEXT)
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
                return GetType(MATRIXSUMTEXT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _MATRIXSUMTEXT As MATRIXSUMTEXT In JsonConvert.DeserializeObject(Of QUERY_MATRIXSUMTEXT)(stream.ReadToEnd).Value
              With _MATRIXSUMTEXT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_MATRIXSUMTEXT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as MATRIXSUMTEXT = JsonConvert.DeserializeObject(Of MATRIXSUMTEXT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, MATRIXSUMTEXT)
                  .TEXT = obj.TEXT
                  .TEXTLINE = obj.TEXTLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new MATRIXSUMTEXT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _MATRIXSUMTEXT as MATRIXSUMTEXT in value
              If _MATRIXSUMTEXT.Equals(trycast(obj,MATRIXSUMTEXT)) Then
                  value.remove(_MATRIXSUMTEXT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class MATRIXSUMTEXT
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetTEXT As Boolean = Boolean.FalseString
        
        Private _TEXT As String
        
        Private _IsSetTEXTLINE As Boolean = Boolean.FalseString
        
        Private _TEXTLINE As Long
        
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
                    return "MATRIXSUMTEXT"
                else
                    return "MATRIXSUMTEXT_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "TEXTLINE={0}", _
                  string.format("{0}",TEXTLINE) _ 
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
        
        <DisplayName("Remarks"),  _
         nType("Edm.String"),  _
         tab("Remarks"),  _
         Pos(4),  _
         twodBarcode("TEXT")>  _
        Public Property TEXT() As String
            Get
                return _TEXT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Remarks", value, "^.{0,68}$") then Exit Property
                _IsSetTEXT = True
                If loading Then
                  _TEXT = Value
                Else
                    if not _TEXT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TEXT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TEXT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("TEXTLINE"),  _
         nType("Edm.Int64"),  _
         tab("Remarks"),  _
         Pos(5),  _
         Browsable(false),  _
         twodBarcode("TEXTLINE")>  _
        Public Property TEXTLINE() As nullable (of int64)
            Get
                return _TEXTLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("TEXTLINE", value, "^[0-9\-]+$") then Exit Property
                _IsSetTEXTLINE = True
                If loading Then
                  _TEXTLINE = Value
                Else
                    if not _TEXTLINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TEXTLINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TEXTLINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetTEXT then
              if f then
                  jw.WriteRaw(", ""TEXT"": ")
              else
                  jw.WriteRaw("""TEXT"": ")
                  f = true
              end if
              jw.WriteValue(me.TEXT)
            end if
            if _IsSetTEXTLINE then
              if f then
                  jw.WriteRaw(", ""TEXTLINE"": ")
              else
                  jw.WriteRaw("""TEXTLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.TEXTLINE)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "MATRIXSUMTEXT")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "TEXTLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetTEXT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TEXT")
              .WriteAttributeString("value", me.TEXT)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "68")
              .WriteEndElement
            end if
            if _IsSetTEXTLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TEXTLINE")
              .WriteAttributeString("value", me.TEXTLINE)
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
                dim obj as MATRIXSUMTEXT = JsonConvert.DeserializeObject(Of MATRIXSUMTEXT)(e.StreamReader.ReadToEnd)
                With obj
                  _TEXT = .TEXT
                  _TEXTLINE = .TEXTLINE
                end with
            End If
        End Sub
    End Class
End Namespace
