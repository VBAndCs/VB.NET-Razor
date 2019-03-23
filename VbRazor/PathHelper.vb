
Public NotInheritable Class PathHelper

        Private Sub New()
        End Sub

        Public Shared Function GetAbsolutePath(ByVal executingFilePath As String, ByVal pagePath As String) As String
            ' Path is not valid or a page name; no change required.
            If String.IsNullOrEmpty(pagePath) OrElse (Not IsRelativePath(pagePath)) Then
                Return pagePath
            End If

            If IsAbsolutePath(pagePath) Then
                ' An absolute path already; no change required.
                Return pagePath.Replace("~/", String.Empty)
            End If

            ' Given a relative path i.e. not yet application-relative (starting with "~/" or "/"), interpret
            ' path relative to currently-executing view, if any.
            If String.IsNullOrEmpty(executingFilePath) Then
                ' Not yet executing a view. Start in app root.
                Return $"/{pagePath}"
            End If

            ' Get directory name (including final slash) but do not use Path.GetDirectoryName() to preserve path
            ' normalization.
            Dim index = executingFilePath.LastIndexOf("/"c)
            Return executingFilePath.Substring(0, index + 1) & pagePath
        End Function

        Public Shared Function IsAbsolutePath(name As String) As Boolean
            Return name.StartsWith("~/") OrElse name.StartsWith("/")
        End Function

        ' Though ./ViewName looks like a relative path, framework searches for that view using view locations.
        Public Shared Function IsRelativePath(name As String) As Boolean
            Return Not IsAbsolutePath(name)
        End Function
    End Class
