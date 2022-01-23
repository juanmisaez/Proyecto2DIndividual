using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCapataz : CollisionSystem
{
    public bool isCutsceneOn;
    public Animator camAnim; // la camara
    public DialogueTrigger _dialogueTrigger;

    private bool bag;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (bag == false)
        {
            isCutsceneOn = true;
            camAnim.SetBool("cutscene1", true);
            //_dialogueTrigger.TriggerDialogue();
        }
    }

    public void StopCutscene()
    {
        isCutsceneOn = false;
        camAnim.SetBool("cutscene1", false);        
    }

    void BagFull()
    {
        bag = true;
    }

    void BagEmpty()
    {
        bag = false;
    }

    void OnEnable()
    {
        InventorySystem.InventoryFull += BagFull;
    }

    void OnDisable()
    {
        InventorySystem.InventoryFull -= BagFull;
    }
}