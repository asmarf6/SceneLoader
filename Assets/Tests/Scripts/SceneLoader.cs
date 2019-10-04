using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    private bool loadScene = false;
    public string LoadingSceneName;
    public Text loadingText;
    public Text quoteText;
    public Slider sliderBar;
    public GameObject quotation;   
    public Image img;
    public Animator anim;

    // Use this for initialization
    void Start()
    {

        //Hide Slider Progress Bar in start
        sliderBar.gameObject.SetActive(false);
        // show hint
        quoteText.text = quotation.GetComponent<TextHandler>().ReadData("tip");
    }

   
    /// <summary>
    /// Load new scene on button click
    /// </summary>
    public void LoadScene()
    {
        // If the player pressed Start training button, load the new scene..
        if (loadScene == false)
        {

            // ...set the loadScene boolean to true to prevent loading a new scene more than once...
            loadScene = true;

            //Visible Slider Progress bar
            sliderBar.gameObject.SetActive(true);

            // ...change the instruction text to read "Loading..."
            loadingText.text = "Loading...";

            //Get quotation from file and load in textfield while the main screen loads
            quoteText.text = quotation.GetComponent<TextHandler>().ReadData("quote");

            // ...and start a coroutine that will load the desired scene.
            StartCoroutine(LoadNewScene(LoadingSceneName));

        }
    }

    /// <summary>
    /// The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    /// </summary>
    /// <param name="sceneName">scene name</param>
    /// <returns></returns>
    IEnumerator LoadNewScene(string sceneName)
    {
        yield return new WaitForSeconds(2f);
        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            sliderBar.value = progress;
            loadingText.text = progress * 100f + "%";            
            //Play animation 
            StartCoroutine(Fade());           
            yield return null;

        }

    }
    /// <summary>
    /// This coroutine plays fade animation
    /// </summary>
    /// <returns></returns>
    IEnumerator Fade()
    {
        anim.enabled = true;
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => img.color.a == 1);

    }
}
