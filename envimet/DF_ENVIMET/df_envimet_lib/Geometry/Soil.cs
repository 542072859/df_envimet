﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace df_envimet_lib.Geometry
{
    public class Soil : Object2d
    {
        public Soil(Mesh geometry, Material material) : base(geometry, material)
        {
        }
    }
}
