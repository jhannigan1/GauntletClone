using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public List<GameObject> attachedDoors;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Elf" && Elf.elf.keys > 0)
        {
            Elf.elf.keys -= 1;
            OpenDoors();
        }
        if (other.tag == "Valkyrie" && Valkyrie.valkyrie.keys > 0)
        {
            Valkyrie.valkyrie.keys -= 1;
            OpenDoors();
        }
        if (other.tag == "Warrior" && Warrior.warrior.keys > 0)
        {
            Warrior.warrior.keys -= 1;
            OpenDoors();
        }
        if (other.tag == "Wizard" && Wizard.wizard.keys > 0)
        {
            Wizard.wizard.keys -= 1;
            OpenDoors();
        }
    }

    public void OpenDoors()
    {
        foreach (GameObject door in attachedDoors)
        {
            Destroy(door.gameObject);
        }
        Destroy(this.gameObject);
    }
}
