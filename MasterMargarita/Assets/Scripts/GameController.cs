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

    public GameObject[] intro;
    public GameObject[] pathA;
    public GameObject[] pathB;

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
            intro[currentSlide].SetActive(true);
            return intro[currentSlide];

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
        intro[0].SetActive(true);
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
}
