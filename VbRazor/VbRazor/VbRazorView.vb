Imports Microsoft.AspNetCore.Mvc.ViewEngines
Imports Microsoft.AspNetCore.Mvc.Rendering
Imports System.IO

Public Class VBRazorView
        Implements IView

        Public Property Path As String Implements IView.Path

        Public Function RenderAsync(ByVal context As ViewContext) As Task Implements IView.RenderAsync
            Dim vbRazor As IVBRazor = context.ViewData.Model
            context.Writer.Write(vbRazor.Razor)
            Return Task.CompletedTask()
        End Function


    End Class
