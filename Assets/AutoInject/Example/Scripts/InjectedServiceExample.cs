using UnityEngine;

public interface IService
{
    void PrintExample(string name);
}


public class InjectedServiceExample : IService
{
    public void PrintExample(string name)
    {
        Debug.Log($"GameObject {name} is successful injected");
    }
}
