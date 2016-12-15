Imports System.CodeDom
Imports System.Xml

Public Class FormProperty

#Region "Constructor"
    Private _FormProperty As XmlNode
    Private _EntityName As String

    Sub New(EntityName As String, FormProperty As XmlNode)
        _FormProperty = FormProperty
        _EntityName = EntityName
    End Sub

    Private _Parent As EntityType
    Public Sub setParent(ByRef EntityType As EntityType)
        _Parent = EntityType
    End Sub

#End Region

#Region "XML Properties"

    Public ReadOnly Property MaxLength() As Integer
        Get
            Return _FormProperty.Attributes("MaxLength").Value
        End Get
    End Property

    Public ReadOnly Property Scale() As Integer
        Get
            Return _FormProperty.Attributes("Scale").Value
        End Get
    End Property

    Public ReadOnly Property Precision() As Integer
        Get
            Return _FormProperty.Attributes("Precision").Value
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return _FormProperty.Attributes("Name").Value
        End Get
    End Property

    Public ReadOnly Property nType() As String
        Get
            Return _FormProperty.Attributes("Type").Value
        End Get
    End Property

#End Region

    Private _Key As Boolean
    Public Property Key() As Boolean
        Get
            Return _Key
        End Get
        Set(ByVal value As Boolean)
            _Key = value
        End Set
    End Property

    Public Function IsSetProperty() As CodeMemberField
        Dim IsSet As New CodeMemberField
        With IsSet
            .Name = String.Format("_IsSet{0}", Name)
            .Attributes = MemberAttributes.Private + MemberAttributes.Final
            .Type = New CodeTypeReference(GetType(System.Boolean))
            .InitExpression = New CodeFieldReferenceExpression( _
                New CodeTypeReferenceExpression("System.BOOLEAN"), _
                "FalseString" _
            )

        End With
        Return IsSet
    End Function

    Public Function PrivateCodeMemberProperty() As CodeMemberField
        Dim pmem As New CodeMemberField
        With pmem
            .Name = String.Format("_{0}", Name)
            .Attributes = MemberAttributes.Private + MemberAttributes.Final
            Select Case nType
                Case "Edm.String"
                    .Type = New CodeTypeReference(GetType(System.String))
                Case "Edm.Decimal"
                    .Type = New CodeTypeReference(GetType(System.Decimal))
                Case "Edm.DateTimeOffset"
                    .Type = New CodeTypeReference(GetType(System.DateTimeOffset))
                Case "Edm.Int64"
                    .Type = New CodeTypeReference(GetType(System.Int64))
            End Select
        End With
        Return pmem
    End Function

    Public Function PublicCodeMemberProperty(Optional ByVal tab As String = "main") As CodeMemberProperty
        Dim mymemberproperty As New CodeMemberProperty
        With mymemberproperty

            .Name = Name
            '.Type = New CodeTypeReference(GetType(System.String))
            PropType(mymemberproperty)
            .Attributes = MemberAttributes.Public + MemberAttributes.Final

            With .CustomAttributes
                .Add( _
                    New CodeAttributeDeclaration( _
                        "tab", _
                        New CodeAttributeArgument( _
                            New CodePrimitiveExpression(tab) _
                        ) _
                    ) _
                )
                .Add( _
                    New CodeAttributeDeclaration( _
                        "DisplayName", _
                        New CodeAttributeArgument( _
                            New CodePrimitiveExpression(DisplayName) _
                        ) _
                    ) _
                )
                .Add( _
                    New CodeAttributeDeclaration( _
                        "Pos", _
                        New CodeAttributeArgument( _
                            New CodePrimitiveExpression(Pos) _
                        ) _
                    ) _
                )
                If IsReadOnly() Then
                    .Add( _
                        New CodeAttributeDeclaration( _
                            "[ReadOnly]", _
                            New CodeAttributeArgument( _
                                New CodePrimitiveExpression(IsReadOnly()) _
                            ) _
                        ) _
                    )
                End If

                If IsMandatory() Then
                    .Add( _
                        New CodeAttributeDeclaration( _
                            "Mandatory", _
                            New CodeAttributeArgument( _
                                New CodePrimitiveExpression(True) _
                            ) _
                        ) _
                    )
                End If

                If IsHidden() Then
                    .Add( _
                        New CodeAttributeDeclaration( _
                            "Browsable", _
                            New CodeAttributeArgument( _
                                New CodePrimitiveExpression(False) _
                            ) _
                        ) _
                    )
                End If
            End With
        End With

        Return mymemberproperty
    End Function

    Private Sub PropType(ByRef prop As CodeMemberProperty)
        With prop
            .GetStatements.Add(New CodeSnippetExpression(String.Format("return _{0}", Name)))

            With .SetStatements
                If Not IsReadOnly() Then
                    .Add(Snippet("if not(value is nothing) then"))
                    .Add(Snippet("  try"))
                    Select Case nType
                        Case "Edm.String"
                            prop.Type = New CodeTypeReference(GetType(System.String))
                            .Add(Snippet("      mybase.validate(""{0}"", value, {1})", DisplayName, MaxLength))

                        Case "Edm.Decimal"
                            prop.Type = New CodeTypeReference("nullable(of decimal)")
                            .Add(Snippet("      mybase.validate(""{0}"", value, {1},{2})", DisplayName, Precision, Scale))


                        Case "Edm.DateTimeOffset"
                            prop.Type = New CodeTypeReference("nullable (of DateTimeOffset)")
                            .Add(Snippet("      mybase.validate(""{0}"", value, true)", DisplayName))

                        Case "Edm.Int64"
                            prop.Type = New CodeTypeReference("nullable (of int64)")
                            .Add(Snippet("      mybase.validate(""{0}"", value)", DisplayName))

                    End Select

                    .Add(Snippet("  catch ex as exception"))
                    .Add(Snippet("      Connection.LastError = ex"))
                    .Add(Snippet("      Exit Property"))
                    .Add(Snippet("  end try"))

                    .Add(Snippet("  _IsSet{0} = True", Name))
                    .Add(Snippet("  If loading Then"))
                    .Add(Snippet("    _{0} = Value", Name))
                    .Add(Snippet("  Else"))
                    .Add(Snippet("      if not _{0} = value then", Name))
                    .Add(Snippet("          loading = true"))
                    .Add(Snippet("          Connection.RaiseStartData()"))
                    .Add(Snippet("          Dim cn As New oDataPUT(Me, PropertyStream(""{0}"", Value), AddressOf HandlesEdit)", Name))
                    .Add(Snippet("          loading = false"))
                    .Add(Snippet("          If Connection.LastError is nothing Then"))
                    .Add(Snippet("              _{0} = Value", Name))
                    .Add(Snippet("          End If"))
                    .Add(Snippet("      end if"))
                    .Add(Snippet("  end if"))
                    .Add(Snippet("end if"))

                Else
                    Select Case nType
                        Case "Edm.String"
                            prop.Type = New CodeTypeReference(GetType(System.String))                            

                        Case "Edm.Decimal"
                            prop.Type = New CodeTypeReference("nullable(of decimal)")

                        Case "Edm.DateTimeOffset"
                            prop.Type = New CodeTypeReference("nullable (of DateTimeOffset)")                            

                        Case "Edm.Int64"
                            prop.Type = New CodeTypeReference("nullable (of int64)")                            

                    End Select

                    .Add(Snippet("if not(value is nothing) then"))
                    .Add(Snippet("  _{0} = Value", Name))
                    .Add(Snippet("end if"))

                End If

            End With

        End With

    End Sub

    Public Sub XMLType(ByRef Statements As CodeStatementCollection)
        With Statements
            .Add(Snippet("  .WriteAttributeString(""type"", ""{0}"")", nType))
            Select Case nType
                Case "Edm.String"
                    .Add(Snippet("  .WriteAttributeString(""MaxLength"", ""{0}"")", MaxLength))

                Case "Edm.Decimal"
                    .Add(Snippet("  .WriteAttributeString(""Scale"", ""{0}"")", Scale))
                    .Add(Snippet("  .WriteAttributeString(""Precision"", ""{0}"")", Precision))

                Case Else

            End Select
        End With
    End Sub

    Private Function Snippet(ByVal str As String) As CodeSnippetExpression
        Return New CodeSnippetExpression(str)
    End Function

    Private Function Snippet(ByVal str As String, ByVal ParamArray Args() As String) As CodeSnippetExpression
        Return New CodeSnippetExpression(String.Format(str, Args))
    End Function

    Public Function DisplayName() As String
        Dim tf As XmlNode = ThisColumn()
        If tf Is Nothing Then
            Return Name
        Else
            If tf.Attributes("title").Value.Trim.Length = 0 Then
                Return Name
            Else
                Return tf.Attributes("title").Value
            End If
        End If
    End Function

    Public Function IsReadOnly() As Boolean
        Dim tf As XmlNode = ThisColumn()
        If tf Is Nothing Then
            Return False
        Else
            If Not _Parent.Updatable Then
                Return True
            Else
                Return Not tf.Attributes("readonly") Is Nothing
            End If
        End If
    End Function

    Public Function IsHidden() As Boolean
        Dim tf As XmlNode = ThisColumn()
        If tf Is Nothing Then
            Return False
        Else
            Return Not tf.Attributes("hidden") Is Nothing
        End If
    End Function

    Public Function IsMandatory() As Boolean
        Dim tf As XmlNode = ThisColumn()
        If tf Is Nothing Then
            Return False
        Else
            Return Not tf.Attributes("mandatory") Is Nothing
        End If
    End Function

    Public Function Pos() As Integer
        Dim tf As XmlNode = ThisColumn()
        If tf Is Nothing Then
            Return 0
        Else
            If tf.Attributes("pos") Is Nothing Then
                Return Nothing
            Else
                Return tf.Attributes("pos").Value
            End If
        End If
    End Function

    Private Function ThisColumn() As XmlNode
        Return sharedvar.FormDef.SelectSingleNode( _
            String.Format( _
                "//form[@name='{0}']/column[@name='{1}']", _
                _EntityName, _
                Name _
            ) _
        )
    End Function

End Class
