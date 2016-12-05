using System;

namespace Procalender.Application
{
    internal class Participant
    {
        public string Name;
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public DateTime AnswerDay { get; set; }
        public string AnswerOnQuestion { get; set; }
    }
}
