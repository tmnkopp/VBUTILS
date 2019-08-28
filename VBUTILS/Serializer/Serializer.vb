Imports System.IO
Imports System.Text
Imports System.Xml.Serialization
Namespace Serializer
    Module Program
        Public Sub Run()
            Console.Write($"SerializerProgram")

            Dim per As Person = New Person()
            per.ID = 1
            per.Name = "test"

            Dim xml_serializer As New XmlSerializer(GetType(Person))
            Dim stringWriter As New StringWriter
            xml_serializer.Serialize(stringWriter, per)
            Console.Write(stringWriter.ToString())
            stringWriter.Close()
            Console.Read()

        End Sub
    End Module

    <Serializable()>
    Public Class Person
        Property ID As Integer
        Property Name As String
        Public Sub New()

        End Sub
    End Class
End Namespace

