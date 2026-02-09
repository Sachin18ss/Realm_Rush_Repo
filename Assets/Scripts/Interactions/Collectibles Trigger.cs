using UnityEngine;

public class CollectibleTrigger : MonoBehaviour
{
    private Collectible parent;

    private void Awake()
    {
        parent = GetComponentInParent<Collectible>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            parent.SetCanCollect(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            parent.SetCanCollect(false);
    }
}
