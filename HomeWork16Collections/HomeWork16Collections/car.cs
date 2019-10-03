using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16Collections {
    public class Car
    {

        public string Model { get; set; }
        public string Colour{ get; set; }
        public string Engine { get; set; }
        public Car(string model, string colour, string engine)
        {
            this.Model = model;
            this.Colour = colour;
            this.Engine = engine;
        }
        //public string model
        //{
        //    get
        //    {
        //        return Model;
        //    }
        //    set
        //    {
        //        Model = value;
        //    }
        //}

        //public string colour
        //{
        //    get
        //    {
        //        return Colour;
        //    }
        //    set
        //    {
        //        Colour = value;
        //    }
        //}
        //public string engine
        //{
        //    get
        //    {
        //        return Engine;
        //    }
        //    set
        //    {
        //        Engine = value;
        //    }
        //}
    }
}
  