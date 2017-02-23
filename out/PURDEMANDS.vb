Imports system
Imports system.IO
Imports system.xml
Imports System.Net
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Newtonsoft.Json

Namespace OData
    
    <QueryTitle("Purchase Demands")>  _
    Public Class QUERY_PURDEMANDS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PURDEMANDS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PURDEMANDS)
            _Parent = nothing
            _Name = "PURDEMANDS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Itemised Purchase Requisitions")
            .add(1, "Attachments")
            .add(2, "Projects/Accounts")
            .add(3, "Purchase Demand Authorisation")
            .add(4, "Tasks for Document")
            .add(5, "To Do Item")
            .add(6, "History of Statuses")
            .add(7, "History of Changes")
            .add(8, "Remarks")
            .add(9, "Internal Dialogue")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PURDEMANDS)
            _Parent = Parent
            _name = "PURDEMANDS_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Itemised Purchase Requisitions")
            .add(1, "Attachments")
            .add(2, "Projects/Accounts")
            .add(3, "Purchase Demand Authorisation")
            .add(4, "Tasks for Document")
            .add(5, "To Do Item")
            .add(6, "History of Statuses")
            .add(7, "History of Changes")
            .add(8, "Remarks")
            .add(9, "Internal Dialogue")
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
        
        Public Property Value() As list(of PURDEMANDS)
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
                return GetType(PURDEMANDS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PURDEMANDS As PURDEMANDS In JsonConvert.DeserializeObject(Of QUERY_PURDEMANDS)(stream.ReadToEnd).Value
              With _PURDEMANDS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PURDEMANDS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PURDEMANDS = JsonConvert.DeserializeObject(Of PURDEMANDS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PURDEMANDS)
                  .CURDATE = obj.CURDATE
                  .PRDNO = obj.PRDNO
                  .DEPTNAME = obj.DEPTNAME
                  .DEPTDES = obj.DEPTDES
                  .SUPNAME = obj.SUPNAME
                  .CDES = obj.CDES
                  .PROJDOCNO = obj.PROJDOCNO
                  .PROJDES = obj.PROJDES
                  .STATDES = obj.STATDES
                  .OWNERLOGIN = obj.OWNERLOGIN
                  .CLOSEDBOOL = obj.CLOSEDBOOL
                  .AUTO = obj.AUTO
                  .EXTFILEFLAG = obj.EXTFILEFLAG
                  .BRANCHNAME = obj.BRANCHNAME
                  .BRANCHDES = obj.BRANCHDES
                  .DOCNO = obj.DOCNO
                  .WARHSNAME = obj.WARHSNAME
                  .LOCNAME = obj.LOCNAME
                  .DETAILS = obj.DETAILS
                  .FORUSERLOGIN = obj.FORUSERLOGIN
                  .TYPECODE = obj.TYPECODE
                  .TYPEDES = obj.TYPEDES
                  .REASONCODE = obj.REASONCODE
                  .REASONDES = obj.REASONDES
                  .CODENAME = obj.CODENAME
                  .CODEDES = obj.CODEDES
                  .USERLOGIN = obj.USERLOGIN
                  .CONFIRMED = obj.CONFIRMED
                  .MAINCURTOTALPRICE = obj.MAINCURTOTALPRICE
                  .ESTIMATETOTALPRICE = obj.ESTIMATETOTALPRICE
                  .VAT = obj.VAT
                  .TOTPRICE = obj.TOTPRICE
                  .CURCODE = obj.CURCODE
                  .TAXCODE = obj.TAXCODE
                  .CASHFLOWFLAG = obj.CASHFLOWFLAG
                  .PORDTYPECODE = obj.PORDTYPECODE
                  .PORDTYPEDES = obj.PORDTYPEDES
                  .USERNAME = obj.USERNAME
                  .UDATE = obj.UDATE
                  .INITUSERLOGIN = obj.INITUSERLOGIN
                  .PURDEMAND = obj.PURDEMAND
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PURDEMANDS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PURDEMANDS as PURDEMANDS in value
              If _PURDEMANDS.Equals(trycast(obj,PURDEMANDS)) Then
                  value.remove(_PURDEMANDS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PURDEMANDS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetCURDATE As Boolean = Boolean.FalseString
        
        Private _CURDATE As System.DateTimeOffset
        
        Private _IsSetPRDNO As Boolean = Boolean.FalseString
        
        Private _PRDNO As String
        
        Private _IsSetDEPTNAME As Boolean = Boolean.FalseString
        
        Private _DEPTNAME As String
        
        Private _DEPTDES As String
        
        Private _IsSetSUPNAME As Boolean = Boolean.FalseString
        
        Private _SUPNAME As String
        
        Private _IsSetCDES As Boolean = Boolean.FalseString
        
        Private _CDES As String
        
        Private _IsSetPROJDOCNO As Boolean = Boolean.FalseString
        
        Private _PROJDOCNO As String
        
        Private _IsSetPROJDES As Boolean = Boolean.FalseString
        
        Private _PROJDES As String
        
        Private _IsSetSTATDES As Boolean = Boolean.FalseString
        
        Private _STATDES As String
        
        Private _IsSetOWNERLOGIN As Boolean = Boolean.FalseString
        
        Private _OWNERLOGIN As String
        
        Private _IsSetCLOSEDBOOL As Boolean = Boolean.FalseString
        
        Private _CLOSEDBOOL As String
        
        Private _AUTO As String
        
        Private _EXTFILEFLAG As String
        
        Private _IsSetBRANCHNAME As Boolean = Boolean.FalseString
        
        Private _BRANCHNAME As String
        
        Private _BRANCHDES As String
        
        Private _IsSetDOCNO As Boolean = Boolean.FalseString
        
        Private _DOCNO As String
        
        Private _IsSetWARHSNAME As Boolean = Boolean.FalseString
        
        Private _WARHSNAME As String
        
        Private _IsSetLOCNAME As Boolean = Boolean.FalseString
        
        Private _LOCNAME As String
        
        Private _IsSetDETAILS As Boolean = Boolean.FalseString
        
        Private _DETAILS As String
        
        Private _IsSetFORUSERLOGIN As Boolean = Boolean.FalseString
        
        Private _FORUSERLOGIN As String
        
        Private _IsSetTYPECODE As Boolean = Boolean.FalseString
        
        Private _TYPECODE As String
        
        Private _TYPEDES As String
        
        Private _IsSetREASONCODE As Boolean = Boolean.FalseString
        
        Private _REASONCODE As String
        
        Private _REASONDES As String
        
        Private _IsSetCODENAME As Boolean = Boolean.FalseString
        
        Private _CODENAME As String
        
        Private _CODEDES As String
        
        Private _USERLOGIN As String
        
        Private _CONFIRMED As String
        
        Private _MAINCURTOTALPRICE As Decimal
        
        Private _ESTIMATETOTALPRICE As Decimal
        
        Private _VAT As Decimal
        
        Private _TOTPRICE As Decimal
        
        Private _IsSetCURCODE As Boolean = Boolean.FalseString
        
        Private _CURCODE As String
        
        Private _IsSetTAXCODE As Boolean = Boolean.FalseString
        
        Private _TAXCODE As String
        
        Private _IsSetCASHFLOWFLAG As Boolean = Boolean.FalseString
        
        Private _CASHFLOWFLAG As String
        
        Private _IsSetPORDTYPECODE As Boolean = Boolean.FalseString
        
        Private _PORDTYPECODE As String
        
        Private _PORDTYPEDES As String
        
        Private _USERNAME As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _INITUSERLOGIN As String
        
        Private _IsSetPURDEMAND As Boolean = Boolean.FalseString
        
        Private _PURDEMAND As Long
        
        Private _PRDITEMS_SUBFORM As QUERY_PRDITEMS
        
        Private _EXTFILES_SUBFORM As QUERY_EXTFILES
        
        Private _PROJLINK_SUBFORM As QUERY_PROJLINK
        
        Private _PDUSER_SUBFORM As QUERY_PDUSER
        
        Private _GENCUSTNOTES_SUBFORM As QUERY_GENCUSTNOTES
        
        Private _DOCTODOLIST_SUBFORM As QUERY_DOCTODOLIST
        
        Private _DOCTODOLISTLOG_SUBFORM As QUERY_DOCTODOLISTLOG
        
        Private _PURD_CHANGES_LOG_SUBFORM As QUERY_PURD_CHANGES_LOG
        
        Private _PURDEMANDSTEXT_SUBFORM As QUERY_PURDEMANDSTEXT
        
        Private _INTERNALDIALOGTEXT_SUBFORM As QUERY_INTERNALDIALOGTEXT
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Itemised Purchase Requisitions"))
            ChildQuery.add(1, new oNavigation("Attachments"))
            ChildQuery.add(2, new oNavigation("Projects/Accounts"))
            ChildQuery.add(3, new oNavigation("Purchase Demand Authorisation"))
            ChildQuery.add(4, new oNavigation("Tasks for Document"))
            ChildQuery.add(5, new oNavigation("To Do Item"))
            ChildQuery.add(6, new oNavigation("History of Statuses"))
            ChildQuery.add(7, new oNavigation("History of Changes"))
            ChildQuery.add(8, new oNavigation("Remarks"))
            ChildQuery.add(9, new oNavigation("Internal Dialogue"))
            _PRDITEMS_SUBFORM = new QUERY_PRDITEMS(me)
            _EXTFILES_SUBFORM = new QUERY_EXTFILES(me)
            _PROJLINK_SUBFORM = new QUERY_PROJLINK(me)
            _PDUSER_SUBFORM = new QUERY_PDUSER(me)
            _GENCUSTNOTES_SUBFORM = new QUERY_GENCUSTNOTES(me)
            _DOCTODOLIST_SUBFORM = new QUERY_DOCTODOLIST(me)
            _DOCTODOLISTLOG_SUBFORM = new QUERY_DOCTODOLISTLOG(me)
            _PURD_CHANGES_LOG_SUBFORM = new QUERY_PURD_CHANGES_LOG(me)
            _PURDEMANDSTEXT_SUBFORM = new QUERY_PURDEMANDSTEXT(me)
            _INTERNALDIALOGTEXT_SUBFORM = new QUERY_INTERNALDIALOGTEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_PRDITEMS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_EXTFILES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_PROJLINK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_PDUSER_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_GENCUSTNOTES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(5)
               .setoDataQuery(_DOCTODOLIST_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(6)
               .setoDataQuery(_DOCTODOLISTLOG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(7)
               .setoDataQuery(_PURD_CHANGES_LOG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(8)
               .setoDataQuery(_PURDEMANDSTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(9)
               .setoDataQuery(_INTERNALDIALOGTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Itemised Purchase Requisitions"))
            ChildQuery.add(1, new oNavigation("Attachments"))
            ChildQuery.add(2, new oNavigation("Projects/Accounts"))
            ChildQuery.add(3, new oNavigation("Purchase Demand Authorisation"))
            ChildQuery.add(4, new oNavigation("Tasks for Document"))
            ChildQuery.add(5, new oNavigation("To Do Item"))
            ChildQuery.add(6, new oNavigation("History of Statuses"))
            ChildQuery.add(7, new oNavigation("History of Changes"))
            ChildQuery.add(8, new oNavigation("Remarks"))
            ChildQuery.add(9, new oNavigation("Internal Dialogue"))
            _PRDITEMS_SUBFORM = new QUERY_PRDITEMS(me)
            _EXTFILES_SUBFORM = new QUERY_EXTFILES(me)
            _PROJLINK_SUBFORM = new QUERY_PROJLINK(me)
            _PDUSER_SUBFORM = new QUERY_PDUSER(me)
            _GENCUSTNOTES_SUBFORM = new QUERY_GENCUSTNOTES(me)
            _DOCTODOLIST_SUBFORM = new QUERY_DOCTODOLIST(me)
            _DOCTODOLISTLOG_SUBFORM = new QUERY_DOCTODOLISTLOG(me)
            _PURD_CHANGES_LOG_SUBFORM = new QUERY_PURD_CHANGES_LOG(me)
            _PURDEMANDSTEXT_SUBFORM = new QUERY_PURDEMANDSTEXT(me)
            _INTERNALDIALOGTEXT_SUBFORM = new QUERY_INTERNALDIALOGTEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_PRDITEMS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_EXTFILES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_PROJLINK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_PDUSER_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_GENCUSTNOTES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(5)
               .setoDataQuery(_DOCTODOLIST_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(6)
               .setoDataQuery(_DOCTODOLISTLOG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(7)
               .setoDataQuery(_PURD_CHANGES_LOG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(8)
               .setoDataQuery(_PURDEMANDSTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(9)
               .setoDataQuery(_INTERNALDIALOGTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Itemised Purchase Requisitions", _PRDITEMS_SUBFORM))
                   .add(1, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(2, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(3, new oNavigation("Purchase Demand Authorisation", _PDUSER_SUBFORM))
                   .add(4, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(5, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(6, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(7, new oNavigation("History of Changes", _PURD_CHANGES_LOG_SUBFORM))
                   .add(8, new oNavigation("Remarks", _PURDEMANDSTEXT_SUBFORM))
                   .add(9, new oNavigation("Internal Dialogue", _INTERNALDIALOGTEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "PURDEMANDS"
                else
                    return "PURDEMANDS_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "PRDNO={0}", _
                  string.format("'{0}'",PRDNO) _ 
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
         Pos(2),  _
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
        
        <DisplayName("Purch Demand Doc No."),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(4),  _
         twodBarcode("PRDNO")>  _
        Public Property PRDNO() As String
            Get
                return _PRDNO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Purch Demand Doc No.", value, "^.{0,16}$") then Exit Property
                _IsSetPRDNO = True
                If loading Then
                  _PRDNO = Value
                Else
                    if not _PRDNO = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PRDNO", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PRDNO = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Department"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(6),  _
         twodBarcode("DEPTNAME")>  _
        Public Property DEPTNAME() As String
            Get
                return _DEPTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Department", value, "^.{0,6}$") then Exit Property
                _IsSetDEPTNAME = True
                If loading Then
                  _DEPTNAME = Value
                Else
                    if not _DEPTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("DEPTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _DEPTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Dept. Description"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(8),  _
         [ReadOnly](true),  _
         twodBarcode("DEPTDES")>  _
        Public Property DEPTDES() As String
            Get
                return _DEPTDES
            End Get
            Set
                if not(value is nothing) then
                  _DEPTDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Vendor Number"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(10),  _
         twodBarcode("SUPNAME")>  _
        Public Property SUPNAME() As String
            Get
                return _SUPNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Vendor Number", value, "^.{0,16}$") then Exit Property
                _IsSetSUPNAME = True
                If loading Then
                  _SUPNAME = Value
                Else
                    if not _SUPNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SUPNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SUPNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Vendor Name"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(12),  _
         twodBarcode("CDES")>  _
        Public Property CDES() As String
            Get
                return _CDES
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Vendor Name", value, "^.{0,48}$") then Exit Property
                _IsSetCDES = True
                If loading Then
                  _CDES = Value
                Else
                    if not _CDES = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CDES", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CDES = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Project Number"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(14),  _
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
         tab("Date"),  _
         Pos(16),  _
         twodBarcode("PROJDES")>  _
        Public Property PROJDES() As String
            Get
                return _PROJDES
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Project Description", value, "^.{0,32}$") then Exit Property
                _IsSetPROJDES = True
                If loading Then
                  _PROJDES = Value
                Else
                    if not _PROJDES = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PROJDES", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PROJDES = Value
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
        
        <DisplayName("Assigned to"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(19),  _
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
        
        <DisplayName("Closed?"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(20),  _
         twodBarcode("CLOSEDBOOL")>  _
        Public Property CLOSEDBOOL() As String
            Get
                return _CLOSEDBOOL
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Closed?", value, "^.{0,1}$") then Exit Property
                _IsSetCLOSEDBOOL = True
                If loading Then
                  _CLOSEDBOOL = Value
                Else
                    if not _CLOSEDBOOL = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CLOSEDBOOL", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CLOSEDBOOL = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Automatic"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(22),  _
         [ReadOnly](true),  _
         twodBarcode("AUTO")>  _
        Public Property [AUTO]() As String
            Get
                return _AUTO
            End Get
            Set
                if not(value is nothing) then
                  _AUTO = Value
                end if
            End Set
        End Property
        
        <DisplayName("Attachments?"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(24),  _
         [ReadOnly](true),  _
         twodBarcode("EXTFILEFLAG")>  _
        Public Property EXTFILEFLAG() As String
            Get
                return _EXTFILEFLAG
            End Get
            Set
                if not(value is nothing) then
                  _EXTFILEFLAG = Value
                end if
            End Set
        End Property
        
        <DisplayName("Branch Code"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(26),  _
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
         tab("Status"),  _
         Pos(28),  _
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
        
        <DisplayName("Service Call"),  _
         nType("Edm.String"),  _
         tab("Status"),  _
         Pos(30),  _
         twodBarcode("DOCNO")>  _
        Public Property DOCNO() As String
            Get
                return _DOCNO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Service Call", value, "^.{0,16}$") then Exit Property
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
        
        <DisplayName("Warehouse"),  _
         nType("Edm.String"),  _
         tab("Warehouse"),  _
         Pos(32),  _
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
         tab("Warehouse"),  _
         Pos(34),  _
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
        
        <DisplayName("Details"),  _
         nType("Edm.String"),  _
         tab("Warehouse"),  _
         Pos(36),  _
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
        
        <DisplayName("For User"),  _
         nType("Edm.String"),  _
         tab("Warehouse"),  _
         Pos(40),  _
         twodBarcode("FORUSERLOGIN")>  _
        Public Property FORUSERLOGIN() As String
            Get
                return _FORUSERLOGIN
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("For User", value, "^.{0,20}$") then Exit Property
                _IsSetFORUSERLOGIN = True
                If loading Then
                  _FORUSERLOGIN = Value
                Else
                    if not _FORUSERLOGIN = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FORUSERLOGIN", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FORUSERLOGIN = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Demand Type"),  _
         nType("Edm.String"),  _
         tab("Warehouse"),  _
         Pos(42),  _
         twodBarcode("TYPECODE")>  _
        Public Property TYPECODE() As String
            Get
                return _TYPECODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Demand Type", value, "^.{0,3}$") then Exit Property
                _IsSetTYPECODE = True
                If loading Then
                  _TYPECODE = Value
                Else
                    if not _TYPECODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TYPECODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TYPECODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Demand Type-Descrip"),  _
         nType("Edm.String"),  _
         tab("Warehouse"),  _
         Pos(43),  _
         [ReadOnly](true),  _
         twodBarcode("TYPEDES")>  _
        Public Property TYPEDES() As String
            Get
                return _TYPEDES
            End Get
            Set
                if not(value is nothing) then
                  _TYPEDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Demand Reason Code"),  _
         nType("Edm.String"),  _
         tab("Warehouse"),  _
         Pos(45),  _
         twodBarcode("REASONCODE")>  _
        Public Property REASONCODE() As String
            Get
                return _REASONCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Demand Reason Code", value, "^.{0,4}$") then Exit Property
                _IsSetREASONCODE = True
                If loading Then
                  _REASONCODE = Value
                Else
                    if not _REASONCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("REASONCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _REASONCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Demand Reason Desc."),  _
         nType("Edm.String"),  _
         tab("Warehouse"),  _
         Pos(47),  _
         [ReadOnly](true),  _
         twodBarcode("REASONDES")>  _
        Public Property REASONDES() As String
            Get
                return _REASONDES
            End Get
            Set
                if not(value is nothing) then
                  _REASONDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Authoriser List Code"),  _
         nType("Edm.String"),  _
         tab("Authoriser List Code"),  _
         Pos(50),  _
         twodBarcode("CODENAME")>  _
        Public Property CODENAME() As String
            Get
                return _CODENAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Authoriser List Code", value, "^.{0,3}$") then Exit Property
                _IsSetCODENAME = True
                If loading Then
                  _CODENAME = Value
                Else
                    if not _CODENAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CODENAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CODENAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("List Description"),  _
         nType("Edm.String"),  _
         tab("Authoriser List Code"),  _
         Pos(52),  _
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
        
        <DisplayName("Next Signature"),  _
         nType("Edm.String"),  _
         tab("Authoriser List Code"),  _
         Pos(54),  _
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
        
        <DisplayName("Authorised"),  _
         nType("Edm.String"),  _
         tab("Authoriser List Code"),  _
         Pos(56),  _
         [ReadOnly](true),  _
         twodBarcode("CONFIRMED")>  _
        Public Property CONFIRMED() As String
            Get
                return _CONFIRMED
            End Get
            Set
                if not(value is nothing) then
                  _CONFIRMED = Value
                end if
            End Set
        End Property
        
        <DisplayName("Total Cost ({L.F})"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(16),  _
         tab("Authoriser List Code"),  _
         Pos(57),  _
         [ReadOnly](true),  _
         twodBarcode("MAINCURTOTALPRICE")>  _
        Public Property MAINCURTOTALPRICE() As nullable(of decimal)
            Get
                return _MAINCURTOTALPRICE
            End Get
            Set
                if not(value is nothing) then
                  _MAINCURTOTALPRICE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Estimated Total Cost"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(16),  _
         tab("Authoriser List Code"),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("ESTIMATETOTALPRICE")>  _
        Public Property ESTIMATETOTALPRICE() As nullable(of decimal)
            Get
                return _ESTIMATETOTALPRICE
            End Get
            Set
                if not(value is nothing) then
                  _ESTIMATETOTALPRICE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Sales Tax"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(16),  _
         tab("Authoriser List Code"),  _
         Pos(63),  _
         [ReadOnly](true),  _
         twodBarcode("VAT")>  _
        Public Property VAT() As nullable(of decimal)
            Get
                return _VAT
            End Get
            Set
                if not(value is nothing) then
                  _VAT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Final Price"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(16),  _
         tab("Authoriser List Code"),  _
         Pos(66),  _
         [ReadOnly](true),  _
         twodBarcode("TOTPRICE")>  _
        Public Property TOTPRICE() As nullable(of decimal)
            Get
                return _TOTPRICE
            End Get
            Set
                if not(value is nothing) then
                  _TOTPRICE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Curr"),  _
         nType("Edm.String"),  _
         tab("Curr"),  _
         Pos(68),  _
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
        
        <DisplayName("Tax Code"),  _
         nType("Edm.String"),  _
         tab("Curr"),  _
         Pos(69),  _
         Mandatory(true),  _
         twodBarcode("TAXCODE")>  _
        Public Property TAXCODE() As String
            Get
                return _TAXCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Tax Code", value, "^.{0,8}$") then Exit Property
                _IsSetTAXCODE = True
                If loading Then
                  _TAXCODE = Value
                Else
                    if not _TAXCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TAXCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TAXCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Omit from Cash Flow?"),  _
         nType("Edm.String"),  _
         tab("Curr"),  _
         Pos(90),  _
         twodBarcode("CASHFLOWFLAG")>  _
        Public Property CASHFLOWFLAG() As String
            Get
                return _CASHFLOWFLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Omit from Cash Flow?", value, "^.{0,1}$") then Exit Property
                _IsSetCASHFLOWFLAG = True
                If loading Then
                  _CASHFLOWFLAG = Value
                Else
                    if not _CASHFLOWFLAG = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CASHFLOWFLAG", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CASHFLOWFLAG = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Type of Purch Order"),  _
         nType("Edm.String"),  _
         tab("Curr"),  _
         Pos(100),  _
         twodBarcode("PORDTYPECODE")>  _
        Public Property PORDTYPECODE() As String
            Get
                return _PORDTYPECODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Type of Purch Order", value, "^.{0,3}$") then Exit Property
                _IsSetPORDTYPECODE = True
                If loading Then
                  _PORDTYPECODE = Value
                Else
                    if not _PORDTYPECODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PORDTYPECODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PORDTYPECODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Description of Type"),  _
         nType("Edm.String"),  _
         tab("Curr"),  _
         Pos(110),  _
         [ReadOnly](true),  _
         twodBarcode("PORDTYPEDES")>  _
        Public Property PORDTYPEDES() As String
            Get
                return _PORDTYPEDES
            End Get
            Set
                if not(value is nothing) then
                  _PORDTYPEDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Curr"),  _
         Pos(200),  _
         [ReadOnly](true),  _
         twodBarcode("USERNAME")>  _
        Public Property USERNAME() As String
            Get
                return _USERNAME
            End Get
            Set
                if not(value is nothing) then
                  _USERNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Time Stamp"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Curr"),  _
         Pos(210),  _
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
        
        <DisplayName("Demand Initiator"),  _
         nType("Edm.String"),  _
         tab("Curr"),  _
         Pos(220),  _
         [ReadOnly](true),  _
         twodBarcode("INITUSERLOGIN")>  _
        Public Property INITUSERLOGIN() As String
            Get
                return _INITUSERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _INITUSERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("PR (ID)"),  _
         nType("Edm.Int64"),  _
         tab("PR (ID)"),  _
         Pos(10),  _
         Browsable(false),  _
         twodBarcode("PURDEMAND")>  _
        Public Property PURDEMAND() As nullable (of int64)
            Get
                return _PURDEMAND
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("PR (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetPURDEMAND = True
                If loading Then
                  _PURDEMAND = Value
                Else
                    if not _PURDEMAND = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PURDEMAND", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PURDEMAND = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property PRDITEMS_SUBFORM() As QUERY_PRDITEMS
            Get
                return _PRDITEMS_SUBFORM
            End Get
            Set
                _PRDITEMS_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property EXTFILES_SUBFORM() As QUERY_EXTFILES
            Get
                return _EXTFILES_SUBFORM
            End Get
            Set
                _EXTFILES_SUBFORM = value
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
        Public Property PDUSER_SUBFORM() As QUERY_PDUSER
            Get
                return _PDUSER_SUBFORM
            End Get
            Set
                _PDUSER_SUBFORM = value
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
        Public Property PURD_CHANGES_LOG_SUBFORM() As QUERY_PURD_CHANGES_LOG
            Get
                return _PURD_CHANGES_LOG_SUBFORM
            End Get
            Set
                _PURD_CHANGES_LOG_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property PURDEMANDSTEXT_SUBFORM() As QUERY_PURDEMANDSTEXT
            Get
                return _PURDEMANDSTEXT_SUBFORM
            End Get
            Set
                _PURDEMANDSTEXT_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property INTERNALDIALOGTEXT_SUBFORM() As QUERY_INTERNALDIALOGTEXT
            Get
                return _INTERNALDIALOGTEXT_SUBFORM
            End Get
            Set
                _INTERNALDIALOGTEXT_SUBFORM = value
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
            if _IsSetPRDNO then
              if f then
                  jw.WriteRaw(", ""PRDNO"": ")
              else
                  jw.WriteRaw("""PRDNO"": ")
                  f = true
              end if
              jw.WriteValue(me.PRDNO)
            end if
            if _IsSetDEPTNAME then
              if f then
                  jw.WriteRaw(", ""DEPTNAME"": ")
              else
                  jw.WriteRaw("""DEPTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.DEPTNAME)
            end if
            if _IsSetSUPNAME then
              if f then
                  jw.WriteRaw(", ""SUPNAME"": ")
              else
                  jw.WriteRaw("""SUPNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SUPNAME)
            end if
            if _IsSetCDES then
              if f then
                  jw.WriteRaw(", ""CDES"": ")
              else
                  jw.WriteRaw("""CDES"": ")
                  f = true
              end if
              jw.WriteValue(me.CDES)
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
            if _IsSetPROJDES then
              if f then
                  jw.WriteRaw(", ""PROJDES"": ")
              else
                  jw.WriteRaw("""PROJDES"": ")
                  f = true
              end if
              jw.WriteValue(me.PROJDES)
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
            if _IsSetCLOSEDBOOL then
              if f then
                  jw.WriteRaw(", ""CLOSEDBOOL"": ")
              else
                  jw.WriteRaw("""CLOSEDBOOL"": ")
                  f = true
              end if
              jw.WriteValue(me.CLOSEDBOOL)
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
            if _IsSetDOCNO then
              if f then
                  jw.WriteRaw(", ""DOCNO"": ")
              else
                  jw.WriteRaw("""DOCNO"": ")
                  f = true
              end if
              jw.WriteValue(me.DOCNO)
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
            if _IsSetDETAILS then
              if f then
                  jw.WriteRaw(", ""DETAILS"": ")
              else
                  jw.WriteRaw("""DETAILS"": ")
                  f = true
              end if
              jw.WriteValue(me.DETAILS)
            end if
            if _IsSetFORUSERLOGIN then
              if f then
                  jw.WriteRaw(", ""FORUSERLOGIN"": ")
              else
                  jw.WriteRaw("""FORUSERLOGIN"": ")
                  f = true
              end if
              jw.WriteValue(me.FORUSERLOGIN)
            end if
            if _IsSetTYPECODE then
              if f then
                  jw.WriteRaw(", ""TYPECODE"": ")
              else
                  jw.WriteRaw("""TYPECODE"": ")
                  f = true
              end if
              jw.WriteValue(me.TYPECODE)
            end if
            if _IsSetREASONCODE then
              if f then
                  jw.WriteRaw(", ""REASONCODE"": ")
              else
                  jw.WriteRaw("""REASONCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.REASONCODE)
            end if
            if _IsSetCODENAME then
              if f then
                  jw.WriteRaw(", ""CODENAME"": ")
              else
                  jw.WriteRaw("""CODENAME"": ")
                  f = true
              end if
              jw.WriteValue(me.CODENAME)
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
            if _IsSetTAXCODE then
              if f then
                  jw.WriteRaw(", ""TAXCODE"": ")
              else
                  jw.WriteRaw("""TAXCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.TAXCODE)
            end if
            if _IsSetCASHFLOWFLAG then
              if f then
                  jw.WriteRaw(", ""CASHFLOWFLAG"": ")
              else
                  jw.WriteRaw("""CASHFLOWFLAG"": ")
                  f = true
              end if
              jw.WriteValue(me.CASHFLOWFLAG)
            end if
            if _IsSetPORDTYPECODE then
              if f then
                  jw.WriteRaw(", ""PORDTYPECODE"": ")
              else
                  jw.WriteRaw("""PORDTYPECODE"": ")
                  f = true
              end if
              jw.WriteValue(me.PORDTYPECODE)
            end if
            if _IsSetPURDEMAND then
              if f then
                  jw.WriteRaw(", ""PURDEMAND"": ")
              else
                  jw.WriteRaw("""PURDEMAND"": ")
                  f = true
              end if
              jw.WriteValue(me.PURDEMAND)
            end if
            if _PRDITEMS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", PRDITEMS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as PRDITEMS in _PRDITEMS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _PRDITEMS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _EXTFILES_SUBFORM.value.count > 0 then
              jw.WriteRaw(", EXTFILES_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as EXTFILES in _EXTFILES_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _EXTFILES_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
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
            if _PDUSER_SUBFORM.value.count > 0 then
              jw.WriteRaw(", PDUSER_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as PDUSER in _PDUSER_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _PDUSER_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
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
            if _PURD_CHANGES_LOG_SUBFORM.value.count > 0 then
              jw.WriteRaw(", PURD_CHANGES_LOG_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as PURD_CHANGES_LOG in _PURD_CHANGES_LOG_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _PURD_CHANGES_LOG_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _PURDEMANDSTEXT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", PURDEMANDSTEXT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as PURDEMANDSTEXT in _PURDEMANDSTEXT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _PURDEMANDSTEXT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _INTERNALDIALOGTEXT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", INTERNALDIALOGTEXT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as INTERNALDIALOGTEXT in _INTERNALDIALOGTEXT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _INTERNALDIALOGTEXT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "PURDEMANDS")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "PRDNO")
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
            if _IsSetPRDNO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PRDNO")
              .WriteAttributeString("value", me.PRDNO)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetDEPTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DEPTNAME")
              .WriteAttributeString("value", me.DEPTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "6")
              .WriteEndElement
            end if
            if _IsSetSUPNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SUPNAME")
              .WriteAttributeString("value", me.SUPNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetCDES then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CDES")
              .WriteAttributeString("value", me.CDES)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "48")
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
            if _IsSetPROJDES then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PROJDES")
              .WriteAttributeString("value", me.PROJDES)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "32")
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
            if _IsSetCLOSEDBOOL then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CLOSEDBOOL")
              .WriteAttributeString("value", me.CLOSEDBOOL)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
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
            if _IsSetDOCNO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DOCNO")
              .WriteAttributeString("value", me.DOCNO)
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
            if _IsSetDETAILS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DETAILS")
              .WriteAttributeString("value", me.DETAILS)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "24")
              .WriteEndElement
            end if
            if _IsSetFORUSERLOGIN then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FORUSERLOGIN")
              .WriteAttributeString("value", me.FORUSERLOGIN)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
              .WriteEndElement
            end if
            if _IsSetTYPECODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TYPECODE")
              .WriteAttributeString("value", me.TYPECODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
            end if
            if _IsSetREASONCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REASONCODE")
              .WriteAttributeString("value", me.REASONCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "4")
              .WriteEndElement
            end if
            if _IsSetCODENAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CODENAME")
              .WriteAttributeString("value", me.CODENAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
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
            if _IsSetTAXCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TAXCODE")
              .WriteAttributeString("value", me.TAXCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "8")
              .WriteEndElement
            end if
            if _IsSetCASHFLOWFLAG then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CASHFLOWFLAG")
              .WriteAttributeString("value", me.CASHFLOWFLAG)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetPORDTYPECODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PORDTYPECODE")
              .WriteAttributeString("value", me.PORDTYPECODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
            end if
            if _IsSetPURDEMAND then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PURDEMAND")
              .WriteAttributeString("value", me.PURDEMAND)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _PRDITEMS_SUBFORM.value.count > 0 then
              for each itm as PRDITEMS in _PRDITEMS_SUBFORM.Value
                itm.toXML(xw,"PRDITEMS_SUBFORM")
              next
            end if
            if _EXTFILES_SUBFORM.value.count > 0 then
              for each itm as EXTFILES in _EXTFILES_SUBFORM.Value
                itm.toXML(xw,"EXTFILES_SUBFORM")
              next
            end if
            if _PROJLINK_SUBFORM.value.count > 0 then
              for each itm as PROJLINK in _PROJLINK_SUBFORM.Value
                itm.toXML(xw,"PROJLINK_SUBFORM")
              next
            end if
            if _PDUSER_SUBFORM.value.count > 0 then
              for each itm as PDUSER in _PDUSER_SUBFORM.Value
                itm.toXML(xw,"PDUSER_SUBFORM")
              next
            end if
            if _GENCUSTNOTES_SUBFORM.value.count > 0 then
              for each itm as GENCUSTNOTES in _GENCUSTNOTES_SUBFORM.Value
                itm.toXML(xw,"GENCUSTNOTES_SUBFORM")
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
            if _PURD_CHANGES_LOG_SUBFORM.value.count > 0 then
              for each itm as PURD_CHANGES_LOG in _PURD_CHANGES_LOG_SUBFORM.Value
                itm.toXML(xw,"PURD_CHANGES_LOG_SUBFORM")
              next
            end if
            if _PURDEMANDSTEXT_SUBFORM.value.count > 0 then
              for each itm as PURDEMANDSTEXT in _PURDEMANDSTEXT_SUBFORM.Value
                itm.toXML(xw,"PURDEMANDSTEXT_SUBFORM")
              next
            end if
            if _INTERNALDIALOGTEXT_SUBFORM.value.count > 0 then
              for each itm as INTERNALDIALOGTEXT in _INTERNALDIALOGTEXT_SUBFORM.Value
                itm.toXML(xw,"INTERNALDIALOGTEXT_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PURDEMANDS = JsonConvert.DeserializeObject(Of PURDEMANDS)(e.StreamReader.ReadToEnd)
                With obj
                  _CURDATE = .CURDATE
                  _PRDNO = .PRDNO
                  _DEPTNAME = .DEPTNAME
                  _DEPTDES = .DEPTDES
                  _SUPNAME = .SUPNAME
                  _CDES = .CDES
                  _PROJDOCNO = .PROJDOCNO
                  _PROJDES = .PROJDES
                  _STATDES = .STATDES
                  _OWNERLOGIN = .OWNERLOGIN
                  _CLOSEDBOOL = .CLOSEDBOOL
                  _AUTO = .AUTO
                  _EXTFILEFLAG = .EXTFILEFLAG
                  _BRANCHNAME = .BRANCHNAME
                  _BRANCHDES = .BRANCHDES
                  _DOCNO = .DOCNO
                  _WARHSNAME = .WARHSNAME
                  _LOCNAME = .LOCNAME
                  _DETAILS = .DETAILS
                  _FORUSERLOGIN = .FORUSERLOGIN
                  _TYPECODE = .TYPECODE
                  _TYPEDES = .TYPEDES
                  _REASONCODE = .REASONCODE
                  _REASONDES = .REASONDES
                  _CODENAME = .CODENAME
                  _CODEDES = .CODEDES
                  _USERLOGIN = .USERLOGIN
                  _CONFIRMED = .CONFIRMED
                  _MAINCURTOTALPRICE = .MAINCURTOTALPRICE
                  _ESTIMATETOTALPRICE = .ESTIMATETOTALPRICE
                  _VAT = .VAT
                  _TOTPRICE = .TOTPRICE
                  _CURCODE = .CURCODE
                  _TAXCODE = .TAXCODE
                  _CASHFLOWFLAG = .CASHFLOWFLAG
                  _PORDTYPECODE = .PORDTYPECODE
                  _PORDTYPEDES = .PORDTYPEDES
                  _USERNAME = .USERNAME
                  _UDATE = .UDATE
                  _INITUSERLOGIN = .INITUSERLOGIN
                  _PURDEMAND = .PURDEMAND
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_PURDEMANDS
        
        PRDITEMS = 0
        
        EXTFILES = 1
        
        PROJLINK = 2
        
        PDUSER = 3
        
        GENCUSTNOTES = 4
        
        DOCTODOLIST = 5
        
        DOCTODOLISTLOG = 6
        
        PURD_CHANGES_LOG = 7
        
        PURDEMANDSTEXT = 8
        
        INTERNALDIALOGTEXT = 9
    End Enum
    
    <QueryTitle("Itemised Purchase Requisitions")>  _
    Public Class QUERY_PRDITEMS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PRDITEMS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PRDITEMS)
            _Parent = nothing
            _Name = "PRDITEMS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Projects/Accounts")
            .add(1, "Part Price Options")
            .add(2, "Budgeted vs. Actual")
            .add(3, "Price Quotes for PR")
            .add(4, "Purchase Requisition - Remarks")
            .add(5, "Electronic Signature")
            .add(6, "RFQs for this Vendor and Part")
            .add(7, "Split Among Profit/Cost Centers")
            .add(8, "History of Changes")
            .add(9, "Projected Balances (fact. units)")
            .add(10, "Projected Balances (buy/sell)")
            .add(11, "MRP Analysis - Raw Materials")
            .add(12, "MRP Analysis - Processed Parts")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PRDITEMS)
            _Parent = Parent
            _name = "PRDITEMS_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Projects/Accounts")
            .add(1, "Part Price Options")
            .add(2, "Budgeted vs. Actual")
            .add(3, "Price Quotes for PR")
            .add(4, "Purchase Requisition - Remarks")
            .add(5, "Electronic Signature")
            .add(6, "RFQs for this Vendor and Part")
            .add(7, "Split Among Profit/Cost Centers")
            .add(8, "History of Changes")
            .add(9, "Projected Balances (fact. units)")
            .add(10, "Projected Balances (buy/sell)")
            .add(11, "MRP Analysis - Raw Materials")
            .add(12, "MRP Analysis - Processed Parts")
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
        
        Public Property Value() As list(of PRDITEMS)
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
                return GetType(PRDITEMS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PRDITEMS As PRDITEMS In JsonConvert.DeserializeObject(Of QUERY_PRDITEMS)(stream.ReadToEnd).Value
              With _PRDITEMS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PRDITEMS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PRDITEMS = JsonConvert.DeserializeObject(Of PRDITEMS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PRDITEMS)
                  .PARTNAME = obj.PARTNAME
                  .PDES = obj.PDES
                  .TQUANT = obj.TQUANT
                  .TUNITNAME = obj.TUNITNAME
                  .ISSDATE = obj.ISSDATE
                  .MNFNAME = obj.MNFNAME
                  .MNFPARTNAME = obj.MNFPARTNAME
                  .NUMPACK = obj.NUMPACK
                  .PACKCODE = obj.PACKCODE
                  .DUEDATE = obj.DUEDATE
                  .DUEDUEDATE = obj.DUEDUEDATE
                  .RECOMDATE = obj.RECOMDATE
                  .BUYERLOGIN = obj.BUYERLOGIN
                  .PARTSUPNAME = obj.PARTSUPNAME
                  .SUPNAME = obj.SUPNAME
                  .SUPPARTNAME = obj.SUPPARTNAME
                  .PROFNUM = obj.PROFNUM
                  .PLINE = obj.PLINE
                  .ORDNAME = obj.ORDNAME
                  .CORDNAME = obj.CORDNAME
                  .CORDLINE = obj.CORDLINE
                  .BUDCODE = obj.BUDCODE
                  .COSTCNAME = obj.COSTCNAME
                  .PRDI = obj.PRDI
                  .QUANT = obj.QUANT
                  .CLOSEDBOOL = obj.CLOSEDBOOL
                  .UNITNAME = obj.UNITNAME
                  .PRICE = obj.PRICE
                  .ICODE = obj.ICODE
                  .ESTIMATEPRICE = obj.ESTIMATEPRICE
                  .CODE = obj.CODE
                  .COPYPRICEFLAG = obj.COPYPRICEFLAG
                  .PRSOURCENAME = obj.PRSOURCENAME
                  .EXCH = obj.EXCH
                  .AUTO = obj.AUTO
                  .PROFOPENED = obj.PROFOPENED
                  .SERIALNAME = obj.SERIALNAME
                  .NOTICEFLAG = obj.NOTICEFLAG
                  .NOOPENORD = obj.NOOPENORD
                  .OPENPDPROF = obj.OPENPDPROF
                  .ORIGPRDI = obj.ORIGPRDI
                  .ORIGTQUANT = obj.ORIGTQUANT
                  .FORSERIALNAME = obj.FORSERIALNAME
                  .KLINE = obj.KLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PRDITEMS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PRDITEMS as PRDITEMS in value
              If _PRDITEMS.Equals(trycast(obj,PRDITEMS)) Then
                  value.remove(_PRDITEMS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PRDITEMS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetPARTNAME As Boolean = Boolean.FalseString
        
        Private _PARTNAME As String
        
        Private _IsSetPDES As Boolean = Boolean.FalseString
        
        Private _PDES As String
        
        Private _IsSetTQUANT As Boolean = Boolean.FalseString
        
        Private _TQUANT As Decimal
        
        Private _TUNITNAME As String
        
        Private _IsSetISSDATE As Boolean = Boolean.FalseString
        
        Private _ISSDATE As System.DateTimeOffset
        
        Private _IsSetMNFNAME As Boolean = Boolean.FalseString
        
        Private _MNFNAME As String
        
        Private _MNFPARTNAME As String
        
        Private _IsSetNUMPACK As Boolean = Boolean.FalseString
        
        Private _NUMPACK As Long
        
        Private _IsSetPACKCODE As Boolean = Boolean.FalseString
        
        Private _PACKCODE As String
        
        Private _IsSetDUEDATE As Boolean = Boolean.FalseString
        
        Private _DUEDATE As System.DateTimeOffset
        
        Private _DUEDUEDATE As System.DateTimeOffset
        
        Private _RECOMDATE As System.DateTimeOffset
        
        Private _IsSetBUYERLOGIN As Boolean = Boolean.FalseString
        
        Private _BUYERLOGIN As String
        
        Private _PARTSUPNAME As String
        
        Private _IsSetSUPNAME As Boolean = Boolean.FalseString
        
        Private _SUPNAME As String
        
        Private _IsSetSUPPARTNAME As Boolean = Boolean.FalseString
        
        Private _SUPPARTNAME As String
        
        Private _IsSetPROFNUM As Boolean = Boolean.FalseString
        
        Private _PROFNUM As String
        
        Private _IsSetPLINE As Boolean = Boolean.FalseString
        
        Private _PLINE As Long
        
        Private _ORDNAME As String
        
        Private _CORDNAME As String
        
        Private _IsSetCORDLINE As Boolean = Boolean.FalseString
        
        Private _CORDLINE As Long
        
        Private _IsSetBUDCODE As Boolean = Boolean.FalseString
        
        Private _BUDCODE As String
        
        Private _IsSetCOSTCNAME As Boolean = Boolean.FalseString
        
        Private _COSTCNAME As String
        
        Private _PRDI As Long
        
        Private _IsSetQUANT As Boolean = Boolean.FalseString
        
        Private _QUANT As Decimal
        
        Private _IsSetCLOSEDBOOL As Boolean = Boolean.FalseString
        
        Private _CLOSEDBOOL As String
        
        Private _UNITNAME As String
        
        Private _IsSetPRICE As Boolean = Boolean.FalseString
        
        Private _PRICE As Decimal
        
        Private _IsSetICODE As Boolean = Boolean.FalseString
        
        Private _ICODE As String
        
        Private _ESTIMATEPRICE As Decimal
        
        Private _CODE As String
        
        Private _IsSetCOPYPRICEFLAG As Boolean = Boolean.FalseString
        
        Private _COPYPRICEFLAG As String
        
        Private _PRSOURCENAME As String
        
        Private _IsSetEXCH As Boolean = Boolean.FalseString
        
        Private _EXCH As Decimal
        
        Private _AUTO As String
        
        Private _IsSetPROFOPENED As Boolean = Boolean.FalseString
        
        Private _PROFOPENED As String
        
        Private _IsSetSERIALNAME As Boolean = Boolean.FalseString
        
        Private _SERIALNAME As String
        
        Private _IsSetNOTICEFLAG As Boolean = Boolean.FalseString
        
        Private _NOTICEFLAG As String
        
        Private _IsSetNOOPENORD As Boolean = Boolean.FalseString
        
        Private _NOOPENORD As String
        
        Private _IsSetOPENPDPROF As Boolean = Boolean.FalseString
        
        Private _OPENPDPROF As String
        
        Private _ORIGPRDI As Long
        
        Private _ORIGTQUANT As Decimal
        
        Private _IsSetFORSERIALNAME As Boolean = Boolean.FalseString
        
        Private _FORSERIALNAME As String
        
        Private _IsSetKLINE As Boolean = Boolean.FalseString
        
        Private _KLINE As Long
        
        Private _PROJLINK_SUBFORM As QUERY_PROJLINK
        
        Private _PRICEOPTIONS_SUBFORM As QUERY_PRICEOPTIONS
        
        Private _BUDGETREP_SUBFORM As QUERY_BUDGETREP
        
        Private _PRDIPPROFI_SUBFORM As QUERY_PRDIPPROFI
        
        Private _PRDITEMSTEXT_SUBFORM As QUERY_PRDITEMSTEXT
        
        Private _PRDITEMSSIGN_SUBFORM As QUERY_PRDITEMSSIGN
        
        Private _PARTPDPROFITEMS_SUBFORM As QUERY_PARTPDPROFITEMS
        
        Private _SPLITCOSTCENTERS_SUBFORM As QUERY_SPLITCOSTCENTERS
        
        Private _CHANGESITEMS_LOG_SUBFORM As QUERY_CHANGESITEMS_LOG
        
        Private _PRDLOG_SUBFORM As QUERY_PRDLOG
        
        Private _PRDLOGPUR_SUBFORM As QUERY_PRDLOGPUR
        
        Private _MRPDEMANDRAW_SUBFORM As QUERY_MRPDEMANDRAW
        
        Private _MRPDEMAND_SUBFORM As QUERY_MRPDEMAND
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Projects/Accounts"))
            ChildQuery.add(1, new oNavigation("Part Price Options"))
            ChildQuery.add(2, new oNavigation("Budgeted vs. Actual"))
            ChildQuery.add(3, new oNavigation("Price Quotes for PR"))
            ChildQuery.add(4, new oNavigation("Purchase Requisition - Remarks"))
            ChildQuery.add(5, new oNavigation("Electronic Signature"))
            ChildQuery.add(6, new oNavigation("RFQs for this Vendor and Part"))
            ChildQuery.add(7, new oNavigation("Split Among Profit/Cost Centers"))
            ChildQuery.add(8, new oNavigation("History of Changes"))
            ChildQuery.add(9, new oNavigation("Projected Balances (fact. units)"))
            ChildQuery.add(10, new oNavigation("Projected Balances (buy/sell)"))
            ChildQuery.add(11, new oNavigation("MRP Analysis - Raw Materials"))
            ChildQuery.add(12, new oNavigation("MRP Analysis - Processed Parts"))
            _PROJLINK_SUBFORM = new QUERY_PROJLINK(me)
            _PRICEOPTIONS_SUBFORM = new QUERY_PRICEOPTIONS(me)
            _BUDGETREP_SUBFORM = new QUERY_BUDGETREP(me)
            _PRDIPPROFI_SUBFORM = new QUERY_PRDIPPROFI(me)
            _PRDITEMSTEXT_SUBFORM = new QUERY_PRDITEMSTEXT(me)
            _PRDITEMSSIGN_SUBFORM = new QUERY_PRDITEMSSIGN(me)
            _PARTPDPROFITEMS_SUBFORM = new QUERY_PARTPDPROFITEMS(me)
            _SPLITCOSTCENTERS_SUBFORM = new QUERY_SPLITCOSTCENTERS(me)
            _CHANGESITEMS_LOG_SUBFORM = new QUERY_CHANGESITEMS_LOG(me)
            _PRDLOG_SUBFORM = new QUERY_PRDLOG(me)
            _PRDLOGPUR_SUBFORM = new QUERY_PRDLOGPUR(me)
            _MRPDEMANDRAW_SUBFORM = new QUERY_MRPDEMANDRAW(me)
            _MRPDEMAND_SUBFORM = new QUERY_MRPDEMAND(me)
            WITH ChildQuery(0)
               .setoDataQuery(_PROJLINK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_PRICEOPTIONS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_BUDGETREP_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_PRDIPPROFI_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_PRDITEMSTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(5)
               .setoDataQuery(_PRDITEMSSIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(6)
               .setoDataQuery(_PARTPDPROFITEMS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(7)
               .setoDataQuery(_SPLITCOSTCENTERS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(8)
               .setoDataQuery(_CHANGESITEMS_LOG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(9)
               .setoDataQuery(_PRDLOG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(10)
               .setoDataQuery(_PRDLOGPUR_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(11)
               .setoDataQuery(_MRPDEMANDRAW_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(12)
               .setoDataQuery(_MRPDEMAND_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Projects/Accounts"))
            ChildQuery.add(1, new oNavigation("Part Price Options"))
            ChildQuery.add(2, new oNavigation("Budgeted vs. Actual"))
            ChildQuery.add(3, new oNavigation("Price Quotes for PR"))
            ChildQuery.add(4, new oNavigation("Purchase Requisition - Remarks"))
            ChildQuery.add(5, new oNavigation("Electronic Signature"))
            ChildQuery.add(6, new oNavigation("RFQs for this Vendor and Part"))
            ChildQuery.add(7, new oNavigation("Split Among Profit/Cost Centers"))
            ChildQuery.add(8, new oNavigation("History of Changes"))
            ChildQuery.add(9, new oNavigation("Projected Balances (fact. units)"))
            ChildQuery.add(10, new oNavigation("Projected Balances (buy/sell)"))
            ChildQuery.add(11, new oNavigation("MRP Analysis - Raw Materials"))
            ChildQuery.add(12, new oNavigation("MRP Analysis - Processed Parts"))
            _PROJLINK_SUBFORM = new QUERY_PROJLINK(me)
            _PRICEOPTIONS_SUBFORM = new QUERY_PRICEOPTIONS(me)
            _BUDGETREP_SUBFORM = new QUERY_BUDGETREP(me)
            _PRDIPPROFI_SUBFORM = new QUERY_PRDIPPROFI(me)
            _PRDITEMSTEXT_SUBFORM = new QUERY_PRDITEMSTEXT(me)
            _PRDITEMSSIGN_SUBFORM = new QUERY_PRDITEMSSIGN(me)
            _PARTPDPROFITEMS_SUBFORM = new QUERY_PARTPDPROFITEMS(me)
            _SPLITCOSTCENTERS_SUBFORM = new QUERY_SPLITCOSTCENTERS(me)
            _CHANGESITEMS_LOG_SUBFORM = new QUERY_CHANGESITEMS_LOG(me)
            _PRDLOG_SUBFORM = new QUERY_PRDLOG(me)
            _PRDLOGPUR_SUBFORM = new QUERY_PRDLOGPUR(me)
            _MRPDEMANDRAW_SUBFORM = new QUERY_MRPDEMANDRAW(me)
            _MRPDEMAND_SUBFORM = new QUERY_MRPDEMAND(me)
            WITH ChildQuery(0)
               .setoDataQuery(_PROJLINK_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_PRICEOPTIONS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_BUDGETREP_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_PRDIPPROFI_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_PRDITEMSTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(5)
               .setoDataQuery(_PRDITEMSSIGN_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(6)
               .setoDataQuery(_PARTPDPROFITEMS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(7)
               .setoDataQuery(_SPLITCOSTCENTERS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(8)
               .setoDataQuery(_CHANGESITEMS_LOG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(9)
               .setoDataQuery(_PRDLOG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(10)
               .setoDataQuery(_PRDLOGPUR_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(11)
               .setoDataQuery(_MRPDEMANDRAW_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
            WITH ChildQuery(12)
               .setoDataQuery(_MRPDEMAND_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Projects/Accounts", _PROJLINK_SUBFORM))
                   .add(1, new oNavigation("Part Price Options", _PRICEOPTIONS_SUBFORM))
                   .add(2, new oNavigation("Budgeted vs. Actual", _BUDGETREP_SUBFORM))
                   .add(3, new oNavigation("Price Quotes for PR", _PRDIPPROFI_SUBFORM))
                   .add(4, new oNavigation("Purchase Requisition - Remarks", _PRDITEMSTEXT_SUBFORM))
                   .add(5, new oNavigation("Electronic Signature", _PRDITEMSSIGN_SUBFORM))
                   .add(6, new oNavigation("RFQs for this Vendor and Part", _PARTPDPROFITEMS_SUBFORM))
                   .add(7, new oNavigation("Split Among Profit/Cost Centers", _SPLITCOSTCENTERS_SUBFORM))
                   .add(8, new oNavigation("History of Changes", _CHANGESITEMS_LOG_SUBFORM))
                   .add(9, new oNavigation("Projected Balances (fact. units)", _PRDLOG_SUBFORM))
                   .add(10, new oNavigation("Projected Balances (buy/sell)", _PRDLOGPUR_SUBFORM))
                   .add(11, new oNavigation("MRP Analysis - Raw Materials", _MRPDEMANDRAW_SUBFORM))
                   .add(12, new oNavigation("MRP Analysis - Processed Parts", _MRPDEMAND_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "PRDITEMS"
                else
                    return "PRDITEMS_SUBFORM"
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
        
        <DisplayName("Part Number"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(2),  _
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
         Pos(3),  _
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
        
        <DisplayName("Quantity to Order"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Part Number"),  _
         Pos(10),  _
         twodBarcode("TQUANT")>  _
        Public Property TQUANT() As nullable(of decimal)
            Get
                return _TQUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Quantity to Order", value, "^[0-9\.\-]+$") then Exit Property
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
         tab("Part Number"),  _
         Pos(12),  _
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
        
        <DisplayName("Demand Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Part Number"),  _
         Pos(24),  _
         twodBarcode("ISSDATE")>  _
        Public Property ISSDATE() As nullable (of DateTimeOffset)
            Get
                return _ISSDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Demand Date", value, "^.*$") then Exit Property
                _IsSetISSDATE = True
                If loading Then
                  _ISSDATE = Value
                Else
                    if not _ISSDATE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ISSDATE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ISSDATE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Manufct Code"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(30),  _
         twodBarcode("MNFNAME")>  _
        Public Property MNFNAME() As String
            Get
                return _MNFNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Manufct Code", value, "^.{0,10}$") then Exit Property
                _IsSetMNFNAME = True
                If loading Then
                  _MNFNAME = Value
                Else
                    if not _MNFNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("MNFNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _MNFNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Mnf. Part No."),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(32),  _
         [ReadOnly](true),  _
         twodBarcode("MNFPARTNAME")>  _
        Public Property MNFPARTNAME() As String
            Get
                return _MNFPARTNAME
            End Get
            Set
                if not(value is nothing) then
                  _MNFPARTNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Packing Crates (No.)"),  _
         nType("Edm.Int64"),  _
         tab("Part Number"),  _
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
         tab("Crate Type Code"),  _
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
        
        <DisplayName("Best On-hand Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Crate Type Code"),  _
         Pos(40),  _
         twodBarcode("DUEDATE")>  _
        Public Property DUEDATE() As nullable (of DateTimeOffset)
            Get
                return _DUEDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Best On-hand Date", value, "^.*$") then Exit Property
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
        
        <DisplayName("Recom. Due Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Crate Type Code"),  _
         Pos(42),  _
         [ReadOnly](true),  _
         twodBarcode("DUEDUEDATE")>  _
        Public Property DUEDUEDATE() As nullable (of DateTimeOffset)
            Get
                return _DUEDUEDATE
            End Get
            Set
                if not(value is nothing) then
                  _DUEDUEDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Recom. Ord Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Crate Type Code"),  _
         Pos(44),  _
         [ReadOnly](true),  _
         twodBarcode("RECOMDATE")>  _
        Public Property RECOMDATE() As nullable (of DateTimeOffset)
            Get
                return _RECOMDATE
            End Get
            Set
                if not(value is nothing) then
                  _RECOMDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Buyer"),  _
         nType("Edm.String"),  _
         tab("Crate Type Code"),  _
         Pos(50),  _
         twodBarcode("BUYERLOGIN")>  _
        Public Property BUYERLOGIN() As String
            Get
                return _BUYERLOGIN
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Buyer", value, "^.{0,20}$") then Exit Property
                _IsSetBUYERLOGIN = True
                If loading Then
                  _BUYERLOGIN = Value
                Else
                    if not _BUYERLOGIN = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("BUYERLOGIN", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _BUYERLOGIN = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Preferred Vendor"),  _
         nType("Edm.String"),  _
         tab("Crate Type Code"),  _
         Pos(52),  _
         [ReadOnly](true),  _
         twodBarcode("PARTSUPNAME")>  _
        Public Property PARTSUPNAME() As String
            Get
                return _PARTSUPNAME
            End Get
            Set
                if not(value is nothing) then
                  _PARTSUPNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Vendor for PR"),  _
         nType("Edm.String"),  _
         tab("Crate Type Code"),  _
         Pos(54),  _
         twodBarcode("SUPNAME")>  _
        Public Property SUPNAME() As String
            Get
                return _SUPNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Vendor for PR", value, "^.{0,16}$") then Exit Property
                _IsSetSUPNAME = True
                If loading Then
                  _SUPNAME = Value
                Else
                    if not _SUPNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SUPNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SUPNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Vend/Manuf. Part No."),  _
         nType("Edm.String"),  _
         tab("Crate Type Code"),  _
         Pos(56),  _
         twodBarcode("SUPPARTNAME")>  _
        Public Property SUPPARTNAME() As String
            Get
                return _SUPPARTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Vend/Manuf. Part No.", value, "^.{0,30}$") then Exit Property
                _IsSetSUPPARTNAME = True
                If loading Then
                  _SUPPARTNAME = Value
                Else
                    if not _SUPPARTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SUPPARTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SUPPARTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Quote Number"),  _
         nType("Edm.String"),  _
         tab("Quote Number"),  _
         Pos(57),  _
         twodBarcode("PROFNUM")>  _
        Public Property PROFNUM() As String
            Get
                return _PROFNUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Quote Number", value, "^.{0,16}$") then Exit Property
                _IsSetPROFNUM = True
                If loading Then
                  _PROFNUM = Value
                Else
                    if not _PROFNUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PROFNUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PROFNUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Quote Line"),  _
         nType("Edm.Int64"),  _
         tab("Quote Number"),  _
         Pos(58),  _
         twodBarcode("PLINE")>  _
        Public Property PLINE() As nullable (of int64)
            Get
                return _PLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Quote Line", value, "^[0-9\-]+$") then Exit Property
                _IsSetPLINE = True
                If loading Then
                  _PLINE = Value
                Else
                    if not _PLINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PLINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PLINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Purchase Order"),  _
         nType("Edm.String"),  _
         tab("Quote Number"),  _
         Pos(60),  _
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
        
        <DisplayName("Sales Order"),  _
         nType("Edm.String"),  _
         tab("Quote Number"),  _
         Pos(65),  _
         [ReadOnly](true),  _
         twodBarcode("CORDNAME")>  _
        Public Property CORDNAME() As String
            Get
                return _CORDNAME
            End Get
            Set
                if not(value is nothing) then
                  _CORDNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("CORDLINE"),  _
         nType("Edm.Int64"),  _
         tab("Quote Number"),  _
         Pos(0),  _
         twodBarcode("CORDLINE")>  _
        Public Property CORDLINE() As nullable (of int64)
            Get
                return _CORDLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("CORDLINE", value, "^[0-9\-]+$") then Exit Property
                _IsSetCORDLINE = True
                If loading Then
                  _CORDLINE = Value
                Else
                    if not _CORDLINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CORDLINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CORDLINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Budget Item"),  _
         nType("Edm.String"),  _
         tab("Quote Number"),  _
         Pos(80),  _
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
        
        <DisplayName("Profit/Cost Centre"),  _
         nType("Edm.String"),  _
         tab("Quote Number"),  _
         Pos(82),  _
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
        
        <DisplayName("PR Number"),  _
         nType("Edm.Int64"),  _
         tab("Quote Number"),  _
         Pos(84),  _
         [ReadOnly](true),  _
         twodBarcode("PRDI")>  _
        Public Property PRDI() As nullable (of int64)
            Get
                return _PRDI
            End Get
            Set
                if not(value is nothing) then
                  _PRDI = Value
                end if
            End Set
        End Property
        
        <DisplayName("Qty (Factory Units)"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Qty (Factory Units)"),  _
         Pos(85),  _
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
        
        <DisplayName("Closed?"),  _
         nType("Edm.String"),  _
         tab("Qty (Factory Units)"),  _
         Pos(88),  _
         twodBarcode("CLOSEDBOOL")>  _
        Public Property CLOSEDBOOL() As String
            Get
                return _CLOSEDBOOL
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Closed?", value, "^.{0,1}$") then Exit Property
                _IsSetCLOSEDBOOL = True
                If loading Then
                  _CLOSEDBOOL = Value
                Else
                    if not _CLOSEDBOOL = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CLOSEDBOOL", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CLOSEDBOOL = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Factory Unit"),  _
         nType("Edm.String"),  _
         tab("Qty (Factory Units)"),  _
         Pos(90),  _
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
        
        <DisplayName("Estimated Unit Price"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(13),  _
         tab("Qty (Factory Units)"),  _
         Pos(92),  _
         twodBarcode("PRICE")>  _
        Public Property PRICE() As nullable(of decimal)
            Get
                return _PRICE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Estimated Unit Price", value, "^[0-9\.\-]+$") then Exit Property
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
         tab("Qty (Factory Units)"),  _
         Pos(94),  _
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
        
        <DisplayName("Estimated Total Cost"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(16),  _
         tab("Qty (Factory Units)"),  _
         Pos(100),  _
         [ReadOnly](true),  _
         twodBarcode("ESTIMATEPRICE")>  _
        Public Property ESTIMATEPRICE() As nullable(of decimal)
            Get
                return _ESTIMATEPRICE
            End Get
            Set
                if not(value is nothing) then
                  _ESTIMATEPRICE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Document Currency"),  _
         nType("Edm.String"),  _
         tab("Qty (Factory Units)"),  _
         Pos(101),  _
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
        
        <DisplayName("Copy Price to Order?"),  _
         nType("Edm.String"),  _
         tab("Qty (Factory Units)"),  _
         Pos(102),  _
         twodBarcode("COPYPRICEFLAG")>  _
        Public Property COPYPRICEFLAG() As String
            Get
                return _COPYPRICEFLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Copy Price to Order?", value, "^.{0,1}$") then Exit Property
                _IsSetCOPYPRICEFLAG = True
                If loading Then
                  _COPYPRICEFLAG = Value
                Else
                    if not _COPYPRICEFLAG = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("COPYPRICEFLAG", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _COPYPRICEFLAG = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Price Source"),  _
         nType("Edm.String"),  _
         tab("Price Source"),  _
         Pos(103),  _
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
        
        <DisplayName("Exchange Rate"),  _
         nType("Edm.Decimal"),  _
         Scale(6),  _
         Precision(13),  _
         tab("Price Source"),  _
         Pos(104),  _
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
        
        <DisplayName("Automatic"),  _
         nType("Edm.String"),  _
         tab("Price Source"),  _
         Pos(105),  _
         [ReadOnly](true),  _
         twodBarcode("AUTO")>  _
        Public Property [AUTO]() As String
            Get
                return _AUTO
            End Get
            Set
                if not(value is nothing) then
                  _AUTO = Value
                end if
            End Set
        End Property
        
        <DisplayName("RFQ Opened?"),  _
         nType("Edm.String"),  _
         tab("Price Source"),  _
         Pos(125),  _
         twodBarcode("PROFOPENED")>  _
        Public Property PROFOPENED() As String
            Get
                return _PROFOPENED
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("RFQ Opened?", value, "^.{0,1}$") then Exit Property
                _IsSetPROFOPENED = True
                If loading Then
                  _PROFOPENED = Value
                Else
                    if not _PROFOPENED = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PROFOPENED", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PROFOPENED = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("To Work Order"),  _
         nType("Edm.String"),  _
         tab("Price Source"),  _
         Pos(130),  _
         twodBarcode("SERIALNAME")>  _
        Public Property SERIALNAME() As String
            Get
                return _SERIALNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("To Work Order", value, "^.{0,22}$") then Exit Property
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
        
        <DisplayName("Notify of Receipt?"),  _
         nType("Edm.String"),  _
         tab("Price Source"),  _
         Pos(140),  _
         twodBarcode("NOTICEFLAG")>  _
        Public Property NOTICEFLAG() As String
            Get
                return _NOTICEFLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Notify of Receipt?", value, "^.{0,1}$") then Exit Property
                _IsSetNOTICEFLAG = True
                If loading Then
                  _NOTICEFLAG = Value
                Else
                    if not _NOTICEFLAG = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("NOTICEFLAG", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _NOTICEFLAG = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Do Not Open Order"),  _
         nType("Edm.String"),  _
         tab("Price Source"),  _
         Pos(150),  _
         twodBarcode("NOOPENORD")>  _
        Public Property NOOPENORD() As String
            Get
                return _NOOPENORD
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Do Not Open Order", value, "^.{0,1}$") then Exit Property
                _IsSetNOOPENORD = True
                If loading Then
                  _NOOPENORD = Value
                Else
                    if not _NOOPENORD = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("NOOPENORD", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _NOOPENORD = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Open RFQ"),  _
         nType("Edm.String"),  _
         tab("Price Source"),  _
         Pos(160),  _
         twodBarcode("OPENPDPROF")>  _
        Public Property OPENPDPROF() As String
            Get
                return _OPENPDPROF
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Open RFQ", value, "^.{0,1}$") then Exit Property
                _IsSetOPENPDPROF = True
                If loading Then
                  _OPENPDPROF = Value
                Else
                    if not _OPENPDPROF = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("OPENPDPROF", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _OPENPDPROF = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Original PR Number"),  _
         nType("Edm.Int64"),  _
         tab("Original PR Number"),  _
         Pos(170),  _
         [ReadOnly](true),  _
         twodBarcode("ORIGPRDI")>  _
        Public Property ORIGPRDI() As nullable (of int64)
            Get
                return _ORIGPRDI
            End Get
            Set
                if not(value is nothing) then
                  _ORIGPRDI = Value
                end if
            End Set
        End Property
        
        <DisplayName("Original PR Qty"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(16),  _
         tab("Original PR Number"),  _
         Pos(180),  _
         [ReadOnly](true),  _
         twodBarcode("ORIGTQUANT")>  _
        Public Property ORIGTQUANT() As nullable(of decimal)
            Get
                return _ORIGTQUANT
            End Get
            Set
                if not(value is nothing) then
                  _ORIGTQUANT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Work Order to Charge"),  _
         nType("Edm.String"),  _
         tab("Original PR Number"),  _
         Pos(190),  _
         twodBarcode("FORSERIALNAME")>  _
        Public Property FORSERIALNAME() As String
            Get
                return _FORSERIALNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Work Order to Charge", value, "^.{0,22}$") then Exit Property
                _IsSetFORSERIALNAME = True
                If loading Then
                  _FORSERIALNAME = Value
                Else
                    if not _FORSERIALNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("FORSERIALNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _FORSERIALNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Original PR Number"),  _
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
        Public Property PRICEOPTIONS_SUBFORM() As QUERY_PRICEOPTIONS
            Get
                return _PRICEOPTIONS_SUBFORM
            End Get
            Set
                _PRICEOPTIONS_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property BUDGETREP_SUBFORM() As QUERY_BUDGETREP
            Get
                return _BUDGETREP_SUBFORM
            End Get
            Set
                _BUDGETREP_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property PRDIPPROFI_SUBFORM() As QUERY_PRDIPPROFI
            Get
                return _PRDIPPROFI_SUBFORM
            End Get
            Set
                _PRDIPPROFI_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property PRDITEMSTEXT_SUBFORM() As QUERY_PRDITEMSTEXT
            Get
                return _PRDITEMSTEXT_SUBFORM
            End Get
            Set
                _PRDITEMSTEXT_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property PRDITEMSSIGN_SUBFORM() As QUERY_PRDITEMSSIGN
            Get
                return _PRDITEMSSIGN_SUBFORM
            End Get
            Set
                _PRDITEMSSIGN_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property PARTPDPROFITEMS_SUBFORM() As QUERY_PARTPDPROFITEMS
            Get
                return _PARTPDPROFITEMS_SUBFORM
            End Get
            Set
                _PARTPDPROFITEMS_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property SPLITCOSTCENTERS_SUBFORM() As QUERY_SPLITCOSTCENTERS
            Get
                return _SPLITCOSTCENTERS_SUBFORM
            End Get
            Set
                _SPLITCOSTCENTERS_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property CHANGESITEMS_LOG_SUBFORM() As QUERY_CHANGESITEMS_LOG
            Get
                return _CHANGESITEMS_LOG_SUBFORM
            End Get
            Set
                _CHANGESITEMS_LOG_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property PRDLOG_SUBFORM() As QUERY_PRDLOG
            Get
                return _PRDLOG_SUBFORM
            End Get
            Set
                _PRDLOG_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property PRDLOGPUR_SUBFORM() As QUERY_PRDLOGPUR
            Get
                return _PRDLOGPUR_SUBFORM
            End Get
            Set
                _PRDLOGPUR_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property MRPDEMANDRAW_SUBFORM() As QUERY_MRPDEMANDRAW
            Get
                return _MRPDEMANDRAW_SUBFORM
            End Get
            Set
                _MRPDEMANDRAW_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property MRPDEMAND_SUBFORM() As QUERY_MRPDEMAND
            Get
                return _MRPDEMAND_SUBFORM
            End Get
            Set
                _MRPDEMAND_SUBFORM = value
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
            if _IsSetTQUANT then
              if f then
                  jw.WriteRaw(", ""TQUANT"": ")
              else
                  jw.WriteRaw("""TQUANT"": ")
                  f = true
              end if
              jw.WriteValue(me.TQUANT)
            end if
            if _IsSetISSDATE then
              if f then
                  jw.WriteRaw(", ""ISSDATE"": ")
              else
                  jw.WriteRaw("""ISSDATE"": ")
                  f = true
              end if
              jw.WriteValue(me.ISSDATE)
            end if
            if _IsSetMNFNAME then
              if f then
                  jw.WriteRaw(", ""MNFNAME"": ")
              else
                  jw.WriteRaw("""MNFNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.MNFNAME)
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
            if _IsSetDUEDATE then
              if f then
                  jw.WriteRaw(", ""DUEDATE"": ")
              else
                  jw.WriteRaw("""DUEDATE"": ")
                  f = true
              end if
              jw.WriteValue(me.DUEDATE)
            end if
            if _IsSetBUYERLOGIN then
              if f then
                  jw.WriteRaw(", ""BUYERLOGIN"": ")
              else
                  jw.WriteRaw("""BUYERLOGIN"": ")
                  f = true
              end if
              jw.WriteValue(me.BUYERLOGIN)
            end if
            if _IsSetSUPNAME then
              if f then
                  jw.WriteRaw(", ""SUPNAME"": ")
              else
                  jw.WriteRaw("""SUPNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SUPNAME)
            end if
            if _IsSetSUPPARTNAME then
              if f then
                  jw.WriteRaw(", ""SUPPARTNAME"": ")
              else
                  jw.WriteRaw("""SUPPARTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SUPPARTNAME)
            end if
            if _IsSetPROFNUM then
              if f then
                  jw.WriteRaw(", ""PROFNUM"": ")
              else
                  jw.WriteRaw("""PROFNUM"": ")
                  f = true
              end if
              jw.WriteValue(me.PROFNUM)
            end if
            if _IsSetPLINE then
              if f then
                  jw.WriteRaw(", ""PLINE"": ")
              else
                  jw.WriteRaw("""PLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.PLINE)
            end if
            if _IsSetCORDLINE then
              if f then
                  jw.WriteRaw(", ""CORDLINE"": ")
              else
                  jw.WriteRaw("""CORDLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.CORDLINE)
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
            if _IsSetCOSTCNAME then
              if f then
                  jw.WriteRaw(", ""COSTCNAME"": ")
              else
                  jw.WriteRaw("""COSTCNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.COSTCNAME)
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
            if _IsSetCLOSEDBOOL then
              if f then
                  jw.WriteRaw(", ""CLOSEDBOOL"": ")
              else
                  jw.WriteRaw("""CLOSEDBOOL"": ")
                  f = true
              end if
              jw.WriteValue(me.CLOSEDBOOL)
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
            if _IsSetCOPYPRICEFLAG then
              if f then
                  jw.WriteRaw(", ""COPYPRICEFLAG"": ")
              else
                  jw.WriteRaw("""COPYPRICEFLAG"": ")
                  f = true
              end if
              jw.WriteValue(me.COPYPRICEFLAG)
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
            if _IsSetPROFOPENED then
              if f then
                  jw.WriteRaw(", ""PROFOPENED"": ")
              else
                  jw.WriteRaw("""PROFOPENED"": ")
                  f = true
              end if
              jw.WriteValue(me.PROFOPENED)
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
            if _IsSetNOTICEFLAG then
              if f then
                  jw.WriteRaw(", ""NOTICEFLAG"": ")
              else
                  jw.WriteRaw("""NOTICEFLAG"": ")
                  f = true
              end if
              jw.WriteValue(me.NOTICEFLAG)
            end if
            if _IsSetNOOPENORD then
              if f then
                  jw.WriteRaw(", ""NOOPENORD"": ")
              else
                  jw.WriteRaw("""NOOPENORD"": ")
                  f = true
              end if
              jw.WriteValue(me.NOOPENORD)
            end if
            if _IsSetOPENPDPROF then
              if f then
                  jw.WriteRaw(", ""OPENPDPROF"": ")
              else
                  jw.WriteRaw("""OPENPDPROF"": ")
                  f = true
              end if
              jw.WriteValue(me.OPENPDPROF)
            end if
            if _IsSetFORSERIALNAME then
              if f then
                  jw.WriteRaw(", ""FORSERIALNAME"": ")
              else
                  jw.WriteRaw("""FORSERIALNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.FORSERIALNAME)
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
            if _PRICEOPTIONS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", PRICEOPTIONS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as PRICEOPTIONS in _PRICEOPTIONS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _PRICEOPTIONS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _BUDGETREP_SUBFORM.value.count > 0 then
              jw.WriteRaw(", BUDGETREP_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as BUDGETREP in _BUDGETREP_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _BUDGETREP_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _PRDIPPROFI_SUBFORM.value.count > 0 then
              jw.WriteRaw(", PRDIPPROFI_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as PRDIPPROFI in _PRDIPPROFI_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _PRDIPPROFI_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _PRDITEMSTEXT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", PRDITEMSTEXT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as PRDITEMSTEXT in _PRDITEMSTEXT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _PRDITEMSTEXT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _PRDITEMSSIGN_SUBFORM.value.count > 0 then
              jw.WriteRaw(", PRDITEMSSIGN_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as PRDITEMSSIGN in _PRDITEMSSIGN_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _PRDITEMSSIGN_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _PARTPDPROFITEMS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", PARTPDPROFITEMS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as PARTPDPROFITEMS in _PARTPDPROFITEMS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _PARTPDPROFITEMS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _SPLITCOSTCENTERS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", SPLITCOSTCENTERS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as SPLITCOSTCENTERS in _SPLITCOSTCENTERS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _SPLITCOSTCENTERS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _CHANGESITEMS_LOG_SUBFORM.value.count > 0 then
              jw.WriteRaw(", CHANGESITEMS_LOG_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as CHANGESITEMS_LOG in _CHANGESITEMS_LOG_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _CHANGESITEMS_LOG_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _PRDLOG_SUBFORM.value.count > 0 then
              jw.WriteRaw(", PRDLOG_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as PRDLOG in _PRDLOG_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _PRDLOG_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _PRDLOGPUR_SUBFORM.value.count > 0 then
              jw.WriteRaw(", PRDLOGPUR_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as PRDLOGPUR in _PRDLOGPUR_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _PRDLOGPUR_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _MRPDEMANDRAW_SUBFORM.value.count > 0 then
              jw.WriteRaw(", MRPDEMANDRAW_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as MRPDEMANDRAW in _MRPDEMANDRAW_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _MRPDEMANDRAW_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _MRPDEMAND_SUBFORM.value.count > 0 then
              jw.WriteRaw(", MRPDEMAND_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as MRPDEMAND in _MRPDEMAND_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _MRPDEMAND_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "PRDITEMS")
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
            if _IsSetPDES then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PDES")
              .WriteAttributeString("value", me.PDES)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "48")
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
            if _IsSetISSDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ISSDATE")
              .WriteAttributeString("value", me.ISSDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetMNFNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "MNFNAME")
              .WriteAttributeString("value", me.MNFNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "10")
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
            if _IsSetDUEDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DUEDATE")
              .WriteAttributeString("value", me.DUEDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetBUYERLOGIN then
              .WriteStartElement("field")
              .WriteAttributeString("name", "BUYERLOGIN")
              .WriteAttributeString("value", me.BUYERLOGIN)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
              .WriteEndElement
            end if
            if _IsSetSUPNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SUPNAME")
              .WriteAttributeString("value", me.SUPNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetSUPPARTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SUPPARTNAME")
              .WriteAttributeString("value", me.SUPPARTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "30")
              .WriteEndElement
            end if
            if _IsSetPROFNUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PROFNUM")
              .WriteAttributeString("value", me.PROFNUM)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetPLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PLINE")
              .WriteAttributeString("value", me.PLINE)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetCORDLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CORDLINE")
              .WriteAttributeString("value", me.CORDLINE)
              .WriteAttributeString("type", "Edm.Int64")
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
            if _IsSetCOSTCNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "COSTCNAME")
              .WriteAttributeString("value", me.COSTCNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "8")
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
            if _IsSetCLOSEDBOOL then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CLOSEDBOOL")
              .WriteAttributeString("value", me.CLOSEDBOOL)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
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
            if _IsSetCOPYPRICEFLAG then
              .WriteStartElement("field")
              .WriteAttributeString("name", "COPYPRICEFLAG")
              .WriteAttributeString("value", me.COPYPRICEFLAG)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
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
            if _IsSetPROFOPENED then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PROFOPENED")
              .WriteAttributeString("value", me.PROFOPENED)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
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
            if _IsSetNOTICEFLAG then
              .WriteStartElement("field")
              .WriteAttributeString("name", "NOTICEFLAG")
              .WriteAttributeString("value", me.NOTICEFLAG)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetNOOPENORD then
              .WriteStartElement("field")
              .WriteAttributeString("name", "NOOPENORD")
              .WriteAttributeString("value", me.NOOPENORD)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetOPENPDPROF then
              .WriteStartElement("field")
              .WriteAttributeString("name", "OPENPDPROF")
              .WriteAttributeString("value", me.OPENPDPROF)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetFORSERIALNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FORSERIALNAME")
              .WriteAttributeString("value", me.FORSERIALNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "22")
              .WriteEndElement
            end if
            if _IsSetKLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", me.KLINE)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _PROJLINK_SUBFORM.value.count > 0 then
              for each itm as PROJLINK in _PROJLINK_SUBFORM.Value
                itm.toXML(xw,"PROJLINK_SUBFORM")
              next
            end if
            if _PRICEOPTIONS_SUBFORM.value.count > 0 then
              for each itm as PRICEOPTIONS in _PRICEOPTIONS_SUBFORM.Value
                itm.toXML(xw,"PRICEOPTIONS_SUBFORM")
              next
            end if
            if _BUDGETREP_SUBFORM.value.count > 0 then
              for each itm as BUDGETREP in _BUDGETREP_SUBFORM.Value
                itm.toXML(xw,"BUDGETREP_SUBFORM")
              next
            end if
            if _PRDIPPROFI_SUBFORM.value.count > 0 then
              for each itm as PRDIPPROFI in _PRDIPPROFI_SUBFORM.Value
                itm.toXML(xw,"PRDIPPROFI_SUBFORM")
              next
            end if
            if _PRDITEMSTEXT_SUBFORM.value.count > 0 then
              for each itm as PRDITEMSTEXT in _PRDITEMSTEXT_SUBFORM.Value
                itm.toXML(xw,"PRDITEMSTEXT_SUBFORM")
              next
            end if
            if _PRDITEMSSIGN_SUBFORM.value.count > 0 then
              for each itm as PRDITEMSSIGN in _PRDITEMSSIGN_SUBFORM.Value
                itm.toXML(xw,"PRDITEMSSIGN_SUBFORM")
              next
            end if
            if _PARTPDPROFITEMS_SUBFORM.value.count > 0 then
              for each itm as PARTPDPROFITEMS in _PARTPDPROFITEMS_SUBFORM.Value
                itm.toXML(xw,"PARTPDPROFITEMS_SUBFORM")
              next
            end if
            if _SPLITCOSTCENTERS_SUBFORM.value.count > 0 then
              for each itm as SPLITCOSTCENTERS in _SPLITCOSTCENTERS_SUBFORM.Value
                itm.toXML(xw,"SPLITCOSTCENTERS_SUBFORM")
              next
            end if
            if _CHANGESITEMS_LOG_SUBFORM.value.count > 0 then
              for each itm as CHANGESITEMS_LOG in _CHANGESITEMS_LOG_SUBFORM.Value
                itm.toXML(xw,"CHANGESITEMS_LOG_SUBFORM")
              next
            end if
            if _PRDLOG_SUBFORM.value.count > 0 then
              for each itm as PRDLOG in _PRDLOG_SUBFORM.Value
                itm.toXML(xw,"PRDLOG_SUBFORM")
              next
            end if
            if _PRDLOGPUR_SUBFORM.value.count > 0 then
              for each itm as PRDLOGPUR in _PRDLOGPUR_SUBFORM.Value
                itm.toXML(xw,"PRDLOGPUR_SUBFORM")
              next
            end if
            if _MRPDEMANDRAW_SUBFORM.value.count > 0 then
              for each itm as MRPDEMANDRAW in _MRPDEMANDRAW_SUBFORM.Value
                itm.toXML(xw,"MRPDEMANDRAW_SUBFORM")
              next
            end if
            if _MRPDEMAND_SUBFORM.value.count > 0 then
              for each itm as MRPDEMAND in _MRPDEMAND_SUBFORM.Value
                itm.toXML(xw,"MRPDEMAND_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PRDITEMS = JsonConvert.DeserializeObject(Of PRDITEMS)(e.StreamReader.ReadToEnd)
                With obj
                  _PARTNAME = .PARTNAME
                  _PDES = .PDES
                  _TQUANT = .TQUANT
                  _TUNITNAME = .TUNITNAME
                  _ISSDATE = .ISSDATE
                  _MNFNAME = .MNFNAME
                  _MNFPARTNAME = .MNFPARTNAME
                  _NUMPACK = .NUMPACK
                  _PACKCODE = .PACKCODE
                  _DUEDATE = .DUEDATE
                  _DUEDUEDATE = .DUEDUEDATE
                  _RECOMDATE = .RECOMDATE
                  _BUYERLOGIN = .BUYERLOGIN
                  _PARTSUPNAME = .PARTSUPNAME
                  _SUPNAME = .SUPNAME
                  _SUPPARTNAME = .SUPPARTNAME
                  _PROFNUM = .PROFNUM
                  _PLINE = .PLINE
                  _ORDNAME = .ORDNAME
                  _CORDNAME = .CORDNAME
                  _CORDLINE = .CORDLINE
                  _BUDCODE = .BUDCODE
                  _COSTCNAME = .COSTCNAME
                  _PRDI = .PRDI
                  _QUANT = .QUANT
                  _CLOSEDBOOL = .CLOSEDBOOL
                  _UNITNAME = .UNITNAME
                  _PRICE = .PRICE
                  _ICODE = .ICODE
                  _ESTIMATEPRICE = .ESTIMATEPRICE
                  _CODE = .CODE
                  _COPYPRICEFLAG = .COPYPRICEFLAG
                  _PRSOURCENAME = .PRSOURCENAME
                  _EXCH = .EXCH
                  _AUTO = .AUTO
                  _PROFOPENED = .PROFOPENED
                  _SERIALNAME = .SERIALNAME
                  _NOTICEFLAG = .NOTICEFLAG
                  _NOOPENORD = .NOOPENORD
                  _OPENPDPROF = .OPENPDPROF
                  _ORIGPRDI = .ORIGPRDI
                  _ORIGTQUANT = .ORIGTQUANT
                  _FORSERIALNAME = .FORSERIALNAME
                  _KLINE = .KLINE
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_PRDITEMS
        
        PROJLINK = 0
        
        PRICEOPTIONS = 1
        
        BUDGETREP = 2
        
        PRDIPPROFI = 3
        
        PRDITEMSTEXT = 4
        
        PRDITEMSSIGN = 5
        
        PARTPDPROFITEMS = 6
        
        SPLITCOSTCENTERS = 7
        
        CHANGESITEMS_LOG = 8
        
        PRDLOG = 9
        
        PRDLOGPUR = 10
        
        MRPDEMANDRAW = 11
        
        MRPDEMAND = 12
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
    
    <QueryTitle("Part Price Options")>  _
    Public Class QUERY_PRICEOPTIONS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PRICEOPTIONS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PRICEOPTIONS)
            _Parent = nothing
            _Name = "PRICEOPTIONS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PRICEOPTIONS)
            _Parent = Parent
            _name = "PRICEOPTIONS_SUBFORM"
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
        
        Public Property Value() As list(of PRICEOPTIONS)
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
                return GetType(PRICEOPTIONS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PRICEOPTIONS As PRICEOPTIONS In JsonConvert.DeserializeObject(Of QUERY_PRICEOPTIONS)(stream.ReadToEnd).Value
              With _PRICEOPTIONS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PRICEOPTIONS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PRICEOPTIONS = JsonConvert.DeserializeObject(Of PRICEOPTIONS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PRICEOPTIONS)
                  .PODOCNO = obj.PODOCNO
                  .SUPNAME = obj.SUPNAME
                  .PRSOURCENAME = obj.PRSOURCENAME
                  .TQUANT = obj.TQUANT
                  .UNITNAME = obj.UNITNAME
                  .PRICE = obj.PRICE
                  .PERCENT = obj.PERCENT
                  .DUTYPERCENT = obj.DUTYPERCENT
                  .DUTYPERCENTTYPE = obj.DUTYPERCENTTYPE
                  .QPRICE = obj.QPRICE
                  .CODE = obj.CODE
                  .BPRICE = obj.BPRICE
                  .BCODE = obj.BCODE
                  .LCODE = obj.LCODE
                  .LEXCH = obj.LEXCH
                  .MNFNAME = obj.MNFNAME
                  .MNFDES = obj.MNFDES
                  .TYPE = obj.TYPE
                  .USER = obj.USER
                  .DOC = obj.DOC
                  .KLINE = obj.KLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PRICEOPTIONS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PRICEOPTIONS as PRICEOPTIONS in value
              If _PRICEOPTIONS.Equals(trycast(obj,PRICEOPTIONS)) Then
                  value.remove(_PRICEOPTIONS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PRICEOPTIONS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _PODOCNO As String
        
        Private _SUPNAME As String
        
        Private _PRSOURCENAME As String
        
        Private _TQUANT As Decimal
        
        Private _UNITNAME As String
        
        Private _PRICE As Decimal
        
        Private _PERCENT As Decimal
        
        Private _DUTYPERCENT As Decimal
        
        Private _DUTYPERCENTTYPE As String
        
        Private _QPRICE As Decimal
        
        Private _CODE As String
        
        Private _BPRICE As Decimal
        
        Private _BCODE As String
        
        Private _LCODE As String
        
        Private _LEXCH As Decimal
        
        Private _MNFNAME As String
        
        Private _MNFDES As String
        
        Private _TYPE As String
        
        Private _USER As Long
        
        Private _DOC As Long
        
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
                    return "PRICEOPTIONS"
                else
                    return "PRICEOPTIONS_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "TYPE={0},USER={1},DOC={2},KLINE={3}", _
                  string.format("'{0}'",TYPE), _
                  string.format("{0}",USER), _
                  string.format("{0}",DOC), _
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
        
        <DisplayName("Document Number"),  _
         nType("Edm.String"),  _
         tab("Document Number"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("PODOCNO")>  _
        Public Property PODOCNO() As String
            Get
                return _PODOCNO
            End Get
            Set
                if not(value is nothing) then
                  _PODOCNO = Value
                end if
            End Set
        End Property
        
        <DisplayName("Vendor"),  _
         nType("Edm.String"),  _
         tab("Document Number"),  _
         Pos(15),  _
         [ReadOnly](true),  _
         twodBarcode("SUPNAME")>  _
        Public Property SUPNAME() As String
            Get
                return _SUPNAME
            End Get
            Set
                if not(value is nothing) then
                  _SUPNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Price Source"),  _
         nType("Edm.String"),  _
         tab("Document Number"),  _
         Pos(17),  _
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
        
        <DisplayName("Doc. Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Document Number"),  _
         Pos(18),  _
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
         tab("Document Number"),  _
         Pos(19),  _
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
        
        <DisplayName("Unit Price"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(13),  _
         tab("Document Number"),  _
         Pos(20),  _
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
         Precision(10),  _
         tab("Document Number"),  _
         Pos(30),  _
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
        
        <DisplayName("Shipping Cost (%)"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(6),  _
         tab("Document Number"),  _
         Pos(32),  _
         [ReadOnly](true),  _
         twodBarcode("DUTYPERCENT")>  _
        Public Property DUTYPERCENT() As nullable(of decimal)
            Get
                return _DUTYPERCENT
            End Get
            Set
                if not(value is nothing) then
                  _DUTYPERCENT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Shipping Cost Type"),  _
         nType("Edm.String"),  _
         tab("Shipping Cost Type"),  _
         Pos(36),  _
         [ReadOnly](true),  _
         twodBarcode("DUTYPERCENTTYPE")>  _
        Public Property DUTYPERCENTTYPE() As String
            Get
                return _DUTYPERCENTTYPE
            End Get
            Set
                if not(value is nothing) then
                  _DUTYPERCENTTYPE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Final Price"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(13),  _
         tab("Shipping Cost Type"),  _
         Pos(40),  _
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
         tab("Shipping Cost Type"),  _
         Pos(50),  _
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
        
        <DisplayName("Final Price ({L.F})"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(13),  _
         tab("Shipping Cost Type"),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("BPRICE")>  _
        Public Property BPRICE() As nullable(of decimal)
            Get
                return _BPRICE
            End Get
            Set
                if not(value is nothing) then
                  _BPRICE = Value
                end if
            End Set
        End Property
        
        <DisplayName("{L.F}"),  _
         nType("Edm.String"),  _
         tab("Shipping Cost Type"),  _
         Pos(61),  _
         [ReadOnly](true),  _
         twodBarcode("BCODE")>  _
        Public Property BCODE() As String
            Get
                return _BCODE
            End Get
            Set
                if not(value is nothing) then
                  _BCODE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Linked Currency"),  _
         nType("Edm.String"),  _
         tab("Shipping Cost Type"),  _
         Pos(70),  _
         [ReadOnly](true),  _
         twodBarcode("LCODE")>  _
        Public Property LCODE() As String
            Get
                return _LCODE
            End Get
            Set
                if not(value is nothing) then
                  _LCODE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Base Rate"),  _
         nType("Edm.Decimal"),  _
         Scale(6),  _
         Precision(13),  _
         tab("Shipping Cost Type"),  _
         Pos(80),  _
         [ReadOnly](true),  _
         twodBarcode("LEXCH")>  _
        Public Property LEXCH() As nullable(of decimal)
            Get
                return _LEXCH
            End Get
            Set
                if not(value is nothing) then
                  _LEXCH = Value
                end if
            End Set
        End Property
        
        <DisplayName("Manufct Code"),  _
         nType("Edm.String"),  _
         tab("Shipping Cost Type"),  _
         Pos(90),  _
         [ReadOnly](true),  _
         twodBarcode("MNFNAME")>  _
        Public Property MNFNAME() As String
            Get
                return _MNFNAME
            End Get
            Set
                if not(value is nothing) then
                  _MNFNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Manufacturer Name"),  _
         nType("Edm.String"),  _
         tab("Manufacturer Name"),  _
         Pos(100),  _
         [ReadOnly](true),  _
         twodBarcode("MNFDES")>  _
        Public Property MNFDES() As String
            Get
                return _MNFDES
            End Get
            Set
                if not(value is nothing) then
                  _MNFDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Document Type"),  _
         nType("Edm.String"),  _
         tab("Manufacturer Name"),  _
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
        
        <DisplayName("User (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Manufacturer Name"),  _
         Pos(99),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("USER")>  _
        Public Property USER() As nullable (of int64)
            Get
                return _USER
            End Get
            Set
                if not(value is nothing) then
                  _USER = Value
                end if
            End Set
        End Property
        
        <DisplayName("Document (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Manufacturer Name"),  _
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
         tab("Manufacturer Name"),  _
         Pos(100),  _
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
                .WriteAttributeString("name", "PRICEOPTIONS")
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
              .WriteAttributeString("name", "USER")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
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
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PRICEOPTIONS = JsonConvert.DeserializeObject(Of PRICEOPTIONS)(e.StreamReader.ReadToEnd)
                With obj
                  _PODOCNO = .PODOCNO
                  _SUPNAME = .SUPNAME
                  _PRSOURCENAME = .PRSOURCENAME
                  _TQUANT = .TQUANT
                  _UNITNAME = .UNITNAME
                  _PRICE = .PRICE
                  _PERCENT = .PERCENT
                  _DUTYPERCENT = .DUTYPERCENT
                  _DUTYPERCENTTYPE = .DUTYPERCENTTYPE
                  _QPRICE = .QPRICE
                  _CODE = .CODE
                  _BPRICE = .BPRICE
                  _BCODE = .BCODE
                  _LCODE = .LCODE
                  _LEXCH = .LEXCH
                  _MNFNAME = .MNFNAME
                  _MNFDES = .MNFDES
                  _TYPE = .TYPE
                  _USER = .USER
                  _DOC = .DOC
                  _KLINE = .KLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Budgeted vs. Actual")>  _
    Public Class QUERY_BUDGETREP
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of BUDGETREP)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of BUDGETREP)
            _Parent = nothing
            _Name = "BUDGETREP"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of BUDGETREP)
            _Parent = Parent
            _name = "BUDGETREP_SUBFORM"
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
        
        Public Property Value() As list(of BUDGETREP)
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
                return GetType(BUDGETREP)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _BUDGETREP As BUDGETREP In JsonConvert.DeserializeObject(Of QUERY_BUDGETREP)(stream.ReadToEnd).Value
              With _BUDGETREP
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_BUDGETREP)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as BUDGETREP = JsonConvert.DeserializeObject(Of BUDGETREP)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, BUDGETREP)
                  .AMOUNT = obj.AMOUNT
                  .TOTCOST = obj.TOTCOST
                  .BAL = obj.BAL
                  .FNCCOST = obj.FNCCOST
                  .TRANSCOST = obj.TRANSCOST
                  .ORDCOST = obj.ORDCOST
                  .PRDCOST = obj.PRDCOST
                  .CODE = obj.CODE
                  .AMOUNT_YTD = obj.AMOUNT_YTD
                  .TOTALCOST_YTD = obj.TOTALCOST_YTD
                  .BAL_YTD = obj.BAL_YTD
                  .AMOUNT_PERIOD = obj.AMOUNT_PERIOD
                  .TOTALCOST_PERIOD = obj.TOTALCOST_PERIOD
                  .BAL_PERIOD = obj.BAL_PERIOD
                  .DATESTR = obj.DATESTR
                  .BCEHCKSTR = obj.BCEHCKSTR
                  .BUDGETDATE = obj.BUDGETDATE
                  .USER = obj.USER
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new BUDGETREP(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _BUDGETREP as BUDGETREP in value
              If _BUDGETREP.Equals(trycast(obj,BUDGETREP)) Then
                  value.remove(_BUDGETREP)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class BUDGETREP
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _AMOUNT As Decimal
        
        Private _TOTCOST As Decimal
        
        Private _BAL As Decimal
        
        Private _FNCCOST As Decimal
        
        Private _TRANSCOST As Decimal
        
        Private _ORDCOST As Decimal
        
        Private _PRDCOST As Decimal
        
        Private _CODE As String
        
        Private _AMOUNT_YTD As Decimal
        
        Private _TOTALCOST_YTD As Decimal
        
        Private _BAL_YTD As Decimal
        
        Private _AMOUNT_PERIOD As Decimal
        
        Private _TOTALCOST_PERIOD As Decimal
        
        Private _BAL_PERIOD As Decimal
        
        Private _DATESTR As String
        
        Private _BCEHCKSTR As String
        
        Private _BUDGETDATE As System.DateTimeOffset
        
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
                    return "BUDGETREP"
                else
                    return "BUDGETREP_SUBFORM"
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
        
        <DisplayName("Annual Appropriation"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(18),  _
         tab("Annual Appropriation"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("AMOUNT")>  _
        Public Property AMOUNT() As nullable(of decimal)
            Get
                return _AMOUNT
            End Get
            Set
                if not(value is nothing) then
                  _AMOUNT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Annual Budget Usage"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(16),  _
         tab("Annual Appropriation"),  _
         Pos(12),  _
         [ReadOnly](true),  _
         twodBarcode("TOTCOST")>  _
        Public Property TOTCOST() As nullable(of decimal)
            Get
                return _TOTCOST
            End Get
            Set
                if not(value is nothing) then
                  _TOTCOST = Value
                end if
            End Set
        End Property
        
        <DisplayName("Balance in Budget"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(15),  _
         tab("Annual Appropriation"),  _
         Pos(20),  _
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
        
        <DisplayName("Billed Transactions"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(18),  _
         tab("Annual Appropriation"),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("FNCCOST")>  _
        Public Property FNCCOST() As nullable(of decimal)
            Get
                return _FNCCOST
            End Get
            Set
                if not(value is nothing) then
                  _FNCCOST = Value
                end if
            End Set
        End Property
        
        <DisplayName("Unbilled Transact."),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(18),  _
         tab("Annual Appropriation"),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("TRANSCOST")>  _
        Public Property TRANSCOST() As nullable(of decimal)
            Get
                return _TRANSCOST
            End Get
            Set
                if not(value is nothing) then
                  _TRANSCOST = Value
                end if
            End Set
        End Property
        
        <DisplayName("Open Orders"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(18),  _
         tab("Annual Appropriation"),  _
         Pos(50),  _
         [ReadOnly](true),  _
         twodBarcode("ORDCOST")>  _
        Public Property ORDCOST() As nullable(of decimal)
            Get
                return _ORDCOST
            End Get
            Set
                if not(value is nothing) then
                  _ORDCOST = Value
                end if
            End Set
        End Property
        
        <DisplayName("Open PRs"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(18),  _
         tab("Annual Appropriation"),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("PRDCOST")>  _
        Public Property PRDCOST() As nullable(of decimal)
            Get
                return _PRDCOST
            End Get
            Set
                if not(value is nothing) then
                  _PRDCOST = Value
                end if
            End Set
        End Property
        
        <DisplayName("Curr"),  _
         nType("Edm.String"),  _
         tab("Annual Appropriation"),  _
         Pos(90),  _
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
        
        <DisplayName("Appropriation-YTD"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(18),  _
         tab("Appropriation-YTD"),  _
         Pos(100),  _
         [ReadOnly](true),  _
         twodBarcode("AMOUNT_YTD")>  _
        Public Property AMOUNT_YTD() As nullable(of decimal)
            Get
                return _AMOUNT_YTD
            End Get
            Set
                if not(value is nothing) then
                  _AMOUNT_YTD = Value
                end if
            End Set
        End Property
        
        <DisplayName("Used-YTD"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(18),  _
         tab("Appropriation-YTD"),  _
         Pos(110),  _
         [ReadOnly](true),  _
         twodBarcode("TOTALCOST_YTD")>  _
        Public Property TOTALCOST_YTD() As nullable(of decimal)
            Get
                return _TOTALCOST_YTD
            End Get
            Set
                if not(value is nothing) then
                  _TOTALCOST_YTD = Value
                end if
            End Set
        End Property
        
        <DisplayName("Balance-YTD"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(16),  _
         tab("Appropriation-YTD"),  _
         Pos(120),  _
         [ReadOnly](true),  _
         twodBarcode("BAL_YTD")>  _
        Public Property BAL_YTD() As nullable(of decimal)
            Get
                return _BAL_YTD
            End Get
            Set
                if not(value is nothing) then
                  _BAL_YTD = Value
                end if
            End Set
        End Property
        
        <DisplayName("Approp.-Current Per."),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(18),  _
         tab("Appropriation-YTD"),  _
         Pos(130),  _
         [ReadOnly](true),  _
         twodBarcode("AMOUNT_PERIOD")>  _
        Public Property AMOUNT_PERIOD() As nullable(of decimal)
            Get
                return _AMOUNT_PERIOD
            End Get
            Set
                if not(value is nothing) then
                  _AMOUNT_PERIOD = Value
                end if
            End Set
        End Property
        
        <DisplayName("Used-Current Period"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(18),  _
         tab("Appropriation-YTD"),  _
         Pos(140),  _
         [ReadOnly](true),  _
         twodBarcode("TOTALCOST_PERIOD")>  _
        Public Property TOTALCOST_PERIOD() As nullable(of decimal)
            Get
                return _TOTALCOST_PERIOD
            End Get
            Set
                if not(value is nothing) then
                  _TOTALCOST_PERIOD = Value
                end if
            End Set
        End Property
        
        <DisplayName("Bal-Current Period"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(16),  _
         tab("Appropriation-YTD"),  _
         Pos(150),  _
         [ReadOnly](true),  _
         twodBarcode("BAL_PERIOD")>  _
        Public Property BAL_PERIOD() As nullable(of decimal)
            Get
                return _BAL_PERIOD
            End Get
            Set
                if not(value is nothing) then
                  _BAL_PERIOD = Value
                end if
            End Set
        End Property
        
        <DisplayName("Current Period"),  _
         nType("Edm.String"),  _
         tab("Appropriation-YTD"),  _
         Pos(160),  _
         [ReadOnly](true),  _
         twodBarcode("DATESTR")>  _
        Public Property DATESTR() As String
            Get
                return _DATESTR
            End Get
            Set
                if not(value is nothing) then
                  _DATESTR = Value
                end if
            End Set
        End Property
        
        <DisplayName("Deviation Check"),  _
         nType("Edm.String"),  _
         tab("Appropriation-YTD"),  _
         Pos(170),  _
         [ReadOnly](true),  _
         twodBarcode("BCEHCKSTR")>  _
        Public Property BCEHCKSTR() As String
            Get
                return _BCEHCKSTR
            End Get
            Set
                if not(value is nothing) then
                  _BCEHCKSTR = Value
                end if
            End Set
        End Property
        
        <DisplayName("Budget Usage Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Budget Usage Date"),  _
         Pos(180),  _
         [ReadOnly](true),  _
         twodBarcode("BUDGETDATE")>  _
        Public Property BUDGETDATE() As nullable (of DateTimeOffset)
            Get
                return _BUDGETDATE
            End Get
            Set
                if not(value is nothing) then
                  _BUDGETDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("User (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Budget Usage Date"),  _
         Pos(99),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("USER")>  _
        Public Property USER() As nullable (of int64)
            Get
                return _USER
            End Get
            Set
                if not(value is nothing) then
                  _USER = Value
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
                .WriteAttributeString("name", "BUDGETREP")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "USER")
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
                dim obj as BUDGETREP = JsonConvert.DeserializeObject(Of BUDGETREP)(e.StreamReader.ReadToEnd)
                With obj
                  _AMOUNT = .AMOUNT
                  _TOTCOST = .TOTCOST
                  _BAL = .BAL
                  _FNCCOST = .FNCCOST
                  _TRANSCOST = .TRANSCOST
                  _ORDCOST = .ORDCOST
                  _PRDCOST = .PRDCOST
                  _CODE = .CODE
                  _AMOUNT_YTD = .AMOUNT_YTD
                  _TOTALCOST_YTD = .TOTALCOST_YTD
                  _BAL_YTD = .BAL_YTD
                  _AMOUNT_PERIOD = .AMOUNT_PERIOD
                  _TOTALCOST_PERIOD = .TOTALCOST_PERIOD
                  _BAL_PERIOD = .BAL_PERIOD
                  _DATESTR = .DATESTR
                  _BCEHCKSTR = .BCEHCKSTR
                  _BUDGETDATE = .BUDGETDATE
                  _USER = .USER
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Price Quotes for PR")>  _
    Public Class QUERY_PRDIPPROFI
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PRDIPPROFI)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PRDIPPROFI)
            _Parent = nothing
            _Name = "PRDIPPROFI"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PRDIPPROFI)
            _Parent = Parent
            _name = "PRDIPPROFI_SUBFORM"
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
        
        Public Property Value() As list(of PRDIPPROFI)
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
                return GetType(PRDIPPROFI)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PRDIPPROFI As PRDIPPROFI In JsonConvert.DeserializeObject(Of QUERY_PRDIPPROFI)(stream.ReadToEnd).Value
              With _PRDIPPROFI
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PRDIPPROFI)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PRDIPPROFI = JsonConvert.DeserializeObject(Of PRDIPPROFI)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PRDIPPROFI)
                  .PROFNUM = obj.PROFNUM
                  .LINE = obj.LINE
                  .SUPNAME = obj.SUPNAME
                  .CDES = obj.CDES
                  .EXPIRYDATE = obj.EXPIRYDATE
                  .TQUANT = obj.TQUANT
                  .TUNITNAME = obj.TUNITNAME
                  .PRICE = obj.PRICE
                  .PERCENT = obj.PERCENT
                  .PPERCENT = obj.PPERCENT
                  .DISPRICE = obj.DISPRICE
                  .ICODE = obj.ICODE
                  .TOTALPRICE = obj.TOTALPRICE
                  .CODE = obj.CODE
                  .BASEDISPRICE = obj.BASEDISPRICE
                  .BASETOTALPRICE = obj.BASETOTALPRICE
                  .BASECODE = obj.BASECODE
                  .SUPPARTNAME = obj.SUPPARTNAME
                  .SUPPARTDES = obj.SUPPARTDES
                  .PDATE = obj.PDATE
                  .PDLVDATE = obj.PDLVDATE
                  .KLINE = obj.KLINE
                  .NSCUST = obj.NSCUST
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PRDIPPROFI(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PRDIPPROFI as PRDIPPROFI in value
              If _PRDIPPROFI.Equals(trycast(obj,PRDIPPROFI)) Then
                  value.remove(_PRDIPPROFI)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PRDIPPROFI
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _PROFNUM As String
        
        Private _IsSetLINE As Boolean = Boolean.FalseString
        
        Private _LINE As Long
        
        Private _SUPNAME As String
        
        Private _CDES As String
        
        Private _EXPIRYDATE As System.DateTimeOffset
        
        Private _TQUANT As Decimal
        
        Private _TUNITNAME As String
        
        Private _PRICE As Decimal
        
        Private _PERCENT As Decimal
        
        Private _PPERCENT As Decimal
        
        Private _DISPRICE As Decimal
        
        Private _ICODE As String
        
        Private _TOTALPRICE As Decimal
        
        Private _CODE As String
        
        Private _BASEDISPRICE As Decimal
        
        Private _BASETOTALPRICE As Decimal
        
        Private _BASECODE As String
        
        Private _SUPPARTNAME As String
        
        Private _SUPPARTDES As String
        
        Private _PDATE As System.DateTimeOffset
        
        Private _PDLVDATE As System.DateTimeOffset
        
        Private _KLINE As Long
        
        Private _NSCUST As Long
        
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
                    return "PRDIPPROFI"
                else
                    return "PRDIPPROFI_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "KLINE={0},NSCUST={1}", _
                  string.format("{0}",KLINE), _
                  string.format("{0}",NSCUST) _ 
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
        
        <DisplayName("Quote Number"),  _
         nType("Edm.String"),  _
         tab("Quote Number"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("PROFNUM")>  _
        Public Property PROFNUM() As String
            Get
                return _PROFNUM
            End Get
            Set
                if not(value is nothing) then
                  _PROFNUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("LINE"),  _
         nType("Edm.Int64"),  _
         tab("Quote Number"),  _
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
        
        <DisplayName("Vendor Number"),  _
         nType("Edm.String"),  _
         tab("Quote Number"),  _
         Pos(65),  _
         [ReadOnly](true),  _
         twodBarcode("SUPNAME")>  _
        Public Property SUPNAME() As String
            Get
                return _SUPNAME
            End Get
            Set
                if not(value is nothing) then
                  _SUPNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Vendor Name"),  _
         nType("Edm.String"),  _
         tab("Quote Number"),  _
         Pos(68),  _
         [ReadOnly](true),  _
         twodBarcode("CDES")>  _
        Public Property CDES() As String
            Get
                return _CDES
            End Get
            Set
                if not(value is nothing) then
                  _CDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Expir. Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Quote Number"),  _
         Pos(70),  _
         [ReadOnly](true),  _
         twodBarcode("EXPIRYDATE")>  _
        Public Property EXPIRYDATE() As nullable (of DateTimeOffset)
            Get
                return _EXPIRYDATE
            End Get
            Set
                if not(value is nothing) then
                  _EXPIRYDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Minimum Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Quote Number"),  _
         Pos(85),  _
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
         tab("Quote Number"),  _
         Pos(90),  _
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
         tab("Quote Number"),  _
         Pos(95),  _
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
        
        <DisplayName("% Item Discount"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(8),  _
         tab("% Item Discount"),  _
         Pos(100),  _
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
        
        <DisplayName("% Overall Discount"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(8),  _
         tab("% Item Discount"),  _
         Pos(110),  _
         [ReadOnly](true),  _
         twodBarcode("PPERCENT")>  _
        Public Property PPERCENT() As nullable(of decimal)
            Get
                return _PPERCENT
            End Get
            Set
                if not(value is nothing) then
                  _PPERCENT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Price After Discount"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(13),  _
         tab("% Item Discount"),  _
         Pos(130),  _
         [ReadOnly](true),  _
         twodBarcode("DISPRICE")>  _
        Public Property DISPRICE() As nullable(of decimal)
            Get
                return _DISPRICE
            End Get
            Set
                if not(value is nothing) then
                  _DISPRICE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Item Currency"),  _
         nType("Edm.String"),  _
         tab("% Item Discount"),  _
         Pos(135),  _
         [ReadOnly](true),  _
         twodBarcode("ICODE")>  _
        Public Property ICODE() As String
            Get
                return _ICODE
            End Get
            Set
                if not(value is nothing) then
                  _ICODE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Total After Discount"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(13),  _
         tab("% Item Discount"),  _
         Pos(145),  _
         [ReadOnly](true),  _
         twodBarcode("TOTALPRICE")>  _
        Public Property TOTALPRICE() As nullable(of decimal)
            Get
                return _TOTALPRICE
            End Get
            Set
                if not(value is nothing) then
                  _TOTALPRICE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Quote Currency"),  _
         nType("Edm.String"),  _
         tab("% Item Discount"),  _
         Pos(150),  _
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
        
        <DisplayName("Price After Discount"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(13),  _
         tab("% Item Discount"),  _
         Pos(155),  _
         [ReadOnly](true),  _
         twodBarcode("BASEDISPRICE")>  _
        Public Property BASEDISPRICE() As nullable(of decimal)
            Get
                return _BASEDISPRICE
            End Get
            Set
                if not(value is nothing) then
                  _BASEDISPRICE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Total After Discount"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(13),  _
         tab("% Item Discount"),  _
         Pos(160),  _
         [ReadOnly](true),  _
         twodBarcode("BASETOTALPRICE")>  _
        Public Property BASETOTALPRICE() As nullable(of decimal)
            Get
                return _BASETOTALPRICE
            End Get
            Set
                if not(value is nothing) then
                  _BASETOTALPRICE = Value
                end if
            End Set
        End Property
        
        <DisplayName("{L.F}"),  _
         nType("Edm.String"),  _
         tab("{L.F}"),  _
         Pos(165),  _
         [ReadOnly](true),  _
         twodBarcode("BASECODE")>  _
        Public Property BASECODE() As String
            Get
                return _BASECODE
            End Get
            Set
                if not(value is nothing) then
                  _BASECODE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Vend/Manuf. Part No."),  _
         nType("Edm.String"),  _
         tab("{L.F}"),  _
         Pos(170),  _
         [ReadOnly](true),  _
         twodBarcode("SUPPARTNAME")>  _
        Public Property SUPPARTNAME() As String
            Get
                return _SUPPARTNAME
            End Get
            Set
                if not(value is nothing) then
                  _SUPPARTNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Descrip. (Vend/Mnf)"),  _
         nType("Edm.String"),  _
         tab("{L.F}"),  _
         Pos(172),  _
         [ReadOnly](true),  _
         twodBarcode("SUPPARTDES")>  _
        Public Property SUPPARTDES() As String
            Get
                return _SUPPARTDES
            End Get
            Set
                if not(value is nothing) then
                  _SUPPARTDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Quote Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("{L.F}"),  _
         Pos(175),  _
         [ReadOnly](true),  _
         twodBarcode("PDATE")>  _
        Public Property PDATE() As nullable (of DateTimeOffset)
            Get
                return _PDATE
            End Get
            Set
                if not(value is nothing) then
                  _PDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Due Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("{L.F}"),  _
         Pos(180),  _
         [ReadOnly](true),  _
         twodBarcode("PDLVDATE")>  _
        Public Property PDLVDATE() As nullable (of DateTimeOffset)
            Get
                return _PDLVDATE
            End Get
            Set
                if not(value is nothing) then
                  _PDLVDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("{L.F}"),  _
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
        
        <DisplayName("Price Quotation (ID)"),  _
         nType("Edm.Int64"),  _
         tab("{L.F}"),  _
         Pos(99),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("NSCUST")>  _
        Public Property NSCUST() As nullable (of int64)
            Get
                return _NSCUST
            End Get
            Set
                if not(value is nothing) then
                  _NSCUST = Value
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
                .WriteAttributeString("name", "PRDIPPROFI")
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
              .WriteAttributeString("name", "NSCUST")
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
                dim obj as PRDIPPROFI = JsonConvert.DeserializeObject(Of PRDIPPROFI)(e.StreamReader.ReadToEnd)
                With obj
                  _PROFNUM = .PROFNUM
                  _LINE = .LINE
                  _SUPNAME = .SUPNAME
                  _CDES = .CDES
                  _EXPIRYDATE = .EXPIRYDATE
                  _TQUANT = .TQUANT
                  _TUNITNAME = .TUNITNAME
                  _PRICE = .PRICE
                  _PERCENT = .PERCENT
                  _PPERCENT = .PPERCENT
                  _DISPRICE = .DISPRICE
                  _ICODE = .ICODE
                  _TOTALPRICE = .TOTALPRICE
                  _CODE = .CODE
                  _BASEDISPRICE = .BASEDISPRICE
                  _BASETOTALPRICE = .BASETOTALPRICE
                  _BASECODE = .BASECODE
                  _SUPPARTNAME = .SUPPARTNAME
                  _SUPPARTDES = .SUPPARTDES
                  _PDATE = .PDATE
                  _PDLVDATE = .PDLVDATE
                  _KLINE = .KLINE
                  _NSCUST = .NSCUST
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Purchase Requisition - Remarks")>  _
    Public Class QUERY_PRDITEMSTEXT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PRDITEMSTEXT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PRDITEMSTEXT)
            _Parent = nothing
            _Name = "PRDITEMSTEXT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PRDITEMSTEXT)
            _Parent = Parent
            _name = "PRDITEMSTEXT_SUBFORM"
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
        
        Public Property Value() As list(of PRDITEMSTEXT)
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
                return GetType(PRDITEMSTEXT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PRDITEMSTEXT As PRDITEMSTEXT In JsonConvert.DeserializeObject(Of QUERY_PRDITEMSTEXT)(stream.ReadToEnd).Value
              With _PRDITEMSTEXT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PRDITEMSTEXT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PRDITEMSTEXT = JsonConvert.DeserializeObject(Of PRDITEMSTEXT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PRDITEMSTEXT)
                  .TEXT = obj.TEXT
                  .TEXTLINE = obj.TEXTLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PRDITEMSTEXT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PRDITEMSTEXT as PRDITEMSTEXT in value
              If _PRDITEMSTEXT.Equals(trycast(obj,PRDITEMSTEXT)) Then
                  value.remove(_PRDITEMSTEXT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PRDITEMSTEXT
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
                    return "PRDITEMSTEXT"
                else
                    return "PRDITEMSTEXT_SUBFORM"
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
        
        <DisplayName("TEXTLINE"),  _
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
                .WriteAttributeString("name", "PRDITEMSTEXT")
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
                dim obj as PRDITEMSTEXT = JsonConvert.DeserializeObject(Of PRDITEMSTEXT)(e.StreamReader.ReadToEnd)
                With obj
                  _TEXT = .TEXT
                  _TEXTLINE = .TEXTLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Electronic Signature")>  _
    Public Class QUERY_PRDITEMSSIGN
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PRDITEMSSIGN)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PRDITEMSSIGN)
            _Parent = nothing
            _Name = "PRDITEMSSIGN"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PRDITEMSSIGN)
            _Parent = Parent
            _name = "PRDITEMSSIGN_SUBFORM"
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
        
        Public Property Value() As list(of PRDITEMSSIGN)
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
                return GetType(PRDITEMSSIGN)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PRDITEMSSIGN As PRDITEMSSIGN In JsonConvert.DeserializeObject(Of QUERY_PRDITEMSSIGN)(stream.ReadToEnd).Value
              With _PRDITEMSSIGN
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PRDITEMSSIGN)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PRDITEMSSIGN = JsonConvert.DeserializeObject(Of PRDITEMSSIGN)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PRDITEMSSIGN)
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .KLINE = obj.KLINE
                  .PURDEMAND = obj.PURDEMAND
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PRDITEMSSIGN(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PRDITEMSSIGN as PRDITEMSSIGN in value
              If _PRDITEMSSIGN.Equals(trycast(obj,PRDITEMSSIGN)) Then
                  value.remove(_PRDITEMSSIGN)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PRDITEMSSIGN
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _KLINE As Long
        
        Private _PURDEMAND As Long
        
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
                    return "PRDITEMSSIGN"
                else
                    return "PRDITEMSSIGN_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "KLINE={0},PURDEMAND={1}", _
                  string.format("{0}",KLINE), _
                  string.format("{0}",PURDEMAND) _ 
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
         Pos(20),  _
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
        
        <DisplayName("PR (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Signature"),  _
         Pos(99),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("PURDEMAND")>  _
        Public Property PURDEMAND() As nullable (of int64)
            Get
                return _PURDEMAND
            End Get
            Set
                if not(value is nothing) then
                  _PURDEMAND = Value
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
                .WriteAttributeString("name", "PRDITEMSSIGN")
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
              .WriteAttributeString("name", "PURDEMAND")
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
                dim obj as PRDITEMSSIGN = JsonConvert.DeserializeObject(Of PRDITEMSSIGN)(e.StreamReader.ReadToEnd)
                With obj
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _KLINE = .KLINE
                  _PURDEMAND = .PURDEMAND
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("RFQs for this Vendor and Part")>  _
    Public Class QUERY_PARTPDPROFITEMS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PARTPDPROFITEMS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PARTPDPROFITEMS)
            _Parent = nothing
            _Name = "PARTPDPROFITEMS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PARTPDPROFITEMS)
            _Parent = Parent
            _name = "PARTPDPROFITEMS_SUBFORM"
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
        
        Public Property Value() As list(of PARTPDPROFITEMS)
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
                return GetType(PARTPDPROFITEMS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PARTPDPROFITEMS As PARTPDPROFITEMS In JsonConvert.DeserializeObject(Of QUERY_PARTPDPROFITEMS)(stream.ReadToEnd).Value
              With _PARTPDPROFITEMS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PARTPDPROFITEMS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PARTPDPROFITEMS = JsonConvert.DeserializeObject(Of PARTPDPROFITEMS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PARTPDPROFITEMS)
                  .PDATE = obj.PDATE
                  .PROFNUM = obj.PROFNUM
                  .STATDES = obj.STATDES
                  .PDES = obj.PDES
                  .SUPPARTNAME = obj.SUPPARTNAME
                  .MNFNAME = obj.MNFNAME
                  .TQUANT = obj.TQUANT
                  .TUNITNAME = obj.TUNITNAME
                  .QUANT = obj.QUANT
                  .UNITNAME = obj.UNITNAME
                  .PRDI = obj.PRDI
                  .DUEDATE = obj.DUEDATE
                  .PROF = obj.PROF
                  .KLINE = obj.KLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PARTPDPROFITEMS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PARTPDPROFITEMS as PARTPDPROFITEMS in value
              If _PARTPDPROFITEMS.Equals(trycast(obj,PARTPDPROFITEMS)) Then
                  value.remove(_PARTPDPROFITEMS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PARTPDPROFITEMS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _PDATE As System.DateTimeOffset
        
        Private _PROFNUM As String
        
        Private _STATDES As String
        
        Private _PDES As String
        
        Private _SUPPARTNAME As String
        
        Private _MNFNAME As String
        
        Private _TQUANT As Decimal
        
        Private _TUNITNAME As String
        
        Private _QUANT As Decimal
        
        Private _UNITNAME As String
        
        Private _PRDI As Long
        
        Private _DUEDATE As System.DateTimeOffset
        
        Private _PROF As Long
        
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
                    return "PARTPDPROFITEMS"
                else
                    return "PARTPDPROFITEMS_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "PROF={0},KLINE={1}", _
                  string.format("{0}",PROF), _
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
        
        <DisplayName("RFQ Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("RFQ Date"),  _
         Pos(1),  _
         [ReadOnly](true),  _
         twodBarcode("PDATE")>  _
        Public Property PDATE() As nullable (of DateTimeOffset)
            Get
                return _PDATE
            End Get
            Set
                if not(value is nothing) then
                  _PDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("RFQ Number"),  _
         nType("Edm.String"),  _
         tab("RFQ Date"),  _
         Pos(2),  _
         [ReadOnly](true),  _
         twodBarcode("PROFNUM")>  _
        Public Property PROFNUM() As String
            Get
                return _PROFNUM
            End Get
            Set
                if not(value is nothing) then
                  _PROFNUM = Value
                end if
            End Set
        End Property
        
        <DisplayName("Status"),  _
         nType("Edm.String"),  _
         tab("RFQ Date"),  _
         Pos(3),  _
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
        
        <DisplayName("Part Description"),  _
         nType("Edm.String"),  _
         tab("RFQ Date"),  _
         Pos(5),  _
         [ReadOnly](true),  _
         twodBarcode("PDES")>  _
        Public Property PDES() As String
            Get
                return _PDES
            End Get
            Set
                if not(value is nothing) then
                  _PDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Vend/Manuf. Part No."),  _
         nType("Edm.String"),  _
         tab("RFQ Date"),  _
         Pos(8),  _
         [ReadOnly](true),  _
         twodBarcode("SUPPARTNAME")>  _
        Public Property SUPPARTNAME() As String
            Get
                return _SUPPARTNAME
            End Get
            Set
                if not(value is nothing) then
                  _SUPPARTNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Manufct Code"),  _
         nType("Edm.String"),  _
         tab("RFQ Date"),  _
         Pos(9),  _
         [ReadOnly](true),  _
         twodBarcode("MNFNAME")>  _
        Public Property MNFNAME() As String
            Get
                return _MNFNAME
            End Get
            Set
                if not(value is nothing) then
                  _MNFNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("RFQ Date"),  _
         Pos(10),  _
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
         tab("RFQ Date"),  _
         Pos(12),  _
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
        
        <DisplayName("Factory Unit"),  _
         nType("Edm.String"),  _
         tab("Qty (Factory Units)"),  _
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
        
        <DisplayName("PR Number"),  _
         nType("Edm.Int64"),  _
         tab("Qty (Factory Units)"),  _
         Pos(19),  _
         [ReadOnly](true),  _
         twodBarcode("PRDI")>  _
        Public Property PRDI() As nullable (of int64)
            Get
                return _PRDI
            End Get
            Set
                if not(value is nothing) then
                  _PRDI = Value
                end if
            End Set
        End Property
        
        <DisplayName("Date Needed"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Qty (Factory Units)"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("DUEDATE")>  _
        Public Property DUEDATE() As nullable (of DateTimeOffset)
            Get
                return _DUEDATE
            End Get
            Set
                if not(value is nothing) then
                  _DUEDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Price Quotation (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Qty (Factory Units)"),  _
         Pos(1),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("PROF")>  _
        Public Property PROF() As nullable (of int64)
            Get
                return _PROF
            End Get
            Set
                if not(value is nothing) then
                  _PROF = Value
                end if
            End Set
        End Property
        
        <DisplayName("Key Line"),  _
         nType("Edm.Int64"),  _
         tab("Qty (Factory Units)"),  _
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
                .WriteAttributeString("name", "PARTPDPROFITEMS")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "PROF")
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
                dim obj as PARTPDPROFITEMS = JsonConvert.DeserializeObject(Of PARTPDPROFITEMS)(e.StreamReader.ReadToEnd)
                With obj
                  _PDATE = .PDATE
                  _PROFNUM = .PROFNUM
                  _STATDES = .STATDES
                  _PDES = .PDES
                  _SUPPARTNAME = .SUPPARTNAME
                  _MNFNAME = .MNFNAME
                  _TQUANT = .TQUANT
                  _TUNITNAME = .TUNITNAME
                  _QUANT = .QUANT
                  _UNITNAME = .UNITNAME
                  _PRDI = .PRDI
                  _DUEDATE = .DUEDATE
                  _PROF = .PROF
                  _KLINE = .KLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Split Among Profit/Cost Centers")>  _
    Public Class QUERY_SPLITCOSTCENTERS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of SPLITCOSTCENTERS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of SPLITCOSTCENTERS)
            _Parent = nothing
            _Name = "SPLITCOSTCENTERS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of SPLITCOSTCENTERS)
            _Parent = Parent
            _name = "SPLITCOSTCENTERS_SUBFORM"
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
        
        Public Property Value() As list(of SPLITCOSTCENTERS)
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
                return GetType(SPLITCOSTCENTERS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _SPLITCOSTCENTERS As SPLITCOSTCENTERS In JsonConvert.DeserializeObject(Of QUERY_SPLITCOSTCENTERS)(stream.ReadToEnd).Value
              With _SPLITCOSTCENTERS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_SPLITCOSTCENTERS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as SPLITCOSTCENTERS = JsonConvert.DeserializeObject(Of SPLITCOSTCENTERS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, SPLITCOSTCENTERS)
                  .COSTCNAME = obj.COSTCNAME
                  .COSTCDES = obj.COSTCDES
                  .COSTCNAME2 = obj.COSTCNAME2
                  .COSTCDES2 = obj.COSTCDES2
                  .COSTCNAME3 = obj.COSTCNAME3
                  .COSTCDES3 = obj.COSTCDES3
                  .COSTCNAME4 = obj.COSTCNAME4
                  .COSTCDES4 = obj.COSTCDES4
                  .COSTCNAME5 = obj.COSTCNAME5
                  .COSTCDES5 = obj.COSTCDES5
                  .ACCNAME = obj.ACCNAME
                  .ACCDES = obj.ACCDES
                  .AMOUNT = obj.AMOUNT
                  .KLINE2 = obj.KLINE2
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new SPLITCOSTCENTERS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _SPLITCOSTCENTERS as SPLITCOSTCENTERS in value
              If _SPLITCOSTCENTERS.Equals(trycast(obj,SPLITCOSTCENTERS)) Then
                  value.remove(_SPLITCOSTCENTERS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class SPLITCOSTCENTERS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetCOSTCNAME As Boolean = Boolean.FalseString
        
        Private _COSTCNAME As String
        
        Private _COSTCDES As String
        
        Private _IsSetCOSTCNAME2 As Boolean = Boolean.FalseString
        
        Private _COSTCNAME2 As String
        
        Private _COSTCDES2 As String
        
        Private _IsSetCOSTCNAME3 As Boolean = Boolean.FalseString
        
        Private _COSTCNAME3 As String
        
        Private _COSTCDES3 As String
        
        Private _IsSetCOSTCNAME4 As Boolean = Boolean.FalseString
        
        Private _COSTCNAME4 As String
        
        Private _COSTCDES4 As String
        
        Private _IsSetCOSTCNAME5 As Boolean = Boolean.FalseString
        
        Private _COSTCNAME5 As String
        
        Private _COSTCDES5 As String
        
        Private _IsSetACCNAME As Boolean = Boolean.FalseString
        
        Private _ACCNAME As String
        
        Private _ACCDES As String
        
        Private _IsSetAMOUNT As Boolean = Boolean.FalseString
        
        Private _AMOUNT As Decimal
        
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
                    return "SPLITCOSTCENTERS"
                else
                    return "SPLITCOSTCENTERS_SUBFORM"
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
        
        <DisplayName("Profit/Cost Centre"),  _
         nType("Edm.String"),  _
         tab("Profit/Cost Centre"),  _
         Pos(10),  _
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
        
        <DisplayName("Descrip (Prof/Cost)"),  _
         nType("Edm.String"),  _
         tab("Profit/Cost Centre"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("COSTCDES")>  _
        Public Property COSTCDES() As String
            Get
                return _COSTCDES
            End Get
            Set
                if not(value is nothing) then
                  _COSTCDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Profit/Cost Center 2"),  _
         nType("Edm.String"),  _
         tab("Profit/Cost Centre"),  _
         Pos(30),  _
         twodBarcode("COSTCNAME2")>  _
        Public Property COSTCNAME2() As String
            Get
                return _COSTCNAME2
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Profit/Cost Center 2", value, "^.{0,8}$") then Exit Property
                _IsSetCOSTCNAME2 = True
                If loading Then
                  _COSTCNAME2 = Value
                Else
                    if not _COSTCNAME2 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("COSTCNAME2", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _COSTCNAME2 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Descrip (Prof/Cost2)"),  _
         nType("Edm.String"),  _
         tab("Profit/Cost Centre"),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("COSTCDES2")>  _
        Public Property COSTCDES2() As String
            Get
                return _COSTCDES2
            End Get
            Set
                if not(value is nothing) then
                  _COSTCDES2 = Value
                end if
            End Set
        End Property
        
        <DisplayName("Profit/Cost Center 3"),  _
         nType("Edm.String"),  _
         tab("Profit/Cost Centre"),  _
         Pos(50),  _
         twodBarcode("COSTCNAME3")>  _
        Public Property COSTCNAME3() As String
            Get
                return _COSTCNAME3
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Profit/Cost Center 3", value, "^.{0,8}$") then Exit Property
                _IsSetCOSTCNAME3 = True
                If loading Then
                  _COSTCNAME3 = Value
                Else
                    if not _COSTCNAME3 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("COSTCNAME3", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _COSTCNAME3 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Descrip (Prof/Cost3)"),  _
         nType("Edm.String"),  _
         tab("Profit/Cost Centre"),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("COSTCDES3")>  _
        Public Property COSTCDES3() As String
            Get
                return _COSTCDES3
            End Get
            Set
                if not(value is nothing) then
                  _COSTCDES3 = Value
                end if
            End Set
        End Property
        
        <DisplayName("Profit/Cost Center 4"),  _
         nType("Edm.String"),  _
         tab("Profit/Cost Centre"),  _
         Pos(70),  _
         twodBarcode("COSTCNAME4")>  _
        Public Property COSTCNAME4() As String
            Get
                return _COSTCNAME4
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Profit/Cost Center 4", value, "^.{0,8}$") then Exit Property
                _IsSetCOSTCNAME4 = True
                If loading Then
                  _COSTCNAME4 = Value
                Else
                    if not _COSTCNAME4 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("COSTCNAME4", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _COSTCNAME4 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Descrip (Prof/Cost4)"),  _
         nType("Edm.String"),  _
         tab("Profit/Cost Centre"),  _
         Pos(80),  _
         [ReadOnly](true),  _
         twodBarcode("COSTCDES4")>  _
        Public Property COSTCDES4() As String
            Get
                return _COSTCDES4
            End Get
            Set
                if not(value is nothing) then
                  _COSTCDES4 = Value
                end if
            End Set
        End Property
        
        <DisplayName("Profit/Cost Center 5"),  _
         nType("Edm.String"),  _
         tab("Profit/Cost Center 5"),  _
         Pos(90),  _
         twodBarcode("COSTCNAME5")>  _
        Public Property COSTCNAME5() As String
            Get
                return _COSTCNAME5
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Profit/Cost Center 5", value, "^.{0,8}$") then Exit Property
                _IsSetCOSTCNAME5 = True
                If loading Then
                  _COSTCNAME5 = Value
                Else
                    if not _COSTCNAME5 = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("COSTCNAME5", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _COSTCNAME5 = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Descrip (Prof/Cost5)"),  _
         nType("Edm.String"),  _
         tab("Profit/Cost Center 5"),  _
         Pos(100),  _
         [ReadOnly](true),  _
         twodBarcode("COSTCDES5")>  _
        Public Property COSTCDES5() As String
            Get
                return _COSTCDES5
            End Get
            Set
                if not(value is nothing) then
                  _COSTCDES5 = Value
                end if
            End Set
        End Property
        
        <DisplayName("Account No."),  _
         nType("Edm.String"),  _
         tab("Profit/Cost Center 5"),  _
         Pos(110),  _
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
         tab("Profit/Cost Center 5"),  _
         Pos(120),  _
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
        
        <DisplayName("Weight"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(16),  _
         tab("Profit/Cost Center 5"),  _
         Pos(130),  _
         twodBarcode("AMOUNT")>  _
        Public Property AMOUNT() As nullable(of decimal)
            Get
                return _AMOUNT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Weight", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetAMOUNT = True
                If loading Then
                  _AMOUNT = Value
                Else
                    if not _AMOUNT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("AMOUNT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _AMOUNT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Key Line 2"),  _
         nType("Edm.Int64"),  _
         tab("Profit/Cost Center 5"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("KLINE2")>  _
        Public Property KLINE2() As nullable (of int64)
            Get
                return _KLINE2
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Key Line 2", value, "^[0-9\-]+$") then Exit Property
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
            if _IsSetCOSTCNAME then
              if f then
                  jw.WriteRaw(", ""COSTCNAME"": ")
              else
                  jw.WriteRaw("""COSTCNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.COSTCNAME)
            end if
            if _IsSetCOSTCNAME2 then
              if f then
                  jw.WriteRaw(", ""COSTCNAME2"": ")
              else
                  jw.WriteRaw("""COSTCNAME2"": ")
                  f = true
              end if
              jw.WriteValue(me.COSTCNAME2)
            end if
            if _IsSetCOSTCNAME3 then
              if f then
                  jw.WriteRaw(", ""COSTCNAME3"": ")
              else
                  jw.WriteRaw("""COSTCNAME3"": ")
                  f = true
              end if
              jw.WriteValue(me.COSTCNAME3)
            end if
            if _IsSetCOSTCNAME4 then
              if f then
                  jw.WriteRaw(", ""COSTCNAME4"": ")
              else
                  jw.WriteRaw("""COSTCNAME4"": ")
                  f = true
              end if
              jw.WriteValue(me.COSTCNAME4)
            end if
            if _IsSetCOSTCNAME5 then
              if f then
                  jw.WriteRaw(", ""COSTCNAME5"": ")
              else
                  jw.WriteRaw("""COSTCNAME5"": ")
                  f = true
              end if
              jw.WriteValue(me.COSTCNAME5)
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
            if _IsSetAMOUNT then
              if f then
                  jw.WriteRaw(", ""AMOUNT"": ")
              else
                  jw.WriteRaw("""AMOUNT"": ")
                  f = true
              end if
              jw.WriteValue(me.AMOUNT)
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
                .WriteAttributeString("name", "SPLITCOSTCENTERS")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "KLINE2")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetCOSTCNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "COSTCNAME")
              .WriteAttributeString("value", me.COSTCNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "8")
              .WriteEndElement
            end if
            if _IsSetCOSTCNAME2 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "COSTCNAME2")
              .WriteAttributeString("value", me.COSTCNAME2)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "8")
              .WriteEndElement
            end if
            if _IsSetCOSTCNAME3 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "COSTCNAME3")
              .WriteAttributeString("value", me.COSTCNAME3)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "8")
              .WriteEndElement
            end if
            if _IsSetCOSTCNAME4 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "COSTCNAME4")
              .WriteAttributeString("value", me.COSTCNAME4)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "8")
              .WriteEndElement
            end if
            if _IsSetCOSTCNAME5 then
              .WriteStartElement("field")
              .WriteAttributeString("name", "COSTCNAME5")
              .WriteAttributeString("value", me.COSTCNAME5)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "8")
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
            if _IsSetAMOUNT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "AMOUNT")
              .WriteAttributeString("value", me.AMOUNT)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "2")
              .WriteAttributeString("Precision", "16")
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
                dim obj as SPLITCOSTCENTERS = JsonConvert.DeserializeObject(Of SPLITCOSTCENTERS)(e.StreamReader.ReadToEnd)
                With obj
                  _COSTCNAME = .COSTCNAME
                  _COSTCDES = .COSTCDES
                  _COSTCNAME2 = .COSTCNAME2
                  _COSTCDES2 = .COSTCDES2
                  _COSTCNAME3 = .COSTCNAME3
                  _COSTCDES3 = .COSTCDES3
                  _COSTCNAME4 = .COSTCNAME4
                  _COSTCDES4 = .COSTCDES4
                  _COSTCNAME5 = .COSTCNAME5
                  _COSTCDES5 = .COSTCDES5
                  _ACCNAME = .ACCNAME
                  _ACCDES = .ACCDES
                  _AMOUNT = .AMOUNT
                  _KLINE2 = .KLINE2
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("History of Changes")>  _
    Public Class QUERY_CHANGESITEMS_LOG
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of CHANGESITEMS_LOG)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of CHANGESITEMS_LOG)
            _Parent = nothing
            _Name = "CHANGESITEMS_LOG"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of CHANGESITEMS_LOG)
            _Parent = Parent
            _name = "CHANGESITEMS_LOG_SUBFORM"
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
        
        Public Property Value() As list(of CHANGESITEMS_LOG)
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
                return GetType(CHANGESITEMS_LOG)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _CHANGESITEMS_LOG As CHANGESITEMS_LOG In JsonConvert.DeserializeObject(Of QUERY_CHANGESITEMS_LOG)(stream.ReadToEnd).Value
              With _CHANGESITEMS_LOG
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_CHANGESITEMS_LOG)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as CHANGESITEMS_LOG = JsonConvert.DeserializeObject(Of CHANGESITEMS_LOG)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, CHANGESITEMS_LOG)
                  .DETAILS = obj.DETAILS
                  .FIELD = obj.FIELD
                  .OLDVALUE = obj.OLDVALUE
                  .NEWVALUE = obj.NEWVALUE
                  .USERLOGIN = obj.USERLOGIN
                  .PHONENAME = obj.PHONENAME
                  .UDATE = obj.UDATE
                  .LOG = obj.LOG
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new CHANGESITEMS_LOG(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _CHANGESITEMS_LOG as CHANGESITEMS_LOG in value
              If _CHANGESITEMS_LOG.Equals(trycast(obj,CHANGESITEMS_LOG)) Then
                  value.remove(_CHANGESITEMS_LOG)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class CHANGESITEMS_LOG
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _DETAILS As String
        
        Private _FIELD As String
        
        Private _OLDVALUE As String
        
        Private _NEWVALUE As String
        
        Private _USERLOGIN As String
        
        Private _PHONENAME As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _LOG As Long
        
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
                    return "CHANGESITEMS_LOG"
                else
                    return "CHANGESITEMS_LOG_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "LOG={0}", _
                  string.format("{0}",LOG) _ 
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
        
        <DisplayName("Details"),  _
         nType("Edm.String"),  _
         tab("Details"),  _
         Pos(7),  _
         [ReadOnly](true),  _
         twodBarcode("DETAILS")>  _
        Public Property DETAILS() As String
            Get
                return _DETAILS
            End Get
            Set
                if not(value is nothing) then
                  _DETAILS = Value
                end if
            End Set
        End Property
        
        <DisplayName("Column"),  _
         nType("Edm.String"),  _
         tab("Details"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("FIELD")>  _
        Public Property FIELD() As String
            Get
                return _FIELD
            End Get
            Set
                if not(value is nothing) then
                  _FIELD = Value
                end if
            End Set
        End Property
        
        <DisplayName("Previous Value"),  _
         nType("Edm.String"),  _
         tab("Details"),  _
         Pos(50),  _
         [ReadOnly](true),  _
         twodBarcode("OLDVALUE")>  _
        Public Property OLDVALUE() As String
            Get
                return _OLDVALUE
            End Get
            Set
                if not(value is nothing) then
                  _OLDVALUE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Current Value"),  _
         nType("Edm.String"),  _
         tab("Details"),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("NEWVALUE")>  _
        Public Property NEWVALUE() As String
            Get
                return _NEWVALUE
            End Get
            Set
                if not(value is nothing) then
                  _NEWVALUE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Details"),  _
         Pos(90),  _
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
        
        <DisplayName("Contact"),  _
         nType("Edm.String"),  _
         tab("Details"),  _
         Pos(95),  _
         [ReadOnly](true),  _
         twodBarcode("PHONENAME")>  _
        Public Property PHONENAME() As String
            Get
                return _PHONENAME
            End Get
            Set
                if not(value is nothing) then
                  _PHONENAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Details"),  _
         Pos(100),  _
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
        
        <DisplayName("Log (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Details"),  _
         Pos(99),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("LOG")>  _
        Public Property LOG() As nullable (of int64)
            Get
                return _LOG
            End Get
            Set
                if not(value is nothing) then
                  _LOG = Value
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
                .WriteAttributeString("name", "CHANGESITEMS_LOG")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "LOG")
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
                dim obj as CHANGESITEMS_LOG = JsonConvert.DeserializeObject(Of CHANGESITEMS_LOG)(e.StreamReader.ReadToEnd)
                With obj
                  _DETAILS = .DETAILS
                  _FIELD = .FIELD
                  _OLDVALUE = .OLDVALUE
                  _NEWVALUE = .NEWVALUE
                  _USERLOGIN = .USERLOGIN
                  _PHONENAME = .PHONENAME
                  _UDATE = .UDATE
                  _LOG = .LOG
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Projected Balances (fact. units)")>  _
    Public Class QUERY_PRDLOG
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PRDLOG)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PRDLOG)
            _Parent = nothing
            _Name = "PRDLOG"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PRDLOG)
            _Parent = Parent
            _name = "PRDLOG_SUBFORM"
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
        
        Public Property Value() As list(of PRDLOG)
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
                return GetType(PRDLOG)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PRDLOG As PRDLOG In JsonConvert.DeserializeObject(Of QUERY_PRDLOG)(stream.ReadToEnd).Value
              With _PRDLOG
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PRDLOG)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PRDLOG = JsonConvert.DeserializeObject(Of PRDLOG)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PRDLOG)
                  .SDATE = obj.SDATE
                  .TYPE = obj.TYPE
                  .OQUANT = obj.OQUANT
                  .INVENTORY = obj.INVENTORY
                  .PRDBALANCE = obj.PRDBALANCE
                  .BALANCE = obj.BALANCE
                  .ISSDATE = obj.ISSDATE
                  .ORDDATE = obj.ORDDATE
                  .PORDNAME = obj.PORDNAME
                  .PLINE = obj.PLINE
                  .PRDI = obj.PRDI
                  .REQDATE = obj.REQDATE
                  .DUEDATE = obj.DUEDATE
                  .PPARTNAME = obj.PPARTNAME
                  .SERIALNAME = obj.SERIALNAME
                  .ORDNAME = obj.ORDNAME
                  .LINE = obj.LINE
                  .PARTNAME = obj.PARTNAME
                  .DOCNO = obj.DOCNO
                  .PROJDES = obj.PROJDES
                  .IND = obj.IND
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PRDLOG(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PRDLOG as PRDLOG in value
              If _PRDLOG.Equals(trycast(obj,PRDLOG)) Then
                  value.remove(_PRDLOG)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PRDLOG
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _SDATE As System.DateTimeOffset
        
        Private _TYPE As String
        
        Private _OQUANT As Decimal
        
        Private _INVENTORY As Decimal
        
        Private _PRDBALANCE As Decimal
        
        Private _BALANCE As Decimal
        
        Private _ISSDATE As System.DateTimeOffset
        
        Private _ORDDATE As System.DateTimeOffset
        
        Private _PORDNAME As String
        
        Private _IsSetPLINE As Boolean = Boolean.FalseString
        
        Private _PLINE As Long
        
        Private _PRDI As Long
        
        Private _REQDATE As System.DateTimeOffset
        
        Private _DUEDATE As System.DateTimeOffset
        
        Private _PPARTNAME As String
        
        Private _SERIALNAME As String
        
        Private _ORDNAME As String
        
        Private _IsSetLINE As Boolean = Boolean.FalseString
        
        Private _LINE As Long
        
        Private _PARTNAME As String
        
        Private _DOCNO As String
        
        Private _PROJDES As String
        
        Private _IND As Long
        
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
                    return "PRDLOG"
                else
                    return "PRDLOG_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "IND={0}", _
                  string.format("{0}",IND) _ 
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
        
        <DisplayName("Date Expected"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Date Expected"),  _
         Pos(10),  _
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
        
        <DisplayName("Type"),  _
         nType("Edm.String"),  _
         tab("Date Expected"),  _
         Pos(20),  _
         [ReadOnly](true),  _
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
        
        <DisplayName("Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Date Expected"),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("OQUANT")>  _
        Public Property OQUANT() As nullable(of decimal)
            Get
                return _OQUANT
            End Get
            Set
                if not(value is nothing) then
                  _OQUANT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Change in Inventory"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Date Expected"),  _
         Pos(33),  _
         [ReadOnly](true),  _
         twodBarcode("INVENTORY")>  _
        Public Property INVENTORY() As nullable(of decimal)
            Get
                return _INVENTORY
            End Get
            Set
                if not(value is nothing) then
                  _INVENTORY = Value
                end if
            End Set
        End Property
        
        <DisplayName("Bal Includ. Demands"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Date Expected"),  _
         Pos(36),  _
         [ReadOnly](true),  _
         twodBarcode("PRDBALANCE")>  _
        Public Property PRDBALANCE() As nullable(of decimal)
            Get
                return _PRDBALANCE
            End Get
            Set
                if not(value is nothing) then
                  _PRDBALANCE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Bal W/out Demands"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Date Expected"),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("BALANCE")>  _
        Public Property BALANCE() As nullable(of decimal)
            Get
                return _BALANCE
            End Get
            Set
                if not(value is nothing) then
                  _BALANCE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Demand Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Date Expected"),  _
         Pos(50),  _
         [ReadOnly](true),  _
         twodBarcode("ISSDATE")>  _
        Public Property ISSDATE() As nullable (of DateTimeOffset)
            Get
                return _ISSDATE
            End Get
            Set
                if not(value is nothing) then
                  _ISSDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Expedited Ord-Onhand"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Date Expected"),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("ORDDATE")>  _
        Public Property ORDDATE() As nullable (of DateTimeOffset)
            Get
                return _ORDDATE
            End Get
            Set
                if not(value is nothing) then
                  _ORDDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Purchase Order"),  _
         nType("Edm.String"),  _
         tab("Purchase Order"),  _
         Pos(70),  _
         [ReadOnly](true),  _
         twodBarcode("PORDNAME")>  _
        Public Property PORDNAME() As String
            Get
                return _PORDNAME
            End Get
            Set
                if not(value is nothing) then
                  _PORDNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("PLINE"),  _
         nType("Edm.Int64"),  _
         tab("Purchase Order"),  _
         Pos(0),  _
         twodBarcode("PLINE")>  _
        Public Property PLINE() As nullable (of int64)
            Get
                return _PLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("PLINE", value, "^[0-9\-]+$") then Exit Property
                _IsSetPLINE = True
                If loading Then
                  _PLINE = Value
                Else
                    if not _PLINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PLINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PLINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("PR Number"),  _
         nType("Edm.Int64"),  _
         tab("Purchase Order"),  _
         Pos(90),  _
         [ReadOnly](true),  _
         twodBarcode("PRDI")>  _
        Public Property PRDI() As nullable (of int64)
            Get
                return _PRDI
            End Get
            Set
                if not(value is nothing) then
                  _PRDI = Value
                end if
            End Set
        End Property
        
        <DisplayName("Recom. Due Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Purchase Order"),  _
         Pos(100),  _
         [ReadOnly](true),  _
         twodBarcode("REQDATE")>  _
        Public Property REQDATE() As nullable (of DateTimeOffset)
            Get
                return _REQDATE
            End Get
            Set
                if not(value is nothing) then
                  _REQDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Recom. Ord Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Purchase Order"),  _
         Pos(110),  _
         [ReadOnly](true),  _
         twodBarcode("DUEDATE")>  _
        Public Property DUEDATE() As nullable (of DateTimeOffset)
            Get
                return _DUEDATE
            End Get
            Set
                if not(value is nothing) then
                  _DUEDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Parent Part Number"),  _
         nType("Edm.String"),  _
         tab("Purchase Order"),  _
         Pos(120),  _
         [ReadOnly](true),  _
         twodBarcode("PPARTNAME")>  _
        Public Property PPARTNAME() As String
            Get
                return _PPARTNAME
            End Get
            Set
                if not(value is nothing) then
                  _PPARTNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Work Order/Lot"),  _
         nType("Edm.String"),  _
         tab("Purchase Order"),  _
         Pos(125),  _
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
        
        <DisplayName("Sales Order"),  _
         nType("Edm.String"),  _
         tab("Purchase Order"),  _
         Pos(150),  _
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
        
        <DisplayName("LINE"),  _
         nType("Edm.Int64"),  _
         tab("LINE"),  _
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
        
        <DisplayName("Top-Level Part No."),  _
         nType("Edm.String"),  _
         tab("LINE"),  _
         Pos(170),  _
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
        
        <DisplayName("Project Number"),  _
         nType("Edm.String"),  _
         tab("LINE"),  _
         Pos(180),  _
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
        
        <DisplayName("Project Description"),  _
         nType("Edm.String"),  _
         tab("LINE"),  _
         Pos(190),  _
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
        
        <DisplayName("Key (ID)"),  _
         nType("Edm.Int64"),  _
         tab("LINE"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("IND")>  _
        Public Property IND() As nullable (of int64)
            Get
                return _IND
            End Get
            Set
                if not(value is nothing) then
                  _IND = Value
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetPLINE then
              if f then
                  jw.WriteRaw(", ""PLINE"": ")
              else
                  jw.WriteRaw("""PLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.PLINE)
            end if
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
                .WriteAttributeString("name", "PRDLOG")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "IND")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetPLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PLINE")
              .WriteAttributeString("value", me.PLINE)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
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
                dim obj as PRDLOG = JsonConvert.DeserializeObject(Of PRDLOG)(e.StreamReader.ReadToEnd)
                With obj
                  _SDATE = .SDATE
                  _TYPE = .TYPE
                  _OQUANT = .OQUANT
                  _INVENTORY = .INVENTORY
                  _PRDBALANCE = .PRDBALANCE
                  _BALANCE = .BALANCE
                  _ISSDATE = .ISSDATE
                  _ORDDATE = .ORDDATE
                  _PORDNAME = .PORDNAME
                  _PLINE = .PLINE
                  _PRDI = .PRDI
                  _REQDATE = .REQDATE
                  _DUEDATE = .DUEDATE
                  _PPARTNAME = .PPARTNAME
                  _SERIALNAME = .SERIALNAME
                  _ORDNAME = .ORDNAME
                  _LINE = .LINE
                  _PARTNAME = .PARTNAME
                  _DOCNO = .DOCNO
                  _PROJDES = .PROJDES
                  _IND = .IND
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Projected Balances (buy/sell)")>  _
    Public Class QUERY_PRDLOGPUR
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PRDLOGPUR)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PRDLOGPUR)
            _Parent = nothing
            _Name = "PRDLOGPUR"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PRDLOGPUR)
            _Parent = Parent
            _name = "PRDLOGPUR_SUBFORM"
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
        
        Public Property Value() As list(of PRDLOGPUR)
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
                return GetType(PRDLOGPUR)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PRDLOGPUR As PRDLOGPUR In JsonConvert.DeserializeObject(Of QUERY_PRDLOGPUR)(stream.ReadToEnd).Value
              With _PRDLOGPUR
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PRDLOGPUR)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PRDLOGPUR = JsonConvert.DeserializeObject(Of PRDLOGPUR)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PRDLOGPUR)
                  .SDATE = obj.SDATE
                  .TYPE = obj.TYPE
                  .OQUANT = obj.OQUANT
                  .INVENTORY = obj.INVENTORY
                  .PRDBALANCE = obj.PRDBALANCE
                  .BALANCE = obj.BALANCE
                  .ISSDATE = obj.ISSDATE
                  .ORDDATE = obj.ORDDATE
                  .PORDNAME = obj.PORDNAME
                  .PLINE = obj.PLINE
                  .PRDI = obj.PRDI
                  .REQDATE = obj.REQDATE
                  .DUEDATE = obj.DUEDATE
                  .PPARTNAME = obj.PPARTNAME
                  .SERIALNAME = obj.SERIALNAME
                  .ORDNAME = obj.ORDNAME
                  .LINE = obj.LINE
                  .PARTNAME = obj.PARTNAME
                  .DOCNO = obj.DOCNO
                  .PROJDES = obj.PROJDES
                  .IND = obj.IND
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PRDLOGPUR(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PRDLOGPUR as PRDLOGPUR in value
              If _PRDLOGPUR.Equals(trycast(obj,PRDLOGPUR)) Then
                  value.remove(_PRDLOGPUR)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PRDLOGPUR
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _SDATE As System.DateTimeOffset
        
        Private _TYPE As String
        
        Private _OQUANT As Decimal
        
        Private _INVENTORY As Decimal
        
        Private _PRDBALANCE As Decimal
        
        Private _BALANCE As Decimal
        
        Private _ISSDATE As System.DateTimeOffset
        
        Private _ORDDATE As System.DateTimeOffset
        
        Private _PORDNAME As String
        
        Private _IsSetPLINE As Boolean = Boolean.FalseString
        
        Private _PLINE As Long
        
        Private _PRDI As Long
        
        Private _REQDATE As System.DateTimeOffset
        
        Private _DUEDATE As System.DateTimeOffset
        
        Private _PPARTNAME As String
        
        Private _SERIALNAME As String
        
        Private _ORDNAME As String
        
        Private _IsSetLINE As Boolean = Boolean.FalseString
        
        Private _LINE As Long
        
        Private _PARTNAME As String
        
        Private _DOCNO As String
        
        Private _PROJDES As String
        
        Private _IND As Long
        
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
                    return "PRDLOGPUR"
                else
                    return "PRDLOGPUR_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "IND={0}", _
                  string.format("{0}",IND) _ 
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
        
        <DisplayName("Date Expected"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Date Expected"),  _
         Pos(10),  _
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
        
        <DisplayName("Type"),  _
         nType("Edm.String"),  _
         tab("Date Expected"),  _
         Pos(20),  _
         [ReadOnly](true),  _
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
        
        <DisplayName("Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("Date Expected"),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("OQUANT")>  _
        Public Property OQUANT() As nullable(of decimal)
            Get
                return _OQUANT
            End Get
            Set
                if not(value is nothing) then
                  _OQUANT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Change in Inventory"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("Date Expected"),  _
         Pos(33),  _
         [ReadOnly](true),  _
         twodBarcode("INVENTORY")>  _
        Public Property INVENTORY() As nullable(of decimal)
            Get
                return _INVENTORY
            End Get
            Set
                if not(value is nothing) then
                  _INVENTORY = Value
                end if
            End Set
        End Property
        
        <DisplayName("Bal Includ. Demands"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("Date Expected"),  _
         Pos(36),  _
         [ReadOnly](true),  _
         twodBarcode("PRDBALANCE")>  _
        Public Property PRDBALANCE() As nullable(of decimal)
            Get
                return _PRDBALANCE
            End Get
            Set
                if not(value is nothing) then
                  _PRDBALANCE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Bal W/out Demands"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("Date Expected"),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("BALANCE")>  _
        Public Property BALANCE() As nullable(of decimal)
            Get
                return _BALANCE
            End Get
            Set
                if not(value is nothing) then
                  _BALANCE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Demand Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Date Expected"),  _
         Pos(50),  _
         [ReadOnly](true),  _
         twodBarcode("ISSDATE")>  _
        Public Property ISSDATE() As nullable (of DateTimeOffset)
            Get
                return _ISSDATE
            End Get
            Set
                if not(value is nothing) then
                  _ISSDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Expedited Ord-Onhand"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Date Expected"),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("ORDDATE")>  _
        Public Property ORDDATE() As nullable (of DateTimeOffset)
            Get
                return _ORDDATE
            End Get
            Set
                if not(value is nothing) then
                  _ORDDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Purchase Order"),  _
         nType("Edm.String"),  _
         tab("Purchase Order"),  _
         Pos(85),  _
         [ReadOnly](true),  _
         twodBarcode("PORDNAME")>  _
        Public Property PORDNAME() As String
            Get
                return _PORDNAME
            End Get
            Set
                if not(value is nothing) then
                  _PORDNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("PLINE"),  _
         nType("Edm.Int64"),  _
         tab("Purchase Order"),  _
         Pos(0),  _
         twodBarcode("PLINE")>  _
        Public Property PLINE() As nullable (of int64)
            Get
                return _PLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("PLINE", value, "^[0-9\-]+$") then Exit Property
                _IsSetPLINE = True
                If loading Then
                  _PLINE = Value
                Else
                    if not _PLINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PLINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PLINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("PR Number"),  _
         nType("Edm.Int64"),  _
         tab("Purchase Order"),  _
         Pos(90),  _
         [ReadOnly](true),  _
         twodBarcode("PRDI")>  _
        Public Property PRDI() As nullable (of int64)
            Get
                return _PRDI
            End Get
            Set
                if not(value is nothing) then
                  _PRDI = Value
                end if
            End Set
        End Property
        
        <DisplayName("Recom. Due Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Purchase Order"),  _
         Pos(100),  _
         [ReadOnly](true),  _
         twodBarcode("REQDATE")>  _
        Public Property REQDATE() As nullable (of DateTimeOffset)
            Get
                return _REQDATE
            End Get
            Set
                if not(value is nothing) then
                  _REQDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Recom. Ord Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Purchase Order"),  _
         Pos(110),  _
         [ReadOnly](true),  _
         twodBarcode("DUEDATE")>  _
        Public Property DUEDATE() As nullable (of DateTimeOffset)
            Get
                return _DUEDATE
            End Get
            Set
                if not(value is nothing) then
                  _DUEDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Parent Part Number"),  _
         nType("Edm.String"),  _
         tab("Purchase Order"),  _
         Pos(120),  _
         [ReadOnly](true),  _
         twodBarcode("PPARTNAME")>  _
        Public Property PPARTNAME() As String
            Get
                return _PPARTNAME
            End Get
            Set
                if not(value is nothing) then
                  _PPARTNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Work Order/Lot"),  _
         nType("Edm.String"),  _
         tab("Purchase Order"),  _
         Pos(125),  _
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
        
        <DisplayName("Sales Order"),  _
         nType("Edm.String"),  _
         tab("Purchase Order"),  _
         Pos(150),  _
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
        
        <DisplayName("LINE"),  _
         nType("Edm.Int64"),  _
         tab("LINE"),  _
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
        
        <DisplayName("Top-Level Part No."),  _
         nType("Edm.String"),  _
         tab("LINE"),  _
         Pos(170),  _
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
        
        <DisplayName("Project Number"),  _
         nType("Edm.String"),  _
         tab("LINE"),  _
         Pos(180),  _
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
        
        <DisplayName("Project Description"),  _
         nType("Edm.String"),  _
         tab("LINE"),  _
         Pos(190),  _
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
        
        <DisplayName("Key (ID)"),  _
         nType("Edm.Int64"),  _
         tab("LINE"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("IND")>  _
        Public Property IND() As nullable (of int64)
            Get
                return _IND
            End Get
            Set
                if not(value is nothing) then
                  _IND = Value
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetPLINE then
              if f then
                  jw.WriteRaw(", ""PLINE"": ")
              else
                  jw.WriteRaw("""PLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.PLINE)
            end if
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
                .WriteAttributeString("name", "PRDLOGPUR")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "IND")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetPLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PLINE")
              .WriteAttributeString("value", me.PLINE)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
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
                dim obj as PRDLOGPUR = JsonConvert.DeserializeObject(Of PRDLOGPUR)(e.StreamReader.ReadToEnd)
                With obj
                  _SDATE = .SDATE
                  _TYPE = .TYPE
                  _OQUANT = .OQUANT
                  _INVENTORY = .INVENTORY
                  _PRDBALANCE = .PRDBALANCE
                  _BALANCE = .BALANCE
                  _ISSDATE = .ISSDATE
                  _ORDDATE = .ORDDATE
                  _PORDNAME = .PORDNAME
                  _PLINE = .PLINE
                  _PRDI = .PRDI
                  _REQDATE = .REQDATE
                  _DUEDATE = .DUEDATE
                  _PPARTNAME = .PPARTNAME
                  _SERIALNAME = .SERIALNAME
                  _ORDNAME = .ORDNAME
                  _LINE = .LINE
                  _PARTNAME = .PARTNAME
                  _DOCNO = .DOCNO
                  _PROJDES = .PROJDES
                  _IND = .IND
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("MRP Analysis - Raw Materials")>  _
    Public Class QUERY_MRPDEMANDRAW
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of MRPDEMANDRAW)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of MRPDEMANDRAW)
            _Parent = nothing
            _Name = "MRPDEMANDRAW"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Use of Alternate Stock-Details")
            .add(1, "Use of Open Work Orders-Details")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of MRPDEMANDRAW)
            _Parent = Parent
            _name = "MRPDEMANDRAW_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Use of Alternate Stock-Details")
            .add(1, "Use of Open Work Orders-Details")
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
        
        Public Property Value() As list(of MRPDEMANDRAW)
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
                return GetType(MRPDEMANDRAW)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _MRPDEMANDRAW As MRPDEMANDRAW In JsonConvert.DeserializeObject(Of QUERY_MRPDEMANDRAW)(stream.ReadToEnd).Value
              With _MRPDEMANDRAW
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_MRPDEMANDRAW)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as MRPDEMANDRAW = JsonConvert.DeserializeObject(Of MRPDEMANDRAW)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, MRPDEMANDRAW)
                  .TYPE = obj.TYPE
                  .DUEDATE = obj.DUEDATE
                  .ODEMAND = obj.ODEMAND
                  .FLOORSTOCK = obj.FLOORSTOCK
                  .ALTFLOORSTOCK = obj.ALTFLOORSTOCK
                  .SERSTOCK = obj.SERSTOCK
                  .SCRAPADDED = obj.SCRAPADDED
                  .QUANT = obj.QUANT
                  .PARTNAME = obj.PARTNAME
                  .PARTDES = obj.PARTDES
                  .SERIALNAME = obj.SERIALNAME
                  .ORIGPARTNAME = obj.ORIGPARTNAME
                  .ORIGPARTDES = obj.ORIGPARTDES
                  .WARHSNAME = obj.WARHSNAME
                  .DOCNO = obj.DOCNO
                  .PROJDES = obj.PROJDES
                  .UDATE = obj.UDATE
                  .USERLOGIN = obj.USERLOGIN
                  .RUNTYPE = obj.RUNTYPE
                  .IND = obj.IND
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new MRPDEMANDRAW(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _MRPDEMANDRAW as MRPDEMANDRAW in value
              If _MRPDEMANDRAW.Equals(trycast(obj,MRPDEMANDRAW)) Then
                  value.remove(_MRPDEMANDRAW)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class MRPDEMANDRAW
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _TYPE As String
        
        Private _DUEDATE As System.DateTimeOffset
        
        Private _ODEMAND As Decimal
        
        Private _FLOORSTOCK As Decimal
        
        Private _ALTFLOORSTOCK As Decimal
        
        Private _SERSTOCK As Decimal
        
        Private _SCRAPADDED As Decimal
        
        Private _QUANT As Decimal
        
        Private _PARTNAME As String
        
        Private _PARTDES As String
        
        Private _SERIALNAME As String
        
        Private _ORIGPARTNAME As String
        
        Private _ORIGPARTDES As String
        
        Private _WARHSNAME As String
        
        Private _DOCNO As String
        
        Private _PROJDES As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _USERLOGIN As String
        
        Private _RUNTYPE As String
        
        Private _IND As Long
        
        Private _MRPDEMANDRAWALT_SUBFORM As QUERY_MRPDEMANDRAWALT
        
        Private _MRPDEMANDRAWSER_SUBFORM As QUERY_MRPDEMANDRAWSER
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Use of Alternate Stock-Details"))
            ChildQuery.add(1, new oNavigation("Use of Open Work Orders-Details"))
            _MRPDEMANDRAWALT_SUBFORM = new QUERY_MRPDEMANDRAWALT(me)
            _MRPDEMANDRAWSER_SUBFORM = new QUERY_MRPDEMANDRAWSER(me)
            WITH ChildQuery(0)
               .setoDataQuery(_MRPDEMANDRAWALT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Use of Alternate Stock-Details", _MRPDEMANDRAWALT_SUBFORM))
                   .add(1, new oNavigation("Use of Open Work Orders-Details", _MRPDEMANDRAWSER_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_MRPDEMANDRAWSER_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Use of Alternate Stock-Details", _MRPDEMANDRAWALT_SUBFORM))
                   .add(1, new oNavigation("Use of Open Work Orders-Details", _MRPDEMANDRAWSER_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Use of Alternate Stock-Details"))
            ChildQuery.add(1, new oNavigation("Use of Open Work Orders-Details"))
            _MRPDEMANDRAWALT_SUBFORM = new QUERY_MRPDEMANDRAWALT(me)
            _MRPDEMANDRAWSER_SUBFORM = new QUERY_MRPDEMANDRAWSER(me)
            WITH ChildQuery(0)
               .setoDataQuery(_MRPDEMANDRAWALT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Use of Alternate Stock-Details", _MRPDEMANDRAWALT_SUBFORM))
                   .add(1, new oNavigation("Use of Open Work Orders-Details", _MRPDEMANDRAWSER_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_MRPDEMANDRAWSER_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Use of Alternate Stock-Details", _MRPDEMANDRAWALT_SUBFORM))
                   .add(1, new oNavigation("Use of Open Work Orders-Details", _MRPDEMANDRAWSER_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "MRPDEMANDRAW"
                else
                    return "MRPDEMANDRAW_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "IND={0}", _
                  string.format("{0}",IND) _ 
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
        
        <DisplayName("Type of Demand/Inv"),  _
         nType("Edm.String"),  _
         tab("Type of Demand/Inv"),  _
         Pos(5),  _
         [ReadOnly](true),  _
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
        
        <DisplayName("Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Type of Demand/Inv"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("DUEDATE")>  _
        Public Property DUEDATE() As nullable (of DateTimeOffset)
            Get
                return _DUEDATE
            End Get
            Set
                if not(value is nothing) then
                  _DUEDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Original Demand"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Type of Demand/Inv"),  _
         Pos(15),  _
         [ReadOnly](true),  _
         twodBarcode("ODEMAND")>  _
        Public Property ODEMAND() As nullable(of decimal)
            Get
                return _ODEMAND
            End Get
            Set
                if not(value is nothing) then
                  _ODEMAND = Value
                end if
            End Set
        End Property
        
        <DisplayName("Use of Floor Stock"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Type of Demand/Inv"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("FLOORSTOCK")>  _
        Public Property FLOORSTOCK() As nullable(of decimal)
            Get
                return _FLOORSTOCK
            End Get
            Set
                if not(value is nothing) then
                  _FLOORSTOCK = Value
                end if
            End Set
        End Property
        
        <DisplayName("Use of Altern. Stock"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Type of Demand/Inv"),  _
         Pos(25),  _
         [ReadOnly](true),  _
         twodBarcode("ALTFLOORSTOCK")>  _
        Public Property ALTFLOORSTOCK() As nullable(of decimal)
            Get
                return _ALTFLOORSTOCK
            End Get
            Set
                if not(value is nothing) then
                  _ALTFLOORSTOCK = Value
                end if
            End Set
        End Property
        
        <DisplayName("Use of Open WorkOrds"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Type of Demand/Inv"),  _
         Pos(27),  _
         [ReadOnly](true),  _
         twodBarcode("SERSTOCK")>  _
        Public Property SERSTOCK() As nullable(of decimal)
            Get
                return _SERSTOCK
            End Get
            Set
                if not(value is nothing) then
                  _SERSTOCK = Value
                end if
            End Set
        End Property
        
        <DisplayName("Added Planned Scrap"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Type of Demand/Inv"),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("SCRAPADDED")>  _
        Public Property SCRAPADDED() As nullable(of decimal)
            Get
                return _SCRAPADDED
            End Get
            Set
                if not(value is nothing) then
                  _SCRAPADDED = Value
                end if
            End Set
        End Property
        
        <DisplayName("Planned Issue"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(13),  _
         tab("Type of Demand/Inv"),  _
         Pos(60),  _
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
        
        <DisplayName("Parent Part Number"),  _
         nType("Edm.String"),  _
         tab("Parent Part Number"),  _
         Pos(80),  _
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
        
        <DisplayName("Part Description"),  _
         nType("Edm.String"),  _
         tab("Parent Part Number"),  _
         Pos(85),  _
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
         tab("Parent Part Number"),  _
         Pos(87),  _
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
        
        <DisplayName("For Alternate Part"),  _
         nType("Edm.String"),  _
         tab("Parent Part Number"),  _
         Pos(89),  _
         [ReadOnly](true),  _
         twodBarcode("ORIGPARTNAME")>  _
        Public Property ORIGPARTNAME() As String
            Get
                return _ORIGPARTNAME
            End Get
            Set
                if not(value is nothing) then
                  _ORIGPARTNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Part Description"),  _
         nType("Edm.String"),  _
         tab("Parent Part Number"),  _
         Pos(90),  _
         [ReadOnly](true),  _
         twodBarcode("ORIGPARTDES")>  _
        Public Property ORIGPARTDES() As String
            Get
                return _ORIGPARTDES
            End Get
            Set
                if not(value is nothing) then
                  _ORIGPARTDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Target Warehouse"),  _
         nType("Edm.String"),  _
         tab("Parent Part Number"),  _
         Pos(92),  _
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
        
        <DisplayName("Project Number"),  _
         nType("Edm.String"),  _
         tab("Parent Part Number"),  _
         Pos(93),  _
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
        
        <DisplayName("Project Description"),  _
         nType("Edm.String"),  _
         tab("Parent Part Number"),  _
         Pos(94),  _
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
        
        <DisplayName("Last Run Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Last Run Date"),  _
         Pos(95),  _
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
        
        <DisplayName("User Name"),  _
         nType("Edm.String"),  _
         tab("Last Run Date"),  _
         Pos(97),  _
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
        
        <DisplayName("Type of MRP"),  _
         nType("Edm.String"),  _
         tab("Last Run Date"),  _
         Pos(100),  _
         [ReadOnly](true),  _
         twodBarcode("RUNTYPE")>  _
        Public Property RUNTYPE() As String
            Get
                return _RUNTYPE
            End Get
            Set
                if not(value is nothing) then
                  _RUNTYPE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Key (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Last Run Date"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("IND")>  _
        Public Property IND() As nullable (of int64)
            Get
                return _IND
            End Get
            Set
                if not(value is nothing) then
                  _IND = Value
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property MRPDEMANDRAWALT_SUBFORM() As QUERY_MRPDEMANDRAWALT
            Get
                return _MRPDEMANDRAWALT_SUBFORM
            End Get
            Set
                _MRPDEMANDRAWALT_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property MRPDEMANDRAWSER_SUBFORM() As QUERY_MRPDEMANDRAWSER
            Get
                return _MRPDEMANDRAWSER_SUBFORM
            End Get
            Set
                _MRPDEMANDRAWSER_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _MRPDEMANDRAWALT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", MRPDEMANDRAWALT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as MRPDEMANDRAWALT in _MRPDEMANDRAWALT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _MRPDEMANDRAWALT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _MRPDEMANDRAWSER_SUBFORM.value.count > 0 then
              jw.WriteRaw(", MRPDEMANDRAWSER_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as MRPDEMANDRAWSER in _MRPDEMANDRAWSER_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _MRPDEMANDRAWSER_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "MRPDEMANDRAW")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "IND")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _MRPDEMANDRAWALT_SUBFORM.value.count > 0 then
              for each itm as MRPDEMANDRAWALT in _MRPDEMANDRAWALT_SUBFORM.Value
                itm.toXML(xw,"MRPDEMANDRAWALT_SUBFORM")
              next
            end if
            if _MRPDEMANDRAWSER_SUBFORM.value.count > 0 then
              for each itm as MRPDEMANDRAWSER in _MRPDEMANDRAWSER_SUBFORM.Value
                itm.toXML(xw,"MRPDEMANDRAWSER_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as MRPDEMANDRAW = JsonConvert.DeserializeObject(Of MRPDEMANDRAW)(e.StreamReader.ReadToEnd)
                With obj
                  _TYPE = .TYPE
                  _DUEDATE = .DUEDATE
                  _ODEMAND = .ODEMAND
                  _FLOORSTOCK = .FLOORSTOCK
                  _ALTFLOORSTOCK = .ALTFLOORSTOCK
                  _SERSTOCK = .SERSTOCK
                  _SCRAPADDED = .SCRAPADDED
                  _QUANT = .QUANT
                  _PARTNAME = .PARTNAME
                  _PARTDES = .PARTDES
                  _SERIALNAME = .SERIALNAME
                  _ORIGPARTNAME = .ORIGPARTNAME
                  _ORIGPARTDES = .ORIGPARTDES
                  _WARHSNAME = .WARHSNAME
                  _DOCNO = .DOCNO
                  _PROJDES = .PROJDES
                  _UDATE = .UDATE
                  _USERLOGIN = .USERLOGIN
                  _RUNTYPE = .RUNTYPE
                  _IND = .IND
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_MRPDEMANDRAW
        
        MRPDEMANDRAWALT = 0
        
        MRPDEMANDRAWSER = 1
    End Enum
    
    <QueryTitle("Use of Alternate Stock-Details")>  _
    Public Class QUERY_MRPDEMANDRAWALT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of MRPDEMANDRAWALT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of MRPDEMANDRAWALT)
            _Parent = nothing
            _Name = "MRPDEMANDRAWALT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of MRPDEMANDRAWALT)
            _Parent = Parent
            _name = "MRPDEMANDRAWALT_SUBFORM"
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
        
        Public Property Value() As list(of MRPDEMANDRAWALT)
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
                return GetType(MRPDEMANDRAWALT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _MRPDEMANDRAWALT As MRPDEMANDRAWALT In JsonConvert.DeserializeObject(Of QUERY_MRPDEMANDRAWALT)(stream.ReadToEnd).Value
              With _MRPDEMANDRAWALT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_MRPDEMANDRAWALT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as MRPDEMANDRAWALT = JsonConvert.DeserializeObject(Of MRPDEMANDRAWALT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, MRPDEMANDRAWALT)
                  .PARTNAME = obj.PARTNAME
                  .PARTDES = obj.PARTDES
                  .QUANT = obj.QUANT
                  .PART = obj.PART
                  .TYPE = obj.TYPE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new MRPDEMANDRAWALT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _MRPDEMANDRAWALT as MRPDEMANDRAWALT in value
              If _MRPDEMANDRAWALT.Equals(trycast(obj,MRPDEMANDRAWALT)) Then
                  value.remove(_MRPDEMANDRAWALT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class MRPDEMANDRAWALT
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _PARTNAME As String
        
        Private _PARTDES As String
        
        Private _QUANT As Decimal
        
        Private _PART As Long
        
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
                    return "MRPDEMANDRAWALT"
                else
                    return "MRPDEMANDRAWALT_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "PART={0},TYPE={1}", _
                  string.format("{0}",PART), _
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
        
        <DisplayName("Part Description"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(20),  _
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
        
        <DisplayName("Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Part Number"),  _
         Pos(30),  _
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
        
        <DisplayName("Part (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Part Number"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("PART")>  _
        Public Property PART() As nullable (of int64)
            Get
                return _PART
            End Get
            Set
                if not(value is nothing) then
                  _PART = Value
                end if
            End Set
        End Property
        
        <DisplayName("Type"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(20),  _
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
                .WriteAttributeString("name", "MRPDEMANDRAWALT")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "PART")
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
                dim obj as MRPDEMANDRAWALT = JsonConvert.DeserializeObject(Of MRPDEMANDRAWALT)(e.StreamReader.ReadToEnd)
                With obj
                  _PARTNAME = .PARTNAME
                  _PARTDES = .PARTDES
                  _QUANT = .QUANT
                  _PART = .PART
                  _TYPE = .TYPE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Use of Open Work Orders-Details")>  _
    Public Class QUERY_MRPDEMANDRAWSER
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of MRPDEMANDRAWSER)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of MRPDEMANDRAWSER)
            _Parent = nothing
            _Name = "MRPDEMANDRAWSER"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of MRPDEMANDRAWSER)
            _Parent = Parent
            _name = "MRPDEMANDRAWSER_SUBFORM"
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
        
        Public Property Value() As list(of MRPDEMANDRAWSER)
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
                return GetType(MRPDEMANDRAWSER)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _MRPDEMANDRAWSER As MRPDEMANDRAWSER In JsonConvert.DeserializeObject(Of QUERY_MRPDEMANDRAWSER)(stream.ReadToEnd).Value
              With _MRPDEMANDRAWSER
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_MRPDEMANDRAWSER)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as MRPDEMANDRAWSER = JsonConvert.DeserializeObject(Of MRPDEMANDRAWSER)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, MRPDEMANDRAWSER)
                  .SERIALNAME = obj.SERIALNAME
                  .QUANT = obj.QUANT
                  .PART = obj.PART
                  .TYPE = obj.TYPE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new MRPDEMANDRAWSER(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _MRPDEMANDRAWSER as MRPDEMANDRAWSER in value
              If _MRPDEMANDRAWSER.Equals(trycast(obj,MRPDEMANDRAWSER)) Then
                  value.remove(_MRPDEMANDRAWSER)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class MRPDEMANDRAWSER
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _SERIALNAME As String
        
        Private _QUANT As Decimal
        
        Private _PART As Long
        
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
                    return "MRPDEMANDRAWSER"
                else
                    return "MRPDEMANDRAWSER_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "PART={0},TYPE={1}", _
                  string.format("{0}",PART), _
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
        
        <DisplayName("Work Order"),  _
         nType("Edm.String"),  _
         tab("Work Order"),  _
         Pos(10),  _
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
        
        <DisplayName("Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Work Order"),  _
         Pos(30),  _
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
        
        <DisplayName("Part (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Work Order"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("PART")>  _
        Public Property PART() As nullable (of int64)
            Get
                return _PART
            End Get
            Set
                if not(value is nothing) then
                  _PART = Value
                end if
            End Set
        End Property
        
        <DisplayName("Type"),  _
         nType("Edm.String"),  _
         tab("Work Order"),  _
         Pos(20),  _
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
                .WriteAttributeString("name", "MRPDEMANDRAWSER")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "PART")
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
                dim obj as MRPDEMANDRAWSER = JsonConvert.DeserializeObject(Of MRPDEMANDRAWSER)(e.StreamReader.ReadToEnd)
                With obj
                  _SERIALNAME = .SERIALNAME
                  _QUANT = .QUANT
                  _PART = .PART
                  _TYPE = .TYPE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("MRP Analysis - Processed Parts")>  _
    Public Class QUERY_MRPDEMAND
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of MRPDEMAND)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of MRPDEMAND)
            _Parent = nothing
            _Name = "MRPDEMAND"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of MRPDEMAND)
            _Parent = Parent
            _name = "MRPDEMAND_SUBFORM"
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
        
        Public Property Value() As list(of MRPDEMAND)
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
                return GetType(MRPDEMAND)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _MRPDEMAND As MRPDEMAND In JsonConvert.DeserializeObject(Of QUERY_MRPDEMAND)(stream.ReadToEnd).Value
              With _MRPDEMAND
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_MRPDEMAND)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as MRPDEMAND = JsonConvert.DeserializeObject(Of MRPDEMAND)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, MRPDEMAND)
                  .DUEDATE = obj.DUEDATE
                  .TYPE = obj.TYPE
                  .QUANT = obj.QUANT
                  .INVENTORY = obj.INVENTORY
                  .BALANCE = obj.BALANCE
                  .SERIALNAME = obj.SERIALNAME
                  .PARTNAME = obj.PARTNAME
                  .PARTDES = obj.PARTDES
                  .ALTPARTNAME = obj.ALTPARTNAME
                  .ALTPARTDES = obj.ALTPARTDES
                  .ORDNAME = obj.ORDNAME
                  .LINE = obj.LINE
                  .PORDNAME = obj.PORDNAME
                  .PLINE = obj.PLINE
                  .DOCNO = obj.DOCNO
                  .PROJDES = obj.PROJDES
                  .UDATE = obj.UDATE
                  .USERLOGIN = obj.USERLOGIN
                  .RUNTYPE = obj.RUNTYPE
                  .IND = obj.IND
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new MRPDEMAND(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _MRPDEMAND as MRPDEMAND in value
              If _MRPDEMAND.Equals(trycast(obj,MRPDEMAND)) Then
                  value.remove(_MRPDEMAND)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class MRPDEMAND
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _DUEDATE As System.DateTimeOffset
        
        Private _TYPE As String
        
        Private _QUANT As Decimal
        
        Private _INVENTORY As Decimal
        
        Private _BALANCE As Decimal
        
        Private _SERIALNAME As String
        
        Private _PARTNAME As String
        
        Private _PARTDES As String
        
        Private _ALTPARTNAME As String
        
        Private _ALTPARTDES As String
        
        Private _ORDNAME As String
        
        Private _IsSetLINE As Boolean = Boolean.FalseString
        
        Private _LINE As Long
        
        Private _PORDNAME As String
        
        Private _IsSetPLINE As Boolean = Boolean.FalseString
        
        Private _PLINE As Long
        
        Private _DOCNO As String
        
        Private _PROJDES As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _USERLOGIN As String
        
        Private _RUNTYPE As String
        
        Private _IND As Long
        
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
                    return "MRPDEMAND"
                else
                    return "MRPDEMAND_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "IND={0}", _
                  string.format("{0}",IND) _ 
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
         Pos(5),  _
         [ReadOnly](true),  _
         twodBarcode("DUEDATE")>  _
        Public Property DUEDATE() As nullable (of DateTimeOffset)
            Get
                return _DUEDATE
            End Get
            Set
                if not(value is nothing) then
                  _DUEDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Type of Demand/Inv"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(10),  _
         [ReadOnly](true),  _
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
        
        <DisplayName("Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Date"),  _
         Pos(15),  _
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
        
        <DisplayName("Effect on Inventory"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Date"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("INVENTORY")>  _
        Public Property INVENTORY() As nullable(of decimal)
            Get
                return _INVENTORY
            End Get
            Set
                if not(value is nothing) then
                  _INVENTORY = Value
                end if
            End Set
        End Property
        
        <DisplayName("Projected Inv Bal"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Date"),  _
         Pos(25),  _
         [ReadOnly](true),  _
         twodBarcode("BALANCE")>  _
        Public Property BALANCE() As nullable(of decimal)
            Get
                return _BALANCE
            End Get
            Set
                if not(value is nothing) then
                  _BALANCE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Work Order/Lot"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(30),  _
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
        
        <DisplayName("Parent Part Number"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(40),  _
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
        
        <DisplayName("Part Description"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(45),  _
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
        
        <DisplayName("Alternate Part"),  _
         nType("Edm.String"),  _
         tab("Alternate Part"),  _
         Pos(50),  _
         [ReadOnly](true),  _
         twodBarcode("ALTPARTNAME")>  _
        Public Property ALTPARTNAME() As String
            Get
                return _ALTPARTNAME
            End Get
            Set
                if not(value is nothing) then
                  _ALTPARTNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Part Description"),  _
         nType("Edm.String"),  _
         tab("Alternate Part"),  _
         Pos(55),  _
         [ReadOnly](true),  _
         twodBarcode("ALTPARTDES")>  _
        Public Property ALTPARTDES() As String
            Get
                return _ALTPARTDES
            End Get
            Set
                if not(value is nothing) then
                  _ALTPARTDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Sales Order"),  _
         nType("Edm.String"),  _
         tab("Alternate Part"),  _
         Pos(60),  _
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
        
        <DisplayName("LINE"),  _
         nType("Edm.Int64"),  _
         tab("Alternate Part"),  _
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
        
        <DisplayName("Purchase Order"),  _
         nType("Edm.String"),  _
         tab("Alternate Part"),  _
         Pos(70),  _
         [ReadOnly](true),  _
         twodBarcode("PORDNAME")>  _
        Public Property PORDNAME() As String
            Get
                return _PORDNAME
            End Get
            Set
                if not(value is nothing) then
                  _PORDNAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("PLINE"),  _
         nType("Edm.Int64"),  _
         tab("Alternate Part"),  _
         Pos(0),  _
         twodBarcode("PLINE")>  _
        Public Property PLINE() As nullable (of int64)
            Get
                return _PLINE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("PLINE", value, "^[0-9\-]+$") then Exit Property
                _IsSetPLINE = True
                If loading Then
                  _PLINE = Value
                Else
                    if not _PLINE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("PLINE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _PLINE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Project Number"),  _
         nType("Edm.String"),  _
         tab("Alternate Part"),  _
         Pos(80),  _
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
        
        <DisplayName("Project Description"),  _
         nType("Edm.String"),  _
         tab("Alternate Part"),  _
         Pos(85),  _
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
        
        <DisplayName("Last Run Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Last Run Date"),  _
         Pos(90),  _
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
        
        <DisplayName("User Name"),  _
         nType("Edm.String"),  _
         tab("Last Run Date"),  _
         Pos(95),  _
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
        
        <DisplayName("Type of MRP"),  _
         nType("Edm.String"),  _
         tab("Last Run Date"),  _
         Pos(100),  _
         [ReadOnly](true),  _
         twodBarcode("RUNTYPE")>  _
        Public Property RUNTYPE() As String
            Get
                return _RUNTYPE
            End Get
            Set
                if not(value is nothing) then
                  _RUNTYPE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Key (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Last Run Date"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("IND")>  _
        Public Property IND() As nullable (of int64)
            Get
                return _IND
            End Get
            Set
                if not(value is nothing) then
                  _IND = Value
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
            if _IsSetPLINE then
              if f then
                  jw.WriteRaw(", ""PLINE"": ")
              else
                  jw.WriteRaw("""PLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.PLINE)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "MRPDEMAND")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "IND")
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
            if _IsSetPLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "PLINE")
              .WriteAttributeString("value", me.PLINE)
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
                dim obj as MRPDEMAND = JsonConvert.DeserializeObject(Of MRPDEMAND)(e.StreamReader.ReadToEnd)
                With obj
                  _DUEDATE = .DUEDATE
                  _TYPE = .TYPE
                  _QUANT = .QUANT
                  _INVENTORY = .INVENTORY
                  _BALANCE = .BALANCE
                  _SERIALNAME = .SERIALNAME
                  _PARTNAME = .PARTNAME
                  _PARTDES = .PARTDES
                  _ALTPARTNAME = .ALTPARTNAME
                  _ALTPARTDES = .ALTPARTDES
                  _ORDNAME = .ORDNAME
                  _LINE = .LINE
                  _PORDNAME = .PORDNAME
                  _PLINE = .PLINE
                  _DOCNO = .DOCNO
                  _PROJDES = .PROJDES
                  _UDATE = .UDATE
                  _USERLOGIN = .USERLOGIN
                  _RUNTYPE = .RUNTYPE
                  _IND = .IND
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Attachments")>  _
    Public Class QUERY_EXTFILES
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of EXTFILES)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of EXTFILES)
            _Parent = nothing
            _Name = "EXTFILES"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Links to File")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of EXTFILES)
            _Parent = Parent
            _name = "EXTFILES_SUBFORM"
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
        
        Public Property Value() As list(of EXTFILES)
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
                return GetType(EXTFILES)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _EXTFILES As EXTFILES In JsonConvert.DeserializeObject(Of QUERY_EXTFILES)(stream.ReadToEnd).Value
              With _EXTFILES
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_EXTFILES)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as EXTFILES = JsonConvert.DeserializeObject(Of EXTFILES)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, EXTFILES)
                  .EXTFILEDES = obj.EXTFILEDES
                  .EXTFILENUM = obj.EXTFILENUM
                  .EXTFILENAME = obj.EXTFILENAME
                  .SUFFIX = obj.SUFFIX
                  .CURDATE = obj.CURDATE
                  .NOSEND = obj.NOSEND
                  .STATUS = obj.STATUS
                  .FILESIZE = obj.FILESIZE
                  .EI_COND = obj.EI_COND
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .LUSERLOGIN = obj.LUSERLOGIN
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new EXTFILES(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _EXTFILES as EXTFILES in value
              If _EXTFILES.Equals(trycast(obj,EXTFILES)) Then
                  value.remove(_EXTFILES)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class EXTFILES
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetEXTFILEDES As Boolean = Boolean.FalseString
        
        Private _EXTFILEDES As String
        
        Private _EXTFILENUM As Long
        
        Private _IsSetEXTFILENAME As Boolean = Boolean.FalseString
        
        Private _EXTFILENAME As String
        
        Private _SUFFIX As String
        
        Private _IsSetCURDATE As Boolean = Boolean.FalseString
        
        Private _CURDATE As System.DateTimeOffset
        
        Private _IsSetNOSEND As Boolean = Boolean.FalseString
        
        Private _NOSEND As String
        
        Private _IsSetSTATUS As Boolean = Boolean.FalseString
        
        Private _STATUS As String
        
        Private _FILESIZE As Long
        
        Private _IsSetEI_COND As Boolean = Boolean.FalseString
        
        Private _EI_COND As String
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _LUSERLOGIN As String
        
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
                    return "EXTFILES"
                else
                    return "EXTFILES_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "EXTFILENUM={0}", _
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
         Pos(10),  _
         Mandatory(true),  _
         twodBarcode("EXTFILEDES")>  _
        Public Property EXTFILEDES() As String
            Get
                return _EXTFILEDES
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("File Name", value, "^.{0,32}$") then Exit Property
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
        
        <DisplayName("Attachment Number"),  _
         nType("Edm.Int64"),  _
         tab("File Name"),  _
         Pos(20),  _
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
        
        <DisplayName("File Creation Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("File Name"),  _
         Pos(50),  _
         twodBarcode("CURDATE")>  _
        Public Property CURDATE() As nullable (of DateTimeOffset)
            Get
                return _CURDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("File Creation Date", value, "^.*$") then Exit Property
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
        
        <DisplayName("Don't Send"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(50),  _
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
        
        <DisplayName("File Status"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(55),  _
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
        
        <DisplayName("Send by DataExchange"),  _
         nType("Edm.String"),  _
         tab("Send by DataExchange"),  _
         Pos(99),  _
         twodBarcode("EI_COND")>  _
        Public Property EI_COND() As String
            Get
                return _EI_COND
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Send by DataExchange", value, "^.{0,1}$") then Exit Property
                _IsSetEI_COND = True
                If loading Then
                  _EI_COND = Value
                Else
                    if not _EI_COND = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EI_COND", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EI_COND = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Modified by"),  _
         nType("Edm.String"),  _
         tab("Send by DataExchange"),  _
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
        
        <DisplayName("Date Modified"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Send by DataExchange"),  _
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
        
        <DisplayName("Locked by"),  _
         nType("Edm.String"),  _
         tab("Send by DataExchange"),  _
         Pos(130),  _
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
            if _IsSetEXTFILENAME then
              if f then
                  jw.WriteRaw(", ""EXTFILENAME"": ")
              else
                  jw.WriteRaw("""EXTFILENAME"": ")
                  f = true
              end if
              jw.WriteValue(me.EXTFILENAME)
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
            if _IsSetNOSEND then
              if f then
                  jw.WriteRaw(", ""NOSEND"": ")
              else
                  jw.WriteRaw("""NOSEND"": ")
                  f = true
              end if
              jw.WriteValue(me.NOSEND)
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
            if _IsSetEI_COND then
              if f then
                  jw.WriteRaw(", ""EI_COND"": ")
              else
                  jw.WriteRaw("""EI_COND"": ")
                  f = true
              end if
              jw.WriteValue(me.EI_COND)
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
                .WriteAttributeString("name", "EXTFILES")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
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
              .WriteAttributeString("MaxLength", "32")
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
            if _IsSetCURDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CURDATE")
              .WriteAttributeString("value", me.CURDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
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
            if _IsSetSTATUS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "STATUS")
              .WriteAttributeString("value", me.STATUS)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetEI_COND then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EI_COND")
              .WriteAttributeString("value", me.EI_COND)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
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
                dim obj as EXTFILES = JsonConvert.DeserializeObject(Of EXTFILES)(e.StreamReader.ReadToEnd)
                With obj
                  _EXTFILEDES = .EXTFILEDES
                  _EXTFILENUM = .EXTFILENUM
                  _EXTFILENAME = .EXTFILENAME
                  _SUFFIX = .SUFFIX
                  _CURDATE = .CURDATE
                  _NOSEND = .NOSEND
                  _STATUS = .STATUS
                  _FILESIZE = .FILESIZE
                  _EI_COND = .EI_COND
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _LUSERLOGIN = .LUSERLOGIN
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_EXTFILES
        
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
    
    <QueryTitle("Purchase Demand Authorisation")>  _
    Public Class QUERY_PDUSER
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PDUSER)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PDUSER)
            _Parent = nothing
            _Name = "PDUSER"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PDUSER)
            _Parent = Parent
            _name = "PDUSER_SUBFORM"
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
        
        Public Property Value() As list(of PDUSER)
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
                return GetType(PDUSER)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PDUSER As PDUSER In JsonConvert.DeserializeObject(Of QUERY_PDUSER)(stream.ReadToEnd).Value
              With _PDUSER
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PDUSER)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PDUSER = JsonConvert.DeserializeObject(Of PDUSER)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PDUSER)
                  .AMOUNT = obj.AMOUNT
                  .CODE = obj.CODE
                  .USERLOGIN = obj.USERLOGIN
                  .ALTUSERLOGIN = obj.ALTUSERLOGIN
                  .UFLAG = obj.UFLAG
                  .CUSERLOGIN = obj.CUSERLOGIN
                  .UDATE = obj.UDATE
                  .USER = obj.USER
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PDUSER(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PDUSER as PDUSER in value
              If _PDUSER.Equals(trycast(obj,PDUSER)) Then
                  value.remove(_PDUSER)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PDUSER
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _AMOUNT As Decimal
        
        Private _CODE As String
        
        Private _USERLOGIN As String
        
        Private _ALTUSERLOGIN As String
        
        Private _IsSetUFLAG As Boolean = Boolean.FalseString
        
        Private _UFLAG As String
        
        Private _CUSERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
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
                    return "PDUSER"
                else
                    return "PDUSER_SUBFORM"
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
        
        <DisplayName("Starting From (Amt)"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(13),  _
         tab("Starting From (Amt)"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("AMOUNT")>  _
        Public Property AMOUNT() As nullable(of decimal)
            Get
                return _AMOUNT
            End Get
            Set
                if not(value is nothing) then
                  _AMOUNT = Value
                end if
            End Set
        End Property
        
        <DisplayName("Curr"),  _
         nType("Edm.String"),  _
         tab("Starting From (Amt)"),  _
         Pos(20),  _
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
        
        <DisplayName("Authoriser"),  _
         nType("Edm.String"),  _
         tab("Starting From (Amt)"),  _
         Pos(22),  _
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
        
        <DisplayName("Alternate"),  _
         nType("Edm.String"),  _
         tab("Starting From (Amt)"),  _
         Pos(25),  _
         [ReadOnly](true),  _
         twodBarcode("ALTUSERLOGIN")>  _
        Public Property ALTUSERLOGIN() As String
            Get
                return _ALTUSERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _ALTUSERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Approve"),  _
         nType("Edm.String"),  _
         tab("Starting From (Amt)"),  _
         Pos(30),  _
         twodBarcode("UFLAG")>  _
        Public Property UFLAG() As String
            Get
                return _UFLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Approve", value, "^.{0,1}$") then Exit Property
                _IsSetUFLAG = True
                If loading Then
                  _UFLAG = Value
                Else
                    if not _UFLAG = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("UFLAG", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _UFLAG = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Authorised by"),  _
         nType("Edm.String"),  _
         tab("Starting From (Amt)"),  _
         Pos(35),  _
         [ReadOnly](true),  _
         twodBarcode("CUSERLOGIN")>  _
        Public Property CUSERLOGIN() As String
            Get
                return _CUSERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _CUSERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Authorisation Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Starting From (Amt)"),  _
         Pos(40),  _
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
        
        <DisplayName("User (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Starting From (Amt)"),  _
         Pos(20),  _
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
            if _IsSetUFLAG then
              if f then
                  jw.WriteRaw(", ""UFLAG"": ")
              else
                  jw.WriteRaw("""UFLAG"": ")
                  f = true
              end if
              jw.WriteValue(me.UFLAG)
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
                .WriteAttributeString("name", "PDUSER")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "USER")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetUFLAG then
              .WriteStartElement("field")
              .WriteAttributeString("name", "UFLAG")
              .WriteAttributeString("value", me.UFLAG)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
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
                dim obj as PDUSER = JsonConvert.DeserializeObject(Of PDUSER)(e.StreamReader.ReadToEnd)
                With obj
                  _AMOUNT = .AMOUNT
                  _CODE = .CODE
                  _USERLOGIN = .USERLOGIN
                  _ALTUSERLOGIN = .ALTUSERLOGIN
                  _UFLAG = .UFLAG
                  _CUSERLOGIN = .CUSERLOGIN
                  _UDATE = .UDATE
                  _USER = .USER
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
    
    <QueryTitle("History of Changes")>  _
    Public Class QUERY_PURD_CHANGES_LOG
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PURD_CHANGES_LOG)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PURD_CHANGES_LOG)
            _Parent = nothing
            _Name = "PURD_CHANGES_LOG"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PURD_CHANGES_LOG)
            _Parent = Parent
            _name = "PURD_CHANGES_LOG_SUBFORM"
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
        
        Public Property Value() As list(of PURD_CHANGES_LOG)
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
                return GetType(PURD_CHANGES_LOG)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PURD_CHANGES_LOG As PURD_CHANGES_LOG In JsonConvert.DeserializeObject(Of QUERY_PURD_CHANGES_LOG)(stream.ReadToEnd).Value
              With _PURD_CHANGES_LOG
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PURD_CHANGES_LOG)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PURD_CHANGES_LOG = JsonConvert.DeserializeObject(Of PURD_CHANGES_LOG)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PURD_CHANGES_LOG)
                  .TITLE = obj.TITLE
                  .LINE = obj.LINE
                  .DETAILS = obj.DETAILS
                  .FIELD = obj.FIELD
                  .OLDVALUE = obj.OLDVALUE
                  .NEWVALUE = obj.NEWVALUE
                  .USERLOGIN = obj.USERLOGIN
                  .PHONENAME = obj.PHONENAME
                  .UDATE = obj.UDATE
                  .LOG = obj.LOG
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PURD_CHANGES_LOG(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PURD_CHANGES_LOG as PURD_CHANGES_LOG in value
              If _PURD_CHANGES_LOG.Equals(trycast(obj,PURD_CHANGES_LOG)) Then
                  value.remove(_PURD_CHANGES_LOG)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PURD_CHANGES_LOG
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _TITLE As String
        
        Private _IsSetLINE As Boolean = Boolean.FalseString
        
        Private _LINE As Long
        
        Private _DETAILS As String
        
        Private _FIELD As String
        
        Private _OLDVALUE As String
        
        Private _NEWVALUE As String
        
        Private _USERLOGIN As String
        
        Private _PHONENAME As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _LOG As Long
        
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
                    return "PURD_CHANGES_LOG"
                else
                    return "PURD_CHANGES_LOG_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "LOG={0}", _
                  string.format("{0}",LOG) _ 
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
        
        <DisplayName("Form"),  _
         nType("Edm.String"),  _
         tab("Form"),  _
         Pos(3),  _
         [ReadOnly](true),  _
         twodBarcode("TITLE")>  _
        Public Property TITLE() As String
            Get
                return _TITLE
            End Get
            Set
                if not(value is nothing) then
                  _TITLE = Value
                end if
            End Set
        End Property
        
        <DisplayName("LINE"),  _
         nType("Edm.Int64"),  _
         tab("Form"),  _
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
        
        <DisplayName("Details"),  _
         nType("Edm.String"),  _
         tab("Form"),  _
         Pos(7),  _
         [ReadOnly](true),  _
         twodBarcode("DETAILS")>  _
        Public Property DETAILS() As String
            Get
                return _DETAILS
            End Get
            Set
                if not(value is nothing) then
                  _DETAILS = Value
                end if
            End Set
        End Property
        
        <DisplayName("Column"),  _
         nType("Edm.String"),  _
         tab("Form"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("FIELD")>  _
        Public Property FIELD() As String
            Get
                return _FIELD
            End Get
            Set
                if not(value is nothing) then
                  _FIELD = Value
                end if
            End Set
        End Property
        
        <DisplayName("Previous Value"),  _
         nType("Edm.String"),  _
         tab("Form"),  _
         Pos(50),  _
         [ReadOnly](true),  _
         twodBarcode("OLDVALUE")>  _
        Public Property OLDVALUE() As String
            Get
                return _OLDVALUE
            End Get
            Set
                if not(value is nothing) then
                  _OLDVALUE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Current Value"),  _
         nType("Edm.String"),  _
         tab("Form"),  _
         Pos(60),  _
         [ReadOnly](true),  _
         twodBarcode("NEWVALUE")>  _
        Public Property NEWVALUE() As String
            Get
                return _NEWVALUE
            End Get
            Set
                if not(value is nothing) then
                  _NEWVALUE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Form"),  _
         Pos(90),  _
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
        
        <DisplayName("Contact"),  _
         nType("Edm.String"),  _
         tab("Form"),  _
         Pos(95),  _
         [ReadOnly](true),  _
         twodBarcode("PHONENAME")>  _
        Public Property PHONENAME() As String
            Get
                return _PHONENAME
            End Get
            Set
                if not(value is nothing) then
                  _PHONENAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Date"),  _
         Pos(100),  _
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
        
        <DisplayName("Log (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Date"),  _
         Pos(99),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("LOG")>  _
        Public Property LOG() As nullable (of int64)
            Get
                return _LOG
            End Get
            Set
                if not(value is nothing) then
                  _LOG = Value
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
                .WriteAttributeString("name", "PURD_CHANGES_LOG")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "LOG")
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
                dim obj as PURD_CHANGES_LOG = JsonConvert.DeserializeObject(Of PURD_CHANGES_LOG)(e.StreamReader.ReadToEnd)
                With obj
                  _TITLE = .TITLE
                  _LINE = .LINE
                  _DETAILS = .DETAILS
                  _FIELD = .FIELD
                  _OLDVALUE = .OLDVALUE
                  _NEWVALUE = .NEWVALUE
                  _USERLOGIN = .USERLOGIN
                  _PHONENAME = .PHONENAME
                  _UDATE = .UDATE
                  _LOG = .LOG
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Remarks")>  _
    Public Class QUERY_PURDEMANDSTEXT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PURDEMANDSTEXT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PURDEMANDSTEXT)
            _Parent = nothing
            _Name = "PURDEMANDSTEXT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PURDEMANDSTEXT)
            _Parent = Parent
            _name = "PURDEMANDSTEXT_SUBFORM"
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
        
        Public Property Value() As list(of PURDEMANDSTEXT)
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
                return GetType(PURDEMANDSTEXT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PURDEMANDSTEXT As PURDEMANDSTEXT In JsonConvert.DeserializeObject(Of QUERY_PURDEMANDSTEXT)(stream.ReadToEnd).Value
              With _PURDEMANDSTEXT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PURDEMANDSTEXT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PURDEMANDSTEXT = JsonConvert.DeserializeObject(Of PURDEMANDSTEXT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PURDEMANDSTEXT)
                  .TEXT = obj.TEXT
                  .TEXTLINE = obj.TEXTLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PURDEMANDSTEXT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PURDEMANDSTEXT as PURDEMANDSTEXT in value
              If _PURDEMANDSTEXT.Equals(trycast(obj,PURDEMANDSTEXT)) Then
                  value.remove(_PURDEMANDSTEXT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PURDEMANDSTEXT
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
                    return "PURDEMANDSTEXT"
                else
                    return "PURDEMANDSTEXT_SUBFORM"
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
                .WriteAttributeString("name", "PURDEMANDSTEXT")
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
                dim obj as PURDEMANDSTEXT = JsonConvert.DeserializeObject(Of PURDEMANDSTEXT)(e.StreamReader.ReadToEnd)
                With obj
                  _TEXT = .TEXT
                  _TEXTLINE = .TEXTLINE
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Internal Dialogue")>  _
    Public Class QUERY_INTERNALDIALOGTEXT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of INTERNALDIALOGTEXT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of INTERNALDIALOGTEXT)
            _Parent = nothing
            _Name = "INTERNALDIALOGTEXT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of INTERNALDIALOGTEXT)
            _Parent = Parent
            _name = "INTERNALDIALOGTEXT_SUBFORM"
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
        
        Public Property Value() As list(of INTERNALDIALOGTEXT)
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
                return GetType(INTERNALDIALOGTEXT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _INTERNALDIALOGTEXT As INTERNALDIALOGTEXT In JsonConvert.DeserializeObject(Of QUERY_INTERNALDIALOGTEXT)(stream.ReadToEnd).Value
              With _INTERNALDIALOGTEXT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_INTERNALDIALOGTEXT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as INTERNALDIALOGTEXT = JsonConvert.DeserializeObject(Of INTERNALDIALOGTEXT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, INTERNALDIALOGTEXT)
                  .TEXT = obj.TEXT
                  .TEXTLINE = obj.TEXTLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new INTERNALDIALOGTEXT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _INTERNALDIALOGTEXT as INTERNALDIALOGTEXT in value
              If _INTERNALDIALOGTEXT.Equals(trycast(obj,INTERNALDIALOGTEXT)) Then
                  value.remove(_INTERNALDIALOGTEXT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class INTERNALDIALOGTEXT
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
                    return "INTERNALDIALOGTEXT"
                else
                    return "INTERNALDIALOGTEXT_SUBFORM"
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
        
        <DisplayName("Comment"),  _
         nType("Edm.String"),  _
         tab("Comment"),  _
         Pos(30),  _
         twodBarcode("TEXT")>  _
        Public Property TEXT() As String
            Get
                return _TEXT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Comment", value, "^.{0,68}$") then Exit Property
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
         tab("Comment"),  _
         Pos(40),  _
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
                .WriteAttributeString("name", "INTERNALDIALOGTEXT")
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
                dim obj as INTERNALDIALOGTEXT = JsonConvert.DeserializeObject(Of INTERNALDIALOGTEXT)(e.StreamReader.ReadToEnd)
                With obj
                  _TEXT = .TEXT
                  _TEXTLINE = .TEXTLINE
                end with
            End If
        End Sub
    End Class
End Namespace
