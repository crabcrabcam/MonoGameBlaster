﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoBlaster
{
	public static class Extensions 
	{
		public static float ToAngle(this Vector2 vector)
		{
			return (float)Math.Atan2(vector.Y, vector.X);
		}

		public static float NextFloat(this Random rand, float minValue, float maxValue)
		{
			return (float)rand.NextDouble() * (maxValue - minValue) + minValue;
		}
	}



}
