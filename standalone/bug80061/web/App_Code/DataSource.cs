using System;
using System.Collections.Generic;

namespace Mono.Test.Data
{
    public class TestItemSource
    {
        private List<TestItem> m_items;

        public TestItemSource()
        {
            m_items = new List<TestItem>();
        }

        public void Add(TestItem item)
        {
            m_items.Add(item);
        }

        public int SelectCount()
        {
            return m_items.Count;
        }

        public List<TestItem> GetAll()
        {
            return m_items;
        }
    }

    [Serializable]
    public class TestItem
    {
        private int m_id;
        private string m_name;
        private int m_age;

        public TestItem()
        {
        }

        public TestItem(int id, string name, int age)
        {
            m_id = id;
            m_name = name;
            m_age = age;
        }

        public int Id
        {
            get { return m_id; }
        }

        public string Name
        {
            get { return m_name; }
        }

        public int Age
        {
            get { return m_age; }
        }
    }
}