Imports System 
Imports System.CodeDom 
Imports System.CodeDom.Compiler 
Imports System.Reflection 

Module Module1
	Public Function CreateAssemblyFromCode(ByVal Code As String) As [Assembly] 
		Dim CDP As CodeDomProvider = New Microsoft.VisualBasic.VBCodeProvider() 
		Dim Compiler As ICodeCompiler = CDP.CreateCompiler() 
		Dim CP As New CompilerParameters() 
		CP.GenerateInMemory = True 
		Dim CR As CompilerResults = Compiler.CompileAssemblyFromSource(CP, Code) 
		If CR.Errors.Count <> 0 Then 
			Return Nothing 
		Else 
			Return CR.CompiledAssembly 
		End If 
	End Function 

	Public Function CreateAssemblyFromFile(ByVal Filename As String) As [Assembly] 
		Dim CDP As CodeDomProvider = New Microsoft.VisualBasic.VBCodeProvider() 
		Dim Compiler As ICodeCompiler = CDP.CreateCompiler() 
		Dim CP As New CompilerParameters() 
		CP.GenerateInMemory = True 
		Dim CR As CompilerResults = Compiler.CompileAssemblyFromFile(CP, Filename) 
		If CR.Errors.Count <> 0 Then 
			Return Nothing 
		Else 
			Return CR.CompiledAssembly 
		End If 
	End Function 

	Sub Main() 
		Dim Code As String = "Namespace aixsoft" & Environment.NewLine & _
			"Public Class Math" & Environment.NewLine & _
			"Public Function Add(ByVal x as Integer, " & _
			"ByVal y as Integer)" & Environment.NewLine & _
			"Return x+y" & Environment.NewLine & _
			"End Function" & Environment.NewLine & _
			"End Class" & Environment.NewLine & _
			"End Namespace" 

		Dim ASM As [Assembly] = CreateAssemblyFromCode(Code) 
		Dim O As Object = ASM.CreateInstance("aixsoft.Math") 
		Dim T As Type = O.GetType() 
		Dim MI As MethodInfo = T.GetMethod("Add") 
		Dim Param(1) As Object 
		Param(0) = 17 
		Param(1) = 25 
		Dim Result As Object = MI.Invoke(O, Param) 
		If Result.ToString = "42" Then
			Environment.Exit (0)
		Else
			Environment.Exit (1)
		End If
	End Sub
End Module
