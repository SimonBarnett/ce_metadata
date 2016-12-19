Imports System.CodeDom
Imports System.Windows.Forms
Imports System.Xml
Imports Newtonsoft.Json

Public Class EntityType : Inherits Dictionary(Of String, FormProperty)

    Private _Entity As XmlNode
    Sub New(Entity As XmlNode)
        _Entity = Entity
    End Sub

    Public Sub Assert()
        For Each FormProperty As FormProperty In Me.Values
            FormProperty.setParent(Me)
        Next
    End Sub

    Public ReadOnly Property Name As String
        Get
            Return _Entity.Attributes("Name").Value
        End Get
    End Property

    Private _NavigationProperty As New Dictionary(Of String, NavigationProperty)
    Public Property NavigationProperty As Dictionary(Of String, NavigationProperty)
        Get
            Return _NavigationProperty
        End Get
        Set(value As Dictionary(Of String, NavigationProperty))
            _NavigationProperty = value
        End Set
    End Property

    Private Function OverridesEntityName() As CodeMemberProperty
        Dim mymemberproperty As New CodeMemberProperty
        With mymemberproperty
            .Name = "EntityName"
            .Type = New CodeTypeReference(GetType(System.String))
            .Attributes = MemberAttributes.Override + MemberAttributes.FamilyOrAssembly
            .GetStatements.Add(Snippet("if _parent is nothing then"))
            .GetStatements.Add(Snippet("    return ""{0}""", Name))
            .GetStatements.Add(Snippet("else"))
            .GetStatements.Add(Snippet("    return ""{0}_SUBFORM""", Name))
            .GetStatements.Add(Snippet("end if"))
        End With

        Return mymemberproperty
    End Function

    Private Function Cstor2() As CodeMemberMethod
        Dim CodeConstructor As New CodeConstructor
        With CodeConstructor
            .Attributes = MemberAttributes.Public
            SharedConstructor(.Statements)
            Return CodeConstructor
        End With
    End Function

    Private Function Cstor3() As CodeMemberMethod
        Dim CodeConstructor As New CodeConstructor
        With CodeConstructor
            .Attributes = MemberAttributes.Public
            With .Parameters
                .Add(New CodeParameterDeclarationExpression("oDataObject", "Parent"))
            End With
            With .Statements
                .Add(New CodeSnippetExpression("_parent = Parent"))
            End With
            SharedConstructor(.Statements)
            Return CodeConstructor
        End With
    End Function

    Private Sub SharedConstructor(ByRef statement As CodeDom.CodeStatementCollection)
        With statement
            Dim i As Integer = 0
            For Each navigationProperty As NavigationProperty In Me.NavigationProperty.Values
                .Add( _
                    New CodeSnippetExpression( _
                        String.Format( _
                            "ChildQuery.add({0}, new oNavigation(""{1}""))", _
                            i, _
                            navigationProperty.Title, _
                            navigationProperty.Name _
                        ) _
                    ) _
                )
                i += 1
            Next
            For Each navigationProperty As NavigationProperty In Me.NavigationProperty.Values
                .Add( _
                    New CodeSnippetExpression( _
                        String.Format( _
                            "_{0} = new QUERY_{1}(me)", _
                            navigationProperty.Name, _
                            navigationProperty.nType _
                        ) _
                    ) _
                )
            Next

            i = 0
            For Each navigationProperty As NavigationProperty In Me.NavigationProperty.Values

                .Add( _
                    Snippet( _
                        "WITH ChildQuery({0})", _
                        i _
                    ) _
                )

                .Add( _
                    Snippet( _
                        "   .setoDataQuery(_{2})", _
                        i, _
                        navigationProperty.Title, _
                        navigationProperty.Name _
                    ) _
                )

                If Me.NavigationProperty.Values.Count > 0 Then
                    .Add( _
                        Snippet( _
                            "   WITH .oDataQuery.SibligQuery" _
                        ) _
                    )

                    Dim n As Integer = 0
                    For Each navigationProperty2 As NavigationProperty In Me.NavigationProperty.Values
                        .Add( _
                            New CodeSnippetExpression( _
                                String.Format( _
                                    "       .add({0}, new oNavigation(""{2}"", _{1}))", _
                                    n, _
                                    navigationProperty2.Name, _
                                    navigationProperty2.Title _
                                ) _
                            ) _
                        )
                        n += 1
                    Next

                    .Add( _
                        Snippet( _
                            "   end with" _
                        ) _
                    )

                End If

                .Add( _
                    Snippet( _
                        "end with" _
                    ) _
                )
                i += 1
            Next
        End With
    End Sub

    Public Function CodeTypeDeclaration() As CodeTypeDeclaration
        Dim aClass As New CodeTypeDeclaration
        With aClass
            .Name = Name
            .IsClass = True
            .Attributes = MemberAttributes.Public
            .BaseTypes.Add("oDataObject")
            With .Members
                Dim pmem As New CodeMemberField
                With pmem
                    .Name = "_Parent"
                    .Attributes = MemberAttributes.Private
                    .Type = New CodeTypeReference("oDataObject")
                End With
                .Add(pmem)
                .Add(Cstor3)
                .Add(Cstor2)
                '.Add(Cstor)
                .Add(OverridesEntityName)
                .Add(OverridesJson)
                .Add(OverridesXML)
                .Add(OverridesKeyString)
                .Add(OverridesParent)
                .Add(HandlesEdit)
                Dim i As Integer = 0
                Dim tab As String = ""
                For Each FormProperty As FormProperty In Me.Values
                    Select Case i
                        Case 0
                            tab = FormProperty.DisplayName
                            i += 1
                        Case 7
                            i = 0
                        Case Else
                            i += 1
                    End Select
                    If Not FormProperty.IsReadOnly Then
                        .Add(FormProperty.IsSetProperty)
                    End If
                    .Add(FormProperty.PrivateCodeMemberProperty)
                    .Add(FormProperty.PublicCodeMemberProperty(tab))

                Next
                For Each navigationProperty As NavigationProperty In Me.NavigationProperty.Values
                    .Add(navigationProperty.PrivateCodeMemberProperty)
                    .Add(navigationProperty.CodeMemberProperty)
                Next
                'If Me.NavigationProperty.Values.Count > 0 Then
                '    .Add(Me.CodeMemberProperty)
                'End If
            End With

        End With

        Return aClass
    End Function

    Public Function HandlesEdit() As CodeMemberMethod
        Dim p As CodeParameterDeclarationExpression
        Dim ret As New CodeMemberMethod
        With ret
            .Name = "HandlesEdit"
            .Attributes = MemberAttributes.FamilyOrAssembly + MemberAttributes.Override

            p = New CodeParameterDeclarationExpression
            With p
                .Direction = FieldDirection.In
                .Name = "sender"
                .Type = New CodeTypeReference(GetType(System.Object))
            End With
            .Parameters.Add(p)

            p = New CodeParameterDeclarationExpression
            With p
                .Direction = FieldDirection.In
                .Name = "e"
                .Type = New CodeTypeReference("ResponseEventArgs")
            End With
            .Parameters.Add(p)

            With .Statements
                .Add(Snippet("If Not e.WebException is nothing Then"))
                .Add(Snippet("    Connection.LastError = e.InterfaceException"))
                .Add(Snippet("Else"))                
                .Add(Snippet("    dim obj as {0} = JsonConvert.DeserializeObject(Of {0})(e.StreamReader.ReadToEnd)", Name))
                .Add(Snippet("    With obj"))
                For Each FormProperty As FormProperty In Me.Values
                    .Add(Snippet("      _{0} = .{0}", FormProperty.Name))
                Next
                .Add(Snippet("    end with"))
                .Add(Snippet("End If"))

            End With

        End With
        Return ret
    End Function

    Private Function OverridesKeyString() As CodeMemberProperty
        Dim mymemberproperty As New CodeMemberProperty
        With mymemberproperty
            .Name = "KeyString"
            .Type = New CodeTypeReference(GetType(System.String))
            .Attributes = MemberAttributes.Override + MemberAttributes.Public

            Dim val As New Dictionary(Of String, String)
            Dim i As Integer = 0
            For Each FormProperty As FormProperty In Me.Values
                If FormProperty.Key Then
                    val.Add(FormProperty.Name & "={" & i & "}", "")
                    Select Case FormProperty.nType
                        Case "Edm.String"
                            val(FormProperty.Name & "={" & i & "}") = "string.format(""'{0}'""," & FormProperty.Name & ")"

                        Case Else
                            val(FormProperty.Name & "={" & i & "}") = "string.format(""{0}""," & FormProperty.Name & ")"

                    End Select
                    i += 1
                End If
            Next

            i = 0
            Dim str As New Text.StringBuilder
            str.AppendFormat("string.format( _{0}                 """, vbCrLf)
            For Each key As String In val.Keys
                If i > 0 Then str.AppendFormat(",")
                str.AppendFormat("{0}", key)
                i += 1
            Next
            str.Append("""")
            For Each key As String In val.Keys
                str.AppendFormat(", _{1}                  {0}", val(key), vbCrLf)
                i += 1
            Next

            str.AppendFormat(" _ {0}               )", vbCrLf)
            .GetStatements.Add(New CodeSnippetExpression(String.Format("return {0}", str.ToString)))
        End With

        Return mymemberproperty
    End Function

    Private Function OverridesObjectType() As CodeMemberProperty
        Dim mymemberproperty As New CodeMemberProperty
        With mymemberproperty
            .Name = "ObjectType"
            .Type = New CodeTypeReference(GetType(System.Type))
            .Attributes = MemberAttributes.Override + MemberAttributes.Public
            .GetStatements.Add(New CodeSnippetExpression(String.Format("return GetType({0})", Name)))
        End With

        Return mymemberproperty
    End Function

    Private Function OverridesBindingSource() As CodeMemberProperty
        Dim mymemberproperty As New CodeMemberProperty
        With mymemberproperty
            .Name = "BindingSource"
            .Type = New CodeTypeReference(GetType(BindingSource))
            .Attributes = MemberAttributes.Override + MemberAttributes.Public
            .GetStatements.Add(Snippet("Return _BindingSource"))
        End With

        Return mymemberproperty
    End Function

    Public Function QueryClass() As CodeTypeDeclaration
        Dim aClass As New CodeTypeDeclaration
        With aClass
            .Name = String.Format("QUERY_{0}", Name)
            .IsClass = True
            .Attributes = MemberAttributes.Public
            .BaseTypes.Add("oDataQuery")
            PublicProperty("Name", New CodeTypeReference(GetType(System.String)), .Members, MemberAttributes.FamilyOrAssembly + MemberAttributes.Final, New CodeAttributeDeclaration("JsonProperty", New CodeAttributeArgument(New CodePrimitiveExpression("@odata.context"))))
            PublicProperty("Value", New CodeTypeReference(String.Format("list(of {0})", Name)), .Members, MemberAttributes.Public + MemberAttributes.Final)

            With .CustomAttributes
                .Add( _
                    New CodeAttributeDeclaration( _
                        "QueryTitle", _
                        New CodeAttributeArgument( _
                            New CodePrimitiveExpression(Me.Title) _
                        ) _
                    ) _
                )
            End With

            With .Members
                Dim pmem As New CodeMemberField
                With pmem
                    .Name = "_Parent"
                    .Attributes = MemberAttributes.Private
                    .Type = New CodeTypeReference("oDataObject")
                End With
                .Add(pmem)
                .Add(PrivateBindingSourceProperty)
                '.Add(LastResultProperty)
                .Add(OverridesQueryEntityName)
                .Add(OverridesParent)
                .Add(OverridesObjectType)
                .Add(OverridesBindingSource)
                .Add(QueryCstor)
                '.Add(QueryCstor2)
                .Add(QueryCstor3)
                .Add(OverloadsDeserialise)
                '.Add(OverloadsAdd)
                .Add(HandlesAdd)
                .Add(OverloadsRemove)

            End With
        End With
        Return aClass
    End Function

    Public Function PrivateBindingSourceProperty() As CodeMemberField
        Dim pmem As New CodeMemberField
        With pmem
            .Name = "_BindingSource"
            .Attributes = MemberAttributes.Private + MemberAttributes.Final
            .Type = New CodeTypeReference(GetType(BindingSource))
        End With
        Return pmem
    End Function

    'Private Function LastResultProperty() As CodeMemberField
    '    Dim pmem As New CodeMemberField
    '    With pmem
    '        .Name = String.Format("_lastResult", "")
    '        .Attributes = MemberAttributes.Private + MemberAttributes.Final
    '        .Type = New CodeTypeReference(Name)
    '    End With
    '    Return pmem
    'End Function

    Private Function OverridesQueryEntityName() As CodeMemberProperty
        Dim mymemberproperty As New CodeMemberProperty
        With mymemberproperty
            .Name = "EntityName"
            .Type = New CodeTypeReference(GetType(System.String))
            .Attributes = MemberAttributes.Override + MemberAttributes.FamilyOrAssembly
            .GetStatements.Add(Snippet("return _Name"))
        End With

        Return mymemberproperty
    End Function

    Private Function OverridesParent() As CodeMemberProperty
        Dim mymemberproperty As New CodeMemberProperty
        With mymemberproperty
            .Name = "Parent"
            .Type = New CodeTypeReference("oDataObject")
            .Attributes = MemberAttributes.Override + MemberAttributes.Public
            .GetStatements.Add(New CodeSnippetExpression(String.Format("return _Parent", Name)))
            .SetStatements.Add(New CodeSnippetExpression(String.Format("_Parent = value", Name)))
        End With

        Return mymemberproperty
    End Function

    Private Function QueryCstor() As CodeMemberMethod
        Dim CodeConstructor As New CodeConstructor
        With CodeConstructor
            .Attributes = MemberAttributes.Public
            With .Statements
                .Add(Snippet("_Value = new list (of {0})", Name))
                .Add(New CodeSnippetExpression("_Parent = nothing"))
                .Add(New CodeSnippetExpression(String.Format("_Name = ""{0}""", Name)))
                .Add(Snippet("_BindingSource = new BindingSource"))

                Dim i As Integer = 0
                .Add(Snippet("with ChildQuery"))
                For Each navigationProperty As NavigationProperty In Me.NavigationProperty.Values
                    .Add( _
                        Snippet( _
                            ".add({0}, ""{1}"")", _
                            i, _
                            navigationProperty.Title _
                        ) _
                    )
                    i += 1
                Next
                .Add(Snippet("end with"))

            End With

            Return CodeConstructor

        End With
    End Function

    'Private Function QueryCstor2() As CodeMemberMethod
    '    Dim CodeConstructor As New CodeConstructor
    '    With CodeConstructor
    '        .Attributes = MemberAttributes.Public
    '        'With .Parameters
    '        '    .Add(New CodeParameterDeclarationExpression("oDataQuery", "Parent"))
    '        'End With
    '        With .Statements
    '            .Add(Snippet("_Value = new list (of {0})", Name))
    '            '    .Add(New CodeSnippetExpression("_Parent = Parent"))
    '            '    .Add(New CodeSnippetExpression("me.Server = _Parent.Server"))
    '            '    .Add(New CodeSnippetExpression("me.Environment = _Parent.Environment"))
    '        End With

    '        Return CodeConstructor
    '        End With
    'End Function

    Private Function QueryCstor3() As CodeMemberMethod
        Dim CodeConstructor As New CodeConstructor
        With CodeConstructor
            .Attributes = MemberAttributes.Public
            With .Parameters
                Dim p As New CodeParameterDeclarationExpression
                With p
                    .Direction = FieldDirection.Ref
                    .Name = "Parent"
                    .Type = New CodeTypeReference("oDataObject")
                End With
                .Add(p)
            End With
            With .Statements
                .Add(Snippet("_Value = new list (of {0})", Name))
                .Add(New CodeSnippetExpression("_Parent = Parent"))
                .Add(Snippet("_name = ""{0}_SUBFORM""", Name))
                .Add(Snippet("_BindingSource = new BindingSource"))

                Dim i As Integer = 0
                .Add(Snippet("with ChildQuery"))
                For Each navigationProperty As NavigationProperty In Me.NavigationProperty.Values
                    .Add( _
                        Snippet( _
                            ".add({0}, ""{1}"")", _
                            i, _
                            navigationProperty.Title _
                        ) _
                    )
                    i += 1
                Next
                .Add(Snippet("end with"))

                '.Add(Snippet("With SibligQuery"))
                '.Add(Snippet("  For Each k As Integer In _Parent.ChildQuery.Keys"))
                '.Add(Snippet("      .Add( _"))
                '.Add(Snippet("          k, _"))
                '.Add(Snippet("          New oNavigation( _"))
                '.Add(Snippet("              Parent.ChildQuery(k).Name, _"))
                '.Add(Snippet("              Parent.ChildQuery(k).oDataQuery _"))
                '.Add(Snippet("          ) _"))
                '.Add(Snippet("      )"))
                '.Add(Snippet("  Next"))
                '.Add(Snippet("End With"))

            End With

            Return CodeConstructor
        End With
    End Function

    Public Function HandlesAdd() As CodeMemberMethod
        Dim p As CodeParameterDeclarationExpression
        Dim ret As New CodeMemberMethod
        With ret
            .Name = "HandlesAdd"
            .Attributes = MemberAttributes.Override + MemberAttributes.FamilyOrAssembly

            p = New CodeParameterDeclarationExpression
            With p
                .Direction = FieldDirection.In
                .Name = "sender"
                .Type = New CodeTypeReference(GetType(System.Object))
            End With
            .Parameters.Add(p)

            p = New CodeParameterDeclarationExpression
            With p
                .Direction = FieldDirection.In
                .Name = "e"
                .Type = New CodeTypeReference("ResponseEventArgs")
            End With
            .Parameters.Add(p)

            With .Statements
                .Add(Snippet("If Not e.WebException is nothing Then"))
                .Add(Snippet("    Connection.LastError = e.InterfaceException"))                
                .Add(Snippet("Else"))
                .Add(Snippet("    dim obj as {0} = JsonConvert.DeserializeObject(Of {0})(e.StreamReader.ReadToEnd)", Name))
                .Add(Snippet("    With TryCast(BindingSource.Current, {0})", Name))
                .Add(Snippet("      .Parent = Parent"))
                .Add(Snippet("      .loading = false"))
                For Each FormProperty As FormProperty In Me.Values
                    .Add(Snippet("      .{0} = obj.{0}", FormProperty.Name))
                Next
                .Add(Snippet("    end with"))
                .Add(Snippet("End If"))                

            End With

        End With
        Return ret
    End Function

    Public Function OverloadsRemove() As CodeMemberMethod
        Dim ret As New CodeMemberMethod
        With ret
            .Name = "Remove"
            .Attributes = MemberAttributes.Override + MemberAttributes.FamilyOrAssembly
            Dim p As New CodeParameterDeclarationExpression
            With p
                .Direction = FieldDirection.Ref
                .Name = "obj"
                .Type = New CodeTypeReference("oDataObject")
            End With
            .Parameters.Add(p)

            With .Statements
                .Add(Snippet("for each _{0} as {0} in value", Name))
                .Add(Snippet("  If _{0}.Equals(trycast(obj,{0})) Then", Name))
                .Add(Snippet("      value.remove(_{0})", Name))
                .Add(Snippet("      exit for", Name))
                .Add(Snippet("  end if"))
                .Add(Snippet("next"))
            End With

        End With
        Return ret
    End Function

    Public Function OverloadsDeserialise() As CodeMemberMethod
        Dim ret As New CodeMemberMethod
        With ret
            .Name = "Deserialise"
            .Attributes = MemberAttributes.Override + MemberAttributes.FamilyOrAssembly
            Dim p As CodeParameterDeclarationExpression
            p = New CodeParameterDeclarationExpression
            With p
                .Direction = FieldDirection.Ref
                .Name = "Stream"
                .Type = New CodeTypeReference("StreamReader")
            End With
            .Parameters.Add(p)

            With .Statements
                .Add(Snippet("_value.clear"))
                .Add(Snippet("For Each _{0} As {0} In JsonConvert.DeserializeObject(Of QUERY_{0})(stream.ReadToEnd).Value", Name))
                .Add(Snippet("  With _{0}", Name))
                .Add(Snippet("      .Parent = Parent"))
                .Add(Snippet("      .loading = false"))
                .Add(Snippet("  end with"))
                .Add(Snippet("  _value.add(_{0})", Name))
                .Add(Snippet("next"))
                .Add(Snippet("_BindingSource.DataSource = _Value"))
            End With

        End With
        Return ret
    End Function

    Public Function OverridesJson() As CodeMemberMethod
        Dim ret As New CodeMemberMethod
        With ret
            .Name = "toJson"
            .Attributes = MemberAttributes.Override + MemberAttributes.FamilyOrAssembly
            Dim p As New CodeParameterDeclarationExpression
            With p
                .Direction = FieldDirection.Ref
                .Name = "jw"
                .Type = New CodeTypeReference(GetType(JsonTextWriter))
            End With
            .Parameters.Add(p)

            With .Statements
                .Add(Snippet("Dim f as boolean = false"))
                For Each FormProperty As FormProperty In Me.Values
                    If Not FormProperty.IsReadOnly Then
                        .Add(Snippet("if _IsSet{0} then", FormProperty.Name))
                        .Add(Snippet("  if f then"))
                        .Add(Snippet("      jw.WriteRaw("", """"{0}"""": "")", FormProperty.Name))
                        .Add(Snippet("  else"))
                        .Add(Snippet("      jw.WriteRaw(""""""{0}"""": "")", FormProperty.Name))
                        .Add(Snippet("      f = true"))
                        .Add(Snippet("  end if"))
                        .Add(Snippet("  jw.WriteValue(me.{0})", FormProperty.Name))
                        .Add(Snippet("end if"))
                    End If
                Next

                For Each navigationProperty As NavigationProperty In Me.NavigationProperty.Values
                    .Add(Snippet("if _{0}.value.count > 0 then", navigationProperty.Name))
                    .Add(Snippet("  jw.WriteRaw("", {0}: "")", navigationProperty.Name))
                    .Add(Snippet("  jw.WriteRaw(""[ "")", ""))

                    .Add(Snippet("  dim i as integer = 0"))
                    .Add(Snippet("  for each itm as {0} in _{1}.value", navigationProperty.nType, navigationProperty.Name))

                    .Add(Snippet("    jw.WriteRaw(""{ "")"))
                    .Add(Snippet("    itm.tojson(jw)"))
                    .Add(Snippet("    jw.WriteRaw("" }"")"))
                    .Add(Snippet("    if i < _{0}.value.count - 1 then jw.WriteRaw("", "")", navigationProperty.Name))
                    .Add(Snippet("    i += 1", ""))

                    .Add(Snippet("    next"))

                    .Add(Snippet("  jw.WriteRaw("" ]"")"))
                    .Add(Snippet("end if"))
                Next
            End With
        End With

        Return ret
    End Function

    Public Function OverridesXML() As CodeMemberMethod
        Dim ret As New CodeMemberMethod
        With ret
            .Name = "toXML"
            .Attributes = MemberAttributes.Override + MemberAttributes.FamilyOrAssembly
            Dim p As New CodeParameterDeclarationExpression

            p = New CodeParameterDeclarationExpression
            With p
                .Direction = FieldDirection.Ref
                .Name = "xw"
                .Type = New CodeTypeReference(GetType(XmlWriter))
            End With
            .Parameters.Add(p)

            p = New CodeParameterDeclarationExpression()
            With p
                .Direction = FieldDirection.In
                .Name = "name"
                .Type = New CodeTypeReference(GetType(String))

            End With
            .Parameters.Add(p)

            With .Statements
                .Add(Snippet("with xw"))
                .Add(Snippet("  .WriteStartElement(""form"")"))
                .Add(Snippet("  if name is nothing then"))
                .Add(Snippet("    .WriteAttributeString(""name"", ""{0}"")", Me.Name))
                .Add(Snippet("  else"))
                .Add(Snippet("    .WriteAttributeString(""name"", name)", Me.Name))
                .Add(Snippet("  end if"))
                .Add(Snippet("  .WriteAttributeString(""result"", {0})", "0"))

                For Each FormProperty As FormProperty In Me.Values
                    If FormProperty.Key Then
                        .Add(Snippet("  .WriteStartElement(""key"")"))
                        .Add(Snippet("  .WriteAttributeString(""name"", ""{0}"")", FormProperty.Name))
                        .Add(Snippet("  .WriteAttributeString(""value"", """")", ""))
                        FormProperty.XMLType(ret.Statements)
                        .Add(Snippet("  .WriteEndElement"))
                    End If
                Next

                For Each FormProperty As FormProperty In Me.Values
                    If Not FormProperty.IsReadOnly Then
                        .Add(Snippet("if _IsSet{0} then", FormProperty.Name))
                        .Add(Snippet("  .WriteStartElement(""field"")"))
                        .Add(Snippet("  .WriteAttributeString(""name"", ""{0}"")", FormProperty.Name))
                        .Add(Snippet("  .WriteAttributeString(""value"", me.{0})", FormProperty.Name))
                        FormProperty.XMLType(ret.Statements)

                        .Add(Snippet("  .WriteEndElement"))
                        .Add(Snippet("end if"))
                    End If
                Next

                For Each navigationProperty As NavigationProperty In Me.NavigationProperty.Values
                    .Add(Snippet("if _{0}.value.count > 0 then", navigationProperty.Name))
                    .Add(Snippet("  for each itm as {0} in _{1}.Value", navigationProperty.nType, navigationProperty.Name))
                    .Add(Snippet("    itm.toXML(xw,""{0}"")", navigationProperty.Name))
                    .Add(Snippet("  next"))
                    .Add(Snippet("end if"))
                Next

                .Add(Snippet("  .WriteEndElement"))
                .Add(Snippet("end with"))

            End With
        End With

        Return ret
    End Function

    Public Function EmumSubFormDeclaration() As CodeTypeDeclaration
        Dim aEnum As New CodeTypeDeclaration
        With aEnum
            .Name = String.Format("Subform_{0}", Name)
            .IsClass = False
            .IsEnum = True
            .Attributes = MemberAttributes.Public

            With .Members
                Dim i As Integer = 0
                For Each nav In Me.NavigationProperty.Values
                    .Add(EnumMember(nav.nType, i))
                    i += 1
                Next
            End With

        End With

        Return aEnum
    End Function

    Private Function ThisForm() As XmlNode
        Return sharedvar.FormDef.SelectSingleNode( _
            String.Format( _
                "//form[@name='{0}']", _
                Name.Replace("_SUBFORM", "") _
            ) _
        )
    End Function

    Public ReadOnly Property Title() As String
        Get
            Return ThisForm.Attributes("title").Value
        End Get
    End Property

    Public ReadOnly Property Updatable() As Boolean
        Get
            Return Not String.Compare(ThisForm.Attributes("del").Value, "Q", True) = 0
        End Get
    End Property

    'Public Function CodeMemberProperty() As CodeMemberProperty
    '    Dim mymemberproperty As New CodeMemberProperty
    '    With mymemberproperty
    '        .Name = "Subforms"
    '        .Attributes = MemberAttributes.Public
    '        .Type = New CodeTypeReference("Object")
    '        Dim p As New CodeParameterDeclarationExpression
    '        With p
    '            .Name = "e"
    '            .Type = New CodeTypeReference(String.Format("Subform_{0}", Name))
    '        End With
    '        .Parameters.Add(p)

    '        With .GetStatements
    '            .Add(Snippet("select case e", Name))
    '            For Each navigationProperty As NavigationProperty In Me.NavigationProperty.Values
    '                .Add(Snippet("case Subform_{0}.{1}", Name, navigationProperty.nType))
    '                .Add(Snippet("return _{0}", navigationProperty.Name))
    '            Next
    '            .Add(Snippet("case else", ""))
    '            .Add(Snippet("Throw new exception(""Unknown Subform."")", ""))
    '            .Add(Snippet("end select", Name))
    '        End With

    '        With .SetStatements
    '            .Add(Snippet("select case e", Name))
    '            For Each navigationProperty As NavigationProperty In Me.NavigationProperty.Values
    '                .Add(Snippet("case Subform_{0}.{1}", Name, navigationProperty.nType))
    '                .Add(Snippet("_{0} = Value", navigationProperty.Name))
    '            Next
    '            .Add(Snippet("case else", ""))
    '            .Add(Snippet("Throw new exception(""Unknown Subform."")", ""))
    '            .Add(Snippet("end select", Name))
    '        End With
    '    End With

    '    Return mymemberproperty
    'End Function

    Private Function EnumMember(ByVal name As String, ByVal id As Integer) As CodeMemberField
        Dim mem As New CodeMemberField
        With mem
            .Name = name
            .Type = New CodeTypeReference(GetType(System.Int32))
            .InitExpression = New CodeSnippetExpression(id)
        End With
        Return mem
    End Function

End Class
