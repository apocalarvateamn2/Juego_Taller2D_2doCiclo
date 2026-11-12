using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public static Fade Instance;
    [SerializeField] private GameObject fadePrefab;
    private CanvasGroup group;
    private string sceneToLoad;
    private bool isFading = false;

    private void Start()
    {
        GameObject panel = Instantiate(fadePrefab);
        group = panel.GetComponentInChildren<CanvasGroup>();
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        if (isFading) return;
        sceneToLoad = sceneName;
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        group.alpha = 1;
        while (group.alpha > 0)
        {
            group.alpha -= Time.deltaTime * 0.5f;
            yield return null;
        }
        group.alpha = 0;
    }

    IEnumerator FadeOut()
    {
        isFading = true;
        group.alpha = 0;
        while (group.alpha < 1)
        {
            group.alpha += Time.deltaTime * 0.5f;
            yield return null;
        }
        group.alpha = 1;
        SceneManager.LoadScene(sceneToLoad);
    }
}
