using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_Hue.Models;

namespace UWP_Hue
{
    public sealed class HueStore
    {
        private static HueStore instance = null;
        private static readonly object padlock = new object();

        HueStore() { }

        public static HueStore Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new HueStore();
                    }

                    return instance;
                }
            }
        }

        public Authentication authenticationObject;

        public List<Light> lights = new List<Light>();
    }
}
