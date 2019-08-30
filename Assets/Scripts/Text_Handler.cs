using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Handler : MonoBehaviour
{
    [SerializeField] private TextAsset Data = null;

    List<Population> Pops = null;

    private int Total_Population_Val = 0;

    private int Teen_Population_Val = 0;

    private int Page_Num = 0;

    private void Start()
    {
        Pops = new List<Population>();

        string[] pData = Data.text.Split('\n');

        for (int i = 1; i < pData.Length - 1; i++)
        {
            string[] pop = pData[i].Split(',');

            Population p = new Population();

            p.Name = pop[0];
            int.TryParse(pop[1], out p.TPop_Tot);
            float.TryParse(pop[2], out p.TPop_Per);
            int.TryParse(pop[3], out p.TePop_Tot);
            float.TryParse(pop[4], out p.TePop_Per);
            int.TryParse(pop[5], out p.Med_Sal);

            Pops.Add(p);
        }

        Display();
    }

    public void Display()
    {
        int iniPoint;

        if (Page_Num == 0)
            iniPoint = 0;
        else
            iniPoint = 10;

        for (int i = iniPoint; i < iniPoint + 10; i++)
        {
            transform.GetChild((i - iniPoint) * 4).GetComponent<TextMesh>().text = Pops[i].Name;

            if (Total_Population_Val == 0)
            {
                transform.GetChild((i - iniPoint) * 4 + 1).GetComponent<TextMesh>().text = Pops[i].TPop_Tot.ToString();
            }
            else
            {
                transform.GetChild((i - iniPoint) * 4 + 1).GetComponent<TextMesh>().text = Pops[i].TPop_Per.ToString();
            }

            if (Teen_Population_Val == 0)
            {
                transform.GetChild((i - iniPoint) * 4 + 2).GetComponent<TextMesh>().text = Pops[i].TePop_Tot.ToString();
            }
            else
            {
                transform.GetChild((i - iniPoint) * 4 + 2).GetComponent<TextMesh>().text = Pops[i].TePop_Per.ToString();
            }
            
            transform.GetChild((i - iniPoint) * 4 + 3).GetComponent<TextMesh>().text = Pops[i].Med_Sal.ToString();
        }
    }

    public void Next_Page()
    {
        if (Page_Num == 0)
            Page_Num = 1;
        else
            Page_Num = 0;

        Display();
    }

    public void Sort_By_Name(int Order)
    {
        for(int i = 0; i < Pops.Count; i++)
        {
            for(int j = i; j < Pops.Count; j++)
            {
                if(j != i)
                {
                    if(Pops[i].Name.CompareTo(Pops[j].Name) == Order)                // For Ascending Order, Order needs to be 1. But comparing it should be with -1 and vice versa.
                    {
                        Population p = new Population();

                        p = Pops[i];
                        Pops[i] = Pops[j];
                        Pops[j] = p;
                    }
                }
            }
        }

        Display();
    }

    public void Sort_By_Total_Population(int Order)
    {
        if (Total_Population_Val == 0)
        {
            for (int i = 0; i < Pops.Count; i++)
            {
                for (int j = i; j < Pops.Count; j++)
                {
                    if (j != i)
                    {
                        if (Pops[i].TPop_Tot.CompareTo(Pops[j].TPop_Tot) == Order)                // For Ascending Order, Order needs to be 1. But comparing it should be with -1 and vice versa.
                        {
                            Population p = new Population();

                            p = Pops[i];
                            Pops[i] = Pops[j];
                            Pops[j] = p;
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < Pops.Count; i++)
            {
                for (int j = i; j < Pops.Count; j++)
                {
                    if (j != i)
                    {
                        if (Pops[i].TPop_Per.CompareTo(Pops[j].TPop_Per) == Order)                // For Ascending Order, Order needs to be 1. But comparing it should be with -1 and vice versa.
                        {
                            Population p = new Population();

                            p = Pops[i];
                            Pops[i] = Pops[j];
                            Pops[j] = p;
                        }
                    }
                }
            }
        }

        Display();
    }

    public void Sort_By_Teen_Population(int Order)
    {
        if(Teen_Population_Val == 0)
        {
            for (int i = 0; i < Pops.Count; i++)
            {
                for (int j = i; j < Pops.Count; j++)
                {
                    if (j != i)
                    {
                        if (Pops[i].TePop_Tot.CompareTo(Pops[j].TePop_Tot) == Order)                // For Ascending Order, Order needs to be 1. But comparing it should be with -1 and vice versa.
                        {
                            Population p = new Population();

                            p = Pops[i];
                            Pops[i] = Pops[j];
                            Pops[j] = p;
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < Pops.Count; i++)
            {
                for (int j = i; j < Pops.Count; j++)
                {
                    if (j != i)
                    {
                        if (Pops[i].TePop_Per.CompareTo(Pops[j].TePop_Per) == Order)                // For Ascending Order, Order needs to be 1. But comparing it should be with -1 and vice versa.
                        {
                            Population p = new Population();

                            p = Pops[i];
                            Pops[i] = Pops[j];
                            Pops[j] = p;
                        }
                    }
                }
            }
        }

        Display();
    }

    public void Sort_By_Salary(int Order)
    {
        for (int i = 0; i < Pops.Count; i++)
        {
            for (int j = i; j < Pops.Count; j++)
            {
                if (j != i)
                {
                    if (Pops[i].Med_Sal.CompareTo(Pops[j].Med_Sal) == Order)                // For Ascending Order, Order needs to be 1. But comparing it should be with -1 and vice versa.
                    {
                        Population p = new Population();

                        p = Pops[i];
                        Pops[i] = Pops[j];
                        Pops[j] = p;
                    }
                }
            }
        }

        Display();
    }

    public void Switch_Total_Population()
    {
        if (Total_Population_Val == 0)
            Total_Population_Val = 1;
        else
            Total_Population_Val = 0;

        Display();
    }

    public void Switch_Teen_Population()
    {
        if (Teen_Population_Val == 0)
            Teen_Population_Val = 1;
        else
            Teen_Population_Val = 0;

        Display();
    }
}