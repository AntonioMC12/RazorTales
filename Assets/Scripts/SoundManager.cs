using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip player_hurt, player_hit, player_jump, enemy_hit, enemy_hurt, main_theme;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player_hurt = Resources.Load<AudioClip>("player_hurt");
        player_hit = Resources.Load<AudioClip>("sword");
        player_jump = Resources.Load<AudioClip>("jump");
        enemy_hit = Resources.Load<AudioClip>("fire");
        enemy_hurt = Resources.Load<AudioClip>("enemy_hurt");
        main_theme = Resources.Load<AudioClip>("main");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {

            case "player_hurt":
                audioSource.PlayOneShot(player_hurt);
                break;

            case "sword":
                audioSource.PlayOneShot(player_hit);
                break;

            case "jump":
                audioSource.PlayOneShot(player_jump);
                break;

            case "fire":
                audioSource.PlayOneShot(enemy_hit);
                break;

            case "enemy_hurt":
                audioSource.PlayOneShot(enemy_hurt);
                break;
        }
    }
}
