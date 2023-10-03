using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public record PerfumeDto(int Id, string Name, string Brand,float Volume, string Scent, string ImageUrl);
    
}
