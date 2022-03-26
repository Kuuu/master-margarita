using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int currentSlide = 1;
    string currentLetter = "";
    GameObject currentPath;

    string mildMistakeText = "";

    
    public GameObject[] noLetter;
    public GameObject[] pathA;
    public GameObject[] pathB;

    int lastScene = 2;

    // Start is called before the first frame update
    void Start()
    {
        currentPath = ShowScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextSlide()
    {
        HideScene();
        currentSlide++;
        currentPath = ShowScene();
        if (mildMistakeText != "")
        {
            currentPath.transform.Find("Text").GetComponent<Text>().text = mildMistakeText;
            //currentPath.GetComponentInChildren<Text>().text = mildMistakeText;
        }
        mildMistakeText = "";
    }

    public void SetLetter(string letter)
    {
        currentLetter = letter;
        NextSlide();
    }

    GameObject ShowScene()
    {
        if (currentLetter == "")
        {
            noLetter[currentSlide].SetActive(true);
            return noLetter[currentSlide];

        } else if (currentLetter == "a")
        {
            pathA[currentSlide].SetActive(true);
            return pathA[currentSlide];
        }

        return null;
    }

    void HideScene()
    {
        if (currentPath != null)
        {
            currentPath.SetActive(false);
        }
    }

    public void Mistake()
    {
        HideScene();
        noLetter[0].SetActive(true);
    }

    public void MildMistake(string newText)
    {
        mildMistakeText = newText;
        NextSlide();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene >= lastScene)
        {
            return;
        }

        SceneManager.LoadScene(currentScene + 1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenLink(string link)
    {
        Debug.Log(link);
        Application.OpenURL(link);
    }
}
