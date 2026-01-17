using UnityEngine;

public class TimetableUI : MonoBehaviour
{
    [SerializeField] private ShiftSlotUI slotPrefab;
    [SerializeField] private Transform containerTransform;

    public int days = 5;
    public int shifts = 5;

    void Start()
    {
        Remove();

        for (int d = 0; d < days; d++)
            for (int s = 0; s < shifts; s++)
            {
                var slot = Instantiate(slotPrefab, containerTransform);
                slot.Setup(d,s);
            }
    }

    public void Remove()
    {
        foreach(Transform t in containerTransform)
        {
            Destroy(t.gameObject);
        }
    }

}
