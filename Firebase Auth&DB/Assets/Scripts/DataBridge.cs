using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Firebase.Database;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;

public class DataBridge : MonoBehaviour
{
    public Text userInput, passwordInput;
    private Player data;
    
    private string DATA_URL = "https://fir-and-unity-dummy-default-rtdb.firebaseio.com/";

    private DatabaseReference dataBaseRef;
    // Start is called before the first frame update
    void Start()
    {
            dataBaseRef = FirebaseDatabase.DefaultInstance.RootReference;
    }




    public void SaveData() 
    {
        if(userInput.text.Equals("") && passwordInput.text.Equals(""))
        {
            print("No Data");
            return;
        }
        data = new Player(userInput.text, passwordInput.text);
        string json = JsonUtility.ToJson(data);
        string userId=FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        dataBaseRef.Child("Users "+userId).SetRawJsonValueAsync(json);


    }
    public void LoadData()
    {
            dataBaseRef.GetValueAsync().ContinueWith((task=>
        {
            if (task.IsCanceled)
            {


            }

            if (task.IsFaulted)
            {


            }

            if(task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                //string playerData = snapshot.GetRawJsonValue();
                //print("data is " + playerData);
               // Player m = JsonUtility.FromJson<Player>(playerData);    //use it for one entry only 


                foreach ( var child in snapshot.Children)
                {
                    string t = child.GetRawJsonValue();
                    print("Data is "+ t );
    
                }
            }



        }));

    }
}
