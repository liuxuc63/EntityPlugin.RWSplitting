using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace EntityPlugin.RWSplitting.MasterSlaves
{
	internal class MasterSlaveDispatcher
    {
        private volatile List<IMasterSlaveInterceptor> _interceptors = new List<IMasterSlaveInterceptor>();
        private readonly object _locker = new object();

        /// <summary>
        /// 初始化类型 <see cref="MasterSlaveDispatcher"/> 的新实例。
        /// </summary>
        internal MasterSlaveDispatcher()
        {
        }

        internal void AddInterceptor(IMasterSlaveInterceptor interceptor)
        {
			if (interceptor == null)
				throw new ArgumentNullException(nameof(interceptor));

            lock (_locker)
            {
                List<IMasterSlaveInterceptor> list = _interceptors.ToList();
                list.Add(interceptor);
                _interceptors = list;
            }
        }

        internal void RemoveInterceptor(IMasterSlaveInterceptor interceptor)
        {
			if (interceptor == null)
				throw new ArgumentNullException(nameof(interceptor));

            lock (_locker)
            {
                List<IMasterSlaveInterceptor> list = _interceptors.ToList();
                list.Remove(interceptor);
                _interceptors = list;
            }
        }


        private void Dispatch(Action<IMasterSlaveInterceptor> action, Type contextType)
        {
			if (action == null)
				throw new ArgumentNullException(nameof(action));

            foreach (var interceptor in this.GetInterceptors(contextType))
            {
                if (interceptor == null)
                    continue;

                action(interceptor);
            }
        }

        private IEnumerable<IMasterSlaveInterceptor> GetInterceptors(Type contextType)
        {
			if (contextType == null)
				throw new ArgumentNullException(nameof(contextType));

            if (this._interceptors.Count > 0)
            {
                return this._interceptors.Where(
                    item =>
                        item.TargetContextType == contextType || contextType.IsSubclassOf(item.TargetContextType)
                        );
            }
            return Enumerable.Empty<IMasterSlaveInterceptor>();
        }


        internal void DbServerStateScanning(string connectionString, DbServerType serverType, DbServerState serverState, Type contextType)
        {
            this.Dispatch(
                interceptor => interceptor.DbServerStateScanning(connectionString, serverType, serverState),
                contextType);
        }

        internal void DbServerStateScanned(string connectionString, DbServerType serverType, DbServerState serverState, Type contextType)
        {
            this.Dispatch(
                interceptor => interceptor.DbServerStateScanned(connectionString, serverType, serverState),
                contextType);
        }


        internal void ConnectionStringUpdating(DbCommand command, Type contextType)
        {
            this.Dispatch(
                interceptor => interceptor.ConnectionStringUpdating(command),
                contextType);
        }

        internal void ConnectionStringUpdated(DbCommand command, Type contextType)
        {
            this.Dispatch(
                interceptor => interceptor.ConnectionStringUpdated(command),
                contextType);
        }


    }
}
