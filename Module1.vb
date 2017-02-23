Imports System.IO
Imports System.Text
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.Xml
Imports System.Net
Imports Newtonsoft.Json


Public Module Module1

    Private processedEntities As Dictionary(Of String, EntityType)

    Sub Main(ByVal args As String())

        ' --------- '
        ' Arguments '
        ' --------- '
        Dim arg = New clArg(args)

        Dim formdef As String = String.Empty

        ' Sets each argument with switch
        Try
            With arg.Keys
                '? Displays help
                If .Contains("?") Or .Count = 0 Then

                Else
                    For Each a As String In arg.Keys
                        Select Case a.ToLower
                            Case "fd", "form", "fdef", "f"
                                formdef = arg(a)
                            Case "path", "dir", "d"
                                My.Settings.PATH = arg(a)
                        End Select
                    Next
                End If

                If String.IsNullOrEmpty(formdef) Then
                    Console.WriteLine("No Form Definitions have been supplied!")
                ElseIf String.IsNullOrEmpty(My.Settings.PATH) Then
                    Console.WriteLine("No existing output directory and none supplied!")
                End If

            End With

            Console.WriteLine(formdef & vbCrLf & My.Settings.PATH)

        Catch ex As Exception

        End Try

        'Dim _url = "https://walrus.wonderland.local/odata/Priority/tabula.ini/wlnd/$metadata"
        'Dim requestStream As Stream = Nothing
        'Dim uploadResponse As Net.HttpWebResponse = Nothing

        'Dim uploadRequest As HttpWebRequest = CType(HttpWebRequest.Create(_url), HttpWebRequest)
        'With uploadRequest
        '    .Method = Net.WebRequestMethods.Http.Get
        '    .Proxy = Nothing
        '    .Credentials = New NetworkCredential("load", "123456")
        '    .ServerCertificateValidationCallback = AddressOf hssl
        '    Console.WriteLine("[{0}]ing to: {1}", .Method.ToString.ToUpper, _url)            
        'End With
        'uploadResponse = uploadRequest.GetResponse()

        ' ------------------------------------------------------ '
        ' Defines xmls for the Form Definitions and the Metadata '
        ' ------------------------------------------------------ '

        'Loads the specified xml for the form definitions, currently hardcoded
        sharedvar.FormDef.Load(String.Format("..\..\xml_files\{0}.XML", formdef))


        Dim metadata As New XmlDocument
        metadata.Load("dummymetadata.xml")

        'Dim reader As New StreamReader(uploadResponse.GetResponseStream)
        'With metadata
        '    .LoadXml(reader.ReadToEnd)
        'End With

        'Dim nsmgr As New XmlNamespaceManager(metadata.NameTable)
        'nsmgr.AddNamespace("Priority.OData", "http://docs.oasis-open.org/odata/ns/edm")
        'nsmgr.AddNamespace("edmx", "http://docs.oasis-open.org/odata/ns/edmx")

        ' ------------------------------------------------------------ '
        ' Creates a dictionary of processed entities from the metadata '
        ' ------------------------------------------------------------ '

        processedEntities = New Dictionary(Of String, EntityType)
        Dim root As XmlNode = metadata.DocumentElement
        Dim i As Integer
        Do
            i = 0
            For Each entity As XmlNode In root.SelectNodes("EntityType")
                If String.Compare(entity.Attributes("Name").Value, "ORDERS") = 0 Then
                    Beep()
                End If
                ' Entities that are not "NAME" attributes
                If Not processedEntities.Keys.Contains(entity.Attributes("Name").Value.ToUpper) Then
                    Dim f As Boolean = False

                    ' Iterates through XML nodes that are called NavigationProperty
                    For Each nav As XmlNode In entity.SelectNodes("NavigationProperty")

                        ' Uses XML Node as NavigationProperty
                        Using n As New NavigationProperty(nav)

                            ' If the node has an object assigned to it
                            If Not IsNothing(root.SelectSingleNode(String.Format("EntityType[@Name='{0}']", n.nType))) Then

                                ' If the object type has not already been indexed
                                If Not processedEntities.Keys.Contains(n.nType) Then

                                    f = True
                                    Exit For
                                End If
                            End If
                        End Using
                    Next



                    If Not f And Not processedEntities.Keys.Contains(entity.Attributes("Name").Value.ToUpper) Then

                        processedEntities.Add(entity.Attributes("Name").Value.ToUpper, New EntityType(entity))
                        i += 1
                        Console.WriteLine("{0}", entity.Attributes("Name").Value)
                        For Each Prop As XmlNode In entity.SelectNodes("Property")
                            processedEntities(entity.Attributes("Name").Value.ToUpper).Add(Prop.Attributes("Name").Value, New FormProperty(entity.Attributes("Name").Value, Prop))
                            Console.WriteLine("   {0}", Prop.Attributes("Name").Value)
                        Next
                        For Each Key As XmlNode In entity.SelectNodes("Key/PropertyRef")
                            processedEntities(entity.Attributes("Name").Value.ToUpper)(Key.Attributes("Name").Value).Key = True
                            Console.WriteLine("   Key:{0}", Key.Attributes("Name").Value)
                        Next
                        For Each nav As XmlNode In entity.SelectNodes("NavigationProperty")
                            Using n As New NavigationProperty(nav)
                                If Not IsNothing(root.SelectSingleNode(String.Format("EntityType[@Name='{0}']", n.nType))) Then
                                    If Not processedEntities(entity.Attributes("Name").Value.ToUpper).NavigationProperty.Keys.Contains(nav.Attributes("Name").Value) Then
                                        processedEntities(entity.Attributes("Name").Value.ToUpper).NavigationProperty.Add(nav.Attributes("Name").Value, n)
                                        Console.WriteLine("   nav:{0}", nav.Attributes("Name").Value)
                                    End If
                                End If
                            End Using

                        Next
                    End If

                End If
            Next
        Loop Until i = 0 'processedEntities.Count = root.SelectNodes("EntityType").Count

        For Each entity As EntityType In processedEntities.Values
            ' ------------------------------------------------------------------ '
            ' Create .vb for oData if name attribute matches specified form def. '
            ' ------------------------------------------------------------------ '

            If String.Compare(entity.Name, formdef) = 0 Then
                Dim ns As New CodeNamespace("OData")
                ' Add imports to namespace
                With ns
                    With .Imports
                        .Add(New CodeNamespaceImport("system"))
                        .Add(New CodeNamespaceImport("system.IO"))
                        .Add(New CodeNamespaceImport("system.xml"))
                        .Add(New CodeNamespaceImport("System.Net"))
                        .Add(New CodeNamespaceImport("System.Windows.Forms"))
                        .Add(New CodeNamespaceImport("System.ComponentModel"))
                        .Add(New CodeNamespaceImport("Newtonsoft.Json"))
                    End With
                    BuildNameSpace(ns, entity.Name)
                    '                .Types.Add(entity.CodeTypeDeclaration)
                End With

                Dim VbProvider As New VBCodeProvider()
                ' get a Generator object
                Dim options As New CodeGeneratorOptions()
                Dim wr As New StringWriter
                VbProvider.GenerateCodeFromNamespace(ns, wr, options)

                Dim param As New CompilerParameters(New String() _
                    {"System.dll", _
                    "system.io", _
                    "system.xml", _
                    "System.Net", _
                    "System.ComponentModel", _
                    "System.Windows.Forms", _
                    "Newtonsoft.Json"} _
                )
                With param
                    .GenerateExecutable = False
                    .GenerateInMemory = True
                    .TreatWarningsAsErrors = False
                    .WarningLevel = 4
                End With

                ' -------------------------------------------------- '
                ' Writes the oData to a file location and to console '
                ' -------------------------------------------------- '
                
                Dim fn As String = String.Format(My.Settings.PATH & formdef & ".vb")
                'Dim fn As String = String.Format("C:\Users\Administrator\Documents\Visual Studio 2015\Projects\oData\ceOData\PriorityOData\{0}.vb", entity.Name)
                Console.WriteLine("Writing {0}...", fn)
                Using sw As New StreamWriter(fn)
                    sw.Write(wr.ToString)
                End Using
            End If
        Next
    End Sub

    ' --------------------------------------------------------------- '
    ' Build the namespace for the current entity                      '
    ' Then builds namespaces for sub-entities (function calls itself) '
    ' --------------------------------------------------------------- '
    Function BuildNameSpace(ByRef ns As CodeNamespace, ByVal EntityName As String) As CodeNamespace
        With ns
            If processedEntities.Keys.Contains(EntityName) Then
                processedEntities(EntityName).Assert()
                .Types.Add(processedEntities(EntityName).QueryClass)
                .Types.Add(processedEntities(EntityName).CodeTypeDeclaration)
                If processedEntities(EntityName).NavigationProperty.Values.Count > 0 Then
                    .Types.Add(processedEntities(EntityName).EmumSubFormDeclaration)
                    For Each nav As NavigationProperty In processedEntities(EntityName).NavigationProperty.Values
                        BuildNameSpace(ns, nav.nType)
                    Next
                End If
            End If
        End With
        Return ns
    End Function

    Function hssl(ByVal sender As Object, _
        ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, _
        ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, _
        ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean

        Return True

    End Function

End Module
