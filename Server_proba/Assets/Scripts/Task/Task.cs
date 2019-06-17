using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Task
{
    [SerializeField]
    string taskName;
    [SerializeField]
    LAType lAType;
    [SerializeField]
    double lASpeed;
    [SerializeField]
    TargetingType targetingType;
    [SerializeField]
    WeatherType weatherType;
    [SerializeField]
    InterferenceType interferenceType;
    [SerializeField]
    InterferencePeriod interferencePeriod;
    [SerializeField]
    TerrainType terrainType;
    [SerializeField]
    Trajectory trajectory;
    [SerializeField]
    RocketType[] rockets;
    [SerializeField]
    TrajectoryType trajectoryType;

    public Task()
    {
        this.taskName = "";
        this.LAType = LAType.Helicopter;
        this.LASpeed = 100;
        this.TargetingType = TargetingType.WithACY;
        this.WeatherType = WeatherType.Simple;
        this.InterferenceType = InterferenceType.Without;
        this.InterferencePeriod = InterferencePeriod.None;
        this.TerrainType = TerrainType.Champaign;
        this.Trajectory = new Trajectory();
        this.Rockets = new RocketType[4] {RocketType.None, RocketType.None, RocketType.None, RocketType.None};
        this.TrajectoryType = TrajectoryType.Simple;
    }

    public string TaskName
    {
        get
        {
            return taskName;
        }

        set
        {
            taskName = value;
        }
    }

    public double LASpeed
    {
        get
        {
            return lASpeed;
        }

        set
        {
            lASpeed = value;
        }
    }

    public Trajectory Trajectory
    {
        get
        {
            return trajectory;
        }

        set
        {
            trajectory = value;
        }
    }

    internal LAType LAType
    {
        get
        {
            return lAType;
        }

        set
        {
            lAType = value;
        }
    }

    internal TargetingType TargetingType
    {
        get
        {
            return targetingType;
        }

        set
        {
            targetingType = value;
        }
    }

    internal WeatherType WeatherType
    {
        get
        {
            return weatherType;
        }

        set
        {
            weatherType = value;
        }
    }

    internal InterferenceType InterferenceType
    {
        get
        {
            return interferenceType;
        }

        set
        {
            interferenceType = value;
            if (InterferenceType == InterferenceType.Without)
            {
                InterferencePeriod = InterferencePeriod.None;
            }
        }
    }

    internal InterferencePeriod InterferencePeriod
    {
        get
        {
            return interferencePeriod;
        }

        set
        {
            interferencePeriod = value;
        }
    }

    internal TerrainType TerrainType
    {
        get
        {
            return terrainType;
        }

        set
        {
            terrainType = value;
        }
    }

    internal RocketType[] Rockets
    {
        get
        {
            return rockets;
        }

        set
        {
            rockets = value;
        }
    }

    internal TrajectoryType TrajectoryType
    {
        get
        {
            return trajectoryType;
        }

        set
        {
            trajectoryType = value;
        }
    }

    public override string ToString()
    {
        return "LAType" + LAType;
    }
}

[Serializable]
public class Trajectory
{
    [SerializeField]
    int startLADistance;
    [SerializeField]
    int flightHeight;
    [SerializeField]
    int azimuth;

    public Trajectory()
    {
        this.StartLADistance = 7000;
        this.FlightHeight = 2000;
        this.Azimuth = 0;
    }

    public int StartLADistance
    {
        get
        {
            return startLADistance;
        }

        set
        {
            startLADistance = value;
        }
    }

    public int FlightHeight
    {
        get
        {
            return flightHeight;
        }

        set
        {
            flightHeight = value;
        }
    }

    public int Azimuth
    {
        get
        {
            return azimuth;
        }

        set
        {
            if (value >= 0 && value <= 359)
            {
                azimuth = value;
            }
        }
    }
}

[Serializable] //траектория "горка"
public class ChuteTrajectory : Trajectory
{
    [SerializeField]
    int heightchute; //высота горки
    [SerializeField]
    int rateofclimbchute; //скороподъемность
    [SerializeField]
    int speedofdescent; //скорость спуска
    [SerializeField]
    int distancechute; //дальность горки
    [SerializeField]
    int speedofwithdrawal; //скорость отхода
    [SerializeField]
    int heightofwithdrawal; //высота отхода

    public ChuteTrajectory() : base()
    {
        this.HeightChute = 300;
        this.RateOfClimbChute = 100;
        this.SpeedOfDescent = 120;
        this.DistanceChute = 3000;
        this.SpeedOfWithdraval = 120;
        this.HeigthOfWithdraval = 50;
    }

    public int HeightChute
    {
        get
        {
            return heightchute;
        }

        set
        {
            heightchute = value;
        }
    }

    public int RateOfClimbChute
    {
        get
        {
            return rateofclimbchute;
        }

        set
        {
            rateofclimbchute = value;
        }
    }

    public int SpeedOfDescent
    {
        get
        {
            return speedofdescent;
        }

        set
        {
            speedofdescent = value;
        }
    }

    public int DistanceChute
    {
        get
        {
            return distancechute;
        }

        set
        {
            distancechute = value;
        }
    }

    public int SpeedOfWithdraval
    {
        get
        {
            return speedofwithdrawal;
        }

        set
        {
            speedofwithdrawal = value;
        }
    }

    public int HeigthOfWithdraval
    {
        get
        {
            return heightofwithdrawal;
        }

        set
        {
            heightofwithdrawal = value;
        }
    }
}

enum LAType
{
    TypeA10F,
    Propeller, //винтомоторный
    CruiseMissle, //крылатая ракета
    F15,
    Helicopter,
}

enum TargetingType
{
    WithoutCY,
    WithACY,
    WithPRP,
}

enum WeatherType
{
    Simple,
    Medium,
    Hard,
}

enum InterferenceType
{
    Without,
    LTC_Horizontal,
    LTC_Vertical,
}

enum InterferencePeriod
{
    None,
    TwoSec,
    FourSec,
    SixSec,
    EightSec,
}

enum TerrainType
{
    Mountains, //горы
    Town, //город
    Champaign, //равнина
    Forest, //лес
}

enum TrajectoryType
{
    Simple,
    Chute, //горка
    Dive, //пикирование
    Direct, //прямой
    CombatTurn, //боевого разворота
    Circle //с круга
}

enum RocketType
{
    None,
    _9M37,
    _9M37M,
    _9M333,
}
