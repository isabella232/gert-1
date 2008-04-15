using System;
using System.Collections;
using System.Collections.Generic;

namespace AspNet.StarterKits.Classifieds.BusinessLogicLayer
{
	public class CategoriesDB : IDisposable
	{

		/// <summary>
		/// InsertCategory
		/// </summary>
		/// <param name="parentCategoryId"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static int InsertCategory(int parentCategoryId, string name)
		{
			int? dbParentCategoryId = parentCategoryId;
			if (parentCategoryId == DefaultValues.CategoryIdMinValue)
				dbParentCategoryId = null;
			return 0;
		}

		public static bool RemoveCategory(int categoryId)
		{
			int result = 0;

			return (result > 0);
		}

		public static CategoriesDataComponent.CategoriesDataTable GetCategoryById(int id)
		{
			return null;
		}

		public static CategoriesDataComponent.CategoriesDataTable GetParentCategoriesById(int categoryId)
		{
			return null;
		}

		public static bool MoveCategory(int categoryId, int newParentCategoryId)
		{
			return true;
		}

		public static void UpdateCategoryName(int categoryId, string newName)
		{
		}

		public CategoriesDB()
		{
		}

		public CategoriesDataComponent.CategoriesDataTable GetCategoriesByParentId(int parentCategroyId)
		{
			return null;
		}

		#region IDisposable Members

		private bool disposedValue; // To detect redundant calls
		// IDisposable
		protected virtual void Dispose(bool disposing)
		{
			if (this.disposedValue != true)
			{
				if (disposing)
				{
					// Free unmanaged resources when explicitly called.
				}
			}
			this.disposedValue = true;
		}

		#endregion

		#region IDisposable Support
		// This code added to implement the disposable pattern.
		public void Dispose()
		{
			// Put cleanup code in Dispose(ByVal disposing As Boolean).
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
