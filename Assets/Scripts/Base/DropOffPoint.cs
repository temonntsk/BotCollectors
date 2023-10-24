using UnityEngine;
using UnityEngine.Events;

public class DropOffPoint : MonoBehaviour
{
    public event UnityAction<Resource> Droped;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Resource resource))
        {
            Droped.Invoke(resource);
        }
    }
}
