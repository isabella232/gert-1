using System;
using System.Text;
using System.IO;

public class gpair_t<LEFT, RIGHT> {
	protected LEFT _left;
	protected RIGHT _right;

	public LEFT name {
		get {
			return _left;
		}
	}
}

public class pair_t : gpair_t<string, string> {
	public pair_t() {
	}
}

namespace litc {
	public class litc_embed_t {
		static int Main(string[] args) {
			pair_t[] pairs = new pair_t[1];
			if (pairs == null)
				return 1;

			pair_t pair = new pair_t();
			string name = pair.name;
			if (name != null)
				return 2;

			return 0;
		}
	}
}

