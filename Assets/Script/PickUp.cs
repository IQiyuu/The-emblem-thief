using UnityEngine;
public class PickUp : MonoBehaviour
{
    [SerializeField] QTE_SYSTEM QTE;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            QTE.LaunchQTE(gameObject.transform.parent.GetComponent<Car>());
            //Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            QTE.ExitQTE(gameObject.GetComponent<Car>());
            //Destroy(gameObject);
        }
    }
}