using UnityEngine;
using Firebase.Auth;
using Firebase.Firestore;
using UnityEngine.UI;


public class DataBridgeFirestore : MonoBehaviour
{

    public Text userInput, passwordInput;
    private Player data;
    FirebaseFirestore db;



    // Start is called before the first frame update
    void Start()

    {
        db = FirebaseFirestore.DefaultInstance;
    }




    public void SaveData()
    {
        if (userInput.text.Equals("") && passwordInput.text.Equals(""))
        {
            print("No Data");
            return;
        }
        data = new Player(userInput.text, passwordInput.text);
        string json = JsonUtility.ToJson(data);
        string userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        DocumentReference doc = db.Collection("Users").Document((string)userInput.text);
            doc.SetAsync(data).ContinueWith((task=> {
            if (task.IsCanceled)
            {
                print("Canceled");

            }

            if (task.IsFaulted)
            {
                print("Fault");

            }

            if (task.IsCompleted)
            {
                print("good job");

            }
        }
        ));


    }
   /* public void LoadData()
    {
        db.GetValueAsync().ContinueWith((task =>
        {
            if (task.IsCanceled)
            {


            }

            if (task.IsFaulted)
            {


            }

            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                //string playerData = snapshot.GetRawJsonValue();
                //print("data is " + playerData);
                // Player m = JsonUtility.FromJson<Player>(playerData);    //use it for one entry only 


                foreach (var child in snapshot.Children)
                {
                    string t = child.GetRawJsonValue();
                    print("Data is " + t);

                }
            }



        }));

    }

    */
}
