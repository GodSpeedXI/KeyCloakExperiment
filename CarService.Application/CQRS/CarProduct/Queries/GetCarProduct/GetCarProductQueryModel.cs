namespace CarService.Application.CQRS.CarProduct.Queries.GetCarProduct
{
    public class GetCarProductQueryModel
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Series { get; set; }
        public string Nickname { get; set; }
    }
}
