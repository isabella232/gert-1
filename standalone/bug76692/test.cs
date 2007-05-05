/// <summary>
/// <see cref="Create" />
/// <see cref="Define" />
/// <see cref="Undefine" />
/// <see cref="Remove" />
/// <see cref="Destroy" />
/// </summary>
public class EntryPoint {
	static void Main () {
	}

	protected void Create (bool test) {
		Define (true);
	}

	private void Define (bool test) {
	}

	protected void Undefine (bool test) {
	}

	protected void Remove () {
	}

	public virtual void Destroy (bool test) {
	}
}
