using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls.Shapes;
using Avalonia.Controls;
using ModelCom;
using ModelCom.Models;
using ModelCom.Services;
using ModelCom.Views;
using ReactiveUI;
using Avalonia.Media;
using System.Collections.ObjectModel;
using System.Drawing;
using Avalonia;
using System.Collections.Immutable;

namespace ModelCom.ViewModels
{
    public class GraphicsViewModel : ViewModelBase
    {
       
        //public int[,] x { get; set; }
        public PointSize graphicsView=new PointSize(false);

        public PointSize GraphicsView 
        {
            get => graphicsView; 
            
            set
            {

                this.RaiseAndSetIfChanged(ref graphicsView, value);

            }
        }
        
        public void Graphics()
        {
           
            GraphicsView = new PointSize(true);
            
           

        }


    }

    public class PointSize : Shape
    {
        protected override Geometry? CreateDefiningGeometry()
        {
            throw new NotImplementedException();
        }
       // public Canvas Field { get; set; }
        public Polyline pointline { get; set; }
        public PointSize(bool Gr)

        {
            if (Gr)
            {
                Graph();
            }
            else
            {
                pointline = new Polyline();
                pointline.Points = new ObservableCollection<Avalonia.Point>();
                pointline.Points.Add(new Avalonia.Point(0, 0));
                pointline.Points.Add(new Avalonia.Point(0, 0));
            }
        }
        public void Graph()
        {
            Random rnd = new Random();
            pointline = new Polyline();

            pointline.Points = new ObservableCollection<Avalonia.Point>();
            for (int i = 0; i < 1000; i++)
            {
                double x = rnd.Next(0, 1200);
                double y = rnd.Next(-350, 350);
                pointline.Points.Add(new Avalonia.Point(x, y));
            }
          // pointline.Points;
        }

    }
}
