Esta carpeta se refiere al algoritmo de ordenación *Quick-Sort*:

Este es un algoritmo **divide and conquer** de ordenación recursivo que es **in-place** como se puede observar en la tabla del benchmark de este, que la memoria consumida es para almacenar un array de enteros random de tamaño $1000*k$, este algoritmo no es **estable** puesto que dos elementos iguales no tienen una posición específica después de ordenar el array (pueden acabar uno delante del otro, o viceversa).

Para determinar la complejidad del algoritmo notemos  que un ejemplo  de su peor caso es cuando escogemos como pivote siempre el elemento más a la izquierda y tenemos una lista ordenada de mayor a menor, notemos que la función particionar será llamada  en casos como el anterior $n$ veces y cada vez hará un trabajo linear que implicará un peor caso de $O(n^2)$ pero este peor caso puede ser evitado escogiendo como pivote un elemento random en el subarray de esta forma es imrobable que caigamos en una situación como lo anterior y asumiendo que en el **mejor** de los casos sucederá que el elemento que escogemos como pivote estará en el medio del subarray lo que permite sacar la siguiente conclusión (en una situación ideal):

$T(n) = O(n) + 2*T(\frac{n}{2})$, la solución de esta recurrencia es $n\log_2{n}$ , observar el siguiente Tree: 

![](g12.png)

Sea $m =\log_2{n}$ la parte entera de el logaritmo en base $2$ de $n$, entonces la altura del  árbol es $m+1$ y tiene $2^m$ leaves, notemos que en cada nivel del árbol el trabajo hecho es $cn$ donde $cn$ representa el $O(n)$ realizado por la función particionar. Esto es un análisis para el mejor de los casos (casi siempre debido a escoger un elemento random) que al escoger un elemento random podemos ver que genera un tiempo de $0.005 n\log_2{n}$ .

Se tomó arreglos de enteros de tamaño $n$ generados aleatoriamente y el pivote es escogido de manera random para realizar el siguiente benchmark. El tiempo de ejecución sería de $0.005 n\log_2{n}$.

| Función      | Tamaño (n) | Tiempo | Factor Constante $n\lg_2(n)$ | Bytes Memoria Total |
|:------------:| ---------- | ------ | ---------------------------- |:-------------------:|
| quick_sort_1 | 1000       | 58.73  | 0.00589316388178187          | 4024                |
| quick_sort_1 | 2000       | 126.11 | 0.00575015870850163          | 8024                |
| quick_sort_1 | 3000       | 196.2  | 0.00566197157769571          | 12024               |
| quick_sort_1 | 4000       | 268.63 | 0.00561246119789101          | 16024               |
| quick_sort_1 | 5000       | 343.31 | 0.00558785865742388          | 20024               |
| quick_sort_1 | 6000       | 418.93 | 0.00556314838157534          | 24024               |
| quick_sort_1 | 7000       | 494.99 | 0.00553605938199253          | 28025               |
| quick_sort_1 | 8000       | 571.38 | 0.00550853680980097          | 32025               |
| quick_sort_1 | 9000       | 648.09 | 0.00548200317406352          | 36025               |
| quick_sort_1 | 10000      | 728.37 | 0.00548153044854435          | 40025               |
