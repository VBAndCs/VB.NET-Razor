Imports Microsoft.AspNetCore.Mvc.ViewEngines
Imports Microsoft.AspNetCore.Mvc.Rendering
Imports System.IO

Public Class VBRazorView
        Implements IView

        Public Property Path As String Implements IView.Path

    Public Async Function RenderAsync(ByVal context As ViewContext) As Task Implements IView.RenderAsync
        Dim razor = CType(context.ViewData.Model, IRazor)
        razor.ViewBag = context.ViewBag
        razor.ModelState = context.ModelState
        Dim view = Await Task.Run(AddressOf razor.RenderView().ToString).ConfigureAwait(False)
        context.Writer.Write(view)
    End Function


End Class
