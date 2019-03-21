Imports System.IO
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.AspNetCore.Mvc.ViewEngines

Public Class VBRazorViewEngine
        Implements IViewEngine

        Public Function GetNormalizedRouteValue(ByVal context As ActionContext, ByVal key As String) As String
            If context Is Nothing Then
                Throw New ArgumentNullException(NameOf(context))
            End If

            If key Is Nothing Then
                Throw New ArgumentNullException(NameOf(key))
            End If

            Dim routeValue As Object
            If Not context.RouteData.Values.TryGetValue(key, routeValue) Then
                Return Nothing
            End If

            Dim normalizedValue As String = Nothing
            Dim value As String
            If context.ActionDescriptor.RouteValues.TryGetValue(key, value) AndAlso (Not String.IsNullOrEmpty(value)) Then
                normalizedValue = value
            End If

            Dim stringRouteValue = routeValue?.ToString()
            Return If(String.Equals(normalizedValue, stringRouteValue, StringComparison.OrdinalIgnoreCase), normalizedValue, stringRouteValue)
        End Function

        Public Function FindView(context As ActionContext, viewName As String, isMainPage As Boolean) As ViewEngineResult Implements IViewEngine.FindView
            Dim controllerName = GetNormalizedRouteValue(context, "controller")
            Dim areaName = GetNormalizedRouteValue(context, "area")

            Dim checkedLocations = New List(Of String)()
            Return ViewEngineResult.Found("Default", New VBRazorView())

        End Function

        Private Function IViewEngine_GetView(executingFilePath As String, viewPath As String, isMainPage As Boolean) As ViewEngineResult Implements IViewEngine.GetView
            Dim applicationRelativePath = PathHelper.GetAbsolutePath(executingFilePath, viewPath)

            If Not PathHelper.IsAbsolutePath(viewPath) Then
                ' Not a path this method can handle.
                Return ViewEngineResult.NotFound(applicationRelativePath, Enumerable.Empty(Of String)())
            End If

            ' ReSharper disable once Mvc.ViewNotResolved
            Return ViewEngineResult.Found("Default", New VBRazorView())

        End Function
    End Class
