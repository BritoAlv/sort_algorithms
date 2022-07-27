public class Matriz_Cuadrada : IComparable<Matriz_Cuadrada>
{
    public readonly int lado;
    int[,] matriz;
    public Matriz_Cuadrada(int lado = -1)
    {
        Random Azar = new Random();
        this.lado = lado;
        if(lado == -1)this.lado = Random.Next(5);//Matrices hasta de tamanho 5, esto es ajustable pero tuve miedo que pa matrices muy grandes StackOverflow will occur
        this.matriz = new int[this.lado, this.lado];
        for(int i = 0; i < this.lado; i++)
            for(int j = 0; j < this.lado; j++)
                this.matriz[i, j] = Azar.Next(-10, 10);
    }
    public Matriz_Cuadrada(int[,] matriz)
    {
        if(matriz.GetLength(0) != matriz.GetLength(1))throw new Exception("Non Square Matrix");
        this.lado = matriz.GetLength(0);
        this.matriz = new int[this.lado, this.lado];
        for (int i = 0; i < this.lado; i++)
            for (int j = 0; j < this.lado; j++)
                this.matriz[i, j] = matriz[i, j];
    }
    public static GetRandomArray(int size)
    {
        Matriz_Cuadrada[] A = new Matriz_Cuadrada[size];
        for (int i = 0; i < A.Length; A[i++] = new Matriz_Cuadrada());
        return A;
    }
    public int CompareTo(Matriz_Cuadrada other)
    {
        return this.Determinante - other.Determinante;
    }
    public int Determinante
    {
        get
        {
            //Para hacer esto ineficiente en complejidad y uso de memoria, lo calcularemos una y otra vez, usando bordeo por menores, creando ademas nuevas matrices para cada menor
            if(this.lado == 1)return this.matriz[0, 0];
            int determinante = 0;
            for (int i = 0; i < lado; i++)
                determinante += this.matriz[0, i]*(this.Menor_Asociado(i).Determinante)*Signo(i);
            return determinante;
            int Signo(int i)
            {
                return (((i&1) == 0)?1:-1);
            }
        }
    }
    Matriz_Cuadrada Menor_Asociado(int x)
    {
        int[,] nueva_matriz = new int[this.lado - 1, this.lado - 1];
        for (int i = 1; i < lado; i++)
            for (int j = 0; j < lado; j++)
                if(j != x)nueva_matriz[i - 1, ((j < x)?j:(j - 1))] = this.matriz[i, j];
        return new Matriz_Cuadrada(nueva_matriz);
    }
    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < lado; i++)
        {
            for (int j = 0; j < lado; s += this.matriz[i, j++]);
            s += "\n";
        }
        return s;
    }
}
