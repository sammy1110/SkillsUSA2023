using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    public enum Levels {one, two, three}
    public Levels currentLevel = Levels.one;

    Dialog dialog;
    SceneSwitcher sceneSwitcher;

    // Start is called before the first frame update
    void Start()
    {
        dialog = GetComponent<Dialog>();
        sceneSwitcher= GetComponent<SceneSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel == Levels.one && Inventory.hasBook)
        {
            sceneSwitcher.enabled = true;
            dialog.enabled = false;
            Destroy(dialog.dialoguePanel);
        }
    }

}
