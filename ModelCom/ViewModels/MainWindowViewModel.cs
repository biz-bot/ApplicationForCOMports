using Avalonia;
using Avalonia.Controls;
using ModelCom.Services;
using ModelCom.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.Metadata;
using Tmds.DBus;
using System.Text.Json;
using System.IO;
using DocumentFormat.OpenXml.Office2010.ExcelAc;

namespace ModelCom.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        
        SettingsViewModel? GET { get; set; }
        
        ViewModelBase content;
        public MainPageViewModel List { get; set; }
        public string CheckD { get; set; }
        string strokethickness = "1";
        int Write = 0;
        public MainWindowViewModel(Database db)
        {
            GetSetting();

            Content = List = new MainPageViewModel(db.GetBase());

            List.SetSetting(GET);
        }
        
        public async void GetSetting()
        {

            try
            {
                //string jsonString = File.ReadAllText("Saves.json");
                //GET =  JsonSerializer.Deserialize<SettingsViewModel>(jsonString);
                using (FileStream fs = new FileStream("Save.json", FileMode.OpenOrCreate))
                {
                    GET = await JsonSerializer.DeserializeAsync<SettingsViewModel>(fs);

                }
                
            }
            catch
            {
                GET = new SettingsViewModel();
               
            }
            List.SetSetting(GET);
            //StrokeThickness = GET.Set3;
        }

        public string StrokeThickness
        {
            get => strokethickness;
            set
            {
                this.RaiseAndSetIfChanged(ref strokethickness, value);
            }
        }

        public ViewModelBase Content
        {
            get => content;
            set
            {
                this.RaiseAndSetIfChanged(ref content, value);
            }
        }

        public  void Settings()
        {

            List.ButtonClickedStop();

            Content = GET;


        }
        public void HomeClick()
        {
            
             Content = List;
            List.SetSetting(GET);
            

        }
       
        public void GrClick()
        {
            List.ButtonClickedStop();
            StrokeThickness = GET.Set3;
            Content = new GraphicsViewModel();
            

        }

        public void ButtonClickedUpdade()
        {
           
            Database db =new Database();

            Content= List = new MainPageViewModel(db.GetBase());



        }

        public void ButtonClickedPort(string check)
        {


            if (CheckD != null && CheckD != check)
            {
                List.Button2 = new ButtonModel { ButtonText = "Blue" };
                List.Button1 = new ButtonModel { ButtonText = "Blue" };
                List.ButtonCl1 = true;
                List.ButtonCl2 = false;
                for (int i = 0; i < List.Items.Count; i++)
                {
                    if (List.Items[i].Description == check)
                    {
                        List.Items[i].IsChecked = true;
                    }
                    if (List.Items[i].Description == CheckD)
                    {
                        List.Items[i].IsChecked = false;
                    }
                }
                List.Description = ">>";
                List.i = 0;

                CheckD = check;
                List.timekill();
            }
            else
            {


                if (CheckD == null || CheckD == check)
                {

                    if (List.ButtonCl1 == List.ButtonCl2)
                    {
                        List.ButtonCl1 = true;
                        List.Button2 = new ButtonModel { ButtonText = "Blue" };
                        List.Button1 = new ButtonModel { ButtonText = "Blue" };
                    }
                    else
                    {
                        List.ButtonCl1 = false;
                        List.ButtonCl2 = false;
                        List.Button2 = new ButtonModel { ButtonText = "Gray" };
                        List.Button1 = new ButtonModel { ButtonText = "Gray" };
                        List.timekill();
                        List.Description = ">>";
                        List.i = 0;
                    }
                    CheckD = check;
                }
            }
            GrClick();
            Content = List;

        }
        public void Save()
        {
            File.Delete("Save.json");
            SetSetting();

        }
        public async void SetSetting()
        {
            //SettingsViewModel SET = GET;
            ////SettingsViewModel SET = (SettingsViewModel)Content;
            //string jsonString = JsonSerializer.Serialize(GET);
            //File.WriteAllText("Saves.json", jsonString);
            //Console.WriteLine(jsonString);
            using (FileStream fs = new FileStream("Save.json", FileMode.OpenOrCreate))
            {
               
                await JsonSerializer.SerializeAsync<SettingsViewModel>(fs, GET);

            }
            
        }
       






       
    }
}