Imports System.IO
Imports System.Text
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.Xml
Imports System.Net
Imports Newtonsoft.Json


Public Module Module1

    Private processedEntities As Dictionary(Of String, EntityType)

    Sub main()
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

        sharedvar.FormDef.Load("formdef.xml")
        Dim metadata As New XmlDocument
        metadata.Load("dummymetadata.xml")

        'Dim reader As New StreamReader(uploadResponse.GetResponseStream)
        'With metadata
        '    .LoadXml(reader.ReadToEnd)
        'End With

        'Dim nsmgr As New XmlNamespaceManager(metadata.NameTable)
        'nsmgr.AddNamespace("Priority.OData", "http://docs.oasis-open.org/odata/ns/edm")
        'nsmgr.AddNamespace("edmx", "http://docs.oasis-open.org/odata/ns/edmx")

        processedEntities = New Dictionary(Of String, EntityType)
        Dim root As XmlNode = metadata.DocumentElement
        Dim i As Integer
        Do
            i = 0
            For Each entity As XmlNode In root.SelectNodes("EntityType")

                If Not processedEntities.Keys.Contains(entity.Attributes("Name").Value.ToUpper) Then

                    Dim f As Boolean = False
                    For Each nav As XmlNode In entity.SelectNodes("NavigationProperty")
                        Using n As New NavigationProperty(nav)
                            If Not IsNothing(root.SelectSingleNode(String.Format("EntityType[@Name='{0}']", n.nType))) Then
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
            If String.Compare(entity.Name, "FAMILY_LOG") = 0 Then                
                Dim ns As New CodeNamespace("OData")
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

                Dim fn As String = String.Format("C:\Users\Administrator\Documents\Visual Studio 2015\Projects\oData\ceOData\PriorityOData\{0}.vb", entity.Name)
                Console.WriteLine("Writing {0}...", fn)
                Using sw As New StreamWriter(fn)
                    sw.Write(wr.ToString)
                End Using
            End If
        Next
    End Sub

    Function BuildNameSpace(ByRef ns As CodeNamespace, ByVal EntityName As String) As CodeNamespace
        With ns
            processedEntities(EntityName).Assert()
            .Types.Add(processedEntities(EntityName).QueryClass)
            .Types.Add(processedEntities(EntityName).CodeTypeDeclaration)
            If processedEntities(EntityName).NavigationProperty.Values.Count > 0 Then
                .Types.Add(processedEntities(EntityName).EmumSubFormDeclaration)
                For Each nav As NavigationProperty In processedEntities(EntityName).NavigationProperty.Values
                    BuildNameSpace(ns, nav.nType)
                Next
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
