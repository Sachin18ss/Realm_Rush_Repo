using UnityEngine;

public class Collectible : MonoBehaviour
{
    private bool canCollect;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (!canCollect) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.collider == GetComponent<Collider>())
                {
                    Collect();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canCollect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canCollect = false;
        }
    }

    private void Collect()
    {
        QuestManager.Instance.ReportProgress<FetchQuestSO>();
        Destroy(gameObject);
    }
}
