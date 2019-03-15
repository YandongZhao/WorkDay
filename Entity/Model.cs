using Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public int deptId { get; set; }
    }
    public class Dept
    {
        public int deptId { get; set; }
        public int parentId { get; set; }
        public string deptName { get; set; }
    }

    public class TreeNode
    {
        public string text { get; set; }
        public string icon { get; set; }
        public StateForTreeNode state { get; set; }

        public object li_attr { get; set; }
        public object a_attr { get; set; }
        public List<TreeNode> children { get; set; }
    }

    public class StateForTreeNode
    {
        public bool opened { get; set; }
        public bool disabled { get; set; }
        public bool selected { get; set; }
    }
}
