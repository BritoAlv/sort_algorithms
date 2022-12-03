## Comprendiendo como funcionan algunos algoritmos de sorting.

- insertion_sort:
  
  - swaps
  
  - binary_search

- merge_sort

- heap_sort

- quick_sort

El siguiente gráfico muestra el tiempo de ejecución de cada uno de los algoritmos para ciertos tamaños de $n$. 

<img title="" src="time_plot.png" alt="" data-align="center">

## Mejoras, Bugs e Ideas Para añadirle.

- Añadir instrucciones de como ejecutar el proyecto.

- El gráfico general obtenido a partir de R no parece ser el más adecuado para el objetivo necesitado que es establecer una comparación entre algunos algoritmos de ordenación.

- Organizar las carpetas dentro de una solución general usando sln.

- Faltan más algoritmos de ordenación.

- Aprender a interpretar los resultados de BenchMarkDotNet en el lenguaje R para poder mejorar la visualización de los resultados.

## Pasos Para Añadir Un Nuevo Algoritmo:

```bash
dotnet new console -n sort_name
dotnet sln add sort_name/sort_name.csproj
cd sort_name
dotnet add benchmark/benchmark.csproj reference sort_name/sort_name.csproj
dotnet add sort_name/sort_name.csproj reference assets/assets.csproj
```

## Para ejecutarlo:

Desde la carpeta principal se puede usar el siguiente código:

```bash
dotnet run --project sort_name
```

En otro caso ejecutar desde la carpeta deseada.

## Benchmark:

Para hacerle un benchmark a un algoritmo en específico, comentar los demás y crear una método con el atributo Benchmark, como está hecho con las demas funciones.

## Futuro:

Este repositorio debe ser un template para testear algoritmos de ordenación.
