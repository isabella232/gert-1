using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

public class EntryPoint
{
	static int Main (string[] args)
	{
		// Load source XML into an XPathDocument object instance.
		XPathDocument xmldoc = new XPathDocument ("books.xml");
		// Create an XPathNavigator from the XPathDocument.
		XPathNavigator nav = xmldoc.CreateNavigator ();

		// The user-defined functions in this sample implement equivalents of the frequently-used
		// Left(string,length) and Right(string,length) Visual Basic string functions.

		// Compile two XPath query expressions that use the user-defined XPath functions and a user-defined variable.
		// The compilation step only checks the query expression for correct tokenization. It does not 
		// try to resolve or to verify the definition or validity of the function and the variable names
		// that are used in the query expression.
		XPathExpression expr1 = nav.Compile ("myFuncs:left(string(.),$length)");
		XPathExpression expr2 = nav.Compile ("myFuncs:right(string(.),$length)");

		// Create an instance of an XsltArgumentList object.
		XsltArgumentList varList = new XsltArgumentList ();
		// Add the user-defined variable to the XsltArgumentList object,
		// and then supply a value for it.
		varList.AddParam ("length", "", 5);

		// Create an instance of a custom XsltContext object. This object is used to 
		// resolve the references to the user-defined XPath extension functions and the
		// user-defined variable at execution time. 

		// Notice that in the Ctor, you also pass in the XsltArgumentList object 
		// in which the user-defined variable is defined.
		CustomContext cntxt = new CustomContext (new NameTable (), varList);

		// Add a namespace definition for the ns prefix that qualifies the user-defined 
		// function names in the expr1 and expr2 query expressions.
		cntxt.AddNamespace ("myFuncs", "http://myXPathExtensionFunctions");

		// Associate the custom XsltContext object with the two XPathExpression objects
		// whose query expressions use the custom XPath functions and the custom variable.
		expr1.SetContext (cntxt);
		expr2.SetContext (cntxt);

		XPathNodeIterator iter = nav.Select ("/Books/Title");
		if (iter.Count != 2) {
			Console.WriteLine ("#1");
			return 1;
		}

		iter.MoveNext ();
		nav = iter.Current;
		if (nav.Value != "A Brief History of Time") {
			Console.WriteLine ("#2: " + nav.Value);
			return 1;
		}
		if (((string) (nav.Evaluate (expr1))) != "A Bri") {
			Console.WriteLine ("#3: " + nav.Evaluate (expr1));
			return 1;
		}
		if (((string) (nav.Evaluate (expr2))) != " Time") {
			Console.WriteLine ("#4: " + nav.Evaluate (expr2));
			return 1;
		}

		iter.MoveNext ();
		nav = iter.Current;
		if (nav.Value != "Principle Of Relativity") {
			Console.WriteLine ("#5: " + nav.Value);
			return 1;
		}
		if (((string) (nav.Evaluate (expr1))) != "Princ") {
			Console.WriteLine ("#6: " + nav.Evaluate (expr1));
			return 1;
		}
		if (((string) (nav.Evaluate (expr2))) != "ivity") {
			Console.WriteLine ("#7: " + nav.Evaluate (expr2));
			return 1; 
		}
		return 0;
	}

	class CustomContext : System.Xml.Xsl.XsltContext
	{
		// XsltArgumentList to store definitions (names and values) of user-defined variables

		// that can be accessed by XPath query expressions that are evaluated by using an object instance
		// of this class as the XsltContext. 
		private XsltArgumentList m_ArgList;

		// Implement constructors.
		public CustomContext ()
		{
		}

		public CustomContext (NameTable nt, XsltArgumentList args)
			: base (nt)
		{
			m_ArgList = args;
		}

		// Function to resolve references to user-defined XPath extension functions in XPath query 
		// expressions that are evaluated by using an object instance of this class as the XsltContext. 

		// This function creates and returns an instance of the XPathExtensionFunctions custom class 
		// that implements the IXsltContextFunction interface. 
		public override System.Xml.Xsl.IXsltContextFunction ResolveFunction (string prefix, string name, System.Xml.XPath.XPathResultType[] ArgTypes)
		{
			XPathStringExtensionFunctions func = null;
			const int MINARGS = 2, MAXARGS = 2;
			if (name == "left")
				// Create an instance of an XPathStringExtensionObjects class by supplying parameters  
				// that map to the user-defined XPath extension function left(). The Invoke method 
				// of the returned object will be used at run time to execute the left() function.
				func = new XPathStringExtensionFunctions (MINARGS, MAXARGS, XPathResultType.String, null, "left");
			else if (name == "right")
				// Create an instance of an XPathStringExtensionObjects class by supplying parameters 
				// that map to the user defined XPath extension function right(). The Invoke method 
				// of the returned object will be used at run time to execute the right() function.
				func = new XPathStringExtensionFunctions (MINARGS, MAXARGS, XPathResultType.String, null, "right");

			// Return the XPathStringExtensionFunctions object instance.
			return func;
		}

		// Function to resolve references to user-defined XPath extension variables in XPath query.
		public override System.Xml.Xsl.IXsltContextVariable ResolveVariable (string prefix, string name)
		{
			// Create an instance of an XPathExtensionVariable (custom IXsltContextVariable
			//  implementation) object by supplying the name of the user-defined variable to resolve.
			XPathExtensionVariable Var;
			Var = new XPathExtensionVariable (name);

			// Return the XPathExtensionVariable object instance that was created. The Evaluate method of the 
			// returned object will be used at run time to resolve the user-defined variable 
			// that is referenced in the XPath query expression. 
			return Var;
		}

		public override bool PreserveWhitespace (System.Xml.XPath.XPathNavigator node)
		{
			return Convert.ToBoolean (null); // empty implementation, returns false
		}

		public override int CompareDocument (string baseUri, string nextbaseUri)
		{
			return Convert.ToInt32 (null); // empty implementation, returns 0
		}

		public override bool Whitespace
		{
			get
			{
				return true;
			}
		}

		// Returns the XsltArgumentList that contains the user-defined variable definitions (names and values). 
		// This property is accessed by the Evaluate method of the XPathExtensionVariable object instance
		// that the ResolveVariable method of this class returns to resolve references to user-defined variables 
		// in XPath query expressions. 
		public XsltArgumentList ArgList
		{
			get
			{
				return m_ArgList;
			}
		}
	}

	// An object instance of this class is used as an interface
	// to resolve and to execute a specified user-defined function. 
	public class XPathStringExtensionFunctions : System.Xml.Xsl.IXsltContextFunction
	{
		// The data types of the arguments that are passed to the custom XPath extension function
		// that an object instance is used to execute
		private System.Xml.XPath.XPathResultType[] m_ArgTypes;
		// The minimum number of arguments that must be passed to a custom XPath extension function 
		// that an object instance is used to execute
		private int m_MinArgs;
		// The maximum number of arguments that must be passed to a custom XPath extension function 
		// that an object instance is used to execute
		private int m_MaxArgs;
		// The data type of the return value of a custom XPath extension function 
		// that an object instance is used to execute
		private System.Xml.XPath.XPathResultType m_ReturnType;
		// The name of the custom XPath extension function that an object instance is used to execute
		private string FunctionName;

		// Constructor that is used in the ResolveFunction method of the custom XsltContext class (CustomContext) 
		// to create and to return an instance of the IXsltContextFunction object to execute a specified 
		// user-defined XPath extension function at run time.
		public XPathStringExtensionFunctions (int p_minArgs, int p_maxArgs, XPathResultType p_ReturnType, XPathResultType[] p_ArgTypes, string p_FunctionName)
		{
			this.m_MinArgs = p_minArgs;
			this.m_MaxArgs = p_maxArgs;
			this.m_ReturnType = p_ReturnType;
			this.m_ArgTypes = p_ArgTypes;
			this.FunctionName = p_FunctionName;
		}

		// Readonly property methods to access the private fields
		public System.Xml.XPath.XPathResultType[] ArgTypes
		{
			get
			{
				return m_ArgTypes;
			}
		}
		public int Maxargs
		{
			get
			{
				return m_MaxArgs;
			}
		}

		public int Minargs
		{
			get
			{
				return m_MinArgs;
			}
		}

		public System.Xml.XPath.XPathResultType ReturnType
		{
			get
			{
				return m_ReturnType;
			}
		}

		// The two custom XPath extension functions
		private string left (string str, int length)
		{
			return str.Substring (0, length);
		}

		private string right (string str, int length)
		{
			return str.Substring ((str.Length - length), length);
		}

		// Function to execute a specified user-defined XPath extension function at run time
		public object Invoke (System.Xml.Xsl.XsltContext xsltContext, object[] args, System.Xml.XPath.XPathNavigator docContext)
		{
			string str = null;
			if (FunctionName == "left")
				str = left (Convert.ToString (args[0]), Convert.ToInt32 (args[1]));
			else if (FunctionName == "right")
				str = right (Convert.ToString (args[0]), Convert.ToInt32 (args[1]));
			return (object) str;
		}
	}

	// This is the class that implements the System.Xml.Xsl.IXsltContextVariable interface.
	// This class is used to resolve references to user-defined variables in 
	// XPath query expressions at run time. An object instance of this class is created and returned
	// by the overridden ResolveVariable function of the custom XsltContext class (CustomContext).
	public class XPathExtensionVariable : IXsltContextVariable
	{
		// The name of the user-defined variable to resolve
		private string m_VarName;

		// Constructor used in the overridden ResolveVariable function of the custom XsltContext class (CustomContext).
		public XPathExtensionVariable (string VarName)
		{
			m_VarName = VarName;
		}

		// This is the function to return the value of the specified user-defined variable.
		// Uses the GetParam method of the XsltArgumentList property of the current active custom XsltContext
		// object to access and return the value assigned to the specified variable
		public object Evaluate (System.Xml.Xsl.XsltContext xsltContext)
		{
			XsltArgumentList vars = ((CustomContext) xsltContext).ArgList;
			return vars.GetParam (m_VarName, null);
		}

		// Is it a local XSLT variable? Not applicable when you are not using a style sheet.
		public bool IsLocal
		{
			get
			{
				return false;
			}
		}

		// Is it an XSLT parameter? Not applicable when you are not using a style sheet.
		public bool IsParam
		{
			get
			{
				return false;
			}
		}

		// The System.Xml.XPath.XPathResultType of the variable
		public System.Xml.XPath.XPathResultType VariableType
		{
			get
			{
				return XPathResultType.Any;
			}
		}
	}
}
