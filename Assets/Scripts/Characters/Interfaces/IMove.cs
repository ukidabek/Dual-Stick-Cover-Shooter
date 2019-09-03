public interface IMove : ISet
{
    void Stop();
    bool OnPosition { get; }
}
