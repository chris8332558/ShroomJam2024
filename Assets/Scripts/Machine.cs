using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bug"))
        {
            Debug.Log("Bug!");
		}
        if (collision.CompareTag("Electron"))
        { 
            Debug.Log("Electron!");   
            uiManager.AddScore(GameManager.ElectronPoint);
		}
        Destroy(collision.gameObject);
    }
}
