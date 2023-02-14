using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Responses;

namespace Infrastructure.Tests.DataMocks
{
    public static class BikeMocks
    {
        public static IEnumerable<BikeDetails> GetBikeDetailsMock()
       => new List<BikeDetails>()
       {
            new BikeDetails
            {
                Id = 1,
                DateStolen=null,
                Description="stolen bike is in excellent condition",
                FrameColors = new string[] { "grey","blue"},
                FrameModel="2006",
                IsStockImage=false,
                ManufacturerName="Panther"
            },
            new BikeDetails
            {
                 Id = 2,
                DateStolen=null,
                Description="stolen bike is in average condition",
                FrameColors = new string[] { "pink","red"},
                FrameModel="2016",
                IsStockImage=false,
                ManufacturerName="KONA Bikes"
            }
       };
    }
}
