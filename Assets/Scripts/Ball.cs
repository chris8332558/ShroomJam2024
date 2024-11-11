using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float mSpeed;

    private void Start()
    {
        mSpeed = GameManager.BallSpeed;
    }

    private void Update()
    {
        transform.position += mSpeed * Time.deltaTime * Vector3.down;
    }
}
