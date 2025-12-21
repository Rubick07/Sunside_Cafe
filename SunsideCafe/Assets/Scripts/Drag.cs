using UnityEngine;

public class Drag : MonoBehaviour
{

    [Header("SETTINGS")]
    [SerializeField] private LayerMask surfaceLayer; // assign = Surface
    [SerializeField] private float heightOffset = 0.1f; // jarak piring dari meja

    private Camera cam;
    private Rigidbody rb;
    private Vector3 offset;
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }
    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, surfaceLayer))
        {
            offset = transform.position - hit.point;
        }
    }

    void OnMouseDrag()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, surfaceLayer))
        {
            Vector3 target = hit.point + offset;

            target.y = hit.point.y + heightOffset;

            rb.MovePosition(target);
        }
    }

    private void OnMouseUp()
    {
        transform.position = startPosition;
    }
}
