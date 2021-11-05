using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int currentSlide = 1;
    string currentLetter = "";
    GameObject currentPath;

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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
