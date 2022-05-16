using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Interfaces
{
    public interface IAdress
    {
        string Street { get; set; }
        string Avenue { get; set; }
        int CountyId { get; set; }

        //int CityId { get; set; }

        int OutDoorNumber { get; set; }

        int PhoneNumber { get; set; }
     //   List<string> GetAdress();  // bu durumdda bunu tanımlayamayız string City,County olarak tanımlamdık

 

    }
}
