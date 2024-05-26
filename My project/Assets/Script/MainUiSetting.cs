using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUiSetting : MonoBehaviour
{
    public GameObject attackPanel;
    public GameObject defensePanel;
    public GameObject UtillPanel;
    public GameObject PetPanel;

    PlayerScript PlayerScript;
    CreatePet CreatePet;


    public Text weaponAttackContens;
    public Text weaponSpraykContens;
    public Text BoomNumberContens;
    public Text GuidedMissileContens;

    private int weaponAttackUpgradeGold = 100;
    private int weaponSprayUpgradeGold = 3000;
    public static int weaponSprayUpgradeCount = 1;
    public static int BoomNumber = 1;
    private int weaponBoomNumberGold = 3000;


    public Text petNumberContens;
    public Text petAttackContens;
    public Text petAttackCooldownContens;

    public static int petNum = 0;
    private int petNumGold = 5000;
    private int petAttackGold = 2000;
    private int petCooldownGold = 2000;

    private void Start()
    {
        PlayerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        CreatePet = GameObject.Find("Player").GetComponent<CreatePet>();

        setAttackText();
        setPetText();

        attackPanel.SetActive(false);
        defensePanel.SetActive(false);
        UtillPanel.SetActive(false);
        PetPanel.SetActive(false);
    }

    public void setAttackText()
    {
        weaponAttackContens.text = "���ݷ� : " + PlayerScript.playerDamage.ToString();
        weaponSpraykContens.text = "���� : " + PlayerScript.playerSpray.ToString();
        BoomNumberContens.text = "���� : " + BoomNumber.ToString();
    }


    public void UpgradePlayerDamage()
    {
        if (weaponAttackUpgradeGold <= EventManager.gold)
        {
            EventManager.gold -= weaponAttackUpgradeGold;
            PlayerScript.playerDamage += 2;
            weaponAttackContens.text = "���ݷ� : " + PlayerScript.playerDamage.ToString();

        }
    }

    public void UpgradePlayerSpray()
    {
        if (weaponSprayUpgradeCount == 5)
        {
            weaponSpraykContens.text = "�����Դϴ�.";
        }
        else if (weaponSprayUpgradeGold <= EventManager.gold)
        {
            weaponSprayUpgradeCount++;
            EventManager.gold -= weaponSprayUpgradeGold;
            PlayerScript.playerSpray += 1;

            weaponSpraykContens.text = "���� : " + weaponSprayUpgradeCount.ToString();

        }
    }

    public void UpgradePlayerBoomNumbers()
    {
        if (weaponSprayUpgradeCount == 3)
        {
            BoomNumberContens.text = "�����Դϴ�.";
        }
        else if (weaponBoomNumberGold <= EventManager.gold)
        {
            BoomNumber++;
            EventManager.gold -= weaponBoomNumberGold;
            PlayerScript.playerSpray += 1;

            BoomNumberContens.text = "���� : " + BoomNumber.ToString();

        }
    }

    public void setPetText()
    {
        petNumberContens.text = "���� : " + CreatePet.num.ToString();
        petAttackContens.text = "���ݷ� : " + CreatePet.damege.ToString();
        petAttackCooldownContens.text = "��Ÿ�� : " + CreatePet.cooldown.ToString();

    }

    public void PetUpgradeNum()
    {

        if(petNum == 1)
        {
            if (petNumGold <= EventManager.gold)
            {
                EventManager.gold -= petNumGold;
                petNum++;

                CreatePet.num += 1;
                petNumberContens.text = "�����Դϴ�";

            }

        }
        else if(petNum == 0)
        {
            if (petNumGold <= EventManager.gold)
            {
                EventManager.gold -= petNumGold;
                petNum++;

                CreatePet.num += 1;
                petNumberContens.text = "���� : " + CreatePet.num.ToString();

            }
        }
        else
        {
            petNumberContens.text = "�����Դϴ�";

        }

    }

    public void PetUpgradeDamege()
    {
        if (petAttackGold <= EventManager.gold)
        {
            EventManager.gold -= petAttackGold;
            CreatePet.damege += 3;
            petAttackContens.text = "���ݷ� : " + CreatePet.damege.ToString();

        }
    }

    public void PetUpgradeCooldown()
    {
        
        if(CreatePet.cooldown < 9)
        {
            if (petCooldownGold <= EventManager.gold)
            {
                EventManager.gold -= petCooldownGold;
                CreatePet.cooldown += 1;
                petAttackCooldownContens.text = "��Ÿ�� : " + CreatePet.cooldown.ToString();
            }
        }
        else if(CreatePet.cooldown >= 9)
        {
            petAttackCooldownContens.text = "MAX��Ÿ�� : " + CreatePet.cooldown.ToString();
        }
    }

    public void SetAttackPanel()
    {
        if(attackPanel.activeSelf == false)
        {
            defensePanel.SetActive(false);
            UtillPanel.SetActive(false);
            PetPanel.SetActive(false);

            attackPanel.SetActive(true);
        }
        else
        {
            attackPanel.SetActive(false);
        }
    }

    public void SetDefenseWindow()
    {
        if(defensePanel.activeSelf == false)
        {
            attackPanel.SetActive(false);
            UtillPanel.SetActive(false);
            PetPanel.SetActive(false);

            defensePanel.SetActive(true);
        }
        else
        {
            defensePanel.SetActive(false);
        }
    }

    public void SetUtillWindow()
    {
        if (UtillPanel.activeSelf == false)
        {
            attackPanel.SetActive(false);
            defensePanel.SetActive(false);
            PetPanel.SetActive(false);

            UtillPanel.SetActive(true);
        }
        else
        {
            UtillPanel.SetActive(false);
        }
    }

    public void SetPetWindow()
    {
        if (PetPanel.activeSelf == false)
        {
            attackPanel.SetActive(false);
            defensePanel.SetActive(false);
            UtillPanel.SetActive(false);

            PetPanel.SetActive(true);
        }
        else
        {
            PetPanel.SetActive(false);
        }
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Game1");
    }
}

