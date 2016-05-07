using System;
using System.Linq;
using System.Reflection;

namespace EntityPlugin.RWSplitting.Utilities
{
	/// <summary>
	/// 提供一组对 类型 <see cref="System.Type"/> 的工具操作方法。
	/// </summary>
	public static class Types
    {
        private static BindingFlags _bindingFlagsAll = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        /// <summary>
        /// 获取已加载至当前应用程序中整个应用程序域下所有已经加载的程序集中定义的所有类型 <see cref="System.Type"/> 集合所构成的一个数组。
        /// </summary>
        /// <returns>已加载至当前应用程序中整个应用程序域下所有已经加载的程序集中定义的所有类型 <see cref="System.Type"/> 集合所构成的一个数组。</returns>
        public static Type[] GetTypes()
        {
            return Assemblies.GetTypes();
        }

        /// <summary>
        /// 获取已加载至当前应用程序中整个应用程序域下所有已经加载的程序集中指定的命名空间中定义的所有类型 <see cref="System.Type"/> 集合所构成的一个数组。
        /// </summary>
        /// <param name="nameSpace">指定的命名空间。</param>
        /// <returns>已加载至当前应用程序中整个应用程序域下所有已经加载的程序集中指定的命名空间中定义的所有类型 <see cref="System.Type"/> 集合所构成的一个数组。</returns>
        public static Type[] GetTypes(string nameSpace)
        {
            return GetTypes(nameSpace, AssemblyScope.Global);
        }

        /// <summary>
        /// 获取已加载至当前应用程序中指定程序集作用范围内的程序集中指定的命名空间中定义的所有类型 <see cref="System.Type"/> 集合所构成的一个数组。
        /// </summary>
        /// <param name="nameSpace">指定的命名空间。</param>
        /// <param name="scope">一个 <see cref="AssemblyScope"/> 枚举值，表示指定的程序集作用范围。</param>
        /// <returns>已加载至当前应用程序中指定程序集作用范围内的程序集中指定的命名空间中定义的所有类型 <see cref="System.Type"/> 集合所构成的一个数组。</returns>
        public static Type[] GetTypes(string nameSpace, AssemblyScope scope)
        {
            return GetTypes(scope).Where(type => string.Equals(nameSpace, type.Namespace, StringComparison.Ordinal)).ToArray();
        }

        /// <summary>
        /// 获取已加载至当前应用程序中指定程序集作用范围内的程序集中定义的所有类型 <see cref="System.Type"/> 集合所构成的一个数组。
        /// </summary>
        /// <param name="scope">一个 <see cref="AssemblyScope"/> 枚举值，表示指定的程序集作用范围。</param>
        /// <returns>已加载至当前应用程序中指定程序集作用范围内的程序集中定义的所有类型 <see cref="System.Type"/> 集合所构成的一个数组。</returns>
        public static Type[] GetTypes(AssemblyScope scope)
        {
            return Assemblies.GetTypes(scope);
        }

        /// <summary>
        /// 获取程序集中定义的类型。
        /// 同 <seealso cref="Assembly.GetTypes"/>；但在 <seealso cref="Assembly.GetTypes"/> 基础上屏蔽了 <see cref="System.Reflection.ReflectionTypeLoadException"/> 异常。
        /// </summary>
        /// <param name="assembly">应用程序集。</param>
        /// <returns>一个数组，包含此程序集中定义的所有类型。</returns>
        public static Type[] GetTypes(Assembly assembly)
        {
            return Assemblies.GetTypes(assembly);
        }



        /// <summary>
        /// 获取已加载至当前应用程序中整个应用程序域下所有已经加载的程序集中定义的所有公共类型 <see cref="System.Type"/> 集合所构成的一个数组。
        /// </summary>
        /// <returns>已加载至当前应用程序中整个应用程序域下所有已经加载的程序集中定义的所有公共类型 <see cref="System.Type"/> 集合所构成的一个数组。</returns>
        public static Type[] GetPublicTypes()
        {
            return Assemblies.GetPublicTypes();
        }

        /// <summary>
        /// 获取已加载至当前应用程序中整个应用程序域下所有已经加载的程序集中指定的命名空间中定义的所有公共类型 <see cref="System.Type"/> 集合所构成的一个数组。
        /// </summary>
        /// <param name="nameSpace">指定的命名空间。</param>
        /// <returns>已加载至当前应用程序中整个应用程序域下所有已经加载的程序集中指定的命名空间中定义的所有公共类型 <see cref="System.Type"/> 集合所构成的一个数组。</returns>
        public static Type[] GetPublicTypes(string nameSpace)
        {
            return GetPublicTypes(nameSpace, AssemblyScope.Global);
        }

        /// <summary>
        /// 获取已加载至当前应用程序中指定程序集作用范围内的程序集中指定的命名空间中定义的所有公共类型 <see cref="System.Type"/> 集合所构成的一个数组。
        /// </summary>
        /// <param name="nameSpace">指定的命名空间。</param>
        /// <param name="scope">一个 <see cref="AssemblyScope"/> 枚举值，表示指定的程序集作用范围。</param>
        /// <returns>已加载至当前应用程序中指定程序集作用范围内的程序集中指定的命名空间中定义的所有公共类型 <see cref="System.Type"/> 集合所构成的一个数组。</returns>
        public static Type[] GetPublicTypes(string nameSpace, AssemblyScope scope)
        {
            return GetPublicTypes(scope).Where(type => string.Equals(nameSpace, type.Namespace, StringComparison.Ordinal)).ToArray();
        }

        /// <summary>
        /// 获取已加载至当前应用程序中指定程序集作用范围内的程序集中定义的所有公共类型 <see cref="System.Type"/> 集合所构成的一个数组。
        /// </summary>
        /// <param name="scope">一个 <see cref="AssemblyScope"/> 枚举值，表示指定的程序集作用范围。</param>
        /// <returns>已加载至当前应用程序中指定程序集作用范围内的程序集中定义的所有公共类型 <see cref="System.Type"/> 集合所构成的一个数组。</returns>
        public static Type[] GetPublicTypes(AssemblyScope scope)
        {
            return Assemblies.GetPublicTypes(scope);
        }

        /// <summary>
        /// 获取此程序集中定义的公共类型的集合，这些公共类型在程序集外可见。
        /// 同 <seealso cref="Assembly.ExportedTypes"/>；但在 <seealso cref="Assembly.ExportedTypes"/> 基础上屏蔽了 <see cref="System.Reflection.ReflectionTypeLoadException"/> 异常。
        /// </summary>
        /// <param name="assembly">应用程序集。</param>
        /// <returns>此程序集中定义的公共类型的集合，这些公共类型在程序集外可见。</returns>
        public static Type[] GetPublicTypes(Assembly assembly)
        {
            return Assemblies.GetPublicTypes(assembly);
        }

		/// <summary>
		/// 尝试获取具有指定名称的 System.Type，执行区分大小写的搜索。
		/// </summary>
		/// <param name="typeName">要获取的类型的程序集限定名称。 请参见 System.Type.AssemblyQualifiedName。 如果该类型位于当前正在执行的程序集中或者 Mscorlib.dll 中，则提供由命名空间限定的类型名称就足够了。</param>
		/// <param name="result">当此方法返回值时，如果找到该类型，便会返回获取到的类型；否则返回 null。</param>
		/// <returns>如果找到具有指定名称的类型，则返回 true，否则返回 false。</returns>
		public static bool TryGetType(string typeName, out Type result)
		{
			try
			{
				result = Type.GetType(typeName);
			}
			catch
			{
				result = null;
			}
			return result != null;
		}
	}
}
