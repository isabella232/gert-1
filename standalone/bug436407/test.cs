using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticCurrying
{
	class Program
	{
		static void Main (string [] args)
		{
			Func<int, int, int> add = (x, y) => x + y;

			var addCurriedAuto = Curry (add);
			var add10 = addCurriedAuto (10);
			Assert.AreEqual (42, add10 (32), "#1");

			Func<int, string, int> weirdCalc = (val, text) => val * text.Length;
			var weirdCalcCurried = Curry (weirdCalc);
			var weirdCalc3 = weirdCalcCurried (3);
			Assert.AreEqual (6, weirdCalc3 ("Hi"), "#2");

			Func<int, int, int, int> multiplyAndAdd =
				(a, b, c) => a * b + c;

			var curriedMultiplyAndAdd = Curry (multiplyAndAdd);

			Assert.AreEqual (35, multiplyAndAdd (10, 3, 5), "#3");
			Assert.AreEqual (35, curriedMultiplyAndAdd (10) (3) (5), "#4");

			var multiplyBy3AndAdd = curriedMultiplyAndAdd (3);
			Assert.AreEqual (35, multiplyBy3AndAdd (10) (5), "#5");
		}

		static Func<T1, Func<T2, T3>> Curry<T1, T2, T3> (Func<T1, T2, T3> func)
		{
			return par1 => par2 => func (par1, par2);
		}

		static Func<T1, Func<T2, Func<T3, T4>>> Curry<T1, T2, T3, T4> (Func<T1, T2, T3, T4> func)
		{
			return par1 => par2 => par3 => func (par1, par2, par3);
		}

		static Func<T1, Func<T2, Func<T3, Func<T4, T5>>>> Curry<T1, T2, T3, T4, T5> (Func<T1, T2, T3, T4, T5> func)
		{
			return par1 => par2 => par3 => par4 => func (par1, par2, par3, par4);
		}
	}
}
