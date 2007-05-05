using System;

public class A {
	[Obsolete()]
	public virtual string Warning {
		get { return ""; }
	}
}

public class B : A {
	[Obsolete()]
	public override string Warning {
		get { return ""; }
	}
}
