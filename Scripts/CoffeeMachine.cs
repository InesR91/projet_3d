using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoffeeMachine : MonoBehaviour
{
    public GameObject coffeeButtonUI;
    public AudioSource coffeeSound;
    public GameObject coffeeCup; // 👉 La tasse de café à afficher

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coffeeButtonUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coffeeButtonUI.SetActive(false);
        }
    }

    public void MakeCoffee()
    {
        if (coffeeSound != null)
        {
            coffeeSound.Play();
            StartCoroutine(ShowCoffeeAfterSound());
        }

        coffeeButtonUI.SetActive(false); // Cacher le bouton après clic
    }

    IEnumerator ShowCoffeeAfterSound()
    {
        // Attend que le son soit terminé
        yield return new WaitForSeconds(coffeeSound.clip.length);

        if (coffeeCup != null)
        {
            coffeeCup.SetActive(true); // 👉 Affiche la tasse
        }
    }
}
