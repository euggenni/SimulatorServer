using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Period
{
    Presently = 0,
    Yesterday = 1,
    ForAWeek = 2,
    PerMonth = 3
}

public class ResultManager : MonoBehaviour
{
    public GameObject DescriptionPanel; //окно с подробностями
    public Dropdown SelectPlatoonDropdown; //кнопка выбора фильтра по взводу
    public Dropdown SelectPeriodDropdown; //кнопка выбора фильтра по времени
    public UnityUITable.Table Table; //таблица с данными
    public UnityUITable.Table Table2; //таблица с данными
    public List<Result> Results = new List<Result>();
    public List<Result> AvgNotes = new List<Result>();
    private List<string> Platoons = new List<string>();
    private List<Result> ResultsBufer = new List<Result>();

    private void ReadAllPlatoons()//заполняет список названий взводов
    {
        Platoons.Clear();
        foreach(Result Rez in ResultsBufer)
        {
            if(!Platoons.Contains(Rez.Platoon))
            {
                Platoons.Add(Rez.Platoon);
            }
        }
        Platoons.Sort();
    }

    public bool PeriodComparator(int value, DateTime Date) //проверяет на вхождение в интервал времени
    {
        switch ((Period)value)
        {
            case Period.Presently:
                {
                    if (Date.Day == DateTime.Now.Day && Date.Month == DateTime.Now.Month && Date.Year == DateTime.Now.Year)
                    {
                        return true;
                    }
                    else return false;
                    break;
                }
            case Period.Yesterday:
                {
                    if (Date.Day == DateTime.Today.AddDays(-1).Day && Date.Month == DateTime.Today.AddDays(-1).Month && Date.Year == DateTime.Today.AddDays(-1).Year)
                    {
                        return true;
                    }
                    else return false;
                    break;
                }
            case Period.ForAWeek:
                {
                    if ((Date.Day >= DateTime.Today.AddDays(-7).Day && Date.Day <= DateTime.Today.Day) && (Date.Month <= DateTime.Today.AddDays(-7).Month && Date.Month <= DateTime.Today.Month) && (Date.Year >= DateTime.Today.AddDays(-7).Year && Date.Year <= DateTime.Today.Year))
                    {
                        return true;
                    }
                    else return false;
                    break;
                }
            case Period.PerMonth:
                {
                    if ((Date.Day >= DateTime.Today.AddDays(-30).Day && Date.Day <= DateTime.Today.Day) && (Date.Month <= DateTime.Today.AddDays(-30).Month && Date.Month <= DateTime.Today.Month) && (Date.Year >= DateTime.Today.AddDays(-30).Year && Date.Year <= DateTime.Today.Year))
                    {
                        return true;
                    }
                    else return false;
                    break;
                }
        }
        return false;
    }


    public void RefreshTable()//перезаполняет выводимую таблицу
    {
        Results.Clear();
        foreach(Result Rez in ResultsBufer)
        {
            if(Rez.Platoon == SelectPlatoonDropdown.captionText.text && PeriodComparator(SelectPeriodDropdown.value, Rez.Date))
            {
                Results.Add(Rez);
            }
        }
        UpdateTable();
    }

    public void OnChangeResults() //обработчик события получения нового результата
    {
        ReadAllPlatoons();
        SelectPlatoonDropdown.options.Clear();
        foreach (string platoon in Platoons)
        {
            SelectPlatoonDropdown.options.Add(new Dropdown.OptionData(platoon));
        }
        SelectPlatoonDropdown.RefreshShownValue();
        SelectPlatoonDropdown.value = 0;
        RefreshTable();
    }

    public void UpdateTable()
    {
        Table.UpdateContent();
        Table2.UpdateContent();
    }

    public void ShowDescription()
    {
        DescriptionPanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        ResultsBufer.Add(new Result(1, "Зверь-ПК", "Абдулаев Артур Багирович", "Хорошо", "122", new DateTime(2019, 6, 18, 15, 40, 25), this));
        ResultsBufer.Add(new Result(2, "Зверь-ПК", "Гайнуллин Шамиль Альбертович", "Удовлетв", "122", new DateTime(2019, 6, 17, 15, 40, 25), this));
        ResultsBufer.Add(new Result(3, "Зверь-ПК", "Гузь Вячеслав Олегович", "Хорошо", "122", new DateTime(2019, 6, 8, 15, 40, 25), this));
        ResultsBufer.Add(new Result(1, "Зверь-ПК", "Балицкий Иван Александрович", "Удовлетв", "121", new DateTime(2019, 6, 18, 15, 40, 25), this));
        Results = new List<Result>(ResultsBufer);
        AvgNotes.Add(new Result(1, "Зверь-ПК", "Абдулаев Артур Багирович", "4.0", "122", new DateTime(2019, 6, 18, 15, 40, 25), this));
        AvgNotes.Add(new Result(2, "Зверь-ПК", "Гайнуллин Шамиль Альбертович", "3.0", "122", new DateTime(2019, 6, 17, 15, 40, 25), this));
        AvgNotes.Add(new Result(3, "Зверь-ПК", "Гузь Вячеслав Олегович", "4.0", "122", new DateTime(2019, 6, 8, 15, 40, 25), this));
        Invoke("UpdateTable", 1);
        OnChangeResults();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
