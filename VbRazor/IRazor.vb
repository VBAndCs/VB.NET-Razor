
Imports System.Runtime.CompilerServices
Imports Microsoft.AspNetCore.Mvc.ModelBinding

Public Interface IRazor
    Property ViewBag As <Dynamic> Object
    Property ModelState As ModelStateDictionary
    Function Razor() As XElement

    Function RenderView() As XElement
End Interface
