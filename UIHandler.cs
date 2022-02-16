using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private Login_Register_Handler login_Register;


    [Header("Panels")]
    //Panels
    public GameObject SignUpPanel;
    public GameObject SignInPanel;
    public GameObject ProfilePanel;
    public GameObject MoreOptions;


    //Animator
    public Animator MoreOptionsAnim;


    [Header("Profile Elements")]
    public InputField Profile_Username;
    public InputField Profile_Email;

    

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        CloseAllPanels();
        SignUpPanel.SetActive(true);

       
    }

    public void OpenSignUpPanel()
    {
        CloseAllPanels();
        SignUpPanel.SetActive(true);
    }


    public void OpenSignInPanel()
    {
        CloseAllPanels();
        SignInPanel.SetActive(true);
    }


    public void OpenProfilePanel()
    {
        CloseAllPanels();
        ProfilePanel.SetActive(true);
        Profile_Username.text = login_Register.AuthorisedUser.username;
        Profile_Email.text = login_Register.AuthorisedUser.email;
    }



    /// <summary>
    /// Close all the panels at once
    /// </summary>
    public void CloseAllPanels()
    {
        SignUpPanel.SetActive(false);
        SignInPanel.SetActive(false);
        ProfilePanel.SetActive(false);
        MoreOptions.SetActive(false);
    }


    /// <summary>
    /// More options buttons functionality (hide/show)
    /// </summary>
    public void MoreOptionsFunc()
    {
        MoreOptions.SetActive(true);
        if(MoreOptionsAnim != null)
        {
            bool isshown = MoreOptionsAnim.GetBool("Show");
            MoreOptionsAnim.SetBool("Show", !isshown);
        }
    }

    /// <summary>
    /// Logout the user from the app
    /// </summary>
    public void LogoutUser()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Deleted");

        CloseAllPanels();
        OpenSignInPanel();
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Deleted");
        }
    }
}
