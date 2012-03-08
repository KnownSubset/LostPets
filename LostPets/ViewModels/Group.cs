using System.Collections;
using System.Collections.Generic;

namespace LostPets {
    public class Group<T> : IEnumerable<T>
    {
        public Group(string name, IEnumerable<T> items)
        {
            Title = name;
            Items = new List<T>(items);
        }

        public string Title { get; set; }

        public IList<T> Items { get; set; }

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        #endregion

        public override bool Equals(object obj)
        {
            var that = obj as Group<T>;

            return (that != null) && (Title.Equals(that.Title));
        }
    }
}