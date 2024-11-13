using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; private set; }

    [Header("5 Speed Up")]
    public float[] ballSpawnCDs = new float[5];
    public float[] electronPoints = new float[5];
    public float[] ballSpeeds = new float[5];

    public Switch switch1;
    public Switch switch2;
    public Switch switch3;
    public TMP_Text startHintText;
    public Image startHintImg;

    public float ballSpeed;
    public float ballSpawnCD;
    public float electronPoint;
    public float timer = 60f;
    //public float timer = 0f;

    //private bool Pass15Sec;
    //private bool Pass10Sec;
    private bool isGameStart;
    private bool isGameOver;
    private bool speedUp1;
    private bool speedUp2;
    private bool speedUp3;
    private bool speedUp4;
    private bool speedUp5;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    private void OnEnable()
    {
        //DOTween.SetTweensCapacity(3125, 50);
        //EventManager.GameOver.AddListener(OnGameOver);
    }

    private void Start()
    {
        startHintText.gameObject.SetActive(true);
        startHintImg.gameObject.SetActive(true);
        startHintImg.DOFade(0.3f, 0.8f).OnComplete(() =>
        {
            startHintImg.DOFade(1f, 0.8f);
        }).SetLoops(-1, LoopType.Yoyo);
        
        ballSpeed = 0;
        ballSpawnCD = Mathf.Infinity;
    }

    private void Update()
    {
        CheckGameStart();
        if (!isGameStart) return;
        if (!isGameOver)
        {
            timer = Mathf.Clamp(timer - Time.deltaTime, 0, 60f);
            if (!speedUp1 && timer <= 50f)
            {
                SpeedUp(1);
                speedUp1 = true;
            }
            else if (!speedUp2 && timer <= 40f)
            {
                SpeedUp(2);
                speedUp2 = true;
            }
            else if (!speedUp3 && timer <= 30f)
            {
                SpeedUp(3);
                speedUp3 = true;
            }
            else if (!speedUp4 && timer <= 20f)
            {
                SpeedUp(4);
                speedUp4 = true;
            }
            else if (!speedUp5 && timer <= 10f)
            {
                SpeedUp(5);
                speedUp5 = true;
            }
        }
    }

    private void SpeedUp(int idx)
    {
        ballSpeed = ballSpeeds[idx];
        ballSpawnCD = ballSpawnCDs[idx];
        electronPoint = electronPoints[idx];
    }

    public void CheckGameStart()
    {
        if (!isGameStart)
        {
            if (switch1.isTurnedOn && switch2.isTurnedOn && switch3.isTurnedOn)
            {
                DOTween.Clear();
                SpeedUp(0);
                isGameStart = true;
                startHintText.gameObject.SetActive(false);
                startHintImg.gameObject.SetActive(false);
			}
        }
    }

    public void StopGame()
    {
        ballSpeed = 0;
        isGameOver = true;
        MusicSource.Instance.StopMusic();
	}
}
