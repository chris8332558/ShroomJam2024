using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameOverUI gameOverUI;
    [SerializeField] Image alertLightFull;
    [SerializeField] TMP_Text clockText;
    [SerializeField] Image transitionInImg;
    private float score;

    private void Start()
    {
        gameOverUI.transform.localScale = Vector3.zero;
        transitionInImg.DOFade(0f, 0.5f).OnComplete(() =>
        {
            transitionInImg.gameObject.SetActive(false);
        });
    }

    private void OnEnable()
    {
        EventManager.GameOver.AddListener(OnGameOver);
    }

    private void Update()
    {
        clockText.text = GameManager.Instance.timer.ToString("00.00");
    }

    public void AddScore(float aScore)
    {
        score += aScore;
	}

    public void FillAlertLight(float amount)
    {
        alertLightFull.fillAmount = amount;
	}

    public void OnGameOver()
    {
        score *= (60f-GameManager.Instance.timer) * 0.125f;
        gameOverUI.SetScore(score);
        gameOverUI.gameObject.SetActive(true);
	}
}
