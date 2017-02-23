Imports system
Imports system.IO
Imports system.xml
Imports System.Net
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Newtonsoft.Json

Namespace OData
    
    <QueryTitle("Warehouse Transfer")>  _
    Public Class QUERY_DOCUMENTS_T
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of DOCUMENTS_T)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of DOCUMENTS_T)
            _Parent = nothing
            _Name = "DOCUMENTS_T"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Transferred Items")
            .add(1, "Projects/Accounts")
            .add(2, "List of Styles")
            .add(3, "Sales Orders for Document")
            .add(4, "Packing Slips in Document")
            .add(5, "Tasks for Document")
            .add(6, "Warehouse Tasks for Document")
            .add(7, "To Do Item")
            .add(8, "History of Statuses")
            .add(9, "Remarks")
            .add(10, "Warehouse Tasks Based on Documt")
            .add(11, "Delivery Scheduling Details")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of DOCUMENTS_T)
            _Parent = Parent
            _name = "DOCUMENTS_T_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Transferred Items")
            .add(1, "Projects/Accounts")
            .add(2, "List of Styles")
            .add(3, "Sales Orders for Document")
            .add(4, "Packing Slips in Document")
            .add(5, "Tasks for Document")
            .add(6, "Warehouse Tasks for Document")
            .add(7, "To Do Item")
            .add(8, "History of Statuses")
            .add(9, "Remarks")
            .add(10, "Warehouse Tasks Based on Documt")
            .add(11, "Delivery Scheduling Details")
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
        
        Public Property Value() As list(of DOCUMENTS_T)
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
                return GetType(DOCUMENTS_T)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _DOCUMENTS_T As DOCUMENTS_T In JsonConvert.DeserializeObject(Of QUERY_DOCUMENTS_T)(stream.ReadToEnd).Value
              With _DOCUMENTS_T
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_DOCUMENTS_T)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DOCUMENTS_T = JsonConvert.DeserializeObject(Of DOCUMENTS_T)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, DOCUMENTS_T)
                  .CURDATE = obj.CURDATE
                  .DOCNO = obj.DOCNO
                  .WARHSNAME = obj.WARHSNAME
                  .LOCNAME = obj.LOCNAME
                  .WARHSDES = obj.WARHSDES
                  .TOWARHSNAME = obj.TOWARHSNAME
                  .TOLOCNAME = obj.TOLOCNAME
                  .TOWARHSDES = obj.TOWARHSDES
                  .PROJDOCNO = obj.PROJDOCNO
                  .PROJDES = obj.PROJDES
                  .BOOKNUM = obj.BOOKNUM
                  .PRINTEDBOOL = obj.PRINTEDBOOL
                  .STATDES = obj.STATDES
                  .OWNERLOGIN = obj.OWNERLOGIN
                  .PDOCNO = obj.PDOCNO
                  .PDOCCODE = obj.PDOCCODE
                  .ORDNAME = obj.ORDNAME
                  .DETAILS = obj.DETAILS
                  .STCODE = obj.STCODE
                  .STDES = obj.STDES
                  .SHIPPERNAME = obj.SHIPPERNAME
                  .SHIPPERDES = obj.SHIPPERDES
                  .LORRYNUM = obj.LORRYNUM
                  .BRANCHNAME = obj.BRANCHNAME
                  .BRANCHDES = obj.BRANCHDES
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .RMADOCNO = obj.RMADOCNO
                  .TOTQUANT = obj.TOTQUANT
                  .DISTRDATE = obj.DISTRDATE
                  .WEIGHT = obj.WEIGHT
                  .NWEIGHT = obj.NWEIGHT
                  .VOLUME = obj.VOLUME
                  .DOC = obj.DOC
                  .TYPE = obj.TYPE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new DOCUMENTS_T(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _DOCUMENTS_T as DOCUMENTS_T in value
              If _DOCUMENTS_T.Equals(trycast(obj,DOCUMENTS_T)) Then
                  value.remove(_DOCUMENTS_T)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class DOCUMENTS_T
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetCURDATE As Boolean = Boolean.FalseString
        
        Private _CURDATE As System.DateTimeOffset
        
        Private _DOCNO As String
        
        Private _IsSetWARHSNAME As Boolean = Boolean.FalseString
        
        Private _WARHSNAME As String
        
        Private _IsSetLOCNAME As Boolean = Boolean.FalseString
        
        Private _LOCNAME As String
        
        Private _WARHSDES As String
        
        Private _IsSetTOWARHSNAME As Boolean = Boolean.FalseString
        
        Private _TOWARHSNAME As String
        
        Private _IsSetTOLOCNAME As Boolean = Boolean.FalseString
        
        Private _TOLOCNAME As String
        
        Private _TOWARHSDES As String
        
        Private _IsSetPROJDOCNO As Boolean = Boolean.FalseString
        
        Private _PROJDOCNO As String
        
        Private _PROJDES As String
        
        Private _IsSetBOOKNUM As Boolean = Boolean.FalseString
        
        Private _BOOKNUM As String
        
        Private _PRINTEDBOOL As String
        
        Private _IsSetSTATDES As Boolean = Boolean.FalseString
        
        Private _STATDES As String
        
        Private _IsSetOWNERLOGIN As Boolean = Boolean.FalseString
        
        Private _OWNERLOGIN As String
        
        Private _IsSetPDOCNO As Boolean = Boolean.FalseString
        
        Private _PDOCNO As String
        
        Private _IsSetPDOCCODE As Boolean = Boolean.FalseString
        
        Private _PDOCCODE As String
        
        Private _IsSetORDNAME As Boolean = Boolean.FalseString
        
        Private _ORDNAME As String
        
        Private _IsSetDETAILS As Boolean = Boolean.FalseString
        
        Private _DETAILS As String
        
        Private _IsSetSTCODE As Boolean = Boolean.FalseString
        
        Private _STCODE As String
        
        Private _STDES As String
        
        Private _IsSetSHIPPERNAME As Boolean = Boolean.FalseString
        
        Private _SHIPPERNAME As String
        
        Private _SHIPPERDES As String
        
        Private _IsSetLORRYNUM As Boolean = Boolean.FalseString
        
        Private _LORRYNUM As String
        
        Private _IsSetBRANCHNAME As Boolean = Boolean.FalseString
        
        Private _BRANCHNAME As String
        
        Private _BRANCHDES As String
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _IsSetRMADOCNO As Boolean = Boolean.FalseString
        
        Private _RMADOCNO As String
        
        Private _TOTQUANT As Decimal
        
        Private _IsSetDISTRDATE As Boolean = Boolean.FalseString
        
        Private _DISTRDATE As System.DateTimeOffset
        
        Private _WEIGHT As Decimal
        
        Private _IsSetNWEIGHT As Boolean = Boolean.FalseString
        
        Private _NWEIGHT As Decimal
        
        Private _IsSetVOLUME As Boolean = Boolean.FalseString
        
        Private _VOLUME As Decimal
        
        Private _IsSetDOC As Boolean = Boolean.FalseString
        
        Private _DOC As Long
        
        Private _IsSetTYPE As Boolean = Boolean.FalseString
        
        Private _TYPE As String
        
        Private _TRANSORDER_T_SUBFORM As QUERY_TRANSORDER_T
        
        Private _PROJLINK_SUBFORM As QUERY_PROJLINK
        
        Private _MATRIXSUM_SUBFORM As QUERY_MATRIXSUM
        
        Private _DOCORD_SUBFORM As QUERY_DOCORD
        
        Private _DOCPACK_SUBFORM As QUERY_DOCPACK
        
        Private _GENCUSTNOTES_SUBFORM As QUERY_GENCUSTNOTES
        
        Private _LINKWTASK_SUBFORM As QUERY_LINKWTASK
        
        Private _DOCTODOLIST_SUBFORM As QUERY_DOCTODOLIST
        
        Private _DOCTODOLISTLOG_SUBFORM As QUERY_DOCTODOLISTLOG
        
        Private _DOCUMENTSTEXT_SUBFORM As QUERY_DOCUMENTSTEXT
        
        Private _DOCTOWTASKS_SUBFORM As QUERY_DOCTOWTASKS
        
        Private _DISTRDETAILS_SUBFORM As QUERY_DISTRDETAILS
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Transferred Items"))
            ChildQuery.add(1, new oNavigation("Projects/Accounts"))
            ChildQuery.add(2, new oNavigation("List of Styles"))
            ChildQuery.add(3, new oNavigation("Sales Orders for Document"))
            ChildQuery.add(4, new oNavigation("Packing Slips in Document"))
            ChildQuery.add(5, new oNavigation("Tasks for Document"))
            ChildQuery.add(6, new oNavigation("Warehouse Tasks for Document"))
            ChildQuery.add(7, new oNavigation("To Do Item"))
            ChildQuery.add(8, new oNavigation("History of Statuses"))
            ChildQuery.add(9, new oNavigation("Remarks"))
            ChildQuery.add(10, new oNavigation("Warehouse Tasks Based on Documt"))
            ChildQuery.add(11, new oNavigation("Delivery Scheduling Details"))
            _TRANSORDER_T_SUBFORM = new QUERY_TRANSORDER_T(me)
            _PROJLINK_SUBFORM = new QUERY_PROJLINK(me)
            _MATRIXSUM_SUBFORM = new QUERY_MATRIXSUM(me)
            _DOCORD_SUBFORM = new QUERY_DOCORD(me)
            _DOCPACK_SUBFORM = new QUERY_DOCPACK(me)
            _GENCUSTNOTES_SUBFORM = new QUERY_GENCUSTNOTES(me)
            _LINKWTASK_SUBFORM = new QUERY_LINKWTASK(me)
            _DOCTODOLIST_SUBFORM = new QUERY_DOCTODOLIST(me)
            _DOCTODOLISTLOG_SUBFORM = new QUERY_DOCTODOLISTLOG(me)
            _DOCUMENTSTEXT_SUBFORM = new QUERY_DOCUMENTSTEXT(me)
            _DOCTOWTASKS_SUBFORM = new QUERY_DOCTOWTASKS(me)
            _DISTRDETAILS_SUBFORM = new QUERY_DISTRDETAILS(me)
            WITH ChildQuery(0)
               .setoDataQuery(_TRANSORDER_T_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_PROJLINK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_MATRIXSUM_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_DOCORD_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_DOCPACK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(5)
               .setoDataQuery(_GENCUSTNOTES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(6)
               .setoDataQuery(_LINKWTASK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(7)
               .setoDataQuery(_DOCTODOLIST_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(8)
               .setoDataQuery(_DOCTODOLISTLOG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(9)
               .setoDataQuery(_DOCUMENTSTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(10)
               .setoDataQuery(_DOCTOWTASKS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(11)
               .setoDataQuery(_DISTRDETAILS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Transferred Items"))
            ChildQuery.add(1, new oNavigation("Projects/Accounts"))
            ChildQuery.add(2, new oNavigation("List of Styles"))
            ChildQuery.add(3, new oNavigation("Sales Orders for Document"))
            ChildQuery.add(4, new oNavigation("Packing Slips in Document"))
            ChildQuery.add(5, new oNavigation("Tasks for Document"))
            ChildQuery.add(6, new oNavigation("Warehouse Tasks for Document"))
            ChildQuery.add(7, new oNavigation("To Do Item"))
            ChildQuery.add(8, new oNavigation("History of Statuses"))
            ChildQuery.add(9, new oNavigation("Remarks"))
            ChildQuery.add(10, new oNavigation("Warehouse Tasks Based on Documt"))
            ChildQuery.add(11, new oNavigation("Delivery Scheduling Details"))
            _TRANSORDER_T_SUBFORM = new QUERY_TRANSORDER_T(me)
            _PROJLINK_SUBFORM = new QUERY_PROJLINK(me)
            _MATRIXSUM_SUBFORM = new QUERY_MATRIXSUM(me)
            _DOCORD_SUBFORM = new QUERY_DOCORD(me)
            _DOCPACK_SUBFORM = new QUERY_DOCPACK(me)
            _GENCUSTNOTES_SUBFORM = new QUERY_GENCUSTNOTES(me)
            _LINKWTASK_SUBFORM = new QUERY_LINKWTASK(me)
            _DOCTODOLIST_SUBFORM = new QUERY_DOCTODOLIST(me)
            _DOCTODOLISTLOG_SUBFORM = new QUERY_DOCTODOLISTLOG(me)
            _DOCUMENTSTEXT_SUBFORM = new QUERY_DOCUMENTSTEXT(me)
            _DOCTOWTASKS_SUBFORM = new QUERY_DOCTOWTASKS(me)
            _DISTRDETAILS_SUBFORM = new QUERY_DISTRDETAILS(me)
            WITH ChildQuery(0)
               .setoDataQuery(_TRANSORDER_T_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_PROJLINK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_MATRIXSUM_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_DOCORD_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_DOCPACK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(5)
               .setoDataQuery(_GENCUSTNOTES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(6)
               .setoDataQuery(_LINKWTASK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(7)
               .setoDataQuery(_DOCTODOLIST_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(8)
               .setoDataQuery(_DOCTODOLISTLOG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(9)
               .setoDataQuery(_DOCUMENTSTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(10)
               .setoDataQuery(_DOCTOWTASKS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
            WITH ChildQuery(11)
               .setoDataQuery(_DISTRDETAILS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Transferred Items", _TRANSORDER_T_SUBFORM))
                   .add(1, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(2, new oNavigation("List of Styles", _MATRIXSUM_SUBFORM))
                   .add(3, new oNavigation("Sales Orders for Document", _DOCORD_SUBFORM))
                   .add(4, new oNavigation("Packing Slips in Document", _DOCPACK_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("Warehouse Tasks for Document", _LINKWTASK_SUBFORM))
                   .add(7, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(8, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(9, new oNavigation("Remarks", _DOCUMENTSTEXT_SUBFORM))
                   .add(10, new oNavigation("Warehouse Tasks Based on Documt", _DOCTOWTASKS_SUBFORM))
                   .add(11, new oNavigation("Delivery Scheduling Details", _DISTRDETAILS_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "DOCUMENTS_T"
                else
                    return "DOCUMENTS_T_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "DOCNO={0},TYPE={1}", _
                  string.format("'{0}'",DOCNO), _
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
        
        <DisplayName("Document"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(3),  _
         [ReadOnly](true),  _
         twodBarcode("DOCNO")>  _
        Public Property DOCNO() As String
            Get
                return _DOCNO
            End Get
            Set
                if not(value is nothing) then
                  _DOCNO = Value
                end if
            End Set
        End Property
        
        <DisplayName("Sending Warehouse"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(8),  _
         Mandatory(true),  _
         twodBarcode("WARHSNAME")>  _
        Public Property WARHSNAME() As String
            Get
                return _WARHSNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Sending Warehouse", value, "^.{0,4}$") then Exit Property
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
         tab("Date"),  _
         Pos(9),  _
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
        
        <DisplayName("Warehouse Descrip."),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("WARHSDES")>  _
        Public Property WARHSDES() As String
            Get
                return _WARHSDES
            End Get
            Set
                if not(value is nothing) then
                  _WARHSDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Receiving Warehouse"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(11),  _
         Mandatory(true),  _
         twodBarcode("TOWARHSNAME")>  _
        Public Property TOWARHSNAME() As String
            Get
                return _TOWARHSNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Receiving Warehouse", value, "^.{0,4}$") then Exit Property
                _IsSetTOWARHSNAME = True
                If loading Then
                  _TOWARHSNAME = Value
                Else
                    if not _TOWARHSNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TOWARHSNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TOWARHSNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Bin"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(12),  _
         Mandatory(true),  _
         twodBarcode("TOLOCNAME")>  _
        Public Property TOLOCNAME() As String
            Get
                return _TOLOCNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Bin", value, "^.{0,14}$") then Exit Property
                _IsSetTOLOCNAME = True
                If loading Then
                  _TOLOCNAME = Value
                Else
                    if not _TOLOCNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TOLOCNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TOLOCNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Warehouse Descrip."),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(13),  _
         [ReadOnly](true),  _
         twodBarcode("TOWARHSDES")>  _
        Public Property TOWARHSDES() As String
            Get
                return _TOWARHSDES
            End Get
            Set
                if not(value is nothing) then
                  _TOWARHSDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Project Number"),  _
         nType("Edm.String"),  _
         tab("Project Number"),  _
         Pos(15),  _
         twodBarcode("PROJDOCNO")>  _
        Public Property PROJDOCNO() As String
            Get
                return _PROJDOCNO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Project Number", value, "^.{0,16}$") then Exit Property
                _IsSetPROJDOCNO = True
                If loading Then
                  _PROJDOCNO = Value
                Else
                    if not _PROJDOCNO = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PROJDOCNO", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PROJDOCNO = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Project Description"),  _
         nType("Edm.String"),  _
         tab("Project Number"),  _
         Pos(16),  _
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
        
        <DisplayName("External Doc. Number"),  _
         nType("Edm.String"),  _
         tab("Project Number"),  _
         Pos(17),  _
         twodBarcode("BOOKNUM")>  _
        Public Property BOOKNUM() As String
            Get
                return _BOOKNUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("External Doc. Number", value, "^.{0,16}$") then Exit Property
                _IsSetBOOKNUM = True
                If loading Then
                  _BOOKNUM = Value
                Else
                    if not _BOOKNUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("BOOKNUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _BOOKNUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Printed"),  _
         nType("Edm.String"),  _
         tab("Project Number"),  _
         Pos(18),  _
         [ReadOnly](true),  _
         twodBarcode("PRINTEDBOOL")>  _
        Public Property PRINTEDBOOL() As String
            Get
                return _PRINTEDBOOL
            End Get
            Set
                if not(value is nothing) then
                  _PRINTEDBOOL = Value
                end if
            End Set
        End Property
        
        <DisplayName("Status"),  _
         nType("Edm.String"),  _
         tab("Project Number"),  _
         Pos(20),  _
         Mandatory(true),  _
         twodBarcode("STATDES")>  _
        Public Property STATDES() As String
            Get
                return _STATDES
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Status", value, "^.{0,12}$") then Exit Property
                _IsSetSTATDES = True
                If loading Then
                  _STATDES = Value
                Else
                    if not _STATDES = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("STATDES", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _STATDES = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Assigned to"),  _
         nType("Edm.String"),  _
         tab("Project Number"),  _
         Pos(22),  _
         Mandatory(true),  _
         twodBarcode("OWNERLOGIN")>  _
        Public Property OWNERLOGIN() As String
            Get
                return _OWNERLOGIN
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Assigned to", value, "^.{0,20}$") then Exit Property
                _IsSetOWNERLOGIN = True
                If loading Then
                  _OWNERLOGIN = Value
                Else
                    if not _OWNERLOGIN = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("OWNERLOGIN", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _OWNERLOGIN = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Source Document"),  _
         nType("Edm.String"),  _
         tab("Project Number"),  _
         Pos(24),  _
         twodBarcode("PDOCNO")>  _
        Public Property PDOCNO() As String
            Get
                return _PDOCNO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Source Document", value, "^.{0,16}$") then Exit Property
                _IsSetPDOCNO = True
                If loading Then
                  _PDOCNO = Value
                Else
                    if not _PDOCNO = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PDOCNO", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PDOCNO = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Source Document Code"),  _
         nType("Edm.String"),  _
         tab("Project Number"),  _
         Pos(25),  _
         twodBarcode("PDOCCODE")>  _
        Public Property PDOCCODE() As String
            Get
                return _PDOCCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Source Document Code", value, "^.{0,4}$") then Exit Property
                _IsSetPDOCCODE = True
                If loading Then
                  _PDOCCODE = Value
                Else
                    if not _PDOCCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PDOCCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PDOCCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Order"),  _
         nType("Edm.String"),  _
         tab("Order"),  _
         Pos(26),  _
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
        
        <DisplayName("Details"),  _
         nType("Edm.String"),  _
         tab("Order"),  _
         Pos(28),  _
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
        
        <DisplayName("Shipment Code"),  _
         nType("Edm.String"),  _
         tab("Order"),  _
         Pos(32),  _
         twodBarcode("STCODE")>  _
        Public Property STCODE() As String
            Get
                return _STCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Shipment Code", value, "^.{0,2}$") then Exit Property
                _IsSetSTCODE = True
                If loading Then
                  _STCODE = Value
                Else
                    if not _STCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("STCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _STCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Shipping Method"),  _
         nType("Edm.String"),  _
         tab("Order"),  _
         Pos(34),  _
         [ReadOnly](true),  _
         twodBarcode("STDES")>  _
        Public Property STDES() As String
            Get
                return _STDES
            End Get
            Set
                if not(value is nothing) then
                  _STDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Shipper/Driver No."),  _
         nType("Edm.String"),  _
         tab("Order"),  _
         Pos(40),  _
         twodBarcode("SHIPPERNAME")>  _
        Public Property SHIPPERNAME() As String
            Get
                return _SHIPPERNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Shipper/Driver No.", value, "^.{0,8}$") then Exit Property
                _IsSetSHIPPERNAME = True
                If loading Then
                  _SHIPPERNAME = Value
                Else
                    if not _SHIPPERNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SHIPPERNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SHIPPERNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Shipper/Driver Name"),  _
         nType("Edm.String"),  _
         tab("Order"),  _
         Pos(42),  _
         [ReadOnly](true),  _
         twodBarcode("SHIPPERDES")>  _
        Public Property SHIPPERDES() As String
            Get
                return _SHIPPERDES
            End Get
            Set
                if not(value is nothing) then
                  _SHIPPERDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Truck No."),  _
         nType("Edm.String"),  _
         tab("Order"),  _
         Pos(44),  _
         twodBarcode("LORRYNUM")>  _
        Public Property LORRYNUM() As String
            Get
                return _LORRYNUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Truck No.", value, "^.{0,12}$") then Exit Property
                _IsSetLORRYNUM = True
                If loading Then
                  _LORRYNUM = Value
                Else
                    if not _LORRYNUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("LORRYNUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _LORRYNUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Branch Code"),  _
         nType("Edm.String"),  _
         tab("Order"),  _
         Pos(46),  _
         twodBarcode("BRANCHNAME")>  _
        Public Property BRANCHNAME() As String
            Get
                return _BRANCHNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Branch Code", value, "^.{0,6}$") then Exit Property
                _IsSetBRANCHNAME = True
                If loading Then
                  _BRANCHNAME = Value
                Else
                    if not _BRANCHNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("BRANCHNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _BRANCHNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Branch Name"),  _
         nType("Edm.String"),  _
         tab("Branch Name"),  _
         Pos(47),  _
         [ReadOnly](true),  _
         twodBarcode("BRANCHDES")>  _
        Public Property BRANCHDES() As String
            Get
                return _BRANCHDES
            End Get
            Set
                if not(value is nothing) then
                  _BRANCHDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Branch Name"),  _
         Pos(50),  _
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
         tab("Branch Name"),  _
         Pos(52),  _
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
        
        <DisplayName("RMA Number"),  _
         nType("Edm.String"),  _
         tab("Branch Name"),  _
         Pos(66),  _
         twodBarcode("RMADOCNO")>  _
        Public Property RMADOCNO() As String
            Get
                return _RMADOCNO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("RMA Number", value, "^.{0,16}$") then Exit Property
                _IsSetRMADOCNO = True
                If loading Then
                  _RMADOCNO = Value
                Else
                    if not _RMADOCNO = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("RMADOCNO", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _RMADOCNO = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Qty of Items"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(16),  _
         tab("Branch Name"),  _
         Pos(70),  _
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
        
        <DisplayName("Delivery Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Branch Name"),  _
         Pos(80),  _
         twodBarcode("DISTRDATE")>  _
        Public Property DISTRDATE() As nullable (of DateTimeOffset)
            Get
                return _DISTRDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Delivery Date", value, "^.*$") then Exit Property
                _IsSetDISTRDATE = True
                If loading Then
                  _DISTRDATE = Value
                Else
                    if not _DISTRDATE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("DISTRDATE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _DISTRDATE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Auto Gross Weight"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(10),  _
         tab("Branch Name"),  _
         Pos(90),  _
         [ReadOnly](true),  _
         twodBarcode("WEIGHT")>  _
        Public Property WEIGHT() As nullable(of decimal)
            Get
                return _WEIGHT
            End Get
            Set
                if not(value is nothing) then
                  _WEIGHT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Auto Net Weight"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(16),  _
         tab("Branch Name"),  _
         Pos(95),  _
         twodBarcode("NWEIGHT")>  _
        Public Property NWEIGHT() As nullable(of decimal)
            Get
                return _NWEIGHT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Auto Net Weight", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetNWEIGHT = True
                If loading Then
                  _NWEIGHT = Value
                Else
                    if not _NWEIGHT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("NWEIGHT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _NWEIGHT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Volume"),  _
         nType("Edm.Decimal"),  _
         Scale(4),  _
         Precision(16),  _
         tab("Volume"),  _
         Pos(100),  _
         twodBarcode("VOLUME")>  _
        Public Property VOLUME() As nullable(of decimal)
            Get
                return _VOLUME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Volume", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetVOLUME = True
                If loading Then
                  _VOLUME = Value
                Else
                    if not _VOLUME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("VOLUME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _VOLUME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Document (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Volume"),  _
         Pos(1),  _
         Browsable(false),  _
         twodBarcode("DOC")>  _
        Public Property DOC() As nullable (of int64)
            Get
                return _DOC
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Document (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetDOC = True
                If loading Then
                  _DOC = Value
                Else
                    if not _DOC = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("DOC", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _DOC = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Type"),  _
         nType("Edm.String"),  _
         tab("Volume"),  _
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
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSORDER_T_SUBFORM() As QUERY_TRANSORDER_T
            Get
                return _TRANSORDER_T_SUBFORM
            End Get
            Set
                _TRANSORDER_T_SUBFORM = value
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
        Public Property MATRIXSUM_SUBFORM() As QUERY_MATRIXSUM
            Get
                return _MATRIXSUM_SUBFORM
            End Get
            Set
                _MATRIXSUM_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property DOCORD_SUBFORM() As QUERY_DOCORD
            Get
                return _DOCORD_SUBFORM
            End Get
            Set
                _DOCORD_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property DOCPACK_SUBFORM() As QUERY_DOCPACK
            Get
                return _DOCPACK_SUBFORM
            End Get
            Set
                _DOCPACK_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property GENCUSTNOTES_SUBFORM() As QUERY_GENCUSTNOTES
            Get
                return _GENCUSTNOTES_SUBFORM
            End Get
            Set
                _GENCUSTNOTES_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property LINKWTASK_SUBFORM() As QUERY_LINKWTASK
            Get
                return _LINKWTASK_SUBFORM
            End Get
            Set
                _LINKWTASK_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property DOCTODOLIST_SUBFORM() As QUERY_DOCTODOLIST
            Get
                return _DOCTODOLIST_SUBFORM
            End Get
            Set
                _DOCTODOLIST_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property DOCTODOLISTLOG_SUBFORM() As QUERY_DOCTODOLISTLOG
            Get
                return _DOCTODOLISTLOG_SUBFORM
            End Get
            Set
                _DOCTODOLISTLOG_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property DOCUMENTSTEXT_SUBFORM() As QUERY_DOCUMENTSTEXT
            Get
                return _DOCUMENTSTEXT_SUBFORM
            End Get
            Set
                _DOCUMENTSTEXT_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property DOCTOWTASKS_SUBFORM() As QUERY_DOCTOWTASKS
            Get
                return _DOCTOWTASKS_SUBFORM
            End Get
            Set
                _DOCTOWTASKS_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property DISTRDETAILS_SUBFORM() As QUERY_DISTRDETAILS
            Get
                return _DISTRDETAILS_SUBFORM
            End Get
            Set
                _DISTRDETAILS_SUBFORM = value
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
            if _IsSetTOWARHSNAME then
              if f then
                  jw.WriteRaw(", ""TOWARHSNAME"": ")
              else
                  jw.WriteRaw("""TOWARHSNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.TOWARHSNAME)
            end if
            if _IsSetTOLOCNAME then
              if f then
                  jw.WriteRaw(", ""TOLOCNAME"": ")
              else
                  jw.WriteRaw("""TOLOCNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.TOLOCNAME)
            end if
            if _IsSetPROJDOCNO then
              if f then
                  jw.WriteRaw(", ""PROJDOCNO"": ")
              else
                  jw.WriteRaw("""PROJDOCNO"": ")
                  f = true
              end if
              jw.WriteValue(me.PROJDOCNO)
            end if
            if _IsSetBOOKNUM then
              if f then
                  jw.WriteRaw(", ""BOOKNUM"": ")
              else
                  jw.WriteRaw("""BOOKNUM"": ")
                  f = true
              end if
              jw.WriteValue(me.BOOKNUM)
            end if
            if _IsSetSTATDES then
              if f then
                  jw.WriteRaw(", ""STATDES"": ")
              else
                  jw.WriteRaw("""STATDES"": ")
                  f = true
              end if
              jw.WriteValue(me.STATDES)
            end if
            if _IsSetOWNERLOGIN then
              if f then
                  jw.WriteRaw(", ""OWNERLOGIN"": ")
              else
                  jw.WriteRaw("""OWNERLOGIN"": ")
                  f = true
              end if
              jw.WriteValue(me.OWNERLOGIN)
            end if
            if _IsSetPDOCNO then
              if f then
                  jw.WriteRaw(", ""PDOCNO"": ")
              else
                  jw.WriteRaw("""PDOCNO"": ")
                  f = true
              end if
              jw.WriteValue(me.PDOCNO)
            end if
            if _IsSetPDOCCODE then
              if f then
                  jw.WriteRaw(", ""PDOCCODE"": ")
              else
                  jw.WriteRaw("""PDOCCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.PDOCCODE)
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
            if _IsSetDETAILS then
              if f then
                  jw.WriteRaw(", ""DETAILS"": ")
              else
                  jw.WriteRaw("""DETAILS"": ")
                  f = true
              end if
              jw.WriteValue(me.DETAILS)
            end if
            if _IsSetSTCODE then
              if f then
                  jw.WriteRaw(", ""STCODE"": ")
              else
                  jw.WriteRaw("""STCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.STCODE)
            end if
            if _IsSetSHIPPERNAME then
              if f then
                  jw.WriteRaw(", ""SHIPPERNAME"": ")
              else
                  jw.WriteRaw("""SHIPPERNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SHIPPERNAME)
            end if
            if _IsSetLORRYNUM then
              if f then
                  jw.WriteRaw(", ""LORRYNUM"": ")
              else
                  jw.WriteRaw("""LORRYNUM"": ")
                  f = true
              end if
              jw.WriteValue(me.LORRYNUM)
            end if
            if _IsSetBRANCHNAME then
              if f then
                  jw.WriteRaw(", ""BRANCHNAME"": ")
              else
                  jw.WriteRaw("""BRANCHNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.BRANCHNAME)
            end if
            if _IsSetRMADOCNO then
              if f then
                  jw.WriteRaw(", ""RMADOCNO"": ")
              else
                  jw.WriteRaw("""RMADOCNO"": ")
                  f = true
              end if
              jw.WriteValue(me.RMADOCNO)
            end if
            if _IsSetDISTRDATE then
              if f then
                  jw.WriteRaw(", ""DISTRDATE"": ")
              else
                  jw.WriteRaw("""DISTRDATE"": ")
                  f = true
              end if
              jw.WriteValue(me.DISTRDATE)
            end if
            if _IsSetNWEIGHT then
              if f then
                  jw.WriteRaw(", ""NWEIGHT"": ")
              else
                  jw.WriteRaw("""NWEIGHT"": ")
                  f = true
              end if
              jw.WriteValue(me.NWEIGHT)
            end if
            if _IsSetVOLUME then
              if f then
                  jw.WriteRaw(", ""VOLUME"": ")
              else
                  jw.WriteRaw("""VOLUME"": ")
                  f = true
              end if
              jw.WriteValue(me.VOLUME)
            end if
            if _IsSetDOC then
              if f then
                  jw.WriteRaw(", ""DOC"": ")
              else
                  jw.WriteRaw("""DOC"": ")
                  f = true
              end if
              jw.WriteValue(me.DOC)
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
            if _TRANSORDER_T_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSORDER_T_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSORDER_T in _TRANSORDER_T_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSORDER_T_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
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
            if _DOCORD_SUBFORM.value.count > 0 then
              jw.WriteRaw(", DOCORD_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as DOCORD in _DOCORD_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _DOCORD_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _DOCPACK_SUBFORM.value.count > 0 then
              jw.WriteRaw(", DOCPACK_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as DOCPACK in _DOCPACK_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _DOCPACK_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _GENCUSTNOTES_SUBFORM.value.count > 0 then
              jw.WriteRaw(", GENCUSTNOTES_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as GENCUSTNOTES in _GENCUSTNOTES_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _GENCUSTNOTES_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _LINKWTASK_SUBFORM.value.count > 0 then
              jw.WriteRaw(", LINKWTASK_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as LINKWTASK in _LINKWTASK_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _LINKWTASK_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _DOCTODOLIST_SUBFORM.value.count > 0 then
              jw.WriteRaw(", DOCTODOLIST_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as DOCTODOLIST in _DOCTODOLIST_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _DOCTODOLIST_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _DOCTODOLISTLOG_SUBFORM.value.count > 0 then
              jw.WriteRaw(", DOCTODOLISTLOG_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as DOCTODOLISTLOG in _DOCTODOLISTLOG_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _DOCTODOLISTLOG_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _DOCUMENTSTEXT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", DOCUMENTSTEXT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as DOCUMENTSTEXT in _DOCUMENTSTEXT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _DOCUMENTSTEXT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _DOCTOWTASKS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", DOCTOWTASKS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as DOCTOWTASKS in _DOCTOWTASKS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _DOCTOWTASKS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _DISTRDETAILS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", DISTRDETAILS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as DISTRDETAILS in _DISTRDETAILS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _DISTRDETAILS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "DOCUMENTS_T")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "DOCNO")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
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
            if _IsSetTOWARHSNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TOWARHSNAME")
              .WriteAttributeString("value", me.TOWARHSNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "4")
              .WriteEndElement
            end if
            if _IsSetTOLOCNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TOLOCNAME")
              .WriteAttributeString("value", me.TOLOCNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "14")
              .WriteEndElement
            end if
            if _IsSetPROJDOCNO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PROJDOCNO")
              .WriteAttributeString("value", me.PROJDOCNO)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetBOOKNUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "BOOKNUM")
              .WriteAttributeString("value", me.BOOKNUM)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetSTATDES then
              .WriteStartElement("field")
              .WriteAttributeString("name", "STATDES")
              .WriteAttributeString("value", me.STATDES)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "12")
              .WriteEndElement
            end if
            if _IsSetOWNERLOGIN then
              .WriteStartElement("field")
              .WriteAttributeString("name", "OWNERLOGIN")
              .WriteAttributeString("value", me.OWNERLOGIN)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
              .WriteEndElement
            end if
            if _IsSetPDOCNO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PDOCNO")
              .WriteAttributeString("value", me.PDOCNO)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetPDOCCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PDOCCODE")
              .WriteAttributeString("value", me.PDOCCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "4")
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
            if _IsSetDETAILS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DETAILS")
              .WriteAttributeString("value", me.DETAILS)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "24")
              .WriteEndElement
            end if
            if _IsSetSTCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "STCODE")
              .WriteAttributeString("value", me.STCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "2")
              .WriteEndElement
            end if
            if _IsSetSHIPPERNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SHIPPERNAME")
              .WriteAttributeString("value", me.SHIPPERNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "8")
              .WriteEndElement
            end if
            if _IsSetLORRYNUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "LORRYNUM")
              .WriteAttributeString("value", me.LORRYNUM)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "12")
              .WriteEndElement
            end if
            if _IsSetBRANCHNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "BRANCHNAME")
              .WriteAttributeString("value", me.BRANCHNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "6")
              .WriteEndElement
            end if
            if _IsSetRMADOCNO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "RMADOCNO")
              .WriteAttributeString("value", me.RMADOCNO)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetDISTRDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DISTRDATE")
              .WriteAttributeString("value", me.DISTRDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetNWEIGHT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "NWEIGHT")
              .WriteAttributeString("value", me.NWEIGHT)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "2")
              .WriteAttributeString("Precision", "16")
              .WriteEndElement
            end if
            if _IsSetVOLUME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "VOLUME")
              .WriteAttributeString("value", me.VOLUME)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "4")
              .WriteAttributeString("Precision", "16")
              .WriteEndElement
            end if
            if _IsSetDOC then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DOC")
              .WriteAttributeString("value", me.DOC)
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
            if _TRANSORDER_T_SUBFORM.value.count > 0 then
              for each itm as TRANSORDER_T in _TRANSORDER_T_SUBFORM.Value
                itm.toXML(xw,"TRANSORDER_T_SUBFORM")
              next
            end if
            if _PROJLINK_SUBFORM.value.count > 0 then
              for each itm as PROJLINK in _PROJLINK_SUBFORM.Value
                itm.toXML(xw,"PROJLINK_SUBFORM")
              next
            end if
            if _MATRIXSUM_SUBFORM.value.count > 0 then
              for each itm as MATRIXSUM in _MATRIXSUM_SUBFORM.Value
                itm.toXML(xw,"MATRIXSUM_SUBFORM")
              next
            end if
            if _DOCORD_SUBFORM.value.count > 0 then
              for each itm as DOCORD in _DOCORD_SUBFORM.Value
                itm.toXML(xw,"DOCORD_SUBFORM")
              next
            end if
            if _DOCPACK_SUBFORM.value.count > 0 then
              for each itm as DOCPACK in _DOCPACK_SUBFORM.Value
                itm.toXML(xw,"DOCPACK_SUBFORM")
              next
            end if
            if _GENCUSTNOTES_SUBFORM.value.count > 0 then
              for each itm as GENCUSTNOTES in _GENCUSTNOTES_SUBFORM.Value
                itm.toXML(xw,"GENCUSTNOTES_SUBFORM")
              next
            end if
            if _LINKWTASK_SUBFORM.value.count > 0 then
              for each itm as LINKWTASK in _LINKWTASK_SUBFORM.Value
                itm.toXML(xw,"LINKWTASK_SUBFORM")
              next
            end if
            if _DOCTODOLIST_SUBFORM.value.count > 0 then
              for each itm as DOCTODOLIST in _DOCTODOLIST_SUBFORM.Value
                itm.toXML(xw,"DOCTODOLIST_SUBFORM")
              next
            end if
            if _DOCTODOLISTLOG_SUBFORM.value.count > 0 then
              for each itm as DOCTODOLISTLOG in _DOCTODOLISTLOG_SUBFORM.Value
                itm.toXML(xw,"DOCTODOLISTLOG_SUBFORM")
              next
            end if
            if _DOCUMENTSTEXT_SUBFORM.value.count > 0 then
              for each itm as DOCUMENTSTEXT in _DOCUMENTSTEXT_SUBFORM.Value
                itm.toXML(xw,"DOCUMENTSTEXT_SUBFORM")
              next
            end if
            if _DOCTOWTASKS_SUBFORM.value.count > 0 then
              for each itm as DOCTOWTASKS in _DOCTOWTASKS_SUBFORM.Value
                itm.toXML(xw,"DOCTOWTASKS_SUBFORM")
              next
            end if
            if _DISTRDETAILS_SUBFORM.value.count > 0 then
              for each itm as DISTRDETAILS in _DISTRDETAILS_SUBFORM.Value
                itm.toXML(xw,"DISTRDETAILS_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DOCUMENTS_T = JsonConvert.DeserializeObject(Of DOCUMENTS_T)(e.StreamReader.ReadToEnd)
                With obj
                  _CURDATE = .CURDATE
                  _DOCNO = .DOCNO
                  _WARHSNAME = .WARHSNAME
                  _LOCNAME = .LOCNAME
                  _WARHSDES = .WARHSDES
                  _TOWARHSNAME = .TOWARHSNAME
                  _TOLOCNAME = .TOLOCNAME
                  _TOWARHSDES = .TOWARHSDES
                  _PROJDOCNO = .PROJDOCNO
                  _PROJDES = .PROJDES
                  _BOOKNUM = .BOOKNUM
                  _PRINTEDBOOL = .PRINTEDBOOL
                  _STATDES = .STATDES
                  _OWNERLOGIN = .OWNERLOGIN
                  _PDOCNO = .PDOCNO
                  _PDOCCODE = .PDOCCODE
                  _ORDNAME = .ORDNAME
                  _DETAILS = .DETAILS
                  _STCODE = .STCODE
                  _STDES = .STDES
                  _SHIPPERNAME = .SHIPPERNAME
                  _SHIPPERDES = .SHIPPERDES
                  _LORRYNUM = .LORRYNUM
                  _BRANCHNAME = .BRANCHNAME
                  _BRANCHDES = .BRANCHDES
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _RMADOCNO = .RMADOCNO
                  _TOTQUANT = .TOTQUANT
                  _DISTRDATE = .DISTRDATE
                  _WEIGHT = .WEIGHT
                  _NWEIGHT = .NWEIGHT
                  _VOLUME = .VOLUME
                  _DOC = .DOC
                  _TYPE = .TYPE
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_DOCUMENTS_T
        
        TRANSORDER_T = 0
        
        PROJLINK = 1
        
        MATRIXSUM = 2
        
        DOCORD = 3
        
        DOCPACK = 4
        
        GENCUSTNOTES = 5
        
        LINKWTASK = 6
        
        DOCTODOLIST = 7
        
        DOCTODOLISTLOG = 8
        
        DOCUMENTSTEXT = 9
        
        DOCTOWTASKS = 10
        
        DISTRDETAILS = 11
    End Enum
    
    <QueryTitle("Transferred Items")>  _
    Public Class QUERY_TRANSORDER_T
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSORDER_T)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSORDER_T)
            _Parent = nothing
            _Name = "TRANSORDER_T"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Serial Numbers in Transaction")
            .add(1, "Auto Recording of Serial Nos.")
            .add(2, "Malfunction Linked to Document")
            .add(3, "Projects/Accounts")
            .add(4, "Analysis Results")
            .add(5, "Warehouse Tasks for Line Item")
            .add(6, "Electronic Signature")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSORDER_T)
            _Parent = Parent
            _name = "TRANSORDER_T_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Serial Numbers in Transaction")
            .add(1, "Auto Recording of Serial Nos.")
            .add(2, "Malfunction Linked to Document")
            .add(3, "Projects/Accounts")
            .add(4, "Analysis Results")
            .add(5, "Warehouse Tasks for Line Item")
            .add(6, "Electronic Signature")
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
        
        Public Property Value() As list(of TRANSORDER_T)
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
                return GetType(TRANSORDER_T)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSORDER_T As TRANSORDER_T In JsonConvert.DeserializeObject(Of QUERY_TRANSORDER_T)(stream.ReadToEnd).Value
              With _TRANSORDER_T
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSORDER_T)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSORDER_T = JsonConvert.DeserializeObject(Of TRANSORDER_T)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSORDER_T)
                  .PARTNAME = obj.PARTNAME
                  .PDES = obj.PDES
                  .SERIALNAME = obj.SERIALNAME
                  .SERIALDES = obj.SERIALDES
                  .REVNAME = obj.REVNAME
                  .REVNUM = obj.REVNUM
                  .ACTNAME = obj.ACTNAME
                  .DATECODE = obj.DATECODE
                  .CUSTNAME = obj.CUSTNAME
                  .BARCODE = obj.BARCODE
                  .CQUANT = obj.CQUANT
                  .PQUANT = obj.PQUANT
                  .BAL = obj.BAL
                  .SETFLAG = obj.SETFLAG
                  .TQUANT = obj.TQUANT
                  .TUNITNAME = obj.TUNITNAME
                  .QUANT = obj.QUANT
                  .UNITNAME = obj.UNITNAME
                  .NUMPACK = obj.NUMPACK
                  .PACKCODE = obj.PACKCODE
                  .ORDNAME = obj.ORDNAME
                  .OLINE = obj.OLINE
                  .WARHSNAME = obj.WARHSNAME
                  .LOCNAME = obj.LOCNAME
                  .TOWARHSNAME = obj.TOWARHSNAME
                  .TOLOCNAME = obj.TOLOCNAME
                  .TOACTNAME = obj.TOACTNAME
                  .TOPALLETNAME = obj.TOPALLETNAME
                  .TOCUSTNAME = obj.TOCUSTNAME
                  .PNUMPACK = obj.PNUMPACK
                  .REWORKFLAG = obj.REWORKFLAG
                  .ANALYSISVALID = obj.ANALYSISVALID
                  .ANALYSISNOTVALID = obj.ANALYSISNOTVALID
                  .KLINE = obj.KLINE
                  .TRANS = obj.TRANS
                  .TYPE = obj.TYPE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new TRANSORDER_T(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSORDER_T as TRANSORDER_T in value
              If _TRANSORDER_T.Equals(trycast(obj,TRANSORDER_T)) Then
                  value.remove(_TRANSORDER_T)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSORDER_T
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetPARTNAME As Boolean = Boolean.FalseString
        
        Private _PARTNAME As String
        
        Private _IsSetPDES As Boolean = Boolean.FalseString
        
        Private _PDES As String
        
        Private _IsSetSERIALNAME As Boolean = Boolean.FalseString
        
        Private _SERIALNAME As String
        
        Private _SERIALDES As String
        
        Private _IsSetREVNAME As Boolean = Boolean.FalseString
        
        Private _REVNAME As String
        
        Private _REVNUM As String
        
        Private _IsSetACTNAME As Boolean = Boolean.FalseString
        
        Private _ACTNAME As String
        
        Private _DATECODE As String
        
        Private _IsSetCUSTNAME As Boolean = Boolean.FalseString
        
        Private _CUSTNAME As String
        
        Private _IsSetBARCODE As Boolean = Boolean.FalseString
        
        Private _BARCODE As String
        
        Private _CQUANT As Decimal
        
        Private _PQUANT As Decimal
        
        Private _BAL As Decimal
        
        Private _IsSetSETFLAG As Boolean = Boolean.FalseString
        
        Private _SETFLAG As String
        
        Private _IsSetTQUANT As Boolean = Boolean.FalseString
        
        Private _TQUANT As Decimal
        
        Private _TUNITNAME As String
        
        Private _IsSetQUANT As Boolean = Boolean.FalseString
        
        Private _QUANT As Decimal
        
        Private _UNITNAME As String
        
        Private _IsSetNUMPACK As Boolean = Boolean.FalseString
        
        Private _NUMPACK As Long
        
        Private _IsSetPACKCODE As Boolean = Boolean.FalseString
        
        Private _PACKCODE As String
        
        Private _IsSetORDNAME As Boolean = Boolean.FalseString
        
        Private _ORDNAME As String
        
        Private _IsSetOLINE As Boolean = Boolean.FalseString
        
        Private _OLINE As Long
        
        Private _WARHSNAME As String
        
        Private _IsSetLOCNAME As Boolean = Boolean.FalseString
        
        Private _LOCNAME As String
        
        Private _TOWARHSNAME As String
        
        Private _IsSetTOLOCNAME As Boolean = Boolean.FalseString
        
        Private _TOLOCNAME As String
        
        Private _IsSetTOACTNAME As Boolean = Boolean.FalseString
        
        Private _TOACTNAME As String
        
        Private _IsSetTOPALLETNAME As Boolean = Boolean.FalseString
        
        Private _TOPALLETNAME As String
        
        Private _IsSetTOCUSTNAME As Boolean = Boolean.FalseString
        
        Private _TOCUSTNAME As String
        
        Private _PNUMPACK As Long
        
        Private _IsSetREWORKFLAG As Boolean = Boolean.FalseString
        
        Private _REWORKFLAG As String
        
        Private _ANALYSISVALID As String
        
        Private _ANALYSISNOTVALID As String
        
        Private _IsSetKLINE As Boolean = Boolean.FalseString
        
        Private _KLINE As Long
        
        Private _IsSetTRANS As Boolean = Boolean.FalseString
        
        Private _TRANS As Long
        
        Private _IsSetTYPE As Boolean = Boolean.FalseString
        
        Private _TYPE As String
        
        Private _SERNTRANS_SUBFORM As QUERY_SERNTRANS
        
        Private _OPENSERNUM_SUBFORM As QUERY_OPENSERNUM
        
        Private _LINKFAULTS_SUBFORM As QUERY_LINKFAULTS
        
        Private _PROJLINK_SUBFORM As QUERY_PROJLINK
        
        Private _TRANSLABANALYSES_SUBFORM As QUERY_TRANSLABANALYSES
        
        Private _WTASKTRANSLINK_SUBFORM As QUERY_WTASKTRANSLINK
        
        Private _TRANSTSIGN_SUBFORM As QUERY_TRANSTSIGN
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Serial Numbers in Transaction"))
            ChildQuery.add(1, new oNavigation("Auto Recording of Serial Nos."))
            ChildQuery.add(2, new oNavigation("Malfunction Linked to Document"))
            ChildQuery.add(3, new oNavigation("Projects/Accounts"))
            ChildQuery.add(4, new oNavigation("Analysis Results"))
            ChildQuery.add(5, new oNavigation("Warehouse Tasks for Line Item"))
            ChildQuery.add(6, new oNavigation("Electronic Signature"))
            _SERNTRANS_SUBFORM = new QUERY_SERNTRANS(me)
            _OPENSERNUM_SUBFORM = new QUERY_OPENSERNUM(me)
            _LINKFAULTS_SUBFORM = new QUERY_LINKFAULTS(me)
            _PROJLINK_SUBFORM = new QUERY_PROJLINK(me)
            _TRANSLABANALYSES_SUBFORM = new QUERY_TRANSLABANALYSES(me)
            _WTASKTRANSLINK_SUBFORM = new QUERY_WTASKTRANSLINK(me)
            _TRANSTSIGN_SUBFORM = new QUERY_TRANSTSIGN(me)
            WITH ChildQuery(0)
               .setoDataQuery(_SERNTRANS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Serial Numbers in Transaction", _SERNTRANS_SUBFORM))
                   .add(1, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(2, new oNavigation("Malfunction Linked to Document", _LINKFAULTS_SUBFORM))
                   .add(3, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(4, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(5, new oNavigation("Warehouse Tasks for Line Item", _WTASKTRANSLINK_SUBFORM))
                   .add(6, new oNavigation("Electronic Signature", _TRANSTSIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_OPENSERNUM_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Serial Numbers in Transaction", _SERNTRANS_SUBFORM))
                   .add(1, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(2, new oNavigation("Malfunction Linked to Document", _LINKFAULTS_SUBFORM))
                   .add(3, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(4, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(5, new oNavigation("Warehouse Tasks for Line Item", _WTASKTRANSLINK_SUBFORM))
                   .add(6, new oNavigation("Electronic Signature", _TRANSTSIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_LINKFAULTS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Serial Numbers in Transaction", _SERNTRANS_SUBFORM))
                   .add(1, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(2, new oNavigation("Malfunction Linked to Document", _LINKFAULTS_SUBFORM))
                   .add(3, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(4, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(5, new oNavigation("Warehouse Tasks for Line Item", _WTASKTRANSLINK_SUBFORM))
                   .add(6, new oNavigation("Electronic Signature", _TRANSTSIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_PROJLINK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Serial Numbers in Transaction", _SERNTRANS_SUBFORM))
                   .add(1, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(2, new oNavigation("Malfunction Linked to Document", _LINKFAULTS_SUBFORM))
                   .add(3, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(4, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(5, new oNavigation("Warehouse Tasks for Line Item", _WTASKTRANSLINK_SUBFORM))
                   .add(6, new oNavigation("Electronic Signature", _TRANSTSIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_TRANSLABANALYSES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Serial Numbers in Transaction", _SERNTRANS_SUBFORM))
                   .add(1, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(2, new oNavigation("Malfunction Linked to Document", _LINKFAULTS_SUBFORM))
                   .add(3, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(4, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(5, new oNavigation("Warehouse Tasks for Line Item", _WTASKTRANSLINK_SUBFORM))
                   .add(6, new oNavigation("Electronic Signature", _TRANSTSIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(5)
               .setoDataQuery(_WTASKTRANSLINK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Serial Numbers in Transaction", _SERNTRANS_SUBFORM))
                   .add(1, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(2, new oNavigation("Malfunction Linked to Document", _LINKFAULTS_SUBFORM))
                   .add(3, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(4, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(5, new oNavigation("Warehouse Tasks for Line Item", _WTASKTRANSLINK_SUBFORM))
                   .add(6, new oNavigation("Electronic Signature", _TRANSTSIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(6)
               .setoDataQuery(_TRANSTSIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Serial Numbers in Transaction", _SERNTRANS_SUBFORM))
                   .add(1, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(2, new oNavigation("Malfunction Linked to Document", _LINKFAULTS_SUBFORM))
                   .add(3, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(4, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(5, new oNavigation("Warehouse Tasks for Line Item", _WTASKTRANSLINK_SUBFORM))
                   .add(6, new oNavigation("Electronic Signature", _TRANSTSIGN_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Serial Numbers in Transaction"))
            ChildQuery.add(1, new oNavigation("Auto Recording of Serial Nos."))
            ChildQuery.add(2, new oNavigation("Malfunction Linked to Document"))
            ChildQuery.add(3, new oNavigation("Projects/Accounts"))
            ChildQuery.add(4, new oNavigation("Analysis Results"))
            ChildQuery.add(5, new oNavigation("Warehouse Tasks for Line Item"))
            ChildQuery.add(6, new oNavigation("Electronic Signature"))
            _SERNTRANS_SUBFORM = new QUERY_SERNTRANS(me)
            _OPENSERNUM_SUBFORM = new QUERY_OPENSERNUM(me)
            _LINKFAULTS_SUBFORM = new QUERY_LINKFAULTS(me)
            _PROJLINK_SUBFORM = new QUERY_PROJLINK(me)
            _TRANSLABANALYSES_SUBFORM = new QUERY_TRANSLABANALYSES(me)
            _WTASKTRANSLINK_SUBFORM = new QUERY_WTASKTRANSLINK(me)
            _TRANSTSIGN_SUBFORM = new QUERY_TRANSTSIGN(me)
            WITH ChildQuery(0)
               .setoDataQuery(_SERNTRANS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Serial Numbers in Transaction", _SERNTRANS_SUBFORM))
                   .add(1, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(2, new oNavigation("Malfunction Linked to Document", _LINKFAULTS_SUBFORM))
                   .add(3, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(4, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(5, new oNavigation("Warehouse Tasks for Line Item", _WTASKTRANSLINK_SUBFORM))
                   .add(6, new oNavigation("Electronic Signature", _TRANSTSIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_OPENSERNUM_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Serial Numbers in Transaction", _SERNTRANS_SUBFORM))
                   .add(1, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(2, new oNavigation("Malfunction Linked to Document", _LINKFAULTS_SUBFORM))
                   .add(3, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(4, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(5, new oNavigation("Warehouse Tasks for Line Item", _WTASKTRANSLINK_SUBFORM))
                   .add(6, new oNavigation("Electronic Signature", _TRANSTSIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_LINKFAULTS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Serial Numbers in Transaction", _SERNTRANS_SUBFORM))
                   .add(1, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(2, new oNavigation("Malfunction Linked to Document", _LINKFAULTS_SUBFORM))
                   .add(3, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(4, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(5, new oNavigation("Warehouse Tasks for Line Item", _WTASKTRANSLINK_SUBFORM))
                   .add(6, new oNavigation("Electronic Signature", _TRANSTSIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_PROJLINK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Serial Numbers in Transaction", _SERNTRANS_SUBFORM))
                   .add(1, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(2, new oNavigation("Malfunction Linked to Document", _LINKFAULTS_SUBFORM))
                   .add(3, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(4, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(5, new oNavigation("Warehouse Tasks for Line Item", _WTASKTRANSLINK_SUBFORM))
                   .add(6, new oNavigation("Electronic Signature", _TRANSTSIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_TRANSLABANALYSES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Serial Numbers in Transaction", _SERNTRANS_SUBFORM))
                   .add(1, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(2, new oNavigation("Malfunction Linked to Document", _LINKFAULTS_SUBFORM))
                   .add(3, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(4, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(5, new oNavigation("Warehouse Tasks for Line Item", _WTASKTRANSLINK_SUBFORM))
                   .add(6, new oNavigation("Electronic Signature", _TRANSTSIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(5)
               .setoDataQuery(_WTASKTRANSLINK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Serial Numbers in Transaction", _SERNTRANS_SUBFORM))
                   .add(1, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(2, new oNavigation("Malfunction Linked to Document", _LINKFAULTS_SUBFORM))
                   .add(3, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(4, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(5, new oNavigation("Warehouse Tasks for Line Item", _WTASKTRANSLINK_SUBFORM))
                   .add(6, new oNavigation("Electronic Signature", _TRANSTSIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(6)
               .setoDataQuery(_TRANSTSIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Serial Numbers in Transaction", _SERNTRANS_SUBFORM))
                   .add(1, new oNavigation("Auto Recording of Serial Nos.", _OPENSERNUM_SUBFORM))
                   .add(2, new oNavigation("Malfunction Linked to Document", _LINKFAULTS_SUBFORM))
                   .add(3, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(4, new oNavigation("Analysis Results", _TRANSLABANALYSES_SUBFORM))
                   .add(5, new oNavigation("Warehouse Tasks for Line Item", _WTASKTRANSLINK_SUBFORM))
                   .add(6, new oNavigation("Electronic Signature", _TRANSTSIGN_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "TRANSORDER_T"
                else
                    return "TRANSORDER_T_SUBFORM"
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
        
        <DisplayName("Part Number"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
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
        
        <DisplayName("Part Description"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(20),  _
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
        
        <DisplayName("Work Order/Lot"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(30),  _
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
        
        <DisplayName("Work Order/Lot Desc."),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(31),  _
         [ReadOnly](true),  _
         twodBarcode("SERIALDES")>  _
        Public Property SERIALDES() As String
            Get
                return _SERIALDES
            End Get
            Set
                if not(value is nothing) then
                  _SERIALDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Part Revision No."),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(40),  _
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
         Pos(50),  _
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
        
        <DisplayName("Operation/Pallet"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
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
        
        <DisplayName("Inventory Date Code"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(62),  _
         [ReadOnly](true),  _
         twodBarcode("DATECODE")>  _
        Public Property DATECODE() As String
            Get
                return _DATECODE
            End Get
            Set
                if not(value is nothing) then
                  _DATECODE = Value
                end if
            End Set
        End Property
        
        <DisplayName("From Status"),  _
         nType("Edm.String"),  _
         tab("From Status"),  _
         Pos(70),  _
         Mandatory(true),  _
         twodBarcode("CUSTNAME")>  _
        Public Property CUSTNAME() As String
            Get
                return _CUSTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("From Status", value, "^.{0,16}$") then Exit Property
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
        
        <DisplayName("Bar Code"),  _
         nType("Edm.String"),  _
         tab("From Status"),  _
         Pos(80),  _
         twodBarcode("BARCODE")>  _
        Public Property BARCODE() As String
            Get
                return _BARCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Bar Code", value, "^.{0,16}$") then Exit Property
                _IsSetBARCODE = True
                If loading Then
                  _BARCODE = Value
                Else
                    if not _BARCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("BARCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _BARCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Order Balance"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("From Status"),  _
         Pos(90),  _
         [ReadOnly](true),  _
         twodBarcode("CQUANT")>  _
        Public Property CQUANT() As nullable(of decimal)
            Get
                return _CQUANT
            End Get
            Set
                if not(value is nothing) then
                  _CQUANT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Warehouse Balance"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("From Status"),  _
         Pos(100),  _
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
        
        <DisplayName("Warehouse Bal(FactU)"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("From Status"),  _
         Pos(101),  _
         [ReadOnly](true),  _
         twodBarcode("BAL")>  _
        Public Property BAL() As nullable(of decimal)
            Get
                return _BAL
            End Get
            Set
                if not(value is nothing) then
                  _BAL = Value
                end if
            End Set
        End Property
        
        <DisplayName("Approve"),  _
         nType("Edm.String"),  _
         tab("From Status"),  _
         Pos(110),  _
         twodBarcode("SETFLAG")>  _
        Public Property SETFLAG() As String
            Get
                return _SETFLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Approve", value, "^.{0,1}$") then Exit Property
                _IsSetSETFLAG = True
                If loading Then
                  _SETFLAG = Value
                Else
                    if not _SETFLAG = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SETFLAG", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SETFLAG = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("From Status"),  _
         Pos(120),  _
         twodBarcode("TQUANT")>  _
        Public Property TQUANT() As nullable(of decimal)
            Get
                return _TQUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Quantity", value, "^[0-9\.\-]+$") then Exit Property
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
         tab("From Status"),  _
         Pos(130),  _
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
        
        <DisplayName("Qty (Factory Units)"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Qty (Factory Units)"),  _
         Pos(140),  _
         twodBarcode("QUANT")>  _
        Public Property QUANT() As nullable(of decimal)
            Get
                return _QUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Qty (Factory Units)", value, "^[0-9\.\-]+$") then Exit Property
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
        
        <DisplayName("Factory Unit"),  _
         nType("Edm.String"),  _
         tab("Qty (Factory Units)"),  _
         Pos(150),  _
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
        
        <DisplayName("Packing Crates (No.)"),  _
         nType("Edm.Int64"),  _
         tab("Qty (Factory Units)"),  _
         Pos(160),  _
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
         tab("Qty (Factory Units)"),  _
         Pos(170),  _
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
        
        <DisplayName("Order"),  _
         nType("Edm.String"),  _
         tab("Qty (Factory Units)"),  _
         Pos(180),  _
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
        
        <DisplayName("Ln"),  _
         nType("Edm.Int64"),  _
         tab("Qty (Factory Units)"),  _
         Pos(190),  _
         twodBarcode("OLINE")>  _
        Public Property OLINE() As nullable (of int64)
            Get
                return _OLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Ln", value, "^[0-9\-]+$") then Exit Property
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
        
        <DisplayName("From Warehouse"),  _
         nType("Edm.String"),  _
         tab("Qty (Factory Units)"),  _
         Pos(200),  _
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
         tab("Qty (Factory Units)"),  _
         Pos(210),  _
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
        
        <DisplayName("To Warehouse"),  _
         nType("Edm.String"),  _
         tab("To Warehouse"),  _
         Pos(220),  _
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
        
        <DisplayName("To Bin"),  _
         nType("Edm.String"),  _
         tab("To Warehouse"),  _
         Pos(230),  _
         Mandatory(true),  _
         twodBarcode("TOLOCNAME")>  _
        Public Property TOLOCNAME() As String
            Get
                return _TOLOCNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("To Bin", value, "^.{0,14}$") then Exit Property
                _IsSetTOLOCNAME = True
                If loading Then
                  _TOLOCNAME = Value
                Else
                    if not _TOLOCNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TOLOCNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TOLOCNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("To Pallet"),  _
         nType("Edm.String"),  _
         tab("To Warehouse"),  _
         Pos(232),  _
         twodBarcode("TOACTNAME")>  _
        Public Property TOACTNAME() As String
            Get
                return _TOACTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("To Pallet", value, "^.{0,16}$") then Exit Property
                _IsSetTOACTNAME = True
                If loading Then
                  _TOACTNAME = Value
                Else
                    if not _TOACTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TOACTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TOACTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("To Pallet's Bar Code"),  _
         nType("Edm.String"),  _
         tab("To Warehouse"),  _
         Pos(235),  _
         twodBarcode("TOPALLETNAME")>  _
        Public Property TOPALLETNAME() As String
            Get
                return _TOPALLETNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("To Pallet's Bar Code", value, "^.{0,16}$") then Exit Property
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
        
        <DisplayName("To Status"),  _
         nType("Edm.String"),  _
         tab("To Warehouse"),  _
         Pos(240),  _
         Mandatory(true),  _
         twodBarcode("TOCUSTNAME")>  _
        Public Property TOCUSTNAME() As String
            Get
                return _TOCUSTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("To Status", value, "^.{0,16}$") then Exit Property
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
        
        <DisplayName("Balance of Crates"),  _
         nType("Edm.Int64"),  _
         tab("To Warehouse"),  _
         Pos(245),  _
         [ReadOnly](true),  _
         twodBarcode("PNUMPACK")>  _
        Public Property PNUMPACK() As nullable (of int64)
            Get
                return _PNUMPACK
            End Get
            Set
                if not(value is nothing) then
                  _PNUMPACK = Value
                end if
            End Set
        End Property
        
        <DisplayName("Transfer of Rework"),  _
         nType("Edm.String"),  _
         tab("To Warehouse"),  _
         Pos(250),  _
         twodBarcode("REWORKFLAG")>  _
        Public Property REWORKFLAG() As String
            Get
                return _REWORKFLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Transfer of Rework", value, "^.{0,1}$") then Exit Property
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
        
        <DisplayName("Acceptable"),  _
         nType("Edm.String"),  _
         tab("To Warehouse"),  _
         Pos(260),  _
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
         tab("Unacceptable"),  _
         Pos(270),  _
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
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Unacceptable"),  _
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
        
        <DisplayName("Transaction (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Unacceptable"),  _
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
         tab("Unacceptable"),  _
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
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property SERNTRANS_SUBFORM() As QUERY_SERNTRANS
            Get
                return _SERNTRANS_SUBFORM
            End Get
            Set
                _SERNTRANS_SUBFORM = value
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
        Public Property LINKFAULTS_SUBFORM() As QUERY_LINKFAULTS
            Get
                return _LINKFAULTS_SUBFORM
            End Get
            Set
                _LINKFAULTS_SUBFORM = value
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
        Public Property WTASKTRANSLINK_SUBFORM() As QUERY_WTASKTRANSLINK
            Get
                return _WTASKTRANSLINK_SUBFORM
            End Get
            Set
                _WTASKTRANSLINK_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property TRANSTSIGN_SUBFORM() As QUERY_TRANSTSIGN
            Get
                return _TRANSTSIGN_SUBFORM
            End Get
            Set
                _TRANSTSIGN_SUBFORM = value
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
            if _IsSetPDES then
              if f then
                  jw.WriteRaw(", ""PDES"": ")
              else
                  jw.WriteRaw("""PDES"": ")
                  f = true
              end if
              jw.WriteValue(me.PDES)
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
            if _IsSetACTNAME then
              if f then
                  jw.WriteRaw(", ""ACTNAME"": ")
              else
                  jw.WriteRaw("""ACTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.ACTNAME)
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
            if _IsSetBARCODE then
              if f then
                  jw.WriteRaw(", ""BARCODE"": ")
              else
                  jw.WriteRaw("""BARCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.BARCODE)
            end if
            if _IsSetSETFLAG then
              if f then
                  jw.WriteRaw(", ""SETFLAG"": ")
              else
                  jw.WriteRaw("""SETFLAG"": ")
                  f = true
              end if
              jw.WriteValue(me.SETFLAG)
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
            if _IsSetQUANT then
              if f then
                  jw.WriteRaw(", ""QUANT"": ")
              else
                  jw.WriteRaw("""QUANT"": ")
                  f = true
              end if
              jw.WriteValue(me.QUANT)
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
            if _IsSetLOCNAME then
              if f then
                  jw.WriteRaw(", ""LOCNAME"": ")
              else
                  jw.WriteRaw("""LOCNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.LOCNAME)
            end if
            if _IsSetTOLOCNAME then
              if f then
                  jw.WriteRaw(", ""TOLOCNAME"": ")
              else
                  jw.WriteRaw("""TOLOCNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.TOLOCNAME)
            end if
            if _IsSetTOACTNAME then
              if f then
                  jw.WriteRaw(", ""TOACTNAME"": ")
              else
                  jw.WriteRaw("""TOACTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.TOACTNAME)
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
            if _IsSetTOCUSTNAME then
              if f then
                  jw.WriteRaw(", ""TOCUSTNAME"": ")
              else
                  jw.WriteRaw("""TOCUSTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.TOCUSTNAME)
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
            if _IsSetKLINE then
              if f then
                  jw.WriteRaw(", ""KLINE"": ")
              else
                  jw.WriteRaw("""KLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.KLINE)
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
            if _SERNTRANS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", SERNTRANS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as SERNTRANS in _SERNTRANS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _SERNTRANS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
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
            if _LINKFAULTS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", LINKFAULTS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as LINKFAULTS in _LINKFAULTS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _LINKFAULTS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
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
            if _WTASKTRANSLINK_SUBFORM.value.count > 0 then
              jw.WriteRaw(", WTASKTRANSLINK_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as WTASKTRANSLINK in _WTASKTRANSLINK_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _WTASKTRANSLINK_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _TRANSTSIGN_SUBFORM.value.count > 0 then
              jw.WriteRaw(", TRANSTSIGN_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as TRANSTSIGN in _TRANSTSIGN_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _TRANSTSIGN_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "TRANSORDER_T")
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
            if _IsSetACTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ACTNAME")
              .WriteAttributeString("value", me.ACTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
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
            if _IsSetBARCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "BARCODE")
              .WriteAttributeString("value", me.BARCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetSETFLAG then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SETFLAG")
              .WriteAttributeString("value", me.SETFLAG)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
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
            if _IsSetQUANT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "QUANT")
              .WriteAttributeString("value", me.QUANT)
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
            if _IsSetLOCNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "LOCNAME")
              .WriteAttributeString("value", me.LOCNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "14")
              .WriteEndElement
            end if
            if _IsSetTOLOCNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TOLOCNAME")
              .WriteAttributeString("value", me.TOLOCNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "14")
              .WriteEndElement
            end if
            if _IsSetTOACTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TOACTNAME")
              .WriteAttributeString("value", me.TOACTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
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
            if _IsSetTOCUSTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TOCUSTNAME")
              .WriteAttributeString("value", me.TOCUSTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
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
            if _IsSetKLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", me.KLINE)
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
            if _SERNTRANS_SUBFORM.value.count > 0 then
              for each itm as SERNTRANS in _SERNTRANS_SUBFORM.Value
                itm.toXML(xw,"SERNTRANS_SUBFORM")
              next
            end if
            if _OPENSERNUM_SUBFORM.value.count > 0 then
              for each itm as OPENSERNUM in _OPENSERNUM_SUBFORM.Value
                itm.toXML(xw,"OPENSERNUM_SUBFORM")
              next
            end if
            if _LINKFAULTS_SUBFORM.value.count > 0 then
              for each itm as LINKFAULTS in _LINKFAULTS_SUBFORM.Value
                itm.toXML(xw,"LINKFAULTS_SUBFORM")
              next
            end if
            if _PROJLINK_SUBFORM.value.count > 0 then
              for each itm as PROJLINK in _PROJLINK_SUBFORM.Value
                itm.toXML(xw,"PROJLINK_SUBFORM")
              next
            end if
            if _TRANSLABANALYSES_SUBFORM.value.count > 0 then
              for each itm as TRANSLABANALYSES in _TRANSLABANALYSES_SUBFORM.Value
                itm.toXML(xw,"TRANSLABANALYSES_SUBFORM")
              next
            end if
            if _WTASKTRANSLINK_SUBFORM.value.count > 0 then
              for each itm as WTASKTRANSLINK in _WTASKTRANSLINK_SUBFORM.Value
                itm.toXML(xw,"WTASKTRANSLINK_SUBFORM")
              next
            end if
            if _TRANSTSIGN_SUBFORM.value.count > 0 then
              for each itm as TRANSTSIGN in _TRANSTSIGN_SUBFORM.Value
                itm.toXML(xw,"TRANSTSIGN_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSORDER_T = JsonConvert.DeserializeObject(Of TRANSORDER_T)(e.StreamReader.ReadToEnd)
                With obj
                  _PARTNAME = .PARTNAME
                  _PDES = .PDES
                  _SERIALNAME = .SERIALNAME
                  _SERIALDES = .SERIALDES
                  _REVNAME = .REVNAME
                  _REVNUM = .REVNUM
                  _ACTNAME = .ACTNAME
                  _DATECODE = .DATECODE
                  _CUSTNAME = .CUSTNAME
                  _BARCODE = .BARCODE
                  _CQUANT = .CQUANT
                  _PQUANT = .PQUANT
                  _BAL = .BAL
                  _SETFLAG = .SETFLAG
                  _TQUANT = .TQUANT
                  _TUNITNAME = .TUNITNAME
                  _QUANT = .QUANT
                  _UNITNAME = .UNITNAME
                  _NUMPACK = .NUMPACK
                  _PACKCODE = .PACKCODE
                  _ORDNAME = .ORDNAME
                  _OLINE = .OLINE
                  _WARHSNAME = .WARHSNAME
                  _LOCNAME = .LOCNAME
                  _TOWARHSNAME = .TOWARHSNAME
                  _TOLOCNAME = .TOLOCNAME
                  _TOACTNAME = .TOACTNAME
                  _TOPALLETNAME = .TOPALLETNAME
                  _TOCUSTNAME = .TOCUSTNAME
                  _PNUMPACK = .PNUMPACK
                  _REWORKFLAG = .REWORKFLAG
                  _ANALYSISVALID = .ANALYSISVALID
                  _ANALYSISNOTVALID = .ANALYSISNOTVALID
                  _KLINE = .KLINE
                  _TRANS = .TRANS
                  _TYPE = .TYPE
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_TRANSORDER_T
        
        SERNTRANS = 0
        
        OPENSERNUM = 1
        
        LINKFAULTS = 2
        
        PROJLINK = 3
        
        TRANSLABANALYSES = 4
        
        WTASKTRANSLINK = 5
        
        TRANSTSIGN = 6
    End Enum
    
    <QueryTitle("Serial Numbers in Transaction")>  _
    Public Class QUERY_SERNTRANS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of SERNTRANS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of SERNTRANS)
            _Parent = nothing
            _Name = "SERNTRANS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of SERNTRANS)
            _Parent = Parent
            _name = "SERNTRANS_SUBFORM"
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
        
        Public Property Value() As list(of SERNTRANS)
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
                return GetType(SERNTRANS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _SERNTRANS As SERNTRANS In JsonConvert.DeserializeObject(Of QUERY_SERNTRANS)(stream.ReadToEnd).Value
              With _SERNTRANS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_SERNTRANS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as SERNTRANS = JsonConvert.DeserializeObject(Of SERNTRANS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, SERNTRANS)
                  .SERNUM = obj.SERNUM
                  .PARENTSERNUM = obj.PARENTSERNUM
                  .PARTNAME = obj.PARTNAME
                  .PARTDES = obj.PARTDES
                  .INCUSENUM = obj.INCUSENUM
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .SERN = obj.SERN
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new SERNTRANS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _SERNTRANS as SERNTRANS in value
              If _SERNTRANS.Equals(trycast(obj,SERNTRANS)) Then
                  value.remove(_SERNTRANS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class SERNTRANS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetSERNUM As Boolean = Boolean.FalseString
        
        Private _SERNUM As String
        
        Private _IsSetPARENTSERNUM As Boolean = Boolean.FalseString
        
        Private _PARENTSERNUM As String
        
        Private _IsSetPARTNAME As Boolean = Boolean.FalseString
        
        Private _PARTNAME As String
        
        Private _PARTDES As String
        
        Private _IsSetINCUSENUM As Boolean = Boolean.FalseString
        
        Private _INCUSENUM As String
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _IsSetSERN As Boolean = Boolean.FalseString
        
        Private _SERN As Long
        
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
                    return "SERNTRANS"
                else
                    return "SERNTRANS_SUBFORM"
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
        
        <DisplayName("Parent's Serial No."),  _
         nType("Edm.String"),  _
         tab("Serial Number"),  _
         Pos(20),  _
         twodBarcode("PARENTSERNUM")>  _
        Public Property PARENTSERNUM() As String
            Get
                return _PARENTSERNUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Parent's Serial No.", value, "^.{0,20}$") then Exit Property
                _IsSetPARENTSERNUM = True
                If loading Then
                  _PARENTSERNUM = Value
                Else
                    if not _PARENTSERNUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PARENTSERNUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PARENTSERNUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Parent Part Number"),  _
         nType("Edm.String"),  _
         tab("Serial Number"),  _
         Pos(22),  _
         twodBarcode("PARTNAME")>  _
        Public Property PARTNAME() As String
            Get
                return _PARTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Parent Part Number", value, "^.{0,15}$") then Exit Property
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
         tab("Serial Number"),  _
         Pos(24),  _
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
        
        <DisplayName("Serial Stamp"),  _
         nType("Edm.String"),  _
         tab("Serial Number"),  _
         Pos(26),  _
         twodBarcode("INCUSENUM")>  _
        Public Property INCUSENUM() As String
            Get
                return _INCUSENUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Serial Stamp", value, "^.{0,16}$") then Exit Property
                _IsSetINCUSENUM = True
                If loading Then
                  _INCUSENUM = Value
                Else
                    if not _INCUSENUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("INCUSENUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _INCUSENUM = Value
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
            if _IsSetPARENTSERNUM then
              if f then
                  jw.WriteRaw(", ""PARENTSERNUM"": ")
              else
                  jw.WriteRaw("""PARENTSERNUM"": ")
                  f = true
              end if
              jw.WriteValue(me.PARENTSERNUM)
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
            if _IsSetINCUSENUM then
              if f then
                  jw.WriteRaw(", ""INCUSENUM"": ")
              else
                  jw.WriteRaw("""INCUSENUM"": ")
                  f = true
              end if
              jw.WriteValue(me.INCUSENUM)
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
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "SERNTRANS")
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
            if _IsSetPARENTSERNUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PARENTSERNUM")
              .WriteAttributeString("value", me.PARENTSERNUM)
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
            if _IsSetINCUSENUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "INCUSENUM")
              .WriteAttributeString("value", me.INCUSENUM)
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
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as SERNTRANS = JsonConvert.DeserializeObject(Of SERNTRANS)(e.StreamReader.ReadToEnd)
                With obj
                  _SERNUM = .SERNUM
                  _PARENTSERNUM = .PARENTSERNUM
                  _PARTNAME = .PARTNAME
                  _PARTDES = .PARTDES
                  _INCUSENUM = .INCUSENUM
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _SERN = .SERN
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
    
    <QueryTitle("Malfunction Linked to Document")>  _
    Public Class QUERY_LINKFAULTS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of LINKFAULTS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of LINKFAULTS)
            _Parent = nothing
            _Name = "LINKFAULTS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of LINKFAULTS)
            _Parent = Parent
            _name = "LINKFAULTS_SUBFORM"
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
        
        Public Property Value() As list(of LINKFAULTS)
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
                return GetType(LINKFAULTS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _LINKFAULTS As LINKFAULTS In JsonConvert.DeserializeObject(Of QUERY_LINKFAULTS)(stream.ReadToEnd).Value
              With _LINKFAULTS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_LINKFAULTS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as LINKFAULTS = JsonConvert.DeserializeObject(Of LINKFAULTS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, LINKFAULTS)
                  .FAULTNO = obj.FAULTNO
                  .CURDATE = obj.CURDATE
                  .KLINE2 = obj.KLINE2
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new LINKFAULTS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _LINKFAULTS as LINKFAULTS in value
              If _LINKFAULTS.Equals(trycast(obj,LINKFAULTS)) Then
                  value.remove(_LINKFAULTS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class LINKFAULTS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetFAULTNO As Boolean = Boolean.FalseString
        
        Private _FAULTNO As String
        
        Private _IsSetCURDATE As Boolean = Boolean.FalseString
        
        Private _CURDATE As System.DateTimeOffset
        
        Private _IsSetKLINE2 As Boolean = Boolean.FalseString
        
        Private _KLINE2 As Long
        
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
                    return "LINKFAULTS"
                else
                    return "LINKFAULTS_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "KLINE2={0}", _
                  string.format("{0}",KLINE2) _ 
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
        
        <DisplayName("Malfunction Number"),  _
         nType("Edm.String"),  _
         tab("Malfunction Number"),  _
         Pos(10),  _
         Mandatory(true),  _
         twodBarcode("FAULTNO")>  _
        Public Property FAULTNO() As String
            Get
                return _FAULTNO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Malfunction Number", value, "^.{0,16}$") then Exit Property
                _IsSetFAULTNO = True
                If loading Then
                  _FAULTNO = Value
                Else
                    if not _FAULTNO = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FAULTNO", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FAULTNO = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Malfunction Number"),  _
         Pos(20),  _
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
        
        <DisplayName("Line2 (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Malfunction Number"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("KLINE2")>  _
        Public Property KLINE2() As nullable (of int64)
            Get
                return _KLINE2
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Line2 (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetKLINE2 = True
                If loading Then
                  _KLINE2 = Value
                Else
                    if not _KLINE2 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("KLINE2", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _KLINE2 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetFAULTNO then
              if f then
                  jw.WriteRaw(", ""FAULTNO"": ")
              else
                  jw.WriteRaw("""FAULTNO"": ")
                  f = true
              end if
              jw.WriteValue(me.FAULTNO)
            end if
            if _IsSetCURDATE then
              if f then
                  jw.WriteRaw(", ""CURDATE"": ")
              else
                  jw.WriteRaw("""CURDATE"": ")
                  f = true
              end if
              jw.WriteValue(me.CURDATE)
            end if
            if _IsSetKLINE2 then
              if f then
                  jw.WriteRaw(", ""KLINE2"": ")
              else
                  jw.WriteRaw("""KLINE2"": ")
                  f = true
              end if
              jw.WriteValue(me.KLINE2)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "LINKFAULTS")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "KLINE2")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetFAULTNO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FAULTNO")
              .WriteAttributeString("value", me.FAULTNO)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetCURDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CURDATE")
              .WriteAttributeString("value", me.CURDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetKLINE2 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "KLINE2")
              .WriteAttributeString("value", me.KLINE2)
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
                dim obj as LINKFAULTS = JsonConvert.DeserializeObject(Of LINKFAULTS)(e.StreamReader.ReadToEnd)
                With obj
                  _FAULTNO = .FAULTNO
                  _CURDATE = .CURDATE
                  _KLINE2 = .KLINE2
                end with
            End If
        End Sub
    End Class
    
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
    
    <QueryTitle("Warehouse Tasks for Line Item")>  _
    Public Class QUERY_WTASKTRANSLINK
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of WTASKTRANSLINK)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of WTASKTRANSLINK)
            _Parent = nothing
            _Name = "WTASKTRANSLINK"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of WTASKTRANSLINK)
            _Parent = Parent
            _name = "WTASKTRANSLINK_SUBFORM"
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
        
        Public Property Value() As list(of WTASKTRANSLINK)
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
                return GetType(WTASKTRANSLINK)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _WTASKTRANSLINK As WTASKTRANSLINK In JsonConvert.DeserializeObject(Of QUERY_WTASKTRANSLINK)(stream.ReadToEnd).Value
              With _WTASKTRANSLINK
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_WTASKTRANSLINK)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as WTASKTRANSLINK = JsonConvert.DeserializeObject(Of WTASKTRANSLINK)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, WTASKTRANSLINK)
                  .CURDATE = obj.CURDATE
                  .WTASKNUM = obj.WTASKNUM
                  .WTASKTYPECODE = obj.WTASKTYPECODE
                  .WTASKTYPEDES = obj.WTASKTYPEDES
                  .REMARK = obj.REMARK
                  .LINE = obj.LINE
                  .KLINE = obj.KLINE
                  .WTASK = obj.WTASK
                  .WTASKI = obj.WTASKI
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new WTASKTRANSLINK(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _WTASKTRANSLINK as WTASKTRANSLINK in value
              If _WTASKTRANSLINK.Equals(trycast(obj,WTASKTRANSLINK)) Then
                  value.remove(_WTASKTRANSLINK)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class WTASKTRANSLINK
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _CURDATE As System.DateTimeOffset
        
        Private _WTASKNUM As String
        
        Private _WTASKTYPECODE As String
        
        Private _WTASKTYPEDES As String
        
        Private _REMARK As String
        
        Private _IsSetLINE As Boolean = Boolean.FalseString
        
        Private _LINE As Long
        
        Private _KLINE As Long
        
        Private _WTASK As Long
        
        Private _WTASKI As Long
        
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
                    return "WTASKTRANSLINK"
                else
                    return "WTASKTRANSLINK_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "KLINE={0},WTASK={1}", _
                  string.format("{0}",KLINE), _
                  string.format("{0}",WTASK) _ 
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
         [ReadOnly](true),  _
         twodBarcode("CURDATE")>  _
        Public Property CURDATE() As nullable (of DateTimeOffset)
            Get
                return _CURDATE
            End Get
            Set
                if not(value is nothing) then
                  _CURDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Warehouse Task No."),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("WTASKNUM")>  _
        Public Property WTASKNUM() As String
            Get
                return _WTASKNUM
            End Get
            Set
                if not(value is nothing) then
                  _WTASKNUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("Warehouse Task Type"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("WTASKTYPECODE")>  _
        Public Property WTASKTYPECODE() As String
            Get
                return _WTASKTYPECODE
            End Get
            Set
                if not(value is nothing) then
                  _WTASKTYPECODE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Task Type Desc."),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("WTASKTYPEDES")>  _
        Public Property WTASKTYPEDES() As String
            Get
                return _WTASKTYPEDES
            End Get
            Set
                if not(value is nothing) then
                  _WTASKTYPEDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Remark"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(50),  _
         [ReadOnly](true),  _
         twodBarcode("REMARK")>  _
        Public Property REMARK() As String
            Get
                return _REMARK
            End Get
            Set
                if not(value is nothing) then
                  _REMARK = Value
                end if
            End Set
        End Property
        
        <DisplayName("LINE"),  _
         nType("Edm.Int64"),  _
         tab("Date"),  _
         Pos(0),  _
         twodBarcode("LINE")>  _
        Public Property LINE() As nullable (of int64)
            Get
                return _LINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("LINE", value, "^[0-9\-]+$") then Exit Property
                _IsSetLINE = True
                If loading Then
                  _LINE = Value
                Else
                    if not _LINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("LINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _LINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Date"),  _
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
        
        <DisplayName("Warehouse Task (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Date"),  _
         Pos(99),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("WTASK")>  _
        Public Property WTASK() As nullable (of int64)
            Get
                return _WTASK
            End Get
            Set
                if not(value is nothing) then
                  _WTASK = Value
                end if
            End Set
        End Property
        
        <DisplayName("Task Line (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Task Line (ID)"),  _
         Pos(99),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("WTASKI")>  _
        Public Property WTASKI() As nullable (of int64)
            Get
                return _WTASKI
            End Get
            Set
                if not(value is nothing) then
                  _WTASKI = Value
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetLINE then
              if f then
                  jw.WriteRaw(", ""LINE"": ")
              else
                  jw.WriteRaw("""LINE"": ")
                  f = true
              end if
              jw.WriteValue(me.LINE)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "WTASKTRANSLINK")
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
              .WriteAttributeString("name", "WTASK")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "LINE")
              .WriteAttributeString("value", me.LINE)
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
                dim obj as WTASKTRANSLINK = JsonConvert.DeserializeObject(Of WTASKTRANSLINK)(e.StreamReader.ReadToEnd)
                With obj
                  _CURDATE = .CURDATE
                  _WTASKNUM = .WTASKNUM
                  _WTASKTYPECODE = .WTASKTYPECODE
                  _WTASKTYPEDES = .WTASKTYPEDES
                  _REMARK = .REMARK
                  _LINE = .LINE
                  _KLINE = .KLINE
                  _WTASK = .WTASK
                  _WTASKI = .WTASKI
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Electronic Signature")>  _
    Public Class QUERY_TRANSTSIGN
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of TRANSTSIGN)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of TRANSTSIGN)
            _Parent = nothing
            _Name = "TRANSTSIGN"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of TRANSTSIGN)
            _Parent = Parent
            _name = "TRANSTSIGN_SUBFORM"
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
        
        Public Property Value() As list(of TRANSTSIGN)
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
                return GetType(TRANSTSIGN)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _TRANSTSIGN As TRANSTSIGN In JsonConvert.DeserializeObject(Of QUERY_TRANSTSIGN)(stream.ReadToEnd).Value
              With _TRANSTSIGN
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_TRANSTSIGN)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as TRANSTSIGN = JsonConvert.DeserializeObject(Of TRANSTSIGN)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, TRANSTSIGN)
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
            e.NewObject = new TRANSTSIGN(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _TRANSTSIGN as TRANSTSIGN in value
              If _TRANSTSIGN.Equals(trycast(obj,TRANSTSIGN)) Then
                  value.remove(_TRANSTSIGN)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class TRANSTSIGN
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
                    return "TRANSTSIGN"
                else
                    return "TRANSTSIGN_SUBFORM"
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
                .WriteAttributeString("name", "TRANSTSIGN")
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
                dim obj as TRANSTSIGN = JsonConvert.DeserializeObject(Of TRANSTSIGN)(e.StreamReader.ReadToEnd)
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
    
    <QueryTitle("Sales Orders for Document")>  _
    Public Class QUERY_DOCORD
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of DOCORD)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of DOCORD)
            _Parent = nothing
            _Name = "DOCORD"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of DOCORD)
            _Parent = Parent
            _name = "DOCORD_SUBFORM"
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
        
        Public Property Value() As list(of DOCORD)
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
                return GetType(DOCORD)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _DOCORD As DOCORD In JsonConvert.DeserializeObject(Of QUERY_DOCORD)(stream.ReadToEnd).Value
              With _DOCORD
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_DOCORD)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DOCORD = JsonConvert.DeserializeObject(Of DOCORD)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, DOCORD)
                  .ORDNAME = obj.ORDNAME
                  .REFERENCE = obj.REFERENCE
                  .CURDATE = obj.CURDATE
                  .CUSTNAME = obj.CUSTNAME
                  .RETURNS = obj.RETURNS
                  .ORD = obj.ORD
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new DOCORD(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _DOCORD as DOCORD in value
              If _DOCORD.Equals(trycast(obj,DOCORD)) Then
                  value.remove(_DOCORD)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class DOCORD
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetORDNAME As Boolean = Boolean.FalseString
        
        Private _ORDNAME As String
        
        Private _IsSetREFERENCE As Boolean = Boolean.FalseString
        
        Private _REFERENCE As String
        
        Private _CURDATE As System.DateTimeOffset
        
        Private _CUSTNAME As String
        
        Private _IsSetRETURNS As Boolean = Boolean.FalseString
        
        Private _RETURNS As String
        
        Private _IsSetORD As Boolean = Boolean.FalseString
        
        Private _ORD As Long
        
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
                    return "DOCORD"
                else
                    return "DOCORD_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "ORD={0}", _
                  string.format("{0}",ORD) _ 
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
        
        <DisplayName("Order"),  _
         nType("Edm.String"),  _
         tab("Order"),  _
         Pos(10),  _
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
        
        <DisplayName("Customer's Purch Ord"),  _
         nType("Edm.String"),  _
         tab("Order"),  _
         Pos(10),  _
         twodBarcode("REFERENCE")>  _
        Public Property REFERENCE() As String
            Get
                return _REFERENCE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Customer's Purch Ord", value, "^.{0,15}$") then Exit Property
                _IsSetREFERENCE = True
                If loading Then
                  _REFERENCE = Value
                Else
                    if not _REFERENCE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("REFERENCE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _REFERENCE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Order"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("CURDATE")>  _
        Public Property CURDATE() As nullable (of DateTimeOffset)
            Get
                return _CURDATE
            End Get
            Set
                if not(value is nothing) then
                  _CURDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Customer Number"),  _
         nType("Edm.String"),  _
         tab("Order"),  _
         Pos(30),  _
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
        
        <DisplayName("Return?"),  _
         nType("Edm.String"),  _
         tab("Order"),  _
         Pos(40),  _
         twodBarcode("RETURNS")>  _
        Public Property RETURNS() As String
            Get
                return _RETURNS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Return?", value, "^.{0,1}$") then Exit Property
                _IsSetRETURNS = True
                If loading Then
                  _RETURNS = Value
                Else
                    if not _RETURNS = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("RETURNS", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _RETURNS = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Order (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Order"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("ORD")>  _
        Public Property ORD() As nullable (of int64)
            Get
                return _ORD
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Order (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetORD = True
                If loading Then
                  _ORD = Value
                Else
                    if not _ORD = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ORD", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ORD = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetORDNAME then
              if f then
                  jw.WriteRaw(", ""ORDNAME"": ")
              else
                  jw.WriteRaw("""ORDNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.ORDNAME)
            end if
            if _IsSetREFERENCE then
              if f then
                  jw.WriteRaw(", ""REFERENCE"": ")
              else
                  jw.WriteRaw("""REFERENCE"": ")
                  f = true
              end if
              jw.WriteValue(me.REFERENCE)
            end if
            if _IsSetRETURNS then
              if f then
                  jw.WriteRaw(", ""RETURNS"": ")
              else
                  jw.WriteRaw("""RETURNS"": ")
                  f = true
              end if
              jw.WriteValue(me.RETURNS)
            end if
            if _IsSetORD then
              if f then
                  jw.WriteRaw(", ""ORD"": ")
              else
                  jw.WriteRaw("""ORD"": ")
                  f = true
              end if
              jw.WriteValue(me.ORD)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "DOCORD")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "ORD")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetORDNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ORDNAME")
              .WriteAttributeString("value", me.ORDNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetREFERENCE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REFERENCE")
              .WriteAttributeString("value", me.REFERENCE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "15")
              .WriteEndElement
            end if
            if _IsSetRETURNS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "RETURNS")
              .WriteAttributeString("value", me.RETURNS)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetORD then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ORD")
              .WriteAttributeString("value", me.ORD)
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
                dim obj as DOCORD = JsonConvert.DeserializeObject(Of DOCORD)(e.StreamReader.ReadToEnd)
                With obj
                  _ORDNAME = .ORDNAME
                  _REFERENCE = .REFERENCE
                  _CURDATE = .CURDATE
                  _CUSTNAME = .CUSTNAME
                  _RETURNS = .RETURNS
                  _ORD = .ORD
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Packing Slips in Document")>  _
    Public Class QUERY_DOCPACK
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of DOCPACK)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of DOCPACK)
            _Parent = nothing
            _Name = "DOCPACK"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of DOCPACK)
            _Parent = Parent
            _name = "DOCPACK_SUBFORM"
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
        
        Public Property Value() As list(of DOCPACK)
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
                return GetType(DOCPACK)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _DOCPACK As DOCPACK In JsonConvert.DeserializeObject(Of QUERY_DOCPACK)(stream.ReadToEnd).Value
              With _DOCPACK
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_DOCPACK)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DOCPACK = JsonConvert.DeserializeObject(Of DOCPACK)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, DOCPACK)
                  .DOCNO = obj.DOCNO
                  .BOOKNUM = obj.BOOKNUM
                  .CURDATE = obj.CURDATE
                  .ORDNAME = obj.ORDNAME
                  .REFERENCE = obj.REFERENCE
                  .MWEIGHT = obj.MWEIGHT
                  .PACKCODE = obj.PACKCODE
                  .PACKNAME = obj.PACKNAME
                  .PACK = obj.PACK
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new DOCPACK(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _DOCPACK as DOCPACK in value
              If _DOCPACK.Equals(trycast(obj,DOCPACK)) Then
                  value.remove(_DOCPACK)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class DOCPACK
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetDOCNO As Boolean = Boolean.FalseString
        
        Private _DOCNO As String
        
        Private _IsSetBOOKNUM As Boolean = Boolean.FalseString
        
        Private _BOOKNUM As String
        
        Private _CURDATE As System.DateTimeOffset
        
        Private _ORDNAME As String
        
        Private _REFERENCE As String
        
        Private _MWEIGHT As Decimal
        
        Private _PACKCODE As String
        
        Private _PACKNAME As String
        
        Private _IsSetPACK As Boolean = Boolean.FalseString
        
        Private _PACK As Long
        
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
                    return "DOCPACK"
                else
                    return "DOCPACK_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "PACK={0}", _
                  string.format("{0}",PACK) _ 
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
        
        <DisplayName("Packing Slip Number"),  _
         nType("Edm.String"),  _
         tab("Packing Slip Number"),  _
         Pos(10),  _
         twodBarcode("DOCNO")>  _
        Public Property DOCNO() As String
            Get
                return _DOCNO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Packing Slip Number", value, "^.{0,16}$") then Exit Property
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
        
        <DisplayName("External Slip No."),  _
         nType("Edm.String"),  _
         tab("Packing Slip Number"),  _
         Pos(11),  _
         twodBarcode("BOOKNUM")>  _
        Public Property BOOKNUM() As String
            Get
                return _BOOKNUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("External Slip No.", value, "^.{0,16}$") then Exit Property
                _IsSetBOOKNUM = True
                If loading Then
                  _BOOKNUM = Value
                Else
                    if not _BOOKNUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("BOOKNUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _BOOKNUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Packing Slip Number"),  _
         Pos(12),  _
         [ReadOnly](true),  _
         twodBarcode("CURDATE")>  _
        Public Property CURDATE() As nullable (of DateTimeOffset)
            Get
                return _CURDATE
            End Get
            Set
                if not(value is nothing) then
                  _CURDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Order"),  _
         nType("Edm.String"),  _
         tab("Packing Slip Number"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("ORDNAME")>  _
        Public Property ORDNAME() As String
            Get
                return _ORDNAME
            End Get
            Set
                if not(value is nothing) then
                  _ORDNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Customer's Purch Ord"),  _
         nType("Edm.String"),  _
         tab("Packing Slip Number"),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("REFERENCE")>  _
        Public Property REFERENCE() As String
            Get
                return _REFERENCE
            End Get
            Set
                if not(value is nothing) then
                  _REFERENCE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Manual Gross Weight"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(10),  _
         tab("Packing Slip Number"),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("MWEIGHT")>  _
        Public Property MWEIGHT() As nullable(of decimal)
            Get
                return _MWEIGHT
            End Get
            Set
                if not(value is nothing) then
                  _MWEIGHT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Crate Type Code"),  _
         nType("Edm.String"),  _
         tab("Packing Slip Number"),  _
         Pos(50),  _
         [ReadOnly](true),  _
         twodBarcode("PACKCODE")>  _
        Public Property PACKCODE() As String
            Get
                return _PACKCODE
            End Get
            Set
                if not(value is nothing) then
                  _PACKCODE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Crate Type Desc."),  _
         nType("Edm.String"),  _
         tab("Packing Slip Number"),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("PACKNAME")>  _
        Public Property PACKNAME() As String
            Get
                return _PACKNAME
            End Get
            Set
                if not(value is nothing) then
                  _PACKNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Crate (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Crate (ID)"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("PACK")>  _
        Public Property PACK() As nullable (of int64)
            Get
                return _PACK
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Crate (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetPACK = True
                If loading Then
                  _PACK = Value
                Else
                    if not _PACK = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PACK", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PACK = Value
                        End If
                    end if
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
            if _IsSetBOOKNUM then
              if f then
                  jw.WriteRaw(", ""BOOKNUM"": ")
              else
                  jw.WriteRaw("""BOOKNUM"": ")
                  f = true
              end if
              jw.WriteValue(me.BOOKNUM)
            end if
            if _IsSetPACK then
              if f then
                  jw.WriteRaw(", ""PACK"": ")
              else
                  jw.WriteRaw("""PACK"": ")
                  f = true
              end if
              jw.WriteValue(me.PACK)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "DOCPACK")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "PACK")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetDOCNO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DOCNO")
              .WriteAttributeString("value", me.DOCNO)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetBOOKNUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "BOOKNUM")
              .WriteAttributeString("value", me.BOOKNUM)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetPACK then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PACK")
              .WriteAttributeString("value", me.PACK)
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
                dim obj as DOCPACK = JsonConvert.DeserializeObject(Of DOCPACK)(e.StreamReader.ReadToEnd)
                With obj
                  _DOCNO = .DOCNO
                  _BOOKNUM = .BOOKNUM
                  _CURDATE = .CURDATE
                  _ORDNAME = .ORDNAME
                  _REFERENCE = .REFERENCE
                  _MWEIGHT = .MWEIGHT
                  _PACKCODE = .PACKCODE
                  _PACKNAME = .PACKNAME
                  _PACK = .PACK
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Tasks for Document")>  _
    Public Class QUERY_GENCUSTNOTES
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of GENCUSTNOTES)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of GENCUSTNOTES)
            _Parent = nothing
            _Name = "GENCUSTNOTES"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Notes")
            .add(1, "Responses to Questions")
            .add(2, "Respondent's Remarks")
            .add(3, "Customer Documents for Task")
            .add(4, "Vendor Documents for Task")
            .add(5, "To Do Item")
            .add(6, "History of Statuses")
            .add(7, "Electronic Signature")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of GENCUSTNOTES)
            _Parent = Parent
            _name = "GENCUSTNOTES_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Notes")
            .add(1, "Responses to Questions")
            .add(2, "Respondent's Remarks")
            .add(3, "Customer Documents for Task")
            .add(4, "Vendor Documents for Task")
            .add(5, "To Do Item")
            .add(6, "History of Statuses")
            .add(7, "Electronic Signature")
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
        
        Public Property Value() As list(of GENCUSTNOTES)
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
                return GetType(GENCUSTNOTES)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _GENCUSTNOTES As GENCUSTNOTES In JsonConvert.DeserializeObject(Of QUERY_GENCUSTNOTES)(stream.ReadToEnd).Value
              With _GENCUSTNOTES
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_GENCUSTNOTES)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as GENCUSTNOTES = JsonConvert.DeserializeObject(Of GENCUSTNOTES)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, GENCUSTNOTES)
                  .CURDATE = obj.CURDATE
                  .USERLOGIN = obj.USERLOGIN
                  .DAY = obj.DAY
                  .STIME = obj.STIME
                  .TILLDATE = obj.TILLDATE
                  .TILLDAY = obj.TILLDAY
                  .ETIME = obj.ETIME
                  .PLANNEDTIME = obj.PLANNEDTIME
                  .STATDES = obj.STATDES
                  .CLOSED = obj.CLOSED
                  .SUBJECT = obj.SUBJECT
                  .CUSTNOTE = obj.CUSTNOTE
                  .CUSTNAME = obj.CUSTNAME
                  .CUSTDES = obj.CUSTDES
                  .DCODE = obj.DCODE
                  .CODEDES = obj.CODEDES
                  .PRIO = obj.PRIO
                  .NAME = obj.NAME
                  .PHONENUM = obj.PHONENUM
                  .CELLPHONE = obj.CELLPHONE
                  .EMAIL = obj.EMAIL
                  .SNAME = obj.SNAME
                  .SPHONENUM = obj.SPHONENUM
                  .SCELLPHONE = obj.SCELLPHONE
                  .EMAIL2 = obj.EMAIL2
                  .TOPICCODE = obj.TOPICCODE
                  .TOPICDES = obj.TOPICDES
                  .CUSTNOTETYPEDES = obj.CUSTNOTETYPEDES
                  .REMINDFLAG = obj.REMINDFLAG
                  .REMINDTIME = obj.REMINDTIME
                  .USERLOGIN2 = obj.USERLOGIN2
                  .USERLOGIN3 = obj.USERLOGIN3
                  .GROUPNAME = obj.GROUPNAME
                  .GROUPNAME2 = obj.GROUPNAME2
                  .GROUPNAME3 = obj.GROUPNAME3
                  .RESOURCENAME = obj.RESOURCENAME
                  .RESOURCENAME2 = obj.RESOURCENAME2
                  .RESOURCENAME3 = obj.RESOURCENAME3
                  .REMARK = obj.REMARK
                  .PREVCUSTNOTEA = obj.PREVCUSTNOTEA
                  .QUESTFCODE = obj.QUESTFCODE
                  .QUESTFDES = obj.QUESTFDES
                  .BRANCHNAME = obj.BRANCHNAME
                  .BRANCHDES = obj.BRANCHDES
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new GENCUSTNOTES(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _GENCUSTNOTES as GENCUSTNOTES in value
              If _GENCUSTNOTES.Equals(trycast(obj,GENCUSTNOTES)) Then
                  value.remove(_GENCUSTNOTES)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class GENCUSTNOTES
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetCURDATE As Boolean = Boolean.FalseString
        
        Private _CURDATE As System.DateTimeOffset
        
        Private _IsSetUSERLOGIN As Boolean = Boolean.FalseString
        
        Private _USERLOGIN As String
        
        Private _DAY As String
        
        Private _IsSetSTIME As Boolean = Boolean.FalseString
        
        Private _STIME As String
        
        Private _IsSetTILLDATE As Boolean = Boolean.FalseString
        
        Private _TILLDATE As System.DateTimeOffset
        
        Private _TILLDAY As String
        
        Private _IsSetETIME As Boolean = Boolean.FalseString
        
        Private _ETIME As String
        
        Private _IsSetPLANNEDTIME As Boolean = Boolean.FalseString
        
        Private _PLANNEDTIME As String
        
        Private _IsSetSTATDES As Boolean = Boolean.FalseString
        
        Private _STATDES As String
        
        Private _IsSetCLOSED As Boolean = Boolean.FalseString
        
        Private _CLOSED As String
        
        Private _IsSetSUBJECT As Boolean = Boolean.FalseString
        
        Private _SUBJECT As String
        
        Private _CUSTNOTE As Long
        
        Private _IsSetCUSTNAME As Boolean = Boolean.FalseString
        
        Private _CUSTNAME As String
        
        Private _CUSTDES As String
        
        Private _IsSetDCODE As Boolean = Boolean.FalseString
        
        Private _DCODE As String
        
        Private _CODEDES As String
        
        Private _IsSetPRIO As Boolean = Boolean.FalseString
        
        Private _PRIO As Long
        
        Private _IsSetNAME As Boolean = Boolean.FalseString
        
        Private _NAME As String
        
        Private _PHONENUM As String
        
        Private _CELLPHONE As String
        
        Private _EMAIL As String
        
        Private _IsSetSNAME As Boolean = Boolean.FalseString
        
        Private _SNAME As String
        
        Private _SPHONENUM As String
        
        Private _SCELLPHONE As String
        
        Private _EMAIL2 As String
        
        Private _IsSetTOPICCODE As Boolean = Boolean.FalseString
        
        Private _TOPICCODE As String
        
        Private _TOPICDES As String
        
        Private _IsSetCUSTNOTETYPEDES As Boolean = Boolean.FalseString
        
        Private _CUSTNOTETYPEDES As String
        
        Private _IsSetREMINDFLAG As Boolean = Boolean.FalseString
        
        Private _REMINDFLAG As String
        
        Private _IsSetREMINDTIME As Boolean = Boolean.FalseString
        
        Private _REMINDTIME As String
        
        Private _IsSetUSERLOGIN2 As Boolean = Boolean.FalseString
        
        Private _USERLOGIN2 As String
        
        Private _IsSetUSERLOGIN3 As Boolean = Boolean.FalseString
        
        Private _USERLOGIN3 As String
        
        Private _IsSetGROUPNAME As Boolean = Boolean.FalseString
        
        Private _GROUPNAME As String
        
        Private _IsSetGROUPNAME2 As Boolean = Boolean.FalseString
        
        Private _GROUPNAME2 As String
        
        Private _IsSetGROUPNAME3 As Boolean = Boolean.FalseString
        
        Private _GROUPNAME3 As String
        
        Private _IsSetRESOURCENAME As Boolean = Boolean.FalseString
        
        Private _RESOURCENAME As String
        
        Private _IsSetRESOURCENAME2 As Boolean = Boolean.FalseString
        
        Private _RESOURCENAME2 As String
        
        Private _IsSetRESOURCENAME3 As Boolean = Boolean.FalseString
        
        Private _RESOURCENAME3 As String
        
        Private _IsSetREMARK As Boolean = Boolean.FalseString
        
        Private _REMARK As String
        
        Private _IsSetPREVCUSTNOTEA As Boolean = Boolean.FalseString
        
        Private _PREVCUSTNOTEA As Long
        
        Private _IsSetQUESTFCODE As Boolean = Boolean.FalseString
        
        Private _QUESTFCODE As String
        
        Private _QUESTFDES As String
        
        Private _IsSetBRANCHNAME As Boolean = Boolean.FalseString
        
        Private _BRANCHNAME As String
        
        Private _BRANCHDES As String
        
        Private _CUSTNOTESTEXT_SUBFORM As QUERY_CUSTNOTESTEXT
        
        Private _CUSTNQUESTLINES_SUBFORM As QUERY_CUSTNQUESTLINES
        
        Private _CUSTNQUESTTEXT_SUBFORM As QUERY_CUSTNQUESTTEXT
        
        Private _CUSTNOTEEXTFILE_SUBFORM As QUERY_CUSTNOTEEXTFILE
        
        Private _SUPNOTEEXTFILE_SUBFORM As QUERY_SUPNOTEEXTFILE
        
        Private _DOCTODOLIST_SUBFORM As QUERY_DOCTODOLIST
        
        Private _DOCTODOLISTLOG_SUBFORM As QUERY_DOCTODOLISTLOG
        
        Private _CUSTNOTESIGN_SUBFORM As QUERY_CUSTNOTESIGN
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Notes"))
            ChildQuery.add(1, new oNavigation("Responses to Questions"))
            ChildQuery.add(2, new oNavigation("Respondent's Remarks"))
            ChildQuery.add(3, new oNavigation("Customer Documents for Task"))
            ChildQuery.add(4, new oNavigation("Vendor Documents for Task"))
            ChildQuery.add(5, new oNavigation("To Do Item"))
            ChildQuery.add(6, new oNavigation("History of Statuses"))
            ChildQuery.add(7, new oNavigation("Electronic Signature"))
            _CUSTNOTESTEXT_SUBFORM = new QUERY_CUSTNOTESTEXT(me)
            _CUSTNQUESTLINES_SUBFORM = new QUERY_CUSTNQUESTLINES(me)
            _CUSTNQUESTTEXT_SUBFORM = new QUERY_CUSTNQUESTTEXT(me)
            _CUSTNOTEEXTFILE_SUBFORM = new QUERY_CUSTNOTEEXTFILE(me)
            _SUPNOTEEXTFILE_SUBFORM = new QUERY_SUPNOTEEXTFILE(me)
            _DOCTODOLIST_SUBFORM = new QUERY_DOCTODOLIST(me)
            _DOCTODOLISTLOG_SUBFORM = new QUERY_DOCTODOLISTLOG(me)
            _CUSTNOTESIGN_SUBFORM = new QUERY_CUSTNOTESIGN(me)
            WITH ChildQuery(0)
               .setoDataQuery(_CUSTNOTESTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_CUSTNQUESTLINES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_CUSTNQUESTTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_CUSTNOTEEXTFILE_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_SUPNOTEEXTFILE_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(5)
               .setoDataQuery(_DOCTODOLIST_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(6)
               .setoDataQuery(_DOCTODOLISTLOG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(7)
               .setoDataQuery(_CUSTNOTESIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Notes"))
            ChildQuery.add(1, new oNavigation("Responses to Questions"))
            ChildQuery.add(2, new oNavigation("Respondent's Remarks"))
            ChildQuery.add(3, new oNavigation("Customer Documents for Task"))
            ChildQuery.add(4, new oNavigation("Vendor Documents for Task"))
            ChildQuery.add(5, new oNavigation("To Do Item"))
            ChildQuery.add(6, new oNavigation("History of Statuses"))
            ChildQuery.add(7, new oNavigation("Electronic Signature"))
            _CUSTNOTESTEXT_SUBFORM = new QUERY_CUSTNOTESTEXT(me)
            _CUSTNQUESTLINES_SUBFORM = new QUERY_CUSTNQUESTLINES(me)
            _CUSTNQUESTTEXT_SUBFORM = new QUERY_CUSTNQUESTTEXT(me)
            _CUSTNOTEEXTFILE_SUBFORM = new QUERY_CUSTNOTEEXTFILE(me)
            _SUPNOTEEXTFILE_SUBFORM = new QUERY_SUPNOTEEXTFILE(me)
            _DOCTODOLIST_SUBFORM = new QUERY_DOCTODOLIST(me)
            _DOCTODOLISTLOG_SUBFORM = new QUERY_DOCTODOLISTLOG(me)
            _CUSTNOTESIGN_SUBFORM = new QUERY_CUSTNOTESIGN(me)
            WITH ChildQuery(0)
               .setoDataQuery(_CUSTNOTESTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_CUSTNQUESTLINES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_CUSTNQUESTTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_CUSTNOTEEXTFILE_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_SUPNOTEEXTFILE_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(5)
               .setoDataQuery(_DOCTODOLIST_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(6)
               .setoDataQuery(_DOCTODOLISTLOG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
            WITH ChildQuery(7)
               .setoDataQuery(_CUSTNOTESIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Notes", _CUSTNOTESTEXT_SUBFORM))
                   .add(1, new oNavigation("Responses to Questions", _CUSTNQUESTLINES_SUBFORM))
                   .add(2, new oNavigation("Respondent's Remarks", _CUSTNQUESTTEXT_SUBFORM))
                   .add(3, new oNavigation("Customer Documents for Task", _CUSTNOTEEXTFILE_SUBFORM))
                   .add(4, new oNavigation("Vendor Documents for Task", _SUPNOTEEXTFILE_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("Electronic Signature", _CUSTNOTESIGN_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "GENCUSTNOTES"
                else
                    return "GENCUSTNOTES_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "CUSTNOTE={0}", _
                  string.format("{0}",CUSTNOTE) _ 
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
        
        <DisplayName("Start Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Start Date"),  _
         Pos(1),  _
         Mandatory(true),  _
         twodBarcode("CURDATE")>  _
        Public Property CURDATE() As nullable (of DateTimeOffset)
            Get
                return _CURDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Start Date", value, "^.*$") then Exit Property
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
        
        <DisplayName("Assigned to"),  _
         nType("Edm.String"),  _
         tab("Start Date"),  _
         Pos(2),  _
         Mandatory(true),  _
         twodBarcode("USERLOGIN")>  _
        Public Property USERLOGIN() As String
            Get
                return _USERLOGIN
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Assigned to", value, "^.{0,20}$") then Exit Property
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
        
        <DisplayName("Day"),  _
         nType("Edm.String"),  _
         tab("Start Date"),  _
         Pos(3),  _
         [ReadOnly](true),  _
         twodBarcode("DAY")>  _
        Public Property DAY() As String
            Get
                return _DAY
            End Get
            Set
                if not(value is nothing) then
                  _DAY = Value
                end if
            End Set
        End Property
        
        <DisplayName("Start Time"),  _
         nType("Edm.String"),  _
         tab("Start Date"),  _
         Pos(10),  _
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
        
        <DisplayName("End Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Start Date"),  _
         Pos(12),  _
         twodBarcode("TILLDATE")>  _
        Public Property TILLDATE() As nullable (of DateTimeOffset)
            Get
                return _TILLDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("End Date", value, "^.*$") then Exit Property
                _IsSetTILLDATE = True
                If loading Then
                  _TILLDATE = Value
                Else
                    if not _TILLDATE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TILLDATE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TILLDATE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("To Day"),  _
         nType("Edm.String"),  _
         tab("Start Date"),  _
         Pos(14),  _
         [ReadOnly](true),  _
         twodBarcode("TILLDAY")>  _
        Public Property TILLDAY() As String
            Get
                return _TILLDAY
            End Get
            Set
                if not(value is nothing) then
                  _TILLDAY = Value
                end if
            End Set
        End Property
        
        <DisplayName("End Time"),  _
         nType("Edm.String"),  _
         tab("Start Date"),  _
         Pos(16),  _
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
        
        <DisplayName("Appointment Duration"),  _
         nType("Edm.String"),  _
         tab("Start Date"),  _
         Pos(17),  _
         twodBarcode("PLANNEDTIME")>  _
        Public Property PLANNEDTIME() As String
            Get
                return _PLANNEDTIME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Appointment Duration", value, "^.{0,6}$") then Exit Property
                _IsSetPLANNEDTIME = True
                If loading Then
                  _PLANNEDTIME = Value
                Else
                    if not _PLANNEDTIME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PLANNEDTIME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PLANNEDTIME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Status"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(18),  _
         Mandatory(true),  _
         twodBarcode("STATDES")>  _
        Public Property STATDES() As String
            Get
                return _STATDES
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Status", value, "^.{0,12}$") then Exit Property
                _IsSetSTATDES = True
                If loading Then
                  _STATDES = Value
                Else
                    if not _STATDES = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("STATDES", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _STATDES = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Done?"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(20),  _
         twodBarcode("CLOSED")>  _
        Public Property CLOSED() As String
            Get
                return _CLOSED
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Done?", value, "^.{0,1}$") then Exit Property
                _IsSetCLOSED = True
                If loading Then
                  _CLOSED = Value
                Else
                    if not _CLOSED = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CLOSED", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CLOSED = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Subject"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(20),  _
         twodBarcode("SUBJECT")>  _
        Public Property SUBJECT() As String
            Get
                return _SUBJECT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Subject", value, "^.{0,52}$") then Exit Property
                _IsSetSUBJECT = True
                If loading Then
                  _SUBJECT = Value
                Else
                    if not _SUBJECT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SUBJECT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SUBJECT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Task Number"),  _
         nType("Edm.Int64"),  _
         tab("Status"),  _
         Pos(22),  _
         [ReadOnly](true),  _
         twodBarcode("CUSTNOTE")>  _
        Public Property CUSTNOTE() As nullable (of int64)
            Get
                return _CUSTNOTE
            End Get
            Set
                if not(value is nothing) then
                  _CUSTNOTE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Customer Number"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(25),  _
         twodBarcode("CUSTNAME")>  _
        Public Property CUSTNAME() As String
            Get
                return _CUSTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Customer Number", value, "^.{0,16}$") then Exit Property
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
        
        <DisplayName("Customer Name"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("CUSTDES")>  _
        Public Property CUSTDES() As String
            Get
                return _CUSTDES
            End Get
            Set
                if not(value is nothing) then
                  _CUSTDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Customer Site"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(31),  _
         twodBarcode("DCODE")>  _
        Public Property DCODE() As String
            Get
                return _DCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Customer Site", value, "^.{0,4}$") then Exit Property
                _IsSetDCODE = True
                If loading Then
                  _DCODE = Value
                Else
                    if not _DCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("DCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _DCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Site Description"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(32),  _
         [ReadOnly](true),  _
         twodBarcode("CODEDES")>  _
        Public Property CODEDES() As String
            Get
                return _CODEDES
            End Get
            Set
                if not(value is nothing) then
                  _CODEDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Priority"),  _
         nType("Edm.Int64"),  _
         tab("Priority"),  _
         Pos(33),  _
         twodBarcode("PRIO")>  _
        Public Property PRIO() As nullable (of int64)
            Get
                return _PRIO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Priority", value, "^[0-9\-]+$") then Exit Property
                _IsSetPRIO = True
                If loading Then
                  _PRIO = Value
                Else
                    if not _PRIO = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PRIO", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PRIO = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Contact"),  _
         nType("Edm.String"),  _
         tab("Priority"),  _
         Pos(34),  _
         twodBarcode("NAME")>  _
        Public Property NAME() As String
            Get
                return _NAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Contact", value, "^.{0,37}$") then Exit Property
                _IsSetNAME = True
                If loading Then
                  _NAME = Value
                Else
                    if not _NAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("NAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _NAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Phone Number"),  _
         nType("Edm.String"),  _
         tab("Priority"),  _
         Pos(36),  _
         [ReadOnly](true),  _
         twodBarcode("PHONENUM")>  _
        Public Property PHONENUM() As String
            Get
                return _PHONENUM
            End Get
            Set
                if not(value is nothing) then
                  _PHONENUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("Cell Phone"),  _
         nType("Edm.String"),  _
         tab("Priority"),  _
         Pos(37),  _
         [ReadOnly](true),  _
         twodBarcode("CELLPHONE")>  _
        Public Property CELLPHONE() As String
            Get
                return _CELLPHONE
            End Get
            Set
                if not(value is nothing) then
                  _CELLPHONE = Value
                end if
            End Set
        End Property
        
        <DisplayName("E-mail Address"),  _
         nType("Edm.String"),  _
         tab("Priority"),  _
         Pos(38),  _
         [ReadOnly](true),  _
         twodBarcode("EMAIL")>  _
        Public Property EMAIL() As String
            Get
                return _EMAIL
            End Get
            Set
                if not(value is nothing) then
                  _EMAIL = Value
                end if
            End Set
        End Property
        
        <DisplayName("Vendor Contact"),  _
         nType("Edm.String"),  _
         tab("Priority"),  _
         Pos(38),  _
         twodBarcode("SNAME")>  _
        Public Property SNAME() As String
            Get
                return _SNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Vendor Contact", value, "^.{0,37}$") then Exit Property
                _IsSetSNAME = True
                If loading Then
                  _SNAME = Value
                Else
                    if not _SNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Vendor Contact Phone"),  _
         nType("Edm.String"),  _
         tab("Priority"),  _
         Pos(39),  _
         [ReadOnly](true),  _
         twodBarcode("SPHONENUM")>  _
        Public Property SPHONENUM() As String
            Get
                return _SPHONENUM
            End Get
            Set
                if not(value is nothing) then
                  _SPHONENUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("Vendor Contact Cell"),  _
         nType("Edm.String"),  _
         tab("Priority"),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("SCELLPHONE")>  _
        Public Property SCELLPHONE() As String
            Get
                return _SCELLPHONE
            End Get
            Set
                if not(value is nothing) then
                  _SCELLPHONE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Vendor Contact Email"),  _
         nType("Edm.String"),  _
         tab("Vendor Contact Email"),  _
         Pos(41),  _
         [ReadOnly](true),  _
         twodBarcode("EMAIL2")>  _
        Public Property EMAIL2() As String
            Get
                return _EMAIL2
            End Get
            Set
                if not(value is nothing) then
                  _EMAIL2 = Value
                end if
            End Set
        End Property
        
        <DisplayName("Task Code"),  _
         nType("Edm.String"),  _
         tab("Vendor Contact Email"),  _
         Pos(41),  _
         twodBarcode("TOPICCODE")>  _
        Public Property TOPICCODE() As String
            Get
                return _TOPICCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Task Code", value, "^.{0,3}$") then Exit Property
                _IsSetTOPICCODE = True
                If loading Then
                  _TOPICCODE = Value
                Else
                    if not _TOPICCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TOPICCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TOPICCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Task Description"),  _
         nType("Edm.String"),  _
         tab("Vendor Contact Email"),  _
         Pos(42),  _
         [ReadOnly](true),  _
         twodBarcode("TOPICDES")>  _
        Public Property TOPICDES() As String
            Get
                return _TOPICDES
            End Get
            Set
                if not(value is nothing) then
                  _TOPICDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Task Type"),  _
         nType("Edm.String"),  _
         tab("Vendor Contact Email"),  _
         Pos(45),  _
         twodBarcode("CUSTNOTETYPEDES")>  _
        Public Property CUSTNOTETYPEDES() As String
            Get
                return _CUSTNOTETYPEDES
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Task Type", value, "^.{0,8}$") then Exit Property
                _IsSetCUSTNOTETYPEDES = True
                If loading Then
                  _CUSTNOTETYPEDES = Value
                Else
                    if not _CUSTNOTETYPEDES = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CUSTNOTETYPEDES", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CUSTNOTETYPEDES = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Remind?"),  _
         nType("Edm.String"),  _
         tab("Vendor Contact Email"),  _
         Pos(48),  _
         twodBarcode("REMINDFLAG")>  _
        Public Property REMINDFLAG() As String
            Get
                return _REMINDFLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Remind?", value, "^.{0,1}$") then Exit Property
                _IsSetREMINDFLAG = True
                If loading Then
                  _REMINDFLAG = Value
                Else
                    if not _REMINDFLAG = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("REMINDFLAG", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _REMINDFLAG = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Hrs/Mins in Advance"),  _
         nType("Edm.String"),  _
         tab("Vendor Contact Email"),  _
         Pos(49),  _
         twodBarcode("REMINDTIME")>  _
        Public Property REMINDTIME() As String
            Get
                return _REMINDTIME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Hrs/Mins in Advance", value, "^.{0,6}$") then Exit Property
                _IsSetREMINDTIME = True
                If loading Then
                  _REMINDTIME = Value
                Else
                    if not _REMINDTIME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("REMINDTIME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _REMINDTIME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Participant 2"),  _
         nType("Edm.String"),  _
         tab("Vendor Contact Email"),  _
         Pos(50),  _
         twodBarcode("USERLOGIN2")>  _
        Public Property USERLOGIN2() As String
            Get
                return _USERLOGIN2
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Participant 2", value, "^.{0,20}$") then Exit Property
                _IsSetUSERLOGIN2 = True
                If loading Then
                  _USERLOGIN2 = Value
                Else
                    if not _USERLOGIN2 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("USERLOGIN2", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _USERLOGIN2 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Participant 3"),  _
         nType("Edm.String"),  _
         tab("Vendor Contact Email"),  _
         Pos(51),  _
         twodBarcode("USERLOGIN3")>  _
        Public Property USERLOGIN3() As String
            Get
                return _USERLOGIN3
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Participant 3", value, "^.{0,20}$") then Exit Property
                _IsSetUSERLOGIN3 = True
                If loading Then
                  _USERLOGIN3 = Value
                Else
                    if not _USERLOGIN3 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("USERLOGIN3", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _USERLOGIN3 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Group Code"),  _
         nType("Edm.String"),  _
         tab("Group Code"),  _
         Pos(210),  _
         twodBarcode("GROUPNAME")>  _
        Public Property GROUPNAME() As String
            Get
                return _GROUPNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Group Code", value, "^.{0,10}$") then Exit Property
                _IsSetGROUPNAME = True
                If loading Then
                  _GROUPNAME = Value
                Else
                    if not _GROUPNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("GROUPNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _GROUPNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Group 2"),  _
         nType("Edm.String"),  _
         tab("Group Code"),  _
         Pos(212),  _
         twodBarcode("GROUPNAME2")>  _
        Public Property GROUPNAME2() As String
            Get
                return _GROUPNAME2
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Group 2", value, "^.{0,10}$") then Exit Property
                _IsSetGROUPNAME2 = True
                If loading Then
                  _GROUPNAME2 = Value
                Else
                    if not _GROUPNAME2 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("GROUPNAME2", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _GROUPNAME2 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Group 3"),  _
         nType("Edm.String"),  _
         tab("Group Code"),  _
         Pos(214),  _
         twodBarcode("GROUPNAME3")>  _
        Public Property GROUPNAME3() As String
            Get
                return _GROUPNAME3
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Group 3", value, "^.{0,10}$") then Exit Property
                _IsSetGROUPNAME3 = True
                If loading Then
                  _GROUPNAME3 = Value
                Else
                    if not _GROUPNAME3 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("GROUPNAME3", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _GROUPNAME3 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Resource"),  _
         nType("Edm.String"),  _
         tab("Group Code"),  _
         Pos(220),  _
         twodBarcode("RESOURCENAME")>  _
        Public Property RESOURCENAME() As String
            Get
                return _RESOURCENAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Resource", value, "^.{0,16}$") then Exit Property
                _IsSetRESOURCENAME = True
                If loading Then
                  _RESOURCENAME = Value
                Else
                    if not _RESOURCENAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("RESOURCENAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _RESOURCENAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Second Resource"),  _
         nType("Edm.String"),  _
         tab("Group Code"),  _
         Pos(221),  _
         twodBarcode("RESOURCENAME2")>  _
        Public Property RESOURCENAME2() As String
            Get
                return _RESOURCENAME2
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Second Resource", value, "^.{0,16}$") then Exit Property
                _IsSetRESOURCENAME2 = True
                If loading Then
                  _RESOURCENAME2 = Value
                Else
                    if not _RESOURCENAME2 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("RESOURCENAME2", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _RESOURCENAME2 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Third Resource"),  _
         nType("Edm.String"),  _
         tab("Group Code"),  _
         Pos(222),  _
         twodBarcode("RESOURCENAME3")>  _
        Public Property RESOURCENAME3() As String
            Get
                return _RESOURCENAME3
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Third Resource", value, "^.{0,16}$") then Exit Property
                _IsSetRESOURCENAME3 = True
                If loading Then
                  _RESOURCENAME3 = Value
                Else
                    if not _RESOURCENAME3 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("RESOURCENAME3", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _RESOURCENAME3 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Remark"),  _
         nType("Edm.String"),  _
         tab("Group Code"),  _
         Pos(225),  _
         twodBarcode("REMARK")>  _
        Public Property REMARK() As String
            Get
                return _REMARK
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Remark", value, "^.{0,32}$") then Exit Property
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
        
        <DisplayName("Original Task"),  _
         nType("Edm.Int64"),  _
         tab("Group Code"),  _
         Pos(230),  _
         twodBarcode("PREVCUSTNOTEA")>  _
        Public Property PREVCUSTNOTEA() As nullable (of int64)
            Get
                return _PREVCUSTNOTEA
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Original Task", value, "^[0-9\-]+$") then Exit Property
                _IsSetPREVCUSTNOTEA = True
                If loading Then
                  _PREVCUSTNOTEA = Value
                Else
                    if not _PREVCUSTNOTEA = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PREVCUSTNOTEA", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PREVCUSTNOTEA = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Format Code"),  _
         nType("Edm.String"),  _
         tab("Format Code"),  _
         Pos(250),  _
         twodBarcode("QUESTFCODE")>  _
        Public Property QUESTFCODE() As String
            Get
                return _QUESTFCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Format Code", value, "^.{0,3}$") then Exit Property
                _IsSetQUESTFCODE = True
                If loading Then
                  _QUESTFCODE = Value
                Else
                    if not _QUESTFCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("QUESTFCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _QUESTFCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Questionnaire Title"),  _
         nType("Edm.String"),  _
         tab("Format Code"),  _
         Pos(260),  _
         [ReadOnly](true),  _
         twodBarcode("QUESTFDES")>  _
        Public Property QUESTFDES() As String
            Get
                return _QUESTFDES
            End Get
            Set
                if not(value is nothing) then
                  _QUESTFDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Branch Code"),  _
         nType("Edm.String"),  _
         tab("Format Code"),  _
         Pos(265),  _
         twodBarcode("BRANCHNAME")>  _
        Public Property BRANCHNAME() As String
            Get
                return _BRANCHNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Branch Code", value, "^.{0,6}$") then Exit Property
                _IsSetBRANCHNAME = True
                If loading Then
                  _BRANCHNAME = Value
                Else
                    if not _BRANCHNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("BRANCHNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _BRANCHNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Branch Name"),  _
         nType("Edm.String"),  _
         tab("Format Code"),  _
         Pos(270),  _
         [ReadOnly](true),  _
         twodBarcode("BRANCHDES")>  _
        Public Property BRANCHDES() As String
            Get
                return _BRANCHDES
            End Get
            Set
                if not(value is nothing) then
                  _BRANCHDES = Value
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property CUSTNOTESTEXT_SUBFORM() As QUERY_CUSTNOTESTEXT
            Get
                return _CUSTNOTESTEXT_SUBFORM
            End Get
            Set
                _CUSTNOTESTEXT_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property CUSTNQUESTLINES_SUBFORM() As QUERY_CUSTNQUESTLINES
            Get
                return _CUSTNQUESTLINES_SUBFORM
            End Get
            Set
                _CUSTNQUESTLINES_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property CUSTNQUESTTEXT_SUBFORM() As QUERY_CUSTNQUESTTEXT
            Get
                return _CUSTNQUESTTEXT_SUBFORM
            End Get
            Set
                _CUSTNQUESTTEXT_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property CUSTNOTEEXTFILE_SUBFORM() As QUERY_CUSTNOTEEXTFILE
            Get
                return _CUSTNOTEEXTFILE_SUBFORM
            End Get
            Set
                _CUSTNOTEEXTFILE_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property SUPNOTEEXTFILE_SUBFORM() As QUERY_SUPNOTEEXTFILE
            Get
                return _SUPNOTEEXTFILE_SUBFORM
            End Get
            Set
                _SUPNOTEEXTFILE_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property DOCTODOLIST_SUBFORM() As QUERY_DOCTODOLIST
            Get
                return _DOCTODOLIST_SUBFORM
            End Get
            Set
                _DOCTODOLIST_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property DOCTODOLISTLOG_SUBFORM() As QUERY_DOCTODOLISTLOG
            Get
                return _DOCTODOLISTLOG_SUBFORM
            End Get
            Set
                _DOCTODOLISTLOG_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property CUSTNOTESIGN_SUBFORM() As QUERY_CUSTNOTESIGN
            Get
                return _CUSTNOTESIGN_SUBFORM
            End Get
            Set
                _CUSTNOTESIGN_SUBFORM = value
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
            if _IsSetUSERLOGIN then
              if f then
                  jw.WriteRaw(", ""USERLOGIN"": ")
              else
                  jw.WriteRaw("""USERLOGIN"": ")
                  f = true
              end if
              jw.WriteValue(me.USERLOGIN)
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
            if _IsSetTILLDATE then
              if f then
                  jw.WriteRaw(", ""TILLDATE"": ")
              else
                  jw.WriteRaw("""TILLDATE"": ")
                  f = true
              end if
              jw.WriteValue(me.TILLDATE)
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
            if _IsSetPLANNEDTIME then
              if f then
                  jw.WriteRaw(", ""PLANNEDTIME"": ")
              else
                  jw.WriteRaw("""PLANNEDTIME"": ")
                  f = true
              end if
              jw.WriteValue(me.PLANNEDTIME)
            end if
            if _IsSetSTATDES then
              if f then
                  jw.WriteRaw(", ""STATDES"": ")
              else
                  jw.WriteRaw("""STATDES"": ")
                  f = true
              end if
              jw.WriteValue(me.STATDES)
            end if
            if _IsSetCLOSED then
              if f then
                  jw.WriteRaw(", ""CLOSED"": ")
              else
                  jw.WriteRaw("""CLOSED"": ")
                  f = true
              end if
              jw.WriteValue(me.CLOSED)
            end if
            if _IsSetSUBJECT then
              if f then
                  jw.WriteRaw(", ""SUBJECT"": ")
              else
                  jw.WriteRaw("""SUBJECT"": ")
                  f = true
              end if
              jw.WriteValue(me.SUBJECT)
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
            if _IsSetDCODE then
              if f then
                  jw.WriteRaw(", ""DCODE"": ")
              else
                  jw.WriteRaw("""DCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.DCODE)
            end if
            if _IsSetPRIO then
              if f then
                  jw.WriteRaw(", ""PRIO"": ")
              else
                  jw.WriteRaw("""PRIO"": ")
                  f = true
              end if
              jw.WriteValue(me.PRIO)
            end if
            if _IsSetNAME then
              if f then
                  jw.WriteRaw(", ""NAME"": ")
              else
                  jw.WriteRaw("""NAME"": ")
                  f = true
              end if
              jw.WriteValue(me.NAME)
            end if
            if _IsSetSNAME then
              if f then
                  jw.WriteRaw(", ""SNAME"": ")
              else
                  jw.WriteRaw("""SNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SNAME)
            end if
            if _IsSetTOPICCODE then
              if f then
                  jw.WriteRaw(", ""TOPICCODE"": ")
              else
                  jw.WriteRaw("""TOPICCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.TOPICCODE)
            end if
            if _IsSetCUSTNOTETYPEDES then
              if f then
                  jw.WriteRaw(", ""CUSTNOTETYPEDES"": ")
              else
                  jw.WriteRaw("""CUSTNOTETYPEDES"": ")
                  f = true
              end if
              jw.WriteValue(me.CUSTNOTETYPEDES)
            end if
            if _IsSetREMINDFLAG then
              if f then
                  jw.WriteRaw(", ""REMINDFLAG"": ")
              else
                  jw.WriteRaw("""REMINDFLAG"": ")
                  f = true
              end if
              jw.WriteValue(me.REMINDFLAG)
            end if
            if _IsSetREMINDTIME then
              if f then
                  jw.WriteRaw(", ""REMINDTIME"": ")
              else
                  jw.WriteRaw("""REMINDTIME"": ")
                  f = true
              end if
              jw.WriteValue(me.REMINDTIME)
            end if
            if _IsSetUSERLOGIN2 then
              if f then
                  jw.WriteRaw(", ""USERLOGIN2"": ")
              else
                  jw.WriteRaw("""USERLOGIN2"": ")
                  f = true
              end if
              jw.WriteValue(me.USERLOGIN2)
            end if
            if _IsSetUSERLOGIN3 then
              if f then
                  jw.WriteRaw(", ""USERLOGIN3"": ")
              else
                  jw.WriteRaw("""USERLOGIN3"": ")
                  f = true
              end if
              jw.WriteValue(me.USERLOGIN3)
            end if
            if _IsSetGROUPNAME then
              if f then
                  jw.WriteRaw(", ""GROUPNAME"": ")
              else
                  jw.WriteRaw("""GROUPNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.GROUPNAME)
            end if
            if _IsSetGROUPNAME2 then
              if f then
                  jw.WriteRaw(", ""GROUPNAME2"": ")
              else
                  jw.WriteRaw("""GROUPNAME2"": ")
                  f = true
              end if
              jw.WriteValue(me.GROUPNAME2)
            end if
            if _IsSetGROUPNAME3 then
              if f then
                  jw.WriteRaw(", ""GROUPNAME3"": ")
              else
                  jw.WriteRaw("""GROUPNAME3"": ")
                  f = true
              end if
              jw.WriteValue(me.GROUPNAME3)
            end if
            if _IsSetRESOURCENAME then
              if f then
                  jw.WriteRaw(", ""RESOURCENAME"": ")
              else
                  jw.WriteRaw("""RESOURCENAME"": ")
                  f = true
              end if
              jw.WriteValue(me.RESOURCENAME)
            end if
            if _IsSetRESOURCENAME2 then
              if f then
                  jw.WriteRaw(", ""RESOURCENAME2"": ")
              else
                  jw.WriteRaw("""RESOURCENAME2"": ")
                  f = true
              end if
              jw.WriteValue(me.RESOURCENAME2)
            end if
            if _IsSetRESOURCENAME3 then
              if f then
                  jw.WriteRaw(", ""RESOURCENAME3"": ")
              else
                  jw.WriteRaw("""RESOURCENAME3"": ")
                  f = true
              end if
              jw.WriteValue(me.RESOURCENAME3)
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
            if _IsSetPREVCUSTNOTEA then
              if f then
                  jw.WriteRaw(", ""PREVCUSTNOTEA"": ")
              else
                  jw.WriteRaw("""PREVCUSTNOTEA"": ")
                  f = true
              end if
              jw.WriteValue(me.PREVCUSTNOTEA)
            end if
            if _IsSetQUESTFCODE then
              if f then
                  jw.WriteRaw(", ""QUESTFCODE"": ")
              else
                  jw.WriteRaw("""QUESTFCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.QUESTFCODE)
            end if
            if _IsSetBRANCHNAME then
              if f then
                  jw.WriteRaw(", ""BRANCHNAME"": ")
              else
                  jw.WriteRaw("""BRANCHNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.BRANCHNAME)
            end if
            if _CUSTNOTESTEXT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", CUSTNOTESTEXT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as CUSTNOTESTEXT in _CUSTNOTESTEXT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _CUSTNOTESTEXT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _CUSTNQUESTLINES_SUBFORM.value.count > 0 then
              jw.WriteRaw(", CUSTNQUESTLINES_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as CUSTNQUESTLINES in _CUSTNQUESTLINES_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _CUSTNQUESTLINES_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _CUSTNQUESTTEXT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", CUSTNQUESTTEXT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as CUSTNQUESTTEXT in _CUSTNQUESTTEXT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _CUSTNQUESTTEXT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _CUSTNOTEEXTFILE_SUBFORM.value.count > 0 then
              jw.WriteRaw(", CUSTNOTEEXTFILE_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as CUSTNOTEEXTFILE in _CUSTNOTEEXTFILE_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _CUSTNOTEEXTFILE_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _SUPNOTEEXTFILE_SUBFORM.value.count > 0 then
              jw.WriteRaw(", SUPNOTEEXTFILE_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as SUPNOTEEXTFILE in _SUPNOTEEXTFILE_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _SUPNOTEEXTFILE_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _DOCTODOLIST_SUBFORM.value.count > 0 then
              jw.WriteRaw(", DOCTODOLIST_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as DOCTODOLIST in _DOCTODOLIST_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _DOCTODOLIST_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _DOCTODOLISTLOG_SUBFORM.value.count > 0 then
              jw.WriteRaw(", DOCTODOLISTLOG_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as DOCTODOLISTLOG in _DOCTODOLISTLOG_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _DOCTODOLISTLOG_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _CUSTNOTESIGN_SUBFORM.value.count > 0 then
              jw.WriteRaw(", CUSTNOTESIGN_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as CUSTNOTESIGN in _CUSTNOTESIGN_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _CUSTNOTESIGN_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "GENCUSTNOTES")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "CUSTNOTE")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetCURDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CURDATE")
              .WriteAttributeString("value", me.CURDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetUSERLOGIN then
              .WriteStartElement("field")
              .WriteAttributeString("name", "USERLOGIN")
              .WriteAttributeString("value", me.USERLOGIN)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
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
            if _IsSetTILLDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TILLDATE")
              .WriteAttributeString("value", me.TILLDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
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
            if _IsSetPLANNEDTIME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PLANNEDTIME")
              .WriteAttributeString("value", me.PLANNEDTIME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "6")
              .WriteEndElement
            end if
            if _IsSetSTATDES then
              .WriteStartElement("field")
              .WriteAttributeString("name", "STATDES")
              .WriteAttributeString("value", me.STATDES)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "12")
              .WriteEndElement
            end if
            if _IsSetCLOSED then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CLOSED")
              .WriteAttributeString("value", me.CLOSED)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetSUBJECT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SUBJECT")
              .WriteAttributeString("value", me.SUBJECT)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "52")
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
            if _IsSetDCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DCODE")
              .WriteAttributeString("value", me.DCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "4")
              .WriteEndElement
            end if
            if _IsSetPRIO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PRIO")
              .WriteAttributeString("value", me.PRIO)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "NAME")
              .WriteAttributeString("value", me.NAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "37")
              .WriteEndElement
            end if
            if _IsSetSNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SNAME")
              .WriteAttributeString("value", me.SNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "37")
              .WriteEndElement
            end if
            if _IsSetTOPICCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TOPICCODE")
              .WriteAttributeString("value", me.TOPICCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
            end if
            if _IsSetCUSTNOTETYPEDES then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CUSTNOTETYPEDES")
              .WriteAttributeString("value", me.CUSTNOTETYPEDES)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "8")
              .WriteEndElement
            end if
            if _IsSetREMINDFLAG then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REMINDFLAG")
              .WriteAttributeString("value", me.REMINDFLAG)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetREMINDTIME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REMINDTIME")
              .WriteAttributeString("value", me.REMINDTIME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "6")
              .WriteEndElement
            end if
            if _IsSetUSERLOGIN2 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "USERLOGIN2")
              .WriteAttributeString("value", me.USERLOGIN2)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
              .WriteEndElement
            end if
            if _IsSetUSERLOGIN3 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "USERLOGIN3")
              .WriteAttributeString("value", me.USERLOGIN3)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
              .WriteEndElement
            end if
            if _IsSetGROUPNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "GROUPNAME")
              .WriteAttributeString("value", me.GROUPNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "10")
              .WriteEndElement
            end if
            if _IsSetGROUPNAME2 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "GROUPNAME2")
              .WriteAttributeString("value", me.GROUPNAME2)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "10")
              .WriteEndElement
            end if
            if _IsSetGROUPNAME3 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "GROUPNAME3")
              .WriteAttributeString("value", me.GROUPNAME3)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "10")
              .WriteEndElement
            end if
            if _IsSetRESOURCENAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "RESOURCENAME")
              .WriteAttributeString("value", me.RESOURCENAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetRESOURCENAME2 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "RESOURCENAME2")
              .WriteAttributeString("value", me.RESOURCENAME2)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetRESOURCENAME3 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "RESOURCENAME3")
              .WriteAttributeString("value", me.RESOURCENAME3)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetREMARK then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REMARK")
              .WriteAttributeString("value", me.REMARK)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "32")
              .WriteEndElement
            end if
            if _IsSetPREVCUSTNOTEA then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PREVCUSTNOTEA")
              .WriteAttributeString("value", me.PREVCUSTNOTEA)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetQUESTFCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "QUESTFCODE")
              .WriteAttributeString("value", me.QUESTFCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
            end if
            if _IsSetBRANCHNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "BRANCHNAME")
              .WriteAttributeString("value", me.BRANCHNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "6")
              .WriteEndElement
            end if
            if _CUSTNOTESTEXT_SUBFORM.value.count > 0 then
              for each itm as CUSTNOTESTEXT in _CUSTNOTESTEXT_SUBFORM.Value
                itm.toXML(xw,"CUSTNOTESTEXT_SUBFORM")
              next
            end if
            if _CUSTNQUESTLINES_SUBFORM.value.count > 0 then
              for each itm as CUSTNQUESTLINES in _CUSTNQUESTLINES_SUBFORM.Value
                itm.toXML(xw,"CUSTNQUESTLINES_SUBFORM")
              next
            end if
            if _CUSTNQUESTTEXT_SUBFORM.value.count > 0 then
              for each itm as CUSTNQUESTTEXT in _CUSTNQUESTTEXT_SUBFORM.Value
                itm.toXML(xw,"CUSTNQUESTTEXT_SUBFORM")
              next
            end if
            if _CUSTNOTEEXTFILE_SUBFORM.value.count > 0 then
              for each itm as CUSTNOTEEXTFILE in _CUSTNOTEEXTFILE_SUBFORM.Value
                itm.toXML(xw,"CUSTNOTEEXTFILE_SUBFORM")
              next
            end if
            if _SUPNOTEEXTFILE_SUBFORM.value.count > 0 then
              for each itm as SUPNOTEEXTFILE in _SUPNOTEEXTFILE_SUBFORM.Value
                itm.toXML(xw,"SUPNOTEEXTFILE_SUBFORM")
              next
            end if
            if _DOCTODOLIST_SUBFORM.value.count > 0 then
              for each itm as DOCTODOLIST in _DOCTODOLIST_SUBFORM.Value
                itm.toXML(xw,"DOCTODOLIST_SUBFORM")
              next
            end if
            if _DOCTODOLISTLOG_SUBFORM.value.count > 0 then
              for each itm as DOCTODOLISTLOG in _DOCTODOLISTLOG_SUBFORM.Value
                itm.toXML(xw,"DOCTODOLISTLOG_SUBFORM")
              next
            end if
            if _CUSTNOTESIGN_SUBFORM.value.count > 0 then
              for each itm as CUSTNOTESIGN in _CUSTNOTESIGN_SUBFORM.Value
                itm.toXML(xw,"CUSTNOTESIGN_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as GENCUSTNOTES = JsonConvert.DeserializeObject(Of GENCUSTNOTES)(e.StreamReader.ReadToEnd)
                With obj
                  _CURDATE = .CURDATE
                  _USERLOGIN = .USERLOGIN
                  _DAY = .DAY
                  _STIME = .STIME
                  _TILLDATE = .TILLDATE
                  _TILLDAY = .TILLDAY
                  _ETIME = .ETIME
                  _PLANNEDTIME = .PLANNEDTIME
                  _STATDES = .STATDES
                  _CLOSED = .CLOSED
                  _SUBJECT = .SUBJECT
                  _CUSTNOTE = .CUSTNOTE
                  _CUSTNAME = .CUSTNAME
                  _CUSTDES = .CUSTDES
                  _DCODE = .DCODE
                  _CODEDES = .CODEDES
                  _PRIO = .PRIO
                  _NAME = .NAME
                  _PHONENUM = .PHONENUM
                  _CELLPHONE = .CELLPHONE
                  _EMAIL = .EMAIL
                  _SNAME = .SNAME
                  _SPHONENUM = .SPHONENUM
                  _SCELLPHONE = .SCELLPHONE
                  _EMAIL2 = .EMAIL2
                  _TOPICCODE = .TOPICCODE
                  _TOPICDES = .TOPICDES
                  _CUSTNOTETYPEDES = .CUSTNOTETYPEDES
                  _REMINDFLAG = .REMINDFLAG
                  _REMINDTIME = .REMINDTIME
                  _USERLOGIN2 = .USERLOGIN2
                  _USERLOGIN3 = .USERLOGIN3
                  _GROUPNAME = .GROUPNAME
                  _GROUPNAME2 = .GROUPNAME2
                  _GROUPNAME3 = .GROUPNAME3
                  _RESOURCENAME = .RESOURCENAME
                  _RESOURCENAME2 = .RESOURCENAME2
                  _RESOURCENAME3 = .RESOURCENAME3
                  _REMARK = .REMARK
                  _PREVCUSTNOTEA = .PREVCUSTNOTEA
                  _QUESTFCODE = .QUESTFCODE
                  _QUESTFDES = .QUESTFDES
                  _BRANCHNAME = .BRANCHNAME
                  _BRANCHDES = .BRANCHDES
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_GENCUSTNOTES
        
        CUSTNOTESTEXT = 0
        
        CUSTNQUESTLINES = 1
        
        CUSTNQUESTTEXT = 2
        
        CUSTNOTEEXTFILE = 3
        
        SUPNOTEEXTFILE = 4
        
        DOCTODOLIST = 5
        
        DOCTODOLISTLOG = 6
        
        CUSTNOTESIGN = 7
    End Enum
    
    <QueryTitle("Notes")>  _
    Public Class QUERY_CUSTNOTESTEXT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of CUSTNOTESTEXT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of CUSTNOTESTEXT)
            _Parent = nothing
            _Name = "CUSTNOTESTEXT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of CUSTNOTESTEXT)
            _Parent = Parent
            _name = "CUSTNOTESTEXT_SUBFORM"
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
        
        Public Property Value() As list(of CUSTNOTESTEXT)
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
                return GetType(CUSTNOTESTEXT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _CUSTNOTESTEXT As CUSTNOTESTEXT In JsonConvert.DeserializeObject(Of QUERY_CUSTNOTESTEXT)(stream.ReadToEnd).Value
              With _CUSTNOTESTEXT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_CUSTNOTESTEXT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as CUSTNOTESTEXT = JsonConvert.DeserializeObject(Of CUSTNOTESTEXT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, CUSTNOTESTEXT)
                  .TEXT = obj.TEXT
                  .TEXTLINE = obj.TEXTLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new CUSTNOTESTEXT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _CUSTNOTESTEXT as CUSTNOTESTEXT in value
              If _CUSTNOTESTEXT.Equals(trycast(obj,CUSTNOTESTEXT)) Then
                  value.remove(_CUSTNOTESTEXT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class CUSTNOTESTEXT
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
                    return "CUSTNOTESTEXT"
                else
                    return "CUSTNOTESTEXT_SUBFORM"
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
        
        <DisplayName("Text"),  _
         nType("Edm.String"),  _
         tab("Text"),  _
         Pos(20),  _
         twodBarcode("TEXT")>  _
        Public Property TEXT() As String
            Get
                return _TEXT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Text", value, "^.{0,68}$") then Exit Property
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
        
        <DisplayName("Line"),  _
         nType("Edm.Int64"),  _
         tab("Text"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("TEXTLINE")>  _
        Public Property TEXTLINE() As nullable (of int64)
            Get
                return _TEXTLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Line", value, "^[0-9\-]+$") then Exit Property
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
                .WriteAttributeString("name", "CUSTNOTESTEXT")
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
                dim obj as CUSTNOTESTEXT = JsonConvert.DeserializeObject(Of CUSTNOTESTEXT)(e.StreamReader.ReadToEnd)
                With obj
                  _TEXT = .TEXT
                  _TEXTLINE = .TEXTLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Responses to Questions")>  _
    Public Class QUERY_CUSTNQUESTLINES
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of CUSTNQUESTLINES)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of CUSTNQUESTLINES)
            _Parent = nothing
            _Name = "CUSTNQUESTLINES"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Response (cont.)")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of CUSTNQUESTLINES)
            _Parent = Parent
            _name = "CUSTNQUESTLINES_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Response (cont.)")
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
        
        Public Property Value() As list(of CUSTNQUESTLINES)
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
                return GetType(CUSTNQUESTLINES)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _CUSTNQUESTLINES As CUSTNQUESTLINES In JsonConvert.DeserializeObject(Of QUERY_CUSTNQUESTLINES)(stream.ReadToEnd).Value
              With _CUSTNQUESTLINES
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_CUSTNQUESTLINES)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as CUSTNQUESTLINES = JsonConvert.DeserializeObject(Of CUSTNQUESTLINES)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, CUSTNQUESTLINES)
                  .QUESTNUM = obj.QUESTNUM
                  .QUESTDES = obj.QUESTDES
                  .QGROUPDES = obj.QGROUPDES
                  .ANSNUM = obj.ANSNUM
                  .QUESTFADES = obj.QUESTFADES
                  .REMARK = obj.REMARK
                  .ATYPE = obj.ATYPE
                  .MANDATORY = obj.MANDATORY
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new CUSTNQUESTLINES(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _CUSTNQUESTLINES as CUSTNQUESTLINES in value
              If _CUSTNQUESTLINES.Equals(trycast(obj,CUSTNQUESTLINES)) Then
                  value.remove(_CUSTNQUESTLINES)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class CUSTNQUESTLINES
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _QUESTNUM As Long
        
        Private _QUESTDES As String
        
        Private _QGROUPDES As String
        
        Private _IsSetANSNUM As Boolean = Boolean.FalseString
        
        Private _ANSNUM As Long
        
        Private _QUESTFADES As String
        
        Private _IsSetREMARK As Boolean = Boolean.FalseString
        
        Private _REMARK As String
        
        Private _ATYPE As String
        
        Private _MANDATORY As String
        
        Private _QUESTLINESTEXT_SUBFORM As QUERY_QUESTLINESTEXT
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Response (cont.)"))
            _QUESTLINESTEXT_SUBFORM = new QUERY_QUESTLINESTEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_QUESTLINESTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Response (cont.)", _QUESTLINESTEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Response (cont.)"))
            _QUESTLINESTEXT_SUBFORM = new QUERY_QUESTLINESTEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_QUESTLINESTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Response (cont.)", _QUESTLINESTEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "CUSTNQUESTLINES"
                else
                    return "CUSTNQUESTLINES_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "QUESTNUM={0}", _
                  string.format("{0}",QUESTNUM) _ 
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
        
        <DisplayName("No. (Question)"),  _
         nType("Edm.Int64"),  _
         tab("No. (Question)"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("QUESTNUM")>  _
        Public Property QUESTNUM() As nullable (of int64)
            Get
                return _QUESTNUM
            End Get
            Set
                if not(value is nothing) then
                  _QUESTNUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("Question"),  _
         nType("Edm.String"),  _
         tab("No. (Question)"),  _
         Pos(22),  _
         [ReadOnly](true),  _
         twodBarcode("QUESTDES")>  _
        Public Property QUESTDES() As String
            Get
                return _QUESTDES
            End Get
            Set
                if not(value is nothing) then
                  _QUESTDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Category"),  _
         nType("Edm.String"),  _
         tab("No. (Question)"),  _
         Pos(25),  _
         [ReadOnly](true),  _
         twodBarcode("QGROUPDES")>  _
        Public Property QGROUPDES() As String
            Get
                return _QGROUPDES
            End Get
            Set
                if not(value is nothing) then
                  _QGROUPDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("No. Response"),  _
         nType("Edm.Int64"),  _
         tab("No. (Question)"),  _
         Pos(30),  _
         twodBarcode("ANSNUM")>  _
        Public Property ANSNUM() As nullable (of int64)
            Get
                return _ANSNUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("No. Response", value, "^[0-9\-]+$") then Exit Property
                _IsSetANSNUM = True
                If loading Then
                  _ANSNUM = Value
                Else
                    if not _ANSNUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ANSNUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ANSNUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Response"),  _
         nType("Edm.String"),  _
         tab("No. (Question)"),  _
         Pos(32),  _
         [ReadOnly](true),  _
         twodBarcode("QUESTFADES")>  _
        Public Property QUESTFADES() As String
            Get
                return _QUESTFADES
            End Get
            Set
                if not(value is nothing) then
                  _QUESTFADES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Remark"),  _
         nType("Edm.String"),  _
         tab("No. (Question)"),  _
         Pos(45),  _
         twodBarcode("REMARK")>  _
        Public Property REMARK() As String
            Get
                return _REMARK
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Remark", value, "^.{0,48}$") then Exit Property
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
        
        <DisplayName("Response Type"),  _
         nType("Edm.String"),  _
         tab("No. (Question)"),  _
         Pos(50),  _
         [ReadOnly](true),  _
         twodBarcode("ATYPE")>  _
        Public Property ATYPE() As String
            Get
                return _ATYPE
            End Get
            Set
                if not(value is nothing) then
                  _ATYPE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Mandatory Question?"),  _
         nType("Edm.String"),  _
         tab("No. (Question)"),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("MANDATORY")>  _
        Public Property MANDATORY() As String
            Get
                return _MANDATORY
            End Get
            Set
                if not(value is nothing) then
                  _MANDATORY = Value
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property QUESTLINESTEXT_SUBFORM() As QUERY_QUESTLINESTEXT
            Get
                return _QUESTLINESTEXT_SUBFORM
            End Get
            Set
                _QUESTLINESTEXT_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetANSNUM then
              if f then
                  jw.WriteRaw(", ""ANSNUM"": ")
              else
                  jw.WriteRaw("""ANSNUM"": ")
                  f = true
              end if
              jw.WriteValue(me.ANSNUM)
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
            if _QUESTLINESTEXT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", QUESTLINESTEXT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as QUESTLINESTEXT in _QUESTLINESTEXT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _QUESTLINESTEXT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "CUSTNQUESTLINES")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "QUESTNUM")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetANSNUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ANSNUM")
              .WriteAttributeString("value", me.ANSNUM)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetREMARK then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REMARK")
              .WriteAttributeString("value", me.REMARK)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "48")
              .WriteEndElement
            end if
            if _QUESTLINESTEXT_SUBFORM.value.count > 0 then
              for each itm as QUESTLINESTEXT in _QUESTLINESTEXT_SUBFORM.Value
                itm.toXML(xw,"QUESTLINESTEXT_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as CUSTNQUESTLINES = JsonConvert.DeserializeObject(Of CUSTNQUESTLINES)(e.StreamReader.ReadToEnd)
                With obj
                  _QUESTNUM = .QUESTNUM
                  _QUESTDES = .QUESTDES
                  _QGROUPDES = .QGROUPDES
                  _ANSNUM = .ANSNUM
                  _QUESTFADES = .QUESTFADES
                  _REMARK = .REMARK
                  _ATYPE = .ATYPE
                  _MANDATORY = .MANDATORY
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_CUSTNQUESTLINES
        
        QUESTLINESTEXT = 0
    End Enum
    
    <QueryTitle("Response (cont.)")>  _
    Public Class QUERY_QUESTLINESTEXT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of QUESTLINESTEXT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of QUESTLINESTEXT)
            _Parent = nothing
            _Name = "QUESTLINESTEXT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of QUESTLINESTEXT)
            _Parent = Parent
            _name = "QUESTLINESTEXT_SUBFORM"
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
        
        Public Property Value() As list(of QUESTLINESTEXT)
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
                return GetType(QUESTLINESTEXT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _QUESTLINESTEXT As QUESTLINESTEXT In JsonConvert.DeserializeObject(Of QUERY_QUESTLINESTEXT)(stream.ReadToEnd).Value
              With _QUESTLINESTEXT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_QUESTLINESTEXT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as QUESTLINESTEXT = JsonConvert.DeserializeObject(Of QUESTLINESTEXT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, QUESTLINESTEXT)
                  .TEXT = obj.TEXT
                  .TEXTLINE = obj.TEXTLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new QUESTLINESTEXT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _QUESTLINESTEXT as QUESTLINESTEXT in value
              If _QUESTLINESTEXT.Equals(trycast(obj,QUESTLINESTEXT)) Then
                  value.remove(_QUESTLINESTEXT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class QUESTLINESTEXT
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
                    return "QUESTLINESTEXT"
                else
                    return "QUESTLINESTEXT_SUBFORM"
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
        
        <DisplayName("Rest of Response"),  _
         nType("Edm.String"),  _
         tab("Rest of Response"),  _
         Pos(3),  _
         twodBarcode("TEXT")>  _
        Public Property TEXT() As String
            Get
                return _TEXT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Rest of Response", value, "^.{0,68}$") then Exit Property
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
         tab("Rest of Response"),  _
         Pos(4),  _
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
                .WriteAttributeString("name", "QUESTLINESTEXT")
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
                dim obj as QUESTLINESTEXT = JsonConvert.DeserializeObject(Of QUESTLINESTEXT)(e.StreamReader.ReadToEnd)
                With obj
                  _TEXT = .TEXT
                  _TEXTLINE = .TEXTLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Respondent's Remarks")>  _
    Public Class QUERY_CUSTNQUESTTEXT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of CUSTNQUESTTEXT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of CUSTNQUESTTEXT)
            _Parent = nothing
            _Name = "CUSTNQUESTTEXT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of CUSTNQUESTTEXT)
            _Parent = Parent
            _name = "CUSTNQUESTTEXT_SUBFORM"
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
        
        Public Property Value() As list(of CUSTNQUESTTEXT)
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
                return GetType(CUSTNQUESTTEXT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _CUSTNQUESTTEXT As CUSTNQUESTTEXT In JsonConvert.DeserializeObject(Of QUERY_CUSTNQUESTTEXT)(stream.ReadToEnd).Value
              With _CUSTNQUESTTEXT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_CUSTNQUESTTEXT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as CUSTNQUESTTEXT = JsonConvert.DeserializeObject(Of CUSTNQUESTTEXT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, CUSTNQUESTTEXT)
                  .TEXT = obj.TEXT
                  .TEXTLINE = obj.TEXTLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new CUSTNQUESTTEXT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _CUSTNQUESTTEXT as CUSTNQUESTTEXT in value
              If _CUSTNQUESTTEXT.Equals(trycast(obj,CUSTNQUESTTEXT)) Then
                  value.remove(_CUSTNQUESTTEXT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class CUSTNQUESTTEXT
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
                    return "CUSTNQUESTTEXT"
                else
                    return "CUSTNQUESTTEXT_SUBFORM"
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
                .WriteAttributeString("name", "CUSTNQUESTTEXT")
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
                dim obj as CUSTNQUESTTEXT = JsonConvert.DeserializeObject(Of CUSTNQUESTTEXT)(e.StreamReader.ReadToEnd)
                With obj
                  _TEXT = .TEXT
                  _TEXTLINE = .TEXTLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Customer Documents for Task")>  _
    Public Class QUERY_CUSTNOTEEXTFILE
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of CUSTNOTEEXTFILE)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of CUSTNOTEEXTFILE)
            _Parent = nothing
            _Name = "CUSTNOTEEXTFILE"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Links to File")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of CUSTNOTEEXTFILE)
            _Parent = Parent
            _name = "CUSTNOTEEXTFILE_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Links to File")
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
        
        Public Property Value() As list(of CUSTNOTEEXTFILE)
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
                return GetType(CUSTNOTEEXTFILE)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _CUSTNOTEEXTFILE As CUSTNOTEEXTFILE In JsonConvert.DeserializeObject(Of QUERY_CUSTNOTEEXTFILE)(stream.ReadToEnd).Value
              With _CUSTNOTEEXTFILE
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_CUSTNOTEEXTFILE)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as CUSTNOTEEXTFILE = JsonConvert.DeserializeObject(Of CUSTNOTEEXTFILE)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, CUSTNOTEEXTFILE)
                  .EXTFILEDES = obj.EXTFILEDES
                  .CURDATE = obj.CURDATE
                  .EXTFILENAME = obj.EXTFILENAME
                  .STATUS = obj.STATUS
                  .SUFFIX = obj.SUFFIX
                  .NOSEND = obj.NOSEND
                  .FILESIZE = obj.FILESIZE
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .LUSERLOGIN = obj.LUSERLOGIN
                  .CUST = obj.CUST
                  .EXTFILENUM = obj.EXTFILENUM
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new CUSTNOTEEXTFILE(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _CUSTNOTEEXTFILE as CUSTNOTEEXTFILE in value
              If _CUSTNOTEEXTFILE.Equals(trycast(obj,CUSTNOTEEXTFILE)) Then
                  value.remove(_CUSTNOTEEXTFILE)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class CUSTNOTEEXTFILE
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetEXTFILEDES As Boolean = Boolean.FalseString
        
        Private _EXTFILEDES As String
        
        Private _IsSetCURDATE As Boolean = Boolean.FalseString
        
        Private _CURDATE As System.DateTimeOffset
        
        Private _IsSetEXTFILENAME As Boolean = Boolean.FalseString
        
        Private _EXTFILENAME As String
        
        Private _IsSetSTATUS As Boolean = Boolean.FalseString
        
        Private _STATUS As String
        
        Private _SUFFIX As String
        
        Private _IsSetNOSEND As Boolean = Boolean.FalseString
        
        Private _NOSEND As String
        
        Private _FILESIZE As Long
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _LUSERLOGIN As String
        
        Private _IsSetCUST As Boolean = Boolean.FalseString
        
        Private _CUST As Long
        
        Private _IsSetEXTFILENUM As Boolean = Boolean.FalseString
        
        Private _EXTFILENUM As Long
        
        Private _EXTFILELINKS_SUBFORM As QUERY_EXTFILELINKS
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Links to File"))
            _EXTFILELINKS_SUBFORM = new QUERY_EXTFILELINKS(me)
            WITH ChildQuery(0)
               .setoDataQuery(_EXTFILELINKS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Links to File", _EXTFILELINKS_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Links to File"))
            _EXTFILELINKS_SUBFORM = new QUERY_EXTFILELINKS(me)
            WITH ChildQuery(0)
               .setoDataQuery(_EXTFILELINKS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Links to File", _EXTFILELINKS_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "CUSTNOTEEXTFILE"
                else
                    return "CUSTNOTEEXTFILE_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "CUST={0},EXTFILENUM={1}", _
                  string.format("{0}",CUST), _
                  string.format("{0}",EXTFILENUM) _ 
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
        
        <DisplayName("File Name"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(1),  _
         twodBarcode("EXTFILEDES")>  _
        Public Property EXTFILEDES() As String
            Get
                return _EXTFILEDES
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("File Name", value, "^.{0,68}$") then Exit Property
                _IsSetEXTFILEDES = True
                If loading Then
                  _EXTFILEDES = Value
                Else
                    if not _EXTFILEDES = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EXTFILEDES", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EXTFILEDES = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Date Created"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("File Name"),  _
         Pos(2),  _
         twodBarcode("CURDATE")>  _
        Public Property CURDATE() As nullable (of DateTimeOffset)
            Get
                return _CURDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Date Created", value, "^.*$") then Exit Property
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
        
        <DisplayName("File Path"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(30),  _
         Mandatory(true),  _
         twodBarcode("EXTFILENAME")>  _
        Public Property EXTFILENAME() As String
            Get
                return _EXTFILENAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("File Path", value, "^.{0,80}$") then Exit Property
                _IsSetEXTFILENAME = True
                If loading Then
                  _EXTFILENAME = Value
                Else
                    if not _EXTFILENAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EXTFILENAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EXTFILENAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("File Status"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(32),  _
         twodBarcode("STATUS")>  _
        Public Property STATUS() As String
            Get
                return _STATUS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("File Status", value, "^.{0,1}$") then Exit Property
                _IsSetSTATUS = True
                If loading Then
                  _STATUS = Value
                Else
                    if not _STATUS = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("STATUS", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _STATUS = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("File Name Extension"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("SUFFIX")>  _
        Public Property SUFFIX() As String
            Get
                return _SUFFIX
            End Get
            Set
                if not(value is nothing) then
                  _SUFFIX = Value
                end if
            End Set
        End Property
        
        <DisplayName("Don't Send"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(45),  _
         twodBarcode("NOSEND")>  _
        Public Property NOSEND() As String
            Get
                return _NOSEND
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Don't Send", value, "^.{0,1}$") then Exit Property
                _IsSetNOSEND = True
                If loading Then
                  _NOSEND = Value
                Else
                    if not _NOSEND = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("NOSEND", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _NOSEND = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Size (Bytes)"),  _
         nType("Edm.Int64"),  _
         tab("File Name"),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("FILESIZE")>  _
        Public Property FILESIZE() As nullable (of int64)
            Get
                return _FILESIZE
            End Get
            Set
                if not(value is nothing) then
                  _FILESIZE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Modified by"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(100),  _
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
        
        <DisplayName("Date Modified"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Date Modified"),  _
         Pos(110),  _
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
        
        <DisplayName("Locked by"),  _
         nType("Edm.String"),  _
         tab("Date Modified"),  _
         Pos(120),  _
         [ReadOnly](true),  _
         twodBarcode("LUSERLOGIN")>  _
        Public Property LUSERLOGIN() As String
            Get
                return _LUSERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _LUSERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Customer (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Date Modified"),  _
         Pos(10),  _
         Browsable(false),  _
         twodBarcode("CUST")>  _
        Public Property CUST() As nullable (of int64)
            Get
                return _CUST
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Customer (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetCUST = True
                If loading Then
                  _CUST = Value
                Else
                    if not _CUST = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CUST", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CUST = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Document Number"),  _
         nType("Edm.Int64"),  _
         tab("Date Modified"),  _
         Pos(20),  _
         Browsable(false),  _
         twodBarcode("EXTFILENUM")>  _
        Public Property EXTFILENUM() As nullable (of int64)
            Get
                return _EXTFILENUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Document Number", value, "^[0-9\-]+$") then Exit Property
                _IsSetEXTFILENUM = True
                If loading Then
                  _EXTFILENUM = Value
                Else
                    if not _EXTFILENUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EXTFILENUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EXTFILENUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property EXTFILELINKS_SUBFORM() As QUERY_EXTFILELINKS
            Get
                return _EXTFILELINKS_SUBFORM
            End Get
            Set
                _EXTFILELINKS_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetEXTFILEDES then
              if f then
                  jw.WriteRaw(", ""EXTFILEDES"": ")
              else
                  jw.WriteRaw("""EXTFILEDES"": ")
                  f = true
              end if
              jw.WriteValue(me.EXTFILEDES)
            end if
            if _IsSetCURDATE then
              if f then
                  jw.WriteRaw(", ""CURDATE"": ")
              else
                  jw.WriteRaw("""CURDATE"": ")
                  f = true
              end if
              jw.WriteValue(me.CURDATE)
            end if
            if _IsSetEXTFILENAME then
              if f then
                  jw.WriteRaw(", ""EXTFILENAME"": ")
              else
                  jw.WriteRaw("""EXTFILENAME"": ")
                  f = true
              end if
              jw.WriteValue(me.EXTFILENAME)
            end if
            if _IsSetSTATUS then
              if f then
                  jw.WriteRaw(", ""STATUS"": ")
              else
                  jw.WriteRaw("""STATUS"": ")
                  f = true
              end if
              jw.WriteValue(me.STATUS)
            end if
            if _IsSetNOSEND then
              if f then
                  jw.WriteRaw(", ""NOSEND"": ")
              else
                  jw.WriteRaw("""NOSEND"": ")
                  f = true
              end if
              jw.WriteValue(me.NOSEND)
            end if
            if _IsSetCUST then
              if f then
                  jw.WriteRaw(", ""CUST"": ")
              else
                  jw.WriteRaw("""CUST"": ")
                  f = true
              end if
              jw.WriteValue(me.CUST)
            end if
            if _IsSetEXTFILENUM then
              if f then
                  jw.WriteRaw(", ""EXTFILENUM"": ")
              else
                  jw.WriteRaw("""EXTFILENUM"": ")
                  f = true
              end if
              jw.WriteValue(me.EXTFILENUM)
            end if
            if _EXTFILELINKS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", EXTFILELINKS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as EXTFILELINKS in _EXTFILELINKS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _EXTFILELINKS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "CUSTNOTEEXTFILE")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "CUST")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "EXTFILENUM")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetEXTFILEDES then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EXTFILEDES")
              .WriteAttributeString("value", me.EXTFILEDES)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "68")
              .WriteEndElement
            end if
            if _IsSetCURDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CURDATE")
              .WriteAttributeString("value", me.CURDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetEXTFILENAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EXTFILENAME")
              .WriteAttributeString("value", me.EXTFILENAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "80")
              .WriteEndElement
            end if
            if _IsSetSTATUS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "STATUS")
              .WriteAttributeString("value", me.STATUS)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetNOSEND then
              .WriteStartElement("field")
              .WriteAttributeString("name", "NOSEND")
              .WriteAttributeString("value", me.NOSEND)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetCUST then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CUST")
              .WriteAttributeString("value", me.CUST)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetEXTFILENUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EXTFILENUM")
              .WriteAttributeString("value", me.EXTFILENUM)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _EXTFILELINKS_SUBFORM.value.count > 0 then
              for each itm as EXTFILELINKS in _EXTFILELINKS_SUBFORM.Value
                itm.toXML(xw,"EXTFILELINKS_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as CUSTNOTEEXTFILE = JsonConvert.DeserializeObject(Of CUSTNOTEEXTFILE)(e.StreamReader.ReadToEnd)
                With obj
                  _EXTFILEDES = .EXTFILEDES
                  _CURDATE = .CURDATE
                  _EXTFILENAME = .EXTFILENAME
                  _STATUS = .STATUS
                  _SUFFIX = .SUFFIX
                  _NOSEND = .NOSEND
                  _FILESIZE = .FILESIZE
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _LUSERLOGIN = .LUSERLOGIN
                  _CUST = .CUST
                  _EXTFILENUM = .EXTFILENUM
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_CUSTNOTEEXTFILE
        
        EXTFILELINKS = 0
    End Enum
    
    <QueryTitle("Links to File")>  _
    Public Class QUERY_EXTFILELINKS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of EXTFILELINKS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of EXTFILELINKS)
            _Parent = nothing
            _Name = "EXTFILELINKS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of EXTFILELINKS)
            _Parent = Parent
            _name = "EXTFILELINKS_SUBFORM"
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
        
        Public Property Value() As list(of EXTFILELINKS)
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
                return GetType(EXTFILELINKS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _EXTFILELINKS As EXTFILELINKS In JsonConvert.DeserializeObject(Of QUERY_EXTFILELINKS)(stream.ReadToEnd).Value
              With _EXTFILELINKS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_EXTFILELINKS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as EXTFILELINKS = JsonConvert.DeserializeObject(Of EXTFILELINKS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, EXTFILELINKS)
                  .DOCDES = obj.DOCDES
                  .TODOREF = obj.TODOREF
                  .EXTFILENUM = obj.EXTFILENUM
                  .EXPLORERPATH = obj.EXPLORERPATH
                  .KLINE = obj.KLINE
                  .USER = obj.USER
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new EXTFILELINKS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _EXTFILELINKS as EXTFILELINKS in value
              If _EXTFILELINKS.Equals(trycast(obj,EXTFILELINKS)) Then
                  value.remove(_EXTFILELINKS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class EXTFILELINKS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _DOCDES As String
        
        Private _TODOREF As String
        
        Private _EXTFILENUM As Long
        
        Private _EXPLORERPATH As String
        
        Private _IsSetKLINE As Boolean = Boolean.FalseString
        
        Private _KLINE As Long
        
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
                    return "EXTFILELINKS"
                else
                    return "EXTFILELINKS_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "KLINE={0},USER={1}", _
                  string.format("{0}",KLINE), _
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
        
        <DisplayName("Document Type"),  _
         nType("Edm.String"),  _
         tab("Document Type"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("DOCDES")>  _
        Public Property DOCDES() As String
            Get
                return _DOCDES
            End Get
            Set
                if not(value is nothing) then
                  _DOCDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Document Number"),  _
         nType("Edm.String"),  _
         tab("Document Type"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("TODOREF")>  _
        Public Property TODOREF() As String
            Get
                return _TODOREF
            End Get
            Set
                if not(value is nothing) then
                  _TODOREF = Value
                end if
            End Set
        End Property
        
        <DisplayName("Attachment Number"),  _
         nType("Edm.Int64"),  _
         tab("Document Type"),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("EXTFILENUM")>  _
        Public Property EXTFILENUM() As nullable (of int64)
            Get
                return _EXTFILENUM
            End Get
            Set
                if not(value is nothing) then
                  _EXTFILENUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("Loc in File Explorer"),  _
         nType("Edm.String"),  _
         tab("Document Type"),  _
         Pos(50),  _
         [ReadOnly](true),  _
         twodBarcode("EXPLORERPATH")>  _
        Public Property EXPLORERPATH() As String
            Get
                return _EXPLORERPATH
            End Get
            Set
                if not(value is nothing) then
                  _EXPLORERPATH = Value
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Document Type"),  _
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
        
        <DisplayName("User (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Document Type"),  _
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
            if _IsSetKLINE then
              if f then
                  jw.WriteRaw(", ""KLINE"": ")
              else
                  jw.WriteRaw("""KLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.KLINE)
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
                .WriteAttributeString("name", "EXTFILELINKS")
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
              .WriteAttributeString("name", "USER")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetKLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", me.KLINE)
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
                dim obj as EXTFILELINKS = JsonConvert.DeserializeObject(Of EXTFILELINKS)(e.StreamReader.ReadToEnd)
                With obj
                  _DOCDES = .DOCDES
                  _TODOREF = .TODOREF
                  _EXTFILENUM = .EXTFILENUM
                  _EXPLORERPATH = .EXPLORERPATH
                  _KLINE = .KLINE
                  _USER = .USER
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Vendor Documents for Task")>  _
    Public Class QUERY_SUPNOTEEXTFILE
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of SUPNOTEEXTFILE)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of SUPNOTEEXTFILE)
            _Parent = nothing
            _Name = "SUPNOTEEXTFILE"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Links to File")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of SUPNOTEEXTFILE)
            _Parent = Parent
            _name = "SUPNOTEEXTFILE_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Links to File")
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
        
        Public Property Value() As list(of SUPNOTEEXTFILE)
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
                return GetType(SUPNOTEEXTFILE)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _SUPNOTEEXTFILE As SUPNOTEEXTFILE In JsonConvert.DeserializeObject(Of QUERY_SUPNOTEEXTFILE)(stream.ReadToEnd).Value
              With _SUPNOTEEXTFILE
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_SUPNOTEEXTFILE)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as SUPNOTEEXTFILE = JsonConvert.DeserializeObject(Of SUPNOTEEXTFILE)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, SUPNOTEEXTFILE)
                  .EXTFILEDES = obj.EXTFILEDES
                  .CURDATE = obj.CURDATE
                  .EXTFILENAME = obj.EXTFILENAME
                  .STATUS = obj.STATUS
                  .SUFFIX = obj.SUFFIX
                  .FILESIZE = obj.FILESIZE
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .LUSERLOGIN = obj.LUSERLOGIN
                  .SUP = obj.SUP
                  .EXTFILENUM = obj.EXTFILENUM
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new SUPNOTEEXTFILE(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _SUPNOTEEXTFILE as SUPNOTEEXTFILE in value
              If _SUPNOTEEXTFILE.Equals(trycast(obj,SUPNOTEEXTFILE)) Then
                  value.remove(_SUPNOTEEXTFILE)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class SUPNOTEEXTFILE
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetEXTFILEDES As Boolean = Boolean.FalseString
        
        Private _EXTFILEDES As String
        
        Private _IsSetCURDATE As Boolean = Boolean.FalseString
        
        Private _CURDATE As System.DateTimeOffset
        
        Private _IsSetEXTFILENAME As Boolean = Boolean.FalseString
        
        Private _EXTFILENAME As String
        
        Private _IsSetSTATUS As Boolean = Boolean.FalseString
        
        Private _STATUS As String
        
        Private _SUFFIX As String
        
        Private _FILESIZE As Long
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _LUSERLOGIN As String
        
        Private _IsSetSUP As Boolean = Boolean.FalseString
        
        Private _SUP As Long
        
        Private _IsSetEXTFILENUM As Boolean = Boolean.FalseString
        
        Private _EXTFILENUM As Long
        
        Private _EXTFILELINKS_SUBFORM As QUERY_EXTFILELINKS
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Links to File"))
            _EXTFILELINKS_SUBFORM = new QUERY_EXTFILELINKS(me)
            WITH ChildQuery(0)
               .setoDataQuery(_EXTFILELINKS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Links to File", _EXTFILELINKS_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Links to File"))
            _EXTFILELINKS_SUBFORM = new QUERY_EXTFILELINKS(me)
            WITH ChildQuery(0)
               .setoDataQuery(_EXTFILELINKS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Links to File", _EXTFILELINKS_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "SUPNOTEEXTFILE"
                else
                    return "SUPNOTEEXTFILE_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "SUP={0},EXTFILENUM={1}", _
                  string.format("{0}",SUP), _
                  string.format("{0}",EXTFILENUM) _ 
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
        
        <DisplayName("File Name"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(1),  _
         Mandatory(true),  _
         twodBarcode("EXTFILEDES")>  _
        Public Property EXTFILEDES() As String
            Get
                return _EXTFILEDES
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("File Name", value, "^.{0,68}$") then Exit Property
                _IsSetEXTFILEDES = True
                If loading Then
                  _EXTFILEDES = Value
                Else
                    if not _EXTFILEDES = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EXTFILEDES", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EXTFILEDES = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Date Created"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("File Name"),  _
         Pos(2),  _
         twodBarcode("CURDATE")>  _
        Public Property CURDATE() As nullable (of DateTimeOffset)
            Get
                return _CURDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Date Created", value, "^.*$") then Exit Property
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
        
        <DisplayName("File Path"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(30),  _
         Mandatory(true),  _
         twodBarcode("EXTFILENAME")>  _
        Public Property EXTFILENAME() As String
            Get
                return _EXTFILENAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("File Path", value, "^.{0,80}$") then Exit Property
                _IsSetEXTFILENAME = True
                If loading Then
                  _EXTFILENAME = Value
                Else
                    if not _EXTFILENAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EXTFILENAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EXTFILENAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("File Status"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(35),  _
         twodBarcode("STATUS")>  _
        Public Property STATUS() As String
            Get
                return _STATUS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("File Status", value, "^.{0,1}$") then Exit Property
                _IsSetSTATUS = True
                If loading Then
                  _STATUS = Value
                Else
                    if not _STATUS = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("STATUS", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _STATUS = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("File Name Extension"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("SUFFIX")>  _
        Public Property SUFFIX() As String
            Get
                return _SUFFIX
            End Get
            Set
                if not(value is nothing) then
                  _SUFFIX = Value
                end if
            End Set
        End Property
        
        <DisplayName("Size (Bytes)"),  _
         nType("Edm.Int64"),  _
         tab("File Name"),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("FILESIZE")>  _
        Public Property FILESIZE() As nullable (of int64)
            Get
                return _FILESIZE
            End Get
            Set
                if not(value is nothing) then
                  _FILESIZE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Modified by"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(100),  _
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
        
        <DisplayName("Date Modified"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("File Name"),  _
         Pos(110),  _
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
        
        <DisplayName("Locked by"),  _
         nType("Edm.String"),  _
         tab("Locked by"),  _
         Pos(120),  _
         [ReadOnly](true),  _
         twodBarcode("LUSERLOGIN")>  _
        Public Property LUSERLOGIN() As String
            Get
                return _LUSERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _LUSERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Vendor (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Locked by"),  _
         Pos(10),  _
         Browsable(false),  _
         twodBarcode("SUP")>  _
        Public Property SUP() As nullable (of int64)
            Get
                return _SUP
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Vendor (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetSUP = True
                If loading Then
                  _SUP = Value
                Else
                    if not _SUP = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SUP", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SUP = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Document Number"),  _
         nType("Edm.Int64"),  _
         tab("Locked by"),  _
         Pos(20),  _
         Browsable(false),  _
         twodBarcode("EXTFILENUM")>  _
        Public Property EXTFILENUM() As nullable (of int64)
            Get
                return _EXTFILENUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Document Number", value, "^[0-9\-]+$") then Exit Property
                _IsSetEXTFILENUM = True
                If loading Then
                  _EXTFILENUM = Value
                Else
                    if not _EXTFILENUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EXTFILENUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EXTFILENUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property EXTFILELINKS_SUBFORM() As QUERY_EXTFILELINKS
            Get
                return _EXTFILELINKS_SUBFORM
            End Get
            Set
                _EXTFILELINKS_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetEXTFILEDES then
              if f then
                  jw.WriteRaw(", ""EXTFILEDES"": ")
              else
                  jw.WriteRaw("""EXTFILEDES"": ")
                  f = true
              end if
              jw.WriteValue(me.EXTFILEDES)
            end if
            if _IsSetCURDATE then
              if f then
                  jw.WriteRaw(", ""CURDATE"": ")
              else
                  jw.WriteRaw("""CURDATE"": ")
                  f = true
              end if
              jw.WriteValue(me.CURDATE)
            end if
            if _IsSetEXTFILENAME then
              if f then
                  jw.WriteRaw(", ""EXTFILENAME"": ")
              else
                  jw.WriteRaw("""EXTFILENAME"": ")
                  f = true
              end if
              jw.WriteValue(me.EXTFILENAME)
            end if
            if _IsSetSTATUS then
              if f then
                  jw.WriteRaw(", ""STATUS"": ")
              else
                  jw.WriteRaw("""STATUS"": ")
                  f = true
              end if
              jw.WriteValue(me.STATUS)
            end if
            if _IsSetSUP then
              if f then
                  jw.WriteRaw(", ""SUP"": ")
              else
                  jw.WriteRaw("""SUP"": ")
                  f = true
              end if
              jw.WriteValue(me.SUP)
            end if
            if _IsSetEXTFILENUM then
              if f then
                  jw.WriteRaw(", ""EXTFILENUM"": ")
              else
                  jw.WriteRaw("""EXTFILENUM"": ")
                  f = true
              end if
              jw.WriteValue(me.EXTFILENUM)
            end if
            if _EXTFILELINKS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", EXTFILELINKS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as EXTFILELINKS in _EXTFILELINKS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _EXTFILELINKS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "SUPNOTEEXTFILE")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "SUP")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "EXTFILENUM")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetEXTFILEDES then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EXTFILEDES")
              .WriteAttributeString("value", me.EXTFILEDES)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "68")
              .WriteEndElement
            end if
            if _IsSetCURDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CURDATE")
              .WriteAttributeString("value", me.CURDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetEXTFILENAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EXTFILENAME")
              .WriteAttributeString("value", me.EXTFILENAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "80")
              .WriteEndElement
            end if
            if _IsSetSTATUS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "STATUS")
              .WriteAttributeString("value", me.STATUS)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetSUP then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SUP")
              .WriteAttributeString("value", me.SUP)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetEXTFILENUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EXTFILENUM")
              .WriteAttributeString("value", me.EXTFILENUM)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _EXTFILELINKS_SUBFORM.value.count > 0 then
              for each itm as EXTFILELINKS in _EXTFILELINKS_SUBFORM.Value
                itm.toXML(xw,"EXTFILELINKS_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as SUPNOTEEXTFILE = JsonConvert.DeserializeObject(Of SUPNOTEEXTFILE)(e.StreamReader.ReadToEnd)
                With obj
                  _EXTFILEDES = .EXTFILEDES
                  _CURDATE = .CURDATE
                  _EXTFILENAME = .EXTFILENAME
                  _STATUS = .STATUS
                  _SUFFIX = .SUFFIX
                  _FILESIZE = .FILESIZE
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _LUSERLOGIN = .LUSERLOGIN
                  _SUP = .SUP
                  _EXTFILENUM = .EXTFILENUM
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_SUPNOTEEXTFILE
        
        EXTFILELINKS = 0
    End Enum
    
    <QueryTitle("Links to File")>  _
    Public Class QUERY_EXTFILELINKS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of EXTFILELINKS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of EXTFILELINKS)
            _Parent = nothing
            _Name = "EXTFILELINKS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of EXTFILELINKS)
            _Parent = Parent
            _name = "EXTFILELINKS_SUBFORM"
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
        
        Public Property Value() As list(of EXTFILELINKS)
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
                return GetType(EXTFILELINKS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _EXTFILELINKS As EXTFILELINKS In JsonConvert.DeserializeObject(Of QUERY_EXTFILELINKS)(stream.ReadToEnd).Value
              With _EXTFILELINKS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_EXTFILELINKS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as EXTFILELINKS = JsonConvert.DeserializeObject(Of EXTFILELINKS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, EXTFILELINKS)
                  .DOCDES = obj.DOCDES
                  .TODOREF = obj.TODOREF
                  .EXTFILENUM = obj.EXTFILENUM
                  .EXPLORERPATH = obj.EXPLORERPATH
                  .KLINE = obj.KLINE
                  .USER = obj.USER
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new EXTFILELINKS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _EXTFILELINKS as EXTFILELINKS in value
              If _EXTFILELINKS.Equals(trycast(obj,EXTFILELINKS)) Then
                  value.remove(_EXTFILELINKS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class EXTFILELINKS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _DOCDES As String
        
        Private _TODOREF As String
        
        Private _EXTFILENUM As Long
        
        Private _EXPLORERPATH As String
        
        Private _IsSetKLINE As Boolean = Boolean.FalseString
        
        Private _KLINE As Long
        
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
                    return "EXTFILELINKS"
                else
                    return "EXTFILELINKS_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "KLINE={0},USER={1}", _
                  string.format("{0}",KLINE), _
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
        
        <DisplayName("Document Type"),  _
         nType("Edm.String"),  _
         tab("Document Type"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("DOCDES")>  _
        Public Property DOCDES() As String
            Get
                return _DOCDES
            End Get
            Set
                if not(value is nothing) then
                  _DOCDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Document Number"),  _
         nType("Edm.String"),  _
         tab("Document Type"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("TODOREF")>  _
        Public Property TODOREF() As String
            Get
                return _TODOREF
            End Get
            Set
                if not(value is nothing) then
                  _TODOREF = Value
                end if
            End Set
        End Property
        
        <DisplayName("Attachment Number"),  _
         nType("Edm.Int64"),  _
         tab("Document Type"),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("EXTFILENUM")>  _
        Public Property EXTFILENUM() As nullable (of int64)
            Get
                return _EXTFILENUM
            End Get
            Set
                if not(value is nothing) then
                  _EXTFILENUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("Loc in File Explorer"),  _
         nType("Edm.String"),  _
         tab("Document Type"),  _
         Pos(50),  _
         [ReadOnly](true),  _
         twodBarcode("EXPLORERPATH")>  _
        Public Property EXPLORERPATH() As String
            Get
                return _EXPLORERPATH
            End Get
            Set
                if not(value is nothing) then
                  _EXPLORERPATH = Value
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Document Type"),  _
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
        
        <DisplayName("User (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Document Type"),  _
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
            if _IsSetKLINE then
              if f then
                  jw.WriteRaw(", ""KLINE"": ")
              else
                  jw.WriteRaw("""KLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.KLINE)
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
                .WriteAttributeString("name", "EXTFILELINKS")
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
              .WriteAttributeString("name", "USER")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetKLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", me.KLINE)
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
                dim obj as EXTFILELINKS = JsonConvert.DeserializeObject(Of EXTFILELINKS)(e.StreamReader.ReadToEnd)
                With obj
                  _DOCDES = .DOCDES
                  _TODOREF = .TODOREF
                  _EXTFILENUM = .EXTFILENUM
                  _EXPLORERPATH = .EXPLORERPATH
                  _KLINE = .KLINE
                  _USER = .USER
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("To Do Item")>  _
    Public Class QUERY_DOCTODOLIST
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of DOCTODOLIST)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of DOCTODOLIST)
            _Parent = nothing
            _Name = "DOCTODOLIST"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of DOCTODOLIST)
            _Parent = Parent
            _name = "DOCTODOLIST_SUBFORM"
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
        
        Public Property Value() As list(of DOCTODOLIST)
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
                return GetType(DOCTODOLIST)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _DOCTODOLIST As DOCTODOLIST In JsonConvert.DeserializeObject(Of QUERY_DOCTODOLIST)(stream.ReadToEnd).Value
              With _DOCTODOLIST
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_DOCTODOLIST)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DOCTODOLIST = JsonConvert.DeserializeObject(Of DOCTODOLIST)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, DOCTODOLIST)
                  .OWNERLOGIN = obj.OWNERLOGIN
                  .INITIATORLOGIN = obj.INITIATORLOGIN
                  .PRIO = obj.PRIO
                  .DETAILS = obj.DETAILS
                  .PLANNEDHOURS = obj.PLANNEDHOURS
                  .FROMDATE = obj.FROMDATE
                  .TODATE = obj.TODATE
                  .TODOLIST = obj.TODOLIST
                  .FOLLOWUPDETAILS = obj.FOLLOWUPDETAILS
                  .FOLLOWUPPRIO = obj.FOLLOWUPPRIO
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new DOCTODOLIST(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _DOCTODOLIST as DOCTODOLIST in value
              If _DOCTODOLIST.Equals(trycast(obj,DOCTODOLIST)) Then
                  value.remove(_DOCTODOLIST)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class DOCTODOLIST
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _OWNERLOGIN As String
        
        Private _IsSetINITIATORLOGIN As Boolean = Boolean.FalseString
        
        Private _INITIATORLOGIN As String
        
        Private _IsSetPRIO As Boolean = Boolean.FalseString
        
        Private _PRIO As Long
        
        Private _IsSetDETAILS As Boolean = Boolean.FalseString
        
        Private _DETAILS As String
        
        Private _IsSetPLANNEDHOURS As Boolean = Boolean.FalseString
        
        Private _PLANNEDHOURS As Long
        
        Private _IsSetFROMDATE As Boolean = Boolean.FalseString
        
        Private _FROMDATE As System.DateTimeOffset
        
        Private _IsSetTODATE As Boolean = Boolean.FalseString
        
        Private _TODATE As System.DateTimeOffset
        
        Private _TODOLIST As Long
        
        Private _IsSetFOLLOWUPDETAILS As Boolean = Boolean.FalseString
        
        Private _FOLLOWUPDETAILS As String
        
        Private _IsSetFOLLOWUPPRIO As Boolean = Boolean.FalseString
        
        Private _FOLLOWUPPRIO As Long
        
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
                    return "DOCTODOLIST"
                else
                    return "DOCTODOLIST_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "TODOLIST={0}", _
                  string.format("{0}",TODOLIST) _ 
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
        
        <DisplayName("Assigned to"),  _
         nType("Edm.String"),  _
         tab("Assigned to"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("OWNERLOGIN")>  _
        Public Property OWNERLOGIN() As String
            Get
                return _OWNERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _OWNERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Opened by"),  _
         nType("Edm.String"),  _
         tab("Assigned to"),  _
         Pos(20),  _
         twodBarcode("INITIATORLOGIN")>  _
        Public Property INITIATORLOGIN() As String
            Get
                return _INITIATORLOGIN
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Opened by", value, "^.{0,20}$") then Exit Property
                _IsSetINITIATORLOGIN = True
                If loading Then
                  _INITIATORLOGIN = Value
                Else
                    if not _INITIATORLOGIN = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("INITIATORLOGIN", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _INITIATORLOGIN = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Priority"),  _
         nType("Edm.Int64"),  _
         tab("Assigned to"),  _
         Pos(90),  _
         twodBarcode("PRIO")>  _
        Public Property PRIO() As nullable (of int64)
            Get
                return _PRIO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Priority", value, "^[0-9\-]+$") then Exit Property
                _IsSetPRIO = True
                If loading Then
                  _PRIO = Value
                Else
                    if not _PRIO = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PRIO", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PRIO = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Details"),  _
         nType("Edm.String"),  _
         tab("Assigned to"),  _
         Pos(130),  _
         twodBarcode("DETAILS")>  _
        Public Property DETAILS() As String
            Get
                return _DETAILS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Details", value, "^.{0,56}$") then Exit Property
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
        
        <DisplayName("Planned Hours"),  _
         nType("Edm.Int64"),  _
         tab("Assigned to"),  _
         Pos(135),  _
         twodBarcode("PLANNEDHOURS")>  _
        Public Property PLANNEDHOURS() As nullable (of int64)
            Get
                return _PLANNEDHOURS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Planned Hours", value, "^[0-9\-]+$") then Exit Property
                _IsSetPLANNEDHOURS = True
                If loading Then
                  _PLANNEDHOURS = Value
                Else
                    if not _PLANNEDHOURS = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PLANNEDHOURS", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PLANNEDHOURS = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Start Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Assigned to"),  _
         Pos(140),  _
         twodBarcode("FROMDATE")>  _
        Public Property FROMDATE() As nullable (of DateTimeOffset)
            Get
                return _FROMDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Start Date", value, "^.*$") then Exit Property
                _IsSetFROMDATE = True
                If loading Then
                  _FROMDATE = Value
                Else
                    if not _FROMDATE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FROMDATE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FROMDATE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Complete by"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Assigned to"),  _
         Pos(150),  _
         twodBarcode("TODATE")>  _
        Public Property TODATE() As nullable (of DateTimeOffset)
            Get
                return _TODATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Complete by", value, "^.*$") then Exit Property
                _IsSetTODATE = True
                If loading Then
                  _TODATE = Value
                Else
                    if not _TODATE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TODATE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TODATE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Item Number"),  _
         nType("Edm.Int64"),  _
         tab("Assigned to"),  _
         Pos(160),  _
         [ReadOnly](true),  _
         twodBarcode("TODOLIST")>  _
        Public Property TODOLIST() As nullable (of int64)
            Get
                return _TODOLIST
            End Get
            Set
                if not(value is nothing) then
                  _TODOLIST = Value
                end if
            End Set
        End Property
        
        <DisplayName("Tracking Details"),  _
         nType("Edm.String"),  _
         tab("Tracking Details"),  _
         Pos(170),  _
         twodBarcode("FOLLOWUPDETAILS")>  _
        Public Property FOLLOWUPDETAILS() As String
            Get
                return _FOLLOWUPDETAILS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Tracking Details", value, "^.{0,56}$") then Exit Property
                _IsSetFOLLOWUPDETAILS = True
                If loading Then
                  _FOLLOWUPDETAILS = Value
                Else
                    if not _FOLLOWUPDETAILS = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FOLLOWUPDETAILS", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FOLLOWUPDETAILS = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Tracking Priority"),  _
         nType("Edm.Int64"),  _
         tab("Tracking Details"),  _
         Pos(180),  _
         twodBarcode("FOLLOWUPPRIO")>  _
        Public Property FOLLOWUPPRIO() As nullable (of int64)
            Get
                return _FOLLOWUPPRIO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Tracking Priority", value, "^[0-9\-]+$") then Exit Property
                _IsSetFOLLOWUPPRIO = True
                If loading Then
                  _FOLLOWUPPRIO = Value
                Else
                    if not _FOLLOWUPPRIO = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FOLLOWUPPRIO", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FOLLOWUPPRIO = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetINITIATORLOGIN then
              if f then
                  jw.WriteRaw(", ""INITIATORLOGIN"": ")
              else
                  jw.WriteRaw("""INITIATORLOGIN"": ")
                  f = true
              end if
              jw.WriteValue(me.INITIATORLOGIN)
            end if
            if _IsSetPRIO then
              if f then
                  jw.WriteRaw(", ""PRIO"": ")
              else
                  jw.WriteRaw("""PRIO"": ")
                  f = true
              end if
              jw.WriteValue(me.PRIO)
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
            if _IsSetPLANNEDHOURS then
              if f then
                  jw.WriteRaw(", ""PLANNEDHOURS"": ")
              else
                  jw.WriteRaw("""PLANNEDHOURS"": ")
                  f = true
              end if
              jw.WriteValue(me.PLANNEDHOURS)
            end if
            if _IsSetFROMDATE then
              if f then
                  jw.WriteRaw(", ""FROMDATE"": ")
              else
                  jw.WriteRaw("""FROMDATE"": ")
                  f = true
              end if
              jw.WriteValue(me.FROMDATE)
            end if
            if _IsSetTODATE then
              if f then
                  jw.WriteRaw(", ""TODATE"": ")
              else
                  jw.WriteRaw("""TODATE"": ")
                  f = true
              end if
              jw.WriteValue(me.TODATE)
            end if
            if _IsSetFOLLOWUPDETAILS then
              if f then
                  jw.WriteRaw(", ""FOLLOWUPDETAILS"": ")
              else
                  jw.WriteRaw("""FOLLOWUPDETAILS"": ")
                  f = true
              end if
              jw.WriteValue(me.FOLLOWUPDETAILS)
            end if
            if _IsSetFOLLOWUPPRIO then
              if f then
                  jw.WriteRaw(", ""FOLLOWUPPRIO"": ")
              else
                  jw.WriteRaw("""FOLLOWUPPRIO"": ")
                  f = true
              end if
              jw.WriteValue(me.FOLLOWUPPRIO)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "DOCTODOLIST")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "TODOLIST")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetINITIATORLOGIN then
              .WriteStartElement("field")
              .WriteAttributeString("name", "INITIATORLOGIN")
              .WriteAttributeString("value", me.INITIATORLOGIN)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
              .WriteEndElement
            end if
            if _IsSetPRIO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PRIO")
              .WriteAttributeString("value", me.PRIO)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetDETAILS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DETAILS")
              .WriteAttributeString("value", me.DETAILS)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "56")
              .WriteEndElement
            end if
            if _IsSetPLANNEDHOURS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PLANNEDHOURS")
              .WriteAttributeString("value", me.PLANNEDHOURS)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetFROMDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FROMDATE")
              .WriteAttributeString("value", me.FROMDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetTODATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TODATE")
              .WriteAttributeString("value", me.TODATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetFOLLOWUPDETAILS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FOLLOWUPDETAILS")
              .WriteAttributeString("value", me.FOLLOWUPDETAILS)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "56")
              .WriteEndElement
            end if
            if _IsSetFOLLOWUPPRIO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FOLLOWUPPRIO")
              .WriteAttributeString("value", me.FOLLOWUPPRIO)
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
                dim obj as DOCTODOLIST = JsonConvert.DeserializeObject(Of DOCTODOLIST)(e.StreamReader.ReadToEnd)
                With obj
                  _OWNERLOGIN = .OWNERLOGIN
                  _INITIATORLOGIN = .INITIATORLOGIN
                  _PRIO = .PRIO
                  _DETAILS = .DETAILS
                  _PLANNEDHOURS = .PLANNEDHOURS
                  _FROMDATE = .FROMDATE
                  _TODATE = .TODATE
                  _TODOLIST = .TODOLIST
                  _FOLLOWUPDETAILS = .FOLLOWUPDETAILS
                  _FOLLOWUPPRIO = .FOLLOWUPPRIO
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("History of Statuses")>  _
    Public Class QUERY_DOCTODOLISTLOG
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of DOCTODOLISTLOG)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of DOCTODOLISTLOG)
            _Parent = nothing
            _Name = "DOCTODOLISTLOG"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "To Do List - Remarks")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of DOCTODOLISTLOG)
            _Parent = Parent
            _name = "DOCTODOLISTLOG_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "To Do List - Remarks")
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
        
        Public Property Value() As list(of DOCTODOLISTLOG)
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
                return GetType(DOCTODOLISTLOG)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _DOCTODOLISTLOG As DOCTODOLISTLOG In JsonConvert.DeserializeObject(Of QUERY_DOCTODOLISTLOG)(stream.ReadToEnd).Value
              With _DOCTODOLISTLOG
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_DOCTODOLISTLOG)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DOCTODOLISTLOG = JsonConvert.DeserializeObject(Of DOCTODOLISTLOG)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, DOCTODOLISTLOG)
                  .UDATE = obj.UDATE
                  .STATDES = obj.STATDES
                  .OWNERLOGIN = obj.OWNERLOGIN
                  .INITIATORLOGIN = obj.INITIATORLOGIN
                  .USERLOGIN = obj.USERLOGIN
                  .DETAILS = obj.DETAILS
                  .PRIO = obj.PRIO
                  .PLANNEDHOURS = obj.PLANNEDHOURS
                  .FROMDATE = obj.FROMDATE
                  .TODATE = obj.TODATE
                  .ACTIVE = obj.ACTIVE
                  .TODOLIST = obj.TODOLIST
                  .DURATION = obj.DURATION
                  .DURATIONDAYS = obj.DURATIONDAYS
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new DOCTODOLISTLOG(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _DOCTODOLISTLOG as DOCTODOLISTLOG in value
              If _DOCTODOLISTLOG.Equals(trycast(obj,DOCTODOLISTLOG)) Then
                  value.remove(_DOCTODOLISTLOG)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class DOCTODOLISTLOG
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _UDATE As System.DateTimeOffset
        
        Private _STATDES As String
        
        Private _OWNERLOGIN As String
        
        Private _INITIATORLOGIN As String
        
        Private _USERLOGIN As String
        
        Private _IsSetDETAILS As Boolean = Boolean.FalseString
        
        Private _DETAILS As String
        
        Private _IsSetPRIO As Boolean = Boolean.FalseString
        
        Private _PRIO As Long
        
        Private _IsSetPLANNEDHOURS As Boolean = Boolean.FalseString
        
        Private _PLANNEDHOURS As Long
        
        Private _FROMDATE As System.DateTimeOffset
        
        Private _TODATE As System.DateTimeOffset
        
        Private _ACTIVE As String
        
        Private _TODOLIST As Long
        
        Private _DURATION As String
        
        Private _DURATIONDAYS As Decimal
        
        Private _DOCTODOLISTLOGTEXT_SUBFORM As QUERY_DOCTODOLISTLOGTEXT
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("To Do List - Remarks"))
            _DOCTODOLISTLOGTEXT_SUBFORM = new QUERY_DOCTODOLISTLOGTEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_DOCTODOLISTLOGTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("To Do List - Remarks", _DOCTODOLISTLOGTEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("To Do List - Remarks"))
            _DOCTODOLISTLOGTEXT_SUBFORM = new QUERY_DOCTODOLISTLOGTEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_DOCTODOLISTLOGTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("To Do List - Remarks", _DOCTODOLISTLOGTEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "DOCTODOLISTLOG"
                else
                    return "DOCTODOLISTLOG_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "TODOLIST={0}", _
                  string.format("{0}",TODOLIST) _ 
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
        
        <DisplayName("Time Stamp"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Time Stamp"),  _
         Pos(5),  _
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
        
        <DisplayName("Status"),  _
         nType("Edm.String"),  _
         tab("Time Stamp"),  _
         Pos(7),  _
         [ReadOnly](true),  _
         twodBarcode("STATDES")>  _
        Public Property STATDES() As String
            Get
                return _STATDES
            End Get
            Set
                if not(value is nothing) then
                  _STATDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Assigned to"),  _
         nType("Edm.String"),  _
         tab("Time Stamp"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("OWNERLOGIN")>  _
        Public Property OWNERLOGIN() As String
            Get
                return _OWNERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _OWNERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Opened by"),  _
         nType("Edm.String"),  _
         tab("Time Stamp"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("INITIATORLOGIN")>  _
        Public Property INITIATORLOGIN() As String
            Get
                return _INITIATORLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _INITIATORLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Time Stamp"),  _
         Pos(25),  _
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
        
        <DisplayName("Details"),  _
         nType("Edm.String"),  _
         tab("Time Stamp"),  _
         Pos(90),  _
         twodBarcode("DETAILS")>  _
        Public Property DETAILS() As String
            Get
                return _DETAILS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Details", value, "^.{0,56}$") then Exit Property
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
        
        <DisplayName("Priority"),  _
         nType("Edm.Int64"),  _
         tab("Time Stamp"),  _
         Pos(130),  _
         twodBarcode("PRIO")>  _
        Public Property PRIO() As nullable (of int64)
            Get
                return _PRIO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Priority", value, "^[0-9\-]+$") then Exit Property
                _IsSetPRIO = True
                If loading Then
                  _PRIO = Value
                Else
                    if not _PRIO = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PRIO", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PRIO = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Planned Hours"),  _
         nType("Edm.Int64"),  _
         tab("Time Stamp"),  _
         Pos(135),  _
         twodBarcode("PLANNEDHOURS")>  _
        Public Property PLANNEDHOURS() As nullable (of int64)
            Get
                return _PLANNEDHOURS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Planned Hours", value, "^[0-9\-]+$") then Exit Property
                _IsSetPLANNEDHOURS = True
                If loading Then
                  _PLANNEDHOURS = Value
                Else
                    if not _PLANNEDHOURS = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PLANNEDHOURS", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PLANNEDHOURS = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Start Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Start Date"),  _
         Pos(140),  _
         [ReadOnly](true),  _
         twodBarcode("FROMDATE")>  _
        Public Property FROMDATE() As nullable (of DateTimeOffset)
            Get
                return _FROMDATE
            End Get
            Set
                if not(value is nothing) then
                  _FROMDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Complete by"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Start Date"),  _
         Pos(150),  _
         [ReadOnly](true),  _
         twodBarcode("TODATE")>  _
        Public Property TODATE() As nullable (of DateTimeOffset)
            Get
                return _TODATE
            End Get
            Set
                if not(value is nothing) then
                  _TODATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("In Use"),  _
         nType("Edm.String"),  _
         tab("Start Date"),  _
         Pos(160),  _
         [ReadOnly](true),  _
         twodBarcode("ACTIVE")>  _
        Public Property ACTIVE() As String
            Get
                return _ACTIVE
            End Get
            Set
                if not(value is nothing) then
                  _ACTIVE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Item Number"),  _
         nType("Edm.Int64"),  _
         tab("Start Date"),  _
         Pos(170),  _
         [ReadOnly](true),  _
         twodBarcode("TODOLIST")>  _
        Public Property TODOLIST() As nullable (of int64)
            Get
                return _TODOLIST
            End Get
            Set
                if not(value is nothing) then
                  _TODOLIST = Value
                end if
            End Set
        End Property
        
        <DisplayName("Status Duration-Hrs"),  _
         nType("Edm.String"),  _
         tab("Start Date"),  _
         Pos(180),  _
         [ReadOnly](true),  _
         twodBarcode("DURATION")>  _
        Public Property DURATION() As String
            Get
                return _DURATION
            End Get
            Set
                if not(value is nothing) then
                  _DURATION = Value
                end if
            End Set
        End Property
        
        <DisplayName("Status Duration-Days"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(6),  _
         tab("Start Date"),  _
         Pos(200),  _
         [ReadOnly](true),  _
         twodBarcode("DURATIONDAYS")>  _
        Public Property DURATIONDAYS() As nullable(of decimal)
            Get
                return _DURATIONDAYS
            End Get
            Set
                if not(value is nothing) then
                  _DURATIONDAYS = Value
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property DOCTODOLISTLOGTEXT_SUBFORM() As QUERY_DOCTODOLISTLOGTEXT
            Get
                return _DOCTODOLISTLOGTEXT_SUBFORM
            End Get
            Set
                _DOCTODOLISTLOGTEXT_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetDETAILS then
              if f then
                  jw.WriteRaw(", ""DETAILS"": ")
              else
                  jw.WriteRaw("""DETAILS"": ")
                  f = true
              end if
              jw.WriteValue(me.DETAILS)
            end if
            if _IsSetPRIO then
              if f then
                  jw.WriteRaw(", ""PRIO"": ")
              else
                  jw.WriteRaw("""PRIO"": ")
                  f = true
              end if
              jw.WriteValue(me.PRIO)
            end if
            if _IsSetPLANNEDHOURS then
              if f then
                  jw.WriteRaw(", ""PLANNEDHOURS"": ")
              else
                  jw.WriteRaw("""PLANNEDHOURS"": ")
                  f = true
              end if
              jw.WriteValue(me.PLANNEDHOURS)
            end if
            if _DOCTODOLISTLOGTEXT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", DOCTODOLISTLOGTEXT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as DOCTODOLISTLOGTEXT in _DOCTODOLISTLOGTEXT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _DOCTODOLISTLOGTEXT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "DOCTODOLISTLOG")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "TODOLIST")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetDETAILS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DETAILS")
              .WriteAttributeString("value", me.DETAILS)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "56")
              .WriteEndElement
            end if
            if _IsSetPRIO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PRIO")
              .WriteAttributeString("value", me.PRIO)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetPLANNEDHOURS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PLANNEDHOURS")
              .WriteAttributeString("value", me.PLANNEDHOURS)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _DOCTODOLISTLOGTEXT_SUBFORM.value.count > 0 then
              for each itm as DOCTODOLISTLOGTEXT in _DOCTODOLISTLOGTEXT_SUBFORM.Value
                itm.toXML(xw,"DOCTODOLISTLOGTEXT_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DOCTODOLISTLOG = JsonConvert.DeserializeObject(Of DOCTODOLISTLOG)(e.StreamReader.ReadToEnd)
                With obj
                  _UDATE = .UDATE
                  _STATDES = .STATDES
                  _OWNERLOGIN = .OWNERLOGIN
                  _INITIATORLOGIN = .INITIATORLOGIN
                  _USERLOGIN = .USERLOGIN
                  _DETAILS = .DETAILS
                  _PRIO = .PRIO
                  _PLANNEDHOURS = .PLANNEDHOURS
                  _FROMDATE = .FROMDATE
                  _TODATE = .TODATE
                  _ACTIVE = .ACTIVE
                  _TODOLIST = .TODOLIST
                  _DURATION = .DURATION
                  _DURATIONDAYS = .DURATIONDAYS
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_DOCTODOLISTLOG
        
        DOCTODOLISTLOGTEXT = 0
    End Enum
    
    <QueryTitle("To Do List - Remarks")>  _
    Public Class QUERY_DOCTODOLISTLOGTEXT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of DOCTODOLISTLOGTEXT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of DOCTODOLISTLOGTEXT)
            _Parent = nothing
            _Name = "DOCTODOLISTLOGTEXT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of DOCTODOLISTLOGTEXT)
            _Parent = Parent
            _name = "DOCTODOLISTLOGTEXT_SUBFORM"
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
        
        Public Property Value() As list(of DOCTODOLISTLOGTEXT)
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
                return GetType(DOCTODOLISTLOGTEXT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _DOCTODOLISTLOGTEXT As DOCTODOLISTLOGTEXT In JsonConvert.DeserializeObject(Of QUERY_DOCTODOLISTLOGTEXT)(stream.ReadToEnd).Value
              With _DOCTODOLISTLOGTEXT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_DOCTODOLISTLOGTEXT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DOCTODOLISTLOGTEXT = JsonConvert.DeserializeObject(Of DOCTODOLISTLOGTEXT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, DOCTODOLISTLOGTEXT)
                  .TEXT = obj.TEXT
                  .TEXTLINE = obj.TEXTLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new DOCTODOLISTLOGTEXT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _DOCTODOLISTLOGTEXT as DOCTODOLISTLOGTEXT in value
              If _DOCTODOLISTLOGTEXT.Equals(trycast(obj,DOCTODOLISTLOGTEXT)) Then
                  value.remove(_DOCTODOLISTLOGTEXT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class DOCTODOLISTLOGTEXT
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
                    return "DOCTODOLISTLOGTEXT"
                else
                    return "DOCTODOLISTLOGTEXT_SUBFORM"
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
        
        <DisplayName("TEXTLINE"),  _
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
                .WriteAttributeString("name", "DOCTODOLISTLOGTEXT")
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
                dim obj as DOCTODOLISTLOGTEXT = JsonConvert.DeserializeObject(Of DOCTODOLISTLOGTEXT)(e.StreamReader.ReadToEnd)
                With obj
                  _TEXT = .TEXT
                  _TEXTLINE = .TEXTLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Electronic Signature")>  _
    Public Class QUERY_CUSTNOTESIGN
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of CUSTNOTESIGN)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of CUSTNOTESIGN)
            _Parent = nothing
            _Name = "CUSTNOTESIGN"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of CUSTNOTESIGN)
            _Parent = Parent
            _name = "CUSTNOTESIGN_SUBFORM"
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
        
        Public Property Value() As list(of CUSTNOTESIGN)
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
                return GetType(CUSTNOTESIGN)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _CUSTNOTESIGN As CUSTNOTESIGN In JsonConvert.DeserializeObject(Of QUERY_CUSTNOTESIGN)(stream.ReadToEnd).Value
              With _CUSTNOTESIGN
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_CUSTNOTESIGN)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as CUSTNOTESIGN = JsonConvert.DeserializeObject(Of CUSTNOTESIGN)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, CUSTNOTESIGN)
                  .UDATE = obj.UDATE
                  .USERLOGIN = obj.USERLOGIN
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new CUSTNOTESIGN(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _CUSTNOTESIGN as CUSTNOTESIGN in value
              If _CUSTNOTESIGN.Equals(trycast(obj,CUSTNOTESIGN)) Then
                  value.remove(_CUSTNOTESIGN)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class CUSTNOTESIGN
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _UDATE As System.DateTimeOffset
        
        Private _USERLOGIN As String
        
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
                    return "CUSTNOTESIGN"
                else
                    return "CUSTNOTESIGN_SUBFORM"
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
        
        <DisplayName("Time Stamp"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Time Stamp"),  _
         Pos(0),  _
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
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Time Stamp"),  _
         Pos(0),  _
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
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "CUSTNOTESIGN")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as CUSTNOTESIGN = JsonConvert.DeserializeObject(Of CUSTNOTESIGN)(e.StreamReader.ReadToEnd)
                With obj
                  _UDATE = .UDATE
                  _USERLOGIN = .USERLOGIN
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Warehouse Tasks for Document")>  _
    Public Class QUERY_LINKWTASK
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of LINKWTASK)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of LINKWTASK)
            _Parent = nothing
            _Name = "LINKWTASK"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of LINKWTASK)
            _Parent = Parent
            _name = "LINKWTASK_SUBFORM"
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
        
        Public Property Value() As list(of LINKWTASK)
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
                return GetType(LINKWTASK)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _LINKWTASK As LINKWTASK In JsonConvert.DeserializeObject(Of QUERY_LINKWTASK)(stream.ReadToEnd).Value
              With _LINKWTASK
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_LINKWTASK)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as LINKWTASK = JsonConvert.DeserializeObject(Of LINKWTASK)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, LINKWTASK)
                  .WTASKNUM = obj.WTASKNUM
                  .WTASKTYPECODE = obj.WTASKTYPECODE
                  .WTASKTYPEDES = obj.WTASKTYPEDES
                  .STATDES = obj.STATDES
                  .WAVENUM = obj.WAVENUM
                  .WTASK = obj.WTASK
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new LINKWTASK(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _LINKWTASK as LINKWTASK in value
              If _LINKWTASK.Equals(trycast(obj,LINKWTASK)) Then
                  value.remove(_LINKWTASK)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class LINKWTASK
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _WTASKNUM As String
        
        Private _WTASKTYPECODE As String
        
        Private _WTASKTYPEDES As String
        
        Private _STATDES As String
        
        Private _WAVENUM As String
        
        Private _IsSetWTASK As Boolean = Boolean.FalseString
        
        Private _WTASK As Long
        
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
                    return "LINKWTASK"
                else
                    return "LINKWTASK_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "WTASK={0}", _
                  string.format("{0}",WTASK) _ 
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
        
        <DisplayName("Warehouse Task No."),  _
         nType("Edm.String"),  _
         tab("Warehouse Task No."),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("WTASKNUM")>  _
        Public Property WTASKNUM() As String
            Get
                return _WTASKNUM
            End Get
            Set
                if not(value is nothing) then
                  _WTASKNUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("Warehouse Task Type"),  _
         nType("Edm.String"),  _
         tab("Warehouse Task No."),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("WTASKTYPECODE")>  _
        Public Property WTASKTYPECODE() As String
            Get
                return _WTASKTYPECODE
            End Get
            Set
                if not(value is nothing) then
                  _WTASKTYPECODE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Task Type Desc."),  _
         nType("Edm.String"),  _
         tab("Warehouse Task No."),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("WTASKTYPEDES")>  _
        Public Property WTASKTYPEDES() As String
            Get
                return _WTASKTYPEDES
            End Get
            Set
                if not(value is nothing) then
                  _WTASKTYPEDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Status"),  _
         nType("Edm.String"),  _
         tab("Warehouse Task No."),  _
         Pos(50),  _
         [ReadOnly](true),  _
         twodBarcode("STATDES")>  _
        Public Property STATDES() As String
            Get
                return _STATDES
            End Get
            Set
                if not(value is nothing) then
                  _STATDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Wave Number"),  _
         nType("Edm.String"),  _
         tab("Warehouse Task No."),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("WAVENUM")>  _
        Public Property WAVENUM() As String
            Get
                return _WAVENUM
            End Get
            Set
                if not(value is nothing) then
                  _WAVENUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("Warehouse Task (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Warehouse Task No."),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("WTASK")>  _
        Public Property WTASK() As nullable (of int64)
            Get
                return _WTASK
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Warehouse Task (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetWTASK = True
                If loading Then
                  _WTASK = Value
                Else
                    if not _WTASK = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("WTASK", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _WTASK = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetWTASK then
              if f then
                  jw.WriteRaw(", ""WTASK"": ")
              else
                  jw.WriteRaw("""WTASK"": ")
                  f = true
              end if
              jw.WriteValue(me.WTASK)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "LINKWTASK")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "WTASK")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetWTASK then
              .WriteStartElement("field")
              .WriteAttributeString("name", "WTASK")
              .WriteAttributeString("value", me.WTASK)
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
                dim obj as LINKWTASK = JsonConvert.DeserializeObject(Of LINKWTASK)(e.StreamReader.ReadToEnd)
                With obj
                  _WTASKNUM = .WTASKNUM
                  _WTASKTYPECODE = .WTASKTYPECODE
                  _WTASKTYPEDES = .WTASKTYPEDES
                  _STATDES = .STATDES
                  _WAVENUM = .WAVENUM
                  _WTASK = .WTASK
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("To Do Item")>  _
    Public Class QUERY_DOCTODOLIST
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of DOCTODOLIST)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of DOCTODOLIST)
            _Parent = nothing
            _Name = "DOCTODOLIST"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of DOCTODOLIST)
            _Parent = Parent
            _name = "DOCTODOLIST_SUBFORM"
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
        
        Public Property Value() As list(of DOCTODOLIST)
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
                return GetType(DOCTODOLIST)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _DOCTODOLIST As DOCTODOLIST In JsonConvert.DeserializeObject(Of QUERY_DOCTODOLIST)(stream.ReadToEnd).Value
              With _DOCTODOLIST
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_DOCTODOLIST)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DOCTODOLIST = JsonConvert.DeserializeObject(Of DOCTODOLIST)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, DOCTODOLIST)
                  .OWNERLOGIN = obj.OWNERLOGIN
                  .INITIATORLOGIN = obj.INITIATORLOGIN
                  .PRIO = obj.PRIO
                  .DETAILS = obj.DETAILS
                  .PLANNEDHOURS = obj.PLANNEDHOURS
                  .FROMDATE = obj.FROMDATE
                  .TODATE = obj.TODATE
                  .TODOLIST = obj.TODOLIST
                  .FOLLOWUPDETAILS = obj.FOLLOWUPDETAILS
                  .FOLLOWUPPRIO = obj.FOLLOWUPPRIO
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new DOCTODOLIST(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _DOCTODOLIST as DOCTODOLIST in value
              If _DOCTODOLIST.Equals(trycast(obj,DOCTODOLIST)) Then
                  value.remove(_DOCTODOLIST)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class DOCTODOLIST
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _OWNERLOGIN As String
        
        Private _IsSetINITIATORLOGIN As Boolean = Boolean.FalseString
        
        Private _INITIATORLOGIN As String
        
        Private _IsSetPRIO As Boolean = Boolean.FalseString
        
        Private _PRIO As Long
        
        Private _IsSetDETAILS As Boolean = Boolean.FalseString
        
        Private _DETAILS As String
        
        Private _IsSetPLANNEDHOURS As Boolean = Boolean.FalseString
        
        Private _PLANNEDHOURS As Long
        
        Private _IsSetFROMDATE As Boolean = Boolean.FalseString
        
        Private _FROMDATE As System.DateTimeOffset
        
        Private _IsSetTODATE As Boolean = Boolean.FalseString
        
        Private _TODATE As System.DateTimeOffset
        
        Private _TODOLIST As Long
        
        Private _IsSetFOLLOWUPDETAILS As Boolean = Boolean.FalseString
        
        Private _FOLLOWUPDETAILS As String
        
        Private _IsSetFOLLOWUPPRIO As Boolean = Boolean.FalseString
        
        Private _FOLLOWUPPRIO As Long
        
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
                    return "DOCTODOLIST"
                else
                    return "DOCTODOLIST_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "TODOLIST={0}", _
                  string.format("{0}",TODOLIST) _ 
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
        
        <DisplayName("Assigned to"),  _
         nType("Edm.String"),  _
         tab("Assigned to"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("OWNERLOGIN")>  _
        Public Property OWNERLOGIN() As String
            Get
                return _OWNERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _OWNERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Opened by"),  _
         nType("Edm.String"),  _
         tab("Assigned to"),  _
         Pos(20),  _
         twodBarcode("INITIATORLOGIN")>  _
        Public Property INITIATORLOGIN() As String
            Get
                return _INITIATORLOGIN
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Opened by", value, "^.{0,20}$") then Exit Property
                _IsSetINITIATORLOGIN = True
                If loading Then
                  _INITIATORLOGIN = Value
                Else
                    if not _INITIATORLOGIN = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("INITIATORLOGIN", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _INITIATORLOGIN = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Priority"),  _
         nType("Edm.Int64"),  _
         tab("Assigned to"),  _
         Pos(90),  _
         twodBarcode("PRIO")>  _
        Public Property PRIO() As nullable (of int64)
            Get
                return _PRIO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Priority", value, "^[0-9\-]+$") then Exit Property
                _IsSetPRIO = True
                If loading Then
                  _PRIO = Value
                Else
                    if not _PRIO = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PRIO", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PRIO = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Details"),  _
         nType("Edm.String"),  _
         tab("Assigned to"),  _
         Pos(130),  _
         twodBarcode("DETAILS")>  _
        Public Property DETAILS() As String
            Get
                return _DETAILS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Details", value, "^.{0,56}$") then Exit Property
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
        
        <DisplayName("Planned Hours"),  _
         nType("Edm.Int64"),  _
         tab("Assigned to"),  _
         Pos(135),  _
         twodBarcode("PLANNEDHOURS")>  _
        Public Property PLANNEDHOURS() As nullable (of int64)
            Get
                return _PLANNEDHOURS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Planned Hours", value, "^[0-9\-]+$") then Exit Property
                _IsSetPLANNEDHOURS = True
                If loading Then
                  _PLANNEDHOURS = Value
                Else
                    if not _PLANNEDHOURS = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PLANNEDHOURS", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PLANNEDHOURS = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Start Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Assigned to"),  _
         Pos(140),  _
         twodBarcode("FROMDATE")>  _
        Public Property FROMDATE() As nullable (of DateTimeOffset)
            Get
                return _FROMDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Start Date", value, "^.*$") then Exit Property
                _IsSetFROMDATE = True
                If loading Then
                  _FROMDATE = Value
                Else
                    if not _FROMDATE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FROMDATE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FROMDATE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Complete by"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Assigned to"),  _
         Pos(150),  _
         twodBarcode("TODATE")>  _
        Public Property TODATE() As nullable (of DateTimeOffset)
            Get
                return _TODATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Complete by", value, "^.*$") then Exit Property
                _IsSetTODATE = True
                If loading Then
                  _TODATE = Value
                Else
                    if not _TODATE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TODATE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TODATE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Item Number"),  _
         nType("Edm.Int64"),  _
         tab("Assigned to"),  _
         Pos(160),  _
         [ReadOnly](true),  _
         twodBarcode("TODOLIST")>  _
        Public Property TODOLIST() As nullable (of int64)
            Get
                return _TODOLIST
            End Get
            Set
                if not(value is nothing) then
                  _TODOLIST = Value
                end if
            End Set
        End Property
        
        <DisplayName("Tracking Details"),  _
         nType("Edm.String"),  _
         tab("Tracking Details"),  _
         Pos(170),  _
         twodBarcode("FOLLOWUPDETAILS")>  _
        Public Property FOLLOWUPDETAILS() As String
            Get
                return _FOLLOWUPDETAILS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Tracking Details", value, "^.{0,56}$") then Exit Property
                _IsSetFOLLOWUPDETAILS = True
                If loading Then
                  _FOLLOWUPDETAILS = Value
                Else
                    if not _FOLLOWUPDETAILS = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FOLLOWUPDETAILS", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FOLLOWUPDETAILS = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Tracking Priority"),  _
         nType("Edm.Int64"),  _
         tab("Tracking Details"),  _
         Pos(180),  _
         twodBarcode("FOLLOWUPPRIO")>  _
        Public Property FOLLOWUPPRIO() As nullable (of int64)
            Get
                return _FOLLOWUPPRIO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Tracking Priority", value, "^[0-9\-]+$") then Exit Property
                _IsSetFOLLOWUPPRIO = True
                If loading Then
                  _FOLLOWUPPRIO = Value
                Else
                    if not _FOLLOWUPPRIO = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FOLLOWUPPRIO", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FOLLOWUPPRIO = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetINITIATORLOGIN then
              if f then
                  jw.WriteRaw(", ""INITIATORLOGIN"": ")
              else
                  jw.WriteRaw("""INITIATORLOGIN"": ")
                  f = true
              end if
              jw.WriteValue(me.INITIATORLOGIN)
            end if
            if _IsSetPRIO then
              if f then
                  jw.WriteRaw(", ""PRIO"": ")
              else
                  jw.WriteRaw("""PRIO"": ")
                  f = true
              end if
              jw.WriteValue(me.PRIO)
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
            if _IsSetPLANNEDHOURS then
              if f then
                  jw.WriteRaw(", ""PLANNEDHOURS"": ")
              else
                  jw.WriteRaw("""PLANNEDHOURS"": ")
                  f = true
              end if
              jw.WriteValue(me.PLANNEDHOURS)
            end if
            if _IsSetFROMDATE then
              if f then
                  jw.WriteRaw(", ""FROMDATE"": ")
              else
                  jw.WriteRaw("""FROMDATE"": ")
                  f = true
              end if
              jw.WriteValue(me.FROMDATE)
            end if
            if _IsSetTODATE then
              if f then
                  jw.WriteRaw(", ""TODATE"": ")
              else
                  jw.WriteRaw("""TODATE"": ")
                  f = true
              end if
              jw.WriteValue(me.TODATE)
            end if
            if _IsSetFOLLOWUPDETAILS then
              if f then
                  jw.WriteRaw(", ""FOLLOWUPDETAILS"": ")
              else
                  jw.WriteRaw("""FOLLOWUPDETAILS"": ")
                  f = true
              end if
              jw.WriteValue(me.FOLLOWUPDETAILS)
            end if
            if _IsSetFOLLOWUPPRIO then
              if f then
                  jw.WriteRaw(", ""FOLLOWUPPRIO"": ")
              else
                  jw.WriteRaw("""FOLLOWUPPRIO"": ")
                  f = true
              end if
              jw.WriteValue(me.FOLLOWUPPRIO)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "DOCTODOLIST")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "TODOLIST")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetINITIATORLOGIN then
              .WriteStartElement("field")
              .WriteAttributeString("name", "INITIATORLOGIN")
              .WriteAttributeString("value", me.INITIATORLOGIN)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
              .WriteEndElement
            end if
            if _IsSetPRIO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PRIO")
              .WriteAttributeString("value", me.PRIO)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetDETAILS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DETAILS")
              .WriteAttributeString("value", me.DETAILS)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "56")
              .WriteEndElement
            end if
            if _IsSetPLANNEDHOURS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PLANNEDHOURS")
              .WriteAttributeString("value", me.PLANNEDHOURS)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetFROMDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FROMDATE")
              .WriteAttributeString("value", me.FROMDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetTODATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TODATE")
              .WriteAttributeString("value", me.TODATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetFOLLOWUPDETAILS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FOLLOWUPDETAILS")
              .WriteAttributeString("value", me.FOLLOWUPDETAILS)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "56")
              .WriteEndElement
            end if
            if _IsSetFOLLOWUPPRIO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FOLLOWUPPRIO")
              .WriteAttributeString("value", me.FOLLOWUPPRIO)
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
                dim obj as DOCTODOLIST = JsonConvert.DeserializeObject(Of DOCTODOLIST)(e.StreamReader.ReadToEnd)
                With obj
                  _OWNERLOGIN = .OWNERLOGIN
                  _INITIATORLOGIN = .INITIATORLOGIN
                  _PRIO = .PRIO
                  _DETAILS = .DETAILS
                  _PLANNEDHOURS = .PLANNEDHOURS
                  _FROMDATE = .FROMDATE
                  _TODATE = .TODATE
                  _TODOLIST = .TODOLIST
                  _FOLLOWUPDETAILS = .FOLLOWUPDETAILS
                  _FOLLOWUPPRIO = .FOLLOWUPPRIO
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("History of Statuses")>  _
    Public Class QUERY_DOCTODOLISTLOG
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of DOCTODOLISTLOG)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of DOCTODOLISTLOG)
            _Parent = nothing
            _Name = "DOCTODOLISTLOG"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "To Do List - Remarks")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of DOCTODOLISTLOG)
            _Parent = Parent
            _name = "DOCTODOLISTLOG_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "To Do List - Remarks")
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
        
        Public Property Value() As list(of DOCTODOLISTLOG)
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
                return GetType(DOCTODOLISTLOG)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _DOCTODOLISTLOG As DOCTODOLISTLOG In JsonConvert.DeserializeObject(Of QUERY_DOCTODOLISTLOG)(stream.ReadToEnd).Value
              With _DOCTODOLISTLOG
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_DOCTODOLISTLOG)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DOCTODOLISTLOG = JsonConvert.DeserializeObject(Of DOCTODOLISTLOG)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, DOCTODOLISTLOG)
                  .UDATE = obj.UDATE
                  .STATDES = obj.STATDES
                  .OWNERLOGIN = obj.OWNERLOGIN
                  .INITIATORLOGIN = obj.INITIATORLOGIN
                  .USERLOGIN = obj.USERLOGIN
                  .DETAILS = obj.DETAILS
                  .PRIO = obj.PRIO
                  .PLANNEDHOURS = obj.PLANNEDHOURS
                  .FROMDATE = obj.FROMDATE
                  .TODATE = obj.TODATE
                  .ACTIVE = obj.ACTIVE
                  .TODOLIST = obj.TODOLIST
                  .DURATION = obj.DURATION
                  .DURATIONDAYS = obj.DURATIONDAYS
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new DOCTODOLISTLOG(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _DOCTODOLISTLOG as DOCTODOLISTLOG in value
              If _DOCTODOLISTLOG.Equals(trycast(obj,DOCTODOLISTLOG)) Then
                  value.remove(_DOCTODOLISTLOG)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class DOCTODOLISTLOG
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _UDATE As System.DateTimeOffset
        
        Private _STATDES As String
        
        Private _OWNERLOGIN As String
        
        Private _INITIATORLOGIN As String
        
        Private _USERLOGIN As String
        
        Private _IsSetDETAILS As Boolean = Boolean.FalseString
        
        Private _DETAILS As String
        
        Private _IsSetPRIO As Boolean = Boolean.FalseString
        
        Private _PRIO As Long
        
        Private _IsSetPLANNEDHOURS As Boolean = Boolean.FalseString
        
        Private _PLANNEDHOURS As Long
        
        Private _FROMDATE As System.DateTimeOffset
        
        Private _TODATE As System.DateTimeOffset
        
        Private _ACTIVE As String
        
        Private _TODOLIST As Long
        
        Private _DURATION As String
        
        Private _DURATIONDAYS As Decimal
        
        Private _DOCTODOLISTLOGTEXT_SUBFORM As QUERY_DOCTODOLISTLOGTEXT
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("To Do List - Remarks"))
            _DOCTODOLISTLOGTEXT_SUBFORM = new QUERY_DOCTODOLISTLOGTEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_DOCTODOLISTLOGTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("To Do List - Remarks", _DOCTODOLISTLOGTEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("To Do List - Remarks"))
            _DOCTODOLISTLOGTEXT_SUBFORM = new QUERY_DOCTODOLISTLOGTEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_DOCTODOLISTLOGTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("To Do List - Remarks", _DOCTODOLISTLOGTEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "DOCTODOLISTLOG"
                else
                    return "DOCTODOLISTLOG_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "TODOLIST={0}", _
                  string.format("{0}",TODOLIST) _ 
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
        
        <DisplayName("Time Stamp"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Time Stamp"),  _
         Pos(5),  _
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
        
        <DisplayName("Status"),  _
         nType("Edm.String"),  _
         tab("Time Stamp"),  _
         Pos(7),  _
         [ReadOnly](true),  _
         twodBarcode("STATDES")>  _
        Public Property STATDES() As String
            Get
                return _STATDES
            End Get
            Set
                if not(value is nothing) then
                  _STATDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Assigned to"),  _
         nType("Edm.String"),  _
         tab("Time Stamp"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("OWNERLOGIN")>  _
        Public Property OWNERLOGIN() As String
            Get
                return _OWNERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _OWNERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Opened by"),  _
         nType("Edm.String"),  _
         tab("Time Stamp"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("INITIATORLOGIN")>  _
        Public Property INITIATORLOGIN() As String
            Get
                return _INITIATORLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _INITIATORLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Time Stamp"),  _
         Pos(25),  _
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
        
        <DisplayName("Details"),  _
         nType("Edm.String"),  _
         tab("Time Stamp"),  _
         Pos(90),  _
         twodBarcode("DETAILS")>  _
        Public Property DETAILS() As String
            Get
                return _DETAILS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Details", value, "^.{0,56}$") then Exit Property
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
        
        <DisplayName("Priority"),  _
         nType("Edm.Int64"),  _
         tab("Time Stamp"),  _
         Pos(130),  _
         twodBarcode("PRIO")>  _
        Public Property PRIO() As nullable (of int64)
            Get
                return _PRIO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Priority", value, "^[0-9\-]+$") then Exit Property
                _IsSetPRIO = True
                If loading Then
                  _PRIO = Value
                Else
                    if not _PRIO = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PRIO", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PRIO = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Planned Hours"),  _
         nType("Edm.Int64"),  _
         tab("Time Stamp"),  _
         Pos(135),  _
         twodBarcode("PLANNEDHOURS")>  _
        Public Property PLANNEDHOURS() As nullable (of int64)
            Get
                return _PLANNEDHOURS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Planned Hours", value, "^[0-9\-]+$") then Exit Property
                _IsSetPLANNEDHOURS = True
                If loading Then
                  _PLANNEDHOURS = Value
                Else
                    if not _PLANNEDHOURS = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PLANNEDHOURS", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PLANNEDHOURS = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Start Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Start Date"),  _
         Pos(140),  _
         [ReadOnly](true),  _
         twodBarcode("FROMDATE")>  _
        Public Property FROMDATE() As nullable (of DateTimeOffset)
            Get
                return _FROMDATE
            End Get
            Set
                if not(value is nothing) then
                  _FROMDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Complete by"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Start Date"),  _
         Pos(150),  _
         [ReadOnly](true),  _
         twodBarcode("TODATE")>  _
        Public Property TODATE() As nullable (of DateTimeOffset)
            Get
                return _TODATE
            End Get
            Set
                if not(value is nothing) then
                  _TODATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("In Use"),  _
         nType("Edm.String"),  _
         tab("Start Date"),  _
         Pos(160),  _
         [ReadOnly](true),  _
         twodBarcode("ACTIVE")>  _
        Public Property ACTIVE() As String
            Get
                return _ACTIVE
            End Get
            Set
                if not(value is nothing) then
                  _ACTIVE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Item Number"),  _
         nType("Edm.Int64"),  _
         tab("Start Date"),  _
         Pos(170),  _
         [ReadOnly](true),  _
         twodBarcode("TODOLIST")>  _
        Public Property TODOLIST() As nullable (of int64)
            Get
                return _TODOLIST
            End Get
            Set
                if not(value is nothing) then
                  _TODOLIST = Value
                end if
            End Set
        End Property
        
        <DisplayName("Status Duration-Hrs"),  _
         nType("Edm.String"),  _
         tab("Start Date"),  _
         Pos(180),  _
         [ReadOnly](true),  _
         twodBarcode("DURATION")>  _
        Public Property DURATION() As String
            Get
                return _DURATION
            End Get
            Set
                if not(value is nothing) then
                  _DURATION = Value
                end if
            End Set
        End Property
        
        <DisplayName("Status Duration-Days"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(6),  _
         tab("Start Date"),  _
         Pos(200),  _
         [ReadOnly](true),  _
         twodBarcode("DURATIONDAYS")>  _
        Public Property DURATIONDAYS() As nullable(of decimal)
            Get
                return _DURATIONDAYS
            End Get
            Set
                if not(value is nothing) then
                  _DURATIONDAYS = Value
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property DOCTODOLISTLOGTEXT_SUBFORM() As QUERY_DOCTODOLISTLOGTEXT
            Get
                return _DOCTODOLISTLOGTEXT_SUBFORM
            End Get
            Set
                _DOCTODOLISTLOGTEXT_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetDETAILS then
              if f then
                  jw.WriteRaw(", ""DETAILS"": ")
              else
                  jw.WriteRaw("""DETAILS"": ")
                  f = true
              end if
              jw.WriteValue(me.DETAILS)
            end if
            if _IsSetPRIO then
              if f then
                  jw.WriteRaw(", ""PRIO"": ")
              else
                  jw.WriteRaw("""PRIO"": ")
                  f = true
              end if
              jw.WriteValue(me.PRIO)
            end if
            if _IsSetPLANNEDHOURS then
              if f then
                  jw.WriteRaw(", ""PLANNEDHOURS"": ")
              else
                  jw.WriteRaw("""PLANNEDHOURS"": ")
                  f = true
              end if
              jw.WriteValue(me.PLANNEDHOURS)
            end if
            if _DOCTODOLISTLOGTEXT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", DOCTODOLISTLOGTEXT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as DOCTODOLISTLOGTEXT in _DOCTODOLISTLOGTEXT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _DOCTODOLISTLOGTEXT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "DOCTODOLISTLOG")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "TODOLIST")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetDETAILS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DETAILS")
              .WriteAttributeString("value", me.DETAILS)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "56")
              .WriteEndElement
            end if
            if _IsSetPRIO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PRIO")
              .WriteAttributeString("value", me.PRIO)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetPLANNEDHOURS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PLANNEDHOURS")
              .WriteAttributeString("value", me.PLANNEDHOURS)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _DOCTODOLISTLOGTEXT_SUBFORM.value.count > 0 then
              for each itm as DOCTODOLISTLOGTEXT in _DOCTODOLISTLOGTEXT_SUBFORM.Value
                itm.toXML(xw,"DOCTODOLISTLOGTEXT_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DOCTODOLISTLOG = JsonConvert.DeserializeObject(Of DOCTODOLISTLOG)(e.StreamReader.ReadToEnd)
                With obj
                  _UDATE = .UDATE
                  _STATDES = .STATDES
                  _OWNERLOGIN = .OWNERLOGIN
                  _INITIATORLOGIN = .INITIATORLOGIN
                  _USERLOGIN = .USERLOGIN
                  _DETAILS = .DETAILS
                  _PRIO = .PRIO
                  _PLANNEDHOURS = .PLANNEDHOURS
                  _FROMDATE = .FROMDATE
                  _TODATE = .TODATE
                  _ACTIVE = .ACTIVE
                  _TODOLIST = .TODOLIST
                  _DURATION = .DURATION
                  _DURATIONDAYS = .DURATIONDAYS
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_DOCTODOLISTLOG
        
        DOCTODOLISTLOGTEXT = 0
    End Enum
    
    <QueryTitle("To Do List - Remarks")>  _
    Public Class QUERY_DOCTODOLISTLOGTEXT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of DOCTODOLISTLOGTEXT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of DOCTODOLISTLOGTEXT)
            _Parent = nothing
            _Name = "DOCTODOLISTLOGTEXT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of DOCTODOLISTLOGTEXT)
            _Parent = Parent
            _name = "DOCTODOLISTLOGTEXT_SUBFORM"
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
        
        Public Property Value() As list(of DOCTODOLISTLOGTEXT)
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
                return GetType(DOCTODOLISTLOGTEXT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _DOCTODOLISTLOGTEXT As DOCTODOLISTLOGTEXT In JsonConvert.DeserializeObject(Of QUERY_DOCTODOLISTLOGTEXT)(stream.ReadToEnd).Value
              With _DOCTODOLISTLOGTEXT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_DOCTODOLISTLOGTEXT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DOCTODOLISTLOGTEXT = JsonConvert.DeserializeObject(Of DOCTODOLISTLOGTEXT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, DOCTODOLISTLOGTEXT)
                  .TEXT = obj.TEXT
                  .TEXTLINE = obj.TEXTLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new DOCTODOLISTLOGTEXT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _DOCTODOLISTLOGTEXT as DOCTODOLISTLOGTEXT in value
              If _DOCTODOLISTLOGTEXT.Equals(trycast(obj,DOCTODOLISTLOGTEXT)) Then
                  value.remove(_DOCTODOLISTLOGTEXT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class DOCTODOLISTLOGTEXT
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
                    return "DOCTODOLISTLOGTEXT"
                else
                    return "DOCTODOLISTLOGTEXT_SUBFORM"
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
        
        <DisplayName("TEXTLINE"),  _
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
                .WriteAttributeString("name", "DOCTODOLISTLOGTEXT")
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
                dim obj as DOCTODOLISTLOGTEXT = JsonConvert.DeserializeObject(Of DOCTODOLISTLOGTEXT)(e.StreamReader.ReadToEnd)
                With obj
                  _TEXT = .TEXT
                  _TEXTLINE = .TEXTLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Remarks")>  _
    Public Class QUERY_DOCUMENTSTEXT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of DOCUMENTSTEXT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of DOCUMENTSTEXT)
            _Parent = nothing
            _Name = "DOCUMENTSTEXT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of DOCUMENTSTEXT)
            _Parent = Parent
            _name = "DOCUMENTSTEXT_SUBFORM"
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
        
        Public Property Value() As list(of DOCUMENTSTEXT)
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
                return GetType(DOCUMENTSTEXT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _DOCUMENTSTEXT As DOCUMENTSTEXT In JsonConvert.DeserializeObject(Of QUERY_DOCUMENTSTEXT)(stream.ReadToEnd).Value
              With _DOCUMENTSTEXT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_DOCUMENTSTEXT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DOCUMENTSTEXT = JsonConvert.DeserializeObject(Of DOCUMENTSTEXT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, DOCUMENTSTEXT)
                  .TEXT = obj.TEXT
                  .TEXTLINE = obj.TEXTLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new DOCUMENTSTEXT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _DOCUMENTSTEXT as DOCUMENTSTEXT in value
              If _DOCUMENTSTEXT.Equals(trycast(obj,DOCUMENTSTEXT)) Then
                  value.remove(_DOCUMENTSTEXT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class DOCUMENTSTEXT
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
                    return "DOCUMENTSTEXT"
                else
                    return "DOCUMENTSTEXT_SUBFORM"
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
         Pos(10),  _
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
        
        <DisplayName("Line"),  _
         nType("Edm.Int64"),  _
         tab("Remarks"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("TEXTLINE")>  _
        Public Property TEXTLINE() As nullable (of int64)
            Get
                return _TEXTLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Line", value, "^[0-9\-]+$") then Exit Property
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
                .WriteAttributeString("name", "DOCUMENTSTEXT")
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
                dim obj as DOCUMENTSTEXT = JsonConvert.DeserializeObject(Of DOCUMENTSTEXT)(e.StreamReader.ReadToEnd)
                With obj
                  _TEXT = .TEXT
                  _TEXTLINE = .TEXTLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Warehouse Tasks Based on Documt")>  _
    Public Class QUERY_DOCTOWTASKS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of DOCTOWTASKS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of DOCTOWTASKS)
            _Parent = nothing
            _Name = "DOCTOWTASKS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of DOCTOWTASKS)
            _Parent = Parent
            _name = "DOCTOWTASKS_SUBFORM"
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
        
        Public Property Value() As list(of DOCTOWTASKS)
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
                return GetType(DOCTOWTASKS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _DOCTOWTASKS As DOCTOWTASKS In JsonConvert.DeserializeObject(Of QUERY_DOCTOWTASKS)(stream.ReadToEnd).Value
              With _DOCTOWTASKS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_DOCTOWTASKS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DOCTOWTASKS = JsonConvert.DeserializeObject(Of DOCTOWTASKS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, DOCTOWTASKS)
                  .WTASKNUM = obj.WTASKNUM
                  .WTASKTYPECODE = obj.WTASKTYPECODE
                  .WTASKTYPEDES = obj.WTASKTYPEDES
                  .STATDES = obj.STATDES
                  .WAVENUM = obj.WAVENUM
                  .WTASK = obj.WTASK
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new DOCTOWTASKS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _DOCTOWTASKS as DOCTOWTASKS in value
              If _DOCTOWTASKS.Equals(trycast(obj,DOCTOWTASKS)) Then
                  value.remove(_DOCTOWTASKS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class DOCTOWTASKS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _WTASKNUM As String
        
        Private _WTASKTYPECODE As String
        
        Private _WTASKTYPEDES As String
        
        Private _STATDES As String
        
        Private _WAVENUM As String
        
        Private _WTASK As Long
        
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
                    return "DOCTOWTASKS"
                else
                    return "DOCTOWTASKS_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "WTASKNUM={0}", _
                  string.format("'{0}'",WTASKNUM) _ 
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
        
        <DisplayName("Warehouse Task No."),  _
         nType("Edm.String"),  _
         tab("Warehouse Task No."),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("WTASKNUM")>  _
        Public Property WTASKNUM() As String
            Get
                return _WTASKNUM
            End Get
            Set
                if not(value is nothing) then
                  _WTASKNUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("Warehouse Task Type"),  _
         nType("Edm.String"),  _
         tab("Warehouse Task No."),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("WTASKTYPECODE")>  _
        Public Property WTASKTYPECODE() As String
            Get
                return _WTASKTYPECODE
            End Get
            Set
                if not(value is nothing) then
                  _WTASKTYPECODE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Task Type Desc."),  _
         nType("Edm.String"),  _
         tab("Warehouse Task No."),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("WTASKTYPEDES")>  _
        Public Property WTASKTYPEDES() As String
            Get
                return _WTASKTYPEDES
            End Get
            Set
                if not(value is nothing) then
                  _WTASKTYPEDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Status"),  _
         nType("Edm.String"),  _
         tab("Warehouse Task No."),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("STATDES")>  _
        Public Property STATDES() As String
            Get
                return _STATDES
            End Get
            Set
                if not(value is nothing) then
                  _STATDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Wave Number"),  _
         nType("Edm.String"),  _
         tab("Warehouse Task No."),  _
         Pos(50),  _
         [ReadOnly](true),  _
         twodBarcode("WAVENUM")>  _
        Public Property WAVENUM() As String
            Get
                return _WAVENUM
            End Get
            Set
                if not(value is nothing) then
                  _WAVENUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("Warehouse Task (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Warehouse Task No."),  _
         Pos(99),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("WTASK")>  _
        Public Property WTASK() As nullable (of int64)
            Get
                return _WTASK
            End Get
            Set
                if not(value is nothing) then
                  _WTASK = Value
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
                .WriteAttributeString("name", "DOCTOWTASKS")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "WTASKNUM")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DOCTOWTASKS = JsonConvert.DeserializeObject(Of DOCTOWTASKS)(e.StreamReader.ReadToEnd)
                With obj
                  _WTASKNUM = .WTASKNUM
                  _WTASKTYPECODE = .WTASKTYPECODE
                  _WTASKTYPEDES = .WTASKTYPEDES
                  _STATDES = .STATDES
                  _WAVENUM = .WAVENUM
                  _WTASK = .WTASK
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Delivery Scheduling Details")>  _
    Public Class QUERY_DISTRDETAILS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of DISTRDETAILS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of DISTRDETAILS)
            _Parent = nothing
            _Name = "DISTRDETAILS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of DISTRDETAILS)
            _Parent = Parent
            _name = "DISTRDETAILS_SUBFORM"
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
        
        Public Property Value() As list(of DISTRDETAILS)
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
                return GetType(DISTRDETAILS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _DISTRDETAILS As DISTRDETAILS In JsonConvert.DeserializeObject(Of QUERY_DISTRDETAILS)(stream.ReadToEnd).Value
              With _DISTRDETAILS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_DISTRDETAILS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DISTRDETAILS = JsonConvert.DeserializeObject(Of DISTRDETAILS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, DISTRDETAILS)
                  .DUEDATE = obj.DUEDATE
                  .DISTRLINECODE = obj.DISTRLINECODE
                  .DISTRLINEDES = obj.DISTRLINEDES
                  .ROUNDNUM = obj.ROUNDNUM
                  .DISTRORDER = obj.DISTRORDER
                  .PACKNUM = obj.PACKNUM
                  .PLTSNUM = obj.PLTSNUM
                  .CONTAINERNUM = obj.CONTAINERNUM
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new DISTRDETAILS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _DISTRDETAILS as DISTRDETAILS in value
              If _DISTRDETAILS.Equals(trycast(obj,DISTRDETAILS)) Then
                  value.remove(_DISTRDETAILS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class DISTRDETAILS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetDUEDATE As Boolean = Boolean.FalseString
        
        Private _DUEDATE As System.DateTimeOffset
        
        Private _IsSetDISTRLINECODE As Boolean = Boolean.FalseString
        
        Private _DISTRLINECODE As String
        
        Private _DISTRLINEDES As String
        
        Private _IsSetROUNDNUM As Boolean = Boolean.FalseString
        
        Private _ROUNDNUM As Long
        
        Private _IsSetDISTRORDER As Boolean = Boolean.FalseString
        
        Private _DISTRORDER As Long
        
        Private _IsSetPACKNUM As Boolean = Boolean.FalseString
        
        Private _PACKNUM As Long
        
        Private _IsSetPLTSNUM As Boolean = Boolean.FalseString
        
        Private _PLTSNUM As Long
        
        Private _IsSetCONTAINERNUM As Boolean = Boolean.FalseString
        
        Private _CONTAINERNUM As String
        
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
                    return "DISTRDETAILS"
                else
                    return "DISTRDETAILS_SUBFORM"
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
        
        <DisplayName("Delivery Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Delivery Date"),  _
         Pos(10),  _
         twodBarcode("DUEDATE")>  _
        Public Property DUEDATE() As nullable (of DateTimeOffset)
            Get
                return _DUEDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Delivery Date", value, "^.*$") then Exit Property
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
        
        <DisplayName("Distrib. Route Code"),  _
         nType("Edm.String"),  _
         tab("Delivery Date"),  _
         Pos(20),  _
         twodBarcode("DISTRLINECODE")>  _
        Public Property DISTRLINECODE() As String
            Get
                return _DISTRLINECODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Distrib. Route Code", value, "^.{0,3}$") then Exit Property
                _IsSetDISTRLINECODE = True
                If loading Then
                  _DISTRLINECODE = Value
                Else
                    if not _DISTRLINECODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("DISTRLINECODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _DISTRLINECODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Distrib. Route Desc."),  _
         nType("Edm.String"),  _
         tab("Delivery Date"),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("DISTRLINEDES")>  _
        Public Property DISTRLINEDES() As String
            Get
                return _DISTRLINEDES
            End Get
            Set
                if not(value is nothing) then
                  _DISTRLINEDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Round Number"),  _
         nType("Edm.Int64"),  _
         tab("Delivery Date"),  _
         Pos(40),  _
         twodBarcode("ROUNDNUM")>  _
        Public Property ROUNDNUM() As nullable (of int64)
            Get
                return _ROUNDNUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Round Number", value, "^[0-9\-]+$") then Exit Property
                _IsSetROUNDNUM = True
                If loading Then
                  _ROUNDNUM = Value
                Else
                    if not _ROUNDNUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ROUNDNUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ROUNDNUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Delivery Order"),  _
         nType("Edm.Int64"),  _
         tab("Delivery Date"),  _
         Pos(50),  _
         twodBarcode("DISTRORDER")>  _
        Public Property DISTRORDER() As nullable (of int64)
            Get
                return _DISTRORDER
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Delivery Order", value, "^[0-9\-]+$") then Exit Property
                _IsSetDISTRORDER = True
                If loading Then
                  _DISTRORDER = Value
                Else
                    if not _DISTRORDER = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("DISTRORDER", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _DISTRORDER = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Number of Crates"),  _
         nType("Edm.Int64"),  _
         tab("Delivery Date"),  _
         Pos(70),  _
         twodBarcode("PACKNUM")>  _
        Public Property PACKNUM() As nullable (of int64)
            Get
                return _PACKNUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Number of Crates", value, "^[0-9\-]+$") then Exit Property
                _IsSetPACKNUM = True
                If loading Then
                  _PACKNUM = Value
                Else
                    if not _PACKNUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PACKNUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PACKNUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Number of Pallets"),  _
         nType("Edm.Int64"),  _
         tab("Delivery Date"),  _
         Pos(75),  _
         twodBarcode("PLTSNUM")>  _
        Public Property PLTSNUM() As nullable (of int64)
            Get
                return _PLTSNUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Number of Pallets", value, "^[0-9\-]+$") then Exit Property
                _IsSetPLTSNUM = True
                If loading Then
                  _PLTSNUM = Value
                Else
                    if not _PLTSNUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PLTSNUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PLTSNUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Container Number"),  _
         nType("Edm.String"),  _
         tab("Delivery Date"),  _
         Pos(80),  _
         twodBarcode("CONTAINERNUM")>  _
        Public Property CONTAINERNUM() As String
            Get
                return _CONTAINERNUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Container Number", value, "^.{0,15}$") then Exit Property
                _IsSetCONTAINERNUM = True
                If loading Then
                  _CONTAINERNUM = Value
                Else
                    if not _CONTAINERNUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CONTAINERNUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CONTAINERNUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetDUEDATE then
              if f then
                  jw.WriteRaw(", ""DUEDATE"": ")
              else
                  jw.WriteRaw("""DUEDATE"": ")
                  f = true
              end if
              jw.WriteValue(me.DUEDATE)
            end if
            if _IsSetDISTRLINECODE then
              if f then
                  jw.WriteRaw(", ""DISTRLINECODE"": ")
              else
                  jw.WriteRaw("""DISTRLINECODE"": ")
                  f = true
              end if
              jw.WriteValue(me.DISTRLINECODE)
            end if
            if _IsSetROUNDNUM then
              if f then
                  jw.WriteRaw(", ""ROUNDNUM"": ")
              else
                  jw.WriteRaw("""ROUNDNUM"": ")
                  f = true
              end if
              jw.WriteValue(me.ROUNDNUM)
            end if
            if _IsSetDISTRORDER then
              if f then
                  jw.WriteRaw(", ""DISTRORDER"": ")
              else
                  jw.WriteRaw("""DISTRORDER"": ")
                  f = true
              end if
              jw.WriteValue(me.DISTRORDER)
            end if
            if _IsSetPACKNUM then
              if f then
                  jw.WriteRaw(", ""PACKNUM"": ")
              else
                  jw.WriteRaw("""PACKNUM"": ")
                  f = true
              end if
              jw.WriteValue(me.PACKNUM)
            end if
            if _IsSetPLTSNUM then
              if f then
                  jw.WriteRaw(", ""PLTSNUM"": ")
              else
                  jw.WriteRaw("""PLTSNUM"": ")
                  f = true
              end if
              jw.WriteValue(me.PLTSNUM)
            end if
            if _IsSetCONTAINERNUM then
              if f then
                  jw.WriteRaw(", ""CONTAINERNUM"": ")
              else
                  jw.WriteRaw("""CONTAINERNUM"": ")
                  f = true
              end if
              jw.WriteValue(me.CONTAINERNUM)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "DISTRDETAILS")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
            if _IsSetDUEDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DUEDATE")
              .WriteAttributeString("value", me.DUEDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetDISTRLINECODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DISTRLINECODE")
              .WriteAttributeString("value", me.DISTRLINECODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
            end if
            if _IsSetROUNDNUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ROUNDNUM")
              .WriteAttributeString("value", me.ROUNDNUM)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetDISTRORDER then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DISTRORDER")
              .WriteAttributeString("value", me.DISTRORDER)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetPACKNUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PACKNUM")
              .WriteAttributeString("value", me.PACKNUM)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetPLTSNUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PLTSNUM")
              .WriteAttributeString("value", me.PLTSNUM)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetCONTAINERNUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CONTAINERNUM")
              .WriteAttributeString("value", me.CONTAINERNUM)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "15")
              .WriteEndElement
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as DISTRDETAILS = JsonConvert.DeserializeObject(Of DISTRDETAILS)(e.StreamReader.ReadToEnd)
                With obj
                  _DUEDATE = .DUEDATE
                  _DISTRLINECODE = .DISTRLINECODE
                  _DISTRLINEDES = .DISTRLINEDES
                  _ROUNDNUM = .ROUNDNUM
                  _DISTRORDER = .DISTRORDER
                  _PACKNUM = .PACKNUM
                  _PLTSNUM = .PLTSNUM
                  _CONTAINERNUM = .CONTAINERNUM
                end with
            End If
        End Sub
    End Class
End Namespace
