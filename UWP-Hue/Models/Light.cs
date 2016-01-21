using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Hue.Models
{
    public class Light
    {
        public Light() { }

        private int id;
        private int brightness;
        private int hue;
        private int saturation;
        private bool on;
        private string name;
        private string type;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int Brightness
        {
            get
            {
                return brightness;
            }

            set
            {
                brightness = value;
            }
        }

        public int Hue
        {
            get
            {
                return hue;
            }

            set
            {
                hue = value;
            }
        }

        public int Saturation
        {
            get
            {
                return saturation;
            }

            set
            {
                saturation = value;
            }
        }

        public bool On
        {
            get
            {
                return on;
            }

            set
            {
                on = value;
            }
        }
    }
}
