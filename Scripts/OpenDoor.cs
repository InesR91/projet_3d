using UnityEngine;

public class AutoOpenDoor : MonoBehaviour
{
    public float openAngle = 90f; // Angle d’ouverture
    public bool isOpen = false;   // État de la porte

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            // Ouvre la porte en la faisant pivoter sur l’axe Y
            transform.Rotate(Vector3.up * openAngle);
            isOpen = true;
        }
    }
}