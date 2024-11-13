using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] Ball[] ballPrefabs; 
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnCD;
    [SerializeField] float spawnCDTimer;

    private void OnEnable()
    {
        EventManager.GameOver.AddListener(OnGameOver);
    }

    private void Update()
    {
        spawnCD = GameManager.Instance.ballSpawnCD;
        spawnCDTimer += Time.deltaTime;
        if (spawnCDTimer > spawnCD)
        {
            Spawn();
		}
    }

    public void Spawn()
    {
        Ball ball = GetRandomBall();
        Transform randomSpawnPoint = GetRandomSpawnPoint();
        Ball instance = Instantiate(ball, randomSpawnPoint.position, Quaternion.identity);
        spawnCDTimer = 0;
	}

    private Transform GetRandomSpawnPoint()
    {
        int idx = Random.Range(0, spawnPoints.Length);
        return spawnPoints[idx];
	}

    private Ball GetRandomBall()
    {
        int idx = Random.Range(0, ballPrefabs.Length);
        return ballPrefabs[idx];
	}

    private void OnGameOver()
    {
        gameObject.SetActive(false);
	}
}
