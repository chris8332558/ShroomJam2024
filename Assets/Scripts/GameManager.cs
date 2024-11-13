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
    public Switch switch4;
    public Transform cable1;
    public Transform cable2;
    public Transform cable3;
    public Transform cable4;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;


    public Button numCableBtn;
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

    public int numCable = 3;

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

        ChangeToThreeCableSet();
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
        if (numCable == 4) ballSpawnCD *= 0.9f;
        electronPoint = electronPoints[idx];
    }

    public void CheckGameStart()
    {
        if (!isGameStart)
        {
            if ((numCable == 3 && switch1.isTurnedOn && switch2.isTurnedOn && switch3.isTurnedOn) ||
                (numCable == 4 && switch1.isTurnedOn && switch2.isTurnedOn && switch3.isTurnedOn && switch4.isTurnedOn))
            {
                DOTween.Clear();
                SpeedUp(0);
                isGameStart = true;
                startHintText.gameObject.SetActive(false);
                startHintImg.gameObject.SetActive(false);
                numCableBtn.gameObject.SetActive(false);
            }
        }
    }


    public void StopGame()
    {
        ballSpeed = 0;
        isGameOver = true;
        MusicSource.Instance.StopMusic();
	}

    public void SwitchCableSet()
    {
        SFXSource.Instance.PlaySwitchOn();
        if (numCable == 3)
        {
            ChangeToFourCableSet();
		}
        else if (numCable == 4)
        {
            ChangeToThreeCableSet();
		}
	}

    private void ChangeToThreeCableSet()
    {
        cable1.transform.DOLocalMoveX(-3, 0.01f);
        cable2.transform.DOLocalMoveX(0, 0.01f);
        cable3.transform.DOLocalMoveX(3, 0.01f);
        switch1.transform.DOLocalMoveX(-2.32f, 0.01f);
        switch2.transform.DOLocalMoveX(0.682f, 0.01f);
        switch3.transform.DOLocalMoveX(3.68f, 0.01f);
        spawnPoint1.transform.DOLocalMoveX(-3, 0.01f);
        spawnPoint2.transform.DOLocalMoveX(0, 0.01f);
        spawnPoint3.transform.DOLocalMoveX(3, 0.01f);
        switch4.gameObject.SetActive(false);
        cable4.gameObject.SetActive(false);
        spawnPoint4.gameObject.SetActive(false);

        switch1.switchKey = KeyCode.J;
        switch2.switchKey = KeyCode.K;
        switch3.switchKey = KeyCode.L;
        numCable = 3;
    }

    private void ChangeToFourCableSet()
    { 
        cable1.transform.DOLocalMoveX(-4, 0.01f);
        cable2.transform.DOLocalMoveX(-1.5f, 0.01f);
        cable3.transform.DOLocalMoveX(0.5f, 0.01f);
        switch1.transform.DOLocalMoveX(-3.32f, 0.01f);
        switch2.transform.DOLocalMoveX(-0.82f, 0.01f);
        switch3.transform.DOLocalMoveX(1.18f, 0.01f);
        spawnPoint1.transform.DOLocalMoveX(-4f, 0.01f);
        spawnPoint2.transform.DOLocalMoveX(-1.5f, 0.01f);
        spawnPoint3.transform.DOLocalMoveX(0.5f, 0.01f);
        switch4.gameObject.SetActive(true);
        cable4.gameObject.SetActive(true);
        spawnPoint4.gameObject.SetActive(true);

        switch1.switchKey = KeyCode.D;
        switch2.switchKey = KeyCode.F;
        switch3.switchKey = KeyCode.J;
        numCable = 4;
    }
}
