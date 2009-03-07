using System.Data.Linq;
using System.Linq;

public partial class Product
{
	public int CategoryID;
	public decimal UnitPrice;
}

class Program
{
	static void Main ()
	{
		DataContext context = new DataContext (string.Empty);
		Table<Product> products = context.GetTable<Product> ();
		var categories =
			from p in products
			group p by p.CategoryID into g
			select new {
				CategoryID = g.Key,
				CheapestProducts =
					from p2 in g
					where p2.UnitPrice == g.Min (p3 => p3.UnitPrice)
					select p2
			};
		if (categories == null) {
		}
	}
}
