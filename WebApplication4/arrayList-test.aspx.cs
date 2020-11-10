using System;
using System.Collections;
using System.Web.UI;

namespace WebApplication4
{
    public partial class arrayList_test : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            // 实例化
            ArrayList List = new ArrayList();
            // 把数组放进去arraylist集合
            int[] arr = {1, 2, 3, 4};
            ArrayList list = new ArrayList(arr);
            // 用指定大小的初始化内部的数组。构造器格式如下：
            ArrayList list2 = new ArrayList();
            for (var i = 0; i < 10; i++)
            {
                list2.Add(i);
            }
            */

            int[] arr = {1, 2, 3, 4, 5, 6, 7, 8};
            ArrayList list = new ArrayList(arr);
            for (int i = 1; i < 6; i++)
            {
                list.Add(i + arr.Length);
            }

            /*
            // add 末尾添填
            list.Add(7);
            // 索引位添加值
            list.Insert(6, 6);
            // 移除与3匹配的元素 删数值=3的删除掉
            list.Remove(3);
            // 移除索引为3的元素。 删所因为是3的值
            list.RemoveAt(3);
            // 从索引3开始删除2个元素
            list.RemoveRange(3, 2);
            // 全部清除
            list.Clear();
            */
            // 确定某元素是否在 ArrayList 中。
            list.Contains(8);
            // 搜索指定 Object 并返回整个内的第一个匹配项的从零开始索引 ArrayList。
            list.IndexOf(8);
            // 在整个 ArrayList 中搜索指定的 Object，并返回最后一个匹配项的从零开始的索引。
            list.LastIndexOf(8);

        }
    }
}