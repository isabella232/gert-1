using System;
using System.IO;
using System.Reflection.Emit;
using System.Reflection;
using System.Diagnostics.SymbolStore;

namespace BugReport
{
	public interface IFoo
	{
		void Bar ();
	}

	class Program
	{
		const string DocumentPath = "test.cs";

		static int Main (string [] args)
		{
			IFoo foo = EmitFoo ();
			try {
				foo.Bar ();
				return 1;
			} catch (Exception ex) {
#if MONO
				Assert.IsTrue (ex.StackTrace.IndexOf (DocumentPath + ":10") != -1, ex.StackTrace);
#else
				Assert.IsTrue (ex.StackTrace.IndexOf (DocumentPath + ":line 10") != -1, ex.StackTrace);
#endif
				return 0;
			}
		}

		static IFoo EmitFoo ()
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;
			string fname = Path.Combine (currentDomain.BaseDirectory, "bugged.dll");

			AssemblyName name = new AssemblyName ();
			name.Name = Path.GetFileNameWithoutExtension (fname);

			AssemblyBuilder builder = currentDomain.DefineDynamicAssembly (name, AssemblyBuilderAccess.Save, Path.GetDirectoryName (fname), null);
			ModuleBuilder module = builder.DefineDynamicModule (Path.GetFileName (fname), true);
			ISymbolDocumentWriter document = module.DefineDocument (DocumentPath, SymDocumentType.Text, SymLanguageType.CSharp, Guid.Empty);

			TypeBuilder container = module.DefineType ("Container", TypeAttributes.Public | TypeAttributes.Class);

			//TypeBuilder foo = module.DefineType("Foo", TypeAttributes.Public | TypeAttributes.Class, typeof(object));
			TypeBuilder foo = container.DefineNestedType ("Foo", TypeAttributes.NestedPublic | TypeAttributes.Class, typeof (object));
			foo.AddInterfaceImplementation (typeof (IFoo));

			MethodBuilder bar = foo.DefineMethod ("Bar", MethodAttributes.Public | MethodAttributes.Virtual, typeof (void), new Type [0]);
			ILGenerator il = bar.GetILGenerator ();
			il.MarkSequencePoint (document, 10, 0, 11, 0);
			il.ThrowException (typeof (ApplicationException));
			il.Emit (OpCodes.Ret);

			container.CreateType ();
			Type emittedTypeName = foo.CreateType ();

			builder.Save (Path.GetFileName (fname));
			return (IFoo) Activator.CreateInstance (Assembly.LoadFrom (fname).GetType (emittedTypeName.FullName));
		}
	}
}
