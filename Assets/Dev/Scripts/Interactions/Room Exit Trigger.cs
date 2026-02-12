using UnityEngine;

public class RoomExitTrigger : MonoBehaviour
{
    public EnemySpawner roomSpawner;

    private void OnTriggerEnter(Collider other)
{
    if (!other.CompareTag("Player")) return;
    roomSpawner.EnableChaseInThisRoom();
}

private void OnTriggerExit(Collider other)
{
    if (!other.CompareTag("Player")) return;
    roomSpawner.DisableChaseInThisRoom();
}

}
