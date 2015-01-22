using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAndRetrievePicturesWPF.Model
{
   public  class User
    {
        [Key]
        public int Id { get; set; }

        public String Nom { get; set; }

        public String Prenom { get; set; }

        public String Tel { get; set; }

        public String Fonction { get; set; }
        public string ImagePath { get; set; }
        public byte[] ImageToByte { get; set; }
    }
}
