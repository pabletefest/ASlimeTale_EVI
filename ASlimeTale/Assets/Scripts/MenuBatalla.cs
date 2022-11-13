using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBatalla : MonoBehaviour
{

    [SerializeField]
    private GameObject actionSelector;

    [SerializeField]
    private GameObject skillSelector;

    [SerializeField]
    private GameObject itemSelector;

    [SerializeField]
    private Color highlightedColor;

    [SerializeField]
    private List<Text> actionTexts;

    int currentAction = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateActionSelection(currentAction);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentAction == actionTexts.Count - 1)
            {
                currentAction = 0;
            }
            else
            {
                currentAction += 1;
            }
            UpdateActionSelection(currentAction);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction == 0)
            {
                currentAction = actionTexts.Count - 1;
            }
            else
            {
                currentAction -= 1;
            }
            UpdateActionSelection(currentAction);
        }
    }

    public void UpdateActionSelection(int selectedAction)
    {
        for(int i = 0; i<actionTexts.Count; ++i)
        {
            if (i == selectedAction)
            {
                actionTexts[i].color = highlightedColor;
            } else
            {
                actionTexts[i].color = Color.black;
            }
        }
    }


    public void EnableSkillSelection(bool enabled)
    {
        skillSelector.SetActive(enabled);
    }

    public void EnableActionSelection(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }

    public void EnableItmeSelection(bool enabled)
    {
        itemSelector.SetActive(enabled);
    }

    public void EnableMenu(bool enabled)
    {
        gameObject.SetActive(enabled);
    }
}
