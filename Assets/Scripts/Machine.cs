using UnityEngine;
using System.Collections;

public class Machine : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] Sprite machineBreakSprite;
    private SpriteRenderer mSprite;
    private float numOfBug = 0;
    private float maxBug = 3;

    private void Awake()
    {
        mSprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bug"))
        {
            Debug.Log("Bug!");
            numOfBug += 1f;
            uiManager.FillAlertLight(numOfBug / maxBug);
            GameManager.Instance.electronPoint *= 0.9f;
            SFXSource.Instance.PlayErrorClip();
		}
        if (collision.CompareTag("Electron"))
        { 
            Debug.Log("Electron!");
            float scoreToAdd = GameManager.Instance.electronPoint;
            if (GameManager.Instance.numCable == 4) scoreToAdd *= 1.35f;
            uiManager.AddScore(scoreToAdd);
            SFXSource.Instance.PlayScoreClip();
		}
        Destroy(collision.gameObject);

        if (numOfBug == maxBug || GameManager.Instance.timer <= 0)
        {
            GameOver();
		}
    }

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
	}

    IEnumerator GameOverRoutine()
    {
        GameManager.Instance.StopGame();
        if (numOfBug == maxBug)
        {
            mSprite.sprite = machineBreakSprite;
        }
        yield return new WaitForSeconds(1.5f);
        EventManager.GameOver.Invoke();
	}
}
