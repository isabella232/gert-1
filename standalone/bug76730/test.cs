/// <summary />
public class A {
	static void Main () {
	}

	/// <summary />
	public virtual string Level {
		get { return null; }
	}

	/// <summary />
	public virtual void Test () {
	}
}

/// <summary>
/// <see cref="Level" />
/// <see cref="Test" />
/// </summary>
public class B : A {
	/// <summary />
	public override string Level {
		get { return null; }
	}

	/// <summary />
	public override void Test () {
	}
}
	
