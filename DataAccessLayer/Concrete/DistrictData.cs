using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public static class DistrictData
    {
        public static List<District> GetList()
        {
            List<District> districts = new List<District>() {
                new District() {Id=6, Name = "30 Ağustos" },
                new District() {Id=7, Name = "Süvari" },
                new District() {Id=8, Name = "İstasyon" },
                new District() {Id=9, Name = "Kazım Karabekir" }
            };
            return districts;
        }
    }
}
