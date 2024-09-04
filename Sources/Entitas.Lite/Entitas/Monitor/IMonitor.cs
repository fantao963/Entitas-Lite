using System.Collections.Generic;

namespace Entitas {

	public delegate bool MonitorFilter(IEntity entity);
	public delegate void MonitorProcessor(List<IEntity> entities);

	public interface IMonitor {

		IMonitor Where(MonitorFilter filter);
		IMonitor Trigger(MonitorProcessor processor);

		void Activate();
		void Deactivate();

		void Clear();

		void Execute();
	}
}
