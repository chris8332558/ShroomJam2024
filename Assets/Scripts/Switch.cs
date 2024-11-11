using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class Switch : MonoBehaviour
{
    [SerializeField] KeyCode switchOneKey;
    private BoxCollider2D mCollider;
    private SpriteRenderer mSprite;

    private void Awake()
    {
        mCollider = GetComponent<BoxCollider2D>();
        mSprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        mCollider.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(switchOneKey))
        {
            mCollider.enabled = !mCollider.enabled;	    
		}

        if (!mCollider.enabled)
        {
            mSprite.color = Color.green;
		}
        else 
		{
            mSprite.color = Color.red;
		}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
