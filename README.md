# Epam.Summer.Leshkova.11
Solution for the tasks of the day 11.

Задание 1. Разработать обобщенный класс BinarySearchTree, реализующий бинарное дерево поиска. 
Рассмотреть возможности использования подключаемого интерфейса для реализации отношения порядка. 

Реализовать три способа обхода дерева: прямой (preorder), поперечный (inorder), обратный (postorder): 
для реализации использовать блок-итератор (yield). 
Протестировать разработанный класс BinaryTree<TItem>, используя в качестве аргумента типа следующие типы:

	int (использовать сравнение по умолчанию и подключаемый компаратор)

	string (использовать сравнение по умолчанию и подключаемый компаратор)

	пользовательский класс Book, реализующий интерфейс IComparable (использовать сравнение по умолчанию и подключаемый компаратор)

	пользовательскую структуру Point, не реализующую интерфейс IComparable.

Задание 2. Создать обобщенные классы для представления квадратной, симметрической и диагональной матриц.
Описать в созданных классах событие, которое происходит при изменении элемента матрицы с индексами (i, j). 
Предусмотреть возможность расширения функциональности иерархии классов, добавив возможность для операции сложения двух матриц любого вида.
Создать unit-тесты для тестирования методов разработанного типа.
