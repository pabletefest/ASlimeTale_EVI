using System;
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
    enum MenuType
    {
        ACTION,
        SKILL,
        ITEM
    }
    MenuType menuOpen = MenuType.ACTION;

    public event Action<string> onSkillSelected;

    public event Action onAttackSelected;

    public string currentPlayerName = "Slime";

    // Start is called before the first frame update
    void Start()
    {
        UpdateActionSelection(currentAction);
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerInput();
    }

    void CheckPlayerInput()
    {
        if (menuOpen == MenuType.ACTION)
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
                UpdateActionSelection(currentAction);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(currentAction == 0)
                {
                    onAttackSelected?.Invoke();
                }
                if (currentAction == 1)
                {
                    EnableActionSelection(false);
                    EnableSkillSelection(true);
                    SetSkillText();
                    menuOpen = MenuType.SKILL;
                    currentAction = 0;
                    UpdateSkillSelection(currentAction, true);
                }
                if (currentAction == 4)
                {
                    Cursor.visible = true;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
                }
            }
        }
        else if (menuOpen == MenuType.SKILL)
        {
            Dictionary<string, SkillData> skills = DataManager.InstanceDB.getTeamMemberByName(currentPlayerName).Skills;
            List<string> skillNames = new List<string>(skills.Keys);
            int skillNumber = skillNames.Count;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (currentAction == skillNumber - 1)
                {
                    currentAction = 0;
                }
                else
                {
                    currentAction += 1;
                }
                if (skillNumber == 0) UpdateSkillSelection(currentAction, true);
                else UpdateSkillSelection(currentAction, false);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (currentAction == 0)
                {
                    currentAction = skillNumber - 1;
                }
                else
                {
                    currentAction -= 1;
                }
                if (skillNumber == 0) UpdateSkillSelection(currentAction, true);
                else UpdateSkillSelection(currentAction, false);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                onSkillSelected?.Invoke(skillTexts[currentAction].text);
            }
        }
    }

    public void SetCurrentPlayerName(string playerName)
    {
        currentPlayerName = playerName;
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

    public void UpdateSkillSelection(int selectedAction, bool noSkills)
    {
        if (noSkills)
        {
            skillTexts[0].color = highlightedColor;
        }
        else
        {
            for (int i = 0; i < skillTexts.Count; ++i)
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
    }

    public void SetSkillText()
    {
        Debug.Log($"Current player {currentPlayerName}");
        Dictionary<string, SkillData> skills = DataManager.InstanceDB.getTeamMemberByName(currentPlayerName).Skills;
        List<string> skillNames = new List<string>(skills.Keys);
        int skillNumber = skillNames.Count;
        if (skillNumber >= 4)
        {
            for(int i = 0; i < 4; i++)
			{
                if (!skillNames[i].Equals("Ataque"))
                    skillTexts[i].text = skillNames[i];
                else
                {
                    skillTexts[i].text = "";
                    skillNumber -= 1;
                }
			}
        }
        else if (skillNumber == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                if (!skillNames[i].Equals("Ataque"))
                    skillTexts[i].text = skillNames[i];
                else
                {
                    skillTexts[i].text = "";
                    skillNumber -= 1;
                }
            }
            skillTexts[3].text = "";
        }
        else if (skillNumber == 2)
        {
            for (int i = 0; i < 2; i++)
            {
                if (!skillNames[i].Equals("Ataque"))
                    skillTexts[i].text = skillNames[i];
                else
                {
                    skillTexts[i].text = "";
                    skillNumber -= 1;
                }
            }
            skillTexts[2].text = "";
            skillTexts[3].text = "";

        }
        else if (skillNumber == 1)
        {
            if (!skillNames[0].Equals("Ataque"))
                skillTexts[0].text = skillNames[0];
            else
            {
                skillTexts[0].text = "";
                skillNumber -= 1;
            }
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
        UpdateActionSelection(currentAction);
        menuOpen = MenuType.ACTION;
    }

    public void ResetBattleMenu()
    {
        actionSelector.SetActive(true);
        skillSelector.SetActive(false);
        itemSelector.SetActive(false);

        menuOpen = MenuType.ACTION;
    }
}
