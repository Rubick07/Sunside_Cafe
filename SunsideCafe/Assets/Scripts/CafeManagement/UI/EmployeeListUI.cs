using UnityEngine;

public class EmployeeListUI : MonoBehaviour
{
    [SerializeField] private EmployeeCardUI cardPrefab;
    [SerializeField] private Transform containerTransform;
    [SerializeField] private EmployeeData[] employees;

    void Start()
    {
        Remove();

        foreach (var emp in employees)
        {
            var card = Instantiate(cardPrefab, containerTransform);
            card.Setup(emp);
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
