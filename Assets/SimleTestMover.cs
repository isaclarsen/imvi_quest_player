using UnityEngine;

public class SimpleTestMover : MonoBehaviour
{
    // Inställningar du kan ändra direkt i Unity
    public float speed = 2.0f;      // Hur snabbt den rör sig
    public float distance = 1.0f;   // Hur långt den rör sig (meter)

    private Vector3 startPos;

    void Start()
    {
        // Kom ihåg var skärmen startade
        startPos = transform.position;
    }

    void Update()
    {
        // En enkel matte-formel (Sinus) för att åka fram och tillbaka
        float xMovement = Mathf.Sin(Time.time * speed) * distance;

        // Uppdatera positionen
        transform.position = startPos + new Vector3(xMovement, 0, 0);
    }
}