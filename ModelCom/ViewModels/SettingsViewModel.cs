using DocumentFormat.OpenXml.Office.CustomUI;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Text.Json.Serialization;

namespace ModelCom.ViewModels
{

    public class SettingsViewModel: ViewModelBase
    {
        public SettingsViewModel() {
            IsCheckedCheckBox1 = true;
            IsCheckedCheckBox2 = true;




        }
        public string set1 = "100";
        public string set2 = "100";
        public string set3 = "1";
        public string Set1 { 
            get=> set1;
            set
            {
                set1 = value;
                this.RaiseAndSetIfChanged(ref set1, value);
            }
        }
        public string Set2
        {
            get => set2;
            set
            {
                set2 = value;
                this.RaiseAndSetIfChanged(ref set2, value);
            }
        }
        public string Set3
        {
            get => set3;
            set
            {

                set3 = value;
                this.RaiseAndSetIfChanged(ref set3, value);
            }
        }
       
        public ButtonModel button1 = new ButtonModel { ButtonText = "Gray" };
        public ButtonModel button2 = new ButtonModel { ButtonText = "Gray" };
        public bool IsCheckedX = true;
        public bool IsCheckedY = true;
        public bool IsChecked1 { get=> IsCheckedX; set { this.RaiseAndSetIfChanged(ref IsCheckedX, value); } }
        public bool IsChecked2 { get => IsCheckedY; set { this.RaiseAndSetIfChanged(ref IsCheckedY, value); } }
        public bool IsCheckedCheckBox1 { get ; set ; }
        public bool IsCheckedCheckBox2 { get ; set ; }
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
        public void ChecBoxClicked1()
        {
            if (IsChecked1)
            {
                Button1 = new ButtonModel { ButtonText = "White" };
               
                IsChecked1 = false;
                IsCheckedCheckBox1 = false;
            }
            else
            {
               
                IsChecked1 = true;
                IsCheckedCheckBox1 = true;
                Button1 = new ButtonModel { ButtonText = "Gray" };

            }

        }
        public void ChecBoxClicked2()
        {
            if (IsChecked2)
            {
                Button2 = new ButtonModel { ButtonText = "White" };
               
                IsChecked2 = false;
                IsCheckedCheckBox2 = false;
            }
            else
            {
                IsCheckedCheckBox2 = true;
                IsChecked2 = true;
                Button2 = new ButtonModel { ButtonText = "Gray" };

            }

        }
        
       
    }
   
}
