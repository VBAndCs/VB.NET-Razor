Imports System

Namespace Models

    Public Class ErrorViewModel
        Public Property RequestId() As String

        Public Function ShowRequestId() As Boolean
            Return Not String.IsNullOrEmpty(RequestId)
        End Function
    End Class

End Namespace