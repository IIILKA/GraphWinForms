Приложение работает так: вы вводите функцию и вам выводится примерный график этой функции (без конкретных координат, 
хотя координата (0,0) присутствует на пересечении осей, и эти координаты соблюдаются, графики которые должны проходить 
через центр координат, через него проходят)

Присутствует окошко в которое можно ввести “коэффициент растяжения вдоль оси y”. По умолчанию стоит 1, координата по оси y 
умножается на этот коэффициент.  Если вы введёте кубическую функцию, то на графике вы увидите почти прямую линию, 
т.к. всего за несколько пикселей влево или вправо высота точки выйдет за пределы размеров, которые нам предоставляются 
окошком где этот график выводится, так что в коэффициент вписываем 0.0001, например, и вот у нас красивенькая 
кубическая парабола. Ещё один пример с синусоидой, т.к. её область значений это [-1;1] то для нас это будет 
линия в два пикселя, но если мы введём коэффициент 50 или больше, то выведется красивенькая синусоида.

Из-за того как работает pictureBox появляются артефакты в функции (tg и ctg) за это я сильно извиняюсь, 
возможно я мог бы это пофиксить используя что-нибудь вместо pictureBox из сторонних библиотек, но я хотел сделать всё 
на чистой WinForms.

P.S.
Если что-то выводится некорректно или некрасиво, то поиграетесь с коэффициентам пожалуйста, если программа 
ничего не выводит, такое может быть если вы ввели tg(x*(pi/2)) (tg не существует с таким аргументом), это не баг, это фича), 
просто такого графика не существует.

В дальнейшем я планирую добавить область на которой у нам надо вывести график и цену деления, 
с этими нововведениями приложение станет намного полезнее.
