using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchicalStructure
{
	public class HierarchicalStructure
	{
		public Branch Root { get; set; }
		public int Depth { get; private set; }

		public void CalculateDepth()
		{
			if (Root == null) return;
			CalculateDepthHelper(Root, 1);
		}

		private void CalculateDepthHelper(Branch branchToCheck,int depthOfBranch)
		{
			Queue<Branch> childrenToCheck = new Queue<Branch>();
			if (branchToCheck.Branches.Count != 0) depthOfBranch++;
			
			foreach (var branch in branchToCheck.Branches)
			{
				childrenToCheck.Enqueue(branch);
			}
			while (childrenToCheck.Count != 0)
			{
				CalculateDepthHelper(childrenToCheck.Dequeue(), depthOfBranch);
			}

			if (depthOfBranch > Depth) Depth = depthOfBranch;
			
		}

	}
}
