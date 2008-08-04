// **********************************************************************************************************************
// 
// Copyright (c)2007, Realtime Worlds Ltd. All Rights reserved.
// 
// File:	    	SPCList.cs
// Created:	        11/03/2008
// Author:    		bert.mcdowell
// Project:		    dWorld
// Description:   	Thread Safe Multiple Producer / Consumer List.
//
//                  TODO :: Improve this to try and minmise or remove locks. 
//
// Date				Version		BY		Comment
// ----------------------------------------------------------------------------------------------------------------------
// 11/03/2008		1.0         BMcD    First Pass
// 
// **********************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace dWorld.Foundation.Utility.Threading
{
	public class MPCList<T> : SPCList<T> where T : class
	{
		public MPCList () : this (1000)
		{
		}

		public MPCList (int _capacity) : base (_capacity)
		{
		}
	}
}
