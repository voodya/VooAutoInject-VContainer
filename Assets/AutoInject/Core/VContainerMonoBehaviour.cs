using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using System.Reflection;
using UnityEditor.SceneManagement;
#endif
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Voodya.VooAutoInject.VContainer
{
    public class VContainerMonoBehaviour : MonoBehaviour
    {
        public virtual void OnValidate()
        {
#if UNITY_EDITOR
            if (this.gameObject.scene.name is null) { return; }

            var gg = PrefabStageUtility.GetCurrentPrefabStage();
            if (gg != null)
                return;

            if (!GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).ToList().Any(x => x.GetCustomAttribute<InjectAttribute>() != null))
                return;

            LifetimeScope installer = FindAnyObjectByType<LifetimeScope>();

            if (installer != null)
            {
                var property = installer.GetType().GetField("autoInjectGameObjects", BindingFlags.Instance | BindingFlags.NonPublic);
                List<GameObject> objects = (List<GameObject>)property.GetValue(installer);
                if (!objects.Contains(this.gameObject))
                {
                    objects.Add(this.gameObject);
                    property.SetValue(installer, objects);
                    Debug.LogWarning("Add successful");
                }
                else
                {
                    Debug.LogWarning($"{gameObject.name} already added");
                }
            }
            else
            {
                Debug.LogError("Notfound liftimescope in scene");
            }
#endif
        }
    }
}


