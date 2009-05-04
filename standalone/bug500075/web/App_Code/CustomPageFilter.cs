using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.Compilation;
using System.Globalization;

public class CustomPageFilter : PageParserFilter
{
	public override CompilationMode GetCompilationMode (CompilationMode current)
	{
		return CompilationMode.Auto;
	}

	public override void PreprocessDirective (string directiveName, IDictionary attributes)
	{
		if (directiveName == "page") {
			string inherits = attributes ["inherits"] as string;
			if (inherits == "NoDefault")
				attributes ["inherits"] = "CustomDefaultPage";
		}

		base.PreprocessDirective (directiveName, attributes);
	}

	public override bool ProcessCodeConstruct (CodeConstructType codeType, string code)
	{
		return true;
	}

	public override bool AllowBaseType (Type baseType)
	{
		return true;
	}

	public override bool AllowControl (Type controlType, ControlBuilder builder)
	{
		return true;
	}

	public override bool AllowVirtualReference (string referenceVirtualPath, VirtualReferenceType referenceType)
	{
		return true;
	}

	public override bool AllowCode {
		get { return true; }
	}

	public override int NumberOfControlsAllowed {
		get { return 5; }
	}

	public override int NumberOfDirectDependenciesAllowed {
		get { return 3; }
	}

	public override int TotalNumberOfDependenciesAllowed {
		get { return 5; }
	}
}
