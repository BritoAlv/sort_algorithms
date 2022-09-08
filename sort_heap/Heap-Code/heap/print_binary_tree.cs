/*  
given an array of objects of type T, such that T.toString() has length 1 for every object 
we can visualize it as a tree.
0
11
2222
33333333
4
*/



public static class print_binary_tree
{
    
    public static void print<T>(T[] a) 
    {
        foreach (var item in a)
        {
            if (!(item.ToString().Length == 1))
            {
                throw new ArgumentException("La propiedad .ToString() de los objetos ha de ser de tamaño 1");
            }
        }
        int cant_levels = (int)Math.Ceiling((Math.Log2(a.Length)+0.000001));
        string[,] bid = new string[2*cant_levels-1, 1+2*((int)Math.Pow(2, cant_levels)-2)];
        int espaciado = (1==(int)Math.Pow(2, cant_levels-1))?0:(int)Math.Pow(2, cant_levels-1);
        static void fill(string[,] arr, T[] a, int index_row, int index_column, int space, int ind)
        {
            // pos y is in the rows, pos x is in the columns
            arr[index_row, index_column] = a[ind].ToString();
            int start = index_column-space;
            int end = index_column+space;
            for (int i = start; i < index_column; i++)
            {
                arr[index_row,i] = "-";
            }
            for (int i = index_column+1; i <= end; i++)
            {
                arr[index_row,i] = "-";
            }
            if (index_row+1 < arr.GetLength(0))
            {
            arr[index_row+1, start] = "-";
            arr[index_row+1, end] = "-";                
            }

            // left child of index i in array a is 2*i+1
            space = (space/2 > 1)?space/2:0;
            if (2*ind+1 < a.Length)
            {
                fill(arr, a, index_row+2,start, space, (2*ind+1));
            }
            if(2*ind+2 < a.Length)
            {
                fill(arr, a, index_row+2, end, space, (2*ind+2));
            }
        }
        fill(bid, a, 0,(int)Math.Pow(2, cant_levels)-2, espaciado, 0);
        for (int i = 0; i < bid.GetLength(0); i++)
        {
            for (int j = 0; j < bid.GetLength(1); j++)
            {
                if (String.IsNullOrEmpty(bid[i,j]))
                {
                    Console.Write(" ");
                }
                else if (bid[i,j] == "-")
                {
                    Console.Write("-");
                }
                else
                {
                    Console.Write(bid[i,j]);
                }
            }
            Console.Write("\n");
        }
    }
}

/*
public class program
{
    public static void Main()
    {
        print_binary_tree.print(new string[6]{"a","b","c","d","e","f"});
    }
}
*/



