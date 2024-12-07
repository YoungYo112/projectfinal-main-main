using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CoinManager : MonoBehaviour
{
    public int coin;
    public Text coinUI;
    public int targetScore;
    public string nextScene;
    public AudioSource coinSound;

}
