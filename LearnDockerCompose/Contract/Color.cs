using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnDockerCompose.Contract
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ColorCode { get; set; }
    }
}
