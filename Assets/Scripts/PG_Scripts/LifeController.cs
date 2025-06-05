using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{

    [SerializeField] int _currentHp = 100;
    [SerializeField] int _maxHp = 100;

    public int GetHp() => _currentHp;
    public int GetmaxHp() => _maxHp;
    public bool _fullHpOnStart = true;



    public void AddHp(int amount) => SetHp(_currentHp + amount);

    public void RemoveHp(int amount) => SetHp(_currentHp - amount);

  

    void SetHp(int hp)
    {

        hp = Mathf.Clamp(hp, 0, _maxHp);
        _currentHp = hp;
        CheckDeath(); // Controlla se il personaggio è morto dopo aver impostato l'hp

    }

    private void SetMaxHp(int maxHp)
    {
        _maxHp = Mathf.Max(maxHp, 1);
        SetHp(_currentHp); // Assicura che l'hp corrente non superi il nuovo maxHp
    }

    void CheckDeath()
    {
        if (_currentHp <= 0)
        {
            Debug.Log("Il personaggio è morto");
            Destroy(gameObject); // Distrugge l'oggetto se la vita è zero o meno
        }
    }


    void Start()
    {
        if (_fullHpOnStart)

        {
            SetHp(_maxHp); // Imposta la vita corrente al massimo all'inizio
        }
    }
}
