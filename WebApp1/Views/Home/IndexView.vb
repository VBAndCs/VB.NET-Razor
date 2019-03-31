Imports Microsoft.AspNetCore.Mvc.ViewFeatures

Public Class IndexView
    Dim students As List(Of Student)

    Public Sub New(students As List(Of Student))
        Me.students = students
    End Sub

    Public Sub New(students As List(Of Student), ViewData As ViewDataDictionary)
        Me.students = students
        Me.ViewData = ViewData
    End Sub
    Public Property ViewData As ViewDataDictionary

    Dim _html As String
    Public ReadOnly Property Html As String
        Get
            If _html Is Nothing Then _html = GetVbXml().ToHtmlString()

            Return _html
        End Get
    End Property

End Class
