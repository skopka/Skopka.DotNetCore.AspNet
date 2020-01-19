using System.ComponentModel.DataAnnotations;

namespace Skopka.DotNetCore.AspNet.FirstApp.Models
{
    public class HelloWorldModel
    {
        [Required(ErrorMessage = "Представься, пожалуйста")]
        public string Name { get; set; }
    }
}
