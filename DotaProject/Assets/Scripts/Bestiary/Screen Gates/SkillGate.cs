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
    [SerializeField,Tooltip("Присваивается только для префаба")] SkillPanel panelPrefab;

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
            // создаю иконку скила и присваиваю все нужные атрибуты
            //
            gate = Instantiate(skillGatePrefab.GetComponent<Image>(), gameObject.transform);
            gate.rectTransform.SetParent(gameObject.transform.parent, false);
            gate.GetComponent<SkillGate>().canvasForSkillPanel = canvasForSkillPanel;
            gate.GetComponent<SkillGate>().skill = skill;
            gate.sprite = skill.skillIcon;

            //
            // если скилл создает несколько скилов - они все подписываются на эвент "удаления других скиллов"
            // так же координаты каждого скилла подвигаются вправо по формуле: координата этой ячейки + (170 * номер скилла), где 170 - константа
            //
            if (otherSkills.Count > 1)
            {
                gate.transform.localPosition = gameObject.transform.localPosition + new Vector3(deltaForX, 0, 0);
                EventController.DestroyOtherSkills += gate.GetComponent<SkillGate>().Destroy;
                //Destroy(gameObject);
            }
            //
            // если скилл перенаправляет на дефолтный, он вызывает эвент удаления других скиллов
            // если скилл создавал один скилл, то эвент ничего не будет делать, а сам обьект удалится
            // return прерывает цикл, потому что дальше код не должен выполнятся
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
