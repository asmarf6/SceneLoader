using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;


public class TestPlayMode
{
    private Text quote;

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator LoadScene()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        // Use the Assert class to test conditions
        Scene test = SceneManager.GetActiveScene();
        yield return SceneManager.LoadSceneAsync("Scene2");

    }

    [UnityTest]
    public IEnumerator LoadQuotationFromFile()
    {

        TextHandler th = Object.FindObjectOfType<TextHandler>();
        Assert.IsNotNull(th, "Texthandler object is null");

        yield return new WaitForSeconds(0.1f);

        quote.text = th.ReadData("quote");
        yield return quote.text;
    }
}

