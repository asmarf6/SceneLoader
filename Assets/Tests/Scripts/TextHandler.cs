using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    public TextAsset txt_file;
    private char lineSeperater = '\n'; // It defines line seperate character
    private char fieldSeperator = '='; // It defines field seperate chracter
    private string[] records;

   
    /// <summary>
    /// Read data for quotes/hint/tips from file
    /// </summary>
    /// <returns></returns>
    public string ReadData(string key)
    {
       
        records = txt_file.text.Split(lineSeperater);
       
        int totalRows = records.Length;

        //Allocate data array
        string value = "";
        try
        {
            //populate data
            for (int row = 0; row < totalRows; row++)
            {
                string[] line_r = records[row].Split(fieldSeperator);
                //get value against key
                if (line_r[0] == key)
                {
                    value = line_r[1];
                    return value;
                }
            }

        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }

        return value;
    }
}
