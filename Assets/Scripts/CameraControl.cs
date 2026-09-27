using Unity.Mathematics;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private float sensitivity = 200f;
    private Vector3 target = Vector3.zero;

    private CarInputActions carControls;

    public GameObject pivot;

    void OnEnable()
    {
        carControls.Enable();
    }

    void OnDisable()
    {
        carControls.Disable();
    }


    void Awake()
    {
        carControls = new CarInputActions(); // Initialize Input Actions
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = carControls.Camera.Rotate.ReadValue<Vector2>();

        target += new Vector3(-inputVector.y * sensitivity * Time.deltaTime, inputVector.x * sensitivity * Time.deltaTime, 0f);

        pivot.transform.rotation = Quaternion.Euler(target.x, target.y, target.z);
    }
}