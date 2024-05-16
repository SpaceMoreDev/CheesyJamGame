using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;
public class BackToMainmenu : MonoBehaviour
{
    [SerializeField] Button Back;
    [SerializeField] GameObject Options;
    [SerializeField] GameObject MainMenu;
    // Start is called before the first frame update
    void Start()
    {
        Back = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void goingback()
    {
        Back.gameObject.SetActive(false);
        Options.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }
}
