using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MajorTest1
{
    public class Content
    {
        public int Id { get; set; }
        public string TypeOfContent { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }

        public string Genre { get; set; }

        [ForeignKey("MainActor")]
        public virtual int MainRoleActorId { get; set; }

        [ForeignKey("Actor")]
        public virtual int ActorId { get; set; }

        [ForeignKey("Country")]
        public virtual int CountryId { get; set; }
    }
}
