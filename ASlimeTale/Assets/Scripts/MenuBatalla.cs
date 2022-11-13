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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
