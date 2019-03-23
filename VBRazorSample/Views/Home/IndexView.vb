Imports Microsoft.AspNetCore.Mvc.ModelBinding
Imports VbRazor

Public Class IndexView
    Implements IRazor

    Dim students As List(Of Student)

    Public Sub New(students As List(Of Student))
        Me.students = students

    End Sub

    Public Property ViewBag As Object Implements IRazor.ViewBag

    Public Property ModelState As ModelStateDictionary Implements IRazor.ModelState

    Public Function RenderView() As XElement Implements IRazor.RenderView
        Dim layout As New LayoutView(Razor(), ViewBag, ModelState)
        Return layout.Razor
    End Function

    Public Function Razor() As XElement Implements IRazor.Razor
        ViewBag.Title = "VB Razor Sample"
        Return _
 <p>
     <h3> Browse Students</h3>
     <p>Select from <%= students.Count() %> students:</p>
     <ul>
         <%= (Iterator Function()
                  For Each std In students
                      Yield <li><%= std.Name %></li>
                  Next
              End Function)() %>
     </ul>
     <script>
        var x = 5;
        document.writeln("students count = <%= students.Count() %>");
    </script>
 </p>

    End Function
End Class
