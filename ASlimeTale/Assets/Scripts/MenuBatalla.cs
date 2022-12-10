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

    [SerializeField]
    private List<Text> skillTexts;

    int currentAction = 0;
    enum menuType
    {
        ACTION,
        SKILL,
        ITEM
    }
    menuType menuOpen = menuType.ACTION;


    // Start is called before the first frame update
    void Start()
    {
        UpdateActionSelection(currentAction);
    }

    // Update is called once per frame
    void Update()
    {
        if(menuOpen == menuType.ACTION) {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (currentAction == actionTexts.Count - 1)
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentAction == 1)
                {
                    EnableActionSelection(false);
                    EnableSkillSelection(true);
                    SetSkillText();
                    menuOpen = menuType.SKILL;
                    currentAction = 0;
                }
                if (currentAction == 4)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
                    Cursor.visible = true;
                }
            }
        }
        if(menuOpen == menuType.SKILL)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (currentAction == actionTexts.Count - 1)
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
                UpdateSkillSelection(currentAction);
            }
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

    public void UpdateSkillSelection(int selectedAction)
    {
        for (int i = 0; i < actionTexts.Count; ++i)
        {
            if (i == selectedAction)
            {
                skillTexts[i].color = highlightedColor;
            }
            else
            {
                skillTexts[i].color = Color.black;
            }
        }
    }

    public void SetSkillText()
    {
        Dictionary<string, SkillData> skills = DataManager.InstanceDB.getTeamMemberByName("Slime").Skills;
        List<string> skillNames = new List<string>(skills.Keys);
        int skillNumber = skillNames.Count;
        if (skillNumber >= 4)
        {
            skillTexts[0].text = skillNames[0];
            skillTexts[1].text = skillNames[1];
            skillTexts[2].text = skillNames[2];
            skillTexts[3].text = skillNames[3];
        }
        else if (skillNumber == 3)
        {
            skillTexts[0].text = skillNames[0];
            skillTexts[1].text = skillNames[1];
            skillTexts[2].text = skillNames[2];
            skillTexts[3].text = "";
        }
        else if (skillNumber == 2)
        {
            skillTexts[0].text = skillNames[0];
            skillTexts[1].text = skillNames[1];
            skillTexts[2].text = "";
            skillTexts[3].text = "";

        }
        else if (skillNumber == 1)
        {
            skillTexts[0].text = skillNames[0];
            skillTexts[1].text = "";
            skillTexts[2].text = "";
            skillTexts[3].text = "";
        }
        else if (skillNumber == 0)
        {
            skillTexts[0].text = "No hay habilidades desbloqueadas.";
            skillTexts[1].text = "";
            skillTexts[2].text = "";
            skillTexts[3].text = "";

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
