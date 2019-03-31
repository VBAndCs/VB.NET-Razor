Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.AspNetCore.Mvc.RazorPages
Imports Vazor

Public Class IndexModel : Inherits PageModel

    Public Property Message = "PageModel in C#"

    Public Sub OnGet()

    End Sub

    Public Property VbXml As String
        Get
            ViewData("Title") = "VB Razor Page"
            Return GetVbXml().ToHtmlString()
        End Get

        Private Set(value As String)

        End Set
    End Property

End Class
