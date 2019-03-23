Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.AspNetCore.Mvc.ViewEngines
Imports Microsoft.Extensions.Options

Public Class VBRazorMvcViewOptionsSetup
        Implements IConfigureOptions(Of MvcViewOptions)


        Private ReadOnly _VBRazorViewEngine As IViewEngine
        Public Sub New(ByVal VBRazorViewEngine As IViewEngine)
            If VBRazorViewEngine Is Nothing Then
                Throw New ArgumentNullException(NameOf(VBRazorViewEngine))
            End If

            _VBRazorViewEngine = VBRazorViewEngine
        End Sub

        Public Sub Configure(ByVal options As MvcViewOptions) Implements IConfigureOptions(Of MvcViewOptions).Configure
            If options Is Nothing Then
                Throw New ArgumentNullException(NameOf(options))
            End If

            options.ViewEngines.Add(_VBRazorViewEngine)
        End Sub
    End Class
