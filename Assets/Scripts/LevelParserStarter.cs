﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParserStarter : MonoBehaviour
{
    public string filename;

    public GameObject Rock;

    public GameObject Brick;

    public GameObject QuestionBox;

    public GameObject Stone;

    public Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        RefreshParse();
    }

    private void FileParser()
    {
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 15;

            while ((line = sr.ReadLine()) != null)
            {
                int column = 0;
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {
                    //Call SpawnPrefab
                    SpawnPrefab(letter, new Vector3(column + 0.5f, row -0.5f, 0));
                    column++;
                }
                row--;
            }

            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;

        switch (spot)
        {
            case 'b': Debug.Log("Spawn Brick");
                //Debug.Log(positionToSpawn);
                ToSpawn = GameObject.Instantiate(Brick, positionToSpawn, transform.rotation);
                break;
            case '?': Debug.Log("Spawn QuestionBox");
                //Debug.Log(positionToSpawn);
                ToSpawn = GameObject.Instantiate(QuestionBox, positionToSpawn, transform.rotation);
                break;
            case 'x': Debug.Log("Spawn Rock");
                //Debug.Log(positionToSpawn);
                ToSpawn = GameObject.Instantiate(Rock, positionToSpawn, transform.rotation);
                break;
            case 's': Debug.Log("Spawn Stone");
                //Debug.Log(positionToSpawn);
                ToSpawn = GameObject.Instantiate(Stone, positionToSpawn, transform.rotation);
                break;
            //default: Debug.Log("Default Entered"); break;
            default: return;
                //ToSpawn = //Brick;       break;
        }

        //ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        //ToSpawn.transform.localPosition = positionToSpawn;
    }

    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;
        
        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }
}


