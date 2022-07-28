data <- read.csv("benchmark-report-swap_1.csv")
plot(type="b", x = data$Tamaño, y = data$Microsegundos, col="red", xlab="tiempo", ylab= "tamaño", xlim = c(0,50000), ylim= c(0,50000) )
data2 <- read.csv("benchmark-report-binary_search_1.csv")
lines(type="b", x=data2$Tamaño, y = data2$Microsegundos, col="blue")
legend(20000,40000,c("swap","binary search"), lwd=c(5,2), col=c("red","blue"), pch=c(15,19), y.intersp=1.5)
title("Insertion Sort O(n²)")
dev.print(svg, file ="plot.svg")



