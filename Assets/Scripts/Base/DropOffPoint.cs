using UnityEngine;
using UnityEngine.Events;

public class DropOffPoint : MonoBehaviour
{
    public event UnityAction<Resource> Droped;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Resource resource))
        {
            Debug.Log(resource.name);
            Droped.Invoke(resource);
        }
    }
}
