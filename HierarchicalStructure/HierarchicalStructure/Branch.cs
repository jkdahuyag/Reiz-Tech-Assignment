namespace HierarchicalStructure
{
	//The flow will be from left to right
	//first child will be the leftmost branch while the last child will be the rightmost child
	public class Branch
	{
		public List<Branch> Branches { get; private set; } = new List<Branch>();

		public void AddBranch()
		{
			Branches.Add(new Branch());
		}
	}
}