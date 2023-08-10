public interface ICleanUp
{
    string SceneName { get; }
    void Cleanup();
}