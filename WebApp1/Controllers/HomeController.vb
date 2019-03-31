﻿Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Threading.Tasks
Imports WebApp1.Models
Imports Microsoft.AspNetCore.Mvc

Namespace Controllers
    Public Class HomeController : Inherits Controller


        Public Function Index() As IActionResult
            Dim html = New IndexView(Students, ViewData).Html
            Return View(New Models.VbXml(html))
        End Function

        Public Function Privacy() As IActionResult
            Return View()
        End Function

        <ResponseCache(Duration:=0, Location:=ResponseCacheLocation.None, NoStore:=True)>
        Public Function [Error]() As IActionResult
            Return View(New ErrorViewModel With {.RequestId = If(Activity.Current?.Id, HttpContext.TraceIdentifier)})
        End Function
    End Class

End Namespace