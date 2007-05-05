using Microsoft.CSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace codegentest
{
	class Program
	{
		static void Main (string[] args)
		{
			CodeGeneratorOptions codeGeneratorOptions = new CodeGeneratorOptions ();
			codeGeneratorOptions.BlankLinesBetweenMembers = true;
			codeGeneratorOptions.BracingStyle = "C";
			codeGeneratorOptions.ElseOnClosing = false;
			codeGeneratorOptions.IndentString = "\t";

			// create the root of our compilation graph
			CodeCompileUnit ccu = new CodeCompileUnit ();

			// prepare the main namespace for the classes to generate
			CodeNamespace cn = new CodeNamespace ("MyNamespace");

			cn.Imports.Add (new CodeNamespaceImport ("System"));
			cn.Imports.Add (new CodeNamespaceImport ("System.Collections.Generic"));
			cn.Imports.Add (new CodeNamespaceImport ("System.Data"));

			// now link our namespace to the root of the compilation unit
			ccu.Namespaces.Add (cn);

			// prepare a test class
			CodeTypeDeclaration testClass = new CodeTypeDeclaration ("MyClass");
			testClass.IsClass = true;

			// prepare a field
			CodeMemberField field = new CodeMemberField (typeof (int?),
														"myField");

			testClass.Members.Add (field);

			cn.Types.Add (testClass);

			// now prepare the writer
			CSharpCodeProvider provider = new CSharpCodeProvider ();

			StreamWriter sw = new StreamWriter ("test-generated.cs");

			provider.GenerateCodeFromCompileUnit (ccu,
												 sw,
												 codeGeneratorOptions);

			sw.Close ();
		}
	}
}
