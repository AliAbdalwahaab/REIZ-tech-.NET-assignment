namespace Assignment
{
    class Branch
    {
        //Instance variables.
        List<Branch> branches;

        //Constructor.
        public Branch()
        {
            branches = new List<Branch>();
        }

        //When called, calculates the lowest depth from a root branch.
        public static int getDepth(Branch root)
        {
            //base case: if no sub branches are found, return the depth of current branch/leaf = 1.
            if (root.branches.Count == 0)
            {
                return 1;
            }

            else
            {
                //Set max depth as current depth = 0.
                int maxDepth = 0;

                //loop on all sub branches and get their corresponding depths.
                foreach (Branch subBranch in root.branches)
                {
                    //get the depths of all sub branches and compare them to determine the maximum.
                    int subDepth = getDepth(subBranch);
                    maxDepth = Math.Max(maxDepth, subDepth);
                }
                //if sub branches are found, add another level to the maximum found depth.
                return maxDepth + 1;
            }
        }

        //This method is used to visualize the tree, just checking whether nodes were added correctly.
        public static void visualize(Branch root, string indent, bool isLast)
        {
            //initial indentation of the current branch.
            Console.Write(indent);

            //if there are no more sub branches to the current branch, write the level-lower group.
            if (isLast)
            {
                Console.Write("└── ");
                indent += "    ";
            }

            //if there are more sub branches, write the same-level group.
            else
            {
                Console.Write("├── ");
                indent += "│   ";
            }


            //place holder string to indicate a branch.
            Console.WriteLine("branch");

            //for all existing sub branches to a given branch, write them and recursively print their sub branches as well.
            for (int i = 0; i < root.branches.Count; i++)
            {
                //initial indentation of the sub branch should be further than the original indentation
                string subBranchIndent = indent + "    ";
                bool isSubBranchLast = (i == root.branches.Count - 1);

                //visualize the sub branches of current branch.
                visualize(root.branches[i], subBranchIndent, isSubBranchLast);
            }
        }


        public static void Main()
        {
            Branch root = new Branch();
            root.branches.Add(new Branch());
            root.branches.Add(new Branch());
            root.branches[0].branches.Add(new Branch());
            root.branches[1].branches.Add(new Branch());
            root.branches[1].branches.Add(new Branch());
            root.branches[1].branches.Add(new Branch());
            root.branches[1].branches[0].branches.Add(new Branch());
            root.branches[1].branches[1].branches.Add(new Branch());
            root.branches[1].branches[1].branches.Add(new Branch());
            root.branches[1].branches[1].branches[0].branches.Add(new Branch());

            visualize(root, "", true);
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine("\n Tree depth = " + getDepth(root) + ".");
        }
    }


}