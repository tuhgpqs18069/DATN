using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System; 
using System.Threading.Tasks;

public class MainMenu : MonoBehaviour
{

    public InputField inputFieldEmail, inputFieldPassword;
    public Text errorMessage;
    public AudioSource main_sound;

    public InputField registerEmail, registerPassword, registerName, registerAge, registerConfirmPassword, registerPhoneNumber;
    // public Text registerErrorMessage;
    public GameObject LoginMenu, RegisterMenu;



    public async void Login()
    {
        var email = inputFieldEmail.text;
        var password = inputFieldPassword.text;
        Debug.Log(">>>>>>>>>" + email + " " + password);
        //Goi API
        // UnityWebRequest Post
        /**
        var url = "http://localhost:3000/users/login";
        var form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);
        var http = new HttpRequestPortal(new Serialization());
        var result = await http.Post<ResponseAPIModel>(url, form);
        if (result != null && result.user != null)
        {
            Debug.Log("Ket qua tra ve:" + result.user.email);
            errorMessage.text = "";
            SceneManager.LoadScene("Scene1");
        }
        else
        {
            errorMessage.text = "Login Failed!";
        }
        */
        // UnityWebRequest Get
        // var url = "https://63761195b5f0e1eb8501bd61.mockapi.io/users";
        //gmail hgqtu79@gmail.com
        var url = "https://647993f6a455e257fa635aa7.mockapi.io/Users";
        var http = new HttpRequestPortal(new Serialization());
        var result = await http.Get<ResponseMockModel[]>(url);
        foreach (var user in result)
        {
            if (user.email.Equals(email) && user.password.Equals(password))
            {
                errorMessage.text = "";
                SceneManager.LoadScene("Scene1");
                return;
            }
        }
        errorMessage.text = "Login Failed!";
    }

    public async void Register()
    {
        var email = registerEmail.text;
        var name = registerName.text;
        var phoneNumber = registerPhoneNumber.text;
        var age = registerAge.text;
        var password = registerPassword.text;
        var confirmPassword = registerConfirmPassword.text;
        if (password.Equals(confirmPassword) == false)
        {
            registerConfirmPassword.text = "Check your password!";
            return;
        }
        var url = "https://647993f6a455e257fa635aa7.mockapi.io/Users";
        var form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);
        form.AddField("name", name);
        form.AddField("age", age);
        form.AddField("phoneNumber", phoneNumber);
        var http = new HttpRequestPortal(new Serialization());
        var result = await http.Post<ResponseMockModel>(url, form);
        Debug.Log("Them moi: " + result.id);
        RegisterMenu.SetActive(false);
        LoginMenu.SetActive(true);
    }
}
