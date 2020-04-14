using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BucketList.ViewModels
{
    public class MissionViewModel : BaseViewModel
    {
        string missionStatement;
        public string MissionStatement
        {
            get { return missionStatement; }
            set { SetProperty(ref missionStatement, value); }
        }

        public Command LoadMissionCommand { get; set; }
        public Command SaveMissionCommand { get; set; }

        public MissionViewModel()
        {
            Title = "Mission Statement";
            LoadMissionCommand = new Command(async () => missionStatement = await DataStore.GetMission());
            SaveMissionCommand = new Command(async () => await DataStore.UpdateMission(missionStatement));
            
        }
    }
}
