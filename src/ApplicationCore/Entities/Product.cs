namespace ApplicationCore.Entities
{
    public class Product :BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PictureUri { get; set; }   //yolunu tutmak istiyorum.
        public int CategoryId { get; set; }   //hangi categoriye ait
        public Category Category { get; set; }   
        public int BrandId { get; set; }   
        public Brand Brand { get; set; }   
    }
}
