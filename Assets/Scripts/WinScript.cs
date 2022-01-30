using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{

    BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D player)
    {
        Debug.Log("ENTRO EN EL COLIDER DEL COFRE" + player.name);
        if (player != null && player.name == "Player")
        {
            Debug.Log("ENTRO EN EL COLIDER DEL COFRE DENTRO DEL IFFFFFFFFFF" + player.name);
            SceneManager.LoadScene("Victory");
        }
    }
}
