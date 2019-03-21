Imports VbRazor

Public Class IndexView
    Implements IVBRazor

    Dim students As List(Of Student)

    Public Sub New(students As List(Of Student))
        Me.students = students
    End Sub

    Public ReadOnly Property Razor As String Implements IVBRazor.Razor
        Get
            Dim x = <html>
                        <h3> Browse Students</h3>
                        <p>Select from <%= students.Count() %> students:</p>
                        <ul>
                            <%= (Iterator Function()
                                     For Each std In students
                                         Yield <li><%= std.Name %></li>
                                     Next
                                 End Function)() %>
                        </ul>
                    </html>
            Return x.ToString()

        End Get
    End Property
End Class
