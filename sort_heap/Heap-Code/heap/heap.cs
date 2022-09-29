public static class idk
{
    /////////////////////////////////////////////////////////////////////////////////////////////////
    /// aplication of the heap to merge sorted lists. <summary>
    /////////////////////////////////////////////////////////////////////////////////////////////////   

    /*
    merge list of same type of objects
    */
    public static List<T> merge_k_list<T>(params List<T>[] lists) where T : IComparable
    {
        Dictionary<int, List<id_element<T>>> a = new Dictionary<int, List<id_element<T>>>();
        for (int i = 0; i < lists.Count(); i++)
        {
            a[i] = new List<id_element<T>>();
            foreach (var item in lists[i])
            {
                id_element<T> temp = new id_element<T>(i, item);
                a[i].Add(temp);
            }
        }
        List<id_element<T>> c = merge_k_list(a);
        List<T> result = new List<T>();
        foreach (var item in c)
        {
            result.Add(item.val);
        }
        return result;
    }


    /* 
    merge list of diferent type of objects.
    */
    public static List<id_element<T>> merge_k_list<T>(Dictionary<int, List<id_element<T>>> lists) where T : IComparable
    {
        // takes k sorted lists of elements of id_element we use char to identifie the list,
        // so two elements in the same list have sAme char value.
        List<id_element<T>> result = new List<id_element<T>>();
        min_heap<id_element<T>> b = new min_heap<id_element<T>>();
        int total = 0;
        foreach (var item in lists)
        {
            int templ = item.Value.Count();
            if (templ > 0)
            {
                b.insert(item.Value[0]);
                total = total + templ;
            }
        }
        for (int i = 0; i < total; i++)
        {
            id_element<T> temp = b.extract_min();
            lists[temp.id].RemoveAt(0);
            result.Add(temp);
            if (lists[temp.id].Count > 0)
            {
                b.insert(lists[temp.id][0]);
            }
        }
        return result;
    }
}

public class id_element<U> : IComparable<id_element<U>> where U : IComparable
{
    public int id;
    public U val;

    public id_element(int id, U val)
    {
        this.id = id;
        this.val = val;
    }

    public int CompareTo(id_element<U> other)
    {
        return this.val.CompareTo(other.val);
    }


}

/////////////////////////////////////////////////////////////////////////////////////////////////
/// aplication of the heap to merge sorted lists. 
/////////////////////////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////////////////////////////////////////
/// the heap
/////////////////////////////////////////////////////////////////////////////////////////////////


/*
Given an array of objects of type T we can visualize them as a binary tree, this is a heap, now if we also add the property og
that every father has to be less than its two childs, we get a min-heap.
*/
public class min_heap<T> where T : IComparable<T>
{
    public List<T> A;
    public min_heap()
    {
        this.A = new List<T>();
    }
    public min_heap(IEnumerable<T> B)
    {
        this.A = new List<T>();
        foreach (var item in B)
        {
            this.insert(item);
        }
    }

    public T get_min()
    {
        return this.A[0];
    }

    public void fix_father(int index)
    {
        int father = (index - 1) / 2;
        if (father >= 0)
        {
            if (this.A[index].CompareTo(this.A[father]) < 0)
            {
                T temp = this.A[father];
                this.A[father] = this.A[index];
                this.A[index] = temp;
                fix_father(father);
            }
        }
    }

    public void fix_child(int index)
    {
        // compute index of childs of index.
        int chil1 = 2 * index + 1;
        int chil2 = 2 * index + 2;

        // store A[index] in a  temp variable
        T temp = this.A[index];
        if (chil2 < this.A.Count) // index have two children
        {
            // set variable child to menor of the two indexes.
            int child = chil2;
            if (this.A[chil1].CompareTo(this.A[chil2]) < 0)
            {
                child = chil1;
            }
            if (this.A[child].CompareTo(this.A[index]) < 0)
            {
                this.A[index] = this.A[child];
                this.A[child] = temp;
                fix_child(child);
            }

        }
        else if (chil2 == this.A.Count) // have only left children
        {
            if (this.A[chil1].CompareTo(this.A[index]) < 0)
            {

                this.A[index] = this.A[chil1];
                this.A[chil1] = temp;
            }
        }
        else
        {
            // doesnt have either left or right childs so we are done.
        }
    }

    public void insert(T val)
    {
        // insert a value into the heap
        int its = this.A.Count;
        this.A.Add(val);
        fix_father(its);
    }

    public T extract_min()
    {
        T temp = this.A[0];
        if (this.A.Count == 1)
        {
            this.A.RemoveAt(0);
        }
        else
        {
            this.A[0] = this.A.Last();
            this.A.RemoveAt(this.A.Count - 1);
            fix_child(0);
        }
        return temp;
    }
    public override string ToString()
    {
        string print<T>(T[] a) // to print an array as a binary tree, just pass the array as argument.
        {
            int cant_levels = (int)Math.Ceiling((Math.Log2(a.Length) + 0.000001));
            string[,] bid = new string[2 * cant_levels - 1, 1 + 2 * ((int)Math.Pow(2, cant_levels) - 2)];
            int espaciado = (1 == (int)Math.Pow(2, cant_levels - 1)) ? 0 : (int)Math.Pow(2, cant_levels - 1);
            static void fill(string[,] arr, T[] a, int index_row, int index_column, int space, int ind)
            {
                // pos y is in the rows, pos x is in the columns
                arr[index_row, index_column] = a[ind].ToString();
                int start = index_column - space;
                int end = index_column + space;
                for (int i = start; i < index_column; i++)
                {
                    arr[index_row, i] = "-";
                }
                for (int i = index_column + 1; i <= end; i++)
                {
                    arr[index_row, i] = "-";
                }
                if (index_row + 1 < arr.GetLength(0))
                {
                    arr[index_row + 1, start] = "-";
                    arr[index_row + 1, end] = "-";
                }

                // left child of index i in array a is 2*i+1
                space = (space / 2 > 1) ? space / 2 : 0;
                if (2 * ind + 1 < a.Length)
                {
                    fill(arr, a, index_row + 2, start, space, (2 * ind + 1));
                }
                if (2 * ind + 2 < a.Length)
                {
                    fill(arr, a, index_row + 2, end, space, (2 * ind + 2));
                }
            }
            fill(bid, a, 0, (int)Math.Pow(2, cant_levels) - 2, espaciado, 0);
            string result = "";
            for (int i = 0; i < bid.GetLength(0); i++)
            {
                for (int j = 0; j < bid.GetLength(1); j++)
                {
                    if (String.IsNullOrEmpty(bid[i, j]))
                    {
                        result = result + " ";
                    }
                    else if (bid[i, j] == "-")
                    {
                        result = result + "-";
                    }
                    else
                    {
                        result = result + bid[i, j];
                    }
                }
                result = result + "\n";
            }
            return result;
        }
        return print(this.A.ToArray());
    }
}

public class program
{
    public static void Main()
    {

        min_heap<int> X = new min_heap<int>(new List<int>() { 1, 2, 3, 5, 6, 4 });
        int len = X.A.Count;
        List<int> c = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            int temp = X.extract_min();
            Console.WriteLine(X);
            c.Add(temp);
        }

        foreach (var item in c)
        {
            Console.Write(item + " ");
        }

    }
}