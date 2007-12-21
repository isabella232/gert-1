Imports System.Reflection

'Public Interface IBase
'    Sub Test()
'End Interface

'Public Interface IDerived
'    Inherits IBase
'End Interface

'Public MustInherit Class A(Of Type)
'    Implements IBase

'    Sub Test() Implements IBase.Test

'    End Sub
'End Class

'Public Class B
'    Inherits A(Of Object)
'    Implements IDerived

'End Class


Friend MustInherit Class A(Of T)
    Implements IBase

    ' Methods
    Public Sub New()

    End Sub
    Public Overrides Sub Test() Implements IBase.Test

    End Sub
End Class

Friend Class B
    Inherits A(Of Object)

    Implements IDerived

    ' Methods
    Public Sub New()

    End Sub
End Class

Friend Interface IBase
    ' Methods
    Sub Test()
End Interface

Friend Interface IDerived
    Inherits IBase

      End Interface
