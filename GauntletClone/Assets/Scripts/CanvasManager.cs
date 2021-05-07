using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Text level;
    public Text elfHealth;
    public Text elfScore;
    public Text warriorHealth;
    public Text warriorScore;
    public Text wizardHealth;
    public Text wizardScore;
    public Text valkyrieHealth;
    public Text valkyrieScore;

    GameObject elf;
    GameObject warrior;
    GameObject wizard;
    GameObject valkyrie;

    void Start()
    {
        elf = GameObject.Find("Elf");
        warrior = GameObject.Find("Warrior");
        wizard = GameObject.Find("Wizard");
        valkyrie = GameObject.Find("Valkyrie");
    }

    // Update is called once per frame
    void Update()
    {
        //find way to sync with levels
        level.text = "Level " + 1;
        
        elfHealth.text = "Health: " + elf.gameObject.GetComponent<Elf>().playerHealth;
        elfScore.text = "Score: " + elf.gameObject.GetComponent<Elf>().playerScore;
        warriorHealth.text = "Health: " + warrior.gameObject.GetComponent<Warrior>().playerHealth;
        warriorScore.text = "Score: " + warrior.gameObject.GetComponent<Warrior>().playerScore;
        wizardHealth.text = "Health: " + wizard.gameObject.GetComponent<Wizard>().playerHealth;
        wizardScore.text = "Score: " + wizard.gameObject.GetComponent<Wizard>().playerScore;
        valkyrieHealth.text = "Health: " + valkyrie.gameObject.GetComponent<Valkyrie>().playerHealth;
        valkyrieScore.text = "Score: " + valkyrie.gameObject.GetComponent<Valkyrie>().playerScore;
    }
}
