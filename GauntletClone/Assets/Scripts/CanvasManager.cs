using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    //Warrior Texts
    public Text warriorHealth;
    public Text warriorScore;
    public Text warriorKeys;
    public Text warriorPotions;

    //Valkyrie Texts
    public Text valkyrieHealth;
    public Text valkyrieScore;
    public Text valkyrieKeys;
    public Text valkyriePotions;

    //Wizard Texts
    public Text wizardHealth;
    public Text wizardScore;
    public Text wizardKeys;
    public Text wizardPotions;

    //Elf Texts
    public Text elfHealth;
    public Text elfScore;
    public Text elfKeys;
    public Text elfPotions;

    //assign objects at start
    public GameObject warriorPlayer;
    public GameObject valkyriePlayer;
    public GameObject wizardPlayer;
    public GameObject elfPlayer;

    // Start is called before the first frame update
    void Start()
    {
        warriorPlayer = GameObject.Find("Warrior");
        valkyriePlayer = GameObject.Find("Valkyrie");
        wizardPlayer = GameObject.Find("Wizard");
        elfPlayer = GameObject.Find("Elf");
    }

    // Update is called once per frame
    void Update()
    {
        //Warrior
        warriorHealth.text = "Health: " + warriorPlayer.gameObject.GetComponent<Warrior>().playerHealth;
        warriorScore.text = "Score: " + warriorPlayer.gameObject.GetComponent<Warrior>().playerScore;
        warriorKeys.text = "Keys: " + warriorPlayer.gameObject.GetComponent<Warrior>().keys;
        warriorPotions.text = "Potions: " + warriorPlayer.gameObject.GetComponent<Warrior>().potions;

        //Valkyrie
        valkyrieHealth.text = "Health: " + valkyriePlayer.gameObject.GetComponent<Valkyrie>().playerHealth;
        valkyrieScore.text = "Score: " + valkyriePlayer.gameObject.GetComponent<Valkyrie>().playerScore;
        valkyrieKeys.text = "Keys: " + valkyriePlayer.gameObject.GetComponent<Valkyrie>().keys;
        valkyriePotions.text = "Potions: " + valkyriePlayer.gameObject.GetComponent<Valkyrie>().potions;

        //Wizard
        wizardHealth.text = "Health: " + wizardPlayer.gameObject.GetComponent<Wizard>().playerHealth;
        wizardScore.text = "Score: " + wizardPlayer.gameObject.GetComponent<Wizard>().playerScore;
        wizardKeys.text = "Keys: " + wizardPlayer.gameObject.GetComponent<Wizard>().keys;
        wizardPotions.text = "Potions: " + wizardPlayer.gameObject.GetComponent<Wizard>().potions;

        //Elf
        elfHealth.text = "Health: " + elfPlayer.gameObject.GetComponent<Elf>().playerHealth;
        elfScore.text = "Score: " + elfPlayer.gameObject.GetComponent<Elf>().playerScore;
        elfKeys.text = "Keys: " + elfPlayer.gameObject.GetComponent<Elf>().keys;
        elfPotions.text = "Potions: " + elfPlayer.gameObject.GetComponent<Elf>().potions;
    }
}
