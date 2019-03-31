Imports System.Runtime.CompilerServices

Module Helper
    <Extension>
    Public Function ToHtmlString(x As XElement, Optional DisableFormatting As Boolean = True) As String
        Dim html
        If DisableFormatting Then
            html = x.ToString(SaveOptions.DisableFormatting)
        Else
            html = x.ToString()
        End If

        html = html.Replace("<vbxml>", "").
            Replace("</vbxml>", "").
            Replace("<VbXml>", "").
            Replace("</VbXml>", "").
            Replace("_vazor_amp_", "&")

        Return html
    End Function

End Module
