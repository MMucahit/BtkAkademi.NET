using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record RegisterDto
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        [Required]
        public string UserName { get; init; }
        [Required]
        public string Email { get; init; }
        [Required]
        public string Password { get; init; }
    }
}
