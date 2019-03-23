This is a working VB.NET ASP.NET MVC Core Razor sample!
I implemented a simple VBRazorViewEngine in the VbRazor project. 
To use VBRazorViewEngine in the web project:
1- Add a reference to VBRazor.dll
2- Added these two statements to the Startup.ConfigureServices method:
```VB.NET
services.AddTransient(Of IConfigureOptions(Of MvcViewOptions), VBRazor.VBRazorMvcViewOptionsSetup)()
services.AddSingleton(Of IViewEngine, VBRazor.VBRazorViewEngine)()
```

3- Creat a Razor Virew  class:
The VBRazor is just a VB class that implements the IVBRazor Interface:
```VB.NET
Public Interface IVBRazor
    ReadOnly Property Razor As String

End Interface
```

The Razor property uses the xml literals to compose the HTML code and returns it as a string.. Example:
```VB.NET
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
```

4- To use the Razor View Class from the Controller:
in the action method, pass an instance of the razor class to the View method, and pass the model data to its constructor:
```VB.NET
Public Function Index() As IActionResult
    Return View(New IndexView(Students))
End Function
```

And that’s all!
If you run the project, you will see the web page that VBRazor composed!.. In this example, it will be as in the image:

![VBRazor](https://user-images.githubusercontent.com/48354902/54750257-bcde8280-4bdf-11e9-9692-a12a989edc15.jpg)


This was really easy, but needs more work, so I hope you start contribute to this project to make it a real productive tool!
The first thing to do, it to create a VB.NET template for ASP.NET MVC Core. I had to create a C# project then convert it to VB!

The second thing to do, is to add intellisense support for html attributes in xml literals in VB!

We need to try more advanced pages with JavaScript and other components. I hope VB team give us the support wee need to make the most of xml literals.

