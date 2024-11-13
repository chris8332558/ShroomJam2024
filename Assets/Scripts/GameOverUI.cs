using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Button restartBtn;
    [SerializeField] Image transitionImg;
    [SerializeField] TMP_Text highScoreText;
    private float finalScore;

    private void Awake()
    {
        restartBtn.gameObject.SetActive(false);
        //highScoreText.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        transform.DOScale(1, 0.2f).OnComplete(() =>
        {
            ShowHighScore();
            MusicSource.Instance.UseChargingClip();
            MusicSource.Instance.PlayMusic();
            DOVirtual.Float(0, finalScore, 3f,
                            v => scoreText.text = v.ToString("00000000")).SetDelay(0.5f)
							    .OnComplete(EnableRestartBtn);


        });
    }

    public void SetScore(float aScore)
    {
        finalScore = aScore;
	}

    public void Restart()
    {
        SFXSource.Instance.PlaySwitchOn();
        SceneLoader.Instance.LoadMain();
	}

    private void ShowHighScore()
    {
        highScoreText.gameObject.SetActive(true);
        highScoreText.text = "High Score: " + PlayerPrefs.GetFloat("HighScore", 0).ToString("00000000");
        Debug.Log("Hight score: " + PlayerPrefs.GetFloat("HighScore").ToString("00000000"));
    }

    private void UpdateHighScore()
    {
        if (finalScore > PlayerPrefs.GetFloat("HighScore", 0))
        {
            SFXSource.Instance.PlayCountingClip();
            PlayerPrefs.SetFloat("HighScore", finalScore);
            highScoreText.text = "High Score: " + finalScore.ToString("00000000");
        }
    }

    private void EnableRestartBtn()
    {
        MusicSource.Instance.StopMusic();
        UpdateHighScore();
        restartBtn.gameObject.SetActive(true);
        Image img = restartBtn.GetComponent<Image>();
        img.DOFade(0.2f, 0.8f).OnComplete(()=> {
            img.DOFade(0.8f, 0.8f);
		}).SetLoops(-1, LoopType.Yoyo);
	}

}
