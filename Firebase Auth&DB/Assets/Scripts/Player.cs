using System;

[Serializable]
public class Player
{

    public string Username, Password;

    public Player() { }

    public Player(string name , string password)
    {
        Username = name;
        Password = password;
    }

}
