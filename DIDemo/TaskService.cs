using DIDemo.Interface;

namespace DIDemo
{
    public class TaskService: ITransientService, IScopedService, SingletonService
    {
        Guid Id;

        public TaskService()
        {
            Id = Guid.NewGuid();
        }

        public Guid GetTaskId()
        {
            return Id;
        }
    }
}
