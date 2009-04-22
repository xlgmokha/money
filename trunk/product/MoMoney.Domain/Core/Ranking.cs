using System.Collections.Generic;

namespace MoMoney.Domain.Core
{
    public interface IRanking<T> : IComparer<T>
    {
        void add(T item);
    }

    public class Ranking<T> : IRanking<T>
    {
        readonly IList<T> ranked_items;

        public Ranking()
        {
            ranked_items = new List<T>();
        }

        public void add(T item)
        {
            ranked_items.Add(item);
        }

        public int Compare(T x, T y)
        {
            var x_ranking = get_ranking_for(x);
            var y_ranking = get_ranking_for(y);
            if (x_ranking.Equals(y_ranking)) return 0;
            return x_ranking < y_ranking ? 1 : -1;
        }

        int get_ranking_for(T item)
        {
            return ranked_items.IndexOf(item) == -1 ? int.MaxValue : ranked_items.IndexOf(item);
        }
    }
}