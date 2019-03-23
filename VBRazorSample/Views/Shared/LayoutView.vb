Imports Microsoft.AspNetCore.Mvc.ModelBinding
Imports VbRazor

Public Class LayoutView
    Implements ILayoutRazor

    Public Sub New(body As XElement, viewBag As Object, modelState As ModelStateDictionary)
        Me.Body = body
        Me.ViewBag = viewBag
        Me.ModelState = modelState
    End Sub

    Public Property Body As XElement Implements ILayoutRazor.Body

    Public Property ViewBag As Object Implements ILayoutRazor.ViewBag

    Public Property ModelState As ModelStateDictionary Implements ILayoutRazor.ModelState

    Function Razor() As XElement Implements IRazor.Razor
        Return _
<html>
    <head>
        <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <title><%= ViewBag.Title %> - WebApplication1</title>

        <environment include="Development">
            <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css"/>
        </environment>
        <environment exclude="Development">
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.min.css"
                asp-fallback-href="~/lib/bootstrap/dist/css/bootstrap.min.css"
                asp-fallback-test-class="sr-only" asp-fallback-test-property="position" asp-fallback-test-value="absolute"
                crossorigin="anonymous"
                integrity="sha256-eSi1q2PG6J7g7ib17yAaWMcrr5GrtohYChqibrV7PBE="/>
        </environment>
        <link rel="stylesheet" href="~/css/site.css"/>
    </head>
    <body>
        <header>
            <nav Class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
                <div Class="container">
                    <a Class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">WebApplication1</a>
                    <button Class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                        <span Class="navbar-toggler-icon"></span>
                    </button>
                    <div Class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
                        <ul Class="navbar-nav flex-grow-1">
                            <li Class="nav-item">
                                <a Class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
                            </li>
                            <li Class="nav-item">
                                <a Class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>
        <div Class="container">
            <partial name="_CookieConsentPartial"/>
            <main role="main" class="pb-3">
                <%= Body %>
            </main>
        </div>

        <footer Class="border-top footer text-muted">
            <div Class="container">
            copy; 2019 - WebApplication1 - <a asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
            </div>
        </footer>

        <environment include="Development">
            <script src="~/lib/jquery/dist/jquery.js"></script>
            <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.js"></script>
        </environment>
        <environment exclude="Development">
            <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"
                asp-fallback-src="~/lib/jquery/dist/jquery.min.js"
                asp-fallback-test="window.jQuery"
                crossorigin="anonymous"
                integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8=">
            </script>
            <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/js/bootstrap.bundle.min.js"
                asp-fallback-src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"
                asp-fallback-test="window.jQuery, window.jQuery.fn,  window.jQuery.fn.modal"
                crossorigin="anonymous"
                integrity="sha256-E/V4cWE4qvAeO5MOhjtGtqDzPndRO1LBk8lJ/PR7CA4=">
            </script>
        </environment>
        <script src="~/js/site.js" asp-append-version="true"></script>

    </body>
</html>

        '  <%= RenderSection("Scripts", required False) %>
    End Function

    Public Function RenderView() As XElement Implements IRazor.RenderView
        Return Razor()
    End Function
End Class
