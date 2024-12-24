using System;
using UnityEngine;
using VContainer;
using Voodya.VooAutoInject.VContainer;

public class ExampleGameObject : VContainerMonoBehaviour
{
    [SerializeField] private int _testInt;
    [Inject] IService _service;

    private void Awake()
    {
        _service.PrintExample(gameObject.name);
    }
}
