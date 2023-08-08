public interface ICleanUp
{
    string SceneName { get; set; }
    void Cleanup();
}