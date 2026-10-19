using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerMobile : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2.0f;
    public float rotationSpeed = 10.0f;

    [Header("References")]
    public Transform avatarRoot; // where the avatar prefab is instantiated
    public VirtualJoystick joystick; // optional: set from scene UI

    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (avatarRoot != null) animator = avatarRoot.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 input = Vector3.zero;

        if (joystick != null && joystick.IsTouched)
        {
            input = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
        }
        else
        {
            // Desktop fallback for testing in editor
            input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        }

        Vector3 move = Vector3.zero;
        if (input.sqrMagnitude > 0.001f)
        {
            // move relative to camera forward
            Vector3 camForward = Camera.main.transform.forward;
            camForward.y = 0f;
            camForward.Normalize();
            Vector3 camRight = Camera.main.transform.right;
            camRight.y = 0f;
            camRight.Normalize();

            Vector3 desiredDir = camForward * input.z + camRight * input.x;
            move = desiredDir.normalized * moveSpeed;

            // smooth rotate player towards movement direction
            Quaternion targetRot = Quaternion.LookRotation(desiredDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }

        // apply movement
        controller.Move(move * Time.deltaTime);

        // simple animator control
        if (animator != null)
        {
            float speed = new Vector3(controller.velocity.x, 0f, controller.velocity.z).magnitude;
            animator.SetFloat("Speed", speed);
        }
    }
}
