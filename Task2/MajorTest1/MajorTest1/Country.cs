using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace MajorTest1
{
    public class Country
    {
        public int Id { get; set; }

        public string CountryName { get; set; }

        public List<Content> Contents { get; set; }
    }
}
