

using Rebar.DataAccess;
using Rebar.Models;

namespace Rebar.Modles
{
    public class Shake
    { 
        public string Name { get;}
        public string? Description { get;  }
        public int Price { get; }

        public  Shake(string name,Size size)
        {
            
            MenuAccess db = new();
          var  shakes= db.GetAllShake();
            var index=shakes.Result.FindIndex(item=>item.Name==name);
            if (index == -1)
                throw new Exception("There is no name of such a shake on the menu");
            Name = name;
            Description = shakes.Result[index].Description;

            switch (size) 
            {
                case Size.Small:
                    Price= shakes.Result[index].PriceS; break;
                    case Size.Medium:
                    Price = shakes.Result[index].PriceM;break;
                    case Size.Large:
                    Price = shakes.Result[index].PriceL;break;
            }



        }
    }
}
