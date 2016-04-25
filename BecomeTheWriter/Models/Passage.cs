using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace BecomeTheWriter.Models
{
    public class Passage
    {
        public long Id { get; set; }

        public string Text { get; set; }

        public bool MustBeOnTheBeginning { get; set; }

        public List<Passage> Before { get; set; } = new List<Passage>();

        public List<Passage> After { get; set; } = new List<Passage>();

        public Passage()
        {
        }

        public Passage(long id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}