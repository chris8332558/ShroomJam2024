using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    private float score;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddScore(18);
		}
    }

    public void AddScore(float aScore)
    {
        score += aScore;
        scoreText.text = score.ToString("00000000");
	}

}
