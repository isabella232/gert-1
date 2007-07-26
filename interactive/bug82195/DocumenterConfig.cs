using System.ComponentModel;

public class DocumenterConfig
{
	private ReferencePathCollection _referencePaths;

	public DocumenterConfig ()
	{
		_referencePaths = new ReferencePathCollection ();
	}

	[Category ("(Global)")]
	[Description ("A collection of additional paths to search for reference assemblies.")]
	public ReferencePathCollection ReferencePaths {
		get {
			return _referencePaths;
		}
		set {
			_referencePaths = value;
		}
	}
}
