Imports system
Imports system.IO
Imports system.xml
Imports System.Net
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Newtonsoft.Json

Namespace OData
    
    <QueryTitle("Service Report-Parts")>  _
    Public Class QUERY_TRANSORDER_Q
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSORDER_Q)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSORDER_Q)
            _Parent = nothing
            _Name = "TRANSORDER_Q"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Projects/Accounts")
            .add(1, "Invoices/Credit Memos for Item")
            .add(2, "Line Items - Remarks")
            .add(3, "Electronic Signature")
            .add(4, "Intrastat Definitions")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSORDER_Q)
            _Parent = Parent
            _name = "TRANSORDER_Q_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Projects/Accounts")
            .add(1, "Invoices/Credit Memos for Item")
            .add(2, "Line Items - Remarks")
            .add(3, "Electronic Signature")
            .add(4, "Intrastat Definitions")
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
        
        Public Property Value() As list(of TRANSORDER_Q)
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
                return GetType(TRANSORDER_Q)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSORDER_Q As TRANSORDER_Q In JsonConvert.DeserializeObject(Of QUERY_TRANSORDER_Q)(stream.ReadToEnd).Value
              With _TRANSORDER_Q
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSORDER_Q)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSORDER_Q = JsonConvert.DeserializeObject(Of TRANSORDER_Q)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSORDER_Q)
                  .CURDATE = obj.CURDATE
                  .TECHNICIANNAME = obj.TECHNICIANNAME
                  .PARTNAME = obj.PARTNAME
                  .PDES = obj.PDES
                  .FAMILYNAME = obj.FAMILYNAME
                  .FAMILYNAMEDES = obj.FAMILYNAMEDES
                  .SERNUM = obj.SERNUM
                  .CQUANT = obj.CQUANT
                  .PQUANT = obj.PQUANT
                  .TQUANT = obj.TQUANT
                  .TUNITNAME = obj.TUNITNAME
                  .PRICE = obj.PRICE
                  .ICODE = obj.ICODE
                  .EXCH = obj.EXCH
                  .PERCENT = obj.PERCENT
                  .QPRICE = obj.QPRICE
                  .CODE = obj.CODE
                  .FLAG = obj.FLAG
                  .NOCHARGENAME = obj.NOCHARGENAME
                  .CHECKING = obj.CHECKING
                  .REVNAME = obj.REVNAME
                  .SERIALNAME = obj.SERIALNAME
                  .CUSTNAME = obj.CUSTNAME
                  .WARHSNAME = obj.WARHSNAME
                  .LOCNAME = obj.LOCNAME
                  .PALLETNAME = obj.PALLETNAME
                  .COSTCNAME = obj.COSTCNAME
                  .BUDCODE = obj.BUDCODE
                  .PBUDCODE = obj.PBUDCODE
                  .PACCNAME = obj.PACCNAME
                  .PACCDES = obj.PACCDES
                  .IVNUM = obj.IVNUM
                  .ORDNAME = obj.ORDNAME
                  .OLINE = obj.OLINE
                  .DUEDATEOI = obj.DUEDATEOI
                  .SNTKLINE = obj.SNTKLINE
                  .TRANS = obj.TRANS
                  .TYPE = obj.TYPE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new TRANSORDER_Q(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSORDER_Q as TRANSORDER_Q in value
              If _TRANSORDER_Q.Equals(trycast(obj,TRANSORDER_Q)) Then
                  value.remove(_TRANSORDER_Q)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSORDER_Q
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetCURDATE As Boolean = Boolean.FalseString
        
        Private _CURDATE As System.DateTimeOffset
        
        Private _IsSetTECHNICIANNAME As Boolean = Boolean.FalseString
        
        Private _TECHNICIANNAME As String
        
        Private _IsSetPARTNAME As Boolean = Boolean.FalseString
        
        Private _PARTNAME As String
        
        Private _IsSetPDES As Boolean = Boolean.FalseString
        
        Private _PDES As String
        
        Private _FAMILYNAME As String
        
        Private _FAMILYNAMEDES As String
        
        Private _IsSetSERNUM As Boolean = Boolean.FalseString
        
        Private _SERNUM As String
        
        Private _IsSetCQUANT As Boolean = Boolean.FalseString
        
        Private _CQUANT As Decimal
        
        Private _PQUANT As Decimal
        
        Private _IsSetTQUANT As Boolean = Boolean.FalseString
        
        Private _TQUANT As Decimal
        
        Private _TUNITNAME As String
        
        Private _IsSetPRICE As Boolean = Boolean.FalseString
        
        Private _PRICE As Decimal
        
        Private _IsSetICODE As Boolean = Boolean.FalseString
        
        Private _ICODE As String
        
        Private _IsSetEXCH As Boolean = Boolean.FalseString
        
        Private _EXCH As Decimal
        
        Private _IsSetPERCENT As Boolean = Boolean.FalseString
        
        Private _PERCENT As Decimal
        
        Private _QPRICE As Decimal
        
        Private _CODE As String
        
        Private _IsSetFLAG As Boolean = Boolean.FalseString
        
        Private _FLAG As String
        
        Private _IsSetNOCHARGENAME As Boolean = Boolean.FalseString
        
        Private _NOCHARGENAME As String
        
        Private _IsSetCHECKING As Boolean = Boolean.FalseString
        
        Private _CHECKING As String
        
        Private _IsSetREVNAME As Boolean = Boolean.FalseString
        
        Private _REVNAME As String
        
        Private _IsSetSERIALNAME As Boolean = Boolean.FalseString
        
        Private _SERIALNAME As String
        
        Private _IsSetCUSTNAME As Boolean = Boolean.FalseString
        
        Private _CUSTNAME As String
        
        Private _IsSetWARHSNAME As Boolean = Boolean.FalseString
        
        Private _WARHSNAME As String
        
        Private _IsSetLOCNAME As Boolean = Boolean.FalseString
        
        Private _LOCNAME As String
        
        Private _IsSetPALLETNAME As Boolean = Boolean.FalseString
        
        Private _PALLETNAME As String
        
        Private _IsSetCOSTCNAME As Boolean = Boolean.FalseString
        
        Private _COSTCNAME As String
        
        Private _IsSetBUDCODE As Boolean = Boolean.FalseString
        
        Private _BUDCODE As String
        
        Private _IsSetPBUDCODE As Boolean = Boolean.FalseString
        
        Private _PBUDCODE As String
        
        Private _IsSetPACCNAME As Boolean = Boolean.FalseString
        
        Private _PACCNAME As String
        
        Private _PACCDES As String
        
        Private _IVNUM As String
        
        Private _IsSetORDNAME As Boolean = Boolean.FalseString
        
        Private _ORDNAME As String
        
        Private _IsSetOLINE As Boolean = Boolean.FalseString
        
        Private _OLINE As Long
        
        Private _DUEDATEOI As System.DateTimeOffset
        
        Private _IsSetSNTKLINE As Boolean = Boolean.FalseString
        
        Private _SNTKLINE As Long
        
        Private _IsSetTRANS As Boolean = Boolean.FalseString
        
        Private _TRANS As Long
        
        Private _IsSetTYPE As Boolean = Boolean.FalseString
        
        Private _TYPE As String
        
        Private _PROJLINK_SUBFORM As QUERY_PROJLINK
        
        Private _TRANSIV_D_SUBFORM As QUERY_TRANSIV_D
        
        Private _TRANSORDERTEXT_SUBFORM As QUERY_TRANSORDERTEXT
        
        Private _TRANSDSIGN_SUBFORM As QUERY_TRANSDSIGN
        
        Private _TRANSORDERINTRASTAT_SUBFORM As QUERY_TRANSORDERINTRASTAT
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Projects/Accounts"))
            ChildQuery.add(1, new oNavigation("Invoices/Credit Memos for Item"))
            ChildQuery.add(2, new oNavigation("Line Items - Remarks"))
            ChildQuery.add(3, new oNavigation("Electronic Signature"))
            ChildQuery.add(4, new oNavigation("Intrastat Definitions"))
            _PROJLINK_SUBFORM = new QUERY_PROJLINK(me)
            _TRANSIV_D_SUBFORM = new QUERY_TRANSIV_D(me)
            _TRANSORDERTEXT_SUBFORM = new QUERY_TRANSORDERTEXT(me)
            _TRANSDSIGN_SUBFORM = new QUERY_TRANSDSIGN(me)
            _TRANSORDERINTRASTAT_SUBFORM = new QUERY_TRANSORDERINTRASTAT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_PROJLINK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Invoices/Credit Memos for Item", _TRANSIV_D_SUBFORM))
                   .add(2, new oNavigation("Line Items - Remarks", _TRANSORDERTEXT_SUBFORM))
                   .add(3, new oNavigation("Electronic Signature", _TRANSDSIGN_SUBFORM))
                   .add(4, new oNavigation("Intrastat Definitions", _TRANSORDERINTRASTAT_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_TRANSIV_D_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Invoices/Credit Memos for Item", _TRANSIV_D_SUBFORM))
                   .add(2, new oNavigation("Line Items - Remarks", _TRANSORDERTEXT_SUBFORM))
                   .add(3, new oNavigation("Electronic Signature", _TRANSDSIGN_SUBFORM))
                   .add(4, new oNavigation("Intrastat Definitions", _TRANSORDERINTRASTAT_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_TRANSORDERTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Invoices/Credit Memos for Item", _TRANSIV_D_SUBFORM))
                   .add(2, new oNavigation("Line Items - Remarks", _TRANSORDERTEXT_SUBFORM))
                   .add(3, new oNavigation("Electronic Signature", _TRANSDSIGN_SUBFORM))
                   .add(4, new oNavigation("Intrastat Definitions", _TRANSORDERINTRASTAT_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_TRANSDSIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Invoices/Credit Memos for Item", _TRANSIV_D_SUBFORM))
                   .add(2, new oNavigation("Line Items - Remarks", _TRANSORDERTEXT_SUBFORM))
                   .add(3, new oNavigation("Electronic Signature", _TRANSDSIGN_SUBFORM))
                   .add(4, new oNavigation("Intrastat Definitions", _TRANSORDERINTRASTAT_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_TRANSORDERINTRASTAT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Invoices/Credit Memos for Item", _TRANSIV_D_SUBFORM))
                   .add(2, new oNavigation("Line Items - Remarks", _TRANSORDERTEXT_SUBFORM))
                   .add(3, new oNavigation("Electronic Signature", _TRANSDSIGN_SUBFORM))
                   .add(4, new oNavigation("Intrastat Definitions", _TRANSORDERINTRASTAT_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Projects/Accounts"))
            ChildQuery.add(1, new oNavigation("Invoices/Credit Memos for Item"))
            ChildQuery.add(2, new oNavigation("Line Items - Remarks"))
            ChildQuery.add(3, new oNavigation("Electronic Signature"))
            ChildQuery.add(4, new oNavigation("Intrastat Definitions"))
            _PROJLINK_SUBFORM = new QUERY_PROJLINK(me)
            _TRANSIV_D_SUBFORM = new QUERY_TRANSIV_D(me)
            _TRANSORDERTEXT_SUBFORM = new QUERY_TRANSORDERTEXT(me)
            _TRANSDSIGN_SUBFORM = new QUERY_TRANSDSIGN(me)
            _TRANSORDERINTRASTAT_SUBFORM = new QUERY_TRANSORDERINTRASTAT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_PROJLINK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Invoices/Credit Memos for Item", _TRANSIV_D_SUBFORM))
                   .add(2, new oNavigation("Line Items - Remarks", _TRANSORDERTEXT_SUBFORM))
                   .add(3, new oNavigation("Electronic Signature", _TRANSDSIGN_SUBFORM))
                   .add(4, new oNavigation("Intrastat Definitions", _TRANSORDERINTRASTAT_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_TRANSIV_D_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Invoices/Credit Memos for Item", _TRANSIV_D_SUBFORM))
                   .add(2, new oNavigation("Line Items - Remarks", _TRANSORDERTEXT_SUBFORM))
                   .add(3, new oNavigation("Electronic Signature", _TRANSDSIGN_SUBFORM))
                   .add(4, new oNavigation("Intrastat Definitions", _TRANSORDERINTRASTAT_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_TRANSORDERTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Invoices/Credit Memos for Item", _TRANSIV_D_SUBFORM))
                   .add(2, new oNavigation("Line Items - Remarks", _TRANSORDERTEXT_SUBFORM))
                   .add(3, new oNavigation("Electronic Signature", _TRANSDSIGN_SUBFORM))
                   .add(4, new oNavigation("Intrastat Definitions", _TRANSORDERINTRASTAT_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_TRANSDSIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Invoices/Credit Memos for Item", _TRANSIV_D_SUBFORM))
                   .add(2, new oNavigation("Line Items - Remarks", _TRANSORDERTEXT_SUBFORM))
                   .add(3, new oNavigation("Electronic Signature", _TRANSDSIGN_SUBFORM))
                   .add(4, new oNavigation("Intrastat Definitions", _TRANSORDERINTRASTAT_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_TRANSORDERINTRASTAT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Invoices/Credit Memos for Item", _TRANSIV_D_SUBFORM))
                   .add(2, new oNavigation("Line Items - Remarks", _TRANSORDERTEXT_SUBFORM))
                   .add(3, new oNavigation("Electronic Signature", _TRANSDSIGN_SUBFORM))
                   .add(4, new oNavigation("Intrastat Definitions", _TRANSORDERINTRASTAT_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "TRANSORDER_Q"
                else
                    return "TRANSORDER_Q_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "SNTKLINE={0},TYPE={1}", _
                  string.format("{0}",SNTKLINE), _
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
        
        <DisplayName("Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Date"),  _
         Pos(10),  _
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
        
        <DisplayName("Technician"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(15),  _
         twodBarcode("TECHNICIANNAME")>  _
        Public Property TECHNICIANNAME() As String
            Get
                return _TECHNICIANNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Technician", value, "^.{0,20}$") then Exit Property
                _IsSetTECHNICIANNAME = True
                If loading Then
                  _TECHNICIANNAME = Value
                Else
                    if not _TECHNICIANNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TECHNICIANNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TECHNICIANNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Part Number"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(20),  _
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
         tab("Date"),  _
         Pos(30),  _
         twodBarcode("PDES")>  _
        Public Property PDES() As String
            Get
                return _PDES
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Part Description", value, "^.{0,48}$") then Exit Property
                _IsSetPDES = True
                If loading Then
                  _PDES = Value
                Else
                    if not _PDES = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PDES", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PDES = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Part Family"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(31),  _
         [ReadOnly](true),  _
         twodBarcode("FAMILYNAME")>  _
        Public Property FAMILYNAME() As String
            Get
                return _FAMILYNAME
            End Get
            Set
                if not(value is nothing) then
                  _FAMILYNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Family Description"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(32),  _
         [ReadOnly](true),  _
         twodBarcode("FAMILYNAMEDES")>  _
        Public Property FAMILYNAMEDES() As String
            Get
                return _FAMILYNAMEDES
            End Get
            Set
                if not(value is nothing) then
                  _FAMILYNAMEDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Serial Number"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(35),  _
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
        
        <DisplayName("Planned Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Date"),  _
         Pos(40),  _
         twodBarcode("CQUANT")>  _
        Public Property CQUANT() As nullable(of decimal)
            Get
                return _CQUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Planned Quantity", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetCQUANT = True
                If loading Then
                  _CQUANT = Value
                Else
                    if not _CQUANT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CQUANT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CQUANT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Warehouse Balance"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Warehouse Balance"),  _
         Pos(42),  _
         [ReadOnly](true),  _
         twodBarcode("PQUANT")>  _
        Public Property PQUANT() As nullable(of decimal)
            Get
                return _PQUANT
            End Get
            Set
                if not(value is nothing) then
                  _PQUANT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Actual Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Warehouse Balance"),  _
         Pos(44),  _
         twodBarcode("TQUANT")>  _
        Public Property TQUANT() As nullable(of decimal)
            Get
                return _TQUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Actual Quantity", value, "^[0-9\.\-]+$") then Exit Property
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
        
        <DisplayName("Unit"),  _
         nType("Edm.String"),  _
         tab("Warehouse Balance"),  _
         Pos(75),  _
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
        
        <DisplayName("Unit Price"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(13),  _
         tab("Warehouse Balance"),  _
         Pos(82),  _
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
        
        <DisplayName("Item Currency"),  _
         nType("Edm.String"),  _
         tab("Warehouse Balance"),  _
         Pos(84),  _
         Mandatory(true),  _
         twodBarcode("ICODE")>  _
        Public Property ICODE() As String
            Get
                return _ICODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Item Currency", value, "^.{0,3}$") then Exit Property
                _IsSetICODE = True
                If loading Then
                  _ICODE = Value
                Else
                    if not _ICODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ICODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ICODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Exchange Rate"),  _
         nType("Edm.Decimal"),  _
         Scale(6),  _
         Precision(13),  _
         tab("Warehouse Balance"),  _
         Pos(85),  _
         twodBarcode("EXCH")>  _
        Public Property EXCH() As nullable(of decimal)
            Get
                return _EXCH
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Exchange Rate", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetEXCH = True
                If loading Then
                  _EXCH = Value
                Else
                    if not _EXCH = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EXCH", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EXCH = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Discount%"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(8),  _
         tab("Warehouse Balance"),  _
         Pos(86),  _
         twodBarcode("PERCENT")>  _
        Public Property PERCENT() As nullable(of decimal)
            Get
                return _PERCENT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Discount%", value, "^[0-9\.\-]+$") then Exit Property
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
        
        <DisplayName("Extended Price"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(16),  _
         tab("Warehouse Balance"),  _
         Pos(88),  _
         [ReadOnly](true),  _
         twodBarcode("QPRICE")>  _
        Public Property QPRICE() As nullable(of decimal)
            Get
                return _QPRICE
            End Get
            Set
                if not(value is nothing) then
                  _QPRICE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Document Currency"),  _
         nType("Edm.String"),  _
         tab("Document Currency"),  _
         Pos(89),  _
         [ReadOnly](true),  _
         twodBarcode("CODE")>  _
        Public Property CODE() As String
            Get
                return _CODE
            End Get
            Set
                if not(value is nothing) then
                  _CODE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Billable?"),  _
         nType("Edm.String"),  _
         tab("Document Currency"),  _
         Pos(91),  _
         twodBarcode("FLAG")>  _
        Public Property FLAG() As String
            Get
                return _FLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Billable?", value, "^.{0,1}$") then Exit Property
                _IsSetFLAG = True
                If loading Then
                  _FLAG = Value
                Else
                    if not _FLAG = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FLAG", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FLAG = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Billing Exempt Type"),  _
         nType("Edm.String"),  _
         tab("Document Currency"),  _
         Pos(92),  _
         twodBarcode("NOCHARGENAME")>  _
        Public Property NOCHARGENAME() As String
            Get
                return _NOCHARGENAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Billing Exempt Type", value, "^.{0,20}$") then Exit Property
                _IsSetNOCHARGENAME = True
                If loading Then
                  _NOCHARGENAME = Value
                Else
                    if not _NOCHARGENAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("NOCHARGENAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _NOCHARGENAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Checking"),  _
         nType("Edm.String"),  _
         tab("Document Currency"),  _
         Pos(95),  _
         twodBarcode("CHECKING")>  _
        Public Property CHECKING() As String
            Get
                return _CHECKING
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Checking", value, "^.{0,1}$") then Exit Property
                _IsSetCHECKING = True
                If loading Then
                  _CHECKING = Value
                Else
                    if not _CHECKING = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CHECKING", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CHECKING = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Part Revision No."),  _
         nType("Edm.String"),  _
         tab("Document Currency"),  _
         Pos(97),  _
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
        
        <DisplayName("Work Order/Lot No."),  _
         nType("Edm.String"),  _
         tab("Document Currency"),  _
         Pos(100),  _
         Mandatory(true),  _
         twodBarcode("SERIALNAME")>  _
        Public Property SERIALNAME() As String
            Get
                return _SERIALNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Work Order/Lot No.", value, "^.{0,22}$") then Exit Property
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
         tab("Document Currency"),  _
         Pos(102),  _
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
        
        <DisplayName("Warehouse"),  _
         nType("Edm.String"),  _
         tab("Document Currency"),  _
         Pos(104),  _
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
         tab("Bin"),  _
         Pos(106),  _
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
        
        <DisplayName("Pallet"),  _
         nType("Edm.String"),  _
         tab("Bin"),  _
         Pos(108),  _
         twodBarcode("PALLETNAME")>  _
        Public Property PALLETNAME() As String
            Get
                return _PALLETNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Pallet", value, "^.{0,16}$") then Exit Property
                _IsSetPALLETNAME = True
                If loading Then
                  _PALLETNAME = Value
                Else
                    if not _PALLETNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PALLETNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PALLETNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Profit/Cost Centre"),  _
         nType("Edm.String"),  _
         tab("Bin"),  _
         Pos(110),  _
         twodBarcode("COSTCNAME")>  _
        Public Property COSTCNAME() As String
            Get
                return _COSTCNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Profit/Cost Centre", value, "^.{0,8}$") then Exit Property
                _IsSetCOSTCNAME = True
                If loading Then
                  _COSTCNAME = Value
                Else
                    if not _COSTCNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("COSTCNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _COSTCNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Budget Item"),  _
         nType("Edm.String"),  _
         tab("Bin"),  _
         Pos(112),  _
         twodBarcode("BUDCODE")>  _
        Public Property BUDCODE() As String
            Get
                return _BUDCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Budget Item", value, "^.{0,24}$") then Exit Property
                _IsSetBUDCODE = True
                If loading Then
                  _BUDCODE = Value
                Else
                    if not _BUDCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("BUDCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _BUDCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Purchasing Budget"),  _
         nType("Edm.String"),  _
         tab("Bin"),  _
         Pos(116),  _
         twodBarcode("PBUDCODE")>  _
        Public Property PBUDCODE() As String
            Get
                return _PBUDCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Purchasing Budget", value, "^.{0,24}$") then Exit Property
                _IsSetPBUDCODE = True
                If loading Then
                  _PBUDCODE = Value
                Else
                    if not _PBUDCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PBUDCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PBUDCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Expense Account"),  _
         nType("Edm.String"),  _
         tab("Bin"),  _
         Pos(118),  _
         twodBarcode("PACCNAME")>  _
        Public Property PACCNAME() As String
            Get
                return _PACCNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Expense Account", value, "^.{0,16}$") then Exit Property
                _IsSetPACCNAME = True
                If loading Then
                  _PACCNAME = Value
                Else
                    if not _PACCNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PACCNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PACCNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Account Description"),  _
         nType("Edm.String"),  _
         tab("Bin"),  _
         Pos(119),  _
         [ReadOnly](true),  _
         twodBarcode("PACCDES")>  _
        Public Property PACCDES() As String
            Get
                return _PACCDES
            End Get
            Set
                if not(value is nothing) then
                  _PACCDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Invoice"),  _
         nType("Edm.String"),  _
         tab("Bin"),  _
         Pos(120),  _
         [ReadOnly](true),  _
         twodBarcode("IVNUM")>  _
        Public Property IVNUM() As String
            Get
                return _IVNUM
            End Get
            Set
                if not(value is nothing) then
                  _IVNUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("Order"),  _
         nType("Edm.String"),  _
         tab("Order"),  _
         Pos(130),  _
         twodBarcode("ORDNAME")>  _
        Public Property ORDNAME() As String
            Get
                return _ORDNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Order", value, "^.{0,16}$") then Exit Property
                _IsSetORDNAME = True
                If loading Then
                  _ORDNAME = Value
                Else
                    if not _ORDNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ORDNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ORDNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Line"),  _
         nType("Edm.Int64"),  _
         tab("Order"),  _
         Pos(132),  _
         twodBarcode("OLINE")>  _
        Public Property OLINE() As nullable (of int64)
            Get
                return _OLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Line", value, "^[0-9\-]+$") then Exit Property
                _IsSetOLINE = True
                If loading Then
                  _OLINE = Value
                Else
                    if not _OLINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("OLINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _OLINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Due Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Order"),  _
         Pos(134),  _
         [ReadOnly](true),  _
         twodBarcode("DUEDATEOI")>  _
        Public Property DUEDATEOI() As nullable (of DateTimeOffset)
            Get
                return _DUEDATEOI
            End Get
            Set
                if not(value is nothing) then
                  _DUEDATEOI = Value
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Order"),  _
         Pos(99),  _
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
        
        <DisplayName("Transaction (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Order"),  _
         Pos(199),  _
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
         tab("Order"),  _
         Pos(199),  _
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
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property PROJLINK_SUBFORM() As QUERY_PROJLINK
            Get
                return _PROJLINK_SUBFORM
            End Get
            Set
                _PROJLINK_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSIV_D_SUBFORM() As QUERY_TRANSIV_D
            Get
                return _TRANSIV_D_SUBFORM
            End Get
            Set
                _TRANSIV_D_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSORDERTEXT_SUBFORM() As QUERY_TRANSORDERTEXT
            Get
                return _TRANSORDERTEXT_SUBFORM
            End Get
            Set
                _TRANSORDERTEXT_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSDSIGN_SUBFORM() As QUERY_TRANSDSIGN
            Get
                return _TRANSDSIGN_SUBFORM
            End Get
            Set
                _TRANSDSIGN_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSORDERINTRASTAT_SUBFORM() As QUERY_TRANSORDERINTRASTAT
            Get
                return _TRANSORDERINTRASTAT_SUBFORM
            End Get
            Set
                _TRANSORDERINTRASTAT_SUBFORM = value
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
            if _IsSetTECHNICIANNAME then
              if f then
                  jw.WriteRaw(", ""TECHNICIANNAME"": ")
              else
                  jw.WriteRaw("""TECHNICIANNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.TECHNICIANNAME)
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
            if _IsSetPDES then
              if f then
                  jw.WriteRaw(", ""PDES"": ")
              else
                  jw.WriteRaw("""PDES"": ")
                  f = true
              end if
              jw.WriteValue(me.PDES)
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
            if _IsSetCQUANT then
              if f then
                  jw.WriteRaw(", ""CQUANT"": ")
              else
                  jw.WriteRaw("""CQUANT"": ")
                  f = true
              end if
              jw.WriteValue(me.CQUANT)
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
            if _IsSetPRICE then
              if f then
                  jw.WriteRaw(", ""PRICE"": ")
              else
                  jw.WriteRaw("""PRICE"": ")
                  f = true
              end if
              jw.WriteValue(me.PRICE)
            end if
            if _IsSetICODE then
              if f then
                  jw.WriteRaw(", ""ICODE"": ")
              else
                  jw.WriteRaw("""ICODE"": ")
                  f = true
              end if
              jw.WriteValue(me.ICODE)
            end if
            if _IsSetEXCH then
              if f then
                  jw.WriteRaw(", ""EXCH"": ")
              else
                  jw.WriteRaw("""EXCH"": ")
                  f = true
              end if
              jw.WriteValue(me.EXCH)
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
            if _IsSetFLAG then
              if f then
                  jw.WriteRaw(", ""FLAG"": ")
              else
                  jw.WriteRaw("""FLAG"": ")
                  f = true
              end if
              jw.WriteValue(me.FLAG)
            end if
            if _IsSetNOCHARGENAME then
              if f then
                  jw.WriteRaw(", ""NOCHARGENAME"": ")
              else
                  jw.WriteRaw("""NOCHARGENAME"": ")
                  f = true
              end if
              jw.WriteValue(me.NOCHARGENAME)
            end if
            if _IsSetCHECKING then
              if f then
                  jw.WriteRaw(", ""CHECKING"": ")
              else
                  jw.WriteRaw("""CHECKING"": ")
                  f = true
              end if
              jw.WriteValue(me.CHECKING)
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
            if _IsSetPALLETNAME then
              if f then
                  jw.WriteRaw(", ""PALLETNAME"": ")
              else
                  jw.WriteRaw("""PALLETNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.PALLETNAME)
            end if
            if _IsSetCOSTCNAME then
              if f then
                  jw.WriteRaw(", ""COSTCNAME"": ")
              else
                  jw.WriteRaw("""COSTCNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.COSTCNAME)
            end if
            if _IsSetBUDCODE then
              if f then
                  jw.WriteRaw(", ""BUDCODE"": ")
              else
                  jw.WriteRaw("""BUDCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.BUDCODE)
            end if
            if _IsSetPBUDCODE then
              if f then
                  jw.WriteRaw(", ""PBUDCODE"": ")
              else
                  jw.WriteRaw("""PBUDCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.PBUDCODE)
            end if
            if _IsSetPACCNAME then
              if f then
                  jw.WriteRaw(", ""PACCNAME"": ")
              else
                  jw.WriteRaw("""PACCNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.PACCNAME)
            end if
            if _IsSetORDNAME then
              if f then
                  jw.WriteRaw(", ""ORDNAME"": ")
              else
                  jw.WriteRaw("""ORDNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.ORDNAME)
            end if
            if _IsSetOLINE then
              if f then
                  jw.WriteRaw(", ""OLINE"": ")
              else
                  jw.WriteRaw("""OLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.OLINE)
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
            if _PROJLINK_SUBFORM.value.count > 0 then
              jw.WriteRaw(", PROJLINK_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as PROJLINK in _PROJLINK_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _PROJLINK_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _TRANSIV_D_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSIV_D_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSIV_D in _TRANSIV_D_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSIV_D_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _TRANSORDERTEXT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSORDERTEXT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSORDERTEXT in _TRANSORDERTEXT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSORDERTEXT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _TRANSDSIGN_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSDSIGN_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSDSIGN in _TRANSDSIGN_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSDSIGN_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _TRANSORDERINTRASTAT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSORDERINTRASTAT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSORDERINTRASTAT in _TRANSORDERINTRASTAT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSORDERINTRASTAT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "TRANSORDER_Q")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "SNTKLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "TYPE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            if _IsSetCURDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CURDATE")
              .WriteAttributeString("value", me.CURDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetTECHNICIANNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TECHNICIANNAME")
              .WriteAttributeString("value", me.TECHNICIANNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
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
            if _IsSetPDES then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PDES")
              .WriteAttributeString("value", me.PDES)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "48")
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
            if _IsSetCQUANT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CQUANT")
              .WriteAttributeString("value", me.CQUANT)
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
            if _IsSetPRICE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PRICE")
              .WriteAttributeString("value", me.PRICE)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "2")
              .WriteAttributeString("Precision", "13")
              .WriteEndElement
            end if
            if _IsSetICODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ICODE")
              .WriteAttributeString("value", me.ICODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
            end if
            if _IsSetEXCH then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EXCH")
              .WriteAttributeString("value", me.EXCH)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "6")
              .WriteAttributeString("Precision", "13")
              .WriteEndElement
            end if
            if _IsSetPERCENT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PERCENT")
              .WriteAttributeString("value", me.PERCENT)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "2")
              .WriteAttributeString("Precision", "8")
              .WriteEndElement
            end if
            if _IsSetFLAG then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FLAG")
              .WriteAttributeString("value", me.FLAG)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetNOCHARGENAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "NOCHARGENAME")
              .WriteAttributeString("value", me.NOCHARGENAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
              .WriteEndElement
            end if
            if _IsSetCHECKING then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CHECKING")
              .WriteAttributeString("value", me.CHECKING)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
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
            if _IsSetPALLETNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PALLETNAME")
              .WriteAttributeString("value", me.PALLETNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetCOSTCNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "COSTCNAME")
              .WriteAttributeString("value", me.COSTCNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "8")
              .WriteEndElement
            end if
            if _IsSetBUDCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "BUDCODE")
              .WriteAttributeString("value", me.BUDCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "24")
              .WriteEndElement
            end if
            if _IsSetPBUDCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PBUDCODE")
              .WriteAttributeString("value", me.PBUDCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "24")
              .WriteEndElement
            end if
            if _IsSetPACCNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PACCNAME")
              .WriteAttributeString("value", me.PACCNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetORDNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ORDNAME")
              .WriteAttributeString("value", me.ORDNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetOLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "OLINE")
              .WriteAttributeString("value", me.OLINE)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetSNTKLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SNTKLINE")
              .WriteAttributeString("value", me.SNTKLINE)
              .WriteAttributeString("type", "Edm.Int64")
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
            if _PROJLINK_SUBFORM.value.count > 0 then
              for each itm as PROJLINK in _PROJLINK_SUBFORM.Value
                itm.toXML(xw,"PROJLINK_SUBFORM")
              next
            end if
            if _TRANSIV_D_SUBFORM.value.count > 0 then
              for each itm as TRANSIV_D in _TRANSIV_D_SUBFORM.Value
                itm.toXML(xw,"TRANSIV_D_SUBFORM")
              next
            end if
            if _TRANSORDERTEXT_SUBFORM.value.count > 0 then
              for each itm as TRANSORDERTEXT in _TRANSORDERTEXT_SUBFORM.Value
                itm.toXML(xw,"TRANSORDERTEXT_SUBFORM")
              next
            end if
            if _TRANSDSIGN_SUBFORM.value.count > 0 then
              for each itm as TRANSDSIGN in _TRANSDSIGN_SUBFORM.Value
                itm.toXML(xw,"TRANSDSIGN_SUBFORM")
              next
            end if
            if _TRANSORDERINTRASTAT_SUBFORM.value.count > 0 then
              for each itm as TRANSORDERINTRASTAT in _TRANSORDERINTRASTAT_SUBFORM.Value
                itm.toXML(xw,"TRANSORDERINTRASTAT_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSORDER_Q = JsonConvert.DeserializeObject(Of TRANSORDER_Q)(e.StreamReader.ReadToEnd)
                With obj
                  _CURDATE = .CURDATE
                  _TECHNICIANNAME = .TECHNICIANNAME
                  _PARTNAME = .PARTNAME
                  _PDES = .PDES
                  _FAMILYNAME = .FAMILYNAME
                  _FAMILYNAMEDES = .FAMILYNAMEDES
                  _SERNUM = .SERNUM
                  _CQUANT = .CQUANT
                  _PQUANT = .PQUANT
                  _TQUANT = .TQUANT
                  _TUNITNAME = .TUNITNAME
                  _PRICE = .PRICE
                  _ICODE = .ICODE
                  _EXCH = .EXCH
                  _PERCENT = .PERCENT
                  _QPRICE = .QPRICE
                  _CODE = .CODE
                  _FLAG = .FLAG
                  _NOCHARGENAME = .NOCHARGENAME
                  _CHECKING = .CHECKING
                  _REVNAME = .REVNAME
                  _SERIALNAME = .SERIALNAME
                  _CUSTNAME = .CUSTNAME
                  _WARHSNAME = .WARHSNAME
                  _LOCNAME = .LOCNAME
                  _PALLETNAME = .PALLETNAME
                  _COSTCNAME = .COSTCNAME
                  _BUDCODE = .BUDCODE
                  _PBUDCODE = .PBUDCODE
                  _PACCNAME = .PACCNAME
                  _PACCDES = .PACCDES
                  _IVNUM = .IVNUM
                  _ORDNAME = .ORDNAME
                  _OLINE = .OLINE
                  _DUEDATEOI = .DUEDATEOI
                  _SNTKLINE = .SNTKLINE
                  _TRANS = .TRANS
                  _TYPE = .TYPE
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_TRANSORDER_Q
        
        PROJLINK = 0
        
        TRANSIV_D = 1
        
        TRANSORDERTEXT = 2
        
        TRANSDSIGN = 3
        
        TRANSORDERINTRASTAT = 4
    End Enum
    
    <QueryTitle("Projects/Accounts")>  _
    Public Class QUERY_PROJLINK
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PROJLINK)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PROJLINK)
            _Parent = nothing
            _Name = "PROJLINK"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PROJLINK)
            _Parent = Parent
            _name = "PROJLINK_SUBFORM"
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
        
        Public Property Value() As list(of PROJLINK)
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
                return GetType(PROJLINK)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PROJLINK As PROJLINK In JsonConvert.DeserializeObject(Of QUERY_PROJLINK)(stream.ReadToEnd).Value
              With _PROJLINK
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PROJLINK)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PROJLINK = JsonConvert.DeserializeObject(Of PROJLINK)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PROJLINK)
                  .DOCNO = obj.DOCNO
                  .PROJDES = obj.PROJDES
                  .ACCNAME = obj.ACCNAME
                  .ACCDES = obj.ACCDES
                  .WBS = obj.WBS
                  .PROJACT = obj.PROJACT
                  .ACTDES = obj.ACTDES
                  .RPROJACT = obj.RPROJACT
                  .EXECPERCENT = obj.EXECPERCENT
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PROJLINK(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PROJLINK as PROJLINK in value
              If _PROJLINK.Equals(trycast(obj,PROJLINK)) Then
                  value.remove(_PROJLINK)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PROJLINK
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetDOCNO As Boolean = Boolean.FalseString
        
        Private _DOCNO As String
        
        Private _PROJDES As String
        
        Private _IsSetACCNAME As Boolean = Boolean.FalseString
        
        Private _ACCNAME As String
        
        Private _ACCDES As String
        
        Private _IsSetWBS As Boolean = Boolean.FalseString
        
        Private _WBS As String
        
        Private _PROJACT As Long
        
        Private _ACTDES As String
        
        Private _RPROJACT As Long
        
        Private _IsSetEXECPERCENT As Boolean = Boolean.FalseString
        
        Private _EXECPERCENT As Decimal
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
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
                    return "PROJLINK"
                else
                    return "PROJLINK_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "" _ 
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
        
        <DisplayName("Project Number"),  _
         nType("Edm.String"),  _
         tab("Project Number"),  _
         Pos(10),  _
         twodBarcode("DOCNO")>  _
        Public Property DOCNO() As String
            Get
                return _DOCNO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Project Number", value, "^.{0,16}$") then Exit Property
                _IsSetDOCNO = True
                If loading Then
                  _DOCNO = Value
                Else
                    if not _DOCNO = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("DOCNO", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _DOCNO = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Project Description"),  _
         nType("Edm.String"),  _
         tab("Project Number"),  _
         Pos(12),  _
         [ReadOnly](true),  _
         twodBarcode("PROJDES")>  _
        Public Property PROJDES() As String
            Get
                return _PROJDES
            End Get
            Set
                if not(value is nothing) then
                  _PROJDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Account No."),  _
         nType("Edm.String"),  _
         tab("Project Number"),  _
         Pos(14),  _
         twodBarcode("ACCNAME")>  _
        Public Property ACCNAME() As String
            Get
                return _ACCNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Account No.", value, "^.{0,16}$") then Exit Property
                _IsSetACCNAME = True
                If loading Then
                  _ACCNAME = Value
                Else
                    if not _ACCNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ACCNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ACCNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Account Description"),  _
         nType("Edm.String"),  _
         tab("Project Number"),  _
         Pos(16),  _
         [ReadOnly](true),  _
         twodBarcode("ACCDES")>  _
        Public Property ACCDES() As String
            Get
                return _ACCDES
            End Get
            Set
                if not(value is nothing) then
                  _ACCDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("WBS Code"),  _
         nType("Edm.String"),  _
         tab("Project Number"),  _
         Pos(20),  _
         twodBarcode("WBS")>  _
        Public Property WBS() As String
            Get
                return _WBS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("WBS Code", value, "^.{0,24}$") then Exit Property
                _IsSetWBS = True
                If loading Then
                  _WBS = Value
                Else
                    if not _WBS = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("WBS", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _WBS = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Activity ID"),  _
         nType("Edm.Int64"),  _
         tab("Project Number"),  _
         Pos(21),  _
         [ReadOnly](true),  _
         twodBarcode("PROJACT")>  _
        Public Property PROJACT() As nullable (of int64)
            Get
                return _PROJACT
            End Get
            Set
                if not(value is nothing) then
                  _PROJACT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Name of Activity"),  _
         nType("Edm.String"),  _
         tab("Project Number"),  _
         Pos(22),  _
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
        
        <DisplayName("SOW ID"),  _
         nType("Edm.Int64"),  _
         tab("Project Number"),  _
         Pos(25),  _
         [ReadOnly](true),  _
         twodBarcode("RPROJACT")>  _
        Public Property RPROJACT() As nullable (of int64)
            Get
                return _RPROJACT
            End Get
            Set
                if not(value is nothing) then
                  _RPROJACT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Percent Completed"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(6),  _
         tab("Percent Completed"),  _
         Pos(32),  _
         twodBarcode("EXECPERCENT")>  _
        Public Property EXECPERCENT() As nullable(of decimal)
            Get
                return _EXECPERCENT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Percent Completed", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetEXECPERCENT = True
                If loading Then
                  _EXECPERCENT = Value
                Else
                    if not _EXECPERCENT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EXECPERCENT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EXECPERCENT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Percent Completed"),  _
         Pos(80),  _
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
         tab("Percent Completed"),  _
         Pos(82),  _
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
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetDOCNO then
              if f then
                  jw.WriteRaw(", ""DOCNO"": ")
              else
                  jw.WriteRaw("""DOCNO"": ")
                  f = true
              end if
              jw.WriteValue(me.DOCNO)
            end if
            if _IsSetACCNAME then
              if f then
                  jw.WriteRaw(", ""ACCNAME"": ")
              else
                  jw.WriteRaw("""ACCNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.ACCNAME)
            end if
            if _IsSetWBS then
              if f then
                  jw.WriteRaw(", ""WBS"": ")
              else
                  jw.WriteRaw("""WBS"": ")
                  f = true
              end if
              jw.WriteValue(me.WBS)
            end if
            if _IsSetEXECPERCENT then
              if f then
                  jw.WriteRaw(", ""EXECPERCENT"": ")
              else
                  jw.WriteRaw("""EXECPERCENT"": ")
                  f = true
              end if
              jw.WriteValue(me.EXECPERCENT)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "PROJLINK")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
            if _IsSetDOCNO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DOCNO")
              .WriteAttributeString("value", me.DOCNO)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetACCNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ACCNAME")
              .WriteAttributeString("value", me.ACCNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetWBS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "WBS")
              .WriteAttributeString("value", me.WBS)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "24")
              .WriteEndElement
            end if
            if _IsSetEXECPERCENT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EXECPERCENT")
              .WriteAttributeString("value", me.EXECPERCENT)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "2")
              .WriteAttributeString("Precision", "6")
              .WriteEndElement
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PROJLINK = JsonConvert.DeserializeObject(Of PROJLINK)(e.StreamReader.ReadToEnd)
                With obj
                  _DOCNO = .DOCNO
                  _PROJDES = .PROJDES
                  _ACCNAME = .ACCNAME
                  _ACCDES = .ACCDES
                  _WBS = .WBS
                  _PROJACT = .PROJACT
                  _ACTDES = .ACTDES
                  _RPROJACT = .RPROJACT
                  _EXECPERCENT = .EXECPERCENT
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Invoices/Credit Memos for Item")>  _
    Public Class QUERY_TRANSIV_D
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSIV_D)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSIV_D)
            _Parent = nothing
            _Name = "TRANSIV_D"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSIV_D)
            _Parent = Parent
            _name = "TRANSIV_D_SUBFORM"
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
        
        Public Property Value() As list(of TRANSIV_D)
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
                return GetType(TRANSIV_D)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSIV_D As TRANSIV_D In JsonConvert.DeserializeObject(Of QUERY_TRANSIV_D)(stream.ReadToEnd).Value
              With _TRANSIV_D
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSIV_D)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSIV_D = JsonConvert.DeserializeObject(Of TRANSIV_D)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSIV_D)
                  .IVNUM = obj.IVNUM
                  .IVDES = obj.IVDES
                  .IVDATE = obj.IVDATE
                  .TQUANT = obj.TQUANT
                  .TUNITNAME = obj.TUNITNAME
                  .PRICE = obj.PRICE
                  .PERCENT = obj.PERCENT
                  .QPRICE = obj.QPRICE
                  .CODE = obj.CODE
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .IV = obj.IV
                  .KLINE = obj.KLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new TRANSIV_D(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSIV_D as TRANSIV_D in value
              If _TRANSIV_D.Equals(trycast(obj,TRANSIV_D)) Then
                  value.remove(_TRANSIV_D)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSIV_D
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IVNUM As String
        
        Private _IVDES As String
        
        Private _IVDATE As System.DateTimeOffset
        
        Private _TQUANT As Decimal
        
        Private _TUNITNAME As String
        
        Private _PRICE As Decimal
        
        Private _PERCENT As Decimal
        
        Private _QPRICE As Decimal
        
        Private _CODE As String
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _IV As Long
        
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
                    return "TRANSIV_D"
                else
                    return "TRANSIV_D_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "IV={0},KLINE={1}", _
                  string.format("{0}",IV), _
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
        
        <DisplayName("Invoice/Memo Number"),  _
         nType("Edm.String"),  _
         tab("Invoice/Memo Number"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("IVNUM")>  _
        Public Property IVNUM() As String
            Get
                return _IVNUM
            End Get
            Set
                if not(value is nothing) then
                  _IVNUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("Document Type"),  _
         nType("Edm.String"),  _
         tab("Invoice/Memo Number"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("IVDES")>  _
        Public Property IVDES() As String
            Get
                return _IVDES
            End Get
            Set
                if not(value is nothing) then
                  _IVDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Invoice/Memo Number"),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("IVDATE")>  _
        Public Property IVDATE() As nullable (of DateTimeOffset)
            Get
                return _IVDATE
            End Get
            Set
                if not(value is nothing) then
                  _IVDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Invoice/Memo Number"),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("TQUANT")>  _
        Public Property TQUANT() As nullable(of decimal)
            Get
                return _TQUANT
            End Get
            Set
                if not(value is nothing) then
                  _TQUANT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Unit"),  _
         nType("Edm.String"),  _
         tab("Invoice/Memo Number"),  _
         Pos(42),  _
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
        
        <DisplayName("Unit Price"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(13),  _
         tab("Invoice/Memo Number"),  _
         Pos(50),  _
         [ReadOnly](true),  _
         twodBarcode("PRICE")>  _
        Public Property PRICE() As nullable(of decimal)
            Get
                return _PRICE
            End Get
            Set
                if not(value is nothing) then
                  _PRICE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Discount%"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(6),  _
         tab("Invoice/Memo Number"),  _
         Pos(55),  _
         [ReadOnly](true),  _
         twodBarcode("PERCENT")>  _
        Public Property PERCENT() As nullable(of decimal)
            Get
                return _PERCENT
            End Get
            Set
                if not(value is nothing) then
                  _PERCENT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Extended Price"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(16),  _
         tab("Invoice/Memo Number"),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("QPRICE")>  _
        Public Property QPRICE() As nullable(of decimal)
            Get
                return _QPRICE
            End Get
            Set
                if not(value is nothing) then
                  _QPRICE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Curr"),  _
         nType("Edm.String"),  _
         tab("Curr"),  _
         Pos(63),  _
         [ReadOnly](true),  _
         twodBarcode("CODE")>  _
        Public Property CODE() As String
            Get
                return _CODE
            End Get
            Set
                if not(value is nothing) then
                  _CODE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Curr"),  _
         Pos(110),  _
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
         tab("Curr"),  _
         Pos(120),  _
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
        
        <DisplayName("Invoice (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Curr"),  _
         Pos(99),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("IV")>  _
        Public Property IV() As nullable (of int64)
            Get
                return _IV
            End Get
            Set
                if not(value is nothing) then
                  _IV = Value
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Curr"),  _
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
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "TRANSIV_D")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "IV")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "KLINE")
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
                dim obj as TRANSIV_D = JsonConvert.DeserializeObject(Of TRANSIV_D)(e.StreamReader.ReadToEnd)
                With obj
                  _IVNUM = .IVNUM
                  _IVDES = .IVDES
                  _IVDATE = .IVDATE
                  _TQUANT = .TQUANT
                  _TUNITNAME = .TUNITNAME
                  _PRICE = .PRICE
                  _PERCENT = .PERCENT
                  _QPRICE = .QPRICE
                  _CODE = .CODE
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _IV = .IV
                  _KLINE = .KLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Line Items - Remarks")>  _
    Public Class QUERY_TRANSORDERTEXT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSORDERTEXT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSORDERTEXT)
            _Parent = nothing
            _Name = "TRANSORDERTEXT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSORDERTEXT)
            _Parent = Parent
            _name = "TRANSORDERTEXT_SUBFORM"
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
        
        Public Property Value() As list(of TRANSORDERTEXT)
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
                return GetType(TRANSORDERTEXT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSORDERTEXT As TRANSORDERTEXT In JsonConvert.DeserializeObject(Of QUERY_TRANSORDERTEXT)(stream.ReadToEnd).Value
              With _TRANSORDERTEXT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSORDERTEXT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSORDERTEXT = JsonConvert.DeserializeObject(Of TRANSORDERTEXT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSORDERTEXT)
                  .TEXT = obj.TEXT
                  .TEXTLINE = obj.TEXTLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new TRANSORDERTEXT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSORDERTEXT as TRANSORDERTEXT in value
              If _TRANSORDERTEXT.Equals(trycast(obj,TRANSORDERTEXT)) Then
                  value.remove(_TRANSORDERTEXT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSORDERTEXT
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
                    return "TRANSORDERTEXT"
                else
                    return "TRANSORDERTEXT_SUBFORM"
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
         Pos(2),  _
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
        
        <DisplayName("Text Line"),  _
         nType("Edm.Int64"),  _
         tab("Remarks"),  _
         Pos(3),  _
         Browsable(false),  _
         twodBarcode("TEXTLINE")>  _
        Public Property TEXTLINE() As nullable (of int64)
            Get
                return _TEXTLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Text Line", value, "^[0-9\-]+$") then Exit Property
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
                .WriteAttributeString("name", "TRANSORDERTEXT")
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
                dim obj as TRANSORDERTEXT = JsonConvert.DeserializeObject(Of TRANSORDERTEXT)(e.StreamReader.ReadToEnd)
                With obj
                  _TEXT = .TEXT
                  _TEXTLINE = .TEXTLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Electronic Signature")>  _
    Public Class QUERY_TRANSDSIGN
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSDSIGN)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSDSIGN)
            _Parent = nothing
            _Name = "TRANSDSIGN"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSDSIGN)
            _Parent = Parent
            _name = "TRANSDSIGN_SUBFORM"
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
        
        Public Property Value() As list(of TRANSDSIGN)
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
                return GetType(TRANSDSIGN)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSDSIGN As TRANSDSIGN In JsonConvert.DeserializeObject(Of QUERY_TRANSDSIGN)(stream.ReadToEnd).Value
              With _TRANSDSIGN
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSDSIGN)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSDSIGN = JsonConvert.DeserializeObject(Of TRANSDSIGN)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSDSIGN)
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
            e.NewObject = new TRANSDSIGN(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSDSIGN as TRANSDSIGN in value
              If _TRANSDSIGN.Equals(trycast(obj,TRANSDSIGN)) Then
                  value.remove(_TRANSDSIGN)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSDSIGN
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
                    return "TRANSDSIGN"
                else
                    return "TRANSDSIGN_SUBFORM"
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
                .WriteAttributeString("name", "TRANSDSIGN")
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
                dim obj as TRANSDSIGN = JsonConvert.DeserializeObject(Of TRANSDSIGN)(e.StreamReader.ReadToEnd)
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
    
    <QueryTitle("Intrastat Definitions")>  _
    Public Class QUERY_TRANSORDERINTRASTAT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSORDERINTRASTAT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSORDERINTRASTAT)
            _Parent = nothing
            _Name = "TRANSORDERINTRASTAT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSORDERINTRASTAT)
            _Parent = Parent
            _name = "TRANSORDERINTRASTAT_SUBFORM"
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
        
        Public Property Value() As list(of TRANSORDERINTRASTAT)
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
                return GetType(TRANSORDERINTRASTAT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSORDERINTRASTAT As TRANSORDERINTRASTAT In JsonConvert.DeserializeObject(Of QUERY_TRANSORDERINTRASTAT)(stream.ReadToEnd).Value
              With _TRANSORDERINTRASTAT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSORDERINTRASTAT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSORDERINTRASTAT = JsonConvert.DeserializeObject(Of TRANSORDERINTRASTAT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSORDERINTRASTAT)
                  .TRANSTYPE1 = obj.TRANSTYPE1
                  .TRANSTYPE2 = obj.TRANSTYPE2
                  .IMPTERMNAME = obj.IMPTERMNAME
                  .COUNTRYNAME = obj.COUNTRYNAME
                  .KLINE = obj.KLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new TRANSORDERINTRASTAT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSORDERINTRASTAT as TRANSORDERINTRASTAT in value
              If _TRANSORDERINTRASTAT.Equals(trycast(obj,TRANSORDERINTRASTAT)) Then
                  value.remove(_TRANSORDERINTRASTAT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSORDERINTRASTAT
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetTRANSTYPE1 As Boolean = Boolean.FalseString
        
        Private _TRANSTYPE1 As String
        
        Private _IsSetTRANSTYPE2 As Boolean = Boolean.FalseString
        
        Private _TRANSTYPE2 As String
        
        Private _IsSetIMPTERMNAME As Boolean = Boolean.FalseString
        
        Private _IMPTERMNAME As String
        
        Private _IsSetCOUNTRYNAME As Boolean = Boolean.FalseString
        
        Private _COUNTRYNAME As String
        
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
                    return "TRANSORDERINTRASTAT"
                else
                    return "TRANSORDERINTRASTAT_SUBFORM"
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
        
        <DisplayName("Nature of Trans-1st"),  _
         nType("Edm.String"),  _
         tab("Nature of Trans-1st"),  _
         Pos(30),  _
         twodBarcode("TRANSTYPE1")>  _
        Public Property TRANSTYPE1() As String
            Get
                return _TRANSTYPE1
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Nature of Trans-1st", value, "^.{0,1}$") then Exit Property
                _IsSetTRANSTYPE1 = True
                If loading Then
                  _TRANSTYPE1 = Value
                Else
                    if not _TRANSTYPE1 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TRANSTYPE1", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TRANSTYPE1 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Nature of Trans-2nd"),  _
         nType("Edm.String"),  _
         tab("Nature of Trans-1st"),  _
         Pos(40),  _
         twodBarcode("TRANSTYPE2")>  _
        Public Property TRANSTYPE2() As String
            Get
                return _TRANSTYPE2
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Nature of Trans-2nd", value, "^.{0,1}$") then Exit Property
                _IsSetTRANSTYPE2 = True
                If loading Then
                  _TRANSTYPE2 = Value
                Else
                    if not _TRANSTYPE2 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TRANSTYPE2", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TRANSTYPE2 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Terms of Delivery"),  _
         nType("Edm.String"),  _
         tab("Nature of Trans-1st"),  _
         Pos(50),  _
         twodBarcode("IMPTERMNAME")>  _
        Public Property IMPTERMNAME() As String
            Get
                return _IMPTERMNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Terms of Delivery", value, "^.{0,4}$") then Exit Property
                _IsSetIMPTERMNAME = True
                If loading Then
                  _IMPTERMNAME = Value
                Else
                    if not _IMPTERMNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("IMPTERMNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _IMPTERMNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Country"),  _
         nType("Edm.String"),  _
         tab("Nature of Trans-1st"),  _
         Pos(60),  _
         twodBarcode("COUNTRYNAME")>  _
        Public Property COUNTRYNAME() As String
            Get
                return _COUNTRYNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Country", value, "^.{0,18}$") then Exit Property
                _IsSetCOUNTRYNAME = True
                If loading Then
                  _COUNTRYNAME = Value
                Else
                    if not _COUNTRYNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("COUNTRYNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _COUNTRYNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Nature of Trans-1st"),  _
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
            if _IsSetTRANSTYPE1 then
              if f then
                  jw.WriteRaw(", ""TRANSTYPE1"": ")
              else
                  jw.WriteRaw("""TRANSTYPE1"": ")
                  f = true
              end if
              jw.WriteValue(me.TRANSTYPE1)
            end if
            if _IsSetTRANSTYPE2 then
              if f then
                  jw.WriteRaw(", ""TRANSTYPE2"": ")
              else
                  jw.WriteRaw("""TRANSTYPE2"": ")
                  f = true
              end if
              jw.WriteValue(me.TRANSTYPE2)
            end if
            if _IsSetIMPTERMNAME then
              if f then
                  jw.WriteRaw(", ""IMPTERMNAME"": ")
              else
                  jw.WriteRaw("""IMPTERMNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.IMPTERMNAME)
            end if
            if _IsSetCOUNTRYNAME then
              if f then
                  jw.WriteRaw(", ""COUNTRYNAME"": ")
              else
                  jw.WriteRaw("""COUNTRYNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.COUNTRYNAME)
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
                .WriteAttributeString("name", "TRANSORDERINTRASTAT")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetTRANSTYPE1 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TRANSTYPE1")
              .WriteAttributeString("value", me.TRANSTYPE1)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetTRANSTYPE2 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TRANSTYPE2")
              .WriteAttributeString("value", me.TRANSTYPE2)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetIMPTERMNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "IMPTERMNAME")
              .WriteAttributeString("value", me.IMPTERMNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "4")
              .WriteEndElement
            end if
            if _IsSetCOUNTRYNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "COUNTRYNAME")
              .WriteAttributeString("value", me.COUNTRYNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "18")
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
                dim obj as TRANSORDERINTRASTAT = JsonConvert.DeserializeObject(Of TRANSORDERINTRASTAT)(e.StreamReader.ReadToEnd)
                With obj
                  _TRANSTYPE1 = .TRANSTYPE1
                  _TRANSTYPE2 = .TRANSTYPE2
                  _IMPTERMNAME = .IMPTERMNAME
                  _COUNTRYNAME = .COUNTRYNAME
                  _KLINE = .KLINE
                end with
            End If
        End Sub
    End Class
End Namespace
