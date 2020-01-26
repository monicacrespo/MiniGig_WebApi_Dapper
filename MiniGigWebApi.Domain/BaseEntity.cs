namespace MiniGigWebApi.Domain
{
    using System.ComponentModel.DataAnnotations;

    // This can easily be modified to be BaseEntity<T> and public T Id to support different key types.
    // Using non-generic integer types for simplicity and to ease caching logic
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
