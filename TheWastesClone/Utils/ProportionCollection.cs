using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWastesClone.Utils
{
	class ProportionCollection<T> : ICollection<T> where T : Proportion<T>
	{
		public int Count
		{
			get { return items.Count; }
		}
		public bool IsReadOnly
		{
			get { return false; }
		}
		private List<T> items;
		private Random rand;
		private double totalProportion;

		public ProportionCollection()
		{
			items = new List<T>();
			rand = new Random(System.Environment.TickCount);
		}

		public void Add(T item)
		{
			totalProportion += item.Proportion;
			for (int i = 0; i < items.Count; i++)
				items[i].ModifiedProportion = items[i].Proportion / totalProportion;
		}

		public void Clear()
		{
			items.Clear();
			totalProportion = 0;
		}

		public bool Contains(T item)
		{
			return items.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			items.CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return items.GetEnumerator();
		}

		public T PeekNext()
		{
			double rnd = rand.NextDouble();
			List<T> sortedItems = items.OrderByDescending(x => x.ModifiedProportion).ToList();
			foreach (Proportion<T> proportion in sortedItems)
			{
				if (rnd > proportion.ModifiedProportion)
					rnd -= proportion.ModifiedProportion;
				else
					sortedItems.Remove(proportion);
			}
			return sortedItems[rand.Next(0, sortedItems.Count)];
		}

		public bool Remove(T item)
		{
			bool result = items.Remove(item);
			totalProportion -= item.Proportion;
			for (int i = 0; i < items.Count; i++)
				items[i].ModifiedProportion = items[i].Proportion / totalProportion;
			return result;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return items.GetEnumerator();
		}
	}
}
