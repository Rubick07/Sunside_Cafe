using UnityEngine;

public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);

    public static Vector3 GetMousePosition(this Vector3 pos) => Camera.main.WorldToScreenPoint(pos);

    public static float TimeConverterToMinutes(float time)
    {
        return time / 60;
    }

    public static float TimeConverterSecond(float time)
    {
        return time % 60;
    }

    public static GameObject GetPlayerGameObject()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        return playerObject;
    }

    public static void RemoveAllChild(this Transform parent)
    {
        foreach (Transform child in parent)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public static TUI CreateUI<TUI, TData>(TUI prefab,Transform parent,TData data)
    where TUI : MonoBehaviour, IBindData<TData>
    {
        TUI ui = GameObject.Instantiate(prefab, parent);
        ui.Bind(data);
        return ui;
    }

}
