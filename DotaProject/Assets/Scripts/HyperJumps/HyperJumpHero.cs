using System;
using UnityEngine;

public class HyperJumpHero : MonoBehaviour
{
    [SerializeField] int cost;
    [SerializeField] Animator _mainTitleAnimator;
    [SerializeField] ParticleSystem _portal;
    private HeroSO[] herosList;
    public static Action<HeroSO> setHero;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        herosList = SODataLoader.LoadAllHerosSO();
    }

    public void HyperJumpStart()
    {
        if(Wallet.Coins < cost)
        {
            return;
        }
        else
        {
            Wallet.AddCoins(-cost);
        }
        _mainTitleAnimator.SetBool("JumpStart",true);
        _mainTitleAnimator.SetBool("JumpEnd", false);
        _portal.Play();
        var hero = herosList[UnityEngine.Random.Range(0, herosList.Length)];
        setHero?.Invoke(hero);
    }

    public void HyperJumpEnd()
    {
        _mainTitleAnimator.SetBool("JumpStart", false);
        _mainTitleAnimator.SetBool("JumpEnd", true);
        _portal.Stop();
    }
}
