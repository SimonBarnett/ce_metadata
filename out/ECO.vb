Imports system
Imports system.IO
Imports system.xml
Imports System.Net
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Newtonsoft.Json

Namespace OData
    
    <QueryTitle("Engineering Change Orders (ECO)")>  _
    Public Class QUERY_ECO
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of ECO)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of ECO)
            _Parent = nothing
            _Name = "ECO"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Parts in the ECO")
            .add(1, "Authorise ECO")
            .add(2, "Library")
            .add(3, "Attachments")
            .add(4, "Implications for the ECO")
            .add(5, "Tasks for Document")
            .add(6, "To Do Item")
            .add(7, "History of Statuses")
            .add(8, "Related Work Orders")
            .add(9, "Related Part Revisions")
            .add(10, "Related BOM Revisions")
            .add(11, "ECOs - Remarks")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of ECO)
            _Parent = Parent
            _name = "ECO_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Parts in the ECO")
            .add(1, "Authorise ECO")
            .add(2, "Library")
            .add(3, "Attachments")
            .add(4, "Implications for the ECO")
            .add(5, "Tasks for Document")
            .add(6, "To Do Item")
            .add(7, "History of Statuses")
            .add(8, "Related Work Orders")
            .add(9, "Related Part Revisions")
            .add(10, "Related BOM Revisions")
            .add(11, "ECOs - Remarks")
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
        
        Public Property Value() As list(of ECO)
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
                return GetType(ECO)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _ECO As ECO In JsonConvert.DeserializeObject(Of QUERY_ECO)(stream.ReadToEnd).Value
              With _ECO
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_ECO)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ECO = JsonConvert.DeserializeObject(Of ECO)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, ECO)
                  .CURDATE = obj.CURDATE
                  .ECONUM = obj.ECONUM
                  .DETAILS = obj.DETAILS
                  .UFLAG = obj.UFLAG
                  .USERLOGIN = obj.USERLOGIN
                  .IUSERLOGIN = obj.IUSERLOGIN
                  .STATDES = obj.STATDES
                  .OWNERLOGIN = obj.OWNERLOGIN
                  .ECOREASONCODE = obj.ECOREASONCODE
                  .ECOREASONDES = obj.ECOREASONDES
                  .EXTFILEFLAG = obj.EXTFILEFLAG
                  .ECO = obj.ECO
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new ECO(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _ECO as ECO in value
              If _ECO.Equals(trycast(obj,ECO)) Then
                  value.remove(_ECO)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class ECO
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetCURDATE As Boolean = Boolean.FalseString
        
        Private _CURDATE As System.DateTimeOffset
        
        Private _IsSetECONUM As Boolean = Boolean.FalseString
        
        Private _ECONUM As String
        
        Private _IsSetDETAILS As Boolean = Boolean.FalseString
        
        Private _DETAILS As String
        
        Private _UFLAG As String
        
        Private _USERLOGIN As String
        
        Private _IsSetIUSERLOGIN As Boolean = Boolean.FalseString
        
        Private _IUSERLOGIN As String
        
        Private _IsSetSTATDES As Boolean = Boolean.FalseString
        
        Private _STATDES As String
        
        Private _IsSetOWNERLOGIN As Boolean = Boolean.FalseString
        
        Private _OWNERLOGIN As String
        
        Private _IsSetECOREASONCODE As Boolean = Boolean.FalseString
        
        Private _ECOREASONCODE As String
        
        Private _ECOREASONDES As String
        
        Private _EXTFILEFLAG As String
        
        Private _IsSetECO As Boolean = Boolean.FalseString
        
        Private _ECO As Long
        
        Private _ECOPART_SUBFORM As QUERY_ECOPART
        
        Private _ECOUSER_SUBFORM As QUERY_ECOUSER
        
        Private _LIBRARY_SUBFORM As QUERY_LIBRARY
        
        Private _EXTFILES_SUBFORM As QUERY_EXTFILES
        
        Private _ECOIMPLICATIONS_SUBFORM As QUERY_ECOIMPLICATIONS
        
        Private _GENCUSTNOTES_SUBFORM As QUERY_GENCUSTNOTES
        
        Private _DOCTODOLIST_SUBFORM As QUERY_DOCTODOLIST
        
        Private _DOCTODOLISTLOG_SUBFORM As QUERY_DOCTODOLISTLOG
        
        Private _ECOSERIAL_SUBFORM As QUERY_ECOSERIAL
        
        Private _ECOPARTREV_SUBFORM As QUERY_ECOPARTREV
        
        Private _ECOREVISIONS_SUBFORM As QUERY_ECOREVISIONS
        
        Private _ECOTEXT_SUBFORM As QUERY_ECOTEXT
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Parts in the ECO"))
            ChildQuery.add(1, new oNavigation("Authorise ECO"))
            ChildQuery.add(2, new oNavigation("Library"))
            ChildQuery.add(3, new oNavigation("Attachments"))
            ChildQuery.add(4, new oNavigation("Implications for the ECO"))
            ChildQuery.add(5, new oNavigation("Tasks for Document"))
            ChildQuery.add(6, new oNavigation("To Do Item"))
            ChildQuery.add(7, new oNavigation("History of Statuses"))
            ChildQuery.add(8, new oNavigation("Related Work Orders"))
            ChildQuery.add(9, new oNavigation("Related Part Revisions"))
            ChildQuery.add(10, new oNavigation("Related BOM Revisions"))
            ChildQuery.add(11, new oNavigation("ECOs - Remarks"))
            _ECOPART_SUBFORM = new QUERY_ECOPART(me)
            _ECOUSER_SUBFORM = new QUERY_ECOUSER(me)
            _LIBRARY_SUBFORM = new QUERY_LIBRARY(me)
            _EXTFILES_SUBFORM = new QUERY_EXTFILES(me)
            _ECOIMPLICATIONS_SUBFORM = new QUERY_ECOIMPLICATIONS(me)
            _GENCUSTNOTES_SUBFORM = new QUERY_GENCUSTNOTES(me)
            _DOCTODOLIST_SUBFORM = new QUERY_DOCTODOLIST(me)
            _DOCTODOLISTLOG_SUBFORM = new QUERY_DOCTODOLISTLOG(me)
            _ECOSERIAL_SUBFORM = new QUERY_ECOSERIAL(me)
            _ECOPARTREV_SUBFORM = new QUERY_ECOPARTREV(me)
            _ECOREVISIONS_SUBFORM = new QUERY_ECOREVISIONS(me)
            _ECOTEXT_SUBFORM = new QUERY_ECOTEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_ECOPART_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_ECOUSER_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_LIBRARY_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_EXTFILES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_ECOIMPLICATIONS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(5)
               .setoDataQuery(_GENCUSTNOTES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(6)
               .setoDataQuery(_DOCTODOLIST_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(7)
               .setoDataQuery(_DOCTODOLISTLOG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(8)
               .setoDataQuery(_ECOSERIAL_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(9)
               .setoDataQuery(_ECOPARTREV_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(10)
               .setoDataQuery(_ECOREVISIONS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(11)
               .setoDataQuery(_ECOTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Parts in the ECO"))
            ChildQuery.add(1, new oNavigation("Authorise ECO"))
            ChildQuery.add(2, new oNavigation("Library"))
            ChildQuery.add(3, new oNavigation("Attachments"))
            ChildQuery.add(4, new oNavigation("Implications for the ECO"))
            ChildQuery.add(5, new oNavigation("Tasks for Document"))
            ChildQuery.add(6, new oNavigation("To Do Item"))
            ChildQuery.add(7, new oNavigation("History of Statuses"))
            ChildQuery.add(8, new oNavigation("Related Work Orders"))
            ChildQuery.add(9, new oNavigation("Related Part Revisions"))
            ChildQuery.add(10, new oNavigation("Related BOM Revisions"))
            ChildQuery.add(11, new oNavigation("ECOs - Remarks"))
            _ECOPART_SUBFORM = new QUERY_ECOPART(me)
            _ECOUSER_SUBFORM = new QUERY_ECOUSER(me)
            _LIBRARY_SUBFORM = new QUERY_LIBRARY(me)
            _EXTFILES_SUBFORM = new QUERY_EXTFILES(me)
            _ECOIMPLICATIONS_SUBFORM = new QUERY_ECOIMPLICATIONS(me)
            _GENCUSTNOTES_SUBFORM = new QUERY_GENCUSTNOTES(me)
            _DOCTODOLIST_SUBFORM = new QUERY_DOCTODOLIST(me)
            _DOCTODOLISTLOG_SUBFORM = new QUERY_DOCTODOLISTLOG(me)
            _ECOSERIAL_SUBFORM = new QUERY_ECOSERIAL(me)
            _ECOPARTREV_SUBFORM = new QUERY_ECOPARTREV(me)
            _ECOREVISIONS_SUBFORM = new QUERY_ECOREVISIONS(me)
            _ECOTEXT_SUBFORM = new QUERY_ECOTEXT(me)
            WITH ChildQuery(0)
               .setoDataQuery(_ECOPART_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_ECOUSER_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_LIBRARY_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_EXTFILES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_ECOIMPLICATIONS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(5)
               .setoDataQuery(_GENCUSTNOTES_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(6)
               .setoDataQuery(_DOCTODOLIST_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(7)
               .setoDataQuery(_DOCTODOLISTLOG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(8)
               .setoDataQuery(_ECOSERIAL_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(9)
               .setoDataQuery(_ECOPARTREV_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(10)
               .setoDataQuery(_ECOREVISIONS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
            WITH ChildQuery(11)
               .setoDataQuery(_ECOTEXT_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Parts in the ECO", _ECOPART_SUBFORM))
                   .add(1, new oNavigation("Authorise ECO", _ECOUSER_SUBFORM))
                   .add(2, new oNavigation("Library", _LIBRARY_SUBFORM))
                   .add(3, new oNavigation("Attachments", _EXTFILES_SUBFORM))
                   .add(4, new oNavigation("Implications for the ECO", _ECOIMPLICATIONS_SUBFORM))
                   .add(5, new oNavigation("Tasks for Document", _GENCUSTNOTES_SUBFORM))
                   .add(6, new oNavigation("To Do Item", _DOCTODOLIST_SUBFORM))
                   .add(7, new oNavigation("History of Statuses", _DOCTODOLISTLOG_SUBFORM))
                   .add(8, new oNavigation("Related Work Orders", _ECOSERIAL_SUBFORM))
                   .add(9, new oNavigation("Related Part Revisions", _ECOPARTREV_SUBFORM))
                   .add(10, new oNavigation("Related BOM Revisions", _ECOREVISIONS_SUBFORM))
                   .add(11, new oNavigation("ECOs - Remarks", _ECOTEXT_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "ECO"
                else
                    return "ECO_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "ECONUM={0}", _
                  string.format("'{0}'",ECONUM) _ 
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
        
        <DisplayName("ECO Number"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(20),  _
         Mandatory(true),  _
         twodBarcode("ECONUM")>  _
        Public Property ECONUM() As String
            Get
                return _ECONUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("ECO Number", value, "^.{0,16}$") then Exit Property
                _IsSetECONUM = True
                If loading Then
                  _ECONUM = Value
                Else
                    if not _ECONUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ECONUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ECONUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Details"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(30),  _
         twodBarcode("DETAILS")>  _
        Public Property DETAILS() As String
            Get
                return _DETAILS
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Details", value, "^.{0,32}$") then Exit Property
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
        
        <DisplayName("Authorised?"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("UFLAG")>  _
        Public Property UFLAG() As String
            Get
                return _UFLAG
            End Get
            Set
                if not(value is nothing) then
                  _UFLAG = Value
                end if
            End Set
        End Property
        
        <DisplayName("Next Signature"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
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
        
        <DisplayName("Initiator of Change"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(60),  _
         twodBarcode("IUSERLOGIN")>  _
        Public Property IUSERLOGIN() As String
            Get
                return _IUSERLOGIN
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Initiator of Change", value, "^.{0,20}$") then Exit Property
                _IsSetIUSERLOGIN = True
                If loading Then
                  _IUSERLOGIN = Value
                Else
                    if not _IUSERLOGIN = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("IUSERLOGIN", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _IUSERLOGIN = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Status"),  _
         nType("Edm.String"),  _
         tab("Date"),  _
         Pos(70),  _
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
         tab("Date"),  _
         Pos(72),  _
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
        
        <DisplayName("Reason Code"),  _
         nType("Edm.String"),  _
         tab("Reason Code"),  _
         Pos(80),  _
         twodBarcode("ECOREASONCODE")>  _
        Public Property ECOREASONCODE() As String
            Get
                return _ECOREASONCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Reason Code", value, "^.{0,3}$") then Exit Property
                _IsSetECOREASONCODE = True
                If loading Then
                  _ECOREASONCODE = Value
                Else
                    if not _ECOREASONCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ECOREASONCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ECOREASONCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Reason for ECO"),  _
         nType("Edm.String"),  _
         tab("Reason Code"),  _
         Pos(90),  _
         [ReadOnly](true),  _
         twodBarcode("ECOREASONDES")>  _
        Public Property ECOREASONDES() As String
            Get
                return _ECOREASONDES
            End Get
            Set
                if not(value is nothing) then
                  _ECOREASONDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Attachments?"),  _
         nType("Edm.String"),  _
         tab("Reason Code"),  _
         Pos(100),  _
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
        
        <DisplayName("ECO Number (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Reason Code"),  _
         Pos(10),  _
         Browsable(false),  _
         twodBarcode("ECO")>  _
        Public Property ECO() As nullable (of int64)
            Get
                return _ECO
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("ECO Number (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetECO = True
                If loading Then
                  _ECO = Value
                Else
                    if not _ECO = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ECO", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ECO = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property ECOPART_SUBFORM() As QUERY_ECOPART
            Get
                return _ECOPART_SUBFORM
            End Get
            Set
                _ECOPART_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property ECOUSER_SUBFORM() As QUERY_ECOUSER
            Get
                return _ECOUSER_SUBFORM
            End Get
            Set
                _ECOUSER_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property LIBRARY_SUBFORM() As QUERY_LIBRARY
            Get
                return _LIBRARY_SUBFORM
            End Get
            Set
                _LIBRARY_SUBFORM = value
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
        Public Property ECOIMPLICATIONS_SUBFORM() As QUERY_ECOIMPLICATIONS
            Get
                return _ECOIMPLICATIONS_SUBFORM
            End Get
            Set
                _ECOIMPLICATIONS_SUBFORM = value
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
        Public Property ECOSERIAL_SUBFORM() As QUERY_ECOSERIAL
            Get
                return _ECOSERIAL_SUBFORM
            End Get
            Set
                _ECOSERIAL_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property ECOPARTREV_SUBFORM() As QUERY_ECOPARTREV
            Get
                return _ECOPARTREV_SUBFORM
            End Get
            Set
                _ECOPARTREV_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property ECOREVISIONS_SUBFORM() As QUERY_ECOREVISIONS
            Get
                return _ECOREVISIONS_SUBFORM
            End Get
            Set
                _ECOREVISIONS_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property ECOTEXT_SUBFORM() As QUERY_ECOTEXT
            Get
                return _ECOTEXT_SUBFORM
            End Get
            Set
                _ECOTEXT_SUBFORM = value
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
            if _IsSetECONUM then
              if f then
                  jw.WriteRaw(", ""ECONUM"": ")
              else
                  jw.WriteRaw("""ECONUM"": ")
                  f = true
              end if
              jw.WriteValue(me.ECONUM)
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
            if _IsSetIUSERLOGIN then
              if f then
                  jw.WriteRaw(", ""IUSERLOGIN"": ")
              else
                  jw.WriteRaw("""IUSERLOGIN"": ")
                  f = true
              end if
              jw.WriteValue(me.IUSERLOGIN)
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
            if _IsSetECOREASONCODE then
              if f then
                  jw.WriteRaw(", ""ECOREASONCODE"": ")
              else
                  jw.WriteRaw("""ECOREASONCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.ECOREASONCODE)
            end if
            if _IsSetECO then
              if f then
                  jw.WriteRaw(", ""ECO"": ")
              else
                  jw.WriteRaw("""ECO"": ")
                  f = true
              end if
              jw.WriteValue(me.ECO)
            end if
            if _ECOPART_SUBFORM.value.count > 0 then
              jw.WriteRaw(", ECOPART_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as ECOPART in _ECOPART_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _ECOPART_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _ECOUSER_SUBFORM.value.count > 0 then
              jw.WriteRaw(", ECOUSER_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as ECOUSER in _ECOUSER_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _ECOUSER_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _LIBRARY_SUBFORM.value.count > 0 then
              jw.WriteRaw(", LIBRARY_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as LIBRARY in _LIBRARY_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _LIBRARY_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
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
            if _ECOIMPLICATIONS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", ECOIMPLICATIONS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as ECOIMPLICATIONS in _ECOIMPLICATIONS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _ECOIMPLICATIONS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
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
            if _ECOSERIAL_SUBFORM.value.count > 0 then
              jw.WriteRaw(", ECOSERIAL_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as ECOSERIAL in _ECOSERIAL_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _ECOSERIAL_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _ECOPARTREV_SUBFORM.value.count > 0 then
              jw.WriteRaw(", ECOPARTREV_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as ECOPARTREV in _ECOPARTREV_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _ECOPARTREV_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _ECOREVISIONS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", ECOREVISIONS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as ECOREVISIONS in _ECOREVISIONS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _ECOREVISIONS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _ECOTEXT_SUBFORM.value.count > 0 then
              jw.WriteRaw(", ECOTEXT_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as ECOTEXT in _ECOTEXT_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _ECOTEXT_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "ECO")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "ECONUM")
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
            if _IsSetECONUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ECONUM")
              .WriteAttributeString("value", me.ECONUM)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetDETAILS then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DETAILS")
              .WriteAttributeString("value", me.DETAILS)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "32")
              .WriteEndElement
            end if
            if _IsSetIUSERLOGIN then
              .WriteStartElement("field")
              .WriteAttributeString("name", "IUSERLOGIN")
              .WriteAttributeString("value", me.IUSERLOGIN)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "20")
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
            if _IsSetECOREASONCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ECOREASONCODE")
              .WriteAttributeString("value", me.ECOREASONCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
            end if
            if _IsSetECO then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ECO")
              .WriteAttributeString("value", me.ECO)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _ECOPART_SUBFORM.value.count > 0 then
              for each itm as ECOPART in _ECOPART_SUBFORM.Value
                itm.toXML(xw,"ECOPART_SUBFORM")
              next
            end if
            if _ECOUSER_SUBFORM.value.count > 0 then
              for each itm as ECOUSER in _ECOUSER_SUBFORM.Value
                itm.toXML(xw,"ECOUSER_SUBFORM")
              next
            end if
            if _LIBRARY_SUBFORM.value.count > 0 then
              for each itm as LIBRARY in _LIBRARY_SUBFORM.Value
                itm.toXML(xw,"LIBRARY_SUBFORM")
              next
            end if
            if _EXTFILES_SUBFORM.value.count > 0 then
              for each itm as EXTFILES in _EXTFILES_SUBFORM.Value
                itm.toXML(xw,"EXTFILES_SUBFORM")
              next
            end if
            if _ECOIMPLICATIONS_SUBFORM.value.count > 0 then
              for each itm as ECOIMPLICATIONS in _ECOIMPLICATIONS_SUBFORM.Value
                itm.toXML(xw,"ECOIMPLICATIONS_SUBFORM")
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
            if _ECOSERIAL_SUBFORM.value.count > 0 then
              for each itm as ECOSERIAL in _ECOSERIAL_SUBFORM.Value
                itm.toXML(xw,"ECOSERIAL_SUBFORM")
              next
            end if
            if _ECOPARTREV_SUBFORM.value.count > 0 then
              for each itm as ECOPARTREV in _ECOPARTREV_SUBFORM.Value
                itm.toXML(xw,"ECOPARTREV_SUBFORM")
              next
            end if
            if _ECOREVISIONS_SUBFORM.value.count > 0 then
              for each itm as ECOREVISIONS in _ECOREVISIONS_SUBFORM.Value
                itm.toXML(xw,"ECOREVISIONS_SUBFORM")
              next
            end if
            if _ECOTEXT_SUBFORM.value.count > 0 then
              for each itm as ECOTEXT in _ECOTEXT_SUBFORM.Value
                itm.toXML(xw,"ECOTEXT_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ECO = JsonConvert.DeserializeObject(Of ECO)(e.StreamReader.ReadToEnd)
                With obj
                  _CURDATE = .CURDATE
                  _ECONUM = .ECONUM
                  _DETAILS = .DETAILS
                  _UFLAG = .UFLAG
                  _USERLOGIN = .USERLOGIN
                  _IUSERLOGIN = .IUSERLOGIN
                  _STATDES = .STATDES
                  _OWNERLOGIN = .OWNERLOGIN
                  _ECOREASONCODE = .ECOREASONCODE
                  _ECOREASONDES = .ECOREASONDES
                  _EXTFILEFLAG = .EXTFILEFLAG
                  _ECO = .ECO
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_ECO
        
        ECOPART = 0
        
        ECOUSER = 1
        
        LIBRARY = 2
        
        EXTFILES = 3
        
        ECOIMPLICATIONS = 4
        
        GENCUSTNOTES = 5
        
        DOCTODOLIST = 6
        
        DOCTODOLISTLOG = 7
        
        ECOSERIAL = 8
        
        ECOPARTREV = 9
        
        ECOREVISIONS = 10
        
        ECOTEXT = 11
    End Enum
    
    <QueryTitle("Parts in the ECO")>  _
    Public Class QUERY_ECOPART
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of ECOPART)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of ECOPART)
            _Parent = nothing
            _Name = "ECOPART"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "BOM Revisions")
            .add(1, "Part Revisions")
            .add(2, "Documents for Part")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of ECOPART)
            _Parent = Parent
            _name = "ECOPART_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "BOM Revisions")
            .add(1, "Part Revisions")
            .add(2, "Documents for Part")
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
        
        Public Property Value() As list(of ECOPART)
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
                return GetType(ECOPART)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _ECOPART As ECOPART In JsonConvert.DeserializeObject(Of QUERY_ECOPART)(stream.ReadToEnd).Value
              With _ECOPART
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_ECOPART)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ECOPART = JsonConvert.DeserializeObject(Of ECOPART)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, ECOPART)
                  .PARTNAME = obj.PARTNAME
                  .PARTDES = obj.PARTDES
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .KLINE = obj.KLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new ECOPART(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _ECOPART as ECOPART in value
              If _ECOPART.Equals(trycast(obj,ECOPART)) Then
                  value.remove(_ECOPART)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class ECOPART
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetPARTNAME As Boolean = Boolean.FalseString
        
        Private _PARTNAME As String
        
        Private _PARTDES As String
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _IsSetKLINE As Boolean = Boolean.FalseString
        
        Private _KLINE As Long
        
        Private _REVISIONS_SUBFORM As QUERY_REVISIONS
        
        Private _PARTREV_SUBFORM As QUERY_PARTREV
        
        Private _ECOPARTEXTFILE_SUBFORM As QUERY_ECOPARTEXTFILE
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("BOM Revisions"))
            ChildQuery.add(1, new oNavigation("Part Revisions"))
            ChildQuery.add(2, new oNavigation("Documents for Part"))
            _REVISIONS_SUBFORM = new QUERY_REVISIONS(me)
            _PARTREV_SUBFORM = new QUERY_PARTREV(me)
            _ECOPARTEXTFILE_SUBFORM = new QUERY_ECOPARTEXTFILE(me)
            WITH ChildQuery(0)
               .setoDataQuery(_REVISIONS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("BOM Revisions", _REVISIONS_SUBFORM))
                   .add(1, new oNavigation("Part Revisions", _PARTREV_SUBFORM))
                   .add(2, new oNavigation("Documents for Part", _ECOPARTEXTFILE_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_PARTREV_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("BOM Revisions", _REVISIONS_SUBFORM))
                   .add(1, new oNavigation("Part Revisions", _PARTREV_SUBFORM))
                   .add(2, new oNavigation("Documents for Part", _ECOPARTEXTFILE_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_ECOPARTEXTFILE_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("BOM Revisions", _REVISIONS_SUBFORM))
                   .add(1, new oNavigation("Part Revisions", _PARTREV_SUBFORM))
                   .add(2, new oNavigation("Documents for Part", _ECOPARTEXTFILE_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("BOM Revisions"))
            ChildQuery.add(1, new oNavigation("Part Revisions"))
            ChildQuery.add(2, new oNavigation("Documents for Part"))
            _REVISIONS_SUBFORM = new QUERY_REVISIONS(me)
            _PARTREV_SUBFORM = new QUERY_PARTREV(me)
            _ECOPARTEXTFILE_SUBFORM = new QUERY_ECOPARTEXTFILE(me)
            WITH ChildQuery(0)
               .setoDataQuery(_REVISIONS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("BOM Revisions", _REVISIONS_SUBFORM))
                   .add(1, new oNavigation("Part Revisions", _PARTREV_SUBFORM))
                   .add(2, new oNavigation("Documents for Part", _ECOPARTEXTFILE_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_PARTREV_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("BOM Revisions", _REVISIONS_SUBFORM))
                   .add(1, new oNavigation("Part Revisions", _PARTREV_SUBFORM))
                   .add(2, new oNavigation("Documents for Part", _ECOPARTEXTFILE_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_ECOPARTEXTFILE_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("BOM Revisions", _REVISIONS_SUBFORM))
                   .add(1, new oNavigation("Part Revisions", _PARTREV_SUBFORM))
                   .add(2, new oNavigation("Documents for Part", _ECOPARTEXTFILE_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "ECOPART"
                else
                    return "ECOPART_SUBFORM"
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
         Pos(10),  _
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
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(30),  _
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
         tab("Part Number"),  _
         Pos(50),  _
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
         tab("Part Number"),  _
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
        Public Property REVISIONS_SUBFORM() As QUERY_REVISIONS
            Get
                return _REVISIONS_SUBFORM
            End Get
            Set
                _REVISIONS_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property PARTREV_SUBFORM() As QUERY_PARTREV
            Get
                return _PARTREV_SUBFORM
            End Get
            Set
                _PARTREV_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property ECOPARTEXTFILE_SUBFORM() As QUERY_ECOPARTEXTFILE
            Get
                return _ECOPARTEXTFILE_SUBFORM
            End Get
            Set
                _ECOPARTEXTFILE_SUBFORM = value
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
            if _IsSetKLINE then
              if f then
                  jw.WriteRaw(", ""KLINE"": ")
              else
                  jw.WriteRaw("""KLINE"": ")
                  f = true
              end if
              jw.WriteValue(me.KLINE)
            end if
            if _REVISIONS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", REVISIONS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as REVISIONS in _REVISIONS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _REVISIONS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _PARTREV_SUBFORM.value.count > 0 then
              jw.WriteRaw(", PARTREV_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as PARTREV in _PARTREV_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _PARTREV_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _ECOPARTEXTFILE_SUBFORM.value.count > 0 then
              jw.WriteRaw(", ECOPARTEXTFILE_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as ECOPARTEXTFILE in _ECOPARTEXTFILE_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _ECOPARTEXTFILE_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "ECOPART")
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
            if _IsSetKLINE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "KLINE")
              .WriteAttributeString("value", me.KLINE)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _REVISIONS_SUBFORM.value.count > 0 then
              for each itm as REVISIONS in _REVISIONS_SUBFORM.Value
                itm.toXML(xw,"REVISIONS_SUBFORM")
              next
            end if
            if _PARTREV_SUBFORM.value.count > 0 then
              for each itm as PARTREV in _PARTREV_SUBFORM.Value
                itm.toXML(xw,"PARTREV_SUBFORM")
              next
            end if
            if _ECOPARTEXTFILE_SUBFORM.value.count > 0 then
              for each itm as ECOPARTEXTFILE in _ECOPARTEXTFILE_SUBFORM.Value
                itm.toXML(xw,"ECOPARTEXTFILE_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ECOPART = JsonConvert.DeserializeObject(Of ECOPART)(e.StreamReader.ReadToEnd)
                With obj
                  _PARTNAME = .PARTNAME
                  _PARTDES = .PARTDES
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _KLINE = .KLINE
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_ECOPART
        
        REVISIONS = 0
        
        PARTREV = 1
        
        ECOPARTEXTFILE = 2
    End Enum
    
    <QueryTitle("BOM Revisions")>  _
    Public Class QUERY_REVISIONS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of REVISIONS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of REVISIONS)
            _Parent = nothing
            _Name = "REVISIONS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Child Parts")
            .add(1, "Tools for the Part")
            .add(2, "Child Part Designations")
            .add(3, "Revision Authorisation")
            .add(4, "Custom BOM for Item: Conditions")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of REVISIONS)
            _Parent = Parent
            _name = "REVISIONS_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Child Parts")
            .add(1, "Tools for the Part")
            .add(2, "Child Part Designations")
            .add(3, "Revision Authorisation")
            .add(4, "Custom BOM for Item: Conditions")
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
        
        Public Property Value() As list(of REVISIONS)
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
                return GetType(REVISIONS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _REVISIONS As REVISIONS In JsonConvert.DeserializeObject(Of QUERY_REVISIONS)(stream.ReadToEnd).Value
              With _REVISIONS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_REVISIONS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as REVISIONS = JsonConvert.DeserializeObject(Of REVISIONS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, REVISIONS)
                  .REVNUM = obj.REVNUM
                  .REVDES = obj.REVDES
                  .FROMDATE = obj.FROMDATE
                  .TILLDATE = obj.TILLDATE
                  .USERLOGIN = obj.USERLOGIN
                  .CONFIRMED = obj.CONFIRMED
                  .ECONUM = obj.ECONUM
                  .UFLAG = obj.UFLAG
                  .REVNAME = obj.REVNAME
                  .REV = obj.REV
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new REVISIONS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _REVISIONS as REVISIONS in value
              If _REVISIONS.Equals(trycast(obj,REVISIONS)) Then
                  value.remove(_REVISIONS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class REVISIONS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetREVNUM As Boolean = Boolean.FalseString
        
        Private _REVNUM As String
        
        Private _IsSetREVDES As Boolean = Boolean.FalseString
        
        Private _REVDES As String
        
        Private _IsSetFROMDATE As Boolean = Boolean.FalseString
        
        Private _FROMDATE As System.DateTimeOffset
        
        Private _TILLDATE As System.DateTimeOffset
        
        Private _USERLOGIN As String
        
        Private _IsSetCONFIRMED As Boolean = Boolean.FalseString
        
        Private _CONFIRMED As String
        
        Private _IsSetECONUM As Boolean = Boolean.FalseString
        
        Private _ECONUM As String
        
        Private _UFLAG As String
        
        Private _IsSetREVNAME As Boolean = Boolean.FalseString
        
        Private _REVNAME As String
        
        Private _IsSetREV As Boolean = Boolean.FalseString
        
        Private _REV As Long
        
        Private _REVPARTARC_SUBFORM As QUERY_REVPARTARC
        
        Private _REVPARTARCTOOL_SUBFORM As QUERY_REVPARTARCTOOL
        
        Private _LOCATIONS_SUBFORM As QUERY_LOCATIONS
        
        Private _REVISIONUSER_SUBFORM As QUERY_REVISIONUSER
        
        Private _PARTCONFIG_SUBFORM As QUERY_PARTCONFIG
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Child Parts"))
            ChildQuery.add(1, new oNavigation("Tools for the Part"))
            ChildQuery.add(2, new oNavigation("Child Part Designations"))
            ChildQuery.add(3, new oNavigation("Revision Authorisation"))
            ChildQuery.add(4, new oNavigation("Custom BOM for Item: Conditions"))
            _REVPARTARC_SUBFORM = new QUERY_REVPARTARC(me)
            _REVPARTARCTOOL_SUBFORM = new QUERY_REVPARTARCTOOL(me)
            _LOCATIONS_SUBFORM = new QUERY_LOCATIONS(me)
            _REVISIONUSER_SUBFORM = new QUERY_REVISIONUSER(me)
            _PARTCONFIG_SUBFORM = new QUERY_PARTCONFIG(me)
            WITH ChildQuery(0)
               .setoDataQuery(_REVPARTARC_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Child Parts", _REVPARTARC_SUBFORM))
                   .add(1, new oNavigation("Tools for the Part", _REVPARTARCTOOL_SUBFORM))
                   .add(2, new oNavigation("Child Part Designations", _LOCATIONS_SUBFORM))
                   .add(3, new oNavigation("Revision Authorisation", _REVISIONUSER_SUBFORM))
                   .add(4, new oNavigation("Custom BOM for Item: Conditions", _PARTCONFIG_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_REVPARTARCTOOL_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Child Parts", _REVPARTARC_SUBFORM))
                   .add(1, new oNavigation("Tools for the Part", _REVPARTARCTOOL_SUBFORM))
                   .add(2, new oNavigation("Child Part Designations", _LOCATIONS_SUBFORM))
                   .add(3, new oNavigation("Revision Authorisation", _REVISIONUSER_SUBFORM))
                   .add(4, new oNavigation("Custom BOM for Item: Conditions", _PARTCONFIG_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_LOCATIONS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Child Parts", _REVPARTARC_SUBFORM))
                   .add(1, new oNavigation("Tools for the Part", _REVPARTARCTOOL_SUBFORM))
                   .add(2, new oNavigation("Child Part Designations", _LOCATIONS_SUBFORM))
                   .add(3, new oNavigation("Revision Authorisation", _REVISIONUSER_SUBFORM))
                   .add(4, new oNavigation("Custom BOM for Item: Conditions", _PARTCONFIG_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_REVISIONUSER_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Child Parts", _REVPARTARC_SUBFORM))
                   .add(1, new oNavigation("Tools for the Part", _REVPARTARCTOOL_SUBFORM))
                   .add(2, new oNavigation("Child Part Designations", _LOCATIONS_SUBFORM))
                   .add(3, new oNavigation("Revision Authorisation", _REVISIONUSER_SUBFORM))
                   .add(4, new oNavigation("Custom BOM for Item: Conditions", _PARTCONFIG_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_PARTCONFIG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Child Parts", _REVPARTARC_SUBFORM))
                   .add(1, new oNavigation("Tools for the Part", _REVPARTARCTOOL_SUBFORM))
                   .add(2, new oNavigation("Child Part Designations", _LOCATIONS_SUBFORM))
                   .add(3, new oNavigation("Revision Authorisation", _REVISIONUSER_SUBFORM))
                   .add(4, new oNavigation("Custom BOM for Item: Conditions", _PARTCONFIG_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Child Parts"))
            ChildQuery.add(1, new oNavigation("Tools for the Part"))
            ChildQuery.add(2, new oNavigation("Child Part Designations"))
            ChildQuery.add(3, new oNavigation("Revision Authorisation"))
            ChildQuery.add(4, new oNavigation("Custom BOM for Item: Conditions"))
            _REVPARTARC_SUBFORM = new QUERY_REVPARTARC(me)
            _REVPARTARCTOOL_SUBFORM = new QUERY_REVPARTARCTOOL(me)
            _LOCATIONS_SUBFORM = new QUERY_LOCATIONS(me)
            _REVISIONUSER_SUBFORM = new QUERY_REVISIONUSER(me)
            _PARTCONFIG_SUBFORM = new QUERY_PARTCONFIG(me)
            WITH ChildQuery(0)
               .setoDataQuery(_REVPARTARC_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Child Parts", _REVPARTARC_SUBFORM))
                   .add(1, new oNavigation("Tools for the Part", _REVPARTARCTOOL_SUBFORM))
                   .add(2, new oNavigation("Child Part Designations", _LOCATIONS_SUBFORM))
                   .add(3, new oNavigation("Revision Authorisation", _REVISIONUSER_SUBFORM))
                   .add(4, new oNavigation("Custom BOM for Item: Conditions", _PARTCONFIG_SUBFORM))
               end with
            end with
            WITH ChildQuery(1)
               .setoDataQuery(_REVPARTARCTOOL_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Child Parts", _REVPARTARC_SUBFORM))
                   .add(1, new oNavigation("Tools for the Part", _REVPARTARCTOOL_SUBFORM))
                   .add(2, new oNavigation("Child Part Designations", _LOCATIONS_SUBFORM))
                   .add(3, new oNavigation("Revision Authorisation", _REVISIONUSER_SUBFORM))
                   .add(4, new oNavigation("Custom BOM for Item: Conditions", _PARTCONFIG_SUBFORM))
               end with
            end with
            WITH ChildQuery(2)
               .setoDataQuery(_LOCATIONS_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Child Parts", _REVPARTARC_SUBFORM))
                   .add(1, new oNavigation("Tools for the Part", _REVPARTARCTOOL_SUBFORM))
                   .add(2, new oNavigation("Child Part Designations", _LOCATIONS_SUBFORM))
                   .add(3, new oNavigation("Revision Authorisation", _REVISIONUSER_SUBFORM))
                   .add(4, new oNavigation("Custom BOM for Item: Conditions", _PARTCONFIG_SUBFORM))
               end with
            end with
            WITH ChildQuery(3)
               .setoDataQuery(_REVISIONUSER_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Child Parts", _REVPARTARC_SUBFORM))
                   .add(1, new oNavigation("Tools for the Part", _REVPARTARCTOOL_SUBFORM))
                   .add(2, new oNavigation("Child Part Designations", _LOCATIONS_SUBFORM))
                   .add(3, new oNavigation("Revision Authorisation", _REVISIONUSER_SUBFORM))
                   .add(4, new oNavigation("Custom BOM for Item: Conditions", _PARTCONFIG_SUBFORM))
               end with
            end with
            WITH ChildQuery(4)
               .setoDataQuery(_PARTCONFIG_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Child Parts", _REVPARTARC_SUBFORM))
                   .add(1, new oNavigation("Tools for the Part", _REVPARTARCTOOL_SUBFORM))
                   .add(2, new oNavigation("Child Part Designations", _LOCATIONS_SUBFORM))
                   .add(3, new oNavigation("Revision Authorisation", _REVISIONUSER_SUBFORM))
                   .add(4, new oNavigation("Custom BOM for Item: Conditions", _PARTCONFIG_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "REVISIONS"
                else
                    return "REVISIONS_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "REVNUM={0}", _
                  string.format("'{0}'",REVNUM) _ 
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
        
        <DisplayName("BOM Revision Number"),  _
         nType("Edm.String"),  _
         tab("BOM Revision Number"),  _
         Pos(10),  _
         twodBarcode("REVNUM")>  _
        Public Property REVNUM() As String
            Get
                return _REVNUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("BOM Revision Number", value, "^.{0,3}$") then Exit Property
                _IsSetREVNUM = True
                If loading Then
                  _REVNUM = Value
                Else
                    if not _REVNUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("REVNUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _REVNUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Description"),  _
         nType("Edm.String"),  _
         tab("BOM Revision Number"),  _
         Pos(15),  _
         twodBarcode("REVDES")>  _
        Public Property REVDES() As String
            Get
                return _REVDES
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Description", value, "^.{0,32}$") then Exit Property
                _IsSetREVDES = True
                If loading Then
                  _REVDES = Value
                Else
                    if not _REVDES = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("REVDES", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _REVDES = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Effect Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("BOM Revision Number"),  _
         Pos(20),  _
         twodBarcode("FROMDATE")>  _
        Public Property FROMDATE() As nullable (of DateTimeOffset)
            Get
                return _FROMDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Effect Date", value, "^.*$") then Exit Property
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
        
        <DisplayName("End Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("BOM Revision Number"),  _
         Pos(30),  _
         [ReadOnly](true),  _
         twodBarcode("TILLDATE")>  _
        Public Property TILLDATE() As nullable (of DateTimeOffset)
            Get
                return _TILLDATE
            End Get
            Set
                if not(value is nothing) then
                  _TILLDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Next Signature"),  _
         nType("Edm.String"),  _
         tab("BOM Revision Number"),  _
         Pos(30),  _
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
         tab("BOM Revision Number"),  _
         Pos(40),  _
         twodBarcode("CONFIRMED")>  _
        Public Property CONFIRMED() As String
            Get
                return _CONFIRMED
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Authorised", value, "^.{0,1}$") then Exit Property
                _IsSetCONFIRMED = True
                If loading Then
                  _CONFIRMED = Value
                Else
                    if not _CONFIRMED = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("CONFIRMED", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _CONFIRMED = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("ECO Number"),  _
         nType("Edm.String"),  _
         tab("BOM Revision Number"),  _
         Pos(50),  _
         twodBarcode("ECONUM")>  _
        Public Property ECONUM() As String
            Get
                return _ECONUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("ECO Number", value, "^.{0,16}$") then Exit Property
                _IsSetECONUM = True
                If loading Then
                  _ECONUM = Value
                Else
                    if not _ECONUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ECONUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ECONUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("ECO Authorised"),  _
         nType("Edm.String"),  _
         tab("BOM Revision Number"),  _
         Pos(51),  _
         [ReadOnly](true),  _
         twodBarcode("UFLAG")>  _
        Public Property UFLAG() As String
            Get
                return _UFLAG
            End Get
            Set
                if not(value is nothing) then
                  _UFLAG = Value
                end if
            End Set
        End Property
        
        <DisplayName("Part Revision No."),  _
         nType("Edm.String"),  _
         tab("Part Revision No."),  _
         Pos(60),  _
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
        
        <DisplayName("Revision (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Part Revision No."),  _
         Pos(30),  _
         Browsable(false),  _
         twodBarcode("REV")>  _
        Public Property REV() As nullable (of int64)
            Get
                return _REV
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Revision (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetREV = True
                If loading Then
                  _REV = Value
                Else
                    if not _REV = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("REV", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _REV = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property REVPARTARC_SUBFORM() As QUERY_REVPARTARC
            Get
                return _REVPARTARC_SUBFORM
            End Get
            Set
                _REVPARTARC_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property REVPARTARCTOOL_SUBFORM() As QUERY_REVPARTARCTOOL
            Get
                return _REVPARTARCTOOL_SUBFORM
            End Get
            Set
                _REVPARTARCTOOL_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property LOCATIONS_SUBFORM() As QUERY_LOCATIONS
            Get
                return _LOCATIONS_SUBFORM
            End Get
            Set
                _LOCATIONS_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property REVISIONUSER_SUBFORM() As QUERY_REVISIONUSER
            Get
                return _REVISIONUSER_SUBFORM
            End Get
            Set
                _REVISIONUSER_SUBFORM = value
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property PARTCONFIG_SUBFORM() As QUERY_PARTCONFIG
            Get
                return _PARTCONFIG_SUBFORM
            End Get
            Set
                _PARTCONFIG_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetREVNUM then
              if f then
                  jw.WriteRaw(", ""REVNUM"": ")
              else
                  jw.WriteRaw("""REVNUM"": ")
                  f = true
              end if
              jw.WriteValue(me.REVNUM)
            end if
            if _IsSetREVDES then
              if f then
                  jw.WriteRaw(", ""REVDES"": ")
              else
                  jw.WriteRaw("""REVDES"": ")
                  f = true
              end if
              jw.WriteValue(me.REVDES)
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
            if _IsSetCONFIRMED then
              if f then
                  jw.WriteRaw(", ""CONFIRMED"": ")
              else
                  jw.WriteRaw("""CONFIRMED"": ")
                  f = true
              end if
              jw.WriteValue(me.CONFIRMED)
            end if
            if _IsSetECONUM then
              if f then
                  jw.WriteRaw(", ""ECONUM"": ")
              else
                  jw.WriteRaw("""ECONUM"": ")
                  f = true
              end if
              jw.WriteValue(me.ECONUM)
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
            if _IsSetREV then
              if f then
                  jw.WriteRaw(", ""REV"": ")
              else
                  jw.WriteRaw("""REV"": ")
                  f = true
              end if
              jw.WriteValue(me.REV)
            end if
            if _REVPARTARC_SUBFORM.value.count > 0 then
              jw.WriteRaw(", REVPARTARC_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as REVPARTARC in _REVPARTARC_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _REVPARTARC_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _REVPARTARCTOOL_SUBFORM.value.count > 0 then
              jw.WriteRaw(", REVPARTARCTOOL_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as REVPARTARCTOOL in _REVPARTARCTOOL_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _REVPARTARCTOOL_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _LOCATIONS_SUBFORM.value.count > 0 then
              jw.WriteRaw(", LOCATIONS_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as LOCATIONS in _LOCATIONS_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _LOCATIONS_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _REVISIONUSER_SUBFORM.value.count > 0 then
              jw.WriteRaw(", REVISIONUSER_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as REVISIONUSER in _REVISIONUSER_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _REVISIONUSER_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
            if _PARTCONFIG_SUBFORM.value.count > 0 then
              jw.WriteRaw(", PARTCONFIG_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as PARTCONFIG in _PARTCONFIG_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _PARTCONFIG_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "REVISIONS")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "REVNUM")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
            if _IsSetREVNUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REVNUM")
              .WriteAttributeString("value", me.REVNUM)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
            end if
            if _IsSetREVDES then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REVDES")
              .WriteAttributeString("value", me.REVDES)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "32")
              .WriteEndElement
            end if
            if _IsSetFROMDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FROMDATE")
              .WriteAttributeString("value", me.FROMDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
              .WriteEndElement
            end if
            if _IsSetCONFIRMED then
              .WriteStartElement("field")
              .WriteAttributeString("name", "CONFIRMED")
              .WriteAttributeString("value", me.CONFIRMED)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetECONUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ECONUM")
              .WriteAttributeString("value", me.ECONUM)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
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
            if _IsSetREV then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REV")
              .WriteAttributeString("value", me.REV)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _REVPARTARC_SUBFORM.value.count > 0 then
              for each itm as REVPARTARC in _REVPARTARC_SUBFORM.Value
                itm.toXML(xw,"REVPARTARC_SUBFORM")
              next
            end if
            if _REVPARTARCTOOL_SUBFORM.value.count > 0 then
              for each itm as REVPARTARCTOOL in _REVPARTARCTOOL_SUBFORM.Value
                itm.toXML(xw,"REVPARTARCTOOL_SUBFORM")
              next
            end if
            if _LOCATIONS_SUBFORM.value.count > 0 then
              for each itm as LOCATIONS in _LOCATIONS_SUBFORM.Value
                itm.toXML(xw,"LOCATIONS_SUBFORM")
              next
            end if
            if _REVISIONUSER_SUBFORM.value.count > 0 then
              for each itm as REVISIONUSER in _REVISIONUSER_SUBFORM.Value
                itm.toXML(xw,"REVISIONUSER_SUBFORM")
              next
            end if
            if _PARTCONFIG_SUBFORM.value.count > 0 then
              for each itm as PARTCONFIG in _PARTCONFIG_SUBFORM.Value
                itm.toXML(xw,"PARTCONFIG_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as REVISIONS = JsonConvert.DeserializeObject(Of REVISIONS)(e.StreamReader.ReadToEnd)
                With obj
                  _REVNUM = .REVNUM
                  _REVDES = .REVDES
                  _FROMDATE = .FROMDATE
                  _TILLDATE = .TILLDATE
                  _USERLOGIN = .USERLOGIN
                  _CONFIRMED = .CONFIRMED
                  _ECONUM = .ECONUM
                  _UFLAG = .UFLAG
                  _REVNAME = .REVNAME
                  _REV = .REV
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_REVISIONS
        
        REVPARTARC = 0
        
        REVPARTARCTOOL = 1
        
        LOCATIONS = 2
        
        REVISIONUSER = 3
        
        PARTCONFIG = 4
    End Enum
    
    <QueryTitle("Child Parts")>  _
    Public Class QUERY_REVPARTARC
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of REVPARTARC)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of REVPARTARC)
            _Parent = nothing
            _Name = "REVPARTARC"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of REVPARTARC)
            _Parent = Parent
            _name = "REVPARTARC_SUBFORM"
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
        
        Public Property Value() As list(of REVPARTARC)
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
                return GetType(REVPARTARC)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _REVPARTARC As REVPARTARC In JsonConvert.DeserializeObject(Of QUERY_REVPARTARC)(stream.ReadToEnd).Value
              With _REVPARTARC
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_REVPARTARC)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as REVPARTARC = JsonConvert.DeserializeObject(Of REVPARTARC)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, REVPARTARC)
                  .SONNAME = obj.SONNAME
                  .TYPE = obj.TYPE
                  .SONDES = obj.SONDES
                  .SONREVNAME = obj.SONREVNAME
                  .SONQUANT = obj.SONQUANT
                  .UNITNAME = obj.UNITNAME
                  .COEF = obj.COEF
                  .OP = obj.OP
                  .VARNAME = obj.VARNAME
                  .SCRAP = obj.SCRAP
                  .ACTNAME = obj.ACTNAME
                  .SONACTNAME = obj.SONACTNAME
                  .INFOONLY = obj.INFOONLY
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .ACT = obj.ACT
                  .SON = obj.SON
                  .SONACT = obj.SONACT
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new REVPARTARC(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _REVPARTARC as REVPARTARC in value
              If _REVPARTARC.Equals(trycast(obj,REVPARTARC)) Then
                  value.remove(_REVPARTARC)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class REVPARTARC
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetSONNAME As Boolean = Boolean.FalseString
        
        Private _SONNAME As String
        
        Private _TYPE As String
        
        Private _SONDES As String
        
        Private _IsSetSONREVNAME As Boolean = Boolean.FalseString
        
        Private _SONREVNAME As String
        
        Private _IsSetSONQUANT As Boolean = Boolean.FalseString
        
        Private _SONQUANT As Decimal
        
        Private _UNITNAME As String
        
        Private _COEF As Decimal
        
        Private _IsSetOP As Boolean = Boolean.FalseString
        
        Private _OP As String
        
        Private _IsSetVARNAME As Boolean = Boolean.FalseString
        
        Private _VARNAME As String
        
        Private _IsSetSCRAP As Boolean = Boolean.FalseString
        
        Private _SCRAP As Decimal
        
        Private _IsSetACTNAME As Boolean = Boolean.FalseString
        
        Private _ACTNAME As String
        
        Private _IsSetSONACTNAME As Boolean = Boolean.FalseString
        
        Private _SONACTNAME As String
        
        Private _IsSetINFOONLY As Boolean = Boolean.FalseString
        
        Private _INFOONLY As String
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _IsSetACT As Boolean = Boolean.FalseString
        
        Private _ACT As Long
        
        Private _IsSetSON As Boolean = Boolean.FalseString
        
        Private _SON As Long
        
        Private _IsSetSONACT As Boolean = Boolean.FalseString
        
        Private _SONACT As Long
        
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
                    return "REVPARTARC"
                else
                    return "REVPARTARC_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "ACT={0},SON={1},SONACT={2}", _
                  string.format("{0}",ACT), _
                  string.format("{0}",SON), _
                  string.format("{0}",SONACT) _ 
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
        
        <DisplayName("Child Part Number"),  _
         nType("Edm.String"),  _
         tab("Child Part Number"),  _
         Pos(1),  _
         Mandatory(true),  _
         twodBarcode("SONNAME")>  _
        Public Property SONNAME() As String
            Get
                return _SONNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Child Part Number", value, "^.{0,15}$") then Exit Property
                _IsSetSONNAME = True
                If loading Then
                  _SONNAME = Value
                Else
                    if not _SONNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SONNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SONNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Type (P/R)"),  _
         nType("Edm.String"),  _
         tab("Child Part Number"),  _
         Pos(2),  _
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
        
        <DisplayName("Part Description"),  _
         nType("Edm.String"),  _
         tab("Child Part Number"),  _
         Pos(4),  _
         [ReadOnly](true),  _
         twodBarcode("SONDES")>  _
        Public Property SONDES() As String
            Get
                return _SONDES
            End Get
            Set
                if not(value is nothing) then
                  _SONDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Child Part Revision"),  _
         nType("Edm.String"),  _
         tab("Child Part Number"),  _
         Pos(6),  _
         twodBarcode("SONREVNAME")>  _
        Public Property SONREVNAME() As String
            Get
                return _SONREVNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Child Part Revision", value, "^.{0,10}$") then Exit Property
                _IsSetSONREVNAME = True
                If loading Then
                  _SONREVNAME = Value
                Else
                    if not _SONREVNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SONREVNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SONREVNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Qty(Child)"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(16),  _
         tab("Child Part Number"),  _
         Pos(9),  _
         Mandatory(true),  _
         twodBarcode("SONQUANT")>  _
        Public Property SONQUANT() As nullable(of decimal)
            Get
                return _SONQUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Qty(Child)", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSONQUANT = True
                If loading Then
                  _SONQUANT = Value
                Else
                    if not _SONQUANT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SONQUANT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SONQUANT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Factory Unit"),  _
         nType("Edm.String"),  _
         tab("Child Part Number"),  _
         Pos(10),  _
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
        
        <DisplayName("Coefficient"),  _
         nType("Edm.Decimal"),  _
         Scale(0),  _
         Precision(13),  _
         tab("Child Part Number"),  _
         Pos(11),  _
         [ReadOnly](true),  _
         twodBarcode("COEF")>  _
        Public Property COEF() As nullable(of decimal)
            Get
                return _COEF
            End Get
            Set
                if not(value is nothing) then
                  _COEF = Value
                end if
            End Set
        End Property
        
        <DisplayName("Operand (C/M/D)"),  _
         nType("Edm.String"),  _
         tab("Child Part Number"),  _
         Pos(12),  _
         Mandatory(true),  _
         twodBarcode("OP")>  _
        Public Property OP() As String
            Get
                return _OP
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Operand (C/M/D)", value, "^.{0,1}$") then Exit Property
                _IsSetOP = True
                If loading Then
                  _OP = Value
                Else
                    if not _OP = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("OP", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _OP = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Variable"),  _
         nType("Edm.String"),  _
         tab("Variable"),  _
         Pos(14),  _
         twodBarcode("VARNAME")>  _
        Public Property VARNAME() As String
            Get
                return _VARNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Variable", value, "^.{0,16}$") then Exit Property
                _IsSetVARNAME = True
                If loading Then
                  _VARNAME = Value
                Else
                    if not _VARNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("VARNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _VARNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Scrap (%)"),  _
         nType("Edm.Decimal"),  _
         Scale(2),  _
         Precision(13),  _
         tab("Variable"),  _
         Pos(20),  _
         twodBarcode("SCRAP")>  _
        Public Property SCRAP() As nullable(of decimal)
            Get
                return _SCRAP
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Scrap (%)", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetSCRAP = True
                If loading Then
                  _SCRAP = Value
                Else
                    if not _SCRAP = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SCRAP", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SCRAP = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Parent Operation"),  _
         nType("Edm.String"),  _
         tab("Variable"),  _
         Pos(30),  _
         Mandatory(true),  _
         twodBarcode("ACTNAME")>  _
        Public Property ACTNAME() As String
            Get
                return _ACTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Parent Operation", value, "^.{0,16}$") then Exit Property
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
        
        <DisplayName("Child Operation"),  _
         nType("Edm.String"),  _
         tab("Variable"),  _
         Pos(32),  _
         Mandatory(true),  _
         twodBarcode("SONACTNAME")>  _
        Public Property SONACTNAME() As String
            Get
                return _SONACTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Child Operation", value, "^.{0,16}$") then Exit Property
                _IsSetSONACTNAME = True
                If loading Then
                  _SONACTNAME = Value
                Else
                    if not _SONACTNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SONACTNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SONACTNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Info Only"),  _
         nType("Edm.String"),  _
         tab("Variable"),  _
         Pos(35),  _
         twodBarcode("INFOONLY")>  _
        Public Property INFOONLY() As String
            Get
                return _INFOONLY
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Info Only", value, "^.{0,1}$") then Exit Property
                _IsSetINFOONLY = True
                If loading Then
                  _INFOONLY = Value
                Else
                    if not _INFOONLY = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("INFOONLY", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _INFOONLY = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Variable"),  _
         Pos(36),  _
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
         tab("Variable"),  _
         Pos(37),  _
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
        
        <DisplayName("Operation (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Variable"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("ACT")>  _
        Public Property ACT() As nullable (of int64)
            Get
                return _ACT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Operation (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetACT = True
                If loading Then
                  _ACT = Value
                Else
                    if not _ACT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ACT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ACT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Child Part No. (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Child Part No. (ID)"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("SON")>  _
        Public Property SON() As nullable (of int64)
            Get
                return _SON
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Child Part No. (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetSON = True
                If loading Then
                  _SON = Value
                Else
                    if not _SON = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SON", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SON = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Child Operation (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Child Part No. (ID)"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("SONACT")>  _
        Public Property SONACT() As nullable (of int64)
            Get
                return _SONACT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Child Operation (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetSONACT = True
                If loading Then
                  _SONACT = Value
                Else
                    if not _SONACT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SONACT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SONACT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetSONNAME then
              if f then
                  jw.WriteRaw(", ""SONNAME"": ")
              else
                  jw.WriteRaw("""SONNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SONNAME)
            end if
            if _IsSetSONREVNAME then
              if f then
                  jw.WriteRaw(", ""SONREVNAME"": ")
              else
                  jw.WriteRaw("""SONREVNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SONREVNAME)
            end if
            if _IsSetSONQUANT then
              if f then
                  jw.WriteRaw(", ""SONQUANT"": ")
              else
                  jw.WriteRaw("""SONQUANT"": ")
                  f = true
              end if
              jw.WriteValue(me.SONQUANT)
            end if
            if _IsSetOP then
              if f then
                  jw.WriteRaw(", ""OP"": ")
              else
                  jw.WriteRaw("""OP"": ")
                  f = true
              end if
              jw.WriteValue(me.OP)
            end if
            if _IsSetVARNAME then
              if f then
                  jw.WriteRaw(", ""VARNAME"": ")
              else
                  jw.WriteRaw("""VARNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.VARNAME)
            end if
            if _IsSetSCRAP then
              if f then
                  jw.WriteRaw(", ""SCRAP"": ")
              else
                  jw.WriteRaw("""SCRAP"": ")
                  f = true
              end if
              jw.WriteValue(me.SCRAP)
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
            if _IsSetSONACTNAME then
              if f then
                  jw.WriteRaw(", ""SONACTNAME"": ")
              else
                  jw.WriteRaw("""SONACTNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SONACTNAME)
            end if
            if _IsSetINFOONLY then
              if f then
                  jw.WriteRaw(", ""INFOONLY"": ")
              else
                  jw.WriteRaw("""INFOONLY"": ")
                  f = true
              end if
              jw.WriteValue(me.INFOONLY)
            end if
            if _IsSetACT then
              if f then
                  jw.WriteRaw(", ""ACT"": ")
              else
                  jw.WriteRaw("""ACT"": ")
                  f = true
              end if
              jw.WriteValue(me.ACT)
            end if
            if _IsSetSON then
              if f then
                  jw.WriteRaw(", ""SON"": ")
              else
                  jw.WriteRaw("""SON"": ")
                  f = true
              end if
              jw.WriteValue(me.SON)
            end if
            if _IsSetSONACT then
              if f then
                  jw.WriteRaw(", ""SONACT"": ")
              else
                  jw.WriteRaw("""SONACT"": ")
                  f = true
              end if
              jw.WriteValue(me.SONACT)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "REVPARTARC")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "ACT")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "SON")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "SONACT")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetSONNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SONNAME")
              .WriteAttributeString("value", me.SONNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "15")
              .WriteEndElement
            end if
            if _IsSetSONREVNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SONREVNAME")
              .WriteAttributeString("value", me.SONREVNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "10")
              .WriteEndElement
            end if
            if _IsSetSONQUANT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SONQUANT")
              .WriteAttributeString("value", me.SONQUANT)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "3")
              .WriteAttributeString("Precision", "16")
              .WriteEndElement
            end if
            if _IsSetOP then
              .WriteStartElement("field")
              .WriteAttributeString("name", "OP")
              .WriteAttributeString("value", me.OP)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetVARNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "VARNAME")
              .WriteAttributeString("value", me.VARNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetSCRAP then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SCRAP")
              .WriteAttributeString("value", me.SCRAP)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "2")
              .WriteAttributeString("Precision", "13")
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
            if _IsSetSONACTNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SONACTNAME")
              .WriteAttributeString("value", me.SONACTNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetINFOONLY then
              .WriteStartElement("field")
              .WriteAttributeString("name", "INFOONLY")
              .WriteAttributeString("value", me.INFOONLY)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetACT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ACT")
              .WriteAttributeString("value", me.ACT)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetSON then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SON")
              .WriteAttributeString("value", me.SON)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetSONACT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SONACT")
              .WriteAttributeString("value", me.SONACT)
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
                dim obj as REVPARTARC = JsonConvert.DeserializeObject(Of REVPARTARC)(e.StreamReader.ReadToEnd)
                With obj
                  _SONNAME = .SONNAME
                  _TYPE = .TYPE
                  _SONDES = .SONDES
                  _SONREVNAME = .SONREVNAME
                  _SONQUANT = .SONQUANT
                  _UNITNAME = .UNITNAME
                  _COEF = .COEF
                  _OP = .OP
                  _VARNAME = .VARNAME
                  _SCRAP = .SCRAP
                  _ACTNAME = .ACTNAME
                  _SONACTNAME = .SONACTNAME
                  _INFOONLY = .INFOONLY
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _ACT = .ACT
                  _SON = .SON
                  _SONACT = .SONACT
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Tools for the Part")>  _
    Public Class QUERY_REVPARTARCTOOL
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of REVPARTARCTOOL)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of REVPARTARCTOOL)
            _Parent = nothing
            _Name = "REVPARTARCTOOL"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of REVPARTARCTOOL)
            _Parent = Parent
            _name = "REVPARTARCTOOL_SUBFORM"
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
        
        Public Property Value() As list(of REVPARTARCTOOL)
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
                return GetType(REVPARTARCTOOL)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _REVPARTARCTOOL As REVPARTARCTOOL In JsonConvert.DeserializeObject(Of QUERY_REVPARTARCTOOL)(stream.ReadToEnd).Value
              With _REVPARTARCTOOL
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_REVPARTARCTOOL)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as REVPARTARCTOOL = JsonConvert.DeserializeObject(Of REVPARTARCTOOL)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, REVPARTARCTOOL)
                  .SONNAME = obj.SONNAME
                  .SONDES = obj.SONDES
                  .ACTNAME = obj.ACTNAME
                  .ACTDES = obj.ACTDES
                  .SON = obj.SON
                  .ACT = obj.ACT
                  .SONACT = obj.SONACT
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new REVPARTARCTOOL(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _REVPARTARCTOOL as REVPARTARCTOOL in value
              If _REVPARTARCTOOL.Equals(trycast(obj,REVPARTARCTOOL)) Then
                  value.remove(_REVPARTARCTOOL)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class REVPARTARCTOOL
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetSONNAME As Boolean = Boolean.FalseString
        
        Private _SONNAME As String
        
        Private _SONDES As String
        
        Private _IsSetACTNAME As Boolean = Boolean.FalseString
        
        Private _ACTNAME As String
        
        Private _ACTDES As String
        
        Private _IsSetSON As Boolean = Boolean.FalseString
        
        Private _SON As Long
        
        Private _IsSetACT As Boolean = Boolean.FalseString
        
        Private _ACT As Long
        
        Private _IsSetSONACT As Boolean = Boolean.FalseString
        
        Private _SONACT As Long
        
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
                    return "REVPARTARCTOOL"
                else
                    return "REVPARTARCTOOL_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "SON={0},ACT={1},SONACT={2}", _
                  string.format("{0}",SON), _
                  string.format("{0}",ACT), _
                  string.format("{0}",SONACT) _ 
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
        
        <DisplayName("Tool Number"),  _
         nType("Edm.String"),  _
         tab("Tool Number"),  _
         Pos(5),  _
         twodBarcode("SONNAME")>  _
        Public Property SONNAME() As String
            Get
                return _SONNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Tool Number", value, "^.{0,15}$") then Exit Property
                _IsSetSONNAME = True
                If loading Then
                  _SONNAME = Value
                Else
                    if not _SONNAME = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SONNAME", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SONNAME = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Tool Description"),  _
         nType("Edm.String"),  _
         tab("Tool Number"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("SONDES")>  _
        Public Property SONDES() As String
            Get
                return _SONDES
            End Get
            Set
                if not(value is nothing) then
                  _SONDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Operation on Part"),  _
         nType("Edm.String"),  _
         tab("Tool Number"),  _
         Pos(35),  _
         twodBarcode("ACTNAME")>  _
        Public Property ACTNAME() As String
            Get
                return _ACTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Operation on Part", value, "^.{0,16}$") then Exit Property
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
         tab("Tool Number"),  _
         Pos(40),  _
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
        
        <DisplayName("Child Part No. (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Tool Number"),  _
         Pos(20),  _
         Browsable(false),  _
         twodBarcode("SON")>  _
        Public Property SON() As nullable (of int64)
            Get
                return _SON
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Child Part No. (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetSON = True
                If loading Then
                  _SON = Value
                Else
                    if not _SON = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SON", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SON = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Operation (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Tool Number"),  _
         Pos(30),  _
         Browsable(false),  _
         twodBarcode("ACT")>  _
        Public Property ACT() As nullable (of int64)
            Get
                return _ACT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Operation (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetACT = True
                If loading Then
                  _ACT = Value
                Else
                    if not _ACT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ACT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ACT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Child Operation (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Tool Number"),  _
         Pos(70),  _
         Browsable(false),  _
         twodBarcode("SONACT")>  _
        Public Property SONACT() As nullable (of int64)
            Get
                return _SONACT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Child Operation (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetSONACT = True
                If loading Then
                  _SONACT = Value
                Else
                    if not _SONACT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SONACT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SONACT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetSONNAME then
              if f then
                  jw.WriteRaw(", ""SONNAME"": ")
              else
                  jw.WriteRaw("""SONNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.SONNAME)
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
            if _IsSetSON then
              if f then
                  jw.WriteRaw(", ""SON"": ")
              else
                  jw.WriteRaw("""SON"": ")
                  f = true
              end if
              jw.WriteValue(me.SON)
            end if
            if _IsSetACT then
              if f then
                  jw.WriteRaw(", ""ACT"": ")
              else
                  jw.WriteRaw("""ACT"": ")
                  f = true
              end if
              jw.WriteValue(me.ACT)
            end if
            if _IsSetSONACT then
              if f then
                  jw.WriteRaw(", ""SONACT"": ")
              else
                  jw.WriteRaw("""SONACT"": ")
                  f = true
              end if
              jw.WriteValue(me.SONACT)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "REVPARTARCTOOL")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "SON")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "ACT")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "SONACT")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetSONNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SONNAME")
              .WriteAttributeString("value", me.SONNAME)
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
            if _IsSetSON then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SON")
              .WriteAttributeString("value", me.SON)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetACT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ACT")
              .WriteAttributeString("value", me.ACT)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetSONACT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SONACT")
              .WriteAttributeString("value", me.SONACT)
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
                dim obj as REVPARTARCTOOL = JsonConvert.DeserializeObject(Of REVPARTARCTOOL)(e.StreamReader.ReadToEnd)
                With obj
                  _SONNAME = .SONNAME
                  _SONDES = .SONDES
                  _ACTNAME = .ACTNAME
                  _ACTDES = .ACTDES
                  _SON = .SON
                  _ACT = .ACT
                  _SONACT = .SONACT
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Child Part Designations")>  _
    Public Class QUERY_LOCATIONS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of LOCATIONS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of LOCATIONS)
            _Parent = nothing
            _Name = "LOCATIONS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of LOCATIONS)
            _Parent = Parent
            _name = "LOCATIONS_SUBFORM"
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
        
        Public Property Value() As list(of LOCATIONS)
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
                return GetType(LOCATIONS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _LOCATIONS As LOCATIONS In JsonConvert.DeserializeObject(Of QUERY_LOCATIONS)(stream.ReadToEnd).Value
              With _LOCATIONS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_LOCATIONS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as LOCATIONS = JsonConvert.DeserializeObject(Of LOCATIONS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, LOCATIONS)
                  .PARTNAME = obj.PARTNAME
                  .PARTDES = obj.PARTDES
                  .TYPE = obj.TYPE
                  .LOCATION = obj.LOCATION
                  .TOLOCATION = obj.TOLOCATION
                  .QUANT = obj.QUANT
                  .X = obj.X
                  .Y = obj.Y
                  .Z = obj.Z
                  .SON = obj.SON
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new LOCATIONS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _LOCATIONS as LOCATIONS in value
              If _LOCATIONS.Equals(trycast(obj,LOCATIONS)) Then
                  value.remove(_LOCATIONS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class LOCATIONS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetPARTNAME As Boolean = Boolean.FalseString
        
        Private _PARTNAME As String
        
        Private _PARTDES As String
        
        Private _TYPE As String
        
        Private _IsSetLOCATION As Boolean = Boolean.FalseString
        
        Private _LOCATION As String
        
        Private _IsSetTOLOCATION As Boolean = Boolean.FalseString
        
        Private _TOLOCATION As String
        
        Private _IsSetQUANT As Boolean = Boolean.FalseString
        
        Private _QUANT As Long
        
        Private _IsSetX As Boolean = Boolean.FalseString
        
        Private _X As Decimal
        
        Private _IsSetY As Boolean = Boolean.FalseString
        
        Private _Y As Decimal
        
        Private _IsSetZ As Boolean = Boolean.FalseString
        
        Private _Z As Decimal
        
        Private _IsSetSON As Boolean = Boolean.FalseString
        
        Private _SON As Long
        
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
                    return "LOCATIONS"
                else
                    return "LOCATIONS_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "LOCATION={0},SON={1}", _
                  string.format("'{0}'",LOCATION), _
                  string.format("{0}",SON) _ 
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
         Pos(15),  _
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
        
        <DisplayName("Type (P/R)"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
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
        
        <DisplayName("Designation"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(30),  _
         twodBarcode("LOCATION")>  _
        Public Property LOCATION() As String
            Get
                return _LOCATION
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Designation", value, "^.{0,10}$") then Exit Property
                _IsSetLOCATION = True
                If loading Then
                  _LOCATION = Value
                Else
                    if not _LOCATION = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("LOCATION", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _LOCATION = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("To Designation"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(32),  _
         twodBarcode("TOLOCATION")>  _
        Public Property TOLOCATION() As String
            Get
                return _TOLOCATION
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("To Designation", value, "^.{0,10}$") then Exit Property
                _IsSetTOLOCATION = True
                If loading Then
                  _TOLOCATION = Value
                Else
                    if not _TOLOCATION = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("TOLOCATION", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _TOLOCATION = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Quantity"),  _
         nType("Edm.Int64"),  _
         tab("Part Number"),  _
         Pos(34),  _
         twodBarcode("QUANT")>  _
        Public Property QUANT() As nullable (of int64)
            Get
                return _QUANT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Quantity", value, "^[0-9\-]+$") then Exit Property
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
        
        <DisplayName("X Coordinate"),  _
         nType("Edm.Decimal"),  _
         Scale(0),  _
         Precision(10),  _
         tab("Part Number"),  _
         Pos(40),  _
         twodBarcode("X")>  _
        Public Property X() As nullable(of decimal)
            Get
                return _X
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("X Coordinate", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetX = True
                If loading Then
                  _X = Value
                Else
                    if not _X = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("X", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _X = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Y Coordinate"),  _
         nType("Edm.Decimal"),  _
         Scale(0),  _
         Precision(10),  _
         tab("Part Number"),  _
         Pos(50),  _
         twodBarcode("Y")>  _
        Public Property Y() As nullable(of decimal)
            Get
                return _Y
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Y Coordinate", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetY = True
                If loading Then
                  _Y = Value
                Else
                    if not _Y = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("Y", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _Y = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Z Coordinate"),  _
         nType("Edm.Decimal"),  _
         Scale(0),  _
         Precision(10),  _
         tab("Z Coordinate"),  _
         Pos(60),  _
         twodBarcode("Z")>  _
        Public Property Z() As nullable(of decimal)
            Get
                return _Z
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Z Coordinate", value, "^[0-9\.\-]+$") then Exit Property
                _IsSetZ = True
                If loading Then
                  _Z = Value
                Else
                    if not _Z = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("Z", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _Z = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Child Part No. (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Z Coordinate"),  _
         Pos(70),  _
         Browsable(false),  _
         twodBarcode("SON")>  _
        Public Property SON() As nullable (of int64)
            Get
                return _SON
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Child Part No. (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetSON = True
                If loading Then
                  _SON = Value
                Else
                    if not _SON = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SON", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SON = Value
                        End If
                    end if
                end if
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
            if _IsSetLOCATION then
              if f then
                  jw.WriteRaw(", ""LOCATION"": ")
              else
                  jw.WriteRaw("""LOCATION"": ")
                  f = true
              end if
              jw.WriteValue(me.LOCATION)
            end if
            if _IsSetTOLOCATION then
              if f then
                  jw.WriteRaw(", ""TOLOCATION"": ")
              else
                  jw.WriteRaw("""TOLOCATION"": ")
                  f = true
              end if
              jw.WriteValue(me.TOLOCATION)
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
            if _IsSetX then
              if f then
                  jw.WriteRaw(", ""X"": ")
              else
                  jw.WriteRaw("""X"": ")
                  f = true
              end if
              jw.WriteValue(me.X)
            end if
            if _IsSetY then
              if f then
                  jw.WriteRaw(", ""Y"": ")
              else
                  jw.WriteRaw("""Y"": ")
                  f = true
              end if
              jw.WriteValue(me.Y)
            end if
            if _IsSetZ then
              if f then
                  jw.WriteRaw(", ""Z"": ")
              else
                  jw.WriteRaw("""Z"": ")
                  f = true
              end if
              jw.WriteValue(me.Z)
            end if
            if _IsSetSON then
              if f then
                  jw.WriteRaw(", ""SON"": ")
              else
                  jw.WriteRaw("""SON"": ")
                  f = true
              end if
              jw.WriteValue(me.SON)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "LOCATIONS")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "LOCATION")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "10")
              .WriteEndElement
              .WriteStartElement("key")
              .WriteAttributeString("name", "SON")
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
            if _IsSetLOCATION then
              .WriteStartElement("field")
              .WriteAttributeString("name", "LOCATION")
              .WriteAttributeString("value", me.LOCATION)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "10")
              .WriteEndElement
            end if
            if _IsSetTOLOCATION then
              .WriteStartElement("field")
              .WriteAttributeString("name", "TOLOCATION")
              .WriteAttributeString("value", me.TOLOCATION)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "10")
              .WriteEndElement
            end if
            if _IsSetQUANT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "QUANT")
              .WriteAttributeString("value", me.QUANT)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _IsSetX then
              .WriteStartElement("field")
              .WriteAttributeString("name", "X")
              .WriteAttributeString("value", me.X)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "0")
              .WriteAttributeString("Precision", "10")
              .WriteEndElement
            end if
            if _IsSetY then
              .WriteStartElement("field")
              .WriteAttributeString("name", "Y")
              .WriteAttributeString("value", me.Y)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "0")
              .WriteAttributeString("Precision", "10")
              .WriteEndElement
            end if
            if _IsSetZ then
              .WriteStartElement("field")
              .WriteAttributeString("name", "Z")
              .WriteAttributeString("value", me.Z)
              .WriteAttributeString("type", "Edm.Decimal")
              .WriteAttributeString("Scale", "0")
              .WriteAttributeString("Precision", "10")
              .WriteEndElement
            end if
            if _IsSetSON then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SON")
              .WriteAttributeString("value", me.SON)
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
                dim obj as LOCATIONS = JsonConvert.DeserializeObject(Of LOCATIONS)(e.StreamReader.ReadToEnd)
                With obj
                  _PARTNAME = .PARTNAME
                  _PARTDES = .PARTDES
                  _TYPE = .TYPE
                  _LOCATION = .LOCATION
                  _TOLOCATION = .TOLOCATION
                  _QUANT = .QUANT
                  _X = .X
                  _Y = .Y
                  _Z = .Z
                  _SON = .SON
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Revision Authorisation")>  _
    Public Class QUERY_REVISIONUSER
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of REVISIONUSER)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of REVISIONUSER)
            _Parent = nothing
            _Name = "REVISIONUSER"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of REVISIONUSER)
            _Parent = Parent
            _name = "REVISIONUSER_SUBFORM"
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
        
        Public Property Value() As list(of REVISIONUSER)
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
                return GetType(REVISIONUSER)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _REVISIONUSER As REVISIONUSER In JsonConvert.DeserializeObject(Of QUERY_REVISIONUSER)(stream.ReadToEnd).Value
              With _REVISIONUSER
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_REVISIONUSER)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as REVISIONUSER = JsonConvert.DeserializeObject(Of REVISIONUSER)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, REVISIONUSER)
                  .USERLOGIN = obj.USERLOGIN
                  .UFLAG = obj.UFLAG
                  .UDATE = obj.UDATE
                  .USER = obj.USER
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new REVISIONUSER(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _REVISIONUSER as REVISIONUSER in value
              If _REVISIONUSER.Equals(trycast(obj,REVISIONUSER)) Then
                  value.remove(_REVISIONUSER)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class REVISIONUSER
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _USERLOGIN As String
        
        Private _IsSetUFLAG As Boolean = Boolean.FalseString
        
        Private _UFLAG As String
        
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
                    return "REVISIONUSER"
                else
                    return "REVISIONUSER_SUBFORM"
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
        
        <DisplayName("Name"),  _
         nType("Edm.String"),  _
         tab("Name"),  _
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
        
        <DisplayName("Approve"),  _
         nType("Edm.String"),  _
         tab("Name"),  _
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
        
        <DisplayName("Authorisation Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Name"),  _
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
         tab("Name"),  _
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
                .WriteAttributeString("name", "REVISIONUSER")
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
                dim obj as REVISIONUSER = JsonConvert.DeserializeObject(Of REVISIONUSER)(e.StreamReader.ReadToEnd)
                With obj
                  _USERLOGIN = .USERLOGIN
                  _UFLAG = .UFLAG
                  _UDATE = .UDATE
                  _USER = .USER
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Custom BOM for Item: Conditions")>  _
    Public Class QUERY_PARTCONFIG
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PARTCONFIG)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PARTCONFIG)
            _Parent = nothing
            _Name = "PARTCONFIG"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PARTCONFIG)
            _Parent = Parent
            _name = "PARTCONFIG_SUBFORM"
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
        
        Public Property Value() As list(of PARTCONFIG)
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
                return GetType(PARTCONFIG)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PARTCONFIG As PARTCONFIG In JsonConvert.DeserializeObject(Of QUERY_PARTCONFIG)(stream.ReadToEnd).Value
              With _PARTCONFIG
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PARTCONFIG)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PARTCONFIG = JsonConvert.DeserializeObject(Of PARTCONFIG)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PARTCONFIG)
                  .PARTNAME = obj.PARTNAME
                  .PARTDES = obj.PARTDES
                  .DELETEWARNING = obj.DELETEWARNING
                  .SON = obj.SON
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PARTCONFIG(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PARTCONFIG as PARTCONFIG in value
              If _PARTCONFIG.Equals(trycast(obj,PARTCONFIG)) Then
                  value.remove(_PARTCONFIG)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PARTCONFIG
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetPARTNAME As Boolean = Boolean.FalseString
        
        Private _PARTNAME As String
        
        Private _PARTDES As String
        
        Private _IsSetDELETEWARNING As Boolean = Boolean.FalseString
        
        Private _DELETEWARNING As String
        
        Private _IsSetSON As Boolean = Boolean.FalseString
        
        Private _SON As Long
        
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
                    return "PARTCONFIG"
                else
                    return "PARTCONFIG_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "SON={0}", _
                  string.format("{0}",SON) _ 
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
        
        <DisplayName("Child Part Number"),  _
         nType("Edm.String"),  _
         tab("Child Part Number"),  _
         Pos(40),  _
         twodBarcode("PARTNAME")>  _
        Public Property PARTNAME() As String
            Get
                return _PARTNAME
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Child Part Number", value, "^.{0,15}$") then Exit Property
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
         tab("Child Part Number"),  _
         Pos(50),  _
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
        
        <DisplayName("Deletion Warning"),  _
         nType("Edm.String"),  _
         tab("Child Part Number"),  _
         Pos(60),  _
         twodBarcode("DELETEWARNING")>  _
        Public Property DELETEWARNING() As String
            Get
                return _DELETEWARNING
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Deletion Warning", value, "^.{0,1}$") then Exit Property
                _IsSetDELETEWARNING = True
                If loading Then
                  _DELETEWARNING = Value
                Else
                    if not _DELETEWARNING = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("DELETEWARNING", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _DELETEWARNING = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Child Part (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Child Part Number"),  _
         Pos(20),  _
         Browsable(false),  _
         twodBarcode("SON")>  _
        Public Property SON() As nullable (of int64)
            Get
                return _SON
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Child Part (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetSON = True
                If loading Then
                  _SON = Value
                Else
                    if not _SON = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("SON", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _SON = Value
                        End If
                    end if
                end if
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
            if _IsSetDELETEWARNING then
              if f then
                  jw.WriteRaw(", ""DELETEWARNING"": ")
              else
                  jw.WriteRaw("""DELETEWARNING"": ")
                  f = true
              end if
              jw.WriteValue(me.DELETEWARNING)
            end if
            if _IsSetSON then
              if f then
                  jw.WriteRaw(", ""SON"": ")
              else
                  jw.WriteRaw("""SON"": ")
                  f = true
              end if
              jw.WriteValue(me.SON)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "PARTCONFIG")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "SON")
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
            if _IsSetDELETEWARNING then
              .WriteStartElement("field")
              .WriteAttributeString("name", "DELETEWARNING")
              .WriteAttributeString("value", me.DELETEWARNING)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetSON then
              .WriteStartElement("field")
              .WriteAttributeString("name", "SON")
              .WriteAttributeString("value", me.SON)
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
                dim obj as PARTCONFIG = JsonConvert.DeserializeObject(Of PARTCONFIG)(e.StreamReader.ReadToEnd)
                With obj
                  _PARTNAME = .PARTNAME
                  _PARTDES = .PARTDES
                  _DELETEWARNING = .DELETEWARNING
                  _SON = .SON
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Part Revisions")>  _
    Public Class QUERY_PARTREV
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PARTREV)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PARTREV)
            _Parent = nothing
            _Name = "PARTREV"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Revision Authorisation")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PARTREV)
            _Parent = Parent
            _name = "PARTREV_SUBFORM"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Revision Authorisation")
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
        
        Public Property Value() As list(of PARTREV)
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
                return GetType(PARTREV)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PARTREV As PARTREV In JsonConvert.DeserializeObject(Of QUERY_PARTREV)(stream.ReadToEnd).Value
              With _PARTREV
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PARTREV)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PARTREV = JsonConvert.DeserializeObject(Of PARTREV)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PARTREV)
                  .REVNAME = obj.REVNAME
                  .FROMDATE = obj.FROMDATE
                  .SIGNUSERLOGIN = obj.SIGNUSERLOGIN
                  .CONFIRMED = obj.CONFIRMED
                  .VALID = obj.VALID
                  .INACTIVE = obj.INACTIVE
                  .ECONUM = obj.ECONUM
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .REV = obj.REV
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PARTREV(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PARTREV as PARTREV in value
              If _PARTREV.Equals(trycast(obj,PARTREV)) Then
                  value.remove(_PARTREV)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PARTREV
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetREVNAME As Boolean = Boolean.FalseString
        
        Private _REVNAME As String
        
        Private _IsSetFROMDATE As Boolean = Boolean.FalseString
        
        Private _FROMDATE As System.DateTimeOffset
        
        Private _SIGNUSERLOGIN As String
        
        Private _CONFIRMED As String
        
        Private _IsSetVALID As Boolean = Boolean.FalseString
        
        Private _VALID As String
        
        Private _IsSetINACTIVE As Boolean = Boolean.FalseString
        
        Private _INACTIVE As String
        
        Private _IsSetECONUM As Boolean = Boolean.FalseString
        
        Private _ECONUM As String
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _IsSetREV As Boolean = Boolean.FalseString
        
        Private _REV As Long
        
        Private _PARTREVUSER_SUBFORM As QUERY_PARTREVUSER
        
        Public Sub New(ByVal Parent As oDataObject)
            MyBase.New
            _parent = Parent
            ChildQuery.add(0, new oNavigation("Revision Authorisation"))
            _PARTREVUSER_SUBFORM = new QUERY_PARTREVUSER(me)
            WITH ChildQuery(0)
               .setoDataQuery(_PARTREVUSER_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Revision Authorisation", _PARTREVUSER_SUBFORM))
               end with
            end with
        End Sub
        
        Public Sub New()
            MyBase.New
            ChildQuery.add(0, new oNavigation("Revision Authorisation"))
            _PARTREVUSER_SUBFORM = new QUERY_PARTREVUSER(me)
            WITH ChildQuery(0)
               .setoDataQuery(_PARTREVUSER_SUBFORM)
               WITH .oDataQuery.SibligQuery
                   .add(0, new oNavigation("Revision Authorisation", _PARTREVUSER_SUBFORM))
               end with
            end with
        End Sub
        
        Protected Friend Overrides ReadOnly Property EntityName() As String
            Get
                if _parent is nothing then
                    return "PARTREV"
                else
                    return "PARTREV_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "REV={0}", _
                  string.format("{0}",REV) _ 
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
        
        <DisplayName("Part Revision No."),  _
         nType("Edm.String"),  _
         tab("Part Revision No."),  _
         Pos(10),  _
         Mandatory(true),  _
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
        
        <DisplayName("Use From"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Part Revision No."),  _
         Pos(30),  _
         twodBarcode("FROMDATE")>  _
        Public Property FROMDATE() As nullable (of DateTimeOffset)
            Get
                return _FROMDATE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Use From", value, "^.*$") then Exit Property
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
        
        <DisplayName("Next Signature"),  _
         nType("Edm.String"),  _
         tab("Part Revision No."),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("SIGNUSERLOGIN")>  _
        Public Property SIGNUSERLOGIN() As String
            Get
                return _SIGNUSERLOGIN
            End Get
            Set
                if not(value is nothing) then
                  _SIGNUSERLOGIN = Value
                end if
            End Set
        End Property
        
        <DisplayName("Authorised"),  _
         nType("Edm.String"),  _
         tab("Part Revision No."),  _
         Pos(50),  _
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
        
        <DisplayName("In Effect?"),  _
         nType("Edm.String"),  _
         tab("Part Revision No."),  _
         Pos(55),  _
         twodBarcode("VALID")>  _
        Public Property VALID() As String
            Get
                return _VALID
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("In Effect?", value, "^.{0,1}$") then Exit Property
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
        
        <DisplayName("Not in Use"),  _
         nType("Edm.String"),  _
         tab("Part Revision No."),  _
         Pos(56),  _
         twodBarcode("INACTIVE")>  _
        Public Property INACTIVE() As String
            Get
                return _INACTIVE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Not in Use", value, "^.{0,1}$") then Exit Property
                _IsSetINACTIVE = True
                If loading Then
                  _INACTIVE = Value
                Else
                    if not _INACTIVE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("INACTIVE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _INACTIVE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("ECO Number"),  _
         nType("Edm.String"),  _
         tab("Part Revision No."),  _
         Pos(57),  _
         twodBarcode("ECONUM")>  _
        Public Property ECONUM() As String
            Get
                return _ECONUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("ECO Number", value, "^.{0,16}$") then Exit Property
                _IsSetECONUM = True
                If loading Then
                  _ECONUM = Value
                Else
                    if not _ECONUM = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ECONUM", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ECONUM = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Part Revision No."),  _
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
         tab("Time Stamp"),  _
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
        
        <DisplayName("Revision (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Time Stamp"),  _
         Pos(20),  _
         Browsable(false),  _
         twodBarcode("REV")>  _
        Public Property REV() As nullable (of int64)
            Get
                return _REV
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Revision (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetREV = True
                If loading Then
                  _REV = Value
                Else
                    if not _REV = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("REV", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _REV = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <JsonIgnore(),  _
         Browsable(false)>  _
        Public Property PARTREVUSER_SUBFORM() As QUERY_PARTREVUSER
            Get
                return _PARTREVUSER_SUBFORM
            End Get
            Set
                _PARTREVUSER_SUBFORM = value
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetREVNAME then
              if f then
                  jw.WriteRaw(", ""REVNAME"": ")
              else
                  jw.WriteRaw("""REVNAME"": ")
                  f = true
              end if
              jw.WriteValue(me.REVNAME)
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
            if _IsSetVALID then
              if f then
                  jw.WriteRaw(", ""VALID"": ")
              else
                  jw.WriteRaw("""VALID"": ")
                  f = true
              end if
              jw.WriteValue(me.VALID)
            end if
            if _IsSetINACTIVE then
              if f then
                  jw.WriteRaw(", ""INACTIVE"": ")
              else
                  jw.WriteRaw("""INACTIVE"": ")
                  f = true
              end if
              jw.WriteValue(me.INACTIVE)
            end if
            if _IsSetECONUM then
              if f then
                  jw.WriteRaw(", ""ECONUM"": ")
              else
                  jw.WriteRaw("""ECONUM"": ")
                  f = true
              end if
              jw.WriteValue(me.ECONUM)
            end if
            if _IsSetREV then
              if f then
                  jw.WriteRaw(", ""REV"": ")
              else
                  jw.WriteRaw("""REV"": ")
                  f = true
              end if
              jw.WriteValue(me.REV)
            end if
            if _PARTREVUSER_SUBFORM.value.count > 0 then
              jw.WriteRaw(", PARTREVUSER_SUBFORM: ")
              jw.WriteRaw("[ ")
              dim i as integer = 0
              for each itm as PARTREVUSER in _PARTREVUSER_SUBFORM.value
                jw.WriteRaw("{ ")
                itm.tojson(jw)
                jw.WriteRaw(" }")
                if i < _PARTREVUSER_SUBFORM.value.count - 1 then jw.WriteRaw(", ")
                i += 1
                next
              jw.WriteRaw(" ]")
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "PARTREV")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "REV")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetREVNAME then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REVNAME")
              .WriteAttributeString("value", me.REVNAME)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "10")
              .WriteEndElement
            end if
            if _IsSetFROMDATE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "FROMDATE")
              .WriteAttributeString("value", me.FROMDATE)
              .WriteAttributeString("type", "Edm.DateTimeOffset")
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
            if _IsSetINACTIVE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "INACTIVE")
              .WriteAttributeString("value", me.INACTIVE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "1")
              .WriteEndElement
            end if
            if _IsSetECONUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ECONUM")
              .WriteAttributeString("value", me.ECONUM)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetREV then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REV")
              .WriteAttributeString("value", me.REV)
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            end if
            if _PARTREVUSER_SUBFORM.value.count > 0 then
              for each itm as PARTREVUSER in _PARTREVUSER_SUBFORM.Value
                itm.toXML(xw,"PARTREVUSER_SUBFORM")
              next
            end if
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PARTREV = JsonConvert.DeserializeObject(Of PARTREV)(e.StreamReader.ReadToEnd)
                With obj
                  _REVNAME = .REVNAME
                  _FROMDATE = .FROMDATE
                  _SIGNUSERLOGIN = .SIGNUSERLOGIN
                  _CONFIRMED = .CONFIRMED
                  _VALID = .VALID
                  _INACTIVE = .INACTIVE
                  _ECONUM = .ECONUM
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _REV = .REV
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_PARTREV
        
        PARTREVUSER = 0
    End Enum
    
    <QueryTitle("Revision Authorisation")>  _
    Public Class QUERY_PARTREVUSER
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of PARTREVUSER)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of PARTREVUSER)
            _Parent = nothing
            _Name = "PARTREVUSER"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of PARTREVUSER)
            _Parent = Parent
            _name = "PARTREVUSER_SUBFORM"
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
        
        Public Property Value() As list(of PARTREVUSER)
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
                return GetType(PARTREVUSER)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _PARTREVUSER As PARTREVUSER In JsonConvert.DeserializeObject(Of QUERY_PARTREVUSER)(stream.ReadToEnd).Value
              With _PARTREVUSER
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_PARTREVUSER)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as PARTREVUSER = JsonConvert.DeserializeObject(Of PARTREVUSER)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, PARTREVUSER)
                  .USERLOGIN = obj.USERLOGIN
                  .UFLAG = obj.UFLAG
                  .UDATE = obj.UDATE
                  .USER = obj.USER
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new PARTREVUSER(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _PARTREVUSER as PARTREVUSER in value
              If _PARTREVUSER.Equals(trycast(obj,PARTREVUSER)) Then
                  value.remove(_PARTREVUSER)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class PARTREVUSER
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _USERLOGIN As String
        
        Private _IsSetUFLAG As Boolean = Boolean.FalseString
        
        Private _UFLAG As String
        
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
                    return "PARTREVUSER"
                else
                    return "PARTREVUSER_SUBFORM"
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
        
        <DisplayName("Name of Authoriser"),  _
         nType("Edm.String"),  _
         tab("Name of Authoriser"),  _
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
        
        <DisplayName("Authorise"),  _
         nType("Edm.String"),  _
         tab("Name of Authoriser"),  _
         Pos(40),  _
         twodBarcode("UFLAG")>  _
        Public Property UFLAG() As String
            Get
                return _UFLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Authorise", value, "^.{0,1}$") then Exit Property
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
        
        <DisplayName("Date of Authorisatn"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Name of Authoriser"),  _
         Pos(50),  _
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
         tab("Name of Authoriser"),  _
         Pos(30),  _
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
                .WriteAttributeString("name", "PARTREVUSER")
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
                dim obj as PARTREVUSER = JsonConvert.DeserializeObject(Of PARTREVUSER)(e.StreamReader.ReadToEnd)
                With obj
                  _USERLOGIN = .USERLOGIN
                  _UFLAG = .UFLAG
                  _UDATE = .UDATE
                  _USER = .USER
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Documents for Part")>  _
    Public Class QUERY_ECOPARTEXTFILE
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of ECOPARTEXTFILE)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of ECOPARTEXTFILE)
            _Parent = nothing
            _Name = "ECOPARTEXTFILE"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            .add(0, "Links to File")
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of ECOPARTEXTFILE)
            _Parent = Parent
            _name = "ECOPARTEXTFILE_SUBFORM"
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
        
        Public Property Value() As list(of ECOPARTEXTFILE)
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
                return GetType(ECOPARTEXTFILE)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _ECOPARTEXTFILE As ECOPARTEXTFILE In JsonConvert.DeserializeObject(Of QUERY_ECOPARTEXTFILE)(stream.ReadToEnd).Value
              With _ECOPARTEXTFILE
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_ECOPARTEXTFILE)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ECOPARTEXTFILE = JsonConvert.DeserializeObject(Of ECOPARTEXTFILE)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, ECOPARTEXTFILE)
                  .EXTFILEDES = obj.EXTFILEDES
                  .CURDATE = obj.CURDATE
                  .EXTFILENAME = obj.EXTFILENAME
                  .NUMBER = obj.NUMBER
                  .SUFFIX = obj.SUFFIX
                  .EXTFILETYPECODE = obj.EXTFILETYPECODE
                  .EXTFILETYPEDES = obj.EXTFILETYPEDES
                  .EXTFILEVER = obj.EXTFILEVER
                  .ACTIVEFLAG = obj.ACTIVEFLAG
                  .NOSEND = obj.NOSEND
                  .EXTFILETEXT = obj.EXTFILETEXT
                  .STATUS = obj.STATUS
                  .FILESIZE = obj.FILESIZE
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .LUSERLOGIN = obj.LUSERLOGIN
                  .EXTFILENUM = obj.EXTFILENUM
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new ECOPARTEXTFILE(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _ECOPARTEXTFILE as ECOPARTEXTFILE in value
              If _ECOPARTEXTFILE.Equals(trycast(obj,ECOPARTEXTFILE)) Then
                  value.remove(_ECOPARTEXTFILE)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class ECOPARTEXTFILE
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetEXTFILEDES As Boolean = Boolean.FalseString
        
        Private _EXTFILEDES As String
        
        Private _IsSetCURDATE As Boolean = Boolean.FalseString
        
        Private _CURDATE As System.DateTimeOffset
        
        Private _IsSetEXTFILENAME As Boolean = Boolean.FalseString
        
        Private _EXTFILENAME As String
        
        Private _IsSetNUMBER As Boolean = Boolean.FalseString
        
        Private _NUMBER As String
        
        Private _SUFFIX As String
        
        Private _IsSetEXTFILETYPECODE As Boolean = Boolean.FalseString
        
        Private _EXTFILETYPECODE As String
        
        Private _EXTFILETYPEDES As String
        
        Private _IsSetEXTFILEVER As Boolean = Boolean.FalseString
        
        Private _EXTFILEVER As String
        
        Private _IsSetACTIVEFLAG As Boolean = Boolean.FalseString
        
        Private _ACTIVEFLAG As String
        
        Private _IsSetNOSEND As Boolean = Boolean.FalseString
        
        Private _NOSEND As String
        
        Private _IsSetEXTFILETEXT As Boolean = Boolean.FalseString
        
        Private _EXTFILETEXT As String
        
        Private _IsSetSTATUS As Boolean = Boolean.FalseString
        
        Private _STATUS As String
        
        Private _FILESIZE As Long
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _LUSERLOGIN As String
        
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
                    return "ECOPARTEXTFILE"
                else
                    return "ECOPARTEXTFILE_SUBFORM"
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
         Pos(5),  _
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
         Pos(10),  _
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
         Pos(15),  _
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
        
        <DisplayName("Document Number"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(20),  _
         twodBarcode("NUMBER")>  _
        Public Property NUMBER() As String
            Get
                return _NUMBER
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Document Number", value, "^.{0,6}$") then Exit Property
                _IsSetNUMBER = True
                If loading Then
                  _NUMBER = Value
                Else
                    if not _NUMBER = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("NUMBER", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _NUMBER = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("File Name Extension"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(25),  _
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
        
        <DisplayName("Code-Document Type"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(30),  _
         twodBarcode("EXTFILETYPECODE")>  _
        Public Property EXTFILETYPECODE() As String
            Get
                return _EXTFILETYPECODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Code-Document Type", value, "^.{0,2}$") then Exit Property
                _IsSetEXTFILETYPECODE = True
                If loading Then
                  _EXTFILETYPECODE = Value
                Else
                    if not _EXTFILETYPECODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EXTFILETYPECODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EXTFILETYPECODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Document Type"),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(35),  _
         [ReadOnly](true),  _
         twodBarcode("EXTFILETYPEDES")>  _
        Public Property EXTFILETYPEDES() As String
            Get
                return _EXTFILETYPEDES
            End Get
            Set
                if not(value is nothing) then
                  _EXTFILETYPEDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Version of Doc."),  _
         nType("Edm.String"),  _
         tab("File Name"),  _
         Pos(40),  _
         twodBarcode("EXTFILEVER")>  _
        Public Property EXTFILEVER() As String
            Get
                return _EXTFILEVER
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Version of Doc.", value, "^.{0,4}$") then Exit Property
                _IsSetEXTFILEVER = True
                If loading Then
                  _EXTFILEVER = Value
                Else
                    if not _EXTFILEVER = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EXTFILEVER", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EXTFILEVER = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("In Use?"),  _
         nType("Edm.String"),  _
         tab("In Use?"),  _
         Pos(45),  _
         twodBarcode("ACTIVEFLAG")>  _
        Public Property ACTIVEFLAG() As String
            Get
                return _ACTIVEFLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("In Use?", value, "^.{0,1}$") then Exit Property
                _IsSetACTIVEFLAG = True
                If loading Then
                  _ACTIVEFLAG = Value
                Else
                    if not _ACTIVEFLAG = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("ACTIVEFLAG", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _ACTIVEFLAG = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Don't Send"),  _
         nType("Edm.String"),  _
         tab("In Use?"),  _
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
        
        <DisplayName("Remarks"),  _
         nType("Edm.String"),  _
         tab("In Use?"),  _
         Pos(55),  _
         twodBarcode("EXTFILETEXT")>  _
        Public Property EXTFILETEXT() As String
            Get
                return _EXTFILETEXT
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Remarks", value, "^.{0,10}$") then Exit Property
                _IsSetEXTFILETEXT = True
                If loading Then
                  _EXTFILETEXT = Value
                Else
                    if not _EXTFILETEXT = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("EXTFILETEXT", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _EXTFILETEXT = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("File Status"),  _
         nType("Edm.String"),  _
         tab("In Use?"),  _
         Pos(57),  _
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
         tab("In Use?"),  _
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
         tab("In Use?"),  _
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
        
        <DisplayName("Date Modified"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("In Use?"),  _
         Pos(65),  _
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
         tab("In Use?"),  _
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
        
        <DisplayName("Document No."),  _
         nType("Edm.Int64"),  _
         tab("Document No."),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("EXTFILENUM")>  _
        Public Property EXTFILENUM() As nullable (of int64)
            Get
                return _EXTFILENUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Document No.", value, "^[0-9\-]+$") then Exit Property
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
            if _IsSetNUMBER then
              if f then
                  jw.WriteRaw(", ""NUMBER"": ")
              else
                  jw.WriteRaw("""NUMBER"": ")
                  f = true
              end if
              jw.WriteValue(me.NUMBER)
            end if
            if _IsSetEXTFILETYPECODE then
              if f then
                  jw.WriteRaw(", ""EXTFILETYPECODE"": ")
              else
                  jw.WriteRaw("""EXTFILETYPECODE"": ")
                  f = true
              end if
              jw.WriteValue(me.EXTFILETYPECODE)
            end if
            if _IsSetEXTFILEVER then
              if f then
                  jw.WriteRaw(", ""EXTFILEVER"": ")
              else
                  jw.WriteRaw("""EXTFILEVER"": ")
                  f = true
              end if
              jw.WriteValue(me.EXTFILEVER)
            end if
            if _IsSetACTIVEFLAG then
              if f then
                  jw.WriteRaw(", ""ACTIVEFLAG"": ")
              else
                  jw.WriteRaw("""ACTIVEFLAG"": ")
                  f = true
              end if
              jw.WriteValue(me.ACTIVEFLAG)
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
            if _IsSetEXTFILETEXT then
              if f then
                  jw.WriteRaw(", ""EXTFILETEXT"": ")
              else
                  jw.WriteRaw("""EXTFILETEXT"": ")
                  f = true
              end if
              jw.WriteValue(me.EXTFILETEXT)
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
                .WriteAttributeString("name", "ECOPARTEXTFILE")
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
            if _IsSetNUMBER then
              .WriteStartElement("field")
              .WriteAttributeString("name", "NUMBER")
              .WriteAttributeString("value", me.NUMBER)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "6")
              .WriteEndElement
            end if
            if _IsSetEXTFILETYPECODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EXTFILETYPECODE")
              .WriteAttributeString("value", me.EXTFILETYPECODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "2")
              .WriteEndElement
            end if
            if _IsSetEXTFILEVER then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EXTFILEVER")
              .WriteAttributeString("value", me.EXTFILEVER)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "4")
              .WriteEndElement
            end if
            if _IsSetACTIVEFLAG then
              .WriteStartElement("field")
              .WriteAttributeString("name", "ACTIVEFLAG")
              .WriteAttributeString("value", me.ACTIVEFLAG)
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
            if _IsSetEXTFILETEXT then
              .WriteStartElement("field")
              .WriteAttributeString("name", "EXTFILETEXT")
              .WriteAttributeString("value", me.EXTFILETEXT)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "10")
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
                dim obj as ECOPARTEXTFILE = JsonConvert.DeserializeObject(Of ECOPARTEXTFILE)(e.StreamReader.ReadToEnd)
                With obj
                  _EXTFILEDES = .EXTFILEDES
                  _CURDATE = .CURDATE
                  _EXTFILENAME = .EXTFILENAME
                  _NUMBER = .NUMBER
                  _SUFFIX = .SUFFIX
                  _EXTFILETYPECODE = .EXTFILETYPECODE
                  _EXTFILETYPEDES = .EXTFILETYPEDES
                  _EXTFILEVER = .EXTFILEVER
                  _ACTIVEFLAG = .ACTIVEFLAG
                  _NOSEND = .NOSEND
                  _EXTFILETEXT = .EXTFILETEXT
                  _STATUS = .STATUS
                  _FILESIZE = .FILESIZE
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _LUSERLOGIN = .LUSERLOGIN
                  _EXTFILENUM = .EXTFILENUM
                end with
            End If
        End Sub
    End Class
    
    Public Enum Subform_ECOPARTEXTFILE
        
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
    
    <QueryTitle("Authorise ECO")>  _
    Public Class QUERY_ECOUSER
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of ECOUSER)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of ECOUSER)
            _Parent = nothing
            _Name = "ECOUSER"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of ECOUSER)
            _Parent = Parent
            _name = "ECOUSER_SUBFORM"
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
        
        Public Property Value() As list(of ECOUSER)
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
                return GetType(ECOUSER)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _ECOUSER As ECOUSER In JsonConvert.DeserializeObject(Of QUERY_ECOUSER)(stream.ReadToEnd).Value
              With _ECOUSER
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_ECOUSER)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ECOUSER = JsonConvert.DeserializeObject(Of ECOUSER)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, ECOUSER)
                  .USERLOGIN = obj.USERLOGIN
                  .UFLAG = obj.UFLAG
                  .UDATE = obj.UDATE
                  .REMARK = obj.REMARK
                  .USER = obj.USER
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new ECOUSER(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _ECOUSER as ECOUSER in value
              If _ECOUSER.Equals(trycast(obj,ECOUSER)) Then
                  value.remove(_ECOUSER)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class ECOUSER
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _USERLOGIN As String
        
        Private _IsSetUFLAG As Boolean = Boolean.FalseString
        
        Private _UFLAG As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _IsSetREMARK As Boolean = Boolean.FalseString
        
        Private _REMARK As String
        
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
                    return "ECOUSER"
                else
                    return "ECOUSER_SUBFORM"
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
        
        <DisplayName("User Name"),  _
         nType("Edm.String"),  _
         tab("User Name"),  _
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
        
        <DisplayName("Authorise"),  _
         nType("Edm.String"),  _
         tab("User Name"),  _
         Pos(30),  _
         twodBarcode("UFLAG")>  _
        Public Property UFLAG() As String
            Get
                return _UFLAG
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Authorise", value, "^.{0,1}$") then Exit Property
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
        
        <DisplayName("Authorise Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("User Name"),  _
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
        
        <DisplayName("Remarks"),  _
         nType("Edm.String"),  _
         tab("User Name"),  _
         Pos(50),  _
         twodBarcode("REMARK")>  _
        Public Property REMARK() As String
            Get
                return _REMARK
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Remarks", value, "^.{0,30}$") then Exit Property
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
        
        <DisplayName("User (ID)"),  _
         nType("Edm.Int64"),  _
         tab("User Name"),  _
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
            if _IsSetREMARK then
              if f then
                  jw.WriteRaw(", ""REMARK"": ")
              else
                  jw.WriteRaw("""REMARK"": ")
                  f = true
              end if
              jw.WriteValue(me.REMARK)
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
                .WriteAttributeString("name", "ECOUSER")
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
            if _IsSetREMARK then
              .WriteStartElement("field")
              .WriteAttributeString("name", "REMARK")
              .WriteAttributeString("value", me.REMARK)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "30")
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
                dim obj as ECOUSER = JsonConvert.DeserializeObject(Of ECOUSER)(e.StreamReader.ReadToEnd)
                With obj
                  _USERLOGIN = .USERLOGIN
                  _UFLAG = .UFLAG
                  _UDATE = .UDATE
                  _REMARK = .REMARK
                  _USER = .USER
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Library")>  _
    Public Class QUERY_LIBRARY
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of LIBRARY)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of LIBRARY)
            _Parent = nothing
            _Name = "LIBRARY"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of LIBRARY)
            _Parent = Parent
            _name = "LIBRARY_SUBFORM"
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
        
        Public Property Value() As list(of LIBRARY)
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
                return GetType(LIBRARY)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _LIBRARY As LIBRARY In JsonConvert.DeserializeObject(Of QUERY_LIBRARY)(stream.ReadToEnd).Value
              With _LIBRARY
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_LIBRARY)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as LIBRARY = JsonConvert.DeserializeObject(Of LIBRARY)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, LIBRARY)
                  .BOOKNUM = obj.BOOKNUM
                  .TITLE = obj.TITLE
                  .SUBTITLE = obj.SUBTITLE
                  .EXTFILENAME = obj.EXTFILENAME
                  .STATDES = obj.STATDES
                  .INTERNETFLAG = obj.INTERNETFLAG
                  .USERLOGIN = obj.USERLOGIN
                  .UDATE = obj.UDATE
                  .BOOK = obj.BOOK
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new LIBRARY(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _LIBRARY as LIBRARY in value
              If _LIBRARY.Equals(trycast(obj,LIBRARY)) Then
                  value.remove(_LIBRARY)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class LIBRARY
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetBOOKNUM As Boolean = Boolean.FalseString
        
        Private _BOOKNUM As String
        
        Private _TITLE As String
        
        Private _SUBTITLE As String
        
        Private _EXTFILENAME As String
        
        Private _STATDES As String
        
        Private _INTERNETFLAG As String
        
        Private _USERLOGIN As String
        
        Private _UDATE As System.DateTimeOffset
        
        Private _IsSetBOOK As Boolean = Boolean.FalseString
        
        Private _BOOK As Long
        
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
                    return "LIBRARY"
                else
                    return "LIBRARY_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "BOOK={0}", _
                  string.format("{0}",BOOK) _ 
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
        
        <DisplayName("Internal Number"),  _
         nType("Edm.String"),  _
         tab("Internal Number"),  _
         Pos(10),  _
         Mandatory(true),  _
         twodBarcode("BOOKNUM")>  _
        Public Property BOOKNUM() As String
            Get
                return _BOOKNUM
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Internal Number", value, "^.{0,16}$") then Exit Property
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
        
        <DisplayName("Title"),  _
         nType("Edm.String"),  _
         tab("Internal Number"),  _
         Pos(15),  _
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
        
        <DisplayName("Subtitle"),  _
         nType("Edm.String"),  _
         tab("Internal Number"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         twodBarcode("SUBTITLE")>  _
        Public Property SUBTITLE() As String
            Get
                return _SUBTITLE
            End Get
            Set
                if not(value is nothing) then
                  _SUBTITLE = Value
                end if
            End Set
        End Property
        
        <DisplayName("File Name"),  _
         nType("Edm.String"),  _
         tab("Internal Number"),  _
         Pos(25),  _
         [ReadOnly](true),  _
         twodBarcode("EXTFILENAME")>  _
        Public Property EXTFILENAME() As String
            Get
                return _EXTFILENAME
            End Get
            Set
                if not(value is nothing) then
                  _EXTFILENAME = Value
                end if
            End Set
        End Property
        
        <DisplayName("Status"),  _
         nType("Edm.String"),  _
         tab("Internal Number"),  _
         Pos(27),  _
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
        
        <DisplayName("Display on Web Site?"),  _
         nType("Edm.String"),  _
         tab("Internal Number"),  _
         Pos(28),  _
         [ReadOnly](true),  _
         twodBarcode("INTERNETFLAG")>  _
        Public Property INTERNETFLAG() As String
            Get
                return _INTERNETFLAG
            End Get
            Set
                if not(value is nothing) then
                  _INTERNETFLAG = Value
                end if
            End Set
        End Property
        
        <DisplayName("Signature"),  _
         nType("Edm.String"),  _
         tab("Internal Number"),  _
         Pos(30),  _
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
         tab("Internal Number"),  _
         Pos(60),  _
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
        
        <DisplayName("Publication (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Publication (ID)"),  _
         Pos(30),  _
         Browsable(false),  _
         twodBarcode("BOOK")>  _
        Public Property BOOK() As nullable (of int64)
            Get
                return _BOOK
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Publication (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetBOOK = True
                If loading Then
                  _BOOK = Value
                Else
                    if not _BOOK = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("BOOK", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _BOOK = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetBOOKNUM then
              if f then
                  jw.WriteRaw(", ""BOOKNUM"": ")
              else
                  jw.WriteRaw("""BOOKNUM"": ")
                  f = true
              end if
              jw.WriteValue(me.BOOKNUM)
            end if
            if _IsSetBOOK then
              if f then
                  jw.WriteRaw(", ""BOOK"": ")
              else
                  jw.WriteRaw("""BOOK"": ")
                  f = true
              end if
              jw.WriteValue(me.BOOK)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "LIBRARY")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "BOOK")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetBOOKNUM then
              .WriteStartElement("field")
              .WriteAttributeString("name", "BOOKNUM")
              .WriteAttributeString("value", me.BOOKNUM)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "16")
              .WriteEndElement
            end if
            if _IsSetBOOK then
              .WriteStartElement("field")
              .WriteAttributeString("name", "BOOK")
              .WriteAttributeString("value", me.BOOK)
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
                dim obj as LIBRARY = JsonConvert.DeserializeObject(Of LIBRARY)(e.StreamReader.ReadToEnd)
                With obj
                  _BOOKNUM = .BOOKNUM
                  _TITLE = .TITLE
                  _SUBTITLE = .SUBTITLE
                  _EXTFILENAME = .EXTFILENAME
                  _STATDES = .STATDES
                  _INTERNETFLAG = .INTERNETFLAG
                  _USERLOGIN = .USERLOGIN
                  _UDATE = .UDATE
                  _BOOK = .BOOK
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
    
    <QueryTitle("Implications for the ECO")>  _
    Public Class QUERY_ECOIMPLICATIONS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of ECOIMPLICATIONS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of ECOIMPLICATIONS)
            _Parent = nothing
            _Name = "ECOIMPLICATIONS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of ECOIMPLICATIONS)
            _Parent = Parent
            _name = "ECOIMPLICATIONS_SUBFORM"
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
        
        Public Property Value() As list(of ECOIMPLICATIONS)
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
                return GetType(ECOIMPLICATIONS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _ECOIMPLICATIONS As ECOIMPLICATIONS In JsonConvert.DeserializeObject(Of QUERY_ECOIMPLICATIONS)(stream.ReadToEnd).Value
              With _ECOIMPLICATIONS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_ECOIMPLICATIONS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ECOIMPLICATIONS = JsonConvert.DeserializeObject(Of ECOIMPLICATIONS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, ECOIMPLICATIONS)
                  .IMPLICATIONCODE = obj.IMPLICATIONCODE
                  .IMPLICATIONDES = obj.IMPLICATIONDES
                  .IMPLICATION = obj.IMPLICATION
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new ECOIMPLICATIONS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _ECOIMPLICATIONS as ECOIMPLICATIONS in value
              If _ECOIMPLICATIONS.Equals(trycast(obj,ECOIMPLICATIONS)) Then
                  value.remove(_ECOIMPLICATIONS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class ECOIMPLICATIONS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _IsSetIMPLICATIONCODE As Boolean = Boolean.FalseString
        
        Private _IMPLICATIONCODE As String
        
        Private _IMPLICATIONDES As String
        
        Private _IsSetIMPLICATION As Boolean = Boolean.FalseString
        
        Private _IMPLICATION As Long
        
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
                    return "ECOIMPLICATIONS"
                else
                    return "ECOIMPLICATIONS_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "IMPLICATION={0}", _
                  string.format("{0}",IMPLICATION) _ 
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
        
        <DisplayName("Implication Code"),  _
         nType("Edm.String"),  _
         tab("Implication Code"),  _
         Pos(5),  _
         twodBarcode("IMPLICATIONCODE")>  _
        Public Property IMPLICATIONCODE() As String
            Get
                return _IMPLICATIONCODE
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Implication Code", value, "^.{0,3}$") then Exit Property
                _IsSetIMPLICATIONCODE = True
                If loading Then
                  _IMPLICATIONCODE = Value
                Else
                    if not _IMPLICATIONCODE = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("IMPLICATIONCODE", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _IMPLICATIONCODE = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        <DisplayName("Implication"),  _
         nType("Edm.String"),  _
         tab("Implication Code"),  _
         Pos(10),  _
         [ReadOnly](true),  _
         twodBarcode("IMPLICATIONDES")>  _
        Public Property IMPLICATIONDES() As String
            Get
                return _IMPLICATIONDES
            End Get
            Set
                if not(value is nothing) then
                  _IMPLICATIONDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Implication (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Implication Code"),  _
         Pos(99),  _
         Browsable(false),  _
         twodBarcode("IMPLICATION")>  _
        Public Property IMPLICATION() As nullable (of int64)
            Get
                return _IMPLICATION
            End Get
            Set
                if value is nothing then Exit Property
                if not mybase.validate("Implication (ID)", value, "^[0-9\-]+$") then Exit Property
                _IsSetIMPLICATION = True
                If loading Then
                  _IMPLICATION = Value
                Else
                    if not _IMPLICATION = value then
                        Connection.RaiseStartData()
                        loading = true
                        Dim cn As New oDataPUT(Me, PropertyStream("IMPLICATION", Value), AddressOf HandlesEdit)
                        loading = false
                        If Connection.LastError is nothing Then
                            _IMPLICATION = Value
                        End If
                    end if
                end if
            End Set
        End Property
        
        Protected Friend Overrides Sub toJson(ByRef jw As Newtonsoft.Json.JsonTextWriter)
            Dim f as boolean = false
            if _IsSetIMPLICATIONCODE then
              if f then
                  jw.WriteRaw(", ""IMPLICATIONCODE"": ")
              else
                  jw.WriteRaw("""IMPLICATIONCODE"": ")
                  f = true
              end if
              jw.WriteValue(me.IMPLICATIONCODE)
            end if
            if _IsSetIMPLICATION then
              if f then
                  jw.WriteRaw(", ""IMPLICATION"": ")
              else
                  jw.WriteRaw("""IMPLICATION"": ")
                  f = true
              end if
              jw.WriteValue(me.IMPLICATION)
            end if
        End Sub
        
        Protected Friend Overrides Sub toXML(ByRef xw As System.Xml.XmlWriter, ByVal name As String)
            with xw
              .WriteStartElement("form")
              if name is nothing then
                .WriteAttributeString("name", "ECOIMPLICATIONS")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "IMPLICATION")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.Int64")
              .WriteEndElement
            if _IsSetIMPLICATIONCODE then
              .WriteStartElement("field")
              .WriteAttributeString("name", "IMPLICATIONCODE")
              .WriteAttributeString("value", me.IMPLICATIONCODE)
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
            end if
            if _IsSetIMPLICATION then
              .WriteStartElement("field")
              .WriteAttributeString("name", "IMPLICATION")
              .WriteAttributeString("value", me.IMPLICATION)
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
                dim obj as ECOIMPLICATIONS = JsonConvert.DeserializeObject(Of ECOIMPLICATIONS)(e.StreamReader.ReadToEnd)
                With obj
                  _IMPLICATIONCODE = .IMPLICATIONCODE
                  _IMPLICATIONDES = .IMPLICATIONDES
                  _IMPLICATION = .IMPLICATION
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
    
    <QueryTitle("Related Work Orders")>  _
    Public Class QUERY_ECOSERIAL
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of ECOSERIAL)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of ECOSERIAL)
            _Parent = nothing
            _Name = "ECOSERIAL"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of ECOSERIAL)
            _Parent = Parent
            _name = "ECOSERIAL_SUBFORM"
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
        
        Public Property Value() As list(of ECOSERIAL)
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
                return GetType(ECOSERIAL)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _ECOSERIAL As ECOSERIAL In JsonConvert.DeserializeObject(Of QUERY_ECOSERIAL)(stream.ReadToEnd).Value
              With _ECOSERIAL
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_ECOSERIAL)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ECOSERIAL = JsonConvert.DeserializeObject(Of ECOSERIAL)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, ECOSERIAL)
                  .SERIALNAME = obj.SERIALNAME
                  .PARTNAME = obj.PARTNAME
                  .PARTDES = obj.PARTDES
                  .REVNAME = obj.REVNAME
                  .REVNUM = obj.REVNUM
                  .QUANT = obj.QUANT
                  .UNITNAME = obj.UNITNAME
                  .PSDATE = obj.PSDATE
                  .SERIAL = obj.SERIAL
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new ECOSERIAL(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _ECOSERIAL as ECOSERIAL in value
              If _ECOSERIAL.Equals(trycast(obj,ECOSERIAL)) Then
                  value.remove(_ECOSERIAL)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class ECOSERIAL
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _SERIALNAME As String
        
        Private _PARTNAME As String
        
        Private _PARTDES As String
        
        Private _REVNAME As String
        
        Private _REVNUM As String
        
        Private _QUANT As Decimal
        
        Private _UNITNAME As String
        
        Private _PSDATE As System.DateTimeOffset
        
        Private _SERIAL As Long
        
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
                    return "ECOSERIAL"
                else
                    return "ECOSERIAL_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "SERIAL={0}", _
                  string.format("{0}",SERIAL) _ 
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
        
        <DisplayName("Part Number"),  _
         nType("Edm.String"),  _
         tab("Work Order"),  _
         Pos(20),  _
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
         tab("Work Order"),  _
         Pos(30),  _
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
        
        <DisplayName("Part Revision No."),  _
         nType("Edm.String"),  _
         tab("Work Order"),  _
         Pos(40),  _
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
         tab("Work Order"),  _
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
        
        <DisplayName("Work Order Quantity"),  _
         nType("Edm.Decimal"),  _
         Scale(3),  _
         Precision(17),  _
         tab("Work Order"),  _
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
        
        <DisplayName("Unit"),  _
         nType("Edm.String"),  _
         tab("Work Order"),  _
         Pos(70),  _
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
        
        <DisplayName("Begin Production"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Work Order"),  _
         Pos(80),  _
         [ReadOnly](true),  _
         twodBarcode("PSDATE")>  _
        Public Property PSDATE() As nullable (of DateTimeOffset)
            Get
                return _PSDATE
            End Get
            Set
                if not(value is nothing) then
                  _PSDATE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Work Order (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Work Order (ID)"),  _
         Pos(99),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("SERIAL")>  _
        Public Property SERIAL() As nullable (of int64)
            Get
                return _SERIAL
            End Get
            Set
                if not(value is nothing) then
                  _SERIAL = Value
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
                .WriteAttributeString("name", "ECOSERIAL")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "SERIAL")
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
                dim obj as ECOSERIAL = JsonConvert.DeserializeObject(Of ECOSERIAL)(e.StreamReader.ReadToEnd)
                With obj
                  _SERIALNAME = .SERIALNAME
                  _PARTNAME = .PARTNAME
                  _PARTDES = .PARTDES
                  _REVNAME = .REVNAME
                  _REVNUM = .REVNUM
                  _QUANT = .QUANT
                  _UNITNAME = .UNITNAME
                  _PSDATE = .PSDATE
                  _SERIAL = .SERIAL
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Related Part Revisions")>  _
    Public Class QUERY_ECOPARTREV
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of ECOPARTREV)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of ECOPARTREV)
            _Parent = nothing
            _Name = "ECOPARTREV"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of ECOPARTREV)
            _Parent = Parent
            _name = "ECOPARTREV_SUBFORM"
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
        
        Public Property Value() As list(of ECOPARTREV)
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
                return GetType(ECOPARTREV)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _ECOPARTREV As ECOPARTREV In JsonConvert.DeserializeObject(Of QUERY_ECOPARTREV)(stream.ReadToEnd).Value
              With _ECOPARTREV
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_ECOPARTREV)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ECOPARTREV = JsonConvert.DeserializeObject(Of ECOPARTREV)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, ECOPARTREV)
                  .PARTNAME = obj.PARTNAME
                  .PARTDES = obj.PARTDES
                  .REVNAME = obj.REVNAME
                  .FROMDATE = obj.FROMDATE
                  .CONFIRMED = obj.CONFIRMED
                  .VALID = obj.VALID
                  .INACTIVE = obj.INACTIVE
                  .REV = obj.REV
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new ECOPARTREV(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _ECOPARTREV as ECOPARTREV in value
              If _ECOPARTREV.Equals(trycast(obj,ECOPARTREV)) Then
                  value.remove(_ECOPARTREV)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class ECOPARTREV
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _PARTNAME As String
        
        Private _PARTDES As String
        
        Private _REVNAME As String
        
        Private _FROMDATE As System.DateTimeOffset
        
        Private _CONFIRMED As String
        
        Private _VALID As String
        
        Private _INACTIVE As String
        
        Private _REV As Long
        
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
                    return "ECOPARTREV"
                else
                    return "ECOPARTREV_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "REV={0}", _
                  string.format("{0}",REV) _ 
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
        
        <DisplayName("Part Revision No."),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(30),  _
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
        
        <DisplayName("Use From"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Part Number"),  _
         Pos(40),  _
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
        
        <DisplayName("Authorised"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(50),  _
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
        
        <DisplayName("In Effect?"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(80),  _
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
        
        <DisplayName("Not in Use"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(82),  _
         [ReadOnly](true),  _
         twodBarcode("INACTIVE")>  _
        Public Property INACTIVE() As String
            Get
                return _INACTIVE
            End Get
            Set
                if not(value is nothing) then
                  _INACTIVE = Value
                end if
            End Set
        End Property
        
        <DisplayName("Revision (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Part Number"),  _
         Pos(20),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("REV")>  _
        Public Property REV() As nullable (of int64)
            Get
                return _REV
            End Get
            Set
                if not(value is nothing) then
                  _REV = Value
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
                .WriteAttributeString("name", "ECOPARTREV")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "REV")
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
                dim obj as ECOPARTREV = JsonConvert.DeserializeObject(Of ECOPARTREV)(e.StreamReader.ReadToEnd)
                With obj
                  _PARTNAME = .PARTNAME
                  _PARTDES = .PARTDES
                  _REVNAME = .REVNAME
                  _FROMDATE = .FROMDATE
                  _CONFIRMED = .CONFIRMED
                  _VALID = .VALID
                  _INACTIVE = .INACTIVE
                  _REV = .REV
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("Related BOM Revisions")>  _
    Public Class QUERY_ECOREVISIONS
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of ECOREVISIONS)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of ECOREVISIONS)
            _Parent = nothing
            _Name = "ECOREVISIONS"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of ECOREVISIONS)
            _Parent = Parent
            _name = "ECOREVISIONS_SUBFORM"
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
        
        Public Property Value() As list(of ECOREVISIONS)
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
                return GetType(ECOREVISIONS)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _ECOREVISIONS As ECOREVISIONS In JsonConvert.DeserializeObject(Of QUERY_ECOREVISIONS)(stream.ReadToEnd).Value
              With _ECOREVISIONS
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_ECOREVISIONS)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ECOREVISIONS = JsonConvert.DeserializeObject(Of ECOREVISIONS)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, ECOREVISIONS)
                  .PARTNAME = obj.PARTNAME
                  .PARTDES = obj.PARTDES
                  .REVNUM = obj.REVNUM
                  .REVDES = obj.REVDES
                  .FROMDATE = obj.FROMDATE
                  .CONFIRMED = obj.CONFIRMED
                  .REV = obj.REV
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new ECOREVISIONS(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _ECOREVISIONS as ECOREVISIONS in value
              If _ECOREVISIONS.Equals(trycast(obj,ECOREVISIONS)) Then
                  value.remove(_ECOREVISIONS)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class ECOREVISIONS
        Inherits oDataObject
        
        Private _Parent As oDataObject
        
        Private _PARTNAME As String
        
        Private _PARTDES As String
        
        Private _REVNUM As String
        
        Private _REVDES As String
        
        Private _FROMDATE As System.DateTimeOffset
        
        Private _CONFIRMED As String
        
        Private _REV As Long
        
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
                    return "ECOREVISIONS"
                else
                    return "ECOREVISIONS_SUBFORM"
                end if
            End Get
        End Property
        
        Public Overrides ReadOnly Property KeyString() As String
            Get
                return string.format( _
                 "REVNUM={0}", _
                  string.format("'{0}'",REVNUM) _ 
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
        
        <DisplayName("BOM Revision Number"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(30),  _
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
        
        <DisplayName("Description"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(40),  _
         [ReadOnly](true),  _
         twodBarcode("REVDES")>  _
        Public Property REVDES() As String
            Get
                return _REVDES
            End Get
            Set
                if not(value is nothing) then
                  _REVDES = Value
                end if
            End Set
        End Property
        
        <DisplayName("Effect Date"),  _
         nType("Edm.DateTimeOffset"),  _
         tab("Part Number"),  _
         Pos(50),  _
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
        
        <DisplayName("Authorised"),  _
         nType("Edm.String"),  _
         tab("Part Number"),  _
         Pos(60),  _
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
        
        <DisplayName("Revision (ID)"),  _
         nType("Edm.Int64"),  _
         tab("Part Number"),  _
         Pos(99),  _
         [ReadOnly](true),  _
         Browsable(false),  _
         twodBarcode("REV")>  _
        Public Property REV() As nullable (of int64)
            Get
                return _REV
            End Get
            Set
                if not(value is nothing) then
                  _REV = Value
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
                .WriteAttributeString("name", "ECOREVISIONS")
              else
                .WriteAttributeString("name", name)
              end if
              .WriteAttributeString("result", 0)
              .WriteStartElement("key")
              .WriteAttributeString("name", "REVNUM")
              .WriteAttributeString("value", "")
              .WriteAttributeString("type", "Edm.String")
              .WriteAttributeString("MaxLength", "3")
              .WriteEndElement
              .WriteEndElement
            end with
        End Sub
        
        Protected Friend Overrides Sub HandlesEdit(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ECOREVISIONS = JsonConvert.DeserializeObject(Of ECOREVISIONS)(e.StreamReader.ReadToEnd)
                With obj
                  _PARTNAME = .PARTNAME
                  _PARTDES = .PARTDES
                  _REVNUM = .REVNUM
                  _REVDES = .REVDES
                  _FROMDATE = .FROMDATE
                  _CONFIRMED = .CONFIRMED
                  _REV = .REV
                end with
            End If
        End Sub
    End Class
    
    <QueryTitle("ECOs - Remarks")>  _
    Public Class QUERY_ECOTEXT
        Inherits oDataQuery
        
        Private _Name As String
        
        Private _Value As list(of ECOTEXT)
        
        Private _Parent As oDataObject
        
        Private _BindingSource As System.Windows.Forms.BindingSource
        
        Public Sub New()
            MyBase.New
            _Value = new list (of ECOTEXT)
            _Parent = nothing
            _Name = "ECOTEXT"
            _BindingSource = new BindingSource
            AddHandler _BindingSource.AddingNew, AddressOf HandlesBeginAdd
            with ChildQuery
            end with
        End Sub
        
        Public Sub New(ByRef Parent As oDataObject)
            MyBase.New
            _Value = new list (of ECOTEXT)
            _Parent = Parent
            _name = "ECOTEXT_SUBFORM"
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
        
        Public Property Value() As list(of ECOTEXT)
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
                return GetType(ECOTEXT)
            End Get
        End Property
        
        Public Overrides ReadOnly Property BindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _BindingSource
            End Get
        End Property
        
        Protected Friend Overrides Sub Deserialise(ByRef Stream As StreamReader)
            _value.clear
            For Each _ECOTEXT As ECOTEXT In JsonConvert.DeserializeObject(Of QUERY_ECOTEXT)(stream.ReadToEnd).Value
              With _ECOTEXT
                  .Parent = Parent
                  .loading = false
              end with
              _value.add(_ECOTEXT)
            next
            _BindingSource.DataSource = _Value
        End Sub
        
        Protected Friend Overrides Sub HandlesAdd(ByVal sender As Object, ByVal e As ResponseEventArgs)
            If Not e.WebException is nothing Then
                Connection.LastError = e.InterfaceException
            Else
                dim obj as ECOTEXT = JsonConvert.DeserializeObject(Of ECOTEXT)(e.StreamReader.ReadToEnd)
                With TryCast(BindingSource.Current, ECOTEXT)
                  .TEXT = obj.TEXT
                  .TEXTLINE = obj.TEXTLINE
                  .loading = false
                end with
            End If
        End Sub
        
        Private Sub HandlesBeginAdd(ByVal sender As Object, ByVal e As ComponentModel.AddingNewEventArgs)
            e.NewObject = new ECOTEXT(me.Parent)
        End Sub
        
        Protected Friend Overrides Sub Remove(ByRef obj As oDataObject)
            for each _ECOTEXT as ECOTEXT in value
              If _ECOTEXT.Equals(trycast(obj,ECOTEXT)) Then
                  value.remove(_ECOTEXT)
                  exit for
              end if
            next
        End Sub
    End Class
    
    Public Class ECOTEXT
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
                    return "ECOTEXT"
                else
                    return "ECOTEXT_SUBFORM"
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
                .WriteAttributeString("name", "ECOTEXT")
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
                dim obj as ECOTEXT = JsonConvert.DeserializeObject(Of ECOTEXT)(e.StreamReader.ReadToEnd)
                With obj
                  _TEXT = .TEXT
                  _TEXTLINE = .TEXTLINE
                end with
            End If
        End Sub
    End Class
End Namespace
