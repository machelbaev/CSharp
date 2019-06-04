namespace Task
{
    public interface IEntityFactory<out T>
    {
        T Instance { get; }
    }
}
