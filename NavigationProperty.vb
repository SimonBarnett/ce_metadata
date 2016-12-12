Imports System.CodeDom
Imports System.Xml

Public Class NavigationProperty : Implements IDisposable

    Private _NavigationProperty As XmlNode
    Sub New(NavigationProperty As XmlNode)
        _NavigationProperty = NavigationProperty
    End Sub

    Public ReadOnly Property Name As String
        Get
            Return _NavigationProperty.Attributes("Name").Value
        End Get
    End Property

    Public ReadOnly Property Title() As String
        Get
            Return ThisForm.Attributes("title").Value
        End Get
    End Property

    Public ReadOnly Property nType As String
        Get
            Return _NavigationProperty.Attributes("Type").Value.Split(".").Last.Replace(")", "")
        End Get
    End Property

    Public Function CodeMemberProperty() As CodeMemberProperty
        Dim mymemberproperty As New CodeMemberProperty
        With mymemberproperty
            .Name = Name
            .Attributes = MemberAttributes.Public + MemberAttributes.Final
            .CustomAttributes.Add( _
                New CodeAttributeDeclaration( _
                    "JsonIgnore" _
                ) _
            )
            .CustomAttributes.Add( _
                New CodeAttributeDeclaration( _
                    "Browsable", _
                    New CodeAttributeArgument( _
                        New CodePrimitiveExpression(False) _
                    ) _
                ) _
            )

            mymemberproperty.Type = New CodeTypeReference(String.Format("QUERY_{0}", nType))
            .GetStatements.Add(New CodeSnippetExpression(String.Format("return _{0}", Name)))
            .SetStatements.Add(New CodeSnippetExpression(String.Format("_{0} = value", Name)))
        End With

        Return mymemberproperty
    End Function

    Public Function PrivateCodeMemberProperty() As CodeMemberField
        Dim pmem As New CodeMemberField
        With pmem
            .Name = String.Format("_{0}", Name)
            .Attributes = MemberAttributes.Private
            pmem.Type = New CodeTypeReference(String.Format("QUERY_{0}", nType))
        End With
        Return pmem
    End Function

    Private Function ThisForm() As XmlNode
        Return sharedvar.FormDef.SelectSingleNode( _
            String.Format( _
                "//form[@name='{0}']", _
                Name.Replace("_SUBFORM", "") _
            ) _
        )
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
