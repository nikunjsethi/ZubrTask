using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Sorting : MonoBehaviour
{
    public string maddison = "Maddison Albert";
    public string hester = "Hester Blankenship";
    public string saara = "Saara Browne";
    public string libbie = "Libbie Case";
    public string dominick = "Dominick Howells";
    public string abida = "Abida Hayden";
    public string giorgia = "Giorgia Cotton";
    public string rita = "Rita Smyth";
    public string rania = "Rania Wolf";
    public string zainab = "Zainab Sheldon";

    public List<string> nameCollection;

    private void Start()
    {
        nameCollection.Add(maddison);
        nameCollection.Add(hester);
        nameCollection.Add(saara);
        nameCollection.Add(libbie);
        nameCollection.Add(dominick);
        nameCollection.Add(abida);
        nameCollection.Add(giorgia);
        nameCollection.Add(rita);
        nameCollection.Add(rania);
        nameCollection.Add(zainab);
    }
    public void LastNameDescending()
    {
        var sortedList = nameCollection.OrderByDescending(name => LastName(name)).ToList();

        foreach (string name in sortedList)
        {
            Debug.Log(name);
        }
    }
    public void FirstNameDescending()
    {
        var sortedList = nameCollection.OrderByDescending(name => FirstName(name)).ToList();

        foreach (string name in sortedList)
        {
            Debug.Log(name);
        }
    }
    public void LastNameAscending()
    {
        var sortedList = nameCollection.OrderBy(name => LastName(name)).ToList();

        foreach (string name in sortedList)
        {
            Debug.Log(name);
        }
    }
    public void FirstNameAscending()
    {

        var sortedList = nameCollection.OrderBy(name => FirstName(name)).ToList();

        foreach(string name in sortedList)
        {
            Debug.Log(name);
        }
    }

    string FirstName(string fullName)
    {
        string[] nameParts = fullName.Split(' ');
        return nameParts[0];
    }

    string LastName(string fullName)
    {
        string[] nameParts = fullName.Split(' ');
        return nameParts[1];
    }
}
