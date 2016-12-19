Imports System.Xml
Imports System.CodeDom

Module sharedvar
    Public FormDef As New XmlDocument

    Public Function Snippet(ByVal str As String) As CodeSnippetExpression
        Return New CodeSnippetExpression(str)
    End Function

    Public Function Snippet(ByVal str As String, ByVal ParamArray Args() As String) As CodeSnippetExpression
        Return New CodeSnippetExpression(String.Format(str, Args))
    End Function

End Module
