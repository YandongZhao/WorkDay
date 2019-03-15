using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm
{
    public class TreeHelper
    {
        public  string BindTree<T>(ITreeNodes<T> treeModel)where T : ITreeNodes<T>
        {
            StringBuilder sb = new StringBuilder();
            if (treeModel != null)
            {
                sb.Append("<ul>");
                List<T> list = treeModel.Children.ToList();
                foreach (T item in list)
                {
                    sb.Append("<li>");
                    sb.Append(item.Name);
                    sb.Append("</li>");
                    sb.Append(BindTree(item));
                }
                sb.Append("</ul>");
            }
            return sb.ToString();
        }
        
    }

   

    public interface ITreeNodes<T> 
    {
        List<T> Children { get; set; }
        string Name { get; }
    }
    
}
