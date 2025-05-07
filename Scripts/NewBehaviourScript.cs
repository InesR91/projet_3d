using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementRigidbody : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 120f; // degr�s par seconde

    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float moveZ = Input.GetAxis("Vertical");   // Avancer/Reculer
        float rotate = Input.GetAxis("Horizontal"); // Tourner

        // Rotation autour de Y
        if (Mathf.Abs(rotate) > 0.1f)
        {
            transform.Rotate(Vector3.up * rotate * rotationSpeed * Time.fixedDeltaTime);
        }

        // Mouvement vers l'avant/recul
        Vector3 moveDirection = transform.forward * moveZ;
        Vector3 velocity = moveDirection * moveSpeed;
        velocity.y = rb.velocity.y; // conserver la gravit�
        rb.velocity = velocity;

        // Animation
        bool isWalking = Mathf.Abs(moveZ) > 0.1f;
        if (animator != null)
            animator.SetBool("isWalking", isWalking);
    }
}
