using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;

namespace EntityPlugin.RWSplitting.Utilities
{
	/// <summary>
	/// 提供一组对 公开泛型枚举数类型 <see cref="System.Collections.Generic.IEnumerable&lt;TSource&gt;"/> 操作方法的扩展。
	/// </summary>
	public static partial class EnumerableExtensions
    {

        /// <summary>
        /// 判断指定的序列对象 <paramref name="_this"/> 是否为 Null 或不包含任何元素。
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="_this">被判断的序列 <see cref="IEnumerable"/> 对象。</param>
        /// <returns>如果序列对象 <paramref name="_this"/> 为 Null 或者不包含任何元素，则返回 true；否则返回 false。</returns>
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> _this)
        {
            return _this == null || _this.Count() == 0;
        }

        /// <summary>
        /// 基于指定的谓词判断指定的序列对象 <paramref name="_this"/> 是否为 Null 或不包含符合谓词条件判断的任何元素。
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="_this">被判断的序列 <see cref="IEnumerable"/> 对象。</param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> _this, Func<TSource, bool> predicate)
        {
            return _this == null || _this.Count(predicate) == 0;
        }

        /// <summary>
        /// 基于指定的谓词判断指定的序列对象 <paramref name="_this"/> 是否为 Null 或不包含符合谓词条件判断的任何元素。
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="_this">被判断的序列 <see cref="IEnumerable"/> 对象。</param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> _this, Func<TSource, int, bool> predicate)
        {
            return _this == null || _this.Count(predicate) == 0;
        }



        /// <summary>
        /// 基于谓词确定序列中的所有元素是否满足条件。将在谓词函数的逻辑中使用每个元素的索引。
        /// </summary>
        /// <typeparam name="TSource"><paramref name="_this"/> 中的元素的类型。</typeparam>
        /// <param name="_this">一个 <see cref="System.Collections.Generic.IEnumerable&lt;TSource&gt;"/>，其元素将应用谓词。</param>
        /// <param name="predicate">用于测试每个源元素是否满足条件的函数；该函数的第二个参数表示源元素的索引。</param>
        /// <returns>如果源序列中的每个元素都通过指定谓词中的测试，或者序列为空，则为 true；否则为 false。</returns>
        public static bool All<TSource>(this IEnumerable<TSource> _this, Func<TSource, int, bool> predicate)
        {
            Check.NotNull(_this);
            TSource[] array = _this.ToArray();
            for (var i = 0; i < array.Length; i++)
            {
                if (!predicate.Invoke(array[i], i))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 基于谓词确定序列中的任何元素是否都满足条件。 将在谓词函数的逻辑中使用每个元素的索引。
        /// </summary>
        /// <typeparam name="TSource"><paramref name="_this"/> 中的元素的类型。</typeparam>
        /// <param name="_this">一个 <see cref="System.Collections.Generic.IEnumerable&lt;TSource&gt;"/>，其元素将应用谓词。</param>
        /// <param name="predicate">用于测试每个源元素是否满足条件的函数；该函数的第二个参数表示源元素的索引。</param>
        /// <returns>如果源序列中的任意一元素通过指定谓词中的测试，则为 true；否则为 false。</returns>
        public static bool Any<TSource>(this IEnumerable<TSource> _this, Func<TSource, int, bool> predicate)
        {
            Check.NotNull(_this);
            TSource[] array = _this.ToArray();
            for (var i = 0; i < array.Length; i++)
            {
                if (predicate.Invoke(array[i], i))
                {
                    return true;
                }
            }
            return false;
        }



        /// <summary>
        /// 将元素合并入泛型序列 <paramref name="_this"/> 中。如果源序列中包含该元素，则不进行合并操作。
        /// </summary>
        /// <typeparam name="TSource"><paramref name="_this"/> 中的元素的类型。</typeparam>
        /// <param name="_this">一个 <see cref="System.Collections.Generic.IEnumerable&lt;TSource&gt;"/> 泛型序列。</param>
        /// <param name="item">要被合并入 <paramref name="_this"/> 序列的元素。</param>
        /// <returns>
        /// 一个新创建的 <see cref="System.Collections.Generic.IEnumerable&lt;TSource&gt;"/> 泛型序列，其包含源序列 <paramref name="_this"/> 的所有项。
        /// 如果 <paramref name="item"/> 元素不包含在 <paramref name="_this"/> 中，则返回的序列中也会包含 <paramref name="item"/> 元素。
        /// </returns>
        public static IEnumerable<TSource> Attach<TSource>(this IEnumerable<TSource> _this, TSource item)
        {
            return _this.Contains(item) ? _this.AsEnumerable() : Append(_this, item);
        }

        /// <summary>
        /// 将元素合并入泛型序列 <paramref name="_this"/> 中。如果源序列中包含该元素，则不进行合并操作。
        /// 以指定的对象相等比较器 <see cref="IEqualityComparer&lt;TSource&gt;"/> 来判断 <paramref name="item"/> 是否包含在 <paramref name="_this"/> 中。
        /// </summary>
        /// <typeparam name="TSource"><paramref name="_this"/> 中的元素的类型。</typeparam>
        /// <param name="_this">一个 <see cref="System.Collections.Generic.IEnumerable&lt;TSource&gt;"/> 泛型序列。</param>
        /// <param name="item">要被合并入 <paramref name="_this"/> 序列的元素。</param>
        /// <param name="comparer">用于判断 <paramref name="item"/> 是否包含在 <paramref name="_this"/> 中的对象相等比较器 <see cref="IEqualityComparer&lt;TSource&gt;"/>。</param>
        /// <returns>
        /// 一个新创建的 <see cref="System.Collections.Generic.IEnumerable&lt;TSource&gt;"/> 泛型序列，其包含源序列 <paramref name="_this"/> 的所有项。
        /// 如果 <paramref name="item"/> 元素不包含在 <paramref name="_this"/> 中，则返回的序列中也会包含 <paramref name="item"/> 元素。
        /// </returns>
        public static IEnumerable<TSource> Attach<TSource>(this IEnumerable<TSource> _this, TSource item, IEqualityComparer<TSource> comparer)
        {
            return _this.Contains(item, comparer) ? _this.AsEnumerable() : Append(_this, item);
        }

        /// <summary>
        /// 将 <see cref="IEnumerable&lt;TSource&gt;"/> 的元素强制转换为指定的类型。
        /// </summary>
        /// <typeparam name="TSource"><paramref name="_this"/> 中的元素的类型。</typeparam>
        /// <typeparam name="TResult"><paramref name="_this"/> 中的元素要强制转换成的类型。</typeparam>
        /// <param name="_this">一个要转换类型的值序列。</param>
        /// <param name="converter">应用于每个元素的转换函数。</param>
        /// <returns>一个 IEnumerable&lt;TResult&gt;，其元素为对 <paramref name="_this"/> 的每个元素调用转换函数的结果。</returns>
        public static IEnumerable<TResult> Cast<TSource, TResult>(this IEnumerable<TSource> _this, Func<TSource, TResult> converter)
        {
            Check.NotNull(_this);
            return _this.Select(item => converter(item));
        }

        /// <summary>
        /// 将 <see cref="IEnumerable&lt;TSource&gt;"/> 的元素强制转换为指定的类型。将在操作函数的逻辑中使用每个元素的索引。
        /// </summary>
        /// <typeparam name="TSource"><paramref name="_this"/> 中的元素的类型。</typeparam>
        /// <typeparam name="TResult"><paramref name="_this"/> 中的元素要强制转换成的类型。</typeparam>
        /// <param name="_this">一个要转换类型的值序列。</param>
        /// <param name="converter">一个应用于每个源元素的转换函数；函数的第二个参数表示源元素的索引。</param>
        /// <returns>一个 IEnumerable&lt;TResult&gt;，其元素为对 <paramref name="_this"/> 的每个元素调用转换函数的结果。</returns>
        public static IEnumerable<TResult> Cast<TSource, TResult>(this IEnumerable<TSource> _this, Func<TSource, int, TResult> converter)
        {
            Check.NotNull(_this);
            return _this.Select((i, item) => converter(i, item));
        }

        /// <summary>
        /// 返回一个数字，表示在指定的序列中满足条件的元素数量。将在操作函数的逻辑中使用每个元素的索引。
        /// </summary>
        /// <typeparam name="TSource"><paramref name="_this"/> 中的元素的类型。</typeparam>
        /// <param name="_this">包含要测试和计数的元素的序列。</param>
        /// <param name="predicate">用于测试每个元素是否满足条件的函数；函数的第二个参数表示源元素的索引。</param>
        /// <returns>一个数字，表示序列中满足谓词函数条件的元素数量。</returns>
        public static int Count<TSource>(this IEnumerable<TSource> _this, Func<TSource, int, bool> predicate)
        {
            Check.NotNull(_this);
            int counter = 0;
            TSource[] array = _this.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                TSource element = array[i];
                if (predicate(element, i))
                {
                    checked { counter++; }
                }
            }
            return counter;
        }

        private static IEnumerable<TSource> CreateDistinctByIterator<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>(comparer);
            foreach (var item in source)
            {
                TKey key = keySelector(item);
                if (!seenKeys.Contains(key))
                {
                    seenKeys.Add(key);
                    yield return item;
                }
            }
        }

        /// <summary>
        /// 返回源序列 <paramref name="_this"/> 中的一个子集。
        /// </summary>
        /// <typeparam name="TSource"><paramref name="_this"/> 中的元素的类型。</typeparam>
        /// <param name="_this">一个 <see cref="System.Collections.Generic.IEnumerable&lt;TSource&gt;"/>，用于从中返回元素。</param>
        /// <param name="startIndex">返回剩余元素前要跳过的元素数量，也可理解为范围开始处的从零开始的 <see cref="System.Collections.Generic.IEnumerable&lt;TSource&gt;"/> 索引。</param>
        /// <param name="count">范围中的元素数，同时也表示要返回的元素数量。</param>
        /// <returns>一个 <see cref="System.Collections.Generic.IEnumerable&lt;TSource&gt;"/>，它表示源序列 <paramref name="_this"/> 中的一个子集。</returns>
        public static IEnumerable<TSource> GetRange<TSource>(this IEnumerable<TSource> _this, int startIndex, int count)
        {
            return _this.Skip(startIndex).Take(count);
        }

        /// <summary>
        /// 根据键和指定的排序规则对序列的元素排序。
        /// </summary>
        /// <typeparam name="TSource">source 中的元素的类型。</typeparam>
        /// <typeparam name="TKey">keySelector 返回的键的类型。</typeparam>
        /// <param name="source">一个要排序的值序列。</param>
        /// <param name="keySelector">用于从元素中提取键的函数。</param>
        /// <param name="sortDirection">用于指定数据排序方式，升序还是降序。</param>
        /// <returns>一个 System.Linq.IOrderedEnumerable(TElement)，其元素按键排序。</returns>
        /// <exception cref="System.ArgumentNullException">source 或 keySelector 为 null。</exception>
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, ListSortDirection sortDirection)
        {
            return sortDirection == ListSortDirection.Ascending ? source.OrderBy(keySelector) : source.OrderByDescending(keySelector);
        }

        /// <summary>
        /// 使用指定的比较器和排序规则对序列的元素排序。
        /// </summary>
        /// <typeparam name="TSource">source 中的元素的类型。</typeparam>
        /// <typeparam name="TKey">keySelector 返回的键的类型。</typeparam>
        /// <param name="source">一个要排序的值序列。</param>
        /// <param name="keySelector">用于从元素中提取键的函数。</param>
        /// <param name="comparer">一个用于比较键的 System.Collections.Generic.IComparer&lt;TSource&gt;。</param>
        /// <param name="sortDirection">用于指定数据排序方式，升序还是降序。</param>
        /// <returns>一个 System.Linq.IOrderedEnumerable(TElement)，其元素按键排序。</returns>
        /// <exception cref="System.ArgumentNullException">source 或 keySelector 为 null。</exception>
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer, ListSortDirection sortDirection)
        {
            return sortDirection == ListSortDirection.Ascending ? source.OrderBy(keySelector, comparer) : source.OrderByDescending(keySelector, comparer);
        }

        /// <summary>
        /// 使用指定的 <see cref="System.Comparison&lt;TSource&gt;"/> 对整个 <see cref="System.Collections.Generic.IEnumerable&lt;TSource&gt;"/> 中的元素进行排序。
        /// 并返回该序列排序操作后的一个副本。
        /// </summary>
        /// <typeparam name="TSource"><paramref name="_this"/> 中的元素的类型。</typeparam>
        /// <param name="_this">一个要进行排序操作的值序列。</param>
        /// <param name="comparison">比较元素时要使用的 <see cref="System.Comparison&lt;TSource&gt;"/>。</param>
        /// <returns>一个 <see cref="System.Collections.Generic.IEnumerable&lt;TSource&gt;"/> ，它是源序列 <paramref name="_this"/> 排序操作后的一个副本。</returns>
        public static IEnumerable<TSource> Sort<TSource>(this IEnumerable<TSource> _this, Comparison<TSource> comparison)
        {
            List<TSource> list = _this.ToList();
            list.Sort(comparison);
            return list;
        }

        /// <summary>
        /// 使用指定的 <see cref="System.Collections.Generic.IComparer&lt;TSource&gt;"/> 对整个 <see cref="System.Collections.Generic.IEnumerable&lt;TSource&gt;"/> 中的元素进行排序。
        /// 并返回该序列排序操作后的一个副本。
        /// </summary>
        /// <typeparam name="TSource"><paramref name="_this"/> 中的元素的类型。</typeparam>
        /// <param name="_this">一个要进行排序操作的值序列。</param>
        /// <param name="comparer">
        /// 比较元素时要使用的 <see cref="System.Collections.Generic.IComparer&lt;TSource&gt;"/> 实现，或者
        /// 为 null，表示使用默认比较器 <seealso cref="System.Collections.Generic.Comparer&lt;TSource&gt;.Default"/>。
        /// </param>
        /// <returns>一个 <see cref="System.Collections.Generic.IEnumerable&lt;TSource&gt;"/> ，它是源序列 <paramref name="_this"/> 排序操作后的一个副本。</returns>
        public static IEnumerable<TSource> Sort<TSource>(this IEnumerable<TSource> _this, IComparer<TSource> comparer)
        {
            List<TSource> list = _this.ToList();
            list.Sort(comparer);
            return list;
        }

        /// <summary>
        /// 将一个泛型序列转换成一个 <see cref="DataTable"/>，表格中的每个 DataRow 表示泛型序列中的一个元素。
        /// </summary>
        /// <typeparam name="TSource">泛型序列中元素的类型。</typeparam>
        /// <param name="_this">一个要进行转换操作的泛型序列。</param>
        /// <returns>返回一个 <see cref="DataTable"/>，表格中的每个 DataRow 表示泛型序列中的一个元素</returns>
        public static DataTable ToDataTable<TSource>(this IEnumerable<TSource> _this)
        {
            Type type = typeof(TSource);
            DataTable table = new DataTable(type.Name);

            IEnumerable<PropertyInfo> properties = type.GetProperties().Where(p => p.GetMethod != null);

            foreach (var p in properties)
            {
                DataColumn column = new DataColumn(p.Name);
                column.DataType = p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
                    ? Nullable.GetUnderlyingType(p.PropertyType)
                    : p.PropertyType;
                table.Columns.Add(column);
            }

            foreach (TSource item in _this)
            {
                DataRow row = table.NewRow();
                foreach (PropertyInfo p in properties)
                {
                    object value = p.GetValue(item);
                    row[p.Name] = value == null ? DBNull.Value : value;
                }
                table.Rows.Add(row);
            }
            return table;
        }




        /// <summary>
        /// 将一个元素添加至泛型序列 IEnumerable&lt;TSource&gt; 的起始位置。并返回该序列添加元素后的一个副本。
        /// </summary>
        /// <typeparam name="TSource"><paramref name="_this"/> 中的元素的类型。</typeparam>
        /// <param name="_this">一个要进行合并操作的值序列。</param>
        /// <param name="item">将被添加值 <paramref name="_this"/> 序列起始位置的元素。</param>
        /// <returns>一个 IEnumerable&lt;TSource&gt; ，它是源序列 <paramref name="_this"/> 排序操作后的一个副本，同时包含新添加的元素 <paramref name="item"/>。</returns>
        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> _this, TSource item)
        {
            List<TSource> list = _this.ToList();
            list.Insert(0, item);
            return list;
        }

        /// <summary>
        /// 将一个元素添加至泛型序列 IEnumerable&lt;TSource&gt; 的结束位置。并返回该序列添加元素后的一个副本。
        /// </summary>
        /// <typeparam name="TSource"><paramref name="_this"/> 中的元素的类型。</typeparam>
        /// <param name="_this">一个要进行合并操作的值序列。</param>
        /// <param name="item">将被添加值 <paramref name="_this"/> 序列结束位置的元素。</param>
        /// <returns>一个 IEnumerable&lt;TSource&gt; ，它是源序列 <paramref name="_this"/> 排序操作后的一个副本，同时包含新添加的元素 <paramref name="item"/>。</returns>
        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> _this, TSource item)
        {
            List<TSource> list = _this.ToList();
            list.Add(item);
            return list;
        }
    }
}
