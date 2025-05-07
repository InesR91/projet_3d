using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Transform player; // À assigner dans l’inspecteur ou automatiquement
    public float openDistance = 2.0f;
    public float openAngle = 90f;
    public float openSpeed = 2f;
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    public OpenDoor()
    {
    }

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
        if (player == null)
        {
            GameObject foundPlayer = GameObject.Find("Untitled (1)");
            if (foundPlayer != null)
                player = foundPlayer.transform;
        }
    }

    void Update()
    {
        if (player == null) return;
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < openDistance)
        {
            isOpen = true;
        }
        else
        {
            isOpen = false;
        }

        if (isOpen)
            transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);
        else
            transform.rotation = Quaternion.Slerp(transform.rotation, closedRotation, Time.deltaTime * openSpeed);
    }
}