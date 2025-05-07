using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject buttonUI; // Le bouton à afficher

    private void Start()
    {
        if (buttonUI != null)
            buttonUI.SetActive(false); // On le cache au départ
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (buttonUI != null)
                buttonUI.SetActive(true); // Affiche le bouton
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (buttonUI != null)
                buttonUI.SetActive(false); // Cache le bouton
        }
    }
}
