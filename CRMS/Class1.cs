﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS
{
    public class Class1
    {
        private string id;
        private string name;
        private string contact;
        private string passport;

        public Class1(string id, string name, string contact, string Passport)
        {
            this.id = id;
            this.name = name;
            this.contact = contact;
            this.passport = Passport;
        }
        public Class1() { }

        public string ID { get { return this.id; } set { this.id = value; }}
        public string Name{ get { return this.name; }set { this.name = value; } }
        public string Contact{ get { return this.contact; } set { this.contact = value; } }
        public string Passport { get { return this.passport; } set { this.passport = value; } }
    }
}
