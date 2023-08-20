using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public abstract class EntityScreen : MonoBehaviour
{
    //скрипт экрана геро€
    //если добавл€ю новые элементы и тд, об€зательно добавить к ним иконки
    [Header("\t\t   General")]
    [SerializeField] Image entityIcon;
    [SerializeField] Image entityConceptSprite;
    [SerializeField] TextMeshProUGUI heroNameText;
    [SerializeField] TextMeshProUGUI elementEntityText;
    [SerializeField] public Image iconAbillityPrefab;
    [SerializeField] public RectTransform summonContentPrefab; 
    [SerializeField] public RectTransform contentField;
    [SerializeField] public Canvas canvasForSpells;
    [Header("\t\tAttack/Weapon")]
    [SerializeField] TextMeshProUGUI typeAttackText;
    [SerializeField] TextMeshProUGUI elementAttackText;
    [SerializeField] Image elementAttackImage;
    [SerializeField] TextMeshProUGUI weaponText;
    [SerializeField] TextMeshProUGUI weaponTypeText;
    [SerializeField] Image attackIcon;

    private void Start()
    {
        EventManager.SwitchMenu += SetNormalScale;
    }

    public void CreateEntity(Entity entity, Transform parent, float yCoordinate)
    {
        //
        // —оздаем канвас дл€ нормального отображени€ 
        Canvas canvas = Instantiate(canvasForSpells, parent);
        //

        entityIcon.sprite = entity.GetIcon();
        heroNameText.text = entity.GetName();

        entityConceptSprite.sprite = entity.GetConceptSprite();

        elementEntityText.text = IconLoader.LoadSmile(entity.GetElement()) + Localizator.Localize(entity.GetElement().ToString());

        typeAttackText.text = Localizator.Localize("TypeAttack") + IconLoader.LoadSmile(entity.GetAttackType()) + Localizator.Localize(entity.GetAttackType().ToString());

        weaponText.text = Localizator.Localize("WeaponText") + Localizator.Localize(entity.GetWeapon().ToString());
        weaponTypeText.text = Localizator.Localize("WeaponType") + Localizator.Localize(entity.GetWeaponType().ToString());
        attackIcon.sprite = IconLoader.LoadIcon(entity.GetWeapon());

        elementAttackText.text = Localizator.Localize("ElementOfAttack") + IconLoader.LoadSmile(entity.GetAttackElement()) + Localizator.Localize(entity.GetAttackElement().ToString());


        for (int skillId = 0; skillId < entity.skills.Length; skillId++) //создаю иконки способностей в зависимости от их количества
        {
            CreateSpell(entity.skills, skillId, yCoordinate, parent, canvas);
        }

        yCoordinate -= 300;

        for (int skillId = 0; skillId < entity.nonCombatSkills.Length; skillId++) //создаю иконки способностей в зависимости от их количества
        {
            CreateSpell(entity.nonCombatSkills, skillId, yCoordinate, parent, canvas);
        }
    }

    public virtual void CreateHero(Hero hero)
    {
        float posY = -1117f;
        CreateEntity(hero, contentField.transform, posY);        
    }

    public void CreateSpell(WikiSkill[] skills, int skillId, float yCoordinate, Transform parent, Canvas canvas)
    {
        Image gate;
        gate = Instantiate(iconAbillityPrefab, gameObject.transform);
        gate.rectTransform.SetParent(parent, false);

        gate.GetComponent<WikiSkill>().SetSkill(skills[skillId]);

        gate.GetComponent<WikiSkill>().canvasForSkillPanel = canvas;

        if(skills[skillId].GetBool_IsHasSummons())
        {
            List<Summon> summons = new List<Summon>();
            summons = skills[skillId].GetListSummons();
            foreach (var summon in summons)
            {
                CreateSummon(summon);
            }
        }
        gate.sprite = gate.GetComponent<WikiSkill>().GetIcon();
        gate.transform.localPosition = CalcCoordForSpell(skills.Length, skillId, yCoordinate);
                
    }

    private void CreateSummon(Summon summon)
    {
        float posY = -1000;
        RectTransform summonContent;
        summonContent = Instantiate(summonContentPrefab, contentField);
        contentField.sizeDelta += new Vector2(0, 1300);
        summonContent.transform.localPosition = new Vector2(0, EventManager.yForSummonsContentfield);

        summonContent.GetComponent<SummonWiki>().CreateEntity(summon,summonContent,posY);

        EventManager.yForSummonsContentfield -= EventManager.deltaForY;
    }

    private Vector2 CalcCoordForSpell(int numberOfAbilities, int spellNumber, float posY)
    {
        #region Magic Numbers
        float startX = 950f;
        float deltaForStartCoord = 91.7f;
        float offsetX = 170f;
        float numberOfSpells = numberOfAbilities - 1;

        float deltaX = offsetX * spellNumber;
        float posX = startX - (numberOfSpells * deltaForStartCoord);
        #endregion

        return new Vector2(posX + deltaX, posY);
    }

    private void SetNormalScale ()
    {
        contentField.sizeDelta = new Vector2 (0, 2000);
    }

    private void OnDestroy()
    {
        EventManager.SwitchMenu -= SetNormalScale;
    }


}
