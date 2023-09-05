using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class SkillGate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SkillSO skill;
    [SerializeField] SkillGate skillGatePrefab;
    [SerializeField,Tooltip("������������� ������ ��� �������")] SkillPanel panelPrefab;

    //another
    private EntityScreen entityScreen;
    bool THIS_SKILL_ICON = false;
    static SkillPanel panel;
    [HideInInspector] public Canvas canvasForSkillPanel;

    public void Instantiate(EntityScreen entityScreen)
    {
        this.entityScreen = entityScreen;
        gameObject.name = skill.skillName;
        if (!ThisEntityOrArtifact())
        {
            EventController.SwitchMenu += Destroy;
        }
        if (panelPrefab != null)
        {
            THIS_SKILL_ICON = true;
        }
    }

    public void ClickButton()
    {
        if (skill.IsHasSomeSkills)
        {
            CreateOtherSpells(skill.otherSkills);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (THIS_SKILL_ICON)
        {
            CreatePanel();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (THIS_SKILL_ICON)
        {
            DestroyPanel();
        }
    }

    public void CreateOtherSpells(List<SkillSO> otherSkills)
    {
        int indexOfSkill = 0;

        foreach (var skill in otherSkills)
        {
            Image gate;
            int deltaForX = 170 * indexOfSkill;
            //
            // ������ ������ ����� � ���������� ��� ������ ��������
            //
            gate = Instantiate(skillGatePrefab.GetComponent<Image>(), gameObject.transform);
            gate.rectTransform.SetParent(gameObject.transform.parent, false);
            gate.GetComponent<SkillGate>().canvasForSkillPanel = canvasForSkillPanel;
            gate.GetComponent<SkillGate>().skill = skill;
            gate.sprite = skill.skillIcon;

            //
            // ���� ����� ������� ��������� ������ - ��� ��� ������������� �� ����� "�������� ������ �������"
            // ��� �� ���������� ������� ������ ����������� ������ �� �������: ���������� ���� ������ + (170 * ����� ������), ��� 170 - ���������
            //
            if (otherSkills.Count > 1)
            {
                gate.transform.localPosition = gameObject.transform.localPosition + new Vector3(deltaForX, 0, 0);
                EventController.DestroyOtherSkills += gate.GetComponent<SkillGate>().Destroy;
                //Destroy(gameObject);
            }
            //
            // ���� ����� �������������� �� ���������, �� �������� ����� �������� ������ �������
            // ���� ����� �������� ���� �����, �� ����� ������ �� ����� ������, � ��� ������ ��������
            // return ��������� ����, ������ ��� ������ ��� �� ������ ����������
            //
            else
            {
                gate.transform.localPosition = gameObject.transform.localPosition;
                EventController.OnDestroyOtherSkills();
                Destroy(gameObject);
                return;
            }
            indexOfSkill++;
        }
        Destroy(gameObject);
    }

    
    public void CreatePanel()
    {
        DestroyPanel();
        panel = Instantiate(panelPrefab);
        panel.SetSkillInPanel(skill,transform, canvasForSkillPanel,3.5f);
        CheckDownBorder(transform, panel);
    }
    
    public void CheckDownBorder(Transform point, SkillPanel panel)
    {
        float offset = 200f;
        float height = Math.Abs(point.localPosition.y) + panel.Background.sizeDelta.y;
        if (height>entityScreen.ContentField.sizeDelta.y)
        {
            panel.transform.position = new Vector3(panel.transform.position.x, point.position.y);
            panel.transform.localPosition += new Vector3(0, panel.Background.sizeDelta.y-offset);
        }
    }

    public void DestroyPanel()
    {
        if (panel != null)
        {
            panel.Destroy();
        }
    }

    
    private bool ThisEntity()
    {
        if(gameObject.GetComponent<HeroGate>() != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private bool ThisArtifact()
    {
        if (gameObject.GetComponent<ArtifactGate>() != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private bool ThisEntityOrArtifact()
    {
        if (ThisArtifact() || ThisEntity())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    
    public void Destroy()
    {
        if(!ThisEntityOrArtifact())
        {
            Destroy(gameObject);
        }
    }
    
    private void OnDestroy()
    {
        if(!ThisEntity())
        {
            EventController.SwitchMenu -= Destroy;
            EventController.DestroyOtherSkills -= Destroy;
        }
    }

}
