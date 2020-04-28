using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp32
{
	public class BinaryTree
	{
		private static bool result = true;
		public static int minLeaf = Int32.MaxValue; //минимальное значение листа
		public static int leftCount = 0;
		public static int rightCount = 0;
		private class Node
		{
			public object inf; //информационное поле   
			public Node left; //ссылка на левое поддерево   
			public Node rigth;// правое поддерево 

			public Node(object nodeInf)
			{
				inf = nodeInf;
				left = null;
				rigth = null;
			}

			public static void Add(ref Node r, object nodeInf)//добавление узла
			{
				if (r == null)
				{
					r = new Node(nodeInf);
				}
				else
				{

					if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0)
					{
						Add(ref r.left, nodeInf);
					}
					else
					{
						Add(ref r.rigth, nodeInf);
					}
				}
			}
			public static void Preorder(Node r) //прямой обход дерева    
			{
				if (r != null)
				{
					Console.Write("{0} ", r.inf);
					Preorder(r.left);
					Preorder(r.rigth);
				}
			}

			public static void Inorder(Node r) //симметричный обход дерева   
			{
				if (r != null)
				{
					Inorder(r.left);
					Console.Write("{0} ", r.inf);
					Inorder(r.rigth);
				}
			}

			public static void Postorder(Node r) //обратный обход дерева    
			{
				if (r != null)
				{
					Postorder(r.left);
					Postorder(r.rigth);
					Console.Write("{0} ", r.inf);
				}
			}
			//поиск ключевого узла в дереве    
			public static void Search(Node r, object key, out Node item)
			{
				if (r == null)
				{
					item = null;
				}
				else
				{
					if (((IComparable)(r.inf)).CompareTo(key) == 0)
					{
						item = r;
					}
					else
					{
						if (((IComparable)(r.inf)).CompareTo(key) > 0)
						{
							Search(r.left, key, out item);
						}
						else
						{
							Search(r.rigth, key, out item);
						}
					}
				}
			}

			public static void LeafSearch(Node r)
			{
				if (r.left == null && r.rigth == null)
				{
					Console.WriteLine("Лист:{0}", r.inf);
					if (Convert.ToInt32(r.inf) < minLeaf)
					{
						minLeaf = Convert.ToInt32(r.inf);
					}
				}
				else
				{
					if (r.left != null)
					{
						LeafSearch(r.left);
					}
					if (r.rigth != null)
					{
						LeafSearch(r.rigth);
					}
				}
			}

			public static void LeftBranchCounter(Node r)
			{
				if (r.left != null)
				{
					leftCount++;
					LeftBranchCounter(r.left);
				}
				if (r.rigth != null)
				{
					leftCount++;
					LeftBranchCounter(r.rigth);
				}
			}
			public static void RightBranchCounter(Node r)
			{
				if (r.left != null)
				{
					rightCount++;
					RightBranchCounter(r.left);
				}
				if (r.rigth != null)
				{
					rightCount++;
					RightBranchCounter(r.rigth);
				}
			}

			public static void BranchCounter(Node r)
			{
				if (r.left != null)
				{
					leftCount++;
					LeftBranchCounter(r.left);
				}
				if (r.rigth != null)
				{
					rightCount++;
					RightBranchCounter(r.rigth);
				}
				if ((leftCount - rightCount) <= 1 && (leftCount - rightCount) >= -1)
				{
					leftCount = 0;
					rightCount = 0;
					if (r.left != null)
						BranchCounter(r.left);
					if (r.rigth != null)
						BranchCounter(r.rigth);
				}
				else
				{
					result = false;
					return;
				}
			}

			public static void BalanceCheck()
			{
				if (result)
				{
					Console.WriteLine("Дерево сбалансированно!");
				}
				else
				{
					Console.WriteLine("Дерево не сбалансированно");
				}
				leftCount = 0;
				rightCount = 0;
			}

			//методы Del и Delete позволяют удалить узел в дереве так, чтобы дерево при этом   
			//оставалось деревом бинарного поиска    
			private static void Del(Node t, ref Node tr)
			{
				if (tr.rigth != null)
				{
					Del(t, ref tr.rigth);
				}
				else
				{
					t.inf = tr.inf;
					tr = tr.left;
				}
			}

			public static void Delete(ref Node t, object key)
			{
				if (t == null) { throw new Exception("Данное значение в дереве отсутствует"); }
				else
				{
					if (((IComparable)(t.inf)).CompareTo(key) > 0) { Delete(ref t.left, key); }
					else
					{
						if (((IComparable)(t.inf)).CompareTo(key) < 0) { Delete(ref t.rigth, key); }
						else
						{
							if (t.left == null) { t = t.rigth; }
							else
							{
								if (t.rigth == null)
								{
									t = t.left;
								}
								else
								{
									Del(t, ref t.left);
								}
							}
						}
					}
				}
			}
		}
		Node tree;//ссылка на корень дерева
		public object Inf
		{
			set { tree.inf = value; }
			get { return tree.inf; }
		}
		public BinaryTree() //открытый конструктор   
		{
			tree = null;
			minLeaf = Int32.MaxValue;
			result = true;
		}
		private BinaryTree(Node r) //закрытый конструктор   
		{
			tree = r;
		}
		public void Add(object nodeInf) //добавление узла в дерево   
		{
			Node.Add(ref tree, nodeInf);
		}
		//организация различных способов обхода дерева   
		public void Preorder()
		{
			Node.Preorder(tree);
		}
		public void Inorder()
		{
			Node.Inorder(tree);
		}
		public void Postorder()
		{
			Node.Postorder(tree);
		}

		public void LSearch()//поиск всех листьев и нахождение минимального
		{
			Node.LeafSearch(tree);
		}

		public void ShowMinLeaf()//вывод минимального листа
		{
			Console.WriteLine("Минимальное значение листа:{0}", BinaryTree.minLeaf);
			minLeaf = Int32.MaxValue;
		}

		public void TreeBalanced()
		{
			Node.BranchCounter(tree);
			Node.BalanceCheck();
			result = true;
		}
	}




	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Input 1\n");
			string path = "input1.txt";
			using (StreamReader fileIn = new StreamReader(path))
			{
				string str = fileIn.ReadToEnd();
				string[] stringArray = str.Split(' ');
				int[] array = new int[stringArray.Length];
				for (int i = 0; i < array.Length; ++i)
				{
					array[i] = int.Parse(stringArray[i]);
				}
				BinaryTree tree = new BinaryTree();
				foreach (int item in array)
				{
					tree.Add(item);
				}
				tree.LSearch();
				tree.ShowMinLeaf();
				tree.TreeBalanced();
			}


			Console.WriteLine("\nInput 2\n");
			path = "input2.txt";
			using (StreamReader fileIn = new StreamReader(path))
			{
				string str = fileIn.ReadToEnd();
				string[] stringArray = str.Split(' ');
				int[] array = new int[stringArray.Length];
				for (int i = 0; i < array.Length; ++i)
				{
					array[i] = int.Parse(stringArray[i]);
				}
				BinaryTree tree = new BinaryTree();
				foreach (int item in array)
				{
					tree.Add(item);
				}
				tree.LSearch();
				tree.ShowMinLeaf();
				tree.TreeBalanced();
				Console.ReadLine();
			}

		}
	}
}
