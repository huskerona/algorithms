﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Algorithms.Tests
{
	public class FindLastNodeOnLevelTest
	{
		[Theory]
		[InlineData("ABCDEFGHIJKLMNOP", "ACGO")]
		public void ConnectTreeNodesAtSameLevel(string data, string expected)
		{
			TreeNode root = CreateTreeNode.Do(data);

			int i = 1, j = 0;
			List<char> list = new List<char>(data.Length);
			Action<TreeNode> visit = n =>
			{
				if (Math.Log(++i, 2) % 1 == 0)
				{
					Debug.WriteLine("{0} is last node on level {1}", n.Value, ++j);
					list.Add((char)n.Value);
				}
			};

			BreadthFirstTraversal.Do(root, visit);

			Assert.Equal(new string(list.ToArray()), expected);
		}
	}
}