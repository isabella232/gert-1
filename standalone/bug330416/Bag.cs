namespace Mono.Util
{
	public class Bag
	{
		static Bag ()
		{
			_itemCount = 2;
		}

		public static int ItemCount {
			get {
				return _itemCount;
			}
			set {
				_itemCount = value;
			}
		}

		private static int _itemCount;
	}
}
