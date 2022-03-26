using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public InputField levelField;
    public GameObject startScreen;
    public GameObject levelSelectScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LevelSelect()
    {
        startScreen.SetActive(false);
        levelSelectScreen.SetActive(true);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartLevel()
    {
        int level;
        int[] availableLevels = {1, 2, 3, 4};
        bool parsed = int.TryParse(levelField.text, out level);
        if (parsed)
        {
            Debug.Log(level);
            bool containsNumber = false;

            foreach (int n in availableLevels)
            {
                if (n == level)
                {
                    containsNumber = true;
                    break;
                }
            }

            if (containsNumber)
            {
                SceneManager.LoadScene(level);
            }
        }
    }
}
