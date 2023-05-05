using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace HierarchicalStructure
{
	public class Tests
	{
		[Test]
		public void DepthOfStructure_NoRoot_Depth0()
		{
			//assign
			var structure = new HierarchicalStructure();
			var expectedDepth = 0;
			//act
			structure.CalculateDepth();
			//assert
			structure.Depth.Should().Be(expectedDepth);
		}
		[Test]
		public void DepthOfStructure_RootOnly_Depth1()
		{
			//assign
			var structure = new HierarchicalStructure();
			var root = new Branch();
			structure.Root = root;
			var expectedDepth = 1;
			//act
			structure.CalculateDepth();
			//assert
			structure.Depth.Should().Be(expectedDepth);
		}
		[Test]
		public void DepthOfStructure_GivenStructure_Depth5()
		{
			//assign
			var structure = new HierarchicalStructure();
			var root = new Branch();
			//recreating given branch from problem
			root.AddBranch();
			root.AddBranch();
			root.Branches[0].AddBranch();
			root.Branches[1].AddBranch();
			root.Branches[1].AddBranch();
			root.Branches[1].AddBranch();
			root.Branches[1].Branches[0].AddBranch();
			root.Branches[1].Branches[1].AddBranch();
			root.Branches[1].Branches[1].AddBranch();
			root.Branches[1].Branches[1].Branches[0].AddBranch();
			structure.Root = root;
			var expectedDepth = 5;
			//act
			structure.CalculateDepth();
			//assert
			structure.Depth.Should().Be(expectedDepth);
		}
	}
}
