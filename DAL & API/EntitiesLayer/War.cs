﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class War : EntityObject
    {
        static int currId;

        public War()
        {
            Id = currId;
            currId++;
        }
    }
}