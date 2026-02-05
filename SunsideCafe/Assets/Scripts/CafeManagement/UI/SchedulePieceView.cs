using System.Collections.Generic;
using UnityEngine;

public class SchedulePieceView : MonoBehaviour
{
    [SerializeField] private RectTransform blockParent;
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private float cellSize = 32f;

    List<GameObject> blocks = new();


    public void BuildShape(EmployeeData employeeData)
    {
        Clear();

        foreach (var cell in employeeData.scheduleShape.cells)
        {
            var block = Instantiate(blockPrefab, blockParent);
            var rt = block.GetComponent<RectTransform>();

            rt.anchoredPosition = new Vector2(
                cell.x * cellSize,
                -cell.y * cellSize
            );

            blocks.Add(block);
        }
    }

    void Clear()
    {
        foreach (var b in blocks)
            Destroy(b);

        blocks.Clear();
    }
}
