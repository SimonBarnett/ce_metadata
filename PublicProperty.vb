Imports System.CodeDom

Public Module dcom

    Public Sub PublicProperty(Name As String, t As CodeTypeReference, ByRef o As CodeTypeMemberCollection, MemberAttributes As MemberAttributes, Optional CodeAttributeDeclaration As CodeAttributeDeclaration = Nothing)
        With o
            Dim pmem As New CodeMemberField
            With pmem
                .Name = String.Format("_{0}", Name)
                .Attributes = MemberAttributes.Private + MemberAttributes.Final
                .Type = t
            End With
            .Add(pmem)
            Dim mymemberproperty As New CodeMemberProperty
            With mymemberproperty
                .Name = Name
                .Type = t
                .Attributes = MemberAttributes
                If Not IsNothing(CodeAttributeDeclaration) Then
                    .CustomAttributes.Add(CodeAttributeDeclaration)
                End If

                .GetStatements.Add(New CodeSnippetExpression(String.Format("return _{0}", Name)))
                .SetStatements.Add(New CodeSnippetExpression(String.Format("_{0} = value", Name)))
            End With
            .Add(mymemberproperty)
        End With

    End Sub

End Module
