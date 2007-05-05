using System;
using System.Reflection;

class M {
	static int Main () {
		Type x = typeof (Tao.OpenGl.Gl);
		FieldInfo f = x.GetField ("GL_TEXTURE_2D");
		if (f.FieldType != typeof (int))
			return 1;
		if (f.Name != "GL_TEXTURE_2D")
			return 2;
		if ((int) f.GetValue (null) != 3553)
			return 3;
		return 0;
	}
}
