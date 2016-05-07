using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;

namespace EntityPlugin.RWSplitting.Utilities
{
	/// <summary>
	/// 提供一组对 基础对象类型 <see cref="System.Object"/> 操作方法的扩展。
	/// </summary>
	public static partial class ObjectExtensions
    {

        /// <summary>
        /// 判断指定的对象是否为 Null 或者等于 DBNull.Value 值。
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsNull(this Object _this)
        {
            return _this == null || Convert.IsDBNull(_this);
        }

        /// <summary>
        /// 将当前对象中所有属性的值按照属性名称和类型定义的匹配关系复制到另一对象中。
        /// </summary>
        /// <param name="_this">
        /// 表示将要用于复制数据到另一对象的元数据对象。
        /// 如果该参数值为 Null，将不会执行复制操作。
        /// </param>
        /// <param name="targetElement">表示一个目标对象，该对象中的相应属性值将会被更改。</param>
        /// <param name="abortOnFailed">一个布尔类型值，该值指示在复制数据过程中如果出现异常，是否立即停止并抛出异常，默认为 false。</param>
        public static void CopyTo(this object _this, object targetElement, bool abortOnFailed = false)
        {
            if (_this == null)
                return;

            Check.NotNull(targetElement);
            Type thisType = _this.GetType(), elemType = targetElement.GetType();

            var thisProps = thisType.GetProperties().Where(p => p.GetMethod != null);
            var elemProps = elemType.GetProperties().Where(p => p.SetMethod != null);
            foreach (PropertyInfo thisProperty in thisProps)
            {
                PropertyInfo elemProperty = elemProps.FirstOrDefault(p => p.Name == thisProperty.Name);
                if (elemProperty != null && elemProperty.PropertyType.IsAssignableFrom(thisProperty.PropertyType))
                {
                    if (abortOnFailed)
                        elemProperty.SetValue(targetElement, thisProperty.GetValue(_this));
                    else
                        Trying.Try(() => elemProperty.SetValue(targetElement, thisProperty.GetValue(_this)));
                }
            }

            var thisFields = thisType.GetFields();
            var elemFields = elemType.GetFields();
            foreach (FieldInfo thisField in thisFields)
            {
                FieldInfo elemField = elemFields.FirstOrDefault(f => f.Name == thisField.Name);
                if (elemField != null && elemField.FieldType.IsAssignableFrom(thisField.FieldType))
                {
                    if (abortOnFailed)
                        elemField.SetValue(targetElement, thisField.GetValue(_this));
                    else
                        Trying.Try(() => elemField.SetValue(targetElement, thisField.GetValue(_this)));
                }
            }
        }

        /// <summary>
        /// 创建一个当前对象的新副本，该副本和当前对象为同一类型，且其中各个属性的值均等同于原对象中各个属性的值。
        /// 相当于浅表复制操作 Object.MemberwiseClone，但和 Object.MemberwiseClone 不同的是该操作只对公共 Public 的可 set 属性进行复制，并且不会复制其他字段或私有成员的值。
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="abortOnFailed"></param>
        /// <returns></returns>
        public static object Duplicate(this object _this, bool abortOnFailed = false)
        {
            if (_this == null)
                return null;

            Type thisType = _this.GetType();
            if (thisType.IsValueType)
                return _this;

            if (_this is ICloneable)
                return ((ICloneable)_this).Clone();

            Object obj = Activator.CreateInstance(thisType);
            _this.CopyTo(obj, abortOnFailed);
            return obj;
        }
    }
}
