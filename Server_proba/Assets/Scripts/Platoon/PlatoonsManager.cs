using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlatoonsManager
{
    private static List<Platoon> platoons = new List<Platoon>();
    private static string PLATOONS_FILE_PATH = "platoons.std";

    public static List<Platoon> Platoons
    {
        get
        {
            return platoons;
        }

        set
        {
            platoons = value;
        }
    }

    public static void AddPlatoon(Platoon platoon) //добавляет взвод в список
    {
        Platoons.Add(platoon);
    }

    public static void DeletePlatoon(Platoon platoon) //удаляет указанный взвод
    {
        Platoons.Remove(Platoons.Find(x => x.NamePlatoon == platoon.NamePlatoon));
    }

    public static void RemovePlatoons() //удаляет все взвода
    {
        Platoons.Clear();
    }

    public static void UpPlatoons() //переводит все взвода на следующий курс
    {
        foreach(Platoon platoon in Platoons)
        {
            platoon.UpNamePlatoon();
        }
    }

    public static Platoon GetPlatoon(string PlatoonName) //возвращает требуемый взвод
    {
        return Platoons.Find(x => x.NamePlatoon == PlatoonName);
    }

    public static void SavePlatoons() //сохраняет список взвода
    {
        try
        {
            string output = JsonHelper.ToJson(Platoons.ToArray(), true);
            File.WriteAllText(PLATOONS_FILE_PATH, output);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
    
    public static void LoadPlatoons() //загружает список взвода
    {
        try
        {
            if (File.Exists(PLATOONS_FILE_PATH))
            {
                Platoons = new List<Platoon>(JsonHelper.FromJson<Platoon>(PLATOONS_FILE_PATH));
            }
            else
            {
                Platoons = new List<Platoon>();
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
