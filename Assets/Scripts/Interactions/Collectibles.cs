using UnityEngine;

public class Collectible : MonoBehaviour
{
    private bool canCollect;
    public  Camera cam;

    private void Start()
    {
       // cam = Camera.main;
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

    public void SetCanCollect(bool value)
    {
        canCollect = value;
    }

    public void TryCollect(GameObject hitObject)
    {
        if (!canCollect) return;

        // check if ray hit THIS collectible or its children
        if (hitObject.transform.root != transform) return;

        Collect();
    }

    private void Collect()
    {
        QuestManager.Instance.ReportProgress<FetchQuestSO>();
        Destroy(gameObject);
    }
}
