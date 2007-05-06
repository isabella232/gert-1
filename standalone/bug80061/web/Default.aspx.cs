using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mono.Test.Data;

namespace Mono.Test
{
    public partial class _Default : Page
    {
        private TestItemSource m_source = new TestItemSource();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            m_source.Add(new TestItem(1, "Peter", 20));
            m_source.Add(new TestItem(2, "John", 20));
            m_source.Add(new TestItem(3, "Jannie", 20));
        }

        protected void TestDataSource_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            e.ObjectInstance = m_source;
        }
    }
}