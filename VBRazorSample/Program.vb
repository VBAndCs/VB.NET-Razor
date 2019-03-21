Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.Hosting
Imports Microsoft.Extensions.Logging

Module MainModule

End Module

Public Class Program
    Public Shared Sub Main(ByVal args() As String)
        CreateHostBuilder(args).Build().Run()
    End Sub
    Public Shared Function CreateHostBuilder(args() As String) As IHostBuilder
        Return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(
                Sub(webBuilder) webBuilder.UseStartup(Of Startup)())
    End Function
End Class
