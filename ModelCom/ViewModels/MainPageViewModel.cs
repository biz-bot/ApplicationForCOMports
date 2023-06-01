using Avalonia.Collections.Pooled;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ModelCom;
using ModelCom.Models;
using ModelCom.Services;
using ModelCom.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelCom.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        
        public MainPageViewModel(IEnumerable<Base> items)
        {
            ButtonCl1 = false;
            ButtonCl2 = false;
            Items = new ObservableCollection<Base>(items);
            if(Items.Count==0)
            {
                Description += "Not found Com ports\n>>";
            }
            

        }
        public void SetSetting(SettingsViewModel setting)
        {
            if (setting != null && setting.IsCheckedCheckBox1 == false)
            {
                int.TryParse(setting.Set1, out Rand);
            }
            else
            {
                Rand = 100;
            }

            if (setting != null && setting.IsCheckedCheckBox2 == false)
            {
                int.TryParse(setting.Set2, out TimeMul);
            }
            else { TimeMul = 1; }
        }
        
        int Rand =100;
        int TimeMul = 1;
        public ObservableCollection<Base> Items { get; }
        public string description = ">>";
        public bool IsLoading { get; set; }
        ButtonModel button1 = new ButtonModel { ButtonText = "Gray" };
        ButtonModel button2 = new ButtonModel { ButtonText = "Gray" };
        public bool ButtonCl1 { get; set; }
        public bool ButtonCl2 { get; set; }
        TimerCallback tms;
        Timer timer;

        public int i = 0;
        public ButtonModel Button1
        {
            get => button1;
            set
            {
                this.RaiseAndSetIfChanged(ref button1, value);

            }
        }
        public ButtonModel Button2
        {
            get => button2;
            set
            {
                this.RaiseAndSetIfChanged(ref button2, value);

            }
        }
       
        public void ButtonClickedStart() //Start
        {
            if (ButtonCl1)
            {
                Button1 = new ButtonModel { ButtonText = "Red" };
                Button2 = new ButtonModel { ButtonText = "Blue" };
                ButtonCl1 = false;
                ButtonCl2 = true;
                tms = new TimerCallback(Count);

                timer = new Timer(tms, 0, 0, TimeMul*1000);
            }
        }
        public void ButtonClickedStop() //Stop
        {
            if (ButtonCl2)
            {
                Button2 = new ButtonModel { ButtonText = "Red" };
                Button1 = new ButtonModel { ButtonText = "Blue" };
                ButtonCl1 = true;
                ButtonCl2 = false;
                timekill();



            }

        }
       public void timekill()

        {
            if (timer != null)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }
        
        
        public void Count(object obj)
        {


            Random rnd = new Random();
            i++;
            if (i >= 10)
            {
                Description += rnd.Next(0, Rand).ToString() + "\n>>";
                i = 0;
            }
            else
            {
                Description +=rnd.Next(0, Rand).ToString() + "  ";
            }


        }
       
        public string Description
        {
            get => description;
            set
            {
                
                this.RaiseAndSetIfChanged(ref description, value);
                
            }
        }


    }
}
