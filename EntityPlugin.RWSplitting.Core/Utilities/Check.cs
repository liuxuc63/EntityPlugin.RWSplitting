using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityPlugin.RWSplitting.Utilities
{
	/// <summary>
	/// 静态辅助类，提供一组用于检查输入参数是否合规的工具方法。
	/// </summary>
	public class Check
    {
        /// <summary>
        /// 检查输入的参数 <paramref name="value"/> 是否为 Null。
        /// 如果 <paramref name="value"/> 值为 Null，则抛出 <see cref="ArgumentNullException"/> 异常；否则返回 <paramref name="value"/> 值本身。
        /// </summary>
        /// <typeparam name="T"><paramref name="value"/> 参数的类型。</typeparam>
        /// <param name="value">被检查的参数值。</param>
        /// <returns>如果 <paramref name="value"/> 值不为 Null ，则返回 <paramref name="value"/> 值本身。</returns>
        /// <exception cref="ArgumentNullException">如果 <paramref name="value"/> 值为 Null，则抛出该异常。</exception>
        public static T NotNull<T>(T value) where T : class
        {
            return NotNull<T>(value, "value");
        }

        /// <summary>
        /// 检查输入的参数 <paramref name="value"/> 是否为 Null。
        /// 如果 <paramref name="value"/> 值为 Null，则抛出 <see cref="ArgumentNullException"/> 异常；否则返回 <paramref name="value"/> 值本身。
        /// </summary>
        /// <typeparam name="T"><paramref name="value"/> 参数的类型。</typeparam>
        /// <param name="value">被检查的参数值。</param>
        /// <param name="parameterName">被检查的参数名称。</param>
        /// <returns>如果 <paramref name="value"/> 值不为 Null ，则返回 <paramref name="value"/> 值本身。</returns>
        /// <exception cref="ArgumentNullException">如果 <paramref name="value"/> 值为 Null，则抛出该异常。</exception>
        public static T NotNull<T>(T value, string parameterName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
            return value;
        }

        /// <summary>
        /// 检查输入的参数是否为 Null、空或者空白字符串组成。
        /// 如果 <paramref name="value"/> 值为 Null、空或者空白字符串组成，则抛出 <see cref="System.ArgumentException"/> 异常；否则返回 <paramref name="value"/> 值本身。
        /// </summary>
        /// <param name="value">被检查的参数值。</param>
        /// <param name="parameterName">被检查的参数名称。</param>
        /// <returns>如果 <paramref name="value"/> 值不为 Null、空或者空白字符串组成 ，则返回 <paramref name="value"/> 值本身。</returns>
        /// <exception cref="System.ArgumentNullException">如果 <paramref name="value"/> 值为 Null、空或者空白字符串组成，则抛出该异常。</exception>
        public static string NotEmpty(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(string.Format(Resource.Check_NotEmpty, parameterName), parameterName);
            }
            return value;
        }

        /// <summary>
        /// 检查输入的参数是否为 Null、空或者空白字符串组成。
        /// 如果 <paramref name="value"/> 值为 Null、空或者空白字符串组成，则抛出 <see cref="System.ArgumentException"/> 异常；否则返回 <paramref name="value"/> 值本身经过去首尾空格处理后的文本内容。
        /// </summary>
        /// <param name="value">被检查的参数值。</param>
        /// <returns>如果 <paramref name="value"/> 值不为 Null、空或者空白字符串组成 ，则返回 <paramref name="value"/> 参数去除首尾空格后的结果。</returns>
        /// <exception cref="System.ArgumentNullException">如果 <paramref name="value"/> 值为 Null、空或者空白字符串组成，则抛出该异常。</exception>
        public static string EmptyCheck(string value)
        {
            return EmptyCheck(value, "value");
        }

        /// <summary>
        /// 检查输入的参数是否为 Null、空或者空白字符串组成。
        /// 如果 <paramref name="value"/> 值为 Null、空或者空白字符串组成，则抛出 <see cref="System.ArgumentException"/> 异常；否则返回 <paramref name="value"/> 值本身经过去首尾空格处理后的文本内容。
        /// </summary>
        /// <param name="value">被检查的参数值。</param>
        /// <param name="parameterName">被检查的参数名称。</param>
        /// <returns>如果 <paramref name="value"/> 值不为 Null、空或者空白字符串组成 ，则返回 <paramref name="value"/> 参数去除首尾空格后的结果。</returns>
        /// <exception cref="System.ArgumentNullException">如果 <paramref name="value"/> 值为 Null、空或者空白字符串组成，则抛出该异常。</exception>
        public static string EmptyCheck(string value, string parameterName)
        {
            value = value != null ? value.Trim() : value;
            NotEmpty(value, parameterName);
            return value;
        }

		/// <summary>
		/// 检查输入的数组参数 <paramref name="values"/> 中应存在至少一个元素的值不能为 Null；
		/// 如果不是，则抛出 <see cref="System.ArgumentException"/> 异常；否则返回 <paramref name="values"/> 值本身。
		/// </summary>
		/// <typeparam name="TSource">被检查的数组参数中元素的类型。</typeparam>
		/// <param name="values">被检查的数组参数，将会判断该数组中每个元素是否为 Null。</param>
		/// <param name="parameterName">表示数组参数 <paramref name="values"/> 的参数名称。</param>
		/// <returns>如果输入的数组参数 <paramref name="values"/> 不为 Null，则包含 1 个或多个元素，则存在至少一个元素的值不为 Null，则返回参数 <paramref name="values"/> 本身。</returns>
		/// <exception cref="System.ArgumentException">如果数组参数 <paramref name="values"/> 中不存在任何元素(空数组)，或其中所有的元素值均为 Null，则抛出该异常。</exception>
		/// <exception cref="System.ArgumentNullException">如果数组参数 <paramref name="values"/> 为 Null，则抛出该异常。</exception>
		public static TSource[] AnyNotNull<TSource>(TSource[] values, string parameterName)
		{
			Check.NotEmpty(values, parameterName);
			if (!values.Any(item => item != null))
			{
				throw new ArgumentException(string.Format(Resource.Check_AnyNotNull, parameterName));
			}
			return values;
		}

		/// <summary>
		/// 检查输入的参数是否为 Null 或者空序列。
		/// 如果 <paramref name="values"/> 值为 Null 或者空序列，则抛出 <see cref="System.ArgumentException"/> 异常；否则返回 <paramref name="values"/> 值本身。
		/// </summary>
		/// <typeparam name="TSource">被检查的数组参数中元素的类型。</typeparam>
		/// <param name="values">被检查的数组参数。</param>
		/// <param name="parameterName">被检查的数组参数名称。</param>
		/// <returns>如果 <paramref name="values"/> 值不为 Null 或者空序列，则返回 <paramref name="values"/> 值本身。</returns>
		/// <exception cref="System.ArgumentException">如果 <paramref name="values"/> 值为 Null 或者空序列，则抛出该异常。</exception>
		public static IEnumerable<TSource> NotEmpty<TSource>(IEnumerable<TSource> values, string parameterName)
		{
			if (EnumerableExtensions.IsNullOrEmpty(values))
			{
				throw new ArgumentException(string.Format(Resource.Check_ArrayNotEmpty, parameterName), parameterName);
			}
			return values;
		}

		/// <summary>
		/// 检查输入参数 <paramref name="value1"/> 的值是否为 Null、空字符串或者值等同于参数 <paramref name="value2"/> 的值；
		/// 如果不是，则抛出 <see cref="System.ArgumentException"/> 异常；否则返回 <paramref name="value1"/> 值本身。
		/// </summary>
		/// <param name="value1">被检查的输入参数。</param>
		/// <param name="value2">作为与 <paramref name="value1"/> 值对比的另一个参数。</param>
		/// <returns>如果输入参数 <paramref name="value1"/> 的值为 Null、空字符串或者值等同于参数 <paramref name="value2"/>，则返回 <paramref name="value1"/> 值本身。</returns>
		/// <exception cref="System.ArgumentException">
		/// 如果输入参数 <paramref name="value1"/> 的值不为 Null、空字符串且不等同于参数 <paramref name="value2"/> 的值，则抛出该异常。
		/// </exception>
		public static string EmptyOrEquals(string value1, string value2)
		{
			return EmptyOrEquals(value1, value2, "value");
		}

		/// <summary>
		/// 检查输入参数 <paramref name="value1"/> 的值是否为 Null、空字符串或者值等同于参数 <paramref name="value2"/> 的值；
		/// 如果不是，则抛出 <see cref="System.ArgumentException"/> 异常；否则返回 <paramref name="value1"/> 值本身。
		/// </summary>
		/// <param name="value1">被检查的输入参数。</param>
		/// <param name="value2">作为与 <paramref name="value1"/> 值对比的另一个参数。</param>
		/// <param name="parameterName">表示参数 <paramref name="value1"/> 的名称。</param>
		/// <returns>如果输入参数 <paramref name="value1"/> 的值为 Null、空字符串或者值等同于参数 <paramref name="value2"/>，则返回 <paramref name="value1"/> 值本身。</returns>
		/// <exception cref="System.ArgumentException">
		/// 如果输入参数 <paramref name="value1"/> 的值不为 Null、空字符串且不等同于参数 <paramref name="value2"/> 的值，则抛出该异常。
		/// </exception>
		public static string EmptyOrEquals(string value1, string value2, string parameterName)
		{
			if (!string.IsNullOrWhiteSpace(value1) && value1 != value2)
			{
				throw new ArgumentException(string.Format(Resource.Check_EmptyOrEquals, parameterName, value2));
			}
			return value1;
		}
	}
}
