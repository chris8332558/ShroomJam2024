using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance{ get; private set; }
    [SerializeField] Image transitionImg;

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

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadMain()
    {
        Debug.Log("Load Main");
        transitionImg.transform.DOScale(30f, 1.5f);
        transitionImg.DOColor(Color.black, 1.5f).OnComplete(() =>
        {
            transitionImg.transform.DOScale(0f, 0.01f);
            transitionImg.DOColor(Color.white, 0.01f);
            SceneManager.LoadScene("Main");
        });
    }
}
