using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float mSpeed;

    private void Start()
    {
        mSpeed = GameManager.Instance.ballSpeed;
    }

    private void Update()
    {
        transform.position += mSpeed * Time.deltaTime * Vector3.down;
        mSpeed = GameManager.Instance.ballSpeed;
    }
}
