using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2MVC.Models
{
    public class AirplaneRepo
    {
        public List<Airplane> airplanes;

        public AirplaneRepo()
        {
            airplanes = new List<Airplane>();
            airplanes
                .Add(
                    new Airplane(
                        "USA", 
                        "North American Aviation",
                        "P-51 Mustang",  
                        Usage.MILITARY, 
                        true,
                        1942, 
                        "https://ru.wikipedia.org/wiki/North_American_P-51_Mustang")
                    );
            airplanes
                .Add(
                    new Airplane(
                        "Germany",
                        "Messerschmitt",
                        "Messerschmitt Bf-109",
                        Usage.MILITARY,
                        true,
                        1937,
                        "https://en.wikipedia.org/wiki/Messerschmitt_Bf_109")
                );
            airplanes
                .Add(
                    new Airplane(
                        "USSR",
                        "Saratov airplane factory",
                        "Yak-1",
                        Usage.MILITARY,
                        true,
                        1940,
                        "https://en.wikipedia.org/wiki/Yakovlev_Yak-1")
                );

        }

    }
}
