using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TaskParamsMenuHandler : MonoBehaviour {

    public Dropdown LATypeDropdown;
    public InputField LASpeedInputField;
    public InputField AzimuthInputField;
    public Dropdown TargetingDropdown;
    public Dropdown WeatherDropdown;
    public Dropdown InterferenceDropdown;
    public Dropdown InterferencePeriodDropdown;
    public Dropdown TerrainDropdown;
    public Dropdown Rocket1Dropdown;
    public Dropdown Rocket2Dropdown;
    public Dropdown Rocket3Dropdown;
    public Dropdown Rocket4Dropdown;
    public Dropdown TrajectoryTypeDropdown;
    public InputField StartLADistanceInputField;
    public InputField FlightHeightInputField;
    public InputField SaveTaskNameInputField;
    //траектория горка
    public InputField HeightChuteInputField;
    public InputField RateOfClimbChuteInputField;
    public InputField SpeedOfDescentInputField;
    public InputField DistanceChuteInputField;
    public InputField SpeedOfWithdrawalInputField;
    public InputField HeightOfWithdrawalInputField;
    //

    public static Task task;
	void Start () {
        task = new Task();
        InitParamsMenu(task);
	}

    public void InitParamsMenu(Task task)
    {
        LATypeDropdown.value = (int)task.LAType;
        LASpeedInputField.text = task.LASpeed.ToString();
        AzimuthInputField.text = task.Trajectory.Azimuth.ToString();
        TargetingDropdown.value = (int)task.TargetingType;
        WeatherDropdown.value = (int)task.WeatherType;
        InterferenceDropdown.value = (int)task.InterferenceType;
        InterferencePeriodDropdown.interactable = task.InterferenceType != InterferenceType.Without;
        InterferencePeriodDropdown.value = (int)task.InterferencePeriod;
        TerrainDropdown.value = (int)task.TerrainType;
        Rocket1Dropdown.value = (int)task.Rockets[0];
        Rocket2Dropdown.value = (int)task.Rockets[1];
        Rocket3Dropdown.value = (int)task.Rockets[2];
        Rocket4Dropdown.value = (int)task.Rockets[3];
        TrajectoryTypeDropdown.value = (int)task.TrajectoryType;
        StartLADistanceInputField.text = task.Trajectory.StartLADistance.ToString();
        FlightHeightInputField.text = task.Trajectory.FlightHeight.ToString();
        SaveTaskNameInputField.text = task.TaskName;
        HeightChuteInputField.text = ((ChuteTrajectory)task.Trajectory).HeightChute.ToString();
        RateOfClimbChuteInputField.text = (task.Trajectory as ChuteTrajectory).RateOfClimbChute.ToString();
        SpeedOfDescentInputField.text = (task.Trajectory as ChuteTrajectory).SpeedOfDescent.ToString();
        DistanceChuteInputField.text = (task.Trajectory as ChuteTrajectory).DistanceChute.ToString();
        SpeedOfWithdrawalInputField.text = (task.Trajectory as ChuteTrajectory).SpeedOfWithdraval.ToString();
        HeightOfWithdrawalInputField.text = (task.Trajectory as ChuteTrajectory).HeigthOfWithdraval.ToString();
    }

    public void OnTypeLAChange()
    {
        task.LAType = (LAType)LATypeDropdown.value;
    }

    public void OnSpeedLAChange()
    {
        task.LASpeed = double.Parse(LASpeedInputField.text);
    }

    public void OnAzimuthChange()
    {
        task.Trajectory.Azimuth = int.Parse(AzimuthInputField.text);
    }

    public void OnTargettingChange()
    {
        task.TargetingType = (TargetingType)TargetingDropdown.value;
    }

    public void OnWeatherChange()
    {
        task.WeatherType = (WeatherType)WeatherDropdown.value;
    }

    public void OnInterferenceTypeChange()
    {
        task.InterferenceType = (InterferenceType)InterferenceDropdown.value;
        if((InterferenceType)InterferenceDropdown.value == InterferenceType.Without)
        {
            InterferencePeriodDropdown.interactable = false;
        }else
        {
            InterferencePeriodDropdown.interactable = true;
        }
    }

    public void OnInterferencePeriodChange()
    {
        task.InterferencePeriod = (InterferencePeriod)InterferencePeriodDropdown.value;
    }

    public void OnTerrainTypeChange()
    {
        task.TerrainType = (TerrainType)TerrainDropdown.value;
    }

    public void OnRocket1Change()
    {
        task.Rockets[0] = (RocketType)Rocket1Dropdown.value;
    }

    public void OnRocket2Change()
    {
        task.Rockets[1] = (RocketType)Rocket2Dropdown.value;
    }

    public void OnRocket3Change()
    {
        task.Rockets[2] = (RocketType)Rocket3Dropdown.value;
    }

    public void OnRocket4Change()
    {
        task.Rockets[3] = (RocketType)Rocket4Dropdown.value;
    }

    public void OnTrajectoryTypeChange()
    {
        Debug.Log((TrajectoryType)TrajectoryTypeDropdown.value);
        switch ((TrajectoryType)TrajectoryTypeDropdown.value)
        {
            case TrajectoryType.Simple:
                task.Trajectory = new Trajectory();
                task.TrajectoryType = TrajectoryType.Simple;
                break;
            case TrajectoryType.Chute:
                task.Trajectory = new ChuteTrajectory();
                task.TrajectoryType = TrajectoryType.Chute;
                break;
        }
    }

    public void OnStartLADistanceChange()
    {
        task.Trajectory.StartLADistance = int.Parse(StartLADistanceInputField.text);
    }

    public void OnFlightHeightChange()
    {
        task.Trajectory.FlightHeight = int.Parse(FlightHeightInputField.text);
    }

    public void OnSaveTaskNameInputFieldChange()
    {
        task.TaskName = SaveTaskNameInputField.text;
    }

    public void OnHeightChuteInputField()
    {
        (task.Trajectory as ChuteTrajectory).HeightChute = int.Parse(HeightChuteInputField.text);
    }

    public void OnRateOfClimbChuteInputField()
    {
        (task.Trajectory as ChuteTrajectory).RateOfClimbChute = int.Parse(RateOfClimbChuteInputField.text);
    }

    public void OnSpeedOfDescentInputField()
    {
        (task.Trajectory as ChuteTrajectory).SpeedOfDescent = int.Parse(SpeedOfDescentInputField.text);
    }

    public void OnDistanceChuteInputField()
    {
        (task.Trajectory as ChuteTrajectory).DistanceChute = int.Parse(DistanceChuteInputField.text);
    }

    public void OnSpeedOfWithdrawalInputField()
    {
        (task.Trajectory as ChuteTrajectory).SpeedOfWithdraval = int.Parse(SpeedOfWithdrawalInputField.text);
    }

    public void OnHeightOfWithdrawalInputField()
    {
        (task.Trajectory as ChuteTrajectory).HeigthOfWithdraval = int.Parse(HeightOfWithdrawalInputField.text);
    }
}
