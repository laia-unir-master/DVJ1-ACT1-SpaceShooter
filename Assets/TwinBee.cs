using UnityEngine;
using UnityEngine.InputSystem;

public class TwinBee : MonoBehaviour
{
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference shot;
    [SerializeField] InputActionReference bomb;

    Vector2 rawMovement;

    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        transform.position += (Vector3)(rawMovement * 10f) * Time.deltaTime;
    }

    void OnEnable()
    {
        move.action.Enable();
        shot.action.Enable();
        bomb.action.Enable();

        move.action.performed += OnMove;
        move.action.started += OnMove;
        move.action.canceled += OnMove;
    }

    void OnDisable()
    {
        move.action.Disable();
        shot.action.Disable();
        bomb.action.Disable();

        move.action.performed -= OnMove;
        move.action.started -= OnMove;
        move.action.canceled -= OnMove;
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        rawMovement = ctx.ReadValue<Vector2>();
    }
}